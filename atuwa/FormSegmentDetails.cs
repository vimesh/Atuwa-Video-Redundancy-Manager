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

namespace atuwa
{
    public partial class FormSegmentDetails : Form
    {
        FormPlayer ply = null;
        int time = 0;
        List<int> segmentend = new List<int>();
       public List<int> id = new List<int>();
        List<string> pathlist = new List<string>();
        DataTable table = new DataTable();
        DataTable temp = new DataTable();
        List<int> segmentinglocations = new List<int>();
        string path = "";
        string parentid = "";

        public FormSegmentDetails(DataTable table, List<int> id, List<int> segmentinglocations, List<string> pathlist, string parentid, List<int> segmentend, FormPlayer ply )
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.id = id;
            comboBox1.DataSource = this.id;
            this.table = table;
            this.segmentinglocations = segmentinglocations;
            this.pathlist = pathlist;
            this.parentid = parentid;
            this.segmentend = segmentend;
            this.ply = ply;
        }
            
        public FormSegmentDetails(DataTable table, List<int> id, List<int> segmentinglocations, List<string> pathlist, string parentid, List<int> segmentend, Boolean auto)
        {
            this.Visible = false;
            this.id = id;
          
            this.table = table;
            this.segmentinglocations = segmentinglocations;
            this.pathlist = pathlist;
            this.parentid = parentid;
            this.segmentend = segmentend;
            insertvideo();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                genaratetable(comboBox1.SelectedIndex, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Segment Number");
            }
        }



        private void genaratetable(int selectedindex,Boolean auto) {

            DataTable table2 = createtable();
            temp = null;
           if(!auto) dataGridView.DataSource = null;
            string[] columnNames = new string[10];
            int i = 0;
            foreach (DataColumn column in table.Columns)
            {
                columnNames[i] = column.ColumnName;
                i++;
            }

            if (i != 0)
            {
                //MessageBox.Show(comboBox1.SelectedIndex.ToString());
                time = (int.Parse(segmentend.ToArray()[selectedindex].ToString()) - int.Parse(segmentinglocations.ToArray()[selectedindex].ToString()));
                if (!auto) label3.Text = time.ToString();
                DataRow[] result = table.Select(columnNames[0] + "=" + (selectedindex + 1).ToString());
                foreach (DataRow row in result)
                {
                    table2.Rows.Add(row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());

                }
                path = pathlist.ElementAt(selectedindex);
                if (!auto)
                { // MessageBox.Show(p);
                    axWindowsMediaPlayer1.close();
                    axWindowsMediaPlayer1.currentPlaylist.clear();
                    axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(path));
                    buttonInsertSelected.Enabled = true;
                }
            }
            if (!auto) dataGridView.DataSource = table2;
            if (!auto) dataGridView.Columns[0].Width = 180;
            temp = table2;
            table2 = null;
        }

        private DataTable createtable() {
            DataTable table2 = new DataTable();
            table2.Columns.Add(new DataColumn("Signature type", typeof(string)));
            table2.Columns.Add(new DataColumn("Top Level Signature", typeof(string)));
            table2.Columns.Add(new DataColumn("2nd Level Signature I", typeof(string)));
            table2.Columns.Add(new DataColumn("2nd Level Signature II", typeof(string)));
            table2.Columns.Add(new DataColumn("3rd Level Signature I", typeof(string)));
            table2.Columns.Add(new DataColumn("3rd Level Signature II", typeof(string)));
            table2.Columns.Add(new DataColumn("3rd Level Signature III", typeof(string)));
            table2.Columns.Add(new DataColumn("3rd Level Signature IV", typeof(string)));

            return table2;
        }

        private void videoSourcePlayer_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FormVideoSegmentInsert isd = new FormVideoSegmentInsert(this, path, temp, (comboBox1.SelectedIndex + 1).ToString(),parentid,time);
           isd.Visible = true;
           this.Visible = false;
           FormPlayer.insertComplete = true;
        }

        public void insertvideo()
        {
            for (int i = 0; i < id.Count; i++) {

                genaratetable(id[i]-1,true);
                FormVideoSegmentInsert isd = new FormVideoSegmentInsert( path, temp, (id[i]).ToString(), parentid, time, true);
            }
            FormPlayer.insertComplete = true; 
        }

        private void InsertAllbtn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int ran = random.Next(9000, 9500);

            this.Enabled = false;
            bgWorknsertAll.RunWorkerAsync();
            bgWorknsertAll.WorkerReportsProgress = true;

            while (this.bgWorknsertAll.IsBusy)
            {
                progressBar.CreateGraphics().DrawString("Inserting Video.... ", new Font("Arial", (float)10.0, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 100, progressBar.Height / 2 - 12));
                if (progressBar.Value < ran)
                    progressBar.Increment(1);

                Application.DoEvents();
            }
        }

        private void bgWorknsertAll_DoWork(object sender, DoWorkEventArgs e)
        {
            insertvideo();
        }

        private void bgWorknsertAll_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bgWorknsertAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("All the segments added to the database");

            ply.Visible = true;
            ply.loaddata();

            this.Dispose();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRow[] rows = temp.Select();
            Point selected = dataGridView.CurrentCellAddress;
            DataRow row = rows[selected.Y];
            label1Node1.Text = row[1].ToString(); label1Node1.BackColor = Color.LightSteelBlue;
            label1Node2.Text = row[2].ToString(); label1Node2.BackColor = Color.LightSteelBlue;
            label1Node3.Text = row[3].ToString(); label1Node3.BackColor = Color.LightSteelBlue;
            label1Node4.Text = row[4].ToString(); label1Node4.BackColor = Color.LightSteelBlue;
            label1Node5.Text = row[5].ToString(); label1Node5.BackColor = Color.LightSteelBlue;
            label1Node6.Text = row[6].ToString(); label1Node6.BackColor = Color.LightSteelBlue;
            label1Node7.Text = row[7].ToString(); label1Node7.BackColor = Color.LightSteelBlue;
            if (selected.X == 1) label1Node1.BackColor = Color.Gold;
            else if (selected.X == 1) label1Node1.BackColor = Color.Gold;
            else if (selected.X == 2) label1Node2.BackColor = Color.Gold;
            else if (selected.X == 3) label1Node3.BackColor = Color.Gold;
            else if (selected.X == 4) label1Node4.BackColor = Color.Gold;
            else if (selected.X == 5) label1Node5.BackColor = Color.Gold;
            else if (selected.X == 6) label1Node6.BackColor = Color.Gold;
            else if (selected.X == 7) label1Node7.BackColor = Color.Gold;
        }
    }
}
