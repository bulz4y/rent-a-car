using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Rent_A_Car
{
    static class Global
    {
        // File promenjljive
        private static BinaryFormatter bf;
        private static FileStream fs;

        // jedinstveni identifikatori
        public static int idbrAutomobila { get; set; }
        public static int idbrKupca { get; set; }

        // putanje do datoteka
        public static string ADMIN { get; set; }
        public static string AUTOMOBIL { get; set; }
        public static string KUPAC { get; set; }
        public static string REZERVACIJA { get; set; }
        public static string PONUDA { get; set; }


        // pocetna inicijalizacija
        public static void init()
        {
            ADMIN = "Admini.bin";
            AUTOMOBIL = "Automobili.bin";
            KUPAC = "Kupci.bin";
            REZERVACIJA = "Rezervacije.bin";
            PONUDA = "Ponude.bin";
            
            bf = new BinaryFormatter();
           
            izracunajIdbrAutomobila();
            izracunajIdbrKupca();

        }

        public static void odjava(Form frmSakrij)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            frmSakrij.Hide();

        }

       
        private static void izracunajIdbrKupca()
        {
            List<Kupac> kupci = citajIzDatoteke<Kupac>(KUPAC);
            
            idbrKupca = kupci.Count + 1;
        }

        private static void izracunajIdbrAutomobila()
        {
            List<Automobil> automobili = citajIzDatoteke<Automobil>(AUTOMOBIL);
            idbrAutomobila = automobili.Count + 1;
        }

        public static void azurirajDatoteku<T>(string path, List<T> generickaLista) {
            fs = File.OpenWrite(path);
            bf.Serialize(fs, generickaLista);
            fs.Close();
        }

        public static List<T> citajIzDatoteke<T>(string path)
        {

            List<T> generickaLista;
            fs = File.OpenRead(path);

            if (fs.Length == 0)
            {
                generickaLista = new List<T>();
            }
            else
            {
                generickaLista = bf.Deserialize(fs) as List<T>;
            }

            fs.Close();

            return generickaLista;
        }
       
    }
}
