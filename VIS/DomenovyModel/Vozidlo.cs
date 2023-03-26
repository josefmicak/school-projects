using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Vozidlo
    {
        public int Id_vozidla { get; set; }
        public DateTime Datum_porizeni { get; set; }
        public int Cena { get; set; }
        public int Objem_kufru { get; set; }
        public string Znacka { get; set; }
        public int Pocet_ujetych_km { get; set; }
    }
}
