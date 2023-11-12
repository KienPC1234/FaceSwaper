<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

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
        Label2 = New Label()
        ProgressBar1 = New ProgressBar()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Cursor = Cursors.No
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.LawnGreen
        Label1.Location = New Point(12, 69)
        Label1.Name = "Label1"
        Label1.Size = New Size(136, 37)
        Label1.TabIndex = 0
        Label1.Text = "LOADING:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Cursor = Cursors.No
        Label2.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.LawnGreen
        Label2.Location = New Point(143, 69)
        Label2.Name = "Label2"
        Label2.Size = New Size(105, 37)
        Label2.TabIndex = 1
        Label2.Text = "STATUS"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 109)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(464, 33)
        ProgressBar1.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Cursor = Cursors.No
        Label3.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.LawnGreen
        Label3.Location = New Point(12, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(320, 37)
        Label3.TabIndex = 3
        Label3.Text = "LOADING FACE SWAPER..."
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(488, 154)
        ControlBox = False
        Controls.Add(Label3)
        Controls.Add(ProgressBar1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Cursor = Cursors.AppStarting
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form3"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        TransparencyKey = Color.Black
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label3 As Label
End Class
