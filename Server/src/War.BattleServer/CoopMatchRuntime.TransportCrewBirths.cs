namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Immutable host spawn publication; canonical Client entry callbacks still require observation.</summary>
    internal sealed record TransportCrewBirth(int Slot, ulong SpawnTick,
        HelicopterRopeBodyPose Aircraft, HelicopterRopeBodyPose CrewPoint);

    private readonly Dictionary<ulong, IReadOnlyList<TransportCrewBirth>> _transportCrewBirths = new();

    internal IReadOnlyList<TransportCrewBirth> TransportCrewBirths(ulong entityId)
    {
        return _transportCrewBirths.GetValueOrDefault(entityId) ?? Array.Empty<TransportCrewBirth>();
    }

    private void CaptureTransportCrewBirths(ulong entityId, int seats)
    {
        if (_transportRopes == null)
        {
            return;
        }
        if (transportCrewPoints == null || _transportCrewPoolFrame == null)
        {
            throw new InvalidDataException("Native crew birth lost its source point or initial pool binding.");
        }
        var aircraft = new HelicopterRopeBodyPose(transportHelicopterFlights[entityId].Position,
            transportHelicopterOrientations[entityId].Rotation);
        IReadOnlyList<HelicopterCrewPose> points = transportCrewPoints.PlaceAttached(
            aircraft.Position, aircraft.Rotation, seats);
        TransportCrewBirth[] births = points.Select(point => new TransportCrewBirth(point.Slot, tick,
            aircraft, new HelicopterRopeBodyPose(point.Position, point.Rotation))).ToArray();
        if (!_transportCrewBirths.TryAdd(entityId, Array.AsReadOnly(births)))
        {
            throw new InvalidDataException("Transport crew birth cannot replace an existing spawn publication.");
        }
    }
}
