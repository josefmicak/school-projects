namespace PrezentacniVrstva
{
    partial class ObjednavkyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.switchForm = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.spravaGB = new System.Windows.Forms.GroupBox();
            this.rozvazkaCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zakaznikCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.zamestnanecCB = new System.Windows.Forms.ComboBox();
            this.upravitObjednavku = new System.Windows.Forms.Button();
            this.odebratObjednavku = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.anoRB = new System.Windows.Forms.RadioButton();
            this.neRB = new System.Windows.Forms.RadioButton();
            this.pridatObjednavku = new System.Windows.Forms.Button();
            this.TB2 = new System.Windows.Forms.TextBox();
            this.TB1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_zamestnance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmenoZakaznika = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmenoZamestnance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum_nastupu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pozice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spravaGB.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // switchForm
            // 
            this.switchForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.switchForm.Location = new System.Drawing.Point(197, 546);
            this.switchForm.Name = "switchForm";
            this.switchForm.Size = new System.Drawing.Size(148, 60);
            this.switchForm.TabIndex = 35;
            this.switchForm.Text = "Přepnout okna";
            this.switchForm.UseVisualStyleBackColor = true;
            this.switchForm.Click += new System.EventHandler(this.switchForm_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(175, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 24);
            this.label11.TabIndex = 34;
            this.label11.Text = "Evidence objednávek";
            // 
            // spravaGB
            // 
            this.spravaGB.Controls.Add(this.rozvazkaCB);
            this.spravaGB.Controls.Add(this.label6);
            this.spravaGB.Controls.Add(this.zakaznikCB);
            this.spravaGB.Controls.Add(this.label5);
            this.spravaGB.Controls.Add(this.zamestnanecCB);
            this.spravaGB.Controls.Add(this.upravitObjednavku);
            this.spravaGB.Controls.Add(this.odebratObjednavku);
            this.spravaGB.Controls.Add(this.panel2);
            this.spravaGB.Controls.Add(this.pridatObjednavku);
            this.spravaGB.Controls.Add(this.TB2);
            this.spravaGB.Controls.Add(this.TB1);
            this.spravaGB.Controls.Add(this.label4);
            this.spravaGB.Controls.Add(this.label3);
            this.spravaGB.Controls.Add(this.label2);
            this.spravaGB.Controls.Add(this.label1);
            this.spravaGB.Location = new System.Drawing.Point(14, 12);
            this.spravaGB.Name = "spravaGB";
            this.spravaGB.Size = new System.Drawing.Size(534, 297);
            this.spravaGB.TabIndex = 33;
            this.spravaGB.TabStop = false;
            this.spravaGB.Text = "Správa objednávek";
            // 
            // rozvazkaCB
            // 
            this.rozvazkaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rozvazkaCB.DropDownWidth = 650;
            this.rozvazkaCB.FormattingEnabled = true;
            this.rozvazkaCB.Location = new System.Drawing.Point(165, 93);
            this.rozvazkaCB.Name = "rozvazkaCB";
            this.rozvazkaCB.Size = new System.Drawing.Size(121, 21);
            this.rozvazkaCB.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Rozvážka:";
            // 
            // zakaznikCB
            // 
            this.zakaznikCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zakaznikCB.DropDownWidth = 550;
            this.zakaznikCB.FormattingEnabled = true;
            this.zakaznikCB.Location = new System.Drawing.Point(165, 27);
            this.zakaznikCB.Name = "zakaznikCB";
            this.zakaznikCB.Size = new System.Drawing.Size(121, 21);
            this.zakaznikCB.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Zákazník:";
            // 
            // zamestnanecCB
            // 
            this.zamestnanecCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zamestnanecCB.DropDownWidth = 450;
            this.zamestnanecCB.FormattingEnabled = true;
            this.zamestnanecCB.Location = new System.Drawing.Point(165, 60);
            this.zamestnanecCB.Name = "zamestnanecCB";
            this.zamestnanecCB.Size = new System.Drawing.Size(121, 21);
            this.zamestnanecCB.TabIndex = 26;
            // 
            // upravitObjednavku
            // 
            this.upravitObjednavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.upravitObjednavku.Location = new System.Drawing.Point(183, 231);
            this.upravitObjednavku.Name = "upravitObjednavku";
            this.upravitObjednavku.Size = new System.Drawing.Size(148, 60);
            this.upravitObjednavku.TabIndex = 25;
            this.upravitObjednavku.Text = "Upravit objednávku";
            this.upravitObjednavku.UseVisualStyleBackColor = true;
            this.upravitObjednavku.Click += new System.EventHandler(this.upravitObjednavku_Click);
            // 
            // odebratObjednavku
            // 
            this.odebratObjednavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odebratObjednavku.Location = new System.Drawing.Point(362, 231);
            this.odebratObjednavku.Name = "odebratObjednavku";
            this.odebratObjednavku.Size = new System.Drawing.Size(148, 60);
            this.odebratObjednavku.TabIndex = 24;
            this.odebratObjednavku.Text = "Odebrat objednávku";
            this.odebratObjednavku.UseVisualStyleBackColor = true;
            this.odebratObjednavku.Click += new System.EventHandler(this.odebratObjednavku_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.anoRB);
            this.panel2.Controls.Add(this.neRB);
            this.panel2.Location = new System.Drawing.Point(165, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 29);
            this.panel2.TabIndex = 23;
            // 
            // anoRB
            // 
            this.anoRB.AutoSize = true;
            this.anoRB.Location = new System.Drawing.Point(9, 9);
            this.anoRB.Name = "anoRB";
            this.anoRB.Size = new System.Drawing.Size(44, 17);
            this.anoRB.TabIndex = 20;
            this.anoRB.Text = "Ano";
            this.anoRB.UseVisualStyleBackColor = true;
            // 
            // neRB
            // 
            this.neRB.AutoSize = true;
            this.neRB.Checked = true;
            this.neRB.Location = new System.Drawing.Point(61, 9);
            this.neRB.Name = "neRB";
            this.neRB.Size = new System.Drawing.Size(39, 17);
            this.neRB.TabIndex = 21;
            this.neRB.TabStop = true;
            this.neRB.Text = "Ne";
            this.neRB.UseVisualStyleBackColor = true;
            // 
            // pridatObjednavku
            // 
            this.pridatObjednavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pridatObjednavku.Location = new System.Drawing.Point(6, 231);
            this.pridatObjednavku.Name = "pridatObjednavku";
            this.pridatObjednavku.Size = new System.Drawing.Size(148, 60);
            this.pridatObjednavku.TabIndex = 1;
            this.pridatObjednavku.Text = "Přidat objednávku";
            this.pridatObjednavku.UseVisualStyleBackColor = true;
            this.pridatObjednavku.Click += new System.EventHandler(this.pridatObjednavku_Click);
            // 
            // TB2
            // 
            this.TB2.Location = new System.Drawing.Point(165, 159);
            this.TB2.Name = "TB2";
            this.TB2.Size = new System.Drawing.Size(62, 20);
            this.TB2.TabIndex = 12;
            // 
            // TB1
            // 
            this.TB1.Location = new System.Drawing.Point(165, 126);
            this.TB1.Name = "TB1";
            this.TB1.Size = new System.Drawing.Size(121, 20);
            this.TB1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vyplacena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cena:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum vytvoření:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zaměstnanec:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_zamestnance,
            this.jmenoZakaznika,
            this.jmenoZamestnance,
            this.datum_nastupu,
            this.pozice});
            this.dataGridView1.Location = new System.Drawing.Point(8, 339);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(540, 192);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id_zamestnance
            // 
            this.id_zamestnance.HeaderText = "ID";
            this.id_zamestnance.Name = "id_zamestnance";
            this.id_zamestnance.ReadOnly = true;
            this.id_zamestnance.Width = 30;
            // 
            // jmenoZakaznika
            // 
            this.jmenoZakaznika.HeaderText = "Jméno zákazníka";
            this.jmenoZakaznika.Name = "jmenoZakaznika";
            this.jmenoZakaznika.ReadOnly = true;
            this.jmenoZakaznika.Width = 150;
            // 
            // jmenoZamestnance
            // 
            this.jmenoZamestnance.HeaderText = "Jméno zaměstnance";
            this.jmenoZamestnance.Name = "jmenoZamestnance";
            this.jmenoZamestnance.ReadOnly = true;
            this.jmenoZamestnance.Width = 150;
            // 
            // datum_nastupu
            // 
            this.datum_nastupu.HeaderText = "Datum vytvoření";
            this.datum_nastupu.Name = "datum_nastupu";
            this.datum_nastupu.ReadOnly = true;
            this.datum_nastupu.Width = 110;
            // 
            // pozice
            // 
            this.pozice.HeaderText = "Cena";
            this.pozice.Name = "pozice";
            this.pozice.ReadOnly = true;
            this.pozice.Width = 80;
            // 
            // ObjednavkyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 618);
            this.Controls.Add(this.switchForm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.spravaGB);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ObjednavkyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa objednávek";
            this.spravaGB.ResumeLayout(false);
            this.spravaGB.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button switchForm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox spravaGB;
        private System.Windows.Forms.ComboBox rozvazkaCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox zakaznikCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox zamestnanecCB;
        private System.Windows.Forms.Button upravitObjednavku;
        private System.Windows.Forms.Button odebratObjednavku;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton anoRB;
        private System.Windows.Forms.RadioButton neRB;
        private System.Windows.Forms.Button pridatObjednavku;
        private System.Windows.Forms.TextBox TB2;
        private System.Windows.Forms.TextBox TB1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_zamestnance;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmenoZakaznika;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmenoZamestnance;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum_nastupu;
        private System.Windows.Forms.DataGridViewTextBoxColumn pozice;
    }
}