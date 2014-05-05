<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.btnSetCapability = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(12, 12)
        Me.dynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(324, 272)
        Me.dynamicDotNetTwain1.TabIndex = 0
        '
        'btnSetCapability
        '
        Me.btnSetCapability.Location = New System.Drawing.Point(12, 299)
        Me.btnSetCapability.Name = "btnSetCapability"
        Me.btnSetCapability.Size = New System.Drawing.Size(159, 23)
        Me.btnSetCapability.TabIndex = 1
        Me.btnSetCapability.Text = "Set Custom CAP 0x:8001"
        Me.btnSetCapability.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(177, 299)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Set Custom CAP 0x:8002"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 330)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(159, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Scan"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 367)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSetCapability)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
	Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Custom Capability Demo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents btnSetCapability As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
