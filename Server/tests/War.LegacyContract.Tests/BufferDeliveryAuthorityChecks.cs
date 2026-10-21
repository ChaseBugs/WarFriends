using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.LegacyContract.Tests.Recovered;
using War.Persistence.Legacy.Buffers;

namespace War.LegacyContract.Tests;

internal static class BufferDeliveryAuthorityChecks
{
    internal static void Verify(JObject response, LegacyBufferedActionResult receipt, long now)
    {
        if (receipt.Delivery == null)
        {
            return;
        }

        LevelManagerData levels = PlayerState.Read<LevelManagerData>(receipt.Player.Serialized["LevelManagerData"]);
        LegacyBufferedDelivery original = receipt.Delivery;
        ItemDelivery current = original.Kind == "weapon" ? levels.WeaponDelivery : levels.UnitDelivery;
        bool isSameDelivery = current.ItemId == original.ItemId && current.BoughtIndex == original.BoughtIndex &&
            current.End == original.EndUnixSeconds;
        if (!isSameDelivery)
        {
            Require(response["DeliveryTime"] == null && OracleTrace.WeaponDeliverySeconds == null &&
                OracleTrace.UnitDeliverySeconds == null, "Old success affected a newer Client delivery.");
            return;
        }

        long expected = Math.Max(0, original.EndUnixSeconds - now);
        int? consumed = original.Kind == "weapon" ? OracleTrace.WeaponDeliverySeconds : OracleTrace.UnitDeliverySeconds;
        Require((long?)response["DeliveryTime"] == expected && consumed == expected,
            "Client countdown extended the committed deadline.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
