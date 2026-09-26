using War.BattleServer;

internal static class ShieldLifecycleTests
{
    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool ok,string reason){if(!ok)throw new Exception(reason);checks++;}
        void Reject(Action action){try{action();}catch(InvalidDataException){checks++;return;}
            throw new Exception("Invalid shield authority accepted.");}
        var policy=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json")).Shields;
        Check(policy.DestroyInOvertime,"recovered DeathMatch overtime destroys shields");
        var shield=new ShieldLifecycle(policy,0,10);
        Check(shield.Health==560 && shield.ColliderEnabled,"rank-zero shield begins at recovered HP");
        shield.ApplyShot("Google2u.Shotgun_SPAS",100,10);
        Check(shield.Health==460 && shield.ColliderEnabled,"source weapon coefficient damages live shield");
        shield.Advance(11);
        Check(shield.Health==460,"shield does not passively regenerate by default");
        shield.HasPlayer=true;shield.CanRegenerate=true;
        shield.Advance(12);
        Check(shield.Health>460 && shield.Health<466,"source 30 Hz respawn rate requires owner and gate");
        shield.ApplyShot("Google2u.Shotgun_SPAS",1000,12);
        Check(shield.Destroyed && !shield.ColliderEnabled && shield.Health==0 && shield.DestroyedTick==12,
              "lethal shot removes shield collider at host tick");
        for(ulong tick=13;tick<192;tick++)shield.Advance(tick);
        Check(shield.Destroyed && !shield.ColliderEnabled,"destroyed shield remains absent before six seconds");
        shield.Advance(192);
        Check(!shield.Destroyed && shield.ColliderEnabled && shield.Health==560,
              "source repair delay restores full HP and collider");
        Reject(()=>shield.ApplyShot("unknown",1,192));
        Reject(()=>shield.ApplyShot("Google2u.Shotgun_SPAS",float.NaN,192));
        Reject(()=>shield.Advance(194));
        var unitShield=new ShieldLifecycle(policy,0,20);
        unitShield.ApplyUnitShot(25,20);
        Check(unitShield.Health==485,
            "source UnitToShieldCoef applies three-times army projectile damage");
        Reject(()=>unitShield.ApplyUnitShot(float.NaN,20));
        var disabled=new ShieldLifecycle(policy,43,0){AutoRepair=false};
        disabled.ApplyShot("Google2u.Shotgun_SPAS",10000,0);
        for(ulong tick=1;tick<=181;tick++)disabled.Advance(tick);
        Check(disabled.Destroyed && disabled.MaxHealth==4626,"disabled auto repair preserves destroyed shield");
        Reject(()=>new ShieldLifecycle(policy,44,0));
        return checks;
    }
}
