using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float MaximumTransportGunnerDamage = 10_000_000;

    private readonly Dictionary<ulong, ulong> _transportGunnerActorIds = new();

    internal ulong? TransportGunnerActorId(ulong aircraftId)
    {
        return _transportGunnerActorIds.TryGetValue(aircraftId, out ulong actorId) ? actorId : null;
    }

    private void RegisterTransportGunnerActor(ulong aircraftId)
    {
        ulong actorId = _enemyIds.Allocate();
        if (!mission.ConfirmTransportGunner(aircraftId, actorId, tick))
        {
            throw new InvalidDataException("Created transport gunner could not enter mission accounting.");
        }

        _transportGunnerActorIds[aircraftId] = actorId;
        enemySpawns.Single(enemy => enemy.EntityId == aircraftId).GunnerEntityId = actorId;
    }

    private bool ApplyHostTransportGunnerDamage(ulong aircraftId, float damage,
        ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        if (phase != BattlePhase.Running || impactTick != tick || impactTick >= mission.DeadlineTick ||
            !float.IsFinite(damage) || damage <= 0 || damage > MaximumTransportGunnerDamage ||
            !transportGunners.TryGetValue(aircraftId, out HelicopterGunnerState? gunner) ||
            !_transportGunnerActorIds.TryGetValue(aircraftId, out ulong actorId))
        {
            return false;
        }

        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == aircraftId && spawn.Health > 0 && spawn.DeathTick == 0);
        float health = gunner.Snapshot().Health;
        if (enemy == null || health <= 0)
        {
            return false;
        }

        if (damage >= health && !ConfirmGunnerDeath(actorId, impactTick, credit))
        {
            return false;
        }

        if (!gunner.Damage(damage, impactTick))
        {
            throw new InvalidDataException("Validated gunner impact could not update source health.");
        }

        PublishTransportGunner(enemy, gunner.Snapshot());
        stateRevision++;
        if (mission.Outcome == MissionOutcome.Succeeded)
        {
            End(BattlePhase.Ended, "mission-success");
        }

        return true;
    }

    private bool ConfirmGunnerDeath(ulong actorId, ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        return credit == null
            ? mission.ConfirmAiDeath(actorId, impactTick)
            : mission.ConfirmAttributedAiDeath(actorId, credit.PlayerId,
                credit.KillCredit, skillShotScores!, impactTick);
    }

    private void DestroyTransportGunnerAfterAircraft(ulong aircraftId, ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        if (transportGunners.TryGetValue(aircraftId, out HelicopterGunnerState? gunner) &&
            gunner.Snapshot().Health > 0)
        {
            // The source calls DestroySoldier for the turret after the aircraft's OnKilled.
            if (!_transportGunnerActorIds.TryGetValue(aircraftId, out ulong actorId) ||
                !ConfirmGunnerDeath(actorId, impactTick, credit))
            {
                throw new InvalidDataException("Source turret soldier death failed mission authority.");
            }
        }
    }
}
