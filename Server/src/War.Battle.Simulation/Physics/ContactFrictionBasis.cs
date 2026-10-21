using System.Numerics;
namespace War.BattleServer;

internal readonly record struct FrictionTangents(Vector3 First,Vector3 Second);
internal static class ContactFrictionBasis
{
    internal static FrictionTangents Prepare(Vector3 normal,Vector3 relativeLinearVelocity)
    {
        if(!PlayerHitbox.Finite(normal)||!PlayerHitbox.Finite(relativeLinearVelocity)||
           Math.Abs(normal.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid friction basis authority.");
        var tangent=relativeLinearVelocity-normal*Vector3.Dot(normal,relativeLinearVelocity);
        if(tangent.LengthSquared()<=.1f)
            tangent=Math.Abs(normal.X)<.70710678f?
                new Vector3(0,-normal.Z,normal.Y):new Vector3(-normal.Y,normal.X,0);
        tangent=Vector3.Normalize(tangent);
        return new(tangent,Vector3.Cross(normal,tangent));
    }
}
