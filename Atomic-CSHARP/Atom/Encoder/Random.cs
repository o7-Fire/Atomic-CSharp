using System.Collections.Generic;
using System.Text;

namespace Atomic_CSHARP.Atom.Encoder
{
    public class Random : System.Random
    {
        private static readonly Random _random = new Random();

        public static int getRandomColor()
        {
            return _random.Next(0xffffff + 1);
        }

        public static string getRandomHexColor()
        {
            int nextInt = getInt(5000000, 16777215);
            return string.Format("#%06x", nextInt);
        }

        public static T getRandom<T>(List<T> array)
        {
            return array[getInt(array.Count)];
        }

        public static T getRandom<T>(T[] array)
        {
            return array[getInt(array.Length)];
        }

        public static string getString()
        {
            return getString(8);
        }

        public static string getString(int length)
        {
            if (length < 0) return "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append((char) getInt(33, 125));
            }

            return sb.ToString();
        }

        public static double getDouble()
        {
            return _random.NextDouble();
        }

        public static bool getBool()
        {
            return _random.Sample() > 0.5;
        }

        public static bool getBool(double chance)
        {
            return _random.Sample() > chance;
        }

        public static long getLong()
        {
            return getLong(long.MinValue + 1, long.MaxValue - 1);
        }

        public static float getFloat()
        {
            int sign = _random.Next(2);
            int exponent = _random.Next((1 << 8) - 1); // do not generate 0xFF (infinities and NaN)
            int mantissa = _random.Next(1 << 23);

            int bits = (sign << 31) + (exponent << 23) + mantissa;
            return IntBitsToFloat(bits);
        }

        public static float getFloat(float min, float max)
        {
            return min + getFloat() * (max - min);
        }

        public static float getFloat(float max)
        {
            return getFloat(0, max);
        }

        public static int getInt()
        {
            return _random.Next();
        }

        public static int getInt(int max)
        {
            return getInt(0, max);
        }

        public static int getInt(int min, int max)
        {
            return _random.Next(max - min + 1) + min;
        }

        public static double getDouble(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }

        public static long getLong(long min, long max)
        {
            return min + (long) (_random.NextDouble() * (max - min));
        }

        public static long getLong(long max)
        {
            return getLong(0, max);
        }

        public static double getDouble(double max)
        {
            return getDouble(0, max);
        }

        private static unsafe float IntBitsToFloat(int bits)
        {
            return *(float*) &bits;
        }
    }
}