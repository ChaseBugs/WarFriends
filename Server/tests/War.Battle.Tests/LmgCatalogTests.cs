using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class LmgCatalogTests
{
    internal static int Run(string directory)
    {
        int checks=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception(name);}
        var catalog=LmgCatalog.Load(Path.Combine(directory,"lmg-content-manifest.json"));
        Check(catalog.WeaponCount==8&&catalog.StageCount==398,"complete recovered burst-LMG package");
        var expected=new Dictionary<string,(int Count,int Index,int Family)>{{"Google2u.LMG_M249",(36,16,15)},
            {"Google2u.LMG_M249Elite",(76,48,15)},{"Google2u.LMG_M60",(66,36,15)},
            {"Google2u.LMG_M60Elite",(66,47,15)},{"Google2u.LMG_MG4",(56,23,15)},
            {"Google2u.LMG_PKMachinegun",(26,15,15)},{"Google2u.LMG_PKMachinegunElite",(26,66,15)},
            {"Google2u.LMG_SA80",(46,24,9)}};
        foreach(var pair in expected)
        {
            var stage=catalog.Stage(pair.Key,0);var binding=catalog.Binding(pair.Key);
            Check(catalog.Stage(pair.Key,pair.Value.Count-1).Index==pair.Value.Count-1&&stage.BurstSize==2&&
                  Math.Abs(stage.CadenceSeconds-.22f)<.000001f&&Math.Abs(stage.BurstLockSeconds-.11f)<.000001f,
                "source LMG lane and runtime two-round burst: "+pair.Key);
            Check(binding.InventoryIndex==pair.Value.Index&&binding.AnimationFamily==pair.Value.Family&&binding.BurstSize==5&&
                  Math.Abs(binding.SerializedBurstLockSeconds-.3f)<.000001f&&Math.Abs(binding.FirstShotWaitSeconds-.1f)<.000001f,
                "LMG retains serialized five-round defaults separately: "+pair.Key);
            Reject(()=>catalog.Stage(pair.Key,pair.Value.Count),"LMG stage overflow rejected: "+pair.Key);
        }
        var stage0=catalog.Stage("Google2u.LMG_M249",0);var burst=new SmgBurstScheduler();Vector3 target=new(1,2,3);
        burst.StartAfterFirstShot(100,target,stage0);
        Check(burst.Remaining==1&&burst.NextShotTick==107,"LMG queues one continuation at ceiling source cadence");
        for(ulong t=101;t<107;t++)burst.Advance(t,stage0);
        Check(burst.Advance(107,stage0)==target&&!burst.Active&&burst.LockThroughTick==111,
            "LMG emits exactly two rounds then applies strict source lock");

        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,
            Path.Combine(directory,"lmg-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest("Google2u.LMG_M249",0);
        var manifest=new MatchManifest("lmg-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.LmgRevision!,MatchManifest.LmgCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        var match=new MatchEngine(manifest,map,content);match.Admit(one);match.Admit(two);
        match.Command(one,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Command(two,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});match.Advance(60);
        Vector3 aim=match.CombatPose(two).Collision.Parts[1].Center;
        Check(match.Command(one,new MatchCommand{CommandId=2,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}}).Code=="shot-scheduled",
            "covered LMG input follows first-shot delay");
        ulong first=0;for(ulong t=61;t<=100&&match.Snapshot().Players[0].ShotsFired<2;t++)
        {match.Advance(t);if(first==0&&match.Snapshot().Players[0].ShotsFired==1)first=t;}
        var state=match.Snapshot().Players[0];
        Check(first>0&&state.ShotsFired==2&&state.ClipAmmo==weapon.ClipSize-2&&match.Snapshot().ServerTick==first+7,
            "one LMG input emits exactly two authoritative rounds at recovered cadence");
        return checks;
    }
}
