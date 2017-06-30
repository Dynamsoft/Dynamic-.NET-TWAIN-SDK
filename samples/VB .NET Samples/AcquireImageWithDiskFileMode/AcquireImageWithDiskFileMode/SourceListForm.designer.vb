Partial Class SourceListForm
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Source:"
        '
        'listBox1
        '
        Me.listBox1.FormattingEnabled = True
        Me.listBox1.Location = New System.Drawing.Point(15, 40)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(259, 95)
        Me.listBox1.TabIndex = 1
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(289, 81)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Select"
        Me.button1.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(289, 112)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 3
        Me.button2.Text = "Cancel"
        Me.button2.UseVisualStyleBackColor = True
        '
        'SourceListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 142)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.listBox1)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "SourceListForm"
        Me.Text = "SourceListForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private label1 As System.Windows.Forms.Label
	Private listBox1 As System.Windows.Forms.ListBox
	Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
End Class
