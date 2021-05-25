namespace Szakdolgozat_RZD
{
    partial class NewMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMessageForm));
            this.tb_message = new System.Windows.Forms.TextBox();
            this.bt_message_send = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cb_country_list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.lb_text_length = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(89, 67);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_message.Size = new System.Drawing.Size(384, 169);
            this.tb_message.TabIndex = 2;
            // 
            // bt_message_send
            // 
            this.bt_message_send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_message_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_message_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_message_send.ForeColor = System.Drawing.Color.Maroon;
            this.bt_message_send.Location = new System.Drawing.Point(12, 67);
            this.bt_message_send.Name = "bt_message_send";
            this.bt_message_send.Size = new System.Drawing.Size(70, 25);
            this.bt_message_send.TabIndex = 3;
            this.bt_message_send.Text = "Küldés";
            this.bt_message_send.UseVisualStyleBackColor = true;
            // 
            // bt_exit
            // 
            this.bt_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_exit.ForeColor = System.Drawing.Color.Maroon;
            this.bt_exit.Location = new System.Drawing.Point(12, 211);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 25);
            this.bt_exit.TabIndex = 4;
            this.bt_exit.Text = "Mégsem";
            this.bt_exit.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(12, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 27);
            this.label20.TabIndex = 62;
            this.label20.Text = "Címzett:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_country_list
            // 
            this.cb_country_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_country_list.FormattingEnabled = true;
            this.cb_country_list.Location = new System.Drawing.Point(89, 13);
            this.cb_country_list.Name = "cb_country_list";
            this.cb_country_list.Size = new System.Drawing.Size(383, 21);
            this.cb_country_list.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 27);
            this.label1.TabIndex = 64;
            this.label1.Text = "Tárgy:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_subject
            // 
            this.tb_subject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_subject.Location = new System.Drawing.Point(88, 44);
            this.tb_subject.Multiline = true;
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(383, 20);
            this.tb_subject.TabIndex = 1;
            // 
            // lb_text_length
            // 
            this.lb_text_length.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_text_length.ForeColor = System.Drawing.Color.Maroon;
            this.lb_text_length.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_text_length.Location = new System.Drawing.Point(395, 239);
            this.lb_text_length.Name = "lb_text_length";
            this.lb_text_length.Size = new System.Drawing.Size(78, 13);
            this.lb_text_length.TabIndex = 65;
            this.lb_text_length.Text = "-";
            this.lb_text_length.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(90, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 1);
            this.panel1.TabIndex = 66;
            // 
            // NewMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_text_length);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_country_list);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_message_send);
            this.Controls.Add(this.tb_message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "NewMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Button bt_message_send;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cb_country_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label lb_text_length;
        private System.Windows.Forms.Panel panel1;
    }
}