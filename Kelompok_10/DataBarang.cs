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
    public partial class DataBarang : Form
    {
        private Koneksi koneksi;
        public DataBarang()
        {
            InitializeComponent();
            koneksi = new Koneksi();
            LoadBarangData();
        }
        private void LoadBarangData()
        {
            if (koneksi.Open())
            {
                string query = "SELECT * FROM tb_barang";
                DataSet ds = koneksi.ExecuteDataSet(query);
                koneksi.Close();

                if (ds != null && ds.Tables["result"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["result"];
                }
            }
        }
    }
    
}
