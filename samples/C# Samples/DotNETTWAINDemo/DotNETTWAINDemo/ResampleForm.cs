using Dynamsoft.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNet_TWAIN_Demo
{
    public partial class ResampleForm : Form
    {
        private int width, height;
        private int newWidth, newHeight;
        private bool flag;
        private EnumInterpolationMethod m_InterpolationMethod = EnumInterpolationMethod.BestQuality;
        public ResampleForm()
        {
            InitializeComponent();
        }

        public ResampleForm(int width, int height)
        {
            InitializeComponent();
            
            this.width = width;
            this.height = height;

            this.flag = false;
            this.tbxWidth.Text = width.ToString();
            this.tbxHeight.Text = height.ToString();
            this.cbxWidthType.SelectedIndex = 0;
            this.cbxHeightType.SelectedIndex = 0;
            this.cbxConstrainProportion.Checked = true;
            this.cbxResampleType.SelectedIndex = 0;
            flag = true;
        }
        
        public int NewHeight
        {
            get 
            {
                if (cbxWidthType.SelectedIndex == 0)
                    return int.Parse(tbxHeight.Text);
                else
                    return int.Parse(tbxHeight.Text) * height / 100;
            }
        }

        public int NewWidth
        {
            get
            {
                if (cbxHeightType.SelectedIndex == 0)
                    return int.Parse(tbxWidth.Text);
                else
                    return int.Parse(tbxWidth.Text) * width / 100;
            }
        }

        public EnumInterpolationMethod Interpolation
        {
            get
            {
                switch (this.cbxResampleType.SelectedIndex)
                {
                    case 0:
                        m_InterpolationMethod = EnumInterpolationMethod.Bicubic;
                        break;
                    case 1:
                        m_InterpolationMethod = EnumInterpolationMethod.Bilinear;
                        break;
                    case 2:
                        m_InterpolationMethod = EnumInterpolationMethod.NearestNeighbour;
                        break;
                    case 3:
                        m_InterpolationMethod = EnumInterpolationMethod.BestQuality;
                        break;
                }
                return m_InterpolationMethod;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbxWidth.Text, out newWidth))
            {
                tbxWidth.Focus();
                return;
            }
            if (!int.TryParse(tbxHeight.Text, out newHeight))
            {
                tbxHeight.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbxWidthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxHeightType.SelectedIndex != this.cbxWidthType.SelectedIndex && flag)
            {
                if (cbxWidthType.SelectedIndex == 0)
                {
                    if (int.TryParse(tbxWidth.Text, out newWidth) && int.TryParse(tbxHeight.Text, out newHeight))
                    {
                        newHeight = newHeight * height / 100;
                        newWidth = newWidth * width / 100;
                        tbxWidth.Text = newWidth.ToString();
                        tbxHeight.Text = newHeight.ToString();
                    }
                }
                else
                {
                    if (int.TryParse(tbxWidth.Text, out newWidth) && int.TryParse(tbxHeight.Text, out newHeight))
                    {
                        newWidth = (int)(newWidth / (double)width * 100);
                        newHeight = (int)(newHeight / (double)height * 100);
                        tbxWidth.Text = newWidth.ToString();
                        tbxHeight.Text = newHeight.ToString();
                    }
                }
                
                this.cbxHeightType.SelectedIndex = this.cbxWidthType.SelectedIndex;
            }
        }

        private void cbxHeightType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxWidthType.SelectedIndex != this.cbxHeightType.SelectedIndex && flag)
            {
                if (cbxHeightType.SelectedIndex == 0)
                {
                    if (int.TryParse(tbxHeight.Text, out newHeight) && int.TryParse(tbxWidth.Text, out newWidth))
                    {
                        newWidth = newWidth * width / 100;
                        newHeight = newHeight * height / 100;
                        tbxWidth.Text = newWidth.ToString();
                        tbxHeight.Text = newHeight.ToString();
                    }
                }
                else
                {
                    if (int.TryParse(tbxHeight.Text, out newHeight))
                    {
                        newHeight = (int)(newHeight / (double)height * 100);
                        newWidth = (int)(newWidth / (double)width * 100);
                        tbxWidth.Text = newWidth.ToString();
                        tbxHeight.Text = newHeight.ToString();
                    }
                }
                this.cbxWidthType.SelectedIndex = this.cbxHeightType.SelectedIndex;
            }
        }

        private void tbxWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbxConstrainProportion.Checked == true)
            {
                if (int.TryParse(tbxWidth.Text, out newWidth) == true)
                {
                    double proportion = width / (double)height;
                    if (cbxWidthType.SelectedIndex == 0)
                    {
                        tbxHeight.Text = ((int)(newWidth / proportion)).ToString();
                    }
                    if (cbxWidthType.SelectedIndex == 1)
                    {
                        tbxHeight.Text = newWidth.ToString();
                    }
                }
            }
        }

        private void tbxHeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbxConstrainProportion.Checked == true)
            {
                if (int.TryParse(tbxHeight.Text, out newHeight) == true)
                {
                    double proportion = width / (double)height;
                    if (cbxWidthType.SelectedIndex == 0)
                    {
                        tbxWidth.Text = ((int)(newHeight * proportion)).ToString();
                    }
                    if (cbxWidthType.SelectedIndex == 1)
                    {
                        tbxWidth.Text = newHeight.ToString();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}