using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Rent_A_Car
{
    public partial class frmPrijava : Form
    {
        public frmPrijava()
        {
            InitializeComponent();
            admini = new List<Admin>();
            kupci = new List<Kupac>();
            kupac = null;

        }

        private List<Admin> admini;
        private List<Kupac> kupci;
        private Kupac kupac;

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            frmRegistracija frm = new frmRegistracija();
            frm.Show();
            this.Hide();
        }

        private void adminForma()
        {
            frmAdmin frm = new frmAdmin();
            frm.Show();
            this.Hide();
        }

        private void kupacForma()
        {
            frmKupac frm = new frmKupac(kupac);
            frm.Show();
            this.Hide();
        }

        private bool jeKupac(string korisnickoIme, string sifra)
        {
            kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);

            foreach (Kupac k in kupci)
            {
                if (k.sifra.Equals(sifra) && k.korisnickoIme.Equals(korisnickoIme))
                {
                    kupac = k;
                    return true;
                }
            }
            return false;
        }

        private bool jeAdmin(string korisnickoIme, string sifra)
        {
            admini = Global.citajIzDatoteke<Admin>(Global.ADMIN);

            foreach (Admin ad in admini)
            {
                if (ad.sifra.Equals(sifra) && ad.korisnickoIme.Equals(korisnickoIme))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            string korisnickoIme = this.txtIme.Text.Trim();
            string sifra = this.txtSifra.Text.Trim();
            

            if(korisnickoIme.Length != 0 && sifra.Length != 0)
            {
                if (jeKupac(korisnickoIme, sifra))
                {
                   kupacForma();

                }
                else if (jeAdmin(korisnickoIme, sifra))
                {
                    adminForma();
                } else
                {
                    MessageBox.Show("Pogrešno korisničko ime ili šifra");
                }


            } else
            {
                MessageBox.Show("Morate uneti oba polja za prijavu");
            }
            
        }

        private void frmPrijava_Load(object sender, EventArgs e)
        {
            txtSifra.PasswordChar = '*';
        }

        private void frmPrijava_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
