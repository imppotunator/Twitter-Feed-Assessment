using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_Feed_Assessment.Model
{
	public class UserModel
	{

		public string Username { get; }
		public IList<string> Followed { get; }

		public UserModel(string username, IList<string> followed)
		{
			Username = username;
			Followed = followed;
		}
		 
	}
}
