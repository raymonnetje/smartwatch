using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace Smartwatch
{
    public class Twitter
    {
        private string accesToken = "3130580315-NM3kzW8GiVzV7Jeqlc0YiIKoK7ILGWTPkZZrQu1";
        private string accesTokenSecret = "irh16gh52kL3tkJGG41aIeKNibdezKwtRIbDW9pexaCGb";
        private string consumerKey = "RbwwU4rdCn7CsjG3KsfHRUCZA";
        private string consumerSecret = "vy4A35h7WQzEeAkynVxHtXxSCyVysCezzkYldvOdYQPboPkRdI";

        public Iterator iterator;

        /// <summary>
        /// Make an array with 8 tweets.
        /// Uses the Tweetinvi library to connect with twitter.com
        /// </summary>
        /// <returns>array with tweets</returns>
        public Array getTwitterArray()
        {            
            // Setup your credentials
            TwitterCredentials.SetCredentials(accesToken, accesTokenSecret, consumerKey, consumerSecret);

            var user = User.GetLoggedUser();

            // Create a parameter for queries with specific parameters
            var timelineParameter = Timeline.CreateHomeTimelineRequestParameter();
            timelineParameter.ExcludeReplies = true;
            timelineParameter.TrimUser = true;
            timelineParameter.MaximumNumberOfTweetsToRetrieve = 8;
            var tweets = Timeline.GetHomeTimeline(timelineParameter);

            Array test = tweets.ToArray();

            return test;
 
            // Skip every other item
            //iterator.Step = 1;

            //for (Tweet tweet = iterator.First(); !iterator.IsDone; tweet = iterator.Next())
            //{
            //    Console.WriteLine(tweet.Message);
            //}
        }
        
        public void Handle(TimeStateClient state)
        {
            throw new NotImplementedException();
        }


        public void Handle(Tweet tweet)
        {
            throw new NotImplementedException();
        }
    }
}
