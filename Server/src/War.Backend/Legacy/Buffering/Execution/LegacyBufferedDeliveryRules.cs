using System.Text.Json.Nodes;
using War.Backend.Legacy.Economy;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedDeliveryRules
{
    /// <summary>Reproduces <c>MiscTools.ConvertTimeIntoGold</c> exactly.</summary>
    internal static long ConvertTimeIntoGold(long seconds, double goldCoefficient, double goldExpCoefficient)
    {
        return LegacyEconomyPricing.CalculateTimeCompletionGold(seconds, goldCoefficient, goldExpCoefficient);
    }

    internal static void ClearDelivery(ItemDelivery delivery)
    {
        delivery.ItemId = null;
        delivery.SlotId = 0;
        delivery.BoughtIndex = 0;
        delivery.Start = 0;
        delivery.End = 0;
        delivery.ActivationNeeded = false;
    }

}
