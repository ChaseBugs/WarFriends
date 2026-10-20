using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Resolves ShootJustStarted aim without treating the observed muzzle as launch authority.</summary>
    internal AssaulterAimPrediction StartTransportCrewPreparedShot(TransportCrewNavigationCommand command,
        TransportCrewPreparedShot prepared, TransportCrewObstacleClock.ShotObservation observation,
        Vector3 observedWeaponMuzzle)
    {
        ArgumentNullException.ThrowIfNull(prepared);
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        if (!ReferenceEquals(owner.PreparedCrewShot, prepared) ||
            !_transportCrewAimWeapons.TryGetValue(command.ActorEntityId, out AssaulterWeaponAimState? weapon) ||
            !participants.TryGetValue(prepared.Target.PlayerId, out Participant? player))
        {
            throw new InvalidOperationException("Crew shot start requires its prepared target and owned rifle.");
        }
        TransportCrewObstacleClock clock = owner.ObstacleClock!;
        clock.RequireShotStart(prepared.Callback, observation);

        // ShootJustStarted predicts from the retained targetPosition, not a freshly sampled target transform.
        // Velocity is read at callback time, including a player that has since stopped walking.
        AssaulterAimPrediction aim = weapon.StartPlayerShot(observedWeaponMuzzle,
            prepared.Target.PreparedAimPosition, player.MovementVelocity);
        clock.ObserveShotStarted(prepared.Callback, observation);
        return aim;
    }
}
