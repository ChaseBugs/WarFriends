using System.Numerics;

namespace War.BattleServer;

/// <summary>Exposes verified grenade collision and target positions without inventing target rotations.</summary>
internal static class GrenadeCombatPoseProjection
{
    internal static PlayerAimPose Create(GrenadePoseFrame frame, IReadOnlyList<Vector3> positions,
        PlayerShotTargetCatalog identities)
    {
        if (positions.Count != identities.Gameplay.Count)
        {
            throw new InvalidDataException("Grenade player targets do not match the recovered rig identities.");
        }

        var targets = identities.Gameplay.Select((target, index) =>
            new KeyValuePair<int, Vector3>(target.TransformFileId, positions[index])).ToDictionary();
        // These exports prove target positions, not rotations, weapon roots or a moving-target transform.
        return new PlayerAimPose(frame.Collision,
            frame.Right.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
            targetPositions: targets);
    }
}
