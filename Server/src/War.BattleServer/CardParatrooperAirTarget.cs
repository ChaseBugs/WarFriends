using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Target chosen by SoldierBehaviourParachuter.PickTarget while airborne.
/// Selection and the 16-unit distance gate happen before the Client's
/// separate CanSeeTarget ray and weapon animation.
/// </summary>
internal sealed record CardParatrooperAirTarget(
    int TransformFileId, Vector3 Position, float Distance, bool WithinRange)
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
            candidate => pose.BodyTarget(candidate.TransformFileId).Position);
        Vector3 targetPosition = pose.BodyTarget(shield.TransformFileId).Position;
        float distance = Vector3.Distance(parachutePosition, targetPosition);
        if (shield.Type != 2 || !float.IsFinite(distance))
            throw new InvalidDataException("Invalid posed Paratrooper shield target.");

        return new CardParatrooperAirTarget(shield.TransformFileId,
            targetPosition, distance, distance <= MaximumRange);
    }
}
