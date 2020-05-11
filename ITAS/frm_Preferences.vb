Public Class frm_preferences

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        RefreshLabels()
    End Sub

    Public Sub RefreshLabels()
        'remember checkstate for start dark setting
        If My.Settings.StartDark = True Then
            checkbox_StartDark.Checked() = True
        Else
            checkbox_StartDark.Checked() = False
        End If
        'remember checkstate for show startup setting
        If My.Settings.OpenStartupWindow = False Then
            checkbox_ShowStartup.Checked() = False
        Else
            checkbox_ShowStartup.Checked() = True
        End If
    End Sub

    Private Sub frm_preferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshLabels()
    End Sub

    Private Sub checkbox_StartDark_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_StartDark.CheckedChanged
        If checkbox_StartDark.CheckState() = CheckState.Checked Then
            My.Settings.StartDark = True
        ElseIf checkbox_StartDark.CheckState() = CheckState.Unchecked Then
            My.Settings.StartDark = False
        End If
    End Sub

    Private Sub checkbox_ShowStartup_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_ShowStartup.CheckedChanged
        If checkbox_ShowStartup.CheckState() = CheckState.Checked Then
            My.Settings.OpenStartupWindow = True
        ElseIf checkbox_showstartup.CheckState() = CheckState.Unchecked Then
            My.Settings.OpenStartupWindow = False
        End If
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_scan.Click
        btn_scan.Enabled = False
    End Sub
End Class