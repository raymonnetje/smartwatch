using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class TimeStateClient : IWatch
    {
        /// <summary>
        /// Make a default state
        /// </summary>
        /// <param name="state"></param>
        public TimeStateClient(ITimeFormat state)
        {
            State = state;
            Console.WriteLine("Create object of context class with initial State.");
        }

        public ITimeFormat State { get; set; }

        /// <summary>
        /// change the state
        /// </summary>
        public void Request()
        {
            State.Handle(this);
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
