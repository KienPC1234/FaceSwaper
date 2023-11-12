Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports System.Threading
Public Class Form3

    ' Tạo một sự kiện mới
    Public Event ExtractionProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
    Sub zip()
        Form4.Show()
        Dim zipPath As String = My.Application.Info.DirectoryPath & "\Python39.zip"
        Dim extractPath As String = My.Application.Info.DirectoryPath

        ' Giải nén tệp
        Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
            Dim totalEntries As Double = archive.Entries.Count
            Dim currentEntry As Integer = 0

            For Each entry As ZipArchiveEntry In archive.Entries
                ' Kiểm tra và tạo thư mục nếu cần
                Dim fullPath As String = Path.Combine(extractPath, entry.FullName)
                If entry.FullName.EndsWith("/") Then ' Nếu là thư mục
                    Directory.CreateDirectory(fullPath)
                Else ' Nếu là tệp
                    ' Tạo thư mục chứa tệp nếu chưa tồn tại
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath))

                    ' Giải nén tệp hiện tại
                    entry.ExtractToFile(fullPath, True)
                End If

                ' Cập nhật tiến trình giải nén
                currentEntry += 1
                Dim progress As Integer = CInt((currentEntry / totalEntries) * 100)
                RaiseEvent ExtractionProgressChanged(Me, New ProgressChangedEventArgs(progress, Nothing))
            Next
        End Using

        ' Xóa tệp zip sau khi giải nén
        System.IO.File.Delete(zipPath)
        Form4.Hide()
    End Sub
    Sub CheckAndAddValuesToDatFile(filePath As String, ix As Integer, iy As Integer, th As Integer, imgq As Integer, model As String, echanmd As String, echble As Integer, videoout As Integer, kvfps As Boolean)
        Dim valueLine As String = $"{ix},{iy},{th},{imgq},{model},{echanmd},{echble},{videoout},{kvfps}"

        ' Check if the file exists
        If Not File.Exists(filePath) Then
            ' Create the file and add the line
            Using sw As StreamWriter = File.CreateText(filePath)
                sw.WriteLine(valueLine)
            End Using
        Else
            ' Read all lines from the file
            Dim lines As List(Of String) = File.ReadAllLines(filePath).ToList()

            ' Check if the line exists in the file
            If Not lines.Contains(valueLine) Then
                ' Append the line to the existing file
                Using sw As StreamWriter = File.AppendText(filePath)
                    sw.WriteLine(valueLine)
                End Using
            End If
        End If
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(My.Application.Info.DirectoryPath & "\Python39.zip") Then
            zip()
        End If
        If My.Computer.Network.IsAvailable = True Then
            Dim dir2 As String = My.Application.Info.DirectoryPath & "\cache"
            Dim dir3 As String = My.Application.Info.DirectoryPath & "\cache\output"
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximumSize = Me.Size
            Me.MinimumSize = Me.Size
            Me.TopMost = True
            Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
            Dim filePath As String = dir & "\dat1.dat"
            Dim filePath2 As String = dir & "\imageout.dat"
            Dim filePath3 As String = dir & "\debug.dat"
            Directory.CreateDirectory(dir2)
            Directory.CreateDirectory(dir3)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If
            If Not File.Exists(filePath) Then
                Using fs As FileStream = File.Create(filePath)
                End Using
                CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
            End If
            If Not Directory.Exists(filePath2) Then
                Using fs As FileStream = File.Create(filePath2)
                End Using
            End If
            If Not Directory.Exists(filePath3) Then
                Using fs As FileStream = File.Create(filePath3)
                End Using
            End If
            Try
                Dim lines As List(Of String) = File.ReadAllLines(filePath).ToList()
                For Each line As String In lines
                    ' Split the line into variables
                    Dim vars As String() = line.Split(",")

                    ' Assign values to variables
                    Dim ix As Integer = Integer.Parse(vars(0))
                    Dim iy As Integer = Integer.Parse(vars(1))
                    Dim th As Integer = Integer.Parse(vars(2))
                    Dim imgq As Integer = Integer.Parse(vars(3))
                    Dim model As String = vars(4)
                    Dim echanmd As String = vars(5)
                    Dim echble As Integer = Integer.Parse(vars(6))
                    Dim videoout As Integer = Integer.Parse(vars(7))
                    Dim kvfps As Boolean = Boolean.Parse(vars(8))
                Next
            Catch ex As IndexOutOfRangeException
                ' Handle the case where the key is out of range
                CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
            Catch ex As KeyNotFoundException
                ' Handle the case where the key is missing
                CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
            Catch ex As InvalidCastException
                ' Handle the case where the key is not of the correct type
                CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
            Catch ex As Exception
                ' Handle any other exceptions
                CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
            End Try
            ProgressBar1.Value = 10
            Label2.Text = "Checking File..."
            Thread.Sleep(100)
            ProgressBar1.Value = 100
            Label2.Text = "Thành Công!"
            Thread.Sleep(100)
            Task.Run(Sub()
                         Thread.Sleep(1000)
                         Invoke(Sub() Me.Hide()) ' Hide the form on the UI thread
                     End Sub)
            Form1.Show()

        Else
            MessageBox.Show("Không có kết nối internet. Vui lòng kiểm tra lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

    End Sub

End Class