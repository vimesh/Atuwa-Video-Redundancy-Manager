namespace atuwa
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBoxAbout = new System.Windows.Forms.PictureBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.linkLabelWebSite = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAbout
            // 
            this.pictureBoxAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxAbout.BackgroundImage")));
            this.pictureBoxAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAbout.Location = new System.Drawing.Point(72, 12);
            this.pictureBoxAbout.Name = "pictureBoxAbout";
            this.pictureBoxAbout.Size = new System.Drawing.Size(242, 85);
            this.pictureBoxAbout.TabIndex = 0;
            this.pictureBoxAbout.TabStop = false;
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(106, 116);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(180, 78);
            this.labelAbout.TabIndex = 1;
            this.labelAbout.Text = "ATUWA Video Redundancy Manger\r\nVersion: 1.0\r\n\r\n\r\n\r\nFind about the Atuwa project f" +
                "rom";
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelWebSite
            // 
            this.linkLabelWebSite.AutoSize = true;
            this.linkLabelWebSite.Location = new System.Drawing.Point(137, 203);
            this.linkLabelWebSite.Name = "linkLabelWebSite";
            this.linkLabelWebSite.Size = new System.Drawing.Size(109, 13);
            this.linkLabelWebSite.TabIndex = 2;
            this.linkLabelWebSite.TabStop = true;
            this.linkLabelWebSite.Text = "Atuwa official website";
            this.linkLabelWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebSite_LinkClicked);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 242);
            this.Controls.Add(this.linkLabelWebSite);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.pictureBoxAbout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Atuwa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAbout;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.LinkLabel linkLabelWebSite;
    }
}