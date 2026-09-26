using System.Numerics;
using War.BattleServer;

internal static class DroneSpecialTests
{
    internal static int Run(ArmyDeploymentCatalog catalog)
    {
        int checks=0;
        void Check(bool value,string name){if(!value)throw new Exception(name);checks++;}
        void Reject(Action action){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception("Invalid Drone special accepted.");}
        Check(catalog.ComposeSpecial("ID_UNIT-DRONE",0,96,null)==1.5f&&
              catalog.ComposeSpecial("ID_UNIT-DRONE",0,116,null)==3.9f,
              "Drone special duration bounds bind recovered first and last special rows");
        var samples=new Queue<float>([0,0,.5f,0]);
        var cycle=new DroneSpecialState(0,true,2.5f,()=>samples.Dequeue());
        Check(!cycle.Observe(5,true,true)&&!cycle.IsImmortal&&samples.Count==3,"strict activation deadline consumes no early random sample");
        Check(cycle.Observe(5.1f,true,true)&&cycle.IsImmortal&&cycle.Transparent&&samples.Count==2,"activation draws duration once and sets immortality/transparency");
        Check(!cycle.Observe(7.5f,true,true)&&cycle.IsImmortal,"immunity end retains original scheduled deadline and strict comparison");
        Check(cycle.Observe(7.6f,true,true)&&!cycle.IsImmortal&&samples.Count==1,"expiry draws next delay exactly once");
        Check(!cycle.Observe(15.6f,true,true)&&!cycle.IsImmortal,"next cycle uses observed expiry time plus ten minus special and random");
        Check(cycle.Observe(15.7f,true,true)&&cycle.IsImmortal&&samples.Count==0,"second cycle starts after its exact deadline");
        Reject(()=>cycle.Observe(float.NaN,true,true));Reject(()=>cycle.Observe(1,true,true));
        var skipped=new DroneSpecialState(0,true,1.5f,()=>0);
        Check(skipped.Observe(100,true,true)&&skipped.IsImmortal,"late observation applies only one source Update branch");
        Check(skipped.Observe(100,true,true)&&!skipped.IsImmortal,"next source Update expires a late activation without fast-forwarding cycles");
        int disabledDraws=0;var disabled=new DroneSpecialState(0,false,0,()=>{disabledDraws++;return 1;});
        Check(!disabled.Observe(100,true,true)&&!disabled.IsImmortal&&disabledDraws==1,"disabled special still draws OnInstancied delay but never activates");
        var gated=new DroneSpecialState(0,true,1.5f,()=>0);
        Check(!gated.Observe(6,false,true)&&!gated.Observe(7,true,false)&&!gated.IsImmortal,"non-running or dead Drone never activates");
        Check(gated.Observe(8,true,true)&&gated.IsImmortal,"gates retain the scheduled activation deadline");
        var upper=new DroneSpecialState(0,true,3.9f,()=>1);
        Check(!upper.Observe(10,true,true)&&upper.Observe(10.1f,true,true)&&upper.IsImmortal,"Unity float random upper endpoint remains valid");
        foreach(float value in new[]{float.NaN,float.PositiveInfinity,-.01f,1.01f})
            Reject(()=>new DroneSpecialState(0,true,1.5f,()=>value));
        foreach(float value in new[]{float.NaN,-1,4})Reject(()=>new DroneSpecialState(0,true,value,()=>0));
        Reject(()=>new DroneSpecialState(float.MaxValue,true,1.5f,()=>0));
        float next=0;var damagedRandom=new DroneSpecialState(0,true,1.5f,()=>next);next=float.NaN;
        Reject(()=>damagedRandom.Observe(6,true,true));Check(!damagedRandom.IsImmortal,"invalid duration draw publishes no immunity transition");
        var registry=new AirEntityRegistry();var immuneCycle=new DroneSpecialState(0,true,1.5f,()=>0);
        var entity=new AirBattleEntity(95,new string('2',32),new(Vector3.Zero,Vector3.Zero,1),
            new(new(5,1,1,1,0,0,0),()=>0),new(40),immuneCycle);
        registry.TrySpawn(entity);immuneCycle.Observe(5.1f,true,true);
        Check(!registry.TryApplyDamage(95,100,out float amount)&&amount==0&&entity.Health.Current==40&&registry.Count==1,
            "immune registry hit preserves health and entity even for lethal damage");
        Reject(()=>registry.TryApplyDamage(95,float.NaN,out _));
        immuneCycle.Observe(6.6f,true,true);
        Check(registry.TryApplyDamage(95,100,out amount)&&amount==40&&registry.Count==0,"expired immunity permits authoritative lethal removal");
        return checks;
    }
}
