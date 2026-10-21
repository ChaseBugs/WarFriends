using System.Collections.ObjectModel;

using System.Numerics;

namespace War.BattleServer;
public sealed record PvpBonusGrenadeDueShot(string BoxId, string RecipientPlayerId,
    ulong FrameId, PvpBonusGrenadeLaunch Launch,
    PvpBonusGrenadeSharedDamage SetupAtLaunch, Vector3? CardFireOrigin = null);

/// <summary>
/// Advances the recovered grenade-box coroutine on ordered scaled frames.
/// A long frame releases at most one shot from each burst: WaitForSeconds
/// starts a fresh wait after every launch rather than catching up instantly.
/// </summary>
internal sealed class PvpBonusGrenadeBurstClock
{
    private sealed class PendingBurst
    {
        internal PvpBonusGrenadeBurstPlan Plan { get; }
        internal ulong StartedFrame { get; }
        internal double FirstWaitSeconds { get; }
        internal Vector3? CardFireOrigin { get; }
        internal int NextShot { get; set; }
        internal double Elapsed { get; set; }

        internal PendingBurst(PvpBonusGrenadeBurstPlan plan, ulong startedFrame,
            double firstWaitSeconds, Vector3? cardFireOrigin = null)
        {
            Plan = plan;
            StartedFrame = startedFrame;
            FirstWaitSeconds = firstWaitSeconds;
            CardFireOrigin = cardFireOrigin;
        }
    }

    private readonly List<PendingBurst> pending = new();
    private readonly PvpBonusCatalog catalog;
    private ulong lastFrame;
    private int lastDeltaBits;
    private IReadOnlyList<PvpBonusGrenadeDueShot>? lastResult;
    // The catalog extracts MainScene component 41786, the KillStreak
    // Manager's shared GrenadeAmmoSetup. GrenadeAmmoBase stores a reference
    // to it, so an earlier projectile reads its latest damage at explosion.
    private PvpBonusGrenadeSharedDamage sharedDamage;

    internal int PendingCount => pending.Count;
    internal PvpBonusGrenadeSharedDamage CurrentSharedDamage => sharedDamage;

    internal PvpBonusGrenadeBurstClock(PvpBonusCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        this.catalog = catalog;
        sharedDamage = new(catalog.GrenadeInitialExplosionDamage,
            catalog.GrenadeInitialDirectDamage);
    }

    internal void Schedule(PvpBonusGrenadeBurstPlan plan, ulong currentFrame)
    {
        ArgumentNullException.ThrowIfNull(plan);
        if (currentFrame == 0 || currentFrame != lastFrame ||
            plan.Launches.Count != 3)
            throw new InvalidDataException("Invalid grenade-box burst schedule.");
        for (int index = 0; index < plan.Launches.Count; index++)
        {
            var launch = plan.Launches[index];
            if (launch.ShotIndex != index ||
                launch.DelayScaledSeconds != 1f + index * 0.2f)
                throw new InvalidDataException("Grenade-box shot order changed.");
        }
        if (pending.Count >= 256)
            throw new InvalidOperationException("Too many pending grenade-box bursts.");
        pending.Add(new PendingBurst(plan, currentFrame, 1d));
    }

    internal void ScheduleCard(CardGrenadesBurstPlan card, ulong currentFrame)
    {
        ArgumentNullException.ThrowIfNull(card);
        if (currentFrame == 0 || currentFrame != lastFrame ||
            card.Launches.Count != 3 ||
            !War.Shared.CanonicalGuid.IsCanonical(card.RequestId) ||
            !War.Shared.CanonicalGuid.IsCanonical(card.OwnerPlayerId) ||
            card.OwnerLevel < 0 || card.OwnerLevel >= catalog.RankCount ||
            !Finite(card.FireOrigin) ||
            pending.Any(burst => burst.Plan.BoxId == card.RequestId))
            throw new InvalidDataException("Invalid CardGrenadesBurst schedule.");
        for (int index = 0; index < card.Launches.Count; index++)
        {
            var launch = card.Launches[index];
            if (launch.ShotIndex != index ||
                launch.DelayScaledSeconds != (index + 1) * 0.2f ||
                !Finite(launch.Position) ||
                (launch.TargetId != null && !ValidTargetId(launch.TargetId)) ||
                (launch.TargetId == null) != (launch.DamageOverride != null) ||
                (launch.DamageOverride is { } damage &&
                 damage != catalog.GrenadeFallbackDamageForLevel(card.OwnerLevel)))
                throw new InvalidDataException("CardGrenadesBurst shot order changed.");
        }
        if (pending.Count >= 256)
            throw new InvalidOperationException("Too many pending grenade bursts.");
        var burst = new PvpBonusGrenadeBurstPlan(card.RequestId,
            card.OwnerPlayerId, Array.AsReadOnly(card.Launches.ToArray()));
        pending.Add(new PendingBurst(burst, currentFrame, 0.2d,
            card.FireOrigin));
    }

    private static bool Finite(Vector3 position) =>
        float.IsFinite(position.X) && float.IsFinite(position.Y) &&
        float.IsFinite(position.Z) &&
        Math.Abs(position.X) <= 10_000f &&
        Math.Abs(position.Y) <= 10_000f &&
        Math.Abs(position.Z) <= 10_000f;

    private static bool ValidTargetId(string targetId) =>
        targetId.Length is >= 1 and <= 64 &&
        targetId.All(character => char.IsAsciiLetterOrDigit(character) ||
            character is '_' or '-' or ':');

    internal IReadOnlyList<PvpBonusGrenadeDueShot> AdvanceFrame(
        ulong frameId, float scaledDeltaSeconds)
    {
        if (!float.IsFinite(scaledDeltaSeconds) || scaledDeltaSeconds < 0f)
            throw new InvalidDataException("Invalid grenade-box scaled frame time.");
        int deltaBits = BitConverter.SingleToInt32Bits(scaledDeltaSeconds);
        if (lastResult != null && frameId == lastFrame)
        {
            if (deltaBits != lastDeltaBits)
                throw new InvalidDataException("Replayed grenade-box frame changed its time.");
            return lastResult;
        }
        if (lastFrame == ulong.MaxValue || frameId != lastFrame + 1)
            throw new InvalidDataException("Grenade-box frames must be consecutive.");

        var dueShots = new List<PvpBonusGrenadeDueShot>();
        for (int index = 0; index < pending.Count; index++)
        {
            var burst = pending[index];
            if (burst.StartedFrame == frameId)
                continue;
            burst.Elapsed += scaledDeltaSeconds;
            double wait = burst.NextShot == 0 ? burst.FirstWaitSeconds : 0.2d;
            if (burst.Elapsed < wait)
                continue;

            var launch = burst.Plan.Launches[burst.NextShot];
            if (launch.DamageOverride is { } damage)
                sharedDamage = new(damage.Explosion, damage.Direct);
            dueShots.Add(new PvpBonusGrenadeDueShot(burst.Plan.BoxId,
                burst.Plan.RecipientPlayerId, frameId, launch, sharedDamage,
                burst.CardFireOrigin));
            burst.NextShot++;
            burst.Elapsed = 0;
            if (burst.NextShot == burst.Plan.Launches.Count)
            {
                pending.RemoveAt(index);
                index--;
            }
        }
        // A forward pass publishes simultaneous launches in box admission
        // order, including their shared setup mutation order.
        lastResult = new ReadOnlyCollection<PvpBonusGrenadeDueShot>(dueShots);
        lastFrame = frameId;
        lastDeltaBits = deltaBits;
        return lastResult;
    }
}
