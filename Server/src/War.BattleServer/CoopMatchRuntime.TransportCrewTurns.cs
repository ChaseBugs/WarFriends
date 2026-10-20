using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, CoopShotRootTween> _transportCrewRootTweens = new();

    /// <summary>Begins the obstacle preparation turn on the crew's already-started source component.</summary>
    internal void BeginTransportCrewShotTurn(TransportCrewNavigationCommand command,
        TransportCrewPreparedShot prepared, TransportCrewShotTurn.Observation observation)
    {
        ArgumentNullException.ThrowIfNull(prepared);
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        if (!ReferenceEquals(owner.PreparedCrewShot, prepared) || owner.ShotTurn != null ||
            prepared.Target.Frame != observation.Frame || owner.PointEntry?.IsCrawling != true)
        {
            throw new InvalidOperationException("Crew turn requires its exact current obstacle preparation.");
        }
        if (owner.HasPathMotor && prepared.Target.ActorPosition !=
            (owner.PathMotor?.Position ?? command.StartPosition))
        {
            throw new InvalidOperationException("Crew turn target was acquired from a different motor root.");
        }
        Quaternion target = CoopAssaulterShotRotation.Obstacle(prepared.Target.ActorPosition,
            prepared.Target.PreparedAimPosition);
        if (!_transportCrewRootTweens.TryGetValue(command.ActorEntityId, out CoopShotRootTween? tween))
        {
            // SwitchStateToHelicopter already began this component before the accepted descent completion.
            tween = CoopShotRootTween.ForStartedComponent(SourceObstacleTurnSeconds);
        }
        tween.Begin(observation.RootBeforeUpdate, target);
        _transportCrewRootTweens[command.ActorEntityId] = tween;
        owner.ShotTurn = new TransportCrewShotTurn(tween, observation.Frame);
    }

    /// <summary>Consumes a scaled tween phase without publishing collision or projectile authority.</summary>
    internal Quaternion AdvanceTransportCrewShotTurn(TransportCrewNavigationCommand command,
        TransportCrewShotTurn.Observation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        TransportCrewShotTurn turn = owner.ShotTurn ??
            throw new InvalidOperationException("Crew has no current preparation turn.");
        return turn.Advance(observation);
    }
}
