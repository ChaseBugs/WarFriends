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

public sealed class PlayerAimPose
{
    public PlayerCollisionModel Collision { get; }
    private readonly Dictionary<string,RifleMuzzlePose> muzzles;
    private readonly IReadOnlyDictionary<int,RifleMuzzlePose> bodyTargets;
    public RifleMuzzlePose? MovingTarget { get; }
    internal PlayerAimPose(PlayerCollisionModel collision,Dictionary<string,RifleMuzzlePose> muzzles,
        RifleMuzzlePose? movingTarget=null,IReadOnlyDictionary<int,RifleMuzzlePose>? bodyTargets=null)
    { Collision=collision; this.muzzles=muzzles; MovingTarget=movingTarget;
      this.bodyTargets=bodyTargets??new Dictionary<int,RifleMuzzlePose>(); }
    public RifleMuzzlePose Muzzle(string rifle) => muzzles.TryGetValue(rifle,out var value) ? value : throw new InvalidDataException("Unknown aimed rifle.");
    public RifleMuzzlePose BodyTarget(int transformFileId) => bodyTargets.TryGetValue(transformFileId,out var value) ?
        value : throw new InvalidDataException("Unknown posed Body target.");
    public PlayerAimPose Place(Vector3 position,Quaternion rotation) => new(Collision.Place(position,rotation),
        muzzles.ToDictionary(k=>k.Key,k=>k.Value.Place(position,rotation),StringComparer.Ordinal),
        MovingTarget?.Place(position,rotation),
        bodyTargets.ToDictionary(k=>k.Key,k=>k.Value.Place(position,rotation)));
}
