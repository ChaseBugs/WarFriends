namespace War.BattleServer;

/// <summary>
/// Validates source point selection and walking-shot timing before replacing a crew reservation.
/// </summary>
internal sealed class TransportCrewPointChange
{
    private readonly CoopEnemyDestinationState _destinations;
    private readonly CoopEnemyCombatCatalog _combat;
    private readonly Func<float> _chooseShotFraction;

    internal TransportCrewPointChange(CoopEnemyDestinationState destinations, CoopEnemyCombatCatalog combat,
        Func<float> chooseShotFraction)
    {
        ArgumentNullException.ThrowIfNull(destinations);
        ArgumentNullException.ThrowIfNull(combat);
        if (!destinations.UsesCombat(combat))
        {
            throw new InvalidDataException("Crew point change requires the destination owner's combat catalog.");
        }
        _destinations = destinations;
        _combat = combat;
        _chooseShotFraction = chooseShotFraction ?? throw new ArgumentNullException(nameof(chooseShotFraction));
    }

    internal Result Resolve(TransportCrewObstacleClock clock, Request request)
    {
        ArgumentNullException.ThrowIfNull(clock);
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.Observation);
        ArgumentNullException.ThrowIfNull(request.Observation.Clock);
        clock.RequirePointChange(request.Observation.Clock);
        // Validate card binding before selection can consume randomness or change a reservation.
        ArmyBaseShotStats shot = _combat.TransportCrewShot(request.ParentUpgradeIndex);
        CoopEnemyDestinationState.CrewRetargetPlan? plan =
            _destinations.PlanCrewRetarget(request.ActorId, request.Observation.Position);
        if (plan == null)
        {
            clock.CompleteBlockedPointChange(request.Observation.Clock);
            return new Result(null, null);
        }

        // UpgradeSlotsBaseSoldier loads walk and hidden shot delays from the same columns for Assaulter.
        // Source chooses the next point/position before SwitchStateToWalking draws its shot deadline.
        float fraction = _chooseShotFraction();
        if (!float.IsFinite(fraction) || fraction is < 0 or > 1)
        {
            throw new InvalidDataException("Crew walking shot choice must be a source float fraction.");
        }
        float delay = shot.MinShootTime + (shot.MaxShootTime - shot.MinShootTime) * fraction;
        float time = request.Observation.Clock.ControllerTime;
        float deadline = time + delay;
        if (!float.IsFinite(deadline) || deadline < time || (delay > 0 && deadline == time))
        {
            throw new InvalidDataException("Crew walking shot deadline exceeds source float time resolution.");
        }
        _destinations.CommitCrewRetarget(plan);
        clock.CompleteSuccessfulPointChange(request.Observation.Clock);
        return new Result(plan.Destination, deadline);
    }

    internal sealed record Request(ulong ActorId, int ParentUpgradeIndex,
        CoopMatchRuntime.TransportCrewObstacleObservation Observation);

    internal sealed record Result(CoopAssignedEnemyDestination? Destination, float? NextWalkingShotTime);
}
