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
        Me.chkIfThrowException = New System.Windows.Forms.CheckBox
        Me.chkContainer = New System.Windows.Forms.CheckBox
        Me.btnSelectSource = New System.Windows.Forms.Button
        Me.radioAll = New System.Windows.Forms.RadioButton
        Me.radioWebCam = New System.Windows.Forms.RadioButton
        Me.radioTwain = New System.Windows.Forms.RadioButton
        Me.btnRemoveAllImages = New System.Windows.Forms.Button
        Me.chkIfShowUI = New System.Windows.Forms.CheckBox
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnAcquireSource = New System.Windows.Forms.Button
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkIfThrowException
        '
        Me.chkIfThrowException.AutoSize = True
        Me.chkIfThrowException.Location = New System.Drawing.Point(363, 285)
        Me.chkIfThrowException.Name = "chkIfThrowException"
        Me.chkIfThrowException.Size = New System.Drawing.Size(115, 17)
        Me.chkIfThrowException.TabIndex = 22
        Me.chkIfThrowException.Text = "Throw Exception"
        Me.chkIfThrowException.UseVisualStyleBackColor = True
        '
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(363, 261)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(120, 17)
        Me.chkContainer.TabIndex = 21
        Me.chkContainer.Text = "Set Video Container"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'btnSelectSource
        '
        Me.btnSelectSource.Location = New System.Drawing.Point(363, 13)
        Me.btnSelectSource.Name = "btnSelectSource"
        Me.btnSelectSource.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectSource.TabIndex = 20
        Me.btnSelectSource.Text = "Select Source"
        Me.btnSelectSource.UseVisualStyleBackColor = True
        '
        'radioAll
        '
        Me.radioAll.AutoSize = True
        Me.radioAll.Location = New System.Drawing.Point(363, 157)
        Me.radioAll.Name = "radioAll"
        Me.radioAll.Size = New System.Drawing.Size(73, 17)
        Me.radioAll.TabIndex = 19
        Me.radioAll.Text = "All Source"
        Me.radioAll.UseVisualStyleBackColor = True
        '
        'radioWebCam
        '
        Me.radioWebCam.AutoSize = True
        Me.radioWebCam.Checked = True
        Me.radioWebCam.Location = New System.Drawing.Point(363, 121)
        Me.radioWebCam.Name = "radioWebCam"
        Me.radioWebCam.Size = New System.Drawing.Size(106, 17)
        Me.radioWebCam.TabIndex = 18
        Me.radioWebCam.TabStop = True
        Me.radioWebCam.Text = "WebCam Source"
        Me.radioWebCam.UseVisualStyleBackColor = True
        '
        'radioTwain
        '
        Me.radioTwain.AutoSize = True
        Me.radioTwain.Location = New System.Drawing.Point(363, 85)
        Me.radioTwain.Name = "radioTwain"
        Me.radioTwain.Size = New System.Drawing.Size(91, 17)
        Me.radioTwain.TabIndex = 17
        Me.radioTwain.Text = "Twain Source"
        Me.radioTwain.UseVisualStyleBackColor = True
        '
        'btnRemoveAllImages
        '
        Me.btnRemoveAllImages.Location = New System.Drawing.Point(363, 198)
        Me.btnRemoveAllImages.Name = "btnRemoveAllImages"
        Me.btnRemoveAllImages.Size = New System.Drawing.Size(110, 23)
        Me.btnRemoveAllImages.TabIndex = 16
        Me.btnRemoveAllImages.Text = "Remove All Images"
        Me.btnRemoveAllImages.UseVisualStyleBackColor = True
        '
        'chkIfShowUI
        '
        Me.chkIfShowUI.AutoSize = True
        Me.chkIfShowUI.Location = New System.Drawing.Point(363, 238)
        Me.chkIfShowUI.Name = "chkIfShowUI"
        Me.chkIfShowUI.Size = New System.Drawing.Size(76, 17)
        Me.chkIfShowUI.TabIndex = 15
        Me.chkIfShowUI.Text = "Show UI"
        Me.chkIfShowUI.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(492, 12)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(242, 224)
        Me.pictureBox1.TabIndex = 14
        Me.pictureBox1.TabStop = False
        '
        'btnAcquireSource
        '
        Me.btnAcquireSource.Location = New System.Drawing.Point(363, 45)
        Me.btnAcquireSource.Name = "btnAcquireSource"
        Me.btnAcquireSource.Size = New System.Drawing.Size(96, 23)
        Me.btnAcquireSource.TabIndex = 13
        Me.btnAcquireSource.Text = "Acquire Source"
        Me.btnAcquireSource.UseVisualStyleBackColor = True
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(12, 12)
        Me.dynamicDotNetTwain1.LogLevel = CType(1, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(327, 292)
        Me.dynamicDotNetTwain1.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 316)
        Me.Controls.Add(Me.chkIfThrowException)
        Me.Controls.Add(Me.chkContainer)
        Me.Controls.Add(Me.btnSelectSource)
        Me.Controls.Add(Me.radioAll)
        Me.Controls.Add(Me.radioWebCam)
        Me.Controls.Add(Me.radioTwain)
        Me.Controls.Add(Me.btnRemoveAllImages)
        Me.Controls.Add(Me.chkIfShowUI)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.btnAcquireSource)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
	Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = "Webcam Demo"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkIfThrowException As System.Windows.Forms.CheckBox
    Private WithEvents chkContainer As System.Windows.Forms.CheckBox
    Private WithEvents btnSelectSource As System.Windows.Forms.Button
    Private WithEvents radioAll As System.Windows.Forms.RadioButton
    Private WithEvents radioWebCam As System.Windows.Forms.RadioButton
    Private WithEvents radioTwain As System.Windows.Forms.RadioButton
    Private WithEvents btnRemoveAllImages As System.Windows.Forms.Button
    Private WithEvents chkIfShowUI As System.Windows.Forms.CheckBox
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnAcquireSource As System.Windows.Forms.Button
    Private WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

End Class
