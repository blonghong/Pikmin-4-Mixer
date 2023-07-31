<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LstFiles = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportCurrentMixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEditClearFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhatDoIDoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGroup = New System.Windows.Forms.Button()
        Me.LblGroups = New System.Windows.Forms.Label()
        Me.PnlMixer = New System.Windows.Forms.FlowLayoutPanel()
        Me.TrkMaster = New System.Windows.Forms.TrackBar()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BetterSplitContainer1 = New Pikmin4Mixer.BetterSplitContainer()
        Me.BetterSplitContainer3 = New Pikmin4Mixer.BetterSplitContainer()
        Me.LstGroups = New System.Windows.Forms.ListBox()
        Me.PnlGroupInfo = New System.Windows.Forms.Panel()
        Me.LblGroupName = New System.Windows.Forms.Label()
        Me.BtnGroupAddExisting = New System.Windows.Forms.Button()
        Me.BtnGroupAddNew = New System.Windows.Forms.Button()
        Me.BtnGroupCopy = New System.Windows.Forms.Button()
        Me.LstGroupContents = New System.Windows.Forms.ListBox()
        Me.TxtGroupName = New System.Windows.Forms.TextBox()
        Me.VerticalLabel1 = New Pikmin4Mixer.VerticalLabel()
        Me.BetterSplitContainer2 = New Pikmin4Mixer.BetterSplitContainer()
        Me.CmsGroupCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WithWEMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithoutWEMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmsUserGroups = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NoGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrkMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetterSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BetterSplitContainer1.Panel1.SuspendLayout()
        Me.BetterSplitContainer1.Panel2.SuspendLayout()
        Me.BetterSplitContainer1.SuspendLayout()
        CType(Me.BetterSplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BetterSplitContainer3.Panel1.SuspendLayout()
        Me.BetterSplitContainer3.Panel2.SuspendLayout()
        Me.BetterSplitContainer3.SuspendLayout()
        Me.PnlGroupInfo.SuspendLayout()
        CType(Me.BetterSplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BetterSplitContainer2.Panel1.SuspendLayout()
        Me.BetterSplitContainer2.Panel2.SuspendLayout()
        Me.BetterSplitContainer2.SuspendLayout()
        Me.CmsGroupCopy.SuspendLayout()
        Me.CmsUserGroups.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstFiles
        '
        Me.LstFiles.AllowDrop = True
        Me.LstFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstFiles.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstFiles.FormattingEnabled = True
        Me.LstFiles.IntegralHeight = False
        Me.LstFiles.Location = New System.Drawing.Point(0, 0)
        Me.LstFiles.Name = "LstFiles"
        Me.LstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstFiles.Size = New System.Drawing.Size(97, 582)
        Me.LstFiles.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ConvertToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(957, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFilesToolStripMenuItem, Me.OpenFolderToolStripMenuItem, Me.OpenLastToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportCurrentMixToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveDictionaryToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenFilesToolStripMenuItem
        '
        Me.OpenFilesToolStripMenuItem.Name = "OpenFilesToolStripMenuItem"
        Me.OpenFilesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenFilesToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OpenFilesToolStripMenuItem.Text = "Add Files..."
        '
        'OpenFolderToolStripMenuItem
        '
        Me.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem"
        Me.OpenFolderToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenFolderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OpenFolderToolStripMenuItem.Text = "Add Folder..."
        '
        'OpenLastToolStripMenuItem
        '
        Me.OpenLastToolStripMenuItem.Name = "OpenLastToolStripMenuItem"
        Me.OpenLastToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.OpenLastToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OpenLastToolStripMenuItem.Text = "Open Last"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'ExportCurrentMixToolStripMenuItem
        '
        Me.ExportCurrentMixToolStripMenuItem.Name = "ExportCurrentMixToolStripMenuItem"
        Me.ExportCurrentMixToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExportCurrentMixToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ExportCurrentMixToolStripMenuItem.Text = "Export Current Mix..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'SaveDictionaryToolStripMenuItem
        '
        Me.SaveDictionaryToolStripMenuItem.Name = "SaveDictionaryToolStripMenuItem"
        Me.SaveDictionaryToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.SaveDictionaryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SaveDictionaryToolStripMenuItem.Text = "Manage Dictionary..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEditClearFiles})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'MenuEditClearFiles
        '
        Me.MenuEditClearFiles.Name = "MenuEditClearFiles"
        Me.MenuEditClearFiles.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MenuEditClearFiles.Size = New System.Drawing.Size(201, 22)
        Me.MenuEditClearFiles.Text = "Clear Files"
        '
        'ConvertToolStripMenuItem
        '
        Me.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem"
        Me.ConvertToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConvertToolStripMenuItem.Size = New System.Drawing.Size(134, 20)
        Me.ConvertToolStripMenuItem.Text = "Convert WEM to WAV"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WhatDoIDoToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'WhatDoIDoToolStripMenuItem
        '
        Me.WhatDoIDoToolStripMenuItem.Name = "WhatDoIDoToolStripMenuItem"
        Me.WhatDoIDoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.WhatDoIDoToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.WhatDoIDoToolStripMenuItem.Text = "What do I do?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'BtnGroup
        '
        Me.BtnGroup.Location = New System.Drawing.Point(3, 3)
        Me.BtnGroup.Name = "BtnGroup"
        Me.BtnGroup.Size = New System.Drawing.Size(140, 23)
        Me.BtnGroup.TabIndex = 2
        Me.BtnGroup.Text = "Group WAVs by Duration"
        Me.BtnGroup.UseVisualStyleBackColor = True
        '
        'LblGroups
        '
        Me.LblGroups.AutoSize = True
        Me.LblGroups.Location = New System.Drawing.Point(149, 10)
        Me.LblGroups.Name = "LblGroups"
        Me.LblGroups.Size = New System.Drawing.Size(50, 13)
        Me.LblGroups.TabIndex = 4
        Me.LblGroups.Text = "0 Groups"
        '
        'PnlMixer
        '
        Me.PnlMixer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlMixer.AutoScroll = True
        Me.PnlMixer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PnlMixer.Location = New System.Drawing.Point(48, 3)
        Me.PnlMixer.Name = "PnlMixer"
        Me.PnlMixer.Size = New System.Drawing.Size(802, 189)
        Me.PnlMixer.TabIndex = 0
        '
        'TrkMaster
        '
        Me.TrkMaster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TrkMaster.AutoSize = False
        Me.TrkMaster.Location = New System.Drawing.Point(22, 3)
        Me.TrkMaster.Maximum = 100
        Me.TrkMaster.Name = "TrkMaster"
        Me.TrkMaster.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrkMaster.Size = New System.Drawing.Size(20, 189)
        Me.TrkMaster.TabIndex = 5
        Me.TrkMaster.TickFrequency = 10
        Me.TrkMaster.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrkMaster.Value = 100
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(431, 5)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(51, 23)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.Text = "PAUSE"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Double-click a group to start playing/mixing"
        '
        'BetterSplitContainer1
        '
        Me.BetterSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BetterSplitContainer1.DrawSplitter = True
        Me.BetterSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.BetterSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.BetterSplitContainer1.Name = "BetterSplitContainer1"
        Me.BetterSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'BetterSplitContainer1.Panel1
        '
        Me.BetterSplitContainer1.Panel1.Controls.Add(Me.BetterSplitContainer3)
        Me.BetterSplitContainer1.Panel1.Controls.Add(Me.BtnStop)
        Me.BetterSplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.BetterSplitContainer1.Panel1.Controls.Add(Me.BtnGroup)
        Me.BetterSplitContainer1.Panel1.Controls.Add(Me.LblGroups)
        Me.BetterSplitContainer1.Panel1Collapsible = False
        '
        'BetterSplitContainer1.Panel2
        '
        Me.BetterSplitContainer1.Panel2.Controls.Add(Me.VerticalLabel1)
        Me.BetterSplitContainer1.Panel2.Controls.Add(Me.PnlMixer)
        Me.BetterSplitContainer1.Panel2.Controls.Add(Me.TrkMaster)
        Me.BetterSplitContainer1.Panel2Collapsible = False
        Me.BetterSplitContainer1.Size = New System.Drawing.Size(853, 582)
        Me.BetterSplitContainer1.SplitterDistance = 383
        Me.BetterSplitContainer1.TabIndex = 9
        '
        'BetterSplitContainer3
        '
        Me.BetterSplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BetterSplitContainer3.DrawSplitter = True
        Me.BetterSplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.BetterSplitContainer3.Location = New System.Drawing.Point(4, 32)
        Me.BetterSplitContainer3.Name = "BetterSplitContainer3"
        '
        'BetterSplitContainer3.Panel1
        '
        Me.BetterSplitContainer3.Panel1.Controls.Add(Me.LstGroups)
        Me.BetterSplitContainer3.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BetterSplitContainer3.Panel1Collapsible = False
        '
        'BetterSplitContainer3.Panel2
        '
        Me.BetterSplitContainer3.Panel2.Controls.Add(Me.PnlGroupInfo)
        Me.BetterSplitContainer3.Panel2Collapsible = False
        Me.BetterSplitContainer3.Size = New System.Drawing.Size(846, 348)
        Me.BetterSplitContainer3.SplitterDistance = 150
        Me.BetterSplitContainer3.TabIndex = 10
        '
        'LstGroups
        '
        Me.LstGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstGroups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.LstGroups.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstGroups.FormattingEnabled = True
        Me.LstGroups.IntegralHeight = False
        Me.LstGroups.Location = New System.Drawing.Point(0, 0)
        Me.LstGroups.Name = "LstGroups"
        Me.LstGroups.Size = New System.Drawing.Size(147, 348)
        Me.LstGroups.TabIndex = 9
        '
        'PnlGroupInfo
        '
        Me.PnlGroupInfo.Controls.Add(Me.LblGroupName)
        Me.PnlGroupInfo.Controls.Add(Me.BtnGroupAddExisting)
        Me.PnlGroupInfo.Controls.Add(Me.BtnGroupAddNew)
        Me.PnlGroupInfo.Controls.Add(Me.BtnGroupCopy)
        Me.PnlGroupInfo.Controls.Add(Me.LstGroupContents)
        Me.PnlGroupInfo.Controls.Add(Me.TxtGroupName)
        Me.PnlGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlGroupInfo.Location = New System.Drawing.Point(0, 0)
        Me.PnlGroupInfo.Name = "PnlGroupInfo"
        Me.PnlGroupInfo.Size = New System.Drawing.Size(692, 348)
        Me.PnlGroupInfo.TabIndex = 0
        Me.PnlGroupInfo.Visible = False
        '
        'LblGroupName
        '
        Me.LblGroupName.AutoSize = True
        Me.LblGroupName.Location = New System.Drawing.Point(239, 8)
        Me.LblGroupName.Name = "LblGroupName"
        Me.LblGroupName.Size = New System.Drawing.Size(70, 13)
        Me.LblGroupName.TabIndex = 5
        Me.LblGroupName.Text = "Group Name:"
        '
        'BtnGroupAddExisting
        '
        Me.BtnGroupAddExisting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGroupAddExisting.Location = New System.Drawing.Point(114, 322)
        Me.BtnGroupAddExisting.Name = "BtnGroupAddExisting"
        Me.BtnGroupAddExisting.Size = New System.Drawing.Size(119, 23)
        Me.BtnGroupAddExisting.TabIndex = 4
        Me.BtnGroupAddExisting.Text = "Add to Existing Group"
        Me.BtnGroupAddExisting.UseVisualStyleBackColor = True
        '
        'BtnGroupAddNew
        '
        Me.BtnGroupAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGroupAddNew.Location = New System.Drawing.Point(114, 293)
        Me.BtnGroupAddNew.Name = "BtnGroupAddNew"
        Me.BtnGroupAddNew.Size = New System.Drawing.Size(119, 23)
        Me.BtnGroupAddNew.TabIndex = 3
        Me.BtnGroupAddNew.Text = "Add to New Group"
        Me.BtnGroupAddNew.UseVisualStyleBackColor = True
        '
        'BtnGroupCopy
        '
        Me.BtnGroupCopy.Location = New System.Drawing.Point(114, 31)
        Me.BtnGroupCopy.Name = "BtnGroupCopy"
        Me.BtnGroupCopy.Size = New System.Drawing.Size(119, 23)
        Me.BtnGroupCopy.TabIndex = 2
        Me.BtnGroupCopy.Text = "Copy Selected"
        Me.BtnGroupCopy.UseVisualStyleBackColor = True
        '
        'LstGroupContents
        '
        Me.LstGroupContents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstGroupContents.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstGroupContents.FormattingEnabled = True
        Me.LstGroupContents.IntegralHeight = False
        Me.LstGroupContents.Location = New System.Drawing.Point(3, 31)
        Me.LstGroupContents.Name = "LstGroupContents"
        Me.LstGroupContents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstGroupContents.Size = New System.Drawing.Size(105, 314)
        Me.LstGroupContents.TabIndex = 1
        '
        'TxtGroupName
        '
        Me.TxtGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGroupName.Location = New System.Drawing.Point(3, 3)
        Me.TxtGroupName.Name = "TxtGroupName"
        Me.TxtGroupName.Size = New System.Drawing.Size(230, 22)
        Me.TxtGroupName.TabIndex = 0
        '
        'VerticalLabel1
        '
        Me.VerticalLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VerticalLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerticalLabel1.Location = New System.Drawing.Point(4, 3)
        Me.VerticalLabel1.Name = "VerticalLabel1"
        Me.VerticalLabel1.Size = New System.Drawing.Size(12, 189)
        Me.VerticalLabel1.TabIndex = 6
        Me.VerticalLabel1.Text = "Master"
        '
        'BetterSplitContainer2
        '
        Me.BetterSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BetterSplitContainer2.DrawSplitter = True
        Me.BetterSplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.BetterSplitContainer2.Location = New System.Drawing.Point(0, 24)
        Me.BetterSplitContainer2.Name = "BetterSplitContainer2"
        '
        'BetterSplitContainer2.Panel1
        '
        Me.BetterSplitContainer2.Panel1.Controls.Add(Me.LstFiles)
        Me.BetterSplitContainer2.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BetterSplitContainer2.Panel1Collapsible = False
        '
        'BetterSplitContainer2.Panel2
        '
        Me.BetterSplitContainer2.Panel2.Controls.Add(Me.BetterSplitContainer1)
        Me.BetterSplitContainer2.Panel2Collapsible = False
        Me.BetterSplitContainer2.Size = New System.Drawing.Size(957, 582)
        Me.BetterSplitContainer2.SplitterDistance = 100
        Me.BetterSplitContainer2.TabIndex = 10
        '
        'CmsGroupCopy
        '
        Me.CmsGroupCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithWEMToolStripMenuItem, Me.WithoutWEMToolStripMenuItem})
        Me.CmsGroupCopy.Name = "CmsGroupCopy"
        Me.CmsGroupCopy.Size = New System.Drawing.Size(152, 48)
        '
        'WithWEMToolStripMenuItem
        '
        Me.WithWEMToolStripMenuItem.Name = "WithWEMToolStripMenuItem"
        Me.WithWEMToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.WithWEMToolStripMenuItem.Text = "With .WEM"
        '
        'WithoutWEMToolStripMenuItem
        '
        Me.WithoutWEMToolStripMenuItem.Name = "WithoutWEMToolStripMenuItem"
        Me.WithoutWEMToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.WithoutWEMToolStripMenuItem.Text = "Without .WEM"
        '
        'CmsUserGroups
        '
        Me.CmsUserGroups.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoGroupsToolStripMenuItem})
        Me.CmsUserGroups.Name = "CmsUserGroups"
        Me.CmsUserGroups.Size = New System.Drawing.Size(158, 26)
        '
        'NoGroupsToolStripMenuItem
        '
        Me.NoGroupsToolStripMenuItem.Name = "NoGroupsToolStripMenuItem"
        Me.NoGroupsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NoGroupsToolStripMenuItem.Text = "-- No Groups --"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 606)
        Me.Controls.Add(Me.BetterSplitContainer2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Pikmin 4 Mixer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrkMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BetterSplitContainer1.Panel1.ResumeLayout(False)
        Me.BetterSplitContainer1.Panel1.PerformLayout()
        Me.BetterSplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.BetterSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BetterSplitContainer1.ResumeLayout(False)
        Me.BetterSplitContainer3.Panel1.ResumeLayout(False)
        Me.BetterSplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.BetterSplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BetterSplitContainer3.ResumeLayout(False)
        Me.PnlGroupInfo.ResumeLayout(False)
        Me.PnlGroupInfo.PerformLayout()
        Me.BetterSplitContainer2.Panel1.ResumeLayout(False)
        Me.BetterSplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.BetterSplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BetterSplitContainer2.ResumeLayout(False)
        Me.CmsGroupCopy.ResumeLayout(False)
        Me.CmsUserGroups.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LstFiles As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuEditClearFiles As ToolStripMenuItem
    Friend WithEvents BtnGroup As Button
    Friend WithEvents LblGroups As Label
    Friend WithEvents PnlMixer As FlowLayoutPanel
    Friend WithEvents TrkMaster As TrackBar
    Friend WithEvents BtnStop As Button
    Friend WithEvents ConvertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WhatDoIDoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SaveDictionaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenLastToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BetterSplitContainer1 As BetterSplitContainer
    Friend WithEvents BetterSplitContainer2 As BetterSplitContainer
    Friend WithEvents ExportCurrentMixToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents VerticalLabel1 As VerticalLabel
    Friend WithEvents BetterSplitContainer3 As BetterSplitContainer
    Friend WithEvents LstGroups As ListBox
    Friend WithEvents PnlGroupInfo As Panel
    Friend WithEvents TxtGroupName As TextBox
    Friend WithEvents LstGroupContents As ListBox
    Friend WithEvents BtnGroupAddExisting As Button
    Friend WithEvents BtnGroupAddNew As Button
    Friend WithEvents BtnGroupCopy As Button
    Friend WithEvents CmsGroupCopy As ContextMenuStrip
    Friend WithEvents WithWEMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WithoutWEMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CmsUserGroups As ContextMenuStrip
    Friend WithEvents NoGroupsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblGroupName As Label
End Class
