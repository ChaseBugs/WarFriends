using System;
using System.IO;
using System.Security.Cryptography;

namespace War.Shared
{
    /// <summary>The Worker's WFR1 terminal-record digest over canonical protobuf payload bytes.</summary>
    public static class TerminalResultDigest
    {
        public const int MaximumPayloadBytes = 65536;

        public static string Compute(byte[] payload)
        {
            if (payload == null || payload.Length < 1 || payload.Length > MaximumPayloadBytes)
                throw new InvalidDataException("Invalid terminal result payload length.");
            var framed = new byte[payload.Length + 8];
            framed[0] = (byte)'W'; framed[1] = (byte)'F'; framed[2] = (byte)'R'; framed[3] = (byte)'1';
            int length = payload.Length;
            framed[4] = (byte)length;
            framed[5] = (byte)(length >> 8);
            framed[6] = (byte)(length >> 16);
            framed[7] = (byte)(length >> 24);
            Array.Copy(payload, 0, framed, 8, length);
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(framed)).Replace("-", "").ToLowerInvariant();
        }
    }
}
