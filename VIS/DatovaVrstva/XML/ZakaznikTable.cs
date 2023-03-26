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
    class ZakaznikTable : ZakaznikProxy
    {
        string zakazniciPath = getPath();
        protected override int delete(int idZakaznika, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            var elements = from ele in xmlDoc.Elements("Zakaznici").Elements("Zakaznik")
                           where ele != null && (ele.Element("Id_zakaznika").Value == idZakaznika.ToString())
                           select ele;

            foreach (var e in elements)
            {
                e.Remove();
            }

            xmlDoc.Save(zakazniciPath);
            return idZakaznika;
        }

        protected override int insert(Zakaznik zakaznik, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            xmlDoc.Elements("Zakaznici")
            .First().Add(
                new XElement("Zakaznik",
                new XElement("Id_zakaznika", getLastId() + 1),
                new XElement("Jmeno", zakaznik.Jmeno),
                new XElement("Prijmeni", zakaznik.Prijmeni),
                new XElement("Adresa", zakaznik.Adresa),
                new XElement("Telefonni_cislo", zakaznik.Telefonni_cislo),
                new XElement("Neaktivni", zakaznik.Neaktivni),
                new XElement("Kategorie", zakaznik.Kategorie),
                new XElement("V_blacklistu", zakaznik.V_blacklistu),
                new XElement("Zrusen", zakaznik.Zrusen),
                new XElement("Email", zakaznik.Email),
                new XElement("Heslo", zakaznik.Heslo)
                ));
            xmlDoc.Save(zakazniciPath);
            return zakaznik.Id_zakaznika;
        }

        protected override Collection<Zakaznik> select(DatabaseProxy pDb = null)
        {
            Collection<Zakaznik> seznamZakazniku = new Collection<Zakaznik>();
            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            var elements = from ele in xmlDoc.Elements("Zakaznici").Elements("Zakaznik")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                Zakaznik zakaznik = new Zakaznik();
                zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                zakaznik.Jmeno = Convert.ToString(e.Element("Jmeno").Value);
                zakaznik.Prijmeni = Convert.ToString(e.Element("Prijmeni").Value);
                zakaznik.Adresa = Convert.ToString(e.Element("Adresa").Value);
                zakaznik.Telefonni_cislo = Convert.ToString(e.Element("Telefonni_cislo").Value);
                zakaznik.Neaktivni = Convert.ToChar(e.Element("Neaktivni").Value);
                zakaznik.Kategorie = Convert.ToInt32(e.Element("Kategorie").Value);
                zakaznik.V_blacklistu = Convert.ToString(e.Element("V_blacklistu").Value);
                zakaznik.Zrusen = Convert.ToString(e.Element("Zrusen").Value);
                zakaznik.Email = Convert.ToString(e.Element("Email").Value);
                zakaznik.Heslo = Convert.ToString(e.Element("Heslo").Value);
                seznamZakazniku.Add(zakaznik);
            }

            return seznamZakazniku;
        }

        protected override Zakaznik select(int idZakaznika, DatabaseProxy pDb = null)
        {
            Zakaznik zakaznik = new Zakaznik();

            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            var elements = from ele in xmlDoc.Elements("Zakaznici").Elements("Zakaznik")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                if (idZakaznika == Convert.ToInt32(e.Element("Id_zakaznika").Value))
                {
                    zakaznik.Id_zakaznika = Convert.ToInt32(e.Element("Id_zakaznika").Value);
                    zakaznik.Jmeno = Convert.ToString(e.Element("Jmeno").Value);
                    zakaznik.Prijmeni = Convert.ToString(e.Element("Prijmeni").Value);
                    zakaznik.Adresa = Convert.ToString(e.Element("Adresa").Value);
                    zakaznik.Telefonni_cislo = Convert.ToString(e.Element("Telefonni_cislo").Value);
                    zakaznik.Neaktivni = Convert.ToChar(e.Element("Neaktivni").Value);
                    zakaznik.Kategorie = Convert.ToInt32(e.Element("Kategorie").Value);
                    zakaznik.V_blacklistu = Convert.ToString(e.Element("V_blacklistu").Value);
                    zakaznik.Zrusen = Convert.ToString(e.Element("Zrusen").Value);
                    zakaznik.Email = Convert.ToString(e.Element("Email").Value);
                    zakaznik.Heslo = Convert.ToString(e.Element("Heslo").Value);
                }
            }
            return zakaznik;
        }

        protected override int update(Zakaznik zakaznik, DatabaseProxy pDb = null)
        {
            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            var elements = from ele in xmlDoc.Elements("Zakaznici").Elements("Zakaznik")
                           where ele != null && (ele.Element("Id_zakaznika").Value == zakaznik.Id_zakaznika.ToString())
                           select ele;
            foreach (var e in elements)
            {
                e.Element("Jmeno").Value = zakaznik.Jmeno;
                e.Element("Prijmeni").Value = zakaznik.Prijmeni;
                e.Element("Adresa").Value = zakaznik.Adresa;
                e.Element("Telefonni_cislo").Value = zakaznik.Telefonni_cislo;
                e.Element("Neaktivni").Value = zakaznik.Neaktivni.ToString();
                e.Element("Kategorie").Value = zakaznik.Kategorie.ToString();
                e.Element("V_blacklistu").Value = zakaznik.V_blacklistu;
                e.Element("Zrusen").Value = zakaznik.Zrusen;
                e.Element("Email").Value = zakaznik.Email;
                e.Element("Heslo").Value = zakaznik.Heslo;
            }

            xmlDoc.Save(zakazniciPath);
            return zakaznik.Id_zakaznika;
        }

        private int getLastId()
        {
            int lastId = 0;
            XDocument xmlDoc = XDocument.Load(zakazniciPath);
            var elements = from ele in xmlDoc.Elements("Zakaznici").Elements("Zakaznik")
                           where ele != null
                           select ele;
            foreach (var e in elements)
            {
                lastId = Convert.ToInt32(e.Element("Id_zakaznika").Value);
            }
            return lastId;
        }

        private static string getPath()
        {
            if (HttpContext.Current != null)
            {
                return Directory.GetParent(HttpContext.Current.Server.MapPath("")).Parent.FullName + "\\Restaurace\\Databaze\\Zakaznici.xml";
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Databaze\\Zakaznici.xml";
            }
        }
    }
}
