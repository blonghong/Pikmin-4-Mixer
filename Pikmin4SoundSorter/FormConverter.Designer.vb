<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConverter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LstFiles = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkVgmstream = New System.Windows.Forms.LinkLabel()
        Me.BtnBrowseOutput = New System.Windows.Forms.Button()
        Me.TxtOutput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelDropFiles = New System.Windows.Forms.Label()
        Me.BtnConvert = New System.Windows.Forms.Button()
        Me.TxtTerminal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.LstFiles.Location = New System.Drawing.Point(12, 12)
        Me.LstFiles.Name = "LstFiles"
        Me.LstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstFiles.Size = New System.Drawing.Size(120, 246)
        Me.LstFiles.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Courtesy of vgmstream"
        '
        'LinkVgmstream
        '
        Me.LinkVgmstream.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkVgmstream.AutoSize = True
        Me.LinkVgmstream.Location = New System.Drawing.Point(135, 245)
        Me.LinkVgmstream.Name = "LinkVgmstream"
        Me.LinkVgmstream.Size = New System.Drawing.Size(207, 13)
        Me.LinkVgmstream.TabIndex = 4
        Me.LinkVgmstream.TabStop = True
        Me.LinkVgmstream.Text = "https://github.com/vgmstream/vgmstream"
        '
        'BtnBrowseOutput
        '
        Me.BtnBrowseOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseOutput.Location = New System.Drawing.Point(380, 26)
        Me.BtnBrowseOutput.Name = "BtnBrowseOutput"
        Me.BtnBrowseOutput.Size = New System.Drawing.Size(75, 23)
        Me.BtnBrowseOutput.TabIndex = 7
        Me.BtnBrowseOutput.Text = "Browse..."
        Me.BtnBrowseOutput.UseVisualStyleBackColor = True
        '
        'TxtOutput
        '
        Me.TxtOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOutput.Location = New System.Drawing.Point(138, 28)
        Me.TxtOutput.Name = "TxtOutput"
        Me.TxtOutput.ReadOnly = True
        Me.TxtOutput.Size = New System.Drawing.Size(236, 20)
        Me.TxtOutput.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Output directory"
        '
        'LabelDropFiles
        '
        Me.LabelDropFiles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelDropFiles.AutoSize = True
        Me.LabelDropFiles.BackColor = System.Drawing.Color.White
        Me.LabelDropFiles.Enabled = False
        Me.LabelDropFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDropFiles.Location = New System.Drawing.Point(43, 105)
        Me.LabelDropFiles.Name = "LabelDropFiles"
        Me.LabelDropFiles.Size = New System.Drawing.Size(55, 60)
        Me.LabelDropFiles.TabIndex = 10
        Me.LabelDropFiles.Text = "DROP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FILES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HERE"
        '
        'BtnConvert
        '
        Me.BtnConvert.Location = New System.Drawing.Point(138, 54)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(75, 23)
        Me.BtnConvert.TabIndex = 11
        Me.BtnConvert.Text = "Convert"
        Me.BtnConvert.UseVisualStyleBackColor = True
        '
        'TxtTerminal
        '
        Me.TxtTerminal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTerminal.Location = New System.Drawing.Point(138, 83)
        Me.TxtTerminal.Multiline = True
        Me.TxtTerminal.Name = "TxtTerminal"
        Me.TxtTerminal.ReadOnly = True
        Me.TxtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTerminal.Size = New System.Drawing.Size(317, 146)
        Me.TxtTerminal.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "You can use Audiokinetic WWise" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to convert WAV to WEM"
        '
        'FormConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 270)
        Me.Controls.Add(Me.LabelDropFiles)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtTerminal)
        Me.Controls.Add(Me.BtnConvert)
        Me.Controls.Add(Me.LstFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkVgmstream)
        Me.Controls.Add(Me.BtnBrowseOutput)
        Me.Controls.Add(Me.TxtOutput)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FormConverter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "WEM Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LstFiles As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkVgmstream As LinkLabel
    Friend WithEvents BtnBrowseOutput As Button
    Friend WithEvents TxtOutput As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelDropFiles As Label
    Friend WithEvents BtnConvert As Button
    Friend WithEvents TxtTerminal As TextBox
    Friend WithEvents Label4 As Label
End Class
