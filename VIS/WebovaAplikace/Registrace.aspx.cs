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
    public partial class Registrace : System.Web.UI.Page
    {
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        Collection<Zakaznik> seznamZakazniku;
        protected void Page_Load(object sender, EventArgs e)
        {
            seznamZakazniku = zakaznikLogika.getSeznamZakazniku();
        }

        protected void vytvoritUcetButton_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                infoText.Text = "Je třeba vyplnit všechny údaje.";
            }
            else if (hesloTB.Text.Length < 5)
            {
                infoText.Text = "Heslo musí obsahovat alespoň 5 znaků.";
            }
            else
            {
                try
                {
                    Zakaznik zakaznik = new Zakaznik();
                    zakaznik.Id_zakaznika = getLastId() + 1;
                    zakaznik.Jmeno = jmenoTB.Text;
                    zakaznik.Prijmeni = prijmeniTB.Text;
                    zakaznik.Adresa = adresaTB.Text;
                    zakaznik.Telefonni_cislo = telefonniCisloTB.Text;
                    zakaznik.Email = emailTB.Text;
                    zakaznik.Heslo = hesloTB.Text;
                    zakaznik.Neaktivni = 'N';
                    zakaznik.Kategorie = 1;
                    zakaznik.V_blacklistu = "N";
                    zakaznik.Zrusen = "N";
                    zakaznikLogika.Insert(zakaznik);
                    Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznik.Id_zakaznika + "&infoText=0");

                }
                catch (Exception ex)
                {
                    infoText.Text = ex.Message;
                }
            }
        }

        public bool jsouUdajeVyplnene()
        {
            if (jmenoTB.Text.Length > 0 && prijmeniTB.Text.Length > 0 && adresaTB.Text.Length > 0 && telefonniCisloTB.Text.Length > 0 && emailTB.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        public int getLastId()
        {
            int lastId = 0;
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                lastId = seznamZakazniku[i].Id_zakaznika;
            }
            return lastId;
        }
    }
}