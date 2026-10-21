using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>Projects the mandatory BuyDecal success fields from bound identity and current ownership.</summary>
internal static class LegacyBufferedCosmeticResponse
{
    internal static void Refresh(JsonObject response, LegacyPlayerDocument player, BufferedRequest? request)
    {
        if (response["ActionId"]!.GetValue<int>() != (int)DatabaseAction.BuyDecal ||
            response["Result"]!.GetValue<int>() != (int)DatabaseResult.Success)
        {
            return;
        }

        string? recordedName = LegacyBufferPayload.ReadString(response["DecalId"]);
        string? boundName = ReadBoundName(request);
        if (recordedName != null && boundName != null && recordedName != boundName)
        {
            throw new InvalidDataException("Recorded cosmetic identity disagrees with its bound request.");
        }

        string? name = recordedName ?? boundName;
        if (string.IsNullOrEmpty(name) || player.Serialized == null ||
            !player.Serialized.ContainsKey("DecalManagerData"))
        {
            throw new InvalidDataException("Cosmetic success has no current ownership evidence.");
        }

        DecalManagerData decals = PlayerState.Read<DecalManagerData>(player.Serialized, "DecalManagerData");
        if (decals.Visuals == null || !decals.Visuals.TryGetValue(name, out SavedPlayerVisual? visual) ||
            visual == null || !visual.Bought || visual.ExpiresOn < 0)
        {
            throw new InvalidDataException("Cosmetic success disagrees with current ownership.");
        }

        // Old no-op receipts omitted both fields. Recover only from the request whose digest the store verified.
        // The Client assigns expiry unconditionally, so replay must not overwrite a newer promotion's deadline.
        response["DecalId"] = name;
        response["ExpiresOn"] = visual.ExpiresOn;
    }

    private static string? ReadBoundName(BufferedRequest? request)
    {
        if (request == null)
        {
            return null;
        }

        if (request.Action != DatabaseAction.BuyDecal ||
            JsonNode.Parse(request.Data ?? "null") is not JsonObject payload ||
            string.IsNullOrEmpty(LegacyBufferPayload.ReadString(payload["Name"])))
        {
            throw new InvalidDataException("Cosmetic replay has no valid bound request.");
        }

        return LegacyBufferPayload.ReadString(payload["Name"]);
    }
}
