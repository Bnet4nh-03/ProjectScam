using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using ATV_Common_WebAPI.Common.Interfaces;

namespace ATV_Common_WebAPI.Common.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var ms = new MemoryStream();
            using (var cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var gzipStream = new GZipStream(cryptoStream, CompressionMode.Compress))
            using (var sw = new StreamWriter(gzipStream, Encoding.UTF8))
            {
                sw.Write(plainText);
            }

            var encrypted = ms.ToArray();
            return Base85.Encode(encrypted);
        }

        public string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            var encrypted = Base85.Decode(cipherText);

            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var ms = new MemoryStream(encrypted);
            using var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var gzipStream = new GZipStream(cryptoStream, CompressionMode.Decompress);
            using var sr = new StreamReader(gzipStream, Encoding.UTF8);

            return sr.ReadToEnd();
        }

        public static string GenerateRandomKxi()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] keyBytes = new byte[32]; // 32 bytes for AES-256
                rng.GetBytes(keyBytes);

                byte[] ivBytes = new byte[16];  // 16 bytes for AES
                rng.GetBytes(ivBytes);

                string keyString = Base85.Encode(keyBytes);
                string ivString = Base85.Encode(ivBytes);

                return $"{keyString}:{ivString}";
            }
        }
    }

    public static class Base85
    {
        private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&()*+-;<=>?@^_`{|}~";

        private static readonly sbyte[] DecodeTable = BuildDecodeTable();

        private static sbyte[] BuildDecodeTable()
        {
            var table = new sbyte[256];
            for (int i = 0; i < table.Length; i++) table[i] = -1;
            for (int i = 0; i < Alphabet.Length; i++)
                table[(byte)Alphabet[i]] = (sbyte)i;
            return table;
        }

        public static string Encode(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (data.Length % 4 != 0) throw new ArgumentException("Input data length must be a multiple of 4.", nameof(data));

            var sb = new StringBuilder((data.Length / 4) * 5);
            for (int i = 0; i < data.Length; i += 4)
            {
                uint value = ((uint)data[i] << 24) | ((uint)data[i + 1] << 16) |
                             ((uint)data[i + 2] << 8) | data[i + 3];
                char[] block = new char[5];
                for (int j = 4; j >= 0; j--)
                {
                    block[j] = Alphabet[(int)(value % 85)];
                    value /= 85;
                }
                sb.Append(block);
            }

            return sb.ToString();
        }

        public static byte[] Decode(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            if (text.Length % 5 != 0) throw new FormatException("Base85 string length must be a multiple of 5.");

            var output = new MemoryStream((text.Length / 5) * 4);
            for (int i = 0; i < text.Length; i += 5)
            {
                uint value = 0;
                for (int j = 0; j < 5; j++)
                {
                    sbyte code = DecodeTable[(byte)text[i + j]];
                    if (code < 0)
                        throw new FormatException($"Invalid Base85 character '{text[i + j]}'");
                    value = value * 85 + (uint)code;
                }
                output.WriteByte((byte)(value >> 24));
                output.WriteByte((byte)(value >> 16));
                output.WriteByte((byte)(value >> 8));
                output.WriteByte((byte)value);
            }

            return output.ToArray();
        }
    }
}