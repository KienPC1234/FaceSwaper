Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Public Class FormImage
    Private Sub FormImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Me.Size = New Size(ix, iy)

            Next
        End If
        Dim filePath2 As String = dir & "\imageout.dat"

        If File.Exists(filePath2) Then
            ' Read all lines from the file
            Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

            For Each line As String In lines
                ' Split the line into variables
                Dim vars As String() = line.Split(",")

                ' Assign values to variables
                Dim imagePath As String = vars(0)
                Me.BackgroundImage = Image.FromFile(imagePath)
            Next
        End If
    End Sub
    Private Sub FormImage_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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
                Me.Size = New Size(ix, iy)

            Next
        End If
        Dim filePath2 As String = dir & "\imageout.dat"

        If File.Exists(filePath2) Then
            ' Read all lines from the file
            Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

            For Each line As String In lines
                ' Split the line into variables
                Dim vars As String() = line.Split(",")

                ' Assign values to variables
                Dim imagePath As String = vars(0)
                Me.BackgroundImage = Image.FromFile(imagePath)
            Next
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png"
        saveFileDialog.Title = "Save an Image File"
        saveFileDialog.FileName = "image.jpg"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim dir As String = My.Application.Info.DirectoryPath & "\datas"
            Dim filePath2 As String = dir & "\imageout.dat"

            If File.Exists(filePath2) Then
                ' Read all lines from the file
                Dim lines As List(Of String) = File.ReadAllLines(filePath2).ToList()

                For Each line As String In lines
                    ' Split the line into variables
                    Dim vars As String() = line.Split(",")

                    ' Assign values to variables
                    Dim imagePath As String = vars(0)
                    Image.FromFile(imagePath).Save(saveFileDialog.FileName)
                Next
            End If
        End If
    End Sub
End Class