namespace ZBase
{
    partial class Menu
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
            this.DiscordBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BunnyhopCheck = new System.Windows.Forms.CheckBox();
            this.GithubBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ESPCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DiscordBTN
            // 
            this.DiscordBTN.Location = new System.Drawing.Point(12, 35);
            this.DiscordBTN.Name = "DiscordBTN";
            this.DiscordBTN.Size = new System.Drawing.Size(166, 23);
            this.DiscordBTN.TabIndex = 0;
            this.DiscordBTN.Text = "Join Discord (Remove Me)";
            this.DiscordBTN.UseVisualStyleBackColor = true;
            this.DiscordBTN.Click += new System.EventHandler(this.DiscordBTN_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thanks for checking out ZBase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BunnyhopCheck
            // 
            this.BunnyhopCheck.AutoSize = true;
            this.BunnyhopCheck.Location = new System.Drawing.Point(12, 129);
            this.BunnyhopCheck.Name = "BunnyhopCheck";
            this.BunnyhopCheck.Size = new System.Drawing.Size(194, 17);
            this.BunnyhopCheck.TabIndex = 2;
            this.BunnyhopCheck.Text = "Bunny Hop (Space) - Sample Cheat";
            this.BunnyhopCheck.UseVisualStyleBackColor = true;
            // 
            // GithubBTN
            // 
            this.GithubBTN.Location = new System.Drawing.Point(203, 35);
            this.GithubBTN.Name = "GithubBTN";
            this.GithubBTN.Size = new System.Drawing.Size(166, 23);
            this.GithubBTN.TabIndex = 4;
            this.GithubBTN.Text = "Github Page (Remove Me)";
            this.GithubBTN.UseVisualStyleBackColor = true;
            this.GithubBTN.Click += new System.EventHandler(this.GithubBTN_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "A function to show/hide the menu is already integrated. use Insert\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Have Fun! - Coopyy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ESPCheck
            // 
            this.ESPCheck.AutoSize = true;
            this.ESPCheck.Location = new System.Drawing.Point(12, 152);
            this.ESPCheck.Name = "ESPCheck";
            this.ESPCheck.Size = new System.Drawing.Size(86, 17);
            this.ESPCheck.TabIndex = 7;
            this.ESPCheck.Text = "Overlay ESP";
            this.ESPCheck.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 187);
            this.Controls.Add(this.ESPCheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GithubBTN);
            this.Controls.Add(this.BunnyhopCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiscordBTN);
            this.Name = "Menu";
            this.Text = "ZBase New Project";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiscordBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox BunnyhopCheck;
        private System.Windows.Forms.Button GithubBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ESPCheck;
    }
}

