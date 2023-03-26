using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Objednavka
    {
        public int Id_objednavky { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Rozvazka Rozvazka { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public int Cena { get; set; }
        public char Vyplacena { get; set; }
    }
}
