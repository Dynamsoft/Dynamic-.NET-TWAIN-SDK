using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomCapabilityDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.ScanInNewProcess = true;
            this.dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82";
        }

        private void btnSetCapability_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain1.SelectSource())
            {
                dynamicDotNetTwain1.OpenSource();
                //If you wish to make use of a scanner property not included in our SDK, 
                //you just need to specify its capability code. 
                //The default CAP code in this section is 0x:8001. 
                dynamicDotNetTwain1.Capability = (Dynamsoft.DotNet.TWAIN.Enums.TWCapability)0x8001;  //Custom CAP 0x:8001
                dynamicDotNetTwain1.CapType = Dynamsoft.DotNet.TWAIN.Enums.TWCapType.TWON_ONEVALUE;
                dynamicDotNetTwain1.CapValue = 0;
                bool bRet = dynamicDotNetTwain1.CapSet();
                double dblValue = dynamicDotNetTwain1.CapValue;
                if (bRet)
                    MessageBox.Show("Successful.");
                else
                    MessageBox.Show("Failed.\r\n" + dynamicDotNetTwain1.ErrorString);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain1.SelectSource())
            {
                dynamicDotNetTwain1.OpenSource();

                dynamicDotNetTwain1.Capability = (Dynamsoft.DotNet.TWAIN.Enums.TWCapability)0x8002; //Custom CAP0x:8002
                dynamicDotNetTwain1.CapType = Dynamsoft.DotNet.TWAIN.Enums.TWCapType.TWON_ONEVALUE;
                dynamicDotNetTwain1.CapValue = 1;
                bool bRet = dynamicDotNetTwain1.CapSet();
                double dblValue = dynamicDotNetTwain1.CapValue;
                if (bRet)
                    MessageBox.Show("Successful.");
                else
                    MessageBox.Show("Failed.\r\n" + dynamicDotNetTwain1.ErrorString);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.IfShowUI = true;
            dynamicDotNetTwain1.AcquireImage();
        }
    }
}
