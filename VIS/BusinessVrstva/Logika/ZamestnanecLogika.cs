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
    public class ZamestnanecLogika
    {
        static Collection<Zamestnanec> seznamZamestnancu;

        public Collection<Zamestnanec> getSeznamZamestnancu()
        {
            if (seznamZamestnancu == null)
            {
                seznamZamestnancu = ZamestnanecProxy.Select();
            }
            return seznamZamestnancu;
        }

        public Zamestnanec Select(int idZamestnance)
        {
            return ZamestnanecProxy.Select(idZamestnance);
        }

        public int? Insert(Zamestnanec zamestnanec, bool vyhozenaVyjimka)
        {
            bool[] vyjimky = { false, false, false, false, false };
            string[] vyjimkyText = { "\nV systému již existuje další manažer", "\nPřidáváný zaměstnanec má nestandardně vysoký plat (vyšší než manažer)",
            "\nPřidáváný zaměstnanec má nestandardně nízký plat (nižší než minimální mzda)", "\nPřidáváný zaměstnanec má nestandardní věk (nižší než 15)"
            , "\nPřidáváný zaměstnanec má nestandardní věk (vyšší než 100)"};

            if (zamestnanec.Pozice == "Manazer" && existujeManazer())
            {
                vyjimky[0] = true;
            }
            Zamestnanec manazer = new Zamestnanec();
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (seznamZamestnancu[i].Pozice == "Manazer")
                {
                    manazer = seznamZamestnancu[i];
                    break;
                }
            }
            if (existujeManazer() && zamestnanec.Pozice != "Manazer" && manazer.Plat < zamestnanec.Plat)
            {
                vyjimky[1] = true;
            }
            bool nalezenaVyjimka = false;
            string vyslednyText = "Během přidávání zaměstnance byly zjištěny tyto skutečnosti:";
            if (zamestnanec.Plat < 14600)
            {
                vyjimky[2] = true;
            }
            if (vypocitatVek(zamestnanec.Datum_narozeni) < 15)
            {
                vyjimky[3] = true;
            }
            if (vypocitatVek(zamestnanec.Datum_narozeni) > 100)
            {
                vyjimky[4] = true;
            }
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
            return ZamestnanecProxy.Insert(zamestnanec);
        }

        public int? Update(Zamestnanec zamestnanec, bool vyhozenaVyjimka)
        {
            bool[] vyjimky = { false, false, false, false };
            string[] vyjimkyText = { "\nUpravovaný zaměstnanec má nestandardně vysoký plat (vyšší než manažer)",
            "\nUpravovaný zaměstnanec má nestandardně nízký plat (nižší než minimální mzda)", "\nUpravovaný zaměstnanec má nestandardní věk (nižší než 15)"
            , "\nUpravovaný zaměstnanec má nestandardní věk (vyšší než 100)"};

            Zamestnanec manazer = new Zamestnanec();
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (seznamZamestnancu[i].Pozice == "Manazer")
                {
                    manazer = seznamZamestnancu[i];
                    break;
                }
            }
            if (existujeManazer() && zamestnanec.Pozice != "Manazer" && manazer.Plat < zamestnanec.Plat)
            {
                vyjimky[0] = true;
            }
            if (zamestnanec.Plat < 14600)
            {
                vyjimky[1] = true;
            }
            if (vypocitatVek(zamestnanec.Datum_narozeni) < 15)
            {
                vyjimky[2] = true;
            }
            if (vypocitatVek(zamestnanec.Datum_narozeni) > 100)
            {
                vyjimky[3] = true;
            }

            bool nalezenaVyjimka = false;
            string vyslednyText = "Během upravování zaměstnance byly zjištěny tyto skutečnosti:";
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
            return ZamestnanecProxy.Update(zamestnanec);
        }

        public int? Delete(int vybranyZamestnanec)
        {
            try
            {
                return ZamestnanecProxy.Delete(vybranyZamestnanec);
            }
            catch
            {
                return null;
            }
        }

        public bool existujeManazer()
        {
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (seznamZamestnancu[i].Pozice == "Manazer")
                {
                    return true;
                }
            }
            return false;
        }

        public int vypocitatVek(DateTime datum_narozeni)
        {
            DateTime dnesniDatum = DateTime.Now;
            TimeSpan ts = dnesniDatum - datum_narozeni;
            DateTime vek = DateTime.MinValue.AddDays(ts.Days);
            return vek.Year - 1;
        }
    }
}
