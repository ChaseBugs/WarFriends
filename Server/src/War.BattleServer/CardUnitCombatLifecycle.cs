using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

/// <summary>The host-owned spawn, health, and death state of card units.</summary>
internal sealed class CardUnitCombatLifecycle
{
    internal sealed record DamageResult(BattleArmyEntityState Entity, bool Died);

    private readonly CardUnitSpawnCoordinator spawns;
    private readonly Dictionary<ulong, CardUnitEntity> entities = [];
    private readonly Dictionary<ulong, BattleArmyEntityState> roster = [];

    internal CardUnitCombatLifecycle(CardUnitSpawnCoordinator spawns)
    {
        this.spawns = spawns ?? throw new ArgumentNullException(nameof(spawns));
    }

    internal int ActiveCount => roster.Count;

    internal BattleArmyEntityState? SpawnDue(CardUnitSpawnIntent intent,
        int ownerFraction, int ownerLevel, Vector3 opponentPosition, ulong tick)
    {
        CardUnitEntity? entity = spawns.SpawnDue(intent, ownerFraction,
            ownerLevel, opponentPosition, tick);
        if (entity == null)
            return null;

        BattleArmyEntityState row = CardUnitEntityProjection.Create(entity, ownerFraction);
        if (!entities.TryAdd(entity.EntityKey, entity) ||
            !roster.TryAdd(entity.EntityKey, row))
            throw new InvalidDataException("Card-unit spawn reused a live entity identity.");

        return row.Clone();
    }

    internal BattleArmyEntityState? Find(ulong entityKey) =>
        roster.TryGetValue(entityKey, out var row) ? row.Clone() : null;

    internal void UpdatePose(BattleArmyEntityState moved)
    {
        ArgumentNullException.ThrowIfNull(moved);
        if (!roster.TryGetValue(moved.EntityKey, out var current) ||
            moved.OwnerPlayerId != current.OwnerPlayerId ||
            moved.SourceCardId != current.SourceCardId ||
            moved.UnitId != current.UnitId ||
            moved.Health != current.Health ||
            moved.PositionTick < current.PositionTick ||
            !float.IsFinite(moved.X) || !float.IsFinite(moved.Y) ||
            !float.IsFinite(moved.Z))
            throw new InvalidDataException("Card-unit pose lost its health or source proof.");
        roster[moved.EntityKey] = moved.Clone();
    }

    /// <summary>
    /// Called only after trusted host combat has established an impact.
    /// Card health comes from the recovered card upgrade rows, not the
    /// similarly named ordinary army option. Death grants no army energy.
    /// </summary>
    internal DamageResult? ApplyHostDamage(ulong entityKey, float damage)
    {
        if (!float.IsFinite(damage) || damage <= 0 || damage > 10_000_000)
            throw new ArgumentOutOfRangeException(nameof(damage));
        if (!roster.TryGetValue(entityKey, out var row))
            return null;
        if (!entities.TryGetValue(entityKey, out var entity) ||
            entity.EntityKey != row.EntityKey ||
            entity.SourceCardId != row.SourceCardId ||
            entity.UnitId != row.UnitId ||
            !float.IsFinite(row.Health) || row.Health <= 0 ||
            row.Health > row.MaxHealth ||
            row.MaxHealth != entity.BaseStats.Combat.Health)
            throw new InvalidDataException("Card-unit health lost its source entity proof.");

        if (damage >= row.Health)
        {
            if (!spawns.RemoveConfirmed(entity))
                throw new InvalidDataException("Card-unit death lost its reserved route.");
            entities.Remove(entityKey);
            roster.Remove(entityKey);
            BattleArmyEntityState dead = row.Clone();
            dead.Health = 0;
            return new DamageResult(dead, true);
        }

        float remainingHealth = row.Health - damage;
        if (!float.IsFinite(remainingHealth) || remainingHealth <= 0)
            throw new InvalidDataException("Card-unit damage produced invalid health.");
        row.Health = remainingHealth;
        return new DamageResult(row.Clone(), false);
    }
}
