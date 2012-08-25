namespace atuwa
{
    partial class FormPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayer));
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.addBtn = new System.Windows.Forms.Button();
            this.listBoxVideos = new System.Windows.Forms.ListBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayingSeg = new System.Windows.Forms.PictureBox();
            this.labelVideoName = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.timerDispaly = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCurrentVideo1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurrentVideo2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurrentVideo3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurrentVideo4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelSegments = new System.Windows.Forms.TableLayoutPanel();
            this.buttonHide = new System.Windows.Forms.Button();
            this.tableLayoutPanelPlayer = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayingSeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo4)).BeginInit();
            this.tableLayoutPanelSegments.SuspendLayout();
            this.tableLayoutPanelPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 12);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(551, 386);
            this.mediaPlayer.TabIndex = 1;
            this.mediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.mediaPlayer_PlayStateChange);
            this.mediaPlayer.CurrentItemChange += new AxWMPLib._WMPOCXEvents_CurrentItemChangeEventHandler(this.mediaPlayer_CurrentItemChange_1);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(340, 8);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(119, 33);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Insert Video";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // listBoxVideos
            // 
            this.listBoxVideos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxVideos.FormattingEnabled = true;
            this.listBoxVideos.Location = new System.Drawing.Point(551, 0);
            this.listBoxVideos.Name = "listBoxVideos";
            this.listBoxVideos.Size = new System.Drawing.Size(232, 485);
            this.listBoxVideos.TabIndex = 3;
            this.listBoxVideos.SelectedIndexChanged += new System.EventHandler(this.listBoxVideos_SelectedIndexChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panelHeader.Controls.Add(this.buttonStatistics);
            this.panelHeader.Controls.Add(this.button1);
            this.panelHeader.Controls.Add(this.addBtn);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(554, 48);
            this.panelHeader.TabIndex = 6;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStatistics.Location = new System.Drawing.Point(220, 8);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(114, 33);
            this.buttonStatistics.TabIndex = 3;
            this.buttonStatistics.Text = "View Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(465, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "About Atuwa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.BackgroundImage")));
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.Location = new System.Drawing.Point(11, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(139, 32);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxPlayingSeg
            // 
            this.pictureBoxPlayingSeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlayingSeg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlayingSeg.BackgroundImage")));
            this.pictureBoxPlayingSeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayingSeg.Location = new System.Drawing.Point(552, 484);
            this.pictureBoxPlayingSeg.Name = "pictureBoxPlayingSeg";
            this.pictureBoxPlayingSeg.Size = new System.Drawing.Size(232, 47);
            this.pictureBoxPlayingSeg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayingSeg.TabIndex = 7;
            this.pictureBoxPlayingSeg.TabStop = false;
            // 
            // labelVideoName
            // 
            this.labelVideoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVideoName.BackColor = System.Drawing.Color.Transparent;
            this.labelVideoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVideoName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelVideoName.Image = ((System.Drawing.Image)(resources.GetObject("labelVideoName.Image")));
            this.labelVideoName.Location = new System.Drawing.Point(561, 487);
            this.labelVideoName.Name = "labelVideoName";
            this.labelVideoName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVideoName.Size = new System.Drawing.Size(215, 21);
            this.labelVideoName.TabIndex = 8;
            this.labelVideoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCount.BackColor = System.Drawing.Color.Transparent;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.ForeColor = System.Drawing.Color.Green;
            this.labelCount.Image = ((System.Drawing.Image)(resources.GetObject("labelCount.Image")));
            this.labelCount.Location = new System.Drawing.Point(562, 509);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(213, 20);
            this.labelCount.TabIndex = 9;
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerDispaly
            // 
            this.timerDispaly.Interval = 500;
            this.timerDispaly.Tick += new System.EventHandler(this.timerDispaly_Tick);
            // 
            // pictureBoxCurrentVideo1
            // 
            this.pictureBoxCurrentVideo1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCurrentVideo1.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCurrentVideo1.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCurrentVideo1.Name = "pictureBoxCurrentVideo1";
            this.pictureBoxCurrentVideo1.Size = new System.Drawing.Size(131, 82);
            this.pictureBoxCurrentVideo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCurrentVideo1.TabIndex = 10;
            this.pictureBoxCurrentVideo1.TabStop = false;
            // 
            // pictureBoxCurrentVideo2
            // 
            this.pictureBoxCurrentVideo2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCurrentVideo2.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCurrentVideo2.Location = new System.Drawing.Point(140, 3);
            this.pictureBoxCurrentVideo2.Name = "pictureBoxCurrentVideo2";
            this.pictureBoxCurrentVideo2.Size = new System.Drawing.Size(131, 82);
            this.pictureBoxCurrentVideo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCurrentVideo2.TabIndex = 11;
            this.pictureBoxCurrentVideo2.TabStop = false;
            // 
            // pictureBoxCurrentVideo3
            // 
            this.pictureBoxCurrentVideo3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCurrentVideo3.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCurrentVideo3.Location = new System.Drawing.Point(277, 3);
            this.pictureBoxCurrentVideo3.Name = "pictureBoxCurrentVideo3";
            this.pictureBoxCurrentVideo3.Size = new System.Drawing.Size(131, 82);
            this.pictureBoxCurrentVideo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCurrentVideo3.TabIndex = 12;
            this.pictureBoxCurrentVideo3.TabStop = false;
            // 
            // pictureBoxCurrentVideo4
            // 
            this.pictureBoxCurrentVideo4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCurrentVideo4.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCurrentVideo4.Location = new System.Drawing.Point(414, 3);
            this.pictureBoxCurrentVideo4.Name = "pictureBoxCurrentVideo4";
            this.pictureBoxCurrentVideo4.Size = new System.Drawing.Size(134, 82);
            this.pictureBoxCurrentVideo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCurrentVideo4.TabIndex = 13;
            this.pictureBoxCurrentVideo4.TabStop = false;
            // 
            // tableLayoutPanelSegments
            // 
            this.tableLayoutPanelSegments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSegments.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelSegments.ColumnCount = 4;
            this.tableLayoutPanelSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSegments.Controls.Add(this.pictureBoxCurrentVideo1, 0, 0);
            this.tableLayoutPanelSegments.Controls.Add(this.pictureBoxCurrentVideo4, 3, 0);
            this.tableLayoutPanelSegments.Controls.Add(this.pictureBoxCurrentVideo2, 1, 0);
            this.tableLayoutPanelSegments.Controls.Add(this.pictureBoxCurrentVideo3, 2, 0);
            this.tableLayoutPanelSegments.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanelSegments.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSegments.Name = "tableLayoutPanelSegments";
            this.tableLayoutPanelSegments.RowCount = 1;
            this.tableLayoutPanelSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSegments.Size = new System.Drawing.Size(551, 88);
            this.tableLayoutPanelSegments.TabIndex = 14;
            // 
            // buttonHide
            // 
            this.buttonHide.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHide.Location = new System.Drawing.Point(0, 0);
            this.buttonHide.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(551, 10);
            this.buttonHide.TabIndex = 15;
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // tableLayoutPanelPlayer
            // 
            this.tableLayoutPanelPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPlayer.ColumnCount = 1;
            this.tableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayer.Controls.Add(this.mediaPlayer, 0, 1);
            this.tableLayoutPanelPlayer.Controls.Add(this.buttonHide, 0, 0);
            this.tableLayoutPanelPlayer.Location = new System.Drawing.Point(0, 133);
            this.tableLayoutPanelPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPlayer.Name = "tableLayoutPanelPlayer";
            this.tableLayoutPanelPlayer.RowCount = 2;
            this.tableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayer.Size = new System.Drawing.Size(551, 398);
            this.tableLayoutPanelPlayer.TabIndex = 16;
            // 
            // FormPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.Controls.Add(this.tableLayoutPanelPlayer);
            this.Controls.Add(this.tableLayoutPanelSegments);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelVideoName);
            this.Controls.Add(this.pictureBoxPlayingSeg);
            this.Controls.Add(this.listBoxVideos);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 570);
            this.Name = "FormPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.Load += new System.EventHandler(this.Player_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayingSeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentVideo4)).EndInit();
            this.tableLayoutPanelSegments.ResumeLayout(false);
            this.tableLayoutPanelPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ListBox listBoxVideos;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.PictureBox pictureBoxPlayingSeg;
        private System.Windows.Forms.Label labelVideoName;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Timer timerDispaly;
        private System.Windows.Forms.PictureBox pictureBoxCurrentVideo1;
        private System.Windows.Forms.PictureBox pictureBoxCurrentVideo2;
        private System.Windows.Forms.PictureBox pictureBoxCurrentVideo3;
        private System.Windows.Forms.PictureBox pictureBoxCurrentVideo4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSegments;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPlayer;
    }
}