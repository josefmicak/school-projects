using System;

namespace RestauraceORM.Databaze
{
    class Vozidlo
    {
        public int Id_vozidla { get; set; }
        public DateTime Datum_porizeni { get; set; }
        public int Cena { get; set; }
        public int Objem_kufru { get; set; }        
        public string Znacka { get; set; }
        public int Pocet_ujetych_km { get; set; }

        public override string ToString()
        {
            return "ID: " + Id_vozidla + " Datum_porizeni: " + Datum_porizeni + " Cena: " + Cena + " Objem_kufru: " + Objem_kufru + " Znacka: " + Znacka + " Pocet_ujetych_km: " + Pocet_ujetych_km;
        }
    }
}
