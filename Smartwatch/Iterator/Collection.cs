using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class Collection : IAbstractCollection
    {
        private ArrayList _tweets = new ArrayList();

        public void Handle(Iterator iteratorTweet)
        {
            //Change the state to TwentyFourHours
            CreateIterator();
        }
        /// <summary>
        /// Creates the iterator
        /// </summary>
        /// <returns>the iterator</returns>
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _tweets.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _tweets[index]; }
            set { _tweets.Add(value); }
        }


        public void Handle(TimeStateClient state)
        {
            throw new NotImplementedException();
        }
    }
}
