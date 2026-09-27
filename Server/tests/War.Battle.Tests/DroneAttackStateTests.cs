using System.Numerics;
using War.BattleServer;
internal static class DroneAttackStateTests
{
    internal static int Run(BattleCombatContent content)
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        Check(content.Army.ComposeDroneShot(0,null,null).ShieldHitProbability==0,
            "Drone shield probability comes from recovered ArmyUpgrades row");
        try
        {
            _=new DroneAttackState(0,content.Army.ComposeDroneShot(0,null,null) with {ShieldHitProbability=float.NaN},
                content.DroneWeapon,content.DroneProjectile,()=>0,(a,b)=>a);
            throw new Exception("invalid shield probability accepted");
        }
        catch(InvalidDataException){Check(true,"invalid composed shield authority rejected at attack boundary");}
        var draws=new Queue<float>([.2f,.9f,.5f,.5f,0,0]);int ranges=0,resolved=0;
        var state=new DroneAttackState(0,content.Army.ComposeDroneShot(0,null,null),content.DroneWeapon,
            content.DroneProjectile,()=>draws.Dequeue(),(minimum,maximum)=>{ranges++;return minimum;});
        var target=new DroneTargetCandidate("decoy:1",2,true,true,true,null,new(0,0,9));
        DroneTargetDetails Resolve(DroneTargetCandidate row)
        {resolved++;return new([new(1,1,row.Position)],false,row.Position,Vector3.Zero,false,Vector3.UnitX);}
        Check(!state.Prepare(2,true,1,Vector3.Zero,Quaternion.Identity,[target],_=>true,Resolve)&&resolved==0&&draws.Count==6,
            "exact Drone spawn deadline consumes no target or random work");
        Check(state.Prepare(2.1f,true,1,Vector3.Zero,Quaternion.Identity,[target],_=>true,Resolve)&&
            state.TargetId==target.Id&&ranges==1&&draws.Count==3&&state.Deadline==5,
            "source batch masks precede interval draw and deadline advances from prior value");
        var expected=DroneShotTargetPolicy.Predict(content.DroneWeapon.Muzzle(Vector3.Zero,Quaternion.Identity),target.Position,Vector3.UnitX,9,1);
        var shot=state.Weapon.Advance(2.1f,Vector3.Zero,Quaternion.Identity)!;
        Check(!shot.Batch.IsFake&&shot.Batch.Target==expected,"prepared nonplayer batch binds source velocity prediction");
        Check(state.Prepare(5.1f,true,1,Vector3.Zero,Quaternion.Identity,[],_=>true,Resolve)&&
            state.TargetId==null&&state.Weapon.Shooting&&draws.Count==2,
            "no-target attempt still advances deadline without canceling previous batch");
        Check(state.Weapon.Advance(5.1f,Vector3.Zero,Quaternion.Identity)!.Batch.IsFake&&draws.Count==0,
            "retained fake round consumes dispersion samples after later interval draw");
        var playerDraws=new Queue<float>([.8f,.1f,.2f,.5f]);
        var player=new DroneAttackState(0,content.Army.ComposeDroneShot(0,null,null),content.DroneWeapon,
            content.DroneProjectile,()=>playerDraws.Dequeue(),(minimum,maximum)=>minimum);
        var playerTarget=target with {Id="player:1",IsDecoy=false};
        player.Prepare(2.1f,true,1,Vector3.Zero,Quaternion.Identity,[playerTarget],_=>true,
            r=>new([new(1,2,r.Position),new(2,1,r.Position+Vector3.UnitY)],true,r.Position,-Vector3.UnitZ,true,Vector3.One));
        Check(player.PlayerTarget&&playerDraws.Count==0&&
            player.Weapon.Advance(2.1f,Vector3.Zero,Quaternion.Identity)!.Batch.Target==playerTarget.Position+Vector3.UnitY,
            "player preparation consumes shield draw first and forces zero prediction velocity");
        var shieldDraws=new Queue<float>([0,.1f,.9f,.5f,0,0]);
        var shield=new DroneAttackState(0,content.Army.ComposeDroneShot(0,null,null),content.DroneWeapon,
            content.DroneProjectile,()=>shieldDraws.Dequeue(),(minimum,maximum)=>minimum);
        shield.Prepare(2.1f,true,1,Vector3.Zero,Quaternion.Identity,[playerTarget],_=>true,
            r=>new([new(1,2,r.Position),new(2,1,r.Position+Vector3.UnitY)],true,r.Position,-Vector3.UnitZ,true,Vector3.Zero));
        var shieldShot=shield.Weapon.Advance(2.1f,Vector3.Zero,Quaternion.Identity)!;
        Check(shieldShot.IsShield&&!shieldShot.Batch.IsFake,"exact Shield target preserves real ammunition type");
        var fakeShield=shield.Weapon.Advance(2.3f,Vector3.Zero,Quaternion.Identity)!;
        Check(fakeShield.IsShield&&fakeShield.Batch.IsFake&&shieldDraws.Count==0,
            "fake presentation flag does not erase stored Shield ammunition type");
        shieldDraws.Enqueue(0);
        shield.Weapon.Replace(Vector3.UnitZ,1,1);
        Check(!shield.Weapon.Advance(2.5f,Vector3.Zero,Quaternion.Identity)!.IsShield,
            "replacement body batch clears prior Shield ammunition type");
        var projectileDraws=new Queue<float>([0,.2f,.3f,.4f,.5f]);
        var emitted=new DroneAttackState(0,content.Army.ComposeDroneShot(0,null,null),content.DroneWeapon,
            content.DroneProjectile,()=>projectileDraws.Dequeue(),(a,b)=>a);
        emitted.Weapon.Replace(Vector3.UnitZ,1,1);
        var intent=emitted.AdvanceProjectile(1,Vector3.Zero,Quaternion.Identity,42.96f)!;
        Check(intent.Speed==9&&intent.Damage==42.96f&&!intent.Critical&&projectileDraws.Count==3,
            "real Drone projectile consumes zero-probability critical draw and composed damage");
        emitted.Weapon.Replace(Vector3.UnitZ,0,0);
        var fakeIntent=emitted.AdvanceProjectile(1.2f,Vector3.Zero,Quaternion.Identity,42.96f)!;
        Check(fakeIntent.Shot.Batch.IsFake&&fakeIntent.Speed==13.5f&&projectileDraws.Count==0,
            "fake Drone projectile consumes dispersion then critical sample and source fake speed");
        emitted.Weapon.Replace(Vector3.UnitZ,0,0);
        projectileDraws.Enqueue(0);projectileDraws.Enqueue(0);
        Check(emitted.AdvanceProjectile(1.4f,Vector3.Zero,Quaternion.Identity,42.96f,false)==null&&
            emitted.Weapon.LastShotTime==1.4f&&projectileDraws.Count==0,
            "unavailable ammo advances weapon clock without consuming setup critical draw");
        return count;
    }
}

