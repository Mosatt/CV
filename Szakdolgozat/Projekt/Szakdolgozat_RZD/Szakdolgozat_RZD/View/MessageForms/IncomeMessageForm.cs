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
    public partial class IncomeMessageForm : Form
    {
        public static int count;
        Model_db M_db = new Model_db();
        DateTime date;

        public IncomeMessageForm()
        {
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            // "ID", "Date", "sender_country", "adress_country", "subject", "text", "read_status"

            lb_sender.Text = DiplomacyForm.list_incoming[2 + (count * 7)];
            lb_subject.Text = DiplomacyForm.list_incoming[4 + (count * 7)];
            lb_date.Text = DiplomacyForm.list_incoming[1 + (count * 7)];
            tb_message.Text = DiplomacyForm.list_incoming[5 + (count * 7)];
            date = Convert.ToDateTime(DiplomacyForm.list_incoming[1 + (count * 7)]);
            read_status();

            bt_answer.Click += (s, e) =>
            {
                NewMessageForm.sender = DiplomacyForm.list_incoming[2 + (count * 7)];
                NewMessageForm.subject = $"RE: {DiplomacyForm.list_incoming[4 + (count * 7)]}";
                NewMessageForm.before_message = $"\n------------------------------------------------------------------------------------------------------------------------" +
                                                $"\n{DiplomacyForm.list_incoming[5 + (count * 7)]}";
                NewMessageForm form = new NewMessageForm();
                form.ShowDialog();
            };

        }

        public void read_status()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Model_db.conn;
            cmd.CommandText = $"UPDATE messages SET Date = '{date:yyyy.MM.dd.HH:mm:ss}', read_status = 1 WHERE ID = {DiplomacyForm.list_incoming[0 + (count * 7)]};";
            try
            {
                Model_db.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Nem sikerült végrehajtani a feladatot!\nOka: " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Model_db.conn.Close(); }
        }

        void color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_message.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_answer.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            tb_message.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_date.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_sender.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_subject.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label3.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_answer.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

        }

    }
}
