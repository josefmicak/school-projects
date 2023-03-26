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
    public partial class SpravaProfilu : System.Web.UI.Page
    {
        int zakaznikId;
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        Zakaznik prihlasenyZakaznik = new Zakaznik();
        Collection<Zakaznik> seznamZakazniku;
        protected void Page_Load(object sender, EventArgs e)
        {
            zakaznikId = int.Parse(Request.QueryString["zakaznikId"]);
            seznamZakazniku = zakaznikLogika.getSeznamZakazniku();
            prihlasenyZakaznik = getPrihlasenyZakaznik(zakaznikId);
            soucasneHesloTB.Attributes["value"] = soucasneHesloTB.Text;

            if (!Page.IsPostBack)
            {
                udajeZakaznika(zakaznikId);
                welcomeText.Text = "Vítejte, " + jmenoZakaznika();
            }
        }

        public void udajeZakaznika(int zakaznikId)
        {
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (zakaznikId != seznamZakazniku[i].Id_zakaznika)
                {
                    continue;
                }

                emailTB.Text = seznamZakazniku[i].Email;
                jmenoTB.Text = seznamZakazniku[i].Jmeno;
                prijmeniTB.Text = seznamZakazniku[i].Prijmeni;
                adresaTB.Text = seznamZakazniku[i].Adresa;
                telefonniCisloTB.Text = seznamZakazniku[i].Telefonni_cislo;
            }
        }

        public Zakaznik getPrihlasenyZakaznik(int zakaznikId)
        {
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (zakaznikId != seznamZakazniku[i].Id_zakaznika)
                {
                    continue;
                }
                else
                {
                    return seznamZakazniku[i];
                }
            }
            return null;
        }

        protected void ulozitZmeny_Click(object sender, EventArgs e)
        {
            if (jsouUdajeVyplnene())
            {
                if (soucasneHesloTB.Text.Length > 0 && noveHesloTB.Text.Length > 0)
                {
                    try
                    {
                        zakaznikLogika.upravitHeslo(prihlasenyZakaznik, soucasneHesloTB.Text, noveHesloTB.Text, noveHesloPotvrzeniTB.Text);
                        Zakaznik zakaznik = zakaznikLogika.Select(zakaznikId);
                        zakaznik.Jmeno = jmenoTB.Text;
                        zakaznik.Prijmeni = prijmeniTB.Text;
                        zakaznik.Adresa = adresaTB.Text;
                        zakaznik.Telefonni_cislo = telefonniCisloTB.Text;
                        zakaznik.Email = emailTB.Text;
                        zakaznik.Heslo = noveHesloTB.Text;
                        zakaznikLogika.Update(zakaznik);
                        nahraditZakaznika(zakaznik, true);

                        Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=2");
                    }
                    catch (Exception ex)
                    {
                        infoText.Text = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        Zakaznik zakaznik = zakaznikLogika.Select(zakaznikId);
                        zakaznik.Jmeno = jmenoTB.Text;
                        zakaznik.Prijmeni = prijmeniTB.Text;
                        zakaznik.Adresa = adresaTB.Text;
                        zakaznik.Telefonni_cislo = telefonniCisloTB.Text;
                        zakaznik.Email = emailTB.Text;
                        zakaznikLogika.Update(zakaznik);
                        nahraditZakaznika(zakaznik, false);
                        Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznikId + "&infoText=2");
                    }
                    catch (Exception ex)
                    {
                        infoText.Text = ex.Message;
                    }
                }
            }
            else
            {
                infoText.Text = "Je potřeba vyplnit všechny údaje. Váš profil nebyl aktualizován.";
            }
        }

        public void nahraditZakaznika(Zakaznik zakaznik, bool nahraditHeslo)
        {
            int index = 0;
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (seznamZakazniku[i].Id_zakaznika == zakaznik.Id_zakaznika)
                {
                    index = i;
                    break;
                }
            }

            Zakaznik updatnutyZakaznik = zakaznik;
            updatnutyZakaznik.Jmeno = jmenoTB.Text;
            updatnutyZakaznik.Prijmeni = prijmeniTB.Text;
            updatnutyZakaznik.Adresa = adresaTB.Text;
            updatnutyZakaznik.Telefonni_cislo = telefonniCisloTB.Text;
            updatnutyZakaznik.Email = emailTB.Text;
            if (nahraditHeslo)
            {
                updatnutyZakaznik.Heslo = noveHesloTB.Text;
            }
            seznamZakazniku.RemoveAt(index);
            seznamZakazniku.Insert(index, updatnutyZakaznik);
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

        public bool jsouUdajeVyplnene()
        {
            if (jmenoTB.Text.Length > 0 && prijmeniTB.Text.Length > 0 && adresaTB.Text.Length > 0 && telefonniCisloTB.Text.Length > 0 && emailTB.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        protected void vymazatUcet_Click(object sender, EventArgs e)
        {
            string text = "Smazání účtu je nevratná operace, váš účet bude smazán. Pro potvrzení stiskněte znovu tlačítko \"Smazat účet\"";

            if (soucasneHesloTB.Text == prihlasenyZakaznik.Heslo)
            {
                if (infoText.Text != text)
                {
                    infoText.Text = text;
                }
                else
                {
                    Zakaznik zakaznik = prihlasenyZakaznik;
                    zakaznik.Zrusen = "Y";
                    zakaznikLogika.Update(zakaznik);
                    Response.Redirect("UvodniStranka.aspx?infoText=1");
                }
            }
            else
            {
                infoText.Text = "Pro smazání účtu je nutné zadat současné heslo.";
            }
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