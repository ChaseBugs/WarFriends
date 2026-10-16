using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly RifleBindingCatalog? _armyBulletBindings;

    private bool HasArmyCombatView => rifleCombat != null || grenadeCombat != null;

    private PlayerCollisionModel ArmyPlayerCollision(string playerId)
    {
        if (rifleCombat != null)
        {
            return rifleCombat.Pose(playerId).Collision;
        }

        return grenadeCombat?.Collision(playerId) ??
            throw new InvalidDataException("Army combat lacks current player collision authority.");
    }

    private Vector3 GrenadePlayerShotTarget(string playerId, int transformFileId)
    {
        if (grenadeCombat == null || playerShotTargets == null)
        {
            throw new InvalidDataException("Grenade army target authority is unavailable.");
        }

        int targetIndex = -1;
        for (int index = 0; index < playerShotTargets.Gameplay.Count; index++)
        {
            if (playerShotTargets.Gameplay[index].TransformFileId == transformFileId)
            {
                targetIndex = index;
                break;
            }
        }

        IReadOnlyList<Vector3> positions = grenadeCombat.PlayerShotTargets(playerId);
        if (targetIndex < 0 || positions.Count != playerShotTargets.Gameplay.Count)
        {
            throw new InvalidDataException("Grenade army target differs from the pinned player rig.");
        }

        return positions[targetIndex];
    }

    private Vector3 ArmyBodyShotTarget(string playerId, int transformFileId)
    {
        if (rifleCombat != null)
        {
            return rifleCombat.Pose(playerId).BodyTarget(transformFileId).Position;
        }

        return GrenadePlayerShotTarget(playerId, transformFileId);
    }

    private ShotCollision? TraceArmyVisibility(
        string ownerPlayerId, Vector3 origin, Vector3 direction, float range)
    {
        if (rifleCombat != null)
        {
            return rifleCombat.TraceForArmy(ownerPlayerId, origin, direction, range);
        }

        if (grenadeCombat == null || _armyBulletBindings == null)
        {
            throw new InvalidDataException("Army visibility lacks player collision authority.");
        }

        Player owner = Find(ownerPlayerId) ??
            throw new InvalidDataException("Army visibility owner disappeared.");
        uint mask = _armyBulletBindings.BulletMask(owner.Definition.Fraction);
        return grenadeCombat.TraceForArmy(ownerPlayerId, origin, direction, range, mask);
    }

    private ShotCollision? TraceArmyShot(
        string ownerPlayerId, Vector3 origin, Vector3 direction, float range)
    {
        if (rifleCombat != null)
        {
            return rifleCombat.TraceForArmyDamage(ownerPlayerId, origin, direction, range);
        }

        if (grenadeCombat == null || _armyBulletBindings == null)
        {
            throw new InvalidDataException("Army shot lacks player collision authority.");
        }

        Player owner = Find(ownerPlayerId) ??
            throw new InvalidDataException("Army shot owner disappeared.");
        uint mask = _armyBulletBindings.BulletMask(owner.Definition.Fraction);
        return grenadeCombat.Trace(ownerPlayerId, origin, direction, range, mask);
    }
}
