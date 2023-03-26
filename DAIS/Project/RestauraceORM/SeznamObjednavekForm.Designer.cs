namespace RestauraceORM
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zakColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRozColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vyplacenaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.objednavkaCB2 = new System.Windows.Forms.ComboBox();
            this.smazatButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rozvazkaCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.jmenoZamCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jmenoZakCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.objednavkaCB1 = new System.Windows.Forms.ComboBox();
            this.aktualizovatButton = new System.Windows.Forms.Button();
            this.cenaTB = new System.Windows.Forms.TextBox();
            this.datumTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.druhyFormButton = new System.Windows.Forms.Button();
            this.vyplacenaCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.zakColumn,
            this.zamColumn,
            this.idRozColumn,
            this.datumColumn,
            this.cenaColumn,
            this.vyplacenaColumn});
            this.dataGridView1.Location = new System.Drawing.Point(55, 373);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(731, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "ID objednávky";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            // 
            // zakColumn
            // 
            this.zakColumn.HeaderText = "Jméno zákazníka";
            this.zakColumn.Name = "zakColumn";
            this.zakColumn.ReadOnly = true;
            this.zakColumn.Width = 120;
            // 
            // zamColumn
            // 
            this.zamColumn.HeaderText = "Jméno zaměstnance";
            this.zamColumn.Name = "zamColumn";
            this.zamColumn.ReadOnly = true;
            this.zamColumn.Width = 130;
            // 
            // idRozColumn
            // 
            this.idRozColumn.HeaderText = "ID rozvážky";
            this.idRozColumn.Name = "idRozColumn";
            this.idRozColumn.ReadOnly = true;
            this.idRozColumn.Width = 90;
            // 
            // datumColumn
            // 
            this.datumColumn.HeaderText = "Datum vytvoření";
            this.datumColumn.Name = "datumColumn";
            this.datumColumn.ReadOnly = true;
            this.datumColumn.Width = 110;
            // 
            // cenaColumn
            // 
            this.cenaColumn.HeaderText = "Cena";
            this.cenaColumn.Name = "cenaColumn";
            this.cenaColumn.ReadOnly = true;
            this.cenaColumn.Width = 50;
            // 
            // vyplacenaColumn
            // 
            this.vyplacenaColumn.HeaderText = "Vyplacena";
            this.vyplacenaColumn.Name = "vyplacenaColumn";
            this.vyplacenaColumn.ReadOnly = true;
            this.vyplacenaColumn.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seznam objednávek";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.objednavkaCB2);
            this.groupBox1.Controls.Add(this.smazatButton);
            this.groupBox1.Location = new System.Drawing.Point(426, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 116);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Smazání objednávky";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Objednávka ke smazání:";
            // 
            // objednavkaCB2
            // 
            this.objednavkaCB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objednavkaCB2.DropDownWidth = 800;
            this.objednavkaCB2.FormattingEnabled = true;
            this.objednavkaCB2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.objednavkaCB2.Location = new System.Drawing.Point(138, 31);
            this.objednavkaCB2.Name = "objednavkaCB2";
            this.objednavkaCB2.Size = new System.Drawing.Size(121, 21);
            this.objednavkaCB2.TabIndex = 3;
            // 
            // smazatButton
            // 
            this.smazatButton.Location = new System.Drawing.Point(98, 77);
            this.smazatButton.Name = "smazatButton";
            this.smazatButton.Size = new System.Drawing.Size(75, 23);
            this.smazatButton.TabIndex = 2;
            this.smazatButton.Text = "Smazat";
            this.smazatButton.UseVisualStyleBackColor = true;
            this.smazatButton.Click += new System.EventHandler(this.smazatButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vyplacenaCB);
            this.groupBox2.Controls.Add(this.rozvazkaCB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.jmenoZamCB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.jmenoZakCB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.objednavkaCB1);
            this.groupBox2.Controls.Add(this.aktualizovatButton);
            this.groupBox2.Controls.Add(this.cenaTB);
            this.groupBox2.Controls.Add(this.datumTB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(119, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 312);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aktualizace objednávky";
            // 
            // rozvazkaCB
            // 
            this.rozvazkaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rozvazkaCB.DropDownWidth = 550;
            this.rozvazkaCB.FormattingEnabled = true;
            this.rozvazkaCB.Location = new System.Drawing.Point(141, 135);
            this.rozvazkaCB.Name = "rozvazkaCB";
            this.rozvazkaCB.Size = new System.Drawing.Size(141, 21);
            this.rozvazkaCB.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Rozvážka:";
            // 
            // jmenoZamCB
            // 
            this.jmenoZamCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jmenoZamCB.FormattingEnabled = true;
            this.jmenoZamCB.Location = new System.Drawing.Point(141, 99);
            this.jmenoZamCB.Name = "jmenoZamCB";
            this.jmenoZamCB.Size = new System.Drawing.Size(142, 21);
            this.jmenoZamCB.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Jméno zaměstnance:";
            // 
            // jmenoZakCB
            // 
            this.jmenoZakCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jmenoZakCB.DropDownWidth = 150;
            this.jmenoZakCB.FormattingEnabled = true;
            this.jmenoZakCB.Location = new System.Drawing.Point(140, 63);
            this.jmenoZakCB.Name = "jmenoZakCB";
            this.jmenoZakCB.Size = new System.Drawing.Size(142, 21);
            this.jmenoZakCB.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Jméno zákazníka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Objednávka k aktualizaci:";
            // 
            // objednavkaCB1
            // 
            this.objednavkaCB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objednavkaCB1.DropDownWidth = 800;
            this.objednavkaCB1.FormattingEnabled = true;
            this.objednavkaCB1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.objednavkaCB1.Location = new System.Drawing.Point(141, 30);
            this.objednavkaCB1.Name = "objednavkaCB1";
            this.objednavkaCB1.Size = new System.Drawing.Size(121, 21);
            this.objednavkaCB1.TabIndex = 15;
            this.objednavkaCB1.SelectedIndexChanged += new System.EventHandler(this.objednavkaCB1_SelectedIndexChanged);
            // 
            // aktualizovatButton
            // 
            this.aktualizovatButton.Location = new System.Drawing.Point(97, 271);
            this.aktualizovatButton.Name = "aktualizovatButton";
            this.aktualizovatButton.Size = new System.Drawing.Size(75, 23);
            this.aktualizovatButton.TabIndex = 14;
            this.aktualizovatButton.Text = "Akutalizovat";
            this.aktualizovatButton.UseVisualStyleBackColor = true;
            this.aktualizovatButton.Click += new System.EventHandler(this.aktualizovatButton_Click);
            // 
            // cenaTB
            // 
            this.cenaTB.Location = new System.Drawing.Point(141, 203);
            this.cenaTB.Name = "cenaTB";
            this.cenaTB.Size = new System.Drawing.Size(43, 20);
            this.cenaTB.TabIndex = 12;
            // 
            // datumTB
            // 
            this.datumTB.Location = new System.Drawing.Point(141, 169);
            this.datumTB.Name = "datumTB";
            this.datumTB.Size = new System.Drawing.Size(134, 20);
            this.datumTB.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Vyplacena:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cena:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Datum vytvoření:";
            // 
            // druhyFormButton
            // 
            this.druhyFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.druhyFormButton.Location = new System.Drawing.Point(287, 541);
            this.druhyFormButton.Name = "druhyFormButton";
            this.druhyFormButton.Size = new System.Drawing.Size(271, 46);
            this.druhyFormButton.TabIndex = 4;
            this.druhyFormButton.Text = "Přejít na druhý formulář";
            this.druhyFormButton.UseVisualStyleBackColor = true;
            this.druhyFormButton.Click += new System.EventHandler(this.druhyForm_Click);
            // 
            // vyplacenaCB
            // 
            this.vyplacenaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vyplacenaCB.FormattingEnabled = true;
            this.vyplacenaCB.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.vyplacenaCB.Location = new System.Drawing.Point(140, 240);
            this.vyplacenaCB.Name = "vyplacenaCB";
            this.vyplacenaCB.Size = new System.Drawing.Size(44, 21);
            this.vyplacenaCB.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 615);
            this.Controls.Add(this.druhyFormButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Seznam objednávek";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button smazatButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button aktualizovatButton;
        private System.Windows.Forms.TextBox cenaTB;
        private System.Windows.Forms.TextBox datumTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button druhyFormButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox objednavkaCB2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox objednavkaCB1;
        private System.Windows.Forms.ComboBox jmenoZamCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox jmenoZakCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zakColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRozColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vyplacenaColumn;
        private System.Windows.Forms.ComboBox rozvazkaCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vyplacenaCB;
    }
}