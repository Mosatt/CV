using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class M_db_economyf
    {
        Model_db m_db = new Model_db();
        MySqlCommand cmd = new MySqlCommand();

        public string budget_sql = $"SELECT * FROM `budget` WHERE ID = {C_Login.ID}";
        public string expected_query = $"SELECT * FROM expected_resources WHERE ID = {C_Login.ID}";

        public List<string> list_budget_sql_query_columns = new List<string>()
        {
            "storage_money", "storage_food", "storage_building_material", "storage_textile", "storage_weapon",
            "cost_money", "cost_food", "cost_building_material", "cost_textile", "cost_weapon",
            "market_money", "market_food", "market_building_material", "market_textile", "market_weapon", "tax", "health_cost", "education_cost", "public_safety_cost"
        };

        public List<string> list_expected_resources = new List<string>();
        public List<string> list_expected_resources_sql_columns = new List<string>() { "money", "food", "building_material", "textile", "weapon" };

        public void data_upload(string sql_table, string sql_column, string amount)
        {
            cmd.Connection = Model_db.conn;
            cmd.CommandText = $"UPDATE {sql_table} SET {sql_column} = {amount} WHERE ID = {C_Login.ID};";
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }

        public void expected_resources()
        {
            cmd.Connection = Model_db.conn;
            cmd.CommandText = $"UPDATE `expected_resources` SET `money`={C_Economy.expected_money},`food`={C_Economy.expected_food},`building_material`={C_Economy.expected_building_material},`textile`={C_Economy.expected_textile},`weapon`={C_Economy.expected_weapon} WHERE ID = {C_Login.ID};";
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Model_db.conn.Close(); }
        }

    }
}
