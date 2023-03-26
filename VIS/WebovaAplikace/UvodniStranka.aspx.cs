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
    public partial class UvodniStranka : System.Web.UI.Page
    {
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["infoText"] != null)
                {
                    switch (int.Parse(Request.QueryString["infoText"]))
                    {
                        case 1:
                            infoText.Text = "Váš účet byl vymazán.";
                            break;
                        case 2:
                            infoText.Text = "Váš účet je deaktivován. Pro umožnění přístupu na účet prosím kontaktujte administrátora.";
                            break;
                    }
                }

            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                Zakaznik zakaznik = zakaznikLogika.Login(emailTB.Text, hesloTB.Text);
                Response.Redirect("HlavniMenu.aspx?zakaznikId=" + zakaznik.Id_zakaznika + "&infoText=0");
            }
            catch (Exception ex)
            {
                infoText.Text = ex.Message;
            }
        }

        protected void registraceButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrace.aspx");
        }
    }
}