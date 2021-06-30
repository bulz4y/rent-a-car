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
    public partial class frmRegistracija : Form
    {
        public frmRegistracija()
        {
            InitializeComponent();
            validacija = new Validacija();
            kupci = null;
        }

        private Validacija validacija;
        private List<Kupac> kupci;

        private void frmRegistracija_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Hide();
        }

        private void frmRegistracija_Load(object sender, EventArgs e)
        {
            txtSifra.PasswordChar = '*';
            txtPotvrdiSifru.PasswordChar = '*';

        }

        private bool validacijaForme()
        {
            bool prosao = true;

            if (!validacija.proveriKorisnickoIme(txtKorisnickoIme.Text.Trim())) { prosao = false; }
            if (!validacija.proveriSifru(txtSifra.Text.Trim())) { prosao = false; }
            if (!validacija.proveriPotvrduSifre(txtSifra.Text.Trim(), txtPotvrdiSifru.Text.Trim())) { prosao = false; }
            if (!validacija.proveriIme(txtIme.Text.Trim())) { prosao = false; }
            if (!validacija.proveriPrezime(txtPrezime.Text.Trim())) { prosao = false; }
            if (!validacija.proveriJMBG(txtJmbg.Text.Trim())) { prosao = false; }
            if (!validacija.proveriDatum(dtDatum.Value)) { prosao = false; }
            if (!validacija.proveriTelefon(txtTelefon.Text.Trim())) { prosao = false; }


            return prosao;
        }

        private void prikaziKupacFormu(Kupac noviKupac)
        {
            frmKupac frm = new frmKupac(noviKupac);
            frm.Show();
            this.Hide();
        }

        private void btnNoviNalog_Click(object sender, EventArgs e)
        {
            validacija.output = "";
            if (validacijaForme())
            {
               if(validacija.korisnickoImePostojiKreiranje(txtKorisnickoIme.Text.Trim()))
                {
                    MessageBox.Show("Korisničko ime već postoji");
                    return;
                }

                if (validacija.jmbgPostojiKreiranje(txtJmbg.Text.Trim()))
                {
                    MessageBox.Show("JMBG već postoji");
                    return;
                }

                    // kreiraj novog kupca
                     kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
                  
                    Kupac noviKupac = new Kupac(txtSifra.Text.Trim(), txtKorisnickoIme.Text.Trim(), txtIme.Text.Trim(), txtPrezime.Text.Trim(), txtJmbg.Text.Trim(), dtDatum.Value, txtTelefon.Text.Trim());

                    kupci.Add(noviKupac);

                    // azuriraj kupce
                    Global.azurirajDatoteku<Kupac>(Global.KUPAC, kupci);

                    MessageBox.Show("Uepesna registracija");

                    prikaziKupacFormu(noviKupac);

            } else
            {
                MessageBox.Show(validacija.output);
            }

            
        }
    }
}
