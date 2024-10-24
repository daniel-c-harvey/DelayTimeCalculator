using libmusicaltime;
using core;

namespace DelayTimeCalculatorWPFUI.ViewModel
{
    public class TimeDivisionEnumeration : DisplayEnumeration<TimeDivisionEnumeration>
    {
        public TimeDivision Time { get; }

        public static TimeDivisionEnumeration Millisecond = new TimeDivisionEnumeration(1, nameof(Millisecond), TimeDivision.Millisecond, "ms");
        public static TimeDivisionEnumeration Second = new TimeDivisionEnumeration(2, nameof(Second), TimeDivision.Second, "sec");
        public static TimeDivisionEnumeration Minute = new TimeDivisionEnumeration(3, nameof(Minute), TimeDivision.Minute, "min");

        public TimeDivisionEnumeration(
            int iID,
            string name,
            TimeDivision time,
            string sCaption)
            : base(iID, name, sCaption)
        {
            Time = time;
        }
    }
}
