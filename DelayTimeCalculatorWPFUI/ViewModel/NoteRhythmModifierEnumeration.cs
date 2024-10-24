using libmusicaltime;
using core;

namespace DelayTimeCalculatorWPFUI.ViewModel
{
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
}
