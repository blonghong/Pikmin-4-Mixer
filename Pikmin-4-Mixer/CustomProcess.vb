Public Class CustomProcess
    Inherits Process

    Property IsRunning As Boolean = False

    Private Sub CustomProcess_Exited(sender As Object, e As EventArgs) Handles Me.Exited
        IsRunning = False
    End Sub

    Public Function Start_() As Boolean
        IsRunning = True
        Return Start()
    End Function


End Class
