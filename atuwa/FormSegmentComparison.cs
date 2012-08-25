using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace atuwa
{
    public partial class FormSegmentComparison : Form
    {
        string[] signatureValus;
        DataTable table;
        DataRow[] result;

        public FormSegmentComparison(DataTable table, string segmentDetails)
        {
            InitializeComponent();
            this.signatureValus = segmentDetails.Split('#');
            this.table = table;
            result = table.Select();
            
            loadMotionDetails();
        }

        private void buttonMotion_Click(object sender, EventArgs e)
        {
            loadMotionDetails();
        }

        private void buttonColorR_Click(object sender, EventArgs e)
        {
            reset();
            buttonColorR.BackColor = Color.White;

            DataRow row = result[5];
            string[] array = row[1].ToString().Split(' ');
            labelI11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[2].ToString().Split(' ');
            labelI21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[3].ToString().Split(' ');
            labelI31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = row[4].ToString().Split(' ');
            labelI41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[5].ToString().Split(' ');
            labelI51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[6].ToString().Split(' ');
            labelI61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[7].ToString().Split(' ');
            labelI71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];

            array = signatureValus[22].Split(' ');
            labelE11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[23].Split(' ');
            labelE21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[24].Split(' ');
            labelE31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = signatureValus[25].Split(' ');
            labelE41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[26].Split(' ');
            labelE51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[27].Split(' ');
            labelE61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[28].Split(' ');
            labelE71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
        }

        private void buttonColorG_Click(object sender, EventArgs e)
        {
            reset();
            buttonColorG.BackColor = Color.White;

            DataRow row = result[6];
            string[] array = row[1].ToString().Split(' ');
            labelI11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[2].ToString().Split(' ');
            labelI21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[3].ToString().Split(' ');
            labelI31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = row[4].ToString().Split(' ');
            labelI41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[5].ToString().Split(' ');
            labelI51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[6].ToString().Split(' ');
            labelI61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[7].ToString().Split(' ');
            labelI71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];

            array = signatureValus[15].Split(' ');
            labelE11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[16].Split(' ');
            labelE21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[17].Split(' ');
            labelE31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = signatureValus[18].Split(' ');
            labelE41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[19].Split(' ');
            labelE51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[20].Split(' ');
            labelE61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[21].Split(' ');
            labelE71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
        }

        private void buttonColorB_Click(object sender, EventArgs e)
        {
            reset();
            buttonColorB.BackColor = Color.White;

            DataRow row = result[7];
            string[] array = row[1].ToString().Split(' ');
            labelI11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[2].ToString().Split(' ');
            labelI21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[3].ToString().Split(' ');
            labelI31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = row[4].ToString().Split(' ');
            labelI41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[5].ToString().Split(' ');
            labelI51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[6].ToString().Split(' ');
            labelI61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = row[7].ToString().Split(' ');
            labelI71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelI72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelI73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelI74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];

            array = signatureValus[8].Split(' ');
            labelE11.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE12.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE13.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE14.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[9].Split(' ');
            labelE21.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE22.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE23.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE24.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[10].Split(' ');
            labelE31.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE32.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE33.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE34.Text = array[12] + ", " + array[13] + " " + array[14] + ", " + array[15];
            array = signatureValus[11].Split(' ');
            labelE41.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE42.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE43.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE44.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[12].Split(' ');
            labelE51.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE52.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE53.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE54.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[13].Split(' ');
            labelE61.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE62.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE63.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE64.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
            array = signatureValus[14].Split(' ');
            labelE71.Text = array[0] + ", " + array[1] + ", " + array[2] + ", " + array[3]; labelE72.Text = array[4] + ", " + array[5] + ", " + array[6] + ", " + array[7]; labelE73.Text = array[8] + ", " + array[9] + ", " + array[10] + ", " + array[11]; labelE74.Text = array[12] + ", " + array[13] + ", " + array[14] + ", " + array[15];
        }

        private void buttonCentroidBrightX_Click(object sender, EventArgs e)
        {
            reset();
            buttonCentroidBrightX.BackColor = Color.White;

            DataRow row = result[1];
            labelI12.Text = row[1].ToString();
            labelI22.Text = row[2].ToString();
            labelI32.Text = row[3].ToString();
            labelI42.Text = row[4].ToString();
            labelI52.Text = row[5].ToString();
            labelI62.Text = row[6].ToString();
            labelI72.Text = row[7].ToString();

            labelE12.Text = signatureValus[50];
            labelE22.Text = signatureValus[51];
            labelE32.Text = signatureValus[52];
            labelE42.Text = signatureValus[53];
            labelE52.Text = signatureValus[54];
            labelE62.Text = signatureValus[55];
            labelE72.Text = signatureValus[56];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
            buttonCentroidBrightY.BackColor = Color.White;

            DataRow row = result[2];
            labelI12.Text = row[1].ToString();
            labelI22.Text = row[2].ToString();
            labelI32.Text = row[3].ToString();
            labelI42.Text = row[4].ToString();
            labelI52.Text = row[5].ToString();
            labelI62.Text = row[6].ToString();
            labelI72.Text = row[7].ToString();

            labelE12.Text = signatureValus[29];
            labelE22.Text = signatureValus[30];
            labelE32.Text = signatureValus[31];
            labelE42.Text = signatureValus[32];
            labelE52.Text = signatureValus[33];
            labelE62.Text = signatureValus[34];
            labelE72.Text = signatureValus[35];
        }

        private void buttonCentroidDarkX_Click(object sender, EventArgs e)
        {
            reset();
            buttonCentroidDarkX.BackColor = Color.White;

            DataRow row = result[3];
            labelI12.Text = row[1].ToString();
            labelI22.Text = row[2].ToString();
            labelI32.Text = row[3].ToString();
            labelI42.Text = row[4].ToString();
            labelI52.Text = row[5].ToString();
            labelI62.Text = row[6].ToString();
            labelI72.Text = row[7].ToString();

            labelE12.Text = signatureValus[43];
            labelE22.Text = signatureValus[44];
            labelE32.Text = signatureValus[45];
            labelE42.Text = signatureValus[46];
            labelE52.Text = signatureValus[47];
            labelE62.Text = signatureValus[48];
            labelE72.Text = signatureValus[49];
        }

        private void buttonCentroidDarkY_Click(object sender, EventArgs e)
        {
            reset();
            buttonCentroidDarkY.BackColor = Color.White;

            DataRow row = result[4];
            labelI12.Text = row[1].ToString();
            labelI22.Text = row[2].ToString();
            labelI32.Text = row[3].ToString();
            labelI42.Text = row[4].ToString();
            labelI52.Text = row[5].ToString();
            labelI62.Text = row[6].ToString();
            labelI72.Text = row[7].ToString();

            labelE12.Text = signatureValus[36];
            labelE22.Text = signatureValus[37];
            labelE32.Text = signatureValus[38];
            labelE42.Text = signatureValus[39];
            labelE52.Text = signatureValus[40];
            labelE62.Text = signatureValus[41];
            labelE72.Text = signatureValus[42];
        }

        /*private void generateRaws()
        {
            DataRow[] result = table.Select();
            int i = 0;
            string[] motionArray = new string[7];
            foreach (DataRow row in result)
            {
                if (i == 0){
                    motionArray[0] = row[1].ToString();
                    motionArray[0] = row[2].ToString();
                    motionArray[0] = row[3].ToString();
                    row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                
                }
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
            }
        }*/

        private void reset()
        {
            labelI11.Text = ""; labelI12.Text = ""; labelI13.Text = ""; labelI14.Text = ""; labelE11.Text = ""; labelE12.Text = ""; labelE13.Text = ""; labelE14.Text = "";
            labelI21.Text = ""; labelI22.Text = ""; labelI23.Text = ""; labelI24.Text = ""; labelE21.Text = ""; labelE22.Text = ""; labelE23.Text = ""; labelE24.Text = "";
            labelI31.Text = ""; labelI32.Text = ""; labelI33.Text = ""; labelI34.Text = ""; labelE31.Text = ""; labelE32.Text = ""; labelE33.Text = ""; labelE34.Text = "";
            labelI41.Text = ""; labelI42.Text = ""; labelI43.Text = ""; labelI44.Text = ""; labelE41.Text = ""; labelE42.Text = ""; labelE43.Text = ""; labelE44.Text = "";
            labelI51.Text = ""; labelI52.Text = ""; labelI53.Text = ""; labelI54.Text = ""; labelE51.Text = ""; labelE52.Text = ""; labelE53.Text = ""; labelE54.Text = "";
            labelI61.Text = ""; labelI62.Text = ""; labelI63.Text = ""; labelI64.Text = ""; labelE61.Text = ""; labelE62.Text = ""; labelE63.Text = ""; labelE64.Text = "";
            labelI71.Text = ""; labelI72.Text = ""; labelI73.Text = ""; labelI74.Text = ""; labelE71.Text = ""; labelE72.Text = ""; labelE73.Text = ""; labelE74.Text = "";
            buttonMotion.BackColor = Color.WhiteSmoke;
            buttonColorR.BackColor = Color.WhiteSmoke;
            buttonColorG.BackColor = Color.WhiteSmoke;
            buttonColorB.BackColor = Color.WhiteSmoke;
            buttonCentroidBrightX.BackColor = Color.WhiteSmoke;
            buttonCentroidBrightY.BackColor = Color.WhiteSmoke;
            buttonCentroidDarkX.BackColor = Color.WhiteSmoke;
            buttonCentroidDarkY.BackColor = Color.WhiteSmoke;
        }

        private void loadMotionDetails()
        {
            reset();
            buttonMotion.BackColor = Color.White;

            DataRow row = result[0];
            labelI12.Text = row[1].ToString();
            labelI22.Text = row[2].ToString();
            labelI32.Text = row[3].ToString();
            labelI42.Text = row[4].ToString();
            labelI52.Text = row[5].ToString();
            labelI62.Text = row[6].ToString();
            labelI72.Text = row[7].ToString();

            labelE12.Text = signatureValus[1];
            labelE22.Text = signatureValus[2];
            labelE32.Text = signatureValus[3];
            labelE42.Text = signatureValus[4];
            labelE52.Text = signatureValus[5];
            labelE62.Text = signatureValus[6];
            labelE72.Text = signatureValus[7];
        }
    }
}
