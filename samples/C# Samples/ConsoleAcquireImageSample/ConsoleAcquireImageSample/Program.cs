using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAcquireImageSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TwainObject tempTwainObject = new TwainObject();
            Console.WriteLine("Start a scan job:");
            if (tempTwainObject.SelectSource())
            {
                tempTwainObject.AcquireImage();
            }
        }
    }
}
