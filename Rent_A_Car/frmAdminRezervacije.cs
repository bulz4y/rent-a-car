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
    public partial class frmAdminRezervacije : Form
    {
        public frmAdminRezervacije(Kupac k)
        {
            InitializeComponent();

            kupac = k;
            rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
            ponude = Global.citajIzDatoteke<Ponuda>(Global.PONUDA);
            rezervacijeKupca = new List<Rezervacija>();
            automobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);
            izabranaRezervacija = null;
            izabranaPonuda = null;
            output = "";
            
        }

        DialogResult dr;
        private List<Rezervacija> rezervacije;
        private List<Rezervacija> rezervacijeKupca;
        private List<Automobil> automobili;
        private Rezervacija izabranaRezervacija;
        private Ponuda izabranaPonuda;
        private List<Ponuda> ponude;
        private Kupac kupac;
        private string output;

        private void frmAdminRezervacije_Load(object sender, EventArgs e)
        {
            lblKupac.Text = kupac.ime + " " + kupac.prezime + " " + kupac.jmbg;

            foreach (Rezervacija rezervacija in rezervacije)
            {
                if(rezervacija.idbrKupca == kupac.IDBR)
                {
                    rezervacijeKupca.Add(rezervacija);
                }
            }

            azurirajRezervacije();
            azurirajPonude();
        }

        private void azurirajRezervacije()
        {
            lbRezervacije.Items.Clear();
            foreach(Automobil auto in automobili)
            {
                foreach (Rezervacija rezervacija in rezervacijeKupca)
                {
                    if(rezervacija.idbrAutomobila == auto.idbr)
                        lbRezervacije.Items.Add("AutoID: " + rezervacija.idbrAutomobila + auto.display() + rezervacija.ToString());
                }
            }
           

            if(lbRezervacije.Items.Count == 0)
            {
                lblRezervacije.Visible = true;
            } else
            {
                lblRezervacije.Visible = false;
            }
        }

        private void azurirajPonude()
        {
           
            foreach (Ponuda ponuda in ponude)
            {
                lbPonude.Items.Add(ponuda.idbrAutomobila + " | " + ponuda.ToString());
            }

            if (lbPonude.Items.Count == 0)
            {
                lblPonude.Visible = true;
            }
            else
            {
                lblPonude.Visible = false;
            }
        }

        private void lbRezervacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRezervacije.SelectedIndex > -1)
            {
                izabranaRezervacija = rezervacijeKupca[lbRezervacije.SelectedIndex];
                dtDatumPreuzimanja.Value = izabranaRezervacija.datumOd;
                dtDatumVracanja.Value = izabranaRezervacija.datumDo;

            }
        }

        private void frmAdminRezervacije_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(lbRezervacije.SelectedIndex > -1)
            {
                dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovu rezervaciju ?", "Brisanje", MessageBoxButtons.YesNo);

                if(dr == DialogResult.Yes)
                {
                    // obrisi rezervaciju
                    rezervacije.Remove(izabranaRezervacija);
                    rezervacijeKupca.Remove(izabranaRezervacija);

                    // azuriraj datoteku
                    Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                    azurirajRezervacije();
                }

            } else
            {
                MessageBox.Show("Niste izabrali rezervaciju");
            }
        }

        private bool validacijaDatuma(DateTime datumOd, DateTime datumDo)
        {
            foreach (Ponuda ponuda in ponude)
            {
                if (izabranaRezervacija.idbrAutomobila == ponuda.idbrAutomobila &&
                    izabranaRezervacija.datumOd.Date >= ponuda.datumOd.Date &&
                    izabranaRezervacija.datumDo.Date <= ponuda.datumDo.Date
                 )
                {
                    if (datumOd.Date <= datumDo.Date &&
                        datumOd.Date >= ponuda.datumOd.Date &&
                        datumOd.Date <= ponuda.datumDo.Date &&
                        datumDo.Date <= ponuda.datumDo.Date)
                    {
                        izabranaPonuda = ponuda;
                        return true;
                    } else
                    {
                        output += "Datum nije u dozvoljenom opsegu";
                        return false;
                    }
                }
            }

            return false;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if(lbRezervacije.SelectedIndex > -1)
            {
                if(validacijaDatuma(dtDatumPreuzimanja.Value.Date, dtDatumVracanja.Value.Date))
                {
                    dr = MessageBox.Show("Da li ste sigurni da želite da ažurirate ovu rezervaciju ?", "Ažuriranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        // azuriraj rezervaciju
                        foreach (Rezervacija rezervacija in rezervacije)
                        {
                            if(izabranaRezervacija.idbrAutomobila == rezervacija.idbrAutomobila && izabranaRezervacija.idbrKupca == rezervacija.idbrKupca)
                            {
                                rezervacija.datumOd = dtDatumPreuzimanja.Value;
                                rezervacija.datumDo = dtDatumVracanja.Value;

                                TimeSpan dani = dtDatumVracanja.Value.Date - dtDatumPreuzimanja.Value.Date;
                                double brDana = dani.TotalDays;
                                if (brDana == 0) brDana = 1;
                                double cena = brDana * izabranaPonuda.cenaPoDanu;

                                rezervacija.cena = cena;
                                break;

                            }
                        }

                        // azuriraj datoteku
                        Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                        azurirajRezervacije();
                    }

                } else
                {
                    MessageBox.Show(output);
                }

            } else
            {
                MessageBox.Show("Niste izabrali rezervaciju");
            }

            output = "";
        }

        private void btnKreirajNovu_Click(object sender, EventArgs e)
        {
            if(lbPonude.SelectedIndex > -1)
            {
                foreach (Rezervacija rezervacija in rezervacijeKupca)
                {
                    if(izabranaPonuda.idbrAutomobila == rezervacija.idbrAutomobila)
                    {
                        MessageBox.Show("Već ste rezervisali ovaj automobil");
                        return;
                    }
                }

                if(dtDatumPreuzimanja.Value.Date <= dtDatumVracanja.Value.Date &&
                   dtDatumPreuzimanja.Value.Date >= izabranaPonuda.datumOd.Date &&
                   dtDatumPreuzimanja.Value.Date <= izabranaPonuda.datumDo.Date &&
                   dtDatumVracanja.Value.Date <= izabranaPonuda.datumDo.Date
                    )
                {
                    dr = MessageBox.Show("Da li ste sigurni da želite da kreirate ovu rezervaciju ?", "Kreiranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        TimeSpan dani = dtDatumVracanja.Value.Date - dtDatumPreuzimanja.Value.Date;
                        double brDana = dani.TotalDays;
                        if (brDana == 0) brDana = 1;
                        double cena = brDana * izabranaPonuda.cenaPoDanu;

                        Rezervacija novaRezervacija = new Rezervacija(kupac.IDBR, izabranaPonuda.idbrAutomobila, dtDatumPreuzimanja.Value, dtDatumVracanja.Value, cena);

                        // azuriraj rezervaciju
                        rezervacije.Add(novaRezervacija);
                        rezervacijeKupca.Add(novaRezervacija);

                        // azuriraj datoteku
                        Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                        azurirajRezervacije();
                    }
                } else
                {
                    MessageBox.Show("Datum nije u dozvoljenom opsegu");

                }
            } else
            {
                MessageBox.Show("Niste izabrali ponudu");
            }
        }

        private void lbPonude_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbPonude.SelectedIndex > -1)
            {
                izabranaPonuda = ponude[lbPonude.SelectedIndex];
            }
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.Show();
            this.Hide();
        }
    }
}
