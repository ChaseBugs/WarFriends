namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private CoopQueuedMuzzleSample? ObserveCornerFiringMuzzle(ulong entityId, CoopInfantryShotWindup windup)
    {
        if (assaulterQueue == null || enemyMuzzles == null)
        {
            return null;
        }

        ulong[] roundTicks = InfantryRoundIntents(entityId)
            .Select(round => round.Tick - windup.StartTick).ToArray();
        var clock = new CoopCornerFiringClock(windup.AnimationClip, windup.QueuedFireClip,
            tick - windup.StartTick, roundTicks);
        return CoopCornerFiringMuzzle.Sample(clock, assaulterQueue, enemyMuzzles);
    }
}
