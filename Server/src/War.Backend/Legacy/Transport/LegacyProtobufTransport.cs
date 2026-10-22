using Google.Protobuf;
using Microsoft.Extensions.Primitives;
using War.Protocol;

namespace War.Backend.Legacy.Transport;

/// <summary>Adapts protobuf transport into the same authenticated action and rollback contracts.</summary>
internal static class LegacyProtobufTransport
{
    internal const string ContentType = "application/x-protobuf";
    private const int MaximumRequestBytes = 65_536;

    internal static bool IsRequested(HttpRequest request) =>
        string.Equals(request.ContentType?.Split(';')[0].Trim(), ContentType, StringComparison.OrdinalIgnoreCase);

    internal static async Task<bool> ReadAsync(HttpRequest request, CancellationToken cancellationToken)
    {
        using var bytes = new MemoryStream();
        var buffer = new byte[4096];
        int count;
        while ((count = await request.Body.ReadAsync(buffer, cancellationToken)) != 0)
        {
            if (bytes.Length + count > MaximumRequestBytes)
            {
                return false;
            }
            bytes.Write(buffer, 0, count);
        }
        try
        {
            ClientActionRequest envelope = ClientActionRequest.Parser.ParseFrom(bytes.ToArray());
            if (envelope.FormatVersion != 1 || envelope.Fields.Count is < 1 or > 256)
            {
                return false;
            }
            var fields = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase);
            foreach (ClientActionField field in envelope.Fields)
            {
                if (field.Name.Length is < 1 or > 128 || field.Name.Any(char.IsControl) ||
                    !fields.TryAdd(field.Name, field.Value))
                {
                    return false;
                }
            }
            request.Form = new FormCollection(fields);
            return true;
        }
        catch (InvalidProtocolBufferException)
        {
            return false;
        }
    }

    internal static byte[] Encode(string contentType, byte[] payload) => new ClientActionReply
    {
        FormatVersion = 1, ContentType = contentType, Payload = ByteString.CopyFrom(payload)
    }.ToByteArray();
}
