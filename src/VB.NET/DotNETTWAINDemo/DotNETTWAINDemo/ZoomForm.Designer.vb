<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZoomForm
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
        Me.label1 = New System.Windows.Forms.Label
        Me.tbxZoomRatio = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.lnAngle = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(136, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(98, 15)
        Me.label1.TabIndex = 14
        Me.label1.Text = "%   (2% ~ 6500%)"
        '
        'tbxZoomRatio
        '
        Me.tbxZoomRatio.Location = New System.Drawing.Point(89, 10)
        Me.tbxZoomRatio.Name = "tbxZoomRatio"
        Me.tbxZoomRatio.Size = New System.Drawing.Size(47, 22)
        Me.tbxZoomRatio.TabIndex = 13
        Me.tbxZoomRatio.Text = "1000"
        Me.tbxZoomRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(27, 38)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lnAngle
        '
        Me.lnAngle.AutoSize = True
        Me.lnAngle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnAngle.Location = New System.Drawing.Point(12, 12)
        Me.lnAngle.Name = "lnAngle"
        Me.lnAngle.Size = New System.Drawing.Size(71, 15)
        Me.lnAngle.TabIndex = 10
        Me.lnAngle.Text = "Zoom Ratio:"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(144, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ZoomForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 72)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.tbxZoomRatio)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lnAngle)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ZoomForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zoom Image"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbxZoomRatio As System.Windows.Forms.TextBox
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents lnAngle As System.Windows.Forms.Label
    Public WithEvents btnCancel As System.Windows.Forms.Button
End Class
