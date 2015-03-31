using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    /// <summary>
    /// Define the functions for the iterator
    /// </summary>
    public interface IAbstractIterator : IWatch
    {
        Tweet First();
        Tweet Next();
        bool IsAtBegin { get; }
        bool IsAtEnd { get; }
        Tweet CurrentItem { get; }
    }
}
