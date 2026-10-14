using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpBonusGrenadeDueShot(string BoxId, string RecipientPlayerId,
    ulong FrameId, PvpBonusGrenadeLaunch Launch);

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
        internal int NextShot { get; set; }
        internal double Elapsed { get; set; }

        internal PendingBurst(PvpBonusGrenadeBurstPlan plan, ulong startedFrame)
        {
            Plan = plan;
            StartedFrame = startedFrame;
        }
    }

    private readonly List<PendingBurst> pending = new();
    private ulong lastFrame;
    private int lastDeltaBits;
    private IReadOnlyList<PvpBonusGrenadeDueShot>? lastResult;

    internal int PendingCount => pending.Count;

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
        pending.Add(new PendingBurst(plan, currentFrame));
    }

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
        for (int index = pending.Count - 1; index >= 0; index--)
        {
            var burst = pending[index];
            if (burst.StartedFrame == frameId)
                continue;
            burst.Elapsed += scaledDeltaSeconds;
            double wait = burst.NextShot == 0 ? 1d : 0.2d;
            if (burst.Elapsed < wait)
                continue;

            var launch = burst.Plan.Launches[burst.NextShot];
            dueShots.Add(new PvpBonusGrenadeDueShot(burst.Plan.BoxId,
                burst.Plan.RecipientPlayerId, frameId, launch));
            burst.NextShot++;
            burst.Elapsed = 0;
            if (burst.NextShot == burst.Plan.Launches.Count)
                pending.RemoveAt(index);
        }
        // Reverse iteration removes completed bursts safely. Publish due
        // launches in the order their boxes were admitted to the host.
        dueShots.Reverse();
        lastResult = new ReadOnlyCollection<PvpBonusGrenadeDueShot>(dueShots);
        lastFrame = frameId;
        lastDeltaBits = deltaBits;
        return lastResult;
    }
}
