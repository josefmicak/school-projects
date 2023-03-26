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
    public partial class SpravaStiznosti : System.Web.UI.Page
    {
        int zakaznikId;
        int objednavkaId;
        int zamestnanecId;
        StiznostLogika stiznostLogika = new StiznostLogika();
        Collection<Stiznost> seznamStiznosti;
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
            seznamStiznosti = stiznostLogika.getSeznamStiznosti();
            welcomeText.Text = "Vítejte, " + jmenoZakaznika();
            if (!Page.IsPostBack)
            {
                for (int i = 1; i <= 6; i++)
                {
                    typStiznostiDDL.Items.Add(getTypStiznosti(i));
                }
                nacistStiznosti();
                inicializaceSouhrnu();
            }
        }

        public void inicializaceSouhrnu()
        {
            jmenoZamestnance.Text = getJmenoZamestnance(zamestnanecId);
            Objednavka objednavka = getObjednavka();
            datumVytvoreni.Text = objednavka.Datum_vytvoreni.ToString();
            cenaObjednavky.Text = objednavka.Cena.ToString() + " Kč";
        }

        public void nacistStiznosti()
        {
            DataTable dt = new DataTable();
            int pocet = 0;

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("datumVytvoreni", typeof(string));
                dt.Columns.Add("zamestnanec", typeof(string));
                dt.Columns.Add("typStiznosti", typeof(string));
            }
            for (int i = 0; i < seznamStiznosti.Count; i++)
            {
                if (zakaznikId != seznamStiznosti[i].Zakaznik.Id_zakaznika)
                {
                    continue;
                }
                DataRow NewRow = dt.NewRow();
                NewRow[0] = seznamStiznosti[i].Datum;
                NewRow[1] = getJmenoZamestnance(seznamStiznosti[i].Zamestnanec.Id_zamestnance);
                NewRow[2] = getTypStiznosti(seznamStiznosti[i].Typ_stiznosti);
                pocet++;
                dt.Rows.Add(NewRow);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (pocet == 0)
            {
                stiznostiNenalezeny.Text = "Nenalezli jsme žádné vámi vytvořené stížnosti.";
            }
        }

        protected void odeslatStiznost_Click(object sender, EventArgs e)
        {
            Stiznost stiznost = new Stiznost();
            stiznost.Id_stiznosti = lastIdStiznost() + 1;
            stiznost.Zakaznik = new Zakaznik();
            stiznost.Zakaznik.Id_zakaznika = zakaznikId;
            stiznost.Zamestnanec = new Zamestnanec();
            stiznost.Zamestnanec.Id_zamestnance = zamestnanecId;
            stiznost.Objednavka = new Objednavka();
            stiznost.Objednavka.Id_objednavky = objednavkaId;
            stiznost.Datum = DateTime.Now;
            stiznost.Typ_stiznosti = typStiznostiDDL.SelectedIndex + 1;
            stiznost.Vyrizena = 'N';
            stiznostLogika.Insert(stiznost);
            seznamStiznosti.Add(stiznost);
            Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=4");
        }

        public int lastIdStiznost()
        {
            int lastId = 0;
            for (int i = 0; i < seznamStiznosti.Count; i++)
            {
                lastId = seznamStiznosti[i].Id_stiznosti;
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

        public string getTypStiznosti(int idStiznosti)
        {
            switch (idStiznosti)
            {
                case 1:
                    return "Nevhodné chování";
                case 2:
                    return "Nedostatečná kvalita objednávky";
                case 3:
                    return "Nedostatečná rychlost dodání objednávky";
                case 4:
                    return "Vydání špatného množství peněz po zaplacení";
                case 5:
                    return "Chybějící část objednávky";
                case 6:
                    return "Jiné";
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
            Collection<Zakaznik> seznamZakazniku = zakaznikLogika.Select();
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