using System;

namespace MayaBinance.Shared.Extensions
{
    public static class StringExtension
    {
        public static string Encrypt(this string text)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
