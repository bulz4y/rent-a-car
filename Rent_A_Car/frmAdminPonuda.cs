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
    public partial class frmAdminPonuda : Form
    {
        public frmAdminPonuda()
        {
            InitializeComponent();

            ponude = Global.citajIzDatoteke<Ponuda>(Global.PONUDA);
            automobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);
            izabranaPonuda = null;
            izabraniAutomobil = null;
            validacija = new Validacija();
        }

        private List<Ponuda> ponude;
        private List<Automobil> automobili;
        private Ponuda izabranaPonuda;
        private Automobil izabraniAutomobil;
        private DialogResult dr;
        private Validacija validacija;

        private void frmAdminPonuda_Load(object sender, EventArgs e)
        {
            azurirajListu();
            popuniAutomobile();
        }

        private void ocistiPolja()
        {
            txtCenaPoDanu.Text = "";
            dtDatumOd.Value = DateTime.Now;
            dtDatumDo.Value = DateTime.Now;
        }

        private void popuniAutomobile()
        {
            foreach (Automobil auto in automobili)
            {
                lbAutomobili.Items.Add(auto);
            }

            if (lbAutomobili.Items.Count == 0)
            {
                lblAutomobili.Visible = true;
            }
            else
            {
                lblAutomobili.Visible = false;
            }
        }

        private void azurirajListu()
        {
            ocistiPolja();
            lbPonude.Items.Clear();
            foreach (Ponuda ponuda in ponude)
            {
                lbPonude.Items.Add(ponuda.idbrAutomobila + " " + ponuda.ToString());
            }

            if(lbPonude.Items.Count == 0)
            {
                lblPonude.Visible = true;
            } else
            {
                lblPonude.Visible = false;
            }
        }

        private bool validacijaForme()
        {
            bool prosao = true;

            if(!validacija.proverCenuPoDanu(txtCenaPoDanu.Text.Trim())) { prosao = false; }
            if(!validacija.proveriDatum(dtDatumOd.Value.Date, dtDatumDo.Value.Date)) { prosao = false; }

            return prosao;
        }

        private bool jeRezervisana()
        {
            List<Rezervacija> rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
            // proveri da li je ponuda rezervisana
            foreach (Rezervacija rezervacija in rezervacije)
            {
                if (izabranaPonuda.idbrAutomobila == rezervacija.idbrAutomobila &&
                  rezervacija.datumOd.Date >= izabranaPonuda.datumOd.Date &&
                  rezervacija.datumDo.Date <= izabranaPonuda.datumDo.Date
                  )
                {
                   
                    return true;
                }
            }
            return false;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (lbPonude.SelectedIndex > -1)
            {
                if(jeRezervisana())
                {
                    MessageBox.Show("Ne mozete ažurirati ovu ponudu jer je rezervisana");
                    return;
                }

                if (validacijaForme())
                {
                    dr = MessageBox.Show("Da li ste sigurni da želite da ažurirate ovu ponudu ?", "Ažuriranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (Ponuda ponuda in ponude)
                        {
                            if (ponuda == izabranaPonuda)
                            {
                                ponuda.datumOd = dtDatumOd.Value;
                                ponuda.datumDo = dtDatumDo.Value;
                                ponuda.cenaPoDanu = double.Parse(txtCenaPoDanu.Text.Trim());

                                //azuriraj datoteku
                                Global.azurirajDatoteku<Ponuda>(Global.PONUDA, ponude);

                                MessageBox.Show("Uspesno ste ažurirali ponudu");

                                // azuriraj listu
                                azurirajListu();

                                break;
                            }
                        }

                    }

                }
                else
                {
                    MessageBox.Show(validacija.output);
                }
            }
            else
            {
                MessageBox.Show("Nsite izabrali nijednu ponudu");
            }

            validacija.output = "";

        }

        private void lbPonude_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbPonude.SelectedIndex > -1)
            {

                izabranaPonuda = ponude[lbPonude.SelectedIndex];

                // azuriraj polja
                dtDatumOd.Value = izabranaPonuda.datumOd;
                dtDatumDo.Value = izabranaPonuda.datumDo;
                txtCenaPoDanu.Text = izabranaPonuda.cenaPoDanu.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbPonude.SelectedIndex > -1)
            {

                if (jeRezervisana())
                {
                    MessageBox.Show("Ne možete obrisati ovu ponudu jer je rezervisana");
                    return;
                }

                dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovou ponudu ?", "Brisanje", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    // izbrisi ponudu 
                    ponude.Remove(izabranaPonuda);

                    MessageBox.Show("Uspešno ste obrisali izabranu ponudu");

                    azurirajListu();
                }

            }
            else
            {
                MessageBox.Show("Niste izabrali Ponudu");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.Show();
            this.Hide();
        }

        private void frmAdminPonuda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool proveriPonudu(Ponuda nova, Ponuda stara)
        {
                if((nova.datumOd.Date < stara.datumOd.Date && nova.datumDo < stara.datumOd.Date) ||
                    (nova.datumOd.Date > stara.datumDo.Date && nova.datumDo > stara.datumDo.Date)
                )
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(izabraniAutomobil != null)
            {
                if(validacijaForme())
                {
                   
                    Ponuda novaPonuda = new Ponuda(izabraniAutomobil.idbr, dtDatumOd.Value, dtDatumDo.Value, double.Parse(txtCenaPoDanu.Text.Trim()));

                    foreach (Ponuda ponuda in ponude)
                    {
                        if(novaPonuda.idbrAutomobila == ponuda.idbrAutomobila && !proveriPonudu(novaPonuda, ponuda))
                        {
                            MessageBox.Show("Datumi ponude se preklapaju");
                            return;
                        }
                    }

                    dr = MessageBox.Show("Da li ste sigurni da želite da kreirate ovu ponudu ?", "Ažuriranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        ponude.Add(novaPonuda);

                        Global.azurirajDatoteku<Ponuda>(Global.PONUDA, ponude);
                        MessageBox.Show("Uepešno ste dodali novu ponudu");

                        azurirajListu();
                    }

                   
                } else
                {
                    MessageBox.Show(validacija.output);
                }
            } else
            {
                MessageBox.Show("Niste izabrali nijedan automobil");
            }

            validacija.output = "";
        }

        private void lbAutomobili_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbAutomobili.SelectedIndex > -1)
            {
                izabraniAutomobil = lbAutomobili.SelectedItem as Automobil;
            }
        }
    }
}
