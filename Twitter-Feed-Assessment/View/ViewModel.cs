using System;
using System.Text;
using Twitter_Feed_Assessment.Model;
using Twitter_Feed_Assessment.Repository;

namespace Twitter_Feed_Assessment.View
{
    public class ViewModel
    {
		public virtual void DisplayTweets()
		{
			var users = UserRepository.Instance.AllUsers;

			var stringBuilder = new StringBuilder();
			stringBuilder.Append('\n');			

			foreach (string user in users)
			{
				var userTweets = UserTweetRepository.Instance.GetUserTweets(user);
				
				stringBuilder.Append(user);
				stringBuilder.Append('\n');
				if ((userTweets != null) && (userTweets.Count > 0))
				{
					foreach (TweetModel tweet in userTweets)
					{
					
						stringBuilder.Append('@');
						stringBuilder.Append(tweet.Sender);
						stringBuilder.Append(@": ");
						stringBuilder.Append(tweet.Tweet);
						stringBuilder.Append('\n');
						
					}					
				}
			}

			Console.WriteLine(stringBuilder.ToString());

			Console.ReadKey();
		}
	}
}
