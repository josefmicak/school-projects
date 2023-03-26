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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Collection<Objednavka> objednavky = ObjednavkaProxy.Select();
            for (int i = 0; i < objednavky.Count; i++)
            {
                objednavkaCB1.Items.Add("( ID: " + objednavky[i].Id_objednavky + " ) Jméno zákazníka: " + objednavky[i].Zakaznik.Jmeno + " " + objednavky[i].Zakaznik.Prijmeni + ", jméno zaměstnance: " +
                objednavky[i].Zamestnanec.Jmeno + " " + objednavky[i].Zamestnanec.Prijmeni + ", ID rozvážky: " + objednavky[i].Rozvazka.Id_rozvazky + ", datum vytvoření: " +
                objednavky[i].Datum_vytvoreni + ", cena " + objednavky[i].Cena + ", vyplacena: " + objednavky[i].Vyplacena);

                objednavkaCB2.Items.Add("( ID: " + objednavky[i].Id_objednavky + " ) Jméno zákazníka: " + objednavky[i].Zakaznik.Jmeno + " " + objednavky[i].Zakaznik.Prijmeni + ", jméno zaměstnance: " +
                objednavky[i].Zamestnanec.Jmeno + " " + objednavky[i].Zamestnanec.Prijmeni + ", ID rozvážky: " + objednavky[i].Rozvazka.Id_rozvazky + ", datum vytvoření: " +
                objednavky[i].Datum_vytvoreni + ", cena " + objednavky[i].Cena + ", vyplacena: " + objednavky[i].Vyplacena);
            }

            Collection<Zamestnanec> zamestnanci = ZamestnanecProxy.Select();
            for (int i = 0; i < zamestnanci.Count; i++)
            {
                jmenoZamCB.Items.Add(zamestnanci[i].Jmeno + " " + zamestnanci[i].Prijmeni);
            }

            Collection<Zakaznik> zakaznici = ZakaznikProxy.Select();
            for (int i = 0; i < zakaznici.Count; i++)
            {
                jmenoZakCB.Items.Add(zakaznici[i].Jmeno + " " + zakaznici[i].Prijmeni);
            }

            Collection<Rozvazka> rozvazky = RozvazkaProxy.Select();
            for (int i = 0; i < rozvazky.Count; i++)
            {
                rozvazkaCB.Items.Add("( ID: " + rozvazky[i].Id_rozvazky + " ), ID zaměstnance: " + rozvazky[i].Zamestnanec.Id_zamestnance + ", ID vozidla: " + rozvazky[i].Vozidlo.Id_vozidla +
                    ", čas odjezdu: " + rozvazky[i].Cas_odjezdu + ", čas příjezdu: " + rozvazky[i].Cas_prijezdu);
            }

            refreshGrid();
        }

        private void refreshGrid()
        {
            dataGridView1.Rows.Clear();
            Collection<Objednavka> objednavky = ObjednavkaProxy.Select();
            for (int i = 0; i < objednavky.Count(); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = objednavky[i].Id_objednavky;
                dataGridView1.Rows[i].Cells[1].Value = objednavky[i].Zakaznik.Jmeno + " " + objednavky[i].Zakaznik.Prijmeni;
                dataGridView1.Rows[i].Cells[2].Value = objednavky[i].Zamestnanec.Jmeno + " " + objednavky[i].Zamestnanec.Prijmeni;
                dataGridView1.Rows[i].Cells[3].Value = objednavky[i].Rozvazka.Id_rozvazky;
                dataGridView1.Rows[i].Cells[4].Value = objednavky[i].Datum_vytvoreni;
                dataGridView1.Rows[i].Cells[5].Value = objednavky[i].Cena;
                dataGridView1.Rows[i].Cells[6].Value = objednavky[i].Vyplacena;
            }
        }

        private void smazatButton_Click(object sender, EventArgs e)
        {         
            try
            {
                string[] wordArray = objednavkaCB2.Text.Split(' ');
                string idObjednavky = wordArray[2];
                ObjednavkaProxy.Delete(Convert.ToInt32(idObjednavky));
                refreshGrid();
                MessageBox.Show("Objednávka byla úspěšně smazána", "Objednávka smazána", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SystemException ex)
            {
                if(objednavkaCB2.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste žádnou objednávku.\nObjednávka nebyla smazána.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
        }

        private void aktualizovatButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] wordArray = objednavkaCB1.Text.Split(' ');
                string idObjednavky = wordArray[2];
                Objednavka objednavka = ObjednavkaProxy.Select(Convert.ToInt32(idObjednavky));
              
                string[] wordArray2 = jmenoZamCB.Text.Split(' ');
                string jmenoZam = wordArray2[0];
                string prijmeniZam = wordArray2[1];
                Zamestnanec zamestnanec = ZamestnanecProxy.Get(jmenoZam, prijmeniZam);
                objednavka.Zamestnanec.Id_zamestnance = zamestnanec.Id_zamestnance;

                string[] wordArray3 = jmenoZakCB.Text.Split(' ');
                string jmenoZak = wordArray3[0];
                string prijmeniZak = wordArray3[1];
                Zakaznik zakaznik = ZakaznikProxy.Get(jmenoZak, prijmeniZak);
                objednavka.Zakaznik.Id_zakaznika = zakaznik.Id_zakaznika;

                string[] wordArray4 = rozvazkaCB.Text.Split(' ');
                objednavka.Rozvazka.Id_rozvazky = Convert.ToInt32(wordArray4[2]);

                objednavka.Datum_vytvoreni = Convert.ToDateTime(datumTB.Text);

                objednavka.Cena = Convert.ToInt32(cenaTB.Text);

                if(vyplacenaCB.SelectedIndex == 0)
                {
                    objednavka.Vyplacena = 'Y';
                }
                else
                {
                    objednavka.Vyplacena = 'N';
                }
                ObjednavkaProxy.Update(objednavka);
                refreshGrid();
                MessageBox.Show("Objednávka byla úspěšně aktualizována", "Objednávka aktualizována", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SystemException ex)
            {
                bool jeCislo = long.TryParse(cenaTB.Text, out _);
                bool jeDatum = DateTime.TryParse(datumTB.Text, out _);
                if (objednavkaCB1.SelectedIndex == -1)
                {
                    MessageBox.Show("Nevybral jste žádnou objednávku.\nObjednávka nebyla aktualizována", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (datumTB.Text.Length == 0)
                {
                    MessageBox.Show("Nezadal jste žádné datum vytvoření objednávky.\nObjednávka nebyla aktualizována", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (jeCislo == false)
                {
                    MessageBox.Show("Cena objednávky nebyla zadána nebo byla zadána ve špatném formátu.\nObjednávka nebyla aktualizována", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (jeDatum == false)
                {
                    MessageBox.Show("Datum vytvoření objednávky nebylo zadáno nebo bylo zadáno ve špatném formátu.\nObjednávka nebyla aktualizována", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void druhyForm_Click(object sender, EventArgs e)
        {
              (new UzivatelskeMenuForm()).Show(); this.Hide();
        }

        private void objednavkaCB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] wordArray = objednavkaCB1.Text.Split(' ');
            jmenoZakCB.SelectedIndex = jmenoZakCB.FindStringExact(wordArray[6] + " " + wordArray[7].Remove(wordArray[7].Length - 1));
            jmenoZamCB.SelectedIndex = jmenoZamCB.FindStringExact(wordArray[10] + " " + wordArray[11].Remove(wordArray[11].Length - 1));
            for(int i = 0; i < rozvazkaCB.Items.Count; i++)
            {
                string helper = rozvazkaCB.GetItemText(rozvazkaCB.Items[i].ToString());
                string[] wordArray2 = helper.Split(' ');
                if (wordArray2[2] == wordArray[14].Remove(wordArray[14].Length - 1))
                {
                    rozvazkaCB.SelectedIndex = i;
                }
            }
            datumTB.Text = wordArray[17] + ' ' + wordArray[18].Remove(wordArray[18].Length - 1);
            cenaTB.Text = wordArray[20].Remove(wordArray[20].Length - 1);
            if(wordArray[22] == "Y")
            {
                vyplacenaCB.SelectedIndex = 0;
            }
            else
            {
                vyplacenaCB.SelectedIndex = 1;
            }
        }
    }
}
