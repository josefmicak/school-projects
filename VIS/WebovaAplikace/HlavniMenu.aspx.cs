using BusinessVrstva.Logika;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebovaAplikace
{
    public partial class HlavniMenu : System.Web.UI.Page
    {
        int zakaznikId;
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        Collection<Zakaznik> seznamZakazniku;

        protected void Page_Load(object sender, EventArgs e)
        {
            zakaznikId = int.Parse(Request.QueryString["zakaznikId"]);
            if (!Page.IsPostBack)
            {
                seznamZakazniku = zakaznikLogika.getSeznamZakazniku();
                overitZruseni();
                welcomeText.Text = "Vítejte, " + jmenoZakaznika();

                switch (int.Parse(Request.QueryString["infoText"]))
                {
                    case 1:
                        infoText.Text = "Objednávka úspěšně vytvořena.";
                        break;
                    case 2:
                        infoText.Text = "Profil úspěšně upraven.";
                        break;
                    case 3:
                        infoText.Text = "Hodnocení úspěšně vytvořeno";
                        break;
                    case 4:
                        infoText.Text = "Stížnost úspěšně vytvořena";
                        break;
                }
            }
        }

        public void overitZruseni()
        {
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (zakaznikId == seznamZakazniku[i].Id_zakaznika && seznamZakazniku[i].Zrusen == "Y")
                {
                    Response.Redirect("UvodniStranka.aspx?infoText=2");
                    break;
                }
            }
        }

        protected void objednavkyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpravaObjednavek.aspx?zakaznikId=" + zakaznikId);
        }

        protected void profilButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpravaProfilu.aspx?zakaznikId=" + zakaznikId);
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