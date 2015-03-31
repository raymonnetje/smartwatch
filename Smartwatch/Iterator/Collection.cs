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
    }
}
