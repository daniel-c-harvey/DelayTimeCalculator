using System;

namespace libdelaytime
{
    public class DelayTimeCalculator
    {
        public double CalculateDelayTime(TimeSignature timesig, Tempo tempo, NoteRhythm subdivision, TimeDivision timediv)
        {
            double millisecondsPerBeat = TimeDivision.minute.Milliseconds / (double)tempo.BeatsPerMinute;
            double beatRatio = timesig.Pulse / subdivision;
            double timePerSubdivision = millisecondsPerBeat / timediv.Milliseconds * beatRatio;
            return timePerSubdivision;
        }
    }
}
