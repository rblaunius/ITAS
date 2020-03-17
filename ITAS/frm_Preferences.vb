Public Class frm_preferences
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshLabels()
    End Sub

    Public Sub RefreshLabels()
        lasttele.Text = My.Settings.LastTelescope
        lastuser.Text = My.Settings.User
        darkmode.Text = My.Settings.StartDark.ToString
        loginwindow.Text = My.Settings.OpenStartupWindow.ToString
    End Sub

    Private Sub frm_preferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshLabels()
    End Sub
End Class