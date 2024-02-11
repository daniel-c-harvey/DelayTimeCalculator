using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libmusicaltime
{
    public class TimeSignature
    {
        public uint Beats { get; set;  }
        public NoteRhythm Pulse { get; set; }

        public TimeSignature(uint beats, uint pulse)
        {
            Beats = beats;
            Pulse = new NoteRhythm(pulse);
        }
    }
}
