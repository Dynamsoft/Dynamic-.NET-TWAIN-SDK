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
using System.IO;
using System.Runtime.InteropServices;

namespace CustomCapabilityDemo
{
    public partial class Form1 : Form,IAcquireCallback
    {
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        public Form1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            m_TwainManager = new TwainManager(m_StrProductKey);
            dsViewer1.Bind(m_ImageCore);
        }

        private void btnSetCapability_Click(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            for (int i = 0; i <= m_TwainManager.SourceCount - 1; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems(Convert.ToInt16(i)));
            }
            SourceListWrapper tempSourceListWrapper = new SourceListWrapper(tempList);
            int iSelectIndex = tempSourceListWrapper.SelectSource();
            if (iSelectIndex == -1)
            {
                return;
            }
            else
            {
                m_TwainManager.SelectSourceByIndex(iSelectIndex);
                m_TwainManager.OpenSource();

                m_TwainManager.Capability = (Dynamsoft.TWAIN.Enums.TWCapability)0x8001;
                m_TwainManager.CapType = Dynamsoft.TWAIN.Enums.TWCapType.TWON_ONEVALUE;
                m_TwainManager.CapValue = 1;
                bool bRet = m_TwainManager.CapSet();
                double dblValue = m_TwainManager.CapValue;
                if (bRet)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            for (int i = 0; i <= m_TwainManager.SourceCount - 1; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems(Convert.ToInt16(i)));
            }
            SourceListWrapper tempSourceListWrapper = new SourceListWrapper(tempList);
            int iSelectIndex = tempSourceListWrapper.SelectSource();
            if (iSelectIndex == -1)
            {
                return;
            }
            else
            {
                m_TwainManager.SelectSourceByIndex(iSelectIndex);
                m_TwainManager.OpenSource();

                m_TwainManager.Capability = (Dynamsoft.TWAIN.Enums.TWCapability)0x8002;
                m_TwainManager.CapType = Dynamsoft.TWAIN.Enums.TWCapType.TWON_ONEVALUE;
                m_TwainManager.CapValue = 1;
                bool bRet = m_TwainManager.CapSet();
                double dblValue = m_TwainManager.CapValue;
                if (bRet)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            m_TwainManager.IfDisableSourceAfterAcquire = true;
            m_TwainManager.IfShowUI = true;
            m_TwainManager.AcquireImage(this as IAcquireCallback);
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
