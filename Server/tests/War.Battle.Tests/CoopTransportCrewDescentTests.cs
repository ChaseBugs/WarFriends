using System.Numerics;

using War.BattleServer;

/// <summary>
/// Exercises real match ownership with explicit authored poses, not a reconstructed animation lifecycle.
/// </summary>
internal sealed class CoopTransportCrewDescentTests
{
    private const float FrameDelta = 1f / MatchManifest.TickRate;
    private const float AuthoredRootHeightOffset = 0.25f;
    private readonly Dictionary<int, HelicopterRopeBodyPose> _pending = new();
    private int _starts;
    private int _updates;

    internal void Observe(CoopMatchRuntime runtime, ulong entityId, ulong tick)
    {
        if (!runtime.HasNativeTransportRopes)
        {
            return;
        }
        foreach ((int slot, HelicopterRopeBodyPose root) in _pending.ToArray())
        {
            HelicopterDescentFrame frame = Frame(root);
            CoopMatchRuntime.TransportCrewDescentSnapshot before = Snapshot(runtime, entityId, slot);
            HelicopterDescentResult result = runtime.AdvanceTransportCrewDescent(entityId, slot, frame, FrameDelta);
            CoopMatchRuntime.TransportCrewDescentSnapshot accepted = Snapshot(runtime, entityId, slot);
            if (accepted.ActorEntityId != before.ActorEntityId ||
                accepted.Pose != result || accepted.RenderFrame != before.RenderFrame + 1 ||
                accepted.StartTick != before.StartTick || accepted.PhysicsSequence < before.PhysicsSequence ||
                before.Pose.Progress >= accepted.Pose.Progress)
            {
                throw new Exception("Match did not publish the accepted crew pose without mutating prior snapshot.");
            }
            if (_updates == 0)
            {
                Reject(() => runtime.AdvanceTransportCrewDescent(entityId, slot, frame, FrameDelta));
                if (Snapshot(runtime, entityId, slot) != accepted)
                {
                    throw new Exception("Rejected crew replay replaced its last accepted pose.");
                }
            }
            _updates++;
            if (result.AnimationComplete)
            {
                _pending.Remove(slot);
            }
            else
            {
                _pending[slot] = new HelicopterRopeBodyPose(result.Position, result.Rotation);
            }
        }
        foreach (CoopMatchRuntime.TransportCrewDrop drop in runtime.TransportCrewDrops(entityId)
            .Where(drop => drop.StartTick == tick))
        {
            Begin(runtime, entityId, drop);
        }
    }

    internal void RequireObserved(CoopMatchRuntime runtime, ulong entityId)
    {
        if (runtime.HasNativeTransportRopes && (_starts == 0 || _updates == 0 ||
            _starts != runtime.TransportCrewDrops(entityId).Count))
        {
            throw new Exception("Match-owned descent never started or consumed a later native publication.");
        }
    }

    private void Begin(CoopMatchRuntime runtime, ulong entityId, CoopMatchRuntime.TransportCrewDrop drop)
    {
        // This fixture authors a host root/palm; it does not claim the normal Client animation produced them.
        var root = new HelicopterRopeBodyPose(drop.CrewPoint.Position + Vector3.UnitY * AuthoredRootHeightOffset,
            Quaternion.Identity);
        Reject(() => runtime.BeginTransportCrewDescent(entityId, drop.Slot, root with { Rotation = default }));
        runtime.BeginTransportCrewDescent(entityId, drop.Slot, root);
        CoopMatchRuntime.TransportCrewDescentSnapshot started = Snapshot(runtime, entityId, drop.Slot);
        if (started.ActorEntityId != drop.Birth.ActorEntityId ||
            started.StartTick != drop.StartTick || started.RenderFrame != drop.RenderFrame ||
            started.PhysicsSequence != drop.PhysicsSequence || started.Pose.Progress != 0 ||
            started.Pose.Position != root.Position || started.Pose.Rotation != root.Rotation)
        {
            throw new Exception("Descent start did not retain the original root pose and drop publication.");
        }
        Reject(() => runtime.BeginTransportCrewDescent(entityId, drop.Slot, root));
        Reject(() => runtime.AdvanceTransportCrewDescent(entityId, drop.Slot, Frame(root), FrameDelta));
        _pending.Add(drop.Slot, root);
        _starts++;
    }

    private static HelicopterDescentFrame Frame(HelicopterRopeBodyPose root)
    {
        return new HelicopterDescentFrame(root.Position, root.Rotation, root.Position + Vector3.UnitY, Vector3.UnitX);
    }

    private static CoopMatchRuntime.TransportCrewDescentSnapshot Snapshot(CoopMatchRuntime runtime,
        ulong entityId, int slot)
    {
        return runtime.TransportCrewDescentSnapshots(entityId).Single(snapshot => snapshot.Slot == slot);
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidDataException or InvalidOperationException)
        {
            return;
        }
        throw new Exception("Match descent accepted a malformed start, repeated start or replayed publication.");
    }
}
