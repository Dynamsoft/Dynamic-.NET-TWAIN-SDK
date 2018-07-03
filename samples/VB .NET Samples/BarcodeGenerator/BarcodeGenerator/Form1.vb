Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.Core
Imports Dynamsoft.Barcode
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums
Imports System.Runtime.InteropServices
Imports System.IO


Partial Public Class Form1
    Inherits Form
    Implements ISave
    Implements IConvertCallback
    Private m_StrProductKey As String
    Private m_ImageCore As ImageCore = Nothing
    Private barcodeformat As Dynamsoft.Barcode.Enums.EnumBarcodeFormat
    Private m_Generator As Dynamsoft.Barcode.BarcodeGenerator = Nothing
    Private m_PDFCreator As PDFCreator = Nothing
    Private m_PDFRasterizer As PDFRasterizer = Nothing
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)

        Initialization()
        m_Generator = New Dynamsoft.Barcode.BarcodeGenerator(m_StrProductKey)
        m_PDFCreator = New PDFCreator(m_StrProductKey)
        m_PDFRasterizer = New PDFRasterizer(m_StrProductKey)
    End Sub





    Protected Sub Initialization()
        Me.Icon = New Icon(GetType(Form), "wfc.ico")
        Me.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbBarcodeFormat.Items.Add("CODE_39")
        Me.cmbBarcodeFormat.Items.Add("CODE_128")
        Me.cmbBarcodeFormat.Items.Add("PDF417")
        Me.cmbBarcodeFormat.Items.Add("QR_CODE")
        Me.cmbBarcodeFormat.SelectedIndex = 0

        Me.rdbBMP.Checked = True

        Me.txtBarcodeContent.Text = "Dynamsoft"
        Me.txtBarcodeLocationX.Text = "0"
        Me.txtBarocdeLocationY.Text = "0"
        Me.txtHumanReadableTxt.Text = "Dynamsoft"
        Me.txtBarcodeScale.Text = "1"


    End Sub

    Private Sub btnLoadImage_Click(sender As Object, e As EventArgs) Handles btnLoadImage.Click
        Try
            Dim openfdlg As New OpenFileDialog()
            openfdlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
            openfdlg.FilterIndex = 0
            openfdlg.Multiselect = True

            If openfdlg.ShowDialog() = DialogResult.OK Then
                For Each strfilename As String In openfdlg.FileNames
                    Dim pos As Integer = strfilename.LastIndexOf(".")
                    If pos <> -1 Then
                        Dim strSuffix As String = strfilename.Substring(pos, strfilename.Length - pos).ToLower()
                        If strSuffix.CompareTo(".pdf") = 0 Then
                            m_PDFRasterizer.ConvertToImage(strfilename, "", 200, TryCast(Me, IConvertCallback))
                        End If
                    End If
                    m_ImageCore.IO.LoadImage(strfilename)
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub btnAddBarcode_Click(sender As Object, e As EventArgs) Handles btnAddBarcode.Click
        Try
            If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
                Me.labMsg.Text = ""
                Me.labmsg2.Text = ""

                If txtBarcodeContent.Text <> "" AndAlso txtBarcodeLocationX.Text <> "" AndAlso txtBarocdeLocationY.Text <> "" AndAlso txtBarcodeScale.Text <> "" Then
                    Dim temp As Bitmap = m_Generator.AddBarcode(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), barcodeformat, txtBarcodeContent.Text, txtHumanReadableTxt.Text, Integer.Parse(txtBarcodeLocationX.Text), Integer.Parse(txtBarocdeLocationY.Text),
                            Single.Parse(txtBarcodeScale.Text))
                    m_ImageCore.ImageBuffer.SetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, temp)
                Else
                    If txtBarcodeContent.Text = "" Then
                        txtBarcodeContent.Focus()
                        Me.labMsg.ForeColor = Color.Red
                        Me.labMsg.Text = "BarcodeContent can not be empty"
                        Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
                    ElseIf txtBarcodeLocationX.Text = "" Then
                        txtBarcodeLocationX.Focus()
                        Me.labMsg.ForeColor = Color.Red
                        Me.labMsg.Text = "BarcodeLocationX can not be empty"
                        Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
                    ElseIf txtBarocdeLocationY.Text = "" Then
                        txtBarocdeLocationY.Focus()
                        Me.labMsg.ForeColor = Color.Red
                        Me.labMsg.Text = "BarcodeLocationY can not be empty"
                        Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
                    ElseIf txtBarcodeScale.Text = "" Then
                        txtBarcodeScale.Focus()
                        Me.labMsg.ForeColor = Color.Red
                        Me.labMsg.Text = "BarcodeScale can not be empty"
                        Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
                    End If
                End If
            Else
                Me.labMsg.ForeColor = Color.Red
                Me.labMsg.Text = "Please load an image first"
                Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
            End If
        Catch
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
                Me.labMsg.Text = ""
                Me.labmsg2.Text = ""
                Dim savefdlg As New SaveFileDialog()
                savefdlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory()
                savefdlg.FileName = ""

                If rdbBMP.Checked = True Then

                    savefdlg.Filter = "BMP File(*.bmp)| *.bmp"
                End If

                If rdbJPEG.Checked = True Then

                    savefdlg.Filter = "JPEG File(*.jpeg)| *.jpeg"
                End If

                If rdbPNG.Checked = True Then

                    savefdlg.Filter = "PNG File(*.png) | *.png"
                End If

                If rdbTIFF.Checked = True Then

                    savefdlg.Filter = "TIFF File(*.tiff)| *.tiff"
                End If

                If rdbPDF.Checked = True Then

                    savefdlg.Filter = "PDF File(*.pdf)| *.pdf"
                End If

                If savefdlg.ShowDialog() = DialogResult.OK Then

                    Dim strFilename As String = savefdlg.FileName

                    If rdbBMP.Checked = True Then
                        m_ImageCore.IO.SaveAsBMP(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If

                    If rdbJPEG.Checked = True Then
                        m_ImageCore.IO.SaveAsJPEG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If

                    If rdbPNG.Checked = True Then
                        m_ImageCore.IO.SaveAsPNG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If

                    If rdbTIFF.Checked = True Then
                        Dim tempListIndex As New List(Of Short)()
                        If chbMultiPageTIFF.Checked = True Then
                            For sIndex As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                                tempListIndex.Add(sIndex)
                            Next
                        Else
                            tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If

                        m_ImageCore.IO.SaveAsTIFF(strFilename, tempListIndex)
                    End If

                    If rdbPDF.Checked = True Then
                        m_PDFCreator.Save(TryCast(Me, ISave), strFilename)
                    End If
                End If
            Else
                Me.labmsg2.ForeColor = Color.Red
                Me.labmsg2.Text = "Please load an image first"
                Me.labmsg2.Location = New Point(Me.groupBox4.Size.Width \ 2 - Me.labmsg2.Size.Width \ 2, Me.labmsg2.Location.Y)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnCreateBarcode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateBarcode.Click
        Try
            Me.labMsg.Text = ""
            Me.labmsg2.Text = ""

            If txtBarcodeContent.Text <> "" AndAlso txtBarcodeScale.Text <> "" Then
                Dim barcodeBit As Bitmap = m_Generator.CreateBarcode(barcodeformat, txtBarcodeContent.Text, txtHumanReadableTxt.Text, Single.Parse(txtBarcodeScale.Text))
                m_ImageCore.IO.LoadImage(barcodeBit)
            Else

                If txtBarcodeContent.Text = "" Then
                    txtBarcodeContent.Focus()
                    Me.labMsg.ForeColor = Color.Red
                    Me.labMsg.Text = "BarcodeContent can not be empty"
                    Me.labMsg.Location = New Point(Me.groupBox2.Size.Width / 2 - Me.labMsg.Size.Width / 2, Me.labMsg.Location.Y)
                ElseIf txtBarcodeScale.Text = "" Then
                    txtBarcodeScale.Focus()
                    Me.labMsg.ForeColor = Color.Red
                    Me.labMsg.Text = "BarcodeScale can not be empty"
                    Me.labMsg.Location = New Point(Me.groupBox2.Size.Width / 2 - Me.labMsg.Size.Width / 2, Me.labMsg.Location.Y)
                End If
            End If

        Catch
        End Try
    End Sub
    Private Sub rdbBMP_CheckedChanged(sender As Object, e As EventArgs) Handles rdbBMP.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbJPEG_CheckedChanged(sender As Object, e As EventArgs) Handles rdbJPEG.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbPNG_CheckedChanged(sender As Object, e As EventArgs) Handles  rdbPNG.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbTIFF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTIFF.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = True
        chbMultiPageTIFF.Enabled = True
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        chbMultiPagePDF.Checked = True
        chbMultiPagePDF.Enabled = True
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub cmbBarcodeFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBarcodeFormat.SelectedIndexChanged
        Select Case cmbBarcodeFormat.SelectedIndex
            Case 0
                barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_39
                Exit Select
            Case 1
                barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_128
                Exit Select
            Case 2
                barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.PDF417
                Exit Select
            Case 3
                barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.QR_CODE
                Exit Select
        End Select
    End Sub

    Private Sub txtBarcodeLocationX_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeLocationX.KeyPress
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtBarocdeLocationY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarocdeLocationY.KeyPress
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtBarcodeScale_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcodeScale.KeyPress
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back OrElse e.KeyChar = "."c Then
            e.Handled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)


    End Sub


#Region "ISave Members"

    Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
        If chbMultiPagePDF.Checked Then
            Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
        Else
            Return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation)
        End If
    End Function

    Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
        If chbMultiPagePDF.Checked Then
            Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
        Else
            Return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Function

    Public Function GetPageCount() As Integer Implements ISave.GetPageCount
        If chbMultiPagePDF.Checked Then
            Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        Else
            Return 1
        End If
    End Function

#End Region

#Region "IConvertCallback Members"

    Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
        m_ImageCore.IO.LoadImage(result.Image)
        If result.Annotations IsNot Nothing Then
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
        End If
    End Sub
#End Region
End Class
