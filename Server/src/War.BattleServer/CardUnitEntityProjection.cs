using War.Protocol;
using War.Shared;

namespace War.BattleServer;

/// <summary>Builds the public roster row for one host-owned card unit.</summary>
internal static class CardUnitEntityProjection
{
    internal static BattleArmyEntityState Create(CardUnitEntity entity, int ownerFraction)
    {
        ArgumentNullException.ThrowIfNull(entity);

        if (ownerFraction is not (1 or 2) ||
            !Guid.TryParseExact(entity.OwnerPlayerId, "N", out var ownerId) ||
            ownerId.ToString("N") != entity.OwnerPlayerId ||
            !CardUnitSourceIdentity.Matches(entity.SourceCardId, entity.UnitId) ||
            entity.LocalEntityId < CardUnitEntityRegistry.FirstLocalEntityId ||
            entity.EntityKey != ((ulong)ownerFraction << 32 | (uint)entity.LocalEntityId) ||
            entity.SpawnComponentFileId <= 0 || entity.ReservationFileId < 0 ||
            !float.IsFinite(entity.Position.X) ||
            !float.IsFinite(entity.Position.Y) ||
            !float.IsFinite(entity.Position.Z) ||
            !float.IsFinite(entity.BaseStats.Combat.Health) ||
            entity.BaseStats.Combat.Health <= 0)
            throw new InvalidDataException("Invalid card-unit roster authority.");

        float health = entity.BaseStats.Combat.Health;
        return new BattleArmyEntityState
        {
            EntityKey = entity.EntityKey,
            OwnerPlayerId = entity.OwnerPlayerId,
            OwnerFraction = ownerFraction,
            LocalEntityId = entity.LocalEntityId,
            OptionIndex = -1,
            SourceCardId = entity.SourceCardId,
            UnitId = entity.UnitId,
            SpawnComponentFileId = entity.SpawnComponentFileId,
            ReservationFileId = entity.ReservationFileId,
            X = entity.Position.X,
            Y = entity.Position.Y,
            Z = entity.Position.Z,
            SpawnTick = entity.SpawnTick,
            PositionTick = entity.SpawnTick,
            MaxHealth = health,
            Health = health,
            DroneRotation = entity.UnitId == "ID_UNIT-DRONE"
                ? new BattleJointRotation { W = 1 }
                : null
        };
    }
}
