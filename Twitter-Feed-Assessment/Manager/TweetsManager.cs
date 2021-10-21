using System;
using System.Collections.Generic;
using Twitter_Feed_Assessment.Model;
using Twitter_Feed_Assessment.Repository;

namespace Twitter_Feed_Assessment.Manager
{
    public class TweetsManager
    {
        public IList<TweetModel> Tweets { get; set; }
        public TweetsManager(IList<TweetModel> tweets)
        {
			Tweets = tweets;
		}
        public virtual void ProcessTweets()
		{
			foreach (TweetModel tweet in Tweets)
			{
				UserTweetRepository.Instance.MappTweetToUser(tweet.Sender, tweet);

				ISet<string> userFollowed = UserRepository.Instance.GetUserFollowed(tweet.Sender);

				foreach (string user in userFollowed)
				{
					UserTweetRepository.Instance.MappTweetToUser(user, tweet);
				}
			}
		}
	}
}
