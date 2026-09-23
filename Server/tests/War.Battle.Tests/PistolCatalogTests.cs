using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class PistolCatalogTests
{
    internal static int Run(string directory)
    {
        int checks=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception(name);}
        var catalog=PistolCatalog.Load(Path.Combine(directory,"pistol-content-manifest.json"));
        Check(catalog.WeaponCount==6&&catalog.StageCount==306,"complete recovered pistol package");
        var expected=new Dictionary<string,(int Count,int Index)>{{"Google2u.Pistol_Berreta",(36,13)},
            {"Google2u.Pistol_DesertEagle",(66,0)},{"Google2u.Pistol_Jester",(76,52)},
            {"Google2u.Pistol_M1911",(46,29)},{"Google2u.Pistol_Magnum357",(56,39)},
            {"Google2u.Pistol_Remmington51",(26,12)}};
        foreach(var pair in expected)
        {
            var stage=catalog.Stage(pair.Key,0);var binding=catalog.Binding(pair.Key);var weaponManifest=catalog.CreateManifest(pair.Key,0);
            Check(catalog.Stage(pair.Key,pair.Value.Count-1).Index==pair.Value.Count-1&&binding.InventoryIndex==pair.Value.Index&&
                  binding.AnimationFamily==5&&Math.Abs(binding.FirstShotWaitSeconds-.1f)<.000001f,
                "source pistol lane and scene binding: "+pair.Key);
            Check(weaponManifest.ClipSize==stage.ClipSize&&weaponManifest.ReserveAmmo==int.MaxValue&&
                  Math.Abs(weaponManifest.CadenceSeconds-stage.CadenceSeconds)<.000001,
                "pistol manifest retains source clip and infinite reserve: "+pair.Key);
            Reject(()=>catalog.Stage(pair.Key,pair.Value.Count),"pistol stage overflow rejected: "+pair.Key);
        }
        var projectile=catalog.Prepare("Google2u.Pistol_M1911",0,1,new string('a',32),Vector3.Zero,new Vector3(1,0,0),1,1,(_,_,_)=>null);
        Check(projectile.WeaponSourceId=="Google2u.Pistol_M1911"&&projectile.Damage.Amount==catalog.Stage("Google2u.Pistol_M1911",0).Damage,
            "pistol projectile retains source damage and identity");
        Reject(()=>catalog.Prepare("Google2u.Pistol_M1911",0,1,"",Vector3.Zero,Vector3.One,1,0,(_,_,_)=>null),
            "pistol projectile rejects empty owner");

        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,
            Path.Combine(directory,"pistol-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest("Google2u.Pistol_M1911",0);
        var manifest=new MatchManifest("pistol-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.PistolRevision!,MatchManifest.PistolCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(100_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(100_000_000),0)]);
        var match=new MatchEngine(manifest,map,content);match.Admit(one);match.Admit(two);
        match.Command(one,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Command(two,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});match.Advance(60);
        Vector3 aim=match.CombatPose(two).Collision.Parts[1].Center;ulong command=2;
        Check(match.Command(one,new MatchCommand{CommandId=command++,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}}).Code=="shot-scheduled",
            "pistol first click follows recovered cover delay");
        for(ulong tick=61;tick<400&&match.Snapshot().Players[0].ReloadEndTick==0;tick++)
        {
            match.Advance(tick);var state=match.Snapshot().Players[0];
            if(state.ClipAmmo>0&&tick>=state.NextFireTick)
                match.Command(one,new MatchCommand{CommandId=command++,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
        }
        var reloading=match.Snapshot().Players[0];
        Check(reloading.ClipAmmo==0&&reloading.ReloadEndTick>reloading.NextFireTick&&reloading.ReserveAmmo==int.MaxValue,
            "empty pistol clip begins reload without consuming infinite reserve");
        for(ulong tick=match.Snapshot().ServerTick+1;tick<=reloading.ReloadEndTick;tick++)match.Advance(tick);
        var loaded=match.Snapshot().Players[0];
        Check(loaded.ClipAmmo==weapon.ClipSize&&loaded.ReserveAmmo==int.MaxValue&&loaded.ReloadEndTick==0,
            "pistol reload restores the source clip and preserves immutable infinite reserve");
        return checks;
    }
}
