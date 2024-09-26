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
    public partial class FormKasir : Form
    {
        private Koneksi koneksi;
        public FormKasir()
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
                    string query = "SELECT * FROM tb_kasir";
                    DataSet dataSet = koneksi.ExecuteDataSet(query);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormKasir_Load(object sender, EventArgs e)
        {
            MunculData();
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string password = txtPassword.Text;
            string level = cmLevel.Text;
            string no = txtNo.Text;

            string query = $"INSERT INTO tb_kasir (KodeKasir,NamaKasir,PasswordKasir,LevelKasir,No_telp)" +
                $" VALUES ('{kode}','{nama}','{password}','{level}','{no}')";

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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string kode = row.Cells["KodeKasir"].Value.ToString();
                string nama = row.Cells["NamaKasir"].Value.ToString();
                string password = row.Cells["PasswordKasir"].Value.ToString();
                string level = row.Cells["LevelKasir"].Value.ToString();
                string no = row.Cells["No_telp"].Value.ToString();

                // Tampilkan nilai username dan password di textbox
                txtKode.Text = kode;
                txtNama.Text = nama;
                txtPassword.Text = password;
                cmLevel.Text = level;
                txtNo.Text = no;
                btnInput.Enabled = false;
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;

            string query = $"DELETE FROM tb_kasir WHERE KodeKasir = '{kode}'";

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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            string password = txtPassword.Text;
            string level = cmLevel.Text;
            string no = txtNo.Text;

            string query = $"UPDATE tb_kasir SET NamaKasir = '{nama}', PasswordKasir = '{password}', LevelKasir = '{level}', No_telp = '{no}' WHERE KodeKasir = '{kode}'";


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

        private void Clear()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtPassword.Clear();
            cmLevel.Text = "";
            txtNo.Clear();
            btnInput.Enabled = true;
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
            string query = $"SELECT * FROM tb_kasir WHERE NamaKasir LIKE '%{keyword}%'";

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
    }
}
