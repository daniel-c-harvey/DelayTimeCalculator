using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace libmusicaltime
{
    public class Tempo : INotifyPropertyChanged
    {
        private uint beatsPerMinute;

        public uint BeatsPerMinute { get => beatsPerMinute; set { beatsPerMinute = value; RaiseNotifyPropertyChanged(); } }

        public Tempo(uint beatsPerMinute)
        {
            BeatsPerMinute = beatsPerMinute;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaiseNotifyPropertyChanged([CallerMemberName] string property = "ERROR")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
