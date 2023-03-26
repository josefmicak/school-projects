using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva
{
    class TypDatabaze
    {
        public enum Databaze { SQL, XML }

        public static Databaze GetTypDatabaze
        {
            get
            {
                return Databaze.XML;
            }
        }
    }
}
