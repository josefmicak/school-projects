namespace PrezentacniVrstva
{
    partial class ZamestnanciForm
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
            this.zobrazitVyhozene = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.spravaGB = new System.Windows.Forms.GroupBox();
            this.odebratZamestnance = new System.Windows.Forms.Button();
            this.upravitZamestnance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.anoRB = new System.Windows.Forms.RadioButton();
            this.neRB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.muzRB = new System.Windows.Forms.RadioButton();
            this.zenaRB = new System.Windows.Forms.RadioButton();
            this.pridatZamestnance = new System.Windows.Forms.Button();
            this.TB8 = new System.Windows.Forms.TextBox();
            this.TB7 = new System.Windows.Forms.TextBox();
            this.TB6 = new System.Windows.Forms.TextBox();
            this.TB5 = new System.Windows.Forms.TextBox();
            this.TB4 = new System.Windows.Forms.TextBox();
            this.TB3 = new System.Windows.Forms.TextBox();
            this.TB2 = new System.Windows.Forms.TextBox();
            this.TB1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_zamestnance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prijmeni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum_nastupu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pozice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spravaGB.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // switchForm
            // 
            this.switchForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.switchForm.Location = new System.Drawing.Point(244, 675);
            this.switchForm.Name = "switchForm";
            this.switchForm.Size = new System.Drawing.Size(148, 60);
            this.switchForm.TabIndex = 32;
            this.switchForm.Text = "Přepnout okna";
            this.switchForm.UseVisualStyleBackColor = true;
            this.switchForm.Click += new System.EventHandler(this.switchForm_Click);
            // 
            // zobrazitVyhozene
            // 
            this.zobrazitVyhozene.AutoSize = true;
            this.zobrazitVyhozene.Location = new System.Drawing.Point(223, 647);
            this.zobrazitVyhozene.Name = "zobrazitVyhozene";
            this.zobrazitVyhozene.Size = new System.Drawing.Size(195, 17);
            this.zobrazitVyhozene.TabIndex = 31;
            this.zobrazitVyhozene.Text = "Zobrazovat vyhozené zaměstnance";
            this.zobrazitVyhozene.UseVisualStyleBackColor = true;
            this.zobrazitVyhozene.CheckedChanged += new System.EventHandler(this.zobrazitVyhozene_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(214, 464);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 24);
            this.label11.TabIndex = 30;
            this.label11.Text = "Evidence zaměstnanců";
            // 
            // spravaGB
            // 
            this.spravaGB.Controls.Add(this.odebratZamestnance);
            this.spravaGB.Controls.Add(this.upravitZamestnance);
            this.spravaGB.Controls.Add(this.panel2);
            this.spravaGB.Controls.Add(this.panel1);
            this.spravaGB.Controls.Add(this.pridatZamestnance);
            this.spravaGB.Controls.Add(this.TB8);
            this.spravaGB.Controls.Add(this.TB7);
            this.spravaGB.Controls.Add(this.TB6);
            this.spravaGB.Controls.Add(this.TB5);
            this.spravaGB.Controls.Add(this.TB4);
            this.spravaGB.Controls.Add(this.TB3);
            this.spravaGB.Controls.Add(this.TB2);
            this.spravaGB.Controls.Add(this.TB1);
            this.spravaGB.Controls.Add(this.label10);
            this.spravaGB.Controls.Add(this.label9);
            this.spravaGB.Controls.Add(this.label8);
            this.spravaGB.Controls.Add(this.label7);
            this.spravaGB.Controls.Add(this.label6);
            this.spravaGB.Controls.Add(this.label5);
            this.spravaGB.Controls.Add(this.label4);
            this.spravaGB.Controls.Add(this.label3);
            this.spravaGB.Controls.Add(this.label2);
            this.spravaGB.Controls.Add(this.label1);
            this.spravaGB.Location = new System.Drawing.Point(11, 13);
            this.spravaGB.Name = "spravaGB";
            this.spravaGB.Size = new System.Drawing.Size(624, 445);
            this.spravaGB.TabIndex = 29;
            this.spravaGB.TabStop = false;
            this.spravaGB.Text = "Správa zaměstnanců";
            // 
            // odebratZamestnance
            // 
            this.odebratZamestnance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odebratZamestnance.Location = new System.Drawing.Point(451, 363);
            this.odebratZamestnance.Name = "odebratZamestnance";
            this.odebratZamestnance.Size = new System.Drawing.Size(148, 60);
            this.odebratZamestnance.TabIndex = 26;
            this.odebratZamestnance.Text = "Odebrat zaměstnance";
            this.odebratZamestnance.UseVisualStyleBackColor = true;
            this.odebratZamestnance.Click += new System.EventHandler(this.odebratZamestnance_Click);
            // 
            // upravitZamestnance
            // 
            this.upravitZamestnance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.upravitZamestnance.Location = new System.Drawing.Point(233, 363);
            this.upravitZamestnance.Name = "upravitZamestnance";
            this.upravitZamestnance.Size = new System.Drawing.Size(148, 60);
            this.upravitZamestnance.TabIndex = 25;
            this.upravitZamestnance.Text = "Upravit zaměstnance";
            this.upravitZamestnance.UseVisualStyleBackColor = true;
            this.upravitZamestnance.Click += new System.EventHandler(this.upravitZamestnance_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.anoRB);
            this.panel2.Controls.Add(this.neRB);
            this.panel2.Location = new System.Drawing.Point(151, 328);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.muzRB);
            this.panel1.Controls.Add(this.zenaRB);
            this.panel1.Location = new System.Drawing.Point(151, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 27);
            this.panel1.TabIndex = 22;
            // 
            // muzRB
            // 
            this.muzRB.AutoSize = true;
            this.muzRB.Checked = true;
            this.muzRB.Location = new System.Drawing.Point(9, 7);
            this.muzRB.Name = "muzRB";
            this.muzRB.Size = new System.Drawing.Size(45, 17);
            this.muzRB.TabIndex = 18;
            this.muzRB.TabStop = true;
            this.muzRB.Text = "Muž";
            this.muzRB.UseVisualStyleBackColor = true;
            // 
            // zenaRB
            // 
            this.zenaRB.AutoSize = true;
            this.zenaRB.Location = new System.Drawing.Point(61, 7);
            this.zenaRB.Name = "zenaRB";
            this.zenaRB.Size = new System.Drawing.Size(50, 17);
            this.zenaRB.TabIndex = 19;
            this.zenaRB.Text = "Žena";
            this.zenaRB.UseVisualStyleBackColor = true;
            // 
            // pridatZamestnance
            // 
            this.pridatZamestnance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pridatZamestnance.Location = new System.Drawing.Point(13, 363);
            this.pridatZamestnance.Name = "pridatZamestnance";
            this.pridatZamestnance.Size = new System.Drawing.Size(148, 60);
            this.pridatZamestnance.TabIndex = 1;
            this.pridatZamestnance.Text = "Přidat zaměstnance";
            this.pridatZamestnance.UseVisualStyleBackColor = true;
            this.pridatZamestnance.Click += new System.EventHandler(this.pridatZamestnance_Click);
            // 
            // TB8
            // 
            this.TB8.Location = new System.Drawing.Point(160, 295);
            this.TB8.Name = "TB8";
            this.TB8.Size = new System.Drawing.Size(102, 20);
            this.TB8.TabIndex = 17;
            // 
            // TB7
            // 
            this.TB7.Location = new System.Drawing.Point(160, 262);
            this.TB7.Name = "TB7";
            this.TB7.Size = new System.Drawing.Size(102, 20);
            this.TB7.TabIndex = 16;
            // 
            // TB6
            // 
            this.TB6.Location = new System.Drawing.Point(160, 225);
            this.TB6.Name = "TB6";
            this.TB6.Size = new System.Drawing.Size(102, 20);
            this.TB6.TabIndex = 15;
            // 
            // TB5
            // 
            this.TB5.Location = new System.Drawing.Point(160, 192);
            this.TB5.Name = "TB5";
            this.TB5.Size = new System.Drawing.Size(102, 20);
            this.TB5.TabIndex = 14;
            // 
            // TB4
            // 
            this.TB4.Location = new System.Drawing.Point(160, 129);
            this.TB4.Name = "TB4";
            this.TB4.Size = new System.Drawing.Size(102, 20);
            this.TB4.TabIndex = 13;
            // 
            // TB3
            // 
            this.TB3.Location = new System.Drawing.Point(160, 96);
            this.TB3.Name = "TB3";
            this.TB3.Size = new System.Drawing.Size(187, 20);
            this.TB3.TabIndex = 12;
            // 
            // TB2
            // 
            this.TB2.Location = new System.Drawing.Point(160, 63);
            this.TB2.Name = "TB2";
            this.TB2.Size = new System.Drawing.Size(102, 20);
            this.TB2.TabIndex = 11;
            // 
            // TB1
            // 
            this.TB1.Location = new System.Drawing.Point(160, 30);
            this.TB1.Name = "TB1";
            this.TB1.Size = new System.Drawing.Size(102, 20);
            this.TB1.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Vyhozen:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Plat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Pozice:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Datum nástupu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Datum narození:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pohlaví:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefonní číslo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Příjmení:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jméno:";
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
            this.jmeno,
            this.prijmeni,
            this.datum_nastupu,
            this.pozice});
            this.dataGridView1.Location = new System.Drawing.Point(128, 491);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(401, 150);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id_zamestnance
            // 
            this.id_zamestnance.HeaderText = "ID";
            this.id_zamestnance.Name = "id_zamestnance";
            this.id_zamestnance.ReadOnly = true;
            this.id_zamestnance.Width = 30;
            // 
            // jmeno
            // 
            this.jmeno.HeaderText = "Jméno";
            this.jmeno.Name = "jmeno";
            this.jmeno.ReadOnly = true;
            this.jmeno.Width = 80;
            // 
            // prijmeni
            // 
            this.prijmeni.HeaderText = "Příjmení";
            this.prijmeni.Name = "prijmeni";
            this.prijmeni.ReadOnly = true;
            this.prijmeni.Width = 80;
            // 
            // datum_nastupu
            // 
            this.datum_nastupu.HeaderText = "Datum nástupu";
            this.datum_nastupu.Name = "datum_nastupu";
            this.datum_nastupu.ReadOnly = true;
            this.datum_nastupu.Width = 110;
            // 
            // pozice
            // 
            this.pozice.HeaderText = "Pozice";
            this.pozice.Name = "pozice";
            this.pozice.ReadOnly = true;
            this.pozice.Width = 80;
            // 
            // ZamestnanciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 749);
            this.Controls.Add(this.switchForm);
            this.Controls.Add(this.zobrazitVyhozene);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.spravaGB);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ZamestnanciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa zaměstnanců";
            this.spravaGB.ResumeLayout(false);
            this.spravaGB.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button switchForm;
        private System.Windows.Forms.CheckBox zobrazitVyhozene;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox spravaGB;
        private System.Windows.Forms.Button odebratZamestnance;
        private System.Windows.Forms.Button upravitZamestnance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton anoRB;
        private System.Windows.Forms.RadioButton neRB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton muzRB;
        private System.Windows.Forms.RadioButton zenaRB;
        private System.Windows.Forms.Button pridatZamestnance;
        private System.Windows.Forms.TextBox TB8;
        private System.Windows.Forms.TextBox TB7;
        private System.Windows.Forms.TextBox TB6;
        private System.Windows.Forms.TextBox TB5;
        private System.Windows.Forms.TextBox TB4;
        private System.Windows.Forms.TextBox TB3;
        private System.Windows.Forms.TextBox TB2;
        private System.Windows.Forms.TextBox TB1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_zamestnance;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn prijmeni;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum_nastupu;
        private System.Windows.Forms.DataGridViewTextBoxColumn pozice;
    }
}