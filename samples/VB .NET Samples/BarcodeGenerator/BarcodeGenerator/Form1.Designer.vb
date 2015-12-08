<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnLoadImage = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.labMsg = New System.Windows.Forms.Label
        Me.cmbBarcodeFormat = New System.Windows.Forms.ComboBox
        Me.txtBarcodeScale = New System.Windows.Forms.TextBox
        Me.txtHumanReadableTxt = New System.Windows.Forms.TextBox
        Me.txtBarcodeContent = New System.Windows.Forms.TextBox
        Me.btnAddBarcode = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtBarcodeLocationY = New System.Windows.Forms.TextBox
        Me.txtBarcodeLocationX = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.chbMultiPagePDF = New System.Windows.Forms.CheckBox
        Me.chbMultiPageTIFF = New System.Windows.Forms.CheckBox
        Me.rdbPDF = New System.Windows.Forms.RadioButton
        Me.rdbTIFF = New System.Windows.Forms.RadioButton
        Me.rdbPNG = New System.Windows.Forms.RadioButton
        Me.rdbJPEG = New System.Windows.Forms.RadioButton
        Me.rdbBMP = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.labMsg2 = New System.Windows.Forms.Label
        Me.DynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLoadImage)
        Me.GroupBox1.Location = New System.Drawing.Point(354, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 67)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Open Image"
        '
        'btnLoadImage
        '
        Me.btnLoadImage.Location = New System.Drawing.Point(83, 25)
        Me.btnLoadImage.Name = "btnLoadImage"
        Me.btnLoadImage.Size = New System.Drawing.Size(99, 26)
        Me.btnLoadImage.TabIndex = 0
        Me.btnLoadImage.Text = "Load Image"
        Me.btnLoadImage.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.labMsg)
        Me.GroupBox2.Controls.Add(Me.cmbBarcodeFormat)
        Me.GroupBox2.Controls.Add(Me.txtBarcodeScale)
        Me.GroupBox2.Controls.Add(Me.txtHumanReadableTxt)
        Me.GroupBox2.Controls.Add(Me.txtBarcodeContent)
        Me.GroupBox2.Controls.Add(Me.btnAddBarcode)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(354, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 237)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add Barcode"
        '
        'labMsg
        '
        Me.labMsg.AutoSize = True
        Me.labMsg.Location = New System.Drawing.Point(58, 217)
        Me.labMsg.Name = "labMsg"
        Me.labMsg.Size = New System.Drawing.Size(0, 13)
        Me.labMsg.TabIndex = 10
        '
        'cmbBarcodeFormat
        '
        Me.cmbBarcodeFormat.FormattingEnabled = True
        Me.cmbBarcodeFormat.Location = New System.Drawing.Point(105, 16)
        Me.cmbBarcodeFormat.Name = "cmbBarcodeFormat"
        Me.cmbBarcodeFormat.Size = New System.Drawing.Size(148, 21)
        Me.cmbBarcodeFormat.TabIndex = 9
        '
        'txtBarcodeScale
        '
        Me.txtBarcodeScale.Location = New System.Drawing.Point(129, 161)
        Me.txtBarcodeScale.Name = "txtBarcodeScale"
        Me.txtBarcodeScale.Size = New System.Drawing.Size(124, 20)
        Me.txtBarcodeScale.TabIndex = 8
        '
        'txtHumanReadableTxt
        '
        Me.txtHumanReadableTxt.Location = New System.Drawing.Point(129, 135)
        Me.txtHumanReadableTxt.Name = "txtHumanReadableTxt"
        Me.txtHumanReadableTxt.Size = New System.Drawing.Size(125, 20)
        Me.txtHumanReadableTxt.TabIndex = 7
        '
        'txtBarcodeContent
        '
        Me.txtBarcodeContent.Location = New System.Drawing.Point(104, 45)
        Me.txtBarcodeContent.Name = "txtBarcodeContent"
        Me.txtBarcodeContent.Size = New System.Drawing.Size(150, 20)
        Me.txtBarcodeContent.TabIndex = 6
        '
        'btnAddBarcode
        '
        Me.btnAddBarcode.Location = New System.Drawing.Point(83, 187)
        Me.btnAddBarcode.Name = "btnAddBarcode"
        Me.btnAddBarcode.Size = New System.Drawing.Size(98, 26)
        Me.btnAddBarcode.TabIndex = 5
        Me.btnAddBarcode.Text = "Add Barcode"
        Me.btnAddBarcode.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Barcode Scale:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Human Readable Text:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtBarcodeLocationY)
        Me.GroupBox3.Controls.Add(Me.txtBarcodeLocationX)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(245, 58)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Barcode Location"
        '
        'txtBarcodeLocationY
        '
        Me.txtBarcodeLocationY.Location = New System.Drawing.Point(162, 25)
        Me.txtBarcodeLocationY.Name = "txtBarcodeLocationY"
        Me.txtBarcodeLocationY.Size = New System.Drawing.Size(77, 20)
        Me.txtBarcodeLocationY.TabIndex = 3
        '
        'txtBarcodeLocationX
        '
        Me.txtBarcodeLocationX.Location = New System.Drawing.Point(42, 25)
        Me.txtBarcodeLocationX.Name = "txtBarcodeLocationX"
        Me.txtBarcodeLocationX.Size = New System.Drawing.Size(77, 20)
        Me.txtBarcodeLocationX.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(139, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Y:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "X:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Barcode Content:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Barcode Format:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(83, 86)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 25)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chbMultiPagePDF
        '
        Me.chbMultiPagePDF.AutoSize = True
        Me.chbMultiPagePDF.Location = New System.Drawing.Point(141, 58)
        Me.chbMultiPagePDF.Name = "chbMultiPagePDF"
        Me.chbMultiPagePDF.Size = New System.Drawing.Size(100, 17)
        Me.chbMultiPagePDF.TabIndex = 14
        Me.chbMultiPagePDF.Text = "Multi-Page PDF"
        Me.chbMultiPagePDF.UseVisualStyleBackColor = True
        '
        'chbMultiPageTIFF
        '
        Me.chbMultiPageTIFF.AutoSize = True
        Me.chbMultiPageTIFF.Location = New System.Drawing.Point(23, 58)
        Me.chbMultiPageTIFF.Name = "chbMultiPageTIFF"
        Me.chbMultiPageTIFF.Size = New System.Drawing.Size(101, 17)
        Me.chbMultiPageTIFF.TabIndex = 13
        Me.chbMultiPageTIFF.Text = "Multi-Page TIFF"
        Me.chbMultiPageTIFF.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Location = New System.Drawing.Point(214, 29)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 17)
        Me.rdbPDF.TabIndex = 12
        Me.rdbPDF.TabStop = True
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbTIFF
        '
        Me.rdbTIFF.AutoSize = True
        Me.rdbTIFF.Location = New System.Drawing.Point(162, 28)
        Me.rdbTIFF.Name = "rdbTIFF"
        Me.rdbTIFF.Size = New System.Drawing.Size(47, 17)
        Me.rdbTIFF.TabIndex = 11
        Me.rdbTIFF.TabStop = True
        Me.rdbTIFF.Text = "TIFF"
        Me.rdbTIFF.UseVisualStyleBackColor = True
        '
        'rdbPNG
        '
        Me.rdbPNG.AutoSize = True
        Me.rdbPNG.Location = New System.Drawing.Point(109, 28)
        Me.rdbPNG.Name = "rdbPNG"
        Me.rdbPNG.Size = New System.Drawing.Size(48, 17)
        Me.rdbPNG.TabIndex = 10
        Me.rdbPNG.TabStop = True
        Me.rdbPNG.Text = "PNG"
        Me.rdbPNG.UseVisualStyleBackColor = True
        '
        'rdbJPEG
        '
        Me.rdbJPEG.AutoSize = True
        Me.rdbJPEG.Location = New System.Drawing.Point(54, 28)
        Me.rdbJPEG.Name = "rdbJPEG"
        Me.rdbJPEG.Size = New System.Drawing.Size(52, 17)
        Me.rdbJPEG.TabIndex = 9
        Me.rdbJPEG.TabStop = True
        Me.rdbJPEG.Text = "JPEG"
        Me.rdbJPEG.UseVisualStyleBackColor = True
        '
        'rdbBMP
        '
        Me.rdbBMP.AutoSize = True
        Me.rdbBMP.Location = New System.Drawing.Point(5, 28)
        Me.rdbBMP.Name = "rdbBMP"
        Me.rdbBMP.Size = New System.Drawing.Size(48, 17)
        Me.rdbBMP.TabIndex = 8
        Me.rdbBMP.TabStop = True
        Me.rdbBMP.Text = "BMP"
        Me.rdbBMP.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.labMsg2)
        Me.GroupBox4.Controls.Add(Me.chbMultiPagePDF)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Controls.Add(Me.chbMultiPageTIFF)
        Me.GroupBox4.Controls.Add(Me.rdbPDF)
        Me.GroupBox4.Controls.Add(Me.rdbTIFF)
        Me.GroupBox4.Controls.Add(Me.rdbPNG)
        Me.GroupBox4.Controls.Add(Me.rdbJPEG)
        Me.GroupBox4.Controls.Add(Me.rdbBMP)
        Me.GroupBox4.Location = New System.Drawing.Point(354, 318)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 136)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Save Images"
        '
        'labMsg2
        '
        Me.labMsg2.AutoSize = True
        Me.labMsg2.Location = New System.Drawing.Point(61, 114)
        Me.labMsg2.Name = "labMsg2"
        Me.labMsg2.Size = New System.Drawing.Size(0, 13)
        Me.labMsg2.TabIndex = 16
        '
        'DynamicDotNetTwain1
        '
        Me.DynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.DynamicDotNetTwain1.AnnotationPen = Nothing
        Me.DynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.DynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.DynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
        Me.DynamicDotNetTwain1.IfShowPrintUI = False
        Me.DynamicDotNetTwain1.IfThrowException = False
        Me.DynamicDotNetTwain1.Location = New System.Drawing.Point(2, 0)
        Me.DynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.DynamicDotNetTwain1.Name = "DynamicDotNetTwain1"
        Me.DynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DynamicDotNetTwain1.Size = New System.Drawing.Size(339, 454)
        Me.DynamicDotNetTwain1.TabIndex = 0
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(330, 459)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(293, 13)
        Me.label7.TabIndex = 17
        Me.label7.Text = "Note: PDF Rasterizer add-on is used when loading PDF files."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 474)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DynamicDotNetTwain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Barcode Generator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadImage As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBarcodeFormat As System.Windows.Forms.ComboBox
    Friend WithEvents txtBarcodeScale As System.Windows.Forms.TextBox
    Friend WithEvents txtHumanReadableTxt As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcodeContent As System.Windows.Forms.TextBox
    Friend WithEvents btnAddBarcode As System.Windows.Forms.Button
    Friend WithEvents txtBarcodeLocationY As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcodeLocationX As System.Windows.Forms.TextBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents chbMultiPagePDF As System.Windows.Forms.CheckBox
    Private WithEvents chbMultiPageTIFF As System.Windows.Forms.CheckBox
    Private WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Private WithEvents rdbTIFF As System.Windows.Forms.RadioButton
    Private WithEvents rdbPNG As System.Windows.Forms.RadioButton
    Private WithEvents rdbJPEG As System.Windows.Forms.RadioButton
    Private WithEvents rdbBMP As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents labMsg As System.Windows.Forms.Label
    Friend WithEvents labMsg2 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label

End Class
