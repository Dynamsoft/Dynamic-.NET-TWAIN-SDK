Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim strFileName As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.dynamicDotNetTwain.ScanInNewProcess = True

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnSelectSource As System.Windows.Forms.Button
    Friend WithEvents dlgFileSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnAcquire As System.Windows.Forms.Button
    Friend WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSelectSource = New System.Windows.Forms.Button
        Me.dlgFileSave = New System.Windows.Forms.SaveFileDialog
        Me.btnAcquire = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.SuspendLayout()
        '
        'btnSelectSource
        '
        Me.btnSelectSource.Location = New System.Drawing.Point(10, 370)
        Me.btnSelectSource.Name = "btnSelectSource"
        Me.btnSelectSource.Size = New System.Drawing.Size(105, 26)
        Me.btnSelectSource.TabIndex = 4
        Me.btnSelectSource.Text = "Select Source"
        '
        'dlgFileSave
        '
        Me.dlgFileSave.DefaultExt = "bmp"
        Me.dlgFileSave.FileName = "dynamicDotNetTwain"
        Me.dlgFileSave.Filter = "Bitmap File(*.bmp)|*.bmp"
        '
        'btnAcquire
        '
        Me.btnAcquire.Location = New System.Drawing.Point(134, 370)
        Me.btnAcquire.Name = "btnAcquire"
        Me.btnAcquire.Size = New System.Drawing.Size(96, 26)
        Me.btnAcquire.TabIndex = 5
        Me.btnAcquire.Text = "Acquire"
        '
        'dynamicDotNetTwain
        '
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(10, 13)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(412, 351)
        Me.dynamicDotNetTwain.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(432, 406)
        Me.Controls.Add(Me.dynamicDotNetTwain)
        Me.Controls.Add(Me.btnAcquire)
        Me.Controls.Add(Me.btnSelectSource)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Acquire Image with Disk File Mode"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSource.Click
        dynamicDotNetTwain.SelectSource()

    End Sub

    Private Sub btnAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcquire.Click
        If dlgFileSave.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        strFileName = dlgFileSave.FileName

        dynamicDotNetTwain.OpenSource()

        dynamicDotNetTwain.TransferMode = Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE

        'Since the TWSX_FILE mode is not required by TWAIN specification,
        'it is better to read the value back to see if the File transfer mode is supported by the Source
        If dynamicDotNetTwain.TransferMode = Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE Then 'the source supports the TWSX_FILE transfer mode.
            dynamicDotNetTwain.SetFileXFERInfo(strFileName, Dynamsoft.DotNet.TWAIN.Enums.TWICapFileFormat.TWFF_BMP)       'Sets file name and file format information
            dynamicDotNetTwain.IfShowUI = False
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = True
            dynamicDotNetTwain.EnableSource()     'Acquire the image.
        Else                       'the source doesn't support the TWSX_FILE transfer mode.
            MessageBox.Show("The source doesn't support the DiskFile transfer mode.")
        End If

    End Sub

    'Private Sub dynamicDotNetTwain_OnPostTransfer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dynamicDotNetTwain.OnPostTransfer

    '    dynamicDotNetTwain.CloseSource()

    '    dynamicDotNetTwain.LoadImage(strFileName)

    'End Sub

    Private Sub dynamicDotNetTwain_OnPostTransfer() Handles dynamicDotNetTwain.OnPostTransfer
        dynamicDotNetTwain.CloseSource()

        dynamicDotNetTwain.LoadImage(strFileName)
    End Sub
End Class
