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
        Twitter b = new Twitter();
        public IWatch ReturnInstanceType(int pType)
        {
            if (pType == 1)
            {
                a.Request();
                return a.State;
            }
            else if (pType == 2)
            {
                b.getCurrentTweet();
                return b.Iterator;
            }
            else
            {
                return a.State;
            }
        }
    }
}
