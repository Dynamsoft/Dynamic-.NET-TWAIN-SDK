using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScanAndUploadToDB
{
    public partial class SuccessInfo : Form
    {
        private string m_strImageName = "DNT_Image.jpg";
        public SuccessInfo(string strImageName)
        {
            if (strImageName != "")
                m_strImageName = strImageName;
            InitializeComponent();
        }

        private void SuccessInfo_Load(object sender, EventArgs e)
        {
            if (m_strImageName.Length > 15)
                this.lblInfo.Text = m_strImageName.Substring(0, 5) + "..." + m_strImageName.Substring(m_strImageName.Length -7, 7) + " successfully uploaded to www.dynamsoft.com. It can be accessed at ";
            else
                this.lblInfo.Text = m_strImageName + " successfully uploaded to www.dynamsoft.com. It can be accessed at ";
            this.lblLink.Text = "http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx");
        }
    }
}
