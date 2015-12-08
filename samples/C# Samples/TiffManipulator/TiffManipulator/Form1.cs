using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Dynamsoft.DotNet.TWAIN;

namespace TiffManipulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.MaxImagesInBuffer = 1000;
            this.dynamicDotNetTwain1.SetViewMode(3, 3);
            this.dynamicDotNetTwain1.AllowMultiSelect = true;
            this.dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82";
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpener = new OpenFileDialog();
            fileOpener.Filter = "TIFF Images (*.tif;*.tiff)|*.tif;*.tiff";

            if (fileOpener.ShowDialog() == DialogResult.OK)
                TryAddingFile(fileOpener.FileName);
        }

        private void TryAddingFile(string fileName)
        {
            OnFileAdded(fileName);
        }

        private bool AlreadyAddedFile(string strFileName)
        {
            foreach (object o in fileList.Items)
            {
                string strfileNameInList = (string)o;
                if (strfileNameInList == strFileName)
                    return true;
            }
            return false;
        }

        private void OnFileAdded(string fileName)
        {
            if (this.dynamicDotNetTwain1.LoadImageEx(fileName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF) == false)
            {
                MessageBox.Show("Unable to open the file - it might not be a TIFF or it might be damaged.");
            }
            fileList.Items.Add(Path.GetFileName(fileName));
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
            {
                SaveFileDialog fileSaver = new SaveFileDialog();
                fileSaver.Filter = "TIFF Image (*.tif)|*.tif";

                if (fileSaver.ShowDialog() == DialogResult.OK)
                    TrySavingFile(fileSaver.FileName);
            }
            else
                MessageBox.Show("There is no file in buffer! Please add some files.");
        }

        private void TrySavingFile(string fileName)
        {
            if (AlreadyAddedFile(fileName))
            {
                MessageBox.Show("Can't save over one of the source files.");
            }
            else
            {
                this.dynamicDotNetTwain1.SaveAllAsMultiPageTIFF(fileName);
            }
        }

        private void deleteSelectedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.RemoveImages(this.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer);
        }

        private void switchImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer.Count == 2)
            {
                IndexList aryList = this.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer;
                this.dynamicDotNetTwain1.SwitchImage((short)aryList[0], (short)aryList[1]);
            }
            else
            {
                MessageBox.Show("Unable to complete the operation. First select two images to switch.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
