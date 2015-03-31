using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwatch
{
    class Time
    {
        public static readonly Time _instance = new Time();

        /// <summary>
        /// Get the system time
        /// </summary>
        /// <returns>Return the system time</returns>
        public DateTime getTime()
        {
            return DateTime.Now;
        }
    }
}
