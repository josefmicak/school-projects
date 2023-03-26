using System;

namespace RestauraceORM.Databaze
{
    class Zamestnanec
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

        public override string ToString()
        {
            return "ID: " + Id_zamestnance + " Jmeno: " + Jmeno + " " + Prijmeni + " Adresa: " + Adresa + " Telefon: " + Telefonni_cislo + " Pohlavi: " + Pohlavi + " Datum narozeni: " + Datum_narozeni + " Datum nastupu: " + Datum_nastupu + " Pozice: " + Pozice + " Plat: " + Plat + " Vyhozen: " + Vyhozen;
        }
    }
}
