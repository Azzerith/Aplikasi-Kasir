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
    public partial class FormDataTransaksi : Form
    {
        private Koneksi koneksi;
        MySqlConnection con = new MySqlConnection(Koneksi.sql);
        public FormDataTransaksi()
        {
            InitializeComponent();
            koneksi = new Koneksi();
            LoadData();
        }

        private void FormDataTransaksi_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadData(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (koneksi.Open())
            {
                string query = "SELECT * FROM tb_transaksi";

                // Modify the query if dates are provided
                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " WHERE Tanggal BETWEEN @StartDate AND @EndDate";
                }

                MySqlCommand cmd = new MySqlCommand(query, con);
                if (startDate.HasValue && endDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value.ToString("yyyy-MM-dd"));
                }

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "result");

                koneksi.Close();

                if (ds != null && ds.Tables["result"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["result"];
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string invoice = row.Cells["Invoice"].Value.ToString();

                FormDetail formDetail = new FormDetail(invoice);
                formDetail.Show();
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            LoadData(startDate, endDate);
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

