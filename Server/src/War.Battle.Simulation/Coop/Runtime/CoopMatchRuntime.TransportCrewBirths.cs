using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float CrewBirthRotationUnitTolerance = 0.0002f;

    /// <summary>Immutable host spawn publication; canonical Client entry callbacks still require observation.</summary>
    internal sealed record TransportCrewBirth
    {
        internal required ulong ActorEntityId { get; init; }
        internal required int Slot { get; init; }
        internal required ulong SpawnTick { get; init; }
        internal required float SpawnRealtime { get; init; }
        internal required HelicopterRopeBodyPose Aircraft { get; init; }
        internal required HelicopterRopeBodyPose CrewPoint { get; init; }
    }

    private readonly Dictionary<ulong, IReadOnlyList<TransportCrewBirth>> _transportCrewBirths = new();

    internal IReadOnlyList<TransportCrewBirth> TransportCrewBirths(ulong entityId)
    {
        return _transportCrewBirths.GetValueOrDefault(entityId) ?? Array.Empty<TransportCrewBirth>();
    }

    private void CaptureTransportCrewBirths(ulong entityId, int seats, Quaternion? sourceSpawnRotation)
    {
        if (_transportRopes == null)
        {
            return;
        }
        if (transportCrewPoints == null || _transportCrewPoolFrame == null)
        {
            throw new InvalidDataException("Native crew birth lost its source point or initial pool binding.");
        }
        if (sourceSpawnRotation is not Quaternion rotation ||
            !float.IsFinite(rotation.LengthSquared()) ||
            MathF.Abs(rotation.LengthSquared() - 1f) > CrewBirthRotationUnitTolerance)
        {
            throw new InvalidDataException("Native crew birth requires the source aircraft spawn rotation.");
        }
        // Helicopter.Spawn sets the spawn-point rotation before SpawnAssaulter. Its first Update later
        // replaces that transform from the separately retained horizontal/vertical orientation state.
        var aircraft = new HelicopterRopeBodyPose(transportHelicopterFlights[entityId].Position,
            rotation);
        IReadOnlyList<HelicopterCrewPose> points = transportCrewPoints.PlaceAttached(
            aircraft.Position, aircraft.Rotation, seats);
        float spawnRealtime = _transportSpawnRealtime[entityId];
        TransportCrewBirth[] births = points.Select(point => new TransportCrewBirth
        {
            ActorEntityId = TransportCrewIdentities(entityId).Single(identity => identity.Slot == point.Slot).EntityId,
            Slot = point.Slot,
            SpawnTick = tick,
            SpawnRealtime = spawnRealtime,
            Aircraft = aircraft,
            CrewPoint = new HelicopterRopeBodyPose(point.Position, point.Rotation),
        }).ToArray();
        if (!_transportCrewBirths.TryAdd(entityId, Array.AsReadOnly(births)))
        {
            throw new InvalidDataException("Transport crew birth cannot replace an existing spawn publication.");
        }
    }
}
