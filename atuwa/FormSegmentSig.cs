using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Imaging.Filters;
using AForge.Vision.Motion;
using System.Threading;
using System.IO;
using System.Media;

namespace atuwa
{
    public partial class FormSegmentSig : Form
    {
        FormPlayer ply = new FormPlayer();
        public Bitmap temp = null;
        public Bitmap temp2 = null;
        public Bitmap tempStatCent = null;
        public Bitmap tempStatMotion = null;
        public Bitmap clred = null;
        public Bitmap clgreen = null;
        public Bitmap clblue = null;

        string path="";
        string parentid = "";
        int counter = 0; int total = 0; int segmentid = 0;

        List<float> motion = new List<float>();
        List<int> id = new List<int>();
        List<int> segmentinglocations = new List<int>();
        List<int> segmentend = new List<int>();
        List<string> asr = null;
        
        DataTable table = new DataTable("signature");
        ColorPart colorp = new ColorPart();
        Centroid cent = new Centroid();
        Boolean segmentingcomplete = false;
        MotionLevel s = new MotionLevel();
        Splitter split = new Splitter();
        MotionDetector detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionAreaHighlighting());
        Boolean auto = false;
        IVideoSource source = null;
        private bool pause = false;
        private int slow = 0;
        String dir;

        public FormSegmentSig(IVideoSource source, string path, string parentid, Boolean auto, FormPlayer ply)
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            setcomponent();
            OpenVideoSource(source);
            this.path = path;
            this.parentid = parentid;
            this.auto = auto;
           if(auto) this.Visible = false;
           this.ply = ply;
           this.source = source;
           dir = Directory.GetCurrentDirectory();
        }
       
        private void videoSourcePlayer_Click(object sender, EventArgs e)
        {

        }
        private void OpenVideoSource(IVideoSource source)
        {
         
            this.Cursor = Cursors.WaitCursor;
            // stop current video source
            CloseCurrentVideoSource();
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();
            this.Cursor = Cursors.Default;
        }

        private void CloseCurrentVideoSource()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                
                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!videoSourcePlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.Stop();
                }
               

                videoSourcePlayer.VideoSource = null;
            }
        }
      
        

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            while (pause)
            {


                Thread.Sleep(1000);

            }
            if (slow > 0)
            {
                Thread.Sleep(slow);


            }

            if (videoSourcePlayer.GetCurrentVideoFrame()!=null)
            {
               
                clred = new Bitmap(image);
                clblue = new Bitmap(image);
                clgreen = new Bitmap(image);
                temp = new Bitmap(image);
                temp2 = new Bitmap(temp);
               
               Bitmap motionb=new Bitmap(videoSourcePlayer.GetCurrentVideoFrame());
                
              
                  
                if (detector != null)
            {
                tempStatMotion = new Bitmap(dir + "/Images/black.png");
                float motionLevel = s.genaratmotionlevel(ref motionb, total, this.Font);
                motion.Add(motionLevel);
                s.drawStat(motionLevel, ref tempStatMotion);
                    
                counter++; // current segment frame counter
                total++;// total frame counter
                    //snap short for current segment starting frame
                if (counter == 2) {

                    Bitmap segments = new Bitmap(videoSourcePlayer.GetCurrentVideoFrame());
                             Graphics gg = Graphics.FromImage(segments);

                            // paint current time
                         SolidBrush brush2 = new SolidBrush(Color.White);


                         gg.DrawString("Segment no:" +segmentid, new Font("Arial", 24), brush2, new PointF(10, 2));
                         //pictureBox3.Image = segments;
                         brush2.Dispose();
                         gg.Dispose();

                         changepic(segments);
                
                
                }

                 //get color leve signature
                //Console.WriteLine(colorp.generateColorPart(image, ref clred, ref clgreen, ref clblue));
                colorp.generateColorPart(image, ref clred, ref clgreen, ref clblue);
                pictureBox2.Image = motionb;
                pictureBoxMotionSeg.Image = motionb;

                //get centroid
                tempStatCent = new Bitmap(dir + "/Images/black.png");
                Boolean ber = cent.generateCentroid(ref temp2, ref tempStatCent);
                pictureBox1.Image = temp2;
                pictureBoxCentroidSeg.Image = temp2;
                pictureBoxCentStat.Image = tempStatCent;
                pictureBoxMotionStat.Image = tempStatMotion;

                if ((motionLevel > 4500 || ber) && counter > 25)
                {
                    if(!auto) SystemSounds.Beep.Play();
                    segmentinglocations.Add(total - counter);
                    segmentid++;
                    id.Add(segmentid);
                   //MessageBox.Show("new segment detected from" + (total - counter).ToString() + "to" + (total).ToString()+" average motion levels");
                    float[] arr = s.getSignature(motion);
                   table.Rows.Add(segmentid, "motion level", arr[0].ToString(), arr[1].ToString(), arr[2].ToString(), arr[3].ToString(), arr[4].ToString(), arr[5].ToString(), arr[6].ToString());
                    int [,,] arrcent =cent.getSignature();

                    table.Rows.Add(segmentid, "centroid brightest x value ", arrcent[0, 0, 0].ToString(), arrcent[1, 0, 0].ToString(), arrcent[2, 0, 0].ToString(), arrcent[3, 0, 0].ToString(), arrcent[4, 0, 0].ToString(), arrcent[5, 0, 0].ToString(), arrcent[6, 0, 0].ToString());
                    table.Rows.Add(segmentid, "centroid brightest y value ", arrcent[0, 1, 0].ToString(), arrcent[1, 1, 0].ToString(), arrcent[2, 1, 0].ToString(), arrcent[3, 1, 0].ToString(), arrcent[4, 1, 0].ToString(), arrcent[5, 1, 0].ToString(), arrcent[6, 1, 0].ToString());
                    table.Rows.Add(segmentid, "centroid darkest x value ", arrcent[0, 0, 1].ToString(), arrcent[1, 0, 1].ToString(), arrcent[2, 0, 1].ToString(), arrcent[3, 0, 1].ToString(), arrcent[4, 0, 1].ToString(), arrcent[5, 0, 1].ToString(), arrcent[6, 0, 1].ToString());
                    table.Rows.Add(segmentid, "centroid darkest y value ", arrcent[0, 1, 1].ToString(), arrcent[1, 1, 1].ToString(), arrcent[2, 1, 1].ToString(), arrcent[3, 1, 1].ToString(), arrcent[4, 1, 1].ToString(), arrcent[5, 1, 1].ToString(), arrcent[6, 1, 1].ToString());

                    int[, , ,] arrcolor = colorp.getColorPart();
                    table.Rows.Add(segmentid, "color level red value ", getvalue(arrcolor, 0, 0), getvalue(arrcolor, 1, 0), getvalue(arrcolor, 2, 0), getvalue(arrcolor, 3, 0), getvalue(arrcolor, 4, 0), getvalue(arrcolor, 5, 0), getvalue(arrcolor, 6, 0));
                    table.Rows.Add(segmentid, "color level green value ", getvalue(arrcolor, 0, 1), getvalue(arrcolor, 1, 1), getvalue(arrcolor, 2, 1), getvalue(arrcolor, 3, 1), getvalue(arrcolor, 4, 1), getvalue(arrcolor, 5, 1), getvalue(arrcolor, 6, 1));
                    table.Rows.Add(segmentid, "color level blue value ", getvalue(arrcolor, 0, 2), getvalue(arrcolor, 1, 2), getvalue(arrcolor, 2, 2), getvalue(arrcolor, 3, 2), getvalue(arrcolor, 4, 2), getvalue(arrcolor, 5, 2), getvalue(arrcolor, 6, 2));
                    segmentend.Add(total );
                    counter = 0;
                    motion = new List<float>();
                    
                }
                pictureBox7.Image = temp;
                pictureBox4.Image = clred;
                pictureBox5.Image = clgreen;
                pictureBox6.Image = clblue;
                        


                  

                
            }

            }
        }

        private void pictureBox1_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void videoSourcePlayer_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {
            //changepic();
            segmentinglocations.Add(total - counter);
            segmentid++;
            id.Add(segmentid);
            //MessageBox.Show("new segment detected from" + (total - counter).ToString() + "to" + (total).ToString() + " average motion levels");
            float[] arr = s.getSignature(motion);
            table.Rows.Add(segmentid, "motion level", arr[0].ToString(), arr[1].ToString(), arr[2].ToString(), arr[3].ToString(), arr[4].ToString(), arr[5].ToString(), arr[6].ToString());
            int[, ,] arrcent = cent.getSignature();

            table.Rows.Add(segmentid, "centroid brightest x value ", arrcent[0, 0, 0].ToString(), arrcent[1, 0, 0].ToString(), arrcent[2, 0, 0].ToString(), arrcent[3, 0, 0].ToString(), arrcent[4, 0, 0].ToString(), arrcent[5, 0, 0].ToString(), arrcent[6, 0, 0].ToString());
            table.Rows.Add(segmentid, "centroid brightest y value ", arrcent[0, 1, 0].ToString(), arrcent[1, 1, 0].ToString(), arrcent[2, 1, 0].ToString(), arrcent[3, 1, 0].ToString(), arrcent[4, 1, 0].ToString(), arrcent[5, 1, 0].ToString(), arrcent[6, 1, 0].ToString());
            table.Rows.Add(segmentid, "centroid darkest x value ", arrcent[0, 0, 1].ToString(), arrcent[1, 0, 1].ToString(), arrcent[2, 0, 1].ToString(), arrcent[3, 0, 1].ToString(), arrcent[4, 0, 1].ToString(), arrcent[5, 0, 1].ToString(), arrcent[6, 0, 1].ToString());
            table.Rows.Add(segmentid, "centroid darkest y value ", arrcent[0, 1, 1].ToString(), arrcent[1, 1, 1].ToString(), arrcent[2, 1, 1].ToString(), arrcent[3, 1, 1].ToString(), arrcent[4, 1, 1].ToString(), arrcent[5, 1, 1].ToString(), arrcent[6, 1, 1].ToString());

            int[, , ,] arrcolor = colorp.getColorPart();
            table.Rows.Add(segmentid, "color level red value ", getvalue(arrcolor, 0, 0), getvalue(arrcolor, 1, 0), getvalue(arrcolor, 2, 0), getvalue(arrcolor, 3, 0), getvalue(arrcolor, 4, 0), getvalue(arrcolor, 5, 0), getvalue(arrcolor, 6, 0));
            table.Rows.Add(segmentid, "color level green value ", getvalue(arrcolor, 0, 1), getvalue(arrcolor, 1, 1), getvalue(arrcolor, 2, 1), getvalue(arrcolor, 3, 1), getvalue(arrcolor, 4, 1), getvalue(arrcolor, 5, 1), getvalue(arrcolor, 6, 1));
            table.Rows.Add(segmentid, "color level blue value ", getvalue(arrcolor, 0, 2), getvalue(arrcolor, 1, 2), getvalue(arrcolor, 2, 2), getvalue(arrcolor, 3, 2), getvalue(arrcolor, 4, 2), getvalue(arrcolor, 5, 2), getvalue(arrcolor, 6, 2));
            segmentend.Add(total);
            segmentingcomplete = true;

            if (!auto)
            {
                //progressBarSegmentation.Style = ProgressBarStyle.Blocks;
                //progressBarSegmentation.Value = progressBarSegmentation.Maximum;
                MessageBox.Show("Video segmentation completed. ");
            }
            if(auto)  insertall();
            Application.ExitThread();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (segmentingcomplete)
            {
                Random random = new Random();
                int ran = random.Next(9000, 9500);

                this.Enabled = false;
                bgWorkerViewSegment.RunWorkerAsync();
                bgWorkerViewSegment.WorkerReportsProgress = true;

                while (this.bgWorkerViewSegment.IsBusy)
                {


                    progressBar.CreateGraphics().DrawString("Spliting video.... ", new Font("Arial", (float)10.0, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 100, progressBar.Height / 2 - 12));
                    if (progressBar.Value < ran)
                        progressBar.Increment(1);

                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show("Please wait untill segmentation complete", "Warning");
            }
            
        }
        private string getvalue(int[, , ,] arrcolor,int x,int y)
        {
            string val = arrcolor[x, 0, 0, y].ToString() + " " + arrcolor[x, 1, 0, y].ToString() + " " + arrcolor[x, 2, 0, y].ToString() + " " + arrcolor[x, 3, 0, y].ToString() + " " + arrcolor[x, 0, 1, y].ToString() + " " + arrcolor[x, 1, 1, y].ToString() + " " + arrcolor[x, 2, 1, y].ToString() + " " + arrcolor[x, 3, 1, y].ToString() + " " + arrcolor[x, 0, 2, y].ToString() + " " + arrcolor[x, 1, 2, y].ToString() + " " + arrcolor[x, 2, 2, y].ToString() + " " + arrcolor[x, 3, 2, y].ToString() + " " + arrcolor[x, 0, 3, y].ToString() + " " + arrcolor[x, 1, 3, y].ToString() + " " + arrcolor[x, 2, 3, y].ToString() + " " + arrcolor[x, 3, 3, y].ToString();
            return val;
        }

        private void InsertAllbtn_Click(object sender, EventArgs e)
        {
            if (segmentingcomplete)
            {
                Random random = new Random();
                int ran = random.Next(9000, 9500);

                this.Enabled = false;
                bgWorkerInsertAll.RunWorkerAsync();
                bgWorkerInsertAll.WorkerReportsProgress = true;

                while (this.bgWorkerInsertAll.IsBusy)
                {


                    progressBar.CreateGraphics().DrawString("Inserting video.... ", new Font("Arial", (float)10.0, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 100, progressBar.Height / 2 - 12));
                    if (progressBar.Value < ran)
                        progressBar.Increment(1);

                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show("Please Wait Untill Segmentation Complete", "Warning");
            }
        }
        private void changepic(Bitmap segments)
        {
                last_pic5.Image = last_pic4.Image;
                last_pic4.Image = last_pic3.Image;
                last_pic3.Image = last_pic2.Image;
                last_pic2.Image = last_pic1.Image;
                last_pic1.Image = segments;
        }
        public void setcomponent() {
            //System.Threading.Thread.Sleep(2000);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMotionSeg.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCentroidSeg.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.CenterImage;
            last_pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            last_pic2.SizeMode = PictureBoxSizeMode.StretchImage;
            last_pic3.SizeMode = PictureBoxSizeMode.StretchImage;
            last_pic4.SizeMode = PictureBoxSizeMode.StretchImage;
            last_pic5.SizeMode = PictureBoxSizeMode.StretchImage;
            last_pic1.Image = null;
            last_pic2.Image = null;
            last_pic3.Image = null;
            last_pic4.Image = null;
            last_pic5.Image = null;
            // create signature table
            table.Columns.Add(new DataColumn("signatureid", typeof(int)));
            table.Columns.Add(new DataColumn("name", typeof(string)));
            table.Columns.Add(new DataColumn("top", typeof(string)));
            table.Columns.Add(new DataColumn("top1", typeof(string)));
            table.Columns.Add(new DataColumn("top2", typeof(string)));
            table.Columns.Add(new DataColumn("top21", typeof(string)));
            table.Columns.Add(new DataColumn("top22", typeof(string)));
            table.Columns.Add(new DataColumn("top23", typeof(string)));
            table.Columns.Add(new DataColumn("top24", typeof(string)));
            
            
        
        }






        public void insertall() {
            if (segmentingcomplete)
            {
                segmentinglocations.RemoveAt(0);
                List<string> asr = split.split(segmentinglocations, path);
                segmentinglocations.Add(0);
                segmentinglocations.Sort();



                //VideoConverterCutter vdc = new VideoConverterCutter();
                //segmentinglocations.Add(segmentend.Max());
                //List<string> asr = vdc.Cut(path, segmentinglocations, parentid.ToString());
                //segmentinglocations.Remove(segmentend.Max());
                FormSegmentDetails seg = new FormSegmentDetails(table, id, segmentinglocations, asr, parentid, segmentend, true);
               
                


            }
            else
            {
                MessageBox.Show("Please wait untill segmentation complete", "Warning");
            }
        }

        private void buttonReplay_Click(object sender, EventArgs e)
        {
            if (segmentingcomplete)
            {
                temp = null;
                temp2 = null;
                clred = null;
                clgreen = null;
                clblue = null;


                counter = 0; total = 0; segmentid = 0;

                motion = new List<float>();
                id = new List<int>();
                segmentinglocations = new List<int>();
                segmentend = new List<int>();
                table = null;
                table = new DataTable("signature");

                segmentingcomplete = false;

                auto = false;
                setcomponent();
                OpenVideoSource(source);
                segmentingcomplete = false;
            }

            else
            {
                MessageBox.Show("Please wait. Segmentation is in progress.");
            }

        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (pause) { pause = false; buttonPause.Text = "Pause"; }
            else { pause = true; buttonPause.Text = "Play"; }
        }

        private void buttonSlow_Click(object sender, EventArgs e)
        {
            if (slow == 0)
            {

                slow = 40;
            }
            else
            {

                slow = slow * 2;
            }
        }

        private void buttonFast_Click(object sender, EventArgs e)
        {
            if (slow == 0)
            {


            }
            else
            {

                slow = slow / 2;
            }

        }

        private void bgWorkerViewSegment_DoWork(object sender, DoWorkEventArgs e)
        {
            segmentinglocations.RemoveAt(0);
            asr = split.split(segmentinglocations, path);
            segmentinglocations.Add(0);
            segmentinglocations.Sort();
            
        }

        private void bgWorkerViewSegment_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerViewSegment_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormSegmentDetails seg = new FormSegmentDetails(table, id, segmentinglocations, asr, parentid, segmentend, ply);
            seg.Visible = true;
            this.Dispose();
        }

        private void bgWorkerInsertAll_DoWork(object sender, DoWorkEventArgs e)
        {
            segmentinglocations.RemoveAt(0);
            asr = split.split(segmentinglocations, path);
            segmentinglocations.Add(0);
            segmentinglocations.Sort();
        }

        private void bgWorkerInsertAll_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerInsertAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormSegmentDetails seg = new FormSegmentDetails(table, id, segmentinglocations, asr, parentid, segmentend, true);
            ply.refreshall();
            progressBar.Value = progressBar.Maximum;
            //if (!auto) MessageBox.Show("All the segments added to the database");
            ply.Visible = true;
            this.Dispose();
        }
    }
}
