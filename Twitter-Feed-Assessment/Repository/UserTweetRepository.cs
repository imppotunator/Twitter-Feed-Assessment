using System.Collections.Generic;
using System.Linq;
using Twitter_Feed_Assessment.Model;

namespace Twitter_Feed_Assessment.Repository
{
    public class UserTweetRepository
    {
		private static UserTweetRepository instance;

		private readonly IDictionary<string, IList<TweetModel>> UserTweet = new SortedDictionary<string, IList<TweetModel>>();
		

		public static UserTweetRepository Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UserTweetRepository();
				}
				return instance;
			}
		}

		public virtual void MappTweetToUser(string user, TweetModel tweet)
		{
			if (!UserTweet.ContainsKey(user))
			{
                var tweetlist = new List<TweetModel>
                {
                    tweet
                };

                UserTweet[user] = tweetlist;

			}
			else
			{
				UserTweet[user].Add(tweet);
			}
		}

		public virtual IList<TweetModel> GetUserTweets(string user)
		{
            foreach (var item in from item in UserTweet
                                 where item.Key.Equals(user)
                                 select item)
            {
                return item.Value;
            }

            return null;
		}
	}
}
