using System.Numerics;
using War.BattleServer;
internal static class DroneWaypointTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        DroneWaypoint[] points=[new(1,Vector3.Zero,0),new(2,Vector3.UnitX,0),new(3,Vector3.UnitY,0)];
        DroneWaypointState State(int join,bool forward,bool loop,float draw=1)
            =>new(points,join,points[join].Position,.2f,.87f,forward,loop,()=>draw);
        var normal=State(0,true,true);
        Check(normal.Advance(1,1f/30)==0&&normal.TargetIndex==1&&normal.Forward,"source arrival precedes forward traversal");
        var back=State(0,false,true);back.Advance(1,1f/30);
        Check(back.TargetIndex==2&&!back.Forward,"reverse loop wraps to final waypoint");
        var wrap=State(2,true,true);wrap.Advance(1,1f/30);
        Check(wrap.TargetIndex==0,"forward loop wraps to first waypoint");
        var end=State(2,true,false);end.Advance(1,1f/30);
        Check(!end.UsingWaypoints&&end.Position==Vector3.UnitY,"nonloop endpoint returns without motion");
        var reverse=State(1,true,true,.099f);reverse.Advance(1,1f/30);
        Check(reverse.TargetIndex==0&&!reverse.Forward,"direction draw below tenth reverses before choosing next point");
        var boundary=State(1,true,true,.1f);boundary.Advance(1,1f/30);
        Check(boundary.TargetIndex==2&&boundary.Forward,"exact tenth does not reverse");
        int draws=0;var staying=new DroneWaypointState([new(1,Vector3.Zero,.1f),new(2,Vector3.UnitX,0)],0,
            Vector3.Zero,.2f,.87f,true,true,()=>{draws++;return 1;});
        Check(staying.Advance(1,.05f)==0&&staying.TargetIndex==0&&draws==0,"stay begins with one arrival and no direction draw");
        Check(staying.Advance(1.05f,.05f)==null&&staying.TargetIndex==1&&draws==1,"stay completion changes target without duplicate arrival");
        var edge=new DroneWaypointState(points,0,new(.2f,0,0),.2f,.87f,true,true,()=>1);
        Check(edge.Advance(1,1f/30)==null&&edge.TargetIndex==0,"exact path radius is not arrival");
        var disabled=State(0,true,true);
        Check(disabled.Advance(1,1f/30,false)==null&&disabled.TargetIndex==0,"disabled traversal produces no arrival or direction change");
        var invalid=State(0,true,true,float.NaN);
        try{invalid.Advance(1,1f/30);throw new Exception("invalid direction accepted");}
        catch(InvalidDataException){Check(invalid.TargetIndex==0&&invalid.Position==Vector3.Zero,"invalid random sample publishes no traversal mutation");}
        var looking=State(0,true,true);var withoutTarget=State(0,true,true);
        looking.Advance(1,1f/30,lookTarget:-Vector3.UnitX);
        withoutTarget.Advance(1,1f/30);
        Check(looking.Position==withoutTarget.Position&&looking.Velocity==withoutTarget.Velocity&&
            Quaternion.Dot(looking.Rotation,withoutTarget.Rotation)<.9999f,
            "look target changes heading without changing source waypoint motion");
        var expected=new DroneOrientationState();
        expected.Advance(looking.Position,looking.Velocity,looking.Velocity,1f/30,-Vector3.UnitX);
        Check(Math.Abs(Quaternion.Dot(expected.Rotation,looking.Rotation))>.999999f,
            "waypoint orientation observes post-movement root and selected target");
        var invalidLook=State(0,true,true);
        try{invalidLook.Advance(1,1f/30,lookTarget:new(float.NaN,0,0));throw new Exception("invalid look accepted");}
        catch(InvalidDataException){Check(invalidLook.Position==Vector3.Zero&&invalidLook.TargetIndex==0,
            "invalid target rejected before path mutation");}
        return count;
    }
}
