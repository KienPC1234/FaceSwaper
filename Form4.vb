Imports System.ComponentModel
Imports System.Threading

Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        ' Đăng ký sự kiện ExtractionProgressChanged
        AddHandler Form3.ExtractionProgressChanged, AddressOf OnExtractionProgressChanged
    End Sub

    Private Sub OnExtractionProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
End Class
