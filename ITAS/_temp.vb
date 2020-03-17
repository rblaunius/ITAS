Imports System.IO
Imports System

'This module will run different debugging/display commands to see events and progress.
'It will not be used in the final build.

Namespace _temp

    Public Class _disp

        'Populates MsgBox with up to 4 lines of content
        Public Function Show(Title As String, Content As String, Optional Content2 As String = "", Optional content3 As String = "") As Nullable
            Dim l As String = Environment.NewLine
            MsgBox(Title + l + Content + l + Content2 + l + content3)
            Return Nothing
        End Function

    End Class

End Namespace


