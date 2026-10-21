using System.Numerics;

namespace War.BattleServer;

/// <summary>Combines a trusted pre-Update root with the recovered tween's complete frame writes.</summary>
internal static class CoopShotRootComposition
{
    private const float UnitRotationTolerance = 0.0002f;

    internal static Quaternion AfterFrame(CoopShotRootTween tween, Quaternion rootBeforeUpdate,
        float scaledDeltaSeconds)
    {
        ArgumentNullException.ThrowIfNull(tween);
        float lengthSquared = rootBeforeUpdate.LengthSquared();
        if (!float.IsFinite(lengthSquared) || Math.Abs(lengthSquared - 1f) > UnitRotationTolerance)
        {
            throw new InvalidDataException("Root composition requires a unit pre-Update rotation.");
        }

        bool writesThisFrame = tween.IsRunning;
        tween.AdvanceFrame(scaledDeltaSeconds);
        // The completion frame still writes the target, even though it disables the component afterwards.
        if (writesThisFrame)
        {
            return tween.Rotation;
        }

        // Once disabled, the tween must not hide a later navigation or other trusted root write.
        return Quaternion.Normalize(rootBeforeUpdate);
    }
}
