
namespace Movie_Player
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pb_openfolder = new System.Windows.Forms.PictureBox();
            this.pb_start = new System.Windows.Forms.PictureBox();
            this.pb_exit = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.pb_next = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_openfolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_back)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_openfolder
            // 
            this.pb_openfolder.BackColor = System.Drawing.Color.Transparent;
            this.pb_openfolder.BackgroundImage = global::Movie_Player.Properties.Resources.folder_b_4;
            this.pb_openfolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_openfolder.Location = new System.Drawing.Point(0, 0);
            this.pb_openfolder.Name = "pb_openfolder";
            this.pb_openfolder.Size = new System.Drawing.Size(50, 50);
            this.pb_openfolder.TabIndex = 0;
            this.pb_openfolder.TabStop = false;
            // 
            // pb_start
            // 
            this.pb_start.BackColor = System.Drawing.Color.Transparent;
            this.pb_start.BackgroundImage = global::Movie_Player.Properties.Resources.play_b_2;
            this.pb_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_start.Location = new System.Drawing.Point(100, 0);
            this.pb_start.Name = "pb_start";
            this.pb_start.Size = new System.Drawing.Size(50, 50);
            this.pb_start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_start.TabIndex = 1;
            this.pb_start.TabStop = false;
            // 
            // pb_exit
            // 
            this.pb_exit.BackColor = System.Drawing.Color.Transparent;
            this.pb_exit.BackgroundImage = global::Movie_Player.Properties.Resources.exit_b_2;
            this.pb_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_exit.Location = new System.Drawing.Point(200, 0);
            this.pb_exit.Name = "pb_exit";
            this.pb_exit.Size = new System.Drawing.Size(50, 50);
            this.pb_exit.TabIndex = 2;
            this.pb_exit.TabStop = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Location = new System.Drawing.Point(250, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(50, 50);
            this.panel.TabIndex = 3;
            // 
            // pb_next
            // 
            this.pb_next.BackColor = System.Drawing.Color.Transparent;
            this.pb_next.BackgroundImage = global::Movie_Player.Properties.Resources.next_b_1;
            this.pb_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_next.Location = new System.Drawing.Point(150, 0);
            this.pb_next.Name = "pb_next";
            this.pb_next.Size = new System.Drawing.Size(50, 50);
            this.pb_next.TabIndex = 5;
            this.pb_next.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_back
            // 
            this.pb_back.BackColor = System.Drawing.Color.Transparent;
            this.pb_back.BackgroundImage = global::Movie_Player.Properties.Resources.back_b_1;
            this.pb_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_back.Location = new System.Drawing.Point(50, 0);
            this.pb_back.Name = "pb_back";
            this.pb_back.Size = new System.Drawing.Size(50, 50);
            this.pb_back.TabIndex = 7;
            this.pb_back.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 70);
            this.Controls.Add(this.pb_back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_next);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pb_exit);
            this.Controls.Add(this.pb_start);
            this.Controls.Add(this.pb_openfolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Movie Player";
            ((System.ComponentModel.ISupportInitialize)(this.pb_openfolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_openfolder;
        private System.Windows.Forms.PictureBox pb_start;
        private System.Windows.Forms.PictureBox pb_exit;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pb_next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_back;
    }
}

