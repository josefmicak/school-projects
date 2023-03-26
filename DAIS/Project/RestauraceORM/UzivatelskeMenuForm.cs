using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using RestauraceORM.Databaze.mssql;
using RestauraceORM.Databaze.Proxy;
using RestauraceORM.Databaze;

namespace RestauraceORM
{
    public partial class UzivatelskeMenuForm : Form
    {
        public UzivatelskeMenuForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Collection<Zamestnanec> zamestnanci = ZamestnanecProxy.Select();
            for (int i = 0; i < zamestnanci.Count; i++)
            {
                jmenoZamCB.Items.Add(zamestnanci[i].Jmeno + " " + zamestnanci[i].Prijmeni + " (ID : " + zamestnanci[i].Id_zamestnance + ")");
                jmenoZamCB2.Items.Add(zamestnanci[i].Jmeno + " " + zamestnanci[i].Prijmeni + " (ID : " + zamestnanci[i].Id_zamestnance + ")");
            }

            refreshGrid();
        }

        private void refreshGrid()
        {
            Zakaznik zakaznik = ZakaznikProxy.Select(9);
            jmenoLabel.Text = "Jméno: " + zakaznik.Jmeno;
            prijmeniLabel.Text = "Příjmení: " + zakaznik.Prijmeni;
            adresaLabel.Text = "Adresa: " + zakaznik.Adresa;
            telefonLabel.Text = "Telefon: " + zakaznik.Telefonni_cislo;
          
            dataGridView1.Rows.Clear();
            Collection<Hodnoceni> _hodnoceni = HodnoceniProxy.Select_by_zak(9);
            for (int i = 0; i < _hodnoceni.Count(); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = _hodnoceni[i].Zamestnanec.Jmeno + " " + _hodnoceni[i].Zamestnanec.Prijmeni;
                dataGridView1.Rows[i].Cells[1].Value = _hodnoceni[i].Datum;
                dataGridView1.Rows[i].Cells[2].Value = _hodnoceni[i].Udelene_hodnoceni;
            }

            dataGridView2.Rows.Clear();
            Collection<Stiznost> stiznosti = StiznostProxy.Select_by_zak(9);
            for (int i = 0; i < stiznosti.Count(); i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = stiznosti[i].Zamestnanec.Jmeno + " " + stiznosti[i].Zamestnanec.Prijmeni;
                dataGridView2.Rows[i].Cells[1].Value = stiznosti[i].Datum;
                dataGridView2.Rows[i].Cells[2].Value = typStiznostiCB.Items[stiznosti[i].Typ_stiznosti - 1].ToString();
               // dataGridView2.Rows[i].Cells[2].Value = stiznosti[i].Typ_stiznosti;
            }
        }

        private void prvniFormButton_Click(object sender, EventArgs e)
        {
            (new Form1()).Show(); this.Hide();
        }

        private void aktualizovatButton_Click(object sender, EventArgs e)
        {
            bool jeCislo = long.TryParse(telefonTB.Text, out _);
            Zakaznik zakaznik = ZakaznikProxy.Select(9);
            if (jmenoTB.Text.Length > 0)
            {
                zakaznik.Jmeno = jmenoTB.Text.ToString();
            }
            if (prijmeniTB.Text.Length > 0)
            {
                zakaznik.Prijmeni = prijmeniTB.Text.ToString();
            }
            if (adresaTB.Text.Length > 0)
            {
                zakaznik.Adresa = adresaTB.Text.ToString();
            }
            if (telefonTB.Text.Length > 0)
            {
                zakaznik.Telefonni_cislo = telefonTB.Text.ToString();
            }
            if (jmenoTB.Text.Length == 0 && prijmeniTB.Text.Length == 0 && adresaTB.Text.Length == 0 && telefonTB.Text.Length == 0)
            {
                MessageBox.Show("Nevyplnil jste žádné z polí.\nÚdaje nebyly aktualizovány.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(jeCislo == false)
            {
                MessageBox.Show("Telefonní číslo bylo zadáno ve špatném formátu.\nÚdaje nebyly aktualizovány", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (telefonTB.Text.Length != 9 && telefonTB.Text.Length != 12)
            {
                MessageBox.Show("Zadané telefonní číslo má špatnou délku. Zadávejte prosím pouze 9-místná (bez předvolby) čísla nebo 12-místná (s předvolbou) čísla.\nÚdaje nebyly aktualizovány", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ZakaznikProxy.Update(zakaznik);
                refreshGrid();
                MessageBox.Show("Údaje byly úspěšně aktualizovány", "Údaje aktualizovány", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }             
       }

        private void pridatHodButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] wordArray = jmenoZamCB.Text.Split(' ');
                string jmenoZam = wordArray[0];
                string prijmeniZam = wordArray[1];
                Zamestnanec zamestnanec = ZamestnanecProxy.Get(jmenoZam, prijmeniZam);
                Hodnoceni maxHodnoceni = HodnoceniProxy.Max();
                Hodnoceni hodnoceni = new Hodnoceni();
                hodnoceni.Id_hodnoceni = maxHodnoceni.Id_hodnoceni + 1;
                hodnoceni.Zakaznik = ZakaznikProxy.Select(9);
                hodnoceni.Zamestnanec = ZamestnanecProxy.Select(zamestnanec.Id_zamestnance);
                hodnoceni.Datum = DateTime.Now;
                hodnoceni.Udelene_hodnoceni = Convert.ToInt32(hodnoceniCB.Text);
                HodnoceniProxy.Insert(hodnoceni);
                MessageBox.Show("Hodnocení bylo úspěšně uloženo", "Hodnocení uloženo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoZamCB.SelectedIndex = -1;
                hodnoceniCB.SelectedIndex = -1;
                refreshGrid();
            }
            catch (SystemException ex)
            {
                if (jmenoZamCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste žádného zaměstnance.\nHodnocení nebylo přidáno.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (hodnoceniCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste hodnocení.\nHodnocení nebylo přidáno.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
            }
        }

        private void pridatStButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] wordArray = jmenoZamCB2.Text.Split(' ');
                string jmenoZam = wordArray[0];
                string prijmeniZam = wordArray[1];
                Zamestnanec zamestnanec = ZamestnanecProxy.Get(jmenoZam, prijmeniZam);
                Stiznost maxStiznost = StiznostProxy.Max();
                Stiznost stiznost = new Stiznost();
                stiznost.Id_stiznosti = maxStiznost.Id_stiznosti + 1;
                stiznost.Zakaznik = ZakaznikProxy.Select(9);
                stiznost.Zamestnanec = ZamestnanecProxy.Select(zamestnanec.Id_zamestnance);
                stiznost.Datum = DateTime.Now;
                stiznost.Typ_stiznosti = typStiznostiCB.SelectedIndex + 1;
                StiznostProxy.Insert(stiznost);
                MessageBox.Show("Stížnost byla úspěšně uložena", "Stížnost uložena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jmenoZamCB2.SelectedIndex = -1;
                typStiznostiCB.SelectedIndex = -1;
                refreshGrid();
            }
            catch (SystemException ex)
            {
                if(jmenoZamCB2.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste žádného zaměstnance.\nStížnost nebyla přidána.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(typStiznostiCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste typ stížnosti.\nStížnost nebyla přidána.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
