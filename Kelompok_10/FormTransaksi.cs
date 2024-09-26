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
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Kelompok_10
{
    public partial class FormTransaksi : Form
    {
        private Koneksi koneksi;
        public FormTransaksi()
        {
            InitializeComponent();
            koneksi = new Koneksi();
        }
        public void SetKodeBarang(string kodeBarang)
        {
            txtKode.Text = kodeBarang;
            txtMontir.Enabled = false;
            txtJumlah.Enabled = true;
        }

        public void SetKodePaket(string kodePaket)
        {
            txtKode.Text = kodePaket;
            txtMontir.Enabled = true;
            txtJumlah.Enabled = false;
        }

        void kondisiawal()
        {
            lbNama.Text = "";
            lbKasir.Text = "";
            lbHarga.Text = "";
            lbKembali.Text = "";
            lbTotal.Text = "";
            txtKode.Text = "";
            txtJumlah.Value = 1;
            txtdibayar.Text = "";
            lbInvoice.Text = (GetLastInsertedID() + 1).ToString();
            lbTanggal.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtMontir.Enabled = true;
            txtJumlah.Enabled = true;

            if (koneksi.Open())
            {
                try
                {
                    string sql = $"SELECT NamaKasir FROM tb_kasir WHERE NamaKasir='{UserInfo.Username}'";
                    DataTable resultTable = koneksi.ExecuteDataSet(sql).Tables[0];

                    if (resultTable.Rows.Count > 0)
                    {
                        lbKasir.Text = resultTable.Rows[0]["NamaKasir"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Data kasir tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    koneksi.Close();
                }
            }
            else
            {
                MessageBox.Show("Gagal membuka koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buatkolom()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Kode", "Kode");
            dataGridView1.Columns.Add("Nama", "Nama");
            dataGridView1.Columns.Add("Harga", "Harga");
            dataGridView1.Columns.Add("Jumlah", "Jumlah");
            dataGridView1.Columns.Add("Montir", "Nama Montir");
            dataGridView1.Columns.Add("SubTotal", "Sub Total");

            dataGridView1.Columns[1].Width = 300;
        }

        void FillMontirComboBox()
        {
            // Kosongkan combo box
            txtMontir.Items.Clear();

            // Buat koneksi baru
            Koneksi koneksiBaru = new Koneksi();
            {
                // Buka koneksi
                if (koneksiBaru.Open())
                {
                    // Ambil data montir dari database dan isi combo box
                    string query = "SELECT NamaMontir FROM tb_montir";
                    DataSet ds = koneksiBaru.ExecuteDataSet(query);
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        txtMontir.Items.Add(row["NamaMontir"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Gagal membuka koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Koneksi akan ditutup secara otomatis ketika keluar dari blok using
        }

        private void SimpanTransaksi()
        {
            double totalHarga = Convert.ToDouble(lbTotal.Text.Replace("Rp", "").Replace(",", ""));
            double bayar = Convert.ToDouble(txtdibayar.Text.Replace("Rp", "").Replace(",", ""));
            double kembali = bayar - totalHarga;

            using (var con = new MySqlConnection(Koneksi.sql))
            {
                try
                {
                    con.Open();
                    string query = $"INSERT INTO tb_transaksi (Tanggal, Jam, NamaKasir, TotalHarga, Bayar, Kembali) VALUES " +
                        $"('{DateTime.Now:yyyy-MM-dd}', '{DateTime.Now:HH:mm:ss}', '{lbKasir.Text}', '{totalHarga}', '{bayar}', '{kembali}')";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private int GetLastInsertedID()
        {
            int lastInsertedID = 0;

            if (koneksi.Open())
            {
                try
                {
                    string query = "SELECT MAX(Invoice) AS LastID FROM tb_transaksi";
                    DataSet ds = koneksi.ExecuteDataSet(query);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0 && dt.Rows[0]["LastID"] != DBNull.Value)
                    {
                        lastInsertedID = Convert.ToInt32(dt.Rows[0]["LastID"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    koneksi.Close();
                }
            }
            else
            {
                MessageBox.Show("Gagal membuka koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lastInsertedID;
        }

        private void SimpanDetailServisPembelian()
        {
            using (MySqlConnection con = new MySqlConnection(Koneksi.sql))
            {
                try
                {
                    con.Open();
                    using (MySqlTransaction transaction = con.BeginTransaction())
                    {
                        string invoiceId = GetLastInsertedID(con, transaction);

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string kodeBarang = row.Cells["Kode"].Value.ToString();
                                string namaBarang = row.Cells["Nama"].Value.ToString();
                                double hargaBarang = Convert.ToDouble(row.Cells["Harga"].Value);
                                int jumlahBarang = Convert.ToInt32(row.Cells["Jumlah"].Value);
                                double subtotal = Convert.ToDouble(row.Cells["SubTotal"].Value);
                                string namaMontir = "";

                                if (IsKodeBarang(kodeBarang))
                                {
                                    string query = "INSERT INTO tb_detailservispembelian (Invoice, KodeBarang, NamaBarang, HargaBarang, JumlahBarang, SubTotal) VALUES" +
                                        " (@Invoice, @KodeBarang, @NamaBarang, @HargaBarang, @JumlahBarang, @SubTotal)";

                                    using (MySqlCommand cmd = new MySqlCommand(query, con, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@Invoice", invoiceId);
                                        cmd.Parameters.AddWithValue("@KodeBarang", kodeBarang);
                                        cmd.Parameters.AddWithValue("@NamaBarang", namaBarang);
                                        cmd.Parameters.AddWithValue("@HargaBarang", hargaBarang);
                                        cmd.Parameters.AddWithValue("@JumlahBarang", jumlahBarang);
                                        cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else if (IsKodePaketServis(kodeBarang))
                                {
                                    // Memeriksa apakah kolom "Montir" ada dan tidak null
                                    if (row.Cells["Montir"] != null && row.Cells["Montir"].Value != null)
                                    {
                                        namaMontir = row.Cells["Montir"].Value.ToString();
                                    }

                                    // Menggunakan nama montir yang diperoleh dari DataGridView
                                    var paketDetail = GetDetailPaket(kodeBarang, namaMontir, con);

                                    string query = "INSERT INTO tb_detailservispembelian (Invoice, KodePaket, Paket, NamaMontir, Biaya, Deskripsi, SubTotal) VALUES" +
                                        " (@Invoice, @KodePaket, @Paket, @NamaMontir, @Biaya, @Deskripsi, @SubTotal)";

                                    using (MySqlCommand cmd = new MySqlCommand(query, con, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@Invoice", invoiceId);
                                        cmd.Parameters.AddWithValue("@KodePaket", kodeBarang);
                                        cmd.Parameters.AddWithValue("@Paket", paketDetail.Paket);
                                        cmd.Parameters.AddWithValue("@NamaMontir", namaMontir); // Menggunakan nama montir dari inputan
                                        cmd.Parameters.AddWithValue("@Biaya", paketDetail.Biaya);
                                        cmd.Parameters.AddWithValue("@Deskripsi", paketDetail.Deskripsi);
                                        cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private (string Paket, double Biaya, string Deskripsi) GetDetailPaket(string kodePaket, string namaMontir, MySqlConnection con)
        {
            string paket = "";
            double biaya = 0;
            string deskripsi = "";

            try
            {
                string query = "SELECT Paket, Biaya, Deskripsi FROM tb_paketservis WHERE KodePaket = @KodePaket";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KodePaket", kodePaket);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            paket = reader["Paket"].ToString();
                            biaya = Convert.ToDouble(reader["Biaya"]);
                            deskripsi = reader["Deskripsi"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (paket, biaya, deskripsi);
        }

        private string GetLastInsertedID(MySqlConnection con, MySqlTransaction transaction)
        {
            string lastInsertedId = "";

            try
            {
                string query = "SELECT LAST_INSERT_ID()";

                using (MySqlCommand cmd = new MySqlCommand(query, con, transaction))
                {
                    lastInsertedId = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInsertedId;
        }


        private string GetDeskripsiPaket(string kodePaket, MySqlConnection con)
        {
            string deskripsi = "";

            try
            {
                // Menggunakan koneksi yang sudah dibuka di metode SimpanDetailServisPembelian
                string query = $"SELECT Deskripsi FROM tb_paketservis WHERE KodePaket = '{kodePaket}'";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        deskripsi = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return deskripsi;
        }


        private void HitungTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["SubTotal"].Value);
            }
            // Tampilkan total pada label
            lbTotal.Text = total.ToString("C0");
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            SimpanTransaksi();

            bool containsBarang = false;
            bool containsPaketServis = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string kode = row.Cells["Kode"].Value.ToString();
                    if (IsKodeBarang(kode)) containsBarang = true;
                    if (IsKodePaketServis(kode)) containsPaketServis = true;
                }
            }

            if (containsBarang && containsPaketServis)
            {
                SimpanDetailServisPembelian();
                //MessageBox.Show("Data Berhasil Di Simpan ke Servis Penjualan");
                if (MessageBox.Show("Cetak Nota?", "Data Berhasil Di Simpan ke Servis Penjualan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "";
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Koneksi.sql);
                        DataSet ds = new DataSet();

                        sql = "select * from tb_transaksi WHERE invoice='" + lbInvoice.Text + "'";

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
            }
            else if (containsBarang)
            {
                SimpanDetailPembelian();
                //MessageBox.Show("Data Pembelian Berhasil Di Simpan");
                if (MessageBox.Show("Cetak Nota?", "Data Pembelian Berhasil Di Simpan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "";
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Koneksi.sql);
                        DataSet ds = new DataSet();

                        sql = "select * from tb_transaksi WHERE invoice='" + lbInvoice.Text + "'";

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
            }
            else if (containsPaketServis)
            {
                SimpanDetailServis();
                //MessageBox.Show("Data Servis Berhasil Di Simpan");
                if (MessageBox.Show("Cetak Nota?", "Data Servis Berhasil Di Simpan", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "";
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Koneksi.sql);
                        DataSet ds = new DataSet();

                        sql = "select * from tb_transaksi WHERE invoice='" + lbInvoice.Text + "'";

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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Periksa apakah baris merupakan baris baru
                {
                    DataGridViewCell kodeCell = row.Cells["Kode"];
                    DataGridViewCell jumlahCell = row.Cells["Jumlah"];

                    if (kodeCell.Value != null && jumlahCell.Value != null)
                    {
                        string kode = kodeCell.Value.ToString();
                        int jumlahTerjual;

                        if (int.TryParse(jumlahCell.Value.ToString(), out jumlahTerjual))
                        {
                            // Update stok barang
                            UpdateStokBarang(kode, jumlahTerjual);
                        }
                        else
                        {
                            MessageBox.Show("Invalid value for Jumlah");
                        }
                    }
                }
            }
            BersihkanForm();
            kondisiawal();
        }
        private string GetInvoiceNumber()
        {
            // Mengambil nomor invoice dari kontrol Label lbInvoice
            return lbInvoice.Text;
        }
        private void UpdateStokBarang(string kodeBarang, int jumlahTerjual)
        {
            MySqlConnection con = new MySqlConnection(Koneksi.sql);
            con.Open();

            // Query SQL untuk mendapatkan jumlah barang yang tersedia
            string querySelect = "SELECT Stok FROM tb_barang WHERE KodeBarang = @KodeBarang";
            MySqlCommand cmdSelect = new MySqlCommand(querySelect, con);
            cmdSelect.Parameters.AddWithValue("@KodeBarang", kodeBarang);
            int jumlahTersedia = Convert.ToInt32(cmdSelect.ExecuteScalar());

            // Menghitung jumlah stok yang tersisa setelah penjualan
            int stokBaru = jumlahTersedia - jumlahTerjual;

            // Query SQL untuk melakukan update stok barang
            string queryUpdate = "UPDATE tb_barang SET Stok = @Stok WHERE KodeBarang = @KodeBarang";
            MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@Stok", stokBaru);
            cmdUpdate.Parameters.AddWithValue("@KodeBarang", kodeBarang);
            cmdUpdate.ExecuteNonQuery();

            con.Close();
        }

        private void BersihkanForm()
        {
            dataGridView1.Rows.Clear();
            txtKode.Text = "";
            txtMontir.Text = "";
            txtJumlah.Value = 0;
            txtdibayar.Text = "";
            lbNama.Text = "";
            lbHarga.Text = "";
            lbTotal.Text = "";
            lbKembali.Text = "";
        }

        private void SimpanDetailPembelian()
        {
            MySqlConnection con = new MySqlConnection(Koneksi.sql);
            {
                con.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewCell kodeCell = row.Cells["Kode"];
                        DataGridViewCell jumlahCell = row.Cells["Jumlah"];

                        if (kodeCell.Value != null && jumlahCell.Value != null)
                        {
                            string kodeBarang = kodeCell.Value.ToString();
                            int jumlahTerjual;

                            if (int.TryParse(jumlahCell.Value.ToString(), out jumlahTerjual))
                            {
                                string query = "INSERT INTO tb_detailpembelian (Invoice, KodeBarang, NamaBarang, HargaBarang, JumlahBarang, SubTotal)" +
                                    " VALUES " +
                                    "(@Invoice, @KodeBarang, @NamaBarang, @HargaBarang, @JumlahBarang, @SubTotal)";
                                using (MySqlCommand cmd = new MySqlCommand(query, con)) // Menggunakan MySqlCommand
                                {
                                    cmd.Parameters.AddWithValue("@Invoice", GetLastInsertedID());
                                    cmd.Parameters.AddWithValue("@KodeBarang", kodeBarang);
                                    cmd.Parameters.AddWithValue("@NamaBarang", row.Cells["Nama"].Value);
                                    cmd.Parameters.AddWithValue("@HargaBarang", row.Cells["Harga"].Value);
                                    cmd.Parameters.AddWithValue("@JumlahBarang", jumlahTerjual);
                                    cmd.Parameters.AddWithValue("@SubTotal", row.Cells["SubTotal"].Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid value for JumlahJual.");
                            }
                        }
                    }
                }
            }
        }

        private void SimpanDetailServis()
        {
            MySqlConnection con = new MySqlConnection(Koneksi.sql);
            try
            {
                con.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewCell kodeCell = row.Cells["Kode"];
                        DataGridViewCell jumlahCell = row.Cells["Jumlah"];

                        if (kodeCell.Value != null && jumlahCell.Value != null)
                        {
                            string kodePaketServis = kodeCell.Value.ToString();
                            int jumlahTerjual;

                            if (int.TryParse(jumlahCell.Value.ToString(), out jumlahTerjual))
                            {
                                string namaMontir = row.Cells["Montir"].Value.ToString();

                                // Dapatkan deskripsi paket servis berdasarkan kodePaketServis
                                string deskripsi = GetDeskripsiPaket(kodePaketServis, con);

                                string query = "INSERT INTO tb_detailservis (Invoice, KodePaket, Paket, Biaya, NamaMontir, Deskripsi) VALUES" +
                                    " (@Invoice, @KodePaket, @Paket, @Biaya, @NamaMontir, @Deskripsi)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(query, con))
                                {
                                    cmdInsert.Parameters.AddWithValue("@Invoice", GetLastInsertedID());
                                    cmdInsert.Parameters.AddWithValue("@KodePaket", kodePaketServis);
                                    cmdInsert.Parameters.AddWithValue("@Paket", row.Cells["Nama"].Value);
                                    cmdInsert.Parameters.AddWithValue("@Biaya", row.Cells["Harga"].Value);
                                    cmdInsert.Parameters.AddWithValue("@NamaMontir", namaMontir);
                                    cmdInsert.Parameters.AddWithValue("@Deskripsi", deskripsi);
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid value for Jumlah.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbJam.Text = GetCurrentTimeInIndonesia();
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            lbTanggal.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbJam.Text = GetCurrentTimeInIndonesia();
            lbKasir.Text = UserInfo.Username;
            kondisiawal();
            buatkolom();
            FillMontirComboBox();
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

        private void TxtKode_TextChanged(object sender, EventArgs e)
        {
            string kodeBarang = txtKode.Text;

            if (!string.IsNullOrWhiteSpace(kodeBarang))
            {
                Koneksi koneksi = new Koneksi();
                try
                {
                    if (koneksi.Open())
                    {
                        string query = $"SELECT * FROM tb_barang WHERE KodeBarang = '{kodeBarang}'";
                        DataSet dsBarang = koneksi.ExecuteDataSet(query);

                        if (dsBarang != null && dsBarang.Tables.Count > 0 && dsBarang.Tables[0].Rows.Count > 0)
                        {
                            // Jika kode barang ada di tb_barang
                            DataTable dtBarang = dsBarang.Tables[0];
                            lbNama.Text = dtBarang.Rows[0]["NamaBarang"].ToString();
                            lbHarga.Text = dtBarang.Rows[0]["HargaJual"].ToString();

                            // Disable combo box txtMontir
                            txtMontir.Enabled = false;
                            txtMontir.Text = "";
                        }
                        else
                        {
                            // Lakukan pemeriksaan untuk tb_paketservis jika tidak ditemukan di tb_barang
                            query = $"SELECT * FROM tb_paketservis WHERE KodePaket = '{kodeBarang}'";
                            DataSet dsPaket = koneksi.ExecuteDataSet(query);

                            if (dsPaket != null && dsPaket.Tables.Count > 0 && dsPaket.Tables[0].Rows.Count > 0)
                            {
                                // Jika kode barang ada di tb_paketservis
                                DataTable dtPaket = dsPaket.Tables[0];
                                lbNama.Text = dtPaket.Rows[0]["Paket"].ToString();
                                lbHarga.Text = dtPaket.Rows[0]["Biaya"].ToString();

                                // Disable numeric up down txtJumlah
                                txtJumlah.Enabled = false;
                            }
                            else
                            {
                                // Jika kode barang tidak ditemukan di tb_barang dan tb_paketservis
                                lbNama.Text = "";
                                lbHarga.Text = "";

                                // Enable kembali combo box txtMontir dan numeric up down txtJumlah
                                txtMontir.Enabled = true;
                                txtJumlah.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gagal membuka koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Tutup koneksi secara manual setelah selesai menggunakan
                    koneksi.Close();
                }
            }
            else
            {
                // Jika kode barang kosong, reset lbNamaBarang dan lbHargaBarang, dan enable kembali combo box txtMontir dan numeric up down txtJumlah
                lbNama.Text = "";
                lbHarga.Text = "";
                txtMontir.Enabled = true;
                txtJumlah.Enabled = true;
            }
        }

        private void Txtdibayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembali();
        }

        private void HitungKembali()
        {
            if (decimal.TryParse(txtdibayar.Text.Replace("Rp", "").Replace(".", ""), out decimal jumlahBayar))
            {
                // Membersihkan format angka total belanja (menghapus simbol mata uang Rupiah)
                string totalBelanjaCleaned = lbTotal.Text.Replace("Rp", "");

                // Cek apakah total belanja bisa diubah menjadi angka setelah membersihkan format
                if (decimal.TryParse(totalBelanjaCleaned, out decimal totalBelanja))
                {
                    // Hitung kembalian
                    decimal kembalian = jumlahBayar - totalBelanja;

                    // Tampilkan kembalian di label dengan format mata uang Rupiah dan tanda titik pemisah ribuan
                    lbKembali.Text = "Rp" + kembalian.ToString("N0");
                }
                else
                {
                    // Total belanja tidak valid
                    lbKembali.Text = "Total Belanja Tidak Valid";
                }
            }
            else
            {
                // Jumlah yang dibayar tidak valid
                lbKembali.Text = "Jumlah yang Dibayar Tidak Valid";
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

        private void HitungSubtotal()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    double harga = Convert.ToDouble(row.Cells["Harga"].Value);
                    int jumlah = Convert.ToInt32(row.Cells["Jumlah"].Value);
                    double subtotal = 0;

                    // Periksa apakah item adalah barang atau paket servis
                    if (IsKodeBarang(row.Cells["Kode"].Value.ToString()))
                    {
                        subtotal = harga * jumlah;
                    }
                    else if (IsKodePaketServis(row.Cells["Kode"].Value.ToString()))
                    {
                        subtotal = harga; // Tidak perlu dikalikan dengan jumlah
                    }

                    // Set nilai subtotal pada kolom "SubTotal"
                    row.Cells["SubTotal"].Value = subtotal;
                }
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            // Ambil nilai dari input pengguna
            string kode = txtKode.Text;
            string nama = lbNama.Text;
            double harga = Convert.ToDouble(lbHarga.Text);
            int jumlah = Convert.ToInt32(txtJumlah.Value);

            // Clear the selected mechanic when adding a product
            string montir = IsKodePaketServis(kode) ? txtMontir.SelectedItem?.ToString() : "";

            // Hitung subtotal
            double subtotal = 0;
            if (IsKodeBarang(kode))
            {
                subtotal = harga * jumlah;
            }
            else if (IsKodePaketServis(kode))
            {
                subtotal = harga; // Tidak perlu dikalikan dengan jumlah
            }

            // Tambahkan data ke DataGridView
            dataGridView1.Rows.Add(kode, nama, harga, jumlah, montir, subtotal);

            // Hitung total
            HitungTotal();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Jika terjadi perubahan pada kolom "Jumlah" atau "Harga"
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Jumlah" || dataGridView1.Columns[e.ColumnIndex].Name == "Harga")
                {
                    HitungSubtotal();
                    HitungTotal();
                }
            }
        }

        private void BtnHapusBaris_Click(object sender, EventArgs e)
        {
            // Periksa apakah ada baris yang dipilih
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Hapus baris yang dipilih
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                // Hitung kembali total setelah penghapusan baris
                HitungTotal();
            }
            else
            {
                MessageBox.Show("Pilih baris yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBarang_Click(object sender, EventArgs e)
        {
            Barang b = new Barang(this);
            b.Show();
        }

        private void BtnServis_Click(object sender, EventArgs e)
        {
            PaketServis s = new PaketServis(this);
            s.Show();
        }

        private void LbTotal_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }
    }
}

