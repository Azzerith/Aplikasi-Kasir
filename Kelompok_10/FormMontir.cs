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
    public partial class FormMontir : Form
    {
        private Koneksi koneksi;
        public FormMontir()
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
                    string query = "SELECT * FROM tb_montir";
                    DataSet dataSet = koneksi.ExecuteDataSet(query);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }


        private void TxtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string alamat = txtAlamat.Text;
            string no = txtNo.Text;

            string query = $"INSERT INTO tb_montir (KodeMontir, NamaMontir, Alamat, No_telp)" +
                $" VALUES ('{kode}', '{nama}', '{alamat}', '{no}')";

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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string alamat = txtAlamat.Text;
            string no = txtNo.Text;

            string query = $"UPDATE tb_montir SET NamaMontir = '{nama}', Alamat = '{alamat}', No_telp = '{no}' WHERE KodeMontir = '{kode}'";

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

            string query = $"DELETE FROM tb_montir WHERE KodeMontir = '{kode}'";

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

        private void FormMontir_Load(object sender, EventArgs e)
        {
            MunculData();
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();
            string query = $"SELECT * FROM tb_montir WHERE NamaMontir LIKE '%{keyword}%'";

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
        private void Clear()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            txtNo.Clear();
            btnInput.Enabled = true;
        }

        private void TxtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtKode.Text = row.Cells["KodeMontir"].Value.ToString();
                txtNama.Text = row.Cells["NamaMontir"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtNo.Text = row.Cells["No_telp"].Value.ToString();
                btnInput.Enabled = false;
            }
        }
    }
}
