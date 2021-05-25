using MySql.Data.MySqlClient;
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
    public partial class MarketForm : Form
    {
        C_Economy c_e = new C_Economy();
        M_db_marketf m_db_mf = new M_db_marketf();
        

        public MarketForm()
        {
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            dgv_style(dgv_marketplace, Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            m_db_mf.dgv_market(dgv_marketplace, Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            cb_offer.SelectedIndex = 0;

            this.Load += (s, e) =>
            {
                dgv_marketplace.ClearSelection();
            };

            bt_offer.Click += (s, e) =>
            {
                offer();
                m_db_mf.dgv_market(dgv_marketplace, Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
                c_e.expected_resources_upload();
                dgv_marketplace.ClearSelection();
            };

            bt_accept.Click += (s, e) =>
            {
                if (nud_market.Value == 0)
                {
                    MessageBox.Show("Válassz az ajánlatok közül!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    m_db_mf.selected_item_loading(nud_market);
                    m_db_mf.selected_item_loading2();
                    M_db_marketf.amount_paid = M_db_marketf.currency_value / C_MainPageForm.currency_value * M_db_marketf.market_get_money;
                    buy();
                    m_db_mf.dgv_market(dgv_marketplace, Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
                    c_e.expected_resources_upload();
                }
                dgv_marketplace.ClearSelection();
            };

            bt_delete.Click += (s, e) =>
            {
                m_db_mf.selected_item_loading(nud_delete);
                delete(nud_delete);
                m_db_mf.dgv_market(dgv_marketplace, Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
                c_e.expected_resources_upload();
                dgv_marketplace.ClearSelection();
            };

        }

        void color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_accept.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_delete.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_offer.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            cb_offer.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_amount_offer.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_delete.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_market.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            nud_price.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            lb_header.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label4.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label5.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label15.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label7.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label16.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label8.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label18.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label9.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label13.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_accept.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_delete.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_offer.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            cb_offer.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_amount_offer.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_delete.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_market.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            nud_price.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

        }

        void dgv_style(DataGridView dgv, int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.BackgroundColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            dgv.ClearSelection();
        }

        void offer()
        {
            string message = $"Sikeresen eladólistára tettél {nud_amount_offer.Value} {cb_offer.SelectedItem}-t {nud_amount_offer.Value * nud_price.Value} {C_MainPageForm.currency_name} értékben!";
            switch (cb_offer.SelectedItem)
            {
                case "Élelmiszer":
                    if (C_Economy.available_food >= nud_amount_offer.Value && nud_amount_offer.Value > 0 && nud_price.Value > 0)
                    {
                        m_db_mf.offer_sql(C_Economy.market_food, "market_food", message, nud_amount_offer, nud_price, cb_offer);
                    }
                    else
                    {
                        MessageBox.Show("Nincs ennyi nyersanyagod, vagy nem állítottál be árat, mennyiséget!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "Építoanyag":
                    if (C_Economy.available_building_material >= nud_amount_offer.Value && nud_amount_offer.Value > 0 && nud_price.Value > 0)
                    {
                        m_db_mf.offer_sql(C_Economy.market_building_material, "market_building_material", message, nud_amount_offer, nud_price, cb_offer);
                    }
                    else
                    {
                        MessageBox.Show("Nincs ennyi nyersanyagod, vagy nem állítottál be árat, mennyiséget!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "Textil":
                    if (C_Economy.available_textile >= nud_amount_offer.Value && nud_amount_offer.Value > 0 && nud_price.Value > 0)
                    {
                        m_db_mf.offer_sql(C_Economy.market_textile, "market_textile", message, nud_amount_offer, nud_price, cb_offer);
                    }
                    else
                    {
                        MessageBox.Show("Nincs ennyi nyersanyagod, vagy nem állítottál be árat, mennyiséget!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "Fegyver":
                    if (C_Economy.available_weapon >= nud_amount_offer.Value && nud_amount_offer.Value > 0 && nud_price.Value > 0)
                    {
                        m_db_mf.offer_sql(C_Economy.market_weapon, "market_weapon", message, nud_amount_offer, nud_price, cb_offer);
                    }
                    else
                    {
                        MessageBox.Show("Nincs ennyi nyersanyagod, vagy nem állítottál be árat, mennyiséget!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        

        void buy()
        {
            if ((C_Economy.sum_cost_money + M_db_marketf.amount_paid) < C_Economy.available_money)
            {
                switch (M_db_marketf.market_material)
                {
                    case "Élelmiszer": m_db_mf.buy_sql(C_Economy.market_food, "market_food", nud_market); break;
                    case "Építoanyag": m_db_mf.buy_sql(C_Economy.market_building_material, "market_building_material", nud_market); break;
                    case "Textil": m_db_mf.buy_sql(C_Economy.market_textile, "market_textile", nud_market); break;
                    case "Fegyver": m_db_mf.buy_sql(C_Economy.market_weapon, "market_weapon", nud_market); break;
                }
            }
        }

        void delete(NumericUpDown nud)
        {
            if (M_db_marketf.market_country_id == C_Login.ID)
            {
                switch (M_db_marketf.market_material)
                {
                    case "Élelmiszer": m_db_mf.delete_item(C_Economy.market_food, "market_food", nud); break;
                    case "Építoanyag": m_db_mf.delete_item(C_Economy.market_building_material, "market_building_material", nud); break;
                    case "Textil": m_db_mf.delete_item(C_Economy.market_textile, "market_textile", nud); break;
                    case "Fegyver": m_db_mf.delete_item(C_Economy.market_weapon, "market_weapon", nud); break;
                }
            }
            else
            {
                MessageBox.Show("Csak a saját ajánlatodat tudod törölni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
