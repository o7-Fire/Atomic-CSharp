using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Atomic_CSHARP.Atom.Encoder
{
    public class Encoder
    {
        private const int MAX_SKIP_BUFFER_SIZE = 2048;
        private const int MAX_BUFFER_SIZE = int.MaxValue;
        private const int DEFAULT_BUFFER_SIZE = 8192;

        public static string base64Encode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] base64Decode(string s)
        {
            return Convert.FromBase64String(s);
        }

        public static string property(Dictionary<string, string> se)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> s in se) sb.Append(s.Key).Append("=").Append(s.Value).Append("\n");
            return sb.ToString();
        }

        public static Dictionary<string, string> parseProperty(string se)
        {
            Dictionary<string, string> te = new Dictionary<string, string>();
            foreach (string see in se.Split('\n'))
            {
                string s = see;
                if (s.EndsWith("\r")) s = s.Substring(0, s.Length - 1);
                if (!s.StartsWith("#")) te.Add(s.Split('#')[0], s.Split('#')[1]);
            }

            return te;
        }


        public static byte[] readAllBytes(Stream iss)
        {
            return readAllBytes(iss, Int32.MaxValue);
        }

        public static byte[] readAllBytes(Stream stream, int len)
        {
            if (len < 0) throw new ArgumentException("len < 0");
            List<byte[]> bufs = null;
            byte[] result = null;
            int total = 0;
            int remaining = len;
            int n;
            do
            {
                byte[] buf = new byte[Math.Min(remaining, DEFAULT_BUFFER_SIZE)];
                int unread = 0;

                // read to EOF which may read more or less than buffer size
                while ((n = stream.Read(buf, unread, Math.Min(buf.Length - unread, remaining))) > 0)
                {
                    unread += n;
                    remaining -= n;
                }

                if (unread > 0)
                {
                    total += unread;
                    if (result == null)
                    {
                        result = buf;
                    }
                    else
                    {
                        if (bufs == null) bufs = new List<byte[]> {result};
                        bufs.Add(buf);
                    }
                }

                // if the last call to read returned -1 or the number of bytes
                // requested have been read then break
            } while (n >= 0 && remaining > 0);

            if (bufs == null)
            {
                if (result == null) return new byte[0];
                if (result.Length != total) Array.Resize(ref result, total);
                return result;
            }

            result = new byte[total];
            int offset = 0;
            remaining = total;
            foreach (byte[] b in bufs)
            {
                int count = Math.Min(b.Length, remaining);
                Array.Copy(b, 0, result, offset, count);
                offset += count;
                remaining -= count;
            }

            return result;
        }
    }
}