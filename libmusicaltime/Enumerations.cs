using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using core;

namespace libmusicaltime.Enumerations
{
    public class NoteRhythmEnumeration : Enumeration<NoteRhythmEnumeration>, INotifyPropertyChanged
    {
        public NoteRhythm Rhythm { get; }

        public static NoteRhythmEnumeration Whole = new NoteRhythmEnumeration(NoteRhythm.Whole);
        public static NoteRhythmEnumeration Half = new NoteRhythmEnumeration(NoteRhythm.Half);
        public static NoteRhythmEnumeration Quarter = new NoteRhythmEnumeration(NoteRhythm.Quarter);
        public static NoteRhythmEnumeration Eighth = new NoteRhythmEnumeration(NoteRhythm.Eighth);
        public static NoteRhythmEnumeration Sixteenth = new NoteRhythmEnumeration(NoteRhythm.Sixteenth);
        public static NoteRhythmEnumeration ThirtySecond = new NoteRhythmEnumeration(NoteRhythm.ThirtySecond);
        
        public NoteRhythmEnumeration(
            NoteRhythm rhythm, 
            [CallerMemberName] string sName = "ERROR") 
            : base((int)rhythm.Subdivision, sName)
        {
            Rhythm = rhythm;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaiseNotifyPropertyChanged([CallerMemberName] string property = "ERROR")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    public class NoteRhythmModifierEnumeration : Enumeration<NoteRhythmModifierEnumeration>
    {
        public NoteRhythmModifier Modifier { get; }

        public static NoteRhythmModifierEnumeration Normal = new NoteRhythmModifierEnumeration(1, NoteRhythmModifier.Normal);
        public static NoteRhythmModifierEnumeration Dotted = new NoteRhythmModifierEnumeration(2, NoteRhythmModifier.Dotted);
        public static NoteRhythmModifierEnumeration Triplet = new NoteRhythmModifierEnumeration(3, NoteRhythmModifier.Triplet);

        public NoteRhythmModifierEnumeration(
            int iID,
            NoteRhythmModifier modifier,
            [CallerMemberName] string sName = "ERROR") 
            : base(iID, sName)
        {
            Modifier = modifier;
        }
    }

    public class TimeDivisionEnumeration : Enumeration<TimeDivisionEnumeration>
    {
        public TimeDivision Time { get; }

        public static TimeDivisionEnumeration Millisecond = new TimeDivisionEnumeration(1, TimeDivision.Millisecond, "Milliseconds");
        public static TimeDivisionEnumeration Second = new TimeDivisionEnumeration(2, TimeDivision.Second, "Seconds");
        public static TimeDivisionEnumeration Minute = new TimeDivisionEnumeration(3, TimeDivision.Minute, "Minutes");

        public TimeDivisionEnumeration(
            int iID,
            TimeDivision time,
            string sName = "ERROR")
            : base(iID, sName)
        {
            Time = time;
        }
    }
}
