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
        var vehicleRoutes=content.Maps.SelectMany(m=>content.ArmySpawnPoints.ForMap(m))
            .Where(p=>p.VehicleRoute!=null).ToArray();
        Check(vehicleRoutes.Length==20&&vehicleRoutes.Sum(p=>p.VehicleRoute!.Positions.Count)==107&&
              vehicleRoutes.All(p=>p.Collection=="spawnPointsCollectionCars"&&
                  p.VehicleRoute!.WaypointTransformFileIds[^1]==p.VehicleRoute.TargetTransformFileId&&
                  !p.VehicleRoute.SmoothRoute&&!p.VehicleRoute.IsLoop),
              "all 20 source vehicle spawns pin their 107 ordered linear waypoints and final targets");
        var humveeShot=content.Army.ComposeVehicleShot("ID_UNIT-HUMVEE",0,null,null);
        var tankShot=content.Army.ComposeVehicleShot("ID_UNIT-TANK",0,null,null);
        var buggyShot=content.Army.ComposeVehicleShot("ID_UNIT-BUGGY",0,null,null);
        var transporterShot=content.Army.ComposeVehicleShot("ID_UNIT-TRANSPORTER",0,null,null);
        var buggyCannon=content.Army.ComposeBuggyCannon(0,null,null);
        var tankCannon=content.Army.ComposeVehicleCannon("ID_UNIT-TANK",0,null,null,1,1);
        var specialTankCannon=content.Army.ComposeVehicleCannon("ID_UNIT-TANK",0,51,null,2,.7f);
        var transporterRepair=content.Army.ComposeTransporterRepairDrone(0,71,null,new(1,1));
        Check(humveeShot==new ArmyVehicleShotStats(5f,.85f,4,5,1.5f,1.8f,0)&&
              tankShot==new ArmyVehicleShotStats(5f,.8f,2,5,2f,5f,0)&&
              buggyShot==new ArmyVehicleShotStats(5f,1f,0,0,0,0,0)&&
              transporterShot==new ArmyVehicleShotStats(5f,.9f,4,7,3.5f,4.5f,0)&&
              buggyCannon==new ArmyVehicleCannonStats(622.44f,8f,10f)&&
              tankCannon==new ArmyVehicleCannonStats(1808.03f,8f,14f)&&
              Math.Abs(specialTankCannon.Damage-3616.06f)<.001f&&
              Math.Abs(specialTankCannon.MinShootTime-5.6f)<.001f&&
              Math.Abs(specialTankCannon.MaxShootTime-9.8f)<.001f&&
              content.Army.PlayerDamagePolicy("ID_UNIT-BUGGY")==
                  new ArmyPlayerDamagePolicy(.3f,.5f,.5f)&&
              content.Army.VehiclePassengerMaximumHealth("ID_UNIT-HUMVEE",0,1f)==875.34f&&
              content.Army.VehiclePassengerMaximumHealth("ID_UNIT-TANK",0,1f)==1225.73f&&
              content.Army.VehiclePassengerMaximumHealth("ID_UNIT-BUGGY",0,1f)==426f&&
              content.Army.VehiclePassengerMaximumHealth("ID_UNIT-TRANSPORTER",0,1f)==774.13f&&
              content.Army.VehiclePassengerRespawnTicks("ID_UNIT-HUMVEE")==375&&
              content.Army.VehiclePassengerRespawnTicks("ID_UNIT-TANK")==525&&
              content.Army.ComposeVehicleShot("ID_UNIT-HUMVEE",0,null,null,2f)
                  .ProbabilityOfRealShot==1f&&
              Math.Abs(transporterRepair.HealRatioPerSecond-.08f)<.00001f&&
              Math.Abs(transporterRepair.MaximumHealth-70.3755f)<.001f,
              "ground vehicle turrets compose primary, Buggy cannon, and Tank cannon stage-zero source authority");
        bool rejectedNormalRepairLane=false;
        try{_=content.Army.ComposeTransporterRepairDrone(0,0,null,new(1,1));}
        catch(ArgumentOutOfRangeException){rejectedNormalRepairLane=true;}
        Check(rejectedNormalRepairLane,"Transporter repair drones require a selected special lane");
        Reject(()=>content.Army.ComposeVehicleShot("ID_UNIT-ASSAULT",0,null,null));
        var humveeRig=content.GroundVehicleWeapons.For("ID_UNIT-HUMVEE");
        var tankRig=content.GroundVehicleWeapons.For("ID_UNIT-TANK");
        var buggyRig=content.GroundVehicleWeapons.For("ID_UNIT-BUGGY");
        var transporterRig=content.GroundVehicleWeapons.For("ID_UNIT-TRANSPORTER");
        Check(humveeRig.Roles.Single(r=>r.Role=="primary").Weapons.Single().Cadence==.3f&&
              tankRig.Roles.Single(r=>r.Role=="primary").Weapons.Single().Cadence==.1f&&
              buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons.Count==2&&
              buggyRig.Roles.Single(r=>r.Role=="cannon").SecondaryDelay==.25f&&
              transporterRig.Roles.Single().Weapons.Count==2&&
              transporterRig.Roles.Single().Weapons.All(w=>w.WeaponType=="AutomaticRifle")&&
              transporterRig.Roles.Single().Weapons.Select(w=>w.Cadence).SequenceEqual([.3f,.5f])&&
              buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons.All(w=>w.Missile is
                  {Speed:6f,MinimumDamage:20f,HurtRadius:1.2f,DeadRadius:1f,CurvedTrajectory:true,
                   RotationRange:{X:.5f,Y:.5f},RotationProfile.Count:5,
                   BaseRotationMagnitude:.5f})&&
              humveeRig.Passengers.Select(x=>x.Role).SequenceEqual(["gunner"])&&
              tankRig.Passengers.Select(x=>x.Role).SequenceEqual(["turret","cannon"])&&
              buggyRig.Passengers.Select(x=>x.Role).SequenceEqual(["driver","co-driver"])&&
              transporterRig.Passengers.Select(x=>x.Role).SequenceEqual(["co-driver"])&&
              transporterRig.RepairDronePaths.Count==2&&
              transporterRig.RepairDronePaths.All(x=>x.Radius==.1f&&x.Waypoints.Count==7&&
                  x.Waypoints.Where(p=>p.StayTime>0).Select(p=>p.Index).SequenceEqual([1,3,5]))&&
              content.GroundVehicleWeapons.RepairDronePrefab is
                  {Speed:.4f,Mass:30f,BreakDistance:.4f,BreakSpeed:.5f,Loop:true,
                   HealIntervalSeconds:1f,RespawnMinimumSeconds:35f,RespawnMaximumSeconds:45f}&&
              new[]{humveeRig,tankRig,buggyRig,transporterRig}.Sum(x=>x.Passengers.Count)==6&&
              content.GroundVehicleWeapons.ArmoredVehicleShotCoefficient==.33f&&
              humveeRig.BodyParts.Count==8&&tankRig.BodyParts.Count==12&&
              buggyRig.BodyParts.Count==8&&transporterRig.BodyParts.Count==12&&
              new[]{humveeRig,tankRig,buggyRig,transporterRig}.Sum(x=>
                  x.BodyParts.Sum(p=>p.Colliders.Count))==41&&
              new[]{humveeRig,tankRig,buggyRig,transporterRig}.SelectMany(x=>x.BodyParts)
                  .All(p=>p.Weight==1&&
                      (content.Bindings.BulletMask(1)&(1u<<p.Layer))!=0&&
                      (content.Bindings.BulletMask(2)&(1u<<p.Layer))!=0)&&
              new[]{humveeRig,tankRig,buggyRig,transporterRig}.SelectMany(r=>r.Roles)
                  .SelectMany(r=>r.Weapons).All(w=>w.ProjectileGuid is
                      "855689762fa6e774aaee190652b08c6f" or "60be7eeb14f5a354c99c9ce23dbc5554"),
              "four vehicle prefabs pin seven turret roles, nine weapon paths, cadence and projectile identity");
        var repairState=new TransporterRepairDroneState(0,transporterRig.RepairDronePaths[0],
            content.GroundVehicleWeapons.RepairDronePrefab,transporterRepair,Vector3.Zero,Vector3.UnitZ,0);
        var bankingRepairState=new TransporterRepairDroneState(1,transporterRig.RepairDronePaths[1],
            content.GroundVehicleWeapons.RepairDronePrefab,transporterRepair,Vector3.Zero,Vector3.UnitZ,0);
        for(ulong bankTick=1;bankTick<=90;bankTick++)
            bankingRepairState.Advance(Vector3.Zero,Vector3.UnitZ,bankTick,()=>.5f);
        Check(Math.Abs(bankingRepairState.Rotation.LengthSquared()-1)<.0002f&&
              Math.Abs(bankingRepairState.Rotation.X)+Math.Abs(bankingRepairState.Rotation.Z)>.00001f,
              "repair-drone steering publishes recovered horizontal bank as well as vertical path look");
        Check(repairState.ApplyDamage(repairState.MaximumHealth,10,()=>0)&&!repairState.Active&&
              repairState.RespawnTick==1060&&
              repairState.Advance(Vector3.Zero,Vector3.UnitZ,1059,()=>.5f).HealRatio==0&&!repairState.Active&&
              repairState.Advance(Vector3.Zero,Vector3.UnitZ,1060,()=>.5f).HealRatio==0&&repairState.Active&&
              repairState.Snapshot() is {WaypointIndex:0,RespawnTick:0} repairedDrone&&
              Math.Abs(repairedDrone.Health-repairedDrone.MaximumHealth)<.001f,
              "repair-drone death preserves its path and respawns at full health after the exact source window");
        var fallingRepairState=new TransporterRepairDroneState(0,transporterRig.RepairDronePaths[0],
            content.GroundVehicleWeapons.RepairDronePrefab,transporterRepair,Vector3.Zero,Vector3.UnitZ,0);
        fallingRepairState.ApplyDamage(fallingRepairState.MaximumHealth,10,()=>0);
        Vector3 fallingStart=fallingRepairState.Position;
        var crash=fallingRepairState.Advance(Vector3.Zero,Vector3.UnitZ,11,()=>.5f,
            (center,size,rotation)=>size==content.GroundVehicleWeapons.RepairDronePrefab.ColliderSize&&
                Math.Abs(rotation.LengthSquared()-1)<.0001f);
        Check(crash.Crashed&&!fallingRepairState.Active&&!fallingRepairState.Falling&&
              fallingRepairState.Crashed&&fallingRepairState.Position!=fallingStart&&
              fallingRepairState.Snapshot() is {Falling:false,Crashed:true},
              "dead repair drone releases its recovered Rigidbody and explodes only on authoritative trigger contact");
        var repairTarget=content.GroundVehicleWeapons.PlaceRepairDrone(78,0,23,repairState.Snapshot());
        var repairRayOrigin=repairTarget.Hitbox.Center+Vector3.UnitX;
        var repairWorld=new ShotCollisionWorld(null,
        [
            new("cccccccccccccccccccccccccccccccc",referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new("dddddddddddddddddddddddddddddddd",referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>[repairTarget]);
        var repairHit=repairWorld.Raycast("cccccccccccccccccccccccccccccccc",repairRayOrigin,
            repairTarget.Hitbox.Center-repairRayOrigin,2,uint.MaxValue);
        Check(repairHit is {DynamicEntityId:78,DynamicRepairDronePathIndex:0,DynamicPartId:null,
                  DynamicPassengerRole:null,PartWeight:1}&&
              repairHit.SourcePath.Contains("miniDrone.prefab",StringComparison.Ordinal),
              "player projectile ray selects the source-pinned repair-drone root BoxCollider");
        var placedHumvee=content.GroundVehicleWeapons.PlaceBody("ID_UNIT-HUMVEE",77,
            Vector3.Zero,Vector3.UnitZ);
        var bodyTarget=placedHumvee.First(x=>x.Hitbox.Kind==PlayerHitboxKind.Box);
        var rayOrigin=bodyTarget.Hitbox.Center+Vector3.Transform(Vector3.UnitX,
            bodyTarget.Hitbox.Rotation)*10;
        const string bodyShooter="cccccccccccccccccccccccccccccccc";
        const string bodyOpponent="dddddddddddddddddddddddddddddddd";
        var bodyWorld=new ShotCollisionWorld(null,
        [
            new(bodyShooter,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new(bodyOpponent,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>placedHumvee);
        var bodyHit=bodyWorld.Raycast(bodyShooter,rayOrigin,bodyTarget.Hitbox.Center-rayOrigin,20,uint.MaxValue);
        Check(bodyHit is {DynamicEntityId:77,DynamicPartId:var sourcePart,PlayerId:null}&&
              sourcePart==bodyTarget.PartComponentFileId&&bodyHit.SourcePath==bodyTarget.Hitbox.SourcePath,
              "player projectile ray selects the nearest source-pinned vehicle body collider");
        var idlePassenger=content.GroundVehicleWeapons.PassengerPoses.Place("ID_UNIT-HUMVEE",
            humveeRig.Passengers[0],Vector3.Zero,Vector3.UnitZ,0);
        var breathingPassenger=content.GroundVehicleWeapons.PassengerPoses.Place("ID_UNIT-HUMVEE",
            humveeRig.Passengers[0],Vector3.Zero,Vector3.UnitZ,15);
        var buggyPassengerStart=content.GroundVehicleWeapons.PassengerPoses.Place("ID_UNIT-BUGGY",
            buggyRig.Passengers[0],Vector3.Zero,Vector3.UnitZ,0);
        var buggyPassengerEnd=content.GroundVehicleWeapons.PassengerPoses.Place("ID_UNIT-BUGGY",
            buggyRig.Passengers[0],Vector3.Zero,Vector3.UnitZ,20);
        Check(idlePassenger.Count==3&&idlePassenger.Select(p=>p.Weight).SequenceEqual([1f,1f,1.5f])&&
              Vector3.Distance(idlePassenger[0].Center,breathingPassenger[0].Center)>.00001f&&
              Vector3.Distance(buggyPassengerStart[0].Center,buggyPassengerEnd[0].Center)>.05f,
              "Unity-sampled passenger catalog preserves looping idle and clamped Buggy sitting hit geometry");
        Check(Vector3.Distance(humveeRig.Roles[0].Weapons[0].MuzzlePosition,
                  new Vector3(-.10999999f,.68667924f,.14323565f))<.00001f&&
              Vector3.Distance(content.GroundVehicleWeapons.RestMuzzleOrigin("ID_UNIT-HUMVEE","primary",0,
                  new Vector3(2,0,3),Vector3.UnitX),new Vector3(2.1432357f,.68667924f,3.11f))<.00002f,
              "vehicle muzzles are prefab-root-relative and rotate with authoritative host facing");
        var buggyMissileBinding=buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons[0].Missile!;
        var buggyFlight=new BuggyMissileFlight(71,72,buggyMissileBinding,5,Vector3.Zero,
            new Vector3(0,0,10),0,.5f,.5f,1,(_,_,_)=>null);
        float buggyCurveDeviation=0;BuggyMissileImpact? buggyTerminal=null;
        for(ulong flightTick=1;flightTick<=100&&!buggyFlight.Finished;flightTick++)
        {
            buggyTerminal=buggyFlight.Advance(flightTick)??buggyTerminal;
            buggyCurveDeviation=Math.Max(buggyCurveDeviation,
                MathF.Sqrt(buggyFlight.Position.X*buggyFlight.Position.X+
                           buggyFlight.Position.Y*buggyFlight.Position.Y));
        }
        Check(buggyFlight.Finished&&buggyTerminal is {Collision:null}&&buggyCurveDeviation>.01f,
              "Buggy missile executes its five-key curved flight on contiguous host ticks");
        var tankMissileBinding=tankRig.Roles.Single(r=>r.Role=="cannon").Weapons.Single().Missile!;
        Vector3 tankTarget=new(0,0,8);int tankTraceCount=0;
        var tankFlight=new TankMissileFlight(81,82,tankMissileBinding,Vector3.Zero,()=>tankTarget,0,
            (origin,direction,range)=>
            {
                tankTraceCount++;
                return origin.Z<7&&origin.Z+direction.Z*range>=7?
                    new ShotCollision(7-origin.Z,new(0,0,7),"tank-target","target",1):null;
            });
        TankMissileImpact? tankImpact=null;
        for(ulong flightTick=1;flightTick<=200&&!tankFlight.Finished;flightTick++)
        {
            if(flightTick==4)tankTarget=new(0,0,9);
            tankImpact=tankFlight.Advance(flightTick)??tankImpact;
        }
        Check(tankImpact is {Collision.PlayerId:"target",Position.Z:7}&&tankTraceCount>0&&
              tankMissileBinding is {Speed:8f,MinimumDamage:20f,HurtRadius:1.2f,DeadRadius:1f,
                  CurvedTrajectory:false,RotationRange:{X:.8f,Y:1.6f},RotationProfile.Count:3,
                  BaseRotationMagnitude:.45f},
              "Tank cannon follows the live target with its source straight missile and collision delay");
        var buggyPose=referencePose.Place(Vector3.Zero,Quaternion.Identity).Collision;
        var buggyBody=buggyPose.Parts[0];
        var tankPolicy=content.Army.PlayerDamagePolicy("ID_UNIT-TANK");
        var tankInner=BuggyExplosion.ResolvePlayer(buggyBody.Center,buggyPose,buggyPose.RootPosition,
            new(5000),5000,tankCannon.Damage,tankMissileBinding,tankPolicy,false,false,false,false,.5f);
        var tankShielded=BuggyExplosion.ResolvePlayer(buggyBody.Center,buggyPose,buggyPose.RootPosition,
            new(5000),5000,tankCannon.Damage,tankMissileBinding,tankPolicy,true,false,false,false,.5f);
        Check(tankPolicy==new ArmyPlayerDamagePolicy(.35f,.3f,.2f)&&
              tankInner is {Kind:CombatDamageType.Explosion}&&
              Math.Abs(tankInner.RawDamage-1808.03f)<.001f&&Math.Abs(tankInner.Result.Damage-542.409f)<.01f&&
              tankShielded!=null&&Math.Abs(tankShielded.RawDamage-632.8105f)<.01f&&
              Math.Abs(tankShielded.Result.Damage-189.84315f)<.01f,
              "Tank missile explosion applies source cannon damage and shield/player ratios");
        var buggyPolicy=content.Army.PlayerDamagePolicy("ID_UNIT-BUGGY");
        var buggyInner=BuggyExplosion.ResolvePlayer(buggyBody.Center,buggyPose,buggyPose.RootPosition,
            new(1000),1000,buggyCannon.Damage*.5f,buggyMissileBinding,buggyPolicy,false,false,false,false,.5f);
        var buggyShielded=BuggyExplosion.ResolvePlayer(buggyBody.Center,buggyPose,buggyPose.RootPosition,
            new(1000),1000,buggyCannon.Damage*.5f,buggyMissileBinding,buggyPolicy,true,false,false,false,.5f);
        Check(buggyInner is {Kind:CombatDamageType.Explosion}&&
              Math.Abs(buggyInner.RawDamage-311.22f)<.001f&&Math.Abs(buggyInner.Result.Damage-155.61f)<.01f&&
              buggyShielded!=null&&Math.Abs(buggyShielded.RawDamage-93.366f)<.01f&&
              Math.Abs(buggyShielded.Result.Damage-46.683f)<.01f,
              "Buggy cannon explosion applies half-cannon damage and recovered shield/player ratios");
        var buggyDynamic=new MapDynamicCollider(1,"test","test-owner",0,Vector3.Zero,new(-.1f),new(.1f));
        var buggyOuter=BuggyExplosion.ResolveDynamic(new(1.25f,0,0),buggyDynamic,
            buggyCannon.Damage*.5f,buggyMissileBinding);
        Check(buggyOuter.Kind==CombatDamageType.Shiver&&buggyOuter.RawDamage>=20&&
              buggyOuter.RawDamage<buggyCannon.Damage*.5f,
              "Buggy cannon outer overlap uses serialized 20-point quadratic hurt falloff");
        string vehicleWeaponPath=Path.Combine(directory,"recovered-ground-vehicle-weapons.json");
        string passengerPosePath=Path.Combine(directory,"recovered-vehicle-passenger-poses.json");
        string enemyPosePath=Path.Combine(directory,"recovered-enemy-poses.json");
        string vehicleWeaponTemp=Path.Combine(directory,"vehicle-weapon-test-"+Guid.NewGuid().ToString("N")+".json");
        string passengerPoseTemp=Path.Combine(directory,"vehicle-passenger-pose-test-"+Guid.NewGuid().ToString("N")+".json");
        string enemyPoseTemp=Path.Combine(directory,"enemy-pose-test-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            var package=JsonSerializer.Deserialize<CombatContentManifest>(File.ReadAllText(
                Path.Combine(directory,"combat-content-manifest.json")))!;
            Check(package.GroundVehicleWeaponsRevision==Convert.ToHexStringLower(
                      SHA256.HashData(File.ReadAllBytes(vehicleWeaponPath))),
                  "ground vehicle weapon bytes bind the composite combat revision");
            Check(package.EnemyPosesRevision==content.EnemyPoses.Revision&&
                  package.EnemyPosesRevision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(enemyPosePath)))&&
                  content.EnemyPoses.SourceSha256==content.Army.InfantryAgent.PrefabSha256&&
                  content.EnemyPoses.Names.Count==133&&content.EnemyPoses.Clip("run_0").Frames.Count==21&&
                  content.EnemyPoses.Place("run_0",Vector3.Zero,Quaternion.Identity,0).Count==3,
                  "all 133 enemy clips bind source-pinned animated infantry hit geometry");
            Reject(()=>EnemyPoseCatalog.Load(enemyPosePath,new string('0',64)));
            string damagedEnemyPose=File.ReadAllText(enemyPosePath).Replace("\"name\": \"SMG_idle\"","\"name\": \"XMG_idle\"",StringComparison.Ordinal);
            File.WriteAllText(enemyPoseTemp,damagedEnemyPose);
            string damagedEnemyPoseHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(enemyPoseTemp)));
            Reject(()=>EnemyPoseCatalog.Load(enemyPoseTemp,damagedEnemyPoseHash));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponPath,new string('0',64)));
            var damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["vehicles"]![0]!["roles"]![0]!["weapons"]![0]!["cadence"]=0;
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            string damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["vehicles"]![2]!["roles"]![1]!["weapons"]![0]!["missile"]!["minimumDamage"]=-1;
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["repairDronePrefab"]!["speed"]=.8f;
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["vehicles"]![3]!["repairDronePaths"]![0]!["waypoints"]![2]!["index"]=1;
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["vehicles"]![2]!["passengers"]![1]!["role"]="driver";
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            damaged=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            damaged["vehicles"]![0]!["bodyParts"]![1]!["colliders"]![0]!["colliderFileId"]=
                damaged["vehicles"]![0]!["bodyParts"]![0]!["colliders"]![0]!["colliderFileId"]!.GetValue<int>();
            File.WriteAllText(vehicleWeaponTemp,damaged.ToJsonString());
            damagedHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)));
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,damagedHash));
            var damagedPose=JsonNode.Parse(File.ReadAllText(passengerPosePath))!;
            damagedPose["clips"]![0]!["frames"]![0]!["parts"]![2]!["weight"]=1;
            File.WriteAllText(passengerPoseTemp,damagedPose.ToJsonString());
            string damagedPoseHash=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(passengerPoseTemp)));
            Reject(()=>VehiclePassengerPoseCatalog.Load(passengerPoseTemp,damagedPoseHash));
        }
        finally
        {
            if(File.Exists(vehicleWeaponTemp))File.Delete(vehicleWeaponTemp);
            if(File.Exists(passengerPoseTemp))File.Delete(passengerPoseTemp);
            if(File.Exists(enemyPoseTemp))File.Delete(enemyPoseTemp);
        }
        var routeProbe=vehicleRoutes[0];
        var routeMotion=new ArmyVehicleRouteMotion(routeProbe.Position,routeProbe.VehicleRoute!,1.7f);
        routeMotion.AdvanceTick();
        Check(!routeMotion.Arrived&&routeMotion.CircuitFileId==routeProbe.VehicleRoute!.CircuitFileId&&
              Vector3.Distance(routeProbe.Position,routeMotion.Position)<=1.7f/MatchManifest.TickRate+.00001f,
              "ground vehicle route motion advances one fixed tick within recovered source speed");
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
            modified=JsonNode.Parse(File.ReadAllText(spawnPath))!;
            modified["maps"]![0]!["points"]!.AsArray().First(p=>
                p!["collection"]!.GetValue<string>()=="spawnPointsCollectionCars")!["vehicleRoute"]![
                    "targetTransformFileId"]=1;
            File.WriteAllText(spawnTemp,modified.ToJsonString());
            altered=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(spawnTemp)));
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
        var commandoRight=content.ArmyWeapons.Muzzle("ID_UNIT-COMMANDO",0);
        var commandoLeft=content.ArmyWeapons.Muzzle("ID_UNIT-COMMANDO",1);
        Check(content.ArmyWeapons.MuzzleCount("ID_UNIT-COMMANDO")==2&&
              content.ArmyWeapons.MuzzleCount("ID_UNIT-SHOTGUNNER")==1&&
              content.ArmyWeapons.LeftGunSnapPath.EndsWith("/gunLeftPivot/gunLeftSnapPoint",StringComparison.Ordinal)&&
              commandoRight.Path==commandoLeft.Path&&
              Vector3.Distance(commandoRight.RestPosition,commandoLeft.RestPosition)>.1f,
              "runtime scene inventory binds Commando DoubleSMGs to distinct right and left muzzle chains");
        Check(content.ArmyWeapons.WindupTicks("ID_UNIT-FLAMETHROWER")==0&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-SHOTGUNNER")==9&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-PARATROOPER")==9&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-SWAT")==30&&
              content.ArmyWeapons.Windup("ID_UNIT-SWAT").ClipAsset=="Assets/AnimationClip/shield_unhide.anim",
              "all source Rusher attacks bind their recovered stand-shoot or shield-unhide windup");
        Check(content.ArmyWeapons.CadenceTicks("ID_UNIT-FLAMETHROWER")==11&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-SHOTGUNNER")==11&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-PARATROOPER")==8&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-COMMANDO")==7&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-WARPER")==7,
              "Rusher batches enforce each strict source weapon cadence at 30 Hz");
        var minigunnerFamily=content.Army.Families.Single(x=>x.UnitId=="ID_UNIT-MINIGUNNER");
        Check(minigunnerFamily.SheetRow=="Google2u.DBUpgradeSlotsShotgunner"&&
              minigunnerFamily.BaseShot is {ProbabilityOfRealShot:1f,FireBatchSizeMin:1,
                  FireBatchSizeMax:4,MinShootTime:2f,MaxShootTime:5f}&&
              content.ArmyWeapons.MuzzleCount("ID_UNIT-MINIGUNNER")==1&&
              content.ArmyWeapons.Muzzle("ID_UNIT-MINIGUNNER").Path==
                  "MiniGun/HK416/MachinegunMuzzleFlash"&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-MINIGUNNER")==30&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-MINIGUNNER")==6,
              "Minigunner pins the original generic-sheet mismatch, base batch, shield windup, muzzle, and strict cadence");
        Check(content.ArmyWeapons.CommandoPoison is {DurationSeconds:5f,PulseIntervalSeconds:1f,PulseCount:5,
                  ConstantsSheet:"Google2u.UnitsContants",ConstantsRow:2}&&
              content.ArmyWeapons.CommandoPoison.BehaviorSource.EndsWith("SoldierBehaviourCommando.cs")&&
              content.ArmyWeapons.CommandoPoison.BulletSource.EndsWith("BulletPoison.cs"),
              "Commando poison duration, interval, arithmetic sources, and constants row are revision-pinned");
        Check(content.ArmyWeapons.ShotgunFalloff("ID_UNIT-SHOTGUNNER") is
                  {Radius:3f,ShotHalfAngle:10f,ShotHalfAngleNear:75f,MinimumDamageRatio:.1f,FlatY:true,ShotOnlyMainBullet:true}&&
              content.ArmyWeapons.ShotgunFalloff("ID_UNIT-WARPER") is
                  {Radius:3f,ShotHalfAngle:10f,ShotHalfAngleNear:75f,MinimumDamageRatio:.1f,FlatY:true,ShotOnlyMainBullet:true}&&
              content.ArmyWeapons.ShotgunFalloff("ID_UNIT-COMMANDO")==null,
              "Shotgunner and Warper bind the recovered one-target radial shotgun setup");
        Check(content.ArmyWeapons.SwatSpecialSpeed.Source.EndsWith("SoldierBehaviourSwat.cs")&&
              content.Army.EffectiveSpeed("ID_UNIT-SWAT",1f,0,null,null)==1f&&
              content.Army.ComposeSpecial("ID_UNIT-SWAT",0,101,null)==.2f&&
              content.Army.EffectiveSpeed("ID_UNIT-SWAT",1f,0,101,null)==1.2f&&
              content.Army.EffectiveSpeed("ID_UNIT-SHOTGUNNER",1f,0,101,null)==1f,
              "only SWAT with a selected special lane multiplies runtime speed by one plus composed SPECIAL");
        Check(content.ArmyWeapons.ParatrooperKevlar.BehaviorSource.EndsWith("SoldierBehaviourParachuter.cs")&&
              content.ArmyWeapons.ParatrooperKevlar.KevlarSource.EndsWith("Kevlar.cs"),
              "Paratrooper special activation and two-pool kevlar absorption are source-hashed");
        var warperPolicy=content.ArmyWeapons.WarperRelocation;
        Check(warperPolicy.Fields.Count==5&&warperPolicy.InitialWarpCountMin==1&&
              warperPolicy.InitialWarpCountMaxExclusive==3&&warperPolicy.RepeatWarpCountMin==0&&
              warperPolicy.RepeatWarpCountMaxExclusive==2&&warperPolicy.StartSpeed==.2f&&
              warperPolicy.WarpAfterSeconds==1.5f&&warperPolicy.WarpSpeed==20f&&
              content.Maps.All(map=>warperPolicy.Fields.TryGetValue(map.Source,out var field)&&
                  field.Sha256==map.SourceHash&&field.Minimum.X<field.Maximum.X&&
                  field.Minimum.Y<field.Maximum.Y&&field.Minimum.Z<field.Maximum.Z),
              "Warper relocation pins all five field colliders, alternating-edge ranges, counts, and speed phases");
        foreach(var sourceMap in content.Maps)
        {
            var field=warperPolicy.Fields[sourceMap.Source];
            Vector3 left=ArmyWarperDestinationPolicy.Select(warperPolicy,field,true,()=>.5f,
                (point,radius)=>content.ArmyNavMeshConnectivity.SampleNearest(sourceMap,point,radius));
            Vector3 right=ArmyWarperDestinationPolicy.Select(warperPolicy,field,false,()=>.5f,
                (point,radius)=>content.ArmyNavMeshConnectivity.SampleNearest(sourceMap,point,radius));
            Check(PlayerHitbox.Finite(left)&&PlayerHitbox.Finite(right)&&left.Z<right.Z,
                "Warper alternating edge candidates sample onto each source NavMesh");
        }
        Reject(()=>ArmyWarperDestinationPolicy.Select(warperPolicy,warperPolicy.Fields.Values.First(),false,
            ()=>1f,(point,_)=>point));
        var warperMap=content.Maps.Single(map=>map.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var warperRoute=content.ArmyNavMeshPaths.ForMap(warperMap).First(row=>row.Complete);
        var warperRandom=new Queue<float>(new[]{.6f,0f,.5f,.5f});
        var warperState=new ArmyWarperRelocationState(warperRoute.SampledStart,warperRoute.SampledEnd,
            warperPolicy,warperPolicy.Fields[warperMap.Source],warperMap,content.ArmyNavMeshConnectivity,
            content.Army.InfantryAgent,.8f,()=>warperRandom.Count>0?warperRandom.Dequeue():.5f);
        bool observedTransparent=false,observedWarpStarted=false,observedWarpEnded=false;
        for(int i=0;i<5000&&warperState.Phase!=ArmyWarperRelocationPhase.Complete;i++)
        {
            var transition=warperState.AdvanceTick();
            observedTransparent|=warperState.Transparent;
            observedWarpStarted|=transition==ArmyWarperPresentationTransition.WarpStarted;
            observedWarpEnded|=transition==ArmyWarperPresentationTransition.WarpEnded;
        }
        Check(warperState.Phase==ArmyWarperRelocationPhase.Complete&&
              warperState.CompletedEdgeHops==1&&observedTransparent&&observedWarpStarted&&observedWarpEnded&&
              Vector3.Distance(warperState.Position,warperRoute.SampledEnd)<.04f,
              "Warper executes one deterministic edge hop, phase transitions, pause, speed-20 phase, and final source route");
        Check(content.ArmyWeapons.TryProjectileDamage("ID_UNIT-SHOTGUNNER",100,Vector3.Zero,Vector3.Zero,out float pointDamage)&&pointDamage==100&&
              content.ArmyWeapons.TryProjectileDamage("ID_UNIT-SHOTGUNNER",100,Vector3.Zero,new(1.5f,0,0),out float midDamage)&&midDamage==55&&
              content.ArmyWeapons.TryProjectileDamage("ID_UNIT-SHOTGUNNER",100,Vector3.Zero,new(3,0,0),out float farDamage)&&farDamage==10&&
              content.ArmyWeapons.TryProjectileDamage("ID_UNIT-WARPER",100,Vector3.Zero,new(30,0,0),out float floorDamage)&&floorDamage==10&&
              content.ArmyWeapons.TryProjectileDamage("ID_UNIT-COMMANDO",100,Vector3.Zero,new(30,50,0),out float rifleDamage)&&rifleDamage==100&&
              !content.ArmyWeapons.TryProjectileDamage("ID_UNIT-SHOTGUNNER",100,Vector3.Zero,new(.1f,3,0),out _),
              "Rusher shotgun launch uses full-distance three-unit falloff, ten-percent floor, and flat-Y cone rejection");
        Reject(()=>content.ArmyWeapons.TryProjectileDamage("ID_UNIT-SHOTGUNNER",float.NaN,Vector3.Zero,Vector3.One,out _));
        try { _=content.ArmyWeapons.RestMuzzleOrigin("ID_UNIT-FLAMETHROWER",Vector3.Zero,Vector3.Zero); throw new Exception("Zero army facing accepted."); }
        catch(InvalidDataException) { count++; }
        try { _=content.ArmyWeapons.Muzzle("ID_UNIT-COMMANDO",2); throw new Exception("Unknown Commando muzzle accepted."); }
        catch(ArgumentOutOfRangeException) { count++; }
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
        try
        {
            var modified=JsonNode.Parse(File.ReadAllText(weaponBindingPath))!;
            modified["warperRelocation"]!["maps"]![0]!["maximum"]![0]=-999f;
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
        Check(content.Army.ComposeSpecial("ID_UNIT-COMMANDO",0,null,null)==0f&&
              content.Army.ComposeSpecial("ID_UNIT-COMMANDO",0,71,null)==.1f,
              "Commando poison ratio composes from the recovered SPECIAL upgrade lane");
        try { _=content.Army.ComposeSpecial("ID_UNIT-COMMANDO",0,0,null); throw new Exception("Normal row accepted as poison special."); }
        catch(ArgumentOutOfRangeException) { count++; }
        var poisonClock=new ArmyPoisonEffect(1,2,"attacker","victim",2f,Vector3.Zero,100);
        var stackedPoisonClock=new ArmyPoisonEffect(2,2,"attacker","victim",2f,Vector3.Zero,100);
        Check(poisonClock.TryTakePulse(100)&&poisonClock.Remaining==4&&
              stackedPoisonClock.TryTakePulse(100)&&stackedPoisonClock.Remaining==4&&
              !poisonClock.TryTakePulse(129)&&poisonClock.TryTakePulse(130)&&
              poisonClock.TryTakePulse(160)&&poisonClock.TryTakePulse(190)&&
              poisonClock.TryTakePulse(220)&&poisonClock.Remaining==0&&
              !poisonClock.TryTakePulse(250),
              "BulletPoison applies at impact then once per second for five independently retained pulses");
        Reject(()=>new ArmyPoisonEffect(1,2,"attacker","victim",float.NaN,Vector3.Zero,100));
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
            Check(content.Army.Families.Count(f=>f.BaseShot!=null)==7 &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourSwat").BaseShot==
                      new ArmyBaseShotStats(.5f,1,4,1f,6f) &&
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourShotgunner").BaseShot==
                      new ArmyBaseShotStats(1f,1,4,1f,5f) &&
                  content.Army.Families.Single(f=>f.BehaviorType=="HelicopterBehaviour").BaseShot==null,
                  "six source-inherited Rusher families and Minigunner bind their serialized base shot definitions");
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
            string decoyArtifact=Path.Combine(directory,"recovered-decoy-source.json");
            string decoyRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(decoyArtifact)));
            var decoys=DecoySourceCatalog.Load(decoyArtifact,decoyRevision,content.Maps);
            var parkDecoys=decoys.ForMap(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer"));
            var selectedDecoys=decoys.Select(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer").Source,
                1,new HashSet<int>{parkDecoys.First(x=>x.Fraction==1).ComponentFileId},_=>0);
            Check(decoys.SpawnCount==3&&decoys.MinimumHealth==62.5f&&decoys.MaximumHealth==1090f&&
                  decoys.Prefab.TargetLocalPosition==new Vector3(0,.431f,0)&&
                  decoys.Prefab.ColliderSize==new Vector3(.2825435f,.5701809f,.1112857f)&&
                  parkDecoys.Count==13&&selectedDecoys.Count==3&&
                  selectedDecoys.All(x=>x.Fraction==1)&&selectedDecoys.Select(x=>x.ComponentFileId).Distinct().Count()==3&&
                  Math.Abs(decoys.Health(22,44)-576.25f)<.001f,
                  "Decoy source pins 89 obstacle slots, three distinct placements, prefab geometry and level-scaled health");
            Check(decoys.Select(content.Maps[0].Source,1,
                      decoys.ForMap(content.Maps[0]).Where(x=>x.Fraction==1).Skip(2)
                          .Select(x=>x.ComponentFileId).ToHashSet(),_=>0).Count==0,
                  "Decoy activation stays closed when fewer than three same-faction obstacle slots are free");
            var decoyRegistry=new DecoyMatchRegistry(3);
            string decoyRequest=new string('d',32),decoyOwner=new string('1',32);
            var decoyPlacements=selectedDecoys.Select((slot,index)=>(slot,
                new Vector3(index,0,index),Vector3.UnitZ)).ToArray();
            Check(decoyRegistry.TrySpawn(decoyRequest,decoyOwner,1,576.25f,decoyPlacements,out var spawnedDecoys)&&
                  spawnedDecoys.Count==3&&decoyRegistry.Snapshot().Count==3&&
                  decoyRegistry.OccupiedObstacleIds.SetEquals(selectedDecoys.Select(x=>x.ComponentFileId))&&
                  decoyRegistry.TryReplay(decoyRequest,decoyOwner,out var replayedDecoys)&&replayedDecoys.Count==3,
                  "Decoy registry atomically owns three source obstacle slots and replays one activation receipt");
            Check(decoyRegistry.TryDamage(spawnedDecoys[0].EntityId,100,out _,out bool firstDestroyed)&&!firstDestroyed&&
                  decoyRegistry.TryDamage(spawnedDecoys[0].EntityId,1000,out _,out bool finalDestroyed)&&finalDestroyed&&
                  !decoyRegistry.OccupiedObstacleIds.Contains(spawnedDecoys[0].ObstacleComponentFileId),
                  "Decoy damage is host-owned and lethal damage releases its exact source obstacle slot");
            Check(!decoyRegistry.TrySpawn(new string('e',32),decoyOwner,1,576.25f,decoyPlacements,out _)&&
                  decoyRegistry.Snapshot().Count==2,
                  "Decoy capacity or occupied-slot failure cannot partially create a three-entity activation");
            Check(decoyRegistry.RemoveOwner(decoyOwner).Count==2&&decoyRegistry.Snapshot().Count==0&&
                  decoyRegistry.OccupiedObstacleIds.Count==0,
                  "Decoy owner cleanup releases every surviving obstacle reservation");
            string decoyTemp=Path.Combine(Path.GetTempPath(),"war-decoy-"+Guid.NewGuid().ToString("N")+".json");
            try
            {
                var changed=JsonNode.Parse(File.ReadAllText(decoyArtifact))!;
                changed["maps"]![0]!["slots"]![0]!["initialMidpoint"]![0]=999;
                File.WriteAllText(decoyTemp,changed.ToJsonString());
                Reject(()=>DecoySourceCatalog.Load(decoyTemp,
                    Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(decoyTemp))),content.Maps));
            }
            finally {if(File.Exists(decoyTemp))File.Delete(decoyTemp);}
            string landMineArtifact=Path.Combine(directory,"recovered-landmine-source.json");
            string landMineRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(landMineArtifact)));
            var landMines=LandMineSourceCatalog.Load(landMineArtifact,landMineRevision,content.Maps);
            var parkLandMines=landMines.ForMap(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer"));
            var selectedLandMines=landMines.Select(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer").Source,1,_=>0);
            Check(landMines.SpawnLimit==3&&landMines.NavMeshSampleRadius==10&&landMines.NavMeshAreaMask==1&&
                  landMines.MinimumDamage==62.5f&&landMines.MaximumDamage==1090&&landMines.CardScale==.1f&&
                  landMines.PlayerRadiusCoefficient==.9f&&landMines.TriggerRadius==5&&landMines.HurtRadius==1.8f&&
                  landMines.DeadRadius==1.1f&&landMines.ExplosionCoefficient==new Vector3(5,8,5)&&
                  landMines.Prefab.TriggerSize==new Vector3(.23787257f,.09612553f,.23773421f)&&
                  parkLandMines.Count==13&&selectedLandMines.Count==3&&selectedLandMines.All(x=>x.Fraction==2)&&
                  selectedLandMines.Select(x=>x.ComponentFileId).Distinct().Count()==3&&
                  Math.Abs(landMines.Damage(22,44)-57.625f)<.001f,
                  "Land Mine source pins 89 opposing hiding slots, three distinct placements, prefab geometry and level-scaled damage");
            string landMineTemp=Path.Combine(Path.GetTempPath(),"war-landmine-"+Guid.NewGuid().ToString("N")+".json");
            try
            {
                var changed=JsonNode.Parse(File.ReadAllText(landMineArtifact))!;
                changed["maps"]![0]!["slots"]![0]!["sourcePosition"]![0]=99999;
                File.WriteAllText(landMineTemp,changed.ToJsonString());
                Reject(()=>LandMineSourceCatalog.Load(landMineTemp,
                    Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(landMineTemp))),content.Maps));
            }
            finally {if(File.Exists(landMineTemp))File.Delete(landMineTemp);}
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
            var vehicleAim=GroundVehicleAimPolicy.Resolve(Vector3.Zero,Vector3.UnitZ,
                new Vector3(1,0,1),70,4);
            Check(Math.Abs(vehicleAim.AngleDegrees-45)<.001f&&vehicleAim.AimTicks==15&&
                  Vector3.Distance(vehicleAim.Direction,Vector3.Normalize(new Vector3(1,0,1)))<.00001f,
                  "vehicle aim applies recovered angle gate and proportional minimum-bounded tween duration");
            Reject(()=>GroundVehicleAimPolicy.Resolve(Vector3.Zero,Vector3.UnitZ,Vector3.UnitX,70,4));
            var humveePrimary=content.GroundVehicleWeapons.For("ID_UNIT-HUMVEE").Roles[0];
            var tankPrimary=content.GroundVehicleWeapons.For("ID_UNIT-TANK").Roles[0];
            Check(GroundVehicleAimPolicy.CanFallbackToPlayer(humveePrimary,false,false)&&
                  !GroundVehicleAimPolicy.CanFallbackToPlayer(humveePrimary,false,true)&&
                  !GroundVehicleAimPolicy.CanFallbackToPlayer(humveePrimary,true,false)&&
                  GroundVehicleAimPolicy.CanFallbackToPlayer(tankPrimary,false,true)&&
                  GroundVehicleAimPolicy.PlayerProjectileSpeed(humveePrimary,5)==2.5f&&
                  GroundVehicleAimPolicy.PlayerProjectileSpeed(tankPrimary,5)==5,
                  "vehicle player fallback preserves decoy/AttackerRusher priority and Humvee speed scaling");
            var vehicleRolls=new Queue<float>([.999f,.1f,.2f,.3f,.5f]);
            var vehicleBatch=new VehicleAttackState(new ArmyVehicleShotStats(5,1,2,4,1,1,0),.1f,
                ()=>vehicleRolls.Dequeue());
            Check(vehicleBatch.TryBegin(true,0)&&vehicleBatch.BatchRemaining==3&&
                  vehicleBatch.AdvanceTick()&&vehicleBatch.ShotDue&&vehicleBatch.CurrentShotIsReal,
                  "vehicle batch uses recovered exclusive integer upper bound and exposes its first shot");
            Check(vehicleBatch.CommitShot()&&vehicleBatch.BatchRemaining==2&&
                  !vehicleBatch.AdvanceTick()&&!vehicleBatch.AdvanceTick()&&
                  vehicleBatch.AdvanceTick()&&vehicleBatch.CommitShot()&&
                  !vehicleBatch.AdvanceTick()&&!vehicleBatch.AdvanceTick()&&
                  vehicleBatch.AdvanceTick()&&vehicleBatch.CommitShot()&&
                  vehicleBatch.CooldownTicksRemaining==30,
                  "vehicle attack preserves per-round weapon cadence and post-batch turret cooldown");
            var transporterRolls=new Queue<float>([.9f,.1f,.8f,.2f,.7f]);
            var transporterVolley=TransporterVolleyPlanner.Plan(6,.3f,.5f,.5f,true,
                ()=>transporterRolls.Dequeue());
            Check(transporterVolley.Select(x=>(x.WeaponIndex,x.TickOffset)).SequenceEqual(
                      [(0,0),(0,9),(0,18),(1,8),(1,23),(1,38)])&&
                  transporterVolley.Select(x=>x.Real).SequenceEqual([true,false,true,false,true,false]),
                  "Transporter divides six rounds floor-half across two source cadences and delays the right gun");
            var transporterStateRolls=new Queue<float>([.999f,.2f,.5f]);
            var transporterState=new VehicleAttackState(
                new ArmyVehicleShotStats(5,.9f,4,7,3.5f,4.5f,0),.3f,
                ()=>transporterStateRolls.Dequeue());
            Check(transporterState.TryBegin(true,0)&&transporterState.BatchRemaining==6&&
                  transporterState.AdvanceTick()&&transporterState.CurrentShotIsReal&&
                  transporterState.CommitWholeBatch(out int transporterBatch)&&transporterBatch==6&&
                  transporterState.BatchRemaining==0&&transporterState.CooldownTicksRemaining==120,
                  "Transporter commits one split batch before its source post-volley cooldown");
            var initialVehicleRolls=new Queue<float>([.5f]);
            var initialVehicleAttack=new VehicleAttackState(
                new ArmyVehicleShotStats(5,1,2,4,1,2,0),.1f,()=>initialVehicleRolls.Dequeue());
            Check(initialVehicleAttack.BeginInitialCooldown()&&
                  initialVehicleAttack.Phase==ArmyAirAttackPhase.Cooldown&&
                  initialVehicleAttack.CooldownTicksRemaining==45&&
                  !initialVehicleAttack.BeginInitialCooldown(),
                  "vehicle spawn reproduces TurretWeaponBasic.Reset random initial cooldown");
            var cannonRolls=new Queue<float>([.5f,.25f]);
            var cannonState=new BuggyCannonAttackState(new ArmyVehicleCannonStats(600,8,10),.25f,
                ()=>cannonRolls.Dequeue());
            Check(cannonState.BeginInitialCooldown()&&cannonState.CooldownTicksRemaining==270,
                  "Buggy cannon starts on its recovered random cooldown");
            for(int i=0;i<270;i++)cannonState.AdvanceTick();
            Check(cannonState.TryBegin(0)&&cannonState.AdvanceTick()&&cannonState.PrimaryDue&&
                  cannonState.DamagePerMissile==300&&cannonState.CommitPrimary()&&
                  cannonState.CooldownTicksRemaining==255,
                  "Buggy primary missile owns half damage and independently starts turret cooldown");
            for(int i=0;i<7;i++)Check(!cannonState.AdvanceTick(),"Buggy secondary delay remains pending");
            Check(cannonState.AdvanceTick()&&cannonState.SecondaryDue&&cannonState.CommitSecondary(),
                  "Buggy secondary missile launches after the recovered eight-tick delay");
            var passengerBinding=buggyRig.Passengers.Single(x=>x.Role=="driver");
            var passengerState=new VehiclePassengerState(passengerBinding,426,525,10);
            Check(passengerState.Active&&passengerState.ApplyDamage(500,10)&&!passengerState.Active&&
                  passengerState.RespawnTick==535&&!passengerState.Advance(534)&&
                  passengerState.Advance(535)&&passengerState.Active&&passengerState.Health==426,
                  "vehicle passenger death disables its seat until the exact source respawn tick");
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
            string cardOwner="33333333333333333333333333333333",otherCardOwner="55555555555555555555555555555555";
            var cards=new WarCardReservationState(new[]{(cardOwner,"HeavyTurret",1),(cardOwner,"LandMine",2),
                (otherCardOwner,"LandMine",1)});
            Check(cards.TryReserve("44444444444444444444444444444444",cardOwner,"LandMine")&&
                  cards.IsReserved("44444444444444444444444444444444",cardOwner)&&cards.Remaining(cardOwner,"LandMine")==1&&
                  cards.Remaining(otherCardOwner,"LandMine")==1&&
                  !cards.TryReserve("44444444444444444444444444444444",cardOwner,"LandMine"),
                  "War Card activation consumes one server-owned card exactly once by request ID");
            Check(cards.TryRelease("44444444444444444444444444444444",cardOwner) && cards.Remaining(cardOwner,"LandMine")==2 &&
                  !cards.TryRelease("44444444444444444444444444444444",cardOwner),
                  "failed War Card effects can release their reservation exactly once");
            Reject(()=>new WarCardReservationState(new[]{(cardOwner,"HeavyTurret",1),(cardOwner,"HeavyTurret",1)}));
            Check(WarCardEffectCatalog.TryGet("CardAirstrike",out var airstrike)&&
                  airstrike.Kind==WarCardEffectKind.Damage&&airstrike.RequiresTarget&&
                  WarCardEffectCatalog.TryGet("CardHeavyTurret",out var turret)&&
                  turret.Kind==WarCardEffectKind.SpawnDeployable&&
                  WarCardEffectCatalog.TryGet("CardDecoy",out var decoyCard)&&
                  decoyCard.Kind==WarCardEffectKind.SpawnDeployable&&WarCardEffectCatalog.All.Count>=17&&
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
            string warperOwner=Guid.NewGuid().ToString("N");
            var warperConsumer=new War.Client.MatchEventConsumer();
            var warperPage=new MatchEventBatch{Code="events",LatestEventId=1};
            warperPage.Events.Add(new MatchEvent{EventId=1,Tick=3,Kind=MatchEventKind.WarperWarpStarted,
                ActorId=warperOwner,ArmyEntityId=1,ArmyOptionIndex=20,ArmyUnitId="ID_UNIT-WARPER",
                ArmySpawnComponentFileId=100,ArmyReservationFileId=0,Reason="warper"});
            Check(warperConsumer.Consume(warperPage)==1,
                  "Client event consumer accepts complete Warper presentation authority");
            var invalidWarperPage=new MatchEventBatch{Code="events",LatestEventId=1};
            invalidWarperPage.Events.Add(new MatchEvent{EventId=1,Tick=3,Kind=MatchEventKind.WarperWarpEnded,
                ActorId=warperOwner,ArmyEntityId=1,ArmyOptionIndex=20,ArmyUnitId="ID_UNIT-SHOTGUNNER",
                ArmySpawnComponentFileId=100,ArmyReservationFileId=0,Reason="warper"});
            Reject(()=>new War.Client.MatchEventConsumer().Consume(invalidWarperPage));
            var passengerConsumer=new War.Client.MatchEventConsumer();
            var passengerPage=new MatchEventBatch{Code="events",LatestEventId=1};
            passengerPage.Events.Add(new MatchEvent{EventId=1,Tick=4,
                Kind=MatchEventKind.VehiclePassengerDown,ActorId=warperOwner,ProjectileId=7,
                Reason="vehicle-passenger-down:driver"});
            Check(passengerConsumer.Consume(passengerPage)==1,
                  "Client event consumer accepts source-bound vehicle passenger lifecycle metadata");
            var invalidPassengerPage=new MatchEventBatch{Code="events",LatestEventId=1};
            invalidPassengerPage.Events.Add(new MatchEvent{EventId=1,Tick=4,
                Kind=MatchEventKind.VehiclePassengerRespawned,ActorId=warperOwner,ProjectileId=0,
                Reason="vehicle-passenger-respawn:driver"});
            Reject(()=>new War.Client.MatchEventConsumer().Consume(invalidPassengerPage));
            var repairDroneConsumer=new War.Client.MatchEventConsumer();
            var repairDronePage=new MatchEventBatch{Code="events",LatestEventId=2};
            repairDronePage.Events.Add(new MatchEvent{EventId=1,Tick=5,
                Kind=MatchEventKind.VehicleRepairDroneDown,ActorId=warperOwner,ProjectileId=8,
                Reason="vehicle-repair-drone-down:1"});
            repairDronePage.Events.Add(new MatchEvent{EventId=2,Tick=6,
                Kind=MatchEventKind.VehicleRepairDroneExploded,ActorId=warperOwner,ProjectileId=8,
                Reason="vehicle-repair-drone-exploded:1"});
            Check(repairDroneConsumer.Consume(repairDronePage)==2,
                  "Client event consumer accepts bounded repair-drone down and crash metadata");
            var invalidRepairDronePage=new MatchEventBatch{Code="events",LatestEventId=1};
            invalidRepairDronePage.Events.Add(new MatchEvent{EventId=1,Tick=5,
                Kind=MatchEventKind.VehicleRepairDroneRespawned,ActorId=warperOwner,ProjectileId=8,
                Reason="vehicle-repair-drone-respawn:2"});
            Reject(()=>new War.Client.MatchEventConsumer().Consume(invalidRepairDronePage));
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
            var walkingCooldown=new ArmyRusherAttackState(new(1f,1,1,1f,5f),()=>0,
                shotIntervalTicks:11,cooldownMinSeconds:5f,cooldownMaxSeconds:25f);
            walkingCooldown.BeginInitialCooldown();
            for(int i=0;i<149;i++)walkingCooldown.AdvanceTick();
            Check(walkingCooldown.Phase==ArmyRusherAttackPhase.Cooldown&&
                  walkingCooldown.CooldownTicksRemaining==1&&!walkingCooldown.AdvanceTick()&&
                  walkingCooldown.Phase==ArmyRusherAttackPhase.Ready,
                  "selected Shotgunner schedules its divided walking interval before the first attack");
            Reject(()=>walkingCooldown.BeginInitialCooldown());
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
        var miniPoints=content.ArmyMinigunnerPoints.ForFaction(park,1);
        var nearestMini=content.ArmyMinigunnerPoints.NearestFree(park,1,normal[0].Position,null,_=>false);
        Check(content.Maps.Sum(m=>new[]{1,2}.Sum(f=>content.ArmyMinigunnerPoints.ForFaction(m,f).Count))==44&&
              content.Maps.Where(m=>!m.Source.EndsWith("Snow_Multiplayer.unity",StringComparison.Ordinal))
                  .All(m=>content.ArmyMinigunnerPoints.ForFaction(m,1).Count==4&&
                          content.ArmyMinigunnerPoints.ForFaction(m,2).Count==4)&&
              content.ArmyMinigunnerPoints.ForFaction(content.Maps.Single(m=>
                  m.Source.EndsWith("Snow_Multiplayer.unity",StringComparison.Ordinal)),2).Count==8&&
              nearestMini!=null&&miniPoints.Contains(nearestMini),
              "all 44 source EnemyPointMinigunner identities and nearest-free initial selection are pinned");
        var randomMini=content.ArmyMinigunnerPoints.RandomFree(park,1,nearestMini!.ComponentFileId,
            id=>id==miniPoints[1].ComponentFileId,count=>count-1);
        Check(randomMini!=null&&randomMini.ComponentFileId!=nearestMini.ComponentFileId&&
              randomMini.ComponentFileId!=miniPoints[1].ComponentFileId&&
              content.ArmyMinigunnerPoints.RandomFree(park,1,nearestMini.ComponentFileId,
                  id=>id!=nearestMini.ComponentFileId,_=>0)==null,
              "later Minigunner selection preserves source list order, excludes current/occupied points, and closes when full");
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
        string decoyPlayer=armyManifest.Players[0].PlayerId,decoyOpponent=armyManifest.Players[1].PlayerId;
        var decoyManifest=armyManifest with
        {
            MatchId="decoy-match",SceneMasterPlayerId=decoyPlayer,
            Players=[armyManifest.Players[0] with {PlayerLevel=22},armyManifest.Players[1] with {PlayerLevel=22}]
        };
        var decoyMatch=new MatchEngine(decoyManifest,content:content,armyChoice:_=>0);
        decoyMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardDecoy"],[],[0],[133],[-1]),
            new(decoyOpponent,["CardDecoy"],[],[0],[-1],[-1])]);
        decoyMatch.Admit(decoyPlayer);decoyMatch.Admit(decoyOpponent);
        MatchCommand SelectDecoy(ulong id)=>new(){CommandId=id,SelectCards=new SelectCardsCommand
        {CardIds={"CardDecoy"},NormalUpgradeIndexes={0},SpecialUpgradeIndexes={133},EliteUpgradeIndexes={-1}}};
        Check(decoyMatch.Command(decoyPlayer,SelectDecoy(1)).Code=="cards-selected",
            "Decoy owner selects the recovered card before battle start");
        var opponentSelection=SelectDecoy(1);opponentSelection.SelectCards.SpecialUpgradeIndexes.Clear();
        opponentSelection.SelectCards.SpecialUpgradeIndexes.Add(-1);
        Check(decoyMatch.Command(decoyOpponent,opponentSelection).Code=="cards-selected",
            "Decoy opponent selection preserves its trusted upgrade lanes");
        decoyMatch.Command(decoyPlayer,new(){CommandId=2,Ready=new(){ManifestHash=decoyMatch.ManifestHash}});
        decoyMatch.Command(decoyOpponent,new(){CommandId=2,Ready=new(){ManifestHash=decoyMatch.ManifestHash}});
        decoyMatch.Advance(60);
        string liveDecoyRequest=new string('c',32);
        var decoyReply=decoyMatch.Command(decoyPlayer,new(){CommandId=3,
            UseDecoy=new(){RequestId=liveDecoyRequest}});
        float expectedDecoyHealth=content.Decoys.Health(22,content.BarrelPolicy.MaxDisplayLevel);
        Check(decoyReply.Code=="decoy-spawned"&&decoyReply.Snapshot.Decoys.Count==3&&
              decoyReply.Snapshot.Decoys.All(x=>x.OwnerPlayerId==decoyPlayer&&x.OwnerFraction==1&&
                  x.RequestId==liveDecoyRequest&&Math.Abs(x.Health-expectedDecoyHealth)<.001f&&x.Health==x.MaxHealth)&&
              decoyReply.Snapshot.Decoys.Select(x=>x.ObstacleComponentFileId).Distinct().Count()==3,
              "live authenticated Decoy activation atomically projects three level-scaled source placements");
        Check(decoyMatch.Command(decoyPlayer,new(){CommandId=4,
                  UseDecoy=new(){RequestId=liveDecoyRequest}}).Code=="decoy-replayed"&&
              decoyMatch.Command(decoyPlayer,new(){CommandId=5,
                  UseDecoy=new(){RequestId=new string('e',32)}}).Code=="decoy-unavailable"&&
              decoyMatch.Snapshot().Decoys.Count==3,
              "Decoy request replay creates no duplicate and exhausted inventory cannot create partial state");
        Check(decoyMatch.Command(decoyOpponent,new(){CommandId=3,
                  UseDecoy=new(){RequestId=new string('f',32)}}).Code=="decoy-spawned"&&
              decoyMatch.Snapshot().Decoys.Count==6&&decoyMatch.Snapshot().CardActivations==2,
              "trusted allocation provisions one isolated Decoy reservation for each selected player");
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
            ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f],ShieldLevel=0
        },detached.Players[1] with {ShieldLevel=0}]};
        var miniMatch=new MatchEngine(miniManifest,armyChoice:_=>0,content:content);
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
        var initialMiniMovement=miniMatch.MinigunnerMovementCandidate(miniEntity.EntityKey);
        int initialMiniPoint=miniMatch.MinigunnerPoint(miniEntity.EntityKey)??0;
        Check(miniEntity.UnitId=="ID_UNIT-MINIGUNNER" &&
              miniEntity.SpawnComponentFileId==normal[^1].ComponentFileId&&
              initialMiniMovement!=null&&initialMiniPoint==initialMiniMovement.PointFileId&&
              miniMatch.MinigunnerPointOccupant(initialMiniPoint)==miniEntity.EntityKey&&
              Vector3.Distance(new(miniEntity.X,miniEntity.Y,miniEntity.Z),initialMiniMovement.Destination)>.04f,
              "live Minigunner reserves its nearest free source point and starts walking from the spawn endpoint");
        bool miniArrived=false,miniTransferred=false;int secondMiniPoint=0;
        ulong miniArrivalTick=0,miniTransferTick=0;
        for(ulong t=62;t<500&&!miniMatch.Terminal;t++)
        {
            if(t%90==0){miniMatch.ArmyBatch(miniOwner);miniMatch.ArmyBatch(miniOpponent);}
            miniMatch.Advance(t);
            if(!miniArrived&&miniMatch.MinigunnerMovementCandidate(miniEntity.EntityKey)==null)
            {miniArrived=true;miniArrivalTick=t;}
            int current=miniMatch.MinigunnerPoint(miniEntity.EntityKey)??0;
            if(current!=0&&current!=initialMiniPoint)
            {miniTransferred=true;secondMiniPoint=current;if(miniTransferTick==0)miniTransferTick=t;}
        }
        var miniEvents=new List<MatchEvent>();ulong miniCursor=0;
        while(true)
        {
            var page=miniMatch.EventBatch(miniOwner,miniCursor);miniEvents.AddRange(page.Events);
            if(page.Events.Count==0||page.Events[^1].EventId==page.LatestEventId)break;
            miniCursor=page.Events[^1].EventId;
        }
        var firstMiniShot=miniEvents.FirstOrDefault(e=>e.Kind==MatchEventKind.Shot&&
            e.ActorId==miniOwner&&e.TargetId==miniOpponent&&e.Reason=="army");
        Check(firstMiniShot!=null&&firstMiniShot.Tick>=miniArrivalTick+91&&
              miniEvents.Any(e=>e.Kind==MatchEventKind.Impact&&e.Reason=="army")&&
              miniArrived&&miniTransferred&&miniTransferTick>miniArrivalTick+180&&secondMiniPoint!=0&&
              miniMatch.MinigunnerPointOccupant(initialMiniPoint)==null&&
              miniMatch.MinigunnerPointOccupant(secondMiniPoint)==miniEntity.EntityKey,
              "live Minigunner reaches its initial point, attacks, and transfers its reservation after the source point-change clock");
        Check(miniMatch.ApplyArmyHostDamage(miniEntity.EntityKey,miniEntity.MaxHealth)&&
              miniMatch.MinigunnerPoint(miniEntity.EntityKey)==null&&
              miniMatch.MinigunnerMovementCandidate(miniEntity.EntityKey)==null&&
              miniMatch.MinigunnerPointOccupant(secondMiniPoint)==null,
              "confirmed Minigunner death releases point, movement, attack, and target authority");
        var miniPairManifest=miniManifest with {MatchId="minigunner-pair"};
        var miniPair=new MatchEngine(miniPairManifest,armyChoice:n=>n-1,content:content);
        miniPair.Admit(miniOwner);miniPair.Admit(miniOpponent);
        miniPair.Command(miniOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=miniPair.ManifestHash}});
        miniPair.Command(miniOpponent,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=miniPair.ManifestHash}});
        miniPair.Advance(60);
        Check(miniPair.ArmyBatch(miniOwner).OptionIndexes.Contains(21)&&
              miniPair.Command(miniOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=21}}).Code=="army-deploying",
              "two-unit Minigunner source option enters the live spawn schedule");
        float miniPairMinimum=float.MaxValue,miniPairMatureMinimum=float.MaxValue,
            miniPairSpawnDistance=float.NaN,miniPairMaxSteering=0f;
        var miniPairArrived=new HashSet<ulong>();
        for(ulong t=61;t<700&&!miniPair.Terminal;t++)
        {
            if(t%90==0){miniPair.ArmyBatch(miniOwner);miniPair.ArmyBatch(miniOpponent);}
            miniPair.Advance(t);
            var pair=miniPair.ArmyEntityBatch(miniOwner,0,0).Entities;
            if(pair.Count==2)
            {
                var a=pair[0];var b=pair[1];
                float separation=Vector2.Distance(new(a.X,a.Z),new(b.X,b.Z));
                if(float.IsNaN(miniPairSpawnDistance))miniPairSpawnDistance=separation;
                miniPairMinimum=Math.Min(miniPairMinimum,separation);
                if(t>=100)miniPairMatureMinimum=Math.Min(miniPairMatureMinimum,separation);
                foreach(var entity in pair)
                {
                    var offset=miniPair.MinigunnerSteeringOffset(entity.EntityKey);
                    if(offset.HasValue)miniPairMaxSteering=Math.Max(miniPairMaxSteering,offset.Value.Length());
                    else miniPairArrived.Add(entity.EntityKey);
                }
            }
        }
        var miniPairFinal=miniPair.ArmyEntityBatch(miniOwner,0,0).Entities;
        Console.WriteLine($"Park two-Minigunner separation spawn {miniPairSpawnDistance:F3}, minimum {miniPairMinimum:F3}, mature {miniPairMatureMinimum:F3}, steering {miniPairMaxSteering:F3}, arrived {miniPairArrived.Count}");
        Check(miniPairMinimum>=.339f&&miniPairMatureMinimum>=.339f&&
              miniPairMaxSteering>0f&&miniPairArrived.Count==2,
              "prior-frame Minigunner lateral steering preserves source-radius separation and both agents arrive");
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
        var paratrooperManifest=detached with {MatchId="paratrooper-kevlar",Players=detached.Players.Select((p,i)=>p with
        {
            EquippedArmyUnitIds=["ID_UNIT-PARATROOPER"],NewArmyUnitIds=null,
            ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[i==0?101:-1],ArmyEliteUpgradeIndexes=[-1],
            ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],
            ArmyAccuracyCoefficients=[1f]
        }).ToArray()};
        content.ValidateAllocation(paratrooperManifest);
        var paratrooperMatch=new MatchEngine(paratrooperManifest,content:content,armyChoice:_=>0);
        paratrooperMatch.Admit(soldierOwner);paratrooperMatch.Admit(helicopterOwner);
        paratrooperMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=paratrooperMatch.ManifestHash}});
        paratrooperMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=paratrooperMatch.ManifestHash}});
        paratrooperMatch.Advance(60);
        var paratrooperHand=paratrooperMatch.ArmyBatch(soldierOwner);
        int paratrooperOption=paratrooperHand.OptionIndexes.OrderBy(x=>content.Army.Option(x).Count).First();
        Check(paratrooperMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=paratrooperOption}}).Code=="army-deploying",
              "source-special Paratrooper enters the host deployment lifecycle");
        for(ulong paratrooperTick=61;paratrooperTick<=70;paratrooperTick++)paratrooperMatch.Advance(paratrooperTick);
        var paratrooper=paratrooperMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        float paratrooperHealth=paratrooper.MaxHealth,paratrooperKevlar=paratrooper.MaxKevlar;
        Check(paratrooperKevlar==paratrooperHealth*.2f&&paratrooper.Kevlar==paratrooperKevlar&&
              paratrooperMatch.ArmyKevlar(paratrooper.EntityKey)==paratrooperKevlar,
              "selected Paratrooper special projects composed-ratio kevlar from authoritative max health");
        Check(paratrooperMatch.ApplyArmyHostDamage(paratrooper.EntityKey,paratrooperKevlar/2)&&
              paratrooperMatch.ArmyHealth(paratrooper.EntityKey)==paratrooperHealth&&
              paratrooperMatch.ArmyKevlar(paratrooper.EntityKey)==paratrooperKevlar/2,
              "Paratrooper kevlar absorbs original damage before main vitality");
        Check(paratrooperMatch.ApplyArmyHostDamage(paratrooper.EntityKey,paratrooperKevlar/2+10)&&
              paratrooperMatch.ArmyHealth(paratrooper.EntityKey)==paratrooperHealth-10&&
              paratrooperMatch.ArmyKevlar(paratrooper.EntityKey)==0&&
              paratrooperMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single() is
                  {Kevlar:0,MaxKevlar:>0},
              "damage beyond depleted Paratrooper kevlar spills exactly into health and reconnect projection");
        var walkingShotgunnerManifest=detached with {MatchId="shotgunner-walking-fire",
            Players=detached.Players.Select((p,i)=>p with
            {
                EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER"],NewArmyUnitIds=null,
                ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[i==0?101:-1],ArmyEliteUpgradeIndexes=[-1],
                ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],
                ArmyAccuracyCoefficients=[2f]
            }).ToArray()};
        content.ValidateAllocation(walkingShotgunnerManifest);
        var walkingShotgunnerMatch=new MatchEngine(walkingShotgunnerManifest,content:content,armyChoice:_=>0);
        walkingShotgunnerMatch.Admit(soldierOwner);walkingShotgunnerMatch.Admit(helicopterOwner);
        walkingShotgunnerMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=walkingShotgunnerMatch.ManifestHash}});
        walkingShotgunnerMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=walkingShotgunnerMatch.ManifestHash}});
        walkingShotgunnerMatch.Advance(60);
        int walkingOption=walkingShotgunnerMatch.ArmyBatch(soldierOwner).OptionIndexes
            .OrderBy(x=>content.Army.Option(x).Count).First();
        Check(walkingShotgunnerMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=walkingOption}}).Code=="army-deploying",
              "selected-special Shotgunner enters its source walking route");
        ulong walkingTick=60;BattleArmyEntityState? walkingEntity=null;
        while(walkingEntity==null&&walkingTick<90)
        {
            walkingShotgunnerMatch.Advance(++walkingTick);
            walkingEntity=walkingShotgunnerMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.SingleOrDefault();
        }
        bool walkingShot=false,observedWalkingPose=false;float priorProgress=0;
        while(!walkingShot&&walkingTick<400)
        {
            var before=walkingShotgunnerMatch.RusherMotionCandidate(walkingEntity!.EntityKey);
            priorProgress=before?.MotionProgress??priorProgress;
            walkingShotgunnerMatch.Advance(++walkingTick);
            var after=walkingShotgunnerMatch.RusherMotionCandidate(walkingEntity.EntityKey);
            var shotgunnerPose=walkingShotgunnerMatch.InfantryPose(walkingEntity.EntityKey);
            observedWalkingPose|=shotgunnerPose is {Clip:"shotgunner_run",Parts.Count:3}&&
                shotgunnerPose.Parts.All(x=>x.SourcePath.StartsWith("army/",StringComparison.Ordinal));
            walkingShot=walkingShotgunnerMatch.RusherShotIntents.Any(x=>x.EntityKey==walkingEntity.EntityKey&&x.IsReal)&&
                after is {Phase:ArmyRusherTravelPhase.Walking}&&after.MotionProgress>priorProgress;
        }
        Check(walkingShot&&observedWalkingPose,
              "special Shotgunner fires while its source walking clip supplies three moving explosion colliders");
        var walkingLive=walkingShotgunnerMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        float walkingHealthBefore=walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value;
        float sourceDroneHealth=content.Army.ComposeTransporterRepairDrone(0,71,null,new(1,1)).MaximumHealth;
        int infantryBlastHits=walkingShotgunnerMatch.ApplyTransporterRepairDroneInfantryExplosion(
            new(walkingLive.X,walkingLive.Y,walkingLive.Z),sourceDroneHealth);
        Check(infantryBlastHits==1&&Math.Abs(walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value-
                  (walkingHealthBefore-sourceDroneHealth*content.GroundVehicleWeapons.RepairDronePrefab.ExplosionDamageRatio))<.001f,
              "repair-drone blast selects the live animated Shotgunner body and applies source full-radius damage");
        var infantryTargets=walkingShotgunnerMatch.GroundVehicleShotTargets(helicopterOwner)
            .Where(x=>x.EntityId==walkingLive.EntityKey&&x.ArmyInfantry).ToArray();
        var infantryHead=infantryTargets.Single(x=>x.Hitbox.Weight==1.5f);
        var infantryRayOrigin=infantryHead.Hitbox.Center+Vector3.UnitY;
        var infantryWorld=new ShotCollisionWorld(null,
        [
            new(helicopterOwner,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new(soldierOwner,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>infantryTargets);
        var infantryHit=infantryWorld.Raycast(helicopterOwner,infantryRayOrigin,
            infantryHead.Hitbox.Center-infantryRayOrigin,2,content.Bindings.BulletMask(2));
        float projectileHealthBefore=walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value;
        walkingShotgunnerMatch.ApplyArmyProjectileImpact(helicopterOwner,walkingLive.EntityKey,10,
            infantryHit!.PartWeight);
        Check(infantryTargets.Length==3&&infantryTargets.All(x=>x.PartComponentFileId==0&&
                  x.PassengerRole==null&&x.RepairDronePathIndex==null&&x.Layer==23)&&
              infantryHit is {DynamicArmyInfantry:true,DynamicEntityId:var infantryEntity,PartWeight:1.5f}&&
              infantryEntity==walkingLive.EntityKey&&
              Math.Abs(walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value-
                  (projectileHealthBefore-15))<.001f,
              "animated infantry enters the shared opposing projectile world and applies its trusted head multiplier");
        var warperManifest=detached with {MatchId="warper-initial-relocation",IdleSeconds=120,Players=detached.Players.Select(p=>p with
        {
            EquippedArmyUnitIds=["ID_UNIT-WARPER"],NewArmyUnitIds=null,ArmyNormalUpgradeIndexes=[0],
            ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
            ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
        }).ToArray()};
        content.ValidateAllocation(warperManifest);
        var warperMatch=new MatchEngine(warperManifest,content:content,armyChoice:_=>0);
        warperMatch.Admit(soldierOwner);warperMatch.Admit(helicopterOwner);
        warperMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=warperMatch.ManifestHash}});
        warperMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=warperMatch.ManifestHash}});
        warperMatch.Advance(60);
        int warperOption=warperMatch.ArmyBatch(soldierOwner).OptionIndexes
            .OrderBy(x=>content.Army.Option(x).Count).First();
        Check(warperMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=warperOption}}).Code=="army-deploying",
              "Warper deployment enters server-owned relocation");
        ulong warperTick=60;BattleArmyEntityState? liveWarper=null;
        while(liveWarper==null&&warperTick<100)
        {warperMatch.Advance(++warperTick);liveWarper=warperMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.FirstOrDefault();}
        var warperStart=new Vector3(liveWarper!.X,liveWarper.Y,liveWarper.Z);
        Check(warperMatch.WarperRelocationCandidate(liveWarper.EntityKey)!=null&&
              warperMatch.RusherMotionCandidate(liveWarper.EntityKey)==null,
              "live Warper begins edge relocation before ordinary Rusher travel");
        ArmyWarperRelocationState? liveRelocation=warperMatch.WarperRelocationCandidate(liveWarper.EntityKey);
        bool completedInitialRelocation=false,observedLiveWarp=false,observedWarpPose=false,observedWarpIdlePose=false;
        while(warperTick<1500)
        {
            warperMatch.Advance(++warperTick);
            liveRelocation=warperMatch.WarperRelocationCandidate(liveWarper.EntityKey);
            observedLiveWarp|=liveRelocation?.Transparent==true;
            var warperPose=warperMatch.InfantryPose(liveWarper.EntityKey);
            observedWarpPose|=liveRelocation?.Transparent==true&&warperPose?.Clip=="warp_movement";
            observedWarpIdlePose|=liveRelocation?.Phase==ArmyWarperRelocationPhase.Pause&&warperPose?.Clip=="warp_idle";
            if(liveRelocation==null&&warperMatch.RusherMotionCandidate(liveWarper.EntityKey)!=null)
            {completedInitialRelocation=true;break;}
        }
        var relocatedWarper=warperMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        Check(completedInitialRelocation&&observedLiveWarp&&observedWarpPose&&observedWarpIdlePose&&
              Vector3.Distance(warperStart,new(relocatedWarper.X,relocatedWarper.Y,relocatedWarper.Z))>1,
              "live Warper binds warp movement and idle poses while completing relocation before Rusher arrival");
        var warperEvents=new List<MatchEvent>();ulong warperEventCursor=0,warperLatest;
        do
        {
            var eventPage=warperMatch.EventBatch(soldierOwner,warperEventCursor);
            Check(eventPage.Code=="events","live Warper event cursor remains valid");
            warperLatest=eventPage.LatestEventId;warperEvents.AddRange(eventPage.Events);
            if(eventPage.Events.Count>0)warperEventCursor=eventPage.Events[^1].EventId;
        } while(warperEventCursor<warperLatest);
        var presentationEvents=warperEvents.Where(x=>x.Kind==MatchEventKind.WarperWarpStarted||
            x.Kind==MatchEventKind.WarperWarpEnded).ToArray();
        Check(presentationEvents.Length>=2&&presentationEvents[0].Kind==MatchEventKind.WarperWarpStarted&&
              presentationEvents[^1].Kind==MatchEventKind.WarperWarpEnded&&
              presentationEvents.All(x=>x.ActorId==soldierOwner&&x.ArmyEntityId==liveWarper.LocalEntityId&&
                  x.ArmyOptionIndex==liveWarper.OptionIndex&&x.ArmyUnitId=="ID_UNIT-WARPER"&&
                  x.ArmySpawnComponentFileId==liveWarper.SpawnComponentFileId&&
                  x.ArmyReservationFileId==liveWarper.ReservationFileId&&x.Reason=="warper"),
              "live Warper publishes ordered source-bound transparent and normal-material events");
        bool postShotRestart=false;ulong? scheduledRestart=null,restartedAt=null;
        while(warperTick<1200)
        {
            warperMatch.Advance(++warperTick);
            scheduledRestart??=warperMatch.WarperRestartTick(liveWarper.EntityKey);
            if(warperMatch.WarperRelocationCandidate(liveWarper.EntityKey)!=null)
            {postShotRestart=true;restartedAt=warperTick;break;}
        }
        Check(postShotRestart&&scheduledRestart==restartedAt&&
              warperMatch.RusherMotionCandidate(liveWarper.EntityKey)==null,
              "live Warper re-enters server-owned relocation one second after Rusher shooting starts");
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
        var eligibleRusherRow=rusherRows.Entities.Skip(1)
            .OrderByDescending(entity=>content.ArmyWeapons.WindupTicks(entity.UnitId)).First();
        ulong eligibleRusher=eligibleRusherRow.EntityKey;
        int eligibleWindup=content.ArmyWeapons.WindupTicks(eligibleRusherRow.UnitId);
        Check(eligibleWindup>0,"live Rusher timing fixture retains a non-flamethrower windup");
        float retargetMinimumGap=float.MaxValue;
        for(int i=0;i<700 && rusherMatch.RusherLatchedShotTarget(eligibleRusher)==null &&
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
        var latchedShotTarget=rusherMatch.RusherLatchedShotTarget(eligibleRusher);
        Check(latchedShotTarget is {PlayerId:var targetPlayer,TargetFileId:17927} &&
              targetPlayer==helicopterOwner,
              "match-owned Rusher latches the current Moving target when its source shot begins");
        int oldRusherPoint=rusherMatch.RusherWalkingTarget(eligibleRusher)!.RusherPointFileId;
        var coverMove=rusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=2,
            MoveCover=new MoveCoverCommand{Direction=1}});
        Check(coverMove.Code=="moving" &&
              rusherMatch.RusherMotionCandidate(eligibleRusher)!=null &&
              rusherMatch.RusherSlotOccupant(oldRusherPoint)==eligibleRusher &&
              rusherMatch.RusherWalkingRoute(eligibleRusher) is {PlanarCovered:true},
              "defender cover departure retains the old occupied Rusher state during the source delay");
        for(int i=1;i<eligibleWindup;i++)rusherMatch.Advance(++rusherTick);
        Check(rusherMatch.RusherLatchedShotTarget(eligibleRusher)==latchedShotTarget &&
              rusherMatch.RusherSlotOccupant(oldRusherPoint)==eligibleRusher,
              "Rusher windup retains its prepared target and pauses source retargeting after cover departure");
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
        var firstCar=staleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        var firstCarSpawn=content.ArmySpawnPoints.ForMap(park).Single(p=>
            p.ComponentFileId==firstCar.SpawnComponentFileId);
        Check(firstCar.UnitId=="ID_UNIT-HUMVEE"&&firstCarSpawn.VehicleRoute!=null&&
              Vector3.Distance(new(firstCar.X,firstCar.Y,firstCar.Z),firstCarSpawn.Position)>1f&&
              staleMatch.GroundVehicleAttack(firstCar.EntityKey) is {ShotSpeed:5f} carAttack&&
              carAttack.Phase is ArmyAirAttackPhase.Ready or ArmyAirAttackPhase.Cooldown&&
              staleMatch.GroundVehicleFacing(firstCar.EntityKey) is { } carFacing&&
              Math.Abs(carFacing.Y)<.00001f&&Math.Abs(carFacing.Length()-1)<.00001f&&
              staleMatch.Snapshot().Vehicles.Any(v=>v.EntityId==firstCar.EntityKey&&v.UnitId==firstCar.UnitId),
              "deployed Humvee reserves its source car route and publishes fixed-tick motion and facing");
        var liveVehicleTargets=staleMatch.GroundVehicleShotTargets(helicopterOwner);
        var livePassengerTargets=liveVehicleTargets.Where(x=>x.EntityId==firstCar.EntityKey&&
            x.PassengerRole=="gunner").ToArray();
        var liveHeadTarget=livePassengerTargets.Single(x=>x.Hitbox.Weight==1.5f);
        var passengerRayOrigin=liveHeadTarget.Hitbox.Center+Vector3.UnitY;
        var passengerOnlyWorld=new ShotCollisionWorld(null,
        [
            new(helicopterOwner,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new(soldierOwner,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>livePassengerTargets);
        var passengerHit=passengerOnlyWorld.Raycast(helicopterOwner,passengerRayOrigin,
            liveHeadTarget.Hitbox.Center-passengerRayOrigin,2,content.Bindings.BulletMask(2));
        Check(livePassengerTargets.Length==3&&livePassengerTargets.All(x=>x.Layer==23)&&
              passengerHit is {DynamicEntityId:var passengerVehicle,DynamicPassengerRole:"gunner",PartWeight:1.5f}&&
              passengerVehicle==firstCar.EntityKey,
              "opposing projectile mask selects the live Humvee gunner's sampled head collider");
        staleMatch.ApplyGroundVehiclePassengerProjectileImpact(helicopterOwner,firstCar.EntityKey,
            "gunner",100,passengerHit!.PartWeight);
        float vehicleHealthBefore=firstCar.Health;
        int humveeBodyPart=content.GroundVehicleWeapons.For(firstCar.UnitId).BodyParts[0].PartComponentFileId;
        staleMatch.ApplyGroundVehicleProjectileImpact(helicopterOwner,firstCar.EntityKey,humveeBodyPart,100);
        var damagedCar=staleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        Check(Math.Abs(damagedCar.Health-(vehicleHealthBefore-33))<.001f&&
              Math.Abs(staleMatch.Snapshot().Vehicles.Single(v=>v.EntityId==firstCar.EntityKey).Health-
                  damagedCar.Health)<.001f,
              "host-selected Humvee body hit applies the recovered 0.33 armor coefficient to shared vehicle health");
        var liveGunner=staleMatch.Snapshot().Vehicles.Single(v=>v.EntityId==firstCar.EntityKey)
            .Parts.Single(p=>p.PartId=="crew:gunner");
        Check(liveGunner.Active&&Math.Abs(liveGunner.Health-(liveGunner.MaxHealth-150))<.001f&&
              liveGunner.PointComponentFileId==11462687&&
              staleMatch.ApplyVehiclePassengerHostDamage(firstCar.EntityKey,"gunner",liveGunner.MaxHealth)&&
              staleMatch.Snapshot().Vehicles.Single(v=>v.EntityId==firstCar.EntityKey).Parts
                  .Single(p=>p.PartId=="crew:gunner") is {Active:false,Health:0} downGunner&&
              downGunner.RespawnTick==nextCarTick+375&&
              staleMatch.GroundVehicleShotTargets(helicopterOwner)
                  .All(x=>x.EntityId!=firstCar.EntityKey||x.PassengerRole!="gunner"),
              "live Humvee gunner death publishes source seat identity and exact respawn deadline");
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
        for(ulong t=nextCarTick+2;t<1500&&!staleMatch.Terminal;t++)
        {
            staleMatch.Advance(t);
            if(t%90==0)
            {staleMatch.ArmyEntityBatch(soldierOwner,0,0);staleMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        var parkedVehicles=staleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var liveTank=parkedVehicles.Single(x=>x.UnitId=="ID_UNIT-TANK");
        Check(staleMatch.Snapshot().Vehicles.Single(v=>v.EntityId==firstCar.EntityKey).Parts
                  .Single(p=>p.PartId=="crew:gunner") is {Active:true,RespawnTick:0,Health:875.34f}&&
              staleMatch.GroundVehicleShotTargets(helicopterOwner)
                  .Count(x=>x.EntityId==firstCar.EntityKey&&x.PassengerRole=="gunner")==3,
              "live Humvee gunner respawns at full source-row health during host simulation");
        Check(staleMatch.TankCannonAttack(liveTank.EntityKey)!=null&&
              staleMatch.TankCannonDamage(liveTank.EntityKey)==1808.03f,
              "live Tank owns its independently composed cannon authority");
        Check(parkedVehicles.Count==2&&parkedVehicles.All(entity=>
        {
            var spawn=content.ArmySpawnPoints.ForMap(park).Single(p=>p.ComponentFileId==entity.SpawnComponentFileId);
            return spawn.VehicleRoute!=null&&staleMatch.VehicleRouteMotion(entity.EntityKey)==null&&
                   Vector3.Distance(new(entity.X,entity.Y,entity.Z),spawn.VehicleRoute.Positions[^1])<.0001f;
        }),"live Humvee and Tank traverse their reserved source waypoint lists and park at final targets");
        var humveeRusherManifest=detached with {MatchId="humvee-rusher-priority",IdleSeconds=120,
            Players=[detached.Players[0] with
            {
                EquippedArmyUnitIds=["ID_UNIT-HUMVEE"],NewArmyUnitIds=null,ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
                ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[2f]
            },detached.Players[1] with
            {
                EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER"],NewArmyUnitIds=null,ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
                ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
            }]};
        content.ValidateAllocation(humveeRusherManifest);
        var humveeRusherMatch=new MatchEngine(humveeRusherManifest,content:content,armyChoice:_=>0);
        humveeRusherMatch.Admit(soldierOwner);humveeRusherMatch.Admit(helicopterOwner);
        humveeRusherMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=humveeRusherMatch.ManifestHash}});
        humveeRusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=humveeRusherMatch.ManifestHash}});
        humveeRusherMatch.Advance(60);
        int humveeOption=humveeRusherMatch.ArmyBatch(soldierOwner).OptionIndexes.First();
        int opposingRusherOption=humveeRusherMatch.ArmyBatch(helicopterOwner).OptionIndexes
            .OrderBy(x=>content.Army.Option(x).Count).First();
        Check(humveeRusherMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=humveeOption}}).Code=="army-deploying"&&
              humveeRusherMatch.Command(helicopterOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=opposingRusherOption}}).Code=="army-deploying",
              "Humvee and opposing AttackerRusher enter one authoritative match");
        ulong priorityTick=60,humveeId=0,rusherId=0;
        while(priorityTick<1800&&!humveeRusherMatch.Terminal&&
              (humveeId==0||rusherId==0||humveeRusherMatch.GroundVehicleArmyTarget(humveeId)!=rusherId))
        {
            humveeRusherMatch.Advance(++priorityTick);
            if(priorityTick%90==0)
            {humveeRusherMatch.ArmyEntityBatch(soldierOwner,0,0);humveeRusherMatch.ArmyEntityBatch(helicopterOwner,0,0);}
            humveeId=humveeRusherMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                .SingleOrDefault(x=>x.UnitId=="ID_UNIT-HUMVEE")?.EntityKey??0;
            rusherId=humveeRusherMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
                .FirstOrDefault(x=>x.UnitId=="ID_UNIT-SHOTGUNNER")?.EntityKey??0;
        }
        Check(humveeId!=0&&rusherId!=0&&humveeRusherMatch.GroundVehicleArmyTarget(humveeId)==rusherId&&
              humveeRusherMatch.GroundVehicleSelectedShotSpeed(humveeId)==5,
              "live Humvee selects the opposing AttackerRusher before player fallback and keeps full projectile speed");
        var humveeDecoyManifest=humveeRusherManifest with
        {
            MatchId="humvee-decoy-priority",SceneMasterPlayerId=soldierOwner,
            Players=[humveeRusherManifest.Players[0] with {PlayerLevel=22},
                humveeRusherManifest.Players[1] with {PlayerLevel=22}]
        };
        int decoyChoice=0;
        var humveeDecoyMatch=new MatchEngine(humveeDecoyManifest,content:content,
            armyChoice:n=>n<=0?0:decoyChoice++%n,combatRandom:()=>0);
        humveeDecoyMatch.ConfigureBattleAllocations([
            new(soldierOwner,[],[],[0],[-1],[-1]),
            new(helicopterOwner,["CardDecoy"],[],[0],[-1],[-1])]);
        humveeDecoyMatch.Admit(soldierOwner);humveeDecoyMatch.Admit(helicopterOwner);
        var emptyHumveeCards=new MatchCommand{CommandId=1,SelectCards=new SelectCardsCommand
            {NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}};
        var opposingDecoyCards=new MatchCommand{CommandId=1,SelectCards=new SelectCardsCommand
            {CardIds={"CardDecoy"},NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}};
        Check(humveeDecoyMatch.Command(soldierOwner,emptyHumveeCards).Code=="cards-selected"&&
              humveeDecoyMatch.Command(helicopterOwner,opposingDecoyCards).Code=="cards-selected",
              "Humvee-versus-Decoy match binds both trusted selections without cross-player receipt collision");
        humveeDecoyMatch.Command(soldierOwner,new(){CommandId=2,Ready=new(){ManifestHash=humveeDecoyMatch.ManifestHash}});
        humveeDecoyMatch.Command(helicopterOwner,new(){CommandId=2,Ready=new(){ManifestHash=humveeDecoyMatch.ManifestHash}});
        humveeDecoyMatch.Advance(60);
        var liveDecoyReply=humveeDecoyMatch.Command(helicopterOwner,new(){CommandId=3,
            UseDecoy=new(){RequestId=new string('9',32)}});
        Check(liveDecoyReply.Code=="decoy-spawned","opposing Decoys enter the Humvee priority match");
        int liveHumveeOption=humveeDecoyMatch.ArmyBatch(soldierOwner).OptionIndexes.First();
        Check(humveeDecoyMatch.Command(soldierOwner,new(){CommandId=3,
                  DeployArmy=new(){OptionIndex=liveHumveeOption}}).Code=="army-deploying",
              "Humvee enters the opposing Decoy match");
        ulong decoyPriorityTick=60,decoyHumveeId=0,selectedDecoyId=0;int selectedDecoyObstacle=0;
        while(decoyPriorityTick<1800&&!humveeDecoyMatch.Terminal&&selectedDecoyId==0)
        {
            humveeDecoyMatch.Advance(++decoyPriorityTick);
            if(decoyPriorityTick%90==0)
            {humveeDecoyMatch.ArmyEntityBatch(soldierOwner,0,0);humveeDecoyMatch.ArmyEntityBatch(helicopterOwner,0,0);}
            decoyHumveeId=humveeDecoyMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                .SingleOrDefault(x=>x.UnitId=="ID_UNIT-HUMVEE")?.EntityKey??0;
            selectedDecoyId=decoyHumveeId==0?0:humveeDecoyMatch.GroundVehicleDecoyTarget(decoyHumveeId)??0;
        }
        var selectedDecoy=humveeDecoyMatch.Snapshot().Decoys.SingleOrDefault(x=>x.EntityId==selectedDecoyId);
        selectedDecoyObstacle=selectedDecoy?.ObstacleComponentFileId??0;
        Check(decoyHumveeId!=0&&selectedDecoyId!=0&&selectedDecoy!=null&&
              humveeDecoyMatch.GroundVehicleArmyTarget(decoyHumveeId)==null&&
              humveeDecoyMatch.GroundVehicleSelectedShotSpeed(decoyHumveeId)==5,
              "live Humvee selects an opposing Decoy before Rusher/player fallback and keeps full projectile speed");
        bool decoyDestroyed=false;
        while(decoyPriorityTick<1860&&!humveeDecoyMatch.Terminal)
        {
            humveeDecoyMatch.Advance(++decoyPriorityTick);
            if(humveeDecoyMatch.DecoyHealth(selectedDecoyId)==null){decoyDestroyed=true;break;}
        }
        var humveeDecoyEvents=new List<MatchEvent>();ulong humveeDecoyCursor=0,humveeDecoyLatest;
        do
        {
            var page=humveeDecoyMatch.EventBatch(soldierOwner,humveeDecoyCursor);
            humveeDecoyLatest=page.LatestEventId;humveeDecoyEvents.AddRange(page.Events);
            if(page.Events.Count>0)humveeDecoyCursor=page.Events[^1].EventId;
        }while(humveeDecoyCursor<humveeDecoyLatest);
        Check(decoyDestroyed&&!humveeDecoyMatch.DecoyObstacleOccupied(selectedDecoyObstacle)&&
              humveeDecoyMatch.Snapshot().Decoys.All(x=>x.EntityId!=selectedDecoyId)&&
              humveeDecoyEvents.Any(x=>
                  x.Kind==MatchEventKind.DecoyDestroyed&&x.ProjectileId==selectedDecoyId),
              "live Humvee projectile destroys its typed Decoy target and releases the exact obstacle slot");
        var transporterManifest=detached with {MatchId="transporter-split-fire",Players=[detached.Players[0] with
        {
            EquippedArmyUnitIds=["ID_UNIT-TRANSPORTER"],NewArmyUnitIds=null,
            ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[71],ArmyEliteUpgradeIndexes=[-1],
            ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],
            ArmyAccuracyCoefficients=[1f]
        },detached.Players[1]]};
        var transporterMatch=new MatchEngine(transporterManifest,content:content);
        transporterMatch.Admit(soldierOwner);transporterMatch.Admit(helicopterOwner);
        transporterMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=transporterMatch.ManifestHash}});
        transporterMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=transporterMatch.ManifestHash}});
        transporterMatch.Advance(60);
        Check(transporterMatch.ArmyBatch(soldierOwner).OptionIndexes.Contains(32)&&
              transporterMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=32}}).Code=="army-deploying",
              "recovered Transporter option enters the live vehicle route");
        ulong transporterSpawnTick=transporterMatch.ArmyBatch(soldierOwner).NextDeployTick;
        for(ulong t=61;t<=transporterSpawnTick;t++)
        {
            transporterMatch.Advance(t);
            if(t%90==0)
            {transporterMatch.ArmyEntityBatch(soldierOwner,0,0);transporterMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        var transporterEntity=transporterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        var initialDrones=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey);
        Check(initialDrones.Count==2&&initialDrones.All(x=>x is
              {Active:true,RespawnTick:0}&&x.MaximumHealth>70&&
              Math.Abs(x.Health-x.MaximumHealth)<.001f),
              "live special-lane Transporter creates one authoritative repair drone on each recovered path");
        var initialDroneProjection=transporterMatch.Snapshot().Vehicles.Single().RepairDrones;
        Check(initialDroneProjection.Count==2&&initialDroneProjection.Select(x=>x.PathIndex).SequenceEqual([0,1])&&
              initialDroneProjection.All(x=>x.Active&&x.Health==x.MaxHealth&&x.RespawnTick==0&&
                  x.WaypointIndex is >=0 and <=6),
              "protobuf vehicle snapshot publishes both ordered authoritative repair drones");
        ulong transporterTick=transporterSpawnTick;
        while(transporterMatch.GroundVehicleAttack(transporterEntity.EntityKey)?.Phase!=ArmyAirAttackPhase.Ready&&
              transporterTick<transporterSpawnTick+200)
        {
            transporterMatch.Advance(++transporterTick);
            if(transporterTick%90==0)
            {transporterMatch.ArmyEntityBatch(soldierOwner,0,0);transporterMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        if(transporterMatch.GroundVehicleAttack(transporterEntity.EntityKey)?.Phase==ArmyAirAttackPhase.Ready)
        {
            var transporterTargetPlayer=transporterMatch.Snapshot().Players.Single(x=>x.PlayerId==helicopterOwner);
            string transporterAttackResult=transporterMatch.Command(soldierOwner,new MatchCommand{CommandId=3,
                VehicleAttack=new VehicleAttackCommand{EntityId=transporterEntity.EntityKey,
                    TargetPlayerId=helicopterOwner,TargetX=transporterTargetPlayer.PositionX,
                    TargetY=transporterTargetPlayer.PositionY,TargetZ=transporterTargetPlayer.PositionZ}}).Code;
            Check(transporterAttackResult=="vehicle-attack-accepted",
                "live Transporter accepts a host-validated opposing player target");
        }
        for(int i=0;i<100&&!transporterMatch.Terminal;i++)
        {
            transporterMatch.Advance(++transporterTick);
            if(transporterTick%90==0)
            {transporterMatch.ArmyEntityBatch(soldierOwner,0,0);transporterMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        var transporterEvents=new List<MatchEvent>();ulong transporterCursor=0;
        while(true)
        {
            var page=transporterMatch.EventBatch(helicopterOwner,transporterCursor);
            transporterEvents.AddRange(page.Events);
            if(page.Events.Count==0||page.Events[^1].EventId==page.LatestEventId)break;
            transporterCursor=page.Events[^1].EventId;
        }
        var splitShots=transporterEvents.Where(e=>e.Reason is "transporter" or "transporter-fake").ToArray();
        Check(splitShots.Length is >=4 and <=6&&splitShots.Select(e=>MathF.Round(e.X,3)).Distinct().Count()>=2&&
              splitShots.Select(e=>e.Tick).Distinct().Count()>=3,
              "live Transporter publishes its split batch from both recovered muzzles over independent cadences");
        float transporterMaximum=transporterEntity.MaxHealth;
        transporterMatch.ApplyGroundVehicleProjectileImpact(helicopterOwner,transporterEntity.EntityKey,
            transporterRig.BodyParts[0].PartComponentFileId,100/.33f);
        Check(transporterMatch.ArmyHealth(transporterEntity.EntityKey)<transporterMaximum,
              "host damage opens trusted Transporter repair capacity");
        float damagedTransporter=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        for(int i=0;i<31&&!transporterMatch.Terminal;i++)transporterMatch.Advance(++transporterTick);
        float repairedTransporter=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        Check(repairedTransporter>damagedTransporter&&repairedTransporter<=transporterMaximum,
              $"two live repair drones heal synchronized Transporter vitality at one-second source boundaries ({damagedTransporter}->{repairedTransporter}, max {transporterMaximum}, terminal {transporterMatch.Terminal})");
        var droneBeforeDeath=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[0];
        bool repairDroneWasTargetable=transporterMatch.GroundVehicleShotTargets(helicopterOwner).Any(x=>
            x.EntityId==transporterEntity.EntityKey&&x.RepairDronePathIndex==0);
        transporterMatch.ApplyTransporterRepairDroneProjectileImpact(helicopterOwner,
            transporterEntity.EntityKey,0,droneBeforeDeath.MaximumHealth,1);
        Check(repairDroneWasTargetable&&
              transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[0] is
                  {Active:false,Health:0,RespawnTick:var repairRespawn}&&
              repairRespawn>=transporterTick+1050&&repairRespawn<=transporterTick+1350&&
              !transporterMatch.GroundVehicleShotTargets(helicopterOwner).Any(x=>
                  x.EntityId==transporterEntity.EntityKey&&x.RepairDronePathIndex==0)&&
              transporterMatch.Snapshot().Vehicles.Single().RepairDrones[0] is
                  {Active:false,Health:0,RespawnTick:var projectedRepairRespawn}&&
              projectedRepairRespawn==repairRespawn,
              "projectile-selected repair-drone death removes collision and projects its 35-45 second respawn");
        var repairEvents=transporterMatch.EventBatch(helicopterOwner,
            transporterEvents.Count==0?0:transporterEvents[^1].EventId).Events;
        Check(repairEvents.Any(x=>x.Kind==MatchEventKind.VehicleRepairDroneDown&&
                  x.ProjectileId==transporterEntity.EntityKey&&x.Reason=="vehicle-repair-drone-down:0"),
              "repair-drone projectile death emits a replayable source-path lifecycle event");
        ulong repairEventCursor=repairEvents.Count>0?repairEvents[^1].EventId:
            transporterEvents.Count>0?transporterEvents[^1].EventId:0;
        for(int i=0;i<300&&!transporterMatch.Terminal&&
            !transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[0].Crashed;i++)
        {
            transporterMatch.Advance(++transporterTick);
            if(transporterTick%90==0)
            {transporterMatch.ArmyEntityBatch(soldierOwner,0,0);transporterMatch.ArmyEntityBatch(helicopterOwner,0,0);}
        }
        var crashedDrone=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[0];
        var crashEvents=new List<MatchEvent>();
        while(true)
        {
            var page=transporterMatch.EventBatch(helicopterOwner,repairEventCursor);
            crashEvents.AddRange(page.Events);
            if(page.Events.Count==0||page.Events[^1].EventId==page.LatestEventId)break;
            repairEventCursor=page.Events[^1].EventId;
        }
        Check(crashedDrone is {Active:false,Falling:false,Crashed:true}&&
              crashEvents.Any(x=>x.Kind==MatchEventKind.VehicleRepairDroneExploded&&
                  x.ProjectileId==transporterEntity.EntityKey&&
                  x.Reason=="vehicle-repair-drone-exploded:0"),
              "live dead repair drone falls into recovered scene geometry and publishes its terminal crash");
        var destroyedVehicle=parkedVehicles[0];
        Check(staleMatch.ApplyArmyHostDamage(destroyedVehicle.EntityKey,destroyedVehicle.MaxHealth)&&
              staleMatch.VehicleRouteMotion(destroyedVehicle.EntityKey)==null&&
              staleMatch.Snapshot().Vehicles.All(v=>v.EntityId!=destroyedVehicle.EntityKey)&&
              staleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Count==1,
              "confirmed ground-vehicle death removes route, vehicle registry, and army entity authority");
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
