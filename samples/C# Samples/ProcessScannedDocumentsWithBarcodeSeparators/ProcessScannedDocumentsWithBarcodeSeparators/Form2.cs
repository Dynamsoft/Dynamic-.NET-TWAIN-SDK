using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSDWBS
{
    public partial class Form2 : Form
    {

        private string m_PDFFileName = null;
        private string m_FolderPath = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string strFolderPath, string strPDFName)
        {
            InitializeComponent();
            this.Text = "Set PDF File Name";
            m_PDFFileName =strPDFName;
            tbxPDFName.Text = m_PDFFileName+".pdf";
            m_FolderPath = strFolderPath;
        }
        private void tbxSetFileName_Click(object sender, EventArgs e)
        {
            if (tbxPDFName.Text != null)
            {
                string strNameText = null;
                strNameText = tbxPDFName.Text;
                foreach (char text in strNameText )
                {
                    foreach (char temp in System.IO.Path.GetInvalidFileNameChars())
                    {
                        if (text == temp)
                        {
                            MessageBox.Show("The name of  PDF file contains  illegal character!", "Error");
                            return;
                        }

                    }
                }
                string FilePath = m_FolderPath + "\\" + strNameText ;
                if (System.IO.File.Exists(FilePath))
                {
                    MessageBox.Show("The name of PDF file has exists!","Warning");
                    return;
                }
                m_PDFFileName = tbxPDFName.Text;
            }
            else
            {
                MessageBox.Show(" The name of PDF file can not be null!","Warning");
                return;
            }
            this.Close();
        }
        public string GetPDfFileName()
        {
            return m_PDFFileName;
        }
    }
}
