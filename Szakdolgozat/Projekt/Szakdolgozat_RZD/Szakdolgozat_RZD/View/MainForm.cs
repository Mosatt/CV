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
    public partial class MainForm : Form
    {

        void color(int backcolor0, int backcolor1, int backcolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            menuStrip1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
        }

        void menu_color(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            metroTile_economy.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            metroTile_constructions.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            metroTile_exit.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            metroTile_mainpage.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            metroTile_market.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            metroTile_messages.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            metroTile_economy.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            metroTile_constructions.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            metroTile_exit.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            metroTile_mainpage.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            metroTile_market.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            metroTile_messages.ForeColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
        }

        void menutrip(Form form)
        {
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        public void mainpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPageForm form = new MainPageForm();
            if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
            Text = "Nemzetek - Főoldal";
        }

        public MainForm()
        {
            InitializeComponent();

            color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2]);
            menu_color(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);
            

            metroTile_mainpage.Click += (s, e) =>
            {
                MainPageForm form = new MainPageForm();
                if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
                Text = "Nemzetek - Főoldal";
            };
            
            metroTile_economy.Click += (s, e) =>
            {
                EconomyForm form = new EconomyForm();
                if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
                Text = "Nemzetek - Gazdaság";
            };

            metroTile_constructions.Click += (s, e) =>
            {
                ConstructionsForm form = new ConstructionsForm();
                if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
                Text = "Nemzetek - Építkezés";
            };

            metroTile_market.Click += (s, e) =>
            {
                MarketForm form = new MarketForm();
                if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
                Text = "Nemzetek - Kereskedelem";
            };

            metroTile_messages.Click += (s, e) =>
            {
                DiplomacyForm form = new DiplomacyForm();
                if (ActiveMdiChild != null) { ActiveMdiChild.Close(); menutrip(form); } else { menutrip(form); }
                Text = "Nemzetek - Üzenetek";
            };

            metroTile_exit.Click += (s, e) => 
            {
                DialogResult dr = MessageBox.Show($"Biztosan ki akarsz lépni?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Application.Exit();
                }
                
            };

            this.FormClosing += (s, e) => { Application.Exit(); };

        }
        
    }
}
