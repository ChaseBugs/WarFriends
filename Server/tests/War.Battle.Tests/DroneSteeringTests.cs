using System.Numerics;
using War.BattleServer;
internal static class DroneSteeringTests
{
    internal static int Run()
    {
        int count=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        DroneSteeringStep.Result Step(Vector3 p,Vector3 v,Vector3 target,float time)
            =>DroneSteeringStep.Advance(p,v,target,time,1f/30,0,.5f,.87f,80,.6f,.5f);
        var delay=Step(Vector3.Zero,new(.01f,0,0),Vector3.UnitX,.49f);
        Check(delay.Steering==Vector3.Zero&&delay.Position.X==.01f,"corner delay retains velocity drift");
        var start=Step(Vector3.Zero,Vector3.Zero,Vector3.UnitX,.5f);
        Check(Math.Abs(start.Position.X-.87f/30/80)<1e-8f,"delay boundary and source mass integration");
        var near=Step(Vector3.Zero,Vector3.Zero,new(.3f,0,0),1);
        Check(Math.Abs(near.Position.X-.5f/30*.5f/80)<1e-8f,"distance-ratio braking");
        var boundary=Step(Vector3.Zero,Vector3.Zero,new(.6f,0,0),1);
        Check(Math.Abs(boundary.Position.X-start.Position.X)<1e-8f,"brake boundary uses full speed");
        var zero=Step(Vector3.Zero,new(.08f,0,0),Vector3.Zero,1);
        Check(Math.Abs(zero.Velocity.X-.079f)<1e-7f,"zero-distance velocity damping without snap");
        Check(Step(Vector3.Zero,Vector3.Zero,Vector3.UnitY,1).Position.Y>0,"vertical steering");
        foreach(float invalid in new[]{float.NaN,float.PositiveInfinity,-1f})
        {
            try{Step(Vector3.Zero,Vector3.Zero,Vector3.UnitX,invalid);}
            catch(InvalidDataException){count++;continue;}
            throw new Exception("Invalid Drone clock accepted.");
        }
        return count;
    }
}
