using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopObstaclePoseCatalog
{
    /// <summary>Selects the transform sampled before the source gameplay Update and OnShot callback.</summary>
    internal IReadOnlyList<PlayerHitbox> PlaceGameplay(CoopObstaclePoseClock clock, Vector3 rootPosition,
        Quaternion rootRotation, string prefix = "")
    {
        GameplayPose pose = SelectGameplayPose(clock);
        ValidatePlacement(rootPosition, rootRotation, prefix);
        rootRotation = Quaternion.Normalize(rootRotation);
        if (pose.IsBlend)
        {
            return PlaceBlendFrame(rootPosition, rootRotation, prefix);
        }

        return _clips.Place(pose.Clip, rootPosition, rootRotation, pose.Seconds, prefix);
    }

    /// <summary>Uses sampled firing transforms even when Update has already changed animation state.</summary>
    internal CoopQueuedMuzzleSample? GameplayFiringMuzzle(CoopObstaclePoseClock clock, CoopEnemyMuzzleCatalog muzzles)
    {
        ArgumentNullException.ThrowIfNull(muzzles);
        GameplayPose pose = SelectGameplayPose(clock);
        if (pose.Clip != FireClip)
        {
            return null;
        }

        CoopMuzzlePose muzzle = muzzles.Place(FireClip, Vector3.Zero, Quaternion.Identity, pose.Seconds);
        return new CoopQueuedMuzzleSample(pose.Seconds, muzzle.Position, muzzle.Rotation);
    }

    private GameplayPose SelectGameplayPose(CoopObstaclePoseClock clock)
    {
        ValidateClock(clock);
        ulong sampleTick = clock.ElapsedTick == 0 ? 0 : clock.ElapsedTick - 1;
        if (clock.CrawlReturnTick.HasValue && clock.ElapsedTick > clock.CrawlReturnTick.Value)
        {
            return AtTick(CrawlClip, sampleTick - clock.CrawlReturnTick.Value);
        }

        int priorRoundCount = 0;
        ulong latestRound = 0;
        foreach (ulong roundTick in clock.EmittedRoundTicks)
        {
            if (roundTick < clock.ElapsedTick)
            {
                latestRound = roundTick;
                priorRoundCount++;
            }
        }

        if (priorRoundCount > 0)
        {
            // Replacing the queued clone starts at zero; replaying the ordinary loop advances this frame.
            ulong elapsed = priorRoundCount == 1 ? sampleTick - latestRound : clock.ElapsedTick - latestRound;
            return AtTick(FireClip, elapsed);
        }

        return SelectPreparationPose(sampleTick);
    }

    private GameplayPose SelectPreparationPose(ulong sampleTick)
    {
        if (sampleTick == 0)
        {
            return new GameplayPose(CrawlClip, _clips.Clip(CrawlClip).Length);
        }
        if (sampleTick == BlendFrameTick)
        {
            return new GameplayPose(BeginClip, 0, true);
        }
        if (sampleTick < _firstQueuedFireTick)
        {
            return AtTick(BeginClip, sampleTick);
        }

        return AtTick(FireClip, sampleTick - _firstQueuedFireTick);
    }

    private static GameplayPose AtTick(string clip, ulong elapsed)
    {
        return new GameplayPose(clip, elapsed / (float)MatchManifest.TickRate);
    }

    private sealed record GameplayPose(string Clip, float Seconds, bool IsBlend = false);
}
