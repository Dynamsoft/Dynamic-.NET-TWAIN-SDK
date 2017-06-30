Partial Class SuccessInfo
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
		Me.lblInfo = New System.Windows.Forms.Label()
		Me.button1 = New System.Windows.Forms.Button()
		Me.lblLink = New System.Windows.Forms.LinkLabel()
		Me.SuspendLayout()
		' 
		' lblInfo
		' 
		Me.lblInfo.Location = New System.Drawing.Point(21, 29)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(421, 20)
		Me.lblInfo.TabIndex = 0
		Me.lblInfo.Text = "label1"
		' 
		' button1
		' 
		Me.button1.Location = New System.Drawing.Point(203, 87)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 1
		Me.button1.Text = "OK"
		Me.button1.UseVisualStyleBackColor = True
		AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
		' 
		' lblLink
		' 
		Me.lblLink.AutoSize = True
		Me.lblLink.Location = New System.Drawing.Point(21, 52)
		Me.lblLink.Name = "lblLink"
		Me.lblLink.Size = New System.Drawing.Size(55, 13)
		Me.lblLink.TabIndex = 2
		Me.lblLink.TabStop = True
		Me.lblLink.Text = "linkLabel1"
		AddHandler Me.lblLink.LinkClicked, New System.Windows.Forms.LinkLabelLinkClickedEventHandler(AddressOf Me.lblLink_LinkClicked)
		' 
		' SuccessInfo
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(465, 122)
		Me.Controls.Add(Me.lblLink)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.lblInfo)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SuccessInfo"
		Me.Text = "Success"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.SuccessInfo_Load)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private lblInfo As System.Windows.Forms.Label
	Private button1 As System.Windows.Forms.Button
	Private lblLink As System.Windows.Forms.LinkLabel
End Class
