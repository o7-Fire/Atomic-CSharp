using System;

namespace Atomic_CSHARP.Atom.Time
{
    public enum TimeUnit
    {
        TICKS,
        MILLISECONDS,
        SECONDS,
        MINUTES,
        HOURS,
        DAYS
    }

    public static class TimeUnitExtenstion
    {
        public static long convert(this TimeUnit unit, double current, TimeUnit target)
        {
            TimeSpan ts;
            switch (unit)
            {
                case TimeUnit.DAYS:
                    ts = TimeSpan.FromDays(current);
                    break;
                case TimeUnit.HOURS:
                    ts = TimeSpan.FromHours(current);
                    break;
                case TimeUnit.MINUTES:
                    ts = TimeSpan.FromMinutes(current);
                    break;
                case TimeUnit.SECONDS:
                    ts = TimeSpan.FromSeconds(current);
                    break;
                case TimeUnit.MILLISECONDS:
                    ts = TimeSpan.FromMilliseconds(current);
                    break;
                case TimeUnit.TICKS:
                    ts = TimeSpan.FromTicks((long) current);
                    break;
            }

            return 0;
        }
    }
}