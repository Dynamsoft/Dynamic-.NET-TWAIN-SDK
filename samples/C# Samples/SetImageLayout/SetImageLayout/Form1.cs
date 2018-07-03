using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.TWAIN;
using Dynamsoft.Core;
using Dynamsoft.TWAIN.Interface;
using System.Runtime.InteropServices;
using System.IO;
using Dynamsoft.Common;

namespace SetImageLayout
{
    public partial class Form1 : Form,IAcquireCallback
    {
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        public Form1()
        {
            InitializeComponent();
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);

            if (m_TwainManager.SourceCount > 0)
            {
                for (short i = 0; i < m_TwainManager.SourceCount; i++)
                {
                    string strSourceName = m_TwainManager.SourceNameItems(i);
                    if (strSourceName != null)
                        cbxSources.Items.Add(strSourceName);
                }
                cbxSources.SelectedIndexChanged += cbxSources_SelectedIndexChanged;
                cbxSources.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "There is no scanner detected!\n " +
    "Please ensure that at least one (virtual) scanner is installed.", "Information");
                return;
            }

        }


        private void btnSetAndAcquire_Click(object sender, System.EventArgs e)
        {
            float fFrameLeft, fFrameTop, fFrameRight, fFrameBottom, frameTemp;

            try
            {
                fFrameLeft = Convert.ToSingle(edtFrameLeft.Text);
                fFrameTop = Convert.ToSingle(edtFrameTop.Text);
                fFrameRight = Convert.ToSingle(edtFrameRight.Text);
                fFrameBottom = Convert.ToSingle(edtFrameBottom.Text);

                if (fFrameLeft > fFrameRight)
                {
                    frameTemp = fFrameLeft;
                    fFrameLeft = fFrameRight;
                    fFrameRight = frameTemp;
                }

                if (fFrameTop > fFrameBottom)
                {
                    frameTemp = fFrameTop;
                    fFrameTop = fFrameBottom;
                    fFrameBottom = frameTemp;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input numerical values in the input boxes.", "Error");
                return;
            }

            if (fFrameLeft == fFrameRight || fFrameTop == fFrameBottom)
            {
                MessageBox.Show("Input Value Error: don't make left equal to right, or top equal to bottom.", "Error");
                return;
            }
            if (fFrameLeft < fDefaultFrameLeft || fFrameTop < fDefaultFrameTop || fFrameRight > fDefaultFrameRight || fFrameBottom > fDefaultFrameBottom)
            {
                DialogResult drImageLayout = MessageBox.Show("Input values are out of rangles,do you want to continue?", "Warning", MessageBoxButtons.YesNo);
                if (drImageLayout == System.Windows.Forms.DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            if (m_TwainManager.SetImageLayout(new Margin(fFrameLeft, fFrameTop, fFrameRight, fFrameBottom)) == false)
            {
                MessageBox.Show("Fail to set image layout","Error");
            }
            else
            {
                m_TwainManager.IfShowUI = false;

                m_TwainManager.IfDisableSourceAfterAcquire = true;
                m_TwainManager.EnableSource(this as IAcquireCallback);
            }
        }

        float fDefaultFrameLeft, fDefaultFrameTop, fDefaultFrameRight, fDefaultFrameBottom;


        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < m_TwainManager.SourceCount)
            {
                m_TwainManager.SelectSourceByIndex(cbxSources.SelectedIndex);
                m_TwainManager.OpenSource();
                m_TwainManager.ResetImageLayout();
                Margin tempMargin = m_TwainManager.GetImageLayout();
                fDefaultFrameLeft = tempMargin.Left;
                fDefaultFrameTop = tempMargin.Top;
                fDefaultFrameRight = tempMargin.Right;
                fDefaultFrameBottom = tempMargin.Bottom;
                fDefaultFrameLeft = (float)((int)(fDefaultFrameLeft * 10)) / 10;
                fDefaultFrameTop = (float)((int)(fDefaultFrameTop * 10)) / 10;
                fDefaultFrameRight = (float)((int)(fDefaultFrameRight * 10)) / 10;
                fDefaultFrameBottom = (float)((int)(fDefaultFrameBottom * 10)) / 10;
                edtFrameLeft.Text = fDefaultFrameLeft.ToString();
                edtFrameTop.Text = fDefaultFrameTop.ToString();
                edtFrameRight.Text = fDefaultFrameRight.ToString();
                edtFrameBottom.Text = fDefaultFrameBottom.ToString();
                lblFrameLeft.Text = string.Format("(0 ~ " + fDefaultFrameRight.ToString() + ")");
                lblFrameTop.Text = string.Format("(0 ~ " + fDefaultFrameBottom.ToString() + ")");
                lblFrameRight.Text = string.Format("(0 ~ " + fDefaultFrameRight.ToString() + ")");
                lblFrameBottom.Text = string.Format("(0 ~ " + fDefaultFrameBottom.ToString() + ")");
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
