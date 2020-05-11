
' Description: This file contains every general function/sub for ITAS. Each form calls upon the following namespaces in some way.

'  Start Date: 02/01/2020 
'  Last Updated: 05/04/2020
'  Framework: VB.NET 4.7
'  Email: launiusrb@jacks.sfasu.edu // rblaunius@gmail.com

Imports System
Imports System.IO

Namespace Common

    Public Class FileManager  'Class containing all functions/subs relating to creating, 

        Private NL As String = Environment.NewLine
        Private D As New DebugManager

        'Returns path/directory for log file, or creates a new one if the User is new
        Public Function GetUserLogPath(Initials As String, ParentPath As String) As String
            GetUserLogPath = ""
            If Directory.Exists(ParentPath) = False Then
                D.ErMsg(Me, "Directory (" + ParentPath + ") doesn't exist.", "00")
                Exit Function
            Else
                Dim allFiles() As String = Directory.GetFiles(ParentPath)
                Dim i As Integer
                Dim foundFile As Boolean
                For i = 0 To UBound(allFiles)
                    If allFiles(i).Contains(Initials) Then
                        GetUserLogPath = allFiles(i)
                        foundFile = True
                        Return GetUserLogPath
                        Exit Function
                    Else
                        foundFile = False
                    End If
                Next
                If foundFile = False Then
                    GetUserLogPath = ParentPath + Initials + "_log.txt"
                    CreateBlankFile(GetUserLogPath)
                    WriteToLog("Log File For:" + Initials + NL + "Created " + Today.ToShortDateString + " @ " + Today.ToShortTimeString + NL)
                    Return GetUserLogPath
                End If
            End If
        End Function

        'Creates any file given a valid input
        Public Sub CreateBlankFile(FullPath As String)
            If File.Exists(FullPath) = False Then
                Dim strw As StreamWriter
                strw = My.Computer.FileSystem.OpenTextFileWriter(FullPath, True)
                strw.Write("")
                strw.Close()
            Else
                D.ErMsg(Me, "The File (" + FullPath + ") does not exist.", "01")
            End If
        End Sub

        'Writes to any txt file
        Public Sub WriteToFile(PathName As String, Content As String, Optional DoubleSpacePadding As Boolean = False)
            If Directory.Exists(PathName) Then
                If PathName.Contains("txt") = False Then
                    D.ErMsg(Me, "Cannot write to file (" + PathName + ") because path is not a text file.", "02")
                    Exit Sub
                End If
                Dim strw1 As StreamWriter
                strw1 = My.Computer.FileSystem.OpenTextFileWriter(PathName, True)
                If DoubleSpacePadding = True Then
                    strw1.Write(NL + Content + NL)
                Else
                    strw1.Write(Content)
                End If
                strw1.Close()
            Else
                D.ErMsg(Me, "Invalid path (" + PathName + ")", "03")
            End If
        End Sub

        'Writes to log file (implicit)
        Public Sub WriteToLog(Content As String, Optional DoubleSpacePadding As Boolean = False)
            Dim Path As String = My.Settings.LogPath
            If File.Exists(Path) Then
                Dim strw2 As StreamWriter
                strw2 = My.Computer.FileSystem.OpenTextFileWriter(Path, True)
                If DoubleSpacePadding = True Then
                    strw2.Write(NL + Content + NL)
                Else
                    strw2.Write(Content)
                End If
                strw2.Close()
            Else
                D.ErMsg(Me, "Log path (" + Path + ") is invalid.", "04")
            End If
        End Sub

        'Erases all log files (implicit)
        Public Sub EraseAllLogs()
            If File.Exists(My.Settings.LogFolder) = False Then
                MsgBox("No files were erased.")
                Exit Sub
            Else
                Dim allFiles() As String = Directory.GetFiles(My.Settings.LogFolder)
                Dim i As Integer
                Dim totfiles As Integer = UBound(allFiles)
                For i = 0 To totfiles
                    File.Delete(allFiles(i))
                Next
                MsgBox("Deleted " + totfiles + " log files.")
            End If
        End Sub
    End Class


    Public Class DebugManager
        'Writes and displays an error message to a msgbox? Not sure if this is necessary
        Public Sub ErMsg(Sender As Object, Optional Content As String = "", Optional Reference As String = "NA")
            Dim style As MsgBoxStyle = New MsgBoxStyle = MsgBoxStyle.Critical
            Dim NL As String = Environment.NewLine
            MsgBox("-ERROR- " + Content + NL + "Sender: " + Sender.ToString + ".vb" + NL + "Error code: " + Reference + NL)
        End Sub
    End Class

End Namespace

Namespace Control

    Public Module Telescope 'Possible that this module can be in its own independent .vb file - Needs work
        Private NL As String = Environment.NewLine

        'Move 41" Telescope
        Public Class T41
            Public Sub Move(XAmount As Double, YAmount As Double)
            End Sub
            Public Sub Rotate(Angle1 As Double, Angle2 As Double)
            End Sub
        End Class

        'Move 18" Telescope
        Public Class T18
            Public Sub Move(ByVal XAmount As Double, ByVal YAmount As Double)
            End Sub
            Public Sub Rotate(ByVal theta As Double, ByVal psi As Double)
            End Sub
        End Class

    End Module

    Public Module Remote
        Private NL As String = Environment.NewLine

        Public Class Remote 'Controls everything relating to remote (will be called upon in main form when remote is connected?)

            'Returns True if the remote is connected
            Public Function IsConnected() As Boolean
                '
                'CODE TO CHECK IF USB REMOTE IS CONNECTED
                '
                Return IsConnected
            End Function

            Public Sub RemoteCommands()
                '
                'CODE THAT RELATES REMOTE CONTROLS WITH TELESCOPE
                '
            End Sub

            'Displays press-down effect on remote's graphic - indicates button was pressed
            Public Sub WhenRemotePressed_Visual(Remote_BtnName As String)
                Remote_BtnName = Remote_BtnName.ToLower
                Select Case Remote_BtnName 'the following cases are the (soon-to-be) declared names of the buttons on the remote (analog)
                    Case "remote_btn_a"
                        'code to execute WHEN user presses remote_btn_a
                        'this code will not control telescope or any buttons...
                        'it will just display in real time on screen what's being pressed (and potentially could save to log file? idk)
                    Case "remote_btn_b"
                    Case "remote_btn_c"
                    Case "remote_up"
                    Case "remote_down"
                    Case "remote_right"
                    Case "remote_left"
                    Case "remote_select"
                    Case Else
                        MsgBox("See MasterFunctions.Control.Other.WhenRemotePressed_Visual")
                        Exit Sub
                End Select
            End Sub

        End Class

    End Module
End Namespace









