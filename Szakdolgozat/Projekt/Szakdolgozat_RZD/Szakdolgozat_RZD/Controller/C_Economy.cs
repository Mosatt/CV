using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    class C_Economy
    {
        Model_db m_db = new Model_db();
        M_db_economyf m_db_ef = new M_db_economyf();

        //raktárkészlet
        public static int storage_money { get; set; }
        public static int storage_food { get; set; }
        public static int storage_building_material { get; set; }
        public static int storage_textile { get; set; }
        public static int storage_weapon { get; set; }
        //költségek
        public static int cost_money { get; set; }
        public static int cost_food { get; set; }
        public static int cost_building_material { get; set; }
        public static int cost_textile { get; set; }
        public static int cost_weapon { get; set; }
        //piaci tevékenység
        public static int market_money { get; set; }
        public static int market_food { get; set; }
        public static int market_building_material { get; set; }
        public static int market_textile { get; set; }
        public static int market_weapon { get; set; }
        
        public static int tax { get; set; } // adó mértéke
        public static int tax_product { get; set; } // adóbevétel pénzben

        //elérhető források => induló raktárkészlet - költségek + piac
        public static int available_money { get; set; }
        public static int available_food { get; set; }
        public static int available_building_material { get; set; }
        public static int available_textile { get; set; }
        public static int available_weapon { get; set; }

        //profit
        public static int money_profit = 0;
        public static int food_profit = 0;
        public static int building_material_profit = 0;
        public static int textile_profit = 0;
        public static int weapon_profit = 0;

        public const int tax_modifier = 63; //egy főre jutó adót befolyásoló változó
        public const int population_food = 4913; //lakosság ételfogyasztás segédszám -> minél kisebb ez a szám, annál nagyobb a fogyasztás
        public const int population_textile = 41853; //lakosság textilfogyasztás segédszám -> minél kisebb ez a szám, annál nagyobb a fogyasztás

        // közszolgáltatások:
        public static int health { get; set; } // közszolgáltatás értékek meghatározása számmal
        public static int education { get; set; }
        public static int public_safety { get; set; }
        public const int health_modifier = 67613612; // módosító, ami segít beállítani egy lakos igényét
        public const int education_modifier = 95227224;
        public const int public_safety_modifier = 47613612;
        public static int health_cost { get; set; } // anyagi ráfordítás
        public static int education_cost { get; set; }
        public static int public_safety_cost { get; set; }

        // fogyasztási adatokhoz:
        public static int food_consumption { get; set; }
        public static int textile_consumption { get; set; }
        public static int consumption_money { get; set; }

        // várható raktárkészlet
        public static int expected_money { get; set; }
        public static int expected_food { get; set; }
        public static int expected_building_material { get; set; }
        public static int expected_textile { get; set; }
        public static int expected_weapon { get; set; }

        public static int sum_cost_money { get; set; } // teljes kiadás (pénz)

        public static double morale{ get; set; }

        public C_Economy() { }

        public C_Economy(List<string> data)
        {
            storage_money = Convert.ToInt32(data[0]);
            storage_food = Convert.ToInt32(data[1]);
            storage_building_material = Convert.ToInt32(data[2]);
            storage_textile = Convert.ToInt32(data[3]);
            storage_weapon = Convert.ToInt32(data[4]);

            cost_money = Convert.ToInt32(data[5]);
            cost_food = Convert.ToInt32(data[6]);
            cost_building_material = Convert.ToInt32(data[7]);
            cost_textile = Convert.ToInt32(data[8]);
            cost_weapon = Convert.ToInt32(data[9]);

            market_money = Convert.ToInt32(data[10]);
            market_food = Convert.ToInt32(data[11]);
            market_building_material = Convert.ToInt32(data[12]);
            market_textile = Convert.ToInt32(data[13]);
            market_weapon = Convert.ToInt32(data[14]);

            // adó mértéke százalékban
            tax = Convert.ToInt32(data[15]);

            //közszolgáltatásokra költött összeg:
            health_cost = Convert.ToInt32(data[16]);
            education_cost = Convert.ToInt32(data[17]);
            public_safety_cost = Convert.ToInt32(data[18]);

            // várható raktárkészlet betöltése adatbázisból:
            expected_resources_download();
        }

        public void expected_resources_download()
        {
            // várható raktárkészlet betöltése adatbázisból:
            m_db.list_upload_horizontal(m_db_ef.list_expected_resources, m_db_ef.expected_query, m_db_ef.list_expected_resources_sql_columns);
            expected_money = Convert.ToInt32(m_db_ef.list_expected_resources[0]);
            expected_food = Convert.ToInt32(m_db_ef.list_expected_resources[1]);
            expected_building_material = Convert.ToInt32(m_db_ef.list_expected_resources[2]);
            expected_textile = Convert.ToInt32(m_db_ef.list_expected_resources[3]);
            expected_weapon = Convert.ToInt32(m_db_ef.list_expected_resources[4]);
        }
        public void expected_resources_refresh()
        {
            expected_money = storage_money + money_profit;
            expected_food = storage_food + food_profit;
            expected_building_material = storage_building_material + building_material_profit;
            expected_textile = storage_textile + textile_profit;
            expected_weapon = storage_weapon + weapon_profit;
        }

        public void expected_resources_upload()
        {
            expected_resources_refresh();
            m_db_ef.expected_resources();
        }

        public void sum_cost_money_calc()
        {
            sum_cost_money = cost_money + health_cost + education_cost + public_safety_cost;
        }

        public void profit_calc()
        {
            // profit kiszámolás
            money_profit = tax_product - sum_cost_money + market_money;
            food_profit = summa_food_product() - cost_food + market_food;
            building_material_profit = summa_building_material_product() - cost_building_material + market_building_material;
            textile_profit = summa_textile_product() - cost_textile + market_textile;
            weapon_profit = summa_weapon_product() - cost_weapon + market_weapon;
        }

        public double morale_calc()
        {
            return morale = ((health + education + public_safety - (tax * 1000)) / 1000);
        }

        public string public_services_string(int service)
        {
            string service_str = "";
            // közszolgáltatás értékek meghatározása stringként
            if (service <= 15000)
            {
                service_str = "Katasztrofális";
            }
            else if (service > 15000 && service <= 19000)
            {
                service_str = "Pocsék";
            }
            else if (service > 19000 && service <= 25000)
            {
                service_str = "Középszerű";
            }
            else if (service > 25000 && service <= 33000)
            {
                service_str = "Megfelelő";
            }
            else if (service > 33000)
            {
                service_str = "Nagyszerű";
            }

            return service_str;
        }

        public void public_services_value_calc()
        {
            // közszolgáltatás értékek meghatározása számmal:
            health = ((health_modifier / C_MainPageForm.population) * health_cost);
            education = ((education_modifier / C_MainPageForm.population) * education_cost);
            public_safety = ((public_safety_modifier / C_MainPageForm.population) * public_safety_cost);
        }

        public void consumptions()
        {
            // lakosság fogyasztási igénye (élelmiszer, textil)
            food_consumption = 0;
            textile_consumption = 0;
            // fogyasztási adatokhoz:
            food_consumption = C_MainPageForm.population / population_food;
            textile_consumption = C_MainPageForm.population / population_textile;
            m_db_ef.data_upload("budget", "cost_food", $"{food_consumption}");
            m_db_ef.data_upload("budget", "cost_textile", $"{textile_consumption}");
        }

        public void tax_products()
        {
            // adó mennyisége pénzben:
            tax_product = (C_MainPageForm.population / tax_modifier / 100) * tax;
        }

        public static void available_resources()
        {
            available_money = storage_money - sum_cost_money + market_money;
            available_food = storage_food - cost_food + market_food;
            available_building_material = storage_building_material - cost_building_material + market_building_material;
            available_textile = storage_textile - cost_textile + market_textile;
            available_weapon = storage_weapon - cost_weapon + market_weapon;
        }

        public int summa_food_product()
        {
            int food_pr = 0;
            food_pr = Convert.ToInt32(C_Constructions.buildings_amount[0]) * Convert.ToInt32(C_Constructions.buildings_product_food[0]) +
                   Convert.ToInt32(C_Constructions.buildings_amount[1]) * Convert.ToInt32(C_Constructions.buildings_product_food[1]) +
                   Convert.ToInt32(C_Constructions.buildings_amount[2]) * Convert.ToInt32(C_Constructions.buildings_product_food[2]);
            if (food_pr > 0) { return food_pr; } else { return 0; }
        }
        public int summa_building_material_product()
        {
            int building_material_pr = 0;
            building_material_pr = Convert.ToInt32(C_Constructions.buildings_amount[3]) * Convert.ToInt32(C_Constructions.buildings_product_building_material[0]) +
                                Convert.ToInt32(C_Constructions.buildings_amount[4]) * Convert.ToInt32(C_Constructions.buildings_product_building_material[1]);
            if (building_material_pr > 0) { return building_material_pr; } else { return 0; }
        }
        
        public int summa_textile_product()
        {
            int textile_pr = 0;
            textile_pr = Convert.ToInt32(C_Constructions.buildings_amount[2]) * Convert.ToInt32(C_Constructions.buildings_product_textile[0]) +
                                Convert.ToInt32(C_Constructions.buildings_amount[6]) * Convert.ToInt32(C_Constructions.buildings_product_textile[1]);
            if (textile_pr > 0) { return textile_pr; } else { return 0; }
        }
        
        public int summa_weapon_product()
        {
            int weapon_pr = 0; 
            weapon_pr = Convert.ToInt32(C_Constructions.buildings_amount[7]) * Convert.ToInt32(C_Constructions.buildings_product_weapon[0]) +
                                Convert.ToInt32(C_Constructions.buildings_amount[8]) * Convert.ToInt32(C_Constructions.buildings_product_weapon[1]);
            if (weapon_pr > 0) { return weapon_pr; } else { return 0; }
        }

        public int mortality()
        {
            int mortality;
            mortality = ((C_MainPageForm.population / 100) * (300 - (health / 1000 + education / 1000 + public_safety / 1000)) * (3 + tax / 2)) / 1000;
            return mortality;
        }

        public int pop_born()
        {
            int born;
            if (((C_MainPageForm.population / 100) + (health + education + public_safety) - (tax * 3056)) < 0)
            {
                born = 0;
            }
            else
            {
                born = ((C_MainPageForm.population / 100) + (health + education + public_safety) - (tax * 3056));
            }
            return born;
        }
    }
}
