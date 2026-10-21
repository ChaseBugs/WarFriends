using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, ulong> _transportCrewWalkingFrames = new();

    /// <summary>Records a source walking transition request, not a fabricated motor pose or combat permission.</summary>
    internal TransportCrewPointArrival? ObserveTransportCrewWalk(
        TransportCrewNavigationCommand command, TransportCrewWalkObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (!IsTransportCrewNavigationCurrent(command) ||
            !_transportCrewNavigation.TryGetValue(command.ActorEntityId, out TransportCrewNavigationOwner? owner) ||
            !owner.HasBegun || owner.PointEntry != null || TransportRopeSnapshot?.RenderFrames != observation.Frame ||
            (_transportCrewWalkingFrames.TryGetValue(command.ActorEntityId, out ulong lastFrame) &&
                observation.Frame <= lastFrame))
        {
            throw new InvalidOperationException("Crew walking requires its current begun command and a fresh host frame.");
        }

        bool reached = EnemyPointArrivalPolicy.HasReached(observation.Position, command.Destination,
            observation.IsPreparingShot);
        CoopAssignedEnemyDestination? destination = enemyDestinations?.ForEnemy(command.ActorEntityId);
        TransportCrewPointArrival? arrival = null;
        if (command.PointComponentFileId.HasValue && owner.Arrival == null && reached)
        {
            if (destination?.PointComponentFileId != command.PointComponentFileId ||
                destination.Position != command.Destination)
            {
                throw new InvalidDataException("Crew walking lost its authored destination reservation.");
            }
            CoopInfantryPointState state = enemyDestinations!.PointTypeFor(command.ActorEntityId) switch
            {
                "EnemyPointObstacle" => CoopInfantryPointState.ObstacleHiding,
                "EnemyPointCorner" => CoopInfantryPointState.CornerHiding,
                _ => throw new InvalidDataException("Crew arrived at an unsupported Assaulter point type."),
            };
            arrival = new TransportCrewPointArrival(observation.Frame, observation.Position,
                destination.PointComponentFileId, state);
        }

        // A fallback destination only plays Walk(); it remains in Helicopter state until GenerateInitPoint succeeds.
        _transportCrewWalkingFrames[command.ActorEntityId] = observation.Frame;
        if (arrival != null)
        {
            owner.Arrival = arrival;
        }
        return arrival;
    }

    internal sealed record TransportCrewWalkObservation(ulong Frame, Vector3 Position, bool IsPreparingShot);

    /// <summary>Requests source point entry; stop/crawl/tweens and shooting clocks still require a host consumer.</summary>
    internal sealed record TransportCrewPointArrival(
        ulong Frame, Vector3 ObservedPosition, int PointComponentFileId, CoopInfantryPointState State);
}
