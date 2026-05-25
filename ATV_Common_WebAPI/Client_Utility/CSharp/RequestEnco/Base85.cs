using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATV_Common_WebAPI.Client_Utility.CSharp.RequestEnco
{
    /// <summary>
    /// Implements the specific Base85 encoding/decoding used by the API.
    /// This is a custom implementation and not the standard Z85 or Ascii85.
    /// </summary>
    public static class Base85
    {
        private static readonly char[] Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&()*+-;<=>?@^_`{|}~".ToCharArray();
        // Corrected line below
        private static readonly Dictionary<char, int> DecodeMap = Alphabet.Select((c, i) => new { Char = c, Index = i }).ToDictionary(x => x.Char, x => x.Index);

        public static string Encode(byte[] data)
        {
            var n = data.Length;
            var paddedLen = (4 - n % 4) % 4;
            var paddedData = new byte[n + paddedLen];
            Buffer.BlockCopy(data, 0, paddedData, 0, n);

            var result = new StringBuilder();
            for (int i = 0; i < paddedData.Length; i += 4)
            {
                uint chunk = (uint)paddedData[i] << 24 | (uint)paddedData[i + 1] << 16 | (uint)paddedData[i + 2] << 8 | paddedData[i + 3];
                var block = new char[5];
                for (int j = 4; j >= 0; j--)
                {
                    block[j] = Alphabet[chunk % 85];
                    chunk /= 85;
                }
                result.Append(block);
            }

            var unpaddedLength = n / 4 * 5 + (n % 4 == 0 ? 0 : n % 4 + 1);
            return result.ToString().Substring(0, unpaddedLength);
        }

        public static byte[] Decode(string text)
        {
            var n = text.Length;
            var paddingNeeded = (5 - n % 5) % 5;
            var paddedText = text.PadRight(n + paddingNeeded, '~'); // Python uses '~~~~~'[:padding_needed] which is equivalent to PadRight with '~'

            var decodedBytes = new List<byte>();
            for (int i = 0; i < paddedText.Length; i += 5)
            {
                ulong chunkValue = 0;
                for (int j = 0; j < 5; j++)
                {
                    chunkValue = chunkValue * 85 + (ulong)DecodeMap[paddedText[i + j]];
                }

                decodedBytes.Add((byte)(chunkValue >> 24));
                decodedBytes.Add((byte)(chunkValue >> 16));
                decodedBytes.Add((byte)(chunkValue >> 8));
                decodedBytes.Add((byte)chunkValue);
            }

            var unpaddedLength = n / 5 * 4 + (n % 5 == 0 ? 0 : n % 5 - 1);
            return decodedBytes.Take(unpaddedLength).ToArray();
        }
    }
}