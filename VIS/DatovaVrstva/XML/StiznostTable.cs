using DatovaVrstva.Proxy;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace DatovaVrstva.XML
{
    class StiznostTable : StiznostProxy
    {
        string stiznostPath = getPath();

        protected override int insert(Stiznost stiznost, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(stiznostPath);
            xmlDoc.Elements("Stiznosti")
            .First().Add(
                new XElement("Stiznost",
                new XElement("Id_stiznosti", getLastId() + 1),
                new XElement("Id_zakaznika", stiznost.Zakaznik.Id_zakaznika),
                new XElement("Id_zamestnance", stiznost.Zamestnanec.Id_zamestnance),
                new XElement("Id_objednavky", stiznost.Objednavka.Id_objednavky),
                new XElement("Datum", stiznost.Datum),
                new XElement("Typ_stiznosti", stiznost.Typ_stiznosti),
                new XElement("Vyrizena", stiznost.Vyrizena)
                ));
            xmlDoc.Save(stiznostPath);
            return stiznost.Id_stiznosti;
        }

        protected override Collection<Stiznost> select(DatabaseProxy pDb = null)
        {
            Collection<Stiznost> seznamStiznosti = new Collection<Stiznost>();
            XDocument xmlDoc = XDocument.Load(stiznostPath);
            var elements = from ele in xmlDoc.Elements("Stiznosti").Elements("Stiznost")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                Stiznost stiznost = new Stiznost();
                stiznost.Id_stiznosti = Convert.ToInt32(e.Element("Id_stiznosti").Value);
                stiznost.Zakaznik = new Zakaznik();
                stiznost.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                stiznost.Zamestnanec = new Zamestnanec();
                stiznost.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                stiznost.Objednavka = new Objednavka();
                stiznost.Objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                stiznost.Datum = Convert.ToDateTime(e.Element("Datum").Value);
                stiznost.Typ_stiznosti = Convert.ToInt32(e.Element("Typ_stiznosti").Value);
                stiznost.Vyrizena = Convert.ToChar(e.Element("Vyrizena").Value);
                seznamStiznosti.Add(stiznost);
            }

            return seznamStiznosti;
        }

        protected override Stiznost select(int idStiznosti, DatabaseProxy pDb = null)
        {
            Stiznost stiznost = new Stiznost();

            XDocument xmlDoc = XDocument.Load(stiznostPath);
            var elements = from ele in xmlDoc.Elements("Stiznosti").Elements("Stiznost")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                if (idStiznosti == Convert.ToInt32(e.Element("Id_stiznosti").Value))
                {
                    stiznost.Id_stiznosti = Convert.ToInt32(e.Element("Id_stiznosti").Value);
                    stiznost.Zakaznik = new Zakaznik();
                    stiznost.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                    stiznost.Zamestnanec = new Zamestnanec();
                    stiznost.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                    stiznost.Objednavka = new Objednavka();
                    stiznost.Objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                    stiznost.Datum = Convert.ToDateTime(e.Element("Datum").Value);
                    stiznost.Typ_stiznosti = Convert.ToInt32(e.Element("Typ_stiznosti").Value);
                    stiznost.Vyrizena = Convert.ToChar(e.Element("Vyrizena").Value);
                }
            }
            return stiznost;
        }

        protected override int update(Stiznost stiznost, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(stiznostPath);
            var elements = from ele in xmlDoc.Elements("Stiznosti").Elements("Stiznost")
                           where ele != null && (ele.Element("Id_stiznosti").Value == stiznost.Id_stiznosti.ToString())
                           select ele;
            foreach (var e in elements)
            {
                e.Element("Id_zakaznika").Value = stiznost.Zakaznik.Id_zakaznika.ToString();
                e.Element("Id_zamestnance").Value = stiznost.Zamestnanec.Id_zamestnance.ToString();
                e.Element("Id_objednavky").Value = stiznost.Objednavka.Id_objednavky.ToString();
                e.Element("Datum").Value = stiznost.Datum.ToString();
                e.Element("Typ_stiznosti").Value = stiznost.Typ_stiznosti.ToString();
                e.Element("Vyrizena").Value = stiznost.Vyrizena.ToString();
            }

            xmlDoc.Save(stiznostPath);
            return stiznost.Id_stiznosti;
        }

        private int getLastId()
        {
            int lastId = 0;
            XDocument xmlDoc = XDocument.Load(stiznostPath);
            var elements = from ele in xmlDoc.Elements("Stiznosti").Elements("Stiznost")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                lastId = Convert.ToInt32(e.Element("Id_stiznosti").Value);
            }
            return lastId;
        }

        private static string getPath()
        {
            if (HttpContext.Current != null)
            {
                return Directory.GetParent(HttpContext.Current.Server.MapPath("")).Parent.FullName + "\\Restaurace\\Databaze\\Stiznosti.xml";
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Databaze\\Stiznosti.xml";
            }
        }
    }
}
