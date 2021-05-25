using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Szakdolgozat_RZD
{
    public partial class LoginF : Form
    {
        public LoginF()
        {
            InitializeComponent();

            design(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            C_Login ml = new C_Login();

            bt_exit.Click += (s, e) => { Application.Exit(); };

            bt_login.Click += (s, e) => { ml.login(tb_username.Text, tb_password.Text); this.Hide(); };

            lb_header.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            };

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        void design(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_username.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            tb_password.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_login.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            bt_exit.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            bt_login.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_exit.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_header.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

        }

    }
}
