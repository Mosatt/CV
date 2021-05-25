using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Szakdolgozat_RZD
{
    class M_db_marketf
    {

        MySqlDataAdapter da;
        DataTable dt;
        public static string market_country_name;
        public static int market_country_id;
        public static string market_material;
        public static int market_amount;
        public static int market_get_money;
        public static double currency_value;
        public static double amount_paid;

        public void dgv_market(DataGridView dgv, int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            string sql_dgv = "SELECT ID, country_name as 'Orszagnev', sell_amount as 'Mennyiseg', sell_material as 'Nyersanyag', Round(((SELECT currency_value FROM countrys WHERE ID = country_id)/(SELECT currency_value FROM countrys WHERE ID = " + C_Login.ID + "))*get_money,0) as 'Teljes ar', Round(((SELECT currency_value FROM countrys WHERE ID = country_id)/(SELECT currency_value FROM countrys WHERE ID = " + C_Login.ID + "))*get_money/sell_amount,0) as 'Egysegar' FROM marketplace;";

            dt = new DataTable();
            try
            {
                Model_db.conn.Open();
                da = new MySqlDataAdapter(sql_dgv, Model_db.conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A lekérdezést nem lehet végrahajtani!\nOka:" + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Model_db.conn.Close();
            }
            da.Dispose();
            dt.Dispose();
            dgv.DataSource = dt;
        }

        public void selected_item_loading2()
        {
            string sql = "SELECT currency_value FROM countrys WHERE ID = '" + market_country_id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, Model_db.conn);
            MySqlDataReader reader;
            try
            {
                Model_db.conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    currency_value = Convert.ToInt32(reader.GetString("currency_value"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Model_db.conn.Close();
            }
        }

        public void selected_item_loading(NumericUpDown nud)
        {
            string sql = $"SELECT country_name, country_id, sell_material, sell_amount, get_money FROM marketplace WHERE ID = '{nud.Value}'";
            MySqlCommand cmd = new MySqlCommand(sql, Model_db.conn);
            MySqlDataReader reader;
            try
            {
                Model_db.conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    market_country_name = reader.GetString("country_name");
                    market_country_id = Convert.ToInt32(reader.GetString("country_id"));
                    market_material = reader.GetString("sell_material");
                    market_amount = Convert.ToInt32(reader.GetString("sell_amount"));
                    market_get_money = Convert.ToInt32(reader.GetString("get_money"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Model_db.conn.Close();
            }
        }

        public void delete_item(int market_product, string market_product_column, NumericUpDown nud)
        {
            market_product += market_amount;
            string sql_budget = $"UPDATE budget SET {market_product_column} = {market_product_column} + '{market_amount}' WHERE ID = '{C_Login.ID}';";
            string sql_delete = "DELETE FROM `marketplace` WHERE ID = '" + nud.Value + "';";
            MySqlCommand cmd_sql_budget = new MySqlCommand(sql_budget, Model_db.conn);
            MySqlCommand cmd_delete = new MySqlCommand(sql_delete, Model_db.conn);
            try
            {
                Model_db.conn.Open();
                cmd_sql_budget.ExecuteNonQuery();
                cmd_delete.ExecuteNonQuery();
                MessageBox.Show($"Sikeresen törölted az ajánlatodat!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Model_db.conn.Close();
            }
        }

        public void buy_sql(int market_product, string market_product_column, NumericUpDown nud)
        {
            C_Economy.market_money -= (int)amount_paid;
            market_product += market_amount;
            string sql_update_seller = $"UPDATE budget SET market_money = market_money + '{market_get_money}' WHERE ID = '{market_country_id}';";
            string sql_update_customer = $"UPDATE budget SET market_money = market_money - '{amount_paid}', {market_product_column} = {market_product_column} + '{market_amount}' WHERE ID = '{C_Login.ID}';";
            string sql_delete = $"DELETE FROM `marketplace` WHERE ID = '{nud.Value}';";
            MySqlCommand cmd_update_seller = new MySqlCommand(sql_update_seller, Model_db.conn);
            MySqlCommand cmd_update_customer = new MySqlCommand(sql_update_customer, Model_db.conn);
            MySqlCommand cmd_delete = new MySqlCommand(sql_delete, Model_db.conn);
            try
            {
                Model_db.conn.Open();
                cmd_update_seller.ExecuteNonQuery();
                cmd_update_customer.ExecuteNonQuery();
                cmd_delete.ExecuteNonQuery();
                MessageBox.Show($"Sikeresen vásároltál {market_amount} {market_material}-t {Math.Round(amount_paid, 0)} {C_MainPageForm.currency_name} értékben!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Model_db.conn.Close();
            }
        }

        public void offer_sql(int market_product, string market_product_column, string message, NumericUpDown nud_amount_offer, NumericUpDown nud_price, ComboBox cb_offer)
        {
            market_product -= Convert.ToInt32(nud_amount_offer.Value);
            string sql_update_seller = $"UPDATE budget SET {market_product_column} = {market_product_column} - '{nud_amount_offer.Value}' WHERE ID = '{C_Login.ID}';";
            string sql_offer = "INSERT INTO marketplace (`country_name`, `country_id`, `sell_material`, `sell_amount`, `get_money`) VALUES ('" + C_MainPageForm.country_name + "', '" + C_Login.ID + "', '" + cb_offer.SelectedItem + "', '" + nud_amount_offer.Value + "', '" + (nud_amount_offer.Value * nud_price.Value) + "');";
            MySqlCommand cmd_update_seller = new MySqlCommand(sql_update_seller, Model_db.conn);
            MySqlCommand cmd_offer = new MySqlCommand(sql_offer, Model_db.conn);
            try
            {
                Model_db.conn.Open();
                cmd_update_seller.ExecuteNonQuery();
                cmd_offer.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Model_db.conn.Close();
            }

            MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
