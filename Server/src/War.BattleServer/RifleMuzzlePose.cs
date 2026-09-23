using System.Numerics;

namespace War.BattleServer;

public sealed record RifleMuzzlePose(string SourcePath, Vector3 Position, Quaternion Rotation,
    Vector3 RootPosition, Quaternion RootRotation)
{
    // Rigid placement only; procedural upper-body aiming/blending is not implied.
    public RifleMuzzlePose Place(Vector3 rootPosition,Quaternion rootRotation)
    {
        if (!PlayerHitbox.Finite(rootPosition) || !float.IsFinite(rootRotation.LengthSquared()) ||
            Math.Abs(rootRotation.LengthSquared()-1)>.0001f) throw new InvalidDataException("Invalid muzzle placement.");
        var delta=Quaternion.Normalize(rootRotation)*Quaternion.Inverse(RootRotation);
        return this with { Position=rootPosition+Vector3.Transform(Position-RootPosition,delta),
            Rotation=Quaternion.Normalize(delta*Rotation), RootPosition=rootPosition, RootRotation=Quaternion.Normalize(rootRotation) };
    }
}
