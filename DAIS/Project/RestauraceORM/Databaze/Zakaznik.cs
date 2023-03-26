using System;
using System.Collections.Generic;

namespace RestauraceORM.Databaze
{
    class Zakaznik
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
        public override string ToString()
        {
            return "ID: " + Id_zakaznika + " Jmeno: " + Jmeno + " " + Prijmeni + " Adresa: " + Adresa + " Telefon: " + Telefonni_cislo + " Neaktivni: " + Neaktivni + " Kategorie: " + Kategorie + " V_blacklistu: " + V_blacklistu + " Zrusen: " + Zrusen;
        }
    }
}
