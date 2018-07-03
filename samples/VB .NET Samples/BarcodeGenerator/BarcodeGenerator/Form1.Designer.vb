Partial Class Form1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLoadImage = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCreateBarcode = New System.Windows.Forms.Button()
        Me.labMsg = New System.Windows.Forms.Label()
        Me.cmbBarcodeFormat = New System.Windows.Forms.ComboBox()
        Me.btnAddBarcode = New System.Windows.Forms.Button()
        Me.txtBarcodeScale = New System.Windows.Forms.TextBox()
        Me.txtHumanReadableTxt = New System.Windows.Forms.TextBox()
        Me.txtBarcodeContent = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtBarocdeLocationY = New System.Windows.Forms.TextBox()
        Me.txtBarcodeLocationX = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.labmsg2 = New System.Windows.Forms.Label()
        Me.chbMultiPagePDF = New System.Windows.Forms.CheckBox()
        Me.chbMultiPageTIFF = New System.Windows.Forms.CheckBox()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbTIFF = New System.Windows.Forms.RadioButton()
        Me.rdbPNG = New System.Windows.Forms.RadioButton()
        Me.rdbJPEG = New System.Windows.Forms.RadioButton()
        Me.rdbBMP = New System.Windows.Forms.RadioButton()
        Me.label7 = New System.Windows.Forms.Label()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnLoadImage)
        Me.groupBox1.Location = New System.Drawing.Point(345, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(269, 65)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Open Image"
        '
        'btnLoadImage
        '
        Me.btnLoadImage.Location = New System.Drawing.Point(83, 24)
        Me.btnLoadImage.Name = "btnLoadImage"
        Me.btnLoadImage.Size = New System.Drawing.Size(103, 25)
        Me.btnLoadImage.TabIndex = 0
        Me.btnLoadImage.Text = "Load Image"
        Me.btnLoadImage.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btnCreateBarcode)
        Me.groupBox2.Controls.Add(Me.labMsg)
        Me.groupBox2.Controls.Add(Me.cmbBarcodeFormat)
        Me.groupBox2.Controls.Add(Me.btnAddBarcode)
        Me.groupBox2.Controls.Add(Me.txtBarcodeScale)
        Me.groupBox2.Controls.Add(Me.txtHumanReadableTxt)
        Me.groupBox2.Controls.Add(Me.txtBarcodeContent)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.label1)
        Me.groupBox2.Location = New System.Drawing.Point(345, 75)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(269, 240)
        Me.groupBox2.TabIndex = 2
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Add Barcode"
        '
        'btnCreateBarcode
        '
        Me.btnCreateBarcode.Location = New System.Drawing.Point(147, 193)
        Me.btnCreateBarcode.Name = "btnCreateBarcode"
        Me.btnCreateBarcode.Size = New System.Drawing.Size(103, 25)
        Me.btnCreateBarcode.TabIndex = 12
        Me.btnCreateBarcode.Text = "Create Barcode"
        Me.btnCreateBarcode.UseVisualStyleBackColor = True
        '
        'labMsg
        '
        Me.labMsg.AutoSize = True
        Me.labMsg.Location = New System.Drawing.Point(62, 221)
        Me.labMsg.Name = "labMsg"
        Me.labMsg.Size = New System.Drawing.Size(0, 13)
        Me.labMsg.TabIndex = 11
        '
        'cmbBarcodeFormat
        '
        Me.cmbBarcodeFormat.FormattingEnabled = True
        Me.cmbBarcodeFormat.Location = New System.Drawing.Point(98, 23)
        Me.cmbBarcodeFormat.Name = "cmbBarcodeFormat"
        Me.cmbBarcodeFormat.Size = New System.Drawing.Size(162, 21)
        Me.cmbBarcodeFormat.TabIndex = 10
        '
        'btnAddBarcode
        '
        Me.btnAddBarcode.Location = New System.Drawing.Point(21, 193)
        Me.btnAddBarcode.Name = "btnAddBarcode"
        Me.btnAddBarcode.Size = New System.Drawing.Size(103, 25)
        Me.btnAddBarcode.TabIndex = 5
        Me.btnAddBarcode.Text = "Add Barcode"
        Me.btnAddBarcode.UseVisualStyleBackColor = True
        '
        'txtBarcodeScale
        '
        Me.txtBarcodeScale.Location = New System.Drawing.Point(127, 164)
        Me.txtBarcodeScale.Name = "txtBarcodeScale"
        Me.txtBarcodeScale.Size = New System.Drawing.Size(133, 20)
        Me.txtBarcodeScale.TabIndex = 9
        '
        'txtHumanReadableTxt
        '
        Me.txtHumanReadableTxt.Location = New System.Drawing.Point(127, 138)
        Me.txtHumanReadableTxt.Name = "txtHumanReadableTxt"
        Me.txtHumanReadableTxt.Size = New System.Drawing.Size(133, 20)
        Me.txtHumanReadableTxt.TabIndex = 8
        '
        'txtBarcodeContent
        '
        Me.txtBarcodeContent.Location = New System.Drawing.Point(98, 52)
        Me.txtBarcodeContent.Name = "txtBarcodeContent"
        Me.txtBarcodeContent.Size = New System.Drawing.Size(162, 20)
        Me.txtBarcodeContent.TabIndex = 7
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(44, 167)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(80, 13)
        Me.label6.TabIndex = 4
        Me.label6.Text = "Barcode Scale:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(7, 141)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(117, 13)
        Me.label5.TabIndex = 3
        Me.label5.Text = "Human Readable Text:"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.txtBarocdeLocationY)
        Me.groupBox3.Controls.Add(Me.txtBarcodeLocationX)
        Me.groupBox3.Controls.Add(Me.label4)
        Me.groupBox3.Controls.Add(Me.label3)
        Me.groupBox3.Location = New System.Drawing.Point(6, 78)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(254, 51)
        Me.groupBox3.TabIndex = 2
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Barcode Location"
        '
        'txtBarocdeLocationY
        '
        Me.txtBarocdeLocationY.Location = New System.Drawing.Point(153, 20)
        Me.txtBarocdeLocationY.Name = "txtBarocdeLocationY"
        Me.txtBarocdeLocationY.Size = New System.Drawing.Size(73, 20)
        Me.txtBarocdeLocationY.TabIndex = 3
        '
        'txtBarcodeLocationX
        '
        Me.txtBarcodeLocationX.Location = New System.Drawing.Point(32, 20)
        Me.txtBarcodeLocationX.Name = "txtBarcodeLocationX"
        Me.txtBarcodeLocationX.Size = New System.Drawing.Size(73, 20)
        Me.txtBarcodeLocationX.TabIndex = 2
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(127, 23)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(17, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Y:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(11, 23)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(17, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "X:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 55)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(90, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Barcode Content:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 25)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(85, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Barcode Format:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(83, 81)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 25)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.labmsg2)
        Me.groupBox4.Controls.Add(Me.btnSave)
        Me.groupBox4.Controls.Add(Me.chbMultiPagePDF)
        Me.groupBox4.Controls.Add(Me.chbMultiPageTIFF)
        Me.groupBox4.Controls.Add(Me.rdbPDF)
        Me.groupBox4.Controls.Add(Me.rdbTIFF)
        Me.groupBox4.Controls.Add(Me.rdbPNG)
        Me.groupBox4.Controls.Add(Me.rdbJPEG)
        Me.groupBox4.Controls.Add(Me.rdbBMP)
        Me.groupBox4.Location = New System.Drawing.Point(345, 319)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(264, 136)
        Me.groupBox4.TabIndex = 3
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Save Images"
        '
        'labmsg2
        '
        Me.labmsg2.AutoSize = True
        Me.labmsg2.Location = New System.Drawing.Point(65, 108)
        Me.labmsg2.Name = "labmsg2"
        Me.labmsg2.Size = New System.Drawing.Size(0, 13)
        Me.labmsg2.TabIndex = 8
        '
        'chbMultiPagePDF
        '
        Me.chbMultiPagePDF.AutoSize = True
        Me.chbMultiPagePDF.Location = New System.Drawing.Point(147, 49)
        Me.chbMultiPagePDF.Name = "chbMultiPagePDF"
        Me.chbMultiPagePDF.Size = New System.Drawing.Size(100, 17)
        Me.chbMultiPagePDF.TabIndex = 6
        Me.chbMultiPagePDF.Text = "Multi-Page PDF"
        Me.chbMultiPagePDF.UseVisualStyleBackColor = True
        '
        'chbMultiPageTIFF
        '
        Me.chbMultiPageTIFF.AutoSize = True
        Me.chbMultiPageTIFF.Location = New System.Drawing.Point(29, 49)
        Me.chbMultiPageTIFF.Name = "chbMultiPageTIFF"
        Me.chbMultiPageTIFF.Size = New System.Drawing.Size(101, 17)
        Me.chbMultiPageTIFF.TabIndex = 5
        Me.chbMultiPageTIFF.Text = "Multi-Page TIFF"
        Me.chbMultiPageTIFF.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Location = New System.Drawing.Point(220, 23)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 17)
        Me.rdbPDF.TabIndex = 4
        Me.rdbPDF.TabStop = True
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbTIFF
        '
        Me.rdbTIFF.AutoSize = True
        Me.rdbTIFF.Location = New System.Drawing.Point(168, 22)
        Me.rdbTIFF.Name = "rdbTIFF"
        Me.rdbTIFF.Size = New System.Drawing.Size(47, 17)
        Me.rdbTIFF.TabIndex = 3
        Me.rdbTIFF.TabStop = True
        Me.rdbTIFF.Text = "TIFF"
        Me.rdbTIFF.UseVisualStyleBackColor = True
        '
        'rdbPNG
        '
        Me.rdbPNG.AutoSize = True
        Me.rdbPNG.Location = New System.Drawing.Point(115, 22)
        Me.rdbPNG.Name = "rdbPNG"
        Me.rdbPNG.Size = New System.Drawing.Size(48, 17)
        Me.rdbPNG.TabIndex = 2
        Me.rdbPNG.TabStop = True
        Me.rdbPNG.Text = "PNG"
        Me.rdbPNG.UseVisualStyleBackColor = True
        '
        'rdbJPEG
        '
        Me.rdbJPEG.AutoSize = True
        Me.rdbJPEG.Location = New System.Drawing.Point(60, 22)
        Me.rdbJPEG.Name = "rdbJPEG"
        Me.rdbJPEG.Size = New System.Drawing.Size(52, 17)
        Me.rdbJPEG.TabIndex = 1
        Me.rdbJPEG.TabStop = True
        Me.rdbJPEG.Text = "JPEG"
        Me.rdbJPEG.UseVisualStyleBackColor = True
        '
        'rdbBMP
        '
        Me.rdbBMP.AutoSize = True
        Me.rdbBMP.Location = New System.Drawing.Point(11, 22)
        Me.rdbBMP.Name = "rdbBMP"
        Me.rdbBMP.Size = New System.Drawing.Size(48, 17)
        Me.rdbBMP.TabIndex = 0
        Me.rdbBMP.TabStop = True
        Me.rdbBMP.Text = "BMP"
        Me.rdbBMP.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(330, 459)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(237, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "Note: PDF library is used when loading PDF files."
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0R
        Me.dsViewer1.Size = New System.Drawing.Size(327, 443)
        Me.dsViewer1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 474)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Barcode Generator"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadImage As System.Windows.Forms.Button
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private groupBox3 As System.Windows.Forms.GroupBox
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Friend WithEvents txtBarcodeScale As System.Windows.Forms.TextBox
    Friend WithEvents txtHumanReadableTxt As System.Windows.Forms.TextBox
    Private txtBarcodeContent As System.Windows.Forms.TextBox
    Friend WithEvents btnAddBarcode As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Friend WithEvents txtBarocdeLocationY As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcodeLocationX As System.Windows.Forms.TextBox
    Friend WithEvents cmbBarcodeFormat As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Private groupBox4 As System.Windows.Forms.GroupBox
    Private chbMultiPagePDF As System.Windows.Forms.CheckBox
    Private chbMultiPageTIFF As System.Windows.Forms.CheckBox
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTIFF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPNG As System.Windows.Forms.RadioButton
    Friend WithEvents rdbJPEG As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBMP As System.Windows.Forms.RadioButton
    Private labMsg As System.Windows.Forms.Label
    Private labmsg2 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private dsViewer1 As Dynamsoft.Forms.DSViewer
    Friend WithEvents btnCreateBarcode As Windows.Forms.Button
End Class

