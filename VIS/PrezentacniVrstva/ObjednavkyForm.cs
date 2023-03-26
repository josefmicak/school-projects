using BusinessVrstva.Logika;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrezentacniVrstva
{
    public partial class ObjednavkyForm : Form
    {
        ObjednavkaLogika objednavkaLogika = new ObjednavkaLogika();
        Collection<Objednavka> seznamObjednavek;
        ZakaznikLogika zakaznikLogika = new ZakaznikLogika();
        Collection<Zakaznik> seznamZakazniku;
        ZamestnanecLogika zamestnanecLogika = new ZamestnanecLogika();
        Collection<Zamestnanec> seznamZamestnancu;
        RozvazkaLogika rozvazkaLogika = new RozvazkaLogika();
        Collection<Rozvazka> seznamRozvazek;

        List<int> idZakaznikuList = new List<int>();
        List<int> idZamestnancuList = new List<int>();
        List<int> idRozvazekList = new List<int>();

        int vybranaObjednavka = 0;

        public ObjednavkyForm()
        {
            seznamObjednavek = objednavkaLogika.Select();
            seznamZakazniku = zakaznikLogika.Select();
            seznamZamestnancu = zamestnanecLogika.getSeznamZamestnancu();
            seznamRozvazek = rozvazkaLogika.Select();
            InitializeComponent();
            nacistObjednavky();
            nacistSeznamy();
        }

        private void nacistObjednavky()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = seznamObjednavek[i].Id_objednavky;
                dataGridView1.Rows[i].Cells[1].Value = seznamZakazniku[int.Parse(seznamObjednavek[i].Zakaznik.Id_zakaznika.ToString()) - 1].Jmeno +
                    " " + seznamZakazniku[int.Parse(seznamObjednavek[i].Zakaznik.Id_zakaznika.ToString()) - 1].Prijmeni;
                dataGridView1.Rows[i].Cells[2].Value = seznamZamestnancu[int.Parse(seznamObjednavek[i].Zamestnanec.Id_zamestnance.ToString())].Jmeno +
                    " " + seznamZamestnancu[int.Parse(seznamObjednavek[i].Zamestnanec.Id_zamestnance.ToString())].Prijmeni;
                dataGridView1.Rows[i].Cells[3].Value = seznamObjednavek[i].Datum_vytvoreni;
                dataGridView1.Rows[i].Cells[4].Value = seznamObjednavek[i].Cena;
            }
            dataGridView1.Refresh();
        }

        private void nacistSeznamy()
        {
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                idZakaznikuList.Add(seznamZakazniku[i].Id_zakaznika);
                zakaznikCB.Items.Add("(ID: " + seznamZakazniku[i].Id_zakaznika + ") jméno: " + seznamZakazniku[i].Jmeno + " " + seznamZakazniku[i].Prijmeni +
                    ", adresa: " + seznamZakazniku[i].Adresa + ", telefonní číslo: " + seznamZakazniku[i].Telefonni_cislo);
            }

            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                idZamestnancuList.Add(seznamZamestnancu[i].Id_zamestnance);
                zamestnanecCB.Items.Add("(ID: " + seznamZamestnancu[i].Id_zamestnance + ") jméno: " + seznamZamestnancu[i].Jmeno + " " + seznamZamestnancu[i].Prijmeni +
                    ", datum nástupu: " + seznamZamestnancu[i].Datum_nastupu.ToShortDateString() + ", pozice: " + seznamZamestnancu[i].Pozice);
            }

            for (int i = 0; i < seznamRozvazek.Count; i++)
            {
                idRozvazekList.Add(seznamRozvazek[i].Id_rozvazky);
                rozvazkaCB.Items.Add("(ID: " + seznamRozvazek[i].Id_rozvazky + ") jméno zaměstnance: " + seznamRozvazek[i].Zamestnanec.Jmeno + " " + seznamRozvazek[i].Zamestnanec.Prijmeni +
                    ", vozidlo: " + seznamRozvazek[i].Vozidlo.Znacka + ", čas odjezdu: " + seznamRozvazek[i].Cas_odjezdu + ", čas příjezdu: " + seznamRozvazek[i].Cas_prijezdu);
            }
        }

        private void pridatObjednavku_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při přidávání objednávky je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Objednavka objednavka = new Objednavka();
                    objednavka.Id_objednavky = seznamObjednavek[seznamObjednavek.Count - 1].Id_objednavky + 1;
                    string[] rozdeleniZak = zakaznikCB.Text.Split(' ');
                    objednavka.Zakaznik = zakaznikLogika.Select(int.Parse(rozdeleniZak[1].Remove(rozdeleniZak[1].Length - 1)));
                    string[] rozdeleniZam = zamestnanecCB.Text.Split(' ');
                    objednavka.Zamestnanec = zamestnanecLogika.Select(int.Parse(rozdeleniZam[1].Remove(rozdeleniZam[1].Length - 1)));
                    string[] rozdeleniRoz = rozvazkaCB.Text.Split(' ');
                    objednavka.Rozvazka = rozvazkaLogika.Select(int.Parse(rozdeleniRoz[1].Remove(rozdeleniRoz[1].Length - 1)));
                    objednavka.Datum_vytvoreni = DateTime.Parse(TB1.Text.ToString());
                    objednavka.Cena = int.Parse(TB2.Text);
                    objednavka.Vyplacena = anoRB.Checked ? 'A' : 'N';
                    try
                    {
                        objednavkaLogika.Insert(objednavka, false);
                        seznamObjednavek.Add(objednavka);
                        MessageBox.Show("Objednávka byla úspešně přidána", "Objednávka přidána", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nacistObjednavky();
                        textBoxObsah();
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show(ex.Message + "\nChcete přesto objednávku přidat?", "Přidání objednávky", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            objednavkaLogika.Insert(objednavka, true);
                            seznamObjednavek.Add(objednavka);
                            MessageBox.Show("Objednávka byla úspešně přidána", "Objednávka přidána", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nacistObjednavky();
                            textBoxObsah();
                        }
                    }
                }
                catch
                {
                    bool jeDatum = DateTime.TryParse(TB1.Text, out _);
                    if (!jeDatum)
                    {
                        MessageBox.Show("Chyba - datum vytvoření objednávky je zadáno ve špatném formátu.\nObjednávka nebyla upravena.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void upravitObjednavku_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při upravování objednávky je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Objednavka objednavka = objednavkaLogika.Select(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    string[] rozdeleniZak = zakaznikCB.Text.Split(' ');
                    objednavka.Zakaznik = new Zakaznik();
                    objednavka.Zakaznik.Id_zakaznika = int.Parse(rozdeleniZak[1].Remove(rozdeleniZak[1].Length - 1));
                    string[] rozdeleniZam = zamestnanecCB.Text.Split(' ');
                    objednavka.Zamestnanec = new Zamestnanec();
                    objednavka.Zamestnanec.Id_zamestnance = int.Parse(rozdeleniZam[1].Remove(rozdeleniZam[1].Length - 1));
                    string[] rozdeleniRoz = rozvazkaCB.Text.Split(' ');
                    objednavka.Rozvazka = new Rozvazka();
                    objednavka.Rozvazka.Id_rozvazky = int.Parse(rozdeleniRoz[1].Remove(rozdeleniRoz[1].Length - 1));
                    objednavka.Datum_vytvoreni = DateTime.Parse(TB1.Text.ToString());
                    objednavka.Cena = int.Parse(TB2.Text);
                    objednavka.Vyplacena = anoRB.Checked ? 'A' : 'N';
                    try
                    {
                        objednavkaLogika.Update(objednavka, false);
                        seznamObjednavek[vybranaObjednavka] = objednavka;
                        MessageBox.Show("Objednávka byla úspešně upravena", "Objednávka upravena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nacistObjednavky();
                        textBoxObsah();
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show(ex.Message + "\nChcete přesto objednávku upravit?", "Úprava objednávky", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            objednavkaLogika.Update(objednavka, true);
                            seznamObjednavek[vybranaObjednavka] = objednavka;
                            MessageBox.Show("Objednávka byla úspešně upravena", "Objednávka upravena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nacistObjednavky();
                            textBoxObsah();
                        }
                    }
                }
                catch
                {
                    bool jeDatum = DateTime.TryParse(TB1.Text, out _);
                    if (!jeDatum)
                    {
                        MessageBox.Show("Chyba - datum vytvoření objednávky je zadáno ve špatném formátu.\nObjednávka nebyla upravena.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void odebratObjednavku_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při odebírání objednávky je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                seznamObjednavek.RemoveAt(vybranaObjednavka);
                objednavkaLogika.Delete(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("Objednávka byla úspešně odebrána", "Objednávka odebrána", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nacistObjednavky();
                textBoxObsah();
            }
        }

        private bool jsouUdajeVyplnene()
        {
            if (TB1.TextLength > 0 && TB2.TextLength > 0 && zakaznikCB.SelectedIndex >= 0 && zamestnanecCB.SelectedIndex >= 0 && rozvazkaCB.SelectedIndex >= 0)
            {
                return true;
            }
            return false;
        }

        private void textBoxObsah()
        {
            TB1.Text = "";
            TB2.Text = "";
            neRB.Checked = true;
            zakaznikCB.SelectedIndex = -1;
            zamestnanecCB.SelectedIndex = -1;
            rozvazkaCB.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vybranaObjednavka = dataGridView1.CurrentCell.RowIndex;
            for (int i = 0; i < seznamObjednavek.Count; i++)
            {
                if (seznamObjednavek[i].Id_objednavky == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
                {
                    TB1.Text = seznamObjednavek[i].Datum_vytvoreni.ToString();
                    TB2.Text = seznamObjednavek[i].Cena.ToString();
                    if (seznamObjednavek[i].Vyplacena == 'A')
                    {
                        anoRB.Checked = true;
                    }
                    else
                    {
                        neRB.Checked = true;
                    }
                    break;
                }
            }
            for (int i = 0; i < idZakaznikuList.Count; i++)
            {
                if (seznamObjednavek[vybranaObjednavka].Zakaznik.Id_zakaznika == idZakaznikuList[i])
                {
                    zakaznikCB.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < idZamestnancuList.Count; i++)
            {
                if (seznamObjednavek[vybranaObjednavka].Zamestnanec.Id_zamestnance == idZamestnancuList[i])
                {
                    zamestnanecCB.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < idRozvazekList.Count; i++)
            {
                if (seznamObjednavek[vybranaObjednavka].Rozvazka.Id_rozvazky == idRozvazekList[i])
                {
                    rozvazkaCB.SelectedIndex = i;
                    break;
                }
            }
        }

        private void switchForm_Click(object sender, EventArgs e)
        {
            new ZamestnanciForm().Show();
            Hide();
        }
    }
}
