namespace Koltsegvetes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_bevetel = new System.Windows.Forms.DataGridView();
            this.tb_megjegyzes = new System.Windows.Forms.TextBox();
            this.tb_osszeg = new System.Windows.Forms.TextBox();
            this.cb_kategoria = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgv_kiadas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_adatfelvetel = new System.Windows.Forms.Button();
            this.dgv_szurt = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_keres = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.bt_kereses = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_zaro = new System.Windows.Forms.DateTimePicker();
            this.dtp_indulo = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_sum_bev = new System.Windows.Forms.Label();
            this.lb_sum_kiad = new System.Windows.Forms.Label();
            this.lb_egyenleg = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_torles = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_torles = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lb_szurt_egyenleg = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lb_szurt_kiad = new System.Windows.Forms.Label();
            this.lb_szurt_bev = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bt_beallit = new System.Windows.Forms.Button();
            this.nud_betumeret = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bevetel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kiadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_szurt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_torles)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_betumeret)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_bevetel
            // 
            this.dgv_bevetel.AllowUserToAddRows = false;
            this.dgv_bevetel.AllowUserToDeleteRows = false;
            this.dgv_bevetel.AllowUserToResizeColumns = false;
            this.dgv_bevetel.AllowUserToResizeRows = false;
            this.dgv_bevetel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_bevetel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bevetel.Location = new System.Drawing.Point(14, 53);
            this.dgv_bevetel.Name = "dgv_bevetel";
            this.dgv_bevetel.ReadOnly = true;
            this.dgv_bevetel.RowHeadersVisible = false;
            this.dgv_bevetel.ShowCellErrors = false;
            this.dgv_bevetel.ShowCellToolTips = false;
            this.dgv_bevetel.ShowEditingIcon = false;
            this.dgv_bevetel.ShowRowErrors = false;
            this.dgv_bevetel.Size = new System.Drawing.Size(482, 500);
            this.dgv_bevetel.TabIndex = 33;
            this.dgv_bevetel.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // tb_megjegyzes
            // 
            this.tb_megjegyzes.Location = new System.Drawing.Point(401, 42);
            this.tb_megjegyzes.Name = "tb_megjegyzes";
            this.tb_megjegyzes.Size = new System.Drawing.Size(200, 20);
            this.tb_megjegyzes.TabIndex = 36;
            // 
            // tb_osszeg
            // 
            this.tb_osszeg.Location = new System.Drawing.Point(168, 42);
            this.tb_osszeg.Name = "tb_osszeg";
            this.tb_osszeg.Size = new System.Drawing.Size(100, 20);
            this.tb_osszeg.TabIndex = 34;
            // 
            // cb_kategoria
            // 
            this.cb_kategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kategoria.FormattingEnabled = true;
            this.cb_kategoria.Items.AddRange(new object[] {
            "Bevétel",
            "Rezsi",
            "Vásárlás"});
            this.cb_kategoria.Location = new System.Drawing.Point(274, 42);
            this.cb_kategoria.Name = "cb_kategoria";
            this.cb_kategoria.Size = new System.Drawing.Size(121, 21);
            this.cb_kategoria.TabIndex = 37;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy.MM.dd. HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(37, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 20);
            this.dateTimePicker1.TabIndex = 38;
            // 
            // dgv_kiadas
            // 
            this.dgv_kiadas.AllowUserToAddRows = false;
            this.dgv_kiadas.AllowUserToDeleteRows = false;
            this.dgv_kiadas.AllowUserToResizeColumns = false;
            this.dgv_kiadas.AllowUserToResizeRows = false;
            this.dgv_kiadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_kiadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kiadas.Location = new System.Drawing.Point(990, 53);
            this.dgv_kiadas.Name = "dgv_kiadas";
            this.dgv_kiadas.ReadOnly = true;
            this.dgv_kiadas.RowHeadersVisible = false;
            this.dgv_kiadas.ShowCellErrors = false;
            this.dgv_kiadas.ShowCellToolTips = false;
            this.dgv_kiadas.ShowEditingIcon = false;
            this.dgv_kiadas.ShowRowErrors = false;
            this.dgv_kiadas.Size = new System.Drawing.Size(482, 500);
            this.dgv_kiadas.TabIndex = 39;
            this.dgv_kiadas.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(165, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Összeg";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(271, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "Kategória";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(401, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "Megjegyzés";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(34, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 43;
            this.label4.Text = "Dátum";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(484, 23);
            this.label6.TabIndex = 45;
            this.label6.Text = "Bevétel";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(987, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(485, 23);
            this.label7.TabIndex = 46;
            this.label7.Text = "Kiadás";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_adatfelvetel
            // 
            this.bt_adatfelvetel.Location = new System.Drawing.Point(526, 68);
            this.bt_adatfelvetel.Name = "bt_adatfelvetel";
            this.bt_adatfelvetel.Size = new System.Drawing.Size(75, 23);
            this.bt_adatfelvetel.TabIndex = 47;
            this.bt_adatfelvetel.Text = "Küld";
            this.bt_adatfelvetel.UseVisualStyleBackColor = true;
            this.bt_adatfelvetel.Click += new System.EventHandler(this.bt_adatfelvetel_Click);
            // 
            // dgv_szurt
            // 
            this.dgv_szurt.AllowUserToAddRows = false;
            this.dgv_szurt.AllowUserToDeleteRows = false;
            this.dgv_szurt.AllowUserToResizeColumns = false;
            this.dgv_szurt.AllowUserToResizeRows = false;
            this.dgv_szurt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_szurt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_szurt.Location = new System.Drawing.Point(502, 53);
            this.dgv_szurt.Name = "dgv_szurt";
            this.dgv_szurt.ReadOnly = true;
            this.dgv_szurt.RowHeadersVisible = false;
            this.dgv_szurt.ShowCellErrors = false;
            this.dgv_szurt.ShowCellToolTips = false;
            this.dgv_szurt.ShowEditingIcon = false;
            this.dgv_szurt.ShowRowErrors = false;
            this.dgv_szurt.Size = new System.Drawing.Size(482, 500);
            this.dgv_szurt.TabIndex = 48;
            this.dgv_szurt.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(502, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(482, 23);
            this.label8.TabIndex = 49;
            this.label8.Text = "Szűrt adatok";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_keres);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.bt_kereses);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtp_zaro);
            this.groupBox1.Controls.Add(this.dtp_indulo);
            this.groupBox1.Location = new System.Drawing.Point(646, 593);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 145);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keresés";
            // 
            // tb_keres
            // 
            this.tb_keres.Location = new System.Drawing.Point(113, 80);
            this.tb_keres.Name = "tb_keres";
            this.tb_keres.Size = new System.Drawing.Size(125, 20);
            this.tb_keres.TabIndex = 53;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 23);
            this.label19.TabIndex = 52;
            this.label19.Text = "Keresendő kifejezés:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_kereses
            // 
            this.bt_kereses.Location = new System.Drawing.Point(9, 116);
            this.bt_kereses.Name = "bt_kereses";
            this.bt_kereses.Size = new System.Drawing.Size(229, 23);
            this.bt_kereses.TabIndex = 51;
            this.bt_kereses.Text = "Listáz";
            this.bt_kereses.UseVisualStyleBackColor = true;
            this.bt_kereses.Click += new System.EventHandler(this.bt_kereses_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 23);
            this.label10.TabIndex = 53;
            this.label10.Text = "Meddig:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 23);
            this.label9.TabIndex = 52;
            this.label9.Text = "Mettől:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_zaro
            // 
            this.dtp_zaro.CustomFormat = "yyyy.MM.dd. HH:mm";
            this.dtp_zaro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_zaro.Location = new System.Drawing.Point(113, 52);
            this.dtp_zaro.Name = "dtp_zaro";
            this.dtp_zaro.Size = new System.Drawing.Size(125, 20);
            this.dtp_zaro.TabIndex = 51;
            // 
            // dtp_indulo
            // 
            this.dtp_indulo.CustomFormat = "yyyy.MM.dd. HH:mm";
            this.dtp_indulo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_indulo.Location = new System.Drawing.Point(113, 29);
            this.dtp_indulo.Name = "dtp_indulo";
            this.dtp_indulo.Size = new System.Drawing.Size(125, 20);
            this.dtp_indulo.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(43, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 23);
            this.label11.TabIndex = 51;
            this.label11.Text = "Teljes bevétel:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(43, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 23);
            this.label12.TabIndex = 52;
            this.label12.Text = "Teljes kiadás:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(43, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 23);
            this.label13.TabIndex = 53;
            this.label13.Text = "Egyenleg:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_sum_bev
            // 
            this.lb_sum_bev.Location = new System.Drawing.Point(136, 16);
            this.lb_sum_bev.Name = "lb_sum_bev";
            this.lb_sum_bev.Size = new System.Drawing.Size(70, 23);
            this.lb_sum_bev.TabIndex = 54;
            this.lb_sum_bev.Text = "-";
            this.lb_sum_bev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_sum_kiad
            // 
            this.lb_sum_kiad.Location = new System.Drawing.Point(136, 39);
            this.lb_sum_kiad.Name = "lb_sum_kiad";
            this.lb_sum_kiad.Size = new System.Drawing.Size(70, 23);
            this.lb_sum_kiad.TabIndex = 55;
            this.lb_sum_kiad.Text = "-";
            this.lb_sum_kiad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_egyenleg
            // 
            this.lb_egyenleg.Location = new System.Drawing.Point(136, 66);
            this.lb_egyenleg.Name = "lb_egyenleg";
            this.lb_egyenleg.Size = new System.Drawing.Size(70, 23);
            this.lb_egyenleg.TabIndex = 56;
            this.lb_egyenleg.Text = "-";
            this.lb_egyenleg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_osszeg);
            this.groupBox2.Controls.Add(this.tb_megjegyzes);
            this.groupBox2.Controls.Add(this.cb_kategoria);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.bt_adatfelvetel);
            this.groupBox2.Location = new System.Drawing.Point(15, 592);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 100);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adatbevitel";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lb_egyenleg);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lb_sum_kiad);
            this.groupBox3.Controls.Add(this.lb_sum_bev);
            this.groupBox3.Location = new System.Drawing.Point(901, 593);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 100);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statisztika - aktuális hónap";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_torles);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.nud_torles);
            this.groupBox4.Location = new System.Drawing.Point(410, 698);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 51);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Adat törlés";
            // 
            // bt_torles
            // 
            this.bt_torles.Location = new System.Drawing.Point(142, 19);
            this.bt_torles.Name = "bt_torles";
            this.bt_torles.Size = new System.Drawing.Size(70, 23);
            this.bt_torles.TabIndex = 60;
            this.bt_torles.Text = "Törlés";
            this.bt_torles.UseVisualStyleBackColor = true;
            this.bt_torles.Click += new System.EventHandler(this.bt_torles_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 23);
            this.label5.TabIndex = 44;
            this.label5.Text = "ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_torles
            // 
            this.nud_torles.Location = new System.Drawing.Point(60, 22);
            this.nud_torles.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nud_torles.Name = "nud_torles";
            this.nud_torles.Size = new System.Drawing.Size(76, 20);
            this.nud_torles.TabIndex = 0;
            this.nud_torles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.lb_szurt_egyenleg);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.lb_szurt_kiad);
            this.groupBox5.Controls.Add(this.lb_szurt_bev);
            this.groupBox5.Location = new System.Drawing.Point(1138, 592);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(231, 100);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Statisztika - keresett adatok alapján";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(43, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 23);
            this.label14.TabIndex = 51;
            this.label14.Text = "Teljes bevétel:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(43, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 23);
            this.label15.TabIndex = 52;
            this.label15.Text = "Teljes kiadás:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_szurt_egyenleg
            // 
            this.lb_szurt_egyenleg.Location = new System.Drawing.Point(136, 66);
            this.lb_szurt_egyenleg.Name = "lb_szurt_egyenleg";
            this.lb_szurt_egyenleg.Size = new System.Drawing.Size(70, 23);
            this.lb_szurt_egyenleg.TabIndex = 56;
            this.lb_szurt_egyenleg.Text = "-";
            this.lb_szurt_egyenleg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(43, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 23);
            this.label17.TabIndex = 53;
            this.label17.Text = "Egyenleg:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_szurt_kiad
            // 
            this.lb_szurt_kiad.Location = new System.Drawing.Point(136, 39);
            this.lb_szurt_kiad.Name = "lb_szurt_kiad";
            this.lb_szurt_kiad.Size = new System.Drawing.Size(70, 23);
            this.lb_szurt_kiad.TabIndex = 55;
            this.lb_szurt_kiad.Text = "-";
            this.lb_szurt_kiad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_szurt_bev
            // 
            this.lb_szurt_bev.Location = new System.Drawing.Point(136, 16);
            this.lb_szurt_bev.Name = "lb_szurt_bev";
            this.lb_szurt_bev.Size = new System.Drawing.Size(70, 23);
            this.lb_szurt_bev.TabIndex = 54;
            this.lb_szurt_bev.Text = "-";
            this.lb_szurt_bev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bt_beallit);
            this.groupBox6.Controls.Add(this.nud_betumeret);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(15, 698);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(247, 51);
            this.groupBox6.TabIndex = 61;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Beállítások";
            // 
            // bt_beallit
            // 
            this.bt_beallit.Enabled = false;
            this.bt_beallit.Location = new System.Drawing.Point(166, 16);
            this.bt_beallit.Name = "bt_beallit";
            this.bt_beallit.Size = new System.Drawing.Size(75, 23);
            this.bt_beallit.TabIndex = 63;
            this.bt_beallit.Text = "Beállít";
            this.bt_beallit.UseVisualStyleBackColor = true;
            this.bt_beallit.Click += new System.EventHandler(this.bt_beallit_Click);
            // 
            // nud_betumeret
            // 
            this.nud_betumeret.Enabled = false;
            this.nud_betumeret.Location = new System.Drawing.Point(105, 19);
            this.nud_betumeret.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nud_betumeret.Name = "nud_betumeret";
            this.nud_betumeret.Size = new System.Drawing.Size(52, 20);
            this.nud_betumeret.TabIndex = 62;
            this.nud_betumeret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Enabled = false;
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 23);
            this.label16.TabIndex = 45;
            this.label16.Text = "Betűméret:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 762);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgv_szurt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_kiadas);
            this.Controls.Add(this.dgv_bevetel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Költségvetés - 1.0 v.";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bevetel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kiadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_szurt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_torles)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_betumeret)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_bevetel;
        private System.Windows.Forms.TextBox tb_megjegyzes;
        private System.Windows.Forms.TextBox tb_osszeg;
        private System.Windows.Forms.ComboBox cb_kategoria;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgv_kiadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_adatfelvetel;
        private System.Windows.Forms.DataGridView dgv_szurt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_kereses;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_zaro;
        private System.Windows.Forms.DateTimePicker dtp_indulo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lb_sum_bev;
        private System.Windows.Forms.Label lb_sum_kiad;
        private System.Windows.Forms.Label lb_egyenleg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_torles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_torles;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lb_szurt_egyenleg;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lb_szurt_kiad;
        private System.Windows.Forms.Label lb_szurt_bev;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nud_betumeret;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bt_beallit;
        private System.Windows.Forms.TextBox tb_keres;
        private System.Windows.Forms.Label label19;
    }
}

