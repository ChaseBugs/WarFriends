using System.Text.Json;

namespace War.BattleServer.Transport.Control;

internal static class WorkerResultRequests
{
    internal static ResultReferenceRequest ReadLookup(byte[] body)
    {
        return ReadReference(body, "manifestHash");
    }

    internal static ResultReferenceRequest ReadAcknowledgement(byte[] body)
    {
        return ReadReference(body, "digest");
    }

    private static ResultReferenceRequest ReadReference(byte[] body, string proofField)
    {
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 2 ||
            !root.TryGetProperty("matchId", out JsonElement match) || match.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty(proofField, out JsonElement proof) || proof.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Invalid terminal reference shape.");
        }
        return new ResultReferenceRequest(match.GetString()!, proof.GetString()!);
    }
}
