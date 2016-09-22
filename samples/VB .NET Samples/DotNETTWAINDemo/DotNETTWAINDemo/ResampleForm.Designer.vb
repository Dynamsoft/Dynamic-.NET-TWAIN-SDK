<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResampleForm
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
        Me.groupBox = New System.Windows.Forms.GroupBox()
        Me.cbxConstrainProportion = New System.Windows.Forms.CheckBox()
        Me.cbxHeightType = New System.Windows.Forms.ComboBox()
        Me.cbxWidthType = New System.Windows.Forms.ComboBox()
        Me.tbxHeight = New System.Windows.Forms.TextBox()
        Me.tbxWidth = New System.Windows.Forms.TextBox()
        Me.lbHeight = New System.Windows.Forms.Label()
        Me.lbWidth = New System.Windows.Forms.Label()
        Me.cbxResampleType = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lbResampleImage = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.groupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox
        '
        Me.groupBox.Controls.Add(Me.cbxConstrainProportion)
        Me.groupBox.Controls.Add(Me.cbxHeightType)
        Me.groupBox.Controls.Add(Me.cbxWidthType)
        Me.groupBox.Controls.Add(Me.tbxHeight)
        Me.groupBox.Controls.Add(Me.tbxWidth)
        Me.groupBox.Controls.Add(Me.lbHeight)
        Me.groupBox.Controls.Add(Me.lbWidth)
        Me.groupBox.Location = New System.Drawing.Point(12, 19)
        Me.groupBox.Name = "groupBox"
        Me.groupBox.Size = New System.Drawing.Size(260, 132)
        Me.groupBox.TabIndex = 8
        Me.groupBox.TabStop = False
        Me.groupBox.Text = "Pixel Dimension"
        '
        'cbxConstrainProportion
        '
        Me.cbxConstrainProportion.AutoSize = True
        Me.cbxConstrainProportion.Location = New System.Drawing.Point(20, 100)
        Me.cbxConstrainProportion.Name = "cbxConstrainProportion"
        Me.cbxConstrainProportion.Size = New System.Drawing.Size(121, 17)
        Me.cbxConstrainProportion.TabIndex = 4
        Me.cbxConstrainProportion.Text = "Constrain Proportion"
        Me.cbxConstrainProportion.UseVisualStyleBackColor = True
        '
        'cbxHeightType
        '
        Me.cbxHeightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxHeightType.FormattingEnabled = True
        Me.cbxHeightType.Items.AddRange(New Object() {"Pixels", "Percent"})
        Me.cbxHeightType.Location = New System.Drawing.Point(164, 63)
        Me.cbxHeightType.Name = "cbxHeightType"
        Me.cbxHeightType.Size = New System.Drawing.Size(78, 21)
        Me.cbxHeightType.TabIndex = 3
        '
        'cbxWidthType
        '
        Me.cbxWidthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxWidthType.FormattingEnabled = True
        Me.cbxWidthType.Items.AddRange(New Object() {"Pixels", "Percent"})
        Me.cbxWidthType.Location = New System.Drawing.Point(164, 27)
        Me.cbxWidthType.Name = "cbxWidthType"
        Me.cbxWidthType.Size = New System.Drawing.Size(78, 21)
        Me.cbxWidthType.TabIndex = 1
        '
        'tbxHeight
        '
        Me.tbxHeight.Location = New System.Drawing.Point(58, 64)
        Me.tbxHeight.Name = "tbxHeight"
        Me.tbxHeight.Size = New System.Drawing.Size(100, 20)
        Me.tbxHeight.TabIndex = 2
        '
        'tbxWidth
        '
        Me.tbxWidth.Location = New System.Drawing.Point(58, 28)
        Me.tbxWidth.Name = "tbxWidth"
        Me.tbxWidth.Size = New System.Drawing.Size(100, 20)
        Me.tbxWidth.TabIndex = 0
        '
        'lbHeight
        '
        Me.lbHeight.AutoSize = True
        Me.lbHeight.Location = New System.Drawing.Point(17, 67)
        Me.lbHeight.Name = "lbHeight"
        Me.lbHeight.Size = New System.Drawing.Size(38, 13)
        Me.lbHeight.TabIndex = 1
        Me.lbHeight.Text = "Height"
        '
        'lbWidth
        '
        Me.lbWidth.AutoSize = True
        Me.lbWidth.Location = New System.Drawing.Point(17, 31)
        Me.lbWidth.Name = "lbWidth"
        Me.lbWidth.Size = New System.Drawing.Size(35, 13)
        Me.lbWidth.TabIndex = 0
        Me.lbWidth.Text = "Width"
        '
        'cbxResampleType
        '
        Me.cbxResampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxResampleType.FormattingEnabled = True
        Me.cbxResampleType.Items.AddRange(New Object() {"Bicubic", "Bilinear", "Nearest Neighbour", "Best Quality"})
        Me.cbxResampleType.Location = New System.Drawing.Point(118, 176)
        Me.cbxResampleType.Name = "cbxResampleType"
        Me.cbxResampleType.Size = New System.Drawing.Size(136, 21)
        Me.cbxResampleType.TabIndex = 10
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(46, 213)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lbResampleImage
        '
        Me.lbResampleImage.AutoSize = True
        Me.lbResampleImage.Location = New System.Drawing.Point(26, 179)
        Me.lbResampleImage.Name = "lbResampleImage"
        Me.lbResampleImage.Size = New System.Drawing.Size(86, 13)
        Me.lbResampleImage.TabIndex = 9
        Me.lbResampleImage.Text = "Resample Image"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(153, 213)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ResampleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 254)
        Me.Controls.Add(Me.groupBox)
        Me.Controls.Add(Me.cbxResampleType)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lbResampleImage)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ResampleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Image Size"
        Me.groupBox.ResumeLayout(False)
        Me.groupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox As System.Windows.Forms.GroupBox
    Public WithEvents cbxConstrainProportion As System.Windows.Forms.CheckBox
    Public WithEvents cbxHeightType As System.Windows.Forms.ComboBox
    Public WithEvents cbxWidthType As System.Windows.Forms.ComboBox
    Public WithEvents tbxHeight As System.Windows.Forms.TextBox
    Public WithEvents tbxWidth As System.Windows.Forms.TextBox
    Private WithEvents lbHeight As System.Windows.Forms.Label
    Private WithEvents lbWidth As System.Windows.Forms.Label
    Public WithEvents cbxResampleType As System.Windows.Forms.ComboBox
    Private WithEvents btnOk As System.Windows.Forms.Button
    Private WithEvents lbResampleImage As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
End Class
