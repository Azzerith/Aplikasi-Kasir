using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Kelompok_10
{
    public static class UserInfo
    {
        public static string Username { get; set; }
        public static string Level { get; set; }
    }
    class Koneksi
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        string myConnectionString;
        static string host = "localhost";
        static string database = "kelompok_10";
        static string userDB = "root";
        static string password = "";
        public static string sql = "server" + host + ";Database=" + database + ";User ID=" + userDB + ";" +
            "Password=" + password;

        public bool Open()
        {
            try
            {
                sql = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";" +
            "Password=" + password;
                con = new MySqlConnection(sql);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error !" + ex.Message, "Information");
            }
            return false;
        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = con.BeginTransaction();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }
}
