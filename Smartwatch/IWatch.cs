using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public interface IWatch
    {
        void Handle(TimeStateClient state);
        void Handle(Iterator iteratorTweet);
    }
}
