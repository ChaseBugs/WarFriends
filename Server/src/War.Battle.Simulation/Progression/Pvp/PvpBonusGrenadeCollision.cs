namespace War.BattleServer;

/// <summary>
/// Layers accepted by GrenadeAmmoBase.OnCollisionEnter in the recovered Client.
/// The grenade explodes after a Static or DestroyableObject contact; other
/// physics contacts do not arm its zero-second fuse.
/// </summary>
internal static class PvpBonusGrenadeCollision
{
    internal const uint ExplosiveContactMask =
        (1u << 8) | (1u << 13) | (1u << 22) | (1u << 23) |
        (1u << 24) | (1u << 26) | (1u << 27) | (1u << 30);

    internal static ShotCollision? ExplosiveContact(ShotCollision? hit)
    {
        if (hit == null) return null;
        if (hit.ColliderLayer is not int layer || layer is < 0 or > 31 ||
            (ExplosiveContactMask & (1u << layer)) == 0)
            return null;
        // TagsAndLayers checks the GameObject's layer, not whether a
        // DestroyableObject component was recovered on this host collider.
        return hit;
    }
}
