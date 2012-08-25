using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace atuwa
{
    class VideoConverter
    {
        string currentDirectory;
        Process p;

        public VideoConverter()
        {

            currentDirectory = Directory.GetCurrentDirectory();
            p = new Process();
            p.StartInfo.FileName = currentDirectory + "/ffmpeg.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        }

        // convert input video to qvga resolution 25 fps .asf video
        public string Convert(string inputFilePath)
        {
            String[] patharr = inputFilePath.Split('\\');
            String[] fileName = patharr[patharr.Length - 1].Split('.');
            DateTime dateNow = DateTime.Now;
            String sec = dateNow.Millisecond.ToString();
            String newFileName = fileName[0]+sec;

            p.StartInfo.Arguments = "-i " + string.Format("\"{0}\"", inputFilePath) + " -r 25 -s qvga -vcodec wmv2 -acodec wmav2 " + string.Format("\"{0}\"", currentDirectory) + "/Tempone/" + string.Format("\"{0}\"", newFileName) + ".asf";
            p.Start();
            p.WaitForExit();

            string inputpath = currentDirectory + "\\Tempone\\" + newFileName + ".asf";
            string outputpath = currentDirectory + "\\Temp\\" + newFileName + ".asf";
            string inputpathforCommand = string.Format("\"{0}\"", currentDirectory + "\\Tempone\\" + newFileName + ".asf");
            string outputpathforCommand = string.Format("\"{0}\"", currentDirectory + "\\Temp\\" + newFileName + ".asf");
            Process p2 = new Process();
            p2.StartInfo.FileName = currentDirectory + "\\asfbin.exe";
            p2.StartInfo.Arguments = "-i " + inputpathforCommand + " -o " + outputpathforCommand + " -start 0 -rkf";
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();

            File.Delete(inputpath);
            return (outputpath);
        }

        // Cut video to clips with given time list
        public List<string> Cut(string inputFilePath, List<int> segmentingTimes, string name)
        {
            int start = 0, lenght = 0, segment = 0;
            List<string> segmentNames = new List<string>();
            while (segment < segmentingTimes.Count - 1)
            {
                start = segmentingTimes[segment];
                lenght = segmentingTimes[++segment] - start;
                p.StartInfo.Arguments = "-i " + "\"" + inputFilePath + "\"" + " -ss " + getTime(start) + " -t " + getTime(lenght) + " -y " + "\"" + currentDirectory + "\"" + "/SplitVideos/" + name + segment.ToString() + ".asf";
                //p.StartInfo.Arguments = "-i " + "\"" + inputFilePath + "\"" + " -ss " + ((int)(start / 3600000)).ToString() + ":" + ((int)(start / 60000)).ToString() + ":" + ((int)(start / 1000)).ToString() + "." + start.ToString() + " -t " + ((int)(lenght / 3600000)).ToString() + ":" + ((int)(lenght / 60000)).ToString() + ":" + ((int)(lenght / 1000)).ToString() + "." + lenght.ToString() + " -y " + "\"" + currentDirectory + "\"" + "/SplitVideos/" + name + segment.ToString() + ".wav";
                p.Start();
                segmentNames.Add(currentDirectory + "\\SplitVideos\\" + name + segment.ToString() + ".asf");
            }
            File.Delete(inputFilePath);
            return segmentNames;
        }

        private String getTime(int frame)
        {

            int totTime = frame * 40;
            double ms = (int)totTime % 1000;
            double s = (int)totTime / 1000;
            double min = 0;
            double hr = 0;
            if (s >= 60)
            {
                double val = s;
                s = (int)val % 60;
                min = (int)val / 60;
            }

            if (min >= 60)
            {
                double val = min;
                min = (int)val % 60;
                hr = (int)val / 60;
            }
            String msS = ms.ToString();
            String sS = s.ToString();
            String minS = min.ToString();
            if (msS.Length == 1)
            {
                msS = "00" + msS;
            }
            else if (msS.Length == 2)
            {
                msS = "0" + msS;
            }

            if (sS.Length == 1)
            {
                sS = "0" + sS;
            }
            if (minS.Length == 1)
            {
                minS = "0" + minS;
            }

            String st = hr.ToString() + ":" + minS + ":" + sS + "." + msS;
            return st;
        }
    }
}
