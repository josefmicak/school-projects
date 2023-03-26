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
    public partial class SpravaObjednavek : System.Web.UI.Page
    {
        ObjednavkaLogika objednavkaLogika = new ObjednavkaLogika();
        Collection<Objednavka> seznamObjednavek;
        ZamestnanecLogika zamestnanecLogika = new ZamestnanecLogika();
        Collection<Zamestnanec> seznamZamestnancu;
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        RozvazkaLogika rozvazkaLogika = new RozvazkaLogika();
        int zakaznikId;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            zakaznikId = int.Parse(Request.QueryString["zakaznikId"]);
            seznamZamestnancu = zamestnanecLogika.getSeznamZamestnancu();
            welcomeText.Text = "Vítejte, " + jmenoZakaznika();
            reload();

            if (!Page.IsPostBack)
            {
                pridatInitRadek();
            }
        }

        private void pridatInitRadek()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("polozka", typeof(string)));
            dt.Columns.Add(new DataColumn("cena", typeof(string)));
            dr = dt.NewRow();
            dr["polozka"] = "Test";
            dr["cena"] = "0 Kč";
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        private void pridatNovyRadek(string nazevPolozky, int cenaPolozky)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["polozka"] = nazevPolozky;
                    drCurrentRow["cena"] = cenaPolozky + " Kč";
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                GridView2.DataSource = dtCurrentTable;
                GridView2.DataBind();
            }
        }

        public void nacistObjednavky()
        {
            int pocet = 0;

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("datumVytvoreni", typeof(string));
                dt.Columns.Add("cena", typeof(string));
                dt.Columns.Add("zamestnanecKuchar", typeof(string));
                dt.Columns.Add("zamestnanecRidic", typeof(string));
                dt.Columns.Add("idObjednavky", typeof(string));
                dt.Columns.Add("idZamestnanceKuchar", typeof(string));
                dt.Columns.Add("idZamestnanceRidic", typeof(string));
            }
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                if (zakaznikId != seznamObjednavek[i].Zakaznik.Id_zakaznika)
                {
                    continue;
                }
                DataRow NewRow = dt.NewRow();
                NewRow[0] = seznamObjednavek[i].Datum_vytvoreni;
                NewRow[1] = seznamObjednavek[i].Cena + " Kč";
                NewRow[2] = getJmenoZamestnance(seznamObjednavek[i].Zamestnanec.Id_zamestnance);
                seznamObjednavek[i].Rozvazka.Zamestnanec = new Zamestnanec();
                int idRozvazky = seznamObjednavek[i].Rozvazka.Id_rozvazky;
                Rozvazka rozvazka = rozvazkaLogika.Select(idRozvazky);
                NewRow[3] = getJmenoZamestnance(rozvazka.Zamestnanec.Id_zamestnance);
                NewRow[4] = seznamObjednavek[i].Id_objednavky;
                NewRow[5] = seznamObjednavek[i].Zamestnanec.Id_zamestnance;
                NewRow[6] = rozvazka.Zamestnanec.Id_zamestnance;
                pocet++;
                dt.Rows.Add(NewRow);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (pocet == 0)
            {
                infoText.Text = "Nenalezli jsme žádné vámi vytvořené objednávky.";
            }
        }

        protected void vytvoritObjednavkuButton_Click(object sender, EventArgs e)
        {
            if (vypocitatCenu() < 1)
            {
                infoText.Text = "Nevybral jste žádné položky. Objednávka nebyla vytvořena.";
            }
            else
            {
                Objednavka objednavka = new Objednavka();
                objednavka.Id_objednavky = lastIdObjednavka() + 1;
                objednavka.Zakaznik = new Zakaznik();
                objednavka.Zakaznik.Id_zakaznika = zakaznikId;
                objednavka.Zamestnanec = new Zamestnanec();
                objednavka.Zamestnanec.Id_zamestnance = 0;
                objednavka.Rozvazka = new Rozvazka();
                objednavka.Rozvazka.Id_rozvazky = 0;
                objednavka.Datum_vytvoreni = DateTime.Now;
                objednavka.Cena = vypocitatCenu();
                objednavka.Vyplacena = 'N';
                objednavkaLogika.Insert(objednavka, true);
                seznamObjednavek.Add(objednavka);
                Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=1");
            }
        }

        public void soucasnaObjednavka(string nazevPolozky, int cenaPolozky)
        {
            if (dt2.Columns.Count == 0)
            {
                dt2.Columns.Add("polozka", typeof(string));
                dt2.Columns.Add("cena", typeof(string));
            }

            DataRow NewRow = dt2.NewRow();
            NewRow[0] = nazevPolozky;
            NewRow[1] = cenaPolozky + " Kč";
            dt2.Rows.Add(NewRow);

            GridView2.DataSource = dt2;
            GridView2.DataBind();
        }

        public int lastIdObjednavka()
        {
            int lastId = 0;
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                lastId = seznamObjednavek[i].Id_objednavky;
            }
            return lastId;
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

        public string getJmenoZamestnance(int idZamestnance)
        {
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (idZamestnance == seznamZamestnancu[i].Id_zamestnance)
                {
                    if (seznamZamestnancu[i].Jmeno == "TEMP")
                    {
                        return "Zpracovává se";
                    }
                    else
                    {
                        return seznamZamestnancu[i].Jmeno + " " + seznamZamestnancu[i].Prijmeni;
                    }
                }
            }
            return "Chyba";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Objednavka objednavka = najitObjednavku(Convert.ToInt32(GridView1.DataKeys[index].Values[0]));
            int objednavkaId = objednavka.Id_objednavky;
            int zamestnanecKucharId = Convert.ToInt32(GridView1.DataKeys[index].Values[1]);
            int zamestnanecRidicId = Convert.ToInt32(GridView1.DataKeys[index].Values[2]);
            if (e.CommandName == "storno")
            {
                try
                {
                    objednavkaLogika.Storno(objednavka);
                    reload();
                    seznamObjednavek.Remove(objednavka);
                    infoText.Text = "Objednávka byla úspěšně stornována.";
                }
                catch (Exception ex)
                {
                    infoText.Text = ex.Message;
                }
            }
            else
            {
                if (zamestnanecKucharId == 0)
                {
                    infoText.Text = "Zaměstnanec nebyl k této objednávce zatím přiřazen, operaci nelze provést.";
                }
                else
                {
                    if (e.CommandName == "hodnoceniKuchar")
                    {
                        Response.Redirect("SpravaHodnoceni.aspx?zakaznikId=" + zakaznikId + "&zamestnanecId=" + zamestnanecKucharId + "&objednavkaId=" + objednavkaId);
                    }
                    else if (e.CommandName == "stiznostKuchar")
                    {
                        Response.Redirect("SpravaStiznosti.aspx?zakaznikId=" + zakaznikId + "&zamestnanecId=" + zamestnanecKucharId + "&objednavkaId=" + objednavkaId);
                    }
                    else if (e.CommandName == "hodnoceniRidic")
                    {
                        Response.Redirect("SpravaHodnoceni.aspx?zakaznikId=" + zakaznikId + "&zamestnanecId=" + zamestnanecRidicId + "&objednavkaId=" + objednavkaId);
                    }
                    else if (e.CommandName == "stiznostRidic")
                    {
                        Response.Redirect("SpravaStiznosti.aspx?zakaznikId=" + zakaznikId + "&zamestnanecId=" + zamestnanecRidicId + "&objednavkaId=" + objednavkaId);
                    }
                }
            }
        }

        public void reload()
        {
            dt.Clear();
            seznamObjednavek = objednavkaLogika.Select();
            GridView1.DataSource = new DataTable();
            GridView1.DataBind();
            nacistObjednavky();
        }

        public Objednavka najitObjednavku(int idObjednavky)
        {
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                if (seznamObjednavek[i].Id_objednavky == idObjednavky)
                {
                    return seznamObjednavek[i];
                }
            }
            return null;
        }

        protected void profilLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpravaProfilu.aspx?zakaznikId=" + zakaznikId);
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            GridView2.Rows[0].Visible = false;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "odebrat")
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                dtCurrentTable.Rows[index].Delete();
                ViewState["CurrentTable"] = dtCurrentTable;
                GridView2.DataSource = dtCurrentTable;
                GridView2.DataBind();
                cenaObjednavkyLabel.Text = "Cena objednávky: " + vypocitatCenu() + " Kč";
            }
        }

        public void pridaniPolozky(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "1":
                    pridatNovyRadek("Pizza, 400 g", 149);
                    break;
                case "2":
                    pridatNovyRadek("Kuřecí křídla, 150 g", 139);
                    break;
                case "3":
                    pridatNovyRadek("Hovězí hamburger, 150 g", 169);
                    break;
                case "4":
                    pridatNovyRadek("Hranolky, 200 g", 55);
                    break;
                case "5":
                    pridatNovyRadek("Krokety, 200 g", 55);
                    break;
                case "6":
                    pridatNovyRadek("Zeleninový salát, 100 g", 55);
                    break;
                case "7":
                    pridatNovyRadek("Pepsi plechovka, 0,55l", 30);
                    break;
                case "8":
                    pridatNovyRadek("Sprite plechovka, 0,55l", 30);
                    break;
                case "9":
                    pridatNovyRadek("Radegast plechovka, 0,55l", 30);
                    break;
            }
            cenaObjednavkyLabel.Text = "Cena objednávky: " + vypocitatCenu() + " Kč";
        }

        public int vypocitatCenu()
        {
            int cenaObjednavky = 0;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string[] hodnotaObjednavky = GridView2.Rows[i].Cells[1].Text.Split(' ');
                cenaObjednavky += int.Parse(hodnotaObjednavky[0]);
            }
            return cenaObjednavky;
        }

        protected void menuLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=0");
        }
    }
}