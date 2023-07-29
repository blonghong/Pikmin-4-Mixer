Imports System.ComponentModel
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports NAudio.Wave

Public Class FormConverter
    Private DialogOutput As New CommonOpenFileDialog With {.IsFolderPicker = True, .Title = "Select Output Directory"}
    Private FileList As New List(Of String)()
    Private RequiredFiles =
    {
        "avcodec-vgmstream-59.dll",
        "avformat-vgmstream-59.dll",
        "avutil-vgmstream-57.dll",
        "COPYING",
        "libatrac9.dll",
        "libcelt-0061.dll",
        "libcelt-0110.dll",
        "libg719_decode.dll",
        "libmpg123-0.dll",
        "libspeex-1.dll",
        "libvorbis.dll",
        "swresample-vgmstream-4.dll",
        "vgmstream-cli.exe"
    }
    Private Sub LinkVgmstream_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkVgmstream.LinkClicked
        Process.Start("https://github.com/vgmstream/vgmstream")
    End Sub

    Private Sub BtnBrowseOutput_Click(sender As Object, e As EventArgs) Handles BtnBrowseOutput.Click
        If DialogOutput.ShowDialog() = CommonFileDialogResult.Ok Then
            TxtOutput.Text = DialogOutput.FileName
        End If
    End Sub

    Private Sub FormConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JobsRunning = False
        TryingToClose = False
        BtnConvert.Enabled = True
        TxtTerminal.Text = ""
    End Sub


    Private Sub LstFiles_DragEnter(sender As Object, e As DragEventArgs) Handles LstFiles.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            Exit Sub
        End If

        e.Effect = DragDropEffects.None
    End Sub

    Private Sub LstFiles_DragDrop(sender As Object, e As DragEventArgs) Handles LstFiles.DragDrop
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Exit Sub
        Dim Files As String() = e.Data.GetData(DataFormats.FileDrop)
        If Files.Length = 0 Then Exit Sub

        ' If only one folder was dropped, use that folder
        If Files.Length = 1 AndAlso Directory.Exists(Files(0)) Then
            Files = Directory.GetFiles(Files(0))
        End If

        ' Validate all items
        For Each f In Files
            If Not File.Exists(f) Then Continue For
            If Path.GetExtension(f).ToLower() <> ".wem" Then Continue For
            LabelDropFiles.Visible = False
            FileList.Add(f)
            LstFiles.Items.Add(Path.GetFileName(f))
        Next

        If FileList.Count = 0 Then
            MessageBox.Show("Please only drop .WEM files (or a folder containing them).", "Invalid Type")
            Exit Sub
        End If

        ' Set the output directory automatically
        TxtOutput.Text = Path.Combine(Path.GetDirectoryName(FileList(0)), "converted")
        DialogOutput.DefaultDirectory = Path.GetDirectoryName(FileList(0))
    End Sub
    Private Sub LstFiles_KeyDown(sender As Object, e As KeyEventArgs) Handles LstFiles.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim ToDelete = New List(Of Integer)()
            For Each i In LstFiles.SelectedIndices
                ToDelete.Add(i)
            Next
            ToDelete.Sort()
            Dim Offset = 0
            For Each i In ToDelete
                Dim ii = i - Offset
                If ii > -1 AndAlso ii < LstFiles.Items.Count Then
                    FileList.RemoveAt(ii)
                    LstFiles.Items.RemoveAt(ii)
                End If
                Offset += 1
            Next

            If LstFiles.Items.Count = 0 Then
                LabelDropFiles.Visible = True
            End If
        End If

        If (e.Control) AndAlso (e.KeyCode And Not Keys.Modifiers) = Keys.A Then
            For i = 0 To LstFiles.Items.Count - 1
                LstFiles.SetSelected(i, True)
            Next
        End If
    End Sub

    Dim JobsRunning = False
    Dim TryingToClose = False
    Dim bgw As BackgroundWorker
    Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
        ' Abort the mission
        If BtnConvert.Text = "Stop" Then
            BtnConvert.Enabled = False
            If bgw IsNot Nothing AndAlso bgw.IsBusy Then
                bgw.CancelAsync()
            End If
            Exit Sub
        End If

        ' Validate list
        If FileList.Count = 0 Then Exit Sub

        ' Validate required files
        Dim vgmstream = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vgmstream")
        For Each f In RequiredFiles
            f = Path.Combine(vgmstream, f)
            If Not File.Exists(f) Then
                ' Could add a downloader at some point, too lazy right now.
                MessageBox.Show("Missing important files for vgmstream. Place the latest vgmstream-cli build in a folder called vgmstream located in the same directory as this application.", "Required Files Missing")
                Exit Sub
            End If
        Next

        If Not Directory.Exists(TxtOutput.Text) Then
            Directory.CreateDirectory(TxtOutput.Text)
        End If

        Dim proc As New CustomProcess With {.EnableRaisingEvents = True, .StartInfo = New ProcessStartInfo With {
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .UseShellExecute = False,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .WorkingDirectory = vgmstream,
            .FileName = """" + Path.Combine(vgmstream, "vgmstream-cli.exe") + """"
        }}

        bgw = New BackgroundWorker With {.WorkerSupportsCancellation = True}
        AddHandler bgw.DoWork,
            Sub(s As Object, e2 As DoWorkEventArgs)
                For Each f In FileList
                    If bgw.CancellationPending Then
                        e2.Cancel = True
                        Exit Sub
                    End If
                    Dim fout = Path.Combine(TxtOutput.Text, Path.GetFileNameWithoutExtension(f) + ".wav")
                    proc.StartInfo.Arguments = String.Format("-o ""{0}"" ""{1}"" -D 2", fout, f)
                    proc.Start()
                    proc.WaitForExit()
                    Invoke(
                    Sub()
                        TxtTerminal.Text += proc.StandardOutput.ReadToEnd() + vbNewLine
                        TxtTerminal.Text += proc.StandardError.ReadToEnd() + vbNewLine
                        TxtTerminal.SelectionLength = 0
                        TxtTerminal.SelectionStart = TxtTerminal.Text.Length
                        TxtTerminal.ScrollToCaret()
                    End Sub)
                Next
            End Sub

        AddHandler bgw.RunWorkerCompleted,
        Sub(s As Object, e2 As RunWorkerCompletedEventArgs)
            JobsRunning = False
            BtnConvert.Text = "Convert"
            BtnConvert.Enabled = True

            If e2.Cancelled Then
                If TryingToClose Then
                    Close()
                    Exit Sub
                End If
                TxtTerminal.Text += "== Aborted by User =="
            Else
                TxtTerminal.Text += " == Completed =="
            End If
            TxtTerminal.SelectionLength = 0
            TxtTerminal.SelectionStart = TxtTerminal.Text.Length
            TxtTerminal.ScrollToCaret()
        End Sub

        JobsRunning = True
        BtnConvert.Text = "Stop"
        bgw.RunWorkerAsync()
    End Sub

    Private Sub FormConverter_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If JobsRunning Then
            If bgw IsNot Nothing AndAlso bgw.IsBusy Then
                TryingToClose = True
                bgw.CancelAsync()
                e.Cancel = True
            End If
        End If
    End Sub
End Class