using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

internal sealed record AssaulterShotTarget(string EntityId, string OwnerPlayerId,
    int TransformFileId, int ShotTargetType, Vector3 TransformPosition, bool IsPlayer)
{
    internal int? CapturedShieldCoverIndex { get; init; }
}

public sealed partial class MatchEngine
{
    private const int AssaulterBodyMask = 1;
    private const int AssaulterShieldMask = 2;
    private const int AssaulterWholeBodyMask = 9;
    private const int AssaulterMovingMask = 16;
    private const float AssaulterWalkingShieldMultiplier = 0.5f;

    /// <summary>Selects a current source transform; prediction and preparation are separate transitions.</summary>
    internal AssaulterShotTarget? SelectAssaulterShotTarget(ulong entityKey)
    {
        if (phase != BattlePhase.Running || !HasArmyCombatView || playerShotTargets == null || map == null)
        {
            return null;
        }

        AssaulterOpponentSelection selected = SelectAssaulterOpponent(entityKey);
        if (selected.Kind == AssaulterOpponentKind.PlayerFallback)
        {
            return SelectAssaulterPlayerTransform(activeArmyEntities[entityKey]);
        }

        if (selected.Kind == AssaulterOpponentKind.Unavailable)
        {
            return null;
        }

        DroneTargetCandidate candidate = selected.Candidate ??
            throw new InvalidDataException("Assaulter entity selection lost its source candidate.");
        return candidate.IsDecoy
            ? SelectAssaulterDecoyTransform(candidate) : SelectAssaulterInfantryTransform(candidate);
    }

    private AssaulterShotTarget? SelectAssaulterInfantryTransform(DroneTargetCandidate candidate)
    {
        return SelectStationaryInfantryTransform(candidate, targets =>
            AssaulterTargetPolicy.SelectShotTarget(targets, AssaulterTargetPolicy.AllInMask, armyChoice));
    }

    private AssaulterShotTarget? SelectStationaryInfantryTransform(DroneTargetCandidate candidate,
        Func<IReadOnlyList<DroneShotTarget>, DroneShotTarget?> selectTransform)
    {
        BattleArmyEntityState entity = activeArmyEntities.Values.SingleOrDefault(row =>
            DroneArmyId(row.EntityKey) == candidate.Id) ??
            throw new InvalidDataException("Selected Assaulter opponent lost its live army identity.");
        IReadOnlyList<DroneShotTarget>? targets = InfantryShotTargets(entity.EntityKey);
        if (targets == null)
        {
            // A selected vehicle/air target needs its own source transform graph.
            // Missing geometry is never permission to choose a different player.
            return null;
        }

        DroneShotTarget? target = selectTransform(targets);
        return target == null ? null : new AssaulterShotTarget(candidate.Id, entity.OwnerPlayerId,
            target.TransformFileId, target.Type, target.Position, false);
    }

    private AssaulterShotTarget SelectAssaulterDecoyTransform(DroneTargetCandidate candidate)
    {
        DecoyMatchEntity decoy = decoys.Snapshot().SingleOrDefault(row => DroneDecoyId(row.EntityId) == candidate.Id) ??
            throw new InvalidDataException("Selected Assaulter Decoy lost its live identity.");
        DecoyPrefabSource source = decoySource?.Prefab ??
            throw new InvalidDataException("Selected Assaulter Decoy lost its source target binding.");
        float yaw = MathF.Atan2(decoy.Facing.X, decoy.Facing.Z);
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
        Vector3 position = decoy.Position + Vector3.Transform(source.TargetLocalPosition, rotation);
        // DecoySourceCatalog validates the prefab's sole target as Body type 1.
        DroneShotTarget target = AssaulterTargetPolicy.SelectShotTarget(
            [new DroneShotTarget(source.TargetTransformFileId, AssaulterBodyMask, position)],
            AssaulterTargetPolicy.AllMask, armyChoice) ??
            throw new InvalidDataException("Source Decoy has no selectable target.");
        return new AssaulterShotTarget(candidate.Id, decoy.OwnerPlayerId,
            target.TransformFileId, target.Type, target.Position, false);
    }

    private AssaulterShotTarget? SelectAssaulterPlayerTransform(BattleArmyEntityState assaulter)
    {
        RecoveredBattleMap sourceMap = map ??
            throw new InvalidDataException("Assaulter player transform lost its source map.");
        Player[] opponents = players.Where(player => player.Admitted && !player.Dead &&
            player.Definition.Fraction != assaulter.OwnerFraction).ToArray();
        if (opponents.Length == 0)
        {
            return null;
        }

        int index = armyChoice(opponents.Length);
        if (index < 0 || index >= opponents.Length)
        {
            throw new InvalidDataException("Assaulter player draw left its source range.");
        }

        Player opponent = opponents[index];
        if (opponent.Cover < 0 || opponent.Cover >= sourceMap.Covers.Count)
        {
            return null;
        }

        Vector3 origin = new(assaulter.X, assaulter.Y, assaulter.Z);
        Vector3 forward = -Vector3.Transform(Vector3.UnitZ, sourceMap.Covers[opponent.Cover].Rotation);
        float shieldProbability = armyCatalog?.ShieldHitProbability(assaulter.UnitId) ??
            throw new InvalidDataException("Assaulter player transform lost its source shield probability.");
        if (shieldProbability < 0f)
        {
            return null;
        }

        if (opponent.Route != null)
        {
            shieldProbability *= AssaulterWalkingShieldMultiplier;
        }

        int mask = SoldierStationaryTargetMask(forward, origin - opponent.Position, shieldProbability, NextArmyFloat);
        return ResolveAssaulterPlayerTransform(opponent, origin, mask);
    }

    private AssaulterShotTarget? ResolveAssaulterPlayerTransform(Player opponent, Vector3 origin, int mask)
    {
        string playerId = opponent.Definition.PlayerId;
        PlayerAimPose pose = rifleCombat?.Pose(playerId) ?? GrenadePlayerCombatPose(playerId);
        Vector3? movingPosition = pose.MovingTarget?.Position;
        if (mask == AssaulterShieldMask)
        {
            // GetShotTargets(Shield) supplies the current cover shield even after
            // health loss. Preserve its source one-element random draw.
            if (armyChoice(1) != 0)
            {
                throw new InvalidDataException("Assaulter Shield draw left its source range.");
            }
        }
        else
        {
            mask = opponent.Route != null ? AssaulterMovingMask : AssaulterWholeBodyMask;
            if (mask == AssaulterMovingMask && movingPosition == null)
            {
                return null;
            }
        }

        Vector3 Position(PlayerShotTarget source)
        {
            if (source.Type == AssaulterShieldMask)
            {
                return ArmyShieldShotTarget(opponent);
            }

            return source.Type == AssaulterMovingMask
                ? movingPosition ?? throw new InvalidDataException("Assaulter moving target has no current pose.")
                : pose.BodyTargetPosition(source.TransformFileId);
        }

        PlayerShotTargetCatalog targets = playerShotTargets ??
            throw new InvalidDataException("Assaulter player transform lost its source target list.");
        PlayerShotTarget target = targets.Nearest(mask, origin, Position);
        return new AssaulterShotTarget(DronePlayerId(playerId), playerId,
            target.TransformFileId, target.Type, Position(target), true)
        {
            CapturedShieldCoverIndex = mask == AssaulterShieldMask ? opponent.Cover : null
        };
    }
}
