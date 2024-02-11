using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace libmusicaltime
{
    public class TimeSignature : INotifyPropertyChanged
    {
        private uint beats;
        private NoteRhythm pulse;

        public uint Beats { get => beats; set { beats = value; RaiseNotifyPropertyChanged(); } }
        public NoteRhythm Pulse { get => pulse; set { pulse = value; RaiseNotifyPropertyChanged(); } }

        public TimeSignature(uint beats, uint pulse)
        {
            Beats = beats;
            Pulse = new NoteRhythm(pulse);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaiseNotifyPropertyChanged([CallerMemberName] string property = "ERROR")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
