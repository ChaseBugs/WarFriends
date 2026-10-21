using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Host-owned vertical motion until the crate first touches source-static
/// geometry. The source prefab uses gravity -9.81 and a 0.4834973-unit cube.
/// This does not reproduce PhysX bounce, rotation or dynamic-object contacts.
/// </summary>
internal static class PvpBonusFallMotion
{
    private const float Gravity = 9.81f;
    private const float HalfBoxHeight = 0.4834973f / 2f;

    internal static PvpBonusBoxSnapshot Advance(PvpBonusBoxSnapshot box,
        float elapsedSeconds)
    {
        ArgumentNullException.ThrowIfNull(box);
        if (!float.IsFinite(elapsedSeconds) || elapsedSeconds < 0)
            throw new ArgumentOutOfRangeException(nameof(elapsedSeconds));
        if (box.Phase != PvpBonusBoxPhase.Falling || elapsedSeconds == 0)
            return box;

        float nextVelocity = box.VerticalVelocity - Gravity * elapsedSeconds;
        float nextY = box.Position.Y +
            (box.VerticalVelocity + nextVelocity) * 0.5f * elapsedSeconds;
        if (!float.IsFinite(nextVelocity) || !float.IsFinite(nextY))
            throw new InvalidDataException("Bonus box fall exceeded finite world coordinates.");

        float? surfaceY = box.Plan.StaticSurfaceCandidate?.Position.Y;
        if (surfaceY.HasValue && nextY <= surfaceY.Value + HalfBoxHeight)
        {
            var groundedPosition = box.Position with
            {
                Y = surfaceY.Value + HalfBoxHeight
            };
            return box with
            {
                Position = groundedPosition,
                VerticalVelocity = 0,
                Phase = PvpBonusBoxPhase.Grounded
            };
        }

        return box with
        {
            Position = box.Position with {Y = nextY},
            VerticalVelocity = nextVelocity
        };
    }
}
