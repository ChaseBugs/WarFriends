using System.Text.Json;
using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Numerics;
using War.BattleServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.Protocol;

internal static class CombatContentTests
{
    internal static int Run(string directory)
    {
        int count=0;
        void Check(bool ok,string name) { if (!ok) throw new Exception(name);count++; }
        void Reject(Action action) { try { action(); } catch (InvalidDataException) { count++;return; } throw new Exception("Invalid combat allocation accepted."); }
        Vector3 Vec(JsonElement value)=>new(value.GetProperty("x").GetSingle(),
            value.GetProperty("y").GetSingle(),value.GetProperty("z").GetSingle());
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var navArtifact=Path.Combine(directory,"recovered-army-navmesh-sources.json");
        var navPin=JsonSerializer.Deserialize<CombatContentManifest>(
            File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
        string allWeaponArtifact=Path.Combine(directory,"recovered-all-weapon-bindings.json");
        Check(content.AllWeaponBindings.Count==66 &&
              content.AllWeaponBindings.Get("Google2u.AssaultRifle_AK47").PlayerWeaponType=="PlayerClickWeapon" &&
              content.AllWeaponBindings.Get("Google2u.SMG_Vector").PlayerWeaponType=="PlayerBurstWeapon" &&
              content.AllWeaponBindings.Get("Google2u.SniperRifle_MSR").PlayerWeaponType=="PlayerZoomOnTouchWeapon" &&
              content.AllWeaponBindings.Get("Google2u.Grenade_M84").MuzzlePath==
                  content.AllWeaponBindings.Get("Google2u.Grenade_M84").WeaponPath &&
              navPin.AllWeaponBindingsRevision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(allWeaponArtifact))),
              "all 66 recovered weapon definitions bind unique inventory, controller, muzzle and projectile identities");
        string allWeaponTemp=Path.Combine(Path.GetTempPath(),"war-all-weapons-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var changed=JsonNode.Parse(File.ReadAllText(allWeaponArtifact))!;
            changed["weapons"]![1]!["inventoryIndex"]=changed["weapons"]![0]!["inventoryIndex"]!.GetValue<int>();
            File.WriteAllText(allWeaponTemp,changed.ToJsonString());
            Reject(()=>WeaponBindingGraphCatalog.Load(allWeaponTemp,
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(allWeaponTemp))),navPin.SceneRevision,
                Path.Combine(directory,"recovered-battle-content.json")));
        }
        finally {if(File.Exists(allWeaponTemp))File.Delete(allWeaponTemp);}
        var rusherPointArtifact=Path.Combine(directory,"recovered-army-rusher-points.json");
        Check(navPin.ArmyRusherPointsRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(rusherPointArtifact))) &&
              content.Maps.All(map=>
              {
                  var points=Enumerable.Range(0,8)
                      .SelectMany(i=>content.ArmyRusherPoints.ForCover(map,i)).ToArray();
                  return points.Length==32 &&
                      points.Count(p=>content.ArmyRusherPoints.NearNeighbour(map,
                          p.ComponentFileId)!=null)==24;
              }),
              "all five pinned Rusher scenes recover 24 directed near-neighbour links each");
        foreach(var map in content.Maps)
        {
            var points=Enumerable.Range(0,8)
                .SelectMany(i=>content.ArmyRusherPoints.ForCover(map,i)).ToArray();
            var candidate=points.First(p=>content.ArmyRusherPoints.NearNeighbour(map,
                p.ComponentFileId)!=null);
            int near=content.ArmyRusherPoints.NearNeighbour(map,candidate.ComponentFileId)!.Value;
            var nearPoint=points.Single(p=>p.ComponentFileId==near);
            var unrelated=points.First(p=>p.ComponentFileId!=near &&
                p.ComponentFileId!=candidate.ComponentFileId);
            Check(content.ArmyRusherPoints.IsFreeWithNearNeighbour(map,candidate,nearPoint,
                      id=>id==near) &&
                  !content.ArmyRusherPoints.IsFreeWithNearNeighbour(map,candidate,unrelated,
                      id=>id==near) &&
                  !content.ArmyRusherPoints.IsFreeWithNearNeighbour(map,candidate,nearPoint,
                      id=>id==candidate.ComponentFileId),
                  "source near-neighbour occupancy permits transfer from its own point only");
        }
        string rusherPointTemp=Path.Combine(Path.GetTempPath(),
            "war-rusher-points-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var changed=JsonNode.Parse(File.ReadAllText(rusherPointArtifact))!;
            changed["maps"]![0]!["covers"]![0]!["playerPointWorldPosition"]![0]=999f;
            File.WriteAllText(rusherPointTemp,changed.ToJsonString());
            string revised=Convert.ToHexStringLower(SHA256.HashData(
                File.ReadAllBytes(rusherPointTemp)));
            Reject(()=>ArmyRusherPointCatalog.Load(rusherPointTemp,revised,content.Maps));
        }
        finally {if(File.Exists(rusherPointTemp))File.Delete(rusherPointTemp);}
        Check(navPin.ArmyNavMeshSourcesRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(navArtifact))) &&
              content.ArmyNavMeshes.Maps.Count==5 &&
              content.Maps.All(m=>content.ArmyNavMeshes.ForMap(m).SceneRevision==m.SourceHash),
              "all five multiplayer scenes bind distinct packaged Unity NavMesh binaries");
        var trianglesArtifact=Path.Combine(directory,"recovered-navmesh-triangulation.json");
        Check(navPin.ArmyNavMeshTriangulationRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(trianglesArtifact))) &&
              content.ArmyNavMeshGeometry.Maps.Count==5 &&
              content.ArmyNavMeshGeometry.Maps.Sum(m=>m.Indices.Count/3)==9658 &&
              content.Maps.All(m=>content.ArmyNavMeshGeometry.ForMap(m).Vertices.Count>2000),
              "Unity 2018 exports 9,658 pinned walkable triangles across the five source maps");
        var pathsArtifact=Path.Combine(directory,"recovered-navmesh-path-manifest.json");
        Check(navPin.ArmyNavMeshPathsRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(pathsArtifact))) &&
              content.ArmyNavMeshPaths.Count==432 && content.ArmyNavMeshPaths.PartialCount==16 &&
              content.Maps.Where(m=>!m.Source.Contains("Snow_Multiplayer",StringComparison.Ordinal))
                  .All(m=>content.ArmyNavMeshPaths.ForMap(m).All(p=>p.Complete)) &&
              content.ArmyNavMeshPaths.ForMap(content.Maps.Single(m=>
                  m.Source.Contains("Snow_Multiplayer",StringComparison.Ordinal)))
                  .Where(p=>!p.Complete).All(p=>p.SpawnFileId==3042),
              "Unity path probes preserve 416 complete routes and 16 partial Snow spawn routes");
        using var motionManifest=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"recovered-navmesh-motion.json")));
        var motionPin=motionManifest.RootElement;
        Check(motionPin.GetProperty("version").GetInt32()==2 &&
              motionPin.GetProperty("pathManifestSha256").GetString()==navPin.ArmyNavMeshPathsRevision &&
              motionPin.GetProperty("infantryPrefabSha256").GetString()==
                  content.Army.InfantryAgent.PrefabSha256 &&
              motionPin.GetProperty("fixtures").GetArrayLength()==8,
              "eight Unity Play Mode trajectories bind the pinned path and infantry sources");
        foreach(var fixture in motionPin.GetProperty("fixtures").EnumerateArray())
        {
            var scene=fixture.GetProperty("scene").GetString()!;
            var caseId=fixture.GetProperty("caseId").GetString()!;
            var motionFile=Path.Combine(directory,fixture.GetProperty("file").GetString()!);
            var motionMap=content.Maps.Single(m=>m.Source==scene);
            float runtimeSpeed=fixture.GetProperty("runtimeSpeed").GetSingle();
            var ids=caseId.Split('-').Select(int.Parse).ToArray();
            var motionRoute=content.ArmyNavMeshPaths.ForMap(motionMap)
                .Single(p=>p.SpawnFileId==ids[0] && p.RusherFileId==ids[1]);
            Check(fixture.GetProperty("sha256").GetString()==Convert.ToHexStringLower(
                      SHA256.HashData(File.ReadAllBytes(motionFile))) &&
                  fixture.GetProperty("navMeshSha256").GetString()==
                      content.ArmyNavMeshes.ForMap(motionMap).Revision &&
                  (runtimeSpeed==1f || runtimeSpeed==.9f || runtimeSpeed==.8f) &&
                  fixture.GetProperty("perkSpeedCoefficient").GetSingle()==1f,
                  $"{scene} Unity trajectory source identities are pinned");
            using var motionDocument=JsonDocument.Parse(File.ReadAllBytes(motionFile));
            var motion=motionDocument.RootElement;
            Check(!motion.TryGetProperty("runtimeSpeed",out var observedSpeed) ||
                  observedSpeed.GetSingle()==runtimeSpeed,
                  $"{scene} Unity agent speed matches fixture metadata");
            var motionSamples=motion.GetProperty("samples").EnumerateArray().ToArray();
            var motionEnd=motion.GetProperty("sampledEnd");
            var motionLast=motionSamples[^1].GetProperty("position");
            double motionGap=Math.Sqrt(Math.Pow(motionLast.GetProperty("x").GetDouble()-
                motionEnd.GetProperty("x").GetDouble(),2)+Math.Pow(
                motionLast.GetProperty("z").GetDouble()-motionEnd.GetProperty("z").GetDouble(),2));
            Check(motion.GetProperty("status").GetString()=="Arrived" &&
                  motion.GetProperty("scene").GetString()==scene &&
                  motion.GetProperty("caseId").GetString()==caseId &&
                  motionSamples.Length==fixture.GetProperty("sampleCount").GetInt32() &&
                  motionSamples.Length is >= 100 and <= 1000 &&
                  motionSamples[0].GetProperty("time").GetDouble()==0 &&
                  motionSamples[^1].GetProperty("time").GetDouble()==
                      fixture.GetProperty("durationSeconds").GetDouble() &&
                  motionGap<.04 &&
                  motionSamples.Zip(motionSamples.Skip(1),(a,b)=>
                      b.GetProperty("time").GetDouble()>a.GetProperty("time").GetDouble()).All(x=>x),
                  $"{scene} Unity trajectory reaches source arrival gate");
            var hostMotionCorridor=content.ArmyNavMeshConnectivity.PlanCorridor(motionMap,
                motionRoute.SampledStart,motionRoute.SampledEnd);
            if(caseId=="3296-3089")
            {
                var sourcePolyline=content.ArmyNavMeshConnectivity.InspectPolyline(
                    motionMap,motionRoute.Corners);
                Check(sourcePolyline.PlanarCovered &&
                      sourcePolyline.MaxVerticalDeviation<=.05f,
                      "City Unity corner path is covered by the recovered walkable mesh");
            }
            Check(hostMotionCorridor is {PlanarCovered:true} &&
                  hostMotionCorridor.SmoothedPoints[0]==motionRoute.SampledStart &&
                  hostMotionCorridor.SmoothedPoints[^1]==motionRoute.SampledEnd,
                  $"{scene} host motion comparison binds source route endpoints");
            var hostMotion=new ArmyNavMeshMotionState(hostMotionCorridor!,
                content.Army.InfantryAgent,runtimeSpeed);
            var trajectoryErrors=new List<float>();
            // Unity resolves its first path asynchronously; align at first moving frame.
            double motionStart=motionSamples.First(sample=>
            {
                var velocity=sample.GetProperty("velocity");
                return Math.Sqrt(Math.Pow(velocity.GetProperty("x").GetDouble(),2)+
                    Math.Pow(velocity.GetProperty("z").GetDouble(),2))>.1;
            }).GetProperty("time").GetDouble()-1d/MatchManifest.TickRate;
            int hostMotionTick=0;
            foreach(var sample in motionSamples)
            {
                double time=sample.GetProperty("time").GetDouble();
                while(motionStart+(hostMotionTick+1d)/MatchManifest.TickRate<=time)
                {hostMotion.AdvanceTick();hostMotionTick++;}
                var position=sample.GetProperty("position");
                trajectoryErrors.Add(Vector2.Distance(new(hostMotion.Position.X,hostMotion.Position.Z),
                    new(position.GetProperty("x").GetSingle(),position.GetProperty("z").GetSingle())));
            }
            trajectoryErrors.Sort();
            Console.WriteLine($"{scene} Unity duration {motionSamples[^1].GetProperty("time").GetDouble():F2}s, " +
                $"host path {hostMotionCorridor!.SmoothedLength:F2}; error median " +
                $"{trajectoryErrors[trajectoryErrors.Count/2]:F3}, " +
                $"p95 {trajectoryErrors[(int)(trajectoryErrors.Count*.95)]:F3}, " +
                $"max {trajectoryErrors[^1]:F3}; host arrived {hostMotion.Arrived}");
            bool boundedMotion=trajectoryErrors.All(float.IsFinite) &&
                hostMotion.Speed<=runtimeSpeed && hostMotion.Traveled>0 &&
                hostMotion.Traveled<=hostMotion.Length;
            bool nearUnity=trajectoryErrors[trajectoryErrors.Count/2]<=.25f &&
                trajectoryErrors[(int)(trajectoryErrors.Count*.95)]<=.40f &&
                trajectoryErrors[^1]<=.40f && hostMotion.Arrived;
            Check(boundedMotion && nearUnity &&
                  (caseId!="2675-2698" ||
                   (trajectoryErrors[(int)(trajectoryErrors.Count*.95)]<=.15f &&
                    trajectoryErrors[^1]<=.15f)) &&
                  (caseId!="3251-3429" || runtimeSpeed!=1f ||
                   trajectoryErrors[^1]<=.25f) &&
                  (caseId!="3251-3429" || runtimeSpeed!=.8f ||
                   trajectoryErrors[^1]<=.20f) &&
                  (caseId!="3251-3429" || runtimeSpeed!=.9f ||
                   trajectoryErrors[^1]<=.23f) &&
                  (caseId!="3296-3089" ||
                   (hostMotionCorridor.SmoothedLength<=15.1f &&
                    trajectoryErrors[^1]<=.26f)),
                  $"{scene} candidate infantry motion stays near Unity frames and arrives");
            var stoppedPosition=hostMotion.Position;
            if(hostMotion.Arrived)
            {
                hostMotion.AdvanceTick();
                Check(hostMotion.Position==stoppedPosition,
                      $"{scene} arrived candidate infantry does not drift");
            }
            var rusherArrival=new ArmyRusherArrivalState(hostMotionCorridor,
                content.Army.InfantryAgent,runtimeSpeed);
            var blockedPosition=rusherArrival.Position;
            Check(!rusherArrival.TryAdvanceTick((_,_)=>false) &&
                  rusherArrival.Position==blockedPosition &&
                  rusherArrival.Phase==ArmyRusherTravelPhase.Walking &&
                  rusherArrival.TryAdvanceTick((_,_)=>true) &&
                  rusherArrival.Position!=blockedPosition,
                  $"{scene} blocked Rusher tick retains movement and arrival state");
            int walkingTicks=0;
            while(rusherArrival.Phase==ArmyRusherTravelPhase.Walking && walkingTicks<1000)
            {rusherArrival.AdvanceTick();walkingTicks++;}
            var atGate=rusherArrival.Position;
            Check(rusherArrival.Phase==ArmyRusherTravelPhase.Settling &&
                  Vector2.Distance(new(atGate.X,atGate.Z),new(
                      hostMotionCorridor.SmoothedPoints[^1].X,
                      hostMotionCorridor.SmoothedPoints[^1].Z))<.04f &&
                  !rusherArrival.InitialShotDelayElapsed,
                  $"{scene} walking Rusher enters the strict source arrival gate");
            for(int settleTick=0;settleTick<MatchManifest.TickRate/2;settleTick++)
                rusherArrival.AdvanceTick();
            Check(rusherArrival.Phase==ArmyRusherTravelPhase.Rusher &&
                  Vector2.Distance(new(rusherArrival.Position.X,rusherArrival.Position.Z),
                      new(hostMotionCorridor.SmoothedPoints[^1].X,
                          hostMotionCorridor.SmoothedPoints[^1].Z))<.00001f &&
                  rusherArrival.Position.Y==atGate.Y &&
                  !rusherArrival.InitialShotDelayElapsed,
                  $"{scene} Rusher settles over 0.5 seconds before initial shot delay expires");
            rusherArrival.AdvanceTick();
            Check(rusherArrival.InitialShotDelayElapsed,
                  $"{scene} Rusher shot delay uses the source strict greater-than gate");
            Reject(()=>new ArmyNavMeshMotionState(hostMotionCorridor,content.Army.InfantryAgent,float.NaN));
            Reject(()=>new ArmyNavMeshMotionState(hostMotionCorridor with {PlanarCovered=false},
                content.Army.InfantryAgent,1f));
        }
        using var crowdManifest=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"recovered-navmesh-crowd.json")));
        var crowdPin=crowdManifest.RootElement;
        var parkCrowd=content.Maps.Single(m=>m.Source.Contains("Park_Multiplayer",StringComparison.Ordinal));
        string crowdFile=Path.Combine(directory,"navmesh-motion","park-crowd-result.json");
        Check(crowdPin.GetProperty("version").GetInt32()==1 &&
              crowdPin.GetProperty("pathManifestSha256").GetString()==navPin.ArmyNavMeshPathsRevision &&
              crowdPin.GetProperty("navMeshSha256").GetString()==
                  content.ArmyNavMeshes.ForMap(parkCrowd).Revision &&
              crowdPin.GetProperty("resultSha256").GetString()==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(crowdFile))) &&
              crowdPin.GetProperty("infantryPrefabSha256").GetString()==
                  content.Army.InfantryAgent.PrefabSha256,
              "two-agent Unity crowd trace binds the same Park NavMesh and infantry prefab");
        using var crowdDocument=JsonDocument.Parse(File.ReadAllBytes(crowdFile));
        var crowdCases=crowdDocument.RootElement.GetProperty("cases").EnumerateArray().ToArray();
        var crowdSamples=crowdCases.Select(c=>c.GetProperty("samples").EnumerateArray().ToArray()).ToArray();
        var crowdMotions=new ArmyNavMeshMotionState[2];
        var observedCornerMotions=new ArmyNavMeshMotionState[2];
        for(int i=0;i<2;i++)
        {
            var ids=crowdCases[i].GetProperty("id").GetString()!.Split('-').Select(int.Parse).ToArray();
            var sourceRoute=content.ArmyNavMeshPaths.ForMap(parkCrowd).Single(p=>
                p.SpawnFileId==ids[0] && p.RusherFileId==ids[1]);
            var route=content.ArmyNavMeshConnectivity.PlanCorridor(parkCrowd,
                sourceRoute.SampledStart,sourceRoute.SampledEnd);
            Check(route is {PlanarCovered:true} && crowdCases[i].GetProperty("status").GetString()=="Arrived" &&
                  crowdSamples[i].Length==crowdPin.GetProperty("sampleCountPerAgent").GetInt32(),
                  "Unity crowd agent retains its complete source-bound Rusher route");
            crowdMotions[i]=new ArmyNavMeshMotionState(route!,content.Army.InfantryAgent,.9f);
            var cornerAudit=content.ArmyNavMeshConnectivity.InspectPolyline(parkCrowd,sourceRoute.Corners);
            var observedCorridor=content.ArmyNavMeshConnectivity.PlanSourceSpawnCorridor(parkCrowd,
                ids[0],ids[1],sourceRoute.Start,sourceRoute.End);
            Check(cornerAudit.PlanarCovered && observedCorridor is {PlanarCovered:true} &&
                  observedCorridor.SmoothedPoints.Count==sourceRoute.Corners.Count &&
                  observedCorridor.SmoothedPoints[0]==sourceRoute.Start &&
                  observedCorridor.SmoothedPoints[^1]==sourceRoute.End,
                  "Unity observed crowd corner route remains inside the walkable NavMesh");
            observedCornerMotions[i]=new ArmyNavMeshMotionState(observedCorridor!,
                content.Army.InfantryAgent,.9f);
        }
        double startTime=crowdSamples.Select(samples=>samples.First(sample=>
        {
            var velocity=sample.GetProperty("velocity");
            return Math.Sqrt(Math.Pow(velocity.GetProperty("x").GetDouble(),2)+
                Math.Pow(velocity.GetProperty("z").GetDouble(),2))>.1;
        }).GetProperty("time").GetDouble()).Min()-1d/MatchManifest.TickRate;
        int crowdTick=0;float hostMinimum=float.MaxValue,hostMaximumError=0;
        float observedMinimum=float.MaxValue,observedMaximumError=0;
        int worstCrowdAgent=-1,worstCrowdFrame=-1;
        Vector3 worstCrowdHost=default,worstCrowdUnity=default;
        for(int i=0;i<crowdSamples[0].Length;i++)
        {
            double sampleTime=crowdSamples[0][i].GetProperty("time").GetDouble();
            while(startTime+(crowdTick+1d)/MatchManifest.TickRate<=sampleTime)
            {foreach(var motion in crowdMotions)motion.AdvanceTick();
             foreach(var motion in observedCornerMotions)motion.AdvanceTick();crowdTick++;}
            hostMinimum=Math.Min(hostMinimum,Vector2.Distance(
                new(crowdMotions[0].Position.X,crowdMotions[0].Position.Z),
                new(crowdMotions[1].Position.X,crowdMotions[1].Position.Z)));
            for(int k=0;k<2;k++)
            {
                var position=crowdSamples[k][i].GetProperty("position");
                float error=Vector2.Distance(
                    new(crowdMotions[k].Position.X,crowdMotions[k].Position.Z),
                    new(position.GetProperty("x").GetSingle(),position.GetProperty("z").GetSingle()));
                if(error>hostMaximumError)
                {
                    hostMaximumError=error;worstCrowdAgent=k;worstCrowdFrame=i;
                    worstCrowdHost=crowdMotions[k].Position;
                    worstCrowdUnity=new(position.GetProperty("x").GetSingle(),
                        position.GetProperty("y").GetSingle(),position.GetProperty("z").GetSingle());
                }
                observedMaximumError=Math.Max(observedMaximumError,Vector2.Distance(
                    new(observedCornerMotions[k].Position.X,observedCornerMotions[k].Position.Z),
                    new(position.GetProperty("x").GetSingle(),position.GetProperty("z").GetSingle())));
            }
            observedMinimum=Math.Min(observedMinimum,Vector2.Distance(
                new(observedCornerMotions[0].Position.X,observedCornerMotions[0].Position.Z),
                new(observedCornerMotions[1].Position.X,observedCornerMotions[1].Position.Z)));
        }
        Console.WriteLine($"Park Unity crowd minimum separation {crowdPin.GetProperty("minimumPlanarSeparation").GetDouble():F3}, " +
            $"independent host minimum {hostMinimum:F3}, maximum individual error {hostMaximumError:F3} " +
            $"agent {worstCrowdAgent} frame {worstCrowdFrame} host {worstCrowdHost} Unity {worstCrowdUnity}; " +
            $"observed-corner minimum {observedMinimum:F3}, maximum error {observedMaximumError:F3}");
        Check(crowdMotions.All(m=>m.Arrived) && float.IsFinite(hostMinimum) &&
              float.IsFinite(hostMaximumError),
              "two simultaneous host Rusher routes complete for crowd comparison");
        Check(observedCornerMotions.All(m=>m.Arrived) && observedMinimum>.34f &&
              observedMaximumError<=.30f &&
              hostMaximumError>observedMaximumError+1f,
              "source-corner host routes preserve two-agent spacing and reduce Unity motion error");
        using var staggeredManifest=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"recovered-navmesh-staggered.json")));
        var staggeredPin=staggeredManifest.RootElement;
        Check(staggeredPin.GetProperty("version").GetInt32()==1 &&
              staggeredPin.GetProperty("pathManifestSha256").GetString()==navPin.ArmyNavMeshPathsRevision &&
              staggeredPin.GetProperty("navMeshSha256").GetString()==
                  content.ArmyNavMeshes.ForMap(parkCrowd).Revision &&
              staggeredPin.GetProperty("resultSha256").GetString()==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(Path.Combine(directory,"navmesh-motion",
                      "park-staggered-result.json")))) &&
              staggeredPin.GetProperty("spawnDelayFrames").GetInt32()==9 &&
              staggeredPin.GetProperty("initialPlanarSeparation").GetDouble()<.34 &&
              staggeredPin.GetProperty("minimumPostFourFrameSeparation").GetDouble()>.34,
              "source same-spawn Rushers recover two-agent radius after a nine-tick stagger");
        using var crossingDocument=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"navmesh-motion","park-crossing-result.json")));
        using var crossingManifest=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"recovered-navmesh-crossing.json")));
        var crossingPin=crossingManifest.RootElement;
        Check(crossingPin.GetProperty("version").GetInt32()==1 &&
              crossingPin.GetProperty("pathManifestSha256").GetString()==navPin.ArmyNavMeshPathsRevision &&
              crossingPin.GetProperty("navMeshSha256").GetString()==
                  content.ArmyNavMeshes.ForMap(parkCrowd).Revision &&
              crossingPin.GetProperty("resultSha256").GetString()==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(Path.Combine(directory,"navmesh-motion",
                      "park-crossing-result.json")))) &&
              crossingPin.GetProperty("minimumPlanarSeparation").GetDouble()>.34,
              "opposing Unity Rusher crossing is source-pinned and avoids radius overlap");
        var crossingCases=crossingDocument.RootElement.GetProperty("cases").EnumerateArray().ToArray();
        var crossingStates=new ArmyRusherArrivalState[2];
        for(int i=0;i<2;i++)
        {
            var ids=crossingCases[i].GetProperty("id").GetString()!.Split('-').Select(int.Parse).ToArray();
            var sourceRoute=content.ArmyNavMeshPaths.ForMap(parkCrowd).Single(p=>
                p.SpawnFileId==ids[0] && p.RusherFileId==ids[1]);
            var route=content.ArmyNavMeshConnectivity.PlanSourceSpawnCorridor(parkCrowd,
                ids[0],ids[1],sourceRoute.Start,sourceRoute.End);
            Check(crossingCases[i].GetProperty("status").GetString()=="Arrived" &&
                  route is {PlanarCovered:true},
                  "opposing Unity Rusher crossing binds two complete source corner routes");
            crossingStates[i]=new ArmyRusherArrivalState(route!,content.Army.InfantryAgent,.9f);
        }
        float crossingMinimum=float.MaxValue;
        for(int i=0;i<600;i++)
        {
            foreach(var state in crossingStates)state.AdvanceTick();
            crossingMinimum=Math.Min(crossingMinimum,Vector2.Distance(
                new(crossingStates[0].Position.X,crossingStates[0].Position.Z),
                new(crossingStates[1].Position.X,crossingStates[1].Position.Z)));
        }
        Console.WriteLine($"Park opposing route crossing host gap {crossingMinimum:F3}, " +
            $"phases {crossingStates[0].Phase}/{crossingStates[1].Phase}");
        Check(crossingStates.All(state=>state.InitialShotDelayElapsed) &&
              crossingMinimum<.34f,
              "opposing source-corner routes still need lateral avoidance, not a deadlocking wait gate");
        var steeredBases=new ArmyRusherArrivalState[2];
        var steering=new ArmyRusherLateralSteering[2];
        for(int i=0;i<2;i++)
        {
            var ids=crossingCases[i].GetProperty("id").GetString()!.Split('-').Select(int.Parse).ToArray();
            var sourceRoute=content.ArmyNavMeshPaths.ForMap(parkCrowd).Single(p=>
                p.SpawnFileId==ids[0] && p.RusherFileId==ids[1]);
            var corridor=content.ArmyNavMeshConnectivity.PlanSourceSpawnCorridor(parkCrowd,
                ids[0],ids[1],sourceRoute.Start,sourceRoute.End)!;
            steeredBases[i]=new ArmyRusherArrivalState(corridor,content.Army.InfantryAgent,.9f);
            steering[i]=new ArmyRusherLateralSteering(steeredBases[i].Position);
        }
        float steeredMinimum=float.MaxValue;
        for(int frame=0;frame<600;frame++)
        {
            foreach(var state in steeredBases)state.AdvanceTick();
            var priorPositions=steering.Select(agent=>agent.Position).ToArray();
            for(int k=0;k<2;k++)
            {
                int other=1-k;
                steering[k].Advance(steeredBases[k].Position,steeredBases[k].PlanarDirection,
                    [(priorPositions[other],steeredBases[other].PlanarDirection)],
                    (before,next)=>
                    {
                        if(before==next)return true;
                        return Vector3.Distance(before,next)<=.07f &&
                            content.ArmyNavMeshConnectivity.Classify(parkCrowd,before,next)==
                                ArmyNavMeshConnection.Connected;
                    });
            }
            float steeredGap=Vector2.Distance(
                new(steering[0].Position.X,steering[0].Position.Z),
                new(steering[1].Position.X,steering[1].Position.Z));
            steeredMinimum=Math.Min(steeredMinimum,steeredGap);
        }
        Console.WriteLine($"Park lateral steering minimum {steeredMinimum:F3}, " +
            $"blocked {steering[0].BlockedSteps}/{steering[1].BlockedSteps}, " +
            $"rejected {steering[0].RejectedSideSteps}/{steering[1].RejectedSideSteps}");
        Check(steeredBases.All(state=>state.InitialShotDelayElapsed) &&
              steeredMinimum>=.34f && steering.All(state=>state.BlockedSteps<10) &&
              Enumerable.Range(0,2).All(i=>Vector2.Distance(
                  new(steering[i].Position.X,steering[i].Position.Z),
                  new(steeredBases[i].Position.X,steeredBases[i].Position.Z))<.04f),
              "covered right-hand steering clears the opposing Unity crossing without blocking arrival");
        string retargetCrowdFile=Path.Combine(directory,"navmesh-motion",
            "park-retarget-crowd-result.json");
        using var retargetCrowdPin=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-navmesh-retarget-crowd.json")));
        using var retargetCrowd=JsonDocument.Parse(File.ReadAllBytes(retargetCrowdFile));
        var retargetPin=retargetCrowdPin.RootElement;
        var retargetCases=retargetCrowd.RootElement.GetProperty("cases").EnumerateArray().ToArray();
        Check(retargetPin.GetProperty("version").GetInt32()==1 &&
              retargetPin.GetProperty("pathManifestSha256").GetString()==
                  navPin.ArmyNavMeshPathsRevision &&
              retargetPin.GetProperty("navMeshSha256").GetString()==
                  content.ArmyNavMeshes.ForMap(parkCrowd).Revision &&
              retargetPin.GetProperty("resultSha256").GetString()==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(retargetCrowdFile))) &&
              retargetCases.Length==3 && retargetCases[0].GetProperty("status").GetString()=="Arrived" &&
              retargetCases.Skip(1).All(c=>c.GetProperty("status").GetString()=="Stationary") &&
              retargetPin.GetProperty("minimumPlanarSeparations").EnumerateArray()
                  .All(g=>g.GetDouble()>.335 && g.GetDouble()<.35),
              "host seed-2 stall snapshot binds a source Unity Park crowd probe");
        var crowdStart=Vec(retargetCases[0].GetProperty("sampledStart"));
        var crowdGoal=Vec(retargetCases[0].GetProperty("sampledEnd"));
        var crowdBlockers=retargetCases.Skip(1)
            .Select(c=>Vec(c.GetProperty("sampledStart"))).ToArray();
        var detourProbe=ArmyRusherDetourPlanner.Plan(parkCrowd,
            content.ArmyNavMeshConnectivity,crowdStart,crowdGoal,crowdBlockers,
            content.Army.InfantryAgent.Radius);
        Check(detourProbe is null,
              "static radius clearance cannot reproduce Unity's moving-agent avoidance at the seed-2 start");
        var stationaryDrift=retargetCases.Skip(1).Select(c=>{
            var first=Vec(c.GetProperty("sampledStart"));
            return c.GetProperty("samples").EnumerateArray().Max(s=>{
                var observed=Vec(s.GetProperty("position"));
                return Vector2.Distance(new(first.X,first.Z),new(observed.X,observed.Z));
            });
        }).ToArray();
        Console.WriteLine($"Park retarget Unity crowd arrival " +
            $"{retargetPin.GetProperty("movingArrivalSeconds").GetDouble():F3}s, " +
            $"stationary-agent maximum drift {stationaryDrift[0]:F3}/{stationaryDrift[1]:F3}, " +
            $"moving min X {retargetPin.GetProperty("movingMinX").GetDouble():F3}");
        Check(stationaryDrift.All(x=>x>.04f),
              "Unity avoidance moves both stopped blockers, so a frozen-obstacle detour is not an equivalent crowd model");
        var retargetClock=new ArmyRusherRetargetClock();
        for(int i=0;i<30;i++)Check(!retargetClock.AdvanceTick(false,false),
            "inactive Rusher does not retarget before the strict source delay");
        Check(!retargetClock.AdvanceTick(true,false) &&
              !retargetClock.AdvanceTick(false,true) &&
              retargetClock.InactiveTicks==30,
              "active point and pending shot pause, but do not erase, the source timer");
        for(int i=0;i<15;i++)Check(!retargetClock.AdvanceTick(false,false),
            "Rusher strict retarget threshold has not elapsed");
        Check(retargetClock.AdvanceTick(false,false) &&
              retargetClock.InactiveTicks==46 &&
              retargetClock.AdvanceTick(false,false),
              "Rusher requests retarget after more than 1.5 seconds until a valid transfer commits");
        retargetClock.Reset();
        Check(retargetClock.InactiveTicks==0 && !retargetClock.AdvanceTick(false,false),
              "committed Rusher transfer resets its source inactive timer");
        var oldSlots=Enumerable.Range(0,4).Select(i=>new ArmyRusherPoint(
            100+i,i,200+i,new Vector3(i,0,0))).ToArray();
        var newSlots=Enumerable.Range(0,4).Select(i=>new ArmyRusherPoint(
            300+i,i,400+i,new Vector3(i,0,3))).ToArray();
        Check(ArmyRusherRetargetSelector.Select(oldSlots,newSlots,1,
                  id=>id==101,(candidate,_)=>candidate.Index==2) is
                  {Qualified:true,Point.Index:2},
              "source Rusher permutation scan maps its occupied old slot to the only eligible destination");
        var tiedSlots=newSlots.Select(p=>p with {Position=new Vector3(1,0,3)}).ToArray();
        Check(ArmyRusherRetargetSelector.Select(oldSlots,tiedSlots,1,
                  id=>id==101,(_,_)=>true) is {Qualified:true,Point.Index:1},
              "strict source score tie retains the first generated four-slot permutation");
        Check(ArmyRusherRetargetSelector.Select(oldSlots,newSlots,1,
                  _=>false,(_,_)=>false) is {Qualified:false,Point.Index:0},
              "source Rusher retarget preserves the index-zero fallback without treating it as occupancy proof");
        var snowMap=content.Maps.Single(m=>m.Source.Contains("Snow_Multiplayer",StringComparison.Ordinal));
        var partialRoute=content.ArmyNavMeshPaths.ForMap(snowMap).First(p=>!p.Complete);
        var completeRoute=content.ArmyNavMeshPaths.ForMap(snowMap).First(p=>p.Complete);
        Check(content.ArmyNavMeshConnectivity.Classify(snowMap,partialRoute.SampledStart,
                  partialRoute.SampledEnd)==ArmyNavMeshConnection.Disconnected &&
              content.ArmyNavMeshConnectivity.Classify(snowMap,completeRoute.SampledStart,
                  completeRoute.SampledEnd)==ArmyNavMeshConnection.Connected &&
              content.ArmyNavMeshConnectivity.Classify(snowMap,new Vector3(9000,9000,9000),
                  completeRoute.SampledEnd)==ArmyNavMeshConnection.Outside &&
              content.Maps.All(m=>content.ArmyNavMeshConnectivity.ComponentCount(m)>1),
              "welded source triangles distinguish connected, partial and outside route endpoints");
        var routeRatios=new List<float>();
        var smoothRatios=new List<float>();
        var verticalDeviations=new List<(float Deviation,string Map,int Spawn,int Rusher)>();
        var worstRoutes=new List<(float Ratio,string Map,int Spawn,int Rusher,int UnityCorners,int HostCorners,
            IReadOnlyList<Vector3> HostPoints)>();
        int planned=0,closed=0;
        int uncovered=0;
        foreach(var navigationMap in content.Maps)
            foreach(var fixture in content.ArmyNavMeshPaths.ForMap(navigationMap))
            {
                var corridor=content.ArmyNavMeshConnectivity.PlanCorridor(navigationMap,
                    fixture.SampledStart,fixture.SampledEnd);
                if(!fixture.Complete)
                { if(corridor!=null)throw new Exception("Partial Unity route received a host corridor.");closed++;continue; }
                if(corridor==null || corridor.Points[0]!=fixture.SampledStart ||
                   corridor.Points[^1]!=fixture.SampledEnd ||
                   corridor.Length<Vector3.Distance(fixture.SampledStart,fixture.SampledEnd)-.0001f)
                    throw new Exception("Connected Unity route lacks a valid host triangle corridor.");
                float unityLength=0;
                for(int i=1;i<fixture.Corners.Count;i++)
                    unityLength+=Vector3.Distance(fixture.Corners[i-1],fixture.Corners[i]);
                routeRatios.Add(corridor.Length/unityLength);
                if(corridor.SmoothedPoints[0]!=fixture.SampledStart ||
                   corridor.SmoothedPoints[^1]!=fixture.SampledEnd ||
                   corridor.SmoothedLength<Vector3.Distance(fixture.SampledStart,fixture.SampledEnd)-.0001f)
                    throw new Exception("Funnel path has invalid endpoints or length.");
                float smoothRatio=corridor.SmoothedLength/unityLength;
                smoothRatios.Add(smoothRatio);
                verticalDeviations.Add((corridor.MaxVerticalDeviation,navigationMap.Source,
                    fixture.SpawnFileId,fixture.RusherFileId));
                if(!corridor.PlanarCovered)uncovered++;
                worstRoutes.Add((smoothRatio,navigationMap.Source,fixture.SpawnFileId,
                    fixture.RusherFileId,fixture.Corners.Count,corridor.SmoothedPoints.Count,
                    corridor.SmoothedPoints));
                planned++;
            }
        Check(planned==416 && closed==16 && routeRatios.All(float.IsFinite) &&
              smoothRatios.All(float.IsFinite),
              "host graph finds a walkable portal corridor for every complete Unity route and none for partial routes");
        Console.WriteLine($"NavMesh planar coverage: {planned-uncovered}/{planned} complete host paths");
        Check(uncovered==0,"every selected smoothed path remains inside its walkable triangle corridor");
        Check(verticalDeviations.Count==416 && verticalDeviations.All(route=>
                  float.IsFinite(route.Deviation) && route.Deviation<=.25f),
              "selected fixture routes stay within the measured vertical NavMesh envelope");
        foreach(var route in verticalDeviations.OrderByDescending(route=>route.Deviation).Take(5))
            Console.WriteLine($"NavMesh vertical deviation {route.Deviation:F3}: {route.Map} " +
                $"spawn {route.Spawn}, Rusher {route.Rusher}");
        routeRatios.Sort();
        smoothRatios.Sort();
        Check(smoothRatios[smoothRatios.Count/2]<=1.02f &&
              smoothRatios[(int)(smoothRatios.Count*.95)]<=1.09f &&
              smoothRatios[^1]<=1.12f,
              "funnel paths stay within the measured Unity length envelope across all 416 complete fixtures");
        Console.WriteLine("NavMesh corridor/Unity length ratio: median "+
            routeRatios[routeRatios.Count/2].ToString("F2",System.Globalization.CultureInfo.InvariantCulture)+
            ", p95 "+routeRatios[(int)(routeRatios.Count*.95)].ToString("F2",System.Globalization.CultureInfo.InvariantCulture)+
            ", max "+routeRatios[^1].ToString("F2",System.Globalization.CultureInfo.InvariantCulture)+
            "; funnel: median "+smoothRatios[smoothRatios.Count/2].ToString("F2",System.Globalization.CultureInfo.InvariantCulture)+
            ", p95 "+smoothRatios[(int)(smoothRatios.Count*.95)].ToString("F2",System.Globalization.CultureInfo.InvariantCulture)+
            ", max "+smoothRatios[^1].ToString("F2",System.Globalization.CultureInfo.InvariantCulture));
        foreach(var route in worstRoutes.OrderByDescending(route=>route.Ratio).Take(5))
            Console.WriteLine($"NavMesh deviation {route.Ratio:F2}: {route.Map} " +
                $"spawn {route.Spawn}, Rusher {route.Rusher}, Unity corners {route.UnityCorners}, " +
                $"host corners {route.HostCorners}; " +
                string.Join(" ",route.HostPoints.Select(point=>$"({point.X:F2},{point.Z:F2})")));
        Reject(()=>ArmyNavMeshSourceCatalog.Load(navArtifact,new string('0',64),content.Maps));
        Reject(()=>ArmyNavMeshTriangulationCatalog.Load(trianglesArtifact,new string('0',64),
            content.ArmyNavMeshes));
        Reject(()=>ArmyNavMeshPathFixtureCatalog.Load(pathsArtifact,new string('0',64),
            content.Maps,content.ArmyNavMeshes,content.ArmyNavMeshGeometry,
            content.ArmySpawnPoints,content.ArmyRusherPoints));
        string navTest=Path.Combine(Path.GetTempPath(),"war-navmesh-"+Guid.NewGuid().ToString("N"));
        string navTestFiles=Path.Combine(navTest,"navmesh");
        string navTestTriangles=Path.Combine(navTest,"navmesh-triangulation");
        Directory.CreateDirectory(navTestFiles);
        Directory.CreateDirectory(navTestTriangles);
        try
        {
            string copiedArtifact=Path.Combine(navTest,Path.GetFileName(navArtifact));
            File.Copy(navArtifact,copiedArtifact);
            string copiedTriangles=Path.Combine(navTest,Path.GetFileName(trianglesArtifact));
            File.Copy(trianglesArtifact,copiedTriangles);
            foreach(var row in content.ArmyNavMeshes.Maps)
            {
                File.Copy(Path.Combine(directory,"navmesh",Path.GetFileName(row.Asset)),
                    Path.Combine(navTestFiles,Path.GetFileName(row.Asset)));
                string triangleFile=Path.GetFileNameWithoutExtension(row.Asset)+".json";
                File.Copy(Path.Combine(directory,"navmesh-triangulation",triangleFile),
                    Path.Combine(navTestTriangles,triangleFile));
            }
            string firstAsset=Path.Combine(navTestFiles,Path.GetFileName(content.ArmyNavMeshes.Maps[0].Asset));
            var altered=File.ReadAllBytes(firstAsset);altered[100]^=1;
            File.WriteAllBytes(firstAsset,altered);
            Reject(()=>ArmyNavMeshSourceCatalog.Load(copiedArtifact,
                navPin.ArmyNavMeshSourcesRevision,content.Maps));
            string firstTriangles=Path.Combine(navTestTriangles,
                Path.GetFileNameWithoutExtension(content.ArmyNavMeshes.Maps[0].Asset)+".json");
            altered=File.ReadAllBytes(firstTriangles);altered[100]^=1;
            File.WriteAllBytes(firstTriangles,altered);
            Reject(()=>ArmyNavMeshTriangulationCatalog.Load(copiedTriangles,
                navPin.ArmyNavMeshTriangulationRevision,content.ArmyNavMeshes));
        }
        finally
        {
            foreach(var row in content.ArmyNavMeshes.Maps)
            {
                File.Delete(Path.Combine(navTestFiles,Path.GetFileName(row.Asset)));
                File.Delete(Path.Combine(navTestTriangles,
                    Path.GetFileNameWithoutExtension(row.Asset)+".json"));
            }
            File.Delete(Path.Combine(navTest,Path.GetFileName(navArtifact)));
            File.Delete(Path.Combine(navTest,Path.GetFileName(trianglesArtifact)));
            Directory.Delete(navTestFiles);
            Directory.Delete(navTestTriangles);
            Directory.Delete(navTest);
        }
        var targetPin=JsonSerializer.Deserialize<CombatContentManifest>(
            File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
        var targetArtifact=Path.Combine(directory,"recovered-player-shot-targets.json");
        Check(targetPin.PlayerShotTargetsRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(targetArtifact))) &&
              content.PlayerShotTargets.Gameplay.Select(t=>t.TransformFileId)
                .SequenceEqual([17937,17936,17935,17927,17926]) &&
              content.PlayerShotTargets.Gameplay.Select(t=>t.Type)
                .SequenceEqual([1,1,2,16,8]),
              "both serialized player target lists bind to the combat package and gameplay order");
        var firstBody=content.PlayerShotTargets.Gameplay[0];
        var secondBody=content.PlayerShotTargets.Gameplay[1];
        Check(content.PlayerShotTargets.ReferenceNearest(1,firstBody.ReferencePosition)==firstBody &&
              content.PlayerShotTargets.ReferenceNearest(1,secondBody.ReferencePosition)==secondBody &&
              content.PlayerShotTargets.ReferenceNearest(16,Vector3.Zero).TransformFileId==17927,
              "source body nearest selection and moving-target selection retain serialized identities");
        Check(content.PlayerShotTargets.Nearest(1,Vector3.Zero,
                  row=>row==secondBody ? Vector3.Zero : Vector3.One)==secondBody &&
              content.PlayerShotTargets.Nearest(1,Vector3.Zero,_=>Vector3.One)==firstBody &&
              content.PlayerShotTargets.Nearest(0xFFFFFF,Vector3.Zero,
                  row=>row.Type==16 ? Vector3.Zero : Vector3.One).Type==16,
              "posed target selection uses current positions, strict nearest ties and the source All mask");
        Reject(()=>content.PlayerShotTargets.Nearest(1,Vector3.Zero,_=>new Vector3(float.NaN,0,0)));
        var idleTarget=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0).MovingTarget;
        var runTarget=content.Poses.SampleBlended("run",0.25,true,"run",0.25,true,0).MovingTarget;
        Check(idleTarget?.SourcePath==content.PlayerShotTargets.Gameplay[3].Path &&
              runTarget?.SourcePath==idleTarget.SourcePath &&
              Vector3.Distance(idleTarget.Position,runTarget.Position)>0.001f &&
              Vector3.Distance(idleTarget.Place(new Vector3(1,2,3),Quaternion.Identity).Position,
                  idleTarget.Position)>1f,
              "Rusher moving target follows the sampled animated rig and host root placement");
        var referencePose=content.Poses.SampleBlended("T_pose",0,true,"T_pose",0,true,0);
        Check(content.PlayerShotTargets.Gameplay.Take(2).All(t=>
                  Vector3.Distance(referencePose.BodyTarget(t.TransformFileId).Position,
                      t.ReferencePosition)<0.0002f) &&
              content.PlayerShotTargets.Gameplay.Take(2).All(t=>
                  Vector3.Distance(referencePose.Place(new Vector3(3,4,5),Quaternion.Identity)
                      .BodyTarget(t.TransformFileId).Position,t.ReferencePosition)>1f),
              "both direct-child Body targets retain scene reference positions and follow host player placement");
        Reject(()=>PlayerShotTargetCatalog.Load(targetArtifact,new string('0',64),targetPin.SceneRevision));
        Check(content.Maps.Sum(m=>m.Covers.Sum(c=>content.ArmyRusherPoints.ForCover(m,c.SourceIndex).Count))==160,
              "all five multiplayer scenes pin four Rusher slots at each defend position");
        var rusherArtifact=Path.Combine(directory,"recovered-army-rusher-points.json");
        var rusherPin=JsonSerializer.Deserialize<CombatContentManifest>(
            File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
        Check(rusherPin.ArmyRusherPointsRevision==Convert.ToHexStringLower(
                  SHA256.HashData(File.ReadAllBytes(rusherArtifact))),
              "Rusher slot artifact bytes match the live combat package pin");
        Reject(()=>ArmyRusherPointCatalog.Load(rusherArtifact,new string('0',64),content.Maps));
        Check(content.Maps.Sum(m=>content.ArmySpawnPoints.ForMap(m).Count)==101 &&
              content.Maps.All(m=>content.ArmySpawnPoints.ForMap(m)
                .Select(p=>p.Collection).Distinct().Count()==5),
              "all five multiplayer scenes retain their typed source spawn collections");
        string spawnPath=Path.Combine(directory,"recovered-army-spawn-points.json");
        string spawnTemp=Path.Combine(directory,"army-spawn-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var pin=JsonSerializer.Deserialize<CombatContentManifest>(File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
            Reject(()=>ArmySpawnPointCatalog.Load(spawnPath,new string('0',64),content.Maps));
            var modified=JsonNode.Parse(File.ReadAllText(spawnPath))!;
            modified["maps"]![0]!["points"]![0]!["worldPosition"]![0]=999f;
            File.WriteAllText(spawnTemp,modified.ToJsonString());
            string altered=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(spawnTemp)));
            Reject(()=>ArmySpawnPointCatalog.Load(spawnTemp,altered,content.Maps));
            Check(pin.ArmySpawnPointsRevision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(spawnPath))),
                  "spawn transforms are pinned into the live combat revision");
        }
        finally {if(File.Exists(spawnTemp))File.Delete(spawnTemp);}
        Check(content.Army.Families.Count==24 && content.Army.Families.Sum(f=>f.Options.Count)==48 &&
              content.Army.Option(0).Count==2 && content.Army.Option(1).Count==4 &&
              content.Army.MaxEnergy==8 && content.Army.BaseCooldown==1,
              "deathmatch runtime options replace scene preview counts and bind source constants");
        var flameMuzzle=content.ArmyWeapons.Muzzle("ID_UNIT-FLAMETHROWER");
        Check(flameMuzzle.Path=="FlamethrowerEnemy/HK416/MachinegunMuzzleFlash"&&
              Vector3.Distance(flameMuzzle.RestPosition,new Vector3(.4031273f,.16250353f,.0405312f))<.00001f&&
              content.ArmyWeapons.GunSnapPath.EndsWith("/GunPivot/gunSnapPoint",StringComparison.Ordinal),
              "pinned enemy rig and flamethrower prefab compose the recovered rest muzzle offset");
        var placedFlameMuzzle=content.ArmyWeapons.RestMuzzleOrigin("ID_UNIT-FLAMETHROWER",
            new Vector3(2,0,3),Vector3.UnitX);
        Check(Vector3.Distance(placedFlameMuzzle,new Vector3(2.0405312f,.16250353f,2.5968728f))<.00002f,
              "army muzzle placement rotates the recovered local chain with authoritative facing");
        Check(content.ArmyWeapons.WindupTicks("ID_UNIT-FLAMETHROWER")==0&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-SHOTGUNNER")==9&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-PARATROOPER")==9&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-SWAT")==30&&
              content.ArmyWeapons.Windup("ID_UNIT-SWAT").ClipAsset=="Assets/AnimationClip/shield_unhide.anim",
              "all source Rusher attacks bind their recovered stand-shoot or shield-unhide windup");
        try { _=content.ArmyWeapons.RestMuzzleOrigin("ID_UNIT-FLAMETHROWER",Vector3.Zero,Vector3.Zero); throw new Exception("Zero army facing accepted."); }
        catch(InvalidDataException) { count++; }
        string weaponBindingPath=Path.Combine(directory,"recovered-rusher-weapon-bindings.json");
        string weaponBindingTemp=Path.Combine(directory,"army-weapon-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var modified=JsonNode.Parse(File.ReadAllText(weaponBindingPath))!;
            modified["families"]![0]!["attackWindup"]!["seconds"]=0f;
            File.WriteAllText(weaponBindingTemp,modified.ToJsonString());
            string altered=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(weaponBindingTemp)));
            Reject(()=>ArmyWeaponBindingCatalog.Load(weaponBindingTemp,altered,rusherPin.SceneRevision));
        }
        finally {if(File.Exists(weaponBindingTemp))File.Delete(weaponBindingTemp);}
        Check(content.Army.BaseStats("ID_UNIT-ASSAULT",0)==new ArmyBaseCombatStats(140f,29.6f) &&
              content.Army.BaseStats("ID_UNIT-HELICOPTER",0).Health>1000f &&
              content.Army.BaseStats("ID_UNIT-BUGGY",0).Damage==0f,
              "host normal-upgrade combat stats bind the recovered HP/DAMAGE rows, including zero-damage carriers");
        Check(content.Army.ComposeShot("ID_UNIT-FLAMETHROWER",0,null,null)==
              new ArmyBaseShotStats(.8f,1,1,2.3f,3f),
              "flamethrower attack scheduler binds its recovered normal-upgrade firing row");
        var flameSpecial=content.Army.ComposeShot("ID_UNIT-FLAMETHROWER",0,51,null);
        Check(flameSpecial==new ArmyBaseShotStats(.8f,1,1,2.3f,3f),
              "zeroed source special sentinel composes without changing flamethrower firing authority");
        try { _=content.Army.ComposeShot("ID_UNIT-FLAMETHROWER",0,0,null); throw new Exception("Normal shot row accepted as special."); }
        catch(ArgumentOutOfRangeException) { count++; }
        try { _=content.Army.BaseStats("ID_UNIT-ASSAULT",int.MaxValue); throw new Exception("Invalid army stage accepted."); }
        catch(ArgumentOutOfRangeException) { count++; }
        try { _=content.Army.BaseStats("ID_UNIT-ASSAULT",101); throw new Exception("Special row accepted as normal."); }
        catch(ArgumentOutOfRangeException) { count++; }
        try { _=content.Army.BaseStats("ID_UNIT-ASSAULT",133); throw new Exception("Later special row accepted as normal."); }
        catch(ArgumentOutOfRangeException) { count++; }
        var specialStats=content.Army.ComposeStats("ID_UNIT-ASSAULT",0,133,null);
        Check(specialStats.Health>140f && specialStats.Damage>29.6f &&
              content.Army.ComposeStats("ID_UNIT-ASSAULT",0,null,null)==content.Army.BaseStats("ID_UNIT-ASSAULT",0),
              "normal and purchased special rows add as recovered UpgradeSlotsGeneric.LoadData does");
        try { _=content.Army.ComposeStats("ID_UNIT-ASSAULT",0,0,null); throw new Exception("Normal row accepted as special."); }
        catch(ArgumentOutOfRangeException) { count++; }
        Check(content.Army.Families.All(f=>content.Army.BaseStats(f.UnitId,0).Health>0),
              "every scene-deployed family has a playable pinned first normal-upgrade stage");
        var deployment=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT"]);
        deployment.SetOffers([0,1,0]);
        Check(deployment.TryDeploy(2,100)=="army-not-offered" &&
              deployment.TryDeploy(0,100)=="army-deploying" && deployment.PendingCount==2 &&
              deployment.Advance(100).Count==1 && deployment.Energy==7 &&
              deployment.Advance(108).Count==0 && deployment.Advance(109).Count==1 && deployment.Energy==6,
              "host accepts only offered equipped runtime option and schedules 0.3-second energy debits");
        deployment.SetOffers([0,1,0]);
        Check(deployment.TryDeploy(1,101)=="army-cooldown" &&
              deployment.TryDeploy(1,200)=="army-deploying" &&
              deployment.Advance(200).Count==1 && deployment.Energy==5 &&
              deployment.Advance(227).Count==3 && deployment.Energy==2 && deployment.ActiveCount==6,
              "cooldown and later four-unit batch are owned by host ticks");
        var combatDeath=deployment.RemoveEntity(1);
        var opposingEnergy=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT"]);
        opposingEnergy.CreditKillEnergy(combatDeath!.Power);
        Check(combatDeath.Power==1 && deployment.Energy==2 &&
              deployment.RemoveEntity(1)==null && deployment.ActiveCount==5 &&
              opposingEnergy.Energy==9,
              "ordinary unit death credits opposing energy once, not owner energy");
        var helicopter=new ArmyDeploymentState(content.Army,["ID_UNIT-HELICOPTER"]);
        Check(helicopter.GenerateOffers(_=>0).SequenceEqual([2,2,2]) &&
              helicopter.OfferedOptions.SequenceEqual([2,2,2]),
              "one eligible source option pads the three-option host hand");
        var fourTypes=new ArmyDeploymentState(content.Army,
            ["ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER","ID_UNIT-SHOTGUNNER"]);
        Check(fourTypes.GenerateOffers(_=>0).SequenceEqual([4,7,11]),
              "Classic source offer samples one option per UnitType then drops one of four types");
        var firstNew=new ArmyDeploymentState(content.Army,
            ["ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER","ID_UNIT-SHOTGUNNER"],
            ["ID_UNIT-SNIPER"]);
        Check(firstNew.GenerateOffers(_=>0).SequenceEqual([6,7,11]) &&
              firstNew.GenerateOffers(_=>0).SequenceEqual([4,7,11]),
              "first source hand promotes the last eligible option of a new behavior only once");
        var droppedNew=new ArmyDeploymentState(content.Army,
            ["ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER","ID_UNIT-SHOTGUNNER"],
            ["ID_UNIT-ASSAULT"]);
        var droppedHand=droppedNew.GenerateOffers(_=>0);
        Check(droppedHand.SequenceEqual([1,7,11]),
              "first-new source rule replaces slot zero when its UnitType was dropped: "+string.Join(',',droppedHand));
        var changedRoutes=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT","ID_UNIT-SNIPER"]);
        Check(changedRoutes.GenerateOffers(_=>0).Contains(0) &&
              changedRoutes.OfferedOptions.Count==3,
              "army hand is initially issued from source-eligible routes");
        changedRoutes.InvalidateOffers();
        Check(changedRoutes.GenerateOffers(_=>0,(_,option)=>option.Index==4).SequenceEqual([4,4,4]) &&
              changedRoutes.TryDeploy(0,10)=="army-not-offered",
              "availability invalidation generates a narrower hand without retaining stale authorization");
        Check(helicopter.TryDeploy(2,0)=="army-deploying" &&
              helicopter.Advance(0).Count==1 && helicopter.Energy==4,
              "single-capacity vehicle deploys once from a repeated offer");
        Reject(()=>helicopter.SetOffers([2,2,2]));
        Check(helicopter.GenerateOffers(_=>0).Count==0 && helicopter.OfferedOptions.Count==0,
              "full capacity cannot fall back to unequipped Assault");
        var suicide=helicopter.RemoveEntity(1);
        helicopter.CreditKillEnergy(suicide!.Power);
        Check(suicide.Power==4 && helicopter.Energy==8,
              "confirmed vehicle suicide restores capacity and owner energy");
        Check(helicopter.GenerateOffers(_=>0).SequenceEqual([2,2,2]),
              "confirmed death makes the equipped vehicle offerable again");
        Reject(()=>new ArmyDeploymentState(content.Army,["ID_UNIT-UNKNOWN"]));
        string armyPath=Path.Combine(directory,"recovered-army-deployment.json");
        string armyTemp=Path.Combine(directory,"army-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var pin=JsonSerializer.Deserialize<CombatContentManifest>(File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
            Reject(()=>ArmyDeploymentCatalog.Load(armyPath,new string('0',64),pin.SceneRevision));
            Check(content.Army.Families.Count==24 &&
                  content.Army.Families.All(f=>float.IsFinite(f.BaseSpeed) && f.BaseSpeed>0 && f.BaseSpeed<=1) &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourShotgunner").BaseSpeed==1f &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourSwat").BaseSpeed==.9f &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourSwat").MovementSpeed==1f &&
                  content.Army.Families.Single(f=>f.BehaviorType=="HelicopterBehaviour").MovementSpeed==3f &&
                  content.Army.EffectiveSpeed("ID_UNIT-SWAT",1.25f)==1.25f &&
                  content.Army.InfantryAgent.Radius==.17f &&
                  content.Army.InfantryAgent.Acceleration==10f &&
                  content.Army.InfantryAgent.AngularSpeed==600f,
                  "24 serialized and runtime speeds plus infantry agent geometry bind recovered sources");
            Check(ArmySpawnPointSelector.Collection("HelicopterBehaviour")=="spawnPointsCollectionHelicopters" &&
                  ArmySpawnPointSelector.Collection("CarBehaviour")=="spawnPointsCollectionCars" &&
                  ArmySpawnPointSelector.Collection("TankBehaviour")=="spawnPointsCollectionCars" &&
                  ArmySpawnPointSelector.Collection("MechBehaviour")=="spawnPointsCollection" &&
                  content.Army.Families.Count(f=>!f.IsSoldier && f.BehaviorType!="MechBehaviour")==7,
                  "vehicle families bind their recovered map spawn collections without using infantry routes");
            Check(content.Army.Families.Count(f=>f.BaseShot!=null)==6 &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourSwat").BaseShot==
                      new ArmyBaseShotStats(.5f,1,4,1f,6f) &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourShotgunner").BaseShot==
                      new ArmyBaseShotStats(1f,1,4,1f,5f) &&
                  content.Army.Families.Single(f=>f.BehaviorType=="HelicopterBehaviour").BaseShot==null,
                  "six source-inherited Rusher families bind their serialized base shot definitions");
            Check(content.Army.Families.Count(f=>f.VehicleShot!=null)==7 &&
                  content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-HELICOPTER").VehicleShot==
                      new ArmyVehicleShotStats(5f,1f,0,0,0f,0f,0) &&
                  content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-DRONE").VehicleShot==
                      new ArmyVehicleShotStats(5f,.75f,0,0,0f,0f,0),
                  "seven vehicle families bind serialized projectile speed, accuracy, batch, timing, and crew fields");
            var air=new ArmyAirMotionState(new(0,4,0),new(0,7,1),3f);
            for(var i=0;i<100;i++)air.AdvanceTick();
            Check(air.Position.Y>4 && air.Position.Z>0 && air.Arrived,
                  "air-unit motion preserves three-dimensional altitude and reaches its destination at fixed tick speed");
            Reject(()=>new ArmyAirMotionState(new(float.NaN,0,0),Vector3.Zero,1));
            var airAttack=new ArmyAirAttackState(new ArmyVehicleShotStats(5f,1f,1,1,0f,0f,0),()=>.1f);
            Check(airAttack.TryBegin(true,1)&&!airAttack.AdvanceTick()&&airAttack.AdvanceTick()&&
                  airAttack.CurrentShotIsReal&&airAttack.CommitShot()&&airAttack.Phase==ArmyAirAttackPhase.Cooldown,
                  "air-unit attack scheduler emits a source-probability shot and enters deterministic cooldown");
            Check(!new ArmyAirAttackState(new ArmyVehicleShotStats(5f,1f,0,0,0f,0f,0),()=>.1f).TryBegin(true,0),
                  "air families without a serialized batch remain non-firing");
            var airIntent=new ArmyAirShotIntent(91,
                "11111111111111111111111111111111","22222222222222222222222222222222",
                new(2,3,4),1.5f,true);
            var airImpact=ArmyAirImpactResolver.Resolve(airIntent,
                new ShotCollision(1,new(2.5f,3,4),"",airIntent.VictimPlayerId,.8f),24f);
            Check(airImpact.EntityKey==91&&airImpact.Damage==24f&&airImpact.IsReal,
                  "air impact proof binds the spawned entity, opposing player, range, and trusted damage");
            Reject(()=>ArmyAirImpactResolver.Resolve(airIntent,
                new ShotCollision(1,new(9,3,4),"",airIntent.VictimPlayerId,.8f),24f));
            var airRegistry=new AirEntityRegistry(1);
            var airEntity=new AirBattleEntity(92,"11111111111111111111111111111111",
                new ArmyAirMotionState(Vector3.Zero,new(0,1,0),1f),
                new ArmyAirAttackState(new ArmyVehicleShotStats(5f,1f,1,1,0f,0f,0),()=>0f));
            Check(airRegistry.TrySpawn(airEntity)&&!airRegistry.TrySpawn(airEntity)&&airRegistry.Count==1&&
                  airRegistry.TryGet(92,out _)&&airRegistry.TryDespawn(92)&&airRegistry.Count==0,
                  "air entities have bounded match-owned spawn, duplicate, lookup, tick and despawn lifecycle");
            var ownedAir=new AirBattleEntity(94,"11111111111111111111111111111111",
                new ArmyAirMotionState(Vector3.Zero,Vector3.UnitY,1),
                new ArmyAirAttackState(new ArmyVehicleShotStats(5,1,1,1,0,0,0),()=>0));
            var ownerAirRegistry=new AirEntityRegistry(); ownerAirRegistry.TrySpawn(ownedAir);
            Check(ownerAirRegistry.RemoveOwner("11111111111111111111111111111111")==1&&ownerAirRegistry.Count==0,
                  "air registry removes all entities owned by a disconnected player");
            var healthRegistry=new AirEntityRegistry();
            var durableAir=new AirBattleEntity(93,"22222222222222222222222222222222",
                new ArmyAirMotionState(Vector3.Zero,Vector3.UnitX,1),
                new ArmyAirAttackState(new ArmyVehicleShotStats(5,1,1,1,0,0,0),()=>0),
                new AirEntityHealthState(40));
            healthRegistry.TrySpawn(durableAir);
            Check(healthRegistry.TryApplyDamage(93,15,out var appliedDamage)&&appliedDamage==15&&
                  durableAir.Health.Current==25&&healthRegistry.TryApplyDamage(93,30,out _)&&
                  !healthRegistry.TryGet(93,out _),"air damage is server-owned and lethal damage removes the entity");
            Reject(()=>new AirEntityHealthState(float.NaN));
            var mines=DeployableCardPolicy.SelectLandmineTargets("LandMine",0,
                new[]{new DeployablePlacement(1,new(1,0,0)),new DeployablePlacement(2,new(2,0,0)),
                      new DeployablePlacement(3,new(3,0,0)),new DeployablePlacement(4,new(4,0,0))},n=>0);
            Check(mines.Count==3&&mines.Select(x=>x.SlotId).Distinct().Count()==3&&
                  DeployableCardPolicy.CanSpawnHeavyTurret("HeavyTurret",Vector3.Zero,0),
                  "deployable cards enforce source three-target landmine selection and trusted turret placement");
            var deployables=new DeployableRegistry(1);
            var mine=new DeployableEntity(501,"33333333333333333333333333333333","LandMine",Vector3.Zero,2);
            Check(deployables.TrySpawn(mine)&&!deployables.TrySpawn(mine)&&!deployables.TryTrigger(999)&&
                  deployables.TryTrigger(501)&&!deployables.TryTrigger(501)&&deployables.RemoveExpired()==1&&deployables.Count==0,
                  "deployables have bounded spawn, one-shot trigger, and owner-safe cleanup lifecycle");
            var turretRegistry=new DeployableRegistry();
            var turretEntity=new DeployableEntity(503,"33333333333333333333333333333333","HeavyTurret",Vector3.Zero,40);
            Check(turretRegistry.TrySpawn(turretEntity)&&turretEntity.Charges==3&&turretRegistry.TryTrigger(503)&&
                  turretRegistry.Snapshot().Single().State==DeployableState.Armed&&
                  turretRegistry.Snapshot().Single().Charges==2&&turretRegistry.Snapshot().Single().CooldownTicks==15,
                  "heavy turret retains bounded charges and authoritative cooldown");
            var snapshotDeployables=new DeployableRegistry();
            snapshotDeployables.TrySpawn(new DeployableEntity(502,"33333333333333333333333333333333","LandMine",Vector3.Zero,5));
            var detachedDeployable=snapshotDeployables.Snapshot().Single();detachedDeployable.State=DeployableState.Triggered;
            Check(snapshotDeployables.Snapshot().Single().State==DeployableState.Armed,
                  "deployable snapshots are detached from server-owned lifecycle state");
            Reject(()=>DeployableCardPolicy.SelectLandmineTargets("LandMine",0,
                new[]{new DeployablePlacement(1,new(1,0,0))},_=>4));
            var effects=new WarCardEffectRuntime(2);
            Check(effects.TryApply("fx-1","44444444444444444444444444444444",
                      new WarCardEffectRequest("CardSlowdown",new(1,0,1),1,0),10)&&
                  !effects.TryApply("fx-1","44444444444444444444444444444444",
                      new WarCardEffectRequest("CardSlowdown",new(1,0,1),1,0),10)&&
                  effects.Count==1&&effects.Expire(10+MatchManifest.TickRate)==1&&effects.Count==0,
                  "War Card effects create idempotent server leases and expire on authoritative ticks");
            var objectiveState=new BattleObjectiveState(new Dictionary<BattleObjectiveKind,int>
                {{BattleObjectiveKind.DestroyCrates,2}});
            var interactables=new BattleInteractableRegistry(1);
            Check(interactables.TryRegister(new BattleInteractable(700,BattleObjectiveKind.DestroyCrates,1))&&
                  !interactables.TryRegister(new BattleInteractable(700,BattleObjectiveKind.DestroyCrates,1))&&
                  interactables.TryRecord("55555555555555555555555555555555",700,
                      "44444444444444444444444444444444",objectiveState,1)&&objectiveState.Progress(BattleObjectiveKind.DestroyCrates)==1&&
                  interactables.TryRecord("55555555555555555555555555555555",700,
                      "44444444444444444444444444444444",objectiveState,1)&&objectiveState.Progress(BattleObjectiveKind.DestroyCrates)==1,
                  "registered interactables advance objectives through idempotent source event IDs");
            Check(BattleEventFactory.Spawn(1,700,Vector3.Zero,"deployable").Kind=="spawn:deployable"&&
                  BattleEventFactory.Objective(2,700,Vector3.Zero,BattleObjectiveKind.DestroyCrates).Kind=="objective:DestroyCrates"&&
                  BattleEventFactory.Effect(3,701,Vector3.Zero,WarCardEffectKind.Shield).Kind=="effect:Shield",
                  "authoritative entities use canonical validated spawn, objective, and effect event kinds");
            Check(BattleModeCapabilityPolicy.Resolve(MatchManifest.RifleCombatMode)==BattleModeCapability.Rifle&&
                  BattleModeCapabilityPolicy.Resolve(MatchManifest.ShotgunCombatMode)==BattleModeCapability.Shotgun&&
                  BattleModeCapabilityPolicy.Resolve(MatchManifest.SmgCombatMode)==BattleModeCapability.Smg&&
                  BattleModeCapabilityPolicy.Resolve(MatchManifest.PistolCombatMode)==BattleModeCapability.Pistol&&
                  BattleModeCapabilityPolicy.Resolve(MatchManifest.LmgCombatMode)==BattleModeCapability.Lmg&&
                  BattleModeCapabilityPolicy.Resolve(MatchManifest.MixedCombatMode)==BattleModeCapability.Mixed,
                  "battle admission resolves only explicitly implemented combat capabilities");
            Reject(()=>BattleModeCapabilityPolicy.Resolve("unimplemented-mode"));
            Reject(()=>ClientBattleEventValidator.Validate(new ClientBattleEvent(1,"rpc:arbitrary",1,Vector3.Zero)));
            SessionKeyRotationPolicy.Validate(1,2,Enumerable.Repeat((byte)7,32).ToArray());
            Reject(()=>SessionKeyRotationPolicy.Validate(2,2,Enumerable.Repeat((byte)7,32).ToArray()));
            var originalKey=Enumerable.Repeat((byte)7,32).ToArray();var keyRing=new SessionKeyRing(1,originalKey);
            originalKey[0]=99;var exposedKey=keyRing.CurrentKey;exposedKey[1]=98;
            Check(keyRing.Generation==1&&keyRing.CurrentKey[0]==7&&keyRing.CurrentKey[1]==7,
                  "transport session keys are defensively copied at construction and access");
            keyRing.Rotate(2,Enumerable.Repeat((byte)8,32).ToArray());
            Check(keyRing.Generation==2&&keyRing.CurrentKey.All(x=>x==8),"transport key rotation advances generation atomically");
            Reject(()=>keyRing.Rotate(2,Enumerable.Repeat((byte)9,32).ToArray()));
            Check(keyRing.Generation==2&&keyRing.CurrentKey.All(x=>x==8),"rejected transport key rotation preserves the active key");
            ReliableEventRetentionPolicy.Validate(10,20,15,32);
            Reject(()=>ReliableEventRetentionPolicy.Validate(1,5000,0,32));
            SnapshotTickPolicy.Validate(10,20);
            Reject(()=>SnapshotTickPolicy.Validate(20,20));
            Check(MapEntityIdentityPolicy.Validate(new MapEntityIdentity("City_Multiplayer",new string('a',64),42)).SourceIndex==42,
                  "dynamic map entities bind to a canonical map revision and source index");
            Reject(()=>MapEntityIdentityPolicy.Validate(new MapEntityIdentity("City_Multiplayer",new string('A',64),42)));
            var animation=new PlayerAnimationStateMachine();
            Check(animation.TryTransition(PlayerAnimationState.Idle)&&animation.TryTransition(PlayerAnimationState.Aim)&&animation.TryTransition(PlayerAnimationState.Fire)&&
                  animation.TryTransition(PlayerAnimationState.Reload)&&animation.TryTransition(PlayerAnimationState.Dead)&&
                  !animation.TryTransition(PlayerAnimationState.Idle),
                  "player animation state machine enforces legal combat transitions and terminal death");
            Check(PlayerMovementPolicy.ValidateStep(Vector3.Zero,new(0.01f,0,0),PlayerAnimationState.Walk,1f).X>.009f,
                  "movement policy accepts bounded stance-specific tick displacement");
            Reject(()=>PlayerMovementPolicy.ValidateStep(Vector3.Zero,new(10,0,0),PlayerAnimationState.Walk,1f));
            var covers=new CoverOccupancyRegistry(4);
            Check(covers.TryClaim(1,"11111111111111111111111111111111")&&
                  covers.TryClaim(1,"11111111111111111111111111111111")&&
                  !covers.TryClaim(1,"22222222222222222222222222222222")&&
                  covers.ReleasePlayer("11111111111111111111111111111111")==1&&covers.Count==0,
                  "cover occupancy is exclusive, idempotent for its owner, and releases on player exit");
            Check(covers.TryClaim(2,"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")&&
                  covers.Release(2,"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")&&covers.Count==0,
                  "cover ownership canonicalizes player GUID casing across reconnect boundaries");
            var coverSnapshot=new CoverOccupancyRegistry();
            coverSnapshot.TryClaim(3,"33333333333333333333333333333333");
            Check(coverSnapshot.Snapshot().Single().CoverIndex==3&&
                  coverSnapshot.Snapshot().Single().PlayerId=="33333333333333333333333333333333",
                  "cover occupancy exposes deterministic reconnect snapshot rows");
            var weaponCatalog=new HashSet<string>(new[]{"Google2u.AK47","Google2u.MP5"},StringComparer.Ordinal);
            Check(BattleLoadoutPolicy.ValidateWeaponIds(new[]{"Google2u.AK47"},weaponCatalog).Count==1,
                  "allocator loadouts resolve weapon identities against a trusted catalog");
            Reject(()=>BattleLoadoutPolicy.ValidateWeaponIds(new[]{"Google2u.AK47","Google2u.AK47"},weaponCatalog));
            var cardCatalog=WarCardEffectCatalog.All.Select(x=>x.CardId).ToHashSet(StringComparer.Ordinal);
            Check(BattleLoadoutPolicy.ValidateCardIds(new[]{"CardAirstrike"},cardCatalog).Count==1,
                  "allocator loadouts resolve War Card identities against the recovered effect catalog");
            Reject(()=>BattleLoadoutPolicy.ValidateCardIds(new[]{"CardUnknown"},cardCatalog));
            Reject(()=>WarCardEffectRequestValidator.Validate(new WarCardEffectRequest("CardAirstrike",new(1,0,1),1,0)));
            BattleTerminalPolicy.Validate("death","11111111111111111111111111111111",true,false);
            Reject(()=>BattleTerminalPolicy.Validate("death","11111111111111111111111111111111",true,true));
            Reject(()=>BattleTerminalPolicy.Validate("player-killed","11111111111111111111111111111111",true,true));
            Reject(()=>BattleTerminalPolicy.Validate("unknown","11111111111111111111111111111111",false,false));
            Check(WeaponFireModePolicy.Validate(WeaponFireMode.Click,true)==WeaponFireMode.Click&&
                  WeaponFireModePolicy.Validate(WeaponFireMode.Burst,true)==WeaponFireMode.Burst,
                  "weapon firing modes require an explicit source capability");
            Reject(()=>WeaponFireModePolicy.Validate(WeaponFireMode.Zoom,false));
            var projectileAuthority=ProjectileAuthorityPolicy.Validate(new ProjectileAuthority(900,
                "11111111111111111111111111111111",Vector3.Zero,new(2,0,0),20,0,30));
            Check(Math.Abs(projectileAuthority.Direction.Length()-1)<.001f&&projectileAuthority.Speed==20,
                  "projectile authority normalizes direction and bounds server flight lifetime");
            Reject(()=>ProjectileAuthorityPolicy.Validate(new ProjectileAuthority(900,
                "11111111111111111111111111111111",Vector3.Zero,Vector3.Zero,20,0,30)));
            Check(ExplosionAuthorityPolicy.Validate(new ExplosionAuthority(901,
                "11111111111111111111111111111111",Vector3.Zero,5,20,8)).PelletCount==8,
                  "explosion authority bounds origin, radius, damage, and pellet count");
            Reject(()=>ExplosionAuthorityPolicy.Validate(new ExplosionAuthority(901,
                "11111111111111111111111111111111",Vector3.Zero,101,20,8)));
            var identity=StableEntityIdentityPolicy.Validate(new StableEntityIdentity(123,1));
            Check(StableEntityIdentityPolicy.IsCurrent(identity,new StableEntityIdentity(123,1))&&
                  !StableEntityIdentityPolicy.IsCurrent(identity,new StableEntityIdentity(123,2)),
                  "stable entities require matching generation and reject stale identity observations");
            Reject(()=>StableEntityIdentityPolicy.Validate(new StableEntityIdentity(123,0)));
            var stableRegistry=new StableEntityRegistry(2);
            var stableRecord=new StableEntityRecord(new StableEntityIdentity(125,1),"11111111111111111111111111111111","barrel");
            Check(stableRegistry.TrySpawn(stableRecord)&&stableRegistry.Snapshot().Count==1&&stableRegistry.TryGet(stableRecord.Identity,out _)&&
                  !stableRegistry.TryGet(new StableEntityIdentity(125,2),out _)&&
                  !stableRegistry.TryDestroy(new StableEntityIdentity(125,2))&&stableRegistry.TryDestroy(stableRecord.Identity),
                  "stable entity registry enforces generation-bound lookup and destruction");
            Check(!stableRegistry.TrySpawn(new StableEntityRecord(new StableEntityIdentity(126,0),stableRecord.OwnerPlayerId,"barrel")),
                  "stable entity admission returns a normal rejection for malformed generations");
            Check(stableRegistry.TrySpawn(stableRecord)&&stableRegistry.RemoveOwner(stableRecord.OwnerPlayerId)==1&&stableRegistry.Count==0,
                  "stable entity registry cleans all entities for a disconnected owner");
            var entitySnapshot=EntitySnapshotPolicy.Validate(new EntitySnapshot(new StableEntityIdentity(124,1),
                "11111111111111111111111111111111",Vector3.Zero,Quaternion.Identity,5));
            Check(entitySnapshot.ServerTick==5,"entity snapshots bind stable identity, owner, transform, and server tick");
            Reject(()=>EntitySnapshotPolicy.Validate(new EntitySnapshot(new StableEntityIdentity(124,1),
                "11111111111111111111111111111111",Vector3.Zero,new Quaternion(2,0,0,0),5)));
            Check(ReconnectSnapshotPolicy.Validate(new ReconnectSnapshotCursor(4,8,20),5,10).EventCursor==8,
                  "reconnect snapshots bind retained entity revision, event cursor, and server tick");
            Reject(()=>ReconnectSnapshotPolicy.Validate(new ReconnectSnapshotCursor(6,8,20),5,10));
            var vehicles=new VehicleEntityRegistry(new Dictionary<string,int>{{"ID_UNIT-TANK",1}});
            Check(vehicles.TrySpawn(new VehicleEntity(1001,"ID_UNIT-TANK","11111111111111111111111111111111",1))&&
                  !vehicles.TrySpawn(new VehicleEntity(1002,"ID_UNIT-TANK","11111111111111111111111111111111",1))&&
                  !vehicles.TryDestroy(1001,2)&&vehicles.TryDestroy(1001,1)&&vehicles.Count==0&&
                  vehicles.TrySpawn(new VehicleEntity(1003,"ID_UNIT-TANK","11111111111111111111111111111111",1))&&
                  vehicles.RemoveOwner("11111111111111111111111111111111")==1&&vehicles.Count==0,
                  "vehicle registry enforces family caps and generation-bound destruction");
            Check(VehicleMotionPolicy.ValidateStep(Vector3.Zero,new(.02f,0,0),1.7f).X>.019f,
                  "vehicle motion respects recovered source speed at fixed tick");
            Reject(()=>VehicleMotionPolicy.ValidateStep(Vector3.Zero,new(2,0,0),1.0f));
            var statsLedger=new BattleStatisticsLedger();
            Check(statsLedger.RecordHit("66666666666666666666666666666666")&&
                  !statsLedger.RecordHit("66666666666666666666666666666666")&&
                  statsLedger.RecordArmySpawn("77777777777777777777777777777777")&&
                  statsLedger.RecordArmyLoss("77777777777777777777777777777777")&&
                  statsLedger.Snapshot.ArmySpawns==1&&statsLedger.Snapshot.ArmyLosses==1,
                  "terminal statistics ledger preserves idempotent hit and real army spawn/loss transitions");
            Reject(()=>statsLedger.RecordArmyLoss("88888888888888888888888888888888"));
            var boundedStats=new BattleStatisticsLedger(1);
            boundedStats.RecordHit("99999999999999999999999999999999");
            Reject(()=>boundedStats.RecordKill("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            var performance=new BattlePerformanceLedger();
            performance.Start(10);
            Check(performance.RecordCard("99999999999999999999999999999999")&&
                  !performance.RecordCard("99999999999999999999999999999999")&&
                  performance.RecordObjective("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"),
                  "battle performance ledger deduplicates card and objective credits");
            performance.End(40);
            Check(performance.DurationTicks==30&&performance.CardActivations==1&&performance.ObjectiveCredits==1,
                  "battle performance ledger records authoritative terminal duration");
            var boundedPerformance=new BattlePerformanceLedger(1);
            boundedPerformance.RecordCard("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            Reject(()=>boundedPerformance.RecordObjective("cccccccccccccccccccccccccccccccc"));
            var ribbons=new BattleRibbonLedger();
            Check(ribbons.Record("first-blood")&&!ribbons.Record("first-blood")&&ribbons.Count==1,
                  "battle ribbon credits are bounded and idempotent");
            Reject(()=>ribbons.Record("bad ribbon"));
            var evidence=CompleteBattleEvidenceValidator.Validate(new CompleteBattleEvidence("match-evidence",new string('a',64),
                new BattleStatistics(2,1,1,1),30,new[]{"first-blood"}));
            Check(evidence.DurationTicks==30&&evidence.Ribbons.Count==1,
                  "complete battle evidence validates immutable identity, statistics, duration, and ribbons");
            Reject(()=>CompleteBattleEvidenceValidator.Validate(new CompleteBattleEvidence("match-evidence",new string('a',64),
                new BattleStatistics(2,1,1,1),30,new[]{"first-blood","first-blood"})));
            var deployImpact=DeployableImpactResolver.Resolve(7,
                "33333333333333333333333333333333",Vector3.Zero,new(.5f,0,0),1f,18f);
            Check(deployImpact.EntityId==7&&deployImpact.Damage==18f&&deployImpact.Distance==.5f,
                  "deployable trigger binds host entity, opposing player, radius, and trusted damage");
            Reject(()=>DeployableImpactResolver.Resolve(7,
                "33333333333333333333333333333333",Vector3.Zero,new(2,0,0),1f,18f));
            var cards=new WarCardReservationState(new[]{("HeavyTurret",1),("LandMine",2)});
            Check(cards.TryReserve("44444444444444444444444444444444","LandMine")&&
                  cards.IsReserved("44444444444444444444444444444444")&&cards.Remaining("LandMine")==1&&
                  !cards.TryReserve("44444444444444444444444444444444","LandMine"),
                  "War Card activation consumes one server-owned card exactly once by request ID");
            Check(cards.TryRelease("44444444444444444444444444444444") && cards.Remaining("LandMine")==2 &&
                  !cards.TryRelease("44444444444444444444444444444444"),
                  "failed War Card effects can release their reservation exactly once");
            Reject(()=>new WarCardReservationState(new[]{("HeavyTurret",1),("HeavyTurret",1)}));
            Check(WarCardEffectCatalog.TryGet("CardAirstrike",out var airstrike)&&
                  airstrike.Kind==WarCardEffectKind.Damage&&airstrike.RequiresTarget&&
                  WarCardEffectCatalog.TryGet("CardHeavyTurret",out var turret)&&
                  turret.Kind==WarCardEffectKind.SpawnDeployable&&WarCardEffectCatalog.All.Count>=16&&
                  !WarCardEffectCatalog.TryGet("CardUnknown",out _),
                  "only explicitly recovered War Card classes enter the authoritative effect registry");
            Check(WarCardEffectRequestValidator.Validate(new WarCardEffectRequest("CardAirstrike",new(1,0,1),2,1)).RequiresTarget,
                  "registered War Card effects validate finite target, duration, and bounded parameters");
            Reject(()=>WarCardEffectRequestValidator.Validate(new WarCardEffectRequest("CardAirstrike",Vector3.Zero,2,1)));
            var lease=new WarCardEffectLease(10,1f);
            Check(lease.ActiveAt(39)&&!lease.ActiveAt(40),"temporary War Card effects expire at their server tick deadline");
            Reject(()=>new WarCardEffectLease(10,float.NaN));
            var stacks=new WarCardEffectStack();
            Check(stacks.TryApply("CardShieldsUp",false)&&!stacks.TryApply("CardShieldsUp",false)&&
                  stacks.TryApply("CardSlowdown",true)&&stacks.TryApply("CardSlowdown",true)&&stacks.Count("CardSlowdown")==2,
                  "War Card effects enforce explicit nonstacking and bounded stacking policy");
            ClientBattleEventValidator.Validate(new ClientBattleEvent(1,"spawn",1,Vector3.Zero));
            Check(true,"Client battle event projection validates bounded sequence, entity, kind, and position");
            Reject(()=>ClientBattleEventValidator.Validate(new ClientBattleEvent(0,"spawn",1,Vector3.Zero)));
            var clientEvents=new ClientBattleEventWindow(2);var clientEvent=clientEvents.Publish("spawn",1,Vector3.Zero);
            Check(clientEvent.Sequence==1&&clientEvents.CanReplay(1),"Client battle events use reliable replay-safe sequencing");
            clientEvents.Acknowledge(1);Check(!clientEvents.CanReplay(1),"Client event acknowledgement retires the event");
            var objectives=new BattleObjectiveState(new Dictionary<BattleObjectiveKind,int>
                {{BattleObjectiveKind.DestroyCrates,3},{BattleObjectiveKind.GainSkillshots,2}});
            Check(objectives.Record(BattleObjectiveKind.DestroyCrates,2)==2&&
                  objectives.Record(BattleObjectiveKind.DestroyCrates,5)==3&&objectives.Complete(BattleObjectiveKind.DestroyCrates)&&
                  objectives.Progress(BattleObjectiveKind.GainSkillshots)==0,
                  "battle objectives apply bounded authoritative progress and never exceed their target");
            Reject(()=>objectives.Record(BattleObjectiveKind.Collect,1));
            Check(objectives.RecordEvent("55555555555555555555555555555555",BattleObjectiveKind.GainSkillshots,1)==1&&
                  objectives.RecordEvent("55555555555555555555555555555555",BattleObjectiveKind.GainSkillshots,1)==1&&
                  objectives.Progress(BattleObjectiveKind.GainSkillshots)==1,
                  "objective event replay is idempotent across duplicate network deliveries");
            var credits=new BattleCreditLedger();
            Check(credits.RecordHit("66666666666666666666666666666666")&&
                  !credits.RecordHit("66666666666666666666666666666666")&&credits.RecordKill("77777777777777777777777777777777")&&
                  !credits.RecordKill("77777777777777777777777777777777")&&credits.HitCount==1&&credits.KillCount==1,
                  "battle hit and kill credits are idempotent across retransmitted combat events");
            Reject(()=>credits.RecordKill("bad-credit-id"));
            BattleStatisticsValidator.Validate(new BattleStatistics(4,2,3,1));
            Check(true,"terminal battle statistics accept conserved hit, kill, spawn, and loss counters");
            Reject(()=>BattleStatisticsValidator.Validate(new BattleStatistics(1,2,0,0)));
            Reject(()=>BattleStatisticsValidator.Validate(new BattleStatistics(0,0,1,2)));
            var arena=new WarArenaPolicy("arena-202609");
            Check(arena.TryEnter("88888888888888888888888888888888")&&
                  !arena.TryEnter("88888888888888888888888888888888")&&arena.IsActive("88888888888888888888888888888888")&&
                  arena.Leave("88888888888888888888888888888888")&&arena.ActiveCount==0,
                  "War Arena entry is bound to a server event and permits one active battle per player");
            Reject(()=>new WarArenaPolicy("arena-invalid"));
            var arenaBattle=new WarArenaBattleState(2);
            Check(arenaBattle.Settle("99999999999999999999999999999999",false)&&arenaBattle.Lives==1&&
                  !arenaBattle.Settle("99999999999999999999999999999999",false)&&
                  arenaBattle.Settle("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",false)&&arenaBattle.Terminal,
                  "War Arena settlement consumes lives once and locks the terminal result");
            arenaBattle.Validate();
            Check(arenaBattle.TryGetSettlement("99999999999999999999999999999999",out var firstArenaWin)&&!firstArenaWin,
                  "War Arena retains the first settlement outcome for deterministic replay");
            Reject(()=>new WarArenaBattleState(0));
            var coop=new CoopMissionState(2);
            Check(coop.AdvanceWave("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",true)&&coop.Wave==2&&
                  !coop.AdvanceWave("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",true)&&
                  coop.AdvanceWave("cccccccccccccccccccccccccccccccc",true)&&coop.Completed,
                  "co-op mission waves advance once per event and complete after the authoritative final wave");
            var coopLeave=new CoopMissionState(3);
            Check(coopLeave.Admit("11111111111111111111111111111111")&&coopLeave.Admit("22222222222222222222222222222222")&&
                  coopLeave.MarkReady("11111111111111111111111111111111")&&coopLeave.MarkReady("22222222222222222222222222222222")&&
                  coopLeave.Started&&coopLeave.Leave("11111111111111111111111111111111")&&coopLeave.Failed,
                  "co-op participant departure fails a started mission authoritatively");
            var failedCoop=new CoopMissionState(2);
            Check(failedCoop.AdvanceWave("dddddddddddddddddddddddddddddddd",false)&&failedCoop.Failed&&
                  !failedCoop.AdvanceWave("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",true),
                  "co-op mission failure closes later progression");
            var timedCoop=new CoopMissionState(3,100);
            Check(!timedCoop.AdvanceClock(99)&&timedCoop.AdvanceClock(100)&&timedCoop.Failed,
                  "co-op mission deadline produces a server-owned terminal timeout");
            Check(CoopMissionModifiersValidator.Validate(new CoopMissionModifiers(true,true,true)).Heroic,
                  "co-op heroic modifiers accept only a coherent server-defined combination");
            Reject(()=>CoopMissionModifiersValidator.Validate(new CoopMissionModifiers(false,true,false)));
            var admittedCoop=new CoopMissionState(1);
            Check(admittedCoop.Admit("12121212121212121212121212121212")&&
                  admittedCoop.Admit("13131313131313131313131313131313")&&
                  admittedCoop.MarkReady("12121212121212121212121212121212")&&
                  admittedCoop.MarkReady("13131313131313131313131313131313")&&admittedCoop.Started&&
                  !admittedCoop.Admit("14141414141414141414141414141414"),
                  "co-op mission starts only after two admitted participants are both ready");
            var offline=new OfflineCampaignPolicy();
            Check(offline.TryStart(1)&&offline.Complete(1)&&offline.IsCompleted(1)&&!offline.TryStart(1)&&
                  !offline.Complete(0),
                  "offline campaign policy keeps local mission completion Photon-free and deterministic");
            Check(offline.RecordObjective(2,"abababababababababababababababab",2,3)==2&&
                  offline.RecordObjective(2,"abababababababababababababababab",2,3)==2&&
                  offline.RecordObjective(2,"acacacacacacacacacacacacacacacac",5,3)==3,
                  "offline campaign objective callbacks are bounded and idempotent");
            var ranks=WarArenaRanking.Order(new[]{new WarArenaRank("15151515151515151515151515151515",9,false),
                new WarArenaRank("14141414141414141414141414141414",1,true),new WarArenaRank("16161616161616161616161616161616",9,false)});
            Check(ranks[0].Flawless&&ranks[1].PlayerId=="15151515151515151515151515151515"&&
                  ranks[2].PlayerId=="16161616161616161616161616161616",
                  "War Arena ranking is flawless-first with deterministic wins and player-ID tie ordering");
            Reject(()=>WarArenaRanking.Order(new[]{new WarArenaRank("bad",1,false)}));
            var scoped=WarArenaRankScope.Current("arena-202609",new[]{
                new WarArenaRankRow("arena-202608",new WarArenaRank("14141414141414141414141414141414",99,true)),
                new WarArenaRankRow("arena-202609",new WarArenaRank("15151515151515151515151515151515",2,false))});
            Check(scoped.Count==1&&scoped[0].PlayerId=="15151515151515151515151515151515",
                  "War Arena rankings exclude stale prior-event rows by exact current event identity");
            WarArenaSnapshotValidator.Validate(new WarArenaSnapshot("arena-202609",
                "17171717171717171717171717171717",2,1,false,1));
            Reject(()=>WarArenaSnapshotValidator.Validate(new WarArenaSnapshot("arena-202609",
                "17171717171717171717171717171717",2,1,false,0)));
            var arenaRewards=new WarArenaRewardState();
            Check(arenaRewards.TryClaim("18181818181818181818181818181818",true,500)&&
                  arenaRewards.IsClaimed("18181818181818181818181818181818")&&
                  !arenaRewards.TryClaim("18181818181818181818181818181818",true,500)&&
                  !arenaRewards.TryClaim("19191919191919191919191919191919",false,1),
                  "War Arena rewards are server-authored and claimed exactly once");
            var events=new ReliableEventWindow(2);var first=events.Append();var second=events.Append();
            Check(first==1&&second==2&&events.NextEventId==3,
                  "reliable event window allocates bounded monotonic IDs");
            events.Acknowledge(first);
            Check(events.Acknowledged==2&&events.Append()==3,"reliable event acknowledgements advance the replay cursor");
            Reject(()=>events.Acknowledge(99));
            var restored=new ReliableEventWindow(2);restored.Restore(events.Snapshot.Next,events.Snapshot.Acknowledged);
            Check(restored.NextEventId==events.NextEventId&&restored.Acknowledged==events.Acknowledged,
                  "reliable event cursor restores monotonically across a process restart");
            Check(restored.CanReplay(2)&&!restored.CanReplay(1)&&!restored.CanReplay(99),
                  "reliable event replay accepts only IDs inside the retained acknowledgement window");
            Check(restored.ReplayRange().SequenceEqual(new ulong[]{2,3}),
                  "reliable event replay exposes only the bounded retained ID range");
            Reject(()=>restored.ReplayRange(0));
            var cursorPath=Path.Combine(Path.GetTempPath(),"warfriends-event-cursor-"+Guid.NewGuid().ToString("N"),"cursor.json");
            var cursorStore=new ReliableEventCursorStore(cursorPath);cursorStore.Save(events);
            var loadedCursor=cursorStore.Load(2);
            Check(cursorStore.Exists&&loadedCursor.NextEventId==events.NextEventId&&
                  loadedCursor.Acknowledged==events.Acknowledged,
                  "reliable event cursors persist and restore atomically across restart");
            File.WriteAllText(cursorPath,"{malformed");
            Reject(()=>cursorStore.Load(2));
            try { Directory.Delete(Path.GetDirectoryName(cursorPath)!,true); } catch { }
            var payloadPath=Path.Combine(Path.GetTempPath(),"warfriends-event-payload-"+Guid.NewGuid().ToString("N"),"events.json");
            var payloadStore=new ReliableEventPayloadStore(payloadPath,2);
            payloadStore.Append(new ClientBattleEvent(1,"spawn:player",1,Vector3.Zero));
            payloadStore.Append(new ClientBattleEvent(2,"impact",1,new(1,0,0)));
            payloadStore.Append(new ClientBattleEvent(3,"death",1,new(2,0,0)));
            var loadedPayload=new ReliableEventPayloadStore(payloadPath,2);
            Check(loadedPayload.ReplayAfter(1).Select(x=>x.Sequence).SequenceEqual(new ulong[]{2,3}),
                  "reliable event payloads persist with bounded replay after restart");
            Reject(()=>loadedPayload.ReplayAfter(0));
            Check(loadedPayload.FirstRetainedSequence==2&&loadedPayload.LastRetainedSequence==3&&
                  !loadedPayload.CanReplayAfter(0)&&loadedPayload.CanReplayAfter(1),
                  "reliable event payload retention exposes the cursor boundary for snapshot fallback");
            var durablePlan=ReconnectRecoveryCoordinator.Build(new ReconnectSnapshotCursor(4,2,200),5,loadedPayload,200);
            Check(!durablePlan.RequiresFullSnapshot&&durablePlan.ReplayFromEvent==3,
                  "reconnect planning derives event bounds from durable payload authority");
            var durableFull=ReconnectRecoveryCoordinator.Build(new ReconnectSnapshotCursor(4,1,200),5,loadedPayload,200);
            Check(durableFull.RequiresFullSnapshot,"durable replay expiry selects a full snapshot");
            Reject(()=>loadedPayload.Append(new ClientBattleEvent(3,"impact",1,Vector3.Zero)));
            try { Directory.Delete(Path.GetDirectoryName(payloadPath)!,true); } catch { }
            var consumer=new War.Client.MatchEventConsumer();int received=0;consumer.EventReceived+=_=>received++;
            var page=new MatchEventBatch{Code="events",LatestEventId=2};
            page.Events.Add(new MatchEvent{EventId=1,Tick=1,Kind=MatchEventKind.Shot,X=1,Y=0,Z=0});
            page.Events.Add(new MatchEvent{EventId=2,Tick=2,Kind=MatchEventKind.Impact,X=2,Y=0,Z=0});
            Check(consumer.Consume(page)==2&&consumer.LastEventId==2&&received==2,
                  "Client event consumer dispatches contiguous authoritative pages");
            Reject(()=>consumer.Consume(new MatchEventBatch{Code="events",LatestEventId=3,Events={new MatchEvent{EventId=4,Tick=3,Kind=MatchEventKind.Shot}}}));
            var interpolation=new SnapshotInterpolationBuffer(3);interpolation.Add(10,Vector3.Zero);interpolation.Add(20,new(10,0,0));
            Check(interpolation.Sample(15)==new Vector3(5,0,0)&&interpolation.Sample(5)==Vector3.Zero&&
                  interpolation.Sample(30)==new Vector3(10,0,0),
                  "snapshot interpolation is bounded by monotonic server ticks and retained poses");
            Reject(()=>interpolation.Add(20,new(20,0,0)));
            var baseline=new SnapshotBaseline();
            Check(baseline.Apply(1,new[]{new SnapshotEntity(1,Vector3.Zero,1)}).Count==1&&
                  baseline.Apply(2,new[]{new SnapshotEntity(1,Vector3.Zero,2)}).Count==0&&
                  baseline.Apply(3,new[]{new SnapshotEntity(1,new(1,0,0),3)}).Count==1,
                  "snapshot baselines emit only changed entity state across monotonic revisions");
            Reject(()=>baseline.Apply(2,new[]{new SnapshotEntity(1,Vector3.Zero,2)}));
            Reject(()=>baseline.Apply(4,new[]{new SnapshotEntity(2,Vector3.Zero,4),new SnapshotEntity(2,Vector3.One,4)}));
            Check(baseline.Apply(4,new[]{new SnapshotEntity(2,Vector3.Zero,4)}).Count==1,
                  "invalid snapshot rows do not partially mutate the baseline revision");
            Check(SnapshotInterestFilter.Within(new[]{new SnapshotEntity(2,new(1,0,0),1),new SnapshotEntity(1,Vector3.Zero,1)},Vector3.Zero,2)
                  .Select(x=>x.EntityId).SequenceEqual(new ulong[]{1,2}),
                  "snapshot interest filtering returns only bounded nearby entities");
            Reject(()=>SnapshotInterestFilter.Within(Array.Empty<SnapshotEntity>(),Vector3.Zero,501));
            Reject(()=>SnapshotInterestFilter.Within(new[]{new SnapshotEntity(1,Vector3.Zero,1),new SnapshotEntity(1,Vector3.One,1)},Vector3.Zero,2));
            Reject(()=>SnapshotInterestFilter.Within(new[]{new SnapshotEntity(3,Vector3.Zero,0)},Vector3.Zero,2));
            var inputAcks=new InputAcknowledgementWindow();
            Check(inputAcks.TryAcknowledge(1,1)&&inputAcks.LastAcknowledged==1&&
                  !inputAcks.TryAcknowledge(1,2)&&inputAcks.TryAcknowledge(2,2)&&
                  !inputAcks.TryAcknowledge(0,2),
                  "snapshot input acknowledgements advance monotonically and reject duplicate or zero commands");
            var chunks=SnapshotChunker.Chunk(new[]{new SnapshotEntity(3,Vector3.Zero,1),new SnapshotEntity(1,Vector3.Zero,1),new SnapshotEntity(2,Vector3.Zero,1)},2);
            Check(chunks.Count==2&&chunks[0][0].EntityId==1&&chunks[1].Count==1,
                  "snapshot chunking produces bounded deterministic entity batches");
            Reject(()=>SnapshotChunker.Chunk(Array.Empty<SnapshotEntity>(),0));
            var assembled=new SnapshotChunkAssembler(7,2);
            assembled.Add(1,new[]{new SnapshotEntity(2,new(2,0,0),7)});
            Check(!assembled.IsComplete&&assembled.ReceivedChunks==1,"snapshot assembler keeps incomplete revisions bounded");
            assembled.Add(0,new[]{new SnapshotEntity(1,Vector3.Zero,7)});
            Check(assembled.IsComplete&&assembled.Complete().Select(x=>x.EntityId).SequenceEqual(new ulong[]{1,2}),
                  "snapshot assembler reorders complete chunks into deterministic entity order");
            var assembledBaseline=new SnapshotBaseline();
            Check(assembled.ApplyTo(assembledBaseline).Count==2,"complete snapshot chunks apply atomically to a baseline");
            var incompleteAssembler=new SnapshotChunkAssembler(10,2);
            incompleteAssembler.Add(0,new[]{new SnapshotEntity(1,Vector3.Zero,10)});
            Reject(()=>incompleteAssembler.ApplyTo(new SnapshotBaseline()));
            Reject(()=>assembled.Add(0,new[]{new SnapshotEntity(3,Vector3.Zero,7)}));
            var duplicateChunk=new SnapshotChunkAssembler(9,2);
            duplicateChunk.Add(0,new[]{new SnapshotEntity(1,Vector3.Zero,9)});
            Reject(()=>duplicateChunk.Add(1,new[]{new SnapshotEntity(1,new(1,0,0),9)}));
            var badChunk=new SnapshotChunkAssembler(8,1);
            Reject(()=>badChunk.Add(0,new[]{new SnapshotEntity(1,Vector3.Zero,7)}));
            ReconnectCursorValidator.Validate(new ReconnectCursor(4,10),5,8);
            ReconnectCursorValidator.Validate(new ReconnectCursor(4,10),20,5,8,12);
            Check(true,"reconnect cursor accepts retained snapshot and event authority");
            Reject(()=>ReconnectCursorValidator.Validate(new ReconnectCursor(6,10),5,8));
            Reject(()=>ReconnectCursorValidator.Validate(new ReconnectCursor(4,7),5,8));
            var recovery=ReconnectRecoveryCoordinator.Build(new ReconnectSnapshotCursor(4,10,200),5,8,12,200);
            Check(!recovery.RequiresFullSnapshot&&recovery.ReplayFromEvent==11&&recovery.SnapshotRevision==5,
                  "reconnect coordinator creates an incremental retained-event plan");
            var fullRecovery=ReconnectRecoveryCoordinator.Build(new ReconnectSnapshotCursor(4,7,200),5,8,12,200);
            Check(fullRecovery.RequiresFullSnapshot&&fullRecovery.ReplayFromEvent==13,
                  "reconnect coordinator requests a full snapshot when event history is gone");
            Reject(()=>ReconnectRecoveryCoordinator.Build(new ReconnectSnapshotCursor(6,10,200),5,8,12,200));
            var grants=new ReconnectGrantState();var grant=grants.Issue(10,5);
            Check(grants.Validate(grant,15)&&!grants.Validate(grant,16),"reconnect grants expire at their server-owned deadline");
            Check(!grants.Validate(new string('x',100000),10),"reconnect grant validation rejects oversized malformed tokens");
            var rotated=grants.Issue(20,5);
            Check(!grants.Validate(grant,20)&&grants.Validate(rotated,20),"reconnect grant rotation revokes the prior session");
            var boundGrants=new ReconnectGrantState();var bound=boundGrants.Issue("20202020202020202020202020202020",30,5);
            Check(boundGrants.Validate("20202020202020202020202020202020",bound,35)&&
                  !boundGrants.Validate("21212121212121212121212121212121",bound,35),
                  "reconnect grants are bound to their authenticated player identity");
            var unboundAfterBound=boundGrants.Issue(40,5);
            Check(!boundGrants.Validate("20202020202020202020202020202020",unboundAfterBound,40),
                  "unbound reconnect grants clear any prior player binding");
            BattleRoomHandshake.Validate("match-1",new string('a',64),new[]{
                "22222222222222222222222222222222","23232323232323232323232323232323"});
            Check(true,"Photon-free room handshake binds the match manifest and two distinct participants");
            Reject(()=>BattleRoomHandshake.Validate("match-1",new string('a',64),new[]{"bad","bad"}));
            Reject(()=>BattleRoomHandshake.Validate("match-1",new string('a',64),new[]{
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"}));
            var loading=new BattleLoadingState(new string('b',64));
            Check(loading.Admit("24242424242424242424242424242424")&&loading.Admit("25252525252525252525252525252525")&&
                  loading.MarkReady("24242424242424242424242424242424",new string('b',64),true)&&
                  !loading.MarkReady("25252525252525252525252525252525",new string('c',64),true)&&
                  loading.MarkReady("25252525252525252525252525252525",new string('b',64),true)&&loading.Started,
                  "room loading starts only after both clients report the exact manifest and scene readiness");
            var loadingTimeout=new BattleLoadingState(new string('d',64),50);
            Check(!loadingTimeout.TimedOut(49)&&loadingTimeout.TimedOut(50),"room loading has a server-owned readiness deadline");
            Check(loadingTimeout.PhaseAt(49)==BattleLoadingPhase.Waiting&&loadingTimeout.PhaseAt(50)==BattleLoadingPhase.TimedOut,
                  "room loading exposes explicit waiting and timeout phases to the Client adapter");
            BattleLoadingCommandValidator.Validate(new BattleLoadingCommand(BattleLoadingCommandKind.Ready,
                "27272727272727272727272727272727",new string('f',64),""));
            Check(true,"Client loading commands validate player, manifest, and cancellation fields before Worker dispatch");
            Reject(()=>BattleLoadingCommandValidator.Validate(new BattleLoadingCommand(BattleLoadingCommandKind.Ready,"bad","","")));
            var commandLoading=new BattleLoadingState(new string('f',64));
            Check(commandLoading.Apply(new BattleLoadingCommand(BattleLoadingCommandKind.Admit,"28282828282828282828282828282828","","")),"loading command adapter admits a valid participant");
            var senderWindow=new SenderRateWindow(2,10);
            Check(senderWindow.Allow(1)&&senderWindow.Allow(1)&&!senderWindow.Allow(1)&&senderWindow.Allow(11),
                  "hostile-network sender rate windows bound bursts and reset on the next tick window");
            Reject(()=>senderWindow.Allow(0));
            var cancelledLoading=new BattleLoadingState(new string('e',64));
            Check(cancelledLoading.Cancel("client-timeout")&&!cancelledLoading.Cancel("again")&&
                  !cancelledLoading.Admit("26262626262626262626262626262626"),
                  "prestart loading cancellation closes the room before participant admission");
            BattleRuntimeConfigValidator.Validate(new BattleRuntimeConfig(8080,32,30,1200));
            Check(true,"BattleServer runtime configuration accepts cross-platform bounded network settings");
            var frozenConfig=BattleRuntimeConfigValidator.ValidateAndFreeze(new BattleRuntimeConfig(8080,32,30,1200));
            Check(frozenConfig.Port==8080&&frozenConfig.MaxMatches==32&&frozenConfig.TickRate==30&&frozenConfig.MtuBytes==1200,
                  "BattleServer startup freezes validated runtime configuration values");
            Reject(()=>BattleRuntimeConfigValidator.Validate(new BattleRuntimeConfig(80,32,30,1200)));
            Reject(()=>BattleRuntimeConfigValidator.Validate(new BattleRuntimeConfig(8080,32,29,1200)));
            Check(PacketMtuPolicy.Accept(600,1200)&&!PacketMtuPolicy.Accept(1401,1200)&&
                  !PacketMtuPolicy.Accept(600,500),"packet MTU policy is shared by transport ingress and adapters");
            TransportSecurityPolicy.ValidateSigningKey(Enumerable.Repeat((byte)1,32).ToArray());
            Reject(()=>TransportSecurityPolicy.ValidateSigningKey(new byte[32]));
            BattleResultHandoffValidator.Validate(new BattleResultHandoff("match-1",new string('a',64),new BattleStatistics(2,1,1,0),false));
            Check(true,"battle result handoff validates identity and conserved terminal statistics before Backend settlement");
            Reject(()=>BattleResultHandoffValidator.Validate(new BattleResultHandoff("bad id",new string('a',64),new BattleStatistics(2,3,1,0),true)));
            var acceptance=new BattleResultAcceptance();var handoff=new BattleResultHandoff("match-2",new string('a',64),new BattleStatistics(2,1,1,0),true);
            Check(acceptance.Accept(handoff,new string('b',64))&&acceptance.Accept(handoff,new string('b',64))&&
                  !acceptance.Accept(handoff,new string('c',64)),"Backend result acceptance is digest-idempotent and rejects conflicting replay");
            var limitedAcceptance=new BattleResultAcceptance(1);
            Check(limitedAcceptance.Accept(handoff,new string('b',64))&&!limitedAcceptance.Accept(new BattleResultHandoff("match-3",new string('a',64),new BattleStatistics(1,0,0,0),false),new string('c',64)),"Backend result acceptance has bounded retained match IDs");
            var status=new StatusEffectState();
            Check(status.Apply("29292929292929292929292929292929",1,1f,false)&&status.Active("29292929292929292929292929292929",10)&&
                  !status.Apply("29292929292929292929292929292929",10,1f,false),"status effects enforce server duration and nonstacking");
            Check(status.Count==1&&status.Expire(31)==1&&status.Count==0,
                  "expired status leases are pruned before they can leak into later snapshots");
            status.SetImmune("30303030303030303030303030303030",true);
            Check(!status.Apply("30303030303030303030303030303030",1,1f,true),"status immunity blocks application");
            Check(HealingPolicy.Apply(90,100,20)==100,"healing clamps to authoritative maximum health");
            Reject(()=>HealingPolicy.Apply(101,100,1));
            Check(ArmorPolicy.Mitigate(100,.25f)==75,"armor mitigation is bounded and server-authored");
            Reject(()=>ArmorPolicy.Mitigate(100,.96f));
            Reject(()=>restored.Restore(1,2));
            var arenaStore=new WarArenaSnapshotStore();
            Check(arenaStore.TryPublish(new WarArenaSnapshot("arena-202609",
                    "17171717171717171717171717171717",0,2,false,1),0)&&
                  !arenaStore.TryPublish(new WarArenaSnapshot("arena-202609",
                    "17171717171717171717171717171717",1,2,false,2),0)&&
                  arenaStore.TryPublish(new WarArenaSnapshot("arena-202609",
                    "17171717171717171717171717171717",1,2,false,2),1),
                  "Arena snapshots publish through monotonic revision compare-and-set");
            var attackDefinition=new ArmyBaseShotStats(1f,2,4,1f,1f);
            var randomValues=new Queue<float>(new[]{.6f,.1f,.9f,.2f,.8f,.4f});
            var attack=new ArmyRusherAttackState(attackDefinition,()=>randomValues.Count>0?randomValues.Dequeue():.1f);
            Check(!attack.TryBegin(false,1,0) && attack.TryBegin(true,1,2) &&
                  attack.Phase==ArmyRusherAttackPhase.Windup && attack.BatchSize==3,
                  "Rusher attack requires an eligible post-arrival target and chooses a bounded source batch");
            Check(!attack.AdvanceTick() && attack.Phase==ArmyRusherAttackPhase.Windup &&
                  !attack.AdvanceTick() && attack.AdvanceTick() && attack.Phase==ArmyRusherAttackPhase.Firing &&
                  attack.ShotDue && attack.CurrentShotIsReal && attack.CommitShot() &&
                  attack.BatchCursor==1 && attack.CommitShot() && attack.CommitShot() &&
                  attack.Phase==ArmyRusherAttackPhase.Cooldown && attack.CooldownTicksRemaining>=30,
                  "Rusher attack preserves windup, ordered real-shot bits, and cooldown after the batch");
            var rusherCooldown=new ArmyRusherAttackState(new(1f,1,1,.1f,.2f),()=>0,
                cooldownMinSeconds:2f,cooldownMaxSeconds:4f);
            Check(rusherCooldown.TryBegin(true,1,0)&&rusherCooldown.AdvanceTick()&&
                  rusherCooldown.CommitShot()&&rusherCooldown.CooldownTicksRemaining==60,
                  "Rusher completion overrides generic upgrade timing with the source two-to-four-second cooldown");
            Reject(()=>new ArmyRusherAttackState(new ArmyBaseShotStats(0f,0,15,-1,2)));
            Reject(()=>new ArmyRusherAttackState(new(1f,1,1,1,1),cooldownMinSeconds:2f));
            var shotIntent=new MatchEngine.ArmyRusherShotIntent(77,
                "11111111111111111111111111111111","22222222222222222222222222222222",16,new(1,2,3),true,0,2);
            var impact=ArmyRusherImpactResolver.Resolve(shotIntent,
                new ShotCollision(1,new(1.1f,2,3),"",shotIntent.TargetPlayerId,.75f),
                12f);
            Check(impact.EntityKey==77 && impact.AttackerPlayerId==shotIntent.OwnerPlayerId &&
                  impact.VictimPlayerId==shotIntent.TargetPlayerId &&
                  impact.Damage==12f && impact.PartWeight==.75f,
                  "Rusher impact proof binds collision target, trusted damage, and batch identity");
            Reject(()=>ArmyRusherImpactResolver.Resolve(shotIntent,
                new ShotCollision(1,new(5,2,3),"",shotIntent.TargetPlayerId,.75f),12f));
            var armyFlight=new ArmyProjectileFlight(9,77,new(0,0,0),new(1,0,0),30,10,
                (from,direction,range)=>new ShotCollision(.2f,from+direction*.2f,"",
                    shotIntent.TargetPlayerId,.5f));
            var armyImpact=armyFlight.Advance(11);
            Check(armyImpact is {ProjectileId:9,EntityKey:77,Tick:11} &&
                  armyFlight.Finished && armyImpact.Collision.PlayerId==shotIntent.TargetPlayerId,
                  "army projectile flight carries entity ownership and fixed-tick collision impact");
            var unadvancedFlight=new ArmyProjectileFlight(10,77,new(0,0,0),new(2,0,0),30,10,
                (_,_,_)=>null);
            Reject(()=>unadvancedFlight.Advance(13));
            var invalidShot=JsonNode.Parse(File.ReadAllText(armyPath))!;
            invalidShot["families"]![6]!["baseShot"]!["probabilityOfRealShot"]=1.5;
            File.WriteAllText(armyTemp,invalidShot.ToJsonString());
            string shotRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(armyTemp)));
            Reject(()=>ArmyDeploymentCatalog.Load(armyTemp,shotRevision,pin.SceneRevision));
            Reject(()=>content.Army.EffectiveSpeed("ID_UNIT-SWAT",float.NaN));
            Reject(()=>content.Army.EffectiveSpeed("ID_UNIT-SWAT",100f));
            var invalidSpeed=JsonNode.Parse(File.ReadAllText(armyPath))!;
            invalidSpeed["families"]![0]!["baseSpeed"]=0;
            File.WriteAllText(armyTemp,invalidSpeed.ToJsonString());
            string speedRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(armyTemp)));
            Reject(()=>ArmyDeploymentCatalog.Load(armyTemp,speedRevision,pin.SceneRevision));
            var wrongRuntimeSpeed=JsonNode.Parse(File.ReadAllText(armyPath))!;
            wrongRuntimeSpeed["families"]![0]!["movementSpeed"]=1.5;
            File.WriteAllText(armyTemp,wrongRuntimeSpeed.ToJsonString());
            string runtimeSpeedRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(armyTemp)));
            var wrongSpeedCatalog=ArmyDeploymentCatalog.Load(armyTemp,runtimeSpeedRevision,pin.SceneRevision);
            Reject(()=>wrongSpeedCatalog.ValidateSourceSheet(Path.Combine(directory,"recovered-battle-content.json")));
            var invalidAgent=JsonNode.Parse(File.ReadAllText(armyPath))!;
            invalidAgent["infantryAgent"]!["radius"]=0.01;
            File.WriteAllText(armyTemp,invalidAgent.ToJsonString());
            string agentRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(armyTemp)));
            Reject(()=>ArmyDeploymentCatalog.Load(armyTemp,agentRevision,pin.SceneRevision));
            var modified=JsonNode.Parse(File.ReadAllText(armyPath))!;
            modified["families"]![0]!["options"]![0]!["power"]=999;
            File.WriteAllText(armyTemp,modified.ToJsonString());
            string altered=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(armyTemp)));
            var falseCatalog=ArmyDeploymentCatalog.Load(armyTemp,altered,pin.SceneRevision);
            Reject(()=>falseCatalog.ValidateSourceSheet(Path.Combine(directory,"recovered-battle-content.json")));
        }
        finally { if(File.Exists(armyTemp))File.Delete(armyTemp); }
        Check(content.Maps.Sum(m=>content.Barrels.ForMap(m).Count)==29 &&
              content.Maps.All(m=>content.Barrels.ForMap(m).All(b=>m.DynamicColliders.Any(c=>
                  c.ColliderIndex==b.ColliderIndex && c.SourcePath==b.SourcePath))),
              "29 barrel GameObject and collider file IDs bind to the pinned map shapes");
        var barrelBinding=content.Barrels.ForMap(content.Maps[0])[0];
        var desert=content.Maps.Single(m=>m.Source.Contains("Desert_Multiplayer",StringComparison.Ordinal));
        Check(content.Barrels.ForMap(desert).Any(b=>
              !content.BarrelOverlap.Targets(desert,b.ColliderIndex).SequenceEqual(
                  content.BarrelOverlap.Targets(desert,b.ColliderIndex).OrderBy(index=>index))),
              "pinned Unity collider order is preserved instead of sorting Desert chain targets");
        Check(content.BarrelPolicy.MaxDisplayLevel==43 && content.BarrelPolicy.MaxHealth(0)==50f &&
              content.BarrelPolicy.MaxHealth(42)==50f+((float)42/43)*6f &&
              content.Maps.Sum(m=>content.Barrels.ForMap(m).Count(b=>b.ShotCoefficient==1f))==29,
              "Barrel.Awake health formula uses 43 recovered levels and all serialized shot multipliers");
        var barrel=new BarrelLifecycle(content.BarrelPolicy,42,barrelBinding);
        Check(!barrel.ApplyShot(10) && !barrel.Destroyed && barrel.Revision==1 &&
              barrel.Health==barrel.MaxHealth-10,"first host shot reduces barrel health once");
        Check(barrel.ApplyShot(100) && barrel.Destroyed && barrel.Revision==2 &&
              !barrel.ApplyShot(100) && barrel.Revision==2,
              "lethal shot emits one barrel death transition and duplicate damage is inert");
        Reject(()=>content.BarrelPolicy.MaxHealth(43));
        Reject(()=>new BarrelLifecycle(content.BarrelPolicy,-1,barrelBinding));
        Reject(()=>new BarrelLifecycle(content.BarrelPolicy,0,barrelBinding with {ShotCoefficient=0}));
        Reject(()=>new BarrelLifecycle(content.BarrelPolicy,0,barrelBinding).ApplyShot(float.NaN));
        Check(BarrelExplosion.Resolve(0,0)==new BarrelExplosionHit(BarrelExplosionHitKind.Explode,180f) &&
              BarrelExplosion.Resolve(1.099f,1.099f).Kind==BarrelExplosionHitKind.Explode &&
              BarrelExplosion.Resolve(1.1f,1.1f)==new BarrelExplosionHit(BarrelExplosionHitKind.Shiver,180f) &&
              BarrelExplosion.Resolve(1.8f,1.8f)==new BarrelExplosionHit(BarrelExplosionHitKind.Shiver,15f) &&
              BarrelExplosion.Resolve(1.8001f,1.8001f)==new BarrelExplosionHit(BarrelExplosionHitKind.Shiver,15f),
              "source barrel explosion dead-radius and hurt-radius branch boundaries");
        float midpoint=BarrelExplosion.Resolve(1.45f,1.45f).Damage;
        Check(Math.Abs(midpoint-56.25f)<.0001f,
              "source barrel explosion uses squared falloff between 15 and 180 damage");
        Reject(()=>BarrelExplosion.Resolve(float.NaN,0));
        Check(content.Explosions.PlayerNormal==.88f && content.Explosions.PlayerOvertime==.6f &&
              content.Explosions.Shield==2f && content.Explosions.Friendly==.5f,
              "all four weaponless explosion constants come from pinned MainScene rows");
        var pose=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0).Collision;
        var blastCenter=pose.Parts[0].TransformPosition;
        var normalBlast=BarrelExplosion.ResolvePlayer(blastCenter,pose,new PlayerCombatManifest(1000),
            1000,false,1,content.Explosions);
        var overtimeBlast=BarrelExplosion.ResolvePlayer(blastCenter,pose,new PlayerCombatManifest(1000),
            1000,true,1,content.Explosions);
        Check(normalBlast?.Kind==BarrelExplosionHitKind.Explode &&
              normalBlast.PartPath==pose.Parts[0].SourcePath &&
              Math.Abs(normalBlast.Result.Damage-158.4f)<.0001f &&
              Math.Abs(overtimeBlast!.Result.Damage-108f)<.0001f,
              "barrel explosion selects first source part and applies normal/overtime player coefficient");
        var outerBlast=BarrelExplosion.ResolvePlayer(blastCenter+System.Numerics.Vector3.UnitX*1.5f,
            pose,new PlayerCombatManifest(1000),1000,false,1,content.Explosions);
        Check(outerBlast?.Kind==BarrelExplosionHitKind.Shiver &&
              outerBlast.Result.Damage>15f*.88f && outerBlast.Result.Damage<180f*.88f &&
              BarrelExplosion.ResolvePlayer(blastCenter+System.Numerics.Vector3.UnitX*10f,
                  pose,new PlayerCombatManifest(1000),1000,false,1,content.Explosions)==null,
              "outer barrel blast shivers only overlapping current player parts");
        string barrelPath=Path.Combine(directory,"recovered-barrel-scene-bindings.json");
        string barrelTemp=Path.Combine(directory,"barrel-binding-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var pin=JsonSerializer.Deserialize<CombatContentManifest>(File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
            Reject(()=>BarrelSceneCatalog.Load(barrelPath,new string('0',64),content.Maps));
            Reject(()=>BarrelOverlapOrderCatalog.Load(Path.Combine(directory,"unity-barrel-overlap-reference.json"),
                new string('0',64),content.Maps,content.Barrels));
            var damaged=JsonNode.Parse(File.ReadAllText(barrelPath))!;
            var barrels=damaged["maps"]![0]!["barrels"]!.AsArray();
            barrels[1]!["gameObjectFileId"]=barrels[0]!["gameObjectFileId"]!.GetValue<int>();
            File.WriteAllText(barrelTemp,damaged.ToJsonString());
            string altered=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(barrelTemp)));
            Reject(()=>BarrelSceneCatalog.Load(barrelTemp,altered,content.Maps));
            Check(pin.BarrelBindingsRevision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(barrelPath))),
                "barrel source identities are pinned into the combat manifest");
        }
        finally{if(File.Exists(barrelTemp))File.Delete(barrelTemp);}
        Check(content.Shields.RankCount==44 && content.Shields.WeaponCount==66 &&
              content.Shields.Health(0)==560 && content.Shields.Health(43)==4626,
              "complete recovered rank-indexed shield HP policy");
        Check(content.Shields.DamageToShield("Google2u.Shotgun_SPAS")==1 &&
              content.Shields.DamageToShield("Google2u.AssaultRifle_AK47")==1 &&
              content.Shields.RepairSeconds==6 && Math.Abs(content.Shields.RespawnRatePerSecond-.3f)<.00001f &&
              content.Shields.RepairEnabled,"weapon and repair shield policy from pinned source");
        Reject(()=>content.Shields.Health(44));
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var manifest=new MatchManifest("content-match","content-host","fixture-map",new string('a',64),content.Revision,MatchManifest.PrototypeMode,10,60,10,
            [new(new string('a',32),weapon,WeaponUpgrade:0),new(new string('b',32),weapon,WeaponUpgrade:0)]);
        var engine=new MatchEngine(manifest,content:content);
        Check(engine.Admit(manifest.Players[0].PlayerId),"source-bound allocation admits roster");
        Reject(()=>new MatchEngine(manifest));
        Reject(()=>new MatchEngine(manifest with { CatalogRevision=new string('b',64) },content:content));
        Reject(()=>new MatchEngine(manifest with { Players=[manifest.Players[0] with { WeaponUpgrade=null },manifest.Players[1]] },content:content));
        Reject(()=>new MatchEngine(manifest with { Players=[manifest.Players[0] with { WeaponUpgrade=26 },manifest.Players[1]] },content:content));
        Reject(()=>new MatchEngine(manifest with { Players=[manifest.Players[0] with { Weapon=weapon with { ClipSize=999 } },manifest.Players[1]] },content:content));
        Reject(()=>new MatchEngine(manifest with { Players=[manifest.Players[0] with { Weapon=weapon with { CadenceSeconds=.01 } },manifest.Players[1]] },content:content));
        var park=content.Maps.Single(m=>m.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var selector=new ArmySpawnPointSelector(content.ArmySpawnPoints);
        var assault=content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-ASSAULT");
        var commando=content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-COMMANDO");
        var minigunner=content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-MINIGUNNER");
        var helicopterFamily=content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-HELICOPTER");
        var opponentPosition=park.Covers.First(c=>c.Main && c.Fraction==2).Position;
        var normal=content.ArmySpawnPoints.ForMap(park).Where(p=>p.Collection=="spawnPointsCollection" &&
            p.ComponentType=="SpawnPoint" && p.Fraction==1).ToArray();
        Check(selector.Select(park,assault,1,opponentPosition,_=>0,_=>true)==normal[0] &&
              selector.Select(park,commando,1,opponentPosition,_=>0,_=>true)==
                normal.OrderByDescending(p=>System.Numerics.Vector3.DistanceSquared(p.Position,opponentPosition))
                      .ThenBy(p=>p.Order).First(),
              "soldier mask and Commando farthest-opponent source selection bind Park points");
        var miniSelector=new ArmySpawnPointSelector(content.ArmySpawnPoints);
        Check(content.Maps.All(sourceMap=>new[]{1,2}.All(side=>
              content.ArmySpawnPoints.ForMap(sourceMap).Count(p=>
                  p.Collection=="spawnPointsCollection" && p.ComponentType=="SpawnPoint" &&
                  p.Fraction==side) is 2 or 3)),
              "all five recovered maps keep Minigunner's Unity-probed two/three-point sort domain");
        var enemyNormal=content.ArmySpawnPoints.ForMap(park).Where(p=>p.Collection=="spawnPointsCollection" &&
            p.ComponentType=="SpawnPoint" && p.Fraction==2).ToArray();
        var allyPosition=park.Covers.First(c=>c.Main && c.Fraction==1).Position;
        Check(normal.Length==2 && enemyNormal.Length==3 &&
              miniSelector.AvailableSlots(park,minigunner,1,_=>true)==int.MaxValue &&
              miniSelector.Select(park,minigunner,1,opponentPosition,_=>0,_=>true)==normal[^1] &&
              miniSelector.Select(park,minigunner,2,allyPosition,_=>0,_=>true)==enemyNormal[0] &&
              miniSelector.Select(park,minigunner,2,allyPosition,_=>0,_=>true)==enemyNormal[^1] &&
              miniSelector.Select(park,minigunner,1,opponentPosition,_=>0,_=>true)==normal[0],
              "Unity 2018 Minigunner comparator alternates source-order endpoints across factions");
        Check(selector.Select(park,helicopterFamily,1,opponentPosition,_=>0,_=>false)==null &&
              selector.Select(park,helicopterFamily,1,opponentPosition,_=>0,_=>true)?.Collection==
                "spawnPointsCollectionHelicopters",
              "helicopter selection respects its dedicated collection and host path occupancy");
        var reservations=new ArmySpawnReservationLedger(content.ArmySpawnPoints,park);
        var helicopterPoint=selector.Select(park,helicopterFamily,1,opponentPosition,_=>0,reservations.Available)!;
        Check(helicopterPoint.JoinWaypointFileId>0 && helicopterPoint.ReservationFileId>0 &&
              reservations.TryReserve(helicopterPoint,101) &&
              selector.Select(park,helicopterFamily,1,opponentPosition,_=>0,reservations.Available)==null &&
              reservations.Release(101) && !reservations.Release(101) &&
              selector.Select(park,helicopterFamily,1,opponentPosition,_=>0,reservations.Available)==helicopterPoint,
              "source waypoint path is reserved once and released on confirmed death");
        var vehicleOffers=new ArmyDeploymentState(content.Army,["ID_UNIT-HELICOPTER"]);
        reservations.TryReserve(helicopterPoint,102);
        Check(vehicleOffers.GenerateOffers(_=>0,f=>selector.CanSelect(park,f,1,reservations.Available)).Count==0 &&
              reservations.Release(102) &&
              vehicleOffers.GenerateOffers(_=>0,f=>selector.CanSelect(park,f,1,reservations.Available))
                  .SequenceEqual([2,2,2]),
              "occupied source path suppresses the vehicle offer until release");
        var coverOne=park.Covers.First(c=>c.Main && c.Fraction==1);
        var coverTwo=park.Covers.First(c=>c.Main && c.Fraction==2);
        var rusherSlots=content.ArmyRusherPoints.ForCover(park,coverTwo.SourceIndex);
        Check(content.ArmyRusherPoints.Choose(park,coverTwo.SourceIndex,rusherSlots[1].Position,_=>false)?.Index==1 &&
              content.ArmyRusherPoints.Choose(park,coverTwo.SourceIndex,rusherSlots[3].Position,_=>false)?.Index is 0 or 1 &&
              content.ArmyRusherPoints.Choose(park,coverTwo.SourceIndex,rusherSlots[3].Position,
                  id=>id==rusherSlots[0].ComponentFileId || id==rusherSlots[1].ComponentFileId)?.Index==3 &&
              content.ArmyRusherPoints.Choose(park,coverTwo.SourceIndex,rusherSlots[3].Position,_=>true)==null,
              "Rusher GetInitPoint preserves nearest primary-point preference and free-slot fallback");
        string[] equipped=["ID_UNIT-ASSAULT"];
        int[] armyStages=[0];
        int[] armySpecial=[133];
        float[] armyDamageScales=[1.5f];
        float[] armySpeedCoefficients=[1.25f];
        float[] armyAccuracyCoefficients=[1.5f];
        var armyManifest=new MatchManifest("army-match","content-host","Park_Multiplayer",park.SourceHash,
            content.Revision,MatchManifest.RifleCombatMode,10,60,10,
            [new(new string('a',32),weapon,1,coverOne.SourceIndex,1,new(1000),0)
                {EquippedArmyUnitIds=equipped,ArmyNormalUpgradeIndexes=armyStages,
                 ArmySpecialUpgradeIndexes=armySpecial,ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1.25f,1f)],
                 ArmyDamageScales=armyDamageScales,ArmySpeedCoefficients=armySpeedCoefficients,
                 ArmyAccuracyCoefficients=armyAccuracyCoefficients},
             new(new string('b',32),weapon,2,coverTwo.SourceIndex,1,new(1000),0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1f,1f)],ArmyDamageScales=[1f],
                 ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]}]);
        var detached=MatchManifest.Validate(armyManifest);
        equipped[0]="ID_UNIT-UNKNOWN";
        armyStages[0]=101;
        armySpecial[0]=0;
        armyDamageScales[0]=99;
        armySpeedCoefficients[0]=99;
        armyAccuracyCoefficients[0]=9;
        Check(detached.Players[0].EquippedArmyUnitIds![0]=="ID_UNIT-ASSAULT" &&
              detached.Players[0].ArmyNormalUpgradeIndexes![0]==0 &&
              detached.Players[0].ArmySpecialUpgradeIndexes![0]==133 &&
              detached.Players[0].ArmyDamageScales![0]==1.5f &&
              detached.Players[0].ArmySpeedCoefficients![0]==1.25f &&
              detached.Players[0].ArmyAccuracyCoefficients![0]==1.5f &&
              new MatchEngine(detached,content:content).HasPlayer(detached.Players[0].PlayerId),
              "trusted equipped army roster and stage are detached and bound to pinned source stats");
        var miniManifest=detached with {MatchId="minigunner-spawn",Players=[detached.Players[0] with
        {
            EquippedArmyUnitIds=["ID_UNIT-MINIGUNNER"],NewArmyUnitIds=null,
            ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[-1],
            ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
            ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
        },detached.Players[1]]};
        var miniMatch=new MatchEngine(miniManifest,content:content);
        string miniOwner=miniManifest.Players[0].PlayerId,miniOpponent=miniManifest.Players[1].PlayerId;
        miniMatch.Admit(miniOwner);miniMatch.Admit(miniOpponent);
        miniMatch.Command(miniOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=miniMatch.ManifestHash}});
        miniMatch.Command(miniOpponent,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=miniMatch.ManifestHash}});
        miniMatch.Advance(60);
        Check(miniMatch.ArmyBatch(miniOwner).OptionIndexes.Contains(20) &&
              miniMatch.Command(miniOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=20}}).Code=="army-deploying",
              "Minigunner is offered and accepted in a source-bound live match");
        miniMatch.Advance(61);
        var miniEntity=miniMatch.ArmyEntityBatch(miniOwner,0,0).Entities.Single();
        Check(miniEntity.UnitId=="ID_UNIT-MINIGUNNER" &&
              miniEntity.SpawnComponentFileId==normal[^1].ComponentFileId,
              "first live Minigunner uses the Unity 2018 even-sort source endpoint");
        Reject(()=>MatchManifest.Validate(detached with { Players=[detached.Players[0] with
            {NewArmyUnitIds=["ID_UNIT-SNIPER"]},detached.Players[1]] }));
        Reject(()=>content.ValidateAllocation(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmyNormalUpgradeIndexes=[101]} : p).ToArray() }));
        Reject(()=>content.ValidateAllocation(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmySpecialUpgradeIndexes=[0]} : p).ToArray() }));
        Reject(()=>MatchManifest.Validate(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmyHealthFactors=[new ArmyHealthFactors(float.NaN,1f)]} : p).ToArray() }));
        Reject(()=>MatchManifest.Validate(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmyDamageScales=[float.NaN]} : p).ToArray() }));
        Reject(()=>MatchManifest.Validate(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmySpeedCoefficients=[float.NaN]} : p).ToArray() }));
        Reject(()=>content.ValidateAllocation(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmySpeedCoefficients=[100f]} : p).ToArray() }));
        Reject(()=>MatchManifest.Validate(detached with { Players=detached.Players.Select((p,i)=>i==0 ?
            p with {ArmyAccuracyCoefficients=[float.NaN]} : p).ToArray() }));
        Check(content.Army.ComposeShot("ID_UNIT-ASSAULT",0,133,null,1.5f).ProbabilityOfRealShot==
              content.Army.ComposeShot("ID_UNIT-ASSAULT",0,133,null).ProbabilityOfRealShot*1.5f,
              "trusted perk accuracy scales the fully composed source real-shot probability");
        var deathMatch=new MatchEngine(detached,content:content);
        string soldierOwner=detached.Players[0].PlayerId,helicopterOwner=detached.Players[1].PlayerId;
        deathMatch.Admit(soldierOwner);deathMatch.Admit(helicopterOwner);
        deathMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=deathMatch.ManifestHash}});
        deathMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=deathMatch.ManifestHash}});
        deathMatch.Advance(60);
        deathMatch.ArmyBatch(soldierOwner);deathMatch.ArmyBatch(helicopterOwner);
        Check(deathMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=0}}).Code=="army-deploying" &&
              deathMatch.Command(helicopterOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=2}}).Code=="army-deploying",
              "both source-equipped factions accept only their issued host deployment");
        Check(deathMatch.Snapshot().Players.All(p=>p.ConfirmedArmySpawns==0 && p.ConfirmedArmyLosses==0),
              "accepted deployment does not masquerade as a confirmed spawned entity");
        for(ulong armyTick=61;armyTick<=70;armyTick++)deathMatch.Advance(armyTick);
        var beforeDeath=deathMatch.ArmyEntityBatch(soldierOwner,0,0);
        var soldierEntity=beforeDeath.Entities.First(x=>x.OwnerPlayerId==soldierOwner);
        var helicopterEntity=beforeDeath.Entities.Single(x=>x.OwnerPlayerId==helicopterOwner);
        Check(deathMatch.Snapshot().Players[0].ConfirmedArmySpawns==2 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmySpawns==1 &&
              deathMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=0}}).Code=="army-deploying" &&
              deathMatch.Snapshot().Players[0].ConfirmedArmySpawns==2,
              "host entity insertion credits actual spawns by owner");
        float spawnedHealth=content.Army.EffectiveHealth("ID_UNIT-ASSAULT",0,133,null,new ArmyHealthFactors(1.25f,1f));
        float spawnedDamage=content.Army.ComposeStats("ID_UNIT-ASSAULT",0,133,null).Damage*1.5f;
        Check(deathMatch.ArmyDamage(soldierEntity.EntityKey)==spawnedDamage &&
              deathMatch.ArmyDamage(helicopterEntity.EntityKey)==
                  content.Army.ComposeStats("ID_UNIT-HELICOPTER",0,null,null).Damage,
              "source upgrade damage and trusted scale are retained by spawned host entities");
        Check(deathMatch.ArmySpeed(soldierEntity.EntityKey)==
                  content.Army.EffectiveSpeed("ID_UNIT-ASSAULT",1.25f) &&
              deathMatch.ArmySpeed(helicopterEntity.EntityKey)==3f,
              "trusted perk coefficient and source ArmyUpgrades speed stay private to spawned entities");
        Check(soldierEntity.MaxHealth==spawnedHealth && soldierEntity.Health==spawnedHealth &&
              deathMatch.ArmyHealth(soldierEntity.EntityKey)==spawnedHealth &&
              deathMatch.ApplyArmyHostDamage(soldierEntity.EntityKey,20f) &&
              deathMatch.ArmyHealth(soldierEntity.EntityKey)==spawnedHealth-20f &&
              deathMatch.ArmyEntityBatch(soldierOwner,0,beforeDeath.Revision).Code=="revision-changed" &&
              deathMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single(x=>x.EntityKey==soldierEntity.EntityKey)
                  .Health==spawnedHealth-20f,
              "trusted health is projected and nonfatal damage invalidates reconnect pages");
        Check(deathMatch.ApplyArmyHostDamage(soldierEntity.EntityKey,spawnedHealth) &&
              deathMatch.ArmyHealth(soldierEntity.EntityKey)==null &&
              deathMatch.ArmyDamage(soldierEntity.EntityKey)==null &&
              deathMatch.ArmySpeed(soldierEntity.EntityKey)==null &&
              !deathMatch.ApplyArmyHostDamage(soldierEntity.EntityKey,20f) &&
              !deathMatch.ConfirmArmyDeath(soldierEntity.EntityKey,false) &&
              deathMatch.ArmyBatch(soldierOwner).Energy==6 &&
              deathMatch.ArmyBatch(helicopterOwner).Energy==5,
              "fatal host damage removes vitality and credits only the opposing faction once");
        Check(deathMatch.Snapshot().Players[0].ConfirmedArmyLosses==1 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmyLosses==0,
              "replayed fatal damage cannot credit another unit loss");
        Check(deathMatch.ConfirmArmyDeath(helicopterEntity.EntityKey,true) &&
              deathMatch.ArmyBatch(helicopterOwner).Energy==9 &&
              deathMatch.ArmyBatch(helicopterOwner).OptionIndexes.Count==3 &&
              deathMatch.ArmyBatch(helicopterOwner).OptionIndexes.All(x=>x==2) &&
              deathMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Count==1 &&
              deathMatch.EventBatch(soldierOwner,3).Events.Count(x=>x.Kind==MatchEventKind.ArmyDied &&
                  x.ArmyEnergyRecipientId==helicopterOwner)==2,
              "suicide refunds owner, releases route, updates projection and emits death receipt");
        Check(deathMatch.Snapshot().Players[1].ConfirmedArmyLosses==1,
              "trusted self-destruction credits the owning player exactly one loss");
        deathMatch.AbortForHostShutdown();
        Check(deathMatch.Snapshot() is {Phase:BattlePhase.Aborted,RewardEligible:false} &&
              deathMatch.Snapshot().Players[0].ConfirmedArmySpawns==2 &&
              deathMatch.Snapshot().Players[0].ConfirmedArmyLosses==1 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmySpawns==1 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmyLosses==1,
              "unscored terminal evidence freezes confirmed army transitions");
        var rusherManifest=detached with {MatchId="rusher-slots",Players=detached.Players.Select(p=>p with
        {
            EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER","ID_UNIT-SWAT","ID_UNIT-FLAMETHROWER"],
            NewArmyUnitIds=null,ArmyNormalUpgradeIndexes=[0,0,0],
            ArmySpecialUpgradeIndexes=[-1,-1,-1],ArmyEliteUpgradeIndexes=[-1,-1,-1],
            ArmyHealthFactors=[new(1f,1f),new(1f,1f),new(1f,1f)],ArmyDamageScales=[1f,1f,1f],
            ArmySpeedCoefficients=[1f,1f,1f],ArmyAccuracyCoefficients=[1f,1f,1f]
        }).ToArray()};
        string? seedText=Environment.GetEnvironmentVariable("WAR_BATTLE_RUSHER_SEED");
        int rusherSeed=seedText==null ? 2 :
            int.Parse(seedText,System.Globalization.CultureInfo.InvariantCulture);
        var rusherChoices=new Random(rusherSeed);
        var rusherMatch=new MatchEngine(rusherManifest,content:content,
            armyChoice:rusherChoices.Next);
        rusherMatch.Admit(soldierOwner);rusherMatch.Admit(helicopterOwner);
        rusherMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=rusherMatch.ManifestHash}});
        rusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=rusherMatch.ManifestHash}});
        rusherMatch.Advance(60);
        ulong rusherTick=60;
        float fourRusherMinimum=float.MaxValue;
        float fourRusherMatureMinimum=float.MaxValue;
        ulong fourRusherMinimumTick=0;
        string fourRusherMinimumPair="";
        for(ulong commandId=2;commandId<=5;commandId++)
        {
            var offer=rusherMatch.ArmyBatch(soldierOwner);
            int selected=offer.OptionIndexes.OrderByDescending(x=>content.Army.Option(x).Count).First();
            Check(rusherMatch.Command(soldierOwner,new MatchCommand{CommandId=commandId,
                DeployArmy=new DeployArmyCommand{OptionIndex=selected}}).Code=="army-deploying",
                "source Rusher slot accepts an offered unit while capacity remains");
            int optionCount=content.Army.Option(selected).Count;
            if(rusherMatch.ArmyEntityBatch(soldierOwner,0,0).ActiveCount+optionCount==4)
                Check(rusherMatch.ArmyBatch(soldierOwner).Code=="army-unavailable",
                    "queued Rushers exhaust the four source slots before their spawn ticks");
            ulong finishTick=rusherTick+(ulong)(9*optionCount)+150;
            while(rusherTick<finishTick)
            {
                rusherMatch.Advance(++rusherTick);
                var movingRows=rusherMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
                for(int first=0;first<movingRows.Count;first++)
                    for(int second=first+1;second<movingRows.Count;second++)
                    {
                        float gap=Vector2.Distance(new(movingRows[first].X,movingRows[first].Z),
                            new(movingRows[second].X,movingRows[second].Z));
                        if(rusherTick>=movingRows[first].SpawnTick+4 &&
                           rusherTick>=movingRows[second].SpawnTick+4)
                            fourRusherMatureMinimum=Math.Min(fourRusherMatureMinimum,gap);
                        if(gap<fourRusherMinimum)
                        {
                            fourRusherMinimum=gap;fourRusherMinimumTick=rusherTick;
                            fourRusherMinimumPair=$"{movingRows[first].EntityKey}/spawn{movingRows[first].SpawnComponentFileId}/slot"+
                                $"{rusherMatch.RusherWalkingTarget(movingRows[first].EntityKey)?.RusherPointFileId} " +
                                $"{movingRows[first].X:F2},{movingRows[first].Z:F2} vs " +
                                $"{movingRows[second].EntityKey}/spawn{movingRows[second].SpawnComponentFileId}/slot"+
                                $"{rusherMatch.RusherWalkingTarget(movingRows[second].EntityKey)?.RusherPointFileId} " +
                                $"{movingRows[second].X:F2},{movingRows[second].Z:F2}";
                        }
                    }
                if(rusherTick%90==0)
                {rusherMatch.ArmyEntityBatch(soldierOwner,0,0);rusherMatch.ArmyEntityBatch(helicopterOwner,0,0);}
            }
            if(rusherMatch.ArmyEntityBatch(soldierOwner,0,0).ActiveCount==4)break;
        }
        var rusherRows=rusherMatch.ArmyEntityBatch(soldierOwner,0,0);
        Console.WriteLine($"Four live host Rushers minimum planar separation {fourRusherMinimum:F3} " +
            $"at tick {fourRusherMinimumTick}: {fourRusherMinimumPair}; " +
            $"mature minimum {fourRusherMatureMinimum:F3}");
        Check(fourRusherMatureMinimum>=.34f,
              "mature host Rusher positions retain two source NavMeshAgent radii of separation");
        Check(rusherRows.ServerTick==rusherTick &&
              rusherRows.Entities.All(entity=>entity.PositionTick>entity.SpawnTick &&
                  entity.PositionTick<=rusherRows.ServerTick),
              "paged Rusher roster carries current host position ticks without movement revision churn");
        var rusherMap=content.Maps.Single(m=>Path.GetFileNameWithoutExtension(m.Source)==rusherManifest.MapId);
        Check(rusherRows.Entities.All(entity=>rusherMatch.RusherMotionCandidate(entity.EntityKey) is { } motion &&
              Vector3.DistanceSquared(motion.Position,new Vector3(entity.X,entity.Y,entity.Z))<.000001f &&
              Vector3.DistanceSquared(motion.Position,content.ArmySpawnPoints.ForMap(rusherMap)
                  .Single(p=>p.ComponentFileId==entity.SpawnComponentFileId).Position)>.01f),
              "all four spawned Rushers publish moved host positions from source-bound spawn points");
        var exhaustedRusherHand=rusherMatch.ArmyBatch(soldierOwner);
        Check(rusherRows.ActiveCount==4 && exhaustedRusherHand.Code=="army-unavailable",
              "four occupied opponent-cover Rusher slots suppress further offers across families: "+
              rusherRows.ActiveCount+" / "+exhaustedRusherHand.Code);
        var rusherTarget=rusherMatch.RusherMovingTarget(rusherRows.Entities[0].EntityKey);
        var walkingTarget=rusherMatch.RusherWalkingTarget(rusherRows.Entities[0].EntityKey);
        foreach(var entity in rusherRows.Entities)
        {
            var route=rusherMatch.RusherWalkingRoute(entity.EntityKey);
            var slot=content.ArmyRusherPoints.ForCover(rusherMap,rusherManifest.Players[1].StartCover)
                .Single(p=>p.ComponentFileId==rusherMatch.RusherWalkingTarget(entity.EntityKey)!.RusherPointFileId);
            Check(route is {PlanarCovered:true} &&
                  route.SmoothedPoints[0]==new Vector3(entity.X,entity.Y,entity.Z) &&
                  route.SmoothedPoints[^1]==slot.Position,
                  "spawned Rusher route binds its exact host entity and occupied source slot");
        }
        var walkingPose=rusherMatch.CombatPose(helicopterOwner);
        var walkingOrigin=new Vector3(rusherRows.Entities[0].X,rusherRows.Entities[0].Y,rusherRows.Entities[0].Z);
        var nearestBody=content.PlayerShotTargets.Nearest(1,walkingOrigin,
            t=>walkingPose.BodyTarget(t.TransformFileId).Position);
        Check(walkingTarget is { } && walkingTarget.PlayerId==helicopterOwner &&
              walkingTarget.TargetFileId==nearestBody.TransformFileId &&
              walkingTarget.Position==walkingPose.BodyTarget(nearestBody.TransformFileId).Position,
              "spawned walking Rusher selects the nearest posed Body target from host entity position");
        Check(rusherTarget is {TargetFileId:17927} &&
              rusherTarget.PlayerId==helicopterOwner &&
              rusherTarget.Position==rusherMatch.CombatPose(helicopterOwner).MovingTarget!.Position &&
              content.ArmyRusherPoints.ForCover(content.Maps.Single(m=>
                  Path.GetFileNameWithoutExtension(m.Source)==rusherManifest.MapId),
                  rusherManifest.Players[1].StartCover)
                  .Any(p=>p.ComponentFileId==rusherTarget.RusherPointFileId),
              "spawned Rusher target projection binds the opponent's current animated Moving target and source cover slot");
        rusherMatch.Advance(++rusherTick);
        var nextRusherPage=rusherMatch.ArmyEntityBatch(soldierOwner,0,rusherRows.Revision);
        Check(nextRusherPage.Code=="entities" && nextRusherPage.Revision==rusherRows.Revision &&
              nextRusherPage.Entities.All(entity=>entity.PositionTick==rusherTick),
              "30 Hz Rusher motion preserves the reconnect roster revision while advancing positions");
        Check(rusherMatch.ConfirmArmyDeath(rusherRows.Entities[0].EntityKey,false) &&
              rusherMatch.RusherMotionCandidate(rusherRows.Entities[0].EntityKey)==null &&
              rusherMatch.RusherInitialShotTarget(rusherRows.Entities[0].EntityKey)==null &&
              rusherMatch.RusherWalkingRoute(rusherRows.Entities[0].EntityKey)==null &&
              rusherMatch.RusherWalkingTarget(rusherRows.Entities[0].EntityKey)==null &&
              rusherMatch.RusherMovingTarget(rusherRows.Entities[0].EntityKey)==null &&
              rusherMatch.ArmyBatch(soldierOwner).Code=="army-offers",
              "confirmed Rusher death releases its exact source slot for a new hand");
        ulong eligibleRusher=rusherRows.Entities[1].EntityKey;
        float retargetMinimumGap=float.MaxValue;
        for(int i=0;i<700 && rusherMatch.RusherInitialShotTarget(eligibleRusher)==null &&
            !rusherMatch.Terminal;i++)
        {
            if(i%90==0)
            {rusherMatch.ArmyBatch(soldierOwner);rusherMatch.ArmyBatch(helicopterOwner);}
            rusherMatch.Advance(++rusherTick);
            var rows=rusherMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
            var moving=rows.Single(entity=>entity.EntityKey==eligibleRusher);
            foreach(var other in rows.Where(entity=>entity.EntityKey!=eligibleRusher))
                retargetMinimumGap=Math.Min(retargetMinimumGap,Vector2.Distance(
                    new(moving.X,moving.Z),new(other.X,other.Z)));
        }
        Check(rusherMatch.RusherInitialShotTarget(eligibleRusher) is
              {PlayerId:var targetPlayer,TargetFileId:17927} && targetPlayer==helicopterOwner,
              "match-owned Rusher reaches its strict first-shot gate with a current Moving target");
        int oldRusherPoint=rusherMatch.RusherWalkingTarget(eligibleRusher)!.RusherPointFileId;
        var coverMove=rusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=2,
            MoveCover=new MoveCoverCommand{Direction=1}});
        Check(coverMove.Code=="moving" &&
              rusherMatch.RusherMotionCandidate(eligibleRusher)!=null &&
              rusherMatch.RusherSlotOccupant(oldRusherPoint)==eligibleRusher &&
              rusherMatch.RusherWalkingRoute(eligibleRusher) is {PlanarCovered:true},
              "defender cover departure retains the old occupied Rusher state during the source delay");
        bool retargeted=false;
        for(int i=0;i<450 && !rusherMatch.Terminal;i++)
        {
            rusherMatch.Advance(++rusherTick);
            if(i%90==0)
            {rusherMatch.ArmyBatch(soldierOwner);rusherMatch.ArmyBatch(helicopterOwner);}
            var target=rusherMatch.RusherWalkingTarget(eligibleRusher);
            if(target!=null && target.RusherPointFileId!=oldRusherPoint)
            {retargeted=true;break;}
        }
        var newRusherTarget=rusherMatch.RusherWalkingTarget(eligibleRusher);
        var movedDefender=rusherMatch.Snapshot().Players.Single(p=>p.PlayerId==helicopterOwner);
        Check(retargeted && !movedDefender.Moving &&
              newRusherTarget!=null && newRusherTarget.RusherPointFileId!=oldRusherPoint &&
              rusherMatch.RusherSlotOccupant(oldRusherPoint)==null &&
              rusherMatch.RusherSlotOccupant(newRusherTarget.RusherPointFileId)==eligibleRusher &&
              content.ArmyRusherPoints.ForCover(rusherMap,movedDefender.CoverIndex)
                  .Any(p=>p.ComponentFileId==newRusherTarget.RusherPointFileId) &&
              rusherMatch.RusherMotionCandidate(eligibleRusher)?.Phase==ArmyRusherTravelPhase.Walking &&
              rusherMatch.RusherWalkingRoute(eligibleRusher) is {PlanarCovered:true} &&
              rusherMatch.RusherInitialShotTarget(eligibleRusher)==null,
              "live Rusher transfers one source slot and begins a covered route after defender cover change");
        for(int i=0;i<700 && rusherMatch.RusherInitialShotTarget(eligibleRusher)==null &&
            !rusherMatch.Terminal;i++)
        {
            if(i%90==0)
            {rusherMatch.ArmyBatch(soldierOwner);rusherMatch.ArmyBatch(helicopterOwner);}
            rusherMatch.Advance(++rusherTick);
        }
        bool crowdedArrival=rusherMatch.RusherInitialShotTarget(eligibleRusher)!=null;
        var crowdedMotion=rusherMatch.RusherMotionCandidate(eligibleRusher);
        string crowdPositions=string.Join("; ",rusherMatch.ArmyEntityBatch(soldierOwner,0,0)
            .Entities.Select(entity=>$"{entity.EntityKey}:{entity.X:F2},{entity.Z:F2}"));
        Console.WriteLine($"Pinned retarget crowd seed {rusherSeed}, arrival {crowdedArrival}, " +
            $"phase {crowdedMotion?.Phase}, rejected {crowdedMotion?.RejectedMotionTicks}, " +
            $"progress {crowdedMotion?.MotionProgress:F2}/{crowdedMotion?.MotionLength:F2}, " +
            $"slot {rusherMatch.RusherWalkingTarget(eligibleRusher)?.RusherPointFileId}, " +
            $"goal {rusherMatch.RusherWalkingRoute(eligibleRusher)?.SmoothedPoints[^1]}, " +
            $"positions {crowdPositions}");
        Check(crowdedArrival,
              "fixed-seed three-Rusher retarget reaches its source first-shot gate");
        if(rusherSeed==2)
            Check(rusherMatch.RusherDetourCount(eligibleRusher)>0 &&
                  retargetMinimumGap>=.339f,
                  "formerly stalled source layout uses a covered detour outside allied radii: "+
                  retargetMinimumGap.ToString("F3"));
        foreach(var other in rusherMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Where(entity=>entity.EntityKey!=eligibleRusher).ToArray())
            Check(rusherMatch.ConfirmArmyDeath(other.EntityKey,false),
                "host removes competing Rushers before isolated retarget-route arrival proof");
        for(int i=0;i<700 && rusherMatch.RusherInitialShotTarget(eligibleRusher)==null &&
            !rusherMatch.Terminal;i++)
        {
            if(i%90==0)
            {rusherMatch.ArmyBatch(soldierOwner);rusherMatch.ArmyBatch(helicopterOwner);}
            rusherMatch.Advance(++rusherTick);
        }
        Check(rusherMatch.RusherInitialShotTarget(eligibleRusher) is
              {RusherPointFileId:var arrivedPoint} &&
              arrivedPoint==newRusherTarget!.RusherPointFileId,
              "retargeted Rusher reaches the new source slot before its strict first-shot gate: " +
              $"phase={rusherMatch.RusherMotionCandidate(eligibleRusher)?.Phase}, " +
              $"slot={rusherMatch.RusherWalkingTarget(eligibleRusher)?.RusherPointFileId}, " +
              $"terminal={rusherMatch.Terminal}, tick={rusherTick}");
        int middleRusherPoint=newRusherTarget!.RusherPointFileId;
        Check(rusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=3,
                  MoveCover=new MoveCoverCommand{Direction=-1}}).Code=="moving",
              "defender can leave the retargeted Rusher point for a second source cover");
        bool retargetedAgain=false;
        for(int i=0;i<600 && !rusherMatch.Terminal;i++)
        {
            if(i%90==0)
            {rusherMatch.ArmyBatch(soldierOwner);rusherMatch.ArmyBatch(helicopterOwner);}
            rusherMatch.Advance(++rusherTick);
            if(rusherMatch.RusherWalkingTarget(eligibleRusher)?.RusherPointFileId!=middleRusherPoint)
            {retargetedAgain=true;break;}
        }
        int returnCover=rusherMatch.Snapshot().Players.Single(p=>p.PlayerId==helicopterOwner).CoverIndex;
        int returnSlot=rusherMatch.RusherWalkingTarget(eligibleRusher)?.RusherPointFileId??0;
        Check(retargetedAgain && returnCover==rusherManifest.Players[1].StartCover &&
              content.ArmyRusherPoints.ForCover(rusherMap,returnCover)
                  .Any(p=>p.ComponentFileId==returnSlot) &&
              rusherMatch.RusherSlotOccupant(middleRusherPoint)==null &&
              rusherMatch.RusherSlotOccupant(returnSlot)==eligibleRusher,
              "second cover move transfers the same Rusher without leaking its intermediate slot");
        var staleManifest=detached with {MatchId="stale-army-hand",Players=[detached.Players[0] with
        {
            EquippedArmyUnitIds=["ID_UNIT-HUMVEE","ID_UNIT-TANK","ID_UNIT-BUGGY"],
            NewArmyUnitIds=null,ArmyNormalUpgradeIndexes=[0,0,0],
            ArmySpecialUpgradeIndexes=[-1,-1,-1],ArmyEliteUpgradeIndexes=[-1,-1,-1],
            ArmyHealthFactors=[new(1f,1f),new(1f,1f),new(1f,1f)],ArmyDamageScales=[1f,1f,1f],
            ArmySpeedCoefficients=[1f,1f,1f],ArmyAccuracyCoefficients=[1f,1f,1f]
        },detached.Players[1]]};
        var staleMatch=new MatchEngine(staleManifest,content:content);
        staleMatch.Admit(soldierOwner);staleMatch.Admit(helicopterOwner);
        staleMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=staleMatch.ManifestHash}});
        staleMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=staleMatch.ManifestHash}});
        staleMatch.Advance(60);
        Check(staleMatch.ArmyBatch(soldierOwner).OptionIndexes.Contains(3) &&
              staleMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=3}}).Code=="army-deploying",
              "first car consumes one of Park's two source routes");
        ulong nextCarTick=staleMatch.ArmyBatch(soldierOwner).NextDeployTick;
        for(ulong t=61;t<=nextCarTick;t++)
        {
            staleMatch.Advance(t);
            if(t%90==0)
            {staleMatch.ArmyEntityBatch(soldierOwner,0,0);staleMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        Check(staleMatch.Command(soldierOwner,new MatchCommand{CommandId=3,
                  DeployArmy=new DeployArmyCommand{OptionIndex=19}}).Code=="army-deploying" &&
              staleMatch.ArmyBatch(soldierOwner).Code=="army-unavailable" &&
              staleMatch.Command(soldierOwner,new MatchCommand{CommandId=4,
                  DeployArmy=new DeployArmyCommand{OptionIndex=29}}).Code=="army-not-offered",
              "pending tank reserves Park's last car capacity before its spawn tick");
        staleMatch.Advance(nextCarTick+1);
        Check(staleMatch.ArmyBatch(soldierOwner).Code=="army-unavailable" &&
              staleMatch.Command(soldierOwner,new MatchCommand{CommandId=4,
                  DeployArmy=new DeployArmyCommand{OptionIndex=29}}).Code=="army-not-offered",
              "spawn retains the unavailable offer state and replays the prior rejection");
        Reject(()=>new MatchEngine(detached with { Players=[detached.Players[0] with
            {EquippedArmyUnitIds=["ID_UNIT-UNKNOWN"]},detached.Players[1]] },content:content));
        Reject(()=>MatchManifest.Validate(detached with { Players=[detached.Players[0] with
            {EquippedArmyUnitIds=["ID_UNIT-ASSAULT","ID_UNIT-ASSAULT"]},detached.Players[1]] }));
        Reject(()=>MatchManifest.Validate(detached with { Players=[detached.Players[0],detached.Players[1] with
            {EquippedArmyUnitIds=null}] }));
        string temporary=Path.Combine(directory,"combat-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var pin=JsonSerializer.Deserialize<CombatContentManifest>(File.ReadAllText(Path.Combine(directory,"combat-content-manifest.json")))!;
            File.WriteAllText(temporary,JsonSerializer.Serialize(pin with { PosesRevision=new string('0',64) }));
            Reject(()=>BattleCombatContent.Load(temporary));
            File.WriteAllText(temporary,JsonSerializer.Serialize(manifest));
            var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
            {
                ["Battle:ServerId"]=manifest.ServerId,["Battle:SigningKey"]=Convert.ToBase64String(new byte[32]),
                ["Battle:MatchManifestPath"]=temporary,["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
                ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-content-outbox-"+Guid.NewGuid().ToString("N"))
            }).Build();
            using (var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance)) { count++; }
            File.WriteAllText(temporary,JsonSerializer.Serialize(manifest with { Players=[manifest.Players[0] with { Weapon=weapon with { ReserveAmmo=99999 } },manifest.Players[1]] }));
            Reject(()=>new NetworkWorker(config,NullLogger<NetworkWorker>.Instance));
            File.WriteAllText(temporary,JsonSerializer.Serialize(pin with { BindingsRevision=new string('0',64) }));
            Reject(()=>BattleCombatContent.Load(temporary));
        }
        finally { if (File.Exists(temporary)) File.Delete(temporary); }
        var synthetic=new MatchEngine(manifest with { Players=manifest.Players.Select(p=>p with { WeaponUpgrade=null }).ToArray() });
        Check(synthetic.HasPlayer(manifest.Players[0].PlayerId),"existing synthetic fixture remains explicit without package");
        return count;
    }
}
