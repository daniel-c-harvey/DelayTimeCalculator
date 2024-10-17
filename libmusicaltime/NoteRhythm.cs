using System;

namespace libmusicaltime
{
    public class NoteRhythm
    {
        public uint Subdivision { get; set; }
        public NoteRhythmModifier Modifier { get; set; }

        public NoteRhythm(uint subdivision, NoteRhythmModifier mod = null)
        {
            Modifier = mod ?? NoteRhythmModifier.Normal;
            Subdivision = subdivision;
        }

        public NoteRhythm Dotted()
        {
            return this.Modify(NoteRhythmModifier.Dotted);
        }

        public NoteRhythm Modify(NoteRhythmModifier modifier)
        {
            Modifier = modifier;
            return this;
        }

        // preset members
        public static NoteRhythm Whole = new NoteRhythm(1);
        public static NoteRhythm Half = new NoteRhythm(2);
        public static NoteRhythm Quarter = new NoteRhythm(4);
        public static NoteRhythm Eighth = new NoteRhythm(8);
        public static NoteRhythm Sixteenth = new NoteRhythm(16);
        public static NoteRhythm ThirtySecond = new NoteRhythm(32);


        // This is for calculating the real number ratio between two subdivisons.  they are meant to be used relatively.
        public static double operator /(NoteRhythm a, NoteRhythm b)
        {
            return (a.Subdivision * a.Modifier.Multiplier / (b.Subdivision * b.Modifier.Multiplier));
        }

    }

    public class NoteRhythmModifier
    {
        public double Multiplier { get; }

        public NoteRhythmModifier(double multiplier)
        {
            Multiplier = multiplier;
        }

        // preset members
        public static NoteRhythmModifier Normal = new NoteRhythmModifier(1);
        public static NoteRhythmModifier Dotted = new NoteRhythmModifier(1.5);
        public static NoteRhythmModifier Triplet = new NoteRhythmModifier(2.0 / 3.0);

    }
}