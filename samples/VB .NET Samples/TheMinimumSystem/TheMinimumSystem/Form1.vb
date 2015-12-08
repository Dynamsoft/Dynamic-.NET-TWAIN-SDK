Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim strFileName As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        dynamicDotNetTwain.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        'Add any initialization after the InitializeComponent() call
        dynamicDotNetTwain.ScanInNewProcess = True
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
    Friend WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnAcquire As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAcquire = New System.Windows.Forms.Button
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.SuspendLayout()
        '
        'btnAcquire
        '
        Me.btnAcquire.Location = New System.Drawing.Point(10, 342)
        Me.btnAcquire.Name = "btnAcquire"
        Me.btnAcquire.Size = New System.Drawing.Size(90, 27)
        Me.btnAcquire.TabIndex = 1
        Me.btnAcquire.Text = "Acquire"
        '
        'dynamicDotNetTwain
        '
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(10, 13)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(390, 323)
        Me.dynamicDotNetTwain.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(406, 377)
        Me.Controls.Add(Me.dynamicDotNetTwain)
        Me.Controls.Add(Me.btnAcquire)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
	Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "The Minimum System"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcquire.Click
        dynamicDotNetTwain.IfDisableSourceAfterAcquire = True
        If dynamicDotNetTwain.SelectSource() Then
            dynamicDotNetTwain.AcquireImage()
        End If
    End Sub


    Private Sub dynamicDotNetTwain_OnPostTransfer() Handles dynamicDotNetTwain.OnPostTransfer
        GC.Collect()
    End Sub
End Class
