namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Derives StartShooting success and its batch from the match-owned target and rifle.</summary>
    internal TransportCrewPreparedShot PrepareTransportCrewShot(TransportCrewNavigationCommand command,
        TransportCrewTargetPlan target, float coroutineTime)
    {
        ArgumentNullException.ThrowIfNull(target);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, target.Frame);
        if (!ReferenceEquals(owner.AcquiredCrewTarget, target) || !float.IsFinite(coroutineTime) || coroutineTime < 0 ||
            assaulterWeapon == null || !CoopCommandCapabilities.CanConfirmPlayerOnlyOpposition)
        {
            throw new InvalidOperationException(
                "Crew preparation requires its acquired target and source rifle binding.");
        }
        if (owner.PreparedCrewShot != null)
        {
            return owner.PreparedCrewShot;
        }
        if (target.Revision != stateRevision || target.Tick != tick ||
            !participants.TryGetValue(target.PlayerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead || player.Departed ||
            owner.PendingObstacleObservation is not TransportCrewObstacleObservation pending)
        {
            throw new InvalidOperationException("Crew preparation target no longer belongs to its acquisition frame.");
        }
        owner.ObstacleClock!.RequireShotPreparation(pending.Clock);
        ArmyBaseShotStats shot = CrewShotStats(command);
        CoopInfantryShotBatch batch = AssaulterShotBatchPolicy.Create(shot,
            _ => chooseInfantryBatchSize(shot.FireBatchSizeMin, shot.FireBatchSizeMax) - shot.FireBatchSizeMin,
            chooseInfantryRealShotRoll);
        // Default Assaulter has its primary rifle. A resolved mShotTarget makes StartShooting true.
        // Native/target-world inputs still do not establish a launch origin or authorize damage.
        var observation = new TransportCrewPreparationObservation(
            TransportCrewObstacleClock.PreparationOutcome.Prepared, coroutineTime);
        TransportCrewObstacleClock.ShotCallbackTicket ticket =
            ObserveTransportCrewPreparation(command, pending, observation) ??
                throw new InvalidDataException("Source preparation failed to create its scheduled callback.");
        var prepared = new TransportCrewPreparedShot(target, batch, ticket, assaulterWeapon.WeaponPrefabGuid);
        owner.PreparedCrewShot = prepared;
        owner.CrewPreparationControllerTime = pending.Clock.ControllerTime;
        owner.CrewPreparationScaledTime = coroutineTime;
        owner.CrewExecutedRoundOffsets.Clear();
        owner.CrewLastRoundScaledTime = null;
        return prepared;
    }

    /// <summary>Source preparation data; animation, callback aim and projectile producers remain separate.</summary>
    internal sealed record TransportCrewPreparedShot(TransportCrewTargetPlan Target, CoopInfantryShotBatch Batch,
        TransportCrewObstacleClock.ShotCallbackTicket Callback, string WeaponPrefabGuid);
}
