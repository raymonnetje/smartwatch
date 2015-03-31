using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public interface ITimeFormat : IWatch
    {
        void Handle(TimeStateClient state);
    }

    public class TwelveHoursFormat : ITimeFormat
    {
        public void Handle(TimeStateClient state)
        {
            //Change the state to TwentyFourHours
            state.State = new TwentyFourHoursFormat();
        }

        public void Handle(Iterator iteratorTweet)
        {
            throw new NotImplementedException();
        }
    }

    public class TwentyFourHoursFormat : ITimeFormat
    {
        public void Handle(TimeStateClient state)
        {
            //Change the state to TwelveHours
            state.State = new TwelveHoursFormat();
        }

        public void Handle(Iterator iteratorTweet)
        {
            throw new NotImplementedException();
        }
    }
}
