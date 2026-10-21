using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Target chosen by SoldierBehaviourParachuter.PickTarget while airborne.
/// Selection and the 16-unit distance gate happen before the Client's
/// separate CanSeeTarget ray and weapon animation.
/// </summary>
internal sealed record CardParatrooperAirTarget(
    int TransformFileId, Vector3 Position, float Distance, bool WithinRange,
    bool HasClearSight = false)
{
    internal const float MaximumRange = 16f;

    internal static CardParatrooperAirTarget Select(
        PlayerShotTargetCatalog targets, PlayerAimPose pose,
        Vector3 parachutePosition)
    {
        ArgumentNullException.ThrowIfNull(targets);
        ArgumentNullException.ThrowIfNull(pose);
        if (!PlayerHitbox.Finite(parachutePosition))
            throw new InvalidDataException("Invalid airborne Paratrooper position.");

        PlayerShotTarget shield = targets.Nearest(2, parachutePosition,
            candidate => pose.BodyTargetPosition(candidate.TransformFileId));
        Vector3 targetPosition = pose.BodyTargetPosition(shield.TransformFileId);
        float distance = Vector3.Distance(parachutePosition, targetPosition);
        if (shield.Type != 2 || !float.IsFinite(distance))
            throw new InvalidDataException("Invalid posed Paratrooper shield target.");

        return new CardParatrooperAirTarget(shield.TransformFileId,
            targetPosition, distance, distance <= MaximumRange);
    }

    internal static HelicopterSightRay SightRay(Vector3 soldierPosition,
        float weaponMuzzleHeight, Vector3 targetPosition)
    {
        if (!PlayerHitbox.Finite(soldierPosition) ||
            !float.IsFinite(weaponMuzzleHeight) ||
            !PlayerHitbox.Finite(targetPosition))
            throw new InvalidDataException("Invalid airborne Paratrooper sight endpoints.");

        // EnemyController.PrepareToShoot starts at root + 0.2 Y, then uses
        // the current weapon spawn point's Y when one is present. Its
        // AIObject.CanSeeTarget overload moves 0.18 along the ray and stops
        // half a unit before the selected Shield target.
        Vector3 start = soldierPosition + Vector3.UnitY * 0.2f;
        start.Y = weaponMuzzleHeight;
        Vector3 delta = targetPosition - start;
        float distance = delta.Length();
        if (!float.IsFinite(distance))
            throw new InvalidDataException("Airborne Paratrooper sight distance overflow.");
        Vector3 direction = distance > 0f ? delta / distance : Vector3.Zero;
        Vector3 origin = start + direction * 0.18f;
        float range = MathF.Max(0.1f,
            Vector3.Distance(origin, targetPosition) - 0.5f);
        if (!PlayerHitbox.Finite(origin) || !float.IsFinite(range))
            throw new InvalidDataException("Airborne Paratrooper sight ray overflow.");
        return new HelicopterSightRay(origin, direction, range,
            HelicopterTurretSightRay.SourceLayerMask);
    }
}
