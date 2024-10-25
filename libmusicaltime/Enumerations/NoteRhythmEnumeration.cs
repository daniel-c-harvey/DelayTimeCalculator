using libmusicaltime;
using core;

namespace libmusicaltime.Enumerations
{
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
}
