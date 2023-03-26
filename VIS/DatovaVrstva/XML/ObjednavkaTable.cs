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
    class ObjednavkaTable : ObjednavkaProxy
    {
        string objednavkyPath = getPath();
        protected override int delete(int idObjednavky, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            var elements = from ele in xmlDoc.Elements("Objednavky").Elements("Objednavka")
                           where ele != null && (ele.Element("Id_objednavky").Value == idObjednavky.ToString())
                           select ele;

            foreach (var e in elements)
            {
                e.Remove();
            }

            xmlDoc.Save(objednavkyPath);
            return idObjednavky;
        }

        protected override int insert(Objednavka objednavka, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            xmlDoc.Elements("Objednavky")
            .First().Add(
                new XElement("Objednavka",
                new XElement("Id_objednavky", getLastId() + 1),
                new XElement("Id_zakaznika", objednavka.Zakaznik.Id_zakaznika),
                new XElement("Id_zamestnance", objednavka.Zamestnanec.Id_zamestnance),
                new XElement("Id_rozvazky", objednavka.Rozvazka.Id_rozvazky),
                new XElement("Datum_vytvoreni", objednavka.Datum_vytvoreni),
                new XElement("Cena", objednavka.Cena),
                new XElement("Vyplacena", objednavka.Vyplacena)
                ));
            xmlDoc.Save(objednavkyPath);
            return objednavka.Id_objednavky;
        }

        protected override Collection<Objednavka> select(DatabaseProxy pDb = null)
        {
            Collection<Objednavka> seznamObjednavek = new Collection<Objednavka>();
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            var elements = from ele in xmlDoc.Elements("Objednavky").Elements("Objednavka")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                Objednavka objednavka = new Objednavka();
                objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                objednavka.Zakaznik = new Zakaznik();
                objednavka.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                objednavka.Zamestnanec = new Zamestnanec();
                objednavka.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                objednavka.Rozvazka = new Rozvazka();
                objednavka.Rozvazka.Id_rozvazky = Convert.ToInt32(e.Element("Id_rozvazky").Value);
                objednavka.Datum_vytvoreni = Convert.ToDateTime(e.Element("Datum_vytvoreni").Value);
                objednavka.Cena = Convert.ToInt32(e.Element("Cena").Value);
                objednavka.Vyplacena = Convert.ToChar(e.Element("Vyplacena").Value);
                seznamObjednavek.Add(objednavka);
            }
            return seznamObjednavek;
        }

        protected override Objednavka select(int idObjednavky, DatabaseProxy pDb = null)
        {
            Objednavka objednavka = new Objednavka();
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            var elements = from ele in xmlDoc.Elements("Objednavky").Elements("Objednavka")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                if (idObjednavky == Convert.ToInt32(e.Element("Id_objednavky").Value))
                {
                    objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                    objednavka.Zakaznik = new Zakaznik();
                    objednavka.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                    objednavka.Zamestnanec = new Zamestnanec();
                    objednavka.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                    objednavka.Rozvazka = new Rozvazka();
                    objednavka.Rozvazka.Id_rozvazky = Convert.ToInt32(e.Element("Id_rozvazky").Value);
                    objednavka.Datum_vytvoreni = Convert.ToDateTime(e.Element("Datum_vytvoreni").Value);
                    objednavka.Cena = Convert.ToInt32(e.Element("Cena").Value);
                    objednavka.Vyplacena = Convert.ToChar(e.Element("Vyplacena").Value);
                }
            }
            return objednavka;
        }

        protected override int update(Objednavka objednavka, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            var elements = from ele in xmlDoc.Elements("Objednavky").Elements("Objednavka")
                           where ele != null && (ele.Element("Id_objednavky").Value == objednavka.Id_objednavky.ToString())
                           select ele;
            foreach (var e in elements)
            {
                e.Element("Id_zakaznika").Value = objednavka.Zakaznik.Id_zakaznika.ToString();
                e.Element("Id_zamestnance").Value = objednavka.Zamestnanec.Id_zamestnance.ToString();
                e.Element("Id_rozvazky").Value = objednavka.Rozvazka.Id_rozvazky.ToString();
                e.Element("Datum_vytvoreni").Value = objednavka.Datum_vytvoreni.ToString();
                e.Element("Cena").Value = objednavka.Cena.ToString();
                e.Element("Vyplacena").Value = objednavka.Vyplacena.ToString();
            }
            xmlDoc.Save(objednavkyPath);
            return objednavka.Id_objednavky;
        }

        private int getLastId()
        {
            int lastId = 0;
            XDocument xmlDoc = XDocument.Load(objednavkyPath);
            var elements = from ele in xmlDoc.Elements("Objednavky").Elements("Objednavka")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                lastId = Convert.ToInt32(e.Element("Id_objednavky").Value);
            }
            return lastId;
        }

        private static string getPath()
        {
            if (HttpContext.Current != null)
            {
                return Directory.GetParent(HttpContext.Current.Server.MapPath("")).Parent.FullName + "\\Restaurace\\Databaze\\Objednavky.xml";
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Databaze\\Objednavky.xml";
            }
        }
    }
}
