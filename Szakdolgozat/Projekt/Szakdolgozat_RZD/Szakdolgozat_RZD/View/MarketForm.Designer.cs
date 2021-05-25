namespace Szakdolgozat_RZD
{
    partial class MarketForm
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
            this.lb_header = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_marketplace = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.nud_delete = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_offer = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_price = new System.Windows.Forms.NumericUpDown();
            this.nud_amount_offer = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_offer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_market = new System.Windows.Forms.NumericUpDown();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marketplace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount_offer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_market)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_header
            // 
            this.lb_header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_header.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_header.ForeColor = System.Drawing.Color.Maroon;
            this.lb_header.Location = new System.Drawing.Point(543, 9);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(445, 80);
            this.lb_header.TabIndex = 26;
            this.lb_header.Text = "Kereskedelem";
            this.lb_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgv_marketplace);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.bt_accept);
            this.panel5.Controls.Add(this.bt_delete);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.nud_delete);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.cb_offer);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.nud_price);
            this.panel5.Controls.Add(this.nud_amount_offer);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.bt_offer);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.nud_market);
            this.panel5.Location = new System.Drawing.Point(178, 151);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(643, 379);
            this.panel5.TabIndex = 49;
            // 
            // dgv_marketplace
            // 
            this.dgv_marketplace.AllowUserToAddRows = false;
            this.dgv_marketplace.AllowUserToDeleteRows = false;
            this.dgv_marketplace.AllowUserToResizeColumns = false;
            this.dgv_marketplace.AllowUserToResizeRows = false;
            this.dgv_marketplace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_marketplace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_marketplace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_marketplace.Location = new System.Drawing.Point(20, 66);
            this.dgv_marketplace.Name = "dgv_marketplace";
            this.dgv_marketplace.ReadOnly = true;
            this.dgv_marketplace.RowHeadersVisible = false;
            this.dgv_marketplace.ShowCellErrors = false;
            this.dgv_marketplace.ShowCellToolTips = false;
            this.dgv_marketplace.ShowEditingIcon = false;
            this.dgv_marketplace.ShowRowErrors = false;
            this.dgv_marketplace.Size = new System.Drawing.Size(602, 182);
            this.dgv_marketplace.TabIndex = 68;
            this.dgv_marketplace.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.Font = new System.Drawing.Font("Georgia", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(19, 351);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(296, 20);
            this.label13.TabIndex = 67;
            this.label13.Text = "Csak a saját ajánlataidat tudod törölni!";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label15.Font = new System.Drawing.Font("Georgia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(175, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 33);
            this.label15.TabIndex = 66;
            this.label15.Text = "Ajánlat törlése";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_accept
            // 
            this.bt_accept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_accept.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_accept.ForeColor = System.Drawing.Color.Maroon;
            this.bt_accept.Location = new System.Drawing.Point(23, 322);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(136, 25);
            this.bt_accept.TabIndex = 36;
            this.bt_accept.TabStop = false;
            this.bt_accept.Text = "Vásárlás";
            this.bt_accept.UseVisualStyleBackColor = true;
            // 
            // bt_delete
            // 
            this.bt_delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_delete.ForeColor = System.Drawing.Color.Maroon;
            this.bt_delete.Location = new System.Drawing.Point(175, 322);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(140, 25);
            this.bt_delete.TabIndex = 64;
            this.bt_delete.TabStop = false;
            this.bt_delete.Text = "Törlés";
            this.bt_delete.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label16.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Location = new System.Drawing.Point(165, 297);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 24);
            this.label16.TabIndex = 65;
            this.label16.Text = "ID:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_delete
            // 
            this.nud_delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nud_delete.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nud_delete.ForeColor = System.Drawing.Color.Maroon;
            this.nud_delete.Location = new System.Drawing.Point(225, 298);
            this.nud_delete.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud_delete.Name = "nud_delete";
            this.nud_delete.Size = new System.Drawing.Size(90, 20);
            this.nud_delete.TabIndex = 63;
            this.nud_delete.TabStop = false;
            this.nud_delete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(322, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 54;
            this.label9.Text = "Nyersanyag:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_offer
            // 
            this.cb_offer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cb_offer.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_offer.FormattingEnabled = true;
            this.cb_offer.Items.AddRange(new object[] {
            "Élelmiszer",
            "Építoanyag",
            "Textil",
            "Fegyver"});
            this.cb_offer.Location = new System.Drawing.Point(418, 349);
            this.cb_offer.Name = "cb_offer";
            this.cb_offer.Size = new System.Drawing.Size(95, 22);
            this.cb_offer.TabIndex = 51;
            this.cb_offer.TabStop = false;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label18.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(322, 324);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 20);
            this.label18.TabIndex = 48;
            this.label18.Text = "Egységár:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(322, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Mennyiség:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_price
            // 
            this.nud_price.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nud_price.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nud_price.ForeColor = System.Drawing.Color.Maroon;
            this.nud_price.Location = new System.Drawing.Point(418, 323);
            this.nud_price.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud_price.Name = "nud_price";
            this.nud_price.Size = new System.Drawing.Size(95, 20);
            this.nud_price.TabIndex = 52;
            this.nud_price.TabStop = false;
            this.nud_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud_amount_offer
            // 
            this.nud_amount_offer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nud_amount_offer.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nud_amount_offer.ForeColor = System.Drawing.Color.Maroon;
            this.nud_amount_offer.Location = new System.Drawing.Point(418, 297);
            this.nud_amount_offer.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud_amount_offer.Name = "nud_amount_offer";
            this.nud_amount_offer.Size = new System.Drawing.Size(95, 20);
            this.nud_amount_offer.TabIndex = 50;
            this.nud_amount_offer.TabStop = false;
            this.nud_amount_offer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(321, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(298, 33);
            this.label7.TabIndex = 49;
            this.label7.Text = "Ajánlattétel";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_offer
            // 
            this.bt_offer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_offer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_offer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_offer.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_offer.ForeColor = System.Drawing.Color.Maroon;
            this.bt_offer.Location = new System.Drawing.Point(519, 297);
            this.bt_offer.Name = "bt_offer";
            this.bt_offer.Size = new System.Drawing.Size(100, 74);
            this.bt_offer.TabIndex = 47;
            this.bt_offer.TabStop = false;
            this.bt_offer.Text = "Megerősít";
            this.bt_offer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(22, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(597, 50);
            this.label4.TabIndex = 34;
            this.label4.Text = "Piaci ajánlatok";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(19, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 33);
            this.label5.TabIndex = 45;
            this.label5.Text = "Vásárlás";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(9, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_market
            // 
            this.nud_market.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nud_market.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nud_market.ForeColor = System.Drawing.Color.Maroon;
            this.nud_market.Location = new System.Drawing.Point(69, 298);
            this.nud_market.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud_market.Name = "nud_market";
            this.nud_market.Size = new System.Drawing.Size(90, 20);
            this.nud_market.TabIndex = 35;
            this.nud_market.TabStop = false;
            this.nud_market.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 611);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lb_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MarketForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarketForm";
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marketplace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount_offer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_market)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_header;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgv_marketplace;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nud_delete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_offer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_price;
        private System.Windows.Forms.NumericUpDown nud_amount_offer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_offer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_market;
    }
}