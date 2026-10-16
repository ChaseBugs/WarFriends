using System.Numerics;

namespace War.BattleServer;

internal sealed record CoopCornerFiringClock(string StartClip, string FireClip, ulong ElapsedTick,
    IReadOnlyList<ulong> EmittedRoundTicks);

/// <summary>Selects corner firing transforms before the gameplay callback or current round resets animation.</summary>
internal static class CoopCornerFiringMuzzle
{
    private const int MaximumVolleyRounds = 14;

    internal static CoopQueuedMuzzleSample? Sample(CoopCornerFiringClock clock,
        CoopAssaulterQueueCatalog queue, CoopEnemyMuzzleCatalog muzzles)
    {
        ArgumentNullException.ThrowIfNull(clock);
        ArgumentNullException.ThrowIfNull(queue);
        ArgumentNullException.ThrowIfNull(muzzles);
        Validate(clock, queue);
        if (clock.ElapsedTick == 0)
        {
            return null;
        }

        ulong[] earlierRounds = clock.EmittedRoundTicks.Where(round => round < clock.ElapsedTick).ToArray();
        if (earlierRounds.Length == 0)
        {
            return queue.Sample(clock.StartClip, clock.FireClip, clock.ElapsedTick - 1);
        }

        // The first OnShot replaces a queued clone; later resets replay the already active ordinary loop.
        ulong elapsed = clock.ElapsedTick - earlierRounds[^1];
        if (earlierRounds.Length == 1)
        {
            elapsed--;
        }

        float seconds = elapsed / (float)MatchManifest.TickRate;
        CoopMuzzlePose pose = muzzles.Place(clock.FireClip, Vector3.Zero, Quaternion.Identity, seconds);
        return new CoopQueuedMuzzleSample(seconds, pose.Position, pose.Rotation);
    }

    private static void Validate(CoopCornerFiringClock clock, CoopAssaulterQueueCatalog queue)
    {
        ArgumentNullException.ThrowIfNull(clock.EmittedRoundTicks);
        string expectedFire = clock.StartClip switch
        {
            "player_look_right3" => "player_fire_right3",
            "player_look_left3" => "player_fire_left3",
            _ => throw new InvalidDataException("Unknown source corner preparation clip.")
        };
        if (clock.FireClip != expectedFire || clock.EmittedRoundTicks.Count > MaximumVolleyRounds)
        {
            throw new InvalidDataException("Invalid source corner firing clock.");
        }

        ulong prior = 0;
        foreach (ulong round in clock.EmittedRoundTicks)
        {
            if (round <= prior || round > clock.ElapsedTick ||
                (prior == 0 && queue.Sample(clock.StartClip, clock.FireClip, round - 1) == null))
            {
                throw new InvalidDataException("Corner rounds must follow preparation in emitted tick order.");
            }

            prior = round;
        }
    }
}
