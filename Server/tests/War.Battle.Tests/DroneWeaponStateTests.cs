using System.Numerics;
using War.BattleServer;
internal static class DroneWeaponStateTests
{
    internal static int Run(DroneWeaponCatalog catalog)
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        int draws=0;var weapon=new DroneWeaponState(catalog,()=>{draws++;return 0;});
        weapon.Replace(Vector3.UnitZ,3,1);
        Check(weapon.Advance(.17f,Vector3.Zero,Quaternion.Identity)==null&&draws==3,
            "exact cadence deadline retains batch and random stream");
        var first=weapon.Advance(.2f,Vector3.Zero,Quaternion.Identity)!;
        Check(first.Batch.Index==0&&!first.Batch.IsFake&&weapon.LastShotTime==.2f,
            "eligible round publishes source last-shot clock");
        Check(first.Muzzle==catalog.Muzzle(Vector3.Zero,Quaternion.Identity),"shot uses verified muzzle");
        Check(weapon.Advance(.3f,Vector3.Zero,Quaternion.Identity)==null&&draws==3,
            "host tick cannot bypass source cadence");
        Check(weapon.Advance(.4f,Vector3.Zero,Quaternion.Identity)!.Batch.Index==1,
            "next cadence consumes exactly one round");
        Check(weapon.Advance(2,Vector3.Zero,Quaternion.Identity)!.Batch.EndsBatch&&!weapon.Shooting,
            "overdue observation emits one remaining shot without catchup");
        weapon.Replace(Vector3.UnitX,1,1);weapon.Reset();
        Check(weapon.LastShotTime==2&&weapon.Advance(3,Vector3.Zero,Quaternion.Identity)==null,
            "Reset cancels batch while retaining gun clock");
        weapon.Replace(Vector3.UnitZ,1,0);
        var fake=weapon.Advance(3,Vector3.Zero,Quaternion.Identity)!;
        Check(Vector3.Distance(fake.Batch.Target,new(-.3f,.3f,1))<1e-6f,
            "fake dispersion uses root rather than muzzle position");
        try{weapon.Advance(2,Vector3.Zero,Quaternion.Identity);throw new Exception("regressed clock accepted");}
        catch(InvalidDataException){count++;}
        return count;
    }
}
