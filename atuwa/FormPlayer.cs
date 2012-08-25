using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using JockerSoft.Media;

namespace atuwa
{
    public partial class FormPlayer : Form
    {
        DatabaseConnector dbc = new DatabaseConnector();
        List<string> lstIds = new List<string>();
        List<string> playList = new List<string>();
        List<string> playListPath = new List<string>();
        List<int> playstat = new List<int>();
        List<string> playThumbnail = new List<string>();
        Dictionary<int, string> playDic = new Dictionary<int, string>();
        List<string> lstNames = new List<string>();
        FormVideoInsert m = null;
        int count = 0;
        string dir = "";
        bool textDisplayed = false, segmentBarDisplayed = true;
        string commonOrUnique;
        public static bool insertComplete = true;

        public FormPlayer()
        {
            InitializeComponent();
            dir = Directory.GetCurrentDirectory();
            mediaPlayer.uiMode = "mini";
            timerDispaly.Start();
            //this.WindowState = FormWindowState.Maximized;

            // start server for setup
            try
            {
                File.Delete("C:\\Atuwa\\mongodbDatabase\\mongod.lock");
            }
            catch (Exception e)
            {

            }
            // testing
            String filePath = string.Format("\"{0}\"", "C:\\Atuwa\\mongodbDatabase\\bin\\mongod.exe");
            String argPath = string.Format("\"{0}\"", "C:\\Atuwa\\mongodbDatabase");
            Process p = new Process();
            p.StartInfo.FileName = filePath;
            p.StartInfo.Arguments = "--dbpath " + argPath;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

        }

        private void Player_Load(object sender, EventArgs e)
        {
            labelVideoName.Text = "ATUWA Video Redundancy Manger";
            commonOrUnique = "";
            loaddata();
        }

        private void listBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVideos.DataSource != null)
            {
                pictureBoxCurrentVideo1.Image = null;
                pictureBoxCurrentVideo2.Image = null;
                pictureBoxCurrentVideo3.Image = null;
                pictureBoxCurrentVideo4.Image = null;

                playListPath = new List<string>();
                playDic.Clear();
                mediaPlayer.currentPlaylist.clear();
                count = 0;
                playstat.Clear();
                playThumbnail.Clear();
                int selectedindex = listBoxVideos.SelectedIndex;
                string playTot;
                playTot = dbc.searchsegments(lstIds[selectedindex]);
                string[] s = playTot.Split('&');
                for (int i = 1; i < s.Length - 2; i = i + 3)
                {
                    playListPath.Add(s[i]);
                    int value;
                    string path = s[i];
                    string stat = s[i + 2];
                    int.TryParse(s[i + 1], out value);
                    playDic.Add(value, path + "&" + stat);
                }

                var list = playDic.Keys.ToList();
                list.Sort();

                foreach (var key in list)
                {
                    string[] pathandstat = playDic[key].Split('&');
                    mediaPlayer.currentPlaylist.appendItem(mediaPlayer.newMedia(pathandstat[0]));
                    playstat.Add(Int32.Parse(pathandstat[1]));
                    playThumbnail.Add(pathandstat[0]);
                }
                labelVideoName.Text = listBoxVideos.SelectedValue.ToString();
            }
            //loaddata();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (insertComplete)
            {
                insertComplete = false;
                if (m != null)
                {
                    m.Dispose();
                    m = null;
                }
                m = new FormVideoInsert(this);
                m.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Insetion is in progress.");
            }
        }
        public void loaddata()
        {
           
          
            string getStr = dbc.searchvideo();
            string[] sec = getStr.Split('#');
            lstNames.Clear();
            lstIds.Clear();
            for (int i = 1; i < sec.Length - 2; i = i + 3)
            {
                lstNames.Add(sec[i]);
                lstIds.Add(sec[i + 2]);
            }
            listBoxVideos.DataSource = null;
            listBoxVideos.Update();
            listBoxVideos.DataSource = lstNames;
            listBoxVideos.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAbout aboutDialog = new FormAbout();
            aboutDialog.Visible = true;
        }
        public void refreshall() {


            loaddata();
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            FormStatistics st = new FormStatistics(dbc.getstat(lstIds[listBoxVideos.SelectedIndex]), (playListPath.Count), lstNames[listBoxVideos.SelectedIndex]);
            st.Visible = true;
        }

        private void mediaPlayer_CurrentItemChange_1(object sender, AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent e)
        {
            if (playstat.Count > 0 && count < playstat.Count)
            {
                try
                {
                    
                    Bitmap image4 = FrameGrabber.GetFrameFromVideo(playThumbnail[count], 0.1d);
                    Graphics g4 = Graphics.FromImage(image4);
                    SolidBrush brush4 = new SolidBrush(Color.White);
                    g4.DrawString("Segment no:" + (count + 1).ToString(), new Font("Arial", 24), brush4, new PointF(10, 2));
                    pictureBoxCurrentVideo4.Image = image4;
                    brush4.Dispose();
                    g4.Dispose();

                    Bitmap image3 = FrameGrabber.GetFrameFromVideo(playThumbnail[count - 1], 0.1d);
                    Graphics g3 = Graphics.FromImage(image3);
                    SolidBrush brush3 = new SolidBrush(Color.White);
                    g3.DrawString("Segment no:" + (count).ToString(), new Font("Arial", 24), brush3, new PointF(10, 2));
                    pictureBoxCurrentVideo3.Image = image3;
                    brush3.Dispose();
                    g3.Dispose();

                    Bitmap image2 = FrameGrabber.GetFrameFromVideo(playThumbnail[count - 2], 0.1d);
                    Graphics g2 = Graphics.FromImage(image2);
                    SolidBrush brush2 = new SolidBrush(Color.White);
                    g2.DrawString("Segment no:" + (count - 1).ToString(), new Font("Arial", 24), brush2, new PointF(10, 2));
                    pictureBoxCurrentVideo2.Image = image2;
                    brush2.Dispose();
                    g2.Dispose();

                    Bitmap image1 = FrameGrabber.GetFrameFromVideo(playThumbnail[count - 3], 0.1d);
                    Graphics g1 = Graphics.FromImage(image1);
                    SolidBrush brush1 = new SolidBrush(Color.White);
                    g1.DrawString("Segment no:" + (count - 2).ToString(), new Font("Arial", 24), brush1, new PointF(10, 2));
                    pictureBoxCurrentVideo1.Image = image1;
                    brush1.Dispose();
                    g1.Dispose();
                }
                catch (Exception ex)
                {
                }
                
                if (playstat[count] == 0)
                {
                    labelCount.ForeColor = Color.Red;
                    commonOrUnique = "Unique to this Video";
                    labelCount.Text = commonOrUnique;
                    
                }
                else
                {
                    labelCount.ForeColor = Color.Green;
                    commonOrUnique = "Common Segment";
                    labelCount.Text = commonOrUnique;
                    
                }
                count++;
            }
            else
            {
                pictureBoxCurrentVideo1.Image = null;
                pictureBoxCurrentVideo2.Image = null;
                pictureBoxCurrentVideo3.Image = null;
                pictureBoxCurrentVideo4.Image = null;
                count = 0;
            }
        }

        private void timerDispaly_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (textDisplayed)
                {
                    labelCount.Hide();
                    textDisplayed = false;
                }
                else
                {
                    if (listBoxVideos.Items.Count > 0) { labelCount.Show(); }
                    textDisplayed = true;
                }
            }
        }

        private void mediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ((e.newState == 1)||(e.newState==8)) { labelCount.Text = ""; }
            if (e.newState == 3) { labelCount.Text = commonOrUnique; }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (segmentBarDisplayed)
            {
                tableLayoutPanelPlayer.Location = new Point(0, panelHeader.Height);
                tableLayoutPanelPlayer.Height += tableLayoutPanelSegments.Height;
                segmentBarDisplayed = false;
            }
            else
            {
                tableLayoutPanelPlayer.Location = new Point(0, panelHeader.Height + tableLayoutPanelSegments.Height);
                tableLayoutPanelPlayer.Height -= tableLayoutPanelSegments.Height;
                segmentBarDisplayed = true;
            }
        }
    }
}
