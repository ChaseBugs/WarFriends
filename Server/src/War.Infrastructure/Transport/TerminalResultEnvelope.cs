using System.Text;
using System.Text.Json;
using War.Shared;

namespace War.Infrastructure;

/// <summary>One bounded server-only JSON envelope for the unchanged WFR1 binary terminal contract.</summary>
public static class TerminalResultEnvelope
{
    public const int MaximumIdentityCharacters = 64;
    private const int DigestCharacters = 64;
    private const int CanonicalChunkBytesPerPayloadByte = 6;
    private const int FinalChunkBytes = 5;
    private const string EmptyEnvelope = "{\"serverId\":\"\",\"matchId\":\"\",\"digest\":\"\",\"snapshot\":\"\"}";
    private static readonly int SyntaxBytes = Encoding.UTF8.GetByteCount(EmptyEnvelope);

    public static int MaximumBodyBytes { get; } = SyntaxBytes + MaximumIdentityCharacters * 2 +
        DigestCharacters + Base64Characters(TerminalResultDigest.MaximumPayloadBytes);

    // Kestrel counts HTTP/1 framing: one size byte, CRLF, one payload byte and CRLF per one-byte chunk.
    // Keep a finite wire budget while the shared reader separately enforces decoded JSON bytes.
    public static int MaximumWireBodyBytes { get; } =
        MaximumBodyBytes * CanonicalChunkBytesPerPayloadByte + FinalChunkBytes;

    public static byte[] Encode(string serverId, string matchId, string digest, byte[] snapshot)
    {
        ValidateMetadata(serverId, matchId, digest);
        if (snapshot is not { Length: > 0 } || snapshot.Length > TerminalResultDigest.MaximumPayloadBytes)
        {
            throw new InvalidDataException("Invalid terminal snapshot length.");
        }

        int expectedBytes = SyntaxBytes + serverId.Length + matchId.Length + digest.Length +
            Base64Characters(snapshot.Length);
        using var memory = new MemoryStream(expectedBytes);
        using (var writer = new Utf8JsonWriter(memory))
        {
            writer.WriteStartObject();
            writer.WriteString("serverId", serverId);
            writer.WriteString("matchId", matchId);
            writer.WriteString("digest", digest);
            // Base64 is written as binary, without HTML escaping '+' into six JSON characters.
            writer.WriteBase64String("snapshot", snapshot);
            writer.WriteEndObject();
            writer.Flush();
        }

        if (memory.Length != expectedBytes || memory.Length > MaximumBodyBytes)
        {
            throw new InvalidDataException("Terminal result envelope exceeds its derived budget.");
        }
        return memory.ToArray();
    }

    private static int Base64Characters(int payloadBytes)
    {
        return ((payloadBytes + 2) / 3) * 4;
    }

    private static void ValidateMetadata(string serverId, string matchId, string digest)
    {
        if (string.IsNullOrEmpty(serverId) || serverId.Length > MaximumIdentityCharacters ||
            !serverId.All(character => char.IsAsciiLetterOrDigit(character) || character == '-') ||
            string.IsNullOrEmpty(matchId) || matchId.Length > MaximumIdentityCharacters ||
            !matchId.All(character => char.IsAsciiLetterOrDigit(character) || character is '_' or '-') ||
            digest == null || digest.Length != DigestCharacters ||
            !digest.All(character => character is >= '0' and <= '9' or >= 'a' and <= 'f'))
        {
            throw new InvalidDataException("Invalid terminal envelope metadata.");
        }
    }
}
