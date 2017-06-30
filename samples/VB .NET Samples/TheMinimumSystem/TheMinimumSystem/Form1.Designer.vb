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
        Me.Acquire = New System.Windows.Forms.Button()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        Me.SuspendLayout()
        '
        'Acquire
        '
        Me.Acquire.Location = New System.Drawing.Point(12, 426)
        Me.Acquire.Name = "Acquire"
        Me.Acquire.Size = New System.Drawing.Size(80, 23)
        Me.Acquire.TabIndex = 1
        Me.Acquire.Text = "Acquire"
        Me.Acquire.UseVisualStyleBackColor = True
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(504, 408)
        Me.dsViewer1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 472)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.Acquire)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Acquire"
        Me.ResumeLayout(False)

    End Sub

	#End Region

    Private WithEvents Acquire As System.Windows.Forms.Button
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

