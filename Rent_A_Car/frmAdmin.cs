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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();

            kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            izabraniKupac = null;
            meseci = new string[] { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };
        }

        private List<Kupac> kupci;
        private Kupac izabraniKupac;
        private string[] meseci;

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            frmAdminAuto frm = new frmAdminAuto();
            frm.Show();
            this.Hide();
        }

        private void btnKupac_Click(object sender, EventArgs e)
        {
            frmAdminKupci frm = new frmAdminKupci();
            frm.Show();
            this.Hide();
        }

        private void btnPonuda_Click(object sender, EventArgs e)
        {
            frmAdminPonuda frm = new frmAdminPonuda();
            frm.Show();
            this.Hide();
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            if (cbKupci.SelectedItem != null)
            {
                foreach (Kupac kupac in kupci)
                {
                    if(kupac.jmbg.Equals(cbKupci.SelectedItem.ToString())) {
                        izabraniKupac = kupac;
                        break;
                    }
                }
                frmAdminRezervacije frm = new frmAdminRezervacije(izabraniKupac);
                frm.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Morate izabrati kupca iz Liste");
            }
         
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            panStatistika.BackColor = Color.LightBlue;
            panStatistika.HorizontalScroll.Enabled = true;

            foreach (string mesec in meseci)
            {
                cbMeseci.Items.Add(mesec);
            }
            

            foreach(Kupac kupac in kupci)
            {
                cbKupci.Items.Add(kupac.jmbg);
            }
        }

        private void crtajStatistiku(int mesec)
        {
            
            List<Ponuda> ponude = Global.citajIzDatoteke<Ponuda>(Global.PONUDA);
            List<Ponuda> ponudeMesec = new List<Ponuda>();
            List<Automobil> automobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);

            double brojPunuda = 0;
            double ukupnoPonuda = 0;
            double procenat = 0;
            int y = 0;

            foreach (Ponuda ponuda in ponude)
            {
                if(ponuda.datumOd.Month == mesec || ponuda.datumDo.Month == mesec)
                {
                    ponudeMesec.Add(ponuda);
                }
            }

             ukupnoPonuda = ponudeMesec.Count;

               
             Graphics g = panStatistika.CreateGraphics();
             g.Clear(Color.LightBlue);

             Brush crnaCetka = Brushes.White;
             Font podebljanArialFont = new Font("Arial", 16, FontStyle.Bold);
             Point koordinate;

            foreach (Automobil auto in automobili)
            {
                foreach (Ponuda ponuda in ponudeMesec)
                {
                    if(ponuda.idbrAutomobila == auto.idbr) { 
                        brojPunuda++;
                    }
                }

                if(brojPunuda > 0)
                {
                    koordinate = new Point(0, y);
                    procenat = (brojPunuda / ukupnoPonuda) * 100;
                    g.DrawString("ID: " + auto.idbr + "  Marka: " + auto.marka + "  Model: " + auto.model + "  Godište: " + auto.godiste + "  Broj Ponuda: " + brojPunuda + "  Procenat: " + (int)procenat + "%", podebljanArialFont, crnaCetka, koordinate);
                    y += 40;
                    brojPunuda = 0;
                }
            }

            koordinate = new Point(0, y);
            g.DrawString("Ukupno Ponuda: " + ukupnoPonuda, podebljanArialFont, crnaCetka, koordinate);

            g.Dispose();
        }

        private void cbMeseci_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mesec = cbMeseci.GetItemText(cbMeseci.SelectedItem).ToLower();

            switch(mesec)
            {
                case "januar":
                    crtajStatistiku(1);
                    break;

                case "februar":
                    crtajStatistiku(2);
                    break;

                case "mart":
                    crtajStatistiku(3);
                    break;

                case "april":
                    crtajStatistiku(4);
                    break;

                case "maj":
                    crtajStatistiku(5);
                    break;

                case "jun":
                    crtajStatistiku(6);
                    break;

                case "jul":
                    crtajStatistiku(7);
                    break;

                case "avgust":
                    crtajStatistiku(8);
                    break;

                case "septembar":
                    crtajStatistiku(9);
                    break;

                case "oktobar":
                    crtajStatistiku(10);
                    break;

                case "novembar":
                    crtajStatistiku(11);
                    break;

                case "decembar":
                    crtajStatistiku(12);
                    break;
                default:
                    break;


            }
        }
    }
}
