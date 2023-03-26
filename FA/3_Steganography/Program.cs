using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Text;
using System.Xml.Linq;

namespace Steganography
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
           
        }
    }
}