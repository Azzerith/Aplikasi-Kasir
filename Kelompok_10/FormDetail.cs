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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Kelompok_10
{
    
    public partial class FormDetail : Form
    {
        private Koneksi koneksi;
        private string invoice;

        public FormDetail(string invoice)
        {
            this.invoice = invoice;
            InitializeComponent();
            koneksi = new Koneksi();
            LoadDetailData();
        }

        private void LoadDetailData()
        {
            DataTable detailTable = GetDetailData(invoice);
            dataGridView1.DataSource = detailTable;
        }

        private DataTable GetDetailData(string invoice)
        {
            string[] queries = {
                $"SELECT * FROM tb_detailservis WHERE Invoice = '{invoice}'",
                $"SELECT * FROM tb_detailpembelian WHERE Invoice = '{invoice}'",
                $"SELECT * FROM tb_detailservispembelian WHERE Invoice = '{invoice}'"
            };

            DataTable detailTable = new DataTable();

            foreach (string query in queries)
            {
                if (koneksi.Open())
                {
                    DataSet ds = koneksi.ExecuteDataSet(query);
                    koneksi.Close();

                    if (ds != null && ds.Tables["result"].Rows.Count > 0)
                    {
                        return ds.Tables["result"];
                    }
                }
            }

            return detailTable; // return empty DataTable if no data found
        }
        private void FormDetail_Load(object sender, EventArgs e)
        {

        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCetak_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string invoice = this.invoice;  // Get the invoice number from the instance variable

            bool containsBarang = false;
            bool containsPaketServis = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (dataGridView1.Columns.Contains("Kode"))
                    {
                        string kode = row.Cells["Kode"].Value.ToString();
                        if (IsKodeBarang(kode)) containsBarang = true;
                        if (IsKodePaketServis(kode)) containsPaketServis = true;
                    }
                    if (dataGridView1.Columns.Contains("KodeBarang"))
                    {
                        string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                        if (IsKodeBarang(kodeBarang)) containsBarang = true;
                    }
                    if (dataGridView1.Columns.Contains("KodePaket"))
                    {
                        string kodePaket = row.Cells["KodePaket"].Value.ToString();
                        if (IsKodePaketServis(kodePaket)) containsPaketServis = true;
                    }
                }
            }

            if (containsBarang && containsPaketServis)
            {
                string sql = "";
                try
                {
                    MySqlConnection con = new MySqlConnection(Koneksi.sql);
                    DataSet ds = new DataSet();

                    sql = "select * from tb_transaksi WHERE invoice='" + invoice + "'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(ds);

                    ReportDocument rd = new ReportDocument();
                    rd.Load("../../NotaServisPembelian.rpt");
                    rd.Database.Tables[0].SetDataSource(ds.Tables[0]);

                    //pakai perintah ini untuk langsung print dan hapus 5 baris perintah di bawahnya
                    //rd.PrintToPrinter;

                    CetakNotaServisPembelian cn = new CetakNotaServisPembelian();
                    cn.MdiParent = this.MdiParent;
                    cn.WindowState = FormWindowState.Maximized;
                    cn.crystalReportViewer1.ReportSource = rd;
                    cn.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (containsBarang)
            {
                string sql = "";
                try
                {
                    MySqlConnection con = new MySqlConnection(Koneksi.sql);
                    DataSet ds = new DataSet();

                    sql = "select * from tb_transaksi WHERE invoice='" + invoice + "'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(ds);

                    ReportDocument rd = new ReportDocument();
                    rd.Load("../../NotaBarang.rpt");
                    rd.Database.Tables[0].SetDataSource(ds.Tables[0]);

                    //pakai perintah ini untuk langsung print dan hapus 5 baris perintah di bawahnya
                    //rd.PrintToPrinter;

                    CetakNotaBarang cn = new CetakNotaBarang();
                    cn.MdiParent = this.MdiParent;
                    cn.WindowState = FormWindowState.Maximized;
                    cn.crystalReportViewer1.ReportSource = rd;
                    cn.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (containsPaketServis)
            {
                string sql = "";
                try
                {
                    MySqlConnection con = new MySqlConnection(Koneksi.sql);
                    DataSet ds = new DataSet();

                    sql = "select * from tb_transaksi WHERE invoice='" + invoice + "'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(ds);

                    ReportDocument rd = new ReportDocument();
                    rd.Load("../../NotaServis.rpt");
                    rd.Database.Tables[0].SetDataSource(ds.Tables[0]);

                    //pakai perintah ini untuk langsung print dan hapus 5 baris perintah di bawahnya
                    //rd.PrintToPrinter;

                    CetakNotaServis cn = new CetakNotaServis();
                    cn.MdiParent = this.MdiParent;
                    cn.WindowState = FormWindowState.Maximized;
                    cn.crystalReportViewer1.ReportSource = rd;
                    cn.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsKodeBarang(string kode)
        {
            MySqlConnection con = new MySqlConnection(Koneksi.sql);
            try
            {
                con.Open();
                string query = $"SELECT COUNT(*) FROM tb_barang WHERE KodeBarang = '{kode}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private bool IsKodePaketServis(string kode)
        {
            MySqlConnection con = new MySqlConnection(Koneksi.sql);
            try
            {
                con.Open();
                string query = $"SELECT COUNT(*) FROM tb_paketservis WHERE KodePaket = '{kode}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
