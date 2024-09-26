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
    public partial class FormBarang : Form
    {
        private Koneksi koneksi;
        public FormBarang()
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
                    string query = "SELECT * FROM tb_barang";
                    DataSet dataSet = koneksi.ExecuteDataSet(query);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
            string kode = txtkode.Text;
            string nama = txtnama.Text;
            string beli = txtbeli.Text;
            string jual = txtjual.Text;
            string stok = txtstok.Value.ToString();

            string query = $"INSERT INTO tb_barang (KodeBarang, NamaBarang, HargaBeli, HargaJual, Stok)" +
                $" VALUES ('{kode}', '{nama}', '{beli}', '{jual}', '{stok}')";

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
                txtkode.Clear();
                txtnama.Clear();
                txtbeli.Clear();
                txtjual.Clear();
                txtstok.Value = 0;
            btnInput.Enabled = true;
        }
            private void BtnRefresh_Click(object sender, EventArgs e)
            {
                MunculData();
            }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string kode = txtkode.Text;
            string nama = txtnama.Text;
            string beli = txtbeli.Text;
            string jual = txtjual.Text;
            string stok = txtstok.Value.ToString();

            string query = $"UPDATE tb_barang SET NamaBarang = '{nama}', HargaBeli = '{beli}', HargaJual = '{jual}', Stok = '{stok}' WHERE KodeBarang = '{kode}'";

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
            string kode = txtkode.Text;

            string query = $"DELETE FROM tb_barang WHERE KodeBarang = '{kode}'";

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

        private void FormBarang_Load(object sender, EventArgs e)
        {
            MunculData();
        }
        private void txtbeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtjual_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string kode = row.Cells["KodeBarang"].Value.ToString();
                string nama = row.Cells["NamaBarang"].Value.ToString();
                string beli = row.Cells["HargaBeli"].Value.ToString();
                string jual = row.Cells["HargaJual"].Value.ToString();
                string stok = row.Cells["Stok"].Value.ToString();

                txtkode.Text = kode;
                txtnama.Text = nama;
                txtbeli.Text = beli;
                txtjual.Text = jual;
                txtstok.Value = int.Parse(stok);
                btnInput.Enabled = false;
            }
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();
            string query = $"SELECT * FROM tb_barang WHERE NamaBarang LIKE '%{keyword}%'";

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

        private void BtnRefresh_Click_1(object sender, EventArgs e)
        {
            MunculData();
        }

        private void FormBarang_Resize(object sender, EventArgs e)
        {

        }

        private void Txtkode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            if (e.KeyCode == Keys.Enter)
            {
                BtnInput_Click(sender, e);
            }
        }

        private void Txtnama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            if (e.KeyCode == Keys.Enter)
            {
                BtnInput_Click(sender, e);
            }
        }

        private void Txtbeli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtjual.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                BtnInput_Click(sender, e);
            }
        }

        private void Txtjual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtstok.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                BtnInput_Click(sender, e);
            }
        }

        private void Txtstok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnInput_Click(sender, e);
            }
        }

        private void Txtbeli_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Txtjual_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
