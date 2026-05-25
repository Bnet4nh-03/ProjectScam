using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace ATV_Common_WebAPI.Client_Utility.CSharp
{
    public class TestRequestDbEnco
    {


        class Program
        {
            static void Main()
            {
                Console.WriteLine("AES + GZip + Base85 Test");

                string json = "{\"spName\": \"[ATV_Common].[dbo].[TEST_Common]\",\"spQuery\": {\"@user_id\": \"112\",\"@badgeno\": \"abca\"},\"logSave\": false}";

                // Generate AES key and IV
                byte[] key = new byte[32];
                byte[] iv = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                    rng.GetBytes(iv);
                }

                string kxi = $"{Base85.Encode(key)}:{Base85.Encode(iv)}";
                Console.WriteLine($"KXI: {kxi}");

                // Encrypt
                string encrypted = Encrypt(json, key, iv);
                Console.WriteLine($"Encrypted: {encrypted}");

                // Decrypt
                string decrypted = Decrypt(encrypted, key, iv);
                Console.WriteLine($"Decrypted: {decrypted}");
            }

            static string Encrypt(string plainText, byte[] key, byte[] iv)
            {
                byte[] compressed = Compress(Encoding.UTF8.GetBytes(plainText));
                byte[] padded = ApplyPKCS7(compressed);

                using var aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;

                using var encryptor = aes.CreateEncryptor();
                byte[] encrypted = encryptor.TransformFinalBlock(padded, 0, padded.Length);

                return Base85.Encode(encrypted);
            }

            static string Decrypt(string cipherText, byte[] key, byte[] iv)
            {
                byte[] encrypted = Base85.Decode(cipherText);

                using var aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;

                using var decryptor = aes.CreateDecryptor();
                byte[] padded = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
                byte[] unpadded = RemovePKCS7(padded);
                byte[] decompressed = Decompress(unpadded);

                return Encoding.UTF8.GetString(decompressed);
            }

            static byte[] Compress(byte[] data)
            {
                using var output = new MemoryStream();
                using (var gzip = new GZipStream(output, CompressionMode.Compress))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return output.ToArray();
            }

            static byte[] Decompress(byte[] data)
            {
                using var input = new MemoryStream(data);
                using var gzip = new GZipStream(input, CompressionMode.Decompress);
                using var output = new MemoryStream();
                gzip.CopyTo(output);
                return output.ToArray();
            }

            static byte[] ApplyPKCS7(byte[] data)
            {
                int blockSize = 16;
                int padLen = blockSize - data.Length % blockSize;
                byte[] padded = new byte[data.Length + padLen];
                Buffer.BlockCopy(data, 0, padded, 0, data.Length);
                for (int i = data.Length; i < padded.Length; i++)
                    padded[i] = (byte)padLen;
                return padded;
            }

            static byte[] RemovePKCS7(byte[] data)
            {
                int padLen = data[^1];
                byte[] unpadded = new byte[data.Length - padLen];
                Buffer.BlockCopy(data, 0, unpadded, 0, unpadded.Length);
                return unpadded;
            }

            // Minimal Base85 encoder/decoder (Z85 style)
            public static class Base85
            {
                private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&()*+-;<=>?@^_`{|}~";
                private static readonly byte[] Decoding = new byte[256];

                static Base85()
                {
                    for (int i = 0; i < Decoding.Length; i++) Decoding[i] = 0xFF;
                    for (int i = 0; i < Alphabet.Length; i++) Decoding[Alphabet[i]] = (byte)i;
                }

                public static string Encode(byte[] data)
                {
                    int len = data.Length;
                    int pad = (4 - len % 4) % 4;
                    byte[] padded = new byte[len + pad];
                    Buffer.BlockCopy(data, 0, padded, 0, len);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < padded.Length; i += 4)
                    {
                        uint val = BitConverter.ToUInt32(padded, i);
                        char[] chunk = new char[5];
                        for (int j = 4; j >= 0; j--)
                        {
                            chunk[j] = Alphabet[(int)(val % 85)];
                            val /= 85;
                        }
                        sb.Append(chunk);
                    }
                    return sb.ToString();
                }

                public static byte[] Decode(string text)
                {
                    int len = text.Length;
                    int pad = (5 - len % 5) % 5;
                    string padded = text + new string(Alphabet[0], pad);

                    byte[] result = new byte[padded.Length / 5 * 4];
                    for (int i = 0; i < padded.Length; i += 5)
                    {
                        uint val = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            val = val * 85 + Decoding[padded[i + j]];
                        }
                        byte[] chunk = BitConverter.GetBytes(val);
                        Buffer.BlockCopy(chunk, 0, result, i / 5 * 4, 4);
                    }
                    return result[..(result.Length - pad)];
                }
            }
        }
    }
}
