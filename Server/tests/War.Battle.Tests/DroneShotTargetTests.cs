using System.Numerics;
using War.BattleServer;
internal static class DroneShotTargetTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        DroneShotTarget[] parts=[new(1,4,Vector3.Zero),new(2,1,Vector3.UnitX),new(3,2,Vector3.UnitZ),new(4,8,-Vector3.UnitX)];
        DroneShotTarget? Select(bool player,bool hiding,float probability,float draw)
            =>DroneShotTargetPolicy.Select(Vector3.Zero,parts,player,-Vector3.UnitZ,Vector3.UnitZ,hiding,probability,()=>draw);
        Check(Select(false,false,0,0)?.TransformFileId==2,"nonplayer AllIn excludes Out and preserves first nearest tie");
        Check(Select(true,true,.5f,.6f)?.TransformFileId==2,"front hiding player with random above probability selects WholeBody");
        Check(Select(true,true,.5f,.5f)?.TransformFileId==3,"strict shield random equality chooses shield");
        Check(Select(true,false,.5f,1)?.TransformFileId==3,"nonhiding player retains source shield branch");
        Check(Select(true,true,-1,0)==null,"negative source shield probability suppresses player shot");
        int draws=0;
        var side=DroneShotTargetPolicy.Select(Vector3.Zero,parts,true,Vector3.UnitZ,Vector3.UnitZ,true,0,()=>{draws++;return 1;});
        Check(side?.TransformFileId==3&&draws==0,"outside front angle selects shield without random draw");
        var none=DroneShotTargetPolicy.Select(Vector3.Zero,[new(7,0,Vector3.Zero)],false,Vector3.Zero,Vector3.Zero,false,0,()=>0);
        Check(none?.TransformFileId==7,"source None mask remains eligible in subset selection");
        Check(DroneShotTargetPolicy.Predict(Vector3.Zero,new(0,0,10),Vector3.UnitX,5,1)==new Vector3(2.1f,0,10),
            "gun muzzle distance/effective speed plus source extra tenth predicts nonplayer motion");
        Check(DroneShotTargetPolicy.Predict(Vector3.Zero,new(0,0,10),Vector3.Zero,2.5f,1)==new Vector3(0,0,10),
            "source player zero velocity preserves target despite half-speed bullet");
        return count;
    }
}
