using System;

namespace RestauraceORM.Databaze
{
    class Rozvazka
    {
        public int Id_rozvazky { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Vozidlo Vozidlo { get; set; }
        public DateTime Cas_odjezdu { get; set; }
        public DateTime Cas_prijezdu { get; set; }

        public override string ToString()
        {
            return "Informace o rozvazce:\nID rozvazky: " + Id_rozvazky + " ID zamestnance: " + Zamestnanec.Id_zamestnance + " ID vozidla: " + Vozidlo.Id_vozidla + " Cas odjezdu: " + Cas_odjezdu + " Cas prijezdu: " + Cas_prijezdu +
            "\nInformace o prislusnem zamestnanci:\nID zamestnance: " + Zamestnanec.Id_zamestnance + " Jmeno: " + Zamestnanec.Jmeno + " Prijmeni: " + Zamestnanec.Prijmeni + " Adresa: " + Zamestnanec.Adresa + " Telefonni cislo: " + Zamestnanec.Telefonni_cislo + " Pohlavi: " + Zamestnanec.Pohlavi + " Datum narozeni: " + Zamestnanec.Datum_narozeni + " Datum nastupu: " + Zamestnanec.Datum_nastupu + " Pozice: " + Zamestnanec.Pozice + " Plat: " + Zamestnanec.Plat + " Vyhozen: " + Zamestnanec.Vyhozen +
            "\nInformace o prislusnem vozidle:\nID vozidla: " + Vozidlo.Id_vozidla + " Datum porizeni: " + Vozidlo.Datum_porizeni + " Cena: " + Vozidlo.Cena + " Objem kufru: " + Vozidlo.Objem_kufru + " Znacka: " + Vozidlo.Znacka + " Pocet ujetych km: " + Vozidlo.Pocet_ujetych_km;
        }
    }
}
