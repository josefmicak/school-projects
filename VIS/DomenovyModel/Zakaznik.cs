using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Zakaznik
    {
        public int Id_zakaznika { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Adresa { get; set; }
        public string Telefonni_cislo { get; set; }
        public char Neaktivni { get; set; }
        public int Kategorie { get; set; }
        public string V_blacklistu { get; set; }
        public string Zrusen { get; set; }
        public string Email { get; set; }
        public string Heslo { get; set; }
    }
}
