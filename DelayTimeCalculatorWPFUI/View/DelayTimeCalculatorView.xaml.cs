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
            AttachHandlers();
        }

        private void InitAssignDefaults()
        {
            model.Init();
        }

        public void AttachHandlers()
        {
            txtTimeSigBeats.TextChanged += Recalculate;
            txtTimeSigPulse.TextChanged += Recalculate;
            txtTempo.TextChanged += Recalculate;

            cbo.SelectionChanged += Recalculate;
            grpModifier.SelectedItemChanged += Recalculate;
            grpTimeUnit.SelectedItemChanged += Recalculate;
        }

        public void Recalculate(Object sender, EventArgs e)
        {
            model.Recalculate();
        }
    }
}
