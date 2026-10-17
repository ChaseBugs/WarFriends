using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopObstaclePoseCatalog
{
    private const ulong FirstFullyWeightedPreparationTick = 2;

    /// <summary>Projects fully weighted preparation and queued fire, independently of emitted projectiles.</summary>
    internal BattleInfantryAnimationFrame? PreparationAnimationFrame(ulong elapsedTick, ulong sampleTick)
    {
        if (elapsedTick < FirstFullyWeightedPreparationTick)
        {
            // Gameplay preparation has a partial-weight transition; do not normalize away its missing base pose.
            return null;
        }

        bool isQueuedFire = elapsedTick >= _firstQueuedFireTick;
        ulong clipElapsed = isQueuedFire ? elapsedTick - _firstQueuedFireTick : elapsedTick;
        var frame = new BattleInfantryAnimationFrame { SampleTick = sampleTick };
        frame.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = isQueuedFire ? FireClip : BeginClip,
            TimeSeconds = clipElapsed / (float)MatchManifest.TickRate,
            Weight = 1f,
            Wrap = isQueuedFire ? BattleInfantryAnimationWrap.ClampForever : BattleInfantryAnimationWrap.Clamp
        });
        return frame;
    }
}
