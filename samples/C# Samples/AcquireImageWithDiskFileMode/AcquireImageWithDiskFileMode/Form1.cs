using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.TWAIN;
using Dynamsoft.Core;
using Dynamsoft.TWAIN.Enums;
using Dynamsoft.TWAIN.Interface;
using System.Runtime.InteropServices;
using System.IO;

namespace AcquireImageWithDiskFileMode
{
    public partial class Form1 : Form,IAcquireCallback
    {
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        private string strFileName;
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        public Form1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            m_TwainManager = new TwainManager(m_StrProductKey);
            dsViewer1.Bind(m_ImageCore);
        }

        private void btnSelectSource_Click(object sender, System.EventArgs e)
        {
            List<string> tempList = new List<string>();
            for (int i = 0; i < m_TwainManager.SourceCount; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems((short)i));
            }
            SourceListForm temp = new SourceListForm(tempList);
            temp.ShowDialog();
            int iSelectSource = temp.GetSelectedIndex();
            m_TwainManager.SelectSourceByIndex((short)iSelectSource);
        }

        private void btnAcquire_Click(object sender, System.EventArgs e)
        {
            if (dlgFileSave.ShowDialog() == DialogResult.Cancel)
                return;

            strFileName = dlgFileSave.FileName;

            m_TwainManager.OpenSource();

            try
            {
                m_TwainManager.TransferMode = Dynamsoft.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE;
            }
            catch (Exception exp)
            {
                MessageBox.Show("The license for TWAIN module is invalid.Please contact support@dynamsoft.com to get a trial license.");
                return;
            }


            //Since the TWSX_FILE mode is not required by TWAIN specification,
            //it is better to read the value back to see if the File transfer mode is supported by the Source
            if (m_TwainManager.TransferMode == Dynamsoft.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE)
            {        //the source supports the TWSX_FILE transfer mode.
                m_TwainManager.SetFileXFERInfo(strFileName, Dynamsoft.TWAIN.Enums.TWICapFileFormat.TWFF_BMP);       //Sets file name and file format information.
                m_TwainManager.IfShowUI = false;
                m_TwainManager.IfDisableSourceAfterAcquire = true;
                m_TwainManager.EnableSource(this as IAcquireCallback);     //Acquire the image.
            }
            else                       //the source doesn't support the TWSX_FILE transfer mode.
                MessageBox.Show("The source doesn't support the DiskFile transfer mode.");


        }

        public void OnPostAllTransfers()
        {
            m_ImageCore.IO.LoadImage(strFileName);
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_TwainManager.Dispose();
        }
    }
}
