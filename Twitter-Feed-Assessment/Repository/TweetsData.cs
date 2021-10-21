using System;
using System.Collections.Generic;
using System.IO;
using Twitter_Feed_Assessment.Model;

namespace Twitter_Feed_Assessment.Repository
{
    public class TweetsData
    {
        private const string SPLIT = "> ";

        public IList<TweetModel> GetMessages(string filePath)
        {
            StreamReader sr = null;
            IList<TweetModel> tweets = new List<TweetModel>();
            try
            {
                
                string line;
                // Read the file and display it line by line.  
                 sr = new StreamReader(filePath);

                while (( line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(SPLIT);
                    string sender = data[0].Trim();
                    var tweet = data[1].Trim();
                    tweets.Add(new TweetModel(sender, tweet));

                }
            }
            catch (Exception ex)
            {

                throw new Exception("File Does not exist",ex);
            }
            finally
            {
                sr.Close();
            }
            return tweets;
        }
    }
}
