<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblPDFName = New System.Windows.Forms.Label()
        Me.tbxSetFileName = New System.Windows.Forms.Button()
        Me.tbxPDFName = New System.Windows.Forms.TextBox()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(23, 27)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(242, 100)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Note:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 47)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(115, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Please reset the name."
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 25)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(233, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "The name of  PDF file contains  illegal character"
        '
        'lblPDFName
        '
        Me.lblPDFName.AutoSize = True
        Me.lblPDFName.Location = New System.Drawing.Point(20, 142)
        Me.lblPDFName.Name = "lblPDFName"
        Me.lblPDFName.Size = New System.Drawing.Size(81, 13)
        Me.lblPDFName.TabIndex = 10
        Me.lblPDFName.Text = "PDF File Name:"
        '
        'tbxSetFileName
        '
        Me.tbxSetFileName.Location = New System.Drawing.Point(95, 213)
        Me.tbxSetFileName.Name = "tbxSetFileName"
        Me.tbxSetFileName.Size = New System.Drawing.Size(89, 23)
        Me.tbxSetFileName.TabIndex = 9
        Me.tbxSetFileName.Text = "Set File Name"
        Me.tbxSetFileName.UseVisualStyleBackColor = True
        '
        'tbxPDFName
        '
        Me.tbxPDFName.Location = New System.Drawing.Point(23, 169)
        Me.tbxPDFName.Name = "tbxPDFName"
        Me.tbxPDFName.Size = New System.Drawing.Size(239, 20)
        Me.tbxPDFName.TabIndex = 8
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.lblPDFName)
        Me.Controls.Add(Me.tbxSetFileName)
        Me.Controls.Add(Me.tbxPDFName)
        Me.Name = "Form2"
        Me.Text = "Set PDF File Name"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents lblPDFName As System.Windows.Forms.Label
    Private WithEvents tbxSetFileName As System.Windows.Forms.Button
    Private WithEvents tbxPDFName As System.Windows.Forms.TextBox
End Class
