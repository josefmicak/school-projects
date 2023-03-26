using System;

namespace RestauraceORM.Databaze
{
    class Objednavka
    {
        public int Id_objednavky { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Rozvazka Rozvazka { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public int Cena { get; set; }
        public char Vyplacena { get; set; } 

        public override string ToString()
        {
            return "ID objednavky: " + Id_objednavky + " ID zakaznika: " + Zakaznik.Id_zakaznika + " ID zamestnance: " + Zamestnanec.Id_zamestnance + " ID rozvazky: " + Rozvazka.Id_rozvazky + " Datum vytvoreni: " + Datum_vytvoreni + " Cena: " + Cena + " Vyplacena: " + Vyplacena;
        }
    }
}
