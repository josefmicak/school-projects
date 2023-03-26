namespace MIC0378
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
            this.idL = new System.Windows.Forms.Label();
            this.idTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.nameL = new System.Windows.Forms.Label();
            this.adultL = new System.Windows.Forms.Label();
            this.addB = new System.Windows.Forms.Button();
            this.editB = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.loadB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.adultRB2 = new System.Windows.Forms.RadioButton();
            this.adultRB1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteAllB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // idL
            // 
            this.idL.AutoSize = true;
            this.idL.Location = new System.Drawing.Point(6, 29);
            this.idL.Name = "idL";
            this.idL.Size = new System.Drawing.Size(21, 13);
            this.idL.TabIndex = 0;
            this.idL.Text = "ID:";
            // 
            // idTB
            // 
            this.idTB.Location = new System.Drawing.Point(82, 26);
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(100, 20);
            this.idTB.TabIndex = 1;
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(82, 63);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 20);
            this.nameTB.TabIndex = 3;
            // 
            // nameL
            // 
            this.nameL.AutoSize = true;
            this.nameL.Location = new System.Drawing.Point(6, 66);
            this.nameL.Name = "nameL";
            this.nameL.Size = new System.Drawing.Size(38, 13);
            this.nameL.TabIndex = 2;
            this.nameL.Text = "Name:";
            // 
            // adultL
            // 
            this.adultL.AutoSize = true;
            this.adultL.Location = new System.Drawing.Point(6, 106);
            this.adultL.Name = "adultL";
            this.adultL.Size = new System.Drawing.Size(34, 13);
            this.adultL.TabIndex = 4;
            this.adultL.Text = "Adult:";
            // 
            // addB
            // 
            this.addB.BackColor = System.Drawing.Color.White;
            this.addB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addB.Location = new System.Drawing.Point(71, 144);
            this.addB.Name = "addB";
            this.addB.Size = new System.Drawing.Size(86, 38);
            this.addB.TabIndex = 6;
            this.addB.Text = "Add";
            this.addB.UseVisualStyleBackColor = false;
            this.addB.Click += new System.EventHandler(this.addB_Click);
            // 
            // editB
            // 
            this.editB.BackColor = System.Drawing.Color.White;
            this.editB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editB.Location = new System.Drawing.Point(54, 37);
            this.editB.Name = "editB";
            this.editB.Size = new System.Drawing.Size(100, 36);
            this.editB.TabIndex = 0;
            this.editB.Text = "Edit";
            this.editB.UseVisualStyleBackColor = false;
            this.editB.Click += new System.EventHandler(this.editB_Click);
            // 
            // deleteB
            // 
            this.deleteB.BackColor = System.Drawing.Color.White;
            this.deleteB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteB.Location = new System.Drawing.Point(176, 37);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(100, 36);
            this.deleteB.TabIndex = 1;
            this.deleteB.Text = "Delete";
            this.deleteB.UseVisualStyleBackColor = false;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // loadB
            // 
            this.loadB.BackColor = System.Drawing.Color.White;
            this.loadB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadB.Location = new System.Drawing.Point(38, 33);
            this.loadB.Name = "loadB";
            this.loadB.Size = new System.Drawing.Size(145, 50);
            this.loadB.TabIndex = 3;
            this.loadB.Text = "Load the XML file";
            this.loadB.UseVisualStyleBackColor = false;
            this.loadB.Click += new System.EventHandler(this.loadB_Click);
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.Color.White;
            this.saveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveB.Location = new System.Drawing.Point(38, 106);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(142, 48);
            this.saveB.TabIndex = 4;
            this.saveB.Text = "Save to XML file";
            this.saveB.UseVisualStyleBackColor = false;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(54, 97);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(344, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adult";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.adultRB2);
            this.groupBox1.Controls.Add(this.adultRB1);
            this.groupBox1.Controls.Add(this.nameL);
            this.groupBox1.Controls.Add(this.addB);
            this.groupBox1.Controls.Add(this.idTB);
            this.groupBox1.Controls.Add(this.idL);
            this.groupBox1.Controls.Add(this.nameTB);
            this.groupBox1.Controls.Add(this.adultL);
            this.groupBox1.Location = new System.Drawing.Point(4, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 188);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add entry";
            // 
            // adultRB2
            // 
            this.adultRB2.AutoSize = true;
            this.adultRB2.Location = new System.Drawing.Point(143, 106);
            this.adultRB2.Name = "adultRB2";
            this.adultRB2.Size = new System.Drawing.Size(39, 17);
            this.adultRB2.TabIndex = 8;
            this.adultRB2.Text = "No";
            this.adultRB2.UseVisualStyleBackColor = true;
            // 
            // adultRB1
            // 
            this.adultRB1.AutoSize = true;
            this.adultRB1.Checked = true;
            this.adultRB1.Location = new System.Drawing.Point(82, 106);
            this.adultRB1.Name = "adultRB1";
            this.adultRB1.Size = new System.Drawing.Size(43, 17);
            this.adultRB1.TabIndex = 7;
            this.adultRB1.TabStop = true;
            this.adultRB1.Text = "Yes";
            this.adultRB1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteAllB);
            this.groupBox2.Controls.Add(this.editB);
            this.groupBox2.Controls.Add(this.deleteB);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(4, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 279);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage entries";
            // 
            // deleteAllB
            // 
            this.deleteAllB.BackColor = System.Drawing.Color.White;
            this.deleteAllB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllB.Location = new System.Drawing.Point(298, 37);
            this.deleteAllB.Name = "deleteAllB";
            this.deleteAllB.Size = new System.Drawing.Size(100, 36);
            this.deleteAllB.TabIndex = 3;
            this.deleteAllB.Text = "Delete all";
            this.deleteAllB.UseVisualStyleBackColor = false;
            this.deleteAllB.Click += new System.EventHandler(this.DeleteAllB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.loadB);
            this.groupBox3.Controls.Add(this.saveB);
            this.groupBox3.Location = new System.Drawing.Point(242, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 188);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manage file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 484);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "User database";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addB;
        private System.Windows.Forms.Label adultL;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label nameL;
        private System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.Label idL;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button loadB;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button editB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton adultRB2;
        private System.Windows.Forms.RadioButton adultRB1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deleteAllB;
    }
}

