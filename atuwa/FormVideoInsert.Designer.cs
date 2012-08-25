namespace atuwa
{
    partial class FormVideoInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVideoInsert));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxVideoPath = new System.Windows.Forms.TextBox();
            this.labelVideoPath = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxVideoName = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxVideoInsert = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.groupBoxModeSelect = new System.Windows.Forms.GroupBox();
            this.radioButtonUser = new System.Windows.Forms.RadioButton();
            this.radioButtonDemoMode = new System.Windows.Forms.RadioButton();
            this.bgWorkerDemo = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerUser = new System.ComponentModel.BackgroundWorker();
            this.groupBoxVideoInsert.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.groupBoxModeSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBrowse.Location = new System.Drawing.Point(634, 88);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxVideoPath
            // 
            this.textBoxVideoPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVideoPath.Location = new System.Drawing.Point(132, 90);
            this.textBoxVideoPath.Name = "textBoxVideoPath";
            this.textBoxVideoPath.Size = new System.Drawing.Size(492, 20);
            this.textBoxVideoPath.TabIndex = 1;
            // 
            // labelVideoPath
            // 
            this.labelVideoPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVideoPath.AutoSize = true;
            this.labelVideoPath.Location = new System.Drawing.Point(49, 93);
            this.labelVideoPath.Name = "labelVideoPath";
            this.labelVideoPath.Size = new System.Drawing.Size(59, 13);
            this.labelVideoPath.TabIndex = 2;
            this.labelVideoPath.Text = "Video Path";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsert.Location = new System.Drawing.Point(663, 100);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(93, 23);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(49, 173);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Video Name";
            // 
            // textBoxVideoName
            // 
            this.textBoxVideoName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVideoName.Location = new System.Drawing.Point(132, 170);
            this.textBoxVideoName.Name = "textBoxVideoName";
            this.textBoxVideoName.Size = new System.Drawing.Size(492, 20);
            this.textBoxVideoName.TabIndex = 5;
            this.textBoxVideoName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(634, 241);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBoxVideoInsert
            // 
            this.groupBoxVideoInsert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxVideoInsert.Controls.Add(this.textBoxVideoPath);
            this.groupBoxVideoInsert.Controls.Add(this.buttonBrowse);
            this.groupBoxVideoInsert.Controls.Add(this.buttonClear);
            this.groupBoxVideoInsert.Controls.Add(this.textBoxVideoName);
            this.groupBoxVideoInsert.Controls.Add(this.labelVideoPath);
            this.groupBoxVideoInsert.Controls.Add(this.labelName);
            this.groupBoxVideoInsert.Location = new System.Drawing.Point(28, 31);
            this.groupBoxVideoInsert.Name = "groupBoxVideoInsert";
            this.groupBoxVideoInsert.Size = new System.Drawing.Size(727, 286);
            this.groupBoxVideoInsert.TabIndex = 8;
            this.groupBoxVideoInsert.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(-1, 499);
            this.progressBar.Maximum = 10000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(786, 33);
            this.progressBar.TabIndex = 9;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelButtons.Controls.Add(this.buttonInsert);
            this.panelButtons.Controls.Add(this.groupBoxModeSelect);
            this.panelButtons.Location = new System.Drawing.Point(-1, 359);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(786, 145);
            this.panelButtons.TabIndex = 10;
            // 
            // groupBoxModeSelect
            // 
            this.groupBoxModeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxModeSelect.Controls.Add(this.radioButtonUser);
            this.groupBoxModeSelect.Controls.Add(this.radioButtonDemoMode);
            this.groupBoxModeSelect.Location = new System.Drawing.Point(29, 30);
            this.groupBoxModeSelect.Name = "groupBoxModeSelect";
            this.groupBoxModeSelect.Size = new System.Drawing.Size(727, 47);
            this.groupBoxModeSelect.TabIndex = 12;
            this.groupBoxModeSelect.TabStop = false;
            this.groupBoxModeSelect.Text = "Select the mode";
            // 
            // radioButtonUser
            // 
            this.radioButtonUser.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonUser.AutoSize = true;
            this.radioButtonUser.Location = new System.Drawing.Point(433, 19);
            this.radioButtonUser.Name = "radioButtonUser";
            this.radioButtonUser.Size = new System.Drawing.Size(77, 17);
            this.radioButtonUser.TabIndex = 12;
            this.radioButtonUser.Text = "User Mode";
            this.radioButtonUser.UseVisualStyleBackColor = true;
            // 
            // radioButtonDemoMode
            // 
            this.radioButtonDemoMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonDemoMode.AutoSize = true;
            this.radioButtonDemoMode.Checked = true;
            this.radioButtonDemoMode.Location = new System.Drawing.Point(191, 19);
            this.radioButtonDemoMode.Name = "radioButtonDemoMode";
            this.radioButtonDemoMode.Size = new System.Drawing.Size(83, 17);
            this.radioButtonDemoMode.TabIndex = 11;
            this.radioButtonDemoMode.TabStop = true;
            this.radioButtonDemoMode.Text = "Demo Mode";
            this.radioButtonDemoMode.UseVisualStyleBackColor = true;
            // 
            // bgWorkerDemo
            // 
            this.bgWorkerDemo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDemo_DoWork);
            this.bgWorkerDemo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerDemo_ProgressChanged);
            this.bgWorkerDemo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDemo_RunWorkerCompleted);
            // 
            // bgWorkerUser
            // 
            this.bgWorkerUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerUser_DoWork);
            this.bgWorkerUser.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerUser_ProgressChanged);
            this.bgWorkerUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerUser_RunWorkerCompleted);
            // 
            // FormVideoInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxVideoInsert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 570);
            this.Name = "FormVideoInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atuwa VRM";
            this.groupBoxVideoInsert.ResumeLayout(false);
            this.groupBoxVideoInsert.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.groupBoxModeSelect.ResumeLayout(false);
            this.groupBoxModeSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxVideoPath;
        private System.Windows.Forms.Label labelVideoPath;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxVideoName;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxVideoInsert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.GroupBox groupBoxModeSelect;
        private System.Windows.Forms.RadioButton radioButtonUser;
        private System.Windows.Forms.RadioButton radioButtonDemoMode;
        private System.ComponentModel.BackgroundWorker bgWorkerDemo;
        private System.ComponentModel.BackgroundWorker bgWorkerUser;
    }
}