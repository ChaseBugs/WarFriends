using System.Numerics;

namespace War.BattleServer;

// Host-only bridge from the recovered cone selection to independently rolled
// fast BulletSlow pellets. MatchEngine must still admit the volley atomically.
internal static class ShotgunVolleyFactory
{
    internal static PreparedVolley PrepareWithVisuals(ShotgunBinding binding,ShotgunStage stage,
        ulong firstId,string owner,Vector3 muzzle,Vector3 aim,ulong tick,
        IReadOnlyList<ShotgunCollider> overlap,Func<float> criticalRoll,
        Func<float> spreadRoll,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        ArgumentNullException.ThrowIfNull(spreadRoll);
        var real=Prepare(binding,stage,firstId,owner,muzzle,aim,tick,overlap,criticalRoll,trace);
        Vector3 from=muzzle+binding.ShotOffset;
        var plan=ShotgunShotPlanner.Plan(binding.Rule(stage),from,aim,overlap);
        if(real.Count+plan.FakePellets>8||firstId>ulong.MaxValue-(ulong)(real.Count+plan.FakePellets)+1)
            throw new InvalidDataException("Shotgun visual volley exceeds its identity bound.");
        var fake=new ShotgunFakePelletFlight[plan.FakePellets];
        for(int i=0;i<fake.Length;i++)
        {
            float u=spreadRoll(),v=spreadRoll();
            if(!float.IsFinite(u)||!float.IsFinite(v)||u is <0 or >1||v is <0 or >1)
                throw new InvalidDataException("Invalid host shotgun spread roll.");
            float z=2*u-1,angle=2*MathF.PI*v;
            float planar=MathF.Sqrt(MathF.Max(0,1-z*z));
            var sphere=new Vector3(planar*MathF.Cos(angle),planar*MathF.Sin(angle),z);
            Vector3 target=ShotgunFakePelletFlight.SpreadTarget(from,aim,sphere);
            fake[i]=new ShotgunFakePelletFlight(firstId+(ulong)real.Count+(ulong)i,
                owner,from,target,binding.FakeSpeed,tick);
        }
        return new(real,Array.AsReadOnly(fake));
    }

    internal static IReadOnlyList<PreparedProjectile> Prepare(ShotgunBinding binding,ShotgunStage stage,
        ulong firstId,string owner,Vector3 muzzle,Vector3 aim,ulong tick,
        IReadOnlyList<ShotgunCollider> overlap,Func<float> criticalRoll,
        Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if(binding==null || stage==null || binding.SourceId!=stage.SourceId ||
            criticalRoll==null || trace==null || firstId==0 || firstId>ulong.MaxValue-7 ||
            !PlayerHitbox.Finite(muzzle) || !PlayerHitbox.Finite(binding.ShotOffset))
            throw new InvalidDataException("Invalid shotgun volley authority.");
        Vector3 from=muzzle+binding.ShotOffset;
        if(!PlayerHitbox.Finite(from))throw new InvalidDataException("Invalid shotgun muzzle.");
        var plan=ShotgunShotPlanner.Plan(binding.Rule(stage),from,aim,overlap);
        var result=new PreparedProjectile[plan.RealPellets.Count];
        for(int i=0;i<result.Length;i++)
        {
            float roll=criticalRoll();
            if(!float.IsFinite(roll) || roll is <0 or >1)throw new InvalidDataException("Invalid shotgun critical roll.");
            var pellet=plan.RealPellets[i];
            float damage=pellet.BaseDamage*(roll<stage.CriticalProbability ? binding.CriticalMultiplier : 1);
            if(!float.IsFinite(damage) || damage is <0 or >100_000_000)
                throw new InvalidDataException("Invalid shotgun pellet damage.");
            result[i]=new(new BulletFlight(firstId+(ulong)i,owner,
                    new BulletFlightDefinition(binding.Speed,binding.CheckDistance,true),
                    from,pellet.Target,tick,trace),
                new ResolvedPlayerDamage(damage,CombatDamageType.Shot,HasWeapon:true,
                    FriendKill:binding.FriendKill,PlayerCoefficient:stage.PlayerDamageRatio,
                    PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio),binding.SourceId);
        }
        return Array.AsReadOnly(result);
    }
}
