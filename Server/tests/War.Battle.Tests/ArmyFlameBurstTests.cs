using System.Numerics;
using War.BattleServer;

internal static class ArmyFlameBurstTests
{
    internal static int Run()
    {
        int checks=0;
        void Check(bool value,string reason){if(!value)throw new Exception(reason);checks++;}
        void Reject(Action action,string reason)
        {try{action();throw new Exception(reason);}catch(InvalidDataException){checks++;}}

        string owner=new string('a',32);
        var burst=new ArmyFlameBurst(1,2,owner,0);
        ulong[] expected=[11,22,33,44,55,66];
        foreach(ulong due in expected)
        {
            Check(!burst.Due(due-1)&&burst.Due(due),
                $"flame pulse preserves strict 0.35-second source clock (expected {due}, actual {burst.NextPulseTick})");
            burst.CommitPulse(due);
        }
        Check(burst.Finished&&!burst.Due(100),"flame burst terminates after exactly six pulses");

        var body=new PlayerHitbox("fixture/player/body",PlayerHitboxKind.Box,1,
            new Vector3(0,0,1),new Vector3(.5f,1,.5f),Quaternion.Identity,0,Vector3.Zero,0);
        var head=new PlayerHitbox("fixture/player/head",PlayerHitboxKind.Sphere,2,
            new Vector3(0,1,1),Vector3.Zero,Quaternion.Identity,.2f,Vector3.Zero,0);
        var pose=PlayerCollisionModel.InitializedFrame(new string('b',64),"fixture/player",
            new Vector3(0,0,1),Quaternion.Identity,[body,head]);
        var hit=ArmyFlameBurst.ResolvePlayer(Vector3.Zero,Vector3.UnitZ,pose,60);
        Check(hit is {PartPath:"fixture/player/body"}&&Math.Abs(hit.RawDamage-7)<.0001f,
            "flame cone uses collider center and recovered distance damage interpolation");

        var near=pose.Place(new Vector3(0,0,.29f),Quaternion.Identity);
        Check(ArmyFlameBurst.ResolvePlayer(Vector3.Zero,Vector3.UnitZ,near,60)==null,
            "flame ignores source targets closer than 0.3 units");
        var behind=pose.Place(new Vector3(0,0,-1),Quaternion.Identity);
        Check(ArmyFlameBurst.ResolvePlayer(Vector3.Zero,Vector3.UnitZ,behind,60)==null,
            "flame rejects targets behind its cone");
        var edge=pose.Place(new Vector3(MathF.Sin(41*MathF.PI/180),0,
            MathF.Cos(41*MathF.PI/180)),Quaternion.Identity);
        Check(ArmyFlameBurst.ResolvePlayer(Vector3.Zero,Vector3.UnitZ,edge,60)==null,
            "flame rejects a target beyond the recovered distance-dependent half angle");

        var cadence=new ArmyRusherAttackState(new ArmyBaseShotStats(1,2,2,1,1),()=>0,11);
        Check(cadence.TryBegin(true,1,0)&&cadence.AdvanceTick()&&cadence.ShotDue&&cadence.CommitShot(),
            "flamethrower batch begins with one due source shot");
        for(int i=1;i<11;i++)
        {
            cadence.AdvanceTick();
            Check(!cadence.ShotDue,"flamethrower cadence blocks early batch shots");
        }
        cadence.AdvanceTick();
        Check(cadence.ShotDue&&cadence.CommitShot()&&
              cadence.Phase==ArmyRusherAttackPhase.Cooldown,
            "flamethrower permits the next batch shot exactly eleven strict-cadence ticks later");

        Reject(()=>new ArmyFlameBurst(0,2,owner,0),"zero flame identity accepted");
        Reject(()=>ArmyFlameBurst.ResolvePlayer(Vector3.Zero,Vector3.Zero,pose,60),
            "zero flame direction accepted");
        Reject(()=>new ArmyRusherAttackState(new ArmyBaseShotStats(1,1,1,1,1),shotIntervalTicks:-1),
            "negative flame cadence accepted");
        return checks;
    }
}
