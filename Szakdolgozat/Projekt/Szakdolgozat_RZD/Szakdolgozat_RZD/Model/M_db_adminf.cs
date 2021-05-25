using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class M_db_adminf
    {

        Model_db m_db = new Model_db();
        M_db_economyf m_db_ef = new M_db_economyf();

        MySqlCommand cmd = new MySqlCommand();
        MySqlCommand cmd2 = new MySqlCommand();
        MySqlCommand cmd3 = new MySqlCommand();
        MySqlCommand cmd4 = new MySqlCommand();
        MySqlCommand cmd5 = new MySqlCommand();

        

        public void combobox_fill(ComboBox cb)
        {
            string sql_country_names = $"SELECT country_name FROM countrys";
            List<string> list_country_names = new List<string>();
            m_db.list_upload_vertical(sql_country_names,list_country_names, "country_name");
            for (int i = 0; i < list_country_names.Count; i++)
            {
                cb.Items.Add(list_country_names[i]);
            }
        }

        public void reg_user_table(TextBox tb_username, int password)
        {
            cmd.Connection = Model_db.conn;
            cmd.CommandText = $"INSERT INTO `users`(`username`, `password`, `status`) VALUES ('{tb_username.Text}', '{password}', 'user');"; ;
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }
        
        public void reg_country_datas(TextBox tb_country_name, TextBox tb_form_of_government, TextBox tb_tech_age, TextBox tb_plain, TextBox tb_hill, TextBox tb_mountain,
                                    TextBox tb_sunshine_hours_class, TextBox tb_population, TextBox tb_beach, TextBox tb_currency_name, TextBox tb_currency_value)
        {
            cmd.Connection = cmd2.Connection = cmd3.Connection = cmd4.Connection = Model_db.conn;
            //budget tábla
            cmd2.CommandText = $"INSERT INTO `budget`(`storage_money`, `storage_food`, `storage_building_material`, `storage_textile`, `storage_weapon`, `cost_money`, `cost_food`, `cost_building_material`, `cost_textile`, `cost_weapon`, `market_money`, `market_food`, `market_building_material`, `market_textile`, `market_weapon`, `tax`, `health_cost`, `education_cost`, `public_safety_cost`) " +
                                $"VALUES (10000, 100, 100, 100, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 300, 300, 300);";
            //countrys tábla
            cmd.CommandText = $"INSERT INTO `countrys`(`country_name`, `form_of_government`, `tech_age`, `plain`, `hill`, `mountain`, `sunshine_hours_class`, `population`, `population_change`, `beach`, `currency_name`, `currency_value`) " +
                $"VALUES ('{tb_country_name.Text}','{tb_form_of_government.Text}','{tb_tech_age.Text}','{tb_plain.Text}','{tb_hill.Text}','{tb_mountain.Text}','{tb_sunshine_hours_class.Text}','{tb_population.Text}',0,'{tb_beach.Text}','{tb_currency_name.Text}','{tb_currency_value.Text}');";
            //users_buildings tábla
            cmd3.CommandText = $"INSERT INTO `users_buildings`(`b_Farm`, `b_Mill`, `b_Pasture`, `b_Quarry`, `b_Forest_built`, `b_Tailor_guild`, `b_Little_blacksmith_guild`, `b_Great_blacksmith_guild`, `b_Barrack`, `b_Archery_school`, `b_Stable`, `b_Cannon_foundry`, `b_Military_port`, `b_Watchtower`, `b_Fortress`," +
                                $" `c_Farm`, `c_Mill`, `c_Pasture`, `c_Quarry`, `c_Forest`, `c_Tailor_guild`, `c_Little_blacksmith_guild`, `c_Great_blacksmith_guild`, `c_Barrack`, `c_Archery_school`, `c_Stable`, `c_Cannon_foundry`, `c_Military_port`, `c_Watchtower`, `c_Fortress`) " +
                                $"VALUES (1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);";
            cmd4.CommandText = $"INSERT INTO `expected_resources`(`money`, `food`, `building_material`, `textile`, `weapon`) VALUES (0,0,0,0,0)";
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }
        /*
         tb_population.Text != string.Empty && tb_form_of_government.Text != string.Empty && tb_tech_age.Text != string.Empty && tb_currency_name.Text != string.Empty &&
                    tb_currency_value.Text != string.Empty && tb_plain.Text != string.Empty && tb_hill.Text != string.Empty && tb_mountain.Text != string.Empty &&
                    tb_beach.Text != string.Empty && tb_sunshine.Text != string.Empty
        */

        public void expected_resources_download(ComboBox cb_countrys)
        {
            // várható nyersanyagok beolvasása, melyek a storage-be lesznek átírva
            string sql = $"SELECT * FROM expected_resources WHERE ID = {cb_countrys.SelectedIndex + 1}";
            m_db.list_upload_horizontal(m_db_ef.list_expected_resources, sql, m_db_ef.list_expected_resources_sql_columns);
            C_Economy.expected_money = Convert.ToInt32(m_db_ef.list_expected_resources[0]);
            C_Economy.expected_food = Convert.ToInt32(m_db_ef.list_expected_resources[1]);
            C_Economy.expected_building_material = Convert.ToInt32(m_db_ef.list_expected_resources[2]);
            C_Economy.expected_textile = Convert.ToInt32(m_db_ef.list_expected_resources[3]);
            C_Economy.expected_weapon = Convert.ToInt32(m_db_ef.list_expected_resources[4]);
        }

        public void round_change(ComboBox cb_countrys)
        {
            cmd.Connection = cmd2.Connection = cmd3.Connection = cmd4.Connection = cmd5.Connection = Model_db.conn;
            cmd.CommandText = $"UPDATE `budget` SET `storage_money`={C_Economy.expected_money},`storage_food`={C_Economy.expected_food},`storage_building_material`={C_Economy.expected_building_material},`storage_textile`={C_Economy.expected_textile},`storage_weapon`={C_Economy.expected_weapon}," +
                                                    $"`cost_money`=0,`cost_food`=0,`cost_building_material`=0,`cost_textile`=0,`cost_weapon`=0," +
                                                    $"`market_money`=0,`market_food`=0,`market_building_material`=0,`market_textile`=0,`market_weapon`=0" +
                                                    $" WHERE ID = {cb_countrys.SelectedIndex + 1};";
            cmd2.CommandText = $"UPDATE `expected_resources` SET `money`=0,`food`=0,`building_material`=0,`textile`=0,`weapon`=0 WHERE ID = {cb_countrys.SelectedIndex + 1};";
            cmd3.CommandText = $"UPDATE `users_buildings` SET `b_Farm`= b_Farm + c_Farm,`b_Mill`= b_Mill + c_Mill,`b_Pasture`= b_Pasture + c_Pasture,`b_Quarry`= b_Quarry + c_Quarry,`b_Forest_built`= b_Forest_built + c_Forest,`b_Tailor_guild`= b_Tailor_guild + c_Tailor_guild," +
                                                             $"`b_Little_blacksmith_guild`= b_Little_blacksmith_guild + c_Little_blacksmith_guild,`b_Great_blacksmith_guild`= b_Great_blacksmith_guild + c_Great_blacksmith_guild,`b_Barrack`= b_Barrack + c_Barrack," +
                                                             $"`b_Archery_school`= b_Archery_school + c_Archery_school,`b_Stable`= b_Stable + c_Stable,`b_Cannon_foundry`= b_Cannon_foundry + c_Cannon_foundry,`b_Military_port`= b_Military_port +c_Military_port ,`b_Watchtower`= b_Watchtower + c_Watchtower," +
                                                             $"`b_Fortress`= b_Fortress + c_Fortress  WHERE ID = {cb_countrys.SelectedIndex + 1};";
            cmd4.CommandText = $"UPDATE `users_buildings` SET `c_Farm`=0,`c_Mill`=0,`c_Pasture`=0,`c_Quarry`=0,`c_Forest`=0,`c_Tailor_guild`=0,`c_Little_blacksmith_guild`=0,`c_Great_blacksmith_guild`=0,`c_Barrack`=0,`c_Archery_school`=0,`c_Stable`=0," +
                                                    $"`c_Cannon_foundry`=0,`c_Military_port`=0,`c_Watchtower`=0,`c_Fortress`=0 WHERE ID = {cb_countrys.SelectedIndex + 1};";
            cmd5.CommandText = $"UPDATE `countrys` SET `population`= population + population_change WHERE ID = {cb_countrys.SelectedIndex + 1};";
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                MessageBox.Show($"A körváltás sikeresen lezajlott a következő nemzet számára:\n{cb_countrys.Text}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }

    }
}
