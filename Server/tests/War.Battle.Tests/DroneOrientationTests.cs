using System.Numerics;
using War.BattleServer;
internal static class DroneOrientationTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        var idle=new DroneOrientationState();idle.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,1f/30,null);
        Check(idle.Rotation==Quaternion.Identity,"zero velocity/acceleration preserves identity bank");
        var heading=new DroneOrientationState();heading.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,.2f,-Vector3.UnitX);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,heading.Rotation),Vector3.UnitX)<1e-5f,
            "source look heading points from target toward Drone");
        heading.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,1f/30,null);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,heading.Rotation),Vector3.UnitX)<1e-5f,"missing target retains prior heading");
        var bank=new DroneOrientationState();bank.Advance(Vector3.Zero,Vector3.UnitZ,new(.001f,0,0),1f/30,null);
        Check(Math.Abs(bank.Rotation.LengthSquared()-1)<1e-5f&&bank.Rotation!=Quaternion.Identity,"source acceleration produces normalized retained bank");
        var prior=bank.Rotation;
        try{bank.Advance(Vector3.Zero,Vector3.UnitZ,Vector3.Zero,float.NaN,null);throw new Exception("invalid orientation clock accepted");}
        catch(InvalidDataException){Check(bank.Rotation==prior,"invalid orientation input leaves prior pose intact");}
        return count;
    }
}
