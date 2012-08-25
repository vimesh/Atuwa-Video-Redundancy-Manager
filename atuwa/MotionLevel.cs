using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Vision.Motion;

namespace atuwa
{
    class MotionLevel
    {
        MotionDetector detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionAreaHighlighting());
        List<int> motQue = new List<int>();

        public float[] getSignature(List<float> motion)
        {
            float[] arr = new float[7];
            float q1, q2, q3, q4, average = 0;

            q1 = q2 = q3 = q4 = 0;
            for (int i = 2; i < motion.Count - 3; i++)
            {
                average = motion.ElementAt(i) + average;
                if (i == (motion.Count - 2) / 4)
                {
                    q1 = average / ((motion.Count - 2) / 4);
                    average = 0;
                }
                else if (i == (motion.Count - 2) / 2)
                {
                    q2 = average / ((motion.Count - 2) / 2);
                    average = 0;
                }
                else if (i == (((motion.Count - 2) * 3) / 4))
                {
                    q3 = average / (((motion.Count - 2) * 3) / 4);
                    average = 0;
                }
                else if (i == motion.Count - 3)
                {
                    q4 = average / ((motion.Count - 3) - (((motion.Count - 2) * 3) / 4));
                    average = 0;
                }
            }
            arr[0] = ((q1 + q2 + q3 + q4) / 4); arr[1] = ((q1 + q2) / 2); arr[2] = ((q3 + q4) / 2); arr[3] = q1; arr[4] = q2; arr[5] = q3; arr[6] = q4;
            return arr;
        }
        public float genaratmotionlevel(ref Bitmap motionb, int total, Font f)
        {

            Graphics g = Graphics.FromImage(motionb);

            // paint current time
            SolidBrush brush = new SolidBrush(Color.White);
            float motionLevel = (detector.ProcessFrame(motionb) * 10000);

            g.DrawString("Motion Level:" + motionLevel.ToString(), f, brush, new PointF(150, 5));
            g.DrawString("Frame no:" + total.ToString(), f, brush, new PointF(50, 5));
            brush.Dispose();

            g.Dispose();
            return motionLevel;

        }
        public void genaratmotionlevel(ref Bitmap motionb, Font f)
        {

            Graphics g = Graphics.FromImage(motionb);

            SolidBrush brush = new SolidBrush(Color.White);
            float motionLevel = (detector.ProcessFrame(motionb) * 10000);

            g.DrawString("Motion Level:" + motionLevel.ToString(), f, brush, new PointF(150, 5));

            brush.Dispose();

            g.Dispose();

        }

        public void drawStat(float motionval, ref Bitmap tempStatMotion)
        {

            Graphics gStat = Graphics.FromImage(tempStatMotion);
            SolidBrush brush = new SolidBrush(Color.Red);
            int motLevel = (int)motionval * 240 / 10000;
            int height = tempStatMotion.Height;
            motQue.Add(motLevel);
            if (motQue.Count == 11)
            {
                motQue.RemoveAt(0);
            }

            for (int i = 0; i < motQue.Count; i++)
            {
                int briDepth = height - motQue[i] - 10;
                for (int j = briDepth; j <= height; j++)
                {
                    gStat.FillEllipse(brush, i * 25 + 20, j, 10, 10);
                }

            }

        }

    }

}
