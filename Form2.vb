Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = New Icon(My.Application.Info.DirectoryPath & "\datas\icon.ico")
        ProgressBar1.Value = 0
        Me.MaximizeBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        ' Tạo một Timer mới.
        Dim Timer1 As New Timer()

        ' Đặt khoảng thời gian cho Timer (5000 ms = 5 giây).
        Timer1.Interval = 5000

        ' Thêm sự kiện Tick cho Timer.
        AddHandler Timer1.Tick, Sub(sender1, e1)
                                    ' Mỗi khi Timer tick, tăng giá trị của ProgressBar1 lên 2.
                                    If ProgressBar1.Value + 2 <= ProgressBar1.Maximum Then
                                        ProgressBar1.Value += 2
                                    Else
                                        ' Nếu giá trị của ProgressBar1 vượt quá Maximum, dừng Timer.
                                        Timer1.Stop()
                                    End If
                                End Sub

        ' Tạo một Timer mới cho việc thay đổi tiêu đề.
        Dim Timer2 As New Timer()

        ' Đặt khoảng thời gian cho Timer (1000 ms = 1 giây).
        Timer2.Interval = 1000

        ' Thêm sự kiện Tick cho Timer.
        AddHandler Timer2.Tick, Sub(sender2, e2)
                                    ' Mỗi khi Timer tick, thay đổi tiêu đề.
                                    If Me.Text = "Loading..." Then
                                        Me.Text = "Loading.."
                                    Else
                                        Me.Text = "Loading."
                                    End If
                                End Sub

        ' Bắt đầu Timer.
        Timer1.Start()
        Timer2.Start()
    End Sub
End Class
