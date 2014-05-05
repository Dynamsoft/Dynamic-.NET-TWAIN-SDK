<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.DynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnLoadPDF = New System.Windows.Forms.Button
        Me.cmbPDFResolution = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LabMsg = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.chbMultiPagePDF = New System.Windows.Forms.CheckBox
        Me.chbMultiPageTIFF = New System.Windows.Forms.CheckBox
        Me.rdbPDF = New System.Windows.Forms.RadioButton
        Me.rdbTIFF = New System.Windows.Forms.RadioButton
        Me.rdbPNG = New System.Windows.Forms.RadioButton
        Me.rdbJPEG = New System.Windows.Forms.RadioButton
        Me.rdbBMP = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DynamicDotNetTwain1
        '
        Me.DynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.DynamicDotNetTwain1.AnnotationPen = Nothing
        Me.DynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.DynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.DynamicDotNetTwain1.IfShowPrintUI = False
        Me.DynamicDotNetTwain1.IfThrowException = False
        Me.DynamicDotNetTwain1.Location = New System.Drawing.Point(-2, -1)
        Me.DynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.DynamicDotNetTwain1.Name = "DynamicDotNetTwain1"
        Me.DynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.Size = New System.Drawing.Size(250, 336)
        Me.DynamicDotNetTwain1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnLoadPDF)
        Me.GroupBox1.Controls.Add(Me.cmbPDFResolution)
        Me.GroupBox1.Controls.Add(Me.label1)
        Me.GroupBox1.Location = New System.Drawing.Point(254, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 121)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load a local PDF file"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "(dpi)"
        '
        'btnLoadPDF
        '
        Me.btnLoadPDF.Location = New System.Drawing.Point(70, 65)
        Me.btnLoadPDF.Name = "btnLoadPDF"
        Me.btnLoadPDF.Size = New System.Drawing.Size(136, 33)
        Me.btnLoadPDF.TabIndex = 5
        Me.btnLoadPDF.Text = "Load PDF"
        Me.btnLoadPDF.UseVisualStyleBackColor = True
        '
        'cmbPDFResolution
        '
        Me.cmbPDFResolution.FormattingEnabled = True
        Me.cmbPDFResolution.Location = New System.Drawing.Point(121, 23)
        Me.cmbPDFResolution.Name = "cmbPDFResolution"
        Me.cmbPDFResolution.Size = New System.Drawing.Size(108, 21)
        Me.cmbPDFResolution.TabIndex = 4
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(103, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Set PDF Resolution:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LabMsg)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.chbMultiPagePDF)
        Me.GroupBox2.Controls.Add(Me.chbMultiPageTIFF)
        Me.GroupBox2.Controls.Add(Me.rdbPDF)
        Me.GroupBox2.Controls.Add(Me.rdbTIFF)
        Me.GroupBox2.Controls.Add(Me.rdbPNG)
        Me.GroupBox2.Controls.Add(Me.rdbJPEG)
        Me.GroupBox2.Controls.Add(Me.rdbBMP)
        Me.GroupBox2.Location = New System.Drawing.Point(254, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 170)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Save Images"
        '
        'LabMsg
        '
        Me.LabMsg.AutoSize = True
        Me.LabMsg.Location = New System.Drawing.Point(71, 150)
        Me.LabMsg.Name = "LabMsg"
        Me.LabMsg.Size = New System.Drawing.Size(0, 13)
        Me.LabMsg.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(68, 112)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 33)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chbMultiPagePDF
        '
        Me.chbMultiPagePDF.AutoSize = True
        Me.chbMultiPagePDF.Location = New System.Drawing.Point(143, 67)
        Me.chbMultiPagePDF.Name = "chbMultiPagePDF"
        Me.chbMultiPagePDF.Size = New System.Drawing.Size(100, 17)
        Me.chbMultiPagePDF.TabIndex = 14
        Me.chbMultiPagePDF.Text = "Multi-Page PDF"
        Me.chbMultiPagePDF.UseVisualStyleBackColor = True
        '
        'chbMultiPageTIFF
        '
        Me.chbMultiPageTIFF.AutoSize = True
        Me.chbMultiPageTIFF.Location = New System.Drawing.Point(25, 67)
        Me.chbMultiPageTIFF.Name = "chbMultiPageTIFF"
        Me.chbMultiPageTIFF.Size = New System.Drawing.Size(101, 17)
        Me.chbMultiPageTIFF.TabIndex = 13
        Me.chbMultiPageTIFF.Text = "Multi-Page TIFF"
        Me.chbMultiPageTIFF.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Location = New System.Drawing.Point(216, 30)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 17)
        Me.rdbPDF.TabIndex = 12
        Me.rdbPDF.TabStop = True
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbTIFF
        '
        Me.rdbTIFF.AutoSize = True
        Me.rdbTIFF.Location = New System.Drawing.Point(162, 29)
        Me.rdbTIFF.Name = "rdbTIFF"
        Me.rdbTIFF.Size = New System.Drawing.Size(47, 17)
        Me.rdbTIFF.TabIndex = 11
        Me.rdbTIFF.TabStop = True
        Me.rdbTIFF.Text = "TIFF"
        Me.rdbTIFF.UseVisualStyleBackColor = True
        '
        'rdbPNG
        '
        Me.rdbPNG.AutoSize = True
        Me.rdbPNG.Location = New System.Drawing.Point(111, 29)
        Me.rdbPNG.Name = "rdbPNG"
        Me.rdbPNG.Size = New System.Drawing.Size(48, 17)
        Me.rdbPNG.TabIndex = 10
        Me.rdbPNG.TabStop = True
        Me.rdbPNG.Text = "PNG"
        Me.rdbPNG.UseVisualStyleBackColor = True
        '
        'rdbJPEG
        '
        Me.rdbJPEG.AutoSize = True
        Me.rdbJPEG.Location = New System.Drawing.Point(56, 29)
        Me.rdbJPEG.Name = "rdbJPEG"
        Me.rdbJPEG.Size = New System.Drawing.Size(52, 17)
        Me.rdbJPEG.TabIndex = 9
        Me.rdbJPEG.TabStop = True
        Me.rdbJPEG.Text = "JPEG"
        Me.rdbJPEG.UseVisualStyleBackColor = True
        '
        'rdbBMP
        '
        Me.rdbBMP.AutoSize = True
        Me.rdbBMP.Location = New System.Drawing.Point(7, 29)
        Me.rdbBMP.Name = "rdbBMP"
        Me.rdbBMP.Size = New System.Drawing.Size(48, 17)
        Me.rdbBMP.TabIndex = 8
        Me.rdbBMP.TabStop = True
        Me.rdbBMP.Text = "BMP"
        Me.rdbBMP.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 332)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DynamicDotNetTwain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "PDF Rasterizer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnLoadPDF As System.Windows.Forms.Button
    Private WithEvents cmbPDFResolution As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents chbMultiPagePDF As System.Windows.Forms.CheckBox
    Private WithEvents chbMultiPageTIFF As System.Windows.Forms.CheckBox
    Private WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Private WithEvents rdbTIFF As System.Windows.Forms.RadioButton
    Private WithEvents rdbPNG As System.Windows.Forms.RadioButton
    Private WithEvents rdbJPEG As System.Windows.Forms.RadioButton
    Private WithEvents rdbBMP As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabMsg As System.Windows.Forms.Label

End Class
