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
    public partial class FormUtamaUser : Form
    {
        public FormUtamaUser()
        {
            InitializeComponent();
        }

        private void BtnTransaksi_Click(object sender, EventArgs e)
        {
            FormTransaksi ft = new FormTransaksi();
            ft.Show();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            FormTransaksi ft = new FormTransaksi();
            ft.Show();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            FormDataTransaksi fdt = new FormDataTransaksi();
            fdt.Show();
        }

        private void Btnlaporan_Click(object sender, EventArgs e)
        {
            FormDataTransaksi fdt = new FormDataTransaksi();
            fdt.Show();
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

        private void Btnkeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnpaketservis_Click(object sender, EventArgs e)
        {
            DataServis ds = new DataServis();
            ds.Show();
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            DataBarang db = new DataBarang();
            db.Show();
        }

        private void Btnbarang_Click(object sender, EventArgs e)
        {
            DataBarang db = new DataBarang();
            db.Show();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            DataServis ds = new DataServis();
            ds.Show();
        }

        private void FormUtamaUser_Load(object sender, EventArgs e)
        {
            lbTanggal.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbJam.Text = GetCurrentTimeInIndonesia();
            lbinfokasir.Text = UserInfo.Username;
            lblevel.Text = UserInfo.Level;
        }
    }
}
