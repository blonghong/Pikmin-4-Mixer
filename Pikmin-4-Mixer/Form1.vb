Imports System.IO
Imports NAudio.Wave
Imports NAudio.Wave.SampleProviders
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Management
Imports NAudio.MediaFoundation
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System
Imports System.Windows.Documents
Imports Microsoft.VisualBasic.Devices
Imports System.Windows.Media.Converters

Public Class Form1
    ' Lists
    Dim FileList As New List(Of String)()
    Dim GroupList As Dictionary(Of Integer, List(Of String))
    ' Dictionaries
    Public FileDict As Dictionary(Of String, String)
    Public GroupNames As Dictionary(Of Integer, String)
    Public UserGroups As Dictionary(Of String, List(Of String))
    ' Dialogs
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
        AddFiles(Files)
    End Sub

    Sub AddFiles(Files As String())
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
            Dim fn = GetFilenameWithoutExtensions(f)
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
    Function GetDurationGroups() As Dictionary(Of Integer, List(Of String))
        ' Get list of durations
        Dim Durations As New List(Of StringIntegerPair)
        For Each f In FileList
            Dim wf As New WaveFileReader(f)
            Durations.Add(New StringIntegerPair With {.Str = f, .Int = wf.TotalTime.TotalMilliseconds})
            wf.Dispose()
        Next
        ' Sort durations
        Durations.Sort(Function(x, y) x.Int.CompareTo(y.Int))

        Dim Groups As New Dictionary(Of Integer, List(Of String))
        Dim i = 0
        Dim Last = FileList.Count
        While True AndAlso Durations.Count > 0
            Dim CurrentDuration = Durations(i).Int
            Dim Items As New List(Of String)()
            ' Get items
            Dim ToRemove As New List(Of StringIntegerPair)()
            For Each d In Durations
                If d.Int = CurrentDuration AndAlso Not Items.Contains(d.Str) Then
                    Items.Add(d.Str)
                    ToRemove.Add(d)
                End If
            Next
            ' Remove them from the durations list
            For Each d In ToRemove
                Durations.Remove(d)
                Last -= 1
            Next
            ' Order items by filename
            Items = Items.OrderBy(
                Function(item)
                    Dim _f = GetFilenameWithoutExtensions(item)
                    Return Integer.Parse(_f)
                End Function).ToList()
            ' Add to group dictionary
            Groups.Add(CurrentDuration, Items)
            ' Inc or exit
            i += 1
            If i >= Last Then Exit While
        End While

        Return Groups
    End Function
    Dim GroupItemsText As New List(Of String)()
    Function GetDefaultGroupName(GroupKey As Integer) As String
        Dim GroupName = $"Group {GroupList.Keys.ToList().IndexOf(GroupKey) + 1} | {GroupKey}ms"
        If GroupNames.ContainsKey(GroupKey) Then
            GroupName = $"{GroupNames(GroupKey)}"
        End If
        Return GroupName
    End Function
    Sub LoadGroups()
        LstGroups.Items.Clear()

        GroupList = GetDurationGroups()
        LblGroups.Text = $"{GroupList.Count} Group{If(GroupList.Count = 1, "", "s")}"
        GroupItemsText.Clear()

        For Each G In GroupList
            LstGroups.Items.Add("")
            GroupItemsText.Add(GetDefaultGroupName(G.Key))
        Next

        For Each G In UserGroups
            LstGroups.Items.Add("")
            GroupItemsText.Add($"Custom: {G.Key}")
        Next
    End Sub

    Dim CurrentlyPlaying = -1
    Sub LoadSelectedGroup()
        CurrentlyPlaying = LstGroups.SelectedIndex
        LstGroups.Invalidate()

        Dim G = GetSelectedGroup()
        If G Is Nothing Then Exit Sub
        If G.Count = 0 Then Exit Sub

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

        For Each f In G
            Dim Wave = New AudioFileReader(f)
            If Wave.WaveFormat.Channels = 1 Then
                Dim fn = Path.Combine(Path.GetDirectoryName(f), GetFilenameWithoutExtensions(f) + "_2ch.wav")
                If Not File.Exists(fn) Then
                    Dim stereo = New MonoToStereoSampleProvider(Wave)
                    WaveFileWriter.CreateWaveFile(fn, stereo.ToWaveProvider())
                End If
                Wave = New AudioFileReader(fn)
            End If

            Waves.Add(Wave)
            WaveNames.Add(f)
            WaveVolumes.Add(100)
            UpdateVolume(Wave, 100)
        Next

        For i = 0 To Waves.Count - 1
            Dim WAV = Waves(i)
            Dim f = WaveNames(i)
            Dim f_ = GetFilenameWithoutExtensions(f)
            Dim Index = i

            Dim Pnl As New Panel With {
                .Size = New Size(16 + 20, PnlMixer.Height - 10 - SystemInformation.HorizontalScrollBarHeight),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom,
                .BorderStyle = BorderStyle.Fixed3D
            }

            Dim Lbl As New VerticalLabel With {
                .Location = New Point(0, 20),
                .Size = New Size(16, Pnl.Height - 20),
                .Font = New Font("Trebuchet MS", 10, FontStyle.Bold Or FontStyle.Italic),
                .Text = f_,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom
            }
            If FileDict.Keys.Contains(f_) Then
                Lbl.Text = FileDict(f_)
            End If
            AddHandler Lbl.DoubleClick,
            Sub()
                Dim NewName = InputBox("What should we remember this file as? Leave blank to cancel.")
                If String.IsNullOrWhiteSpace(NewName) Then Exit Sub
                If Not FileDict.Keys.Contains(f_) Then
                    FileDict.Add(f_, NewName)
                Else
                    FileDict(f_) = NewName
                End If

                Lbl.Text = FileDict(f_)
                SaveDict()
            End Sub
            Dim Mute As New CheckBox With {
                .AutoSize = False,
                .Location = New Point(Pnl.Width / 2 - 7, 0),
                .Size = New Size(Pnl.Width, 20),
                .Text = "",
                .Checked = True
            }
            Dim VolSlider As New TrackBar With {
                .AutoSize = False,
                .Location = New Point(16, 20),
                .Orientation = Orientation.Vertical,
                .TickStyle = TickStyle.None,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom,
                .Size = New Size(20, Pnl.Height - 20),
                .Maximum = 100,
                .Minimum = 0,
                .Value = 100,
                .TickFrequency = 10
            }
            AddHandler Mute.CheckedChanged,
            Sub()
                If Mute.Checked Then
                    WaveVolumes(Index) = VolSlider.Value
                Else
                    WaveVolumes(Index) = 0
                End If
                UpdateVolume(WAV, WaveVolumes(Index))
            End Sub
            AddHandler Mute.MouseDown,
            Sub(s As Object, e2 As MouseEventArgs)
                If e2.Button = MouseButtons.Right Then
                    Dim IsOnlyChecked = True
                    Dim MuteButtons = New List(Of CheckBox)()
                    For Each ctrl In PnlMixer.Controls
                        If TypeOf ctrl IsNot Panel Then Continue For
                        For Each c In DirectCast(ctrl, Panel).Controls
                            If TypeOf c IsNot CheckBox Then Continue For
                            If c IsNot Mute Then
                                MuteButtons.Add(c)
                                If DirectCast(c, CheckBox).Checked Then
                                    IsOnlyChecked = False
                                End If
                            Else
                                If Not DirectCast(c, CheckBox).Checked Then
                                    IsOnlyChecked = False
                                    Mute.Checked = True
                                End If
                            End If
                        Next
                    Next
                    For Each chk In MuteButtons
                        chk.Checked = IsOnlyChecked
                    Next
                End If
            End Sub
            AddHandler VolSlider.ValueChanged,
            Sub()
                If Mute.Checked Then
                    WaveVolumes(Index) = VolSlider.Value
                    UpdateVolume(WAV, WaveVolumes(Index))
                End If
            End Sub

            Pnl.Controls.AddRange({Lbl, Mute, VolSlider})
            PnlMixer.Controls.Add(Pnl)
        Next

        SoundMix = NewMixer(Waves)
        SoundOut = New DirectSoundOut()
        SoundOut.Init(SoundMix)
        SoundOut.Play()
    End Sub
    Private Sub LstGroups_DoubleClick(sender As Object, e As EventArgs) Handles LstGroups.DoubleClick
        LoadSelectedGroup()
    End Sub
    Dim UpdatingList = False

    Private Sub LstGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstGroups.SelectedIndexChanged
        If LstGroups.SelectedIndex = -1 Then
            PnlGroupInfo.Visible = False
            Exit Sub
        End If

        PnlGroupInfo.Visible = True
        LstGroupContents.Items.Clear()
        Dim g = GetSelectedGroup()
        If g Is Nothing Then
            MessageBox.Show("Failed to load items in this group, nothing was returned.", "Error")
            Exit Sub
        End If
        LstGroupContents.Items.AddRange(g.Select(Function(item) GetFilenameWithoutExtensions(item)).ToArray())
        Dim GN = GetSelectedGroupName()
        UpdatingList = True
        TxtGroupName.Text = GN
        UpdatingList = False
        LblGroupName.Text = $"Group Name: {GN}"
    End Sub

    Private Sub BtnGroup_Click(sender As Object, e As EventArgs) Handles BtnGroup.Click
        LstGroups.Items.Clear()
        LoadGroups()
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
        If FileDict Is Nothing Then FileDict = New Dictionary(Of String, String)()
        UserGroups = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of String)))(My.Settings.UserGroups)
        If UserGroups Is Nothing Then UserGroups = New Dictionary(Of String, List(Of String))()
        GroupNames = JsonConvert.DeserializeObject(Of Dictionary(Of Integer, String))(My.Settings.GroupNames)
        If GroupNames Is Nothing Then GroupNames = New Dictionary(Of Integer, String)()
    End Sub

    Sub SaveDict()
        My.Settings.FileDict = JsonConvert.SerializeObject(FileDict)
        My.Settings.Save()
    End Sub
    Sub SaveGroups()
        My.Settings.UserGroups = JsonConvert.SerializeObject(UserGroups)
        My.Settings.GroupNames = JsonConvert.SerializeObject(GroupNames)
        My.Settings.Save()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveDict()
        SaveGroups()
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
            AddFiles({DialogOpenFolder.FileName})
        End If
    End Sub

    Private Sub OpenFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFilesToolStripMenuItem.Click
        If DialogOpenFiles.ShowDialog() = CommonFileDialogResult.Ok Then
            AddFiles(DialogOpenFiles.FileNames)
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
        AddFiles(Files.ToArray())
    End Sub

    Private Sub PnlMixer_Layout(sender As Object, e As LayoutEventArgs) Handles PnlMixer.Layout
        For Each c As Control In PnlMixer.Controls
            c.Height = PnlMixer.Height - 10 - If(PnlMixer.HorizontalScroll.Visible, SystemInformation.HorizontalScrollBarHeight, 0)
        Next
    End Sub
    Dim SaveDialog As New SaveFileDialog With {.Title = "Save As...", .Filter = "Wave Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3",
        .RestoreDirectory = True}
    Private Sub ExportCurrentMixToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportCurrentMixToolStripMenuItem.Click
        If Waves Is Nothing OrElse Waves.Count = 0 Then
            MessageBox.Show("You need to start playing/mixing a group to export.", "Export Mix")
            Exit Sub
        End If

        Dim NewWaves = New List(Of AudioFileReader)()
        For Each w In Waves
            Dim a = New AudioFileReader(w.FileName)
            a.Volume = w.Volume
            NewWaves.Add(a)
        Next
        Dim OutMixer = New MixingSampleProvider(NewWaves)

        If SaveDialog.ShowDialog() = DialogResult.OK Then
            Dim Ext = Path.GetExtension(SaveDialog.FileName).ToLower()
            Select Case Ext
                Case ".wav"
                    WaveFileWriter.CreateWaveFile16(SaveDialog.FileName, OutMixer)
                Case ".mp3" '192k
                    MediaFoundationApi.Startup()
                    MediaFoundationEncoder.EncodeToMp3(OutMixer.ToWaveProvider(), SaveDialog.FileName)
                    MediaFoundationApi.Shutdown()
            End Select
        End If
    End Sub

    Private Sub LstGroups_DrawItem(sender As Object, e As DrawItemEventArgs) Handles LstGroups.DrawItem
        e.DrawBackground()
        If e.Index = -1 Then Exit Sub
        Dim ForeBrush = Brushes.Black

        If e.Index = CurrentlyPlaying Then
            Using BackBrush As New SolidBrush(Color.Black)
                e.Graphics.FillRectangle(BackBrush, e.Bounds)
            End Using
            ForeBrush = Brushes.White
        End If


        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ForeBrush = Brushes.White
        End If

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        If e.Index < GroupItemsText.Count Then
            e.Graphics.DrawString(GroupItemsText(e.Index), LstGroups.Font, ForeBrush, New PointF(e.Bounds.Left, e.Bounds.Top))
        Else
            e.Graphics.DrawString("###ERROR###", LstGroups.Font, Brushes.Red, New PointF(e.Bounds.Left, e.Bounds.Top))
        End If

        e.DrawFocusRectangle()
    End Sub

    Private Sub BtnGroupCopy_Click(sender As Object, e As EventArgs) Handles BtnGroupCopy.Click
        CmsGroupCopy.Show(BtnGroupCopy, BtnGroupCopy.PointToClient(MousePosition))
    End Sub

    Private Sub WithWEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithWEMToolStripMenuItem.Click
        Dim str = ""
        Dim i = 0
        For Each s In GetSelectedItemsInGroup()
            str += GetFilenameWithoutExtensions(s) + ".wem"
            If i < LstGroupContents.Items.Count - 1 Then
                str += vbNewLine
            End If
            i += 1
        Next
        If Not String.IsNullOrWhiteSpace(str) Then
            Clipboard.SetText(str)
        End If
    End Sub

    Private Sub WithoutWEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithoutWEMToolStripMenuItem.Click
        Dim str = ""
        Dim i = 0
        For Each s In GetSelectedItemsInGroup()
            str += GetFilenameWithoutExtensions(s)
            If i < LstGroupContents.Items.Count - 1 Then
                str += vbNewLine
            End If
            i += 1
        Next
        If Not String.IsNullOrWhiteSpace(str) Then
            Clipboard.SetText(str)
        End If
    End Sub
    Function GetFullNameFromFileList(s As String) As String
        For Each f In FileList
            Dim f_ = GetFilenameWithoutExtensions(f)
            If f_ = s Then
                Return f
            End If
        Next
        Return s
    End Function
    Function GetSelectedGroup() As List(Of String)
        If LstGroups.SelectedIndex = -1 Then Return Nothing
        If LstGroups.SelectedIndex >= GroupList.Count Then
            Dim UserIndex = LstGroups.SelectedIndex - GroupList.Count
            If UserGroups.Count <= UserIndex Then Return Nothing
            Return UserGroups.Values(UserIndex).Select(Function(item) GetFullNameFromFileList(item)).ToList()
        End If
        Return GroupList.Values(LstGroups.SelectedIndex)
    End Function
    Function GetSelectedGroupName() As String
        If LstGroups.SelectedIndex = -1 Then Return Nothing
        If LstGroups.SelectedIndex >= GroupList.Count Then
            Dim UserIndex = LstGroups.SelectedIndex - GroupList.Count
            If UserGroups.Count <= UserIndex Then Return Nothing
            Return UserGroups.Keys(UserIndex)
        End If
        Dim key = GroupList.Keys(LstGroups.SelectedIndex)
        If GroupNames.ContainsKey(key) Then
            Return GroupNames(key)
        Else
            Return GetDefaultGroupName(key)
        End If
    End Function
    Function IsCustomGroup() As Boolean
        If LstGroups.SelectedIndex >= GroupList.Count Then
            Return True
        End If
        Return False
    End Function
    Function GetSelectedItemsInGroup() As List(Of String)
        Dim g = GetSelectedGroup()
        If g Is Nothing Then Return Nothing
        Dim lst As New List(Of String)()
        For Each ShortName In LstGroupContents.SelectedItems
            For Each FullName In g
                If FullName.Contains(ShortName) Then
                    lst.Add(FullName)
                    Continue For
                End If
            Next
        Next
        Return lst
    End Function
    Function GetFilenameWithoutExtensions(s As String) As String
        Dim f = Path.GetFileNameWithoutExtension(s)
        While f.ToLower().EndsWith(".wav") OrElse f.ToLower().EndsWith(".wem")
            f = f.Substring(0, f.Length - 4)
        End While
        Return f
    End Function
    Private Sub BtnGroupAddExisting_Click(sender As Object, e As EventArgs) Handles BtnGroupAddExisting.Click
        If LstGroupContents.SelectedIndex = -1 Then Exit Sub

        If UserGroups.Count = 0 Then
            NoGroupsToolStripMenuItem.Visible = True
        Else
            NoGroupsToolStripMenuItem.Visible = False
            While CmsUserGroups.Items.Count > 1
                CmsUserGroups.Items.RemoveAt(1)
            End While
            For Each Group In UserGroups
                Dim g = Group.Key
                Dim btn = New ToolStripMenuItem With {
                    .Text = g
                }

                AddHandler btn.Click,
                    Sub()
                        Dim items = GetSelectedItemsInGroup()
                        If items Is Nothing Then
                            MessageBox.Show("Failed to add items to group, none were selected.", "Error")
                            Exit Sub
                        End If
                        For Each s In items
                            Dim ShortName = GetFilenameWithoutExtensions(s)
                            If Not UserGroups(g).Contains(ShortName) Then
                                UserGroups(g).Add(ShortName)
                            End If
                        Next
                    End Sub

                CmsUserGroups.Items.Add(btn)
            Next
        End If
        CmsUserGroups.Show(BtnGroupCopy, BtnGroupCopy.PointToClient(MousePosition))
    End Sub

    Private Sub BtnGroupAddNew_Click(sender As Object, e As EventArgs) Handles BtnGroupAddNew.Click
        If LstGroupContents.SelectedIndex = -1 Then Exit Sub

        Dim GroupName = ""
        Do
            GroupName = InputBox("Enter the name of the new group. Leave blank to cancel.", "Add to New Group")
        Loop Until Not UserGroups.Select(Function(dict) dict.Key).Contains(GroupName) OrElse String.IsNullOrWhiteSpace(GroupName)

        If String.IsNullOrWhiteSpace(GroupName) Then Exit Sub

        Dim Selected = GetSelectedItemsInGroup().Select(Function(item) GetFilenameWithoutExtensions(item)).ToList()
        If Selected Is Nothing Then
            MessageBox.Show("Failed to add items to new group, none were selected.", "Error")
            Exit Sub
        End If
        UserGroups.Add(GroupName, Selected)
        LstGroups.Items.Add("")
        GroupItemsText.Add($"Custom: {GroupName}")
    End Sub

    Private Sub TxtGroupName_TextChanged(sender As Object, e As EventArgs) Handles TxtGroupName.TextChanged
        If UpdatingList Then Exit Sub

        If Not String.IsNullOrWhiteSpace(TxtGroupName.Text) AndAlso Not GroupNames.ContainsValue(TxtGroupName.Text) AndAlso Not UserGroups.ContainsKey(TxtGroupName.Text) Then
            If IsCustomGroup() Then
                Dim key = UserGroups.Keys(LstGroups.SelectedIndex - GroupList.Count)
                DictionaryRenameKey(UserGroups, key, TxtGroupName.Text)
                LblGroupName.Text = $"Group Name: {TxtGroupName.Text}"
                GroupItemsText(LstGroups.SelectedIndex) = $"Custom: {TxtGroupName.Text}"
                LstGroups.Invalidate()
            Else
                'the groupNames keys use the same duration as groupList keys
                Dim key = GroupList.Keys(LstGroups.SelectedIndex)
                If GroupNames.ContainsKey(key) Then
                    GroupNames(key) = TxtGroupName.Text
                Else
                    GroupNames.Add(key, TxtGroupName.Text)
                End If
                LblGroupName.Text = $"Group Name: {TxtGroupName.Text}"
                GroupItemsText(LstGroups.SelectedIndex) = TxtGroupName.Text
                LstGroups.Invalidate()
            End If
        Else
            If Not IsCustomGroup() Then
                Dim key = GroupList.Keys(LstGroups.SelectedIndex)
                If GroupNames.ContainsKey(key) Then
                    GroupNames.Remove(key)
                End If
                Dim gn = GetDefaultGroupName(key)
                LblGroupName.Text = $"Group Name: {gn}"
                GroupItemsText(LstGroups.SelectedIndex) = gn
                LstGroups.Invalidate()
            End If
        End If
    End Sub

    Sub DictionaryRenameKey(Of TKey, TValue)(dic As Dictionary(Of TKey, TValue), FromKey As TKey, ToKey As TKey)
        Dim value As TValue = dic(FromKey)
        dic.Remove(FromKey)
        dic.Add(ToKey, value)
    End Sub

    Private Sub LstGroups_KeyDown(sender As Object, e As KeyEventArgs) Handles LstGroups.KeyDown
        If e.KeyCode = Keys.Delete AndAlso IsCustomGroup() Then
            Dim key = UserGroups.Keys(LstGroups.SelectedIndex - GroupList.Count)
            UserGroups.Remove(key)
            GroupItemsText.RemoveAt(LstGroups.SelectedIndex)
            LstGroups.Items.RemoveAt(LstGroups.SelectedIndex)
        End If
    End Sub
End Class

Public Class StringIntegerPair
    Property Str As String
    Property Int As Integer
End Class
