using System;
using System.Collections.Generic;
using System.Text;
using Dynamsoft.TWAIN;
using Dynamsoft.TWAIN.Interface;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleAcquireImageSample
{
    public partial class TwainObject:Dynamsoft.TWAIN.Interface.IAcquireCallback
    {
        private TwainManager m_TwainManager = null;
        short iPageNumber = 0;
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        public TwainObject()
        {
            m_TwainManager = new TwainManager(m_StrProductKey);
        }


        public bool SelectSource()
        {
            bool bRet = false;
            Console.WriteLine("Select a scanner:");
            short sSourceCount = m_TwainManager.SourceCount;
            for (short sIndex = 0; sIndex < sSourceCount; sIndex++)
            {
                Console.WriteLine(sIndex.ToString() + ". "+m_TwainManager.SourceNameItems(sIndex));
            }
            Console.WriteLine("Enter the scanner index:");
            string temp = Console.ReadLine();
            int res = Int32.Parse(temp);
            if (res > -1 && res < m_TwainManager.SourceCount)
            {
                 bRet = m_TwainManager.SelectSourceByIndex((short)res);
                Console.WriteLine("Current Source name: " + m_TwainManager.CurrentSourceName);
            }
            if (!bRet)
            {
                Console.WriteLine("Fail to select source.");
            }
            return bRet;
        }

        public void AcquireImage()
        {
            m_TwainManager.IfDisableSourceAfterAcquire = true;
           m_TwainManager.AcquireImage(this as IAcquireCallback);
        }

        public void Dispose()
        {
            m_TwainManager.Dispose();
        }
        #region IAcquireCallback Members

        public void OnPostAllTransfers()
        {
            m_TwainManager.CloseSourceManager();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        public bool OnPostTransfer(System.Drawing.Bitmap bit)
        {
  
            Console.WriteLine("The "+iPageNumber.ToString() +" pages of document has been scanned.");
            string path = System.IO.Path.GetTempPath();
            DateTime temp = DateTime.Now;
            int year = temp.Year;
            int month = temp.Month;
            int day = temp.Day;
            int hour = temp.Hour;
            int min = temp.Minute;
            int sec = temp.Second;
            string date = "Page" + iPageNumber.ToString()+"_" + year.ToString() + "_" + month.ToString() + "_" + day.ToString() + "_" + hour.ToString()+"hour" + "_"+min.ToString()+"min" + "_" + sec.ToString() + "sec";

            string filePath = path + date.ToString() + ".bmp"; 
            bit.Save(filePath);
            Console.WriteLine("Image has been saved. "+"The file path: "+ filePath.ToString());
            return true;

        }

        public void OnPreAllTransfers()
        {
            Console.WriteLine("The scan task will begin.");
        }

        public bool OnPreTransfer()
        {
            iPageNumber++;
            Console.WriteLine("The " + iPageNumber.ToString() + " pages of document will be scanned.");
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

        #endregion
    }
}
