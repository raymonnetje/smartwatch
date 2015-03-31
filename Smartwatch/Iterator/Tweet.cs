using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class Tweet
    {
        private string _message;
 
        // Constructor
        public Tweet(string message)
        {
            this._message = message;
        }
 
        // Gets name
        public String Message
        {
            get { return _message; }
        }
    }
}
