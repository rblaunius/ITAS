Imports System
Imports System.IO
Imports ITAS.Control 'In MasterFunctions.vb
Imports ITAS.Common 'In MasterFunctions.vb

Public Class frm_Startup

    'Variables for Objects
    Private F As New FileManager  'from MasterFunctions.vb
    Public UserInitials As String = ""
    Public ParentFolder As String = My.Computer.FileSystem.CurrentDirectory()
    Public LogFolder As String = ParentFolder + "\User Logs\"
    Public LogPath As String
    Public tele As String

#Region "Load"

    'runs as form begins loading
    Private Sub frm_Startup_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.OpenStartupWindow = False Then
            UserInitials = My.Settings.User
            LogPath = My.Settings.LogPath
            tele = My.Settings.Telescope
            Me.Hide()
            Me.Enabled() = False
            frm_main.Show()
            Me.Close()
            Exit Sub
        Else
            If My.Computer.FileSystem.DirectoryExists(LogFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(LogFolder)
            End If
            Me.KeyPreview = True
            tb_initials.Text = My.Settings.User
            tb_initials.Select()
        End If
    End Sub

    'Keyboard Shortcuts
    Private Sub frm_Startup_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            btn_continue.PerformClick()
        End If
    End Sub

#End Region


#Region "Controls"

    'Continue Button: closes startup form and opens main form
    Private Sub btn_continue_Click(sender As Object, e As EventArgs) Handles btn_continue.Click
        If UserInitials = "" Then 'if user did not enter any initials
            UserInitials = "Guest" 'assign initials as "Guest"
        End If
        LogPath = F.GetUserLogPath(UserInitials, LogFolder)  'returns log path defined by user initials
        My.Settings.LogPath = LogPath 'saves logpath to application settings, incase user wants to skip menu
        My.Settings.User = UserInitials
        tele = My.Settings.Telescope

        frm_main.Show()
        Me.Hide()
        Me.Enabled() = False
    End Sub

    'TextBox for initials
    Private Sub tb_user_TextChanged(sender As Object, e As EventArgs) Handles tb_initials.TextChanged
        UserInitials = tb_initials.Text
    End Sub

#End Region

End Class
