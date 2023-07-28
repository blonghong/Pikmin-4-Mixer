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
        Me.LstFiles = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEditClearFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhatDoIDoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGroup = New System.Windows.Forms.Button()
        Me.PnlGroups = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblGroups = New System.Windows.Forms.Label()
        Me.PnlMixer = New System.Windows.Forms.FlowLayoutPanel()
        Me.TrkMaster = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrkMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LstFiles
        '
        Me.LstFiles.AllowDrop = True
        Me.LstFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstFiles.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstFiles.FormattingEnabled = True
        Me.LstFiles.IntegralHeight = False
        Me.LstFiles.Location = New System.Drawing.Point(12, 27)
        Me.LstFiles.Name = "LstFiles"
        Me.LstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstFiles.Size = New System.Drawing.Size(120, 567)
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
        Me.MenuEditClearFiles.Size = New System.Drawing.Size(127, 22)
        Me.MenuEditClearFiles.Text = "Clear Files"
        '
        'ConvertToolStripMenuItem
        '
        Me.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem"
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
        Me.WhatDoIDoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.WhatDoIDoToolStripMenuItem.Text = "What do I do?"
        '
        'BtnGroup
        '
        Me.BtnGroup.Location = New System.Drawing.Point(138, 27)
        Me.BtnGroup.Name = "BtnGroup"
        Me.BtnGroup.Size = New System.Drawing.Size(140, 23)
        Me.BtnGroup.TabIndex = 2
        Me.BtnGroup.Text = "Group WAVs by Duration"
        Me.BtnGroup.UseVisualStyleBackColor = True
        '
        'PnlGroups
        '
        Me.PnlGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlGroups.AutoScroll = True
        Me.PnlGroups.Location = New System.Drawing.Point(138, 56)
        Me.PnlGroups.Name = "PnlGroups"
        Me.PnlGroups.Size = New System.Drawing.Size(658, 538)
        Me.PnlGroups.TabIndex = 3
        '
        'LblGroups
        '
        Me.LblGroups.AutoSize = True
        Me.LblGroups.Location = New System.Drawing.Point(284, 34)
        Me.LblGroups.Name = "LblGroups"
        Me.LblGroups.Size = New System.Drawing.Size(50, 13)
        Me.LblGroups.TabIndex = 4
        Me.LblGroups.Text = "0 Groups"
        '
        'PnlMixer
        '
        Me.PnlMixer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlMixer.AutoScroll = True
        Me.PnlMixer.Location = New System.Drawing.Point(802, 126)
        Me.PnlMixer.Name = "PnlMixer"
        Me.PnlMixer.Size = New System.Drawing.Size(143, 468)
        Me.PnlMixer.TabIndex = 0
        '
        'TrkMaster
        '
        Me.TrkMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrkMaster.Location = New System.Drawing.Point(802, 75)
        Me.TrkMaster.Maximum = 100
        Me.TrkMaster.Name = "TrkMaster"
        Me.TrkMaster.Size = New System.Drawing.Size(143, 45)
        Me.TrkMaster.TabIndex = 5
        Me.TrkMaster.TickFrequency = 10
        Me.TrkMaster.Value = 100
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(802, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Master Volume"
        '
        'BtnStop
        '
        Me.BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStop.Location = New System.Drawing.Point(894, 51)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(51, 23)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.Text = "PAUSE"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFolderToolStripMenuItem, Me.OpenFilesToolStripMenuItem, Me.OpenLastToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveDictionaryToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenFolderToolStripMenuItem
        '
        Me.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem"
        Me.OpenFolderToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenFolderToolStripMenuItem.Text = "Add Folder..."
        '
        'OpenFilesToolStripMenuItem
        '
        Me.OpenFilesToolStripMenuItem.Name = "OpenFilesToolStripMenuItem"
        Me.OpenFilesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenFilesToolStripMenuItem.Text = "Add Files..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Double-click a group to start playing/mixing"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'SaveDictionaryToolStripMenuItem
        '
        Me.SaveDictionaryToolStripMenuItem.Name = "SaveDictionaryToolStripMenuItem"
        Me.SaveDictionaryToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveDictionaryToolStripMenuItem.Text = "Manage Dictionary..."
        '
        'OpenLastToolStripMenuItem
        '
        Me.OpenLastToolStripMenuItem.Name = "OpenLastToolStripMenuItem"
        Me.OpenLastToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.OpenLastToolStripMenuItem.Text = "Open Last"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 606)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrkMaster)
        Me.Controls.Add(Me.PnlMixer)
        Me.Controls.Add(Me.LblGroups)
        Me.Controls.Add(Me.PnlGroups)
        Me.Controls.Add(Me.BtnGroup)
        Me.Controls.Add(Me.LstFiles)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Pikmin 4 Sound Sorter"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrkMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LstFiles As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuEditClearFiles As ToolStripMenuItem
    Friend WithEvents BtnGroup As Button
    Friend WithEvents PnlGroups As FlowLayoutPanel
    Friend WithEvents LblGroups As Label
    Friend WithEvents PnlMixer As FlowLayoutPanel
    Friend WithEvents TrkMaster As TrackBar
    Friend WithEvents Label1 As Label
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
End Class
