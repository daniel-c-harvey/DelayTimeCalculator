using CustomControls;
using libmusicaltime.Enumerations;

namespace DelayTimeCalculatorWinFormsUI
{
    class NoteSubdivisionRadioButton : EnumeratedRadioButton<NoteRhythmEnumeration> { }
    class NoteSubdivisionRadioGroupBox : EnumeratedRadioGroupBox<NoteRhythmEnumeration> { }
    class NoteModifierRadioButton : EnumeratedRadioButton<NoteRhythmModifierEnumeration> { }
    class NoteModifierRadioGroupBox : EnumeratedRadioGroupBox<NoteRhythmModifierEnumeration> { }
    class TimeUnitRadioButton : EnumeratedRadioButton<TimeDivisionEnumeration> { }
    class TimeUnitRadioGroupBox : EnumeratedRadioGroupBox<TimeDivisionEnumeration> { }

    partial class DelayTimeCalculatorWinFormsUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayTimeCalculatorWinFormsUI));
            this.lblTimeSig = new System.Windows.Forms.Label();
            this.txtTimeSigBeats = new System.Windows.Forms.TextBox();
            this.txtTimeSigPulse = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpNoteSubdivision = new NoteSubdivisionRadioGroupBox();
            this.radWhole = new NoteSubdivisionRadioButton();
            this.radThirtySecond = new NoteSubdivisionRadioButton();
            this.radSixteenth = new NoteSubdivisionRadioButton();
            this.radEighth = new NoteSubdivisionRadioButton();
            this.radQuarter = new NoteSubdivisionRadioButton();
            this.radHalf = new NoteSubdivisionRadioButton();
            this.grpModifier = new NoteModifierRadioGroupBox();
            this.radTriplet = new NoteModifierRadioButton();
            this.radDotted = new NoteModifierRadioButton();
            this.radNatural = new NoteModifierRadioButton();
            this.lblTempo = new System.Windows.Forms.Label();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.lblBPM = new System.Windows.Forms.Label();
            this.grpTimeUnit = new TimeUnitRadioGroupBox();
            this.radMinutes = new TimeUnitRadioButton();
            this.radSeconds = new TimeUnitRadioButton();
            this.radMilliseconds = new TimeUnitRadioButton();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeUnits = new System.Windows.Forms.Label();
            this.grpNoteSubdivision.SuspendLayout();
            this.grpModifier.SuspendLayout();
            this.grpTimeUnit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimeSig
            // 
            this.lblTimeSig.AutoSize = true;
            this.lblTimeSig.Location = new System.Drawing.Point(14, 23);
            this.lblTimeSig.Name = "lblTimeSig";
            this.lblTimeSig.Size = new System.Drawing.Size(52, 26);
            this.lblTimeSig.TabIndex = 0;
            this.lblTimeSig.Text = "Time\r\nSignature";
            this.lblTimeSig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTimeSigBeats
            // 
            this.txtTimeSigBeats.Location = new System.Drawing.Point(72, 13);
            this.txtTimeSigBeats.Name = "txtTimeSigBeats";
            this.txtTimeSigBeats.Size = new System.Drawing.Size(27, 20);
            this.txtTimeSigBeats.TabIndex = 1;
            // 
            // txtTimeSigPulse
            // 
            this.txtTimeSigPulse.Location = new System.Drawing.Point(72, 39);
            this.txtTimeSigPulse.Name = "txtTimeSigPulse";
            this.txtTimeSigPulse.Size = new System.Drawing.Size(27, 20);
            this.txtTimeSigPulse.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // grpNoteSubdivision
            // 
            this.grpNoteSubdivision.Controls.Add(this.radWhole);
            this.grpNoteSubdivision.Controls.Add(this.radThirtySecond);
            this.grpNoteSubdivision.Controls.Add(this.radSixteenth);
            this.grpNoteSubdivision.Controls.Add(this.radEighth);
            this.grpNoteSubdivision.Controls.Add(this.radQuarter);
            this.grpNoteSubdivision.Controls.Add(this.radHalf);
            this.grpNoteSubdivision.Location = new System.Drawing.Point(12, 65);
            this.grpNoteSubdivision.Name = "grpNoteSubdivision";
            this.grpNoteSubdivision.Size = new System.Drawing.Size(345, 55);
            this.grpNoteSubdivision.TabIndex = 2;
            this.grpNoteSubdivision.TabStop = false;
            this.grpNoteSubdivision.Text = "Note Subdivision";
            // 
            // radWhole
            // 
            this.radWhole.AutoSize = true;
            this.radWhole.Location = new System.Drawing.Point(6, 19);
            this.radWhole.Name = "radWhole";
            this.radWhole.Size = new System.Drawing.Size(42, 17);
            this.radWhole.TabIndex = 0;
            this.radWhole.TabStop = true;
            this.radWhole.Text = "1/1";
            this.radWhole.UseVisualStyleBackColor = true;
            this.radWhole.Value = null;
            // 
            // radThirtySecond
            // 
            this.radThirtySecond.AutoSize = true;
            this.radThirtySecond.Location = new System.Drawing.Point(252, 19);
            this.radThirtySecond.Name = "radThirtySecond";
            this.radThirtySecond.Size = new System.Drawing.Size(48, 17);
            this.radThirtySecond.TabIndex = 0;
            this.radThirtySecond.TabStop = true;
            this.radThirtySecond.Text = "1/32";
            this.radThirtySecond.UseVisualStyleBackColor = true;
            this.radThirtySecond.Value = null;
            // 
            // radSixteenth
            // 
            this.radSixteenth.AutoSize = true;
            this.radSixteenth.Location = new System.Drawing.Point(198, 19);
            this.radSixteenth.Name = "radSixteenth";
            this.radSixteenth.Size = new System.Drawing.Size(48, 17);
            this.radSixteenth.TabIndex = 0;
            this.radSixteenth.TabStop = true;
            this.radSixteenth.Text = "1/16";
            this.radSixteenth.UseVisualStyleBackColor = true;
            this.radSixteenth.Value = null;
            // 
            // radEighth
            // 
            this.radEighth.AutoSize = true;
            this.radEighth.Location = new System.Drawing.Point(150, 19);
            this.radEighth.Name = "radEighth";
            this.radEighth.Size = new System.Drawing.Size(42, 17);
            this.radEighth.TabIndex = 0;
            this.radEighth.TabStop = true;
            this.radEighth.Text = "1/8";
            this.radEighth.UseVisualStyleBackColor = true;
            this.radEighth.Value = null;
            // 
            // radQuarter
            // 
            this.radQuarter.AutoSize = true;
            this.radQuarter.Location = new System.Drawing.Point(102, 19);
            this.radQuarter.Name = "radQuarter";
            this.radQuarter.Size = new System.Drawing.Size(42, 17);
            this.radQuarter.TabIndex = 0;
            this.radQuarter.TabStop = true;
            this.radQuarter.Text = "1/4";
            this.radQuarter.UseVisualStyleBackColor = true;
            this.radQuarter.Value = null;
            // 
            // radHalf
            // 
            this.radHalf.AutoSize = true;
            this.radHalf.Location = new System.Drawing.Point(54, 19);
            this.radHalf.Name = "radHalf";
            this.radHalf.Size = new System.Drawing.Size(42, 17);
            this.radHalf.TabIndex = 0;
            this.radHalf.TabStop = true;
            this.radHalf.Text = "1/2";
            this.radHalf.UseVisualStyleBackColor = true;
            this.radHalf.Value = null;
            // 
            // grpModifier
            // 
            this.grpModifier.Controls.Add(this.radTriplet);
            this.grpModifier.Controls.Add(this.radDotted);
            this.grpModifier.Controls.Add(this.radNatural);
            this.grpModifier.Location = new System.Drawing.Point(12, 126);
            this.grpModifier.Name = "grpModifier";
            this.grpModifier.Size = new System.Drawing.Size(192, 53);
            this.grpModifier.TabIndex = 2;
            this.grpModifier.TabStop = false;
            this.grpModifier.Text = "Note Rhythm Modifier";
            // 
            // radTriplet
            // 
            this.radTriplet.AutoSize = true;
            this.radTriplet.Location = new System.Drawing.Point(134, 19);
            this.radTriplet.Name = "radTriplet";
            this.radTriplet.Size = new System.Drawing.Size(54, 17);
            this.radTriplet.TabIndex = 0;
            this.radTriplet.TabStop = true;
            this.radTriplet.Text = "Triplet";
            this.radTriplet.UseVisualStyleBackColor = true;
            this.radTriplet.Value = null;
            // 
            // radDotted
            // 
            this.radDotted.AutoSize = true;
            this.radDotted.Location = new System.Drawing.Point(71, 19);
            this.radDotted.Name = "radDotted";
            this.radDotted.Size = new System.Drawing.Size(57, 17);
            this.radDotted.TabIndex = 0;
            this.radDotted.TabStop = true;
            this.radDotted.Text = "Dotted";
            this.radDotted.UseVisualStyleBackColor = true;
            this.radDotted.Value = null;
            // 
            // radNatural
            // 
            this.radNatural.AutoSize = true;
            this.radNatural.Location = new System.Drawing.Point(7, 20);
            this.radNatural.Name = "radNatural";
            this.radNatural.Size = new System.Drawing.Size(58, 17);
            this.radNatural.TabIndex = 0;
            this.radNatural.TabStop = true;
            this.radNatural.Text = "Normal";
            this.radNatural.UseVisualStyleBackColor = true;
            this.radNatural.Value = null;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(111, 13);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(40, 13);
            this.lblTempo.TabIndex = 3;
            this.lblTempo.Text = "Tempo";
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(114, 29);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(61, 20);
            this.txtTempo.TabIndex = 4;
            // 
            // lblBPM
            // 
            this.lblBPM.AutoSize = true;
            this.lblBPM.Location = new System.Drawing.Point(181, 32);
            this.lblBPM.Name = "lblBPM";
            this.lblBPM.Size = new System.Drawing.Size(30, 13);
            this.lblBPM.TabIndex = 5;
            this.lblBPM.Text = "BPM";
            // 
            // grpTimeUnit
            // 
            this.grpTimeUnit.Controls.Add(this.radMinutes);
            this.grpTimeUnit.Controls.Add(this.radSeconds);
            this.grpTimeUnit.Controls.Add(this.radMilliseconds);
            this.grpTimeUnit.Location = new System.Drawing.Point(211, 127);
            this.grpTimeUnit.Name = "grpTimeUnit";
            this.grpTimeUnit.Size = new System.Drawing.Size(146, 52);
            this.grpTimeUnit.TabIndex = 6;
            this.grpTimeUnit.TabStop = false;
            this.grpTimeUnit.Text = "Time Unit";
            // 
            // radMinutes
            // 
            this.radMinutes.AutoSize = true;
            this.radMinutes.Location = new System.Drawing.Point(99, 20);
            this.radMinutes.Name = "radMinutes";
            this.radMinutes.Size = new System.Drawing.Size(41, 17);
            this.radMinutes.TabIndex = 0;
            this.radMinutes.TabStop = true;
            this.radMinutes.Text = "min";
            this.radMinutes.UseVisualStyleBackColor = true;
            this.radMinutes.Value = null;
            // 
            // radSeconds
            // 
            this.radSeconds.AutoSize = true;
            this.radSeconds.Location = new System.Drawing.Point(51, 20);
            this.radSeconds.Name = "radSeconds";
            this.radSeconds.Size = new System.Drawing.Size(42, 17);
            this.radSeconds.TabIndex = 0;
            this.radSeconds.TabStop = true;
            this.radSeconds.Text = "sec";
            this.radSeconds.UseVisualStyleBackColor = true;
            this.radSeconds.Value = null;
            // 
            // radMilliseconds
            // 
            this.radMilliseconds.AutoSize = true;
            this.radMilliseconds.Location = new System.Drawing.Point(7, 20);
            this.radMilliseconds.Name = "radMilliseconds";
            this.radMilliseconds.Size = new System.Drawing.Size(38, 17);
            this.radMilliseconds.TabIndex = 0;
            this.radMilliseconds.TabStop = true;
            this.radMilliseconds.Text = "ms";
            this.radMilliseconds.UseVisualStyleBackColor = true;
            this.radMilliseconds.Value = null;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(229, 29);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(75, 20);
            this.txtTime.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(228, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time";
            // 
            // lblTimeUnits
            // 
            this.lblTimeUnits.AutoSize = true;
            this.lblTimeUnits.Location = new System.Drawing.Point(310, 32);
            this.lblTimeUnits.Name = "lblTimeUnits";
            this.lblTimeUnits.Size = new System.Drawing.Size(65, 13);
            this.lblTimeUnits.TabIndex = 9;
            this.lblTimeUnits.Text = "<unit><unit>";
            // 
            // DelayTimeCalculatorWinFormsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 200);
            this.Controls.Add(this.lblTimeUnits);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.grpTimeUnit);
            this.Controls.Add(this.lblBPM);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.grpModifier);
            this.Controls.Add(this.grpNoteSubdivision);
            this.Controls.Add(this.txtTimeSigPulse);
            this.Controls.Add(this.txtTimeSigBeats);
            this.Controls.Add(this.lblTimeSig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelayTimeCalculatorWinFormsUI";
            this.Text = "Delay Time Calculator";
            this.Load += new System.EventHandler(this.DelayTimeCalculatorWinFormsUI_Load);
            this.grpNoteSubdivision.ResumeLayout(false);
            this.grpNoteSubdivision.PerformLayout();
            this.grpModifier.ResumeLayout(false);
            this.grpModifier.PerformLayout();
            this.grpTimeUnit.ResumeLayout(false);
            this.grpTimeUnit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimeSig;
        private System.Windows.Forms.TextBox txtTimeSigBeats;
        private System.Windows.Forms.TextBox txtTimeSigPulse;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private NoteSubdivisionRadioGroupBox grpNoteSubdivision;
        private NoteModifierRadioGroupBox grpModifier;
        private NoteSubdivisionRadioButton radWhole;
        private NoteSubdivisionRadioButton radThirtySecond;
        private NoteSubdivisionRadioButton radSixteenth;
        private NoteSubdivisionRadioButton radEighth;
        private NoteSubdivisionRadioButton radQuarter;
        private NoteSubdivisionRadioButton radHalf;
        private NoteModifierRadioButton radNatural;
        private NoteModifierRadioButton radDotted;
        private NoteModifierRadioButton radTriplet;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Label lblBPM;
        private TimeUnitRadioGroupBox grpTimeUnit;
        private TimeUnitRadioButton radMinutes;
        private TimeUnitRadioButton radSeconds;
        private TimeUnitRadioButton radMilliseconds;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeUnits;
    }
}

