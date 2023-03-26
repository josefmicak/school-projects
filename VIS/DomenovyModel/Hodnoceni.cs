using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Hodnoceni
    {
        public int Id_hodnoceni { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Objednavka Objednavka { get; set; }
        public DateTime Datum { get; set; }
        public int Udelene_hodnoceni { get; set; }
    }
}
