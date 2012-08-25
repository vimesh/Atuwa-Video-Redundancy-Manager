using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace atuwa
{
    class Centroid
    {
        float brightness_value = 0.4f;
        float darkness_value = 0.2f;
        int referenced_frame_count = 0;
        int referenced_limit = 10;
        bool isReferncing = true;
        float intensity_value = 0.0f;

        List<int> brightnessValuesListX = new List<int>();
        List<int> brightnessValuesListY = new List<int>();
        List<int> darknessValuesListX = new List<int>();
        List<int> darknessValuesListY = new List<int>();

        List<int> resultsBriX = new List<int>();
        List<int> resultsBriY = new List<int>();
        List<int> resultsDarX = new List<int>();
        List<int> resultsDarY = new List<int>();
        List<float> referenced_brightness_values = new List<float>();
        List<float> referenced_darkness_values = new List<float>();
        List<float> intensity_values_list = new List<float>();

        int[, ,] resultsArray = new int[7, 2, 2];

        int oldXValB = 0, oldYValB = 0, oldXValD = 0, oldYValD = 0;
        int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

        List<int> briQue = new List<int>();
        List<int> darQue = new List<int>();

        public bool generateCentroid(ref Bitmap image, ref Bitmap imageStat)
        {

            int[] arrpnt;
            Graphics g = Graphics.FromImage(image);
            Graphics gStat = Graphics.FromImage(imageStat);
            brightnessValuesListX.Clear();
            brightnessValuesListY.Clear();
            darknessValuesListX.Clear();
            darknessValuesListY.Clear();

            looparound(image);

            arrpnt = setResults(brightnessValuesListX, brightnessValuesListY, true);
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, arrpnt[0], arrpnt[1], 10, 10);
            x1 = arrpnt[0];
            y1 = arrpnt[1];

            arrpnt = setResults(darknessValuesListX, darknessValuesListY, false);
            SolidBrush brush2 = new SolidBrush(Color.YellowGreen);
            g.FillEllipse(brush2, arrpnt[0], arrpnt[1], 10, 10);

            x2 = arrpnt[0];
            y2 = arrpnt[1];

            /// to make a difference
            int briXDiff = x1 - oldXValB;
            int briYDiff = y1 - oldYValB;
            int darXDiff = x2 - oldXValD;
            int darYDiff = y2 - oldYValD;
            int briDiff = (int)Math.Sqrt(Math.Pow(briXDiff, 2) + Math.Pow(briYDiff, 2));
            int darDiff = (int)Math.Sqrt(Math.Pow(darXDiff, 2) + Math.Pow(darYDiff, 2));
            bool toSegment = false;

            if (briDiff > 20 && darDiff > 20)
            {
                toSegment = true;
            }

            int height = image.Height;
            briDiff = (int)briDiff * 240 / 400;
            darDiff = (int)darDiff * 240 / 400;
            briQue.Add(briDiff);
            darQue.Add(darDiff);
            if (briQue.Count == 11)
            {
                briQue.RemoveAt(0);
                darQue.RemoveAt(0);
            }

            for (int i = 0; i < briQue.Count; i++)
            {
                int briDepth = height - briQue[i] - 10;
                int darDepth = height - darQue[i] - 10;
                for (int j = briDepth; j <= height; j++)
                {
                    gStat.FillEllipse(brush, i * 25 + 20, j, 10, 10);
                }

                for (int j = darDepth; j <= height; j++)
                {
                    gStat.FillEllipse(brush2, i * 25 + 25, j, 10, 10);
                }
            }


            oldXValB = x1;
            oldYValB = y1;
            oldXValD = x2;
            oldYValD = y2;

            brush.Dispose();
            brush2.Dispose();
            g.Dispose();
            gStat.Dispose();

            return toSegment;
        }

        public void generateCentroid(ref Bitmap image)
        {
            int[] arrpnt;
            Graphics g = Graphics.FromImage(image);
            brightnessValuesListX.Clear();
            brightnessValuesListY.Clear();
            darknessValuesListX.Clear();
            darknessValuesListY.Clear();

            looparound(image);

            arrpnt = setResults(brightnessValuesListX, brightnessValuesListY, true);
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, arrpnt[0], arrpnt[1], 10, 10);
            x1 = arrpnt[0];
            y1 = arrpnt[1];

            arrpnt = setResults(darknessValuesListX, darknessValuesListY, false);
            SolidBrush brush2 = new SolidBrush(Color.YellowGreen);
            g.FillEllipse(brush2, arrpnt[0], arrpnt[1], 10, 10);

            x2 = arrpnt[0];
            y2 = arrpnt[1];

            brush.Dispose();
            g.Dispose();

        }



        public int[, ,] getSignature()
        {
            resultsHierarchyDesign(resultsBriX, resultsBriY, true);
            resultsHierarchyDesign(resultsDarX, resultsDarY, false);

            brightness_value = 0.4f;
            darkness_value = 0.2f;
            referenced_frame_count = 0;
            isReferncing = true;

            resultsBriX.Clear();
            resultsBriY.Clear();
            resultsDarX.Clear();
            resultsDarY.Clear();

            referenced_brightness_values.Clear();
            referenced_darkness_values.Clear();
            intensity_values_list.Clear(); // no need

            return resultsArray;

        }
        private void findThresholdLevel()
        {
            float ref_value;
            intensity_values_list.Sort();
            ref_value = intensity_values_list[(int)intensity_values_list.Count * 1 / 10];
            referenced_darkness_values.Add(ref_value);

            intensity_values_list.Reverse();
            ref_value = intensity_values_list[(int)intensity_values_list.Count * 1 / 10];
            referenced_brightness_values.Add(ref_value);
        }

        private int[] setResults(List<int> valuesListX, List<int> valuesListY, bool isBrightness)
        {

            int avgXval = 0, avgYval = 0;
            int[] arr = new int[2];
            if (valuesListX.Count == 0)
            {
                avgXval = 0;
                avgYval = 0;
            }
            else
            {
                avgXval = (int)valuesListX.Average();
                avgYval = (int)valuesListY.Average();
            }

            arr[0] = avgXval;
            arr[1] = avgYval;

            if (isBrightness)
            {
                resultsBriX.Add(avgXval);
                resultsBriY.Add(avgYval);
            }
            else
            {
                resultsDarX.Add(avgXval);
                resultsDarY.Add(avgYval);
            }

            return arr;

        }


        private void resultsHierarchyDesign(List<int> resultsX, List<int> resultsY, bool isBrightness)
        {  // make a hierarchy of brightness values from the values of each frame

            int avgL3X1, avgL3X2, avgL3X3, avgL3X4, avgL2X1, avgL2X2, avgL1X;
            int avgL3Y1, avgL3Y2, avgL3Y3, avgL3Y4, avgL2Y1, avgL2Y2, avgL1Y;
            int totX = 0, totY = 0;

            if (resultsX.Count() > 4)
            {

                for (int i = 0; i < resultsX.Count() / 4; i++)
                {  // signature for each quater of scene
                    totX = totX + resultsX[i];
                    totY = totY + resultsY[i];
                }
                avgL3X1 = totX / (resultsX.Count() / 4);
                avgL3Y1 = totY / (resultsY.Count() / 4);

                totX = 0;
                totY = 0;
                for (int i = resultsX.Count() / 4; i < resultsX.Count() / 2; i++)
                {
                    totX = totX + resultsX[i];
                    totY = totY + resultsY[i];
                }
                avgL3X2 = totX / (resultsX.Count() / 4);
                avgL3Y2 = totY / (resultsY.Count() / 4);

                totX = 0;
                totY = 0;
                for (int i = resultsX.Count() / 2; i < (resultsX.Count() * 3) / 4; i++)
                {
                    totX = totX + resultsX[i];
                    totY = totY + resultsY[i];
                }
                avgL3X3 = totX / (resultsX.Count() / 4);
                avgL3Y3 = totY / (resultsY.Count() / 4);

                totX = 0;
                totY = 0;
                for (int i = (resultsX.Count() * 3) / 4; i < resultsX.Count(); i++)
                {
                    totX = totX + resultsX[i];
                    totY = totY + resultsY[i];
                }
                avgL3X4 = totX / (resultsX.Count() / 4);
                avgL3Y4 = totY / (resultsY.Count() / 4);

                avgL2X1 = (avgL3X1 + avgL3X2) / 2; // signature for each half of the scene
                avgL2X2 = (avgL3X3 + avgL3X4) / 2;
                avgL1X = (avgL2X1 + avgL2X2) / 2;

                avgL2Y1 = (avgL3Y1 + avgL3Y2) / 2;
                avgL2Y2 = (avgL3Y3 + avgL3Y4) / 2;
                avgL1Y = (avgL2Y1 + avgL2Y2) / 2;   // overall signature for the scene


            }
            else
            {
                if (resultsX.Count == 0)
                {
                    avgL1X = 0;
                    avgL1Y = 0;
                }
                else
                {
                    avgL1X = (int)resultsX.Average();
                    avgL1Y = (int)resultsY.Average();
                }
                avgL2X1 = 0;
                avgL2X2 = 0;
                avgL2Y1 = 0;
                avgL2Y2 = 0;
                avgL3X1 = 0;
                avgL3X2 = 0;
                avgL3X3 = 0;
                avgL3X4 = 0;
                avgL3Y1 = 0;
                avgL3Y2 = 0;
                avgL3Y3 = 0;
                avgL3Y4 = 0;
            }

            // put x and y coordinates to the results array
            if (isBrightness)
            {  // for brightness 

                resultsArray[0, 0, 0] = avgL1X;
                resultsArray[0, 1, 0] = avgL1Y;
                resultsArray[1, 0, 0] = avgL2X1;
                resultsArray[1, 1, 0] = avgL2Y1;
                resultsArray[2, 0, 0] = avgL2X2;
                resultsArray[2, 1, 0] = avgL2Y2;
                resultsArray[3, 0, 0] = avgL3X1;
                resultsArray[3, 1, 0] = avgL3Y1;
                resultsArray[4, 0, 0] = avgL3X2;
                resultsArray[4, 1, 0] = avgL3Y2;
                resultsArray[5, 0, 0] = avgL3X3;
                resultsArray[5, 1, 0] = avgL3Y3;
                resultsArray[6, 0, 0] = avgL3X4;
                resultsArray[6, 1, 0] = avgL3Y4;

            }
            else
            {   // for darkness

                resultsArray[0, 0, 1] = avgL1X;
                resultsArray[0, 1, 1] = avgL1Y;
                resultsArray[1, 0, 1] = avgL2X1;
                resultsArray[1, 1, 1] = avgL2Y1;
                resultsArray[2, 0, 1] = avgL2X2;
                resultsArray[2, 1, 1] = avgL2Y2;
                resultsArray[3, 0, 1] = avgL3X1;
                resultsArray[3, 1, 1] = avgL3Y1;
                resultsArray[4, 0, 1] = avgL3X2;
                resultsArray[4, 1, 1] = avgL3Y2;
                resultsArray[5, 0, 1] = avgL3X3;
                resultsArray[5, 1, 1] = avgL3Y3;
                resultsArray[6, 0, 1] = avgL3X4;
                resultsArray[6, 1, 1] = avgL3Y4;
            }


        }

        private void looparound(Bitmap image)
        {

            // Grayscale level 
            //Bitmap bmp = Grayscale.CommonAlgorithms.RMY.Apply(videoSourcePlayer.GetCurrentVideoFrame());


            int height = image.Height;
            int width = image.Width;
            for (int i = 0; i < height; i = i + 10)
            {
                for (int j = 0; j < width; j = j + 10)
                {
                    Color c = image.GetPixel(j, i);
                    intensity_value = c.GetBrightness();
                    //g.DrawString(intensity_value.ToString(), this.Font, brush, new PointF(j, i));

                    if (isReferncing)
                    {
                        intensity_values_list.Add(intensity_value);
                    }

                    if (intensity_value > brightness_value)
                    {
                        brightnessValuesListX.Add(i);
                        brightnessValuesListY.Add(j);
                    }


                    if (intensity_value < darkness_value)
                    {
                        darknessValuesListX.Add(i);
                        darknessValuesListY.Add(j);
                    }

                }

            }
            if (isReferncing)
            {
                if (referenced_frame_count < referenced_limit)
                {
                    findThresholdLevel();
                    referenced_frame_count++;

                }
                else
                {
                    isReferncing = false;
                    brightness_value = referenced_brightness_values.Average();
                    darkness_value = referenced_darkness_values.Average();
                    //MessageBox.Show("  b  value: "+brightness_value+"    d value"+darkness_value );
                }

                intensity_values_list.Clear();
            }


        }
    }
}
