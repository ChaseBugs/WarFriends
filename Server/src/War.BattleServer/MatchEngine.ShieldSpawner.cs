using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseShieldSpawner(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardShieldsSpawner"))
            return "shield-spawner-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-shield-spawner-request";
        if (cardReservations == null || shields == null)
            return "shield-spawner-authority-unavailable";

        var alliedShields=shields.Snapshot()
            .Where(shield=>shield.OwnerFraction==owner.Definition.Fraction).ToArray();
        if (alliedShields.Length==0 ||
            !float.IsFinite(alliedShields[0].RepairSeconds*0.7f) ||
            alliedShields[0].RepairSeconds*0.7f<=0)
            return "shield-spawner-authority-unavailable";
        if (events.Count >= MaximumRetainedEvents ||
            stateRevision > ulong.MaxValue-1-(ulong)alliedShields.Length)
            return "event-backpressure";

        // CardShieldsSpawner takes the first allied shield's current repair
        // time, multiplies it by 0.7, then assigns it to every allied shield.
        var effect=new WarCardEffectRequest("CardShieldsSpawner",
            Vector3.Zero,0,1,"SHIELDSPAWNER");
        if (!TryApplyCardEffect(requestId,owner.Definition.PlayerId,effect))
            return "shield-spawner-unavailable";

        shields.AccelerateRepair(owner.Definition.Fraction,0.7f);
        stateRevision+=(ulong)alliedShields.Length;
        return "shield-spawner-applied";
    }
}
