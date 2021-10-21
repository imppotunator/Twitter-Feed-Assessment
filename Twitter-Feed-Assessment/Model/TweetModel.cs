using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_Feed_Assessment.Model
{
	public class TweetModel
	{

		public string Sender { get; }
		public string Tweet { get; }

		public TweetModel(string sender, string tweet)
		{
			Sender = sender;
			Tweet = tweet;
		}
	}
}
