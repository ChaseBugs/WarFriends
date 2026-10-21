using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopObstaclePoseCatalog
{
    private const float InitialCrawlWeight = 1f / 3f;
    private const float FirstBeginWeight = 2f / 3f;

    /// <summary>
    /// Projects reviewed gameplay-phase preparation and queued fire, independently of emitted projectiles.
    /// </summary>
    internal BattleInfantryAnimationFrame? PreparationAnimationFrame(ulong elapsedTick, ulong sampleTick)
    {
        var frame = new BattleInfantryAnimationFrame { SampleTick = sampleTick };
        float weight = 1f;
        if (elapsedTick == 0)
        {
            AddInitialCrawl(frame);
            weight = 0f;
        }
        else if (elapsedTick == 1)
        {
            weight = FirstBeginWeight;
        }
        bool isQueuedFire = elapsedTick >= _firstQueuedFireTick;
        ulong clipElapsed = isQueuedFire ? elapsedTick - _firstQueuedFireTick : elapsedTick;
        frame.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = isQueuedFire ? FireClip : BeginClip,
            TimeSeconds = clipElapsed / (float)MatchManifest.TickRate,
            Weight = weight,
            Wrap = isQueuedFire ? BattleInfantryAnimationWrap.ClampForever : BattleInfantryAnimationWrap.Clamp
        });
        return frame;
    }
    private void AddInitialCrawl(BattleInfantryAnimationFrame frame)
    {
        // The completed clamped pose is canonical; its unbounded prior idle clock carries no new geometry.
        frame.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = CrawlClip,
            TimeSeconds = _clips.Clip(CrawlClip).Length + 1f / MatchManifest.TickRate,
            Weight = InitialCrawlWeight,
            Wrap = BattleInfantryAnimationWrap.ClampForever
        });
    }

}
