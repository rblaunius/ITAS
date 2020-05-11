' Description: This file contains every sub/function for the main form.

'  Start Date: 02/01/2020 
'  Last Updated: 05/04/2020
'  Framework: VB.NET 4.7
'  Email: launiusrb@jacks.sfasu.edu // rblaunius@gmail.com

Imports System.ComponentModel
Imports System
Imports System.IO
Imports System.IO.File
Imports System.Text
Imports ITAS.Common

Public Class frm_main

    'General environment/setup variables:
    Private F As New FileManager  'from MasterFunctions
    Private _l As String = Environment.NewLine
    Public UserInitials, LogPath, CurrentTelescope, OtherTelescope As String
    Public onlyloading As Boolean
    'Current object variables:
    Public current_name As String
    Public current_RA As String
    Public current_DEC As String
    Public current_UT As String
    Public current_LST As String
    'Data tables:
    Public strCatalog As New DataTable 'for bright stars data table? I might just use one data table (hence the name "strCatalog")
    Public data_v As New DataTable
    Public data_o As New DataTable
    Public data_DeepSky As New DataTable
    Public numberOfStars As Integer 'how many stars are stored in the starcatalog.txt file
    Public selectedIndex As Integer
    'Telescope variables:
    Public TrackingEnabled As Boolean = True
    'Interface/appearance variables:
    Public LockedLocation As Point
    Public Origin As Point
    Public SegoeUI As Font = New Font("Segoe UI", emSize:=12, FontStyle.Regular) 'create font for quick ref
    Public CompletelyExit As Boolean = True

#Region "ON LOAD"

    'Executes upon loading
    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        onlyloading = True
        Me.KeyPreview = True 'allows keyboard inputs/shorcuts
        RetrieveVariables()
        SetPrevConfig()
        CreatePoints()
        PopulateDataTable(strCatalog)
        Me.Text = "ITAS (May 2020)"
        Me.KeyPreview = True  'allows keyboard shortcuts
        onlyloading = False
        searchbar.Select()
    End Sub

    'Retrieves all variables from My.Settings
    Private Sub RetrieveVariables()
        UserInitials = My.Settings.User
        If UserInitials = "" Then
            OpenUserLogToolStripMenuItem.Text = "Open Guest's Log File"
        Else
            OpenUserLogToolStripMenuItem.Text = "Open " + UserInitials + "'s Log File"
        End If
        'Retreive more from my.settings as necessary
    End Sub

    'Sets previous UI configurations from My.Settings :
    Private Sub SetPrevConfig()
        'Set the UI colors to the last user's preferences:
        If My.Settings.StartDark = True Then
            goDark()
        ElseIf My.Settings.StartDark = False Then
            goBright()
        End If
        'Add more as neccessary
    End Sub

    'Creates points/origins/locations for objects (visuals)...
    ' changing these coordinates or deleting will mess up spacing when resizing (figure out a better way to manage in future) :
    Private Sub CreatePoints()
        Origin = Point.Add(group_currentobject.Location, New Drawing.Size(0, 0)) 'Defines origin (upper left) for canvas reference
        LockedLocation = Point.Add(Origin, New Drawing.Size(0, group_currentobject.Height + group_telescope.Height + 10))
        panel_buttons.Location = Point.Add(Origin, New Size(6, 238))
        group_remote.Location = LockedLocation
    End Sub

    'Populates specified data table (input may be redundant depending on whether or not we need more than one data table) :
    Public Sub PopulateDataTable(DataTableName As DataTable)
        'Create Columns :
        If onlyloading = True Then
            onlyloading = False
            With DataTableName
                .Columns.Add("Star Name", System.Type.GetType("System.String"))
                .Columns.Add("RA-h", System.Type.GetType("System.String"))
                .Columns.Add("RA-m", System.Type.GetType("System.String"))
                .Columns.Add("RA-s", System.Type.GetType("System.String"))
                .Columns.Add("DEC", System.Type.GetType("System.String"))
                .Columns.Add("DEC'", System.Type.GetType("System.String"))
                .Columns.Add("DEC""", System.Type.GetType("System.String"))
                .Columns.Add("Move Time", System.Type.GetType("System.String"))
            End With
            'Verify StarCatalog.txt file exists :
            If File.Exists("StarCatalog.txt") = False Then
                MsgBox("File (StarCatalog.txt) does not exist. Create the valid text file and place it into the same folder as ITAS.")
                Exit Sub
            End If
        End If

        'Count how many rows are in StarCatalog.txt :
        numberOfStars = getdatapoints()
        'Create array of separated rows :
        Dim reader As New StreamReader("StarCatalog.txt")  'in future, change txt file to a csv file so it may be compatible with excel
        Dim inp As String = ""
        Dim col() As String
        For k = 1 To numberOfStars
            inp = reader.ReadLine
            col = inp.Split(",")
            Dim newRow As DataRow = strCatalog.NewRow
            'Code to retreive each star data from txt file and insert into each row :
            newRow("Star Name") = col(0)
            newRow("RA-h") = col(1)
            newRow("RA-m") = col(2)
            newRow("RA-s") = col(3)
            newRow("DEC") = col(4)
            newRow("DEC'") = col(5)
            newRow("DEC""") = col(6)
            newRow("Move Time") = col(7)
            DataTableName.Rows.Add(newRow)
        Next
        reader.Close()
        grid1.DataSource = strCatalog

    End Sub

    'keyboard shortcut for search que (pressing enter will search)
    Private Sub frm_main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            If searchbar.Text IsNot "" Then
                btn_search.PerformClick()
            Else
                Exit Sub
            End If

        End If
    End Sub


#End Region


#Region "Menu/Toolbar"

    'opens user_log.txt :
    Private Sub OpenUserLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUserLogToolStripMenuItem.Click
        F.WriteToFile(frm_Startup.LogPath, sender.ToString)
        Dim pathname As String = frm_Startup.LogPath
        Process.Start(pathname)
    End Sub

    'logs out, closes main form, and opens startup form :
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        frm_Startup.Enabled = True
        frm_Startup.Show()
        Me.Hide()

        frm_Startup.Enabled = True
        Me.Enabled = False
        CompletelyExit = False
        frm_Startup.tb_initials.Select()
        Me.Close()
    End Sub

    'Closes program :
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        F.WriteToFile(LogPath, sender.ToString)
        Me.Hide()
        frm_Startup.Close()  'startup form controls whether app closes or not *I have found that less errors occur this way
    End Sub

    'Opens previous documentation for ITAS (in future, create updated html link)
    Private Sub DocumentationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DocumentationToolStripMenuItem1.Click
        Process.Start("http://www.physics.sfasu.edu/observatory/41-inch/itas2000.html")
    End Sub

    'Opens google maps at observatory location
    Private Sub GoogleEarthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleEarthToolStripMenuItem.Click
        Process.Start("https://earth.google.com/web/@31.7599981,-94.660994,150.53474939a,882.20855354d,35y,0h,45t,0r/data=CnEabxJpCiUweDg2Mzc5MjM3NTVkM2EzZTU6MHhmNTBiOTk2OGEzYjA4NTZmGaqFSDyPwj9AIYs2x7lNqlfAKi5TdGVwaGVuIEYuIEF1c3RpbiBTdGF0ZSBVbml2ZXJzaXR5IE9ic2VydmF0b3J5GAIgASgC")
    End Sub

    'Turns on or off night mode
    Public Sub NightModeOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NightModeOffToolStripMenuItem.Click
        changecolors()
    End Sub

    Private Sub GitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GitHubToolStripMenuItem.Click
        Process.Start("https://github.com/rblaunius/itas")
    End Sub

#End Region

#Region "Color/UI Preferences"

    Private Sub changecolors(Optional a As Boolean = True)
        If group_currentobject.ForeColor = Color.DarkRed Then
            goBright()
            NightModeOffToolStripMenuItem.Text = "Enable Night Mode"
        Else
            goDark()
            NightModeOffToolStripMenuItem.Text = "Disable Night Mode"
        End If
    End Sub

    Public Sub goDark()
        'Change button style to flat
        btn_resettelescope.FlatStyle = FlatStyle.Flat
        btn_SlewTo.FlatStyle = FlatStyle.Flat
        btn_loadHome.FlatStyle = FlatStyle.Flat
        btn_loadmounting.FlatStyle = FlatStyle.Flat
        btn_readTheSky.FlatStyle = FlatStyle.Flat
        btn_add.FlatStyle = FlatStyle.Flat
        btn_remove.FlatStyle = FlatStyle.Flat
        btn_linkTheSky.FlatStyle = FlatStyle.Flat
        btn_movetonext.FlatStyle = FlatStyle.Flat
        btn_survey.FlatStyle = FlatStyle.Flat
        'Change background color of buttons to dark grey
        btn_resettelescope.BackColor = Color.FromArgb(15, 15, 15)
        btn_SlewTo.BackColor = Color.FromArgb(15, 15, 15)
        btn_loadHome.BackColor = Color.FromArgb(15, 15, 15)
        btn_loadmounting.BackColor = Color.FromArgb(15, 15, 15)
        btn_readTheSky.BackColor = Color.FromArgb(15, 15, 15)
        btn_add.BackColor = Color.FromArgb(15, 15, 15)
        btn_remove.BackColor = Color.FromArgb(15, 15, 15)
        btn_linkTheSky.BackColor = Color.FromArgb(15, 15, 15)
        btn_movetonext.BackColor = Color.FromArgb(15, 15, 15)
        btn_survey.BackColor = Color.FromArgb(15, 15, 15)
        'Change background color of panels and tabs to black
        Panel_center.BackColor = Color.Black
        tab_brightstars.BackColor = Color.Black
        tab_deepsky.BackColor = Color.Black
        tab_othertargets.BackColor = Color.Black
        tab_variablestars.BackColor = Color.Black
        'Change foreground colors (text color) of all labels, buttons, etc. to Dark Red
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
        'Change Tabs

    End Sub
    Public Sub goBright()
        'Change button style to System (bright) - this also changes the Background color of buttons to white
        btn_resettelescope.FlatStyle = FlatStyle.System
        btn_SlewTo.FlatStyle = FlatStyle.System
        btn_loadHome.FlatStyle = FlatStyle.System
        btn_loadmounting.FlatStyle = FlatStyle.System
        btn_readTheSky.FlatStyle = FlatStyle.System
        btn_add.FlatStyle = FlatStyle.System
        btn_remove.FlatStyle = FlatStyle.System
        btn_linkTheSky.FlatStyle = FlatStyle.System
        btn_movetonext.FlatStyle = FlatStyle.System
        btn_survey.FlatStyle = FlatStyle.System
        btn_search.FlatStyle = FlatStyle.System
        btn_resetdata.FlatStyle = FlatStyle.System
        btn_remoterefresh.FlatStyle = FlatStyle.System
        'Change background color of panels to light grey 
        Panel_center.BackColor = Color.FromArgb(200, 200, 200)
        tab_brightstars.BackColor = Color.FromArgb(200, 200, 200)
        tab_deepsky.BackColor = Color.FromArgb(200, 200, 200)
        tab_othertargets.BackColor = Color.FromArgb(200, 200, 200)
        tab_variablestars.BackColor = Color.FromArgb(200, 200, 200)
        'Change colors of all texts and others to black
        Me.ForeColor = Color.Black
        group_currentobject.ForeColor = Color.Black
        group_nextobject.ForeColor = Color.Black
        group_remote.ForeColor = Color.Black
        group_telescope.ForeColor = Color.Black
        updown_frequency.BackColor = Color.Black
        updown_frequency.ForeColor = Color.Black
        Panel2.ForeColor = Color.Black
        Label10.ForeColor = Color.Black
        Label11.ForeColor = Color.Black
        Label12.ForeColor = Color.Black
        Label13.ForeColor = Color.Black
        Label14.ForeColor = Color.Black
        Label15.ForeColor = Color.Black
        Label23.ForeColor = Color.Black

        searchbar.BackColor = Color.White
        updown_frequency.BackColor = Color.White

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
    End Sub

#End Region

#Region "Form Sizing/Spacing"

    'Controls visual spacing/sizing of each panel, tab, and group according to window size
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
            grid1.Width = TabControl1.Width - 25
            grid1.Height = TabControl1.Height - 45
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

    'Updates the form size every time the window size changes
    Public Sub AdjustForm()
        Panel_center.Width = Me.Width
        Panel_center.Height = Me.Height
        group_remote.Location = LockedLocation
        group_remote.Height = Me.Height - 450
        group_nextobject.Height = group_currentobject.Height + group_telescope.Height + group_remote.Height + 9
        group_nextobject.Width = Panel_center.Width - 30
        TabControl1.Size = New Drawing.Size(Me.Width - 590, Me.Height - 250)
        panel_buttons.Location = Point.Add(Origin, New Size(6, 238))
        grid1.Width = TabControl1.Width - 6
        grid1.Height = TabControl1.Height - 40
    End Sub

#End Region

#Region "All Buttons/Controls"
    'The following subs control every button/control in this form. Some relate back to the MasterFunctions.vb file.
    'The " MsgBox("Unifinished code") " is used for debugging to show which control does nothing... 
    ' this is because most controls refer to the telescope commands and need to be implemented and tested first.

    'This will populate the "nextObject" panel whenever an object is selected from the grid
    Public Sub populateNextObject()
        Dim rownumber = grid1.CurrentRow.Index
        'Code to get the values per column in the data grid and set them in their respective places under the "next object" panel :
        MsgBox("Unifinished code")

    End Sub

    'counts how many stars are in txt :
    Public Function getdatapoints() As Integer
        Dim a As Integer
        a = File.ReadAllLines("StarCatalog.txt").Length - 1
        Return a
    End Function

    'Adjust the telescope to the selected object :
    Private Sub btn_SlewTo_Click(sender As Object, e As EventArgs) Handles btn_SlewTo.Click
        MsgBox("Unifinished code")
    End Sub

    'Load home coordinates (are these coordinates pre-loaded or user-defined?) :
    Private Sub btn_loadHome_Click(sender As Object, e As EventArgs) Handles btn_loadHome.Click
        MsgBox("Unifinished code")
    End Sub

    'Load mounting coordinates (are these coordinates like the reference coordinates?) :
    Private Sub btn_loadmounting_Click(sender As Object, e As EventArgs) Handles btn_loadmounting.Click
        MsgBox("Unifinished code")
    End Sub

    'Creates/verifies link to theSky (then what is the purpose of "Sync To..." in menu bar?) :
    Private Sub btn_linkTheSky_Click(sender As Object, e As EventArgs) Handles btn_linkTheSky.Click
        MsgBox("Unifinished code")
    End Sub

    'Reads coordinates from theSky :
    Private Sub btn_readTheSky_Click(sender As Object, e As EventArgs) Handles btn_readTheSky.Click
        MsgBox("Unifinished code")
    End Sub

    'Adds the "NextObject" to the catalog file :
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim newentry As String = """" + next_name.Text + """" + "," + next_RA_h.Text + "," + next_RA_m.Text + "," + next_RA_s.Text + "," + next_DEC_2.Text + "," + next_DEC_3.Text + "," + next_DEC_4.Text + "," + moveTime.Text
        'code to write to file :
        'code to refresh data :
    End Sub

    'Removes the entry from the catalog and txt file. Message box should appear to confirm/notify the user that you can't undo the action :
    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
        MsgBox("Unifinished code")
    End Sub

    'Moves telescope to Next Position :
    Private Sub btn_movetonext_Click(sender As Object, e As EventArgs) Handles btn_movetonext.Click
        MsgBox("Unifinished code")
    End Sub

    'Reset search (load default data table) :
    Private Sub btn_resetdata_Click(sender As Object, e As EventArgs) Handles btn_resetdata.Click
        searchbar.Text = ""
        grid1.ClearSelection()
    End Sub

    'Searches the object name from the DataBox (not the text file... easier this way) and selects it, or tells you nothing was found :
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'This code will get a list of the values in the "star names" column :
        Dim starnames_list As New List(Of Object)
        For Each row As DataGridViewRow In grid1.Rows
            starnames_list.Add(row.Cells(0).Value)
        Next
        'Convert list to array :
        Dim names = starnames_list.ToArray()
        'Remove parenthesese :
        For i = 0 To names.Length - 1
            names(i) = names(i).substring(1, names(i).length - 2)
        Next
        'Convert to string :
        Convert.ToString(names)
        'Search for the entered text :
        Dim que = searchbar.Text
        Dim k As Integer
        For k = 0 To names.Length - 1
            If names(k).ToString.ToLower.Contains(que) Then
                'code to hide all other values? :
                ' ~
                'code to select value:
                grid1.ClearSelection()
                grid1.Rows(k).Selected = True
                'populateNextObject()
                Exit For
                Exit Sub
            End If
            k = k
        Next
        If k = names.Length Then
            MsgBox("No object was found with the the search que, " + """" + que + """")
        End If
    End Sub

    'Unsure what this does :
    Private Sub btn_survey_Click(sender As Object, e As EventArgs) Handles btn_survey.Click
        MsgBox("Unifinished code")
    End Sub

    'Opens user preferences control window :
    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        frm_preferences.Show()
    End Sub

    'If user accidentally presses "seconds" text it will automatically select the input box instead
    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        moveTime.Select()
    End Sub

#End Region


#Region "ON CLOSE"

    'Logs out just before exiting app:
    Private Sub frm_main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        F.WriteToLog("  ~Logged Out @ " + Today.ToShortTimeString + Environment.NewLine, True)
    End Sub

    'Not sure if this is necessary, but used this code to add redundancy and make sure it completely exits/has time to save all settings
    Private Sub frm_main_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If CompletelyExit = True Then
            frm_Startup.Close()
        End If
    End Sub





#End Region

End Class