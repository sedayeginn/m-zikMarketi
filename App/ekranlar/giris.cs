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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
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
                Eposta = txtKadi.Text,
                Sifre = txtParola.Text
            };

            kullanici _k = kullaniciDAL.Kontrol(k);

            if (_k == null)
            {
                MessageBox.Show("Kullanıcı bilgileri hatalı !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Yardimci.onlineKullanici = _k;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            pbLogo.Image = Image.FromFile("kutuphane/logo.png");
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            kayit k = new kayit();
            k.ShowDialog();
        }
    }
}
