Imports Dynamsoft.DotNet.TWAIN.Annotation
Imports Dynamsoft.DotNet.TWAIN.Enums



Public Class Form1
    Dim aryAnnotation As List(Of AnnotationData)


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        toolStripCbxPen.SelectedIndex = 0
        toolStripCbxFont.SelectedIndex = 0

        DynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumPointer
        DynamicDotNetTwain1.MaxImagesInBuffer = 1000
        DynamicDotNetTwain1.SetViewMode(1, 1)

        Dim imagePath As String
        imagePath = Application.ExecutablePath
        Dim pos As Integer
        pos = imagePath.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            imagePath = imagePath.Substring(0, imagePath.IndexOf("\", pos)) + "\Samples\Bin\Images\AnnotationImage\Annotation Sample Image.png"
        End If
        DynamicDotNetTwain1.LoadImage(imagePath)

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim filedlg As New OpenFileDialog
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF"
        Dim strFilename As String
        filedlg.Multiselect = True
        If (filedlg.ShowDialog() = DialogResult.OK) Then
            For Each strFilename In filedlg.FileNames

                DynamicDotNetTwain1.LoadImage(strFilename)

            Next
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        DynamicDotNetTwain1.IfSaveAnnotations = True
        Dim filedlg As New SaveFileDialog
        filedlg.Filter = "PDF File(*.pdf) | *.pdf"
        If (filedlg.ShowDialog() = DialogResult.OK) Then

            DynamicDotNetTwain1.SaveAsMultiPagePDF(filedlg.FileName, DynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer)


        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Me.DynamicDotNetTwain1.IfShowPrintUI = True
        DynamicDotNetTwain1.Print()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub LineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineToolStripMenuItem.Click
        Dim LAnnotation As New LineAnnotationData
        LAnnotation.StartPoint = New Point(200, 200)
        LAnnotation.EndPoint = New Point(260, 280)
        LAnnotation.PenColor = Color.Black
        LAnnotation.PenWidth = 5
        LAnnotation.Description = "Create a line annotation."
        DynamicDotNetTwain1.CreateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, LAnnotation)
    End Sub

    Private Sub EllipseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EllipseToolStripMenuItem.Click
        Dim EAnnotation As New EllipseAnnotationData
        EAnnotation.AnnotationLocation = New Point(300, 300)
        EAnnotation.AnnotationSize = New Size(80, 140)
        EAnnotation.FillColor = Color.Blue
        EAnnotation.PenColor = Color.Black
        EAnnotation.PenWidth = 2
        EAnnotation.Description = "Create an ellipse annotation."
        DynamicDotNetTwain1.CreateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, EAnnotation)
    End Sub

    Private Sub RectangleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleToolStripMenuItem.Click
        Dim RAnnotation As New RectangleAnnotationData
        RAnnotation.AnnotationLocation = New Point(400, 400)
        RAnnotation.AnnotationSize = New Size(90, 120)
        RAnnotation.FillColor = Color.Green
        RAnnotation.PenColor = Color.Black
        RAnnotation.PenWidth = 2
        RAnnotation.Description = "Create a rectangle annotation."
        DynamicDotNetTwain1.CreateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, RAnnotation)
    End Sub

    Private Sub TextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextToolStripMenuItem.Click
        Dim TAnnotation As New TextAnnotationData
        TAnnotation.AnnotationLocation = New Point(80, 80)
        TAnnotation.AnnotationSize = New Size(200, 200)
        TAnnotation.TextFont = New Font("", 20)
        TAnnotation.TextContent = "Dynamsoft"
        TAnnotation.TextColor = Color.Brown
        TAnnotation.Description = "Create a text annotation"
        DynamicDotNetTwain1.CreateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, TAnnotation)
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        Dim aryAnnotation As New List(Of AnnotationData)
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        DynamicDotNetTwain1.DeleteAnnotations(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        UpdateAnnotationProperty()
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        Dim aryAnnotation As New List(Of AnnotationData)
        DynamicDotNetTwain1.GetAllAnnotationDataList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        DynamicDotNetTwain1.DeleteAnnotations(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        UpdateAnnotationProperty()
    End Sub

    Private Sub CopySelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopySelectedToolStripMenuItem.Click
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        DynamicDotNetTwain1.LoadAnnotationDataList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
    End Sub

    Private Sub BringToFrontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontToolStripMenuItem.Click
        Dim aryAnnotation As New List(Of AnnotationData)
        Dim objAnnotation As New AnnotationData
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        If (aryAnnotation.Count > 0) Then
            objAnnotation = aryAnnotation(0)
            DynamicDotNetTwain1.ChangeAnnotationPosition(DynamicDotNetTwain1.CurrentImageIndexInBuffer, objAnnotation, DWTAnnotationChangePosition.enumToFront)
        End If

    End Sub

    Private Sub SendToBackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
        Dim aryAnnotation As New List(Of AnnotationData)
        Dim objAnnotation As New AnnotationData
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        If (aryAnnotation.Count > 0) Then
            objAnnotation = aryAnnotation(0)
            DynamicDotNetTwain1.ChangeAnnotationPosition(DynamicDotNetTwain1.CurrentImageIndexInBuffer, objAnnotation, DWTAnnotationChangePosition.enumMoveToBack)
        End If
    End Sub

  
    Private Sub ToolStripBtnLAnnotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnLAnnotation.Click
        DynamicDotNetTwain1.AnnotationPen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        DynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumLine
    End Sub

    Private Sub ToolStripBtnEAnnotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnEAnnotation.Click
        DynamicDotNetTwain1.AnnotationPen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        DynamicDotNetTwain1.AnnotationFillColor = toolStripBtnFill.BackColor
        DynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumEllipse

    End Sub

    Private Sub ToolStripBtnRAnnotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnRAnnotation.Click
        DynamicDotNetTwain1.AnnotationPen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        DynamicDotNetTwain1.AnnotationFillColor = toolStripBtnFill.BackColor
        DynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumRectangle

    End Sub

    Private Sub ToolStripBtnTAnnotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnTAnnotation.Click
        DynamicDotNetTwain1.AnnotationTextColor = toolStripBtnFont.BackColor
        DynamicDotNetTwain1.AnnotationTextFont = New Font("", Decimal.Parse(toolStripCbxFont.Text))
        DynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumText
    End Sub

    Private Sub UpdateAnnotationProperty()
        Dim aryAnnotation As New List(Of AnnotationData)
        Dim objAnnotation As New AnnotationData
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        If (aryAnnotation.Count > 0) Then

            objAnnotation = aryAnnotation(0)
            Me.PropertyGrid1.SelectedObject = objAnnotation

        Else
            Me.PropertyGrid1.SelectedObject = Nothing

        End If

    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationCreated() Handles DynamicDotNetTwain1.OnAnnotationCreated
        UpdateAnnotationProperty()
    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationDeselected() Handles DynamicDotNetTwain1.OnAnnotationDeselected

        Me.PropertyGrid1.SelectedObject = Nothing


    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationMoved() Handles DynamicDotNetTwain1.OnAnnotationMoved
        UpdateAnnotationProperty()
    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationResized() Handles DynamicDotNetTwain1.OnAnnotationResized
        UpdateAnnotationProperty()
    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationSelected() Handles DynamicDotNetTwain1.OnAnnotationSelected
        UpdateAnnotationProperty()
    End Sub

    Private Sub DynamicDotNetTwain1_OnAnnotationTextChanged() Handles DynamicDotNetTwain1.OnAnnotationTextChanged
        UpdateAnnotationProperty()
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        Dim aryAnnotation As New List(Of AnnotationData)
        Dim oldAnnotation As New AnnotationData
        Dim newAnnotation As New AnnotationData
        Dim sImageIndex As Short
        sImageIndex = DynamicDotNetTwain1.CurrentImageIndexInBuffer
        DynamicDotNetTwain1.GetSelectedAnnotationList(sImageIndex, aryAnnotation)
        If (aryAnnotation.Count > 0) Then

            oldAnnotation = aryAnnotation(0)
            newAnnotation = Me.PropertyGrid1.SelectedObject
            DynamicDotNetTwain1.UpdateAnnotation(sImageIndex, oldAnnotation, newAnnotation)

        End If

    End Sub

    Private Sub DynamicDotNetTwain1_OnTopImageInTheViewChanged(ByVal sImageIndex As System.Int16) Handles DynamicDotNetTwain1.OnTopImageInTheViewChanged
        DynamicDotNetTwain1.CurrentImageIndexInBuffer = sImageIndex
        UpdateAnnotationProperty()

    End Sub

    Private Sub toolStripBtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnFill.Click
        Dim color As Color
        color = SelectColor()
        If color <> color.Transparent Then
            toolStripBtnFill.BackColor = color
            Dim aryAnnotation As New List(Of AnnotationData)
            DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
            Dim annotation As AnnotationData
            For Each annotation In aryAnnotation
                Dim type As DWTAnnotationType
                type = annotation.GetAnnotationType()
                If (type = DWTAnnotationType.enumRectangle) Then
                    Dim oldAnnotation As RectangleAnnotationData
                    oldAnnotation = annotation
                    Dim newAnnotation As RectangleAnnotationData
                    newAnnotation = New RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, color, oldAnnotation.PenColor, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                    DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)

                ElseIf (type = DWTAnnotationType.enumEllipse) Then
                    Dim oldAnnotation As EllipseAnnotationData
                    oldAnnotation = annotation
                    Dim newAnnotation As EllipseAnnotationData
                    newAnnotation = New EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, color, oldAnnotation.PenColor, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                    DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)

                End If
            Next
        End If
    End Sub

    Private Function SelectColor() As Color
        If dlgColor.ShowDialog() = DialogResult.OK Then
            SelectColor = (dlgColor.Color)
            Return SelectColor
        End If
        SelectColor = Color.Transparent
    End Function

    Private Sub toolStripBtnPen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnPen.Click
        Dim color As Color
        color = SelectColor()
        If color <> color.Transparent Then
            toolStripBtnPen.BackColor = color
            Dim aryAnnotation As New List(Of AnnotationData)
            DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
            Dim annotation As AnnotationData
            For Each annotation In aryAnnotation
                Dim type As DWTAnnotationType
                type = annotation.GetAnnotationType()
                If (type = DWTAnnotationType.enumRectangle) Then
                    Dim oldAnnotation As RectangleAnnotationData
                    oldAnnotation = annotation
                    Dim newAnnotation As RectangleAnnotationData
                    newAnnotation = New RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,oldAnnotation.FillColor, color, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                    DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
                ElseIf (type = DWTAnnotationType.enumEllipse) Then
                    Dim oldAnnotation As EllipseAnnotationData
                    oldAnnotation = annotation
                    Dim newAnnotation As EllipseAnnotationData
                    newAnnotation = New EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, oldAnnotation.FillColor, color, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                    DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)

                End If
            Next
        End If
    End Sub

    Private Sub toolStripBtnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnFont.Click
        Dim color As Color
        color = SelectColor()
        If color <> color.Transparent Then
            toolStripBtnFont.BackColor = color
            Dim aryAnnotation As New List(Of AnnotationData)
            DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
            Dim annotation As AnnotationData
            For Each annotation In aryAnnotation
                Dim type As DWTAnnotationType
                type = annotation.GetAnnotationType()
                If (type = DWTAnnotationType.enumText) Then
                    Dim oldAnnotation As TextAnnotationData
                    oldAnnotation = annotation
                    Dim newAnnotation As TextAnnotationData
                    newAnnotation = New TextAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,oldAnnotation.TextFont, color, oldAnnotation.TextContent, oldAnnotation.TextRotate, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                    DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
                End If
            Next
        End If
    End Sub

    Private Sub toolStripCbxPen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripCbxPen.TextChanged
        Dim aryAnnotation As New List(Of AnnotationData)
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        Dim annotation As AnnotationData
        For Each annotation In aryAnnotation
            Dim type As DWTAnnotationType
            type = annotation.GetAnnotationType()
            If (type = DWTAnnotationType.enumRectangle) Then
                Dim oldAnnotation As RectangleAnnotationData
                oldAnnotation = annotation
                Dim newAnnotation As RectangleAnnotationData
                newAnnotation = New RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, oldAnnotation.FillColor, oldAnnotation.PenColor, Integer.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
            ElseIf (type = DWTAnnotationType.enumEllipse) Then
                Dim oldAnnotation As EllipseAnnotationData
                oldAnnotation = annotation
                Dim newAnnotation As EllipseAnnotationData
                newAnnotation = New EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, oldAnnotation.FillColor, oldAnnotation.PenColor, Integer.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
            ElseIf (type = DWTAnnotationType.enumLine) Then
                Dim oldAnnotation As LineAnnotationData
                oldAnnotation = annotation
                Dim newAnnotation As LineAnnotationData
                newAnnotation = New LineAnnotationData(oldAnnotation.StartPoint, oldAnnotation.EndPoint, oldAnnotation.PenColor, Integer.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
            End If
        Next
    End Sub

    Private Sub toolStripCbxFont_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripCbxFont.TextChanged
        Dim aryAnnotation As New List(Of AnnotationData)
        DynamicDotNetTwain1.GetSelectedAnnotationList(DynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation)
        Dim annotation As AnnotationData
        For Each annotation In aryAnnotation
            Dim type As DWTAnnotationType
            type = annotation.GetAnnotationType()
            If (type = DWTAnnotationType.enumText) Then
                Dim oldAnnotation As TextAnnotationData
                oldAnnotation = annotation
                Dim newAnnotation As TextAnnotationData
                newAnnotation = New TextAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize, New Font("", Decimal.Parse(toolStripCbxFont.Text)), oldAnnotation.TextColor, oldAnnotation.TextContent, oldAnnotation.TextRotate, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description, oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected)
                DynamicDotNetTwain1.UpdateAnnotation(DynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation)
            End If
        Next
    End Sub

    Private Sub toolStripBtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnDelete.Click
        DeleteSelectedToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub toolStripBtnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnDeleteAll.Click
        DeleteAllToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub toolStripBtnBringToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnBringToBack.Click
        SendToBackToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub toolStripBtnBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripBtnBringToFront.Click
        BringToFrontToolStripMenuItem_Click(sender, e)
    End Sub
End Class
