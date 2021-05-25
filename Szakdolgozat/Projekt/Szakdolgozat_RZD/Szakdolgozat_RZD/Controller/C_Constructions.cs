using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Szakdolgozat_RZD
{

    class C_Constructions
    {
        
        public List<string> building_list = new List<string>();
        public static List<string> buildings_amount = new List<string>();
        public List<string> buildings_constructions = new List<string>();
        public List<string> buildings_prices_money = new List<string>();
        public List<string> buildings_prices_building_material = new List<string>();
        public static List<string> buildings_product_food = new List<string>();
        public static List<string> buildings_product_building_material = new List<string>();
        public static List<string> buildings_product_textile = new List<string>();
        public static List<string> buildings_product_weapon = new List<string>();
        
        Model_db M_db = new Model_db();
        C_Economy c_e = new C_Economy();

        public void construction_start(ComboBox cb, string sql_column)
        {
            if (C_Economy.available_money - Convert.ToInt32(buildings_prices_money[cb.SelectedIndex]) >= 0 && C_Economy.available_building_material - Convert.ToInt32(buildings_prices_building_material[cb.SelectedIndex]) >= 0)
            {
                DialogResult dr = MessageBox.Show($"Biztosan meg akarod építeni a(z) {cb.SelectedItem}-t?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    C_Economy.cost_money += Convert.ToInt32(buildings_prices_money[cb.SelectedIndex]);
                    C_Economy.cost_building_material += Convert.ToInt32(buildings_prices_building_material[cb.SelectedIndex]);
                    M_db.database_update("budget", "cost_money", buildings_prices_money[cb.SelectedIndex]);
                    M_db.database_update("budget", "cost_building_material", buildings_prices_building_material[cb.SelectedIndex]);
                    M_db.database_update("users_buildings", sql_column, "1");
                    c_e.expected_resources_upload();
                    MessageBox.Show("Az építkezés sikeresen megkezdődött!");
                }
            }
            else
            {
                MessageBox.Show("Nincs elég pénzed, vagy építőanyagod az építkezéshez!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void construction_cancel(ComboBox cb, string sql_column)
        {
            if (Convert.ToInt32(buildings_constructions[cb.SelectedIndex]) > 0)
            {
                DialogResult dr = MessageBox.Show($"Biztosan vissza akarod vonni a(z) {cb.SelectedItem} építését?", "Want something else?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    C_Economy.cost_money -= Convert.ToInt32(buildings_prices_money[cb.SelectedIndex]);
                    C_Economy.cost_building_material -= Convert.ToInt32(buildings_prices_building_material[cb.SelectedIndex]);
                    M_db.database_update("budget", "cost_money", $"-{buildings_prices_money[cb.SelectedIndex]}");
                    M_db.database_update("budget", "cost_building_material", $"-{buildings_prices_building_material[cb.SelectedIndex]}");
                    M_db.database_update("users_buildings", sql_column, "-1");
                    c_e.expected_resources_upload();
                    MessageBox.Show("Az építkezés sikeresen visszavonásra került!");
                }
            }
            else { MessageBox.Show("Nincs megkezdett építkezés!","Hibaüzenet",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

    }
}
