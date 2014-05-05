Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Dynamsoft.DotNet.TWAIN

    Public Class DotNetTWAINDemo

        ' For move the window
        Dim mouse_offset As System.Drawing.Point
        ' For move the annotation form
        Dim mouse_offset2 As System.Drawing.Point
    Dim currentImageIndex As Integer
    Public Delegate Sub CrossThreadOperationControl()
        Dim isToCrop As Boolean
        Dim infoLabel As Label
        Dim lbLoadImageInfo As Label
    Private WithEvents picboxLoadImage As System.Windows.Forms.PictureBox

 
    Private Sub DotNetTWAINDemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        currentImageIndex = -1
        isToCrop = False

        InitUI()
        InitDefaultValueForTWAIN()
    End Sub

    Private Sub InitUI()
        Me.dynamicDotNetTwain.Visible = False
        panelAnnotations.Visible = False

        DisableAllFunctionButtons()

        ' Init the View mode
        Me.cbxViewMode.Items.Clear()
        Me.cbxViewMode.Items.Insert(0, "1 x 1")
        Me.cbxViewMode.Items.Insert(1, "2 x 2")
        Me.cbxViewMode.Items.Insert(2, "3 x 3")
        Me.cbxViewMode.Items.Insert(3, "4 x 4")
        Me.cbxViewMode.Items.Insert(4, "5 x 5")

        ' Init the cbxResolution
        Me.cbxResolution.Items.Clear()
        Me.cbxResolution.Items.Insert(0, "100")
        Me.cbxResolution.Items.Insert(1, "150")
        Me.cbxResolution.Items.Insert(2, "200")
        Me.cbxResolution.Items.Insert(3, "300")

        ' Init the Scan Button
        DisableControls(Me.picboxScan)

        ' Init the save image type
        Me.rdbtnJPG.Checked = True

        ' Init the Save Image Button
        DisableControls(Me.picboxSave)

        ' For the popup tip label
        infoLabel = New Label()
        infoLabel.Text = ""
        infoLabel.Visible = False
        infoLabel.AutoSize = True
        infoLabel.Name = "Info"
        infoLabel.BackColor = System.Drawing.Color.White
        infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        infoLabel.Font = New System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        infoLabel.BringToFront()
        Me.Controls.Add(infoLabel)

        ' For the load image label
        Me.lbLoadImageInfo = New System.Windows.Forms.Label()
        Me.lbLoadImageInfo.AutoSize = True
        Me.lbLoadImageInfo.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
        Me.lbLoadImageInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lbLoadImageInfo.Location = New System.Drawing.Point(19, 50)
        Me.lbLoadImageInfo.Name = "lbLoadImageInfo"
        Me.lbLoadImageInfo.Size = New System.Drawing.Size(83, 15)
        Me.lbLoadImageInfo.TabIndex = 84
        Me.lbLoadImageInfo.Text = "Load a local image"
        Me.lbLoadImageInfo.Visible = False

        ' For the load image button
        picboxLoadImage = New System.Windows.Forms.PictureBox()
        CType(picboxLoadImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picboxLoadImage.Image = CType(My.Resources.Resources.ResourceManager.GetObject("picboxLoadImage_Leave"), System.Drawing.Image)

        Me.picboxLoadImage.Location = New System.Drawing.Point(40, 82)
        Me.picboxLoadImage.Name = "picboxLoadImage"
        Me.picboxLoadImage.Size = New System.Drawing.Size(180, 38)
        Me.picboxLoadImage.TabIndex = 59
        Me.picboxLoadImage.TabStop = False
        Me.picboxLoadImage.Tag = "Load a local image"
        Me.picboxLoadImage.Visible = False
        CType(Me.picboxLoadImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelSource.Controls.Add(Me.lbLoadImageInfo)
        Me.panelSource.Controls.Add(Me.picboxLoadImage)

    End Sub

    Private Sub InitDefaultValueForTWAIN()
        Try
            ' dynamicDotNetTwain.IfThrowException = true
            dynamicDotNetTwain.IfFitWindow = True
            dynamicDotNetTwain.MouseShape = False
            dynamicDotNetTwain.SetViewMode(-1, -1)
            Me.cbxViewMode.SelectedIndex = 0

            ' Init the sources for TWAIN scanning, show in the cbxSources controls
            If (dynamicDotNetTwain.SourceCount > 0) Then
                Dim i As Integer
                For i = 0 To dynamicDotNetTwain.SourceCount - 1
                    cbxSource.Items.Add(dynamicDotNetTwain.SourceNameItems(i))
                Next

                cbxSource.Enabled = True
                chkShowUI.Enabled = True
                chkADF.Enabled = True
                chkDuplex.Enabled = True
                cbxResolution.Enabled = True
                EnableControls(Me.picboxScan)

                cbxSource.SelectedIndex = 0
                rdbtnGray.Checked = True
                cbxResolution.SelectedIndex = 0
                dynamicDotNetTwain.SelectSourceByIndex(cbxSource.SelectedIndex)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DrawBackground()
        ' Create a bitmap
        Dim img As Bitmap
        img = My.Resources.Resources.main_bg
        ' Set the form properties
        'Size AS New Size(img.Width, img.Height)
        Dim BackgroundImage As Bitmap
        BackgroundImage = New Bitmap(Width, Height)

        ' Draw it
        Dim g As Graphics
        g = Graphics.FromImage(BackgroundImage)
        g.DrawImage(img, 0, 0, img.Width, img.Height)

    End Sub

    Private Sub DisableAllFunctionButtons()
        DisableControls(Me.picboxHand)
        DisableControls(Me.picboxPoint)
        DisableControls(Me.picboxCrop)
        DisableControls(Me.picboxRotate)

        DisableControls(Me.picboxRotateRight)
        DisableControls(Me.picboxRotateLeft)
        DisableControls(Me.picboxMirror)
        DisableControls(Me.picboxFlip)

        DisableControls(Me.picboxLine)
        DisableControls(Me.picboxEllipse)
        DisableControls(Me.picboxRectangle)
        DisableControls(Me.picboxText)

        DisableControls(Me.picboxZoom)
        DisableControls(Me.picboxResample)
        DisableControls(Me.picboxZoomIn)
        DisableControls(Me.picboxZoomOut)

        DisableControls(Me.picboxDelete)
        DisableControls(Me.picboxDeleteAll)

        DisableControls(Me.picboxFirst)
        DisableControls(Me.picboxPrevious)
        DisableControls(Me.picboxNext)
        DisableControls(Me.picboxLast)
    End Sub


    ''' <summary>
    '''  Enable all the function buttons in the left and bottom panel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableAllFunctionButtons()
        EnableControls(Me.picboxHand)
        EnableControls(Me.picboxPoint)
        EnableControls(Me.picboxCrop)
        EnableControls(Me.picboxRotate)

        EnableControls(Me.picboxRotateRight)
        EnableControls(Me.picboxRotateLeft)
        EnableControls(Me.picboxMirror)
        EnableControls(Me.picboxFlip)

        EnableControls(Me.picboxLine)
        EnableControls(Me.picboxEllipse)
        EnableControls(Me.picboxRectangle)
        EnableControls(Me.picboxText)

        EnableControls(Me.picboxZoom)
        EnableControls(Me.picboxResample)
        EnableControls(Me.picboxZoomIn)
        EnableControls(Me.picboxZoomOut)

        EnableControls(Me.picboxDelete)
        EnableControls(Me.picboxDeleteAll)

        If dynamicDotNetTwain.HowManyImagesInBuffer > 1 Then
            EnableControls(Me.picboxFirst)
            EnableControls(Me.picboxPrevious)
            EnableControls(Me.picboxNext)
            EnableControls(Me.picboxLast)

            If (dynamicDotNetTwain.CurrentImageIndexInBuffer = 0) Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If

            If (dynamicDotNetTwain.CurrentImageIndexInBuffer + 1 = dynamicDotNetTwain.HowManyImagesInBuffer) Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        End If

        checkZoom()
    End Sub

#Region "regist Event For All PictureBox Buttons"

    Private Sub picbox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxHand.MouseDown, picboxPoint.MouseDown, picboxCrop.MouseDown, picboxRotate.MouseDown, _
                picboxRotateRight.MouseDown, picboxRotateLeft.MouseDown, picboxMirror.MouseDown, picboxFlip.MouseDown, _
                picboxLine.MouseDown, picboxEllipse.MouseDown, picboxRectangle.MouseDown, picboxText.MouseDown, _
                picboxZoom.MouseDown, picboxResample.MouseDown, picboxZoomIn.MouseDown, picboxZoomOut.MouseDown, _
                picboxDelete.MouseDown, picboxDeleteAll.MouseDown, picboxLoadImage.MouseDown, _
                picboxFirst.MouseDown, picboxLast.MouseDown, picboxNext.MouseDown, picboxPrevious.MouseDown, _
                picboxSave.MouseDown, picboxMin.MouseDown, picboxClose.MouseDown, picboxScan.MouseDown, _
                picboxDeleteAnnotationA.MouseDown, picboxEllipseA.MouseDown, picboxRectangleA.MouseDown, _
                picboxTextA.MouseDown, picboxLineA.MouseDown
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Down"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxHand.MouseEnter, picboxPoint.MouseEnter, picboxCrop.MouseEnter, picboxRotate.MouseEnter, _
                picboxRotateRight.MouseEnter, picboxRotateLeft.MouseEnter, picboxMirror.MouseEnter, picboxFlip.MouseEnter, _
                picboxLine.MouseEnter, picboxEllipse.MouseEnter, picboxRectangle.MouseEnter, picboxText.MouseEnter, _
                picboxZoom.MouseEnter, picboxResample.MouseEnter, picboxZoomIn.MouseEnter, picboxZoomOut.MouseEnter, _
                picboxDelete.MouseEnter, picboxDeleteAll.MouseEnter, picboxLoadImage.MouseEnter, _
                picboxFirst.MouseEnter, picboxLast.MouseEnter, picboxNext.MouseEnter, picboxPrevious.MouseEnter, _
                picboxSave.MouseEnter, picboxMin.MouseEnter, picboxClose.MouseEnter, picboxScan.MouseEnter, _
                picboxDeleteAnnotationA.MouseEnter, picboxEllipseA.MouseEnter, picboxRectangleA.MouseEnter, _
                picboxTextA.MouseEnter, picboxLineA.MouseEnter
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxHand.MouseHover, picboxPoint.MouseHover, picboxCrop.MouseHover, picboxRotate.MouseHover, _
                picboxRotateRight.MouseHover, picboxRotateLeft.MouseHover, picboxMirror.MouseHover, picboxFlip.MouseHover, _
                picboxLine.MouseHover, picboxEllipse.MouseHover, picboxRectangle.MouseHover, picboxText.MouseHover, _
                picboxZoom.MouseHover, picboxResample.MouseHover, picboxZoomIn.MouseHover, picboxZoomOut.MouseHover, _
                picboxDelete.MouseHover, picboxDeleteAll.MouseHover, _
                picboxFirst.MouseHover, picboxLast.MouseHover, picboxNext.MouseHover, picboxPrevious.MouseHover, _
                picboxDeleteAnnotationA.MouseHover, picboxEllipseA.MouseHover, picboxRectangleA.MouseHover, _
                picboxTextA.MouseHover, picboxLineA.MouseHover
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            infoLabel.Text = picBox.Tag.ToString()
            infoLabel.Location = New Point(Me.PointToClient(MousePosition).X, Me.PointToClient(MousePosition).Y + 20)
            infoLabel.Visible = True
            infoLabel.BringToFront()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxHand.MouseLeave, picboxPoint.MouseLeave, picboxCrop.MouseLeave, picboxRotate.MouseLeave, _
                picboxRotateRight.MouseLeave, picboxRotateLeft.MouseLeave, picboxMirror.MouseLeave, picboxFlip.MouseLeave, _
                picboxLine.MouseLeave, picboxEllipse.MouseLeave, picboxRectangle.MouseLeave, picboxText.MouseLeave, _
                picboxZoom.MouseLeave, picboxResample.MouseLeave, picboxZoomIn.MouseLeave, picboxZoomOut.MouseLeave, _
                picboxDelete.MouseLeave, picboxDeleteAll.MouseLeave, picboxLoadImage.MouseLeave, _
                picboxFirst.MouseLeave, picboxLast.MouseLeave, picboxNext.MouseLeave, picboxPrevious.MouseLeave, _
                picboxSave.MouseLeave, picboxMin.MouseLeave, picboxClose.MouseLeave, picboxScan.MouseLeave, _
                picboxDeleteAnnotationA.MouseLeave, picboxEllipseA.MouseLeave, picboxRectangleA.MouseLeave, _
                picboxTextA.MouseLeave, picboxLineA.MouseLeave
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), System.Drawing.Image)
                infoLabel.Text = ""
                infoLabel.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxHand.MouseUp, picboxPoint.MouseUp, picboxCrop.MouseUp, picboxRotate.MouseUp, _
                picboxRotateRight.MouseUp, picboxRotateLeft.MouseUp, picboxMirror.MouseUp, picboxFlip.MouseUp, _
                picboxLine.MouseUp, picboxEllipse.MouseUp, picboxRectangle.MouseUp, picboxText.MouseUp, _
                picboxZoom.MouseUp, picboxResample.MouseUp, picboxZoomIn.MouseUp, picboxZoomOut.MouseUp, _
                picboxDelete.MouseUp, picboxDeleteAll.MouseUp, picboxLoadImage.MouseUp, _
                picboxFirst.MouseUp, picboxLast.MouseUp, picboxNext.MouseUp, picboxPrevious.MouseUp, _
                picboxSave.MouseUp, picboxMin.MouseUp, picboxClose.MouseUp, picboxScan.MouseUp, _
                picboxDeleteAnnotationA.MouseUp, picboxEllipseA.MouseUp, picboxRectangleA.MouseUp, _
                picboxTextA.MouseUp, picboxLineA.MouseUp
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DisableControls(ByVal sender As System.Object)
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Disabled"), System.Drawing.Image)
            picBox.Enabled = False
        Catch ex As Exception
            picBox = CType(sender, Control)
            picBox.Enabled = False
        End Try
    End Sub

    Private Sub EnableControls(ByVal sender As System.Object)
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), System.Drawing.Image)
            picBox.Enabled = True
        Catch ex As Exception
            picBox = CType(sender, Control)
            picBox.Enabled = True
        End Try
    End Sub
#End Region

#Region "functions for the form, ignore them please"
    Private Sub lbMoveBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbMoveBar.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub lbMoveBar_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbMoveBar.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Dim mousePos As Point
            mousePos = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Me.Location = mousePos
        End If
    End Sub

    Private Sub picboxClose_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxClose.MouseClick
        Application.Exit()
    End Sub

    Private Sub picboxMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

    Private Sub picboxLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLoadImage.Click
        openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF"
        openFileDialog.FilterIndex = 0
        openFileDialog.Multiselect = False
        dynamicDotNetTwain.IfAppendImage = True
        If (openFileDialog.ShowDialog() = DialogResult.OK) Then
            dynamicDotNetTwain.LoadImage(openFileDialog.FileName)
            dynamicDotNetTwain.Visible = True
        End If
        checkImageCount()
    End Sub

    ''' <summary>
    ''' If the image count changed, some features should changed.
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub picboxScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxScan.Click
        If (Me.cbxSource.SelectedIndex < 0) Then
            MessageBox.Show(Me, "There is no scaner detected!\n " + "Please ensure that at least one (virtual) scanner is installed.", "Information")
        Else
            Me.AcquireImage()
        End If
    End Sub


    ''' <summary>
    ''' Acquire image from the selected source
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AcquireImage()
        Try
            ' Select the source for TWAIN
            dynamicDotNetTwain.SelectSourceByIndex(cbxSource.SelectedIndex)
            dynamicDotNetTwain.OpenSource()
            ' Set the image fit the size of window
            'dynamicDotNetTwain.IfFitWindow = true;
            'dynamicDotNetTwain.MouseShape = false;

            dynamicDotNetTwain.IfShowUI = chkShowUI.Checked

            ' if (chkADF.Enabled)
            ' dynamicDotNetTwain.IfAutoFeed = dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked;
            dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked
            dynamicDotNetTwain.IfAutoFeed = chkADF.Checked
            ' if (chkDuplex.Enabled)
            dynamicDotNetTwain.IfDuplexEnabled = chkDuplex.Checked

            ' Need to open source first
            ' dynamicDotNetTwain.OpenSource();
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = True

            If (rdbtnBW.Checked) Then
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW
                dynamicDotNetTwain.BitDepth = 1
            ElseIf (rdbtnGray.Checked) Then
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                dynamicDotNetTwain.BitDepth = 8
            Else
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                dynamicDotNetTwain.BitDepth = 24
            End If

            dynamicDotNetTwain.Resolution = Integer.Parse(cbxResolution.Text)
            ' Acquire image from the source
            dynamicDotNetTwain.AcquireImage()
        Catch ex As Exception
            MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    '''  multi-page are allowed for tiff and pdf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbtnMultiPage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnPDF.CheckedChanged, rdbtnTIFF.CheckedChanged
        Dim radioButton As RadioButton
        Try
            radioButton = CType(sender, RadioButton)
            If radioButton.Checked = True Then
                Me.chkMultiPage.Enabled = True
                Me.chkMultiPage.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' When other image formats are selected, multi-page are not allowed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbtnSinglePage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnJPG.CheckedChanged, rdbtnPNG.CheckedChanged, rdbtnBMP.CheckedChanged
        Dim radioButton As RadioButton
        Try
            radioButton = CType(sender, RadioButton)
            If radioButton.Checked = True Then
                Me.chkMultiPage.Enabled = False
                Me.chkMultiPage.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Verified the file name. If the file name is ok, return true, else return false.
    ''' </summary>
    ''' <param name="fileName">file name</param>
    ''' <remarks></remarks>
    Private Function VerifyFileName(ByVal fileName As String) As Boolean
        Dim i As Integer
        For i = 0 To fileName.Length - 1
            If (Char.IsLetterOrDigit(fileName(i)) = False And fileName(i) <> "_" And fileName(i) <> " ") Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub picboxSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSave.Click
        Dim fileName As String
        fileName = tbxSaveFileName.Text.Trim()
        If (VerifyFileName(fileName)) Then
            saveFileDialog.FileName = Me.tbxSaveFileName.Text
            If (rdbtnJPG.Checked) Then
                saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF"
                saveFileDialog.DefaultExt = "jpg"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsJPEG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If
            If (rdbtnBMP.Checked) Then
                saveFileDialog.Filter = "BMP|*.BMP"
                saveFileDialog.DefaultExt = "bmp"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsBMP(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If

            If (rdbtnPNG.Checked) Then
                saveFileDialog.Filter = "PNG|*.PNG"
                saveFileDialog.DefaultExt = "png"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsPNG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If

            If (rdbtnTIFF.Checked) Then
                saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF"
                saveFileDialog.DefaultExt = "tiff"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    ' Multi page TIFF
                    If (chkMultiPage.Checked = True) Then
                        dynamicDotNetTwain.SaveAllAsMultiPageTIFF(saveFileDialog.FileName)
                    Else
                        dynamicDotNetTwain.SaveAsTIFF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                End If
            End If

            If (rdbtnPDF.Checked) Then
                saveFileDialog.Filter = "PDF|*.PDF"
                saveFileDialog.DefaultExt = "pdf"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    ' Multi page PDF
                    dynamicDotNetTwain.IfSaveAnnotations = True
                    If (chkMultiPage.Checked = True) Then
                        dynamicDotNetTwain.SaveAllAsPDF(saveFileDialog.FileName)
                    Else
                        dynamicDotNetTwain.SaveAsPDF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                End If
            End If
        Else
            Me.tbxSaveFileName.Focus()
        End If
    End Sub

    Private Sub picboxPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxPoint.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone
    End Sub

    Private Sub picboxHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxHand.Click
        dynamicDotNetTwain.MouseShape = True
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone
    End Sub


    Private Sub picboxRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRotate.Click
        Dim angle As Double
        Dim interPolation As Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod
        interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear
        Dim keepSize As Boolean
        Dim r, g, b As Integer
        Dim fillColor As Color
        Dim rotateForm As RotateForm
        rotateForm = New RotateForm()
        rotateForm.ShowDialog()

        If (rotateForm.DialogResult = System.Windows.Forms.DialogResult.OK) Then
            If (rotateForm.cbxInterPolation.SelectedIndex = 0) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bicubic
            End If
            If (rotateForm.cbxInterPolation.SelectedIndex = 1) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear
            End If

            If (rotateForm.cbxInterPolation.SelectedIndex = 2) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.NearestNeighbour
            End If

            keepSize = rotateForm.cbxKeepSize.Checked

            Dim dAngle, iR, iG, iB As Boolean
            dAngle = Double.TryParse(rotateForm.tbxAngle.Text, angle)
            iR = Integer.TryParse(rotateForm.tbxR.Text, r)
            iG = Integer.TryParse(rotateForm.tbxG.Text, g)
            iB = Integer.TryParse(rotateForm.tbxB.Text, b)

            If (dAngle And iR And iG And iB) Then
                If (r >= 0 And r <= 255 And g >= 0 And g <= 255 And b >= 0 And b <= 255) Then
                    fillColor = Color.FromArgb(r, g, b)
                    dynamicDotNetTwain.BackgroundFillColor = fillColor.ToArgb()
                End If
                dynamicDotNetTwain.Rotate(dynamicDotNetTwain.CurrentImageIndexInBuffer, angle, keepSize, interPolation)
            End If
        End If
    End Sub

    Private Sub picboxCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxCrop.Click
        'if (dynamicDotNetTwain.AnnotationType != Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone)
        '{
        picboxPoint_Click(sender, Nothing)
        '}    //what does this mean?
        Dim rc As Rectangle
        rc = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        If (rc.IsEmpty) Then
            'isToCrop = true;
            'dynamicDotNetTwain.MouseShape = false;
            'DisableAllFunctionButtons();//why this?
            MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            cropPicture(dynamicDotNetTwain.CurrentImageIndexInBuffer, rc)
        End If
    End Sub

    Private Sub cropPicture(ByVal imageIndex As Integer, ByVal rc As Rectangle)
        dynamicDotNetTwain.Crop(imageIndex, rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height)
    End Sub

    Private Sub picboxRotateLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRotateLeft.Click
        dynamicDotNetTwain.RotateLeft(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxRotateRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRotateRight.Click
        dynamicDotNetTwain.RotateRight(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxMirror_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxMirror.Click
        dynamicDotNetTwain.Mirror(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxFlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxFlip.Click
        dynamicDotNetTwain.Flip(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLine.Click, picboxLineA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Blue, 5)
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumLine
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxEllipse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxEllipse.Click, picboxEllipseA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Black, 2)
        dynamicDotNetTwain.AnnotationFillColor = Color.Blue
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumEllipse
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxRectangle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRectangle.Click, picboxRectangleA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Black, 2)
        dynamicDotNetTwain.AnnotationFillColor = Color.ForestGreen
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumRectangle
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxText.Click, picboxTextA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationTextColor = Color.Black
        dynamicDotNetTwain.AnnotationTextFont = New Font("", 32)
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumText
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoom.Click
        Dim zoomForm As New ZoomForm
        zoomForm.SetZoomRatio(dynamicDotNetTwain.Zoom)
        zoomForm.ShowDialog()
        If (zoomForm.DialogResult = DialogResult.OK) Then
            dynamicDotNetTwain.IfFitWindow = False
            dynamicDotNetTwain.Zoom = zoomForm.GetZoomRatio()
            checkZoom()
        End If
    End Sub

    Private Sub picboxResample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxResample.Click
        Dim width, height As Integer
        width = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Width
        height = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Height

        Dim resampleForm As New ResampleForm
        resampleForm.InitResampleForm(width, height)
        resampleForm.ShowDialog()
        If (resampleForm.DialogResult = DialogResult.OK) Then
            dynamicDotNetTwain.ChangeImageSize(dynamicDotNetTwain.CurrentImageIndexInBuffer, resampleForm.GetNewWidth(), resampleForm.GetNewHeight(), resampleForm.GetInterpolation())
            dynamicDotNetTwain.IfFitWindow = False
        End If
    End Sub

    Private Sub picboxZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoomIn.Click
        Dim zoom As Decimal
        zoom = dynamicDotNetTwain.Zoom + 0.1F
        dynamicDotNetTwain.IfFitWindow = False
        dynamicDotNetTwain.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub picboxZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoomOut.Click
        Dim zoom As Decimal
        zoom = dynamicDotNetTwain.Zoom - 0.1F
        dynamicDotNetTwain.IfFitWindow = False
        dynamicDotNetTwain.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub checkZoom()
        If (cbxViewMode.SelectedIndex <> 0 Or dynamicDotNetTwain.HowManyImagesInBuffer = 0) Then
            DisableControls(picboxZoomIn)
            DisableControls(picboxZoomOut)
            DisableControls(picboxZoom)
            Return
        End If

        If (picboxZoom.Enabled = False) Then
            EnableControls(picboxZoom)
        End If

        '  the valid range of zoom is between 0.02 to 65.0,

        If (dynamicDotNetTwain.Zoom <= 0.02F) Then
            DisableControls(picboxZoomOut)
        Else
            EnableControls(picboxZoomOut)
        End If

        If (dynamicDotNetTwain.Zoom >= 65.0F) Then
            DisableControls(picboxZoomIn)
        Else
            EnableControls(picboxZoomIn)
        End If
    End Sub

    Private Sub picboxDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDelete.Click
        dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        checkImageCount()
    End Sub

    Private Sub picboxDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDeleteAll.Click
        dynamicDotNetTwain.RemoveAllImages()
        checkImageCount()
    End Sub

    Private Sub checkImageCount()
        currentImageIndex = dynamicDotNetTwain.CurrentImageIndexInBuffer
        Dim currentIndex As Integer
        Dim imageCount As Integer

        currentIndex = currentImageIndex + 1
        imageCount = dynamicDotNetTwain.HowManyImagesInBuffer
        If (imageCount = 0) Then
            currentIndex = 0
        End If

        tbxCurrentImageIndex.Text = currentIndex.ToString()
        tbxTotalImageNum.Text = imageCount.ToString()

        If (imageCount > 0) Then
            EnableControls(picboxSave)
            EnableAllFunctionButtons()
        Else
            DisableControls(picboxSave)
            DisableAllFunctionButtons()
            dynamicDotNetTwain.Visible = False
            panelAnnotations.Visible = False
        End If
        If (imageCount > 1) Then

            EnableControls(picboxFirst)
            EnableControls(picboxLast)
            EnableControls(picboxPrevious)
            EnableControls(picboxNext)

            If (currentIndex = 1) Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If

            If (currentIndex = imageCount) Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        Else
            DisableControls(picboxFirst)
            DisableControls(picboxLast)
            DisableControls(picboxPrevious)
            DisableControls(picboxNext)
        End If
    End Sub

    Private Sub cbxViewMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxViewMode.SelectedIndexChanged
        Select Case Me.cbxViewMode.SelectedIndex
            Case 0
                dynamicDotNetTwain.SetViewMode(-1, -1)
            Case 1
                dynamicDotNetTwain.SetViewMode(2, 2)
            Case 2
                dynamicDotNetTwain.SetViewMode(3, 3)
            Case 3
                dynamicDotNetTwain.SetViewMode(4, 4)
            Case 4
                dynamicDotNetTwain.SetViewMode(5, 5)
            Case Else
                dynamicDotNetTwain.SetViewMode(-1, -1)
        End Select
        checkZoom()
    End Sub

    Private Sub picboxFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxFirst.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = 0
            checkImageCount()
        End If
    End Sub

    Private Sub picboxLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLast.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = (dynamicDotNetTwain.HowManyImagesInBuffer - 1)
            checkImageCount()
        End If
    End Sub

    Private Sub picboxPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxPrevious.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0 And dynamicDotNetTwain.CurrentImageIndexInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = dynamicDotNetTwain.CurrentImageIndexInBuffer - 1
            checkImageCount()
        End If

    End Sub

    Private Sub picboxNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxNext.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0 And dynamicDotNetTwain.CurrentImageIndexInBuffer < dynamicDotNetTwain.HowManyImagesInBuffer - 1) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = dynamicDotNetTwain.CurrentImageIndexInBuffer + 1
            checkImageCount()
        End If

    End Sub

    Private Sub dynamicDotNetTwain_OnMouseClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseClick
        If (dynamicDotNetTwain.CurrentImageIndexInBuffer <> currentImageIndex) Then
            checkImageCount()
        End If
    End Sub

    Public Sub CallMe()
        dynamicDotNetTwain.Visible = True
        checkImageCount()
        EnableControls(picboxScan)
    End Sub
    Private Sub dynamicDotNetTwain_OnPostTransfer() Handles dynamicDotNetTwain.OnPostTransfer

        Me.Invoke(New CrossThreadOperationControl(AddressOf CallMe))
    End Sub

    Private Sub dynamicDotNetTwain_OnMouseDoubleClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseDoubleClick
        Try
            Dim rc As Rectangle
            rc = dynamicDotNetTwain.GetSelectionRect(sImageIndex)

            If (isToCrop And rc.IsEmpty = False) Then
                cropPicture(sImageIndex, rc)
            End If
            isToCrop = False
        Catch ex As Exception

        End Try
        EnableAllFunctionButtons()
    End Sub

    Private Sub dynamicDotNetTwain_OnMouseRightClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseRightClick
        If (isToCrop) Then
            isToCrop = False
        End If
        dynamicDotNetTwain.ClearSelectionRect(sImageIndex)
        EnableAllFunctionButtons()
    End Sub

    Private Sub dynamicDotNetTwain_OnImageAreaDeselected(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnImageAreaDeselected
        If (isToCrop) Then
            isToCrop = False
        End If
        EnableAllFunctionButtons()
    End Sub

    Private Sub cbxSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSource.SelectedIndexChanged
        dynamicDotNetTwain.SelectSourceByIndex((CType(sender, ComboBox)).SelectedIndex)
    End Sub

    Private Sub picboxTitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxTitle.MouseDown
        mouse_offset2 = New Point(-e.X, -e.Y)
    End Sub

    Private Sub picboxTitle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxTitle.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Dim mousePos As Point
            mousePos = Control.MousePosition
            mousePos.Offset(mouse_offset2.X, mouse_offset2.Y)
            If (IsInForm(panelAnnotations.Parent.PointToClient(mousePos))) Then
                panelAnnotations.Location = panelAnnotations.Parent.PointToClient(mousePos)
            End If
        End If
    End Sub

    Private Function IsInForm(ByVal point As Point) As Boolean
        If (point.X > 0 And point.X < 693 And point.Y > 35 And point.Y < 635) Then
            Return True
        End If
        Return False
    End Function

    Private Sub picboxDeleteAnnotationA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDeleteAnnotationA.Click
        Dim aryAnnotation As List(Of Dynamsoft.DotNet.TWAIN.Annotation.AnnotationData)
        If (dynamicDotNetTwain.GetSelectedAnnotationList(dynamicDotNetTwain.CurrentImageIndexInBuffer, aryAnnotation)) Then
            dynamicDotNetTwain.DeleteAnnotations(dynamicDotNetTwain.CurrentImageIndexInBuffer, aryAnnotation)
        End If
    End Sub

    Private Sub lbCloseAnnotations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.MouseHover
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Red
    End Sub

    Private Sub lbCloseAnnotations_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.MouseLeave
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub lbCloseAnnotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.Click
        Me.panelAnnotations.Visible = False
    End Sub

    Private Sub lbLoadImageBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLoadImageBar.Click
        Me.panelSource.Visible = False
        Me.panelSource.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("Load_Image"), System.Drawing.Image)
        Me.panelSource.Size = New System.Drawing.Size(250, 130)

        Me.cbxSource.Visible = False
        Me.cbxResolution.Visible = False
        Me.picboxScan.Visible = False
        Me.lbSelectSource.Visible = False
        Me.lbResolution.Visible = False
        Me.chkShowUI.Visible = False
        Me.chkDuplex.Visible = False
        Me.chkADF.Visible = False

        Me.lbLoadImageInfo.Visible = True
        Me.picboxLoadImage.Visible = True

        Me.panelSource.Visible = True
    End Sub

    Private Sub lbTWAINSourceBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTWAINSourceBar.Click
        Me.panelSource.Visible = False
        Me.panelSource.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("TWAIN_Source"), System.Drawing.Image)
        Me.panelSource.Size = New System.Drawing.Size(250, 265)

        Me.lbLoadImageInfo.Visible = False
        Me.picboxLoadImage.Visible = False

        Me.cbxSource.Visible = True
        Me.cbxResolution.Visible = True
        Me.picboxScan.Visible = True
        Me.lbSelectSource.Visible = True
        Me.lbResolution.Visible = True
        Me.chkShowUI.Visible = True
        Me.chkDuplex.Visible = True
        Me.chkADF.Visible = True

        Me.panelSource.Visible = True
    End Sub
End Class

