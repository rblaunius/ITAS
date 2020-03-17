Imports System
Imports System.IO
Imports ITAS.frm_debug
Imports ITAS.Control 'In MasterFunctions.vb
Imports ITAS.Common 'In MasterFunctions.vb

Public Class frm_Startup

    'Declare Shortcuts to Objects
    Private F As New FileManager
    Private D As New frm_debug

    Public UserInitials As String = ""
    Public ParentFolder As String = My.Computer.FileSystem.CurrentDirectory()
    Public LogFolder As String = ParentFolder + "\User Logs\"
    Public LogPath As String

#Region "Load"

    'runs as form begins loading
    Private Sub frm_Startup_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Immediately run debug script


        'close form if user My.Settings.OpenStartupWindow = false
        If My.Settings.OpenStartupWindow = False Then 'if prev. user selected "Remember Settings", exit sub and open main
            UserInitials = My.Settings.User
            LogPath = My.Settings.LogPath
            frm_main.Show()
            Me.Hide()
            Me.Enabled = False
            Exit Sub
        End If
        'Runs every time if My.Settings.OpenStartupWindow = true
        If My.Computer.FileSystem.DirectoryExists(LogFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(LogFolder)
        End If
        Me.KeyPreview = True
        If My.Computer.FileSystem.FileExists(ParentFolder + "\ITAS.lnk") = False Then
            F.CreateShortcut(ParentFolder + "\ITAS.exe", ParentFolder, "ITAS")
        End If

    End Sub

    'runs as soon as form is finished loading - used for setting other details for visual items
    Private Sub frm_Startup_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        tb_initials.Select()
    End Sub

    'Keyboard Shortcuts
    Private Sub frm_Startup_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            btn_continue.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#End Region



    'Controls
    Private Sub btn_continue_Click(sender As Object, e As EventArgs) Handles btn_continue.Click
        If UserInitials = "" Then 'if user did not enter any initials
            UserInitials = "Guest" 'assign initials as "Guest"
        End If
        LogPath = F.GetUserLogPath(UserInitials, LogFolder)  'returns log path defined by user initials
        My.Settings.LogPath = LogPath 'saves logpath to application settings, incase user wants to skip menu

        frm_main.Show()
        Me.Hide()
        Me.Enabled() = False
    End Sub
    Private Sub tb_user_TextChanged(sender As Object, e As EventArgs) Handles tb_initials.TextChanged
        UserInitials = tb_initials.Text
    End Sub


End Class
