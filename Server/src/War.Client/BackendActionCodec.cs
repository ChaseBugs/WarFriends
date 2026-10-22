using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Google.Protobuf;
using War.Protocol;

namespace War.Client
{
    /// <summary>Protobuf framing preserves recovered action fields and callback payloads.</summary>
    public static class BackendActionCodec
    {
        public const string ContentType = "application/x-protobuf";
        public const int MaximumRequestBytes = 65536;
        public const int MaximumReplyBytes = 8 * 1024 * 1024;
        public const uint FormatVersion = 1;

        public static byte[] Encode(IEnumerable<KeyValuePair<string, string>> fields)
        {
            var request = new ClientActionRequest { FormatVersion = FormatVersion };
            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (KeyValuePair<string, string> field in fields)
            {
                if (string.IsNullOrEmpty(field.Key) || !names.Add(field.Key) || names.Count > 256)
                {
                    throw new InvalidDataException("Duplicate or invalid action field.");
                }
                request.Fields.Add(new ClientActionField { Name = field.Key, Value = field.Value ?? "null" });
            }
            if (request.CalculateSize() > MaximumRequestBytes)
            {
                throw new InvalidDataException("Action request exceeds the transport limit.");
            }
            return request.ToByteArray();
        }

        public static string Decode(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0 || bytes.Length > MaximumReplyBytes)
            {
                throw new InvalidDataException("Invalid action reply size.");
            }
            ClientActionReply reply = ClientActionReply.Parser.ParseFrom(bytes);
            if (reply.FormatVersion != FormatVersion ||
                (reply.ContentType != "application/json" && reply.ContentType != "text/plain"))
            {
                throw new InvalidDataException("Unsupported action reply contract.");
            }
            return new UTF8Encoding(false, true).GetString(reply.Payload.ToByteArray());
        }
    }
}
