Partial Class Form1

	Private btnSelectSource As System.Windows.Forms.Button
	Private btnAcquire As System.Windows.Forms.Button
	Private dlgFileSave As System.Windows.Forms.SaveFileDialog
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
		Me.btnSelectSource = New System.Windows.Forms.Button()
		Me.btnAcquire = New System.Windows.Forms.Button()
		Me.dlgFileSave = New System.Windows.Forms.SaveFileDialog()
		Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
		Me.SuspendLayout()


		Me.btnSelectSource.Location = New System.Drawing.Point(8, 342)
		Me.btnSelectSource.Name = "btnSelectSource"
		Me.btnSelectSource.Size = New System.Drawing.Size(94, 25)
		Me.btnSelectSource.TabIndex = 1
		Me.btnSelectSource.Text = "Select Source"
		AddHandler Me.btnSelectSource.Click, New System.EventHandler(AddressOf Me.btnSelectSource_Click)
		' 
		' btnAcquire
		' 
		Me.btnAcquire.Location = New System.Drawing.Point(119, 342)
		Me.btnAcquire.Name = "btnAcquire"
		Me.btnAcquire.Size = New System.Drawing.Size(86, 25)
		Me.btnAcquire.TabIndex = 2
		Me.btnAcquire.Text = "Acquire"
		AddHandler Me.btnAcquire.Click, New System.EventHandler(AddressOf Me.btnAcquire_Click)
		' 
		' dlgFileSave
		' 
		Me.dlgFileSave.DefaultExt = "bmp"
		Me.dlgFileSave.FileName = "dynamicDotNetTwain"
		Me.dlgFileSave.Filter = "Bitmap File(*.bmp)|*.bmp"
		' 
		' dsViewer1
		' 
		Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
		Me.dsViewer1.Name = "dsViewer1"
		Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dsViewer1.SelectionRectAspectRatio = 0.0
		Me.dsViewer1.Size = New System.Drawing.Size(369, 324)
		Me.dsViewer1.TabIndex = 3
		' 
		' Form1
		' 
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(393, 401)
		Me.Controls.Add(Me.dsViewer1)
		Me.Controls.Add(Me.btnAcquire)
		Me.Controls.Add(Me.btnSelectSource)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Acquire Image with DiskFile Mode"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private dsViewer1 As Dynamsoft.Forms.DSViewer

End Class

