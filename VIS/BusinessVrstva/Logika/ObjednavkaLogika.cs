using DatovaVrstva.Proxy;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessVrstva.Logika
{
    public class ObjednavkaLogika
    {
        static Collection<Objednavka> seznamObjednavek;
        public Collection<Objednavka> Select()
        {
            return ObjednavkaProxy.Select();
        }

        public Objednavka Select(int idObjednavky)
        {
            return ObjednavkaProxy.Select(idObjednavky);
        }

        public int? Insert(Objednavka objednavka, bool vyhozenaVyjimka)
        {
            bool[] vyjimky = { false, false, false, false, false };
            string[] vyjimkyText = { "\nRozvážka přidávané objednávky není vytvořena ve stejný den jako přidávaná objednávka",
            "\nZaměstnanec přiřazený k přidávané objednávce je označen jako vyhozený", "\nZákazník přiřazený k přidávané objednávce je zařazen v blacklistu"
            , "\nPřidávaná objednávka má nestandardně vysokou cenu (vyšší než 2000 Kč)", "\nZaměstnanec přiřazený k přidávané objednávce není na pozici kuchaře"};
            Zamestnanec zamestnanec = ZamestnanecProxy.Select(objednavka.Zamestnanec.Id_zamestnance);
            Zakaznik zakaznik = ZakaznikProxy.Select(objednavka.Zakaznik.Id_zakaznika);
            Rozvazka rozvazka = RozvazkaProxy.Select(objednavka.Rozvazka.Id_rozvazky);

            if (objednavka.Datum_vytvoreni.Date != rozvazka.Cas_odjezdu.Date)
            {
                vyjimky[0] = true;
            }
            if (zamestnanec.Vyhozen != null && zamestnanec.Vyhozen.ToUpper() == "Y")
            {
                vyjimky[1] = true;
            }
            if (zakaznik.V_blacklistu != null && zakaznik.V_blacklistu.ToUpper() == "Y")
            {
                vyjimky[2] = true;
            }
            if (objednavka.Cena > 2000)
            {
                vyjimky[3] = true;
            }
            if (zamestnanec.Pozice != "Kuchar")
            {
                vyjimky[4] = true;
            }

            bool nalezenaVyjimka = false;
            string vyslednyText = "Během přidávání objednávky byly zjištěny tyto skutečnosti:";
            for (int i = 0; i < vyjimky.Length; i++)
            {
                if (vyjimky[i])
                {
                    nalezenaVyjimka = true;
                    vyslednyText += vyjimkyText[i];
                }
            }
            if (nalezenaVyjimka && !vyhozenaVyjimka)
            {
                throw new Exception(vyslednyText);
            }
            return ObjednavkaProxy.Insert(objednavka);
        }

        public int? Update(Objednavka objednavka, bool vyhozenaVyjimka)
        {
            bool[] vyjimky = { false, false, false, false, false };
            string[] vyjimkyText = { "\nRozvážka upravované objednávky není vytvořena ve stejný den jako upravovaná objednávka",
            "\nZaměstnanec přiřazený k upravované objednávce je označen jako vyhozený", "\nZákazník přiřazený k upravované objednávce je zařazen v blacklistu"
            , "\nUpravovaná objednávka má nestandardně vysokou cenu (vyšší než 2000 Kč)", "\nZaměstnanec přiřazený k upravované objednávce není na pozici kuchaře"};
            Zamestnanec zamestnanec = ZamestnanecProxy.Select(objednavka.Zamestnanec.Id_zamestnance);
            Zakaznik zakaznik = ZakaznikProxy.Select(objednavka.Zakaznik.Id_zakaznika);
            Rozvazka rozvazka = RozvazkaProxy.Select(objednavka.Rozvazka.Id_rozvazky);

            if (objednavka.Datum_vytvoreni.Date != rozvazka.Cas_odjezdu.Date)
            {
                vyjimky[0] = true;
            }
            if (zamestnanec.Vyhozen != null && zamestnanec.Vyhozen.ToUpper() == "Y")
            {
                vyjimky[1] = true;
            }
            if (zakaznik.V_blacklistu != null && zakaznik.V_blacklistu.ToUpper() == "Y")
            {
                vyjimky[2] = true;
            }
            if (objednavka.Cena > 2000)
            {
                vyjimky[3] = true;
            }
            if (zamestnanec.Pozice != "Kuchar")
            {
                vyjimky[4] = true;
            }

            bool nalezenaVyjimka = false;
            string vyslednyText = "Během upravování objednávky byly zjištěny tyto skutečnosti:";
            for (int i = 0; i < vyjimky.Length; i++)
            {
                if (vyjimky[i])
                {
                    nalezenaVyjimka = true;
                    vyslednyText += vyjimkyText[i];
                }
            }
            if (nalezenaVyjimka && !vyhozenaVyjimka)
            {
                throw new Exception(vyslednyText);
            }
            return ObjednavkaProxy.Update(objednavka);
        }

        public int? Delete(int vybranaObjednavka)
        {
            try
            {
                return ObjednavkaProxy.Delete(vybranaObjednavka);
            }
            catch
            {
                return null;
            }
        }

        public Collection<Objednavka> getSeznamObjednavek()
        {
            if (seznamObjednavek == null)
            {
                seznamObjednavek = ObjednavkaProxy.Select();
            }
            return seznamObjednavek;
        }

        public int? Storno(Objednavka objednavka)
        {
            if (seznamObjednavek == null)
            {
                getSeznamObjednavek();
            }

            TimeSpan ts = DateTime.Now - objednavka.Datum_vytvoreni;
            if (ts.TotalMinutes > 10)
            {
                throw new Exception("Objednávku lze stornovat pouze do 10 minut od doby vytvoření objednávky, operaci nelze provést.");
            }
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                if (seznamObjednavek[i].Id_objednavky == objednavka.Id_objednavky)
                {
                    seznamObjednavek.Remove(objednavka);
                    break;
                }
            }
            return ObjednavkaProxy.Delete(objednavka.Id_objednavky);
        }
    }
}
