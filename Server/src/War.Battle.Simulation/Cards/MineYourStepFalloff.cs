namespace War.BattleServer;

/// <summary>
/// The distinct damage branch used by MineAmmo's Explosion.MissileExplode.
/// The caller determines collision distance from trusted host geometry.
/// </summary>
internal static class MineYourStepFalloff
{
    internal static float Damage(float outerDamage, float explosionDamage,
        float deadRadius, float hurtRadius, float rootDistance, float colliderDistance,
        float radiusCoefficient = 1f)
    {
        if (!float.IsFinite(outerDamage) || !float.IsFinite(explosionDamage) ||
            !float.IsFinite(deadRadius) || !float.IsFinite(hurtRadius) ||
            !float.IsFinite(rootDistance) || !float.IsFinite(colliderDistance) ||
            !float.IsFinite(radiusCoefficient) || outerDamage <= 0 ||
            explosionDamage < outerDamage || explosionDamage > 10_000_000 ||
            deadRadius <= 0 || hurtRadius <= deadRadius || rootDistance < 0 ||
            colliderDistance < 0 || radiusCoefficient <= 0 || radiusCoefficient > 1)
            throw new InvalidDataException("Mine Your Step falloff needs valid host geometry and damage.");

        if (colliderDistance < deadRadius * radiusCoefficient)
            return explosionDamage;
        if (colliderDistance > hurtRadius * radiusCoefficient)
            return 0;

        float ratio = Math.Clamp(1f - (rootDistance - deadRadius) /
            (hurtRadius - deadRadius), 0f, 1f);
        return outerDamage + (explosionDamage - outerDamage) * ratio * ratio;
    }
}
