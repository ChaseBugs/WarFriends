using System.Numerics;

namespace War.BattleServer;

internal sealed record RigLocalTransform(Vector3 Position,Quaternion Rotation,Vector3 Scale);
internal sealed record RigWorldTransform(Vector3 Position,Quaternion Rotation,Matrix4x4 Matrix);

internal static class RigLocalPose
{
    internal static RigLocalTransform[] BlendWeighted(IReadOnlyList<RigLocalTransform[]> layers,IReadOnlyList<float> weights)
    {
        if (layers.Count is < 1 or > 4 || weights.Count!=layers.Count || weights.Any(w=>!float.IsFinite(w)||w<0||w>1) ||
            Math.Abs(weights.Sum()-1)>.00001f || layers[0].Length is < 1 or > 1024 || layers.Any(l=>l.Length!=layers[0].Length))
            throw new InvalidDataException("Invalid weighted rig layers.");
        var result=new RigLocalTransform[layers[0].Length];
        for (int node=0;node<result.Length;node++)
        {
            Vector3 position=Vector3.Zero,scale=Vector3.Zero;Quaternion rotation=new(0,0,0,0);
            Quaternion? hemisphere=null;
            for (int layer=0;layer<layers.Count;layer++)
            {
                var value=layers[layer][node];Validate(value);float weight=weights[layer];
                if (weight==0) continue;
                hemisphere ??= value.Rotation;
                position+=value.Position*weight;scale+=value.Scale*weight;
                rotation+=value.Rotation*(Quaternion.Dot(hemisphere.Value,value.Rotation)<0 ? -weight : weight);
            }
            result[node]=new(position,Quaternion.Normalize(rotation),scale);
        }
        return result;
    }
    internal static RigLocalTransform[] Blend(IReadOnlyList<RigLocalTransform> a,IReadOnlyList<RigLocalTransform> b,float weight)
    {
        if (!float.IsFinite(weight)||weight is < 0 or > 1 || a.Count!=b.Count || a.Count is < 1 or > 1024)
            throw new InvalidDataException("Invalid rig blend.");
        var result=new RigLocalTransform[a.Count];
        for (int i=0;i<result.Length;i++)
        {
            Validate(a[i]); Validate(b[i]);
            result[i]=new(Vector3.Lerp(a[i].Position,b[i].Position,weight),
                Quaternion.Normalize(Quaternion.Lerp(a[i].Rotation,b[i].Rotation,weight)),Vector3.Lerp(a[i].Scale,b[i].Scale,weight));
        }
        return result;
    }
    internal static RigWorldTransform[] Compose(IReadOnlyList<int> parents,IReadOnlyList<RigLocalTransform> local)
    {
        if (local.Count is < 1 or > 1024 || parents.Count!=local.Count) throw new InvalidDataException("Invalid rig hierarchy.");
        var result=new RigWorldTransform[local.Count];
        for (int i=0;i<local.Count;i++)
        {
            int parent=parents[i]; var pose=local[i]; Validate(pose);
            if ((i==0 && parent!=-1) || (i>0 && (parent<0 || parent>=i))) throw new InvalidDataException("Invalid rig parent order.");
            var matrix=Matrix4x4.CreateScale(pose.Scale)*Matrix4x4.CreateFromQuaternion(pose.Rotation)*Matrix4x4.CreateTranslation(pose.Position);
            var rotation=pose.Rotation;
            if (parent>=0) { matrix*=result[parent].Matrix; rotation=Quaternion.Normalize(result[parent].Rotation*rotation); }
            var position=Vector3.Transform(Vector3.Zero,matrix);
            if (!PlayerHitbox.Finite(position)) throw new InvalidDataException("Rig world position exceeds bound.");
            result[i]=new(position,rotation,matrix);
        }
        return result;
    }
    private static void Validate(RigLocalTransform pose)
    {
        if (pose==null || !PlayerHitbox.Finite(pose.Position) || !PlayerHitbox.Finite(pose.Scale) ||
            pose.Scale.X<=0 || pose.Scale.Y<=0 || pose.Scale.Z<=0 ||
            !float.IsFinite(pose.Rotation.LengthSquared()) || Math.Abs(pose.Rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid local rig transform.");
    }
}
