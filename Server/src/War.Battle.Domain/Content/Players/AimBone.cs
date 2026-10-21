using System.Collections.ObjectModel;
using System.Numerics;

namespace War.BattleServer;

internal sealed record AimBone(string Path,Vector3 Position,Quaternion Rotation,Quaternion ParentRotation)
{
    internal (Vector3 Position,Quaternion Rotation) Apply(string path,Vector3 position,Quaternion rotation,Quaternion localOverride)
    {
        if (path!=Path && !path.StartsWith(Path+"/",StringComparison.Ordinal)) return (position,rotation);
        var delta=Quaternion.Normalize(ParentRotation*localOverride*Quaternion.Inverse(Rotation));
        return (Position+Vector3.Transform(position-Position,delta),Quaternion.Normalize(delta*rotation));
    }
}
