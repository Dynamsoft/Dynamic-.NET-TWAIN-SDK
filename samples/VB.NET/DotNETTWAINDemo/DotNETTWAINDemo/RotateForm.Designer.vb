<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RotateForm
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
        Me.tbxB = New System.Windows.Forms.TextBox()
        Me.tbxG = New System.Windows.Forms.TextBox()
        Me.tbxR = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lbB = New System.Windows.Forms.Label()
        Me.lbG = New System.Windows.Forms.Label()
        Me.lbR = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxKeepSize = New System.Windows.Forms.CheckBox()
        Me.cbxInterPolation = New System.Windows.Forms.ComboBox()
        Me.tbxAngle = New System.Windows.Forms.TextBox()
        Me.lbInterPolation = New System.Windows.Forms.Label()
        Me.lnAngle = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbxB
        '
        Me.tbxB.Location = New System.Drawing.Point(175, 27)
        Me.tbxB.Name = "tbxB"
        Me.tbxB.Size = New System.Drawing.Size(46, 23)
        Me.tbxB.TabIndex = 5
        '
        'tbxG
        '
        Me.tbxG.Location = New System.Drawing.Point(101, 27)
        Me.tbxG.Name = "tbxG"
        Me.tbxG.Size = New System.Drawing.Size(46, 23)
        Me.tbxG.TabIndex = 4
        '
        'tbxR
        '
        Me.tbxR.Location = New System.Drawing.Point(27, 27)
        Me.tbxR.Name = "tbxR"
        Me.tbxR.Size = New System.Drawing.Size(46, 23)
        Me.tbxR.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(38, 212)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbB
        '
        Me.lbB.AutoSize = True
        Me.lbB.Location = New System.Drawing.Point(153, 30)
        Me.lbB.Name = "lbB"
        Me.lbB.Size = New System.Drawing.Size(17, 15)
        Me.lbB.TabIndex = 2
        Me.lbB.Text = "B:"
        '
        'lbG
        '
        Me.lbG.AutoSize = True
        Me.lbG.Location = New System.Drawing.Point(80, 30)
        Me.lbG.Name = "lbG"
        Me.lbG.Size = New System.Drawing.Size(18, 15)
        Me.lbG.TabIndex = 1
        Me.lbG.Text = "G:"
        '
        'lbR
        '
        Me.lbR.AutoSize = True
        Me.lbR.Location = New System.Drawing.Point(7, 30)
        Me.lbR.Name = "lbR"
        Me.lbR.Size = New System.Drawing.Size(17, 15)
        Me.lbR.TabIndex = 0
        Me.lbR.Text = "R:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tbxB)
        Me.groupBox1.Controls.Add(Me.tbxG)
        Me.groupBox1.Controls.Add(Me.tbxR)
        Me.groupBox1.Controls.Add(Me.lbB)
        Me.groupBox1.Controls.Add(Me.lbG)
        Me.groupBox1.Controls.Add(Me.lbR)
        Me.groupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(15, 131)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(228, 66)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Fill Color:"
        '
        'cbxKeepSize
        '
        Me.cbxKeepSize.AutoSize = True
        Me.cbxKeepSize.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxKeepSize.Location = New System.Drawing.Point(107, 103)
        Me.cbxKeepSize.Name = "cbxKeepSize"
        Me.cbxKeepSize.Size = New System.Drawing.Size(76, 19)
        Me.cbxKeepSize.TabIndex = 12
        Me.cbxKeepSize.Text = "Keep Size"
        Me.cbxKeepSize.UseVisualStyleBackColor = True
        '
        'cbxInterPolation
        '
        Me.cbxInterPolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInterPolation.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxInterPolation.FormattingEnabled = True
        Me.cbxInterPolation.Items.AddRange(New Object() {"Bicubic", "Bilinear", "NearestNeighbour"})
        Me.cbxInterPolation.Location = New System.Drawing.Point(107, 60)
        Me.cbxInterPolation.Name = "cbxInterPolation"
        Me.cbxInterPolation.Size = New System.Drawing.Size(121, 23)
        Me.cbxInterPolation.TabIndex = 10
        '
        'tbxAngle
        '
        Me.tbxAngle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxAngle.Location = New System.Drawing.Point(107, 19)
        Me.tbxAngle.Name = "tbxAngle"
        Me.tbxAngle.Size = New System.Drawing.Size(122, 23)
        Me.tbxAngle.TabIndex = 8
        '
        'lbInterPolation
        '
        Me.lbInterPolation.AutoSize = True
        Me.lbInterPolation.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInterPolation.Location = New System.Drawing.Point(21, 68)
        Me.lbInterPolation.Name = "lbInterPolation"
        Me.lbInterPolation.Size = New System.Drawing.Size(82, 15)
        Me.lbInterPolation.TabIndex = 9
        Me.lbInterPolation.Text = "Interpolation:"
        '
        'lnAngle
        '
        Me.lnAngle.AutoSize = True
        Me.lnAngle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnAngle.Location = New System.Drawing.Point(21, 27)
        Me.lnAngle.Name = "lnAngle"
        Me.lnAngle.Size = New System.Drawing.Size(40, 15)
        Me.lnAngle.TabIndex = 11
        Me.lnAngle.Text = "Angle:"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(132, 212)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'RotateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 256)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.cbxKeepSize)
        Me.Controls.Add(Me.cbxInterPolation)
        Me.Controls.Add(Me.tbxAngle)
        Me.Controls.Add(Me.lbInterPolation)
        Me.Controls.Add(Me.lnAngle)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "RotateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rotate Image"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tbxB As System.Windows.Forms.TextBox
    Public WithEvents tbxG As System.Windows.Forms.TextBox
    Public WithEvents tbxR As System.Windows.Forms.TextBox
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents lbB As System.Windows.Forms.Label
    Public WithEvents lbG As System.Windows.Forms.Label
    Public WithEvents lbR As System.Windows.Forms.Label
    Public WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents cbxKeepSize As System.Windows.Forms.CheckBox
    Public WithEvents cbxInterPolation As System.Windows.Forms.ComboBox
    Public WithEvents tbxAngle As System.Windows.Forms.TextBox
    Public WithEvents lbInterPolation As System.Windows.Forms.Label
    Public WithEvents lnAngle As System.Windows.Forms.Label
    Public WithEvents btnCancel As System.Windows.Forms.Button
End Class
