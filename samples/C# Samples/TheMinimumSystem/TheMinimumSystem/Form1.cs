using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.TWAIN;
using Dynamsoft.Forms;
using Dynamsoft.Core;
using Dynamsoft.TWAIN.Interface;
using System.IO;
using System.Runtime.InteropServices;

namespace TheMinimumSystem
{
    public partial class Form1 : Form,IAcquireCallback
    {
        string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        public Form1()
        {
            InitializeComponent();
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
        }


        private void Acquire_Click(object sender, EventArgs e)
        {

            List<string> tempList = new List<string>();
            for (int i = 0; i < m_TwainManager.SourceCount; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems((short)i));
            }
            SourceListWrapper tempSourceListWrapper = new SourceListWrapper(tempList);

            int iSelectIndex = tempSourceListWrapper.SelectSource(); 
            if (iSelectIndex == -1)
            {
                return;
            }
            else
            {
                m_TwainManager.IfDisableSourceAfterAcquire = true;
                m_TwainManager.IfShowUI = true;
                m_TwainManager.SelectSourceByIndex((short)iSelectIndex);
                m_TwainManager.AcquireImage(this as IAcquireCallback);
            }
        }

        public void OnPostAllTransfers()
        {
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            m_ImageCore.IO.LoadImage(bit);
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
