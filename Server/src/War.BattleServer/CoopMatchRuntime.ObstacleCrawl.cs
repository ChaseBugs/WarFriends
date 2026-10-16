namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float SourceInitialHideSeconds = 1f;
    private readonly Dictionary<ulong, ObstacleCrawlState> _obstacleCrawlStates = [];

    internal ulong? ObstacleCrawlReturnTick(ulong entityId)
    {
        return _obstacleCrawlStates.TryGetValue(entityId, out ObstacleCrawlState? state)
            ? state.ReturnTick
            : null;
    }

    private void BeginObstacleCrawlClock(ulong entityId)
    {
        var state = new ObstacleCrawlState();
        state.Clock.RecordShot(ObstacleScaledTime(), SourceInitialHideSeconds);
        _obstacleCrawlStates[entityId] = state;
    }

    private void AdvanceObstacleCrawlClocks()
    {
        float scaledTime = ObstacleScaledTime();
        foreach (ObstacleCrawlState state in _obstacleCrawlStates.Values)
        {
            if (state.Clock.Update(scaledTime))
            {
                state.ReturnTick = tick;
            }
        }
    }

    private void RecordObstacleCrawlRound(ulong entityId)
    {
        if (!_obstacleCrawlStates.TryGetValue(entityId, out ObstacleCrawlState? state))
        {
            return;
        }

        // A resumed shot during crawl needs a new blend; the completed-crawl pose selector cannot model it yet.
        state.HasInterruptedReturn |= state.ReturnTick.HasValue;
        state.Clock.RecordShot(ObstacleScaledTime(), SourceRoundHideSeconds);
    }

    private float ObstacleScaledTime()
    {
        // The self-hosted fixed-step simulation starts at zero, independently of Unity process uptime.
        return (float)(tick / (double)MatchManifest.TickRate);
    }

    private sealed class ObstacleCrawlState
    {
        internal CoopObstacleCrawlReturnClock Clock { get; } = new();

        internal ulong? ReturnTick { get; set; }

        internal bool HasInterruptedReturn { get; set; }
    }
}
