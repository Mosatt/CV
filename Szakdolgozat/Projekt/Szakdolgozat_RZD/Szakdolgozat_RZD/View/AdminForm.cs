using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    public partial class AdminForm : Form
    {

        M_db_adminf m_db_adminf = new M_db_adminf();
        M_db_economyf m_db_ef = new M_db_economyf();
        Model_db m_db = new Model_db();


        public AdminForm()
        {
            InitializeComponent();
            m_db_adminf.combobox_fill(cb_countrys);

            this.FormClosed += (s, e) => { Application.Exit(); };

            bt_test_country.Click += (s, e) => { MainForm mf = new MainForm(); mf.Show(); mf.mainpageToolStripMenuItem_Click(null, null); this.Hide(); };

            bt_user_reg.Click += (s, e) =>
            {
                if (tb_country_name.Text != string.Empty && tb_user_password.Text != string.Empty &&
                    tb_population.Text != string.Empty && tb_form_of_government.Text != string.Empty && tb_tech_age.Text != string.Empty && tb_currency_name.Text != string.Empty &&
                    tb_currency_value.Text != string.Empty && tb_plain.Text != string.Empty && tb_hill.Text != string.Empty && tb_mountain.Text != string.Empty &&
                    tb_beach.Text != string.Empty && tb_sunshine_hours_class.Text != string.Empty)
                {
                    DialogResult dr = MessageBox.Show($"Szeretnéd regisztrálni az alábbi felhasználói fiókot?\nOrszág: {tb_country_name.Text}\nFelhasználónév: {tb_country_name.Text}\nJelszó: {tb_user_password.Text}", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        m_db_adminf.reg_user_table(tb_username, Encript(tb_user_password.Text).GetHashCode());
                        m_db_adminf.reg_country_datas(tb_country_name, tb_form_of_government, tb_tech_age, tb_plain, tb_hill, tb_mountain, tb_sunshine_hours_class, tb_population, tb_beach, tb_currency_name, tb_currency_value);
                        MessageBox.Show("Sikeres regisztráció!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nem jött létre a regisztráció!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nem adtál meg nevet, vagy jelszót!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            };

            string Encript(string value)
            {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    UTF8Encoding utf8 = new UTF8Encoding();
                    byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                    return Convert.ToBase64String(data);
                }
            }

            bt_round_change.Click += (s, e) =>
            {
                // várható nyersanyagok beolvasása, melyek a storage-be lesznek átírva
                m_db_adminf.expected_resources_download(cb_countrys);
                m_db_adminf.round_change(cb_countrys);
                listBox_round_change.Items.Add(cb_countrys.SelectedItem);
            };


        }
    }
}
