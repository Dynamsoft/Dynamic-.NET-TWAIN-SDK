<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkContainer = New System.Windows.Forms.CheckBox
        Me.btnRemoveAllImages = New System.Windows.Forms.Button
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnCaptureImage = New System.Windows.Forms.Button
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbContainer = New System.Windows.Forms.Label
        Me.cbxSources = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(15, 90)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(120, 17)
        Me.chkContainer.TabIndex = 21
        Me.chkContainer.Text = "Set Video Container"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'btnRemoveAllImages
        '
        Me.btnRemoveAllImages.Location = New System.Drawing.Point(15, 182)
        Me.btnRemoveAllImages.Name = "btnRemoveAllImages"
        Me.btnRemoveAllImages.Size = New System.Drawing.Size(130, 23)
        Me.btnRemoveAllImages.TabIndex = 16
        Me.btnRemoveAllImages.Text = "Remove All Images"
        Me.btnRemoveAllImages.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.White
        Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(275, 295)
        Me.pictureBox1.TabIndex = 14
        Me.pictureBox1.TabStop = False
        '
        'btnCaptureImage
        '
        Me.btnCaptureImage.Location = New System.Drawing.Point(15, 141)
        Me.btnCaptureImage.Name = "btnCaptureImage"
        Me.btnCaptureImage.Size = New System.Drawing.Size(130, 23)
        Me.btnCaptureImage.TabIndex = 13
        Me.btnCaptureImage.Text = "Capture Image"
        Me.btnCaptureImage.UseVisualStyleBackColor = True
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.Single3D
        Me.dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.IfThrowException = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(160, 35)
        Me.dynamicDotNetTwain1.LogLevel = CType(1, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(280, 300)
        Me.dynamicDotNetTwain1.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.pictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(455, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 300)
        Me.Panel1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Webcam Source:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(160, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "ImageContainer:"
        '
        'lbContainer
        '
        Me.lbContainer.AutoSize = True
        Me.lbContainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbContainer.Location = New System.Drawing.Point(455, 16)
        Me.lbContainer.Name = "lbContainer"
        Me.lbContainer.Size = New System.Drawing.Size(101, 13)
        Me.lbContainer.TabIndex = 26
        Me.lbContainer.Text = "Video Container:"
        '
        'cbxSources
        '
        Me.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSources.FormattingEnabled = True
        Me.cbxSources.Location = New System.Drawing.Point(15, 35)
        Me.cbxSources.Name = "cbxSources"
        Me.cbxSources.Size = New System.Drawing.Size(131, 21)
        Me.cbxSources.TabIndex = 27
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.Color.Silver
        Me.label4.Location = New System.Drawing.Point(15, 120)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(130, 1)
        Me.label4.TabIndex = 28
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 347)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.cbxSources)
        Me.Controls.Add(Me.lbContainer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkContainer)
        Me.Controls.Add(Me.btnRemoveAllImages)
        Me.Controls.Add(Me.btnCaptureImage)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Webcam Demo"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkContainer As System.Windows.Forms.CheckBox
    Private WithEvents btnRemoveAllImages As System.Windows.Forms.Button
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnCaptureImage As System.Windows.Forms.Button
    Private WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbContainer As System.Windows.Forms.Label
    Friend WithEvents cbxSources As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label

End Class
