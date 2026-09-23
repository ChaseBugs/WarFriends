using War.BattleServer;
using System.Numerics;

internal static class BarrelChainTests
{
    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        void Reject(Action action){try{action();}catch(InvalidDataException){checks++;return;}
            throw new Exception("Invalid barrel chain input accepted.");}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        BarrelMutation[] Initial(RecoveredBattleMap map)=>content.Barrels.ForMap(map)
            .Select(b=>new BarrelMutation(b.ColliderIndex,b.GameObjectFileId,
                content.BarrelPolicy.MaxHealth(0),content.BarrelPolicy.MaxHealth(0),false,0)).ToArray();
        var park=content.Maps.Single(m=>m.Source.Contains("Park_Multiplayer",StringComparison.Ordinal));
        var parkInitial=Initial(park);
        int parkOrigin=content.Barrels.ForMap(park).Single(b=>b.SourcePath.EndsWith("/barrelPark",StringComparison.Ordinal)).ColliderIndex;
        var parkPlan=BarrelChainPlanner.Plan(park,content.BarrelOverlap,parkInitial,parkOrigin,100);
        var parkRepeat=BarrelChainPlanner.Plan(park,content.BarrelOverlap,parkInitial,parkOrigin,100);
        Check(parkPlan.Barrels.Count==4 &&
              parkPlan.Barrels.Select(x=>x.ColliderIndex).SequenceEqual([78,86,80,86]) &&
              parkPlan.Barrels[0]==
              new BarrelChainTransition(parkOrigin,-50,true,BarrelChainCause.Shot,null) &&
              parkPlan.Barrels[1].Cause==BarrelChainCause.Shiver && parkPlan.Barrels[1].Health>0 &&
              parkPlan.Barrels[2].Cause==BarrelChainCause.Explosion &&
              parkPlan.Barrels[3].Cause==BarrelChainCause.Shiver && parkPlan.Barrels[3].Destroyed,
              "Park chain preserves a nonlethal Shiver before nested explosion finishes that barrel");
        Check(parkPlan.Barrels.SequenceEqual(parkRepeat.Barrels) &&
              parkPlan.OtherTargets.SequenceEqual(parkRepeat.OtherTargets) &&
              parkPlan.OrderedEffects.SequenceEqual(parkRepeat.OrderedEffects) &&
              parkInitial.All(row=>row.Health==50 && !row.Destroyed && row.Revision==0),
              "barrel chain preview is deterministic and never publishes authority");
        Check(parkPlan.OrderedEffects.Select(x=>x.ColliderIndex).SequenceEqual([78,86,80,86]) &&
              parkPlan.OrderedEffects.All(x=>x.Health.HasValue) &&
              parkPlan.OrderedEffects.Select(x=>x.Health!.Value).SequenceEqual(
                  parkPlan.Barrels.Select(x=>x.Health)),
              "ordered barrel effects preserve the synchronous nested-death sequence");
        Check(parkPlan.Barrels.Count<=29*29 && parkPlan.OtherTargets.Count==0 &&
              parkPlan.Barrels.Where(x=>x.Destroyed).Select(x=>x.ColliderIndex).Distinct().Count()==3,
              "Park chain damages source barrels only and destroys each at most once");
        var parkCenter=park.DynamicColliders.Single(c=>c.ColliderIndex==parkOrigin).TransformPosition;
        var sourcePose=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0).Collision;
        var runProbe=content.Poses.Sample("run",0.3,true);
        var moveHits=new List<string>();
        int sampledRoutePoses=0;
        foreach(var candidateMap in content.Maps)
        foreach(var from in candidateMap.Covers)
        foreach(int direction in new[]{-1,1})
        {
            int to=candidateMap.Adjacent(from.SourceIndex,direction,from.Fraction);
            if(to<0)continue;
            var route=candidateMap.Path(from.SourceIndex,to);
            for(int segment=1;segment<route.Length;segment++)
            for(int sample=0;sample<=30;sample++)
            {
                Vector3 position=Vector3.Lerp(route[segment-1],route[segment],sample/30f);
                Vector3 delta=route[segment]-route[segment-1];delta.Y=0;
                if(delta.LengthSquared()<1e-8f)continue;
                var rotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(delta.X,delta.Z));
                var pose=runProbe.Place(position,rotation);
                sampledRoutePoses++;
                foreach(var barrel in content.Barrels.ForMap(candidateMap))
                {
                    var center=candidateMap.DynamicColliders.Single(c=>c.ColliderIndex==barrel.ColliderIndex).TransformPosition;
                    if(pose.Parts.Any(part=>part.OverlapsSphere(center,BarrelExplosion.HurtRadius)))
                        moveHits.Add($"{candidateMap.Source}:{from.SourceIndex}->{to}:{barrel.ColliderIndex}:{sample}");
                }
            }
        }
        Check(sampledRoutePoses>1000 && moveHits.Count==0,
            "sampled source cover routes do not enter a barrel blast with the host run collider");
        var playerStates=new[]{
            new BarrelExplosionPlayerState(Guid.NewGuid().ToString("N"),
                sourcePose.Place(parkCenter,Quaternion.Identity),new PlayerCombatManifest(1000),1000,false),
            new BarrelExplosionPlayerState(Guid.NewGuid().ToString("N"),
                sourcePose.Place(parkCenter+new Vector3(100,0,0),Quaternion.Identity),
                new PlayerCombatManifest(1000),1000,false)};
        var playerEffects=BarrelPlayerChainResolver.Resolve(park,parkPlan,playerStates,
            content.Explosions,()=>1);
        Check(playerEffects.Count>=2 && playerEffects.All(x=>x.PlayerId==playerStates[0].PlayerId) &&
              playerEffects.Select(x=>x.SourceBarrelIndex).SequenceEqual(
                  parkPlan.OrderedEffects.Where(x=>x.Destroyed && x.Health.HasValue)
                      .Select(x=>x.ColliderIndex).Where(id=>playerEffects.Any(effect=>effect.SourceBarrelIndex==id))) &&
              playerEffects.Zip(playerEffects.Skip(1)).All(pair=>pair.First.Damage.Health>=pair.Second.Damage.Health),
              "moving-pose explosion projection follows every barrel death and accumulates player HP");
        Check(playerStates[0].Health==1000 && playerStates[1].Health==1000,
              "explosion player chain does not publish preview health");
        var overtimeEffects=BarrelPlayerChainResolver.Resolve(park,parkPlan,playerStates,
            content.Explosions,()=>1,overtime:true);
        Check(overtimeEffects.Count==playerEffects.Count &&
              overtimeEffects.Zip(playerEffects).All(pair=>pair.First.PlayerId==pair.Second.PlayerId &&
                  pair.First.SourceBarrelIndex==pair.Second.SourceBarrelIndex) &&
              overtimeEffects[^1].Damage.Health>playerEffects[^1].Damage.Health,
              "source overtime explosive coefficient changes the same ordered player hits");
        var city=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var cityInitial=Initial(city);
        var cityPlans=cityInitial.Select(row=>BarrelChainPlanner.Plan(city,content.BarrelOverlap,
            cityInitial,row.ColliderIndex,100)).ToArray();
        Check(cityPlans.Sum(plan=>plan.OtherTargets.Count)>=1 && cityPlans.SelectMany(plan=>plan.OtherTargets)
              .All(hit=>city.DynamicColliders.Single(c=>c.ColliderIndex==hit.ColliderIndex)
                  .SourcePath.EndsWith("/beam",StringComparison.Ordinal)),
              "City chain reports the separate beam destroyable for later health authority");
        Check(cityPlans.All(plan=>plan.OrderedEffects.Count==
                  plan.Barrels.Count+plan.OtherTargets.Count) &&
              cityPlans.SelectMany(plan=>plan.OrderedEffects.Where(x=>!x.Health.HasValue))
                  .Select(x=>(x.ColliderIndex,x.Damage,x.Cause,x.SourceBarrelIndex))
                  .SequenceEqual(cityPlans.SelectMany(plan=>plan.OtherTargets)
                      .Select(x=>(x.ColliderIndex,x.Damage,x.Cause,(int?)x.SourceBarrelIndex))),
              "ordered effects retain nonbarrel targets without losing Unity overlap order");
        Check(cityPlans.SelectMany(plan=>plan.OtherTargets).All(hit=>
                  1e10f-hit.Damage==1e10f) &&
              1e10f-180f==1e10f,
              "City beam's serialized 1E+10 float HP cannot change from one barrel blast");
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,parkInitial,-1,100));
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,parkInitial,parkOrigin,float.NaN));
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,parkInitial[..^1],parkOrigin,100));
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,
            [..parkInitial,parkInitial[0]],parkOrigin,100));
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,
            [parkInitial[0] with {MaxHealth=float.NaN},..parkInitial[1..]],parkOrigin,100));
        Reject(()=>BarrelChainPlanner.Plan(park,content.BarrelOverlap,
            [parkInitial[0] with {Destroyed=true},..parkInitial[1..]],parkOrigin,100));
        int stationaryCoverOverlaps=0;
        foreach(var battleMap in content.Maps)
        foreach(var cover in battleMap.Covers)
        foreach(var b in content.Barrels.ForMap(battleMap))
        {
            var center=battleMap.DynamicColliders.Single(x=>x.ColliderIndex==b.ColliderIndex).TransformPosition;
            var currentPose=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0)
                .Place(cover.Position,cover.Rotation).Collision;
            if(currentPose.Parts.Any(x=>x.OverlapsSphere(center,BarrelExplosion.HurtRadius)))
                stationaryCoverOverlaps++;
        }
        Check(stationaryCoverOverlaps==0,
            "none of the 40 stationary source cover poses overlap a source barrel blast");
        return checks;
    }
}
