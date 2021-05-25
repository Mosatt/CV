namespace Szakdolgozat_RZD
{
    partial class DiplomacyForm
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
            this.panel = new System.Windows.Forms.Panel();
            this.lb_header = new System.Windows.Forms.Label();
            this.bt_new_message = new System.Windows.Forms.Button();
            this.bt_incoming = new System.Windows.Forms.Button();
            this.bt_sent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(165, 100);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 473);
            this.panel.TabIndex = 0;
            // 
            // lb_header
            // 
            this.lb_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_header.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_header.ForeColor = System.Drawing.Color.Maroon;
            this.lb_header.Location = new System.Drawing.Point(165, 47);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(800, 50);
            this.lb_header.TabIndex = 55;
            this.lb_header.Text = "Bejövő üzenetek:";
            this.lb_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_new_message
            // 
            this.bt_new_message.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_new_message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_new_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_new_message.ForeColor = System.Drawing.Color.Maroon;
            this.bt_new_message.Location = new System.Drawing.Point(14, 100);
            this.bt_new_message.Name = "bt_new_message";
            this.bt_new_message.Size = new System.Drawing.Size(145, 50);
            this.bt_new_message.TabIndex = 58;
            this.bt_new_message.Text = "Üzenet írás";
            this.bt_new_message.UseVisualStyleBackColor = true;
            // 
            // bt_incoming
            // 
            this.bt_incoming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_incoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_incoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_incoming.ForeColor = System.Drawing.Color.Maroon;
            this.bt_incoming.Location = new System.Drawing.Point(14, 156);
            this.bt_incoming.Name = "bt_incoming";
            this.bt_incoming.Size = new System.Drawing.Size(145, 50);
            this.bt_incoming.TabIndex = 59;
            this.bt_incoming.Text = "Bejövő üzenetek";
            this.bt_incoming.UseVisualStyleBackColor = true;
            // 
            // bt_sent
            // 
            this.bt_sent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_sent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_sent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_sent.ForeColor = System.Drawing.Color.Maroon;
            this.bt_sent.Location = new System.Drawing.Point(14, 212);
            this.bt_sent.Name = "bt_sent";
            this.bt_sent.Size = new System.Drawing.Size(145, 50);
            this.bt_sent.TabIndex = 60;
            this.bt_sent.Text = "Elküldött üzenetek";
            this.bt_sent.UseVisualStyleBackColor = true;
            // 
            // DiplomacyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 611);
            this.Controls.Add(this.bt_sent);
            this.Controls.Add(this.bt_incoming);
            this.Controls.Add(this.bt_new_message);
            this.Controls.Add(this.lb_header);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiplomacyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lb_header;
        private System.Windows.Forms.Button bt_new_message;
        private System.Windows.Forms.Button bt_incoming;
        private System.Windows.Forms.Button bt_sent;
    }
}