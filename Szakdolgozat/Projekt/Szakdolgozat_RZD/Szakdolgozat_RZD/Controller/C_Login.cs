using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Szakdolgozat_RZD
{
    class C_Login
    {

        string username { get; set; }
        string password { get; set; }
        public static string status { get; set; }
        bool check_username { get; set; }
        bool check_password { get; set; }
        public static int ID { get; set; }

        public C_Login() { }

        string Encript(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public void login(string tb_username, string tb_password)
        {
            M_db_loginf m_db_loginform = new M_db_loginf();

            username = tb_username;
            password = Encript(tb_password).GetHashCode().ToString();
            
            string sql_name = "SELECT username FROM users WHERE username = @login_name;";
            string sql_pass = "SELECT password FROM users WHERE password = @login_password;";
            string sql_status = "SELECT status FROM users WHERE username = '"+ username +"' and password = '"+ password +"'";
            string sql_ID = "SELECT userID FROM users WHERE username = '" + username + "' and password = '" + password + "'";
            
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@login_name";
            param.Value = username;
            MySqlCommand cmd_username = new MySqlCommand(sql_name, Model_db.conn);
            cmd_username.Parameters.Add(param);

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@login_password";
            param2.Value = password;
            MySqlCommand cmd_password = new MySqlCommand(sql_pass, Model_db.conn);
            cmd_password.Parameters.Add(param2);
            
            

            if (!Regex.IsMatch(username.ToLower(), @"^[a-z]{9-16}$") && Regex.IsMatch(username.ToLower(),
                "select|drop|update|insert|delete|alter|create|group|order|from|where|having|;|>|<|-"))
            {
                MessageBox.Show("Rossz felhasználónév, vagy jelszó!");
                username = string.Empty;
                password = string.Empty;
            }
            else if (!Regex.IsMatch(password.ToLower(), @"^[a-zA-Z0-9]{0-30}$") && Regex.IsMatch(password.ToLower(),
                "select|drop|update|insert|delete|alter|create|or|group|order|from|where|having|;|>|<|-"))
            {
                MessageBox.Show("Rossz felhasználónév, vagy jelszó!");
                username = string.Empty;
                password = string.Empty;
            }
            else
            {
                
                check_username = m_db_loginform.login_hash_check(check_username, cmd_username);
                check_password = m_db_loginform.login_hash_check(check_password, cmd_password);

                try
                {
                    Model_db.conn.Open();
                    MySqlCommand cmd_status = new MySqlCommand(sql_status, Model_db.conn);
                    MySqlDataReader statusreader = cmd_status.ExecuteReader();
                    while (statusreader.Read())
                    {
                        status = statusreader.GetString("status");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                finally { Model_db.conn.Close(); }
                
                try
                {
                    Model_db.conn.Open();
                    MySqlCommand cmd_ID = new MySqlCommand(sql_ID, Model_db.conn);
                    MySqlDataReader IDreader = cmd_ID.ExecuteReader();
                    while (IDreader.Read())
                    {
                        ID = int.Parse(IDreader.GetString("userID"));
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                finally { Model_db.conn.Close(); }

                if (check_username == true && check_password == true)
                {
                    if (status == "user") { MainForm mf = new MainForm(); mf.Show(); mf.mainpageToolStripMenuItem_Click(null, null); }
                    else if (status == "admin") { AdminForm af = new AdminForm(); af.Show(); }
                    LoginF lf = new LoginF(); lf.Hide();
                }
                else
                {
                    MessageBox.Show("Rossz felhasználónév, vagy jelszó!\n", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    username = string.Empty;
                    password = string.Empty;
                }
            }
        }
    }
}
