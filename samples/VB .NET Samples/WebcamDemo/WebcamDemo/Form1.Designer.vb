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
        Me.btnCaptureImage = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRemoveAllImages = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cbxSources = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.lbContainer = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCaptureImage
        '
        Me.btnCaptureImage.Location = New System.Drawing.Point(15, 266)
        Me.btnCaptureImage.Name = "btnCaptureImage"
        Me.btnCaptureImage.Size = New System.Drawing.Size(130, 23)
        Me.btnCaptureImage.TabIndex = 1
        Me.btnCaptureImage.Text = "Capture Image"
        Me.btnCaptureImage.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.White
        Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(275, 295)
        Me.pictureBox1.TabIndex = 2
        Me.pictureBox1.TabStop = False
        '
        'btnRemoveAllImages
        '
        Me.btnRemoveAllImages.Location = New System.Drawing.Point(15, 309)
        Me.btnRemoveAllImages.Name = "btnRemoveAllImages"
        Me.btnRemoveAllImages.Size = New System.Drawing.Size(130, 23)
        Me.btnRemoveAllImages.TabIndex = 4
        Me.btnRemoveAllImages.Text = "Remove All Images"
        Me.btnRemoveAllImages.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.label1.Location = New System.Drawing.Point(15, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(104, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Webcam Source:"
        '
        'cbxSources
        '
        Me.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSources.FormattingEnabled = True
        Me.cbxSources.Location = New System.Drawing.Point(15, 35)
        Me.cbxSources.Name = "cbxSources"
        Me.cbxSources.Size = New System.Drawing.Size(131, 21)
        Me.cbxSources.TabIndex = 13
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.label2.Location = New System.Drawing.Point(160, 15)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(99, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "ImageContainer:"
        '
        'lbContainer
        '
        Me.lbContainer.AutoSize = True
        Me.lbContainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbContainer.Location = New System.Drawing.Point(455, 16)
        Me.lbContainer.Name = "lbContainer"
        Me.lbContainer.Size = New System.Drawing.Size(101, 13)
        Me.lbContainer.TabIndex = 15
        Me.lbContainer.Text = "Video Container:"
        '
        'panel1
        '
        Me.panel1.AutoScroll = True
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.pictureBox1)
        Me.panel1.Location = New System.Drawing.Point(455, 35)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(280, 300)
        Me.panel1.TabIndex = 17
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(163, 37)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(277, 295)
        Me.dsViewer1.TabIndex = 23
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(749, 347)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lbContainer)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.cbxSources)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnRemoveAllImages)
        Me.Controls.Add(Me.btnCaptureImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Webcam Demo"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region
    Private WithEvents btnCaptureImage As System.Windows.Forms.Button
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnRemoveAllImages As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cbxSources As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents lbContainer As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

