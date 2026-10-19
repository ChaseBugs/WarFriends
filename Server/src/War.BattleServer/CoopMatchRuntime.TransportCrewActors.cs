using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, TransportCrewActorState> _transportCrewActors = new();

    internal int TransportCrewActorCount => _transportCrewActors.Count;

    internal TransportCrewActorSnapshot? TransportCrewActor(ulong actorId)
    {
        return _transportCrewActors.TryGetValue(actorId, out TransportCrewActorState? actor)
            ? actor.Snapshot() : null;
    }

    /// <summary>Confirms host SetFinalTarget seat release only after a scene point is reserved.</summary>
    internal bool ConfirmTransportCrewSeatReleased(ulong actorId, ulong observedTick)
    {
        if (phase != BattlePhase.Running || observedTick != tick ||
            observedTick >= mission.DeadlineTick ||
            enemyDestinations?.ForEnemy(actorId) == null ||
            !_transportCrewActors.TryGetValue(actorId, out TransportCrewActorState? actor) ||
            !actor.Detach(observedTick))
        {
            return false;
        }

        stateRevision++;
        return true;
    }

    private bool ApplyHostCrewDamage(TransportCrewActorState actor, float damage,
        ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        if (actor.Health <= 0)
        {
            return false;
        }

        if (damage >= actor.Health)
        {
            bool confirmed = credit == null
                ? mission.ConfirmAiDeath(actor.EntityId, impactTick)
                : mission.ConfirmAttributedAiDeath(actor.EntityId, credit.PlayerId,
                    credit.KillCredit, skillShotScores!, impactTick);
            if (!confirmed)
            {
                return false;
            }
        }

        if (!actor.Damage(damage, impactTick))
        {
            throw new InvalidDataException("Validated host damage could not update crew health.");
        }

        if (transportHelicopterCrew.TryGetValue(actor.AircraftId, out HelicopterCrewState? crew))
        {
            crew.PublishActorHealth(actor.Slot, actor.Health);
        }

        if (actor.Health == 0)
        {
            enemyDestinations?.Release(actor.EntityId);
        }

        stateRevision++;
        if (mission.Outcome == MissionOutcome.Succeeded)
        {
            End(BattlePhase.Ended, "mission-success");
        }

        return true;
    }

    private void RegisterInitialTransportCrewActors(ulong aircraftId)
    {
        if (!transportHelicopterCrew.TryGetValue(aircraftId, out HelicopterCrewState? crew))
        {
            return;
        }

        IReadOnlyList<TransportCrewIdentity> identities = TransportCrewIdentities(aircraftId);
        IReadOnlyList<HelicopterCrewMemberSnapshot> members = crew.Snapshot();
        var actors = new List<TransportCrewActorState>(members.Count);
        foreach (TransportCrewIdentity identity in identities)
        {
            actors.Add(new TransportCrewActorState(identity, aircraftId, members[identity.Slot], tick));
        }

        // Reservations alone were not actors. Health initialization now creates the
        // initial source cohort, after its parent has entered mission accounting.
        ulong[] actorIds = actors.Select(actor => actor.EntityId).ToArray();
        if (actors.Count != members.Count ||
            actorIds.Any(actorId => _transportCrewActors.ContainsKey(actorId)) ||
            !mission.ConfirmInitialTransportCrew(aircraftId, actorIds, tick))
        {
            throw new InvalidDataException("Initial transport crew could not enter host mission accounting.");
        }

        foreach (TransportCrewActorState actor in actors)
        {
            _transportCrewActors.Add(actor.EntityId, actor);
        }
    }

    private void DestroyAttachedTransportCrew(ulong aircraftId, ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        TransportCrewActorState[] attached = _transportCrewActors.Values
            .Where(actor => actor.AircraftId == aircraftId && actor.IsAttached && actor.Health > 0)
            .OrderBy(actor => actor.Slot).ToArray();
        foreach (TransportCrewActorState actor in attached)
        {
            // Helicopter.OnOnDeath invokes DestroySoldier in seat order before its own OnKilled.
            if (!ApplyHostCrewDamage(actor, actor.Health, impactTick, credit))
            {
                throw new InvalidDataException("Source attached crew death failed mission authority.");
            }
        }
    }
}
