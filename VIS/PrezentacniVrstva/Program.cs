using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatovaVrstva.SQL;

namespace PrezentacniVrstva
{
    class Program
    {
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new ZamestnanciForm());
            Database db = new Database();
            db.Connect();
        }
    }
}
