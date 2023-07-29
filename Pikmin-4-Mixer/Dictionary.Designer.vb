<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dictionary
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
        Me.DgvDict = New System.Windows.Forms.DataGridView()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvDict, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvDict
        '
        Me.DgvDict.AllowUserToAddRows = False
        Me.DgvDict.AllowUserToResizeRows = False
        Me.DgvDict.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDict.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Filename, Me.Reference})
        Me.DgvDict.Location = New System.Drawing.Point(12, 12)
        Me.DgvDict.Name = "DgvDict"
        Me.DgvDict.ReadOnly = True
        Me.DgvDict.RowHeadersVisible = False
        Me.DgvDict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDict.Size = New System.Drawing.Size(352, 244)
        Me.DgvDict.TabIndex = 0
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(370, 233)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save CSV"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCopy
        '
        Me.BtnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopy.Location = New System.Drawing.Point(370, 204)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(75, 23)
        Me.BtnCopy.TabIndex = 2
        Me.BtnCopy.Text = "Copy CSV"
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(370, 12)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(75, 23)
        Me.BtnImport.TabIndex = 3
        Me.BtnImport.Text = "Import CSV"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'Filename
        '
        Me.Filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Filename.HeaderText = "Filename"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        Me.Filename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Reference
        '
        Me.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Reference.HeaderText = "Reference"
        Me.Reference.Name = "Reference"
        Me.Reference.ReadOnly = True
        Me.Reference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Dictionary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 268)
        Me.Controls.Add(Me.BtnImport)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.DgvDict)
        Me.Name = "Dictionary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dictionary"
        CType(Me.DgvDict, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvDict As DataGridView
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnCopy As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents Filename As DataGridViewTextBoxColumn
    Friend WithEvents Reference As DataGridViewTextBoxColumn
End Class
