using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{

    class Model_db
    {
        public static MySqlConnection conn = new MySqlConnection(@"server = localhost; user id = root; password= ;database= szakdoga_db;"); //localhost

        MySqlDataReader reader;
        MySqlCommand cmd = new MySqlCommand();


        public void list_upload_vertical(string sql_query, List<string> list, string db_column)
        {
            cmd.Connection = conn;
            cmd.CommandText = sql_query;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) { list.Add(reader.GetString(db_column)); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }

        public void list_upload_horizontal(List<string> list_upload_data, string sql_query, List<string> list_sql_columns)
        {
            cmd.Connection = conn;
            cmd.CommandText = sql_query;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < list_sql_columns.Count; i++)
                    {
                        list_upload_data.Add(reader.GetString(list_sql_columns[i]));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }

        public void database_update(string sql_table, string sql_column, string amount)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE {sql_table} SET {sql_column} = {sql_column} + {amount} WHERE ID = {C_Login.ID};";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
        }

    }
}
