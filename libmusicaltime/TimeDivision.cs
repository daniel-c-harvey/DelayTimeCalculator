using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libmusicaltime
{
    public class TimeDivision
    {
        public uint Milliseconds { get; }

        public TimeDivision(uint milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public static TimeDivision Millisecond = new TimeDivision(1);
        public static TimeDivision Second = new TimeDivision(1000);
        public static TimeDivision Minute = new TimeDivision(60000);
    }
}
