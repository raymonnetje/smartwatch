using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    public interface IAbstractIterator : IWatch
    {
        Tweet First();
        Tweet Next();
        bool IsDone { get; }
        Tweet CurrentItem { get; }
    }
}
