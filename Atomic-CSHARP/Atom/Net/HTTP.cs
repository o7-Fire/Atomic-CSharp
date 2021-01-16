using System.IO;
using System.Net.Http;

namespace Atomic_CSHARP.Atom.Net
{
    public class HTTP
    {
        private static HttpClient _client = new HttpClient();

        public static HttpResponseMessage post(string url, byte[] data)
        {
            return _client.PostAsync(url, new ByteArrayContent(data)).Result;
        }

        public static HttpResponseMessage post(string url, string data)
        {
            return _client.PostAsync(url, new StringContent(data)).Result;
        }

        public static HttpResponseMessage post(string url, Stream data)
        {
            return _client.PostAsync(url, new StreamContent(data)).Result;
        }

        public static HttpResponseMessage get(string url)
        {
            return _client.GetAsync(url).Result;
        }

        public static Stream getStream(string url)
        {
            return _client.GetStreamAsync(url).Result;
        }

        public static string getString(string url)
        {
            return _client.GetStringAsync(url).Result;
        }

        public static byte[] getByteArray(string url)
        {
            return _client.GetByteArrayAsync(url).Result;
        }
    }
}