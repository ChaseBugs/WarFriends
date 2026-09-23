using System.Numerics;
using War.BattleServer;

internal static class ShotgunOverlapTests
{
    internal static int Run()
    {
        int checks=0;
        void Check(bool ok,string reason){if(!ok)throw new Exception(reason);checks++;}
        var box=new PlayerHitbox("fixture/player/body",PlayerHitboxKind.Box,1,
            new Vector3(0,0,5),Vector3.One,Quaternion.Identity,0,Vector3.Zero,0);
        var head=new PlayerHitbox("fixture/player/head",PlayerHitboxKind.Sphere,2,
            new Vector3(0,1,5),Vector3.Zero,Quaternion.Identity,.5f,Vector3.Zero,0);
        Check(box.OverlapsSphere(Vector3.Zero,4.5f),"sphere overlaps box surface even when box center is outside");
        Check(!box.OverlapsSphere(Vector3.Zero,4.49f),"box surface outside overlap radius");
        Check(head.OverlapsSphere(new Vector3(0,1,0),4.5f),"sphere collider boundary included");
        var rotated=new PlayerHitbox(box.SourcePath,box.Kind,box.Weight,box.Center,new Vector3(1,1,4),
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/2),0,Vector3.Zero,0);
        Check(rotated.OverlapsSphere(new Vector3(2,0,5),.1f),"oriented box overlap uses local axes");
        var pose=PlayerCollisionModel.InitializedFrame(new string('a',64),"fixture/player",Vector3.Zero,
            Quaternion.Identity,[box,head]);
        var distant=pose.Place(new Vector3(100,0,0),Quaternion.Identity);
        string a=new('a',32),b=new('b',32);
        var world=new ShotCollisionWorld(null,[new(a,distant),new(b,pose)]);
        var hits=world.OverlapEnemy(a,Vector3.Zero,4.5f);
        Check(hits.Count==1 && hits[0].MainEntityId==b && hits[0].Center==box.Center &&
              hits[0].EntityId.Length==64,"current enemy collider supplies bounded stable part identity");
        var shot=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            Vector3.Zero,new Vector3(0,0,6),hits);
        Check(shot.RealPellets.Count==2 && shot.RealPellets[1].EntityId==hits[0].EntityId,
              "host overlap feeds one extra real pellet");
        Check(new ShotCollisionWorld(null,[new(a,pose),new(b,distant)]).OverlapEnemy(a,Vector3.Zero,4.5f).Count==0,
              "moving enemy pose removes old overlap candidates");
        try { _=world.OverlapEnemy(new string('c',32),Vector3.Zero,4.5f); throw new Exception("Unknown shooter accepted."); }
        catch(InvalidDataException){checks++;}
        return checks;
    }
}
