using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Threading;

namespace atuwa
{
    public partial class FormVideoInsert : Form
    {
        string path = "";
        FormPlayer ply = new FormPlayer();
        FileVideoSource fileSource=null;
        DatabaseConnector db = new DatabaseConnector();
        FormSegmentSig fm;
        string parent = null;

        public FormVideoInsert(FormPlayer ply)
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.ply = ply;
            //openFileDialog1.Filter = "*.mpg|*.m2ts|*.avi|*.wmv|*.mp4|*.asf|*.mkv|*.webm|*.ogv|*.3gp";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                fileSource = new FileVideoSource(openFileDialog1.FileName);
                textBoxVideoPath.Text = openFileDialog1.FileName;
                textBoxVideoPath.Enabled = false;
                VideoConverter vdc = new VideoConverter();
                path = openFileDialog1.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButtonDemoMode.Checked == true)
            {
                if ((textBoxVideoName.Text.Length > 0) && (textBoxVideoPath.Text.Length>0))
                {
                    
                    if (!db.checkvideo(textBoxVideoName.Text))
                    {
                        Random random = new Random();
                        int ran = random.Next(9000, 9500);

                        this.Enabled = false;
                        bgWorkerDemo.RunWorkerAsync();
                        bgWorkerDemo.WorkerReportsProgress = true;

                        while (this.bgWorkerDemo.IsBusy)
                        {


                            progressBar.CreateGraphics().DrawString("Converting Video.... ", new Font("Arial", (float)10.0, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 100, progressBar.Height / 2 - 12));
                            if (progressBar.Value < ran)
                                progressBar.Increment(1);

                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Same Video name found in the database");
                    }
                }
                else
                {
                    MessageBox.Show("Please, give both video name and file path", "Warning");
                }
            }
            else
            {
                if ((textBoxVideoName.Text.Length > 0) && (textBoxVideoPath.Text.Length > 0))
                {
                    if (!db.checkvideo(textBoxVideoName.Text))
                    {
                        Random random = new Random();
                        int ran = random.Next(9000, 9500);


                        bgWorkerUser.RunWorkerAsync();
                        bgWorkerUser.WorkerReportsProgress = true;

                        while (this.bgWorkerUser.IsBusy)
                        {


                            progressBar.CreateGraphics().DrawString("Converting video.... ", new Font("Arial", (float)10.0, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 100, progressBar.Height / 2 - 12));
                            if (progressBar.Value < ran)
                                progressBar.Increment(1);

                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Same Video name found in the database");
                    }
                }
                else
                {
                    MessageBox.Show("Please, give both video name and file path", "Warning");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxVideoName.Clear();
            textBoxVideoPath.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void bgWorkerDemo_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            parent = db.addVideo(textBoxVideoName.Text, textBoxVideoPath.Text, dateNow.ToString());

            VideoConverter vdc = new VideoConverter();
            path = vdc.Convert(path);
            fileSource = new FileVideoSource(path);
            //td.Suspend();
            
            
        }

        private void bgWorkerDemo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerDemo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fm = new FormSegmentSig(fileSource, path, parent, false, this.ply);
            fm.Visible = true;
            this.Visible = false;
        }

        private void bgWorkerUser_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            parent = db.addVideo(textBoxVideoName.Text, textBoxVideoPath.Text, dateNow.ToString());
            VideoConverter vdc = new VideoConverter();
            path = vdc.Convert(path);
            fileSource = new FileVideoSource(path);
            
        }

        private void bgWorkerUser_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fm = new FormSegmentSig(fileSource, path, parent, true, this.ply);
            ply.Visible = true;
            this.Visible = false;
        }
    }
}
