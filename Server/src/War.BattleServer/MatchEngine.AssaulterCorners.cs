using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterCornerState(AssaulterCornerEntry Entry,
    ulong? FirstShotEligibleTick, ulong FirstPointChangeEligibleTick);

public sealed partial class MatchEngine
{
    private const int MinimumAssaulterCornerSeconds = 10;
    private const int AssaulterCornerSecondsRange = 10;
    private readonly Dictionary<ulong, AssaulterCornerState> _assaulterCorners = [];
    private readonly HashSet<ulong> _settledAssaulterCorners = [];

    /// <summary>Reads source arrival geometry and initial clocks without asserting a shot has fired.</summary>
    internal AssaulterCornerState? AssaulterCorner(ulong entityKey)
    {
        return _assaulterCorners.GetValueOrDefault(entityKey);
    }

    private void EnterAssaulterCorner(ulong entityKey, Vector3? walkingFacing)
    {
        var entity = activeArmyEntities[entityKey];
        CardUnitInitialPoint point = cardEnemyPoints?.Find(entityKey) ??
            throw new InvalidDataException("Arriving Assaulter lost its shared Corner reservation.");
        Vector3 facing = walkingFacing ?? infantryAnimations[entityKey].Facing;
        var pose = new AssaulterCornerPose(new Vector3(entity.X, entity.Y, entity.Z), facing);
        var entry = new AssaulterCornerEntry(point, pose, tick);
        // Diagnostic manifests may omit upgrade-lane combat authority. Do not
        // invent a shot clock from serialized placeholders for those entities.
        ulong? firstShot = armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot)
            ? FirstAssaulterShotTick(shot) : null;
        int changeSeconds = MinimumAssaulterCornerSeconds + armyChoice(AssaulterCornerSecondsRange);
        if (changeSeconds < MinimumAssaulterCornerSeconds ||
            changeSeconds >= MinimumAssaulterCornerSeconds + AssaulterCornerSecondsRange)
        {
            throw new InvalidDataException("Assaulter Corner change draw left its source integer range.");
        }

        ulong changeTick = checked(tick + (ulong)changeSeconds * MatchManifest.TickRate + 1);
        _assaulterCorners.Add(entityKey, new AssaulterCornerState(entry, firstShot, changeTick));
    }

    private ulong FirstAssaulterShotTick(ArmyBaseShotStats shot)
    {
        float fraction = NextArmyFloat();
        if (!float.IsFinite(fraction) || fraction is < 0f or >= 1f ||
            !float.IsFinite(shot.MinShootTime) || !float.IsFinite(shot.MaxShootTime) ||
            shot.MinShootTime < 0f || shot.MaxShootTime < shot.MinShootTime)
        {
            throw new InvalidDataException("Assaulter Corner shot clock lost its composed source authority.");
        }

        float seconds = shot.MinShootTime + (shot.MaxShootTime - shot.MinShootTime) * fraction;
        // CornerHidingUpdate tests mTime > mNextShootTime, including at exact tick boundaries.
        return checked(tick + (ulong)MathF.Floor(seconds * MatchManifest.TickRate) + 1);
    }

    private void AdvanceAssaulterCornerEntries()
    {
        foreach (var (entityKey, state) in _assaulterCorners.OrderBy(row => row.Key))
        {
            if (_settledAssaulterCorners.Contains(entityKey))
            {
                continue;
            }

            var entity = activeArmyEntities[entityKey];
            if (cardEnemyPoints?.Find(entityKey)?.ComponentFileId != state.Entry.PointFileId)
            {
                throw new InvalidDataException("Assaulter Corner entry lost its shared reservation.");
            }

            AssaulterCornerPose pose = state.Entry.Sample(tick);
            entity.X = pose.Position.X;
            entity.Y = pose.Position.Y;
            entity.Z = pose.Position.Z;
            entity.PositionTick = tick;
            infantryAnimations[entityKey].Facing = pose.Facing;
            if (tick >= state.Entry.EndTick)
            {
                _settledAssaulterCorners.Add(entityKey);
            }
        }
    }
}
