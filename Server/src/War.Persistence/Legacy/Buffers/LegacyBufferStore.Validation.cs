using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Tutorial;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using War.Persistence.Legacy.Buffers;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyBufferStore
{
    private const int MaximumReceiptEntries = 256;
    private const int MaximumResponseBytes = 1024 * 1024;
    private const int MaximumReceiptResponseBytes = 8 * MaximumResponseBytes;
    private const long MaximumClientUnixSeconds = int.MaxValue;

    private static void ValidateRequest(LegacyBufferedAction request)
    {
        if (string.IsNullOrWhiteSpace(request.PlayerId) || string.IsNullOrEmpty(request.BufferId) ||
            request.BufferId.Length > 128 || request.BufferId.Any(char.IsControl) ||
            request.Index < 0 || request.ActionId <= 0 ||
            !Regex.IsMatch(request.PayloadDigest, "\\A[0-9a-f]{64}\\z"))
        {
            throw new InvalidDataException("Invalid buffered action identity.");
        }
    }

    private static void ValidateReceipt(LegacyBufferReceipt? receipt, LegacyBufferedAction request)
    {
        if (receipt == null)
        {
            return;
        }

        if (receipt.PlayerId != request.PlayerId || receipt.BufferId != request.BufferId ||
            receipt.Entries == null || receipt.Entries.Count > MaximumReceiptEntries ||
            receipt.Entries.Any(entry => entry == null || entry.Index < 0 || entry.ActionId <= 0) ||
            receipt.Entries.Select(entry => entry.Index).Distinct().Count() != receipt.Entries.Count)
        {
            throw new InvalidDataException("Invalid durable buffer receipt.");
        }

        foreach (LegacyBufferEntry entry in receipt.Entries)
        {
            if (entry.PayloadDigest == null && entry.ResponseJson == null && entry.Delivery == null &&
                entry.Result is null or > 0)
            {
                continue;
            }

            if (entry.PayloadDigest == null || !Regex.IsMatch(entry.PayloadDigest, "\\A[0-9a-f]{64}\\z") ||
                entry.ResponseJson == null || entry.Result == null)
            {
                throw new InvalidDataException("Incomplete durable buffer response evidence.");
            }

            ValidateResponse(entry.ResponseJson, entry.ActionId, entry.Result.Value);
            if (entry.Delivery != null)
            {
                ValidateDelivery(entry.ResponseJson, entry.Delivery);
            }
        }
    }

    private static string? ReadReplay(LegacyBufferEntry entry, LegacyBufferedAction request)
    {
        if (entry.ActionId != request.ActionId || entry.PayloadDigest != request.PayloadDigest ||
            entry.Result == null || entry.ResponseJson == null)
        {
            // Old claims do not prove an outcome, and an altered request cannot borrow a receipt.
            return null;
        }

        ValidateResponse(entry.ResponseJson, entry.ActionId, entry.Result.Value);
        using JsonDocument response = JsonDocument.Parse(entry.ResponseJson);
        if (entry.Delivery == null && response.RootElement.TryGetProperty("DeliveryTime", out _))
        {
            // A duration without its original deadline cannot safely reset a Client countdown.
            return null;
        }

        return entry.ResponseJson;
    }

    private static void ValidateMutation(
        LegacyBufferedAction request,
        LegacyBufferedMutation mutation)
    {
        LegacyPlayerEconomyAuthority.ValidateArmyPower(mutation.ArmyPower);
        if (mutation.Gold < 0 || mutation.WarBucks < 0 || mutation.Scraps < 0 || mutation.ArmyPower < 0 ||
            mutation.Serialized == null || mutation.Serialized.Any(replacement =>
                !LegacyPlayerStore.SerializedKeys.Contains(replacement.Key) ||
                string.IsNullOrWhiteSpace(replacement.Value)))
        {
            throw new InvalidDataException("Invalid buffered account transition.");
        }

        if (mutation.Serialized.TryGetValue(LegacyAnalyticsState.Key, out string? analyticsJson))
        {
            LegacyAnalyticsState.ValidateJson(analyticsJson);
        }

        ValidateResponse(mutation.ResponseJson, request.ActionId, mutation.Result);
        ValidateDelivery(mutation.ResponseJson, mutation.Delivery);
    }

    private static void ValidateDelivery(string json, LegacyBufferedDelivery? delivery)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        bool hasDuration = document.RootElement.TryGetProperty("DeliveryTime", out JsonElement duration);
        if (!hasDuration && delivery == null)
        {
            return;
        }

        if (!hasDuration || duration.ValueKind != JsonValueKind.Number || !duration.TryGetInt32(out int seconds) ||
            seconds < 0 || delivery == null || delivery.Kind is not ("weapon" or "unit") ||
            string.IsNullOrEmpty(delivery.ItemId) || delivery.ItemId.Length > 256 ||
            delivery.ItemId.Any(char.IsControl) || delivery.BoughtIndex < 0 ||
            delivery.EndUnixSeconds < seconds || delivery.EndUnixSeconds > MaximumClientUnixSeconds)
        {
            throw new InvalidDataException("Invalid buffered delivery response evidence.");
        }
    }

    private static void ValidatePlayer(LegacyPlayerDocument player)
    {
        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyAnalyticsState.ValidateContainer(player.Serialized);
        LegacyTutorialAuthority.ValidateForRead(player);
        if (player.Revision < 0 || player.Revision == long.MaxValue || player.Serialized == null ||
            player.Gold < 0 || player.WarBucks < 0 || player.Scraps < 0 || player.ArmyPower < 0)
        {
            throw new InvalidDataException("Invalid buffered account snapshot.");
        }
    }

    private static void ValidateResponse(string json, int actionId, int result)
    {
        if (result <= 0 || string.IsNullOrEmpty(json) || Encoding.UTF8.GetByteCount(json) > MaximumResponseBytes)
        {
            throw new InvalidDataException("Invalid buffered response size or result.");
        }

        using JsonDocument document = JsonDocument.Parse(json);
        JsonElement response = document.RootElement;
        if (response.ValueKind != JsonValueKind.Object ||
            !response.TryGetProperty("ActionId", out JsonElement action) ||
            action.ValueKind != JsonValueKind.Number || !action.TryGetInt32(out int storedAction) ||
            storedAction != actionId || !response.TryGetProperty("Result", out JsonElement code) ||
            code.ValueKind != JsonValueKind.Number || !code.TryGetInt32(out int storedResult) || storedResult != result)
        {
            throw new InvalidDataException("Buffered response does not match its action receipt.");
        }
    }

    private static void ValidateReceiptCapacity(LegacyBufferReceipt? receipt, string response)
    {
        long bytes = Encoding.UTF8.GetByteCount(response);
        foreach (LegacyBufferEntry entry in receipt?.Entries ?? [])
        {
            bytes += entry.ResponseJson == null ? 0 : Encoding.UTF8.GetByteCount(entry.ResponseJson);
        }

        if (receipt?.Entries.Count >= MaximumReceiptEntries || bytes > MaximumReceiptResponseBytes)
        {
            throw new InvalidDataException("Buffered receipt exceeds its retained response budget.");
        }
    }
}
