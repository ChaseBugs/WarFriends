namespace War.BattleServer;

/// <summary>
/// Fixed-tick form of EnemyController.RusherUpdate's inactive-point timer.
/// Returning true requests a retarget; the caller resets only after a slot
/// and covered route have both been committed.
/// </summary>
internal sealed class ArmyRusherRetargetClock
{
    private const int SourceThresholdTicks=MatchManifest.TickRate*3/2;
    private int inactiveTicks;

    internal int InactiveTicks => inactiveTicks;

    internal bool AdvanceTick(bool pointActive,bool shotPending)
    {
        if(pointActive || shotPending)return false;
        if(inactiveTicks<=SourceThresholdTicks)inactiveTicks++;
        return inactiveTicks>SourceThresholdTicks;
    }

    internal void Reset()=>inactiveTicks=0;
}
