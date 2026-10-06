using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class HelicopterShotgunTests
{
    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool yes,string name){if(!yes)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            Path.Combine(directory,"shotgun-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(x=>x.Main&&x.Fraction==1&&x.SourceIndex==2);
        var right=map.Covers.First(x=>x.Main&&x.Fraction==2);
        string one=new('a',32),two=new('b',32);
        var shotgun=content.Shotguns!.CreateManifest("Google2u.Shotgun_SPAS",35);
        var manifest=MatchManifest.Validate(new MatchManifest("helicopter-shotgun","local-1",
            "Park_Multiplayer",map.SourceHash,content.ShotgunRevision!,
            MatchManifest.ShotgunCombatMode,10,180,120,
            [new(one,shotgun,1,left.SourceIndex,1,new(1000),35,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},
             new(two,shotgun,2,right.SourceIndex,1,new(1000),35,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}])
            {SceneMasterPlayerId=one});
        content.ValidateAllocation(manifest);
        var match=new MatchEngine(manifest,content:content);
        match.Admit(one);match.Admit(two);
        foreach(var id in new[]{one,two})match.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Advance(60);
        Check(match.ArmyBatch(two).OptionIndexes.SequenceEqual([2,2,2])&&
              match.Command(two,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=2}}).Code=="army-deploying",
              "shotgun duel deploys a trusted combat Helicopter");
        ulong tick=60;BattleArmyEntityState? helicopter=null;
        while(tick<1800&&!match.Terminal)
        {
            match.Advance(++tick);
            helicopter=match.ArmyEntityBatch(one,0,0).Entities.SingleOrDefault(x=>
                x.UnitId=="ID_UNIT-HELICOPTER");
            if(helicopter is {HelicopterStopTick:>0})break;
        }
        Check(helicopter is {HelicopterStopTick:>0,HelicopterGunnerHealth:>0},
              "source Helicopter stop retains a live gunner in shotgun mode");
        var explosionParts=match.GroundVehicleShotTargets(one).Where(x=>
            x.EntityId==helicopter!.EntityKey&&x.HelicopterGunner).ToArray();
        Check(explosionParts.Length==3,"explosion sees one complete live gunner rig");
        float beforeExplosion=helicopter!.HelicopterGunnerHealth;
        var head=explosionParts.Single(x=>x.Hitbox.Weight==1.5f).Hitbox.Center;
        var selectedExplosionPart=explosionParts.Select((part,index)=>(part,index))
            .Where(value=>value.part.Hitbox.OverlapsSphere(head,2))
            .OrderBy(value=>value.part.Hitbox.BoundsDistanceToPoint(head))
            .ThenBy(value=>value.index).First().part;
        Check(selectedExplosionPart.Hitbox.Weight==1.5f,
            "gunner head collider is the selected explosion part for this damage proof");
        match.ApplyHelicopterGunnerExplosion(one,head+new Vector3(50,0,0),.25f,2,1,2,false);
        Check(match.ArmyEntityBatch(one,0,0).Entities.Single(x=>x.EntityKey==helicopter.EntityKey)
            .HelicopterGunnerHealth==beforeExplosion,"non-overlapping explosion cannot damage gunner");
        match.ApplyHelicopterGunnerExplosion(two,head,.25f,2,1,2,false);
        float afterFriendly=match.ArmyEntityBatch(one,0,0).Entities.Single(x=>x.EntityKey==helicopter.EntityKey)
            .HelicopterGunnerHealth;
        Check(Math.Abs(beforeExplosion-afterFriendly-1)<.0001f&&
              match.Snapshot().Players.Single(x=>x.PlayerId==two).ConfirmedEnemyHits==0,
              "source friendly explosion halves owner damage without bullet part weight or enemy-hit credit");
        match.ApplyHelicopterGunnerExplosion(one,head,.25f,2,1,2,false);
        helicopter=match.ArmyEntityBatch(one,0,0).Entities.Single(x=>x.EntityKey==helicopter.EntityKey);
        Check(Math.Abs((afterFriendly-helicopter.HelicopterGunnerHealth)-2)<.0001f&&
              match.Snapshot().Players.Single(x=>x.PlayerId==one).ConfirmedEnemyHits==1,
              "opposing explosion applies source owner damage once and one hit credit");
        float initial=helicopter!.HelicopterGunnerHealth;
        ulong commandId=2;bool damaged=false;int accepted=0;
        for(int attempt=0;attempt<35&&!damaged&&!match.Terminal;attempt++)
        {
            var parts=match.GroundVehicleShotTargets(one).Where(x=>
                x.EntityId==helicopter.EntityKey&&x.HelicopterGunner).ToArray();
            if(parts.Length!=3)throw new Exception("Gunner source hitboxes disappeared before shotgun hit.");
            var target=parts[attempt%parts.Length].Hitbox.Center;
            var shot=match.Command(one,new MatchCommand{CommandId=commandId++,
                Fire=new FireCommand{TargetX=target.X,TargetY=target.Y,TargetZ=target.Z}});
            if(shot.Code is "shot-scheduled" or "shot-accepted")accepted++;
            for(int i=0;i<15&&!match.Terminal;i++)match.Advance(++tick);
            var current=match.ArmyEntityBatch(one,0,0).Entities.Single(x=>
                x.EntityKey==helicopter.EntityKey);
            damaged=current.HelicopterGunnerHealth<initial;
        }
        Check(damaged&&accepted>0&&
              match.Snapshot().Players.Single(x=>x.PlayerId==one).ConfirmedEnemyHits>0,
              "source shotgun pellets can damage and credit the opposing Helicopter gunner");
        ulong cursor=0;bool impact=false;
        while(true)
        {
            var page=match.EventBatch(one,cursor);
            if(page.Events.Count==0)break;
            impact|=page.Events.Any(x=>x.Kind==MatchEventKind.Impact&&
                x.ActorId==one&&x.TargetId=="army:"+helicopter.EntityKey&&
                x.Reason=="helicopter-gunner");
            cursor=page.Events[^1].EventId;
        }
        Check(impact,"shotgun pellet publishes the source-bound gunner impact identity");
        return checks;
    }
}
