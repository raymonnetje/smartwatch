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

    public class AmFormat : ITimeFormat
    {
        public void Handle(TimeStateClient state)
        {
            //Change the state to AM
            state.State = new PmFormat();
        }
    }

    public class PmFormat : ITimeFormat
    {
        public void Handle(TimeStateClient state)
        {
            //Change the state to PM
            state.State = new AmFormat();
        }
    }
}
