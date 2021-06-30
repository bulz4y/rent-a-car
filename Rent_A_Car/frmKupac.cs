using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public partial class frmKupac : Form
    {
        public frmKupac(Kupac k)
        {
            InitializeComponent();
            kupac = k;

            rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
            automobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);

            rezervacijeKupca = new List<Rezervacija>();

        }

        private Kupac kupac;
        private List<Rezervacija> rezervacije;
        private List<Rezervacija> rezervacijeKupca;
        private List<Automobil> automobili;

        private void frmKorisnik_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            
        }

        private void proveriRezervacije()
        {
            if(this.lbRezervacije.Items.Count == 0)
            {
                this.lblRez.Visible = true;
                this.btnUkloni.Enabled = false;
            }
        }

        private void frmKupac_Load(object sender, EventArgs e)
        {
                lblKupac.Text = kupac.ime + " " + kupac.prezime + " " + kupac.jmbg; 
                foreach (Rezervacija rez in rezervacije)
                {
                    if (rez.idbrKupca == kupac.IDBR)
                    {
                        
                        rezervacijeKupca.Add(rez);
                    }

                }

            foreach (Automobil auto in automobili)
            {
                foreach (Rezervacija rez in rezervacijeKupca)
                {
                    if(auto.idbr == rez.idbrAutomobila)
                    {
                        this.lbRezervacije.Items.Add("AutoID: " + rez.idbrAutomobila + auto.display() + rez.ToString());
                    }
                }

            }

            proveriRezervacije();


        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            if (lbRezervacije.SelectedIndex > -1)
            {

                Rezervacija ukinutaRezervacija = rezervacijeKupca[lbRezervacije.SelectedIndex];
                this.rezervacijeKupca.RemoveAt(lbRezervacije.SelectedIndex);

                this.lbRezervacije.Items.Remove(lbRezervacije.SelectedItem);
             
                rezervacije.Remove(ukinutaRezervacija);

                Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                MessageBox.Show("Uspešno ste uklonili rezervaciju");

                proveriRezervacije();

            } else
            {
                MessageBox.Show("Niste izabrali rezervaciju koju želite da uklonite");
            }
        }

        private void btnFormaRezervacije_Click(object sender, EventArgs e)
        {
           frmRezervacija frm = new frmRezervacija(kupac);

           frm.Show();
           
            
           this.Hide();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }
    }
}
