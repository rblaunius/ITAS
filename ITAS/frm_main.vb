Imports System.ComponentModel
Imports System
Imports System.IO
Imports ITAS.Common


Public Class frm_main

    'General environment/setup variables
    Private F As New FileManager
    Private _l As String = Environment.NewLine
    Public UserInitials, LogPath, CurrentTelescope, OtherTelescope As String
    'Current object variables
    Public current_name As String
    Public current_RA As String
    Public current_DEC As String
    Public current_UT As String
    Public current_LST As String
    'Telescope variables
    Public TrackingEnabled As Boolean = True
    'Interface/appearance variables
    Public LockedLocation As Point
    Public Origin As Point
    Public SegoeUI As Font = New Font("Segoe UI", emSize:=12, FontStyle.Regular) 'create font for quick ref
    Public CompletelyExit As Boolean = True

#Region "LOAD"

    'Executes upon loading every time, regardless of user settings
    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RetrieveVariables()
        Me.Text = "ITAS (41"" Telescope)"
        Origin = Point.Add(group_currentobject.Location, New Drawing.Size(0, 0))
        LockedLocation = Point.Add(Origin, New Drawing.Size(0, group_currentobject.Height + group_telescope.Height + 10))
        panel_buttons.Location = Point.Add(Origin, New Size(6, 238))
        group_remote.Location = LockedLocation
        Me.KeyPreview = True
    End Sub

    'Retrieve all variables either from frm_startup or My.Settings
    Public Sub RetrieveVariables()
        'if startup form was opened () then


    End Sub

#End Region

#Region "Menu Toolbar"

    'opens user_log.txt - this file stores every event/command
    Private Sub OpenUserLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUserLogToolStripMenuItem.Click
        F.WriteToFile(frm_Startup.LogPath, sender.ToString)
        Process.Start(LogPath)
    End Sub

    Private Sub SaveSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSessionToolStripMenuItem.Click
        F.WriteToFile(LogPath, sender.ToString)
        'some code to save contents? might delete...
        SaveFileDialog1.FileName = UserInitials + "_save"
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        frm_Startup.Enabled = True
        Me.Hide()
        frm_Startup.Show()
        Me.Enabled = False
        CompletelyExit = False
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        F.WriteToFile(LogPath, sender.ToString)
        Me.Hide()
        frm_Startup.Close()
    End Sub

    Private Sub SwitchTelescopeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchTelescopeToolStripMenuItem.Click
        F.WriteToFile(LogPath, sender.ToString)
        F.WriteToFile(LogPath, "-----------------------------------------------------------------------------", False)
        SwitchTelescopeToolStripMenuItem.Text = "Switch to " + OtherTelescope
        F.WriteToFile(LogPath, "New Session: " + Today + "--" + CurrentTelescope, False)
    End Sub

    Private Sub DocumentationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DocumentationToolStripMenuItem1.Click
        Process.Start("http://www.physics.sfasu.edu/observatory/41-inch/itas2000.html")
    End Sub

    Private Sub GoogleEarthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleEarthToolStripMenuItem.Click
        Process.Start("https://earth.google.com/web/@31.7599981,-94.660994,150.53474939a,882.20855354d,35y,0h,45t,0r/data=CnEabxJpCiUweDg2Mzc5MjM3NTVkM2EzZTU6MHhmNTBiOTk2OGEzYjA4NTZmGaqFSDyPwj9AIYs2x7lNqlfAKi5TdGVwaGVuIEYuIEF1c3RpbiBTdGF0ZSBVbml2ZXJzaXR5IE9ic2VydmF0b3J5GAIgASgC")
    End Sub

    Private Sub NightModeOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NightModeOffToolStripMenuItem.Click
        changecolors()
    End Sub

    Private Sub SetupRemoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupRemoteToolStripMenuItem.Click
        frm_remotesetup.Show()
    End Sub

#End Region
#Region "Color/UI Preferences"

    Private Sub changecolors(Optional a As Boolean = True)
        If group_currentobject.ForeColor = Color.DarkRed Then
            ''change type of buttons
            btn_resettelescope.FlatStyle = FlatStyle.System
            btn_SlewTo.FlatStyle = FlatStyle.System
            btn_loadHome.FlatStyle = FlatStyle.System
            btn_loadmounting.FlatStyle = FlatStyle.System
            btn_readTheSky.FlatStyle = FlatStyle.System
            btn_movetime.FlatStyle = FlatStyle.System
            btn_add.FlatStyle = FlatStyle.System
            btn_remove.FlatStyle = FlatStyle.System
            btn_linkTheSky.FlatStyle = FlatStyle.System
            btn_movetonext.FlatStyle = FlatStyle.System
            btn_sortalphabet.FlatStyle = FlatStyle.System
            btn_sortRAscension.FlatStyle = FlatStyle.System
            btn_survey.FlatStyle = FlatStyle.System
            ''change back colors
            Panel_center.BackColor = Color.FromArgb(200, 200, 200)
            tab_brightstars.BackColor = Color.FromArgb(200, 200, 200)
            tab_deepsky.BackColor = Color.FromArgb(200, 200, 200)
            tab_othertargets.BackColor = Color.FromArgb(200, 200, 200)
            tab_variablestars.BackColor = Color.FromArgb(200, 200, 200)
            'change colors of all texts and others
            Me.ForeColor = Color.Black
            group_currentobject.ForeColor = Color.Black
            group_nextobject.ForeColor = Color.Black
            group_remote.ForeColor = Color.Black
            group_telescope.ForeColor = Color.Black
            updown_frequency.BackColor = Color.White
            updown_frequency.ForeColor = Color.Black
            Panel2.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Label11.ForeColor = Color.Black
            Label12.ForeColor = Color.Black
            Label13.ForeColor = Color.Black
            Label14.ForeColor = Color.Black
            Label15.ForeColor = Color.Black
            moveTime.BackColor = SystemColors.Control
            next_ALT.BackColor = SystemColors.Control
            next_AZ.BackColor = SystemColors.Control
            next_DEC_1.BackColor = SystemColors.Control
            next_DEC_2.BackColor = SystemColors.Control
            next_DEC_3.BackColor = SystemColors.Control
            next_DEC_4.BackColor = SystemColors.Control
            next_name.BackColor = SystemColors.Control
            next_RA_h.BackColor = SystemColors.Control
            next_RA_m.BackColor = SystemColors.Control
            next_RA_s.BackColor = SystemColors.Control
            Label22.BackColor = SystemColors.Control
            MenuStrip1.BackColor = SystemColors.Control
            MenuStrip1.ForeColor = Color.Black
            FileToolStripMenuItem.ForeColor = Color.Black
            EditToolStripMenuItem.ForeColor = Color.Black
            ViewToolStripMenuItem.ForeColor = Color.Black
            ToolsToolStripMenuItem.ForeColor = Color.Black
            HelpToolStripMenuItem.ForeColor = Color.Black
            NightModeOffToolStripMenuItem.Text = "Enable Night Mode"
        Else
            ''change type on buttons
            btn_resettelescope.FlatStyle = FlatStyle.Flat
            btn_SlewTo.FlatStyle = FlatStyle.Flat
            btn_loadHome.FlatStyle = FlatStyle.Flat
            btn_loadmounting.FlatStyle = FlatStyle.Flat
            btn_readTheSky.FlatStyle = FlatStyle.Flat
            btn_movetime.FlatStyle = FlatStyle.Flat
            btn_add.FlatStyle = FlatStyle.Flat
            btn_remove.FlatStyle = FlatStyle.Flat
            btn_linkTheSky.FlatStyle = FlatStyle.Flat
            btn_movetonext.FlatStyle = FlatStyle.Flat
            btn_sortalphabet.FlatStyle = FlatStyle.Flat
            btn_sortRAscension.FlatStyle = FlatStyle.Flat
            btn_survey.FlatStyle = FlatStyle.Flat
            ''change colors on buttons
            btn_resettelescope.BackColor = Color.FromArgb(15, 15, 15)
            btn_SlewTo.BackColor = Color.FromArgb(15, 15, 15)
            btn_loadHome.BackColor = Color.FromArgb(15, 15, 15)
            btn_loadmounting.BackColor = Color.FromArgb(15, 15, 15)
            btn_readTheSky.BackColor = Color.FromArgb(15, 15, 15)
            btn_movetime.BackColor = Color.FromArgb(15, 15, 15)
            btn_add.BackColor = Color.FromArgb(15, 15, 15)
            btn_remove.BackColor = Color.FromArgb(15, 15, 15)
            btn_linkTheSky.BackColor = Color.FromArgb(15, 15, 15)
            btn_movetonext.BackColor = Color.FromArgb(15, 15, 15)
            btn_sortalphabet.BackColor = Color.FromArgb(15, 15, 15)
            btn_sortRAscension.BackColor = Color.FromArgb(15, 15, 15)
            btn_survey.BackColor = Color.FromArgb(15, 15, 15)
            ''change back colors
            Panel_center.BackColor = Color.Black
            tab_brightstars.BackColor = Color.Black
            tab_deepsky.BackColor = Color.Black
            tab_othertargets.BackColor = Color.Black
            tab_variablestars.BackColor = Color.Black
            ''change colors of all texts and others
            Me.ForeColor = Color.DarkRed
            group_currentobject.ForeColor = Color.DarkRed
            group_nextobject.ForeColor = Color.DarkRed
            group_remote.ForeColor = Color.DarkRed
            group_telescope.ForeColor = Color.DarkRed
            updown_frequency.BackColor = Color.Black
            updown_frequency.ForeColor = Color.DarkRed
            Panel2.ForeColor = Color.DarkRed
            Label10.ForeColor = Color.DarkRed
            Label11.ForeColor = Color.DarkRed
            Label12.ForeColor = Color.DarkRed
            Label13.ForeColor = Color.DarkRed
            Label14.ForeColor = Color.DarkRed
            Label15.ForeColor = Color.DarkRed
            moveTime.BackColor = Color.DarkRed
            next_ALT.BackColor = Color.DarkRed
            next_AZ.BackColor = Color.DarkRed
            next_DEC_1.BackColor = Color.DarkRed
            next_DEC_2.BackColor = Color.DarkRed
            next_DEC_3.BackColor = Color.DarkRed
            next_DEC_4.BackColor = Color.DarkRed
            next_name.BackColor = Color.DarkRed
            next_RA_h.BackColor = Color.DarkRed
            next_RA_m.BackColor = Color.DarkRed
            next_RA_s.BackColor = Color.DarkRed
            Label22.BackColor = Color.DarkRed
            MenuStrip1.BackColor = Color.Black
            MenuStrip1.ForeColor = Color.DarkRed
            FileToolStripMenuItem.ForeColor = Color.DarkRed
            EditToolStripMenuItem.ForeColor = Color.DarkRed
            ViewToolStripMenuItem.ForeColor = Color.DarkRed
            ToolsToolStripMenuItem.ForeColor = Color.DarkRed
            HelpToolStripMenuItem.ForeColor = Color.DarkRed
            NightModeOffToolStripMenuItem.Text = "Disable Night Mode"
        End If
    End Sub

#End Region
#Region "Form Sizing"

    Private Sub frm_main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            Panel_center.Width = Me.Width - 16
            Panel_center.Height = Me.Height - 27
            group_remote.Location = LockedLocation
            group_remote.Height = Me.Height - 450
            group_nextobject.Height = Me.Height - 70
            group_nextobject.Width = Panel_center.Width - group_currentobject.Width - 10
            TabControl1.Size = New Drawing.Size(Me.Width - 565, Me.Height - 140)
            panel_buttons.Location = Point.Add(Origin, New Size(6, 239))
        ElseIf Me.WindowState = FormWindowState.Minimized Then
            Panel_center.Width = 1184
            group_remote.Location = LockedLocation
            group_remote.Height = 315
            group_nextobject.Height = 682
            group_nextobject.Width = 962
            TabControl1.Size = New Drawing.Size(638, 616)
            panel_buttons.Location = Point.Add(Origin, New Size(6, 238))
        Else
            AdjustForm()
        End If
    End Sub

    Public Sub AdjustForm()
        Panel_center.Width = Me.Width
        Panel_center.Height = Me.Height
        group_remote.Location = LockedLocation
        group_remote.Height = Me.Height - 450
        group_nextobject.Height = group_currentobject.Height + group_telescope.Height + group_remote.Height + 9
        group_nextobject.Width = Panel_center.Width - 30
        TabControl1.Size = New Drawing.Size(Me.Width - 590, Me.Height - 250)
        panel_buttons.Location = Point.Add(Origin, New Size(6, 238))
    End Sub

#End Region
#Region "Open Debug Screen"

    Private Sub lbl_screenlog_Click(sender As Object, e As EventArgs) Handles DEBUGToolstripMenuItem.Click
        frm_debug.Show()
        frm_debug.btn_refresh.PerformClick()
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs)
        frm_remotesetup.Show()
    End Sub

#End Region

#Region "CLOSE"

    Private Sub frm_main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        F.WriteToLog("  ~Logged Out @ " + Today.ToShortTimeString + Environment.NewLine, True)
    End Sub

    Private Sub frm_main_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If CompletelyExit = True Then
            frm_Startup.Close()
        End If
    End Sub

#End Region

#Region "UI Controls"

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        moveTime.Select()  'if user accidentally presses "seconds" it will automatically select the move time instead
    End Sub

    Private Sub btn_SlewTo_Click(sender As Object, e As EventArgs) Handles btn_SlewTo.Click

    End Sub

    Private Sub btn_loadHome_Click(sender As Object, e As EventArgs) Handles btn_loadHome.Click

    End Sub

    Private Sub btn_loadmounting_Click(sender As Object, e As EventArgs) Handles btn_loadmounting.Click

    End Sub

    Private Sub btn_linkTheSky_Click(sender As Object, e As EventArgs) Handles btn_linkTheSky.Click

    End Sub

    Private Sub btn_readTheSky_Click(sender As Object, e As EventArgs) Handles btn_readTheSky.Click

    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

    End Sub

    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click

    End Sub

    Private Sub btn_movetonext_Click(sender As Object, e As EventArgs) Handles btn_movetonext.Click

    End Sub

    Private Sub btn_survey_Click(sender As Object, e As EventArgs) Handles btn_survey.Click

    End Sub

    Private Sub btn_movetime_Click(sender As Object, e As EventArgs) Handles btn_movetime.Click

    End Sub

    Private Sub btn_sortalphabet_Click(sender As Object, e As EventArgs) Handles btn_sortalphabet.Click

    End Sub

    Private Sub btn_sortRAscension_Click(sender As Object, e As EventArgs) Handles btn_sortRAscension.Click

    End Sub

    'shows remote setup screen when clicking on remote (if its disconnected)
    Private Sub lbl_remotestatustitle_Click(sender As Object, e As EventArgs) Handles lbl_remotestatustitle.Click
        frm_remotesetup.Show()
    End Sub

    'opens user preferences control window
    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click

    End Sub










































#End Region

End Class