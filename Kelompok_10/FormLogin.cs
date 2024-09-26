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
    public partial class FormLogin : Form
    {
        Koneksi con = new Koneksi();
        string username, password;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            txtPassword.PasswordChar = '\u25CF';

        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    con.Open();
                    string query = "SELECT * FROM tb_kasir WHERE NamaKasir = '" + txtUsername.Text + "' AND PasswordKasir = '" + txtPassword.Text + "'";
                    MySqlDataReader row = con.ExecuteReader(query);

                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            string level = row["LevelKasir"].ToString();

                            UserInfo.Username = txtUsername.Text;
                            UserInfo.Level = level;

                            MessageBox.Show("Login Berhasil!");
                            this.Hide();

                            if (level == "Admin")
                            {
                                FormUtama fu = new FormUtama();
                                fu.Show();
                            }
                            else if (level == "User")
                            {
                                FormUtamaUser fuUser = new FormUtamaUser();
                                fuUser.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is empty!", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message, "Information");
            }
            finally
            {
                con.Close();
            }
        }


    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '\u25CF'; // Hide password
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    con.Open();
                    string query = "SELECT * FROM tb_kasir WHERE NamaKasir = '" + txtUsername.Text + "' AND PasswordKasir = '" + txtPassword.Text + "'";
                    MySqlDataReader row = con.ExecuteReader(query);

                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            string level = row["LevelKasir"].ToString();

                            UserInfo.Username = txtUsername.Text;
                            UserInfo.Level = level;

                            MessageBox.Show("Login Berhasil!");
                            this.Hide();

                            if (level == "Admin")
                            {
                                FormUtama fu = new FormUtama();
                                fu.Show();
                            }
                            else if (level == "User")
                            {
                                FormUtamaUser fuUser = new FormUtamaUser();
                                fuUser.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is empty!", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message, "Information");
            }
            finally
            {
                con.Close();
            }
        }
    
    }
}
