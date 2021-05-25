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
    public partial class NewMessageForm : Form
    {

        Model_db M_db = new Model_db();
        M_db_messages m_db_messages = new M_db_messages();
        public static string sender = null;
        public static string subject;
        public static string before_message;

        public NewMessageForm()
        {
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            List<string> country_name_list = new List<string>();
            M_db.list_upload_vertical("SELECT * FROM `countrys`;", country_name_list, "country_name");
            

            if (sender != null)
            {
                cb_country_list.Items.Clear();
                for (int i = 0; i < country_name_list.Count; i++)
                {
                    if (country_name_list[i] == sender)
                    {
                        cb_country_list.Items.Add(sender);
                        cb_country_list.SelectedIndex = 0;
                        break;
                    }
                }
                tb_subject.Text = subject;
                tb_message.Text = $"\n\n{before_message}";
                cb_country_list.Enabled = false;
                sender = subject = before_message = null;
            }
            else
            {
                for (int i = 0; i < country_name_list.Count; i++)
                {
                    cb_country_list.Items.Add(country_name_list[i]);
                }
                cb_country_list.SelectedItem = 0;
            }

            bt_message_send.Click += (s, e) =>
            {
                if (tb_subject.Text.Length > 100 || tb_message.Text.Length > 2000)
                {
                    MessageBox.Show("Tárgynak, vagy üzenetnek túl hosszú szöveget adtál meg!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    if (tb_subject.Text == "" || tb_message.Text == "")
                    {
                        MessageBox.Show("Nem adtál meg címzettet, vagy tárgyat, de lehet hogy lemaradt az üzenet.", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        m_db_messages.message_send(cb_country_list,tb_subject,tb_message);
                        MessageBox.Show("Az üzenet elküldve!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            };

            lb_text_length.Text = $"{tb_message.Text.Length}/2000";

            tb_message.TextChanged += (s, e) =>
            {
                lb_text_length.Text = $"{tb_message.Text.Length}/2000";
            };

            bt_exit.Click += (s, e) =>
            {
                DialogResult dr = MessageBox.Show($"Biztosan ki meg akarod szakítani a levélírást?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    this.Close();
                }
            };
        }

        void color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_message.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            cb_country_list.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_subject.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            tb_message.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            cb_country_list.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            tb_subject.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_text_length.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_message_send.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_exit.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

        }

    }
}
