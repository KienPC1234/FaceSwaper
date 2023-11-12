<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        ProgressBar1 = New ProgressBar()
        Process1 = New Process()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(12, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(353, 37)
        Label1.TabIndex = 1
        Label1.Text = "   Đang Thực Hiện Ghép Ảnh"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(33, 93)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(332, 23)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.TabIndex = 2
        ' 
        ' Process1
        ' 
        Process1.StartInfo.Domain = ""
        Process1.StartInfo.LoadUserProfile = False
        Process1.StartInfo.Password = Nothing
        Process1.StartInfo.StandardErrorEncoding = Nothing
        Process1.StartInfo.StandardInputEncoding = Nothing
        Process1.StartInfo.StandardOutputEncoding = Nothing
        Process1.StartInfo.UserName = ""
        Process1.SynchronizingObject = Me
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(390, 151)
        ControlBox = False
        Controls.Add(ProgressBar1)
        Controls.Add(Label1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Process1 As Process
End Class
