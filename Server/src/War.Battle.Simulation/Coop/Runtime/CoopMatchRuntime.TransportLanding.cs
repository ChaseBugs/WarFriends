using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    internal sealed record TransportLanding(ulong StopTick, Vector3 RopeOrigin,
        Vector3 PlayerPoint, Vector3? Surface);

    private readonly Dictionary<ulong, TransportLanding> _transportLandings = new();
    private CoopNavMeshConnectivity? _transportLandingNavigation;
    private readonly HelicopterRopeDefinition? _transportRopeDefinition;

    /// <summary>Binds trusted detail geometry before admission; no client command can select this source.</summary>
    internal void BindTransportLandingNavigation(CoopNavMeshConnectivity navigation)
    {
        ArgumentNullException.ThrowIfNull(navigation);
        if (Terminal || tick != 0 || participants.Values.Any(player => player.Admitted) ||
            _transportLandingNavigation != null || !navigation.HasHelicopterLandingDetails ||
            _transportRopeDefinition == null)
        {
            throw new InvalidOperationException("Transport landing geometry must bind once before admission.");
        }
        _transportLandingNavigation = navigation;
    }

    internal TransportLanding? TransportLandingFor(ulong entityId)
    {
        return _transportLandings.GetValueOrDefault(entityId);
    }

    private void CaptureTransportLanding(ulong entityId, Vector3 previousPosition, Quaternion previousRotation)
    {
        if (_transportLandingNavigation == null)
        {
            return;
        }
        if (_transportRopeDefinition == null || manifest.MissionIndex is not int missionIndex)
        {
            throw new InvalidDataException("Transport landing lost its source rope or mission identity.");
        }
        Participant player = GetSourceAuthorityPlayer();
        // GoTo locks currentPlayerPoint to its destination before physical movement finishes.
        int coverIndex = player.Route == null ? player.CoverIndex : player.DestinationIndex;
        if (coverIndex < alliedFirstCover || coverIndex > alliedLastCover)
        {
            throw new InvalidDataException("Transport landing lost the source master's current player point.");
        }
        Vector3 playerPoint = playerPositions[coverIndex].Position;
        Vector3 ropeOrigin = _transportRopeDefinition.RootPositionAt(
            new HelicopterRopeBodyPose(previousPosition, previousRotation));
        var query = new HelicopterRopeLandingQuery(ropeOrigin, playerPoint);
        Vector3? surface = _transportLandingNavigation.SampleHelicopterLanding(missionCatalog, missionIndex, query);
        if (!_transportLandings.TryAdd(entityId, new TransportLanding(tick, ropeOrigin, playerPoint, surface)))
        {
            throw new InvalidDataException("Transport arrival attempted to replace an existing landing decision.");
        }
    }
}
