Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(GetType(Form), "wfc.ico")
        Me.DynamicDotNetTwain1.IfThrowException = False
        Me.cmbPDFResolution.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbPDFResolution.Items.Add("100")
        Me.cmbPDFResolution.Items.Add("150")
        Me.cmbPDFResolution.Items.Add("200")
        Me.cmbPDFResolution.Items.Add("300")
        Me.cmbPDFResolution.SelectedIndex = 0

        Me.rdbBMP.Checked = True

        Dim strDllPath As String
        Dim m_strCurrentDirectory As String
        m_strCurrentDirectory = Application.ExecutablePath
        Dim pos As Integer
        pos = m_strCurrentDirectory.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
            strDllPath = m_strCurrentDirectory + "Redistributable\PDFResources\"
        Else
            pos = m_strCurrentDirectory.LastIndexOf("\bin\")
            m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
            strDllPath = m_strCurrentDirectory + "Redistributable\PDFResources\"
        End If
        Me.DynamicDotNetTwain1.PDFRasterizerDllPath = strDllPath
        Me.DynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = True
    End Sub

    Private Sub btnLoadPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPDF.Click
        Dim openfiledlg As New OpenFileDialog
        Try
            openfiledlg.Filter = "PDF|*.PDF"
            openfiledlg.FilterIndex = 0
            openfiledlg.Multiselect = True

            Dim strfilename As String
            If (openfiledlg.ShowDialog() = DialogResult.OK) Then
                For Each strfilename In openfiledlg.FileNames
                    Me.DynamicDotNetTwain1.ConvertPDFToImage(strfilename, CInt(cmbPDFResolution.SelectedItem.ToString()))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try      
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (Me.DynamicDotNetTwain1.HowManyImagesInBuffer > 0) Then
                Me.LabMsg.Text = ""
                Dim dlgFileSave As New SaveFileDialog
                Dim strFile As String 'The file name use to save the acquired image

                If (rdbBMP.Checked = True) Then
                    dlgFileSave.Filter = "BMP File (*.bmp)|*.bmp"
                ElseIf (rdbJPEG.Checked = True) Then
                    dlgFileSave.Filter = "JPEG File (*.jpg)|*.jpg"
                ElseIf (rdbPNG.Checked = True) Then
                    dlgFileSave.Filter = "PNG File (*.png)|*.png"
                ElseIf (rdbTIFF.Checked = True) Then
                    dlgFileSave.Filter = "TIFF File (*.tif)|*.tif"
                Else
                    dlgFileSave.Filter = "PDF File (*.pdf)|*.pdf"
                End If

                dlgFileSave.InitialDirectory = CurDir()
                dlgFileSave.FileName = ""
                If (dlgFileSave.ShowDialog() = DialogResult.OK) Then
                    strFile = dlgFileSave.FileName
                    If (rdbBMP.Checked = True) Then
                        DynamicDotNetTwain1.SaveAsBMP(strFile, DynamicDotNetTwain1.CurrentImageIndexInBuffer)

                    ElseIf (rdbJPEG.Checked = True) Then
                        DynamicDotNetTwain1.SaveAsJPEG(strFile, DynamicDotNetTwain1.CurrentImageIndexInBuffer)

                    ElseIf (rdbPNG.Checked = True) Then
                        DynamicDotNetTwain1.SaveAsPNG(strFile, DynamicDotNetTwain1.CurrentImageIndexInBuffer)

                    ElseIf (rdbTIFF.Checked = True) Then
                        If (chbMultiPageTIFF.CheckState = 1) Then
                            DynamicDotNetTwain1.SaveAllAsMultiPageTIFF(strFile)
                        Else
                            DynamicDotNetTwain1.SaveAsTIFF(strFile, DynamicDotNetTwain1.CurrentImageIndexInBuffer)
                        End If
                    Else
                        If (chbMultiPagePDF.CheckState = 1) Then
                            DynamicDotNetTwain1.SaveAllAsPDF(strFile)
                        Else
                            DynamicDotNetTwain1.SaveAsPDF(strFile, DynamicDotNetTwain1.CurrentImageIndexInBuffer)
                        End If
                    End If
                End If
            Else
                Me.LabMsg.ForeColor = Color.Red
                Me.LabMsg.Text = "Please load a PDF file first"
                Me.LabMsg.Location = New Point(Me.GroupBox2.Size.Width / 2 - Me.LabMsg.Size.Width / 2, Me.LabMsg.Location.Y)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try  
    End Sub

    Private Sub rdbBMP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBMP.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbJPEG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbJPEG.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbPNG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPNG.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub

    Private Sub rdbTIFF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTIFF.CheckedChanged
        chbMultiPagePDF.Checked = False
        chbMultiPagePDF.Enabled = False
        chbMultiPageTIFF.Checked = True
        chbMultiPageTIFF.Enabled = True
    End Sub

    Private Sub rdbPDF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPDF.CheckedChanged
        chbMultiPagePDF.Checked = True
        chbMultiPagePDF.Enabled = True
        chbMultiPageTIFF.Checked = False
        chbMultiPageTIFF.Enabled = False
    End Sub
End Class
