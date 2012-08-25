using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.IO;

//main database connectro class . 

namespace atuwa
{
    class DatabaseConnector
    {

        MongoServer server = MongoServer.Create();
        int searchCount = 5;
        int topLevelRange = 30;
        int secondLevelRange = 20;
        int thirdLevelRange = 15;


        //Video file detail methods
        public string addVideo(string name, string path, string date)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> videos = database.GetCollection<BsonDocument>("videos");
            string id = (videos.Count() + 1).ToString(); ;
            BsonDocument video = new BsonDocument { { "name", name }, { "path", path }, { "date", date }, { "id", id } };
            videos.Insert(video);

            return id;
        }

        public Boolean checkvideo(string parentvideo)// use to identify segments related to a given video
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("videos");
            var query = Query.EQ("name", parentvideo);

            foreach (BsonDocument video in segments.Find(query))
            {
                return true;
            }

            return false;
        }



        public string searchvideo()
        {
            string ret = "";
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> videos = database.GetCollection<BsonDocument>("videos");
            foreach (BsonDocument video in videos.FindAll())
            {
                ret = ret + "#" + video["name"].ToString() + "#" + video["date"].ToString() + "#" + video["id"].ToString();
            }

            return ret;
        }

        //public void delsegments()
        //{

        //    var database = server.GetDatabase("videos");
        //    MongoCollection<BsonDocument> videos = database.GetCollection<BsonDocument>("delsegments");
        //    foreach (BsonDocument video in videos.FindAll())
        //    {
        //        File.Delete(video["path"].ToString()); 
        //    }


        //}
        // video segment related methods



        //methods for staticstics data
        public Boolean addstat(string parentvideo, int count)
        {
            try
            {
                var databaseSettings = server.CreateDatabaseSettings("videos");
                var database = server[databaseSettings];
                MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("stat");
                string id = (segments.Count() + 1).ToString(); ;
                BsonDocument segment = new BsonDocument { { "parentvideo", parentvideo }, { "count", count }, { "id", id } };
                segments.Insert(segment);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean checkstat(string parentvideo)// use to identify segments related to a given video
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> stat = database.GetCollection<BsonDocument>("stat");
            var query = Query.EQ("parentvideo", parentvideo);

            foreach (BsonDocument video in stat.Find(query))
            {


                return true;
            }

            return false;
        }
        public Boolean updatestat(string parentvideo)// use to identify segments related to a given video
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> stat = database.GetCollection<BsonDocument>("stat");

            if (checkstat(parentvideo))
            {
                var query = Query.EQ("parentvideo", parentvideo);

                foreach (BsonDocument video in stat.Find(query))
                {

                    var query2 = Query.EQ("parentvideo", parentvideo);
                    var update = Update.Set("count", (video["count"].AsInt32 + 1)); // update modifiers
                    stat.Update(query, update);
                    return true;
                }
                return true;
            }
            else
            {


                addstat(parentvideo, 1);
            }

            return false;
        }

        public void stat(string path)// use to identify segments related to a given video
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segments");
            var query = Query.EQ("path", path);

            foreach (BsonDocument video in segments.Find(query))
            {
                updatestat(video["parentvideo"].ToString());
            }

        }


        public int getstat(string parentvideo)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> stat = database.GetCollection<BsonDocument>("stat");
            var query = Query.EQ("parentvideo", parentvideo);

            foreach (BsonDocument video in stat.Find(query))
            {


                return video["count"].AsInt32;
            }

            return 0;



        }
        /////////////

        public Boolean addsegment(string parentvideo, string path, string orderid, int duplicate)
        {
            try
            {
                var databaseSettings = server.CreateDatabaseSettings("videos");
                var database = server[databaseSettings];
                MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segments");
                string id = (segments.Count() + 1).ToString(); ;
                BsonDocument segment = new BsonDocument { { "parentvideo", parentvideo }, { "path", path }, { "orderid", orderid }, { "duplicate", duplicate }, { "id", id } };
                segments.Insert(segment);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public Boolean addsegmenttime(string path, int time)//video segment time initial level search happen on this
        {
            try
            {
                var databaseSettings = server.CreateDatabaseSettings("videos");
                var database = server[databaseSettings];
                MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segmentstime");
                string id = (segments.Count() + 1).ToString(); ;
                BsonDocument segment = new BsonDocument { { "path", path }, { "time", time }, { "id", id } };
                segments.Insert(segment);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<string> searchsegmentstime(int time)//video segment time initial level search happen using this
        {
            List<string> ret = new List<string>();
            int min = time - 10;
            int max = time + 10;
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segmentstime");
            var query = Query.And(Query.GTE("time", min), Query.LTE("time", max));
            foreach (BsonDocument video in segments.Find(query))
            {
                ret.Add(video["path"].ToString());
            }

            return ret;
        }

        public string searchsegments(string parentvideo)// use to identify segments related to a given video
        {
            string ret = "";

            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segments");
            var query = Query.EQ("parentvideo", parentvideo);

            foreach (BsonDocument video in segments.Find(query))
            {
                ret = ret + "&" + video["path"].ToString() + "&" + video["orderid"].ToString() + "&" + video["duplicate"].ToString();
            }

            return ret;
        }

        public Boolean checksegments(string parentvideo, string path, string orderid)// use to identify segments related to a given video
        {
            string ret = "";
            Boolean b = false;
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> segments = database.GetCollection<BsonDocument>("segments");
            var query = Query.And(Query.EQ("parentvideo", parentvideo), Query.EQ("path", path), Query.EQ("orderid", orderid));

            foreach (BsonDocument video in segments.Find(query))
            {
                ret = ret + "#" + video["path"].ToString() + "#" + video["orderid"].ToString() + "#" + video["id"].ToString();
            }
            if (ret.Length > 0) { b = true; }
            return b;
        }

        public string getsegmentdetails(string path)
        {

            String signature = "";

            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> signaturedb = database.GetCollection<BsonDocument>("motionlevels");
            var query = Query.EQ("path", path);
            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("ColorLevelBlue");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("ColorLevelGreen");
            query = Query.EQ("path", path);
            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("ColorLevelRed");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("CentroidLightYs");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("CentroidDarkYs");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("CentroidDarkXs");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            signaturedb = database.GetCollection<BsonDocument>("CentroidLightXs");

            foreach (BsonDocument video in signaturedb.Find(query))
            {
                signature = signature + "#" + video["level1"].ToString() + "#" + video["level21"].ToString() + "#" + video["level22"].ToString() + "#" + video["level31"].ToString() + "#" + video["level32"].ToString() + "#" + video["level33"].ToString() + "#" + video["level34"].ToString();
            }
            return signature;
        }



        //video signature related methods

        public List<string> secondlevelsearch(string motion, string brightx, string brighty, string darkx, string darky, string colorR, string colorG, string colorB, string motion2, string brightx2, string brighty2, string darkx2, string darky2, string colorR2, string colorG2, string colorB2, List<string> paths)
        {
            Boolean[] searchls = new Boolean[8];
            foreach (string row in paths.ToArray())
            {
                int count = 0;
                searchls[0] = searchCentroidDarkXSecondLevel(darkx, darkx2, row);
                searchls[1] = searchCentroidDarkYSecondLevel(darky, darky2, row);
                searchls[2] = searchCentroidLightXSecondLevel(brightx, brightx2, row);
                searchls[3] = searchCentroidLightYSecondLevel(brighty, brighty2, row);
                searchls[4] = searchColorLevelBlueSecondLevel(colorB, colorB2, row);
                searchls[5] = searchColorLevelRedSecondLevel(colorR, colorR2, row);
                searchls[6] = searchColorLevelGreenSecondLevel(colorG, colorG2, row);
                searchls[7] = searchMotionSecondLevel(motion, motion2, row);

                for (int i = 0; i < 8; i++)
                {
                    if (searchls[i]) { count++; }
                }

                if (count < searchCount)
                {

                    paths.Remove(row);

                }

            }
            return paths;
        }


        public List<string> Thiredlevelsearch(string motion, string brightx, string brighty, string darkx, string darky, string colorR, string colorG, string colorB, string motion2, string brightx2, string brighty2, string darkx2, string darky2, string colorR2, string colorG2, string colorB2, string motion3, string brightx3, string brighty3, string darkx3, string darky3, string colorR3, string colorG3, string colorB3, string motion4, string brightx4, string brighty4, string darkx4, string darky4, string colorR4, string colorG4, string colorB4, List<string> paths)
        {
            Boolean[] searchls = new Boolean[8];
            foreach (string row in paths.ToArray())
            {

                int count = 0;
                searchls[0] = searchCentroidDarkXThiredLevel(darkx, darkx2, darkx3, darkx4, row);
                searchls[1] = searchCentroidDarkYThiredLevel(darky, darky2, darky3, darky4, row);
                searchls[2] = searchCentroidLightXThiredLevel(brightx, brightx2, brightx3, brightx4, row);
                searchls[3] = searchCentroidLightYThiredLevel(brighty, brighty2, brighty3, brighty4, row);
                searchls[4] = searchMotionThiredLevel(motion, motion2, motion3, motion4, row);
                searchls[5] = searchColorLevelRedThiredLevel(colorR, colorR2, colorR3, colorR4, row);
                searchls[6] = searchColorLevelBlueThiredLevel(colorB, colorB2, colorB3, colorB4, row);
                searchls[7] = searchColorLevelGreenThiredLevel(colorG, colorG2, colorG3, colorG4, row);

                for (int i = 0; i < 8; i++)
                {
                    if (searchls[i]) { count++; }
                }

                if (count < searchCount)
                {

                    paths.Remove(row);

                }

            }


            return paths;
        }


        public List<string> toplevelsearch(string motion, string brightx, string brighty, string darkx, string darky, string colorR, string colorG, string colorB, List<string> paths)
        {
            Boolean[] searchls = new Boolean[8];
            foreach (string row in paths.ToArray())
            {

                int count = 0;
                searchls[0] = searchCentroidDarkXTopLevel(darkx, row);
                searchls[1] = searchCentroidDarkYTopLevel(darky, row);
                searchls[2] = searchCentroidLightXTopLevel(brightx, row);
                searchls[3] = searchCentroidLightYTopLevel(brighty, row);
                searchls[4] = searchColorLevelBlueTopLevel(colorB, row);
                searchls[5] = searchColorLevelRedTopLevel(colorR, row);
                searchls[6] = searchColorLevelGreenTopLevel(colorG, row);
                searchls[7] = searchMotionTopLevel(motion, row);

                for (int i = 0; i < 8; i++)
                {
                    if (searchls[i]) { count++; }
                }

                if (count < searchCount)
                {

                    paths.Remove(row);

                }


            }


            return paths;


        }
        // motion level signatures 
        public Boolean addmotionlevel(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {
            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("motionlevels");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, motionlevels);
        }

        public Boolean searchMotionTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("motionlevels");
            return searchTopLevel(level1, motionlevels, true, path);
        }
        public Boolean searchMotionSecondLevel(string level21, string level22, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("motionlevels");
            return searchSecondLevel(level21, level22, path, motionlevels, true);
        }
        public Boolean searchMotionThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("motionlevels");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, true);
        }

        /// ColorLevelBlue
        public Boolean addColorLevelBlue(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelBlue");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchColorLevelBlueTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelBlue");
            return searchTopLevel(level1, CentroidDarkXs, false, path);
        }

        public Boolean searchColorLevelBlueSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelBlue");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, false);
        }

        public Boolean searchColorLevelBlueThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("ColorLevelBlue");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, false);
        }


        /// ColorLevelGreen
        public Boolean addColorLevelGreen(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelGreen");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchColorLevelGreenTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelGreen");
            return searchTopLevel(level1, CentroidDarkXs, false, path);
        }

        public Boolean searchColorLevelGreenSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelGreen");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, false);
        }

        public Boolean searchColorLevelGreenThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("ColorLevelGreen");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, false);
        }


        /// ColorLevelRed
        public Boolean addColorLevelRed(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelRed");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchColorLevelRedTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelRed");
            return searchTopLevel(level1, CentroidDarkXs, false, path);
        }

        public Boolean searchColorLevelRedSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("ColorLevelRed");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, false);
        }

        public Boolean searchColorLevelRedThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("ColorLevelRed");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, false);
        }

        /// CentroidLightX
        public Boolean addCentroidLightX(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightXs");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchCentroidLightXTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightXs");
            return searchTopLevel(level1, CentroidDarkXs, true, path);
        }

        public Boolean searchCentroidLightXSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightXs");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, true);
        }

        public Boolean searchCentroidLightXThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("CentroidLightXs");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, true);
        }

        /// CentroidLightY 
        public Boolean addCentroidLightY(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightYs");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchCentroidLightYTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightYs");
            return searchTopLevel(level1, CentroidDarkXs, true, path);
        }

        public Boolean searchCentroidLightYSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidLightYs");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, true);
        }

        public Boolean searchCentroidLightYThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("CentroidLightYs");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, true);
        }

        /// CentroidDarkY 
        public Boolean addCentroidDarkY(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkYs");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchCentroidDarkYTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkYs");
            return searchTopLevel(level1, CentroidDarkXs, true, path);
        }

        public Boolean searchCentroidDarkYSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkYs");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, true);
        }

        public Boolean searchCentroidDarkYThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("CentroidDarkYs");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, true);
        }

        /// CentroidDarkX 
        public Boolean addCentroidDarkX(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34)
        {

            var databaseSettings = server.CreateDatabaseSettings("videos");
            var database = server[databaseSettings];
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkXs");
            return addtodatabase(path, level1, level21, level22, level31, level32, level33, level34, CentroidDarkXs);


        }

        public Boolean searchCentroidDarkXTopLevel(string level1, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkXs");
            return searchTopLevel(level1, CentroidDarkXs, true, path);
        }

        public Boolean searchCentroidDarkXSecondLevel(string level21, string level22, string path)
        {
            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> CentroidDarkXs = database.GetCollection<BsonDocument>("CentroidDarkXs");
            return searchSecondLevel(level21, level22, path, CentroidDarkXs, true);
        }

        public Boolean searchCentroidDarkXThiredLevel(string level31, string level32, string level33, string level34, string path)
        {


            var database = server.GetDatabase("videos");
            MongoCollection<BsonDocument> motionlevels = database.GetCollection<BsonDocument>("CentroidDarkXs");
            return searchThiredLevel(level31, level32, level33, level34, path, motionlevels, true);
        }



        //genaral methods for signature 
        public Boolean searchThiredLevel(string level31, string level32, string level33, string level34, string path, MongoCollection<BsonDocument> motionlevels, Boolean b)
        {
            Boolean ris = false;
            string ret = "";
            try
            {

                if (b)
                {
                    float lev = float.Parse(level31);
                    float levmin = lev - thirdLevelRange;
                    float levmax = lev + thirdLevelRange;
                    float lev2 = float.Parse(level32);
                    float levmin2 = lev2 - thirdLevelRange;
                    float levmax2 = lev2 + thirdLevelRange;
                    float lev3 = float.Parse(level33);
                    float levmin3 = lev3 - thirdLevelRange;
                    float levmax3 = lev3 + thirdLevelRange;
                    float lev4 = float.Parse(level34);
                    float levmin4 = lev4 - thirdLevelRange;
                    float levmax4 = lev4 + thirdLevelRange;

                    var query = Query.And(Query.GTE("level31", levmin), Query.LTE("level31", levmax), Query.GTE("level32", levmin2), Query.LTE("level32", levmax2), Query.GTE("level33", levmin3), Query.LTE("level33", levmax3), Query.GTE("level34", levmin4), Query.LTE("level34", levmax4), Query.EQ("path", path));

                    foreach (BsonDocument video in motionlevels.Find(query))
                    {
                        ret = ret + "#" + video["path"].ToString();
                    }

                    if (ret.Length > 0)
                    {
                        ris = true;
                    }
                    return ris;

                }
                else
                {
                    var query = Query.EQ("path", path);

                    foreach (BsonDocument video in motionlevels.Find(query))
                    {
                        if (matchsegment(level31, video["level31"].ToString(), 2) && matchsegment(level32, video["level32"].ToString(), 2) && matchsegment(level33, video["level33"].ToString(), 2) && matchsegment(level34, video["level34"].ToString(), 2))
                            ret = ret + "#" + video["path"].ToString() + "#" + video["id"].ToString();
                    }

                    if (ret.Length > 0)
                    {
                        ris = true;
                    }
                    return ris;

                }
            }
            catch (Exception e)
            {
                return ris;
            }
        }


        public Boolean searchSecondLevel(string level21, string level22, string path, MongoCollection<BsonDocument> CentroidDarkXs, Boolean b)
        {
            Boolean ris = false;
            string ret = "";
            try
            {
                if (b)
                {

                    float lev = float.Parse(level21);
                    float levmin = lev - secondLevelRange;
                    float levmax = lev + secondLevelRange;
                    float lev2 = float.Parse(level22);
                    float levmin2 = lev2 - secondLevelRange;
                    float levmax2 = lev2 + secondLevelRange;
                    var query = Query.And(Query.GTE("level21", levmin), Query.LTE("level21", levmax), Query.GTE("level22", levmin2), Query.LTE("level22", levmax2), Query.EQ("path", path));



                    foreach (BsonDocument video in CentroidDarkXs.Find(query))
                    {
                        ret = ret + "#" + video["path"].ToString() + "#" + video["id"].ToString();
                    }
                    if (ret.Length > 0)
                    { ris = true; }
                    return ris;
                }
                else
                {
                    var query = Query.EQ("path", path);
                    foreach (BsonDocument video in CentroidDarkXs.Find(query))
                    {
                        if (matchsegment(level21, video["level21"].ToString(), 2) && matchsegment(level22, video["level22"].ToString(), 2))
                            ret = ret + "#" + video["path"].ToString() + "#" + video["id"].ToString();
                    }
                    if (ret.Length > 0)
                    { ris = true; }
                    return ris;

                }
            }
            catch (Exception e)
            {

                return false;

            }
        }

        public Boolean searchTopLevel(string level1, MongoCollection<BsonDocument> CentroidDarkXs, Boolean b, string path)
        {
            Boolean ris = false;
            string ret = "";
            try
            {
                if (b)
                {

                    float lev = float.Parse(level1);
                    float levmin = lev - topLevelRange;
                    float levmax = lev + topLevelRange;
                    var query = Query.And(Query.GTE("level1", levmin), Query.LTE("level1", levmax), Query.EQ("path", path));
                    foreach (BsonDocument video in CentroidDarkXs.Find(query))
                    {
                        ret = ret + "#" + video["path"].ToString();
                    }
                    if (ret.Length > 0)
                    { ris = true; }
                    return ris;

                }
                else
                {

                    var query = Query.EQ("path", path);
                    foreach (BsonDocument video in CentroidDarkXs.Find(query))
                    {
                        if (matchsegment(level1, video["level1"].ToString(), 3))
                            ret = ret + "#" + video["path"].ToString();
                    }
                    if (ret.Length > 0)
                    { ris = true; }
                    return ris;
                }
            }
            catch (Exception e)
            {
                return ris;
            }

        }

        private Boolean matchsegment(string level1, string level2, int tresholed)
        {
            try
            {
                int countmatchno = 0;
                string[] array1 = level1.Split();
                string[] array2 = level2.Split();
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i].Length > 0 && array2[i].Length > 0)
                    {
                        int a = Int32.Parse(array1[i]);
                        int b = Int32.Parse(array2[i]);
                        if ((b - tresholed) < a && a < (b + tresholed))
                        {
                            countmatchno++;

                        }
                    }
                }
                if (countmatchno > 12)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;


            }
        }

        public Boolean addtodatabase(string path, string level1, string level21, string level22, string level31, string level32, string level33, string level34, MongoCollection<BsonDocument> CentroidDarkXs)
        {
            try
            {
                float[] lev = { float.Parse(level1), float.Parse(level21), float.Parse(level22), float.Parse(level31), float.Parse(level32), float.Parse(level33), float.Parse(level34) };
                string id = (CentroidDarkXs.Count() + 1).ToString(); ;
                BsonDocument CentroidDarkX = new BsonDocument { { "path", path }, { "level1", lev[0] }, { "level21", lev[1] }, { "level22", lev[2] }, { "level31", lev[3] }, { "level32", lev[4] }, { "level33", lev[5] }, { "level34", lev[6] }, { "id", id } };
                CentroidDarkXs.Insert(CentroidDarkX);
                return true;
            }

            catch (FormatException e)
            {
                string id = (CentroidDarkXs.Count() + 1).ToString(); ;
                BsonDocument CentroidDarkX = new BsonDocument { { "path", path }, { "level1", level1 }, { "level21", level21 }, { "level22", level22 }, { "level31", level31 }, { "level32", level32 }, { "level33", level33 }, { "level34", level34 }, { "id", id } };
                CentroidDarkXs.Insert(CentroidDarkX);
                return true;

            }
            catch (MongoException ex)
            {

                return false;
            }

        }

    }
}
