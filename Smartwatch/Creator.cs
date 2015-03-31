using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class Creator
    {
        TimeStateClient stateClient = new TimeStateClient(new TwentyFourHoursFormat());
        Collection collectionTweets = new Collection();
        Twitter twitterObj;
        Iterator iterator;

        /// <summary>
        /// Acces the factory with the State Pattern and change the state
        /// </summary>
        /// <returns>the state</returns>
        public IWatch ReturnInstanceType()
        {
            stateClient.Request();
            return stateClient.State;
        }

        /// <summary>
        /// Access the factory with the Iterator Pattern
        /// </summary>
        /// <returns>the iterator object</returns>
        public Iterator ReturnTweets()
        {
            twitterObj = new Twitter();

            int i = 0;
            foreach (var testen in twitterObj.getTwitterArray())
            {
                collectionTweets[i] = new Tweet(testen.ToString());
                i++;
            }
            iterator = new Iterator(collectionTweets);
            return iterator;
        }
    }
}
