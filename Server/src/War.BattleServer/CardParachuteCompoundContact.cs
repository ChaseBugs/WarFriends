using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Queries the two BoxColliders on the recovered parachute Rigidbody against
/// the recovered scene map. This is a geometric contact candidate, not Unity's
/// OnCollisionEnter: PhysX may resolve a contact on a different fixed step.
/// </summary>
internal static class CardParachuteCompoundContact
{
    // Layer 15 (CollideOnlyEnviroment) in the recovered DynamicsManager.
    private const uint SceneCollisionMask = 0x20c9u;
    private static readonly Vector3 ChildPosition =
        new(-0.00023651123f, 0f, -0.0002412796f);

    internal static bool HasNearbySceneSurface(RecoveredBattleMap map,
        Vector3 rootPosition, Quaternion rootRotation, float margin,
        Func<string, bool>? dynamicEnabled = null,
        Func<int, bool>? colliderEnabled = null,
        Func<int, int, int>? runtimeLayer = null)
    {
        if (map == null || !PlayerHitbox.Finite(rootPosition) ||
            !float.IsFinite(margin) || margin < 0f || margin > 0.02f ||
            !ValidRotation(rootRotation))
            throw new InvalidDataException("Invalid parachute contact pose.");

        return BoxTouchesScene(map, rootPosition, rootRotation,
                   new Vector3(0.0025825514f, 0.2140131f, -0.009037019f),
                   new Vector3(0.23838009f, 0.37729108f, 0.1947221f),
                   Quaternion.Normalize(new Quaternion(0f, 0.015279869f,
                       0f, 0.9998833f)), margin, dynamicEnabled,
                   colliderEnabled, runtimeLayer) ||
               BoxTouchesScene(map, rootPosition, rootRotation,
                   new Vector3(0f, 0.9668381f, 0.03979206f),
                   new Vector3(1f, 0.43308878f, 1.9321573f),
                   Quaternion.Normalize(new Quaternion(0f, -0.69621986f,
                       0f, 0.71782863f)), margin, dynamicEnabled,
                   colliderEnabled, runtimeLayer);
    }

    private static bool BoxTouchesScene(RecoveredBattleMap map,
        Vector3 rootPosition, Quaternion rootRotation, Vector3 colliderCenter,
        Vector3 colliderSize, Quaternion childRotation, float margin,
        Func<string, bool>? dynamicEnabled,
        Func<int, bool>? colliderEnabled,
        Func<int, int, int>? runtimeLayer)
    {
        Vector3 localCenter = ChildPosition +
            Vector3.Transform(colliderCenter, childRotation);
        Vector3 worldCenter = rootPosition +
            Vector3.Transform(localCenter, rootRotation);
        Quaternion worldRotation = Quaternion.Normalize(
            rootRotation * childRotation);
        Vector3 querySize = colliderSize + new Vector3(2f * margin);

        return map.BoxOverlaps(worldCenter, querySize, worldRotation,
            SceneCollisionMask, dynamicEnabled, colliderEnabled, runtimeLayer);
    }

    private static bool ValidRotation(Quaternion rotation)
    {
        float lengthSquared = rotation.LengthSquared();
        return float.IsFinite(lengthSquared) &&
            Math.Abs(lengthSquared - 1f) <= 0.0001f;
    }
}
