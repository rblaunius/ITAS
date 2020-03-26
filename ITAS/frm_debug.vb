Public Class frm_debug

    Public Sub DebugALPHA(a As String, Optional b As String = "", Optional c As String = "", Optional d As String = "", Optional e As String = "", Optional f As String = "")
        Label1.Text = a
        Label2.Text = b
        Label3.Text = c
        Label4.Text = d
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        Me.Refresh()
    End Sub

End Class