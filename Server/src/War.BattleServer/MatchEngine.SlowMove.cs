using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseSlowMove(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardBelovedEnemy"))
            return "slow-move-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-slow-move-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        Player opponent = players.Single(player => player != owner);
        if (!opponent.Admitted || opponent.Dead)
            return "slow-move-target-unavailable";

        // CardBelovedEnemy.UseCardOnline sets the opponent's NavMeshAgent
        // speed to the absolute source value 0.5 for ten seconds.
        var effect = new WarCardEffectRequest("CardBelovedEnemy",
            Vector3.Zero, 10, 0, "SLOWMOVE");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "slow-move-unavailable";

        RecalculateMoveEnd(opponent);
        return "slow-move-active";
    }

    private float PlayerSpeed(Player player)
    {
        Player opponent = players.Single(other => other != player);
        if (cardEffects.HasActiveCard(opponent.Definition.PlayerId,
                "CardBelovedEnemy"))
            return 0.5f;
        return player.Definition.MovementSpeed;
    }

    private void RecalculateMoveEnd(Player player)
    {
        if (player.Route == null)
            return;

        float remainingDistance = Math.Max(0,
            player.RouteLength - player.RouteTravelled);
        ulong fromTick = Math.Max(tick, player.MoveStart);
        player.MoveEnd = checked(fromTick + Math.Max(1,
            Ticks(remainingDistance / PlayerSpeed(player))));
        stateRevision++;
    }
}
