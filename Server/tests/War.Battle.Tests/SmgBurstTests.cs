using System.Numerics;
using War.BattleServer;

internal static class SmgBurstTests
{
    internal static int Run(string directory)
    {
        int count=0;void Check(bool value,string name){if(!value)throw new Exception(name);count++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){count++;return;}throw new Exception(name);}
        var catalog=SmgCatalog.Load(Path.Combine(directory,"smg-content-manifest.json"));
        var stage=catalog.Stage("Google2u.SMG_MP5",0);var burst=new SmgBurstScheduler();
        var firstTarget=new Vector3(1,2,3);burst.StartAfterFirstShot(100,firstTarget,stage);
        Check(burst.Active&&burst.Remaining==2&&burst.NextShotTick==104,"SMG queues remainder after first shot using ceiling cadence");
        for(ulong tick=101;tick<104;tick++)Check(burst.Advance(tick,stage)==null,"SMG does not fire before source cadence");
        var second=burst.Advance(104,stage);Check(second==firstTarget&&burst.Remaining==1&&burst.NextShotTick==108,
            "SMG emits second source burst round");
        var updated=new Vector3(4,5,6);burst.UpdateTarget(updated);
        for(ulong tick=105;tick<108;tick++)burst.Advance(tick,stage);
        var third=burst.Advance(108,stage);
        Check(third==updated&&!burst.Active&&burst.LockThroughTick==112,"SMG completes three rounds and owns post-burst lock");
        Check(!burst.CanStart(112)&&burst.CanStart(113),"SMG source strict greater-than lock gate retained");
        Reject(()=>burst.StartAfterFirstShot(112,firstTarget,stage),"SMG cannot restart at lock deadline");
        burst.StartAfterFirstShot(113,firstTarget,stage);burst.Cancel();
        Check(!burst.Active&&burst.NextShotTick==0,"SMG selection/reload cancellation removes pending continuation");
        Reject(()=>burst.UpdateTarget(firstTarget),"inactive SMG target update rejected");
        var skipped=new SmgBurstScheduler();skipped.StartAfterFirstShot(200,firstTarget,stage);
        Reject(()=>skipped.Advance(205,stage),"SMG scheduler rejects skipped live simulation tick");
        var invalid=stage with {BurstSize=1};var bad=new SmgBurstScheduler();
        Reject(()=>bad.StartAfterFirstShot(1,firstTarget,invalid),"invalid SMG burst size rejected");
        Reject(()=>new SmgBurstScheduler().StartAfterFirstShot(1,new(float.NaN,0,0),stage),"nonfinite SMG target rejected");
        return count;
    }
}
