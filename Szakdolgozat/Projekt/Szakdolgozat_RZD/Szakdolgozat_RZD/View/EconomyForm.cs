using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    public partial class EconomyForm : Form
    {

        C_Economy c_e = new C_Economy();
        Model_db M_db = new Model_db();
        M_db_constructrionf M_db_cf = new M_db_constructrionf();
        M_db_economyf M_db_ef = new M_db_economyf();

        
        //double morale;

        public EconomyForm()
        {
            InitializeComponent();

            //panel_economy.Location = new Point(10, 77);
            design(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            c_e.consumptions(); // lakosság fogyasztási igénye (élelmiszer, textil)
            list_upload();
            all_labels_update();

            bt_tax_setting.Click += (s, e) =>
            {
                C_Economy.tax = Convert.ToInt32(nud_tax_setting.Value);
                M_db_ef.data_upload("budget", "tax", $"{C_Economy.tax}");
                MessageBox.Show("Az új adósáv beállítva!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //c_e.expected_resources_upload();
                all_labels_update();
            };

            bt_currency_increase.Click += (s, e) =>
            {
                if (nud_currency_amount_increase.Value > 0)
                {
                    currency_calc(nud_currency_amount_increase);
                    //c_e.expected_resources_upload();
                    all_labels_update();
                }
                else
                {
                    MessageBox.Show("Nem állítottad be a kívánt értéket!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            };

            bt_currency_decrease.Click += (s,e) =>
            {
                if (nud_currency_amount_decrease.Value > 0)
                {
                    currency_calc(nud_currency_amount_decrease);
                    //c_e.expected_resources_upload();
                    all_labels_update();
                }
                else
                {
                    MessageBox.Show("Nem állítottad be a kívánt értéket!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            bt_public_services.Click += (s, e) =>
            {
                int public_service_limit = C_MainPageForm.population / 450; // segít korlátozni a maximálisan elkölthető támogatás összegét
                // beállított érték átadása változónak:
                C_Economy.health_cost = Convert.ToInt32(nud_health.Value);
                C_Economy.education_cost = Convert.ToInt32(nud_education.Value);
                C_Economy.public_safety_cost = Convert.ToInt32(nud_public_safety.Value);
                if (nud_health.Value + nud_education.Value + nud_public_safety.Value <= public_service_limit )
                {
                    // változó értékének feltöltése adatbázisba:
                    M_db_ef.data_upload("budget", "health_cost", $"{C_Economy.health_cost}");
                    M_db_ef.data_upload("budget", "education_cost", $"{C_Economy.education_cost}");
                    M_db_ef.data_upload("budget", "public_safety_cost", $"{C_Economy.public_safety_cost}");
                    MessageBox.Show("Az új támogatások beállítva!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Nem növelheted a támogatás mértékét, ha a morál eléri a 100%-ot, illetve nem lépheted túl a(z) '{public_service_limit}'  támogatási összeget!\nA lakosság méretének függvényében változik a támogatás maximális összege!");
                }
                
                all_labels_update();
                services_labels_nud();
            };

            bt_menu_1.Click += (s, e) =>
            {
                show_submenu(panel_economy_summary, panel_1);
                panel_2.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_2.Click += (s, e) =>
            {
                show_submenu(panel_pop, panel_2);
                panel_1.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_3.Click += (s, e) =>
            {
                show_submenu(panel_tax_monetary_politics, panel_3);
                panel_1.BackColor = Color.Black;
                panel_2.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_4.Click += (s, e) =>
            {
                show_submenu(panel_public_safety, panel_4);
                panel_1.BackColor = Color.Black;
                panel_2.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
            };

        }

        #region submenus
        void hide_submenu()
        {
            if (panel_economy_summary.Visible == true) { panel_economy_summary.Visible = false; }
            if (panel_pop.Visible == true) { panel_pop.Visible = false; }
            if (panel_tax_monetary_politics.Visible == true) { panel_tax_monetary_politics.Visible = false; }
            if (panel_public_safety.Visible == true) { panel_public_safety.Visible = false; }
        }

        void show_submenu(Panel submenu, Panel panel_slide)
        {
            if (submenu.Visible == false)
            {
                hide_submenu();
                submenu.Visible = true;
                panel_slide.BackColor = Color.White;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion

        void design(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_header.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            bt_menu_1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_2.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_3.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_4.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            bt_menu_1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_3.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_4.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // panel pop: //
            // bal oldal:
            label21.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label16.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label24.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label33.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            //
            lb_population_total.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_born.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_mortality.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_popchange.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            // chart:
            chart_pop.Titles["Demografiai adatok"].BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            chart_pop.Titles["Demografiai adatok"].ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // panel tax and monetary politics: //
            // adózás:
            label13.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label14.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label18.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label23.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            //
            lb_tax_setting.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_tax_pr.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_tax_setting.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_tax_setting.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            //
            bt_tax_setting.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_tax_setting.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            // monetárls politika:
            label43.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label17.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label27.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_currency_name.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_currency_value.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            //
            label35.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // csík
            // pénzmennyiségi célok:
            label12.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label26.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_currency_amount_increase.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_currency_amount_increase.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_currency_amount_decrease.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_currency_amount_decrease.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_currency_increase.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_currency_increase.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_currency_decrease.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_currency_decrease.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            // pnael public safety: //
            label6.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label11.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label22.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label15.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label10.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_health.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_education.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_public_safety.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            // nud:
            nud_health.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_health.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_education.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_education.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_public_safety.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_public_safety.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            // button:
            bt_public_services.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_public_services.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            // csík:
            label3.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            // morál:
            label2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label39.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_morale.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

        }

        void list_upload()
        {
            // meglévő épületek betöltése:
            List<string> list = new List<string>(); list = M_db_cf.definition_tech_age_buildings_amount_sql_query_columns();
            M_db.list_upload_horizontal(C_Constructions.buildings_amount, M_db_cf.list_own_buildings_sql_query, list);
            // termelési adatok betöltése:
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_food, C_Constructions.buildings_product_food, "food_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_textile, C_Constructions.buildings_product_textile, "textile_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_bulding_material, C_Constructions.buildings_product_building_material, "building_material_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_weapon, C_Constructions.buildings_product_weapon, "weapon_product");


        }

        void currency_calc(NumericUpDown nud)
        {
            if ((C_MainPageForm.currency_value - (Convert.ToInt32(nud.Value) / 200)) > 50 && nud.Value > 0)
            {
                int old_curr_value = C_MainPageForm.currency_value;
                if (nud == nud_currency_amount_increase)
                {
                    C_MainPageForm.currency_value = C_MainPageForm.currency_value - (Convert.ToInt32(nud.Value) / 450);
                    C_Economy.storage_money += Convert.ToInt32(nud.Value);
                    M_db.database_update("budget", "storage_money", $"{nud.Value}");
                    MessageBox.Show($"Sikeresen forgalomba helyeztél {nud.Value} {C_MainPageForm.currency_name}-t!\nA {C_MainPageForm.currency_name} {old_curr_value} értékről {C_MainPageForm.currency_value} értékre változott.");
                }
                else
                {
                    C_MainPageForm.currency_value = C_MainPageForm.currency_value + (Convert.ToInt32(nud.Value) / 450);
                    C_Economy.storage_money -= Convert.ToInt32(nud.Value);
                    M_db.database_update("budget", "storage_money", $"-{nud.Value}");
                    MessageBox.Show($"Sikeresen kivontál a forgalomból {nud.Value} {C_MainPageForm.currency_name}-t!\nA {C_MainPageForm.currency_name} {old_curr_value} értékről {C_MainPageForm.currency_value} értékre változott.");
                }
                M_db_ef.data_upload("countrys", "currency_value", $"{C_MainPageForm.currency_value}");
            }
            else
            {
                MessageBox.Show($"Az országod fizetőeszközének ({C_MainPageForm.currency_name}) értéke nem lehet 50-nél kisebb!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            nud.Value = 0;
        }

        void all_labels_update()
        {
            
            tax_datas();
            currency_labels();
            services_labels_nud();

            morale_label();
            population_labels();
            chart_pop_datas(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            economic_storage_labels();
            economic_product_labels();
            economic_cost_labels();
            economic_market_labels();
            economic_profit_labels();
            c_e.expected_resources_upload();
            economic_exstor_labels();
            economic_available_labels();
        }

        void services_labels_nud()
        {
            // a közszolgáltatások színvonalának megjelenítése:
            lb_health.Text = c_e.public_services_string(C_Economy.health);
            lb_education.Text = c_e.public_services_string(C_Economy.education);
            lb_public_safety.Text = c_e.public_services_string(C_Economy.public_safety);
            nud_health.Value = C_Economy.health_cost;
            nud_education.Value = C_Economy.education_cost;
            nud_public_safety.Value = C_Economy.public_safety_cost;
        }

        void currency_labels()
        {
            // pénznem neve és értéke
            lb_currency_name.Text = C_MainPageForm.currency_name;
            lb_currency_value.Text = string.Format($"{C_MainPageForm.currency_value:N0}");
        }

        void tax_datas()
        {
            // adó
            c_e.tax_products();
            lb_tax_pr.Text = $"{C_Economy.tax_product:N0}";
            lb_tax_setting.Text = $"{C_Economy.tax} %";
            nud_tax_setting.Value = C_Economy.tax;
        }

        

        void morale_label()
        {
            c_e.morale_calc();
            if (C_Economy.morale >= 100)
            {
                lb_morale.Text = "100 %";
            }
            else
            {
                if (C_Economy.morale < 0)
                {
                    lb_morale.Text = "0 %";
                }
                else
                {
                    lb_morale.Text = C_Economy.morale.ToString() + " %";
                }
            }
        }
        
        void chart_pop_datas(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            chart_pop.Series["population"].IsValueShownAsLabel = true;
            foreach (var series in chart_pop.Series)
            {
                series.Points.Clear();
            }
            chart_pop.Series["population"].Points.AddXY("Születés", c_e.pop_born());
            chart_pop.Series["population"].Points.AddXY("Halálozás", c_e.mortality());
            chart_pop.Legends["Legend1"].BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            chart_pop.Legends["Legend1"].ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
        }

        void population_labels()
        {
            c_e.public_services_value_calc();// közszolgáltatás értékek meghatározása számmal -> szükséges az állandóan frissülő populációs adatokhoz is.
            C_MainPageForm.population_change = c_e.pop_born() - c_e.mortality();
            lb_population_total.Text = string.Format($"{C_MainPageForm.population:N0} Fő");
            lb_popchange.Text = string.Format($"{C_MainPageForm.population_change:N0} Fő");
            lb_mortality.Text = string.Format($"{c_e.mortality():N0} Fő");
            lb_born.Text = string.Format($"{c_e.pop_born():N0} Fő");
            M_db_ef.data_upload("countrys", "population_change", $"{C_MainPageForm.population_change}");
        }

        void economic_product_labels()
        {
            // termelés:
            lb_product_money.Text = string.Format($"{C_Economy.tax_product:N0}");
            lb_product_food.Text = string.Format($"{c_e.summa_food_product():N0}");
            lb_product_building_material.Text = string.Format($"{c_e.summa_building_material_product():N0}");
            lb_product_textile.Text = string.Format($"{c_e.summa_textile_product():N0}");
            lb_product_weapon.Text = string.Format($"{c_e.summa_weapon_product():N0}");
        }

        void economic_storage_labels()
        {
            // induló raktárkészlet oszlop:
            lb_storage_money.Text = string.Format($"{C_Economy.storage_money:N0}");
            lb_storage_food.Text = string.Format($"{C_Economy.storage_food:N0}");
            lb_storage_bulding_material.Text = string.Format($"{C_Economy.storage_building_material:N0}");
            lb_storage_textile.Text = string.Format($"{C_Economy.storage_textile:N0}");
            lb_storage_weapon.Text = string.Format($"{C_Economy.storage_weapon:N0}");
        }

        void economic_cost_labels()
        {
            c_e.sum_cost_money_calc();

            // költségek:
            lb_cost_money.Text = string.Format($"{C_Economy.sum_cost_money:N0}");
            lb_cost_food.Text = string.Format($"{C_Economy.cost_food:N0}");
            lb_cost_building_material.Text = string.Format($"{C_Economy.cost_building_material:N0}");
            lb_cost_textile.Text = string.Format($"{C_Economy.cost_textile:N0}");
            lb_cost_weapon.Text = string.Format($"{C_Economy.cost_weapon:N0}");
        }

        void economic_market_labels()
        {
            // piac:
            lb_market_money.Text = string.Format($"{C_Economy.market_money:N0}");
            lb_market_food.Text = string.Format($"{C_Economy.market_food:N0}");
            lb_market_building_material.Text = string.Format($"{C_Economy.market_building_material:N0}");
            lb_market_textile.Text = string.Format($"{C_Economy.market_textile}");
            lb_market_weapon.Text = string.Format($"{C_Economy.market_weapon:N0}");
        }

        void economic_profit_labels()
        {
            c_e.profit_calc();

            // kiíratás
            lb_profit_money.Text = string.Format($"{C_Economy.money_profit:N0}");
            lb_profit_food.Text = string.Format($"{C_Economy.food_profit:N0}");
            lb_profit_building_material.Text = string.Format($"{C_Economy.building_material_profit:N0}");
            lb_profit_textile.Text = string.Format($"{C_Economy.textile_profit:N0}");
            lb_profit_weapon.Text = string.Format($"{C_Economy.weapon_profit:N0}");
        }

        void economic_exstor_labels()
        {
            c_e.expected_resources_refresh();
            lb_exstor_money.Text = string.Format($"{C_Economy.expected_money:N0}");
            lb_exstor_food.Text = string.Format($"{C_Economy.expected_food:N0}");
            lb_exstor_building_material.Text = string.Format($"{C_Economy.expected_building_material:N0}");
            lb_exstor_textile.Text = string.Format($"{C_Economy.expected_textile:N0}");
            lb_exstor_weapon.Text = string.Format($"{C_Economy.expected_weapon:N0}");
            
        }

        void economic_available_labels()
        {
            c_e.sum_cost_money_calc();
            lb_available_money.Text = string.Format($"{C_Economy.storage_money - C_Economy.sum_cost_money + C_Economy.market_money:N0}");
            lb_available_food.Text = string.Format($"{C_Economy.storage_food - C_Economy.cost_food + C_Economy.market_food:N0}");
            lb_available_building_material.Text = string.Format($"{C_Economy.storage_building_material - C_Economy.cost_building_material + C_Economy.market_building_material:N0}");
            lb_available_textile.Text = string.Format($"{C_Economy.storage_textile - C_Economy.cost_textile + C_Economy.market_textile:N0}");
            lb_available_weapon.Text = string.Format($"{C_Economy.storage_weapon - C_Economy.cost_weapon + C_Economy.market_weapon:N0}");
        }


    }
}
