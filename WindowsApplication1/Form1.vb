Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Xml

Public Class formSentry

    Private Declare Function GetLastInputInfo Lib "User32.dll" (ByRef lastInput As LASTINPUTINFO) As Boolean

    <StructLayout(LayoutKind.Sequential)> Public Structure LASTINPUTINFO
        Public cbSize As Int32
        Public dwTime As Int32
    End Structure

    Dim hostName As String = Environment.MachineName
    Dim userName As String = Environment.UserName
    Dim typePersonal As String = "Personal"
    Dim typeAcademic As String = "Academic"
    Dim startTime = DateTime.Now
    Dim addComma As String = ","

    Dim startUpWriteMsg As String = hostName & addComma & userName & addComma & typePersonal & addComma & startTime.ToString()
    Dim academicWriteMsg As String = hostName & addComma & userName & addComma & typeAcademic & addComma & startTime.ToString()

    Dim homePath As String = "\\NISSRV5\NLCLabManager$\Sentry\"
    Dim csvPath As String = hostName & "\" & hostName & ".csv"
    Dim shutdownFilePath As String = homePath & hostName & "\shutdown.txt"

    Dim pauseTime As Integer = 1000 * 60

    Dim shutdownThread As New System.Threading.Thread(AddressOf keepShutdownFileActive)
    Dim idleThread As New System.Threading.Thread(AddressOf idleDetector)

    Dim newInfo As String = "1"
    Dim updateInfo As String = "3"
    Dim closeInfo As String = "0"

    Dim urlPath As String = "https://www.ntid.rit.edu/nlc/sentry?"
    Dim newUrl As String = urlPath & "&host=" & hostName & "&user=" & userName & "&priority=" & typePersonal & "&status=" & newInfo
    Dim updateUrl As String = urlPath & "&host=" & hostName & "&status=" & updateInfo
    Dim closeUrl As String = urlPath & "&host=" & hostName & "&status=" & closeInfo

    Private Sub formSentry_Load(sender As Object, e As EventArgs) Handles Me.Load

        'MessageBox.Show(homePath & csvPath)
        directoryDuty(homePath, 1)
        writeCSV(homePath & csvPath, 1)
        sendUrl(1)

        shutdownThread.Start()
        idleThread.Start()

        'testXML()

    End Sub

    Private Sub buttonAcademic_Click(sender As Object, e As EventArgs) Handles buttonAcademic.Click

        writeCSV(homePath & csvPath, 3)
        sendUrl(3)

        'Me.Hide()


    End Sub

    Private Sub buttonPersonal_Click(sender As Object, e As EventArgs) Handles buttonPersonal.Click

        'Me.Hide()

    End Sub

    Private Sub directoryDuty(path As String, action As Integer)

        Select Case action
            Case 0
                My.Computer.FileSystem.DeleteFile(shutdownFilePath)
            Case 1
                If Not Directory.Exists(path) Then
                    My.Computer.FileSystem.CreateDirectory(homePath)
                    createFile(homePath & csvPath)
                Else
                    If Not File.Exists(path & csvPath) Then
                        createFile(homePath & csvPath)
                    End If
                End If

                If Not File.Exists(shutdownFilePath) Then
                    createFile(shutdownFilePath)
                Else
                    writeCSV(homePath & csvPath, 0)
                    My.Computer.FileSystem.DeleteFile(shutdownFilePath)
                    createFile(shutdownFilePath)
                End If
        End Select


    End Sub

    Private Sub createFile(path As String)

        Dim fs As FileStream = File.Create(path)
        fs.Close()

    End Sub

    Private Sub deleteFile(path As String)

    End Sub

    Private Sub writeCSV(path As String, action As Integer)

        Select Case action
            Case 0

                Dim endTime = File.GetLastWriteTime(shutdownFilePath)

                My.Computer.FileSystem.WriteAllText(path, addComma & endTime.ToString() & vbCrLf, True)

            Case 1

                My.Computer.FileSystem.WriteAllText(path, startUpWriteMsg, True)

            Case 3

                Dim arrText() As String = File.ReadAllLines(homePath & csvPath)

                My.Computer.FileSystem.DeleteFile(homePath & csvPath)
                createFile(homePath & csvPath)

                Using objWriter As StreamWriter = New StreamWriter(homePath & csvPath)
                    For I As Integer = 1 To arrText.Length - 1
                        objWriter.WriteLine(arrText(I))
                    Next
                End Using

                My.Computer.FileSystem.WriteAllText(path, academicWriteMsg, True)

        End Select


    End Sub

    Private Sub idleDetector()

        Do While True
            Dim lastInput As New LASTINPUTINFO

            lastInput.cbSize = Marshal.SizeOf(lastInput)

            If GetLastInputInfo(lastInput) Then
                'MessageBox.Show((Environment.TickCount - lastInput.dwTime) / 1000)
                If ((Environment.TickCount - lastInput.dwTime) / 1000) > 600 Then
                    'MessageBox.Show("Idle for 10 minutes!")
                End If
            End If

            System.Threading.Thread.Sleep(pauseTime)
        Loop

    End Sub

    Private Sub keepShutdownFileActive()

        Do While True

            My.Computer.FileSystem.WriteAllText(shutdownFilePath, " ", True)
            System.Threading.Thread.Sleep(pauseTime)

        Loop

    End Sub

    Private Sub sendUrl(action As Integer)

        Dim ie As Object
        ie = CreateObject("InternetExplorer.Application")

        Select Case action
            Case 0 'Closing
                ie.navigate(closeUrl)
            Case 1 'New
                ie.navigate(newUrl)
            Case 3 'Update Priority
                ie.navigate(updateUrl)
        End Select

    End Sub

    Private Sub formSentry_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        writeCSV(homePath & csvPath, 0)
        directoryDuty(shutdownFilePath, 0)
        sendUrl(0)

        shutdownThread.Abort()
        idleThread.Abort()

    End Sub

    Sub testXML()

        Dim reader As XmlTextReader = New XmlTextReader("\\NISSRV5\NLCLabManager$\Sentry\survey.xml")

        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Display beginning of element.
                    MessageBox.Show(reader.Name)
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            'Display attribute name and value.
                            MessageBox.Show(reader.Name & " " & reader.Value)
                        End While
                    End If
                Case XmlNodeType.Text 'Display the text in each element.
                    MessageBox.Show(reader.Value)
                Case XmlNodeType.EndElement 'Display end of element.
                    MessageBox.Show(reader.Name)
            End Select
        Loop

    End Sub

End Class
