using System;

namespace libdelaytime
{
    public class NoteRhythm
    {
        private uint Subdivision { get; }
        private NoteRhythmModifier Modifier { get; set; }

        public NoteRhythm(uint subdivision, NoteRhythmModifier mod = null)
        {
            if (mod is null)
            {
                Modifier = NoteRhythmModifier.normal;
            }

            Subdivision = subdivision;
        }

        public NoteRhythm Dotted()
        {
            return this.Modify(NoteRhythmModifier.dotted);
        }

        public NoteRhythm Modify(NoteRhythmModifier modifier)
        {
            Modifier = modifier;
            return this;
        }

        public static NoteRhythm Whole = new(1);

        public static NoteRhythm Half = new(2);

        public static NoteRhythm Quarter = new(4);

        public static NoteRhythm Eighth = new(8);

        public static NoteRhythm Sixtennth = new(16);

        public static NoteRhythm ThirtySecond = new(32);

        // This is for calculating the real number ratio between two subdivisons.  they are meant to be uswed relatively.
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

        public static NoteRhythmModifier normal = new(1);
        public static NoteRhythmModifier dotted = new(1.5);

    }
}