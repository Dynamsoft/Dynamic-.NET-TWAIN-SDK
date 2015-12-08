Imports System.IO
Imports Dynamsoft.DotNet.TWAIN

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        Me.dynamicDotNetTwain1.MaxImagesInBuffer = 1000
        Me.dynamicDotNetTwain1.SetViewMode(3, 3)
        Me.dynamicDotNetTwain1.AllowMultiSelect = True
    End Sub

    Private Sub AddFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFileToolStripMenuItem.Click
        Dim fileOpener As OpenFileDialog
        fileOpener = New OpenFileDialog()
        fileOpener.Filter = "TIFF Images (*.tif;*.tiff)|*.tif;*.tiff"

        If (fileOpener.ShowDialog() = DialogResult.OK) Then
            TryAddingFile(fileOpener.FileName)
        End If
    End Sub

    Private Sub TryAddingFile(ByVal strFileName As String)
        OnFileAdded(strFileName)
    End Sub

    Private Function AlreadyAddedFile(ByVal strFileName As String) As Boolean
        Dim strfileNameInList As String
        For Each strfileNameInList In fileList.Items
            If strfileNameInList = strFileName Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub OnFileAdded(ByVal strFileName As String)
        If (Me.dynamicDotNetTwain1.LoadImageEx(strFileName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF) = False) Then
            MessageBox.Show("Unable to open the file - it might not be a TIFF or it might be damaged.")
        End If
        fileList.Items.Add(Path.GetFileName(strFileName))
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If dynamicDotNetTwain1.HowManyImagesInBuffer > 0 Then
            Dim fileSaver As SaveFileDialog
            fileSaver = New SaveFileDialog()
            fileSaver.Filter = "TIFF Image (*.tif)|*.tif"

            If (fileSaver.ShowDialog() = DialogResult.OK) Then
                TrySavingFile(fileSaver.FileName)
            End If
        Else
            MessageBox.Show("There is no file in buffer! Please add some files.")
        End If
    End Sub

    Private Sub TrySavingFile(ByVal strFileName As String)
        If (AlreadyAddedFile(strFileName)) Then
            MessageBox.Show("Can't save over one of the source files.")
        Else
            Me.dynamicDotNetTwain1.SaveAllAsMultiPageTIFF(strFileName)
        End If
    End Sub

    Private Sub DeleteSelectedImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedImageToolStripMenuItem.Click
        Me.dynamicDotNetTwain1.RemoveImages(Me.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer)
    End Sub

    Private Sub SwitchImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchImagesToolStripMenuItem.Click
        If (Me.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer.Count = 2) Then
            Dim aryList As IndexList
            aryList = Me.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer
            Me.dynamicDotNetTwain1.SwitchImage(CShort(aryList(0)), CShort(aryList(1)))
        Else
            MessageBox.Show("Unable to complete the operation. First select two images to switch.")
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
