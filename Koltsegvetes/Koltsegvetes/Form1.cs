using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Koltsegvetes
{

    struct Adatok
    {
        public int ID { get; set; }
        public DateTime Ido { get; set; }
        public int Osszeg { get; set; }
        public string Kategoria { get; set; }
        public string Megjegyzes { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static List<Adatok> lista = new List<Adatok>();

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void dgv_bev()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Dátum");
            dt.Columns.Add("Összeg");
            dt.Columns.Add("Kategória");
            dt.Columns.Add("Megjegyzés");

            IEnumerable<Adatok> count = (from x in lista where x.Kategoria == "Bevétel" && x.Ido.Month == DateTime.Now.Month orderby x.Ido select x);

            foreach (var item in count)
            {
                dt.Rows.Add(new object[] {item.ID, Convert.ToDateTime(item.Ido), item.Osszeg,item.Kategoria,item.Megjegyzes });
            }
            dgv_bevetel.DataSource = dt;
            dgv_bevetel.Columns[0].Width = 30;
            dgv_bevetel.Columns[1].Width = 130;
            dgv_bevetel.Columns[2].Width = 70;
            dgv_bevetel.Columns[3].Width = 70;
            dgv_bevetel.Columns[4].Width = 200;
            dgv_bevetel.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.RowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgv_bevetel.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Window;
            dgv_bevetel.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bevetel.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_bevetel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;     // ez és a következő sor a multiline-ért felelnek.
            dgv_bevetel.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void dgv_kiad()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Dátum");
            dt.Columns.Add("Összeg");
            dt.Columns.Add("Kategória");
            dt.Columns.Add("Megjegyzés");
            
            IEnumerable<Adatok> count = (from x in lista where (x.Kategoria == "Vásárlás" || x.Kategoria == "Rezsi") && x.Ido.Month == DateTime.Now.Month orderby x.Ido select x);
            foreach (var item in count)
            {
                dt.Rows.Add(new object[] { item.ID, Convert.ToDateTime(item.Ido), item.Osszeg, item.Kategoria, item.Megjegyzes });
            }
            dgv_kiadas.DataSource = dt;
            dgv_kiadas.Columns[0].Width = 30;
            dgv_kiadas.Columns[1].Width = 130;
            dgv_kiadas.Columns[2].Width = 70;
            dgv_kiadas.Columns[3].Width = 70;
            dgv_kiadas.Columns[4].Width = 200;
            dgv_kiadas.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.RowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgv_kiadas.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Window;
            dgv_kiadas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_kiadas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_kiadas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;     // ez és a következő sor a multiline-ért felelnek.
            dgv_kiadas.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }


        

        static void beolvas()
        {
            if (File.Exists("data.mazsi"))
            {
                lista.Clear();
                StreamReader sr = new StreamReader("data.mazsi", Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string[] sor = Base64Decode(sr.ReadLine()).Split(';');
                    if (sor[0] != string.Empty)
                    {
                        lista.Add(new Adatok
                        {
                            ID = Convert.ToInt32(sor[0]),
                            Ido = Convert.ToDateTime(sor[1]),
                            Osszeg = Convert.ToInt32(sor[2]),
                            Kategoria = sor[3],
                            Megjegyzes = sor[4]
                        });
                    }
                }
                sr.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter("data.mazsi",false,Encoding.UTF8);
                sw.Close();
                StreamReader sr = new StreamReader("data.mazsi", Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string[] sor = Base64Decode(sr.ReadLine()).Split(';');
                    if (sor[0] != string.Empty)
                    {
                        lista.Add(new Adatok
                        {
                            ID = Convert.ToInt32(sor[0]),
                            Ido = Convert.ToDateTime(sor[1]),
                            Osszeg = Convert.ToInt32(sor[2]),
                            Kategoria = sor[3],
                            Megjegyzes = sor[4]
                        });
                    }
                }
                sr.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // ismert hibák:
            /*
             * ha több év azonos hónapjából szerepel adat, akkor mindet kilistázza a bevétel-kiadás dgv-be, nem csak az aktuális évit.
             * ez a hiba befolyásolhatja a statisztikát is
            */

            cb_kategoria.SelectedIndex = 0;
            beolvas();
            dgv_bev();
            dgv_kiad();
            statisztika();

            int betumeret = 0;
            if (File.Exists("settings.settings"))
            {
                StreamReader sr = new StreamReader("settings.settings", Encoding.UTF8);
                betumeret = Convert.ToInt32(sr.ReadLine());
                nud_betumeret.Value = betumeret;
                sr.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter("settings.settings", false, Encoding.UTF8);
                sw.WriteLine("14");
                sw.Close();
                StreamReader sr = new StreamReader("settings.settings", Encoding.UTF8);
                betumeret = Convert.ToInt32(sr.ReadLine());
                sr.Close();
                
            }
            nud_betumeret.Value = betumeret;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv_bevetel.ClearSelection();
            dgv_kiadas.ClearSelection();
            dgv_szurt.ClearSelection();
        }

        private void bt_adatfelvetel_Click(object sender, EventArgs e)
        {

            // új id meghatározása
            int id = 0;
            if (lista.Count > 0)
            {
                id = lista.Count;
            }
            else
            {
                id = 0;
            }

            if (int.TryParse(tb_osszeg.Text, out int osszeg) && !tb_megjegyzes.Text.Contains(';'))
            {
                StreamWriter sw = new StreamWriter("data.mazsi", true, Encoding.UTF8);
                sw.WriteLine(Base64Encode($"{id};{Convert.ToDateTime(dateTimePicker1.Value)};{tb_osszeg.Text};{cb_kategoria.SelectedItem};{tb_megjegyzes.Text}"));
                sw.Close();
                MessageBox.Show($"Az alábbi adatokat sikeresen mentetted:\n\nID: {id}\nDátum: {Convert.ToDateTime(dateTimePicker1.Value)}\nÖsszeg: {tb_osszeg.Text}\nKategória {cb_kategoria.SelectedItem}\nMegjegyzés: {tb_megjegyzes.Text}","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Rossz bevitel!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            dateTimePicker1.Value = DateTime.Now;
            tb_osszeg.Text = string.Empty;
            tb_megjegyzes.Text = string.Empty;

            beolvas();
            dgv_bev();
            dgv_kiad();
            statisztika();
        }

        void statisztika()
        {
            int bevetel = 0;
            int kiadas = 0;
            IEnumerable<Adatok> sum_bev = from x in lista where x.Kategoria == "Bevétel" select x;
            foreach (var item in sum_bev)
            {
                bevetel += item.Osszeg;
            }
            IEnumerable<Adatok> sum_kiad = from x in lista where x.Kategoria == "Vásárlás" || x.Kategoria == "Rezsi" select x;
            foreach (var item in sum_kiad)
            {
                kiadas += item.Osszeg;
            }
            lb_sum_bev.Text = bevetel.ToString("### ### ###") + " Ft";
            lb_sum_kiad.Text = kiadas.ToString("### ### ###") + " Ft";
            lb_egyenleg.Text = (bevetel - kiadas).ToString("### ### ###") + " Ft";
        }

        private void bt_torles_Click(object sender, EventArgs e)
        {
            IEnumerable<Adatok> delete = from x in lista where x.ID != nud_torles.Value select x;
            StreamWriter sw = new StreamWriter("data.mazsi",false,Encoding.UTF8);
            foreach (var item in delete)
            {
                sw.WriteLine(Base64Encode($"{item.ID};{item.Ido};{item.Osszeg};{item.Kategoria};{item.Megjegyzes}"));
            }
            sw.Close();

            beolvas();
            dgv_bev();
            dgv_kiad();
            statisztika();
        }

        private void bt_beallit_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("settings.settings", false, Encoding.UTF8);
            sw.WriteLine(nud_betumeret.Value);
            sw.Close();
            MessageBox.Show("A beállítás siekres volt!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void szurt_dgv_stilus()
        {
            dgv_szurt.Columns[0].Width = 30;
            dgv_szurt.Columns[1].Width = 130;
            dgv_szurt.Columns[2].Width = 70;
            dgv_szurt.Columns[3].Width = 70;
            dgv_szurt.Columns[4].Width = 200;
            dgv_szurt.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.RowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgv_szurt.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Window;
            dgv_szurt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_szurt.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_szurt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;     // ez és a következő sor a multiline-ért felelnek.
            dgv_szurt.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void bt_kereses_Click(object sender, EventArgs e)
        {
            //szűrt adatok

            int bevetel = 0;
            int kiadas = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Dátum");
            dt.Columns.Add("Összeg");
            dt.Columns.Add("Kategória");
            dt.Columns.Add("Megjegyzés");

            if (tb_keres.Text == string.Empty && (dtp_indulo.Value != DateTime.Now || dtp_zaro.Value != DateTime.Now))
            {

                // nincs szöveg, keresett dátum változott

                IEnumerable<Adatok> ido = (from x in lista where x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) orderby x.Ido select x);
                foreach (var item in ido)
                {
                    dt.Rows.Add(new object[] { item.ID, Convert.ToDateTime(item.Ido), item.Osszeg, item.Kategoria, item.Megjegyzes });
                }
                

                IEnumerable<Adatok> sum_bev = from x in lista where x.Kategoria == "Bevétel" && x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) select x;
                foreach (var item in sum_bev)
                {
                    bevetel += item.Osszeg;
                }
                IEnumerable<Adatok> sum_kiad = from x in lista where (x.Kategoria == "Vásárlás" || x.Kategoria == "Rezsi") && x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) select x;
                foreach (var item in sum_kiad)
                {
                    kiadas += item.Osszeg;
                }

            }
            else if (tb_keres.Text != string.Empty)
            {

                // van szöveg

                if (dtp_indulo.Value.DayOfYear == DateTime.Now.DayOfYear && dtp_zaro.Value.DayOfYear == DateTime.Now.DayOfYear)
                {

                    // és dátum nem változott

                    foreach (var item in lista.Where(x => x.Megjegyzes.Contains(tb_keres.Text)))
                    {
                        dt.Rows.Add(new object[] { item.ID, Convert.ToDateTime(item.Ido), item.Osszeg, item.Kategoria, item.Megjegyzes });
                    }


                    IEnumerable<Adatok> sum_bev = from x in lista where x.Kategoria == "Bevétel" && x.Megjegyzes.Contains(tb_keres.Text) select x;
                    foreach (var item in sum_bev)
                    {
                        bevetel += item.Osszeg;
                    }
                    IEnumerable<Adatok> sum_kiad = from x in lista where (x.Kategoria == "Vásárlás" || x.Kategoria == "Rezsi") && x.Megjegyzes.Contains(tb_keres.Text) select x;
                    foreach (var item in sum_kiad)
                    {
                        kiadas += item.Osszeg;
                    }
                }
                else
                {

                    // és dátum változott

                    foreach (var item in lista.Where(x => x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) && x.Megjegyzes.Contains(tb_keres.Text)))
                    {
                        dt.Rows.Add(new object[] { item.ID, Convert.ToDateTime(item.Ido), item.Osszeg, item.Kategoria, item.Megjegyzes });
                    }


                    IEnumerable<Adatok> sum_bev = from x in lista where x.Kategoria == "Bevétel" && x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) && x.Megjegyzes.Contains(tb_keres.Text) select x;
                    foreach (var item in sum_bev)
                    {
                        bevetel += item.Osszeg;
                    }
                    IEnumerable<Adatok> sum_kiad = from x in lista where (x.Kategoria == "Vásárlás" || x.Kategoria == "Rezsi") && x.Ido >= Convert.ToDateTime(dtp_indulo.Value) && x.Ido <= Convert.ToDateTime(dtp_zaro.Value) && x.Megjegyzes.Contains(tb_keres.Text) select x;
                    foreach (var item in sum_kiad)
                    {
                        kiadas += item.Osszeg;
                    }
                }
            }

            dgv_szurt.DataSource = dt;

            szurt_dgv_stilus();
            tb_keres.Text = string.Empty;
            lb_szurt_bev.Text = bevetel.ToString("### ### ###") + " Ft";
            lb_szurt_kiad.Text = kiadas.ToString("### ### ###") + " Ft";
            lb_szurt_egyenleg.Text = (bevetel - kiadas).ToString("### ### ###") + " Ft";

        }
    }
}
