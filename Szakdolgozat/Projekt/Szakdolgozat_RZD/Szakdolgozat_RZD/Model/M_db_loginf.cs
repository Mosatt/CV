using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class M_db_loginf
    {
        public bool login_hash_check(bool check, MySqlCommand cmd)
        {
            try
            {
                Model_db.conn.Open();
                MySqlDataReader mdr = cmd.ExecuteReader();
                check = mdr.HasRows;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            finally { Model_db.conn.Close(); }
            return check;
        }



    }
}
