using System.Numerics;
using War.BattleServer;

internal static class RiflePlaybackTests
{
    internal static int Run(RifleStatCatalog stats,RifleBindingCatalog bindings,PlayerPoseCatalog poses)
    {
        int count=0;
        void Check(bool ok,string name) { if (!ok) throw new Exception(name);count++; }
        var timeline=new RifleCoverTimeline(poses);
        timeline.Shot(true);
        Check(timeline.Layers.Count==2 && timeline.Layers[0].Weight==1 && timeline.Layers[1].Weight==0,"uncover starts from outgoing idle pose");
        timeline.Advance(.01);
        Check(Math.Abs(timeline.Layers[1].Weight-.5)<.00001,"uncover fade half weight");
        var intermediate=poses.SampleLayers(timeline.Layers);
        Check(intermediate.Collision.PoseKind=="local-rig-blend","playback layers produce runtime collision pose");
        timeline.Advance(.033333333);
        Check(timeline.Layers.Count==1,"uncover fade completes before next thirty-Hz sample");
        timeline.Advance(10/30d);
        var shooter=poses.SampleLayers(timeline.Layers).Place(Vector3.Zero,Quaternion.Identity);
        var victimTimeline=new RifleCoverTimeline(poses); victimTimeline.Shot(false);victimTimeline.Advance(.5);victimTimeline.Advance(.8);
        Check(victimTimeline.Layers.Count==2 && victimTimeline.Layers[1].Weight>0,"victim is blending hide into idle");
        var victim=poses.SampleLayers(victimTimeline.Layers).Place(new Vector3(0,0,8),Quaternion.Identity);
        string a=new string('a',32),b=new string('b',32),rifle="Google2u.AssaultRifle_AK47";
        var world=new ShotCollisionWorld(null,[new(a,shooter.Collision),new(b,victim.Collision)]);
        Vector3 target=victim.Collision.Parts[1].Center;
        var projectile=bindings.Prepare(stats,rifle,0,1,a,shooter.Muzzle(rifle).Position,target,10,1,
            (origin,direction,range)=>world.Raycast(a,origin,direction,range));
        BulletImpact? impact=null;
        for (ulong tick=11;tick<=130 && !projectile.Flight.Finished;tick++) impact=projectile.Flight.Advance(tick)??impact;
        Check(impact?.Hit.PlayerId==b,"source rifle projectile hits blended victim pose");
        var resolved=PlayerDamage.Resolve(new PlayerCombatManifest(1000),1000,
            projectile.Damage with { PartWeight=impact!.Hit.PartWeight },false,false,1);
        Check(resolved.Applied && resolved.Health<1000 && resolved.Health>0,"source-bound collision feeds health kernel");
        Check(projectile.Flight.Advance(131)==null,"source-bound impact is not repeated");
        victimTimeline.Shot(true);
        Check(victimTimeline.Layers.Count==3 && Math.Abs(victimTimeline.Layers.Sum(l=>l.Weight)-1)<.00001,"interrupted hide blend conserves outgoing layers");
        victimTimeline.Advance(.81);
        Check(poses.SampleLayers(victimTimeline.Layers).Collision.Parts.Count==2,"three-layer playback rebuilds collision");
        return count;
    }
}
