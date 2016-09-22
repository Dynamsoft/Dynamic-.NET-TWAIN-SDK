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
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.label1 = New System.Windows.Forms.Label
        Me.cmbBarcodeFormat = New System.Windows.Forms.ComboBox
        Me.btnScan = New System.Windows.Forms.Button
        Me.radMode2 = New System.Windows.Forms.RadioButton
        Me.picMode1 = New System.Windows.Forms.PictureBox
        Me.btnRemoveAllImage = New System.Windows.Forms.Button
        Me.picMode2 = New System.Windows.Forms.PictureBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnRemoveSelectedImages = New System.Windows.Forms.Button
        Me.radMode1 = New System.Windows.Forms.RadioButton
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.picFAQMode2 = New System.Windows.Forms.PictureBox
        Me.picFAQMode1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.picMode1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMode2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFAQMode2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFAQMode1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.IfThrowException = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(8, 7)
        Me.dynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.ProductFamily = "Dynamic .NET TWAIN Trial (.NET Fr"
        Me.dynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(353, 366)
        Me.dynamicDotNetTwain1.TabIndex = 16
        Me.dynamicDotNetTwain1.Visible = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(379, 94)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(98, 15)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Barcode Format:"
        '
        'cmbBarcodeFormat
        '
        Me.cmbBarcodeFormat.FormattingEnabled = True
        Me.cmbBarcodeFormat.Location = New System.Drawing.Point(524, 92)
        Me.cmbBarcodeFormat.Name = "cmbBarcodeFormat"
        Me.cmbBarcodeFormat.Size = New System.Drawing.Size(125, 21)
        Me.cmbBarcodeFormat.TabIndex = 10
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(569, 14)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(81, 23)
        Me.btnScan.TabIndex = 5
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'radMode2
        '
        Me.radMode2.AutoSize = True
        Me.radMode2.Location = New System.Drawing.Point(530, 126)
        Me.radMode2.Name = "radMode2"
        Me.radMode2.Size = New System.Drawing.Size(58, 17)
        Me.radMode2.TabIndex = 5
        Me.radMode2.Text = "Mode2"
        Me.radMode2.UseVisualStyleBackColor = True
        '
        'picMode1
        '

        Me.picMode1.Location = New System.Drawing.Point(382, 149)
        Me.picMode1.Name = "picMode1"
        Me.picMode1.Size = New System.Drawing.Size(118, 179)
        Me.picMode1.TabIndex = 12
        Me.picMode1.TabStop = False
        '
        'btnRemoveAllImage
        '
        Me.btnRemoveAllImage.Location = New System.Drawing.Point(12, 386)
        Me.btnRemoveAllImage.Name = "btnRemoveAllImage"
        Me.btnRemoveAllImage.Size = New System.Drawing.Size(131, 23)
        Me.btnRemoveAllImage.TabIndex = 17
        Me.btnRemoveAllImage.Text = "Remove All Images"
        Me.btnRemoveAllImage.UseVisualStyleBackColor = True
        '
        'picMode2
        '

        Me.picMode2.Location = New System.Drawing.Point(531, 149)
        Me.picMode2.Name = "picMode2"
        Me.picMode2.Size = New System.Drawing.Size(118, 179)
        Me.picMode2.TabIndex = 14
        Me.picMode2.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(569, 352)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemoveSelectedImages
        '
        Me.btnRemoveSelectedImages.Location = New System.Drawing.Point(164, 386)
        Me.btnRemoveSelectedImages.Name = "btnRemoveSelectedImages"
        Me.btnRemoveSelectedImages.Size = New System.Drawing.Size(141, 23)
        Me.btnRemoveSelectedImages.TabIndex = 19
        Me.btnRemoveSelectedImages.Text = "Remove Selected Images"
        Me.btnRemoveSelectedImages.UseVisualStyleBackColor = True
        '
        'radMode1
        '
        Me.radMode1.AutoSize = True
        Me.radMode1.Checked = True
        Me.radMode1.Location = New System.Drawing.Point(382, 126)
        Me.radMode1.Name = "radMode1"
        Me.radMode1.Size = New System.Drawing.Size(58, 17)
        Me.radMode1.TabIndex = 4
        Me.radMode1.TabStop = True
        Me.radMode1.Text = "Mode1"
        Me.radMode1.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(377, 355)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(60, 15)
        Me.label7.TabIndex = 27
        Me.label7.Text = "Step 3:  "
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(377, 64)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(60, 15)
        Me.label6.TabIndex = 26
        Me.label6.Text = "Step 2:  "
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(377, 16)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(60, 15)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Step 1:  "
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(434, 356)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(80, 15)
        Me.label4.TabIndex = 24
        Me.label4.Text = "Save to Local"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(431, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(117, 15)
        Me.label3.TabIndex = 23
        Me.label3.Text = " Separation Settings"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(431, 17)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(104, 15)
        Me.label2.TabIndex = 22
        Me.label2.Text = " Scan Documents"
        '
        'picFAQMode2
        '

        Me.picFAQMode2.Location = New System.Drawing.Point(594, 126)
        Me.picFAQMode2.Name = "picFAQMode2"
        Me.picFAQMode2.Size = New System.Drawing.Size(32, 17)
        Me.picFAQMode2.TabIndex = 29
        Me.picFAQMode2.TabStop = False
        '
        'picFAQMode1
        '

        Me.picFAQMode1.Location = New System.Drawing.Point(445, 126)
        Me.picFAQMode1.Name = "picFAQMode1"
        Me.picFAQMode1.Size = New System.Drawing.Size(30, 17)
        Me.picFAQMode1.TabIndex = 28
        Me.picFAQMode1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox1.Location = New System.Drawing.Point(378, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 1)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox2.Location = New System.Drawing.Point(379, 343)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 1)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font

        Me.ClientSize = New System.Drawing.Size(679, 424)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picFAQMode2)
        Me.Controls.Add(Me.picFAQMode1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.picMode2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmbBarcodeFormat)
        Me.Controls.Add(Me.radMode1)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
        Me.Controls.Add(Me.radMode2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.picMode1)
        Me.Controls.Add(Me.btnRemoveAllImage)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnRemoveSelectedImages)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Process scanned documents with barcode separators"
        CType(Me.picMode1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMode2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFAQMode2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFAQMode1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmbBarcodeFormat As System.Windows.Forms.ComboBox
    Private WithEvents btnScan As System.Windows.Forms.Button
    Private WithEvents radMode2 As System.Windows.Forms.RadioButton
    Private WithEvents picMode1 As System.Windows.Forms.PictureBox
    Private WithEvents btnRemoveAllImage As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnRemoveSelectedImages As System.Windows.Forms.Button
    Private WithEvents picMode2 As System.Windows.Forms.PictureBox
    Private WithEvents radMode1 As System.Windows.Forms.RadioButton
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents picFAQMode2 As System.Windows.Forms.PictureBox
    Private WithEvents picFAQMode1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
