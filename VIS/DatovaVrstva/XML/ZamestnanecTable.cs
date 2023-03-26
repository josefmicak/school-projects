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
    class ZamestnanecTable : ZamestnanecProxy
    {
        string zamestnanciPath = getPath();
        protected override int delete(int idZamestnance, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            var elements = from ele in xmlDoc.Elements("Zamestnanci").Elements("Zamestnanec")
                           where ele != null && (ele.Element("Id_zamestnance").Value == idZamestnance.ToString())
                           select ele;

            foreach (var e in elements)
            {
                e.Remove();
            }

            xmlDoc.Save(zamestnanciPath);
            return idZamestnance;
        }

        protected override int insert(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            xmlDoc.Elements("Zamestnanci")
            .First().Add(
                new XElement("Zamestnanec",
                new XElement("Id_zamestnance", getLastId() + 1),
                new XElement("Jmeno", zamestnanec.Jmeno),
                new XElement("Prijmeni", zamestnanec.Prijmeni),
                new XElement("Adresa", zamestnanec.Adresa),
                new XElement("Telefonni_cislo", zamestnanec.Telefonni_cislo),
                new XElement("Pohlavi", zamestnanec.Pohlavi),
                new XElement("Datum_narozeni", zamestnanec.Datum_narozeni),
                new XElement("Datum_nastupu", zamestnanec.Datum_nastupu),
                new XElement("Pozice", zamestnanec.Pozice),
                new XElement("Plat", zamestnanec.Plat),
                new XElement("Vyhozen", zamestnanec.Vyhozen)
                ));
            xmlDoc.Save(zamestnanciPath);
            return zamestnanec.Id_zamestnance;
        }

        protected override Collection<Zamestnanec> select(DatabaseProxy pDb = null)
        {
            Collection<Zamestnanec> seznamZamestnancu = new Collection<Zamestnanec>();
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            var elements = from ele in xmlDoc.Elements("Zamestnanci").Elements("Zamestnanec")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                zamestnanec.Jmeno = Convert.ToString(e.Element("Jmeno").Value);
                zamestnanec.Prijmeni = Convert.ToString(e.Element("Prijmeni").Value);
                zamestnanec.Adresa = Convert.ToString(e.Element("Adresa").Value);
                zamestnanec.Telefonni_cislo = Convert.ToString(e.Element("Telefonni_cislo").Value);
                zamestnanec.Pohlavi = Convert.ToChar(e.Element("Pohlavi").Value);
                zamestnanec.Datum_narozeni = Convert.ToDateTime(e.Element("Datum_narozeni").Value);
                zamestnanec.Datum_nastupu = Convert.ToDateTime(e.Element("Datum_nastupu").Value);
                zamestnanec.Pozice = Convert.ToString(e.Element("Pozice").Value);
                zamestnanec.Plat = Convert.ToInt32(e.Element("Plat").Value);
                zamestnanec.Vyhozen = Convert.ToString(e.Element("Vyhozen").Value);
                seznamZamestnancu.Add(zamestnanec);
            }

            return seznamZamestnancu;
        }

        protected override Zamestnanec select(int idZamestnance, DatabaseProxy pDb = null)
        {
            Zamestnanec zamestnanec = new Zamestnanec();
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            var elements = from ele in xmlDoc.Elements("Zamestnanci").Elements("Zamestnanec")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                if (idZamestnance == Convert.ToInt32(e.Element("Id_zamestnance").Value))
                {
                    zamestnanec.Id_zamestnance = Convert.ToInt32(e.Element("Id_zamestnance").Value);
                    zamestnanec.Jmeno = Convert.ToString(e.Element("Jmeno").Value);
                    zamestnanec.Prijmeni = Convert.ToString(e.Element("Prijmeni").Value);
                    zamestnanec.Adresa = Convert.ToString(e.Element("Adresa").Value);
                    zamestnanec.Telefonni_cislo = Convert.ToString(e.Element("Telefonni_cislo").Value);
                    zamestnanec.Pohlavi = Convert.ToChar(e.Element("Pohlavi").Value);
                    zamestnanec.Datum_narozeni = Convert.ToDateTime(e.Element("Datum_narozeni").Value);
                    zamestnanec.Datum_nastupu = Convert.ToDateTime(e.Element("Datum_nastupu").Value);
                    zamestnanec.Pozice = Convert.ToString(e.Element("Pozice").Value);
                    zamestnanec.Plat = Convert.ToInt32(e.Element("Plat").Value);
                    zamestnanec.Vyhozen = Convert.ToString(e.Element("Vyhozen").Value);
                }
            }
            return zamestnanec;
        }

        protected override int update(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            var elements = from ele in xmlDoc.Elements("Zamestnanci").Elements("Zamestnanec")
                           where ele != null && (ele.Element("Id_zamestnance").Value == zamestnanec.Id_zamestnance.ToString())
                           select ele;
            foreach (var e in elements)
            {
                e.Element("Jmeno").Value = zamestnanec.Jmeno;
                e.Element("Prijmeni").Value = zamestnanec.Prijmeni;
                e.Element("Adresa").Value = zamestnanec.Adresa;
                e.Element("Telefonni_cislo").Value = zamestnanec.Telefonni_cislo;
                e.Element("Pohlavi").Value = zamestnanec.Pohlavi.ToString();
                e.Element("Datum_narozeni").Value = zamestnanec.Datum_narozeni.ToString();
                e.Element("Datum_nastupu").Value = zamestnanec.Datum_nastupu.ToString();
                e.Element("Pozice").Value = zamestnanec.Pozice;
                e.Element("Plat").Value = zamestnanec.Plat.ToString();
                e.Element("Vyhozen").Value = zamestnanec.Vyhozen;
            }

            xmlDoc.Save(zamestnanciPath);
            return zamestnanec.Id_zamestnance;
        }

        private int getLastId()
        {
            int lastId = 0;
            XDocument xmlDoc = XDocument.Load(zamestnanciPath);
            var elements = from ele in xmlDoc.Elements("Zamestnanci").Elements("Zamestnanec")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                lastId = Convert.ToInt32(e.Element("Id_zamestnance").Value);
            }
            return lastId;
        }

        private static string getPath()
        {
            if (HttpContext.Current != null)
            {
                return Directory.GetParent(HttpContext.Current.Server.MapPath("")).Parent.FullName + "\\Restaurace\\Databaze\\Zamestnanci.xml";
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Databaze\\Zamestnanci.xml";
            }
        }
    }
}
