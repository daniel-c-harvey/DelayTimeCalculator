using libmusicaltime;
using libmusicaltime.Enumerations;

namespace DelayTimeCalculatorWPFUI.ViewModel
{
    public class DelayTimeCalculatorViewModel
    {
        private TimeSignature timeSignature;
        private Tempo tempo;
        private double timeOutput;
        private NoteRhythmEnumeration noteSubdivision;
        private NoteRhythmModifierEnumeration noteModifier;
        private TimeDivisionEnumeration timeUnit;

        public DelayTimeCalculator Calculator { get; }

        // Inputs
        public TimeSignature TimeSignature
        {
            get => timeSignature;
            set
            {
                timeSignature = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }
        public Tempo Tempo
        {
            get => tempo;
            set
            {
                tempo = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }
        public NoteRhythmEnumeration NoteSubdivision
        {
            get => noteSubdivision;
            set
            {
                noteSubdivision = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }
        public NoteRhythmModifierEnumeration NoteModifier
        {
            get => noteModifier;
            set
            {
                noteModifier = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }

        // Outputs
        public double TimeOutput
        {
            get => timeOutput;
            set
            {
                timeOutput = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }
        public TimeDivisionEnumeration TimeUnit
        {
            get => timeUnit;
            set
            {
                timeUnit = value;
                //RaiseNotifyPropertyChanged(); 
            }
        }

        public DelayTimeCalculatorViewModel()
        {
            Calculator = new DelayTimeCalculator();
        }
    }
}
