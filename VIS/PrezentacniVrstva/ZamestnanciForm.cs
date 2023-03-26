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
    public partial class ZamestnanciForm : Form
    {
        ZamestnanecLogika zamestnanecLogika = new ZamestnanecLogika();
        Collection<Zamestnanec> seznamZamestnancu;
        int vybranyZamestnanec = 0;

        public ZamestnanciForm()
        {
            seznamZamestnancu = zamestnanecLogika.getSeznamZamestnancu();
            InitializeComponent();
            nacistZamestnance();
        }

        private void nacistZamestnance()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (seznamZamestnancu[i].Vyhozen == "A" && !zobrazitVyhozene.Checked)
                {
                    continue;
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = seznamZamestnancu[i].Id_zamestnance;
                dataGridView1.Rows[i].Cells[1].Value = seznamZamestnancu[i].Jmeno;
                dataGridView1.Rows[i].Cells[2].Value = seznamZamestnancu[i].Prijmeni;
                dataGridView1.Rows[i].Cells[3].Value = seznamZamestnancu[i].Datum_nastupu.ToShortDateString();
                dataGridView1.Rows[i].Cells[4].Value = seznamZamestnancu[i].Pozice;
            }
            dataGridView1.Refresh();
        }

        private void pridatZamestnance_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při přidávání zaměstnance je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Zamestnanec zamestnanec = new Zamestnanec();
                    zamestnanec.Id_zamestnance = seznamZamestnancu[seznamZamestnancu.Count - 1].Id_zamestnance + 1;
                    zamestnanec.Jmeno = TB1.Text.ToString();
                    zamestnanec.Prijmeni = TB2.Text.ToString();
                    zamestnanec.Adresa = TB3.Text.ToString();
                    zamestnanec.Telefonni_cislo = TB4.Text.ToString();
                    zamestnanec.Pohlavi = muzRB.Checked ? 'M' : 'Z';
                    zamestnanec.Datum_narozeni = DateTime.Parse(TB5.Text.ToString());
                    zamestnanec.Datum_nastupu = DateTime.Parse(TB6.Text.ToString());
                    zamestnanec.Pozice = TB7.Text.ToString();
                    zamestnanec.Plat = int.Parse(TB8.Text.ToString());
                    zamestnanec.Vyhozen = anoRB.Checked ? "A" : "N";
                    try
                    {
                        zamestnanecLogika.Insert(zamestnanec, false);
                        seznamZamestnancu.Add(zamestnanec);
                        MessageBox.Show("Zaměstnanec byl úspešně přidán", "Zaměstnanec přidán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nacistZamestnance();
                        textBoxObsah();
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show(ex.Message + "\nChcete přesto zaměstnance přidat?", "Přidání zaměstnance", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            zamestnanecLogika.Insert(zamestnanec, true);
                            seznamZamestnancu.Add(zamestnanec);
                            MessageBox.Show("Zaměstnanec byl úspešně přidán", "Zaměstnanec přidán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nacistZamestnance();
                            textBoxObsah();
                        }
                    }
                }
                catch
                {
                    bool jeNarDatum = DateTime.TryParse(TB5.Text, out _);
                    bool jeNasDatum = DateTime.TryParse(TB6.Text, out _);
                    if (!jeNarDatum)
                    {
                        MessageBox.Show("Chyba - datum narození je zadáno ve špatném formátu.\nZaměstnanec nebyl přidán.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!jeNasDatum)
                    {
                        MessageBox.Show("Chyba - datum nástupu je zadáno ve špatném formátu.\nZaměstnanec nebyl přidán.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void upravitZamestnance_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při upravování zaměstnance je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Zamestnanec zamestnanec = zamestnanecLogika.Select(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    zamestnanec.Jmeno = TB1.Text;
                    zamestnanec.Prijmeni = TB2.Text;
                    zamestnanec.Adresa = TB3.Text;
                    zamestnanec.Telefonni_cislo = TB4.Text;
                    if (muzRB.Checked)
                    {
                        zamestnanec.Pohlavi = 'M';
                    }
                    else
                    {
                        zamestnanec.Pohlavi = 'Z';
                    }
                    zamestnanec.Datum_narozeni = DateTime.Parse(TB5.Text);
                    zamestnanec.Datum_nastupu = DateTime.Parse(TB6.Text);
                    zamestnanec.Pozice = TB7.Text;
                    zamestnanec.Plat = int.Parse(TB8.Text);
                    if (anoRB.Checked)
                    {
                        zamestnanec.Vyhozen = "A";
                    }
                    else
                    {
                        zamestnanec.Vyhozen = "N";
                    }
                    try
                    {
                        zamestnanecLogika.Update(zamestnanec, false);
                        seznamZamestnancu[vybranyZamestnanec] = zamestnanec;
                        MessageBox.Show("Zaměstnanec byl úspešně aktualizován", "Zaměstnanec aktualizován", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nacistZamestnance();
                        textBoxObsah();
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show(ex.Message + "\nChcete přesto zaměstnance upravit?", "Úprava zaměstnance", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            zamestnanecLogika.Update(zamestnanec, true);
                            seznamZamestnancu[vybranyZamestnanec] = zamestnanec;
                            MessageBox.Show("Zaměstnanec byl úspešně aktualizován", "Zaměstnanec aktualizován", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nacistZamestnance();
                            textBoxObsah();
                        }
                    }
                }
                catch
                {
                    bool jeNarDatum = DateTime.TryParse(TB5.Text, out _);
                    bool jeNasDatum = DateTime.TryParse(TB6.Text, out _);
                    if (!jeNarDatum)
                    {
                        MessageBox.Show("Chyba - datum narození je zadáno ve špatném formátu.\nZaměstnanec nebyl aktualizován.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!jeNasDatum)
                    {
                        MessageBox.Show("Chyba - datum nástupu je zadáno ve špatném formátu.\nZaměstnanec nebyl aktualizován.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void odebratZamestnance_Click(object sender, EventArgs e)
        {
            if (!jsouUdajeVyplnene())
            {
                MessageBox.Show("Chyba - při odebírání je nutné vyplnit všechny údaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (zamestnanecLogika.Delete(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())) != null)
                {
                    seznamZamestnancu.RemoveAt(vybranyZamestnanec);
                    MessageBox.Show("Zaměstnanec byl úspešně odebrán", "Zaměstnanec odebrán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nacistZamestnance();
                    textBoxObsah();
                }
                else
                {
                    MessageBox.Show("Zaměstnanec nemohl být odebrán - systém pravděpodobně obsahuje data u kterých je tento zaměstnanec zapsán." +
                    "\nPro odebrání tohoto zaměstnance můžete označit zaměstnance za vyhozeného (nastavit parametr vyhozen na A).", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool jsouUdajeVyplnene()
        {
            foreach (var textBox in spravaGB.Controls.OfType<TextBox>())
            {
                if (textBox.Text.Length < 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void textBoxObsah()
        {
            foreach (var textBox in spravaGB.Controls.OfType<TextBox>().OrderBy(x => x.Name))
            {
                textBox.Text = "";
            }
            muzRB.Checked = true;
            neRB.Checked = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vybranyZamestnanec = dataGridView1.CurrentCell.RowIndex;
            for (int i = 0; i < seznamZamestnancu.Count; i++)
            {
                if (seznamZamestnancu[i].Id_zamestnance == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
                {
                    TB1.Text = seznamZamestnancu[i].Jmeno;
                    TB2.Text = seznamZamestnancu[i].Prijmeni;
                    TB3.Text = seznamZamestnancu[i].Adresa;
                    TB4.Text = seznamZamestnancu[i].Telefonni_cislo;
                    TB5.Text = seznamZamestnancu[i].Datum_narozeni.ToShortDateString();
                    TB6.Text = seznamZamestnancu[i].Datum_nastupu.ToShortDateString();
                    TB7.Text = seznamZamestnancu[i].Pozice;
                    TB8.Text = seznamZamestnancu[i].Plat.ToString();
                    if (seznamZamestnancu[i].Pohlavi == 'M')
                    {
                        muzRB.Checked = true;
                    }
                    else
                    {
                        zenaRB.Checked = true;
                    }
                    if (seznamZamestnancu[i].Vyhozen == "A")
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
        }

        private void zobrazitVyhozene_CheckedChanged(object sender, EventArgs e)
        {
            nacistZamestnance();
        }

        private void switchForm_Click(object sender, EventArgs e)
        {
            new ObjednavkyForm().Show();
            Hide();
        }
    }
}
