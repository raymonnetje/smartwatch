using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class Creator
    {
        TimeStateClient a = new TimeStateClient(new TwentyFourHoursFormat());
        Collection collectionTweets = new Collection();
        Twitter twitterObj;
        Iterator iterator;

        public IWatch ReturnInstanceType()
        {
            a.Request();
            return a.State;
        }

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
