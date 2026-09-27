using System.Numerics;
using War.BattleServer;
internal static class DroneBatchTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        var draws=new Queue<float>([0,.75f,1,0,0,1,1]);
        var batch=new DroneBatchState(()=>draws.Dequeue());batch.Replace(Vector3.UnitZ,3,.75f);
        Check(draws.Count==4&&batch.Shooting,"one strict probability draw per batch round at setup");
        Check(batch.Advance(Vector3.Zero,false)==null&&draws.Count==4,"ammo gate consumes no fake dispersion samples");
        var real=batch.Advance(Vector3.Zero,true)!;
        Check(!real.IsFake&&real.Target==Vector3.UnitZ&&real.Index==0&&!real.EndsBatch,"real round uses stored target without another probability draw");
        var firstFake=batch.Advance(Vector3.Zero,true)!;
        Check(firstFake.IsFake&&Vector3.Distance(firstFake.Target,new(-.3f,.3f,1))<1e-6f&&draws.Count==2,
            "fake shot uses perpendicular offset, magnitude then strict sign draw");
        var last=batch.Advance(Vector3.Zero,true)!;
        Check(last.IsFake&&Vector3.Distance(last.Target,new(.5f,.3f,1))<1e-6f&&last.EndsBatch&&!batch.Shooting,
            "final fake shot accepts float-range upper endpoint and ends batch");
        var replace=new DroneBatchState(()=>0);replace.Replace(Vector3.UnitX,3,1);replace.Advance(Vector3.Zero,true);
        replace.Replace(Vector3.UnitY,1,1);
        Check(replace.Advance(Vector3.Zero,true)!.Target==Vector3.UnitY&&!replace.Shooting,"new batch replaces unconsumed rounds and target");
        int zeroDraws=0;var zero=new DroneBatchState(()=>{zeroDraws++;return 0;});zero.Replace(Vector3.Zero,0,1);
        var zeroShot=zero.Advance(Vector3.Zero,true)!;
        Check(zeroShot.IsFake&&zeroShot.EndsBatch&&zeroShot.Target==new Vector3(0,.3f,0)&&zeroDraws==2,
            "source zero batch still emits one fake shot before completion");
        replace.Replace(Vector3.Zero,1,1);replace.Reset();
        Check(replace.Advance(Vector3.Zero,true)==null,"source Reset cancels pending batch");
        var elite=new DroneBatchState(()=>1);elite.Replace(Vector3.UnitZ,1,1.4f);
        Check(!elite.Advance(Vector3.Zero,true)!.IsFake,"additive elite probability above one includes random upper endpoint");
        return count;
    }
}
