using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal static class RiflePoseProjection
{
    // Stable protocol order; do not derive IDs from catalog or enum iteration.
    private static readonly string[] Names=["idle","player_look_left3","player_fire_left3",
        "player_left_coverBack3","player_look_right3","player_fire_right3","player_right_coverBack3",
        "player_look_left_qbz","player_fire_left_qbz","player_left_coverBack_qbz",
        "player_look_right_qbz","player_fire_right_qbz","player_right_coverBack_qbz",
        "player_look_left_qbz2","player_fire_left_qbz2","player_left_coverBack_qbz2",
        "player_look_right_qbz2","player_fire_right_qbz2","player_right_coverBack_qbz2",
        "player_look_left_shotgun","player_fire_left_shotgun","player_left_coverBack_shotgun",
        "player_look_right_shotgun","player_fire_right_shotgun","player_right_coverBack_shotgun",
        "run","qbz_run","qbz2_run","shotgunner_run","shootAdditive",
        "player_look_left_pistol","player_fire_left_pistol","player_left_coverBack_pistol",
        "player_look_right_pistol","player_fire_right_pistol","player_right_coverBack_pistol","pistol_run",
        "player_look_left_minigun","player_fire_left_minigun","player_left_coverBack_minigun",
        "player_look_right_minigun","player_fire_right_minigun","player_right_coverBack_minigun",
        "minigun_run","minigun_idle",
        "player_look_left_sniper","player_fire_left_sniper","player_left_coverBack_sniper",
        "player_look_right_sniper","player_fire_right_sniper","player_right_coverBack_sniper",
        "sniper_run","sniper_idle",
        "bazooka_uncover_left","bazooka_shoot_left","bazooka_uncover_right","bazooka_shoot_right",
        "bazooka_run","bazooka_idle",
        "throw_grenade_left","throw_grenade_right","grenade_run","grenade_idle",
        "player_look_left_grenadelauncher","player_fire_left_grenadelauncher","player_left_coverBack_grenadelauncher",
        "player_look_right_grenadelauncher","player_fire_right_grenadelauncher","player_right_coverBack_grenadelauncher",
        "run_grenadelauncher","grenadelauncher_idle"];
    internal static bool ValidWire(RiflePoseState pose,ulong serverTick)
    {
        if(pose.SampledTick>serverTick || pose.Layers.Count is <1 or >4 ||
           !ValidRotation(pose.RootRotation) || !ValidRotation(pose.BodyLocalRotation) ||
           pose.UpperLocalRotation!=null && !ValidRotation(pose.UpperLocalRotation))return false;
        double total=0;
        foreach(var layer in pose.Layers)
        {
            if((int)layer.Clip<1 || (int)layer.Clip>Names.Length || !double.IsFinite(layer.Seconds) ||
               layer.Seconds is <0 or >86400 || !float.IsFinite(layer.Weight) ||
               layer.Weight is <0 or >1)return false;
            total+=layer.Weight;
        }
        if(Math.Abs(total-1)>.0001)return false;
        return pose.UpperBodyLayer==null ||
            float.IsFinite(pose.UpperBodyLayer.Seconds) &&
            pose.UpperBodyLayer.Seconds is >=0 and <=86400 &&
            float.IsFinite(pose.UpperBodyLayer.Weight) &&
            pose.UpperBodyLayer.Weight is >=0 and <=1;
    }

    private static bool ValidRotation(PoseRotation? r)
    {
        if(r==null || !float.IsFinite(r.X) || !float.IsFinite(r.Y) ||
           !float.IsFinite(r.Z) || !float.IsFinite(r.W))return false;
        double length=(double)r.X*r.X+(double)r.Y*r.Y+(double)r.Z*r.Z+(double)r.W*r.W;
        return Math.Abs(length-1)<=.0001;
    }
    internal static RiflePoseState Create(ulong tick,IReadOnlyList<RifleClipLayer> layers,
        Quaternion root,Quaternion body,Quaternion? upper,RifleClipLayer? upperBodyLayer=null)
    {
        if(layers.Count is <1 or >4)throw new InvalidDataException("Invalid wire pose layer count.");
        var result=new RiflePoseState {SampledTick=tick,RootRotation=Rotation(root),BodyLocalRotation=Rotation(body)};
        if(upper.HasValue)result.UpperLocalRotation=Rotation(upper.Value);
        foreach(var layer in layers)
        {
            int index=Array.IndexOf(Names,layer.Clip.Name);
            if(index<0 || !double.IsFinite(layer.Clip.Seconds) || layer.Clip.Seconds<0 || layer.Clip.Seconds>86400 ||
                !float.IsFinite(layer.Weight) || layer.Weight is <0 or >1)
                throw new InvalidDataException("Invalid wire pose layer.");
            result.Layers.Add(new RiflePoseLayer {Clip=(RiflePoseClip)(index+1),Seconds=layer.Clip.Seconds,Weight=layer.Weight,Loop=layer.Clip.Loop});
        }
        if(Math.Abs(layers.Sum(l=>l.Weight)-1)>.0001f)throw new InvalidDataException("Unnormalized wire pose.");
        if(upperBodyLayer!=null)
        {
            var clip=upperBodyLayer.Clip;
            if(clip.Name!="shootAdditive" || clip.Loop || !double.IsFinite(clip.Seconds) || clip.Seconds is <0 or >86400 ||
                !float.IsFinite(upperBodyLayer.Weight) || upperBodyLayer.Weight is <0 or >1)
                throw new InvalidDataException("Invalid upper-body rifle layer.");
            result.UpperBodyLayer=new RifleUpperBodyLayer {Seconds=(float)clip.Seconds,Weight=upperBodyLayer.Weight};
        }
        return result;
    }
    private static PoseRotation Rotation(Quaternion q)
    {
        if(!float.IsFinite(q.LengthSquared()) || Math.Abs(q.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid wire pose rotation.");
        return new() {X=q.X,Y=q.Y,Z=q.Z,W=q.W};
    }
}
