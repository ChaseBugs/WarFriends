using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Source drop inputs tied to a live rope; this is not a landed soldier or damage target.</summary>
    internal sealed record TransportCrewDrop
    {
        internal required int Slot { get; init; }
        internal required ulong StartTick { get; init; }
        internal required HelicopterRopeBodyPose Aircraft { get; init; }
        internal required HelicopterRopeBodyPose CrewPoint { get; init; }
        internal required TransportCrewBirth Birth { get; init; }
        internal required Quaternion InitialPoolParentRotation { get; init; }
        internal required Quaternion SpawnResetRotation { get; init; }
        internal required Vector3 RopeMarker { get; init; }
        internal required Vector3? LandingSurface { get; init; }
        internal required HelicopterPhysicsLease RopeLease { get; init; }
        internal required ulong PhysicsSequence { get; init; }
        internal required ulong RenderFrame { get; init; }
    }

    private readonly Dictionary<(ulong EntityId, int Slot), TransportCrewDrop> _transportCrewDrops = new();
    private readonly HelicopterCrewPoolFrame? _transportCrewPoolFrame;

    internal IReadOnlyList<TransportCrewDrop> TransportCrewDrops(ulong entityId)
    {
        return Array.AsReadOnly(_transportCrewDrops.Where(entry => entry.Key.EntityId == entityId)
            .OrderBy(entry => entry.Key.Slot).Select(entry => entry.Value).ToArray());
    }

    private void CaptureTransportCrewDrops(HelicopterPhysicsWorldSnapshot physics)
    {
        if (_transportLandingNavigation == null || transportCrewPoints == null || _transportCrewPoolFrame == null ||
            manifest.MissionIndex is not int missionIndex)
        {
            throw new InvalidDataException("Native crew drop lost its mission and source placement bindings.");
        }
        var ropes = physics.Members.ToDictionary(member => member.Lease.EntityId);
        foreach ((ulong entityId, HelicopterCrewState crew) in transportHelicopterCrew)
        {
            HelicopterCrewMemberSnapshot[] due = crew.Snapshot().Where(member =>
                member.IsAttached && member.Health > 0 && member.DropStartTick == tick &&
                !_transportCrewDrops.ContainsKey((entityId, member.Slot))).ToArray();
            if (due.Length == 0)
            {
                continue;
            }
            if (!ropes.TryGetValue(entityId, out HelicopterPhysicsMemberSnapshot? rope))
            {
                throw new InvalidDataException("A crew drop requires the aircraft's active native rope.");
            }
            var aircraft = new HelicopterRopeBodyPose(transportHelicopterFlights[entityId].Position,
                transportHelicopterOrientations[entityId].Rotation);
            IReadOnlyList<HelicopterCrewPose> attached = transportCrewPoints.PlaceAttached(
                aircraft.Position, aircraft.Rotation, crew.Snapshot().Count);
            foreach (HelicopterCrewMemberSnapshot member in due)
            {
                HelicopterCrewPose pose = attached[member.Slot];
                Vector3? surface = _transportLandingNavigation.SampleHelicopterCrewLanding(
                    missionCatalog, missionIndex, pose.RopePosition);
                _transportCrewDrops.Add((entityId, member.Slot), new TransportCrewDrop
                {
                    Slot = member.Slot,
                    StartTick = tick,
                    Aircraft = aircraft,
                    // Driving follows point position only; this rotation is the point's, not the soldier's.
                    CrewPoint = new HelicopterRopeBodyPose(pose.Position, pose.Rotation),
                    // Entry captures its target earlier; later point rotations must not overwrite that evidence.
                    Birth = TransportCrewBirths(entityId).Single(birth => birth.Slot == member.Slot),
                    InitialPoolParentRotation = _transportCrewPoolFrame.ParentRotation,
                    SpawnResetRotation = _transportCrewPoolFrame.SpawnResetRotation,
                    RopeMarker = pose.RopePosition,
                    LandingSurface = surface,
                    RopeLease = rope.Lease,
                    PhysicsSequence = physics.PhysicsSteps,
                    RenderFrame = physics.RenderFrames,
                });
            }
        }
    }

    private void RemoveTransportCrewDrops(ulong entityId)
    {
        _transportCrewBirths.Remove(entityId);
        _transportCrewIdentities.Remove(entityId);
        foreach (var key in _transportCrewDrops.Keys.Where(key => key.EntityId == entityId).ToArray())
        {
            _transportCrewDescents.Remove(key);
            _transportCrewDrops.Remove(key);
        }
    }
}
