using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelompok_10
{
    public partial class FormPaketServis : Form
    {
        private Koneksi koneksi;
        public FormPaketServis()
        {
            InitializeComponent();
            koneksi = new Koneksi();
        }

        void MunculData()
        {
            if (koneksi.Open())
            {
                try
                {
                    string query = "SELECT * FROM tb_paketservis";
                    DataSet dataSet = koneksi.ExecuteDataSet(query);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Txtjual_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string deskripsi = txtDeskripsi.Text;
            string biaya = txtBiaya.Text;

            string query = $"INSERT INTO tb_paketservis (KodePaket, Paket, Deskripsi, Biaya)" +
                $" VALUES ('{kode}','{nama}','{deskripsi}','{biaya}')";

            if (koneksi.Open())
            {
                try
                {
                    int affectedRows = koneksi.ExecuteNonQuery(query);

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan!");
                        MunculData();
                        Clear();
                    }
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }
        private void Clear()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtDeskripsi.Clear();
            txtBiaya.Clear();
            btnInput.Enabled = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string deskripsi = txtDeskripsi.Text;
            string biaya = txtBiaya.Text;

            string query = $"UPDATE tb_paketservis SET Paket = '{nama}', Deskripsi = '{deskripsi}', Biaya = '{biaya}' WHERE KodePaket = '{kode}'";

            if (koneksi.Open())
            {
                try
                {
                    int affectedRows = koneksi.ExecuteNonQuery(query);
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Data berhasil diupdate!");
                        MunculData();
                    }
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;

            string query = $"DELETE FROM tb_paketservis WHERE KodePaket = '{kode}'";

            if (koneksi.Open())
            {
                try
                {
                    int affectedRows = koneksi.ExecuteNonQuery(query);

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus!");
                        MunculData();
                        Clear();
                    }
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();
            string query = $"SELECT * FROM tb_paketservis WHERE Paket LIKE '%{keyword}%'";

            if (koneksi.Open())
            {
                try
                {
                    DataSet dataSet = koneksi.ExecuteDataSet(query);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            MunculData();
        }

        private void TxtBiaya_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormPaketServis_Load(object sender, EventArgs e)
        {
            MunculData();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string kode = row.Cells["KodePaket"].Value.ToString();
                string nama = row.Cells["Paket"].Value.ToString();
                string deskripsi = row.Cells["Deskripsi"].Value.ToString();
                string biaya = row.Cells["Biaya"].Value.ToString();

                txtKode.Text = kode;
                txtNama.Text = nama;
                txtDeskripsi.Text = deskripsi;
                txtBiaya.Text = biaya;
                btnInput.Enabled = false;
            }
        }
    }
}
