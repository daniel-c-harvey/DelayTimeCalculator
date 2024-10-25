using System.Runtime.CompilerServices;
using System.ComponentModel;
using libmusicaltime;
using libmusicaltime.Enumerations;

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

        #region Inputs
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
        #endregion

        #region Outputs
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
        #endregion

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

            InitSubhandlers();
        }

        private void InitSubhandlers()
        {
            TimeSignature.PropertyChanged += PropertyChanged;
            Tempo.PropertyChanged += PropertyChanged;
        }
    }
}
