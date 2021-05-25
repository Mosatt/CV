using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class M_db_messages
    {
        MySqlCommand cmd = new MySqlCommand();

        public void message_send(ComboBox cb_country_list, TextBox tb_subject, TextBox tb_message)
        {
            cmd.Connection = Model_db.conn;
            cmd.CommandText = $"INSERT INTO `messages`(`date`, `sender_country`, `adresse_country`, `subject`, `text`, `read_status`)" +
                $" VALUES ('{DateTime.Now:yyyy.MM.dd.HH:mm:ss}', '{C_MainPageForm.country_name}', '{cb_country_list.SelectedItem}', '{tb_subject.Text}', '{tb_message.Text}', '0')";
            //
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }
    }
}
