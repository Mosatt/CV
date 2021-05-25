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
    public partial class ConstructionsForm : Form
    {

        Model_db M_db = new Model_db();
        C_Constructions c_c = new C_Constructions();
        M_db_constructrionf M_db_cf = new M_db_constructrionf();

        int helper_number;
        int food_restriction;
        int textile_and_weapon_restriction;
        int building_material_restriction;

        public ConstructionsForm()
        {

            InitializeComponent();

            design(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            //panel10.BackColor = Color.FromArgb(50, Color.WhiteSmoke); //opacity
            //ToolTip t = new ToolTip();
            //t.SetToolTip(bt_construction,"tippek helye");

            list_upload();
            dgv_settings();
            labels_upload();
            restriction_labels();
            chart(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            locations();

            

            cb_building.SelectedIndexChanged += (s, e) => 
            {
                lb_building_prices.Text = $"Pénz: {c_c.buildings_prices_money[cb_building.SelectedIndex]}    Építőanyag: {c_c.buildings_prices_building_material[cb_building.SelectedIndex]}";
            };

            cb_building.SelectedIndex = 0;

            bt_constructions.Click += (s, e) =>
            {
                if (C_MainPageForm.tech_age == "Középkor") //vizsgálni kell majd, hogy az építési korlátba belefér-e az új épület.
                {
                    //építési limithez segédletek:
                    // összes élelemtermelő épület: (megépült és építés alatt állók) //-> 0: farm, 1: mill, 2: pasture
                    int food_buildings = Convert.ToInt32(C_Constructions.buildings_amount[0]) + Convert.ToInt32(C_Constructions.buildings_amount[1]) + Convert.ToInt32(C_Constructions.buildings_amount[2]) +
                                        Convert.ToInt32(c_c.buildings_constructions[0]) + Convert.ToInt32(c_c.buildings_constructions[1]) + Convert.ToInt32(c_c.buildings_constructions[2]);
                    // összes építőanyagtermelő épület: (megépült és építés alatt állók) //-> 3: kőbánya, 4: erdő
                    int building_material_buildings = Convert.ToInt32(C_Constructions.buildings_amount[3]) + Convert.ToInt32(C_Constructions.buildings_amount[4]) +
                                                      Convert.ToInt32(c_c.buildings_constructions[3]) + Convert.ToInt32(c_c.buildings_constructions[4]);
                    int textile_and_weapon_buildings = Convert.ToInt32(C_Constructions.buildings_amount[5]) + Convert.ToInt32(C_Constructions.buildings_amount[6]) + Convert.ToInt32(C_Constructions.buildings_amount[7]) +
                                                       Convert.ToInt32(c_c.buildings_constructions[5]) + Convert.ToInt32(c_c.buildings_constructions[6]) + Convert.ToInt32(c_c.buildings_constructions[7]);

                    switch (cb_building.SelectedIndex)
                    {
                        case 0:
                            if (food_buildings < food_restriction)
                            { c_c.construction_start(cb_building, "c_Farm"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 1:
                            if (food_buildings < food_restriction)
                            { c_c.construction_start(cb_building, "c_Mill"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 2:
                            if (food_buildings < food_restriction)
                            { c_c.construction_start(cb_building, "c_Pasture"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 3:
                            if (building_material_buildings < building_material_restriction)
                            { c_c.construction_start(cb_building, "c_Quarry"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 4:
                            if (building_material_buildings < building_material_restriction)
                            { c_c.construction_start(cb_building, "c_Forest"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 5:
                            if (textile_and_weapon_buildings < textile_and_weapon_restriction)
                            { c_c.construction_start(cb_building, "c_Tailor_guild"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 6:
                            if (textile_and_weapon_buildings < textile_and_weapon_restriction)
                            { c_c.construction_start(cb_building, "c_Little_blacksmith_guild"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 7:
                            if (textile_and_weapon_buildings < textile_and_weapon_restriction)
                            { c_c.construction_start(cb_building, "c_Great_blacksmith_guild"); }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 8:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[8]) > 0 && Convert.ToInt32(c_c.buildings_constructions[8]) > 0)
                            { c_c.construction_start(cb_building, "c_Barrack"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 9:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[9]) > 0 && Convert.ToInt32(c_c.buildings_constructions[9]) > 0)
                            { c_c.construction_start(cb_building, "c_Archery_school"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 10:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[10]) > 0 && Convert.ToInt32(c_c.buildings_constructions[10]) > 0)
                            { c_c.construction_start(cb_building, "c_Stable"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 11:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[11]) > 0 && Convert.ToInt32(c_c.buildings_constructions[11]) > 0)
                            { c_c.construction_start(cb_building, "c_Cannon_foundry"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 12:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[12]) > 0 && Convert.ToInt32(c_c.buildings_constructions[12]) > 0 && C_MainPageForm.beach == true)
                            { c_c.construction_start(cb_building, "c_Military_port"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet vagy nem rendelkezel tengerparttal!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 13:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[13]) > 0 && Convert.ToInt32(c_c.buildings_constructions[13]) > 0)
                            { c_c.construction_start(cb_building, "c_Watchtower"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                        case 14:
                            if (Convert.ToInt32(C_Constructions.buildings_amount[14]) > 0 && Convert.ToInt32(c_c.buildings_constructions[14]) > 0)
                            { c_c.construction_start(cb_building, "c_Fortress"); break; }
                            else { MessageBox.Show("Nem lehet megépíteni, mivel elérted a maximális limitet!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); } break;
                    }
                }

                list_upload();
                dgv_settings();
                cb_building.SelectedIndex = 0;
            };

            bt_constructions_cancel.Click += (s, e) =>
            {
                Model_db M_db = new Model_db();
                if (C_MainPageForm.tech_age == "Középkor") //vizsgálni kell majd, hogy az építési korlátba belefér-e az új épület.
                {
                    switch (cb_building.SelectedIndex)
                    {
                        case 0: c_c.construction_cancel(cb_building, "c_Farm"); break;
                        case 1: c_c.construction_cancel(cb_building, "c_Mill"); break;
                        case 2: c_c.construction_cancel(cb_building, "c_Pasture"); break;
                        case 3: c_c.construction_cancel(cb_building, "c_Quarry"); break;
                        case 4: c_c.construction_cancel(cb_building, "c_Forest"); break;
                        case 5: c_c.construction_cancel(cb_building, "c_Tailor_guild"); break;
                        case 6: c_c.construction_cancel(cb_building, "c_Little_blacksmith_guild"); break;
                        case 7: c_c.construction_cancel(cb_building, "c_Great_blacksmith_guild"); break;
                        case 8: c_c.construction_cancel(cb_building, "c_Barrack"); break;
                        case 9: c_c.construction_cancel(cb_building, "c_Archery_school"); break;
                        case 10: c_c.construction_cancel(cb_building, "c_Stable"); break;
                        case 11: c_c.construction_cancel(cb_building, "c_Cannon_foundry"); break;
                        case 12: c_c.construction_cancel(cb_building, "c_Military_port"); break;
                        case 13: c_c.construction_cancel(cb_building, "c_Watchtower"); break;
                        case 14: c_c.construction_cancel(cb_building, "c_Fortress"); break;
                    }
                }
                list_upload();
                dgv_settings();
                cb_building.SelectedIndex = 0;
            };

            bt_menu_1.Click += (s, e) =>
            {
                show_submenu(panel_buildings, panel_1);
                panel_2.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_2.Click += (s, e) =>
            {
                show_submenu(panel_constructions, panel_2);
                panel_1.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_3.Click += (s, e) =>
            {
                show_submenu(panel_production_datas, panel_3);
                panel_1.BackColor = Color.Black;
                panel_2.BackColor = Color.Black;
                panel_4.BackColor = Color.Black;
            };

            bt_menu_4.Click += (s, e) =>
            {
                show_submenu(panel_other_datas, panel_4);
                panel_1.BackColor = Color.Black;
                panel_2.BackColor = Color.Black;
                panel_3.BackColor = Color.Black;
            };

        }

        void locations()
        {
            bt_menu_1.Location = new Point(230, 190);
            bt_menu_2.Location = new Point(356, 190);
            bt_menu_3.Location = new Point(482, 190);
            bt_menu_4.Location = new Point(638, 190);
            panel3.Location = new Point(543, 9);
        }

        #region submenus
        void hide_submenu()
        {
            if (panel_buildings.Visible == true) { panel_buildings.Visible = false; }
            if (panel_constructions.Visible == true) { panel_constructions.Visible = false; }
            if (panel_production_datas.Visible == true) { panel_production_datas.Visible = false; }
            if (panel_other_datas.Visible == true) { panel_other_datas.Visible = false; }
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
            
            bt_menu_1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_2.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_3.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_menu_4.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            bt_menu_1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_3.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_menu_4.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            lb_header.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_tech_age.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //menu_1
            lb_buildings_1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_buildings_2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //menu_2
            bt_constructions_cancel.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_constructions.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            cb_building.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            cb_building.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label13.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_building_prices.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_constructions_cancel.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_constructions.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //menu_3 
            //épületek nevei felülről lefelé sorrendben:
            label14.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); //Farm
            label27.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label26.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label25.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label5.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // Erdő
            label31.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label29.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label30.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // Nagykovács céh
            //nyersanyagok nevei:
            label41.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // élelmiszer
            label44.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label43.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label42.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // építőanyag
            label37.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label40.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // textil
            label39.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // fegyver
            label38.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label32.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // textil

            //termelési értékek:
            lb_info_food_farm.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_food_mill.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_food_pasture.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_building_material_forest.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_building_material_stone_mine.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_textile_tailor_guild.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_weapon_small_guild.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_weapon_great_guild.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_info_textile_pasture.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //menu_4
            //építési korlát:
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label6.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label17.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label16.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label15.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_food_restriction.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_building_material_restriction.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_textile_and_weapon_restriction.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //domborzati adatok:
            label7.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label8.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label9.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label10.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label11.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label12.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            //chart:
            chart_terrain.Titles["Domborzati adatok"].BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            chart_terrain.Titles["Domborzati adatok"].ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            
        }

        public void chart(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            chart_terrain.Series["area"].IsValueShownAsLabel = true;
            chart_terrain.Series["area"].Points.AddXY("Síkság", C_MainPageForm.plain);
            chart_terrain.Series["area"].Points.AddXY("Domság", C_MainPageForm.hill);
            chart_terrain.Series["area"].Points.AddXY("Hegység", C_MainPageForm.mountain);
            chart_terrain.Legends["Legend1"].BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            chart_terrain.Legends["Legend1"].ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
        }

        void dgv_cb_upload()
        {
            cb_building.Items.Clear();
            dgv_own_buildings.Rows.Clear();
            dgv_construction.Rows.Clear();
            for (int i = 0; i < c_c.building_list.Count; i++)
            {
                cb_building.Items.Add(c_c.building_list[i]); //combobox upload
                dgv_own_buildings.Rows.Add(c_c.building_list[i], C_Constructions.buildings_amount[i]); // dgv upload
                dgv_construction.Rows.Add(c_c.building_list[i], c_c.buildings_constructions[i]); //dgv upload
            }
        }

        void dgv_settings()
        {
            dgv_own_buildings.Columns.Clear(); dgv_own_buildings.Rows.Clear();
            dgv_construction.Columns.Clear(); dgv_construction.Rows.Clear();
            dgv_style_2columns(dgv_own_buildings, "Column1", "Column2", "Épület neve", "Mennyiség", Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            dgv_style_2columns(dgv_construction, "Column1", "Column2", "Épület neve", "Építés alatt áll", Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            dgv_cb_upload();

            // ne legyen kijelölhető cella
            dgv_own_buildings.SelectionChanged += (s, e) => { dgv_own_buildings.ClearSelection(); };
            dgv_construction.SelectionChanged += (s, e) => { dgv_construction.ClearSelection(); };
        }

        void list_upload()
        {
            // technológiai kor meghatározás annak érdekében, hogy melyik épületeket töltse be
            List<string> list = new List<string>(); list.Clear(); list = M_db_cf.definition_tech_age_buildings_amount_sql_query_columns();
            List<string> list2 = new List<string>(); list2.Clear(); list2 = M_db_cf.definition_tech_age_buildings_constructions_sql_query_columns();

            c_c.buildings_prices_money.Clear();
            c_c.buildings_prices_building_material.Clear();
            c_c.building_list.Clear();
            C_Constructions.buildings_amount.Clear();
            c_c.buildings_constructions.Clear();

            // listák feltöltése -> épület árak (pénz, építőanyag), comboboxhoz épületlista, meglévő épületek, építés alatt álló épületek 
            M_db.list_upload_vertical(M_db_cf.list_buildings_prices, c_c.buildings_prices_money, "money_price"); 
            M_db.list_upload_vertical(M_db_cf.list_buildings_prices, c_c.buildings_prices_building_material, "building_material_price");
            M_db.list_upload_vertical(M_db_cf.buildings_names, c_c.building_list, "building_name"); 
            M_db.list_upload_horizontal(C_Constructions.buildings_amount, M_db_cf.list_own_buildings_sql_query, list); 
            M_db.list_upload_horizontal(c_c.buildings_constructions, M_db_cf.list_own_buildings_sql_query, list2);

            //label adatok feltöltése listába:
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_food, C_Constructions.buildings_product_food, "food_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_textile, C_Constructions.buildings_product_textile, "textile_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_bulding_material, C_Constructions.buildings_product_building_material, "building_material_product");
            M_db.list_upload_vertical(M_db_cf.list_buildings_product_weapon, C_Constructions.buildings_product_weapon, "weapon_product");

            

        }

        void dgv_style_2columns(DataGridView dgv, string column_name1, string column_name2, string column_title1, string column_title2, int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            //kettő oszlopos dgv stílus beállítás
            dgv.Columns.Add(column_name1, column_title1);
            dgv.Columns.Add(column_name2, column_title2);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.BackgroundColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
        }

        void labels_upload()
        {
            //label megjelenés beállítása listából
            // épületek termelése:
            lb_info_food_farm.Text = C_Constructions.buildings_product_food[0];
            lb_info_food_mill.Text = C_Constructions.buildings_product_food[1];
            lb_info_food_pasture.Text = C_Constructions.buildings_product_food[2];
            lb_info_textile_pasture.Text = C_Constructions.buildings_product_textile[0];
            lb_info_textile_tailor_guild.Text = C_Constructions.buildings_product_textile[1];
            lb_info_building_material_stone_mine.Text = C_Constructions.buildings_product_building_material[0];
            lb_info_building_material_forest.Text = C_Constructions.buildings_product_building_material[1];
            lb_info_weapon_small_guild.Text = C_Constructions.buildings_product_weapon[0];
            lb_info_weapon_great_guild.Text = C_Constructions.buildings_product_weapon[1];
            lb_tech_age.Text = C_MainPageForm.tech_age;

            //domborzati labelek feltöltése:
            int area = C_MainPageForm.plain + C_MainPageForm.hill + C_MainPageForm.mountain;
            label10.Text = $"{Math.Round(((double)C_MainPageForm.plain / area) * 100,2)} %";
            label11.Text = $"{Math.Round(((double)C_MainPageForm.hill / area) * 100, 2)} %";
            label12.Text = $"{Math.Round(((double)C_MainPageForm.mountain / area) * 100, 2)} %";

        }

        void restriction_labels()
        {

            //építési limit kiszámítása
            helper_number = C_MainPageForm.area - C_MainPageForm.mountain;
            food_restriction = (helper_number / 100) - ((C_MainPageForm.plain / 150) + (C_MainPageForm.hill / 130));
            textile_and_weapon_restriction = (helper_number / 100) - ((C_MainPageForm.plain + C_MainPageForm.hill) / 115);
            building_material_restriction = C_MainPageForm.mountain / 170;
            // építési limit labelek:
            if (C_MainPageForm.tech_age == "Középkor")
            {
                label17.Text = "Farm, Malom, Legelő:";
                label16.Text = "Szabó céh,\nKis/nagy kovács céh:";
                label15.Text = "Erdő, kőbánya:";
            }
            lb_food_restriction.Text = $"{food_restriction} db.";
            lb_building_material_restriction.Text = $"{building_material_restriction} db.";
            lb_textile_and_weapon_restriction.Text = $"{textile_and_weapon_restriction} db.";
        }
    }
}
