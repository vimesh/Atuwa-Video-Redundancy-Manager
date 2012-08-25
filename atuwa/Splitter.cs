using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace atuwa
{
    class Splitter
    {
        public List<string> split(List<int> framelst, string pathName)
        {
            string str = "";
            List<string> returnPathLst = new List<string>();
            int retFileId = 1, retSectionId = 1;
            String dir = Directory.GetCurrentDirectory();
            String[] patharr = pathName.Split('\\');
            String[] fileName = patharr[patharr.Length - 1].Split('.');
            DateTime dateNow = DateTime.Now;
            String sec = dateNow.Millisecond.ToString();
            int section = 0;
            String newFileName = fileName[0] + section.ToString() + sec;

            /*string storeDir = System.IO.Path.Combine(dir, "SplitVideos");
            System.IO.Directory.CreateDirectory(storeDir);*/

            String path = string.Format("\"{0}\"", pathName);
            String stDir = dir + "\\SplitVideos";
            String storedDir = string.Format("\"{0}\"", stDir);

            if (framelst.Count() == 0)
            {
                string ret = stDir + "\\" + newFileName + "1.asf";

                File.Copy(pathName, ret);
                returnPathLst.Add(ret);
            }
            else
            {

                List<String> startTimeLst = new List<String>();
                startTimeLst.Add(" -start 0");
                foreach (int frame in framelst)
                {
                    startTimeLst.Add(" -start " + getTime(frame));
                }

                List<String> durationLst = new List<String>();
                durationLst.Add(" -dur " + getTime(framelst[0]));
                for (int i = 0; i < framelst.Count - 1; i++)
                {
                    durationLst.Add(" -dur " + getTime(framelst[i + 1] - framelst[i]));
                }


                for (int i = 0; i < durationLst.Count; i++)
                {
                    str = str + startTimeLst[i] + durationLst[i];

                    string ret = stDir + "\\" + fileName[0] + retSectionId.ToString() + sec + retFileId.ToString() + ".asf";
                    returnPathLst.Add(ret);
                    retFileId++;

                    if (i > 0)
                    {
                        if (i == durationLst.Count - 1)
                        {
                            section++;
                            newFileName = fileName[0] + section.ToString() + sec;
                            str = str + startTimeLst[startTimeLst.Count - 1];
                            ret = stDir + "\\" + fileName[0] + retSectionId.ToString() + sec + retFileId.ToString() + ".asf";
                            returnPathLst.Add(ret);
                            Process p = new Process();
                            p.StartInfo.FileName = @dir + "\\asfbin.exe";
                            p.StartInfo.Arguments = "-i " + path + str + " -sep -o " + storedDir + "\\" + newFileName + "{0}.asf -unique -rkf";
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            p.Start();
                            p.WaitForExit();
                            str = "";
                        }
                        else if (i % 300 == 0)
                        {
                            section++;
                            newFileName = fileName[0] + section.ToString() + sec;
                            Process p = new Process();
                            p.StartInfo.FileName = @dir + "\\asfbin.exe";
                            p.StartInfo.Arguments = "-i " + path + str + " -sep -o " + storedDir + "\\" + newFileName + "{0}.asf -unique -rkf";
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            p.Start();
                            p.WaitForExit();
                            str = "";
                            retSectionId++;
                            retFileId = 1;
                        }
                    }
                }


            }

            File.Delete(pathName);

            return returnPathLst;

        }



        public String getTime(int frame)
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
