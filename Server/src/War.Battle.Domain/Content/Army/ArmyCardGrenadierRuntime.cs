using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyCardGrenadierRuntime(float FuseSeconds,
    float ThrowAngleDegrees, float ThrowDistance, float InnerRadius,
    float OuterRadius, float PlayerBehindShieldRatio,
    float SecondaryWeaponProbability)
{
    /// <summary>
    /// Gun.Fire passes the secondary weapon's spawn point to GrenadeAmmoBase.
    /// A zero throw distance means the recovered weapon does not cap range.
    /// The launch pose must come from the soldier rig, not the entity center.
    /// </summary>
    public Vector3 LaunchVelocity(Vector3 muzzlePosition, Vector3 targetPosition)
    {
        if (!float.IsFinite(ThrowDistance) || ThrowDistance < 0f ||
            !float.IsFinite(ThrowAngleDegrees) || ThrowAngleDegrees <= 0f ||
            ThrowAngleDegrees >= 90f || !PlayerHitbox.Finite(muzzlePosition) ||
            !PlayerHitbox.Finite(targetPosition))
            throw new InvalidDataException("Grenadier launch authority is invalid.");

        Vector3 offset = targetPosition - muzzlePosition;
        if (ThrowDistance > 0f && offset.Length() > ThrowDistance)
            targetPosition = muzzlePosition + Vector3.Normalize(offset) * ThrowDistance;

        return GrenadeBallistics.CalculateVelocity(muzzlePosition,
            targetPosition, ThrowAngleDegrees);
    }

    /// <summary>
    /// SoldierBehaviourGrennader.PickTarget chooses the grenade before
    /// selecting a Decoy or player. Card soldiers have both source weapons.
    /// The host supplies the random roll and owns the resulting weapon.
    /// </summary>
    public bool ShouldThrowGrenade(float roll, bool usingExternalWeapon)
    {
        if (!float.IsFinite(roll) || roll < 0f || roll >= 1f ||
            !float.IsFinite(SecondaryWeaponProbability) ||
            SecondaryWeaponProbability is < 0f or > 1f)
            throw new InvalidDataException("Grenadier weapon roll is invalid.");
        return !usingExternalWeapon && roll < SecondaryWeaponProbability;
    }
}
