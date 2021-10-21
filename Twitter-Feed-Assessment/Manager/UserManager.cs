
using System.Collections.Generic;
using Twitter_Feed_Assessment.Model;
using Twitter_Feed_Assessment.Repository;

namespace Twitter_Feed_Assessment.Manager
{
    public class UserManager 
    {
        public IList<UserModel> Users  { get; set; }

		public UserManager(IList<UserModel> users)
        {
			Users = users;
		}
		public virtual void ProcessUserData()
		{
			foreach (UserModel user in Users)
			{
				foreach (string followee in user.Followed)
				{
					UserRepository.Instance.MappUsers(followee, user.Username);
				}
			}
		}
	}
}
