using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public class TimeStateClient : IWatch
    {
        public TimeStateClient(ITimeFormat state)
        {
            State = state;
            Console.WriteLine("Create object of context class with initial State.");
        }

        public ITimeFormat State { get; set; }

        public void Request()
        {
            State.Handle(this);
        }

        public void Handle(TimeStateClient state)
        {
            throw new NotImplementedException();
        }
    }
}
