using System.Collections.Generic;
using System.Text;

namespace Atomic_CSHARP.Atom.Utility
{
    public class Utility
    {
        public static string getHex(int h)
        {
            return string.Format("#%06x", h);
        }

        public static string shuffle(string input)
        {
            List<char> characters = new List<char>(input.ToCharArray());
            StringBuilder output = new StringBuilder(input.Length);
            while (characters.Count != 0)
            {
                output.Append(characters.Remove(characters[Random.getInt(characters.Count)]));
            }

            return output.ToString();
        }

        public static T[] joinArray<T>(T[] t1, T[] t2)
        {
            int m = 0;
            T[] t3 = new T[t1.Length + t2.Length];
            for (int i = 0; i < t1.Length; i++)
            {
                m = i;
                t3[m] = t1[m];
            }

            for (int i = m; i < t2.Length; i++)
            {
                t3[m] = t2[i];
            }

            return t3;
        }
    }
}