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
    public partial class SentMessageForm : Form
    {

        public static int count;
        // "ID", "Date", "sender_country", "adress_country", "subject", "text", "read_status"

        public SentMessageForm()
        {
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            lb_sender.Text = DiplomacyForm.list_sent[3 + (count * 7)];
            lb_subject.Text = DiplomacyForm.list_sent[4 + (count * 7)];
            lb_date.Text = DiplomacyForm.list_sent[1 + (count * 7)];
            tb_message.Text = DiplomacyForm.list_sent[5 + (count * 7)];

            if (DiplomacyForm.list_sent[6 + (count * 7)] == "0")
            {
                lb_read_status.Location = new System.Drawing.Point(12, 205);
                lb_read_status.Size = new System.Drawing.Size(70, 45);
                lb_read_status.Text = "Az üzenetet nem olvasták el!";
            }
            else
            {
                lb_read_status.Location = new System.Drawing.Point(12, 220);
                lb_read_status.Size = new System.Drawing.Size(70, 30);
                lb_read_status.Text = "Az üzenetet elolvasták!";
            }


        }

        void color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_message.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            tb_message.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_date.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_sender.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_subject.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label3.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_read_status.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
        }

    }
}
