namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const ulong SourcePointRetryTicks = 10UL * MatchManifest.TickRate;
    private readonly Dictionary<ulong, ulong> _nextObstaclePointChangeTicks = [];

    internal ulong? NextObstaclePointChangeTick(ulong entityId)
    {
        return _nextObstaclePointChangeTicks.TryGetValue(entityId, out ulong changeTick) ? changeTick : null;
    }

    private void AdvanceObstaclePointChanges()
    {
        foreach ((ulong entityId, ulong changeTick) in _nextObstaclePointChangeTicks.ToArray())
        {
            if (tick < changeTick || !_obstacleVolleyClocks.TryGetValue(entityId, out CoopObstacleVolleyClock? clock) ||
                !clock.IsCrawling || clock.HasPendingShot || clock.LastRepositionTick == tick ||
                clock.Decide(tick) != CoopObstacleAction.None)
            {
                continue;
            }

            // This is the third else-if in ObstacleHidingUpdate: a shot or same-point move owns the frame first.
            if (TryHostRetargetEnemy(entityId) != null)
            {
                continue;
            }

            // With no different free point, the Client extends the original threshold, not the current time.
            _nextObstaclePointChangeTicks[entityId] = checked(changeTick + SourcePointRetryTicks);
        }
    }
}
