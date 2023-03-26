namespace Steganography
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newImageNameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.existingImagePathTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveTxtFileLocationTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.hiddenTextTB = new System.Windows.Forms.TextBox();
            this.getInfoLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.existingImagePathTB2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.newPublicImageNameTB = new System.Windows.Forms.TextBox();
            this.publicImagePathTB = new System.Windows.Forms.TextBox();
            this.privateImagePathTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.detectSteganographyImagePathTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newImageNameTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.existingImagePathTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(42, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zápis textu do obrázku";
            // 
            // newImageNameTB
            // 
            this.newImageNameTB.Location = new System.Drawing.Point(243, 94);
            this.newImageNameTB.Name = "newImageNameTB";
            this.newImageNameTB.Size = new System.Drawing.Size(545, 23);
            this.newImageNameTB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Název nového obrázku bez přípony:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // existingImagePathTB
            // 
            this.existingImagePathTB.Location = new System.Drawing.Point(244, 63);
            this.existingImagePathTB.Name = "existingImagePathTB";
            this.existingImagePathTB.Size = new System.Drawing.Size(544, 23);
            this.existingImagePathTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cesta k existujícímu obrázku:";
            // 
            // textTB
            // 
            this.textTB.Location = new System.Drawing.Point(244, 34);
            this.textTB.Name = "textTB";
            this.textTB.Size = new System.Drawing.Size(544, 23);
            this.textTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text k ukrytí:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.saveTxtFileLocationTB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.hiddenTextTB);
            this.groupBox2.Controls.Add(this.getInfoLabel);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.existingImagePathTB2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(871, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(809, 473);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Získání informace z obrázku";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Skrytý obrázek:";
            this.label10.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(443, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Skrytý text:";
            this.label6.Visible = false;
            // 
            // saveTxtFileLocationTB
            // 
            this.saveTxtFileLocationTB.Location = new System.Drawing.Point(164, 379);
            this.saveTxtFileLocationTB.Name = "saveTxtFileLocationTB";
            this.saveTxtFileLocationTB.Size = new System.Drawing.Size(624, 23);
            this.saveTxtFileLocationTB.TabIndex = 10;
            this.saveTxtFileLocationTB.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lokace k uložení souboru:";
            this.label5.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(370, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Uložit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // hiddenTextTB
            // 
            this.hiddenTextTB.Location = new System.Drawing.Point(10, 171);
            this.hiddenTextTB.Multiline = true;
            this.hiddenTextTB.Name = "hiddenTextTB";
            this.hiddenTextTB.Size = new System.Drawing.Size(415, 202);
            this.hiddenTextTB.TabIndex = 7;
            this.hiddenTextTB.Visible = false;
            // 
            // getInfoLabel
            // 
            this.getInfoLabel.AutoSize = true;
            this.getInfoLabel.Location = new System.Drawing.Point(9, 144);
            this.getInfoLabel.Name = "getInfoLabel";
            this.getInfoLabel.Size = new System.Drawing.Size(0, 15);
            this.getInfoLabel.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Získat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // existingImagePathTB2
            // 
            this.existingImagePathTB2.Location = new System.Drawing.Point(240, 34);
            this.existingImagePathTB2.Name = "existingImagePathTB2";
            this.existingImagePathTB2.Size = new System.Drawing.Size(544, 23);
            this.existingImagePathTB2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cesta k existujícímu obrázku:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.newPublicImageNameTB);
            this.groupBox3.Controls.Add(this.publicImagePathTB);
            this.groupBox3.Controls.Add(this.privateImagePathTB);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(44, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(811, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zápis souboru do obrázku";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(372, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Uložit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // newPublicImageNameTB
            // 
            this.newPublicImageNameTB.Location = new System.Drawing.Point(238, 107);
            this.newPublicImageNameTB.Name = "newPublicImageNameTB";
            this.newPublicImageNameTB.Size = new System.Drawing.Size(544, 23);
            this.newPublicImageNameTB.TabIndex = 9;
            // 
            // publicImagePathTB
            // 
            this.publicImagePathTB.Location = new System.Drawing.Point(238, 68);
            this.publicImagePathTB.Name = "publicImagePathTB";
            this.publicImagePathTB.Size = new System.Drawing.Size(544, 23);
            this.publicImagePathTB.TabIndex = 8;
            // 
            // privateImagePathTB
            // 
            this.privateImagePathTB.Location = new System.Drawing.Point(238, 27);
            this.privateImagePathTB.Name = "privateImagePathTB";
            this.privateImagePathTB.Size = new System.Drawing.Size(544, 23);
            this.privateImagePathTB.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Název nového obrázku bez přípony:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cesta k veřejnému obrázku:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cesta k ukrývanému souboru:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.detectSteganographyImagePathTB);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(44, 392);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(808, 133);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detekce steganografie";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 15);
            this.label12.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(373, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Získat";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // detectSteganographyImagePathTB
            // 
            this.detectSteganographyImagePathTB.Location = new System.Drawing.Point(243, 34);
            this.detectSteganographyImagePathTB.Name = "detectSteganographyImagePathTB";
            this.detectSteganographyImagePathTB.Size = new System.Drawing.Size(544, 23);
            this.detectSteganographyImagePathTB.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Cesta k existujícímu obrázku:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1736, 558);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganografie projekt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private TextBox existingImagePathTB;
        private Label label2;
        private TextBox textTB;
        private Label label1;
        private TextBox newImageNameTB;
        private Label label3;
        private GroupBox groupBox2;
        private Button button2;
        private TextBox existingImagePathTB2;
        private Label label4;
        private Button button3;
        private TextBox hiddenTextTB;
        private Label getInfoLabel;
        private TextBox saveTxtFileLocationTB;
        private Label label5;
        private Label label6;
        private GroupBox groupBox3;
        private Label label8;
        private Label label7;
        private Button button4;
        private TextBox newPublicImageNameTB;
        private TextBox publicImagePathTB;
        private TextBox privateImagePathTB;
        private Label label9;
        private PictureBox pictureBox1;
        private Label label10;
        private GroupBox groupBox4;
        private Label label12;
        private Button button5;
        private TextBox detectSteganographyImagePathTB;
        private Label label11;
    }
}