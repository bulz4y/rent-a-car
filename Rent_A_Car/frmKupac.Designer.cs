namespace Rent_A_Car
{
    partial class frmKupac
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFormaRezervacije = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.lblRez = new System.Windows.Forms.Label();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.lblKupac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRezervacije
            // 
            this.lbRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRezervacije.HorizontalScrollbar = true;
            this.lbRezervacije.ItemHeight = 16;
            this.lbRezervacije.Location = new System.Drawing.Point(81, 78);
            this.lbRezervacije.Name = "lbRezervacije";
            this.lbRezervacije.Size = new System.Drawing.Size(698, 132);
            this.lbRezervacije.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vaše Rezervacije:";
            // 
            // btnFormaRezervacije
            // 
            this.btnFormaRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormaRezervacije.Location = new System.Drawing.Point(81, 232);
            this.btnFormaRezervacije.Name = "btnFormaRezervacije";
            this.btnFormaRezervacije.Size = new System.Drawing.Size(193, 41);
            this.btnFormaRezervacije.TabIndex = 1;
            this.btnFormaRezervacije.Text = "Rezervišite novi auto";
            this.btnFormaRezervacije.UseVisualStyleBackColor = true;
            this.btnFormaRezervacije.Click += new System.EventHandler(this.btnFormaRezervacije_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkloni.Location = new System.Drawing.Point(576, 232);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(203, 41);
            this.btnUkloni.TabIndex = 3;
            this.btnUkloni.Text = "Uklonite Rezervaciju";
            this.btnUkloni.UseVisualStyleBackColor = true;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // lblRez
            // 
            this.lblRez.AutoSize = true;
            this.lblRez.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRez.Location = new System.Drawing.Point(305, 142);
            this.lblRez.Name = "lblRez";
            this.lblRez.Size = new System.Drawing.Size(258, 16);
            this.lblRez.TabIndex = 4;
            this.lblRez.Text = "Trenutno nemate nijednu rezervaciju";
            this.lblRez.Visible = false;
            // 
            // btnOdjava
            // 
            this.btnOdjava.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdjava.Location = new System.Drawing.Point(712, 2);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(100, 27);
            this.btnOdjava.TabIndex = 5;
            this.btnOdjava.Text = "Odjavi se";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // lblKupac
            // 
            this.lblKupac.AutoSize = true;
            this.lblKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupac.Location = new System.Drawing.Point(220, 59);
            this.lblKupac.Name = "lblKupac";
            this.lblKupac.Size = new System.Drawing.Size(51, 16);
            this.lblKupac.TabIndex = 6;
            this.lblKupac.Text = "label2";
            // 
            // frmKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 302);
            this.Controls.Add(this.lblKupac);
            this.Controls.Add(this.btnOdjava);
            this.Controls.Add(this.lblRez);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnFormaRezervacije);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRezervacije);
            this.Name = "frmKupac";
            this.Text = "Kupac";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKorisnik_FormClosed);
            this.Load += new System.EventHandler(this.frmKupac_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFormaRezervacije;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.Label lblRez;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Label lblKupac;
    }
}