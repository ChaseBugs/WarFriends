using System.Numerics;
using War.BattleServer;

internal static class SmgCatalogTests
{
    internal static int Run(string directory)
    {
        int count=0;void Check(bool value,string name){if(!value)throw new Exception(name);count++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){count++;return;}throw new Exception(name);}
        var catalog=SmgCatalog.Load(Path.Combine(directory,"smg-content-manifest.json"));
        Check(catalog.WeaponCount==8&&catalog.StageCount==398,"complete recovered SMG stage package");
        Check(catalog.AlliesBulletMask!=0&&catalog.EnemiesBulletMask!=0&&catalog.AlliesBulletMask!=catalog.EnemiesBulletMask,
            "source SMG faction masks retained");
        var expected=new Dictionary<string,(int Stages,int Index,int Family)>(StringComparer.Ordinal)
        {
            ["Google2u.SMG_CPW"]=(36,18,5),["Google2u.SMG_MP5"]=(26,17,0),
            ["Google2u.SMG_MP7"]=(56,28,0),["Google2u.SMG_P90"]=(66,35,13),
            ["Google2u.SMG_UMP45"]=(46,9,0),["Google2u.SMG_MP5_elite"]=(26,43,0),
            ["Google2u.SMG_P90Elite"]=(66,49,13),["Google2u.SMG_Vector"]=(76,56,13)
        };
        foreach(var pair in expected)
        {
            var first=catalog.Stage(pair.Key,0);var last=catalog.Stage(pair.Key,pair.Value.Stages-1);
            var binding=catalog.Binding(pair.Key);var manifest=catalog.CreateManifest(pair.Key,0);
            Check(first.Index==0&&last.Index==pair.Value.Stages-1&&first.BurstSize==3&&
                  Math.Abs(first.BurstLockSeconds-.11f)<.000001f&&Math.Abs(first.CadenceSeconds-.11f)<.000001f,
                  "source SMG lane and burst definition: "+pair.Key);
            Check(binding.InventoryIndex==pair.Value.Index&&binding.AnimationFamily==pair.Value.Family&&
                  binding.BurstSize==3&&Math.Abs(binding.FirstShotWaitSeconds-.1f)<.000001f&&
                  Math.Abs(binding.Speed-30)<.000001f&&binding.BulletRevision.Length==64,
                  "source SMG scene binding: "+pair.Key);
            Check(manifest.SourceId==pair.Key&&manifest.ClipSize==first.ClipSize&&
                  manifest.ReserveAmmo==first.ReserveAmmo&&manifest.CadenceSeconds==first.CadenceSeconds,
                  "SMG manifest derives only from source stage: "+pair.Key);
            Reject(()=>catalog.Stage(pair.Key,pair.Value.Stages),"SMG rejects upgrade overflow: "+pair.Key);
        }
        Reject(()=>catalog.Stage("Google2u.SMG_missing",0),"unknown SMG rejected");
        Reject(()=>catalog.Stage("Google2u.SMG_MP5",-1),"negative SMG stage rejected");
        var normal=catalog.Prepare("Google2u.SMG_MP5",0,1,new string('a',32),Vector3.Zero,new Vector3(10,0,0),
            10,1,(_,_,_)=>null);
        var critical=catalog.Prepare("Google2u.SMG_MP5",0,2,new string('a',32),Vector3.Zero,new Vector3(10,0,0),
            10,0,(_,_,_)=>null);
        Check(normal.WeaponSourceId=="Google2u.SMG_MP5"&&normal.Damage.Amount==catalog.Stage("Google2u.SMG_MP5",0).Damage,
            "SMG projectile retains source and normal damage");
        Check(Math.Abs(critical.Damage.Amount-normal.Damage.Amount*2)<.0001f,
            "SMG projectile uses recovered critical multiplier");
        Reject(()=>catalog.Prepare("Google2u.SMG_MP5",0,3,"",Vector3.Zero,new Vector3(1,0,0),0,0,(_,_,_)=>null),
            "SMG projectile rejects empty owner");
        Reject(()=>catalog.Prepare("Google2u.SMG_MP5",0,3,new string('a',32),Vector3.Zero,new Vector3(1,0,0),0,float.NaN,(_,_,_)=>null),
            "SMG projectile rejects nonfinite roll");
        return count;
    }
}
