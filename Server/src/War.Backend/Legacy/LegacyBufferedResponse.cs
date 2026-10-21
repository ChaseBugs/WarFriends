using System.Text.Json.Nodes;
using War.Persistence.Legacy.Buffers;

namespace War.Backend.Legacy;

/// <summary>Projects a frozen response without restarting an old or unrelated Client delivery timer.</summary>
public static class LegacyBufferedResponse
{
    private const long MaximumClientUnixSeconds = int.MaxValue;

    /// <summary>Keeps stored outcome fields and expresses only an applicable delivery as remaining seconds.</summary>
    public static JsonObject Project(LegacyBufferedActionResult applied, long now, BufferedRequest? request = null)
    {
        if (now < 0 || now > MaximumClientUnixSeconds || string.IsNullOrEmpty(applied.ResponseJson) ||
            JsonNode.Parse(applied.ResponseJson) is not JsonObject response)
        {
            throw new InvalidDataException("Invalid buffered response projection.");
        }

        LegacyBufferedRollback.Refresh(response, applied.Player);
        LegacyBufferedCosmeticResponse.Refresh(response, applied.Player, request);
        if (applied.Delivery == null)
        {
            if (response.ContainsKey("DeliveryTime"))
            {
                throw new InvalidDataException("Relative delivery response has no absolute evidence.");
            }

            return response;
        }

        ItemDelivery? current = ReadCurrentDelivery(applied);
        LegacyBufferedDelivery original = applied.Delivery;
        if (original.EndUnixSeconds < 0 || original.EndUnixSeconds > MaximumClientUnixSeconds)
        {
            throw new InvalidDataException("Delivery end exceeds the recovered Client clock.");
        }

        if (current == null || current.ItemId != original.ItemId || current.BoughtIndex != original.BoughtIndex ||
            current.End != original.EndUnixSeconds)
        {
            // SetWeapon/UnitDeliveryTime searches any delivering item, so an old reply must not affect a successor.
            response.Remove("DeliveryTime");
            return response;
        }

        long remaining = Math.Max(0, checked(original.EndUnixSeconds - now));
        if (remaining > int.MaxValue)
        {
            throw new InvalidDataException("Delivery duration exceeds the recovered Client field.");
        }

        // The Client adds this value to currentTimestamp. Replaying the original duration extends its end.
        response["DeliveryTime"] = (int)remaining;
        return response;
    }

    private static ItemDelivery? ReadCurrentDelivery(LegacyBufferedActionResult applied)
    {
        if (applied.Player.Serialized == null)
        {
            throw new InvalidDataException("Current delivery subsystem container is null.");
        }

        if (!applied.Player.Serialized.ContainsKey("LevelManagerData"))
        {
            return null;
        }

        LevelManagerData levels = PlayerState.Read<LevelManagerData>(applied.Player.Serialized, "LevelManagerData");
        return applied.Delivery!.Kind switch
        {
            "weapon" => levels.WeaponDelivery,
            "unit" => levels.UnitDelivery,
            _ => throw new InvalidDataException("Unknown buffered delivery kind.")
        };
    }
}
