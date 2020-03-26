
'    Creators: Barrett Launius, (Original created by Dr. Dan Bruton: astro@sfasu.edu in VB6)
'  Start Date: 02/01/2020 
'   Framework: VB.NET 4.7
'       Email: launiusrb@jacks.sfasu.edu
'
' Description: This file contains every general function/sub for ITAS. 
'              Each form calls upon this file in some way.

Imports System
Imports System.IO

Namespace Common

    Public Class FileManager

        Private NL As String = Environment.NewLine
        Private D As New DebugManager

        'Returns log file path as string (implicit)
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
        'Creates any file 
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
                    D.ErMsg(Me, "Cannot write to file (" + PathName + ") because path is either invalid or has invalid extension.", "02")
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
                D.ErMsg(Me, "Error 75")
            End If
        End Sub
        'Writes to log file (implicit)
        Public Sub WriteToLog(Content As String, Optional DoubleSpacePadding As Boolean = False)
            Dim Path As String = My.Settings.LogPath
            If ValidPath(Path) = True Then
                Dim strw2 As StreamWriter
                strw2 = My.Computer.FileSystem.OpenTextFileWriter(Path, True)
                If DoubleSpacePadding = True Then
                    strw2.Write(NL + Content + NL)
                Else
                    strw2.Write(Content)
                End If
                strw2.Close()
            Else

                D.ErMsg(Me, "File path (" + Path + ") is invalid.", "03")
            End If
        End Sub
        'Returns True if input path is valid
        Public Function ValidPath(Path As String) As Boolean
            If File.Exists(Path) Then
                ValidPath = True
            Else
                ValidPath = False
            End If
            Return ValidPath
        End Function
        'Returns local Desktop directory as string (implicit)
        Public Function GetDesktop() As String
            GetDesktop = My.Computer.FileSystem.SpecialDirectories.Desktop.ToString
            Return GetDesktop
        End Function
        'Erases all log files (implicit)
        Public Sub EraseAllLogs()
            If ValidPath(My.Settings.LogFolder) = False Then
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
        'creates a shortcut for the .exe??
        Public Function CreateShortcut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Nullable
            Dim oShell As Object
            Dim oLink As Object
            Try
                oShell = CreateObject("WScript.Shell")
                oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")
                oLink.TargetPath = TargetName
                oLink.WindowStyle = 1
                oLink.Save()
            Catch ex As Exception
            End Try
            Return Nothing
        End Function

    End Class
    Public Class DebugManager
        'Writes and displays an error message to a msgbox
        Public Sub ErMsg(Sender As Object, Optional Content As String = "", Optional Reference As String = "NA")
            Dim style As MsgBoxStyle = New MsgBoxStyle = MsgBoxStyle.Critical
            Dim _l As String = Environment.NewLine
            MsgBox("-ERROR- " + Content + _l + "Sender: " + Sender.ToString + ".vb" + _l + "Error code: " + Reference + _l)
        End Sub
    End Class

End Namespace

Namespace Control

    Public Module Telescope
        Private _l As String = Environment.NewLine
        Private temp As New _temp._disp

        Public Class T41
            Public Sub Move(XAmount As Double, YAmount As Double)
            End Sub
            Public Sub Rotate(Angle1 As Double, Angle2 As Double)
            End Sub
        End Class

        Public Class T18
            Public Sub Move(ByVal XAmount As Double, ByVal YAmount As Double)
            End Sub
            Public Sub Rotate(ByVal theta As Double, ByVal psi As Double)
            End Sub
        End Class

    End Module
    Public Module Other
        Private NL As String = Environment.NewLine
        Private temp As New _temp._disp

        Public Class Remote

            'Returns True if the remote is connected
            Public Function IsConnected() As Boolean
                Return IsConnected
                temp.Show("IsConnected", IsConnected.ToString)
            End Function
            'Displays press-down effect on remote's graphic - indicates button was pressed
            Public Sub WhenRemotePressed_Visual(Remote_BtnName As String)
                Remote_BtnName = Remote_BtnName.ToLower
                Select Case Remote_BtnName 'the following cases are the (soon-to-be) declared names of the buttons on the remote (analog)
                    Case "remote_btn_a"
                        'code to execute WHEN user presses remote_btn_a
                        'this code will not control telescope or control any buttons,
                        'it will just display in real time on screen what's being pressed (and potentially could save to log file? idk)
                    Case "remote_btn_b"
                    Case "remote_btn_c"
                    Case "remote_up"
                    Case "remote_down"
                    Case "remote_right"
                    Case "remote_left"
                    Case "remote_select"
                    Case Else
                        MsgBox("ERROR")
                        Exit Sub
                End Select
            End Sub

        End Class

    End Module
End Namespace









