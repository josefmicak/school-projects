using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Stiznost
    {
        public int Id_stiznosti { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Objednavka Objednavka { get; set; }
        public DateTime Datum { get; set; }
        public int Typ_stiznosti { get; set; }
        public char Vyrizena { get; set; }
    }
}
