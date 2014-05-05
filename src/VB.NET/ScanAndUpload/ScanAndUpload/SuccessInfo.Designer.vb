<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuccessInfo
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
        Me.lblLink = New System.Windows.Forms.LinkLabel
        Me.button1 = New System.Windows.Forms.Button
        Me.lblInfo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblLink
        '
        Me.lblLink.AutoSize = True
        Me.lblLink.Location = New System.Drawing.Point(12, 47)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(55, 13)
        Me.lblLink.TabIndex = 5
        Me.lblLink.TabStop = True
        Me.lblLink.Text = "linkLabel1"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(194, 82)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "OK"
        Me.button1.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(12, 25)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(421, 20)
        Me.lblInfo.TabIndex = 3
        Me.lblInfo.Text = "label1"
        '
        'SuccessInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 122)
        Me.Controls.Add(Me.lblLink)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.lblInfo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SuccessInfo"
        Me.Text = "SuccessInfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblLink As System.Windows.Forms.LinkLabel
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents lblInfo As System.Windows.Forms.Label
End Class
