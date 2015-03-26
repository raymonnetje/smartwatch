using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public interface ITimeFormat
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
    }

    public class TwentyFourHoursFormat : ITimeFormat
    {
        public void Handle(TimeStateClient state)
        {
            //Change the state to TwelveHours
            state.State = new TwelveHoursFormat();
        }
    }
}
