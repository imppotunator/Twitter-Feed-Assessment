using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Twitter_Feed_Assessment.Model;

namespace Twitter_Feed_Assessment.Repository
{
    public class UserData
    {
        private const string SPLIT = "follows";
        private const string SPLITMULTIPLE = ",";

        public IList<UserModel> GetUsers(string filePath)
        {
            StreamReader sr = null;
            IList<UserModel> tweets = new List<UserModel>();
            try
            {

                string line; 
                sr = new StreamReader(filePath);

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(SPLIT);
                    string user = data[0].Trim();
                    var followed = data[1].Split(SPLITMULTIPLE).Select(s => s.Trim()).ToArray();

                    tweets.Add(new UserModel(user, followed));

                }
            }
            catch (Exception ex)
            {
                throw new Exception("FileDoesnot exist", ex);
            }
            finally
            {
                sr.Close();
            }
            return tweets;
        }
    }
}
