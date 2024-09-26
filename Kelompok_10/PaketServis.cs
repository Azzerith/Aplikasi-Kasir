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
    public partial class PaketServis : Form
    {
        private Koneksi koneksi;
        private FormTransaksi formTransaksi;
        public PaketServis(FormTransaksi formTransaksi)
        {
            InitializeComponent();
            koneksi = new Koneksi();
            LoadData();
            this.formTransaksi = formTransaksi;
        }
        private void LoadData()
        {
            if (koneksi.Open())
            {
                string query = "SELECT KodePaket, Paket, Deskripsi, Biaya FROM tb_paketservis";
                DataSet ds = koneksi.ExecuteDataSet(query);
                koneksi.Close();

                if (ds != null && ds.Tables["result"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["result"];
                }
            }
        }

        private void PaketServis_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string kodePaket = row.Cells["KodePaket"].Value.ToString();
                formTransaksi.SetKodePaket(kodePaket);
            }
        }
    }
}
