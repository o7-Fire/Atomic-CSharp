using System.Security.Cryptography;

namespace Atomic_CSHARP.Atom.Utility
{
    public class Encoder
    {
        public static readonly HashAlgorithm
            sha256 = System.Security.Cryptography.SHA256.Create(),
            sha1 = System.Security.Cryptography.SHA1.Create(),
            md5 = System.Security.Cryptography.MD5.Create();

        public static byte[] SHA256(byte[] bytes)
        {
            return sha256.ComputeHash(bytes);
        }

        public static byte[] SHA1(byte[] bytes)
        {
            return sha1.ComputeHash(bytes);
        }

        public static byte[] MD5(byte[] bytes)
        {
            return md5.ComputeHash(bytes);
        }
    }
}