using System;
using libdelaytime;

namespace delaytimetester
{
    class Program
    {
        static void Main(string[] args)
        {
            DelayTimeCalculator calc = new();

            Console.WriteLine("4/4 Quarter Notes at 120 BPM: " + calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Quarter, TimeDivision.millisecond).ToString() + " milliseconds");
            Console.WriteLine("4/4 Eighth Notes at 120 BPM: " + calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth, TimeDivision.millisecond).ToString() + " milliseconds");
            Console.WriteLine("4/4 Dotted Eight Notes at 120 BPM: " + calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth.Dotted(), TimeDivision.millisecond).ToString() + " milliseconds");
            Console.WriteLine("4/4 Dotted Eight Notes at 120 BPM: " + calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(120), NoteRhythm.Eighth.Dotted(), TimeDivision.second).ToString() + " seconds");
            Console.WriteLine("4/4  Eight Notes at 150 BPM: " + calc.CalculateDelayTime(new TimeSignature(4, 4), new Tempo(150), NoteRhythm.Eighth, TimeDivision.millisecond).ToString() + " milliseconds");
            Console.ReadLine();
        }
    }
}
