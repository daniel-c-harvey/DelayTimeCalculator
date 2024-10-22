using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using core;
using libmusicaltime;

namespace DelayTimeCalculatorWinFormsUI
{
    public class DelayTimeCalculatorViewModel : INotifyPropertyChanged
    {
        private TimeSignature timeSignature;
        private Tempo tempo;
        private double timeOutput;
        private NoteRhythmEnumeration noteSubdivision;
        private NoteRhythmModifierEnumeration noteModifier;
        private TimeDivisionEnumeration timeUnit;

        public DelayTimeCalculator Calculator { get; }

        // Inputs
        public TimeSignature TimeSignature { get => timeSignature; set { timeSignature = value; RaiseNotifyPropertyChanged(); } }
        public Tempo Tempo { get => tempo; set { tempo = value; RaiseNotifyPropertyChanged(); } }
        public NoteRhythmEnumeration NoteSubdivision { get => noteSubdivision; set { noteSubdivision = value; RaiseNotifyPropertyChanged(); } }
        public NoteRhythmModifierEnumeration NoteModifier { get => noteModifier; set { noteModifier = value; RaiseNotifyPropertyChanged(); } }
        
        // Outputs
        public double TimeOutput { get => timeOutput; set { timeOutput = value; RaiseNotifyPropertyChanged(); } }
        public TimeDivisionEnumeration TimeUnit { get => timeUnit; set { timeUnit = value; RaiseNotifyPropertyChanged(); } }

        public DelayTimeCalculatorViewModel()
        {
            Calculator = new DelayTimeCalculator();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaiseNotifyPropertyChanged([CallerMemberName] string property = "ERROR")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    public class NoteRhythmEnumeration : DisplayEnumeration<NoteRhythmEnumeration>
    {
        public NoteRhythm Rhythm { get; }

        public static NoteRhythmEnumeration Whole = new NoteRhythmEnumeration(NoteRhythm.Whole, "1/1");
        public static NoteRhythmEnumeration Half = new NoteRhythmEnumeration(NoteRhythm.Half, "1/2");
        public static NoteRhythmEnumeration Quarter = new NoteRhythmEnumeration(NoteRhythm.Quarter, "1/4");
        public static NoteRhythmEnumeration Eighth = new NoteRhythmEnumeration(NoteRhythm.Eighth, "1/8");
        public static NoteRhythmEnumeration Sixteenth = new NoteRhythmEnumeration(NoteRhythm.Sixteenth, "1/16");
        public static NoteRhythmEnumeration ThirtySecond = new NoteRhythmEnumeration(NoteRhythm.ThirtySecond, "1/32");

        public NoteRhythmEnumeration(NoteRhythm rhythm, string sCaption)
            : base((int)rhythm.Subdivision, nameof(rhythm), sCaption)
        {
            Rhythm = rhythm;
        }
    }

    public class NoteRhythmModifierEnumeration : DisplayEnumeration<NoteRhythmModifierEnumeration>
    {
        public NoteRhythmModifier Modifier { get; }

        public static NoteRhythmModifierEnumeration Normal = new NoteRhythmModifierEnumeration(1, NoteRhythmModifier.Normal, nameof(Normal));
        public static NoteRhythmModifierEnumeration Dotted = new NoteRhythmModifierEnumeration(2, NoteRhythmModifier.Dotted, nameof(Dotted));
        public static NoteRhythmModifierEnumeration Triplet = new NoteRhythmModifierEnumeration(3, NoteRhythmModifier.Triplet, nameof(Triplet));

        public NoteRhythmModifierEnumeration(int iID, NoteRhythmModifier modifier, string sCaption)
            : base(iID, sCaption, sCaption)
        {
            Modifier = modifier;
        }
    }

    public class TimeDivisionEnumeration : DisplayEnumeration<TimeDivisionEnumeration>
    {
        public TimeDivision Time { get; }

        public static TimeDivisionEnumeration Millisecond = new TimeDivisionEnumeration(1, TimeDivision.Millisecond, "ms");
        public static TimeDivisionEnumeration Second = new TimeDivisionEnumeration(2, TimeDivision.Second, "sec");
        public static TimeDivisionEnumeration Minute = new TimeDivisionEnumeration(3, TimeDivision.Minute, "min");

        public TimeDivisionEnumeration(
            int iID,
            TimeDivision time,
            string sCaption)
            : base(iID, nameof(time), sCaption)
        {
            Time = time;
        }
    }
}
