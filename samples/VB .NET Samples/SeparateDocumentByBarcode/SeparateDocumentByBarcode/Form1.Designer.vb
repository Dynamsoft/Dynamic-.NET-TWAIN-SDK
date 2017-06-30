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
        Me.cmbBarcodeFormat = New System.Windows.Forms.ComboBox()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.radMode1 = New System.Windows.Forms.RadioButton()
        Me.radMode2 = New System.Windows.Forms.RadioButton()
        Me.picMode1 = New System.Windows.Forms.PictureBox()
        Me.btnRemoveAllImage = New System.Windows.Forms.Button()
        Me.picMode2 = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemoveSelectedImages = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.picFAQMode1 = New System.Windows.Forms.PictureBox()
        Me.picFAQMode2 = New System.Windows.Forms.PictureBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        CType(Me.picMode1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMode2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFAQMode1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFAQMode2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnScan.Size = New System.Drawing.Size(83, 23)
        Me.btnScan.TabIndex = 5
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
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
        Me.btnRemoveAllImage.TabIndex = 13
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
        Me.btnSave.Location = New System.Drawing.Point(569, 351)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemoveSelectedImages
        '
        Me.btnRemoveSelectedImages.Location = New System.Drawing.Point(164, 386)
        Me.btnRemoveSelectedImages.Name = "btnRemoveSelectedImages"
        Me.btnRemoveSelectedImages.Size = New System.Drawing.Size(141, 23)
        Me.btnRemoveSelectedImages.TabIndex = 14
        Me.btnRemoveSelectedImages.Text = "Remove Selected Images"
        Me.btnRemoveSelectedImages.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(431, 17)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(104, 15)
        Me.label2.TabIndex = 16
        Me.label2.Text = " Scan Documents"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(431, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(117, 15)
        Me.label3.TabIndex = 17
        Me.label3.Text = " Separation Settings"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(434, 356)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(80, 15)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Save to Local"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(377, 16)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(60, 15)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Step 1:  "
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(377, 64)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(60, 15)
        Me.label6.TabIndex = 20
        Me.label6.Text = "Step 2:  "
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(377, 355)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(60, 15)
        Me.label7.TabIndex = 21
        Me.label7.Text = "Step 3:  "
        '
        'picFAQMode1
        '
        Me.picFAQMode1.Location = New System.Drawing.Point(446, 126)
        Me.picFAQMode1.Name = "picFAQMode1"
        Me.picFAQMode1.Size = New System.Drawing.Size(30, 17)
        Me.picFAQMode1.TabIndex = 22
        Me.picFAQMode1.TabStop = False
        '
        'picFAQMode2
        '
        Me.picFAQMode2.Location = New System.Drawing.Point(595, 126)
        Me.picFAQMode2.Name = "picFAQMode2"
        Me.picFAQMode2.Size = New System.Drawing.Size(32, 17)
        Me.picFAQMode2.TabIndex = 23
        Me.picFAQMode2.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.groupBox1.Location = New System.Drawing.Point(378, 50)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(271, 1)
        Me.groupBox1.TabIndex = 24
        Me.groupBox1.TabStop = False
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.groupBox2.Location = New System.Drawing.Point(379, 343)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(270, 1)
        Me.groupBox2.TabIndex = 25
        Me.groupBox2.TabStop = False
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(349, 358)
        Me.dsViewer1.TabIndex = 26
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 425)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.picFAQMode2)
        Me.Controls.Add(Me.picFAQMode1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.picMode2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmbBarcodeFormat)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.radMode1)
        Me.Controls.Add(Me.btnRemoveSelectedImages)
        Me.Controls.Add(Me.radMode2)
        Me.Controls.Add(Me.btnRemoveAllImage)
        Me.Controls.Add(Me.picMode1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnScan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Process scanned documents with barcode separators"
        CType(Me.picMode1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMode2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFAQMode1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFAQMode2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
    Private WithEvents btnScan As System.Windows.Forms.Button
	Private cmbBarcodeFormat As System.Windows.Forms.ComboBox
    Private WithEvents radMode1 As System.Windows.Forms.RadioButton
    Private WithEvents radMode2 As System.Windows.Forms.RadioButton
	Private picMode1 As System.Windows.Forms.PictureBox
    Private WithEvents btnRemoveAllImage As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnRemoveSelectedImages As System.Windows.Forms.Button
	Private picMode2 As System.Windows.Forms.PictureBox
	Private label2 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private picFAQMode1 As System.Windows.Forms.PictureBox
	Private picFAQMode2 As System.Windows.Forms.PictureBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

