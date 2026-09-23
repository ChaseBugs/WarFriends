using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class BulletFlightTests
{
    internal static int Run(MatchManifest source)
    {
        int count = 0;
        void Check(bool value,string name) { if (!value) throw new Exception(name); count++; }
        void Reject(Action action)
        {
            try { action(); } catch (Exception e) when (e is InvalidDataException or ArgumentException or InvalidOperationException or ProjectileTargetException) { count++; return; }
            throw new Exception("Invalid projectile accepted.");
        }
        string a = source.Players[0].PlayerId, b = source.Players[1].PlayerId;
        ShotCollision? Plane(Vector3 from,Vector3 direction,float range,float x,bool stationary)
        {
            if (Math.Abs(direction.X)<0.00001f) return null;
            float t = (x-from.X)/direction.X;
            return t >= 0 && t <= range ? new(t,from+direction*t,"fixture/body",stationary ? null : b,1,stationary) : null;
        }
        var slow = new BulletFlightDefinition(10,1,false);
        var wall = new BulletFlight(1,a,slow,Vector3.Zero,new(20,0,0),0,(o,d,r) => Plane(o,d,r,10,true));
        for (ulong tick=1;tick<30;tick++) Check(wall.Advance(tick)==null,"static impact waits for travel");
        Check(wall.Advance(30)?.Hit.Static == true && wall.Finished,"static impact at travel deadline");
        Check(wall.Advance(30)==null && wall.Advance(31)==null,"impact returned only once");
        var dynamic = new BulletFlight(2,a,slow,Vector3.Zero,new(20,0,0),0,(o,d,r) => Plane(o,d,r,10,false));
        BulletImpact? hit = null;
        for (ulong tick=1;tick<=100 && !dynamic.Finished;tick++)
        {
            var impact = dynamic.Advance(tick);
            if (impact != null) { Check(hit==null,"one dynamic impact"); hit=impact; }
        }
        Check(hit?.Hit.PlayerId==b && hit.Tick>30,"slow bullet rechecks target near arrival");
        bool present = true;
        var dodge = new BulletFlight(3,a,slow,Vector3.Zero,new(20,0,0),0,(o,d,r) => present ? Plane(o,d,r,10,false) : null);
        present = false;
        for (ulong tick=1;tick<=100 && !dodge.Finished;tick++) Check(dodge.Advance(tick)==null,"departed target is not cached as slow hit");
        Check(dodge.Finished,"miss flight eventually expires");
        var fast = new BulletFlight(4,a,slow with { Fast=true },Vector3.Zero,new(20,0,0),0,
            (o,d,r) => Plane(o,d,r,10,false),id => new Vector3(0,0,10));
        BulletImpact? predicted = null;
        for (ulong tick=1;tick<=100 && !fast.Finished;tick++) predicted = fast.Advance(tick) ?? predicted;
        Check(predicted != null && Math.Abs(predicted.Hit.Position.Z-11)<0.0001f && predicted.Tick==45,"fast branch predicts position and defers impact");
        float firstRange = 0;
        _ = new BulletFlight(5,a,slow,Vector3.Zero,new(100,0,0),0,(o,d,r) => { firstRange=r; return null; });
        Check(Math.Abs(firstRange-49.8f)<0.0001f,"normal initial target capped at source fifty units");
        Reject(() => new BulletFlight(6,a,slow,Vector3.Zero,Vector3.Zero,0,(o,d,r)=>null));
        Reject(() => new BulletFlight(6,a,slow with { Speed=float.NaN },Vector3.Zero,Vector3.One,0,(o,d,r)=>null));
        Reject(() => new BulletFlight(6,a,slow,Vector3.Zero,Vector3.One,0,(o,d,r)=>new(r+1,Vector3.Zero,"x",null,1)));
        var step = new BulletFlight(7,a,slow,Vector3.Zero,Vector3.One,0,(o,d,r)=>null);
        Reject(() => step.Advance(2));

        var definition = source with { Players=source.Players.Select((p,i)=>p with { Fraction=i+1,Combat=new PlayerCombatManifest(100) }).ToArray() };
        var match = new MatchEngine(definition); int preparations=0;
        match.ConfigureProjectiles((id,owner,target,tick) =>
        {
            preparations++;
            return new(new BulletFlight(id,owner,slow with { Fast=true },Vector3.Zero,target,tick,(o,d,r)=>Plane(o,d,r,10,false)),
                new ResolvedPlayerDamage(60,CombatDamageType.Shot));
        },()=>1);
        Start(match,a,b);
        var fire = new MatchCommand { CommandId=2,Fire=new FireCommand { TargetX=20 } };
        Check(match.Command(a,fire).Code=="shot-accepted" && match.Snapshot().Players[1].Health==100,"accepted command launches without immediate damage");
        match.Advance(61);
        Check(match.Command(a,fire).Code=="shot-accepted" && preparations==1 && match.PendingProjectileCount==1,"command retry cannot duplicate projectile");
        match.Advance(62); match.Advance(63);
        Check(match.Command(a,new MatchCommand { CommandId=3,Fire=new FireCommand { TargetX=20 } }).Code=="shot-accepted","second authorized shot");
        for (ulong tick=64;tick<=89;tick++) match.Advance(tick);
        Check(match.Snapshot().Players[1].Health==100,"no damage before deadline");
        match.Advance(90);
        Check(match.Snapshot().Players[1].Health==40 && match.Snapshot().Players[1].DamageRevision==1,"first impact applies source damage once");
        match.Advance(91); match.Advance(92); match.Advance(93);
        var terminal = match.Snapshot();
        Check(terminal.Phase==BattlePhase.Ended && terminal.WinnerPlayerId==a && terminal.Players[1].Health==-20 &&
            terminal.Players[1].DamageRevision==2 && !terminal.RewardEligible && match.PendingProjectileCount==0,"projectile death terminates unscored match and clears flights");

        var many = new MatchEngine(definition with { IdleSeconds=120,Players=definition.Players.Select(p=>p with { Weapon=p.Weapon with { ClipSize=1000,CadenceSeconds=0.01 } }).ToArray() });
        many.ConfigureProjectiles((id,owner,target,tick)=>new(new BulletFlight(id,owner,new(1,1,true),Vector3.Zero,target,tick,(o,d,r)=>Plane(o,d,r,1000,false)),new(1,CombatDamageType.Shot)),()=>1);
        Start(many,a,b);
        for (ulong n=0;n<MatchEngine.MaximumProjectiles;n++)
        {
            if (n>0) many.Advance(60+n);
            Check(many.Command(a,new MatchCommand { CommandId=n+2,Fire=new FireCommand { TargetX=20 } }).Code=="shot-accepted","bounded flight admission");
        }
        many.Advance(60+MatchEngine.MaximumProjectiles);
        var before = many.Snapshot().Players[0].ClipAmmo;
        Check(many.Command(a,new MatchCommand { CommandId=(ulong)MatchEngine.MaximumProjectiles+2,Fire=new FireCommand { TargetX=20 } }).Code=="projectile-capacity" &&
            many.Snapshot().Players[0].ClipAmmo==before,"capacity rejection conserves ammo");
        Reject(()=>many.Advance(62+MatchEngine.MaximumProjectiles));
        many.Command(b,new MatchCommand { CommandId=2,Forfeit=new ForfeitCommand() });
        Check(many.PendingProjectileCount==0,"forfeit cancels remaining flights");
        var invalidTarget = new MatchEngine(definition);
        invalidTarget.ConfigureProjectiles((id,owner,target,tick)=>new(new BulletFlight(id,owner,slow,Vector3.Zero,target,tick,(o,d,r)=>null),new(1,CombatDamageType.Shot)),()=>1);
        Start(invalidTarget,a,b);
        int initialAmmo = invalidTarget.Snapshot().Players[0].ClipAmmo;
        Check(invalidTarget.Command(a,new MatchCommand { CommandId=2,Fire=new FireCommand() }).Code=="invalid-target" &&
            invalidTarget.Snapshot().Players[0].ClipAmmo==initialAmmo && invalidTarget.PendingProjectileCount==0,"degenerate target is callback-safe and conserves ammo");
        var corrupt = new MatchEngine(definition);
        corrupt.ConfigureProjectiles((id,owner,target,tick)=>new(new BulletFlight(id,owner,slow,Vector3.Zero,target,tick,(o,d,r)=>null),new(float.NaN,CombatDamageType.Shot)),()=>1);
        Start(corrupt,a,b);
        Check(corrupt.Command(a,new MatchCommand { CommandId=2,Fire=new FireCommand { TargetX=20 } }).Code=="match-aborted" &&
            corrupt.Snapshot().Players[0].ClipAmmo==initialAmmo && !corrupt.Snapshot().RewardEligible,"malformed host damage aborts before shot debit");
        return count;
    }
    private static void Start(MatchEngine match,string a,string b)
    {
        match.Admit(a); match.Admit(b);
        foreach (var id in new[]{a,b}) match.Command(id,new MatchCommand { CommandId=1,Ready=new ReadyCommand { ManifestHash=match.ManifestHash } });
        match.Advance(60);
    }
}
