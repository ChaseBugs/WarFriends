using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly RifleBindingCatalog? _armyBulletBindings;

    private bool HasArmyCombatView => rifleCombat != null || grenadeCombat != null;

    internal PlayerCollisionModel ArmyPlayerCollision(string playerId)
    {
        if (rifleCombat != null)
        {
            return rifleCombat.Pose(playerId).Collision;
        }

        return GrenadePlayerCombatPose(playerId).Collision;
    }

    private Vector3 GrenadePlayerShotTarget(string playerId, int transformFileId)
    {
        return GrenadePlayerCombatPose(playerId).BodyTargetPosition(transformFileId);
    }

    private PlayerAimPose GrenadePlayerCombatPose(string playerId)
    {
        if (grenadeCombat == null || playerShotTargets == null)
        {
            throw new InvalidDataException("Grenade army player pose authority is unavailable.");
        }

        return grenadeCombat.CombatPose(playerId, playerShotTargets);
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
