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
    public partial class DiplomacyForm : Form
    {

        Model_db M_db = new Model_db();
        public static List<string> list_incoming = new List<string>();
        public static List<string> list_sent = new List<string>();
        // buttonhoz tartozó segédváltozók:
        int count = 0; // beállítja a nevet
        int top = 10; // beállítja a button elhelyezkedését vertikálisan
        int left = 10; // beállítja a button elhelyezkedését horizontálisan
        public static string[] pieces = new string[2];

        public DiplomacyForm()
        {
            
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            this.Load += (s, e) =>
            {
                panel.Controls.Clear();
                incoming_message();
                lb_header.Text = "Bejövő üzenetek";
            };
            

            bt_incoming.Click += (s, e) =>
            {
                panel.Controls.Clear();
                incoming_message();
                lb_header.Text = "Bejövő üzenetek";
            };

            bt_sent.Click += (s, e) =>
            {
                panel.Controls.Clear();
                sent_message();
                lb_header.Text = "Elküldött üzenetek";
            };

            bt_new_message.Click += (s, e) =>
            {
                NewMessageForm form = new NewMessageForm();
                form.ShowDialog();
            };
            
        }

        void color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_new_message.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_incoming.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_sent.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            lb_header.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_new_message.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_incoming.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_sent.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
        }

        void message_click(object sender, EventArgs e)
        {
            // megvizsgálja, hogy a beérkező, vagy a kimenő üzeneteket nyissa-e meg.
            Button btn = sender as Button;
            pieces = btn.Name.Split('_');
            
            if (pieces[0] == "incoming")
            {
                IncomeMessageForm.count = Convert.ToInt32(pieces[1]);
                IncomeMessageForm form = new IncomeMessageForm();
                form.ShowDialog();
            }
            else
            {
                SentMessageForm.count = Convert.ToInt32(pieces[1]);
                SentMessageForm form2 = new SentMessageForm();
                form2.ShowDialog();
            }
            
        }

        void sent_messages_load()
        {
            list_sent.Clear();
            // elküldött üzenetek:
            string sql_sent_messages = $"SELECT * FROM `messages` WHERE sender_country = '{C_MainPageForm.country_name}' ORDER BY ID DESC;";
            List<string> sql_sent_columns = new List<string>() { "ID", "Date", "sender_country", "adresse_country", "subject", "text", "read_status" };
            M_db.list_upload_horizontal(list_sent, sql_sent_messages, sql_sent_columns);
        }

        public void incoming_messages_load()
        {
            list_incoming.Clear();
            // bejövő üzenetek:
            string sql_incoming_messages = $"SELECT * FROM `messages` WHERE adresse_country = '{C_MainPageForm.country_name}' ORDER BY ID DESC;";
            List<string> sql_incoming_columns = new List<string>() { "ID", "Date", "sender_country", "adresse_country", "subject", "text", "read_status" };
            M_db.list_upload_horizontal(list_incoming, sql_incoming_messages, sql_incoming_columns);
        }



        void incoming_message()
        {
            count = 0;
            top = 10;
            left = 10;

            incoming_messages_load();

            for (int i = 0; i < list_incoming.Count / 7; i++)
            {
                Button bt = new Button();
                string read_status;
                if (list_incoming[6 + (count * 7)] == "0")
                {
                    read_status = "OLVASATLAN ÜZENET";
                    message_button_style(bt, panel, $"{read_status} | Dátum: {list_incoming[1 + (count * 7)]} | Feladó: {list_incoming[2 + (count * 7)]} | Tárgy: {list_incoming[4 + (count * 7)]}", "incoming",
                        Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
                }
                else
                {
                    message_button_style(bt, panel, $"Dátum: {list_incoming[1 + (count * 7)]} | Feladó: {list_incoming[2 + (count * 7)]} | Tárgy: {list_incoming[4 + (count * 7)]}", "incoming",
                        Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
                }
                
            }
        }

        void sent_message()
        {
            count = 0;
            top = 10;
            left = 10;

            sent_messages_load();

            for (int i = 0; i < list_sent.Count / 7; i++)
            {
                Button bt = new Button();
                message_button_style(bt, panel, $"Dátum: {list_sent[1 + (count * 7)]} | Címzett: {list_sent[3 + (count * 7)]} | Tárgy: {list_sent[4 + (count * 7)]}", "sent",
                    Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            }
        }

        void message_button_style(Button bt, Panel panel, string text, string bt_name, int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            panel.Controls.Add(bt);
            bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            bt.Location = new System.Drawing.Point(left, top);
            bt.Name = $"{bt_name}_{count}";
            if (bt_name.Contains("incoming"))
            {
                if (list_incoming[6 + (count * 7)] == "0")
                {
                    bt.BackColor = System.Drawing.Color.FromArgb(forecolor0, forecolor1, forecolor2);
                    bt.ForeColor = System.Drawing.Color.FromArgb(backcolor0, backcolor1, backcolor2);
                }
                else
                {
                    bt.ForeColor = System.Drawing.Color.FromArgb(forecolor0, forecolor1, forecolor2);
                }
            }
            else
            {
                bt.ForeColor = System.Drawing.Color.FromArgb(forecolor0, forecolor1, forecolor2);
            }
            bt.Size = new System.Drawing.Size(760, 33);
            bt.TabStop = false;
            bt.Text = text;
            bt.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            bt.Cursor = Cursors.Hand;
            bt.FlatStyle = FlatStyle.Flat;
            bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            bt.Click += new EventHandler(this.message_click);
            top += 35;
            count++;
        }
    }
}
