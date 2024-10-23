using System.Runtime.CompilerServices;
using System.ComponentModel;
using libmusicaltime;
using core;

namespace DelayTimeCalculatorWPFUI.ViewModel
{
    public class DelayTimeCalculatorViewModel : INotifyPropertyChanged
    {
        private TimeSignature timeSignature = default!;
        private Tempo tempo = default!;
        private NoteRhythmEnumeration noteSubdivision = default!;
        private NoteRhythmModifierEnumeration noteModifier = default!;
        private TimeDivisionEnumeration timeUnit = default!;
        private double timeOutput = default!;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DelayTimeCalculator Calculator { get; }

        // Inputs
        public TimeSignature TimeSignature
        {
            get => timeSignature;
            set
            {
                if (timeSignature != value)
                {
                    timeSignature = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }
        public Tempo Tempo
        {
            get => tempo;
            set
            {
                if (tempo != value)
                {
                    tempo = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }
        public NoteRhythmEnumeration NoteSubdivision
        {
            get => noteSubdivision;
            set
            {
                if (noteSubdivision != value)
                {
                    noteSubdivision = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }
        public NoteRhythmModifierEnumeration NoteModifier
        {
            get => noteModifier;
            set
            {
                if (noteModifier != value)
                {
                    noteModifier = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }

        // Outputs
        public double TimeOutput
        {
            get => timeOutput;
            set
            {
                if (timeOutput != value)
                {
                    timeOutput = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }
        public TimeDivisionEnumeration TimeUnit
        {
            get => timeUnit;
            set
            {
                if (timeUnit != value)
                {
                    timeUnit = value;
                    RaiseNotifyPropertyChanged();
                }
            }
        }

        public DelayTimeCalculatorViewModel()
        {
            Calculator = new DelayTimeCalculator();
        }

        public void Recalculate()
        {
            TimeOutput = Calculator.CalculateDelayTime(TimeSignature,
                                                       Tempo,
                                                       new NoteRhythm(NoteSubdivision.Rhythm.Subdivision, 
                                                                      NoteModifier.Modifier),
                                                       TimeUnit.Time);
        }

        private void RaiseNotifyPropertyChanged([CallerMemberName] string name = "ERROR")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        internal void Init()
        {
            TimeSignature = new TimeSignature(4, 4);
            Tempo = new Tempo(120);
            NoteSubdivision = NoteRhythmEnumeration.Quarter;
            NoteModifier = NoteRhythmModifierEnumeration.Normal;
            TimeUnit = TimeDivisionEnumeration.Millisecond;
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

        public static TimeDivisionEnumeration Millisecond = new TimeDivisionEnumeration(1, nameof(Millisecond), TimeDivision.Millisecond, "ms");
        public static TimeDivisionEnumeration Second = new TimeDivisionEnumeration(2, nameof(Second), TimeDivision.Second, "sec");
        public static TimeDivisionEnumeration Minute = new TimeDivisionEnumeration(3, nameof(Minute), TimeDivision.Minute, "min");

        public TimeDivisionEnumeration(
            int iID,
            string name,
            TimeDivision time,
            string sCaption)
            : base(iID, name, sCaption)
        {
            Time = time;
        }
    }
}
