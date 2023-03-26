using System;
using RestauraceORM.Databaze.mssql;
using RestauraceORM.Databaze.Proxy;
using RestauraceORM.Databaze;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RestauraceORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1()); 
            Database db = new Database();
            db.Connect();
            int count1;
            int pocet = 5;
            /*
            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Zamestnanec");
            Console.WriteLine("=======================================================");
            count1 = ZamestnanecTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);
            
            Console.WriteLine("1.1 Pridani zamestnance");
            Zamestnanec zamestnanec = new Zamestnanec();
            zamestnanec.Id_zamestnance = 7;
            zamestnanec.Jmeno = "Jiri";
            zamestnanec.Prijmeni = "Kratochvil";
            zamestnanec.Adresa = "1177 Provaznicka Ostrava-Hrabuvka";
            zamestnanec.Telefonni_cislo = "420752335241";
            zamestnanec.Pohlavi = 'M';
            zamestnanec.Datum_narozeni = DateTime.Parse("1984-02-03");
            zamestnanec.Datum_nastupu = DateTime.Parse("2019-11-01");
            zamestnanec.Pozice = "Kuchar";
            zamestnanec.Plat = 20000;
            zamestnanec.Vyhozen = null;
            ZamestnanecProxy.Insert(zamestnanec, db);
            count1 = ZamestnanecTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);
            
            Console.WriteLine("1.2 Seznam zamestnancu");
            Collection<Zamestnanec> zamestnanci = ZamestnanecProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zamestnanci[i]);
            }

            Console.WriteLine("1.3 Aktualizace zamestnance");
            zamestnanci[0].Jmeno = "Erik";
            ZamestnanecProxy.Update(zamestnanci[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zamestnanci[i]);
            }
                      
            Console.WriteLine("1.4 Smazani zamestnance");
            ZamestnanecProxy.Delete(7, db);
            count1 = ZamestnanecTable.Select(db).Count;

            Console.WriteLine("1.5 Vypocet efektivnosti zamestnancu pri rozvazeni");
            ZamestnanecProxy.VypocetEfektivnostiRidicu(db);

            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Zakaznik");
            Console.WriteLine("=======================================================");
            count1 = ZakaznikTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("2.1 Pridani zakaznika");      
            Zakaznik zakaznik = new Zakaznik();
            zakaznik.Id_zakaznika = 11;
            zakaznik.Jmeno = "Tomas";
            zakaznik.Prijmeni = "Konecny";
            zakaznik.Adresa = "4321 28. Rijna Ostrava-Marianske Hory";
            zakaznik.Telefonni_cislo = "420744125412";
            zakaznik.Neaktivni = 'N';
            zakaznik.Kategorie = 1;
            zakaznik.V_blacklistu = null;
            zakaznik.Zrusen = null;
            ZakaznikProxy.Insert(zakaznik, db);
            count1 = ZakaznikTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);
            
            Console.WriteLine("2.2 Seznam zakazniku");
            Collection<Zakaznik> zakaznici = ZakaznikProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zakaznici[i]);
            }

            Console.WriteLine("2.3 Aktualizace zakaznika");
            zakaznici[0].Jmeno = "Marek";
            ZakaznikProxy.Update(zakaznici[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zakaznici[i]);
            }

            Console.WriteLine("2.4 Smazani zakaznika");
            ZakaznikProxy.Delete(11, db);
            count1 = ZakaznikTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("2.6 Sumarizace aktivity zakazniku");
            ZakaznikProxy.SumarizaceAktivityZakazniku(db);

            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Objednavka");
            Console.WriteLine("=======================================================");
            count1 = ObjednavkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("3.1 Pridani objednavky");
            Objednavka objednavka = new Objednavka();
            objednavka.Id_objednavky = 21;
            objednavka.Zakaznik = ZakaznikProxy.Select(3);
            objednavka.Zamestnanec = ZamestnanecProxy.Select(2);
            objednavka.Rozvazka = RozvazkaProxy.Select(4);
            objednavka.Datum_vytvoreni = DateTime.Parse("2019-11-07 21:05:10");
            objednavka.Cena = 359;
            objednavka.Vyplacena = 'N';
            ObjednavkaProxy.Insert(objednavka, db);
            count1 = ObjednavkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("3.2 Seznam objednavek");
            Collection<Objednavka> objednavky = ObjednavkaProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(objednavky[i]);
            }

            Console.WriteLine("3.3 Aktualizace objednavky");
            objednavky[0].Cena = 275;
            ObjednavkaProxy.Update(objednavky[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(objednavky[i]);
            }

            Console.WriteLine("3.4 Smazani objednavky");
            ObjednavkaProxy.Delete(21, db);
            count1 = ObjednavkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("3.5 Urceni vyse slevy objednavky");
            objednavka = new Objednavka();
            objednavka.Id_objednavky = 21;
            objednavka.Zakaznik = ZakaznikProxy.Select(1);
            objednavka.Zamestnanec = ZamestnanecProxy.Select(2);
            objednavka.Rozvazka = RozvazkaProxy.Select(4);
            objednavka.Datum_vytvoreni = DateTime.Parse("2019-11-07 21:05:10");
            objednavka.Cena = 450;
            objednavka.Vyplacena = 'N';
            ObjednavkaProxy.SlevaObjednavky(objednavka, db);
            count1 = ObjednavkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);
            ObjednavkaProxy.Delete(21, db);
            count1 = ObjednavkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);
            
            pocet = 3;
            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Stiznost");
            Console.WriteLine("=======================================================");
            count1 = StiznostTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("4.1 Pridani stiznosti");
            Stiznost stiznost = new Stiznost();
            stiznost.Id_stiznosti = 3;
            stiznost.Zakaznik = ZakaznikProxy.Select(9);
            stiznost.Zamestnanec = ZamestnanecProxy.Select(4);
            stiznost.Datum = DateTime.Parse("2019-11-08 15:15:23");
            stiznost.Typ_stiznosti = 2;
            stiznost.Vyrizena = 'N';
            StiznostProxy.Insert(stiznost, db);
            count1 = StiznostTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("4.2 Seznam stiznosti");
            Collection<Stiznost> stiznosti = StiznostProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(stiznosti[i]);
            }

            Console.WriteLine("4.3 Aktualizace stiznosti");
            stiznosti[1].Vyrizena = 'Y';
            StiznostProxy.Update(stiznosti[1], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(stiznosti[i]);
            }

            Console.WriteLine("4.4 Smazani stiznosti");
            StiznostProxy.Delete(3, db);
            count1 = StiznostTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            pocet = 5;
            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Hodnoceni");
            Console.WriteLine("=======================================================");
            count1 = HodnoceniTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("5.1 Pridani hodnoceni");
            Hodnoceni hodnoceni = new Hodnoceni();
            hodnoceni.Id_hodnoceni = 5;
            hodnoceni.Zakaznik = ZakaznikProxy.Select(2);
            hodnoceni.Zamestnanec = ZamestnanecProxy.Select(5);
            hodnoceni.Datum = DateTime.Parse("2019-11-07 19:44:02");
            hodnoceni.Udelene_hodnoceni = 7;
            HodnoceniProxy.Insert(hodnoceni, db);
            count1 = HodnoceniTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("5.2 Seznam hodnoceni");
            Collection<Hodnoceni> seznam_hodnoceni = HodnoceniProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(seznam_hodnoceni[i]);
            }

            Console.WriteLine("5.3 Aktualizace hodnoceni");
            seznam_hodnoceni[0].Udelene_hodnoceni = 4;
            HodnoceniProxy.Update(seznam_hodnoceni[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(seznam_hodnoceni[i]);
            }

            Console.WriteLine("5.4 Smazani hodnoceni");
            HodnoceniProxy.Delete(5, db);
            count1 = HodnoceniTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("5.5 Posouzeni hodnoceni");
            HodnoceniProxy.PosouzeniHodnoceni(db);

            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Rozvazka");
            Console.WriteLine("=======================================================");
            count1 = RozvazkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("6.1 Pridani rozvazky");
            Rozvazka rozvazka = new Rozvazka();
            rozvazka.Id_rozvazky = 5;         
            rozvazka.Zamestnanec = ZamestnanecProxy.Select(1);
            rozvazka.Vozidlo = VozidloProxy.Select(1);
            rozvazka.Cas_odjezdu = DateTime.Parse("2019-11-08 13:45:10");
            rozvazka.Cas_prijezdu = DateTime.Parse("2019-11-08 14:33:58");
            RozvazkaProxy.Insert(rozvazka, db);
            count1 = RozvazkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("Dotaz psan s durazem na minimalizaci poctu operaci.");
            Console.WriteLine("6.2 Seznam rozvazek");
            Collection<Rozvazka> rozvazky = RozvazkaProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(rozvazky[i]);
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("6.3 Aktualizace rozvazky");
            rozvazky[0].Cas_prijezdu = DateTime.Parse("2019-11-05 14:48:14");
            RozvazkaProxy.Update(rozvazky[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(rozvazky[i]);
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("6.4 Smazani rozvazky");
            RozvazkaProxy.Delete(5, db);
            count1 = RozvazkaTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("6.5 Kontrola dostupnosti zamestnance");
            RozvazkaProxy.KontrolaDostupnostiZamestnance(6, db);

            pocet = 3;
            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Vozidlo");
            Console.WriteLine("=======================================================");
            count1 = VozidloTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("7.1 Pridani vozidla");
            Vozidlo vozidlo = new Vozidlo();
            vozidlo.Id_vozidla = 3;
            vozidlo.Datum_porizeni = DateTime.Parse("2019-11-01");
            vozidlo.Cena = 126000;
            vozidlo.Objem_kufru = 380;
            vozidlo.Znacka = "8T51423";
            vozidlo.Pocet_ujetych_km = 10023;
            VozidloProxy.Insert(vozidlo, db);
            count1 = VozidloTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("7.2 Seznam vozidel");
            Collection<Vozidlo> vozidla = VozidloProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(vozidla[i]);
            }

            Console.WriteLine("7.3 Aktualizace vozidla");
            vozidla[0].Pocet_ujetych_km = 25645;
            VozidloProxy.Update(vozidla[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(vozidla[i]);
            }

            Console.WriteLine("7.4 Smazani vozidla");
            VozidloProxy.Delete(3, db);
            count1 = VozidloTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            pocet = 5;
            Console.WriteLine("=======================================================");
            Console.WriteLine("Tabulka Historie_ujetych_km");
            Console.WriteLine("=======================================================");
            count1 = ZaznamTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("8.1 Pridani zaznamu");
            Zaznam zaznam = new Zaznam();
            zaznam.Id_zaznamu = 19;
            zaznam.Vozidlo = VozidloProxy.Select(1);
            zaznam.Datum_zaznamu = DateTime.Parse("2019-12-01");
            zaznam.Pocet_ujetych_km = 25454;
            ZaznamProxy.Insert(zaznam, db);
            count1 = ZaznamTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.WriteLine("8.2 Seznam zaznamu");
            Collection<Zaznam> zaznamy = ZaznamProxy.Select();
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zaznamy[i]);
            }

            Console.WriteLine("8.3 Aktualizace zaznamu");
            zaznamy[0].Pocet_ujetych_km = 3168;
            ZaznamProxy.Update(zaznamy[0], db);
            Console.WriteLine("Vypis prvnich " + pocet + ". zaznamu:");
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine(zaznamy[i]);
            }

            Console.WriteLine("8.4 Smazani zaznamu");
            ZaznamProxy.Delete(19, db);
            count1 = ZaznamTable.Select(db).Count;
            Console.WriteLine("Pocet zaznamu: " + count1);

            Console.Read();
            */
            db.Close();
        }
    }
}

