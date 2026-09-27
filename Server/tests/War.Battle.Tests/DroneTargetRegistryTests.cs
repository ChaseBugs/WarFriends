using System.Numerics;
using War.BattleServer;
internal static class DroneTargetRegistryTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        DroneTargetCandidate Row(string id)=>new(id,2,true,true,false,null,Vector3.Zero);
        var registry=new DroneTargetRegistry();
        registry.Enable("PlayerController",Row("p1"));registry.Enable("Tank",Row("t1"));
        registry.Enable("PlayerController",Row("p2"));
        Check(registry.Snapshot().Select(r=>r.Id).SequenceEqual(new[]{"p1","p2","t1"}),
            "owner-type buckets precede global entity insertion order");
        var old=registry.Snapshot();registry.Disable("p1");registry.Disable("p2");
        registry.Enable("Drone",Row("d1"));registry.Enable("PlayerController",Row("p1"));
        Check(registry.Snapshot().Select(r=>r.Id).SequenceEqual(new[]{"p1","t1","d1"}),
            "empty owner bucket retains original position after reenabling");
        Check(old.Count==3&&old[1].Id=="p2","snapshot survives subsequent lifecycle changes");
        registry.Update(Row("p1") with {Alive=false});
        Check(registry.Select(1,_=>true)?.Id=="t1","lifecycle update changes eligibility without reordering");
        registry.Enable("Tank",Row("t2"));registry.Disable("t1");registry.Enable("Tank",Row("t1"));
        Check(registry.Select(1,_=>true)?.Id=="t2","reenabled instance appends within retained owner bucket");
        try{registry.Enable("Tank",Row("t2"));throw new Exception("duplicate target accepted");}
        catch(InvalidDataException){count++;}
        try{registry.Update(Row("t2") with {Position=new(float.NaN,0,0)});throw new Exception("invalid update accepted");}
        catch(InvalidDataException){count++;}
        Check(registry.Select(1,_=>true)?.Id=="t2","rejected update preserves prior target authority");
        return count;
    }
}
