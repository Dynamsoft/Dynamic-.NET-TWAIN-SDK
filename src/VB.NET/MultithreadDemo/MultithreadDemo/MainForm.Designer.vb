<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LoadImageBtn = New System.Windows.Forms.Button
        Me.ScanBtn = New System.Windows.Forms.Button
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.SuspendLayout()
        '
        'LoadImageBtn
        '
        Me.LoadImageBtn.Location = New System.Drawing.Point(9, 3)
        Me.LoadImageBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.LoadImageBtn.Name = "LoadImageBtn"
        Me.LoadImageBtn.Size = New System.Drawing.Size(81, 23)
        Me.LoadImageBtn.TabIndex = 4
        Me.LoadImageBtn.Text = "Load Image"
        Me.LoadImageBtn.UseVisualStyleBackColor = True
        '
        'ScanBtn
        '
        Me.ScanBtn.Location = New System.Drawing.Point(94, 4)
        Me.ScanBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ScanBtn.Name = "ScanBtn"
        Me.ScanBtn.Size = New System.Drawing.Size(81, 23)
        Me.ScanBtn.TabIndex = 5
        Me.ScanBtn.Text = "Scan"
        Me.ScanBtn.UseVisualStyleBackColor = True
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(9, 33)
        Me.dynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(474, 303)
        Me.dynamicDotNetTwain1.TabIndex = 6
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 347)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
        Me.Controls.Add(Me.ScanBtn)
        Me.Controls.Add(Me.LoadImageBtn)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
	Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Multithread Demo"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LoadImageBtn As System.Windows.Forms.Button
    Private WithEvents ScanBtn As System.Windows.Forms.Button
    Friend WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

End Class
