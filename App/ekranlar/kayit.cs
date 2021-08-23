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

namespace App
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == string.Empty)
            {
                MessageBox.Show("Kullanıcı ad soyad boş geçilemez !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtKadi.Text == string.Empty)
            {
                MessageBox.Show("Kullanıcı adı boş geçilemez !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtParola.Text == string.Empty)
            {
                MessageBox.Show("Kullanıcı parolası boş geçilemez !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kullanici k = new kullanici()
            {
                AdiSoyadi = txtAdi.Text,
                Eposta = txtKadi.Text,
                Sifre = txtParola.Text,
                AktifMi = false,
            };

            kullaniciDAL.Ekle(k);

            MessageBox.Show("Kullanıcı başarıyla oluşturuldu ve aktivasyon maili iletildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string icerik = "Kullanıcı adı : " + k.Eposta + "\nParola : " + k.Sifre + "\n" + "Aktifleştirmek için tıklayınız : LİNK";
            mail.AktivasyonMailiGonder(k.Eposta, icerik);
            this.Close();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            pbLogo.Image = Image.FromFile("kutuphane/logo.png");
        }
    }
}
