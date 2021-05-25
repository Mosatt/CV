using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Movie_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Location = new Point(810,915);

            this.BackColor = Color.FromArgb(34, 34, 34);

            pb_exit.Click += (s, e) => { Application.Exit(); };
            pb_openfolder.Click += (s, e) => { Open_file(); };
            pb_start.Click += (s, e) => { Start(movie_index); };
            pb_back.Click += (s, e) => { movie_index--; File_write(movie_index); Label_text(); };
            pb_next.Click += (s, e) => { movie_index++; File_write(movie_index); Label_text(); };

            panel.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            };

            int i = 0;
            do
            {
                Label_text();
                i++;
            } while (i == 0);
        }

        void Label_text()
        {

            File_Read();

            if (movie_index >= 0 && movie_index < list.Count)
            {
                label1.Text = $"Jelenlegi rész: {Path.GetFileName(list[movie_index])}";
                pb_openfolder.MouseHover += (s, e) => { label1.Text = $"Sorozat kiválasztása"; };
                if (movie_index == 0)
                {
                    pb_back.MouseHover += (s, e) => { label1.Text = $"Nincs előző rész."; };
                    pb_back.Enabled = false;
                }
                else
                {
                    pb_back.MouseHover += (s, e) => { label1.Text = $"Előző rész: {Path.GetFileName(list[movie_index - 1])}"; };
                    pb_back.Enabled = true;
                }
                if (movie_index == list.Count-1)
                {
                    pb_next.MouseHover += (s, e) => { label1.Text = $"Nincs következő rész."; };
                    pb_next.Enabled = false;
                }
                else
                {
                    pb_next.MouseHover += (s, e) => { label1.Text = $"Következő rész: {Path.GetFileName(list[movie_index + 1])}"; };
                    pb_next.Enabled = true;
                }
                pb_start.MouseHover += (s, e) => { label1.Text = $"Jelenlegi rész: {Path.GetFileName(list[movie_index])}"; };
                pb_exit.MouseHover += (s, e) => { label1.Text = $"Kilépés"; };
                panel.MouseHover += (s, e) => { label1.Text = $"Mozgatás"; };
            }
            else if (movie_index == list.Count && list.Count != 0)
            {
                label1.Text = $"Nincs több rész.";
                pb_openfolder.MouseHover += (s, e) => { label1.Text = $"Sorozat kiválasztása"; };
                pb_back.MouseHover += (s, e) => { label1.Text = $"Előző rész: {Path.GetFileName(list[movie_index - 1])}"; };
                pb_next.MouseHover += (s, e) => { label1.Text = $"Nincs több rész."; };
                pb_start.MouseHover += (s, e) => { label1.Text = $"Nincs több rész."; };
                pb_exit.MouseHover += (s, e) => { label1.Text = $"Kilépés"; };
                panel.MouseHover += (s, e) => { label1.Text = $"Mozgatás"; };
            }
            else
            {
                label1.Text = $"Nincs kiválasztva sorozat.";
                pb_openfolder.MouseHover += (s, e) => { label1.Text = $"Sorozat kiválasztása"; };
                pb_back.MouseHover += (s, e) => { label1.Text = $"Nincs kiválasztva sorozat."; };
                pb_next.MouseHover += (s, e) => { label1.Text = $"Nincs kiválasztva sorozat."; };
                pb_start.MouseHover += (s, e) => { label1.Text = $"Nincs kiválasztva sorozat."; };
                pb_exit.MouseHover += (s, e) => { label1.Text = $"Kilépés"; };
                panel.MouseHover += (s, e) => { label1.Text = $"Mozgatás"; };
            }
        }

        /// <summary>
        /// panel.MouseDown eventhez szükséges. Így válik mozgathatóvá a form.
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        /// 

        static List<string> list = new List<string>(); // mappában lévő összes útvonalat tárolja
        static int movie_index; // következő videó indexét tárolja

        void File_write(int index)
        {
            StreamWriter sw = new StreamWriter("datas.txt");
            sw.WriteLine(index);
            foreach (var item in list)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        void File_Read()
        {

            list.Clear();

            if (File.Exists("datas.txt"))
            {
                StreamReader sr = new StreamReader("datas.txt");
                movie_index = Convert.ToInt32(sr.ReadLine());
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                sr.Close();
            }
            else
            {

                MessageBox.Show("Nincs kiválasztva sorozat!","",MessageBoxButtons.OK,MessageBoxIcon.Error);

                Open_file();

                StreamReader sr = new StreamReader("datas.txt");
                movie_index = Convert.ToInt32(sr.ReadLine());
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        void Open_file()
        {

            list.Clear();

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] rows = Directory.GetFiles(fbd.SelectedPath);
                    foreach (var item in rows)
                    {
                        list.Add(item);
                    }

                }
            }

            File_write(0);

        }

        void Start(int index)
        {

            File_Read();

            if (movie_index == list.Count)
            {
                MessageBox.Show("Nincs elérhető videó!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //MessageBox.Show($"{next_movie_index}");
                ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files\Windows Media Player\wmplayer.exe");
                startInfo.Arguments = list[index];
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
                movie_index++;
                File_write(movie_index);
            }
        }
    }
}
