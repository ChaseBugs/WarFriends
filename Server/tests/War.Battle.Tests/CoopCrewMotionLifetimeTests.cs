using System.Numerics;
using War.BattleServer;

/// <summary>Checks that retired actor motion cannot outlive its health or source seat ownership.</summary>
internal static class CoopCrewMotionLifetimeTests
{
    internal sealed record Observation(CoopMatchRuntime.TransportCrewDrop Drop,
        CoopMatchRuntime.TransportCrewDescentSnapshot Descent);

    internal static Observation? Capture(CoopMatchRuntime runtime, ulong aircraftId, int slot)
    {
        if (!runtime.HasNativeTransportRopes)
        {
            return null;
        }

        return new Observation(runtime.TransportCrewDrops(aircraftId).Single(drop => drop.Slot == slot),
            runtime.TransportCrewDescentSnapshots(aircraftId).Single(descent => descent.Slot == slot));
    }

    internal static void VerifyRetired(CoopMatchRuntime runtime, ulong aircraftId, Observation? before)
    {
        if (before == null)
        {
            return;
        }

        int slot = before.Drop.Slot;
        if (runtime.TransportCrewDrops(aircraftId).Any(drop => drop.Slot == slot) ||
            runtime.TransportCrewDescentSnapshots(aircraftId).Any(descent => descent.Slot == slot) ||
            runtime.TransportRopeSnapshot?.Members.Single(member => member.Lease.EntityId == aircraftId).Lease !=
                before.Drop.RopeLease)
        {
            throw new Exception("Retired crew kept motion state or revoked the shared aircraft rope.");
        }

        var root = new HelicopterRopeBodyPose(before.Descent.Pose.Position, before.Descent.Pose.Rotation);
        var frame = new HelicopterDescentFrame(root.Position, root.Rotation,
            root.Position + Vector3.UnitY, Vector3.UnitX);
        RequireRejected(() => runtime.BeginTransportCrewDescent(aircraftId, slot, root));
        RequireRejected(() => runtime.AdvanceTransportCrewDescent(
            aircraftId, slot, frame, 1f / MatchManifest.TickRate));
    }

    private static void RequireRejected(Action callback)
    {
        try
        {
            callback();
        }
        catch (Exception error) when (error is InvalidDataException or InvalidOperationException)
        {
            return;
        }

        throw new Exception("Retired crew consumed a stale source motion callback.");
    }
}
