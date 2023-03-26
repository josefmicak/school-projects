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
    class HodnoceniTable : HodnoceniProxy
    {
        string hodnoceniPath = getPath();
        protected override int delete(int idHodnoceni, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            var elements = from ele in xmlDoc.Elements("SeznamHodnoceni").Elements("UdeleneHodnoceni")
                           where ele != null && (ele.Element("Id_hodnoceni").Value == idHodnoceni.ToString())
                           select ele;

            foreach (var e in elements)
            {
                e.Remove();
            }

            xmlDoc.Save(hodnoceniPath);
            return idHodnoceni;
        }

        protected override int insert(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            xmlDoc.Elements("SeznamHodnoceni")
            .First().Add(
                new XElement("UdeleneHodnoceni",
                new XElement("Id_hodnoceni", getLastId() + 1),
                new XElement("Id_zakaznika", hodnoceni.Zakaznik.Id_zakaznika),
                new XElement("Id_zamestnance", hodnoceni.Zamestnanec.Id_zamestnance),
                new XElement("Id_objednavky", hodnoceni.Objednavka.Id_objednavky),
                new XElement("Datum", hodnoceni.Datum),
                new XElement("Hodnoceni", hodnoceni.Udelene_hodnoceni)
                ));
            xmlDoc.Save(hodnoceniPath);
            return hodnoceni.Id_hodnoceni;
        }

        protected override Collection<Hodnoceni> select(DatabaseProxy pDb = null)
        {
            Collection<Hodnoceni> seznamHodnoceni = new Collection<Hodnoceni>();
            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            var elements = from ele in xmlDoc.Elements("SeznamHodnoceni").Elements("UdeleneHodnoceni")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                Hodnoceni hodnoceni = new Hodnoceni();
                hodnoceni.Id_hodnoceni = Convert.ToInt32(e.Element("Id_hodnoceni").Value);
                hodnoceni.Zakaznik = new Zakaznik();
                hodnoceni.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                hodnoceni.Zamestnanec = new Zamestnanec();
                hodnoceni.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                hodnoceni.Objednavka = new Objednavka();
                hodnoceni.Objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                hodnoceni.Datum = Convert.ToDateTime(e.Element("Datum").Value);
                hodnoceni.Udelene_hodnoceni = Convert.ToInt32(e.Element("Hodnoceni").Value);
                seznamHodnoceni.Add(hodnoceni);
            }

            return seznamHodnoceni;
        }

        protected override Hodnoceni select(int idHodnoceni, DatabaseProxy pDb = null)
        {
            Hodnoceni hodnoceni = new Hodnoceni();

            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            var elements = from ele in xmlDoc.Elements("SeznamHodnoceni").Elements("UdeleneHodnoceni")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                if (idHodnoceni == Convert.ToInt32(e.Element("Id_hodnoceni").Value))
                {
                    hodnoceni.Id_hodnoceni = Convert.ToInt32(e.Element("Id_hodnoceni").Value);
                    hodnoceni.Zakaznik = new Zakaznik();
                    hodnoceni.Zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                    hodnoceni.Zamestnanec = new Zamestnanec();
                    hodnoceni.Zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                    hodnoceni.Objednavka = new Objednavka();
                    hodnoceni.Objednavka.Id_objednavky = Convert.ToInt32(e.Element("Id_objednavky").Value);
                    hodnoceni.Datum = Convert.ToDateTime(e.Element("Datum").Value);
                    hodnoceni.Udelene_hodnoceni = Convert.ToInt32(e.Element("Hodnoceni").Value);
                }
            }
            return hodnoceni;
        }

        protected override int update(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            var elements = from ele in xmlDoc.Elements("SeznamHodnoceni").Elements("UdeleneHodnoceni")
                           where ele != null && (ele.Element("Id_hodnoceni").Value == hodnoceni.Id_hodnoceni.ToString())
                           select ele;
            foreach (var e in elements)
            {
                e.Element("Id_zakaznika").Value = hodnoceni.Zakaznik.Id_zakaznika.ToString();
                e.Element("Id_zamestnance").Value = hodnoceni.Zamestnanec.Id_zamestnance.ToString();
                e.Element("Id_objednavky").Value = hodnoceni.Objednavka.Id_objednavky.ToString();
                e.Element("Datum").Value = hodnoceni.Datum.ToString();
                e.Element("Hodnoceni").Value = hodnoceni.Udelene_hodnoceni.ToString();
            }

            xmlDoc.Save(hodnoceniPath);
            return hodnoceni.Id_hodnoceni;
        }

        private int getLastId()
        {
            int lastId = 0;
            XDocument xmlDoc = XDocument.Load(hodnoceniPath);
            var elements = from ele in xmlDoc.Elements("SeznamHodnoceni").Elements("UdeleneHodnoceni")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                lastId = Convert.ToInt32(e.Element("Id_hodnoceni").Value);
            }
            return lastId;
        }

        private static string getPath()
        {
            if (HttpContext.Current != null)
            {
                return Directory.GetParent(HttpContext.Current.Server.MapPath("")).Parent.FullName + "\\Restaurace\\Databaze\\Hodnoceni.xml";
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Databaze\\Hodnoceni.xml";
            }
        }
    }
}
