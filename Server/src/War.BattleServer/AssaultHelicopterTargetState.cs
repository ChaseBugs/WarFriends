using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Recovered AssaultHelicopter.PickTarget runs when its shot clock expires.
/// Target selection is separate from firing so movement can face the selected root.
/// </summary>
internal sealed class AssaultHelicopterTargetState
{
    private float nextSelectionTime;
    private ulong? targetDecoyId;
    private string? targetPlayerId;

    internal float NextSelectionTime => nextSelectionTime;
    internal ulong? TargetDecoyId => targetDecoyId;
    internal string? TargetPlayerId => targetPlayerId;

    internal AssaultHelicopterTargetState(float spawnTime)
    {
        if (!float.IsFinite(spawnTime) || spawnTime < 0)
            throw new InvalidDataException("Invalid Assault Helicopter spawn time.");
        // OnInstancied sets mNextShotTime = Time.time + 2.
        nextSelectionTime = spawnTime + 2f;
    }

    internal void Advance(float time, ArmyVehicleShotStats shot,
        IReadOnlyList<DecoyMatchEntity> opposingDecoys, string opposingPlayerId,
        Func<int, int> chooseIndex, Func<float> nextRandom,
        Action? onTargetSelected = null)
    {
        if (!float.IsFinite(time) || time < 0 || opposingDecoys == null ||
            !Guid.TryParseExact(opposingPlayerId, "N", out _) ||
            chooseIndex == null || nextRandom == null ||
            !float.IsFinite(shot.MinShootTime) || !float.IsFinite(shot.MaxShootTime) ||
            shot.MinShootTime <= 0 || shot.MaxShootTime < shot.MinShootTime)
            throw new InvalidDataException("Invalid Assault Helicopter target clock authority.");
        if (time <= nextSelectionTime) return;

        if (opposingDecoys.Count > 0)
        {
            int index = chooseIndex(opposingDecoys.Count);
            if (index < 0 || index >= opposingDecoys.Count)
                throw new InvalidDataException("Assault Helicopter selected an invalid Decoy.");
            targetDecoyId = opposingDecoys[index].EntityId;
            targetPlayerId = null;
        }
        else
        {
            targetDecoyId = null;
            targetPlayerId = opposingPlayerId;
        }

        // StartShooting prepares the first gun before Movement samples the
        // next cooldown. The caller can retain that exact random-call order.
        onTargetSelected?.Invoke();
        float sample = nextRandom();
        if (!float.IsFinite(sample) || sample < 0 || sample > 1)
            throw new InvalidDataException("Invalid Assault Helicopter shot interval sample.");
        nextSelectionTime += shot.MinShootTime +
            (shot.MaxShootTime - shot.MinShootTime) * sample;
        if (!float.IsFinite(nextSelectionTime))
            throw new InvalidDataException("Assault Helicopter shot clock overflowed.");
    }

    internal Vector3? LookTarget(IReadOnlyList<DecoyMatchEntity> decoys,
        string opposingPlayerId, Vector3 opposingPlayerPosition)
    {
        if (targetDecoyId is ulong decoyId)
            return decoys.SingleOrDefault(decoy => decoy.EntityId == decoyId)?.Position;
        if (targetPlayerId == opposingPlayerId)
            return opposingPlayerPosition;
        return null;
    }
}
