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
        Me.WhatDoIDoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGroup = New System.Windows.Forms.Button()
        Me.PnlGroups = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblGroups = New System.Windows.Forms.Label()
        Me.PnlMixer = New System.Windows.Forms.FlowLayoutPanel()
        Me.TrkMaster = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.ConvertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.ConvertToolStripMenuItem, Me.WhatDoIDoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(918, 24)
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
        Me.MenuEditClearFiles.Size = New System.Drawing.Size(180, 22)
        Me.MenuEditClearFiles.Text = "Clear Files"
        '
        'WhatDoIDoToolStripMenuItem
        '
        Me.WhatDoIDoToolStripMenuItem.Name = "WhatDoIDoToolStripMenuItem"
        Me.WhatDoIDoToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
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
        Me.PnlGroups.Size = New System.Drawing.Size(619, 538)
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
        Me.PnlMixer.Location = New System.Drawing.Point(763, 126)
        Me.PnlMixer.Name = "PnlMixer"
        Me.PnlMixer.Size = New System.Drawing.Size(143, 468)
        Me.PnlMixer.TabIndex = 0
        '
        'TrkMaster
        '
        Me.TrkMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrkMaster.Location = New System.Drawing.Point(763, 75)
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
        Me.Label1.Location = New System.Drawing.Point(763, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Master Volume"
        '
        'BtnStop
        '
        Me.BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStop.Location = New System.Drawing.Point(855, 51)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(51, 23)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.Text = "PAUSE"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'ConvertToolStripMenuItem
        '
        Me.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem"
        Me.ConvertToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ConvertToolStripMenuItem.Text = "Convert Files"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 606)
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
    Friend WithEvents WhatDoIDoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConvertToolStripMenuItem As ToolStripMenuItem
End Class
