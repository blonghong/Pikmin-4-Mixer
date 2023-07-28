Imports System.IO
Imports NAudio.Wave
Imports NAudio.Wave.SampleProviders
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class Form1
    Dim FileList As New List(Of String)()
    Public FileDict As Dictionary(Of String, String)
    Private DialogOpenFolder As New CommonOpenFileDialog With {.IsFolderPicker = True, .Title = "Open Folder Containing WwiseAudio WEM Files"}
    Private DialogOpenFiles As New OpenFileDialog With {.Filter = "WwiseAudio WEM files (*.wem)|*.wem", .Title = "Open WwiseAudio WEM Files"}
    Sub SetFormCenter(ParentForm As Form, SubjectForm As Form)
        SubjectForm.SetDesktopLocation(ParentForm.Left + ParentForm.ClientSize.Width / 2 - SubjectForm.ClientSize.Width / 2,
            ParentForm.Top + ParentForm.ClientSize.Height / 2 - SubjectForm.ClientSize.Height / 2)
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
        OpenFiles(Files)
    End Sub

    Sub OpenFiles(Files As String())
        If Files.Length = 0 Then Exit Sub

        ' If only one folder was dropped, use that folder
        If Files.Length = 1 AndAlso Directory.Exists(Files(0)) Then
            Files = Directory.GetFiles(Files(0))
        End If

        ' last file list settings
        If My.Settings.LastFileList Is Nothing Then
            My.Settings.LastFileList = New Specialized.StringCollection()
        End If

        ' Validate all items
        Dim WarningShown = False
        For Each f In Files
            If Not File.Exists(f) Then Continue For
            If Path.GetExtension(f).ToLower() <> ".wav" Then
                If Not WarningShown Then
                    MessageBox.Show("Only WAV files are supported, you can use the converter in the menu bar to convert WEM to WAV.", "Invalid File")
                    WarningShown = True
                End If
                Continue For
            End If
            Dim fn = Path.GetFileNameWithoutExtension(f)
            If fn.EndsWith("_2ch") Then Continue For
            FileList.Add(f)
            My.Settings.LastFileList.Add(f)
            LstFiles.Items.Add(fn)
        Next

        ' save last file list settings
        My.Settings.Save()
    End Sub

    Private Sub MenuEditClearFiles_Click(sender As Object, e As EventArgs) Handles MenuEditClearFiles.Click
        ClearFiles()
    End Sub
    Sub ClearFiles()
        LstFiles.Items.Clear()
        FileList.Clear()
        My.Settings.LastFileList.Clear()
        My.Settings.Save()
    End Sub

    Private Sub BtnGroup_Click(sender As Object, e As EventArgs) Handles BtnGroup.Click
        PnlGroups.Controls.Clear()
        Dim Durations As New List(Of StringDecimalPair)
        For Each f In FileList
            Dim wf As New WaveFileReader(f)
            Durations.Add(New StringDecimalPair With {.Str = f, .Dec = wf.TotalTime.TotalMilliseconds})
            wf.Dispose()
        Next
        Durations.Sort(Function(x, y) x.Dec.CompareTo(y.Dec))

        Dim Groups As New List(Of Dictionary(Of String, Decimal))
        Dim i = 0
        Dim Last = FileList.Count
        While True AndAlso Durations.Count > 0
            Dim CurrentDuration = Durations(i).Dec
            Dim Group As New Dictionary(Of String, Decimal)()
            Dim ToRemove As New List(Of StringDecimalPair)()
            For Each d In Durations
                If d.Dec = CurrentDuration AndAlso Not Group.ContainsKey(d.Str) Then
                    Group.Add(d.Str, d.Dec)
                    ToRemove.Add(d)
                End If
            Next
            For Each d In ToRemove
                Durations.Remove(d)
                Last -= 1
            Next

            Groups.Add(Group)

            i += 1
            If i >= Last Then Exit While
        End While

        LblGroups.Text = Groups.Count.ToString() + " Group" + If(Groups.Count = 1, "", "s")
        For Each Group In Groups
            Dim g = Group.OrderBy(Function(pair)
                                      Dim _f = Path.GetFileNameWithoutExtension(pair.Key)
                                      If _f.EndsWith(".wem") Then _f = _f.Substring(0, _f.Length - 4)
                                      Return Integer.Parse(_f)
                                  End Function)
            If g.Count = 0 Then Continue For
            Dim Lst As New ListBox With {
                .IntegralHeight = False,
                .Size = New Size(120, 80),
                .Font = New Font("Consolas", 8, FontStyle.Regular)
            }
            Lst.Items.Add("Time: " + g(0).Value.ToString())
            For Each f In g
                Lst.Items.Add(Path.GetFileNameWithoutExtension(f.Key))
            Next

            AddHandler Lst.MouseDown,
            Sub(s As Object, eM As MouseEventArgs)
                If eM.Button = MouseButtons.Middle Then
                    Dim str As String = ""
                    For i = 1 To Lst.Items.Count - 1
                        str += Lst.Items(i).ToString() + vbNewLine
                    Next
                    str = str.Trim()
                    Clipboard.SetText(str)
                    MsgBox("Copied List")
                End If
            End Sub


            AddHandler Lst.DoubleClick,
                    Sub()
                        For Each ctrl As Control In Lst.Parent.Controls
                            If TypeOf ctrl IsNot ListBox Then Continue For
                            Dim _Lst As ListBox = ctrl
                            If _Lst Is Lst Then Continue For
                            _Lst.SelectedIndex = -1
                        Next

                        If SoundOut IsNot Nothing Then
                            If SoundOut.PlaybackState = PlaybackState.Playing Then SoundOut.Stop()
                            SoundOut.Dispose()
                            SoundOut = Nothing
                        End If

                        If SoundMix IsNot Nothing Then
                            SoundMix = Nothing
                        End If

                        For Each w In Waves
                            w.Dispose()
                        Next
                        Waves.Clear()
                        WaveNames.Clear()
                        WaveVolumes.Clear()
                        PnlMixer.Controls.Clear()

                        For Each f In g
                            Dim Wave = New AudioFileReader(f.Key)
                            If Wave.WaveFormat.Channels = 1 Then
                                Dim fn = Path.Combine(Path.GetDirectoryName(f.Key), Path.GetFileNameWithoutExtension(f.Key) + "_2ch.wav")
                                If Not File.Exists(fn) Then
                                    Dim stereo = New MonoToStereoSampleProvider(Wave)
                                    WaveFileWriter.CreateWaveFile(fn, stereo.ToWaveProvider())
                                End If
                                Wave = New AudioFileReader(fn)
                            End If

                            Waves.Add(Wave)
                            WaveNames.Add(f.Key)
                            WaveVolumes.Add(100)
                            UpdateVolume(Wave, 100)
                        Next

                        Dim BtnExportMix As New Button With {.Size = New Size(110, 23), .Text = "Export Mix"}
                        AddHandler BtnExportMix.Click,
                        Sub()
                            SoundOut.Stop()
                            BtnStop.Text = "PLAY"
                            For Each Wave In Waves
                                Wave.Position = 0
                            Next

                            Dim OutMixer = New MixingSampleProvider(Waves)
                            Dim SaveDialog As New SaveFileDialog With {.Title = "Save As...", .Filter = "Wave Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3"}
                            If SaveDialog.ShowDialog() = DialogResult.OK Then
                                Dim Ext = Path.GetExtension(SaveDialog.FileName).ToLower()
                                Select Case Ext
                                    Case ".wav"
                                        WaveFileWriter.CreateWaveFile16(SaveDialog.FileName, OutMixer)
                                    Case ".mp3" '192k
                                        MediaFoundationEncoder.EncodeToMp3(OutMixer.ToWaveProvider(), SaveDialog.FileName)
                                End Select
                            End If
                        End Sub
                        PnlMixer.Controls.Add(BtnExportMix)

                        Dim BtnMuteAll As New Button With {.Size = New Size(110, 23), .Text = "Mute All"}
                        AddHandler BtnMuteAll.Click,
                        Sub()
                            For Each ctrl In BtnMuteAll.Parent.Controls
                                If TypeOf ctrl IsNot TrackBar Then Continue For
                                Dim Trk As TrackBar = ctrl
                                Trk.Value = 0
                            Next
                        End Sub
                        PnlMixer.Controls.Add(BtnMuteAll)

                        For i = 0 To Waves.Count - 1
                            Dim WAV = Waves(i)
                            Dim f = WaveNames(i)
                            Dim f_ = Path.GetFileNameWithoutExtension(f)
                            If f_.EndsWith(".wem") Then f_ = f_.Substring(0, f_.Length - 4)
                            Dim Index = i

                            Dim Lbl As New Label With {.AutoSize = True, .Text = f_}
                            If FileDict.Keys.Contains(f_) Then
                                Lbl.Text = FileDict(f_)
                            End If
                            AddHandler Lbl.DoubleClick,
                            Sub()
                                Dim NewName = InputBox("What should we remember this file as? Leave blank to cancel.")
                                If String.IsNullOrWhiteSpace(NewName) Then Exit Sub
                                If Not FileDict.Keys.Contains(f) Then
                                    FileDict.Add(f_, NewName)
                                Else
                                    FileDict(f_) = NewName
                                End If

                                Lbl.Text = FileDict(f_)
                                SaveDict()
                            End Sub
                            Dim VolSlider As New TrackBar With {
                                .Size = New Size(PnlMixer.Width - 10 - SystemInformation.VerticalScrollBarWidth, 45),
                                .Maximum = 100,
                                .Minimum = 0,
                                .Value = 100,
                                .TickFrequency = 10
                            }
                            AddHandler VolSlider.ValueChanged,
                            Sub()
                                WaveVolumes(Index) = VolSlider.Value
                                UpdateVolume(WAV, WaveVolumes(Index))
                            End Sub

                            PnlMixer.Controls.AddRange({Lbl, VolSlider})
                        Next

                        SoundMix = NewMixer(Waves)
                        SoundOut = New DirectSoundOut()
                        SoundOut.Init(SoundMix)
                        SoundOut.Play()
                    End Sub

            PnlGroups.Controls.Add(Lst)
        Next
    End Sub
    Function NewMixer(Wavs As IEnumerable(Of AudioFileReader)) As MixingSampleProvider
        Dim Mixer = New MixingSampleProvider(Wavs)
        AddHandler Mixer.MixerInputEnded,
                    Sub()
                        For Each Wave In Wavs
                            Wave.Position = 0
                        Next
                        Mixer = NewMixer(Wavs)
                        SoundOut.Init(Mixer)
                        SoundOut.Play()
                    End Sub
        Return Mixer
    End Function
    Private WaveNames As New List(Of String)()
    Private Waves As New List(Of AudioFileReader)()
    Private WaveVolumes As New List(Of Integer)
    Private SoundMix As MixingSampleProvider
    Private SoundOut As DirectSoundOut

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
                    My.Settings.LastFileList.RemoveAt(ii)
                    LstFiles.Items.RemoveAt(ii)
                End If
                Offset += 1
            Next
        End If
    End Sub
    Sub UpdateVolume(WAV As AudioFileReader, Volume As Integer)
        WAV.Volume = Math.Min(1, Math.Max(0, (Volume / 100) * (TrkMaster.Value / 100)))
    End Sub
    Private Sub TrkMaster_ValueChanged(sender As Object, e As EventArgs) Handles TrkMaster.ValueChanged
        For i = 0 To Waves.Count - 1
            UpdateVolume(Waves(i), WaveVolumes(i))
        Next
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        If SoundOut IsNot Nothing Then
            If BtnStop.Text = "PAUSE" Then
                If SoundOut.PlaybackState = PlaybackState.Playing Then SoundOut.Pause()
                BtnStop.Text = "PLAY"
            ElseIf BtnStop.Text = "PLAY" Then
                If SoundOut.PlaybackState = PlaybackState.Paused Then SoundOut.Play()
                BtnStop.Text = "PAUSE"
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(My.Settings.FileDict)
        If FileDict Is Nothing Then
            FileDict = New Dictionary(Of String, String)()
        End If
    End Sub

    Sub SaveDict()
        My.Settings.FileDict = JsonConvert.SerializeObject(FileDict)
        My.Settings.Save()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveDict()
    End Sub
    Private Sub ConvertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToolStripMenuItem.Click
        SetFormCenter(Me, FormConverter)
        FormConverter.ShowDialog()
    End Sub

    Private Sub WhatDoIDoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhatDoIDoToolStripMenuItem.Click
        MessageBox.Show("Drag and drop WAV or WEM files (presumably from Pikmin 4) onto the left-most list box.

Then click the group button to group based on duration.

Double-click any of the groups to start listening to those groups all together.
A mixer shows on the right to adjust volume of layers, and even export your mix.",
"What Do I Do?")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Pikmin 4 Sound Sorter
Version " + Application.ProductVersion + "

A simple GUI that takes your .WAVs, sorts them by duration, and lets you mix them.

Made by Jimble",
"About")
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFolderToolStripMenuItem.Click
        If DialogOpenFolder.ShowDialog() = CommonFileDialogResult.Ok Then
            OpenFiles({DialogOpenFolder.FileName})
        End If
    End Sub

    Private Sub OpenFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFilesToolStripMenuItem.Click
        If DialogOpenFiles.ShowDialog() = CommonFileDialogResult.Ok Then
            OpenFiles(DialogOpenFiles.FileNames)
        End If
    End Sub

    Private Sub SaveDictionaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDictionaryToolStripMenuItem.Click
        SetFormCenter(Me, Dictionary)
        Dictionary.ShowDialog()
    End Sub

    Private Sub OpenLastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenLastToolStripMenuItem.Click
        If My.Settings.LastFileList Is Nothing Then Exit Sub
        Dim Files = New List(Of String)()
        For Each f In My.Settings.LastFileList
            Files.Add(f)
        Next
        ClearFiles()
        OpenFiles(Files.ToArray())
    End Sub
End Class

Public Class StringDecimalPair
    Property Str As String
    Property Dec As Decimal
End Class
