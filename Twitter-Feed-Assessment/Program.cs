using Twitter_Feed_Assessment.Manager;
using Twitter_Feed_Assessment.Repository;
using Twitter_Feed_Assessment.View;

namespace Twitter_Feed_Assessment
{
    class Program
    {
        static void Main(string[] args)
        {

			var dataTweetLoad = new TweetsData();
			var tweets = dataTweetLoad.GetMessages("DataFiles\\tweet.txt");

			var dataUserload = new UserData();
			var users = dataUserload.GetUsers("DataFiles\\user.txt");

			var userManager = new UserManager(users);
			    userManager.ProcessUserData();	

			var userTweersProcessor = new TweetsManager(tweets);
			    userTweersProcessor.ProcessTweets();

            var viewModel = new ViewModel();
			    viewModel.DisplayTweets();
		}
    }
}
