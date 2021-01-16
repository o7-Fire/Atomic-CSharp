using System.Collections.Generic;
using System.Diagnostics;

namespace Atomic_CSHARP.Atom.Time
{
    public class Countdown
    {
        private static Queue<StopwatchCountdown> lastCount;
        private static StopwatchCountdown last;

        static Countdown()
        {
            reset();
        }

        public static void start()
        {
            start(TimeUnit.MILLISECONDS);
        }

        public static void start(TimeUnit t)
        {
            lastCount.Enqueue(new StopwatchCountdown(Stopwatch.StartNew(), t));
        }

        public static long stop()
        {
            if (lastCount.Count == 0) return 0L;
            last = lastCount.Dequeue();
            return last._stopwatch.ElapsedTicks;
        }

        public static string result()
        {
            return get() + " Milliseconds";
        }

        public static string result(TimeUnit a)
        {
            return result(get(), a);
        }

        public static string result(long a)
        {
            return result(a, TimeUnit.MILLISECONDS);
        }

        public static string result(long a, TimeUnit b)
        {
            return b.convert(currentTimeMillis() - a, TimeUnit.MILLISECONDS) + " " + b.ToString();
        }

        public static long get()
        {
            return last?._stopwatch.ElapsedMilliseconds ?? 0;
        }

        public static void reset()
        {
            lastCount = new Queue<StopwatchCountdown>();
            last = null;
        }

        public static long currentTimeMillis()
        {
            Stopwatch s = Stopwatch.StartNew();
            s.Stop();
            return s.ElapsedMilliseconds;
        }
    }

    public class StopwatchCountdown
    {
        public Stopwatch _stopwatch;
        public TimeUnit _TimeSpan;

        public StopwatchCountdown(Stopwatch sw, TimeUnit ts)
        {
            _stopwatch = sw;
            _TimeSpan = ts;
        }
    }
}