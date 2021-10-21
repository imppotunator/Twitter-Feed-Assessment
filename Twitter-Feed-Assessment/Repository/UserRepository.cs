
using System.Collections.Generic;
using System.Linq;

namespace Twitter_Feed_Assessment.Repository
{
	public class UserRepository
	{
		private static UserRepository instance;

		private readonly IDictionary<string, ISet<string>> userDictinary = new SortedDictionary<string, ISet<string>>();

		public static UserRepository Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UserRepository();
				}
				return instance;
			}
		}

		public virtual void MappUsers(string followee, string user)
		{
			if (!userDictinary.ContainsKey(followee))
			{
				ISet<string> followerSet = CreateHashSet();
				followerSet.Add(user);

				userDictinary[followee] = followerSet;

			}
			else
			{
				userDictinary[followee].Add(user);
			}

			if (!userDictinary.ContainsKey(user))
			{
				userDictinary[user] = CreateHashSet();
			}
		}

		private static ISet<string> CreateHashSet()
		{
			return new HashSet<string>();
		}

		public virtual ISet<string> GetUserFollowed(string user)
		{
            foreach (var item in from item in userDictinary
                                 where item.Key == user
                                 select item)
            {
                return item.Value;
            }

            return null;
		}

		public virtual IList<string> AllUsers
		{
			get
			{
				IList<string> users = new List<string>();
				((List<string>)users).AddRange(userDictinary.Keys);

				return users;
			}
		}


	}
}
