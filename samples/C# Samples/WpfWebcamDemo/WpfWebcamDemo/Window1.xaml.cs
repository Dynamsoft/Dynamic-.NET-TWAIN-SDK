﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dynamsoft.DotNet.TWAIN.Enums; 

namespace WpfWebcamDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int m_iRotate = 0;
        private double m_dDesignWidth = 898.123;
        public Window1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
            this.ResizeMode = System.Windows.ResizeMode.CanMinimize;
            this.dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
            this.dynamicDotNetTwain1.IfShowUI = true;
            this.chkContainer.IsChecked = false;
            this.cbxSources.SelectionChanged += cbxSources_SelectionChanged;
            this.cbxSources.DropDownOpened += cbxSources_DropDownOpened;
            cbxSources.SelectedIndex = 0;
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            for (int i = 0; i < 4; i++)
            {
                int irotateType = 90 * i;
                string sRotateType = irotateType.ToString() + "°"; 
                cbxRotateType.Items.Add(sRotateType);
            }
            cbxRotateType.SelectedIndex = 0;
            //this.cbxRotateType.DropDownClosed += cbxRotateType_DropDownClosed;
            this.cbxRotateType.SelectionChanged += cbxRotateType_SelectionChanged;
        }

        void cbxSources_DropDownOpened(object sender, EventArgs e)
        {
            this.cbxSources.SelectionChanged -= cbxSources_SelectionChanged;
            this.cbxSources.SelectedIndex = -1;
            this.cbxSources.SelectionChanged += cbxSources_SelectionChanged;
        }


        void cbxRotateType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_iRotate = (((ComboBox)sender).SelectedIndex) % 4;
            dynamicDotNetTwain1.RotateVideo((EnumVideoRotateType)((ComboBox)sender).SelectedIndex);
            ResizeVideoWindow(m_iRotate);
        }

        //void cbxRotateType_DropDownClosed(object sender, EventArgs e)
        //{
        //    m_iRotate = (((ComboBox)sender).SelectedIndex) % 4;
        //    dynamicDotNetTwain1.RotateVideo((EnumVideoRotateType)((ComboBox)sender).SelectedIndex);
        //    ResizeVideoWindow(m_iRotate);
        //}

        private void btnCaptureImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxSources.Items.Count > 0)
                {
                    dynamicDotNetTwain1.AcquireImage();
                }
                else
                {
                    MessageBox.Show("No webcam source detected!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.chkContainer.Checked += chkContainer_CheckedChanged;
                this.chkContainer.Unchecked += chkContainer_CheckedChanged;

                this.chkContainer.IsChecked = true;

                this.chkFocus.Checked += chkFocus_CheckedChanged;
                this.chkFocus.Unchecked += chkFocus_CheckedChanged;
                for (short i = 0; i < dynamicDotNetTwain1.SourceCount; i++)
                {
                    string SourceCountName = dynamicDotNetTwain1.SourceNameItems(i);
                    if (SourceCountName != null)
                    {
                        this.cbxSources.Items.Add(SourceCountName);
                    }
                    if (cbxSources.Items.Count > 0)
                    {
                        cbxSources.SelectedIndex = 0;
                    }
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        void chkFocus_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (chkFocus.IsChecked == true)
            {
                //this.chkContainer.IsChecked = true;
                //this.chkContainer.IsEnabled = false;
                this.image1.MouseLeftButtonDown += image1_MouseLeftButtonDown;
            }
            else
            {
                //this.chkContainer.IsEnabled = true;
                this.image1.MouseLeftButtonDown -= image1_MouseLeftButtonDown;
            }
        }

        void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            System.Windows.Point wpFocus = Mouse.GetPosition(e.Source as FrameworkElement);
            //System.Drawing.Point dpFocus = new System.Drawing.Point((int)wpFocus.X, (int)wpFocus.Y);
            //System.Drawing.Rectangle rectRect = new System.Drawing.Rectangle(dpFocus.X - 25, dpFocus.Y - 25, 50, 50);
            System.Windows.Rect rectRect = new System.Windows.Rect(wpFocus.X - 25, wpFocus.Y - 25, 50, 50);
            dynamicDotNetTwain1.FocusOnArea(rectRect);
        }

        void chkContainer_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (chkContainer.IsChecked == false)
            {
                this.border1.Visibility = System.Windows.Visibility.Hidden;
                this.image1.Visibility = System.Windows.Visibility.Hidden;
                this.Width = m_dDesignWidth - this.border1.ActualWidth - 45;
                this.chkFocus.IsChecked = false;
                this.chkFocus.IsEnabled = false;
                dynamicDotNetTwain1.SetVideoContainer(null);
            }
            else
            {
                this.border1.Visibility = System.Windows.Visibility.Visible;
                this.image1.Visibility = System.Windows.Visibility.Visible;
                this.Width = m_dDesignWidth;
                this.chkFocus.IsEnabled = true;
                dynamicDotNetTwain1.SetVideoContainer(image1);
            }
            ResizeVideoWindow(m_iRotate);
        }

        void cbxSources_SelectionChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < dynamicDotNetTwain1.SourceCount)
            {
                dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex);
                m_iRotate = 0;
                cbxRotateType.SelectedIndex = 0;
                dynamicDotNetTwain1.OpenSource();
                dynamicDotNetTwain1.RotateVideo((EnumVideoRotateType)(m_iRotate));
                ResizeVideoWindow(m_iRotate);
            }
        }

        private void ResizeVideoWindow(int iRotate)
        {
            if (chkContainer.IsChecked == true)
            {
                Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution camResolution = dynamicDotNetTwain1.ResolutionForCam;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    if (iRotate % 2 == 0)
                    {
                        double iVideowidth = border1.Width;
                        double iVideoHeight = border1.Width * camResolution.Height / camResolution.Width;
                        if (iVideoHeight < border1.ActualHeight)
                        {
                            image1.Width = border1.Width;
                            image1.Height = iVideoHeight;
                            image1.Margin = new Thickness(0, (border1.ActualHeight - iVideoHeight) / 2, 0, 0);
                        }

                    }
                    else
                    {
                        double iVideoHeight = border1.Height;
                        double iVideoWidth = border1.Height * camResolution.Height / camResolution.Width;
                        if (iVideoWidth < border1.Width)
                        {
                            image1.Height = border1.Height;
                            image1.Width = iVideoWidth;
                            image1.Margin = new Thickness((border1.ActualWidth - iVideoWidth) / 2, 0, 0, 0);
                        }
                    }
                }

            }
        }

        private void btnRemoveAllImage_Click(object sender, RoutedEventArgs e)
        {
            this.dynamicDotNetTwain1.RemoveAllImages();
        }
    }
}
