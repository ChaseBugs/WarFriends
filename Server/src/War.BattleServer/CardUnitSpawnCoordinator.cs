using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Resolves one due card call using trusted level data and the recovered map.
/// The card's inventory is reserved separately when its activation is accepted.
/// </summary>
internal sealed class CardUnitSpawnCoordinator
{
    private readonly CardUnitSpawnState schedule;
    private readonly CardUnitEntityRegistry entities;
    private readonly ArmyDeploymentCatalog army;
    private readonly RecoveredBattleMap map;
    private readonly ArmySpawnPointSelector selector;
    private readonly ArmySpawnReservationLedger reservations;
    private readonly int maximumDisplayLevel;
    private readonly Func<int, int> choose;

    internal CardUnitSpawnCoordinator(CardUnitSpawnState schedule,
        CardUnitEntityRegistry entities, ArmyDeploymentCatalog army,
        RecoveredBattleMap map, ArmySpawnPointSelector selector,
        ArmySpawnReservationLedger reservations,
        int maximumDisplayLevel, Func<int, int> choose)
    {
        this.schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
        this.entities = entities ?? throw new ArgumentNullException(nameof(entities));
        this.army = army ?? throw new ArgumentNullException(nameof(army));
        this.map = map ?? throw new ArgumentNullException(nameof(map));
        this.selector = selector ?? throw new ArgumentNullException(nameof(selector));
        this.reservations = reservations ?? throw new ArgumentNullException(nameof(reservations));
        this.choose = choose ?? throw new ArgumentNullException(nameof(choose));
        if (maximumDisplayLevel <= 0 || maximumDisplayLevel > 1000)
            throw new InvalidDataException("Invalid card-unit maximum display level.");
        this.maximumDisplayLevel = maximumDisplayLevel;
    }

    internal CardUnitEntity? SpawnDue(CardUnitSpawnIntent intent,
        int ownerFraction, int ownerLevel, Vector3 opponentPosition, ulong tick)
    {
        if (intent == null || !schedule.Due(tick).Contains(intent))
            throw new InvalidDataException("Card-unit call is not due in this match.");

        var family = CardSpawnUnitSourceCatalog.Family(army, intent.SourceCardId);
        var stats = army.CardBaseStats(intent.SourceCardId,
            ownerLevel, maximumDisplayLevel);
        var point = selector.Select(map, family, ownerFraction,
            opponentPosition, choose, reservations.Available);

        // The recovered Drone.Spawn logs a failed point search; the card was
        // already used. A soldier's Spawn catches the same failure. Do not
        // retry this source call later after an unrelated route becomes free.
        if (point == null)
        {
            if (!schedule.Complete(intent, tick))
                throw new InvalidDataException("Missing card-unit call changed before point failure.");
            return null;
        }

        var entity = entities.Add(intent, ownerFraction, point, stats, army, tick);
        if (entity == null ||
            !reservations.TryReserve(point, entity.EntityKey) ||
            !schedule.Complete(intent, tick))
            throw new InvalidDataException("Card-unit entity, route, and call did not commit together.");
        return entity;
    }

    internal bool ReleaseRoute(CardUnitEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return reservations.Release(entity.EntityKey);
    }
}
