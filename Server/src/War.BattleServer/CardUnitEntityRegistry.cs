namespace War.BattleServer;

/// <summary>Host provenance for one unit created by a selected War Card.</summary>
internal sealed record CardUnitEntity(
    int LocalEntityId,
    ulong EntityKey,
    string RequestId,
    string OwnerPlayerId,
    string SourceCardId,
    string UnitId,
    int SpawnComponentFileId,
    int ReservationFileId,
    ulong SpawnTick,
    ArmyCardBaseStats BaseStats);

/// <summary>
/// Allocates card-unit identities outside the ordinary deployment ID range.
/// A card unit has no army option, energy cost, or kill-energy value.
/// </summary>
internal sealed class CardUnitEntityRegistry
{
    internal const int FirstLocalEntityId = 2_000_000_000;
    private const int MaximumEntities = 4096;

    private readonly Dictionary<int, CardUnitEntity> active = [];
    private readonly Dictionary<(string RequestId, int UnitIndex), CardUnitSpawnIntent>
        spawnedCalls = [];
    private int nextLocalEntityId = FirstLocalEntityId;

    internal int ActiveCount => active.Count;

    internal CardUnitEntity? Add(CardUnitSpawnIntent intent, int ownerFraction,
        ArmySpawnPoint point, ArmyCardBaseStats stats,
        ArmyDeploymentCatalog army, ulong tick)
    {
        if (intent == null || point == null || stats == null || army == null ||
            ownerFraction is not (1 or 2) || point.Fraction != ownerFraction ||
            intent.DueTick > tick || tick > 10_000_000 ||
            stats.Source != CardSpawnUnitSourceCatalog.Get(intent.SourceCardId) ||
            point.ComponentFileId <= 0 || point.ReservationFileId < 0 ||
            !float.IsFinite(stats.Combat.Health) || stats.Combat.Health <= 0 ||
            stats.Combat.Health > 10_000_000)
            throw new InvalidDataException("Invalid card-unit entity authority.");

        ArmyDeploymentFamily family = CardSpawnUnitSourceCatalog.Family(army,
            intent.SourceCardId);
        if (point.Collection != ArmySpawnPointSelector.Collection(family.BehaviorType))
            throw new InvalidDataException("Card unit uses the wrong source spawn collection.");

        var call = (intent.RequestId, intent.UnitIndex);
        if (spawnedCalls.TryGetValue(call, out var previous))
        {
            if (previous != intent)
                throw new InvalidDataException("Card-unit spawn call identity changed.");
            return null;
        }
        if (spawnedCalls.Count >= MaximumEntities ||
            nextLocalEntityId == FirstLocalEntityId + MaximumEntities)
            throw new InvalidDataException("Card-unit entity identity capacity exceeded.");

        int localId = nextLocalEntityId++;
        ulong entityKey = ((ulong)ownerFraction << 32) | (uint)localId;
        var entity = new CardUnitEntity(localId, entityKey,
            intent.RequestId, intent.OwnerPlayerId, intent.SourceCardId,
            stats.Source.UnitId, point.ComponentFileId,
            point.ReservationFileId, tick, stats);
        active.Add(localId, entity);
        spawnedCalls.Add(call, intent);
        return entity;
    }

    internal CardUnitEntity? Find(int localEntityId) =>
        active.GetValueOrDefault(localEntityId);

    internal CardUnitEntity? Remove(int localEntityId)
    {
        return active.Remove(localEntityId, out var entity) ? entity : null;
    }
}
