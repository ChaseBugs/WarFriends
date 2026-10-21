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
            moved.Kevlar != current.Kevlar ||
            moved.MaxKevlar != current.MaxKevlar ||
            moved.PositionTick < current.PositionTick ||
            !float.IsFinite(moved.X) || !float.IsFinite(moved.Y) ||
            !float.IsFinite(moved.Z))
            throw new InvalidDataException("Card-unit pose lost its health or source proof.");
        roster[moved.EntityKey] = moved.Clone();
    }

    internal BattleArmyEntityState? RefillKevlar(ulong entityKey, float maximum)
    {
        if (!float.IsFinite(maximum) || maximum <= 0 || maximum > 10_000_000)
            throw new ArgumentOutOfRangeException(nameof(maximum));
        if (!roster.TryGetValue(entityKey, out var row))
            return null;
        ValidateHealthAuthority(entityKey, row);
        row.MaxKevlar = maximum;
        row.Kevlar = maximum;
        return row.Clone();
    }

    /// <summary>Refills current health without changing source maximum health or kevlar.</summary>
    internal BattleArmyEntityState? RefillHealth(ulong entityKey, float health)
    {
        if (!roster.TryGetValue(entityKey, out var row))
        {
            return null;
        }

        ValidateHealthAuthority(entityKey, row);
        if (!float.IsFinite(health) || health <= 0f || health > row.MaxHealth)
        {
            throw new InvalidDataException("Card-unit refill requires valid current health within its maximum.");
        }

        row.Health = health;
        return row.Clone();
    }

    internal DamageResult? ConfirmDeath(ulong entityKey)
    {
        if (!roster.TryGetValue(entityKey, out var row))
            return null;
        ValidateHealthAuthority(entityKey, row);
        return RemoveConfirmed(entityKey, row);
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
        ValidateHealthAuthority(entityKey, row);

        float absorbed = Math.Min(damage, row.Kevlar);
        float remainingKevlar = row.Kevlar - absorbed;
        float remainingDamage = damage - absorbed;
        if (remainingDamage >= row.Health)
            return RemoveConfirmed(entityKey, row);

        row.Kevlar = remainingKevlar;
        row.Health -= remainingDamage;
        return new DamageResult(row.Clone(), false);
    }

    private void ValidateHealthAuthority(ulong entityKey, BattleArmyEntityState row)
    {
        if (!entities.TryGetValue(entityKey, out var entity) ||
            entity.EntityKey != row.EntityKey ||
            entity.SourceCardId != row.SourceCardId ||
            entity.UnitId != row.UnitId ||
            !float.IsFinite(row.Health) || row.Health <= 0 ||
            row.Health > row.MaxHealth ||
            !float.IsFinite(row.Kevlar) || row.Kevlar < 0 ||
            !float.IsFinite(row.MaxKevlar) || row.MaxKevlar < 0 ||
            row.Kevlar > row.MaxKevlar ||
            row.MaxHealth != entity.BaseStats.Combat.Health)
            throw new InvalidDataException("Card-unit health lost its source entity proof.");
    }

    private DamageResult RemoveConfirmed(ulong entityKey, BattleArmyEntityState row)
    {
        CardUnitEntity entity = entities[entityKey];
        if (!spawns.RemoveConfirmed(entity))
            throw new InvalidDataException("Card-unit death lost its reserved route.");
        entities.Remove(entityKey);
        roster.Remove(entityKey);
        BattleArmyEntityState dead = row.Clone();
        dead.Health = 0;
        dead.Kevlar = 0;
        return new DamageResult(dead, true);
    }
}
