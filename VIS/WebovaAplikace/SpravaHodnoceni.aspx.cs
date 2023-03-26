using BusinessVrstva.Logika;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebovaAplikace
{
    public partial class SpravaHodnoceni : System.Web.UI.Page
    {
        int zakaznikId;
        int zamestnanecId;
        int objednavkaId;
        HodnoceniLogika hodnoceniLogika = new HodnoceniLogika();
        Collection<Hodnoceni> seznamHodnoceni;
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        ZamestnanecLogika zamestnanecLogika = new ZamestnanecLogika();
        Collection<Zamestnanec> seznamZamestnancu;
        ObjednavkaLogika objednavkaLogika = new ObjednavkaLogika();
        Collection<Objednavka> seznamObjednavek;

        protected void Page_Load(object sender, EventArgs e)
        {
            zakaznikId = int.Parse(Request.QueryString["zakaznikId"]);
            zamestnanecId = int.Parse(Request.QueryString["zamestnanecId"]);
            objednavkaId = int.Parse(Request.QueryString["objednavkaId"]);
            seznamZamestnancu = zamestnanecLogika.getSeznamZamestnancu();
            seznamObjednavek = objednavkaLogika.getSeznamObjednavek();
            seznamHodnoceni = hodnoceniLogika.getSeznamHodnoceni();
            welcomeText.Text = "Vítejte, " + jmenoZakaznika();
            if (!Page.IsPostBack)
            {
                inicializaceSouhrnu();
                nacistHodnoceni();
            }
        }

        public void inicializaceSouhrnu()
        {
            jmenoZamestnance.Text = getJmenoZamestnance(zamestnanecId);
            Objednavka objednavka = getObjednavka();
            datumVytvoreni.Text = objednavka.Datum_vytvoreni.ToString();
            cenaObjednavky.Text = objednavka.Cena.ToString() + " Kč";
        }

        public void nacistHodnoceni()
        {
            DataTable dt = new DataTable();
            int pocet = 0;

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("datumVytvoreni", typeof(string));
                dt.Columns.Add("zamestnanec", typeof(string));
                dt.Columns.Add("hodnoceni", typeof(string));
            }
            for (int i = 0; i < seznamHodnoceni.Count; i++)
            {
                if (zakaznikId != seznamHodnoceni[i].Zakaznik.Id_zakaznika)
                {
                    continue;
                }
                DataRow NewRow = dt.NewRow();
                NewRow[0] = seznamHodnoceni[i].Datum;
                NewRow[1] = getJmenoZamestnance(seznamHodnoceni[i].Zamestnanec.Id_zamestnance);
                NewRow[2] = seznamHodnoceni[i].Udelene_hodnoceni;
                pocet++;
                dt.Rows.Add(NewRow);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (pocet == 0)
            {
                hodnoceniNenalezena.Text = "Nenalezli jsme žádná vámi vytvořená hodnocení.";
            }
        }

        protected void odeslatHodnoceni_Click(object sender, EventArgs e)
        {
            Hodnoceni hodnoceni = new Hodnoceni();
            hodnoceni.Id_hodnoceni = lastIdHodnoceni() + 1;
            hodnoceni.Zakaznik = new Zakaznik();
            hodnoceni.Zakaznik.Id_zakaznika = zakaznikId;
            hodnoceni.Zamestnanec = new Zamestnanec();
            hodnoceni.Zamestnanec.Id_zamestnance = zamestnanecId;
            hodnoceni.Objednavka = new Objednavka();
            hodnoceni.Objednavka.Id_objednavky = objednavkaId;
            hodnoceni.Datum = DateTime.Now;
            hodnoceni.Udelene_hodnoceni = int.Parse(hodnoceniTB.Text);
            hodnoceniLogika.Insert(hodnoceni);
            seznamHodnoceni.Add(hodnoceni);
            Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=3");
        }

        public int lastIdHodnoceni()
        {
            int lastId = 0;
            for (int i = 0; i < seznamHodnoceni.Count; i++)
            {
                lastId = seznamHodnoceni[i].Id_hodnoceni;
            }
            return lastId;
        }

        public string getJmenoZamestnance(int idZamestnance)
        {
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (idZamestnance == seznamZamestnancu[i].Id_zamestnance)
                {
                    return seznamZamestnancu[i].Jmeno + " " + seznamZamestnancu[i].Prijmeni;
                }
            }
            return "Chyba";
        }

        public Objednavka getObjednavka()
        {
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                if (objednavkaId == seznamObjednavek[i].Id_objednavky)
                {
                    return seznamObjednavek[i];
                }
            }
            return null;
        }

        public string jmenoZakaznika()
        {
            Collection<Zakaznik> seznamZakazniku = zakaznikLogika.getSeznamZakazniku();
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (zakaznikId == seznamZakazniku[i].Id_zakaznika)
                {
                    return seznamZakazniku[i].Jmeno + " " + seznamZakazniku[i].Prijmeni;
                }
            }
            return "Chyba";
        }

        protected void profilLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpravaProfilu.aspx?zakaznikId=" + zakaznikId);
        }

        protected void menuLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=0");
        }
    }
}