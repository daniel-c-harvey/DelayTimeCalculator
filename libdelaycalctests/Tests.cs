using Microsoft.VisualStudio.TestTools.UnitTesting;
using libmusicaltime;
using testutils;

namespace libdelaycalctests
{

    [TestClass]
    public class Tests
    {
        DelayTimeCalculator calc;

        [TestInitialize]
        public void Init()
        {
            calc = new DelayTimeCalculator();
        }

        [TestMethod]
        public void Pass44QuarterNotes120BPMInMilliseconds()
        {
            AssertExtensions.AreClose(500, calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Quarter, TimeDivision.Millisecond), 0.00001);
        }
        
        [TestMethod]
        public void Pass44EighthNotes120BPMInMilliseconds()
        {
            AssertExtensions.AreClose(250, calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth, TimeDivision.Millisecond), 0.00001);
        }
        
        [TestMethod]
        public void Pass44DottedEighthNotes120BPMInMilliseconds()
        {
            AssertExtensions.AreClose(166.66667, calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth.Dotted(), TimeDivision.Millisecond), 0.00001);
        }
        
        [TestMethod]
        public void Pass44DottedEighthNotes120BPMInSeconds()
        {
            AssertExtensions.AreClose(0.166667, calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth.Dotted(), TimeDivision.Second), 0.00001);
        }
        
        [TestMethod]
        public void Pass44EighthNotes150BPMInMilliseconds()
        {
            AssertExtensions.AreClose(133.33333, calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(150), NoteRhythm.Eighth, TimeDivision.Millisecond), 0.00001);
        }
    }
}
