namespace Szakdolgozat_RZD
{
    partial class SentMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SentMessageForm));
            this.lb_date = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.lb_sender = new System.Windows.Forms.Label();
            this.lb_subject = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lb_read_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_date
            // 
            this.lb_date.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_date.ForeColor = System.Drawing.Color.Maroon;
            this.lb_date.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_date.Location = new System.Drawing.Point(88, 10);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(384, 27);
            this.lb_date.TabIndex = 54;
            this.lb_date.Text = "-";
            this.lb_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 27);
            this.label3.TabIndex = 53;
            this.label3.Text = "Üzenet:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(88, 94);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.ReadOnly = true;
            this.tb_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_message.Size = new System.Drawing.Size(384, 156);
            this.tb_message.TabIndex = 52;
            this.tb_message.TabStop = false;
            // 
            // lb_sender
            // 
            this.lb_sender.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_sender.ForeColor = System.Drawing.Color.Maroon;
            this.lb_sender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_sender.Location = new System.Drawing.Point(88, 37);
            this.lb_sender.Name = "lb_sender";
            this.lb_sender.Size = new System.Drawing.Size(384, 27);
            this.lb_sender.TabIndex = 51;
            this.lb_sender.Text = "-";
            this.lb_sender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_subject
            // 
            this.lb_subject.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_subject.ForeColor = System.Drawing.Color.Maroon;
            this.lb_subject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_subject.Location = new System.Drawing.Point(88, 64);
            this.lb_subject.Name = "lb_subject";
            this.lb_subject.Size = new System.Drawing.Size(384, 27);
            this.lb_subject.TabIndex = 50;
            this.lb_subject.Text = "-";
            this.lb_subject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 27);
            this.label2.TabIndex = 49;
            this.label2.Text = "Dátum:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 27);
            this.label1.TabIndex = 48;
            this.label1.Text = "Tárgy:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(12, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 27);
            this.label20.TabIndex = 47;
            this.label20.Text = "Címzett:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_read_status
            // 
            this.lb_read_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_read_status.Font = new System.Drawing.Font("Georgia", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_read_status.ForeColor = System.Drawing.Color.Maroon;
            this.lb_read_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_read_status.Location = new System.Drawing.Point(12, 220);
            this.lb_read_status.Name = "lb_read_status";
            this.lb_read_status.Size = new System.Drawing.Size(70, 30);
            this.lb_read_status.TabIndex = 55;
            this.lb_read_status.Text = "-";
            this.lb_read_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SentMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.lb_read_status);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.lb_sender);
            this.Controls.Add(this.lb_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "SentMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Label lb_sender;
        private System.Windows.Forms.Label lb_subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lb_read_status;
    }
}