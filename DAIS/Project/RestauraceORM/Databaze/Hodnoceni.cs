using System;

namespace RestauraceORM.Databaze
{
    class Hodnoceni
    {
        public int Id_hodnoceni { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public int Udelene_hodnoceni { get; set; }

        public override string ToString()
        {
            return "ID hodnoceni: " + Id_hodnoceni + " ID zakaznika: " + Zakaznik.Id_zakaznika + " ID zamestnance: " + Zamestnanec.Id_zamestnance +  " Datum: " + Datum + " Hodnoceni: " + Udelene_hodnoceni;
        }
    }
}
