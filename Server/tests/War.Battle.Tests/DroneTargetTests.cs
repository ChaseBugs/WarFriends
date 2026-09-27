using System.Numerics;
using War.BattleServer;
internal static class DroneTargetTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        DroneTargetCandidate Row(string id,int? group,bool decoy=false)=>new(id,2,true,true,decoy,group,Vector3.Zero);
        var rows=new[]{Row("player",null),Row("defender",0),Row("shooter",2),Row("explosive",1),Row("rusher",3),Row("decoy",null,true)};
        Check(DroneTargetPolicy.Select(1,rows,_=>true)?.Id=="decoy","visible Decoy precedes army/player targets");
        Check(DroneTargetPolicy.Select(1,rows,r=>r.Id!="decoy")?.Id=="rusher","visible Rusher precedes anyUnit groups");
        Check(DroneTargetPolicy.Select(1,rows,r=>r.Id is not ("decoy" or "rusher"))?.Id=="explosive","anyUnit order is explosive before shooter/defender");
        Check(DroneTargetPolicy.Select(1,[Row("first",2),Row("second",2)],_=>true)?.Id=="first","registry first visibility wins without random sorting");
        Check(DroneTargetPolicy.Select(1,[Row("friend",0) with {Fraction=1},Row("dead",0) with {Alive=false},
            Row("hidden",0) with {Visible=false},Row("player",null)],_=>true)?.Id=="player","lifecycle/faction filtering before fallback");
        Check(DroneTargetPolicy.Select(1,rows,_=>false)==null,"blocked opponents produce no target");
        var ray=DroneTargetPolicy.Sight(Vector3.Zero,new(0,.5f,10));
        Check(ray.Origin==new Vector3(0,.5f,.5f)&&ray.Direction==Vector3.UnitZ&&ray.Range==9,"source height/start/end visibility offsets");
        var close=DroneTargetPolicy.Sight(Vector3.Zero,new(0,.5f,.1f));
        Check(close.Range==.1f&&close.Origin.Z==.5f,"near sight overshoots start and keeps source minimum range");
        var zero=DroneTargetPolicy.Sight(Vector3.Zero,new(0,.5f,0));
        Check(zero.Direction==Vector3.Zero&&zero.Range==.1f,"coincident sight retains Unity zero normalized direction");
        int visibilityCalls=0;
        try{DroneTargetPolicy.Select(1,[Row("valid",null),Row("damaged",0) with {Position=new(float.NaN,0,0)}],
            _=>{visibilityCalls++;return true;});throw new Exception("damaged target registry accepted");}
        catch(InvalidDataException){Check(visibilityCalls==0,"complete target registry validates before first visibility query");}
        return count;
    }
}
