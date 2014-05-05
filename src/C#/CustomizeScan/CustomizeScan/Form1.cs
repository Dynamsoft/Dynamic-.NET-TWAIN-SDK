using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomizeScan
{
    public partial class frmCustomizeScan : Form
    {
        bool bNotSupportDuplex = false;
        public frmCustomizeScan()
        {
            InitializeComponent();
            int lngNum;
            dynamicDotNetTwain.OpenSourceManager();
            for (lngNum = 0; lngNum < dynamicDotNetTwain.SourceCount; lngNum++)
            {     
               cmbSource.Items.Add(dynamicDotNetTwain.SourceNameItems(Convert.ToInt16(lngNum)));
            }
            if (lngNum > 0)
                cmbSource.SelectedIndex = 0;

            cmbResolution.Items.Insert(0,"100");
            cmbResolution.Items.Insert(1,"150");
            cmbResolution.Items.Insert(2, "200");
            cmbResolution.Items.Insert(3, "300");
            cmbResolution.SelectedIndex = 0;

            optGray.Checked = true;
            dynamicDotNetTwain.IfThrowException = true;

            IfInsertEnable();

            CreateContextMenu();
        }

        private void IfInsertEnable()
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer == 0)
            {
                cmdInsert.Enabled = false;
            }
            else
            {
                cmdInsert.Enabled = true;
            }
        }

        private void cmdScan_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfAppendImage = true;
		    AcquireImage();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfAppendImage = false;
		    AcquireImage();
        }

        private void AcquireImage()
        {
            try
            {
                dynamicDotNetTwain.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex));
                dynamicDotNetTwain.IfShowUI = chkIfShowUI.Checked;
                dynamicDotNetTwain.OpenSource();
                dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;
                if (optBW.Checked == true)
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW;
                    dynamicDotNetTwain.BitDepth = 1;
                }
                else if (optGray.Checked == true)
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                    dynamicDotNetTwain.BitDepth = 8;
                }
                else
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                    dynamicDotNetTwain.BitDepth = 24;
                }

                if (cmbResolution.SelectedIndex == 0)
                {
                    dynamicDotNetTwain.Resolution = 100;
                }
                else if (cmbResolution.SelectedIndex == 1)
                {
                    dynamicDotNetTwain.Resolution = 150;
                }
                else if (cmbResolution.SelectedIndex == 2)
                {
                    dynamicDotNetTwain.Resolution = 200;
                }
                else
                {
                    dynamicDotNetTwain.Resolution = 300;
                }

                if (dynamicDotNetTwain.Resolution != int.Parse(cmbResolution.Text))
                {
                    string errorstr = "Fail to set resolution.";
                    errorstr += "\r\n";
                    errorstr += "Current source does not support the resolution you set.";
                    errorstr += "\r\n";
                    txtErrorString.Text = errorstr + txtErrorString.Text;
                }

                dynamicDotNetTwain.IfShowUI = chkIfShowUI.Checked;
                dynamicDotNetTwain.IfFeederEnabled = chkIfUseADF.Checked;
                dynamicDotNetTwain.IfAutoFeed = chkIfUseADF.Checked;
                if (bNotSupportDuplex == false)
                {
                    dynamicDotNetTwain.IfDuplexEnabled = chkDuplex.Checked;
                    if ((dynamicDotNetTwain.Duplex == 0) && (chkDuplex.Checked == true))
                    {
                        string errorstr = "Current source does not support duplex scan.";
                        errorstr += "\r\n";
                        txtErrorString.Text = errorstr + txtErrorString.Text;
                        chkDuplex.Checked = false;
                    }
                }

                dynamicDotNetTwain.AcquireImage();
            }
            catch (Dynamsoft.DotNet.TWAIN.TwainException exp)
            {
                String errorstr = "";
                errorstr += "Error " + exp.Code + "\r\n" + "Description: " + exp.Message + "\r\nPosition: " + exp.TargetSite + "\r\nHelp: " + exp.HelpLink + "\r\n";
                txtErrorString.Text = errorstr + txtErrorString.Text;
            }
            catch (Exception exp)
            {
                String errorstr = "";
                errorstr += "ErrorMessage: " + exp.Message + "\r\n";
                txtErrorString.Text = errorstr + txtErrorString.Text;
            }
        }
        
    

        private void dynamicDotNetTwain_OnPreAllTransfers()
        {
            IfInsertEnable();
        }

        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            dynamicDotNetTwain.CurrentImageIndexInBuffer = sImageIndex;
            IfInsertEnable();
        }

        private void CreateContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem menuItemCopy = new ToolStripMenuItem("Copy", null, MenuItemClick, Keys.Control | Keys.C);
            ToolStripMenuItem menuItemSelect = new ToolStripMenuItem("Select All", null, MenuItemClick, Keys.Control | Keys.A);
            ToolStripMenuItem menuItemClear = new ToolStripMenuItem("Clear", null, MenuItemClick, Keys.Control | Keys.X);
            menu.Items.Add(menuItemCopy);
            menu.Items.Add(menuItemClear);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(menuItemSelect);
            txtErrorString.ContextMenuStrip = menu;
            txtErrorString.ReadOnly = true;
        }

        private void MenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Text == "Clear")
            {
                txtErrorString.Clear();
            }
            if (menuItem.Text == "Copy")
            {
                txtErrorString.Copy();
            }
            if (menuItem.Text == "Select All")
            {
                txtErrorString.SelectAll();
            }
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dynamicDotNetTwain.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex));
                dynamicDotNetTwain.OpenSource();
                if (dynamicDotNetTwain.Duplex == Dynamsoft.DotNet.TWAIN.Enums.TWICapDuplex.TWDX_NONE)
                {
                    chkDuplex.Checked = false;
                    chkDuplex.Enabled = false;
                    bNotSupportDuplex = true;
                }
                else
                {
                    chkDuplex.Enabled = true;
                    bNotSupportDuplex = false;
                }
                dynamicDotNetTwain.CloseSource();
            }
            catch 
            {
            }
        }
    }
}