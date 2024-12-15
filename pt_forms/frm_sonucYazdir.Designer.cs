namespace gymKing.pt_forms
{
    partial class frm_sonucYazdir
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_kisiler = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.richtxt_yorumlama = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbtn_pdf = new System.Windows.Forms.RadioButton();
            this.rdbtn_word = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_vucut = new System.Windows.Forms.DataGridView();
            this.dgv_makro = new System.Windows.Forms.DataGridView();
            this.dgv_oranlar = new System.Windows.Forms.DataGridView();
            this.dgv_hesaplamalar = new System.Windows.Forms.DataGridView();
            this.richtxt_eknot = new System.Windows.Forms.RichTextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kisiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vucut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_makro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oranlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hesaplamalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_kisiler
            // 
            this.dgv_kisiler.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_kisiler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_kisiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kisiler.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_kisiler.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_kisiler.Location = new System.Drawing.Point(2, 52);
            this.dgv_kisiler.Name = "dgv_kisiler";
            this.dgv_kisiler.Size = new System.Drawing.Size(564, 173);
            this.dgv_kisiler.TabIndex = 0;
            this.dgv_kisiler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kayıtlı Kisiler";
            // 
            // richtxt_yorumlama
            // 
            this.richtxt_yorumlama.BackColor = System.Drawing.Color.Silver;
            this.richtxt_yorumlama.ForeColor = System.Drawing.Color.Ivory;
            this.richtxt_yorumlama.Location = new System.Drawing.Point(2, 454);
            this.richtxt_yorumlama.Name = "richtxt_yorumlama";
            this.richtxt_yorumlama.Size = new System.Drawing.Size(857, 219);
            this.richtxt_yorumlama.TabIndex = 4;
            this.richtxt_yorumlama.Text = "Analiz Yorumları";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Britannic Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(975, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dosya Türü";
            // 
            // rdbtn_pdf
            // 
            this.rdbtn_pdf.AutoSize = true;
            this.rdbtn_pdf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn_pdf.Location = new System.Drawing.Point(935, 437);
            this.rdbtn_pdf.Name = "rdbtn_pdf";
            this.rdbtn_pdf.Size = new System.Drawing.Size(95, 23);
            this.rdbtn_pdf.TabIndex = 7;
            this.rdbtn_pdf.TabStop = true;
            this.rdbtn_pdf.Text = "PDF(.pdf)";
            this.rdbtn_pdf.UseVisualStyleBackColor = true;
            // 
            // rdbtn_word
            // 
            this.rdbtn_word.AutoSize = true;
            this.rdbtn_word.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn_word.Location = new System.Drawing.Point(1057, 437);
            this.rdbtn_word.Name = "rdbtn_word";
            this.rdbtn_word.Size = new System.Drawing.Size(141, 23);
            this.rdbtn_word.TabIndex = 8;
            this.rdbtn_word.TabStop = true;
            this.rdbtn_word.Text = "MS Word(.docx)";
            this.rdbtn_word.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(982, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Sonuçları Yazdır";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gymKing.kaynaklar.arrow_left;
            this.pictureBox1.Location = new System.Drawing.Point(1176, 586);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dgv_vucut
            // 
            this.dgv_vucut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_vucut.Location = new System.Drawing.Point(92, 224);
            this.dgv_vucut.Name = "dgv_vucut";
            this.dgv_vucut.Size = new System.Drawing.Size(767, 60);
            this.dgv_vucut.TabIndex = 11;
            // 
            // dgv_makro
            // 
            this.dgv_makro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_makro.Location = new System.Drawing.Point(92, 281);
            this.dgv_makro.Name = "dgv_makro";
            this.dgv_makro.Size = new System.Drawing.Size(767, 59);
            this.dgv_makro.TabIndex = 13;
            // 
            // dgv_oranlar
            // 
            this.dgv_oranlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_oranlar.Location = new System.Drawing.Point(92, 338);
            this.dgv_oranlar.Name = "dgv_oranlar";
            this.dgv_oranlar.Size = new System.Drawing.Size(767, 59);
            this.dgv_oranlar.TabIndex = 15;
            // 
            // dgv_hesaplamalar
            // 
            this.dgv_hesaplamalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hesaplamalar.Location = new System.Drawing.Point(92, 395);
            this.dgv_hesaplamalar.Name = "dgv_hesaplamalar";
            this.dgv_hesaplamalar.Size = new System.Drawing.Size(767, 60);
            this.dgv_hesaplamalar.TabIndex = 18;
            // 
            // richtxt_eknot
            // 
            this.richtxt_eknot.BackColor = System.Drawing.Color.Silver;
            this.richtxt_eknot.ForeColor = System.Drawing.Color.Ivory;
            this.richtxt_eknot.Location = new System.Drawing.Point(857, 43);
            this.richtxt_eknot.Name = "richtxt_eknot";
            this.richtxt_eknot.Size = new System.Drawing.Size(414, 335);
            this.richtxt_eknot.TabIndex = 21;
            this.richtxt_eknot.Text = "Eğitmenin ek notları";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::gymKing.kaynaklar.transparentGYMKING;
            this.pictureBox7.Location = new System.Drawing.Point(562, 43);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(297, 182);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 38;
            this.pictureBox7.TabStop = false;
            // 
            // frm_sonucYazdir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.richtxt_eknot);
            this.Controls.Add(this.dgv_hesaplamalar);
            this.Controls.Add(this.dgv_oranlar);
            this.Controls.Add(this.dgv_makro);
            this.Controls.Add(this.dgv_vucut);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdbtn_word);
            this.Controls.Add(this.rdbtn_pdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richtxt_yorumlama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_kisiler);
            this.Name = "frm_sonucYazdir";
            this.Text = "frm_sonucYazdir";
            this.Load += new System.EventHandler(this.frm_sonucYazdir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kisiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vucut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_makro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oranlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hesaplamalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_kisiler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richtxt_yorumlama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbtn_pdf;
        private System.Windows.Forms.RadioButton rdbtn_word;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_vucut;
        private System.Windows.Forms.DataGridView dgv_makro;
        private System.Windows.Forms.DataGridView dgv_oranlar;
        private System.Windows.Forms.DataGridView dgv_hesaplamalar;
        private System.Windows.Forms.RichTextBox richtxt_eknot;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}