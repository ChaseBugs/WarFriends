using System.Numerics;

namespace War.BattleServer;

/// <summary>Replaces the reference rifle muzzle on a sampled current rig with the selected pistol spawn.</summary>
internal static class GrenadierAcquisitionMuzzle
{
    private const float RotationTolerance = 0.0001f;

    internal static Vector3 Place(CoopMuzzlePose sampledReference, CoopAssaulterWeaponCatalog reference,
        GrenadierPrimaryWeapon pistol)
    {
        ArgumentNullException.ThrowIfNull(sampledReference);
        ArgumentNullException.ThrowIfNull(reference);
        ArgumentNullException.ThrowIfNull(pistol);
        float rotationLength = sampledReference.Rotation.LengthSquared();
        if (!PlayerHitbox.Finite(sampledReference.Position) || !float.IsFinite(rotationLength) ||
            MathF.Abs(rotationLength - 1f) > RotationTolerance)
        {
            throw new InvalidDataException("Grenadier acquisition lost its current rig pose.");
        }

        // Observations include the attached rifle's local muzzle rotation. Remove it
        // before transforming the pistol/rifle local-position difference at the shared snap.
        Quaternion attachment = Quaternion.Normalize(sampledReference.Rotation *
            Quaternion.Inverse(reference.MuzzleRestRotation));
        Vector3 result = sampledReference.Position +
            Vector3.Transform(pistol.LocalMuzzle - reference.MuzzleRestPosition, attachment);
        if (!PlayerHitbox.Finite(result))
        {
            throw new InvalidDataException("Grenadier acquisition muzzle left the finite world domain.");
        }

        return result;
    }
}
