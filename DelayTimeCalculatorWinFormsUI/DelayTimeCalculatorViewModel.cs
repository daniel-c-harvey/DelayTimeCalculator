using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libmusicaltime;
using libmusicaltime.Enumerations;

namespace DelayTimeCalculatorWinFormsUI
{
    public class DelayTimeCalculatorViewModel
    {
        public DelayTimeCalculator Calculator { get; }

        public TimeSignature TimeSignature { get; set; }
        public Tempo Tempo { get; set; }
        public double TimeOutput { get; set; }
        public NoteRhythmEnumeration NoteSubdivision { get; set; }
        public NoteRhythmModifierEnumeration NoteModifier { get; set; }
        public TimeDivisionEnumeration TimeUnit { get; set; }

        public DelayTimeCalculatorViewModel()
        {
            Calculator = new DelayTimeCalculator();
        }
    }
}
