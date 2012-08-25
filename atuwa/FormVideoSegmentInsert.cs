using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System.IO;

namespace atuwa
{
    public partial class FormVideoSegmentInsert : Form
    {
        List<string> matschsegments2 = new List<string>();
        String temppath = "";
        Boolean setinsert = true;
        int segmenttime;
        int selectedid = -1;
        MotionLevel s = new MotionLevel();
        ColorPart colorp = new ColorPart();
        Centroid cent = new Centroid();
        MotionLevel s2 = new MotionLevel();
        ColorPart colorp2 = new ColorPart();
        Centroid cent2 = new Centroid();
        MotionDetector detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionAreaHighlighting());
        Boolean flag = false;
        DataTable table = new DataTable();
        String path = "";
        string orderid = "";
        string parentid="";
        List<string> matschsegments = new List<string>();
        DatabaseConnector db = new DatabaseConnector();
        FormSegmentDetails ivd = null;
        Boolean auto = false;
        Bitmap right, wrong;

        public FormVideoSegmentInsert(FormSegmentDetails ivd, string path, DataTable table, string orderid, string parentid, int segmenttime)
        {
            
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ivd = ivd;
            this.path = path;
            this.table = table;
            this.orderid = orderid;
            this.parentid = parentid;
            List<string> st = new List<string>();
            st.Add("Motion Level");
            st.Add("Color Level R");
            st.Add("Color Level B");
            st.Add("Color Level G");
            st.Add("Centroid Dark");
            st.Add("Centroid Light");
            comboBox2.DataSource = st;
            this.segmenttime = segmenttime;
            matschsegments = db.searchsegmentstime(segmenttime);
            right = new Bitmap(Directory.GetCurrentDirectory() + "/Images/right.png");
            wrong = new Bitmap(Directory.GetCurrentDirectory() + "/Images/wrong.png");

            if (matschsegments.Count == 0)
            {
                buttonInsert.Enabled = true;
                listBoxScenes.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                //comboBox1.DataSource = matschsegments;
                listBoxScenes.DataSource = matschsegments;
                buttonTop.Enabled = true;
                //comboBox1.Enabled = true;
                listBoxScenes.Enabled = true;
                comboBox2.Enabled = true;
            }

        }

        public FormVideoSegmentInsert( string path, DataTable table, string orderid, string parentid, int segmenttime,Boolean auto)
        {

            InitializeComponent();

            this.ivd = ivd;
            this.path = path;
            this.table = table;
            this.orderid = orderid;
            this.parentid = parentid;
            List<string> st = new List<string>();
            this.auto = auto;
            this.segmenttime = segmenttime;
            autoinsert();

        }

        private void OpenVideoSource1(IVideoSource source)
        {

            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
            videoSourcePlayer1.VideoSource = source;
            videoSourcePlayer1.Start();



            this.Cursor = Cursors.Default;
        }
        private void CloseCurrentVideoSource1()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                videoSourcePlayer1.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!videoSourcePlayer1.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (videoSourcePlayer1.IsRunning)
                {
                    videoSourcePlayer1.Stop();
                }


                videoSourcePlayer1.VideoSource = null;
            }
        }
      
        private void OpenVideoSource(IVideoSource source)
        {

            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
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
      
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBoxInsert.BackgroundImage = right;
            insert();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            //comboBox1.Enabled = false;
            listBoxScenes.Enabled = false;
            addtoplevel();
            if (matschsegments.Count == 0)
            {
                buttonInsert.Enabled = true;
                listBoxScenes.Enabled = false;
                comboBox2.Enabled = false;
                pictureBoxTop.BackgroundImage = wrong;
                pictureBoxSecond.BackgroundImage = wrong;
                pictureBoxThird.BackgroundImage = wrong;
                //buttonViewTree.Enabled = false;
            }
            else
            {
                //comboBox1.DataSource = matschsegments2;
                listBoxScenes.DataSource = matschsegments2;
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                //comboBox1.DataSource = matschsegments;
                listBoxScenes.DataSource = matschsegments;
                buttonSecond.Enabled = true;
                comboBox2.Enabled = true;
                //comboBox1.Enabled = true;
                listBoxScenes.Enabled = true;
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                pictureBoxTop.BackgroundImage = right;
            }
            buttonTop.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ivd.Visible = true;
            this.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
              //  MessageBox.Show(comboBox1.SelectedValue.ToString());
                //FileVideoSource fileSource = new FileVideoSource(comboBox1.SelectedValue.ToString());
                FileVideoSource fileSource = new FileVideoSource(listBoxScenes.SelectedValue.ToString());
                FileVideoSource fileSource2 = new FileVideoSource(path);
                OpenVideoSource1(fileSource);
                OpenVideoSource(fileSource2);
                selectedid = comboBox2.SelectedIndex;
            }
            else {
                flag = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap b = new Bitmap(image);
            Bitmap c = new Bitmap(image);
            Bitmap d = new Bitmap(image);
            if (selectedid == 0)
            {

                s.genaratmotionlevel(ref b, this.Font);

            }
            else if (selectedid == 1)
            {
                colorp.generateColorPart(image, ref b, ref d, ref c);

            }
            else if (selectedid == 2)
            {

                colorp.generateColorPart(image, ref d, ref b, ref c);
            }
            else if (selectedid == 3)
            {
                colorp.generateColorPart(image, ref c, ref b, ref b);

            }
            else
            {

                cent.generateCentroid(ref b);
            }
            pictureBox1.Image = new Bitmap(b);

        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap b = new Bitmap(image);
            Bitmap c = new Bitmap(image);
            Bitmap d = new Bitmap(image);
            if (selectedid == 0)
            {

                s2.genaratmotionlevel(ref b, this.Font);

            }
            else if (selectedid == 1)
            {
                colorp2.generateColorPart(image, ref b, ref d, ref c);

            }
            else if (selectedid == 2)
            {

                colorp2.generateColorPart(image, ref d, ref b, ref c);
            }
            else if (selectedid == 3)
            {
                colorp2.generateColorPart(image, ref c, ref b, ref b);

            }
            else
            {

                cent2.generateCentroid(ref b);
            }
            pictureBox2.Image = new Bitmap(b);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonTop.Enabled = false;
            addsecondlevel();
            if (matschsegments.Count == 0)
            {
                buttonInsert.Enabled = true;
                listBoxScenes.Enabled = false;
                comboBox2.Enabled = false;
                pictureBoxSecond.BackgroundImage = wrong;
                pictureBoxSecond.BackgroundImage = wrong;
                //buttonViewTree.Enabled = false;
            }
            else
            {
                //comboBox1.DataSource = matschsegments2;
                listBoxScenes.DataSource = matschsegments2;
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                //comboBox1.DataSource = matschsegments;
                listBoxScenes.DataSource = matschsegments;
                buttonThird.Enabled = true;
                comboBox2.Enabled = true;
                //comboBox1.Enabled = true;
                listBoxScenes.Enabled = true;
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                //setinsert = false;
                //path = matschsegments[0];
                //  button4.Enabled = true;
                pictureBoxSecond.BackgroundImage = right;
            }
            buttonSecond.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonThird.Enabled = false;
            buttonSecond.Enabled = false;
            addthredlevel();
            if (matschsegments.Count == 0)
            {
                buttonInsert.Enabled = true;
                listBoxScenes.Enabled = false;
                comboBox2.Enabled = false;
                pictureBoxThird.BackgroundImage = wrong;
                //buttonViewTree.Enabled = false;
            }
            else
            {
                //comboBox1.DataSource = matschsegments2;
                listBoxScenes.DataSource = matschsegments2;
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                setinsert = false;
                //comboBox1.DataSource = matschsegments;
                listBoxScenes.DataSource = matschsegments;
                buttonInsert.Enabled = true;
                listBoxScenes.Enabled = false;
                comboBox2.Enabled = false;
                //comboBox1.Enabled = true;
                listBoxScenes.Enabled = true;
                temppath = path;
                path = matschsegments.First();
                //comboBox1.Refresh();
                listBoxScenes.Refresh();
                pictureBoxThird.BackgroundImage = right;
            }
            buttonThird.Enabled = false;
        }
        private void addtoplevel() {
            DataRow[] result = table.Select();
            string[] arr = new string[8];
            int i = 0;
            foreach (DataRow row in result)
            {
                arr[i] = row[1].ToString();
                i++;
            }
            //MessageBox.Show(arr[0] + "#" + arr[1] + "#" + arr[2] + "#" + arr[3] + "#" + arr[4] + "#" + arr[5] + "#" + arr[6] + "#" + arr[7] + "#" + parentid + "#" + path + "#" + orderid);
            matschsegments = db.toplevelsearch(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], matschsegments);
        
        
        }
        private void addsecondlevel() {


            DataRow[] result = table.Select();
            string[] arr = new string[16];
            int i = 0;
            foreach (DataRow row in result)
            {
                arr[i] = row[2].ToString();
                arr[8 + i] = row[3].ToString();
                i++;
            }
            // MessageBox.Show(arr[0] + "#" + arr[1] + "#" + arr[2] + "#" + arr[3] + "#" + arr[4] + "#" + arr[5] + "#" + arr[6] + "#" + arr[7] + "#" + parentid + "#" + path + "#" + orderid);
            matschsegments = db.secondlevelsearch(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8], arr[9], arr[10], arr[11], arr[12], arr[13], arr[14], arr[15], matschsegments);
        }
        private void addthredlevel(){

            DataRow[] result = table.Select();
            string[] arr = new string[32];
            int i = 0;
            foreach (DataRow row in result)
            {
                arr[i] = row[4].ToString();
                arr[8 + i] = row[5].ToString();
                arr[16 + i] = row[6].ToString();
                arr[24 + i] = row[7].ToString();
                i++;
            }

            matschsegments = db.Thiredlevelsearch(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8], arr[9], arr[10], arr[11], arr[12], arr[13], arr[14], arr[15], arr[16], arr[17], arr[18], arr[19], arr[20], arr[21], arr[22], arr[23], arr[24], arr[25], arr[26], arr[27], arr[28], arr[29], arr[30], arr[31], matschsegments);
        
        }
        private void insert()
        {
            if (!db.checksegments(parentid, path, orderid))
            {
                
                if (setinsert)
                {
                    db.addsegment(parentid, path, orderid,0);
                    DataRow[] result = table.Select();
                    int i = 0;
                    Boolean b = true;
                    foreach (DataRow row in result)
                    {
                        if (i == 0)
                            b = db.addmotionlevel(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 1)
                            b = db.addCentroidLightX(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 2)
                            b = db.addCentroidLightY(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 3)
                            b = db.addCentroidDarkX(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 4)
                            b = db.addCentroidDarkY(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 5)
                            b = db.addColorLevelRed(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 6)
                            b = db.addColorLevelGreen(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        else if (i == 7)
                            b = db.addColorLevelBlue(path, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                       

                        i++;
                        if (!b) { MessageBox.Show("error at" + i); }
                    }
                    db.addsegmenttime(path, segmenttime);
                    //if (!auto) MessageBox.Show("No, similer segment  found in the database new segment  added to the collection"); 
                }
                else
                {
                    db.addsegment(parentid, path, orderid,1);
                    //if (!auto) MessageBox.Show("similer video found in the database new segment deletaed and added a index to that excisting video");
                    db.stat(path);
                    File.Delete(temppath);
                }
                
              
            }
            else
            {
               //if(!auto) MessageBox.Show("previously you have added this segment");
            }
            if (!auto) ivd.Visible = true;
            if (!auto) this.Dispose();
        }

        private void autoinsert() {
            matschsegments = db.searchsegmentstime(segmenttime);
            if (matschsegments.Count == 0)
            {
                insert();

            }
            else
            {
                addtoplevel();
                if (matschsegments.Count == 0)
                {
                    insert();

                }
                else
                {
                    addsecondlevel();
                    if (matschsegments.Count == 0)
                    {
                        insert();

                    }
                    else
                    {

                        addthredlevel();
                        if (matschsegments.Count == 0)
                        {
                            insert();

                        }
                        else
                        {
                            setinsert = false;
                            temppath = path;
                            path = matschsegments.First();
                            insert();

                        }
                    }
                }
            }
        }

        private void listBoxScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //comboBox2.Enabled = true;
        }

        private void buttonViewTree_Click(object sender, EventArgs e)
        {
            if (listBoxScenes.Items.Count > 0)
            {
                FormSegmentComparison segComparison = new FormSegmentComparison(table, db.getsegmentdetails(listBoxScenes.SelectedValue.ToString()));
                segComparison.Show();
            }
            else
            {
                MessageBox.Show("No Any Identified Clips in list");
            }
        }

    }
}
