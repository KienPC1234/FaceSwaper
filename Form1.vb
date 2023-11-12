Imports System.IO
Imports System.Linq
Imports System
Imports System.Net.Http
Imports System.Security.Policy
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Diagnostics
Imports System.Threading
Public Class Form1

    Private pic2 As Image
    Private filepath1 As String
    Private filepath2 As String
    Private appver As Single = 1.2
    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        DrawBorder(sender, Color.Green) ' Change to your preferred color
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        DrawBorder(sender, PictureBox1.BackColor) ' Reset border color to original color
    End Sub

    Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        DrawBorder(sender, Color.Green) ' Change to your preferred color
        If Not pic2 Is Nothing Then
            PictureBox2.Image = DirectCast(pic2.Clone(), Image)
        End If
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        DrawBorder(sender, PictureBox2.BackColor) ' Reset border color to original color
        If Not pic2 Is Nothing Then
            PictureBox2.Image = DirectCast(pic2.Clone(), Image)
        End If
    End Sub

    Private Sub DrawBorder(ByVal sender As Object, ByVal borderColor As Color)
        Dim picBox As PictureBox = DirectCast(sender, PictureBox)
        picBox.Refresh()
        ControlPaint.DrawBorder(picBox.CreateGraphics(), picBox.ClientRectangle, borderColor, ButtonBorderStyle.Solid)
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaterialSlider3.Value = Environment.ProcessorCount
        MaterialSlider3.RangeMax = Environment.ProcessorCount
        ToolStripStatusLabel1.Text = "Chưa Có Tác Vụ Gì"
        ToolStripStatusLabel1.ForeColor = Color.Gold
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.Icon = New Icon(My.Application.Info.DirectoryPath & "\datas\icon.ico")
        Dim dir2 As String = My.Application.Info.DirectoryPath & "\cache"
        Dim dir3 As String = My.Application.Info.DirectoryPath & "\cache\output"
        Me.Text = "Face Swaper"
        Directory.CreateDirectory(dir2)
        Directory.CreateDirectory(dir3)
        Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
        Dim filePath As String = dir & "\dat1.dat"
        If File.Exists(filePath) Then
            ' Read all lines from the file
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
                TextBox3.Text = ix
                TextBox4.Text = iy
                NumericUpDown1.Value = th
                TextBox6.Text = imgq
                ComboBox3.Text = model
                ComboBox1.Text = echanmd
                MaterialSlider1.Value = echble
                MaterialSlider2.Value = videoout
                CheckBox1.Checked = kvfps
                Label29.Text = appver
                ' Now you can use the variables ix, iy, th, imgq, and model in your code
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Chọn File Lấy Mặt"
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Store the selected file path in file1_path
            filepath1 = openFileDialog.FileName
            ' Display the file path in a Label control
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            TextBox1.Text = filepath1
        End If


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Chọn File Lấy Mục Tiêu"
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Store the selected file path in file1_path
            filepath2 = openFileDialog.FileName
            ' Display the file path in a Label control
            pic2 = Image.FromFile(openFileDialog.FileName)
            TextBox2.Text = filepath2
            PictureBox2.Image = DirectCast(pic2.Clone(), Image)
        End If

    End Sub

    Sub CheckAndAddValuesToDatFile2(filePath As String, image As String)
        Dim valueLine As String = $"{image}"

        ' Check if the file exists
        If Not File.Exists(filePath) Then
            ' Create the file and add the line
            Using sw As StreamWriter = File.CreateText(filePath)
                sw.WriteLine(valueLine)
            End Using
        Else
            ' Overwrite the existing file with the new line
            Using sw As New StreamWriter(filePath, False) ' False means overwrite mode
                sw.WriteLine(valueLine)
            End Using
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
        Dim filePath2 As String = dir & "\dat1.dat"
        Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

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
            ' Now you can use the variables ix, iy, th, imgq, and model in your code
            If filepath1 Is Nothing Or filePath2 Is Nothing Then
                MessageBox.Show("Vui Lòng Chọn File Ảnh", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ToolStripStatusLabel1.Text = "Vui Lòng Chọn File Ảnh"
                ToolStripStatusLabel1.ForeColor = Color.Red
            ElseIf model Is Nothing Then
                MessageBox.Show("Vui Lòng Chọn Lại Model Ở Phần Cài Đặt", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim src As String
                src = TextBox1.Text
                Dim ost As String
                ost = TextBox2.Text
                ' Define the file paths
                Dim pythonEnvPath As String = Path.Combine(Directory.GetCurrentDirectory(), "Python39")
                Dim pythonExePath As String = Path.Combine(pythonEnvPath, "python.exe")
                Dim mainPyPath As String = "run.py"

                ' Define the command-line arguments for main.py   
                Dim random As New Random()
                Dim characters As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
                Dim outputFileName As String = New String(Enumerable.Repeat(characters, 12) _
                                                      .Select(Function(s) s(random.Next(s.Length))).ToArray()) & ".jpg"
                ' Now outputFileName contains a random string of 12 characters followed by ".jpg"
                Dim args As String = $"-s ""{src}"" -t ""{ost}"" -o cache/output/{outputFileName} --execution-thread-count {th} --output-image-quality {imgq} --face-swapper-model {model}  --headless --face-enhancer-model {echanmd} --face-enhancer-blend {echble} --frame-processors face_swapper face_enhancer"
                Dim data As String = My.Application.Info.DirectoryPath & "\datas"
                ' Create the command to run main.py using python.exe
                Dim command As String = $"""{pythonExePath}"" {mainPyPath} {args}"

                ' Print the command to the console
                Console.WriteLine(command)
                ' Run the command
                Form2.Show()
                Task.Run(Sub()
                             Dim process As New Process()
                             process.StartInfo.FileName = "cmd.exe"
                             process.StartInfo.Arguments = "/K " & command
                             process.StartInfo.UseShellExecute = False
                             process.StartInfo.RedirectStandardInput = True
                             process.StartInfo.RedirectStandardOutput = True
                             process.StartInfo.CreateNoWindow = True
                             Dim filePath3 As String = data & "\debug.dat"
                             CheckAndAddValuesToDatFile2(filePath3, command)

                             process.Start()

                             Dim writer As StreamWriter = process.StandardInput
                             writer.WriteLine(command)
                             writer.WriteLine("exit")
                             writer.Close()
                             process.WaitForExit()
                             Dim filePath4 As String = data & "\imageout.dat"
                             Dim dir2 As String = My.Application.Info.DirectoryPath & "\cache\output"
                             Dim filePath As String = dir2 & $"\{outputFileName}"
                             If Not File.Exists(filePath) Then
                                 Me.StatusStrip1.Invoke(Sub() ToolStripStatusLabel1.Text = "Thực Hiện Thất Bại")
                                 Me.StatusStrip1.Invoke(Sub() ToolStripStatusLabel1.ForeColor = Color.Red)
                                 Me.Invoke(Sub() MessageBox.Show("Tạo File Ảnh Thất Bại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error))
                                 Me.Invoke(Sub() Form2.Close())
                             Else
                                 Me.StatusStrip1.Invoke(Sub() ToolStripStatusLabel1.Text = "Thực Hiện Thành Công")
                                 Me.StatusStrip1.Invoke(Sub() ToolStripStatusLabel1.ForeColor = Color.LightGreen)
                                 CheckAndAddValuesToDatFile2(filePath4, filePath)
                                 Me.Invoke(Sub() Form2.Close())
                                 Me.Invoke(Sub() FormImage.Show())
                             End If
                         End Sub)



            End If
        Next



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
            ' Overwrite the existing file with the new line
            Using sw As New StreamWriter(filePath, False) ' False means overwrite mode
                sw.WriteLine(valueLine)
            End Using
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ix As String
        Dim iy As String
        Dim th As String
        Dim imgq As String
        Dim model As String
        Dim echanmd As String
        Dim echble As String
        Dim videoout As String
        Dim kvfps As String
        model = ComboBox3.Text
        echanmd = ComboBox1.Text
        echble = MaterialSlider1.Value
        videoout = MaterialSlider2.Value
        kvfps = CheckBox1.Checked
        ix = TextBox3.Text
        iy = TextBox4.Text
        th = NumericUpDown1.Value
        imgq = TextBox6.Text
        If Not IsNumeric(imgq) Or imgq < 0 Or imgq > 100 Then
            MessageBox.Show("Chỉ Chọn Ở Tầm 1>100 Và Phải Là Số Thực!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf th > Environment.ProcessorCount Or th < 1 Then
            MessageBox.Show("Số CPUs Của Bạn Nhập Lớn Hơn Số CPUs Mà Bạn Có Và Số CPUs Của Bạn Nhập Ít Nhất Phải Lớn Hơn 1!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
            Dim filePath As String = dir & "\dat1.dat"
            CheckAndAddValuesToDatFile(filePath, ix, iy, th, imgq, model, echanmd, echble, videoout, kvfps)
            MessageBox.Show("Đã Lưu Cài Đặt Thành Công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim url As String = "https://github.com/KienPC1234"
        Clipboard.SetText(url)
        MessageBox.Show("Đã Lưu URL Vào Clipboard!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim url As String = "https://github.com/henryruhs"
        Clipboard.SetText(url)
        MessageBox.Show("Đã Lưu URL Vào Clipboard!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim dir2 As String = My.Application.Info.DirectoryPath & "\cache\output"
        ' Kiểm tra xem thư mục còn chứa file nào không
        If Directory.GetFiles(dir2).Length = 0 Then
            MessageBox.Show("Đã Xóa Hết!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            For Each _file As String In Directory.GetFiles(dir2)
                Try
                    File.Delete(_file)
                Catch ex As IOException
                    MessageBox.Show("Không thể xóa file " & _file & " vì nó đang được sử dụng, nếu muốn xóa thì hãy reset lại App!.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Continue For
                End Try
            Next
            If Directory.GetFiles(dir2).Length = 0 Then
                MessageBox.Show("Đã Xóa Hết!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub



    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
        Dim filePath As String = dir & "\dat1.dat"
        If File.Exists(filePath) Then
            ' Read all lines from the file
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
                TextBox3.Text = ix
                TextBox4.Text = iy
                NumericUpDown1.Value = th
                TextBox6.Text = imgq
                ComboBox3.Text = model
                ComboBox1.Text = echanmd
                MaterialSlider1.Value = echble
                MaterialSlider2.Value = videoout
                CheckBox1.Checked = kvfps
            Next
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
        Dim filePath As String = dir & "\dat1.dat"
        CheckAndAddValuesToDatFile(filePath, 800, 600, Environment.ProcessorCount, 100, "inswapper_128", "gfpgan_1.4", 100, 100, False)
        Dim filePath2 As String = dir & "\dat1.dat"
        If File.Exists(filePath2) Then
            ' Read all lines from the file
            Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

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
                TextBox3.Text = ix
                TextBox4.Text = iy
                NumericUpDown1.Value = th
                TextBox6.Text = imgq
                ComboBox3.Text = model
                ComboBox1.Text = echanmd
                MaterialSlider1.Value = echble
                MaterialSlider2.Value = videoout
                CheckBox1.Checked = kvfps
            Next
        End If
    End Sub
    Private Async Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If My.Computer.Network.IsAvailable = True Then
            Dim url As String = "https://raw.githubusercontent.com/KienPC1234/FaceSwaper/main/ver.dat"
            Dim changelogUrl As String = "https://raw.githubusercontent.com/KienPC1234/FaceSwaper/main/chagelog.rtf"
            Dim webClient As New HttpClient()
            Dim ver As String = Await webClient.GetStringAsync(url)
            Dim verFloat As Single = Single.Parse(ver)

            If appver < verFloat Then
                MessageBox.Show($"Hãy Cập Nhật Phiên Bản Mới Nhất:{verFloat}", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf appver = verFloat Then
                MessageBox.Show("Phiên Bản Của Bạn Là Phiên Bản Mới Nhất", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Download the changelog and set it as the text for RichTextBox1
            Dim changelog As String = Await webClient.GetStringAsync(changelogUrl)
            RichTextBox1.Text = changelog
        Else
            MessageBox.Show("Không có kết nối internet. Vui lòng kiểm tra lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "(mp4,mov,wmv)|*.mp4;*.mov;*.wmv"
        If openFileDialog1.ShowDialog() = DialogResult.OK Then

            TextBox7.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If TextBox7.Text = Nothing Or Not File.Exists(TextBox7.Text) Then
            MessageBox.Show("Chưa Chọn File!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dir As String = My.Application.Info.DirectoryPath & "\VLC\VLCPortable.exe"
            Dim process As New Process()
            process.StartInfo.FileName = dir
            process.StartInfo.Arguments = """" & TextBox7.Text & """"
            process.Start()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Chọn File Lấy Mặt"
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox6.Image = DirectCast(Image.FromFile(openFileDialog.FileName).Clone(), Image)
            TextBox8.Text = openFileDialog.FileName
        End If
    End Sub
    Private Sub PictureBox6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseHover
        DrawBorder(sender, Color.Green) ' Change to your preferred color
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        DrawBorder(sender, PictureBox6.BackColor) ' Reset border color to original color
    End Sub


    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "MP4 files (*.mp4)|*.mp4"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fs As FileStream = File.Create(saveFileDialog1.FileName)
            fs.Close()
            TextBox9.Text = saveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Application.Exit()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
        Dim filePath2 As String = dir & "\dat1.dat"
        Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

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
            ' Now you can use the variables ix, iy, th, imgq, and model in your code
            If TextBox8.Text Is Nothing Or TextBox9.Text Is Nothing Or TextBox7.Text Is Nothing Then
                MessageBox.Show("Vui Lòng Chọn File Đủ File!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not File.Exists(TextBox8.Text) Or Not File.Exists(TextBox9.Text) Or Not File.Exists(TextBox7.Text) Then
                MessageBox.Show("Không Tìm Thấy File Được Nhập", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim kchoice As String
                If kvfps = True Then
                    kchoice = "--keep-fps"
                Else
                    kchoice = Nothing
                End If
                Dim pythonEnvPath As String = Path.Combine(Directory.GetCurrentDirectory(), "Python39")
                Dim pythonExePath As String = Path.Combine(pythonEnvPath, "python.exe")
                Dim mainPyPath As String = "run.py"
                Dim args As String = $"-s ""{TextBox8.Text}"" -t ""{TextBox7.Text}"" -o ""{TextBox9.Text}"" --execution-thread-count {th} --output-video-quality {videoout} --face-swapper-model {model}  --headless --face-enhancer-model {echanmd} --face-enhancer-blend {echble} --frame-processors face_swapper face_enhancer  --output-video-encoder libx265 {kchoice}"

                ' Create the command to run main.py using python.exe
                Dim command As String = $"""{pythonExePath}"" {mainPyPath} {args}"

                ' Print the command to the console
                Console.WriteLine(command)
                Form2.Show()
                Task.Run(Sub()
                             Dim process As New Process()
                             process.StartInfo.FileName = "cmd.exe"
                             process.StartInfo.Arguments = "/K " & command
                             process.StartInfo.UseShellExecute = False
                             process.StartInfo.RedirectStandardInput = True
                             process.StartInfo.RedirectStandardOutput = True ' Redirect StandardOutput
                             process.StartInfo.CreateNoWindow = True
                             Dim data As String = My.Application.Info.DirectoryPath & "\datas"
                             Dim filePath3 As String = data & "\debug.dat"
                             CheckAndAddValuesToDatFile2(filePath3, command)
                             process.Start()

                             ' Get the StreamWriter of the cmd.exe process's standard input.
                             Dim writer As StreamWriter = process.StandardInput

                             ' Write the command to the cmd.exe process's standard input.
                             writer.WriteLine(command)
                             writer.WriteLine("exit")
                             writer.Close()
                             process.WaitForExit()
                             Me.Invoke(Sub() Form2.Close())
                             Dim dir2 As String = My.Application.Info.DirectoryPath & "\VLC\VLCPortable.exe"
                             Dim process2 As New Process()
                             process2.StartInfo.FileName = dir2
                             process2.StartInfo.Arguments = """" & TextBox9.Text & """"
                             process2.Start()
                         End Sub)
            End If
        Next
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

        Dim pythonEnvPath As String = Path.Combine(Directory.GetCurrentDirectory(), "Python39")
        Dim pythonExePath As String = Path.Combine(pythonEnvPath, "python.exe")
        Dim mainPyPath As String = "run.py"
        Dim args As String = $"--ui-layouts {ComboBox2.Text} --execution-thread-count {MaterialSlider3.Value}"
        Dim command As String = $"""{pythonExePath}"" {mainPyPath} {args}"
        Console.WriteLine(command)
        Task.Run(Sub()
                     Dim process As New Process()
                     process.StartInfo.FileName = "cmd.exe"
                     process.StartInfo.Arguments = "/K " & command
                     process.StartInfo.UseShellExecute = False
                     process.StartInfo.RedirectStandardInput = True
                     process.StartInfo.RedirectStandardOutput = True ' Redirect StandardOutput
                     process.StartInfo.CreateNoWindow = True
                     Dim data As String = My.Application.Info.DirectoryPath & "\datas"
                     Dim filePath3 As String = data & "\debug.dat"
                     CheckAndAddValuesToDatFile2(filePath3, command)
                     process.Start()
                     Dim writer As StreamWriter = process.StandardInput
                     writer.WriteLine(command)
                     writer.WriteLine("exit")
                     writer.Close()
                     Thread.Sleep(1000)
                     MessageBox.Show("Vui Lòng Đợi Vài Giây Để Web Hoạt Động!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Dim process2 As New Process()
                     process2.StartInfo.FileName = "cmd.exe"
                     process2.StartInfo.Arguments = "/K " & "start /max http://localhost:7860/"
                     process2.StartInfo.UseShellExecute = False
                     process2.StartInfo.RedirectStandardInput = True
                     process2.StartInfo.RedirectStandardOutput = True ' Redirect StandardOutput
                     process2.StartInfo.CreateNoWindow = True
                     process2.Start()
                     Dim writer2 As StreamWriter = process2.StandardInput
                     process2.WaitForExit()
                     process.WaitForExit()
                     MessageBox.Show("Đã Tắt WebMode!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                 End Sub)
    End Sub
    Sub KillPythonProcesses()
        For Each proc As Process In Process.GetProcesses()
            If proc.ProcessName.ToLower().Contains("python") Then
                proc.Kill()
            ElseIf proc.ProcessName.ToLower().Contains("cmd") Then
                proc.Kill()
            End If
        Next
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        KillPythonProcesses()
    End Sub

End Class
