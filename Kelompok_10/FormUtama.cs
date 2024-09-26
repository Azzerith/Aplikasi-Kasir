using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelompok_10
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void BtnTransaksi_Click(object sender, EventArgs e)
        {
            FormTransaksi ft = new FormTransaksi();
            ft.Show();
        }

        private void BtnMontir_Click(object sender, EventArgs e)
        {
            FormMontir fm = new FormMontir();
            fm.Show();
        }

        private void Btnkasir_Click(object sender, EventArgs e)
        {
            FormKasir fk = new FormKasir();
            fk.Show();
        }

        private void Btnlaporan_Click(object sender, EventArgs e)
        {
            FormDataTransaksi fdt = new FormDataTransaksi();
            fdt.Show();
        }

        private void Btnpaketservis_Click(object sender, EventArgs e)
        {
            FormPaketServis fps = new FormPaketServis();
            fps.Show();
        }

        private void Btnbarang_Click(object sender, EventArgs e)
        {
            FormBarang fb = new FormBarang();
            fb.Show();
        }

        private void Btnkeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AAA_Load(object sender, EventArgs e)
        {
            lbTanggal.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbJam.Text = GetCurrentTimeInIndonesia();
            lbinfokasir.Text = UserInfo.Username;
            lblevel.Text = UserInfo.Level;
        }

        private void Btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Membersihkan informasi pengguna yang sudah login
                UserInfo.Username = "";
                UserInfo.Level = "";

                // Menampilkan FormLogin dan menyembunyikan Form Utama
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbJam.Text = GetCurrentTimeInIndonesia();
        }
        private string GetCurrentTimeInIndonesia()
        {
            // Mendapatkan zona waktu Indonesia
            TimeZoneInfo indonesiaZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Mendapatkan waktu saat ini dalam zona waktu Indonesia
            DateTime indonesiaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, indonesiaZone);

            // Mengembalikan waktu dalam format yang diinginkan
            return indonesiaTime.ToString("HH:mm:ss");
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            FormTransaksi ft = new FormTransaksi();
            ft.Show();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            FormMontir fm = new FormMontir();
            fm.Show();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            FormKasir fk = new FormKasir();
            fk.Show();
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            FormBarang fb = new FormBarang();
            fb.Show();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            FormPaketServis fps = new FormPaketServis();
            fps.Show();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            FormDataTransaksi fdt = new FormDataTransaksi();
            fdt.Show();
        }
    }
}
