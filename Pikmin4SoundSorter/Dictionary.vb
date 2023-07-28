Imports System.IO

Public Class Dictionary
    Private DialogOpenCSV As New OpenFileDialog With {.Filter = "CSV files (*.csv)|*.csv", .Title = "Import CSV file to Dictionary"}
    Private DialogSaveCSV As New SaveFileDialog With {.Filter = "CSV files (*.csv)|*.csv", .Title = "Save Dictionary as CSV file"}
    Private Sub Dictionary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDictionary()

    End Sub

    Sub LoadDictionary()
        DgvDict.Rows.Clear()
        For Each f In Form1.FileDict
            DgvDict.Rows.Add(f.Key, f.Value)
        Next
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If DialogOpenCSV.ShowDialog() = DialogResult.OK Then
            If File.Exists(DialogOpenCSV.FileName) Then
                For Each line In File.ReadAllLines(DialogOpenCSV.FileName)
                    If String.IsNullOrWhiteSpace(line) Then Continue For
                    Dim pair = line.Split(",")
                    If pair.Length <> 2 Then
                        MessageBox.Show("Invalid CSV file.")
                        Exit Sub
                    End If
                    If Form1.FileDict.ContainsKey(pair(0)) Then
                        Form1.FileDict(pair(0)) = pair(1)
                        For Each r As DataGridViewRow In DgvDict.Rows
                            If r.Cells(0).Value.ToString() = pair(0) Then
                                r.Cells(1).Value = pair(1)
                            End If
                        Next
                    Else
                        Form1.FileDict.Add(pair(0), pair(1))
                        DgvDict.Rows.Add(pair(0), pair(1))
                    End If
                Next
                Form1.SaveDict()
            End If
        End If
    End Sub
    Function GetCSV() As String
        Dim csv = ""
        For i = 0 To Form1.FileDict.Count - 1
            csv += String.Format("{0},{1}", Form1.FileDict.Keys(i), Form1.FileDict.Values(i))
            If i < Form1.FileDict.Count - 1 Then
                csv += vbNewLine
            End If
        Next
        Return csv
    End Function
    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        Dim csv = GetCSV()
        If String.IsNullOrWhiteSpace(csv) Then
            MessageBox.Show("Nothing to copy.", "Copy CSV")
        Else
            Clipboard.SetText(csv)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DialogSaveCSV.ShowDialog() = DialogResult.OK Then
            File.WriteAllText(DialogSaveCSV.FileName, GetCSV())
        End If
    End Sub

    Private Sub DgvDict_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DgvDict.UserDeletingRow
        Form1.FileDict.Remove(e.Row.Cells(0).Value.ToString())
        Form1.SaveDict()
    End Sub
End Class