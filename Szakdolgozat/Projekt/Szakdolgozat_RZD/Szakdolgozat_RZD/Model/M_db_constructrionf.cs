using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class M_db_constructrionf
    {
        // épületlista comboboxhoz
        public string buildings_names = $"SELECT `building_name` FROM `buildings` WHERE `tech_age` = '{C_MainPageForm.tech_age}';";
        // user épületlistája
        public string list_own_buildings_sql_query = $"SELECT * FROM `users_buildings` WHERE ID = '{C_Login.ID}';";
        // user épületlista árai
        public string list_buildings_prices = $"SELECT * FROM `buildings` WHERE `tech_age` = '{C_MainPageForm.tech_age}';";
        // épületek termelési adatai
        public string list_buildings_product_food = $"SELECT `food_product` FROM `buildings` WHERE tech_age = '{C_MainPageForm.tech_age}' AND `type`LIKE '%food%';";
        public string list_buildings_product_bulding_material = $"SELECT `building_material_product` FROM `buildings` WHERE tech_age = '{C_MainPageForm.tech_age}' AND `type`LIKE '%building_material%';";
        public string list_buildings_product_textile = $"SELECT `textile_product` FROM `buildings` WHERE tech_age = '{C_MainPageForm.tech_age}' AND `type`LIKE '%textile%';";
        public string list_buildings_product_weapon = $"SELECT `weapon_product` FROM `buildings` WHERE tech_age = '{C_MainPageForm.tech_age}' AND `type`LIKE '%weapon%';";

        public List<string> definition_tech_age_buildings_constructions_sql_query_columns()
        {
            // meghatzározza, hogy melyik tech kornak megfelelő listát töltsön be az épületek listázához
            List<string> list = new List<string>();
            switch (C_MainPageForm.tech_age)
            {
                case "Középkor":
                    list = list_buildings_constructions_sql_query_columns_middle_age;
                    break;
                case "Újkor":
                    MessageBox.Show("Még nincs ilyen");
                    break;
            }
            return list;
        }

        public List<string> definition_tech_age_buildings_amount_sql_query_columns()
        {
            // eldönti a függvény, hogy melyik oszlopokat kell beolvasni az adatbázisból (tech kor alapján)
            List<string> list = new List<string>();
            switch (C_MainPageForm.tech_age)
            {
                case "Középkor":
                    list = list_own_buildings_amount_sql_query_columns_middle_age;
                    break;
                case "Újkor":
                    MessageBox.Show("Még nincs ilyen");
                    break;
            }
            return list;
        }


        // tech koronként a listák:
        public List<string> list_own_buildings_amount_sql_query_columns_middle_age = new List<string>()
        {
            "b_Farm", "b_Mill", "b_Pasture", "b_Quarry", "b_Forest_built", "b_Tailor_guild", "b_Little_blacksmith_guild",
            "b_Great_blacksmith_guild", "b_Barrack", "b_Archery_school", "b_Stable", "b_Cannon_foundry", "b_Military_port",
            "b_Watchtower", "b_Fortress"
        };

        public List<string> list_buildings_constructions_sql_query_columns_middle_age = new List<string>()
        {
            "c_Farm", "c_Mill", "c_Pasture", "c_Quarry", "c_Forest", "c_Tailor_guild", "c_Little_blacksmith_guild",
            "c_Great_blacksmith_guild", "c_Barrack", "c_Archery_school", "c_Stable", "c_Cannon_foundry", "c_Military_port",
            "c_Watchtower", "c_Fortress"
        };
    }
}
