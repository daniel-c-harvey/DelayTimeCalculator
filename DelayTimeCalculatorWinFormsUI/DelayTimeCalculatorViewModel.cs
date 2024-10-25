using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using core;
using libmusicaltime;
using libmusicaltime.Enumerations;

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
}
