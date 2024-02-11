using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libdelaytime
{
    public class TimeDivision
    {
        public uint Milliseconds { get; }

        public TimeDivision(uint milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public static TimeDivision millisecond = new(1);
        public static TimeDivision second = new(1000);
        public static TimeDivision minute = new(60000);
    }
}
