using libmusicaltime.Enumerations;
using libmusicaltime;


namespace DelayTimeCalculatorWPFUI.View
{
    /// <summary>
    /// Interaction logic for DelayTimeCalculatorView.xaml
    /// </summary>
    public partial class DelayTimeCalculatorView : System.Windows.Window
    {
        public DelayTimeCalculatorView()
        {
            InitializeComponent();

            InitAssignDefaults();
        }

        private void InitAssignDefaults()
        {
            model.TimeSignature = new TimeSignature(4, 4);
            model.Tempo = new Tempo(120);
            model.NoteSubdivision = NoteRhythmEnumeration.Quarter;
            model.NoteModifier = NoteRhythmModifierEnumeration.Normal;
            model.TimeUnit = TimeDivisionEnumeration.Millisecond;
        }

        public void AttachHandlers()
        {
            txtTimeSigBeats.TextChanged += Recalculate;
            txtTimeSigPulse.TextChanged += Recalculate;
            txtTempo.TextChanged += Recalculate;

            cbo.SelectionChanged += Recalculate;
            //grpModifier.CheckedChanged += Recalculate;
            //grpTimeUnit.CheckedChanged += Recalculate;
        }

        public void Recalculate(Object sender, EventArgs e)
        {
            model.Recalculate();
        }
    }
}
