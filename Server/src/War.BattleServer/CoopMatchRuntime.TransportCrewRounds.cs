using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Runs one source Update through a host-only weapon producer, then applies final-round return.</summary>
    internal bool ExecuteTransportCrewRifleRound(TransportCrewNavigationCommand command,
        CrewRoundObservation observation, Action<TransportCrewRifleVolley.Round> fire)
    {
        ArgumentNullException.ThrowIfNull(observation);
        ArgumentNullException.ThrowIfNull(observation.Clock);
        ArgumentNullException.ThrowIfNull(fire);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Clock.Frame);
        if (owner.PreparedCrewShot is not TransportCrewPreparedShot prepared ||
            owner.CrewRifleVolley is not TransportCrewRifleVolley volley)
        {
            throw new InvalidOperationException("Crew rifle execution requires its prepared and started volley.");
        }
        // EndShooting must run before this frame's AI update, also constraining intermediate rounds.
        owner.ObstacleClock!.RequireShotEnd(prepared.Callback, observation.Clock);
        var fireObservation = new TransportCrewRifleVolley.FireObservation(observation.Clock.Frame,
            observation.Clock.CoroutineTime, observation.ActorPosition);
        bool fired = volley.TryFire(fireObservation,
            new TransportCrewRifleVolley.FakeDraws(chooseInfantryFakeDistance, chooseInfantryFakeSideRoll), fire);
        if (fired && volley.IsComplete)
        {
            ObserveTransportCrewShotEnded(command, prepared.Callback, observation.Clock);
        }
        return fired;
    }

    internal sealed record CrewRoundObservation(TransportCrewObstacleClock.ShotObservation Clock,
        Vector3 ActorPosition);
}
