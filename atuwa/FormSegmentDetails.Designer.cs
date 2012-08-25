namespace atuwa
{
    partial class FormSegmentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSegmentDetails));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInsertSelected = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonInsertAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1Node1 = new System.Windows.Forms.Label();
            this.label1Node4 = new System.Windows.Forms.Label();
            this.label1Node5 = new System.Windows.Forms.Label();
            this.label1Node6 = new System.Windows.Forms.Label();
            this.label1Node7 = new System.Windows.Forms.Label();
            this.label1Node2 = new System.Windows.Forms.Label();
            this.label1Node3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bgWorknsertAll = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(5, 56);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(773, 233);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Segment ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Segment Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "          ";
            // 
            // buttonInsertSelected
            // 
            this.buttonInsertSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertSelected.Enabled = false;
            this.buttonInsertSelected.Location = new System.Drawing.Point(506, 13);
            this.buttonInsertSelected.Name = "buttonInsertSelected";
            this.buttonInsertSelected.Size = new System.Drawing.Size(139, 23);
            this.buttonInsertSelected.TabIndex = 5;
            this.buttonInsertSelected.Text = "Insert Selected Segment";
            this.buttonInsertSelected.UseVisualStyleBackColor = true;
            this.buttonInsertSelected.Click += new System.EventHandler(this.button1_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 291);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(387, 237);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // buttonInsertAll
            // 
            this.buttonInsertAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertAll.Location = new System.Drawing.Point(651, 13);
            this.buttonInsertAll.Name = "buttonInsertAll";
            this.buttonInsertAll.Size = new System.Drawing.Size(130, 23);
            this.buttonInsertAll.TabIndex = 9;
            this.buttonInsertAll.Text = "Insert All Segments";
            this.buttonInsertAll.UseVisualStyleBackColor = true;
            this.buttonInsertAll.Click += new System.EventHandler(this.InsertAllbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.buttonInsertAll);
            this.panel1.Controls.Add(this.buttonInsertSelected);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 49);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(389, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 237);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(-3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 246);
            this.panel2.TabIndex = 12;
            // 
            // label1Node1
            // 
            this.label1Node1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node1.Location = new System.Drawing.Point(536, 305);
            this.label1Node1.Name = "label1Node1";
            this.label1Node1.Size = new System.Drawing.Size(91, 43);
            this.label1Node1.TabIndex = 13;
            this.label1Node1.Text = " ";
            this.label1Node1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node4
            // 
            this.label1Node4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node4.Location = new System.Drawing.Point(401, 463);
            this.label1Node4.Name = "label1Node4";
            this.label1Node4.Size = new System.Drawing.Size(84, 43);
            this.label1Node4.TabIndex = 14;
            this.label1Node4.Text = " ";
            this.label1Node4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node5
            // 
            this.label1Node5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node5.Location = new System.Drawing.Point(495, 463);
            this.label1Node5.Name = "label1Node5";
            this.label1Node5.Size = new System.Drawing.Size(84, 43);
            this.label1Node5.TabIndex = 15;
            this.label1Node5.Text = " ";
            this.label1Node5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node6
            // 
            this.label1Node6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node6.Location = new System.Drawing.Point(592, 463);
            this.label1Node6.Name = "label1Node6";
            this.label1Node6.Size = new System.Drawing.Size(84, 43);
            this.label1Node6.TabIndex = 16;
            this.label1Node6.Text = " ";
            this.label1Node6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node7
            // 
            this.label1Node7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node7.Location = new System.Drawing.Point(684, 463);
            this.label1Node7.Name = "label1Node7";
            this.label1Node7.Size = new System.Drawing.Size(84, 43);
            this.label1Node7.TabIndex = 17;
            this.label1Node7.Text = " ";
            this.label1Node7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node2
            // 
            this.label1Node2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node2.Location = new System.Drawing.Point(444, 382);
            this.label1Node2.Name = "label1Node2";
            this.label1Node2.Size = new System.Drawing.Size(91, 43);
            this.label1Node2.TabIndex = 18;
            this.label1Node2.Text = " ";
            this.label1Node2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1Node3
            // 
            this.label1Node3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Node3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1Node3.Location = new System.Drawing.Point(630, 382);
            this.label1Node3.Name = "label1Node3";
            this.label1Node3.Size = new System.Drawing.Size(91, 43);
            this.label1Node3.TabIndex = 19;
            this.label1Node3.Text = " ";
            this.label1Node3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 509);
            this.progressBar.Maximum = 10000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(784, 23);
            this.progressBar.TabIndex = 20;
            // 
            // bgWorknsertAll
            // 
            this.bgWorknsertAll.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorknsertAll_DoWork);
            this.bgWorknsertAll.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorknsertAll_ProgressChanged);
            this.bgWorknsertAll.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorknsertAll_RunWorkerCompleted);
            // 
            // FormSegmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1Node1);
            this.Controls.Add(this.label1Node4);
            this.Controls.Add(this.label1Node5);
            this.Controls.Add(this.label1Node6);
            this.Controls.Add(this.label1Node3);
            this.Controls.Add(this.label1Node7);
            this.Controls.Add(this.label1Node2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 570);
            this.Name = "FormSegmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "segmentDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInsertSelected;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button buttonInsertAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1Node1;
        private System.Windows.Forms.Label label1Node4;
        private System.Windows.Forms.Label label1Node5;
        private System.Windows.Forms.Label label1Node6;
        private System.Windows.Forms.Label label1Node7;
        private System.Windows.Forms.Label label1Node2;
        private System.Windows.Forms.Label label1Node3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker bgWorknsertAll;
    }
}