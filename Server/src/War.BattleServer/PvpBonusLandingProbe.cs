using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Finds the first source-static surface below a bonus spawn position.
/// This is a geometry probe, not a Rigidbody contact or a grounded box.
/// The source KillStreakBonusBox marks onGround only after a collision with
/// TagsAndLayers.staticlayerNum (13) or t4mObj (30).
/// </summary>
internal static class PvpBonusLandingProbe
{
    private const uint StaticLayerMask = (1u << 13) | (1u << 30);
    private const float MaximumProbeDistance = 1000f;

    internal static MapHit? FindStaticSurface(RecoveredBattleMap map,
        Vector3 spawnPosition)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (!float.IsFinite(spawnPosition.X) ||
            !float.IsFinite(spawnPosition.Y) ||
            !float.IsFinite(spawnPosition.Z))
            throw new ArgumentOutOfRangeException(nameof(spawnPosition));

        return map.Raycast(spawnPosition, -Vector3.UnitY,
            MaximumProbeDistance, StaticLayerMask);
    }
}
