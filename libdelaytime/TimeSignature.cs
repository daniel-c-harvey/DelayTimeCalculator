using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libdelaytime
{
    public class TimeSignature
    {
        public uint Beats { get; }
        public NoteRhythm Pulse { get; }

        public TimeSignature(uint beats, uint pulse)
        {
            Beats = beats;
            Pulse = new NoteRhythm(pulse);
        }
    }
}
