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
    public partial class Barang : Form
    {
        private Koneksi koneksi;
        private FormTransaksi formTransaksi;
        public Barang(FormTransaksi formTransaksi)
        {
            InitializeComponent();
            koneksi = new Koneksi();
            LoadBarangData();
            this.formTransaksi = formTransaksi;
        }
        private void LoadBarangData()
        {
            if (koneksi.Open())
            {
                string query = "SELECT KodeBarang, NamaBarang, Stok, HargaJual FROM tb_barang";
                DataSet ds = koneksi.ExecuteDataSet(query);
                koneksi.Close();

                if (ds != null && ds.Tables["result"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["result"];
                }
            }
        }

        private void Barang_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                formTransaksi.SetKodeBarang(kodeBarang);
            }
        }
    }
}
