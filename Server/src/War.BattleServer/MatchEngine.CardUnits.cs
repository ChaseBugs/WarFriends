using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly CardUnitSpawnState cardUnitSpawns = new();
    private readonly CardUnitEntityRegistry cardUnitEntities = new();
    private CardUnitCombatLifecycle? cardUnitCombat;

    /// <summary>
    /// Host-only activation seam. The UDP command remains closed until
    /// recovered unit AI and Client presentation can consume these spawns.
    /// </summary>
    internal bool TryScheduleCardUnit(string requestId, string ownerPlayerId,
        string sourceCardId)
    {
        Player? owner = Find(ownerPlayerId);
        if (phase != BattlePhase.Running || owner?.Admitted != true ||
            owner.Definition.PlayerLevel is not { } ownerLevel ||
            ownerLevel < 0 || cardUnitCombat == null ||
            !War.Shared.CardUnitSourceIdentity.IsKnown(sourceCardId) ||
            !owner.CardsSelected ||
            !owner.SelectedCards.Contains(sourceCardId, StringComparer.Ordinal) ||
            cardReservations?.HasInventory(ownerPlayerId, sourceCardId) != true ||
            !performance.CanRecordCard(requestId) ||
            !EventCapacityForArmy(CardSpawnUnitSourceCatalog.Get(sourceCardId).Count + 1))
            return false;

        if (!cardUnitSpawns.TrySchedule(requestId, ownerPlayerId,
            sourceCardId, tick))
            return false;
        if (!cardReservations!.TryReserve(requestId, ownerPlayerId, sourceCardId))
        {
            cardUnitSpawns.CancelBeforeSpawn(requestId);
            return false;
        }

        // A selected Card.id is charged once even if its recovered source
        // Spawn call finds no scene point. Ordinary army energy is untouched.
        performance.RecordCard(requestId, ownerPlayerId,
            "CardSpawnUnit", sourceCardId);
        stateRevision++;
        Emit(MatchEventKind.CardEffectApplied, ownerPlayerId,
            "CardSpawnUnit", 0, owner.Position, 0, requestId);
        AdvanceCardUnitSpawns();
        return true;
    }

    private void AdvanceCardUnitSpawns()
    {
        if (cardUnitCombat == null)
            throw new InvalidDataException("Card-unit combat content is absent.");

        foreach (CardUnitSpawnIntent intent in cardUnitSpawns.Due(tick))
        {
            Player owner = Find(intent.OwnerPlayerId) ??
                throw new InvalidDataException("Card-unit owner left the match.");
            Player opponent = players.Single(player => player != owner);
            int ownerLevel = owner.Definition.PlayerLevel ??
                throw new InvalidDataException("Card-unit owner lacks a trusted level.");

            if (!EventCapacityForArmy(1))
            {
                End("army-event-backpressure", "", false);
                return;
            }

            BattleArmyEntityState? entity = cardUnitCombat.SpawnDue(intent,
                owner.Definition.Fraction, ownerLevel, opponent.Position, tick);
            if (entity == null)
                continue; // Source Spawn consumed its failed point search.

            activeArmyEntities.Add(entity.EntityKey, entity);
            armyEntityRevision++;
            stateRevision++;
            Emit(MatchEventKind.ArmySpawned, owner.Definition.PlayerId,
                "", 0, new(entity.X, entity.Y, entity.Z), 0, "");
            MatchEvent spawnEvent = events[^1];
            spawnEvent.ArmyEntityId = entity.LocalEntityId;
            spawnEvent.ArmyOptionIndex = -1;
            spawnEvent.ArmyUnitId = entity.UnitId;
            spawnEvent.ArmySpawnComponentFileId = entity.SpawnComponentFileId;
            spawnEvent.ArmyReservationFileId = entity.ReservationFileId;
            spawnEvent.SourceCardId = entity.SourceCardId;
        }
    }

    private bool ConfirmCardUnitDeath(ulong entityKey, bool suicide)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId.Length == 0 || cardUnitCombat == null)
            return false;
        if (!EventCapacityForArmyDeath())
        {
            End("army-event-backpressure", "", false);
            return false;
        }

        BattleArmyEntityState? authoritative = cardUnitCombat.Find(entityKey);
        if (authoritative == null ||
            authoritative.OwnerPlayerId != entity.OwnerPlayerId ||
            authoritative.SourceCardId != entity.SourceCardId ||
            authoritative.Health != entity.Health)
            throw new InvalidDataException("Card-unit death lost its roster proof.");
        if (cardUnitCombat.ApplyHostDamage(entityKey, entity.Health) is not
            { Died: true })
            throw new InvalidDataException("Card-unit death did not remove its health authority.");
        if (!activeArmyEntities.Remove(entityKey))
            throw new InvalidDataException("Card-unit death lost its public roster row.");

        armyEntityRevision++;
        stateRevision++;
        Emit(MatchEventKind.ArmyDied, "", entity.OwnerPlayerId, 0,
            new(entity.X, entity.Y, entity.Z), 0,
            suicide ? "suicide" : "combat");
        MatchEvent deathEvent = events[^1];
        deathEvent.ArmyEntityId = entity.LocalEntityId;
        deathEvent.ArmyOptionIndex = -1;
        deathEvent.ArmyUnitId = entity.UnitId;
        deathEvent.ArmySpawnComponentFileId = entity.SpawnComponentFileId;
        deathEvent.ArmyReservationFileId = entity.ReservationFileId;
        deathEvent.SourceCardId = entity.SourceCardId;
        return true;
    }
}
