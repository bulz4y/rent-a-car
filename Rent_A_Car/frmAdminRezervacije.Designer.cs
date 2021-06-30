namespace Rent_A_Car
{
    partial class frmAdminRezervacije
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
            this.lbRezervacije = new System.Windows.Forms.ListBox();
            this.lbPonude = new System.Windows.Forms.ListBox();
            this.Ponude = new System.Windows.Forms.Label();
            this.Rezervacije = new System.Windows.Forms.Label();
            this.dtDatumPreuzimanja = new System.Windows.Forms.DateTimePicker();
            this.dtDatumVracanja = new System.Windows.Forms.DateTimePicker();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnKreirajNovu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRezervacije = new System.Windows.Forms.Label();
            this.lblPonude = new System.Windows.Forms.Label();
            this.lblKupac = new System.Windows.Forms.Label();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.btnNazad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRezervacije
            // 
            this.lbRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRezervacije.FormattingEnabled = true;
            this.lbRezervacije.HorizontalScrollbar = true;
            this.lbRezervacije.ItemHeight = 16;
            this.lbRezervacije.Location = new System.Drawing.Point(326, 127);
            this.lbRezervacije.Name = "lbRezervacije";
            this.lbRezervacije.Size = new System.Drawing.Size(620, 132);
            this.lbRezervacije.TabIndex = 0;
            this.lbRezervacije.SelectedIndexChanged += new System.EventHandler(this.lbRezervacije_SelectedIndexChanged);
            // 
            // lbPonude
            // 
            this.lbPonude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPonude.FormattingEnabled = true;
            this.lbPonude.HorizontalScrollbar = true;
            this.lbPonude.ItemHeight = 16;
            this.lbPonude.Location = new System.Drawing.Point(12, 127);
            this.lbPonude.Name = "lbPonude";
            this.lbPonude.Size = new System.Drawing.Size(293, 132);
            this.lbPonude.TabIndex = 1;
            this.lbPonude.SelectedIndexChanged += new System.EventHandler(this.lbPonude_SelectedIndexChanged);
            // 
            // Ponude
            // 
            this.Ponude.AutoSize = true;
            this.Ponude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ponude.Location = new System.Drawing.Point(13, 105);
            this.Ponude.Name = "Ponude";
            this.Ponude.Size = new System.Drawing.Size(61, 16);
            this.Ponude.TabIndex = 2;
            this.Ponude.Text = "Ponude";
            // 
            // Rezervacije
            // 
            this.Rezervacije.AutoSize = true;
            this.Rezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rezervacije.Location = new System.Drawing.Point(323, 108);
            this.Rezervacije.Name = "Rezervacije";
            this.Rezervacije.Size = new System.Drawing.Size(145, 16);
            this.Rezervacije.TabIndex = 3;
            this.Rezervacije.Text = "Rezervacije kupca: ";
            // 
            // dtDatumPreuzimanja
            // 
            this.dtDatumPreuzimanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDatumPreuzimanja.Location = new System.Drawing.Point(478, 22);
            this.dtDatumPreuzimanja.Name = "dtDatumPreuzimanja";
            this.dtDatumPreuzimanja.Size = new System.Drawing.Size(222, 20);
            this.dtDatumPreuzimanja.TabIndex = 5;
            // 
            // dtDatumVracanja
            // 
            this.dtDatumVracanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDatumVracanja.Location = new System.Drawing.Point(478, 65);
            this.dtDatumVracanja.Name = "dtDatumVracanja";
            this.dtDatumVracanja.Size = new System.Drawing.Size(222, 20);
            this.dtDatumVracanja.TabIndex = 6;
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAzuriraj.Location = new System.Drawing.Point(385, 267);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(123, 28);
            this.btnAzuriraj.TabIndex = 7;
            this.btnAzuriraj.Text = "Ažuriraj";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            this.btnAzuriraj.Click += new System.EventHandler(this.btnAzuriraj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.Location = new System.Drawing.Point(510, 267);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(123, 28);
            this.btnObrisi.TabIndex = 8;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnKreirajNovu
            // 
            this.btnKreirajNovu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKreirajNovu.Location = new System.Drawing.Point(639, 267);
            this.btnKreirajNovu.Name = "btnKreirajNovu";
            this.btnKreirajNovu.Size = new System.Drawing.Size(123, 28);
            this.btnKreirajNovu.TabIndex = 9;
            this.btnKreirajNovu.Text = "Kreiraj novu";
            this.btnKreirajNovu.UseVisualStyleBackColor = true;
            this.btnKreirajNovu.Click += new System.EventHandler(this.btnKreirajNovu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Datum preuzimanja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Datum vraćanja";
            // 
            // lblRezervacije
            // 
            this.lblRezervacije.AutoSize = true;
            this.lblRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRezervacije.Location = new System.Drawing.Point(499, 177);
            this.lblRezervacije.Name = "lblRezervacije";
            this.lblRezervacije.Size = new System.Drawing.Size(201, 16);
            this.lblRezervacije.TabIndex = 12;
            this.lblRezervacije.Text = "Trenutno Nema Rezervacija";
            this.lblRezervacije.Visible = false;
            // 
            // lblPonude
            // 
            this.lblPonude.AutoSize = true;
            this.lblPonude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPonude.Location = new System.Drawing.Point(58, 177);
            this.lblPonude.Name = "lblPonude";
            this.lblPonude.Size = new System.Drawing.Size(171, 16);
            this.lblPonude.TabIndex = 13;
            this.lblPonude.Text = "Trenutno Nema Ponuda";
            this.lblPonude.Visible = false;
            // 
            // lblKupac
            // 
            this.lblKupac.AutoSize = true;
            this.lblKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupac.Location = new System.Drawing.Point(474, 108);
            this.lblKupac.Name = "lblKupac";
            this.lblKupac.Size = new System.Drawing.Size(0, 16);
            this.lblKupac.TabIndex = 14;
            // 
            // btnOdjava
            // 
            this.btnOdjava.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdjava.Location = new System.Drawing.Point(872, 2);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(87, 23);
            this.btnOdjava.TabIndex = 15;
            this.btnOdjava.Text = "Odjavi se";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // btnNazad
            // 
            this.btnNazad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNazad.Location = new System.Drawing.Point(1, 2);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(87, 23);
            this.btnNazad.TabIndex = 16;
            this.btnNazad.Text = "Nazad";
            this.btnNazad.UseVisualStyleBackColor = true;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // frmAdminRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.btnOdjava);
            this.Controls.Add(this.lblKupac);
            this.Controls.Add(this.lblPonude);
            this.Controls.Add(this.lblRezervacije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKreirajNovu);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.dtDatumVracanja);
            this.Controls.Add(this.dtDatumPreuzimanja);
            this.Controls.Add(this.Rezervacije);
            this.Controls.Add(this.Ponude);
            this.Controls.Add(this.lbPonude);
            this.Controls.Add(this.lbRezervacije);
            this.Name = "frmAdminRezervacije";
            this.Text = "frmAdminRezervacije";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminRezervacije_FormClosed);
            this.Load += new System.EventHandler(this.frmAdminRezervacije_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRezervacije;
        private System.Windows.Forms.ListBox lbPonude;
        private System.Windows.Forms.Label Ponude;
        private System.Windows.Forms.Label Rezervacije;
        private System.Windows.Forms.DateTimePicker dtDatumPreuzimanja;
        private System.Windows.Forms.DateTimePicker dtDatumVracanja;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnKreirajNovu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRezervacije;
        private System.Windows.Forms.Label lblPonude;
        private System.Windows.Forms.Label lblKupac;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Button btnNazad;
    }
}