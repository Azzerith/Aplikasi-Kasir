namespace Kelompok_10
{
    partial class FormTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtJumlah = new System.Windows.Forms.NumericUpDown();
            this.lbKasir = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbHarga = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbNama = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbJam = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTanggal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbInvoice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtdibayar = new System.Windows.Forms.TextBox();
            this.lbKembali = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontir = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHapusBaris = new System.Windows.Forms.Button();
            this.btnBarang = new System.Windows.Forms.Button();
            this.btnServis = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtJumlah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJumlah
            // 
            this.txtJumlah.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlah.Location = new System.Drawing.Point(1326, 19);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(110, 35);
            this.txtJumlah.TabIndex = 48;
            // 
            // lbKasir
            // 
            this.lbKasir.BackColor = System.Drawing.Color.White;
            this.lbKasir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbKasir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKasir.Location = new System.Drawing.Point(191, 76);
            this.lbKasir.Name = "lbKasir";
            this.lbKasir.Size = new System.Drawing.Size(151, 32);
            this.lbKasir.TabIndex = 47;
            this.lbKasir.Text = "lbKasir";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(85, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 32);
            this.label21.TabIndex = 46;
            this.label21.Text = "Kasir";
            // 
            // txtKode
            // 
            this.txtKode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKode.Location = new System.Drawing.Point(84, 60);
            this.txtKode.Multiline = true;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(165, 37);
            this.txtKode.TabIndex = 45;
            this.txtKode.TextChanged += new System.EventHandler(this.TxtKode_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(84, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1705, 372);
            this.dataGridView1.TabIndex = 44;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambah.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(1607, 19);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(179, 86);
            this.btnTambah.TabIndex = 43;
            this.btnTambah.Text = "TAMBAH";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1158, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 35);
            this.label14.TabIndex = 42;
            this.label14.Text = "JUMLAH BARANG";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(504, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 39);
            this.label13.TabIndex = 41;
            this.label13.Text = "HARGA";
            // 
            // lbHarga
            // 
            this.lbHarga.BackColor = System.Drawing.Color.White;
            this.lbHarga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHarga.Location = new System.Drawing.Point(646, 62);
            this.lbHarga.Name = "lbHarga";
            this.lbHarga.Size = new System.Drawing.Size(462, 39);
            this.lbHarga.TabIndex = 40;
            this.lbHarga.Text = "lbHarga";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(84, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(265, 35);
            this.label11.TabIndex = 39;
            this.label11.Text = "Kode Barang/ Servis";
            // 
            // lbNama
            // 
            this.lbNama.BackColor = System.Drawing.Color.White;
            this.lbNama.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNama.Location = new System.Drawing.Point(646, 19);
            this.lbNama.Name = "lbNama";
            this.lbNama.Size = new System.Drawing.Size(462, 33);
            this.lbNama.TabIndex = 38;
            this.lbNama.Text = "lbNama";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(504, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 32);
            this.label10.TabIndex = 37;
            this.label10.Text = "NAMA";
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(3, 16);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(1099, 119);
            this.lbTotal.TabIndex = 36;
            this.lbTotal.Text = "lbTotal";
            this.lbTotal.Click += new System.EventHandler(this.LbTotal_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(667, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 36);
            this.label8.TabIndex = 35;
            this.label8.Text = "TOTAL";
            // 
            // lbJam
            // 
            this.lbJam.BackColor = System.Drawing.Color.White;
            this.lbJam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbJam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJam.Location = new System.Drawing.Point(472, 76);
            this.lbJam.Name = "lbJam";
            this.lbJam.Size = new System.Drawing.Size(151, 32);
            this.lbJam.TabIndex = 34;
            this.lbJam.Text = "lbJam";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 32);
            this.label6.TabIndex = 33;
            this.label6.Text = "Jam";
            // 
            // lbTanggal
            // 
            this.lbTanggal.BackColor = System.Drawing.Color.White;
            this.lbTanggal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTanggal.Location = new System.Drawing.Point(472, 25);
            this.lbTanggal.Name = "lbTanggal";
            this.lbTanggal.Size = new System.Drawing.Size(151, 32);
            this.lbTanggal.TabIndex = 32;
            this.lbTanggal.Text = "lbTanggal";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 32);
            this.label4.TabIndex = 31;
            this.label4.Text = "Tanggal";
            // 
            // lbInvoice
            // 
            this.lbInvoice.BackColor = System.Drawing.Color.White;
            this.lbInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvoice.Location = new System.Drawing.Point(191, 21);
            this.lbInvoice.Name = "lbInvoice";
            this.lbInvoice.Size = new System.Drawing.Size(125, 36);
            this.lbInvoice.TabIndex = 30;
            this.lbInvoice.Text = "lbInvoice";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 36);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nomor Nota";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(696, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 66);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "KEMBALI";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(867, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 66);
            this.btnClear.TabIndex = 54;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSimpan.Location = new System.Drawing.Point(1318, 99);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(182, 68);
            this.btnSimpan.TabIndex = 53;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtdibayar
            // 
            this.txtdibayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdibayar.Location = new System.Drawing.Point(1520, 21);
            this.txtdibayar.Multiline = true;
            this.txtdibayar.Name = "txtdibayar";
            this.txtdibayar.Size = new System.Drawing.Size(266, 34);
            this.txtdibayar.TabIndex = 52;
            this.txtdibayar.TextChanged += new System.EventHandler(this.Txtdibayar_TextChanged);
            // 
            // lbKembali
            // 
            this.lbKembali.BackColor = System.Drawing.Color.White;
            this.lbKembali.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKembali.Location = new System.Drawing.Point(1520, 61);
            this.lbKembali.Name = "lbKembali";
            this.lbKembali.Size = new System.Drawing.Size(266, 32);
            this.lbKembali.TabIndex = 51;
            this.lbKembali.Text = "Kembali";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1318, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 32);
            this.label16.TabIndex = 50;
            this.label16.Text = "Kembali";
            this.label16.Click += new System.EventHandler(this.Label16_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1318, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 32);
            this.label15.TabIndex = 49;
            this.label15.Text = "Di Bayar";
            this.label15.Click += new System.EventHandler(this.Label15_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1158, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 39);
            this.label2.TabIndex = 57;
            this.label2.Text = "Montir";
            // 
            // txtMontir
            // 
            this.txtMontir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontir.FormattingEnabled = true;
            this.txtMontir.Location = new System.Drawing.Point(1326, 64);
            this.txtMontir.Name = "txtMontir";
            this.txtMontir.Size = new System.Drawing.Size(244, 37);
            this.txtMontir.TabIndex = 58;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Location = new System.Drawing.Point(773, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 148);
            this.panel1.TabIndex = 59;
            // 
            // btnHapusBaris
            // 
            this.btnHapusBaris.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHapusBaris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapusBaris.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusBaris.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHapusBaris.Location = new System.Drawing.Point(1038, 21);
            this.btnHapusBaris.Name = "btnHapusBaris";
            this.btnHapusBaris.Size = new System.Drawing.Size(220, 66);
            this.btnHapusBaris.TabIndex = 60;
            this.btnHapusBaris.Text = "HAPUS BARIS";
            this.btnHapusBaris.UseVisualStyleBackColor = false;
            this.btnHapusBaris.Click += new System.EventHandler(this.BtnHapusBaris_Click);
            // 
            // btnBarang
            // 
            this.btnBarang.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBarang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBarang.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBarang.Location = new System.Drawing.Point(81, 21);
            this.btnBarang.Name = "btnBarang";
            this.btnBarang.Size = new System.Drawing.Size(165, 66);
            this.btnBarang.TabIndex = 62;
            this.btnBarang.Text = "BARANG";
            this.btnBarang.UseVisualStyleBackColor = false;
            this.btnBarang.Click += new System.EventHandler(this.BtnBarang_Click);
            // 
            // btnServis
            // 
            this.btnServis.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnServis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServis.Font = new System.Drawing.Font("Quicksilver", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnServis.Location = new System.Drawing.Point(252, 21);
            this.btnServis.Name = "btnServis";
            this.btnServis.Size = new System.Drawing.Size(220, 66);
            this.btnServis.TabIndex = 63;
            this.btnServis.Text = "PAKET SERVIS";
            this.btnServis.UseVisualStyleBackColor = false;
            this.btnServis.Click += new System.EventHandler(this.BtnServis_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1894, 170);
            this.panel2.TabIndex = 64;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kelompok_10.Properties.Resources.cash_machine;
            this.pictureBox1.Location = new System.Drawing.Point(23, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Transformers Movie", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(176, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1324, 90);
            this.label3.TabIndex = 3;
            this.label3.Text = "FORM TRANSAKSI BENGKEL DUKUN TIROT";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.lbInvoice);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbKasir);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.lbTanggal);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lbJam);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1894, 154);
            this.panel3.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.btnBarang);
            this.panel4.Controls.Add(this.btnServis);
            this.panel4.Controls.Add(this.btnHapusBaris);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.txtdibayar);
            this.panel4.Controls.Add(this.lbKembali);
            this.panel4.Controls.Add(this.btnSimpan);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 841);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1894, 179);
            this.panel4.TabIndex = 66;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txtKode);
            this.panel5.Controls.Add(this.txtMontir);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lbHarga);
            this.panel5.Controls.Add(this.txtJumlah);
            this.panel5.Controls.Add(this.lbNama);
            this.panel5.Controls.Add(this.btnTambah);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 324);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1894, 517);
            this.panel5.TabIndex = 67;
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1894, 1020);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormTransaksi";
            this.Text = "FormTransaksi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTransaksi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtJumlah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtJumlah;
        public System.Windows.Forms.Label lbKasir;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbHarga;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbNama;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbJam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTanggal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtdibayar;
        private System.Windows.Forms.Label lbKembali;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtMontir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHapusBaris;
        private System.Windows.Forms.Button btnBarang;
        private System.Windows.Forms.Button btnServis;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}