using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Zamestnanec
    {
        public int Id_zamestnance { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Adresa { get; set; }
        public string Telefonni_cislo { get; set; }
        public char Pohlavi { get; set; }
        public DateTime Datum_narozeni { get; set; }
        public DateTime Datum_nastupu { get; set; }
        public string Pozice { get; set; }
        public int Plat { get; set; }
        public string Vyhozen { get; set; }
    }
}
