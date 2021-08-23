using DB.DAL;
using DB.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ekranlar
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            giris g = new giris();

            if (g.ShowDialog() == DialogResult.OK)
            {
                lblKullanici.Text = "Hoşgeldin " + Yardimci.onlineKullanici.AdiSoyadi + " !";
                pbAvatar.Image = Image.FromFile("kutuphane/user.png");
                ListeleriGetir();
                datagridGuncelle();
                sanatcilariGetir();
                turleriGetir();
            }
            else
            {
                Application.Exit();
            }
        }

        List<album> indirimListesi = new List<album>();
        List<album> soneklenenlistesi = new List<album>();
        List<album> hepsi = new List<album>();
        List<album> filtre = new List<album>();

        void ListeleriGetir()
        {
            indirimListesi = albumDAL.IndirimdekiOnBesAlbum();
            soneklenenlistesi = albumDAL.SonOnAlbum();
            hepsi = albumDAL.Listele();
        }

        private void datagridGuncelle()
        {
            dgfiltre.DataSource = hepsi;
            dgfiltre.Columns["IDAlbum"].Visible = false;
            dgfiltre.Columns["Resim"].Visible = false;
            dgfiltre.Columns["SanatciID"].Visible = false;
            dgfiltre.Columns["TurID"].Visible = false;
            dgfiltre.Columns["SilindiMi"].Visible = false;
            dgfiltre.Columns["sanatci"].Visible = false;
            dgfiltre.Columns["Adi"].Visible = true;
            dgfiltre.Columns["Adi"].HeaderText = "ADI";
            dgfiltre.Columns["SanatciAdi"].Visible = true;
            dgfiltre.Columns["SanatciAdi"].HeaderText = "SANATÇI";
            dgfiltre.Columns["Turu"].Visible = true;
            dgfiltre.Columns["Turu"].HeaderText = "TÜRÜ";
            dgfiltre.Columns["Fiyati"].Visible = true;
            dgfiltre.Columns["Fiyati"].HeaderText = "FİYATI";
            dgfiltre.Columns["IndirimOrani"].Visible = true;
            dgfiltre.Columns["IndirimOrani"].HeaderText = "İNDİRİM";



            dgsoneklenen.DataSource = soneklenenlistesi;
            dgsoneklenen.Columns["IDAlbum"].Visible = false;
            dgsoneklenen.Columns["Resim"].Visible = false;
            dgsoneklenen.Columns["SanatciID"].Visible = false;
            dgsoneklenen.Columns["TurID"].Visible = false;
            dgsoneklenen.Columns["SilindiMi"].Visible = false;
            dgsoneklenen.Columns["sanatci"].Visible = false;
            dgsoneklenen.Columns["Adi"].Visible = true;
            dgsoneklenen.Columns["Adi"].HeaderText = "ADI";
            dgsoneklenen.Columns["SanatciAdi"].Visible = true;
            dgsoneklenen.Columns["SanatciAdi"].HeaderText = "SANATÇI";
            dgsoneklenen.Columns["Turu"].Visible = true;
            dgsoneklenen.Columns["Turu"].HeaderText = "TÜRÜ";
            dgsoneklenen.Columns["Fiyati"].Visible = true;
            dgsoneklenen.Columns["Fiyati"].HeaderText = "FİYATI";
            dgsoneklenen.Columns["IndirimOrani"].Visible = true;
            dgsoneklenen.Columns["IndirimOrani"].HeaderText = "İNDİRİM";

            dgindirimdeki.DataSource = indirimListesi;
            dgindirimdeki.Columns["IDAlbum"].Visible = false;
            dgindirimdeki.Columns["Resim"].Visible = false;
            dgindirimdeki.Columns["SanatciID"].Visible = false;
            dgindirimdeki.Columns["TurID"].Visible = false;
            dgindirimdeki.Columns["SilindiMi"].Visible = false;
            dgindirimdeki.Columns["sanatci"].Visible = false;
            dgindirimdeki.Columns["Adi"].Visible = true;
            dgindirimdeki.Columns["Adi"].HeaderText = "ADI";
            dgindirimdeki.Columns["SanatciAdi"].Visible = true;
            dgindirimdeki.Columns["SanatciAdi"].HeaderText = "SANATÇI";
            dgindirimdeki.Columns["Turu"].Visible = true;
            dgindirimdeki.Columns["Turu"].HeaderText = "TÜRÜ";
            dgindirimdeki.Columns["Fiyati"].Visible = true;
            dgindirimdeki.Columns["Fiyati"].HeaderText = "FİYATI";
            dgindirimdeki.Columns["IndirimOrani"].Visible = true;
            dgindirimdeki.Columns["IndirimOrani"].HeaderText = "İNDİRİM";
        }

        private void sanatcilariGetir()
        {
            cmbSanatci.Items.Clear();
            cmbSanatci.Items.Add("Sanatçı Seç");

            foreach (var item in sanatciDAL.Listele())
            {
                cmbSanatci.Items.Add(item.Adi);
            }
        }

        private void cmbSanatci_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtre = hepsi.Where(x => x.SanatciAdi == cmbSanatci.Text).ToList();
            dgfiltre.DataSource = filtre;
        }

        private void turleriGetir()
        {
            cmbTur.Items.Clear();
            cmbTur.Items.Add("Tür Seç");

            foreach (var item in turDAL.Listele())
            {
                cmbTur.Items.Add(item.Adi);
            }
        }

        private void cmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtre = hepsi.Where(x => x.Turu == cmbTur.Text).ToList();
            dgfiltre.DataSource = filtre;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            cmbSanatci.SelectedIndex = 0;
            cmbTur.SelectedIndex = 0;

            hepsi = albumDAL.Listele();
            dgfiltre.DataSource = hepsi;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
