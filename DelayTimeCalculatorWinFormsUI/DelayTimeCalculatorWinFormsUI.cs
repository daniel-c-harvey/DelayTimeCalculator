using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libmusicaltime;
using libmusicaltime.Enumerations;
using CustomControls;

namespace DelayTimeCalculatorWinFormsUI
{
    public partial class DelayTimeCalculatorWinFormsUI : Form
    {
        private DelayTimeCalculatorViewModel model;
        
        public DelayTimeCalculatorWinFormsUI()
        {
            InitializeComponent();
            InitializeMembers();
            TagRadios();
        }

        private void InitializeMembers()
        {
            model = new DelayTimeCalculatorViewModel();
        }

        private void TagRadios()
        {
            radWhole.Value = NoteRhythmEnumeration.Whole;
            radHalf.Value = NoteRhythmEnumeration.Half;
            radQuarter.Value = NoteRhythmEnumeration.Quarter;
            radEighth.Value = NoteRhythmEnumeration.Eighth;
            radSixteenth.Value = NoteRhythmEnumeration.Sixteenth;
            radThirtySecond.Value = NoteRhythmEnumeration.ThirtySecond;

            radNatural.Value = NoteRhythmModifierEnumeration.Normal;
            radDotted.Value = NoteRhythmModifierEnumeration.Dotted;
            radTriplet.Value = NoteRhythmModifierEnumeration.Triplet;

            radMilliseconds.Value = TimeDivisionEnumeration.Millisecond;
            radSeconds.Value = TimeDivisionEnumeration.Second;
            radMinutes.Value = TimeDivisionEnumeration.Minute;
        }

        private void DelayTimeCalculatorWinFormsUI_Load(object sender, System.EventArgs e)
        {
            InitAssignDefaults();
            DataBind();
            AttachHandlers();
        }

        private void DataBind()
        {
            // Inputs
            txtTimeSigBeats.DataBindings.Add(
                new Binding(
                    nameof(txtTimeSigBeats.Text), 
                    model.TimeSignature, 
                    nameof(model.TimeSignature.Beats)));

            txtTimeSigPulse.DataBindings.Add(
                new Binding(
                    nameof(txtTimeSigPulse.Text), 
                    model.TimeSignature.Pulse, 
                    nameof(model.TimeSignature.Pulse.Subdivision)));

            txtTempo.DataBindings.Add(
                new Binding(
                    nameof(txtTempo.Text),
                    model.Tempo,
                    nameof(model.Tempo.BeatsPerMinute)));

            grpNoteSubdivision.DataBindings.Add(
                new Binding(
                    nameof(grpNoteSubdivision.SelectedRadioValue),
                    model,
                    nameof(model.NoteSubdivision)));

            grpModifier.DataBindings.Add(
                new Binding(
                    nameof(grpModifier.SelectedRadioValue),
                    model,
                    nameof(model.NoteModifier)));

            grpTimeUnit.DataBindings.Add(
                new Binding(
                    nameof(grpTimeUnit.SelectedRadioValue),
                    model,
                    nameof(model.TimeUnit)));

            var timeValueBinding = new Binding(
                nameof(txtTime.Text),
                model,
                nameof(model.TimeOutput));
            timeValueBinding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            txtTime.DataBindings.Add(timeValueBinding);

            lblTimeUnits.DataBindings.Add(
                new Binding(
                    nameof(lblTimeUnits.Text),
                    model.TimeUnit,
                    nameof(model.TimeUnit.Name)));
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
            //txtTempo.TextChanged += Recalculate;
            txtTempo.TextChanged += a;

            grpNoteSubdivision.CheckedChanged += Recalculate;
            grpModifier.CheckedChanged += Recalculate;
            grpTimeUnit.CheckedChanged += Recalculate;
        }

        public void Recalculate(Object sender, EventArgs e)
        {
            model.TimeOutput = model.Calculator.CalculateDelayTime(
                model.TimeSignature,
                model.Tempo,
                model.NoteSubdivision.Rhythm,
                model.TimeUnit.Time);
        }

        public void a(Object sender, EventArgs e)
        {

        }
    }
}
