using System.Numerics;

namespace War.BattleServer;

/// <summary>Combines grenade collision and positions with separately observed rig transforms when available.</summary>
internal static class GrenadeCombatPoseProjection
{
    internal static PlayerAimPose Create(GrenadePoseFrame frame, IReadOnlyList<Vector3> positions,
        PlayerShotTargetCatalog identities, PlayerAimPoseDetails? details = null)
    {
        if (positions.Count != identities.Gameplay.Count)
        {
            throw new InvalidDataException("Grenade player targets do not match the recovered rig identities.");
        }

        var targets = identities.Gameplay.Select((target, index) =>
            new KeyValuePair<int, Vector3>(target.TransformFileId, positions[index])).ToDictionary();
        return new PlayerAimPose(frame.Collision,
            frame.Right.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
            details,
            targetPositions: targets);
    }
}
