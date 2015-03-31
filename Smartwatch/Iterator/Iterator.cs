using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;

        // Constructor
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        // Gets first item
        public Tweet First()
        {
            _current = 0;
            return _collection[_current] as Tweet;
        }

        // Gets next item
        public Tweet Next()
        {
            if (!IsAtEnd)
            {
                _current += _step;
                return _collection[_current] as Tweet;
            }
            else
            {
                return null;
            }
        }

        // Gets previous item
        public Tweet Previous()
        {
            if (!IsAtBegin)
            {
                _current -= _step;
                return _collection[_current] as Tweet;
            }
            else
            {
                return null;
            }
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public Tweet CurrentItem
        {
            get { return _collection[_current] as Tweet; }
        }

        // Gets whether iteration is complete
        public bool IsAtBegin
        {
            get { return _current <= 0; }
        }

        // Gets whether iteration is complete
        public bool IsAtEnd
        {
            get { return _current >= _collection.Count - 1; }
        }


        public void Handle(TimeStateClient state)
        {
            throw new NotImplementedException();
        }

        public void Handle(Iterator iteratorTweet)
        {
            throw new NotImplementedException();
        }
    }
}
