using System;

namespace RestauraceORM.Databaze
{
    class Stiznost
    {
        public int Id_stiznosti { get; set; }
        public Zakaznik Zakaznik { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public int Typ_stiznosti { get; set; }
        public char Vyrizena { get; set; }

        public override string ToString()
        {
            return "ID stiznosti: " + Id_stiznosti + " ID zakaznika: " + Zakaznik.Id_zakaznika + " ID zamestnance: " + Zamestnanec.Id_zamestnance +  " Datum: " + Datum + " Typ stiznosti: " + Typ_stiznosti + " Vyrizena: " + Vyrizena;
        }
    }
}
