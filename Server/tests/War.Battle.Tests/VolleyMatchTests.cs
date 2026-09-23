using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class VolleyMatchTests
{
    internal static int Run(MatchManifest source)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        var duel=source with { Players=source.Players.Select((p,i)=>p with
            { Fraction=i+1,Combat=new PlayerCombatManifest(100),Weapon=p.Weapon with {ClipSize=9} }).ToArray() };
        string a=duel.Players[0].PlayerId,b=duel.Players[1].PlayerId;
        static PreparedProjectile Pellet(ulong id,string owner,Vector3 target,ulong tick,float amount)
            => new(new BulletFlight(id,owner,new(30,1,true),Vector3.Zero,target,tick,(_,_,_)=>null),
                new ResolvedPlayerDamage(amount,CombatDamageType.Shot));
        static void Start(MatchEngine match,string a,string b)
        {
            match.Admit(a);match.Admit(b);
            foreach(var id in new[]{a,b})match.Command(id,new MatchCommand{CommandId=1,
                Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
            match.Advance(60);
        }
        var match=new MatchEngine(duel);
        int prepared=0;
        match.ConfigureVolley((id,owner,target,tick)=>{prepared++;return [Pellet(id,owner,target,tick,10),
            Pellet(id+1,owner,target,tick,20)];},()=>1);
        Start(match,a,b);
        var fire=new MatchCommand{CommandId=2,Fire=new FireCommand{TargetX=5}};
        Check(match.Command(a,fire).Code=="shot-accepted" && match.PendingProjectileCount==2 &&
              match.Snapshot().Players[0].ClipAmmo==8 && match.Snapshot().Players[0].ShotsFired==1,
              "two projectiles consume one shotgun shell");
        Check(match.Command(a,fire).Code=="shot-accepted" && match.PendingProjectileCount==2 && prepared==1,
              "replayed command does not create a second volley");
        var batch=match.EventBatch(a,0);
        Check(batch.Events.Count==2 && batch.Events[0].ProjectileId+1==batch.Events[1].ProjectileId,
              "consecutive pellet identities have distinct shot events");
        var corrupt=new MatchEngine(duel);
        corrupt.ConfigureVolley((id,owner,target,tick)=>[Pellet(id,owner,target,tick,10),
            Pellet(id+1,owner,target,tick,float.NaN)],()=>1);
        Start(corrupt,a,b);
        Check(corrupt.Command(a,fire).Code=="match-aborted" && corrupt.PendingProjectileCount==0 &&
              corrupt.Snapshot().Players[0].ClipAmmo==9 && corrupt.Snapshot().Players[0].ShotsFired==0,
              "bad second pellet aborts before any flight, shot or ammo mutation");
        var oversized=new MatchEngine(duel);
        oversized.ConfigureVolley((id,owner,target,tick)=>Enumerable.Range(0,9)
            .Select(i=>Pellet(id+(ulong)i,owner,target,tick,1)).ToArray(),()=>1);
        Start(oversized,a,b);
        Check(oversized.Command(a,fire).Code=="match-aborted" && oversized.PendingProjectileCount==0 &&
              oversized.Snapshot().Players[0].ClipAmmo==9,"volley size is bounded before admission");
        return checks;
    }
}
