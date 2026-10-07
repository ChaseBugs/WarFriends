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
        var firstAssaultMuzzle = content.AssaultHelicopterWeapons.Muzzle(
            0, Vector3.Zero, Quaternion.Identity);
        var secondAssaultMuzzle = content.AssaultHelicopterWeapons.Muzzle(
            1, Vector3.Zero, Quaternion.Identity);
        Check(firstAssaultMuzzle == new Vector3(.3287352f, -.24099445f, .04579982f) &&
              secondAssaultMuzzle == new Vector3(-.31855813f, -.24099472f, .045799464f),
            "pinned Assault Helicopter prefab binds two distinct source gun muzzles");
        var turnedAssaultMuzzle = content.AssaultHelicopterWeapons.Muzzle(0,
            new Vector3(1, 2, 3), Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI));
        Check(Vector3.Distance(turnedAssaultMuzzle,
                  new Vector3(1 - .3287352f, 2 - .24099445f, 3 - .04579982f)) < .000001f,
            "Assault Helicopter gun muzzle follows the host root rotation");
        Reject(() => content.AssaultHelicopterWeapons.Muzzle(2,
            Vector3.Zero, Quaternion.Identity));
        var assaultBodyBox = content.AssaultHelicopterBoxCollider.Place(
            Vector3.Zero, Quaternion.Identity);
        Check(assaultBodyBox.Kind == PlayerHitboxKind.Box &&
              Vector3.Distance(assaultBodyBox.Center,
                  new Vector3(.0043849445f, .0405483f, .03434353f)) < .00001f &&
              assaultBodyBox.Size == new Vector3(.50202096f, .542398f, .27047324f),
            "pinned Assault Helicopter body box retains its source center and size");
        Reject(() => content.AssaultHelicopterBoxCollider.Place(Vector3.Zero, default));
        var tetrahedron = new TriangleMeshGeometry(
            [Vector3.Zero, Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ],
            [0, 2, 1, 0, 1, 3, 0, 3, 2, 1, 2, 3]);
        var tetrahedronHitbox = new PlayerHitbox("test-convex-mesh", 1,
            Vector3.Zero, Quaternion.Identity, tetrahedron, Vector3.Zero);
        Check(tetrahedronHitbox.Raycast(new Vector3(2, .2f, .2f), -Vector3.UnitX, 3f)
                  is > 1f and < 2f &&
              tetrahedronHitbox.Raycast(new Vector3(.1f, .1f, .1f), Vector3.UnitX, 3f) == null &&
              tetrahedronHitbox.OverlapsSphere(new Vector3(.1f, .1f, .1f), .01f) &&
              tetrahedronHitbox.DistanceToPoint(new Vector3(.1f, .1f, .1f)) == 0,
            "convex mesh queries preserve exterior rays and interior overlap semantics");
        var assaultBodyMeshes = content.AssaultHelicopterMeshColliders.Place(
            Vector3.Zero, Quaternion.Identity);
        Check(content.AssaultHelicopterMeshColliders.Count == 5 &&
              assaultBodyMeshes.Count == 5 &&
              assaultBodyMeshes.Select(mesh => mesh.ColliderFileId).Distinct().Count() == 5 &&
              assaultBodyMeshes.All(mesh => mesh.Hitbox.Kind == PlayerHitboxKind.Mesh &&
                  content.AssaultHelicopterMeshColliders.HasCollider(mesh.ColliderFileId)),
            "independent Unity triangle export binds five distinct Assault Helicopter body parts");
        Check(assaultBodyMeshes.All(mesh =>
                  mesh.Hitbox.Raycast(mesh.Hitbox.Center + Vector3.UnitX * 5,
                      -Vector3.UnitX, 10f).HasValue &&
                  mesh.Hitbox.Raycast(mesh.Hitbox.Center + Vector3.UnitX * 5,
                      Vector3.UnitX, 10f) == null),
            "Assault Helicopter body meshes use their triangles for hit and miss rays");
        var frontGlass = content.AssaultHelicopterMeshColliders.PlaceFrontGlass(
            Vector3.Zero, Quaternion.Identity);
        Check(frontGlass.ColliderFileId == 6468680 &&
              frontGlass.PartComponentFileId == 11485712 &&
              frontGlass.Hitbox.Kind == PlayerHitboxKind.Mesh &&
              frontGlass.Hitbox.OverlapsSphere(frontGlass.Hitbox.Center, .5f),
            "front glass uses its own damage part and assigned Unity mesh triangles");
        using (var glassGeometry = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-air-unit-unity-geometry.json"))))
        {
            var sourceMesh = glassGeometry.RootElement.GetProperty("meshes")
                .GetProperty("799a7c85c474ee0449daf0e57600399c:4300000");
            var vertices = sourceMesh.GetProperty("vertices");
            var triangle = sourceMesh.GetProperty("triangles");
            Vector3 Point(JsonElement point) => new(point[0].GetSingle(),
                point[1].GetSingle(), point[2].GetSingle());
            Vector3 Vertex(int index)
            {
                var point = vertices[triangle[index].GetInt32()];
                return Point(point);
            }
            Vector3 first = Vertex(0), second = Vertex(1), third = Vertex(2);
            Vector3 glassTriangleMidpoint = (first + second + third) / 3f;
            Vector3 glassTriangleNormal = Vector3.Normalize(Vector3.Cross(second - first, third - first));
            var allGlassVertices = vertices.EnumerateArray().Select(Point).ToArray();
            Vector3 glassBoundsCenter = (allGlassVertices.Aggregate(Vector3.Min) +
                allGlassVertices.Aggregate(Vector3.Max)) / 2f;
            Vector3 glassOrigin = frontGlass.Hitbox.Center -
                Vector3.Transform(glassBoundsCenter, frontGlass.Hitbox.Rotation);
            Vector3 worldMidpoint = glassOrigin +
                Vector3.Transform(glassTriangleMidpoint, frontGlass.Hitbox.Rotation);
            Vector3 worldNormal = Vector3.Transform(glassTriangleNormal, frontGlass.Hitbox.Rotation);
            Check(frontGlass.Hitbox.Raycast(worldMidpoint + worldNormal, -worldNormal, 2f)
                      is > .9f and < 1.1f ||
                  frontGlass.Hitbox.Raycast(worldMidpoint - worldNormal, worldNormal, 2f)
                      is > .9f and < 1.1f,
                "a ray aimed at a recovered front glass triangle intersects its live hitbox");
        }
        Reject(() => content.AssaultHelicopterMeshColliders.PlaceFrontGlass(
            Vector3.Zero, default));
        var heliBoxes=content.HelicopterBodyColliders.Place(Vector3.Zero,Quaternion.Identity);
        using(var geometryReference=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-air-unit-unity-geometry.json"))))
        {
            var unityHeli=geometryReference.RootElement.GetProperty("units").EnumerateArray()
                .Single(x=>x.GetProperty("source").GetString()=="Assets/GameObject/Helicopter.prefab");
            var unityBoxes=unityHeli.GetProperty("colliders").EnumerateArray().ToArray();
            Check(content.HelicopterBodyColliders.Count==11&&heliBoxes.Count==11&&
                  unityBoxes.Length==11&&heliBoxes.Select(x=>x.ColliderFileId)
                      .SequenceEqual(unityBoxes.Select(x=>x.GetProperty("componentFileId").GetInt32()))&&
                  heliBoxes.Select(x=>x.PartComponentFileId).Distinct().Count()==11&&
                  heliBoxes.All(x=>x.Layer==8&&x.Hitbox.Kind==PlayerHitboxKind.Box),
                  "combat package binds eleven ordered Helicopter boxes to unique damage parts");
            for(int i=0;i<heliBoxes.Count;i++)
            {
                var reference=unityBoxes[i];var center=reference.GetProperty("center");
                var q=reference.GetProperty("rotation");
                Check(Vector3.Distance(heliBoxes[i].Hitbox.Center,
                          new Vector3(center[0].GetSingle(),center[1].GetSingle(),
                              center[2].GetSingle()))<.0002f&&
                      Math.Abs(Quaternion.Dot(heliBoxes[i].Hitbox.Rotation,
                          new Quaternion(q[0].GetSingle(),q[1].GetSingle(),
                              q[2].GetSingle(),q[3].GetSingle())))>.99999f&&
                      content.HelicopterBodyColliders.HasCollider(heliBoxes[i].ColliderFileId),
                      $"Helicopter body box {i} matches independent Unity rest geometry");
            }
        }
        var rotatedHeliBoxes=content.HelicopterBodyColliders.Place(new(3,2,-4),
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/2));
        Check(rotatedHeliBoxes.Count==11&&
              Vector3.Distance(rotatedHeliBoxes[0].Hitbox.Center,
                  new Vector3(3,2,-4)+Vector3.Transform(heliBoxes[0].Hitbox.Center,
                      Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/2)))<.00001f&&
              !content.HelicopterBodyColliders.HasCollider(1),
              "Helicopter collision follows current host root placement without accepting unknown parts");
        Reject(()=>content.HelicopterBodyColliders.Place(Vector3.Zero,default));
        Check(content.HelicopterCrewPoints.Slots.Count==6&&
              content.HelicopterCrewPoints.Slots.Select(x=>x.ComponentFileId).SequenceEqual(
                  new[]{11438461,11450766,11481434,11454267,11412170,11411857})&&
              content.HelicopterCrewPoints.Slots.All(x=>x.RopeTransformFileId==480871)&&
              content.HelicopterCrewPoints.TurretPointComponentFileId==11499861,
            "combat package binds ordered source Helicopter crew and turret attachment identities");
        Check(content.Army.VehiclePassengerRespawnTicks("ID_UNIT-HELICOPTER")==375,
            "Helicopter gunner respawn delay is the recovered 12.5 second mechanical-unit row");
        var gunnerState=new HelicopterGunnerState(11499861,621f,375,60);
        Check(gunnerState.Snapshot() is {Health:621f,SpawnTick:60,RespawnTick:0,TurretEnabled:true}&&
              gunnerState.Damage(621f,61)&&
              gunnerState.Snapshot() is {Health:0,RespawnTick:436,TurretEnabled:false}&&
              !gunnerState.Damage(1f,62),
              "source gunner death disables its turret and schedules one respawn");
        gunnerState.Advance(435);
        Check(!gunnerState.Snapshot().TurretEnabled,
              "Helicopter turret remains disabled before the source respawn deadline");
        gunnerState.Advance(436);
        Check(gunnerState.Snapshot() is {Health:621f,SpawnTick:436,RespawnTick:0,TurretEnabled:true},
              "Helicopter gunner respawns with full source health at its deadline");
        var sourceCrewPoses=content.HelicopterCrewPoints.PlaceAttached(
            Vector3.Zero,Quaternion.Identity,2);
        Check(sourceCrewPoses.Count==2&&
              sourceCrewPoses.All(p=>Vector3.Distance(p.Position,
                  content.HelicopterCrewPoints.Slots[p.Slot].RestPosition)<.000001f&&
                  Vector3.Distance(p.RopePosition,
                  content.HelicopterCrewPoints.Slots[p.Slot].RopeRestPosition)<.000001f),
              "identity root placement reproduces both ordered prefab crew and rope rest points");
        var turretRest=content.HelicopterCrewPoints.PlaceTurret(
            Vector3.Zero,Quaternion.Identity);
        Check(turretRest.PointComponentFileId==11499861&&
              Vector3.Distance(turretRest.GunnerPosition,
                  content.HelicopterCrewPoints.TurretPointRestPosition)<.000001f&&
              Vector3.Distance(turretRest.SightRestPosition,
                  new Vector3(-.3553753f,.003f,-.025f))<.000001f&&
              Vector3.Distance(turretRest.MuzzleRestPosition,
                  content.HelicopterCrewPoints.TurretMuzzleRestPosition)<.000001f,
              "source turret point, sight eye and gun muzzle preserve prefab rest geometry");
        var selectionRay=HelicopterTurretSightRay.ForSelection(turretRest.SightRestPosition,
            turretRest.SightRestPosition+Vector3.UnitZ*10);
        var aimedRay=HelicopterTurretSightRay.ForAimedShot(turretRest.SightRestPosition,
            turretRest.SightRestPosition+Vector3.UnitZ*10);
        Check(Math.Abs(selectionRay.Range-9.45f)<.00001f&&
              Math.Abs(aimedRay.Range-9.25f)<.00001f&&
              Vector3.Distance(selectionRay.Origin,
                  turretRest.SightRestPosition+Vector3.UnitZ*.05f)<.000001f&&
              Vector3.Distance(aimedRay.Origin,
                  turretRest.SightRestPosition+Vector3.UnitZ*.25f)<.000001f&&
              selectionRay.LayerMask==aimedRay.LayerMask&&
              selectionRay.LayerMask==((1u<<8)|(1u<<13)|(1u<<22)|(1u<<23)|
                  (1u<<24)|(1u<<26)|(1u<<27)|(1u<<30)),
              "Helicopter sight rays retain source selection and post-aim offsets and layer mask");
        Reject(()=>HelicopterTurretSightRay.ForSelection(Vector3.Zero,
            new Vector3(float.NaN,0,0)));
        Reject(()=>content.HelicopterCrewPoints.PlaceTurret(Vector3.Zero,default));
        var coneOrigin=new Vector3(-.373f,-.209f,0);
        Check(HelicopterTurretTargetCone.Contains(Vector3.Zero,Quaternion.Identity,
                  coneOrigin+new Vector3(-10,5,0))&&
              !HelicopterTurretTargetCone.Contains(Vector3.Zero,Quaternion.Identity,
                  coneOrigin+new Vector3(10,5,0))&&
              HelicopterTurretTargetCone.Contains(Vector3.Zero,
                  Quaternion.CreateFromAxisAngle(Vector3.UnitZ,MathF.PI/2),
                  Vector3.Transform(coneOrigin,Quaternion.CreateFromAxisAngle(Vector3.UnitZ,MathF.PI/2))-
                  Vector3.UnitY*10),
              "source Helicopter turret cone retains full 3D direction under root bank");
        Reject(()=>HelicopterTurretTargetCone.Contains(Vector3.Zero,default,Vector3.UnitX));
        using(var aimReference=JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory,"recovered-helicopter-turret-aim.json"))))
        {
            var oracle=aimReference.RootElement;
            Check(oracle.GetProperty("version").GetInt32()==1&&
                  oracle.GetProperty("client").GetString()=="1.4.0"&&
                  oracle.GetProperty("source").GetString()=="Assets/GameObject/Helicopter.prefab"&&
                  oracle.GetProperty("prefabSha256").GetString()==
                    "e91c07c1552988601ada89c769056354ebd5d94ea88356eeacc5fa3f3fb76408"&&
                  oracle.GetProperty("rows").GetArrayLength()==5,
                  "Unity turret-aim oracle retains source prefab identity and all five cases");
            static Vector3 ArrayVector(JsonElement a)=>new(a[0].GetSingle(),a[1].GetSingle(),a[2].GetSingle());
            static Quaternion ArrayRotation(JsonElement a)=>new(a[0].GetSingle(),a[1].GetSingle(),
                a[2].GetSingle(),a[3].GetSingle());
            foreach(var row in oracle.GetProperty("rows").EnumerateArray())
            {
                var aimRoot=ArrayVector(row.GetProperty("rootPosition"));
                var aimRootRotation=ArrayRotation(row.GetProperty("rootRotation"));
                var aimTarget=ArrayVector(row.GetProperty("target"));
                var aimPose=HelicopterTurretAim.FromRest(aimRoot,aimRootRotation,aimTarget);
                float horizontalDot=Math.Abs(Quaternion.Dot(aimPose.HorizontalLocalRotation,
                    ArrayRotation(row.GetProperty("horizontalLocalRotation"))));
                float verticalDot=Math.Abs(Quaternion.Dot(aimPose.VerticalWorldRotation,
                    ArrayRotation(row.GetProperty("verticalWorldRotation"))));
                Check(aimPose.Immediate==row.GetProperty("immediate").GetBoolean()&&
                      aimPose.Clipped==row.GetProperty("clipped").GetBoolean()&&
                      Math.Abs(aimPose.AimSeconds-row.GetProperty("aimSeconds").GetSingle())<.0001f&&
                      horizontalDot>.99999f&&verticalDot>.99999f&&
                      Vector3.Distance(aimPose.SightPosition,
                          ArrayVector(row.GetProperty("sightPosition")))<.0001f&&
                      Vector3.Distance(aimPose.MuzzlePosition,
                          ArrayVector(row.GetProperty("muzzlePosition")))<.0001f,
                      $"Helicopter turret aim final transform matches Unity oracle row {row.GetProperty("id").GetInt32()}");
                var tween=new HelicopterTurretTweenState();
                int turnTicks=tween.Plan(aimRoot,aimRootRotation,aimTarget);
                Check(Math.Abs(aimPose.VerticalSeconds-row.GetProperty("verticalSeconds").GetSingle())<.0001f&&
                      turnTicks==(aimPose.Immediate?0:(int)MathF.Ceiling(aimPose.AimSeconds*30))&&
                      tween.Ready==aimPose.Immediate,
                      $"Helicopter turret aim retains source horizontal/vertical durations in row {row.GetProperty("id").GetInt32()}");
                foreach(var sample in row.GetProperty("samples").EnumerateArray())
                {
                    int sampleTick=sample.GetProperty("tick").GetInt32();
                    if(sampleTick>0)tween.AdvanceTick(aimRoot,aimRootRotation);
                    var sampled=tween.Current(aimRoot,aimRootRotation);
                    Check(Math.Abs(Quaternion.Dot(sampled.HorizontalLocalRotation,
                              ArrayRotation(sample.GetProperty("horizontalLocalRotation"))))>.99999f&&
                          Math.Abs(Quaternion.Dot(sampled.VerticalWorldRotation,
                              ArrayRotation(sample.GetProperty("verticalWorldRotation"))))>.99999f&&
                          Vector3.Distance(sampled.SightPosition,
                              ArrayVector(sample.GetProperty("sightPosition")))<.0002f&&
                          Vector3.Distance(sampled.MuzzlePosition,
                              ArrayVector(sample.GetProperty("muzzlePosition")))<.0002f,
                          $"Helicopter turret TweenRotation.Sample matches Unity row {row.GetProperty("id").GetInt32()} tick {sampleTick}");
                }
                Check(tween.Ready==!aimPose.Clipped&&
                      Vector3.Distance(tween.Current(aimRoot,aimRootRotation).MuzzlePosition,
                          aimPose.MuzzlePosition)<.0002f,
                      $"Helicopter turret completed aim preserves source clipped-shot gate in row {row.GetProperty("id").GetInt32()}");
            }
        }
        Reject(()=>HelicopterTurretAim.FromRest(Vector3.Zero,default,-Vector3.UnitX));
        Reject(()=>HelicopterTurretAim.FromRest(Vector3.Zero,Quaternion.Identity,
            new Vector3(-.373f,-.209f,0)));
        var turretCandidates=new DroneTargetCandidate[]
        {
            new("defender",2,true,true,false,0,Vector3.UnitX),
            new("shooter",2,true,true,false,2,Vector3.UnitY),
            new("rusher",2,true,true,false,3,Vector3.UnitZ),
            new("decoy",2,true,true,true,null,-Vector3.UnitX),
            new("player",2,true,true,false,null,-Vector3.UnitZ)
        };
        DroneTargetCandidate? SelectTurret(Func<DroneTargetCandidate,bool> eligible,
            Func<int,int>? choose=null)=>HelicopterTurretTargetPolicy.Select(1,turretCandidates,
                eligible,choose??(_=>0));
        Check(SelectTurret(_=>false)?.Id=="decoy"&&
              HelicopterTurretTargetPolicy.Select(1,turretCandidates[..3],
                  _=>true,_=>0)?.Id=="rusher"&&
              HelicopterTurretTargetPolicy.Select(1,turretCandidates[..2],
                  _=>true,n=>n-1)?.Id=="shooter"&&
              HelicopterTurretTargetPolicy.Select(1,[turretCandidates[4]],
                  _=>true,_=>0)?.Id=="player",
              "Helicopter turret retains source decoy, primary, secondary, fallback and random-list order");
        Reject(()=>HelicopterTurretTargetPolicy.Select(1,turretCandidates[..3],
            _=>true,n=>n));
        var helicopterShotTargets=new DroneTargetDetails([
            new(1,1,new(0,1,1)),new(2,2,new(0,.2f,1)),
            new(3,16,new(0,1.4f,1))],true,Vector3.Zero,Vector3.UnitZ,true,Vector3.Zero);
        Check(HelicopterTurretShotTargetPolicy.Select(Vector3.UnitZ*2,
                  helicopterShotTargets,0,()=>0)?.Type==1&&
              HelicopterTurretShotTargetPolicy.Select(Vector3.UnitZ*2,
                  helicopterShotTargets with {Hiding=false},0,()=>0)?.Type==16,
              "Helicopter source target rule selects whole body behind shield and moving pose while walking");
        var turretAcquisition=new HelicopterTurretAcquisitionState(61,
            new ArmyVehicleShotStats(12,.75f,4,5,1,5,2),()=>0);
        Check(turretAcquisition.NextPickTick==91&&!turretAcquisition.Due(91)&&
              turretAcquisition.Due(92),
              "Helicopter source minimum cooldown and strict Update time gate use host ticks");
        turretAcquisition.Acquired(92,"player:test");
        Check(turretAcquisition.TargetId=="player:test"&&
              turretAcquisition.NextPickTick==392,
              "target acquisition retains the source twice-maximum guard until shooting is connected");
        turretAcquisition.Disable();turretAcquisition.Reset(400);
        Check(turretAcquisition.TargetId==null&&turretAcquisition.NextPickTick==430,
              "gunner respawn resets target and samples a fresh shoot-time delay");
        var translatedCrew=content.HelicopterCrewPoints.PlaceAttached(new(10,5,20),Quaternion.Identity,2);
        Check(Vector3.Distance(translatedCrew[0].Position,
                  new Vector3(10.21307182f,4.8822651f,19.82723331f))<.00001f,
              "source child offsets are applied once without the prefab-stage root translation");
        Reject(()=>content.HelicopterCrewPoints.PlaceAttached(Vector3.Zero,default,2));
        Reject(()=>HelicopterCrewPointCatalog.Load(Path.Combine(directory,"recovered-helicopter-crew-points.json"),new string('0',64)));
        Check(content.DroneWeapon.Revision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-weapon.json")))),"combat package binds verified Drone weapon authority");
        Check(content.DroneProjectile.Revision==Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-projectile-setup.json")))),"combat package requires verified Drone projectile setup revision");
        count+=DroneSpecialTests.Run(content.Army);
        count+=DroneSteeringTests.Run();
        count+=DroneFreeFallTests.Run(directory);
        count+=DroneImpulseTests.Run(directory,content.DroneColliders);
        count+=DroneFrictionControlTests.Run(directory,content.DroneColliders);
        count+=DroneSourceFrictionTests.Run(directory,content.DroneColliders);
        count+=DronePersistentContactTests.Run(directory,content.DroneColliders);
        count+=ContactFrictionTests.Run();
        count+=DroneGroundProbeTests.Run(directory,content);
        count+=DroneDeathContactTests.Run(directory,content);
        count+=DroneWaypointTests.Run();
        count+=DroneOrientationTests.Run(directory);
        count+=DroneTargetTests.Run();
        count+=DroneTargetRegistryTests.Run();
        count+=DroneAttackClockTests.Run();
        count+=DroneBatchTests.Run();
        count+=DroneAttackStateTests.Run(content);
        var airAim=AirShotTargetCatalog.Load(Path.Combine(directory,"recovered-air-unit-geometry.json"));
        Check(airAim.PlaceRest("ID_UNIT-HELICOPTER",Vector3.Zero,Quaternion.Identity).Single() is
            {TransformFileId:414249,Type:0},"Helicopter source aim preserves None type included by source mask");
        Check(airAim.PlaceRest("ID_UNIT-ASSAULTHELI",Vector3.Zero,Quaternion.Identity).Single() is
            {TransformFileId:479075,Type:1},"Assault Helicopter aim preserves body target identity");
        Check(airAim.PlaceRest("ID_UNIT-DRONE",Vector3.One,Quaternion.Identity).Single().Position==Vector3.One,
            "Drone root aim transforms under source rest binding");
        Reject(()=>airAim.PlaceRest("ID_UNIT-HELICOPTER",Vector3.Zero,default));
        var aimReferencePath=Path.Combine(directory,"recovered-enemy-poses.json");
        var enemyPoses=EnemyPoseCatalog.Load(aimReferencePath,Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(aimReferencePath))));
        var enemyAim=EnemyShotTargetCatalog.Load(Path.Combine(directory,"recovered-enemy-target-poses.json"),enemyPoses);
        foreach(string clipName in enemyPoses.Names)
        {
            var targets=enemyAim.Place(clipName,Vector3.Zero,Quaternion.Identity,0);
            Check(targets.Count==3&&targets[0].TransformFileId==454546&&targets[1].Type==1&&targets[2].Type==4,
                "animated infantry aim preserves source target order");
            var rotated=enemyAim.Place(clipName,Vector3.One,Quaternion.CreateFromAxisAngle(Vector3.UnitY,1),0);
            Check(Vector3.Distance(rotated[0].Position,Vector3.One+Vector3.Transform(targets[0].Position,
                Quaternion.CreateFromAxisAngle(Vector3.UnitY,1)))<.00001f,"animated aim places target in army root pose");
        }
        Reject(()=>enemyAim.Place("T_pose",Vector3.Zero,Quaternion.Identity,float.NaN));
        count+=DroneWeaponStateTests.Run(content.DroneWeapon);
        count+=DroneShotTargetTests.Run();
        count+=DroneWeaponCatalogTests.Run(directory);
        count+=AirWaypointCatalogTests.Run(directory,content);
        count+=HelicopterWaypointTests.Run(directory,content);
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
        var headTarget=content.PlayerShotTargets.Gameplay.Single(t=>t.Type==8);
        Check(Vector3.Distance(content.Poses.SampleBlended("run",.25,true,"run",.25,true,0)
                .BodyTarget(headTarget.TransformFileId).Position,referencePose.BodyTarget(headTarget.TransformFileId).Position)>.001f,
            "Head shot target follows the recovered animated hierarchy");
        using(var headOracle=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-player-poses.json"))))
        foreach(var clip in headOracle.RootElement.GetProperty("clips").EnumerateArray())
        foreach(var frame in clip.GetProperty("frames").EnumerateArray())
        {
            string clipName=clip.GetProperty("name").GetString()!;double seconds=frame.GetProperty("seconds").GetDouble();
            var expected=frame.GetProperty("headTarget");
            // Unity exports float seconds; sample just inside that frame so
            // a rounded-down 17/30 does not select host frame 16.
            var actual=content.Poses.SampleBlended(clipName,seconds+.000001,false,clipName,seconds+.000001,false,0).BodyTarget(headTarget.TransformFileId).Position;
            Check(Vector3.Distance(actual,new(expected[0].GetSingle(),expected[1].GetSingle(),expected[2].GetSingle()))<.0002f,
                "posed Head target matches independent Unity world sample: "+clipName+"/"+seconds);
        }
        Check(MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,Vector3.UnitZ,0,()=>0)==9&&
            MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,Vector3.UnitZ,.5f,()=>.25f)==2&&
            MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,Vector3.UnitZ,.5f,()=>.5f)==9&&
            MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,-Vector3.UnitZ,0,()=>throw new Exception("side branch drew random"))==2,
            "Heavy Turret whole-body and Shield branches preserve facing, strict probability and random short-circuit rules");
        Check(MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,
                  Vector3.Transform(Vector3.UnitZ,Quaternion.CreateFromAxisAngle(Vector3.UnitY,49*MathF.PI/180)),0,()=>0)==9&&
              MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,
                  Vector3.Transform(Vector3.UnitZ,Quaternion.CreateFromAxisAngle(Vector3.UnitY,51*MathF.PI/180)),0,()=>0)==2,
              "Heavy Turret facing gate separates inside and outside the recovered 50-degree cone");
        Reject(()=>MatchEngine.HeavyTurretStationaryTargetMask(Vector3.Zero,Vector3.UnitZ,0,()=>0));
        Reject(()=>MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,Vector3.UnitZ,float.NaN,()=>0));
        Reject(()=>MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ,Vector3.UnitZ,0,()=>float.NaN));
        var shieldTarget=content.PlayerShotTargets.Gameplay.Single(t=>t.Type==2);
        Check(Vector3.Distance(referencePose.BodyTarget(shieldTarget.TransformFileId).Position,
                  shieldTarget.ReferencePosition)<.0002f&&
              Vector3.Distance(referencePose.Place(new(3,4,5),Quaternion.Identity)
                  .BodyTarget(shieldTarget.TransformFileId).Position,shieldTarget.ReferencePosition)>1,
              "source Shield target preserves its direct-child position and follows host placement");
        Check(content.PlayerShotTargets.Gameplay.Where(t=>t.Type==16).All(t=>
                  referencePose.BodyTarget(t.TransformFileId).Position==referencePose.MovingTarget!.Position),
              "typed Moving shot target agrees with the existing animated moving target");
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
        var droneComposedShot=content.Army.ComposeDroneShot(0,null,null);
        Check(droneComposedShot is {ShotSpeed:9,ProbabilityOfRealShot:.7f,FireBatchSizeMin:2,FireBatchSizeMax:3,MinShootTime:2.5f,MaxShootTime:3.5f},
            "Drone LoadData binds ArmyUpgrades speed and additive normal batch/timing rows");
        Check(content.Army.ComposeDroneShot(0,96,null,2).ShotSpeed==18&&content.Army.ComposeDroneShot(0,96,null,2).ProbabilityOfRealShot==.7f,
            "Drone special lane and shot-speed perk retain vehicle probability without soldier accuracy scaling");
        Reject(()=>content.Army.ComposeDroneShot(0,null,null,float.NaN));
        try{content.Army.ComposeDroneShot(0,0,null);throw new Exception("invalid Drone special lane accepted");}
        catch(ArgumentOutOfRangeException){count++;}
        try{content.Army.ComposeDroneShot(0,null,117);throw new Exception("closed Drone elite lane accepted");}
        catch(ArgumentOutOfRangeException){count++;}
        Check(content.Army.ComposeHelicopterCrew(0,null,null)==new ArmyHelicopterCrewStats(2,621f)&&
              content.Army.ComposeHelicopterCrew(70,82,null)==new ArmyHelicopterCrewStats(6,1531f),
              "Helicopter seats add selected normal/special lanes while crew health reads only normal row");
        Check(content.Army.EffectiveHelicopterCrew(0,null,null,new(2f,1.25f))==
                  new ArmyHelicopterCrewStats(2,776.25f),
              "Helicopter soldier health uses upgrade scale without vehicle health perk coefficient");
        Reject(()=>content.Army.EffectiveHelicopterCrew(0,null,null,new(1f,float.NaN)));
        try{content.Army.ComposeHelicopterCrew(0,0,null);throw new Exception("invalid Helicopter special lane accepted");}
        catch(ArgumentOutOfRangeException){count++;}
        var humveeShot=content.Army.ComposeVehicleShot("ID_UNIT-HUMVEE",0,null,null);
        var helicopterShot=content.Army.ComposeHelicopterShot(0,null,null);
        var assaultHelicopterShot=content.Army.ComposeAssaultHelicopterShot(0,null,null);
        Check(content.Army.EffectiveAssaultHelicopterGlassHealth(0,null,null,new(1f,1f))==72.33f,
              "Assault Helicopter glass uses its attached sheet and separate source health");
        Check(content.Army.EffectiveAssaultHelicopterGlassHealth(0,null,null,new(1f,2f))==144.66f,
              "Assault Helicopter glass scales by upgrade scale, independently of body health");
        Reject(()=>content.Army.EffectiveAssaultHelicopterGlassHealth(0,null,null,new(1f,float.NaN)));
        Check(helicopterShot==new ArmyVehicleShotStats(12f,.75f,4,5,2f,4f,0),
              "Helicopter turret binds selected source shot stages apart from attached crew count");
        Check(assaultHelicopterShot.MinShootTime>0&&
              assaultHelicopterShot.MaxShootTime>=assaultHelicopterShot.MinShootTime&&
              assaultHelicopterShot.FireBatchSizeMax>0 &&
              assaultHelicopterShot.ShieldHitProbability == .3f,
              "Assault Helicopter firing cadence and shield policy come from source upgrade rows");
        var assaultPlayerTargets = new DroneTargetDetails(
            [new(11, 1, new Vector3(0, 0, 2)),
             new(12, 1, new Vector3(1, 0, 2)),
             new(13, 2, new Vector3(0, 1, 1)),
             new(14, 16, new Vector3(0, 0, 1)),
             new(15, 8, new Vector3(0, 2, 2))],
            true, Vector3.Zero, Vector3.UnitZ, true, Vector3.Zero);
        var assaultBodyPair = AssaultHelicopterShotTargetPolicy.Select(
            new Vector3(0, 0, 3), assaultPlayerTargets, false,
            assaultHelicopterShot.ShieldHitProbability, () => .5f);
        Check(assaultBodyPair.First.TransformFileId == 12 &&
              assaultBodyPair.Second.TransformFileId == 11 && !assaultBodyPair.Shield,
            "shield miss gives Assault Helicopter guns the second and first ordered body targets");
        var assaultShieldPair = AssaultHelicopterShotTargetPolicy.Select(
            new Vector3(0, 0, 3), assaultPlayerTargets, false, .6f, () => .2f);
        Check(assaultShieldPair.First.TransformFileId == 13 &&
              assaultShieldPair.Second.TransformFileId == 13 && assaultShieldPair.Shield,
            "shield hit gives both Assault Helicopter guns the same shield target");
        var assaultWalkingTarget = AssaultHelicopterShotTargetPolicy.Select(
            new Vector3(0, 0, 3), assaultPlayerTargets with { Hiding = false },
            true, 0, () => throw new Exception("walking aim consumed a shield draw"));
        Check(assaultWalkingTarget.First.TransformFileId == 14 &&
              assaultWalkingTarget.Second.TransformFileId == 14,
            "walking player aim chooses the recovered Moving target for both guns");
        var assaultBehindPlayer = AssaultHelicopterShotTargetPolicy.Select(
            new Vector3(0, 0, -3), assaultPlayerTargets, false, .6f,
            () => throw new Exception("rear aim consumed a shield draw"));
        Check(assaultBehindPlayer.First.TransformFileId == 11 &&
              assaultBehindPlayer.Second.TransformFileId == 11,
            "Assault Helicopter rear aim selects the nearest whole-body target");
        var assaultDecoyAim = AssaultHelicopterShotTargetPolicy.Select(
            Vector3.Zero, assaultPlayerTargets with
            {
                IsPlayer = false,
                Targets = [new(21, 1, new Vector3(2, 0, 0))]
            }, false, 0, () => throw new Exception("Decoy aim consumed a shield draw"));
        Check(assaultDecoyAim.First.TransformFileId == 21 &&
              assaultDecoyAim.Second.TransformFileId == 21,
            "Assault Helicopter uses the same nearest AllIn Decoy target for both guns");
        Vector3 predictedAssaultFirst = AssaultHelicopterAimPolicy.First(
            Vector3.Zero, new Vector3(10, 0, 0), new Vector3(2, 0, 0), 10);
        Vector3 predictedAssaultSecond = AssaultHelicopterAimPolicy.Second(
            Vector3.Zero, new Vector3(11, 0, 0), new Vector3(2, 0, 0),
            10, false);
        Vector3 unpredictedAssaultShield = AssaultHelicopterAimPolicy.Second(
            Vector3.Zero, new Vector3(11, 0, 0), new Vector3(2, 0, 0),
            10, true);
        Check(Vector3.Distance(predictedAssaultFirst, new Vector3(12.2f, 0, 0)) < .00001f &&
              Vector3.Distance(predictedAssaultSecond, new Vector3(13.4f, 0, 0)) < .00001f &&
              unpredictedAssaultShield == new Vector3(11, 0, 0),
            "delayed Assault Helicopter aim refreshes its target and skips prediction for shield");
        var assaultVolley = AssaultHelicopterVolleyPlanner.Plan(
            new ArmyVehicleShotStats(5, .75f, 4, 7, 2, 4, 0),
            span => span - 1);
        Check(assaultVolley == new AssaultHelicopterVolleyPlanner.Volley(3, 3, .13f),
            "Assault Helicopter excludes the batch upper bound and divides six shots equally");
        var oddAssaultVolley = AssaultHelicopterVolleyPlanner.Plan(
            new ArmyVehicleShotStats(5, .75f, 5, 5, 2, 4, 0),
            _ => throw new Exception("fixed batch consumed a random index"));
        Check(oddAssaultVolley == new AssaultHelicopterVolleyPlanner.Volley(2, 3, .13f),
            "Assault Helicopter gives the second gun the extra shot in an odd fixed batch");
        var realShotSamples = new Queue<float>([.2f, .75f, .8f]);
        Check(AssaultHelicopterVolleyPlanner.SampleRealShots(3, .75f,
                  () => realShotSamples.Dequeue()).SequenceEqual([true, false, false]) &&
              realShotSamples.Count == 0,
            "each Assault Helicopter round receives its own strict real-shot probability sample");
        var overlappingVolleys = new AssaultHelicopterVolleyState();
        var fixedAssaultShot = new ArmyVehicleShotStats(5, .75f, 4, 4, 2, 4, 0);
        int sampledAssaultRounds = 0;
        float NextAssaultRound() { sampledAssaultRounds++; return .5f; }
        overlappingVolleys.PrepareFirstGun(2f, 60, fixedAssaultShot,
            "player:one", assaultBodyPair, Vector3.Zero,
            assaultBodyPair.First.Position,
            _ => 0, NextAssaultRound);
        overlappingVolleys.PrepareFirstGun(2.05f, 62, fixedAssaultShot,
            "player:one", assaultBodyPair, Vector3.Zero,
            assaultBodyPair.First.Position,
            _ => 0, NextAssaultRound);
        overlappingVolleys.PrepareDueSecondGuns(2.12f, fixedAssaultShot,
            NextAssaultRound, _ => (assaultBodyPair.Second.Position, firstAssaultMuzzle));
        Check(overlappingVolleys.Latest?.SecondGunRealShots == null &&
              sampledAssaultRounds == 4,
            "Assault Helicopter does not sample the delayed gun before its callback deadline");
        overlappingVolleys.PrepareDueSecondGuns(2.13f, fixedAssaultShot,
            NextAssaultRound, _ => (assaultBodyPair.Second.Position, firstAssaultMuzzle));
        overlappingVolleys.PrepareDueSecondGuns(2.18f, fixedAssaultShot,
            NextAssaultRound, _ => (assaultBodyPair.Second.Position, firstAssaultMuzzle));
        Check(overlappingVolleys.Latest?.SelectionTick == 62 &&
              overlappingVolleys.Latest.SecondGunRealShots?.SequenceEqual([true, true]) == true &&
              sampledAssaultRounds == 8,
            "overlapping Assault Helicopter callbacks preserve both second-gun masks in order");
        var firstGunRound = overlappingVolleys.DueRoundIntents(2.18f,
            Vector3.Zero, Quaternion.Identity, content.AssaultHelicopterWeapons,
            NextAssaultRound);
        var noEarlyRound = overlappingVolleys.DueRoundIntents(2.44f,
            Vector3.Zero, Quaternion.Identity, content.AssaultHelicopterWeapons,
            NextAssaultRound);
        var nextGunRounds = overlappingVolleys.DueRoundIntents(2.45f,
            Vector3.Zero, Quaternion.Identity, content.AssaultHelicopterWeapons,
            NextAssaultRound);
        Check(firstGunRound.Count == 2 &&
              firstGunRound.Select(round => round.GunIndex).SequenceEqual([0, 1]) &&
              firstGunRound.All(round => round.IsReal) &&
              firstGunRound[0].Muzzle == firstAssaultMuzzle &&
              firstGunRound[1].Muzzle == secondAssaultMuzzle &&
              firstGunRound[0].Target == assaultBodyPair.First.Position &&
              firstGunRound[1].Target == assaultBodyPair.Second.Position &&
              noEarlyRound.Count == 0 && nextGunRounds.Count == 2 &&
              nextGunRounds.All(round => round.RoundIndex == 1),
            "two Assault Helicopter guns keep independent strict cadence and pinned muzzle positions");
        var fakeAssaultVolley = new AssaultHelicopterVolleyState();
        fakeAssaultVolley.PrepareFirstGun(2f, 60,
            fixedAssaultShot with { ProbabilityOfRealShot = 0 },
            "player:one", assaultBodyPair, Vector3.Zero,
            new Vector3(0, 0, 10), _ => 0, () => 0f);
        var fakeAssaultRound = fakeAssaultVolley.DueRoundIntents(2f,
            Vector3.Zero, Quaternion.Identity, content.AssaultHelicopterWeapons,
            () => 0f).Single();
        Check(!fakeAssaultRound.IsReal &&
              Math.Abs(fakeAssaultRound.Target.Y - .3f) < .00001f &&
              Math.Abs(Vector2.Distance(
                  new Vector2(fakeAssaultRound.Target.X, fakeAssaultRound.Target.Z),
                  new Vector2(0, 10)) - .3f) < .00001f,
            "fake Assault Helicopter rounds receive the source lateral and upward miss offset");
        Reject(() => AssaultHelicopterVolleyPlanner.Plan(
            new ArmyVehicleShotStats(5, .75f, 4, 7, 2, 4, 0), _ => 3));
        Reject(()=>content.Army.ComposeHelicopterShot(0,null,null,float.NaN));
        Reject(()=>content.Army.ComposeAssaultHelicopterShot(0,null,null,float.NaN));
        var tankShot=content.Army.ComposeVehicleShot("ID_UNIT-TANK",0,null,null);
        var buggyShot=content.Army.ComposeVehicleShot("ID_UNIT-BUGGY",0,null,null);
        var transporterShot=content.Army.ComposeVehicleShot("ID_UNIT-TRANSPORTER",0,null,null);
        var buggyCannon=content.Army.ComposeBuggyCannon(0,null,null);
        var tankCannon=content.Army.ComposeVehicleCannon("ID_UNIT-TANK",0,null,null,1,1);
        var specialTankCannon=content.Army.ComposeVehicleCannon("ID_UNIT-TANK",0,51,null,2,.7f);
        var transporterRepair=content.Army.ComposeTransporterRepairDrone(0,71,null,new(1,1));
        Check(humveeShot==new ArmyVehicleShotStats(14f,.85f,4,5,1.5f,1.8f,0)&&
              tankShot==new ArmyVehicleShotStats(16f,.8f,2,5,2f,5f,0)&&
              buggyShot==new ArmyVehicleShotStats(6f,1f,0,0,0,0,0)&&
              transporterShot==new ArmyVehicleShotStats(11f,.9f,4,7,3.5f,4.5f,0)&&
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
                  .ProbabilityOfRealShot==.85f&&
              Math.Abs(transporterRepair.HealRatioPerSecond-.08f)<.00001f&&
              Math.Abs(transporterRepair.MaximumHealth-70.3755f)<.001f,
              "ground vehicle turrets compose primary, Buggy cannon, and Tank cannon stage-zero source authority");
        bool rejectedNormalRepairLane=false;
        try{_=content.Army.ComposeTransporterRepairDrone(0,0,null,new(1,1));}
        catch(ArgumentOutOfRangeException){rejectedNormalRepairLane=true;}
        Check(rejectedNormalRepairLane,"Transporter repair drones require a selected special lane");
        Reject(()=>content.Army.ComposeVehicleShot("ID_UNIT-ASSAULT",0,null,null));
        Check(content.Army.ComposeVehicleShot("ID_UNIT-HUMVEE",0,null,null,2,2).ShotSpeed==28&&
            content.Army.ComposeVehicleShot("ID_UNIT-HUMVEE",0,null,null,2,2).ProbabilityOfRealShot==.85f,
            "vehicle shot-speed perk changes runtime speed without soldier accuracy scaling");
        Reject(()=>content.Army.ComposeVehicleShot("ID_UNIT-TANK",0,null,null,1,float.NaN));
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
                   HealIntervalSeconds:1f,RespawnMinimumSeconds:35f,RespawnMaximumSeconds:45f,
                   DamageComponentFileId:11470521,FlameCoefficient:1f}&&
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
        var repairShotOrigin=repairTarget.Hitbox.Center-Vector3.UnitZ*2;
        var repairOverlap=repairWorld.OverlapEnemy("cccccccccccccccccccccccccccccccc",
            repairShotOrigin,4,1u<<repairTarget.Layer);
        Check(repairOverlap.Any(x=>x.MainEntityId=="repair-drone:78:0")&&
              !repairWorld.OverlapEnemy("cccccccccccccccccccccccccccccccc",
                  repairShotOrigin,4,0).Any(x=>x.MainEntityId=="repair-drone:78:0"),
              "source mini-drone root enters shotgun overlap only through its live faction layer");
        var repairPlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            repairShotOrigin,repairTarget.Hitbox.Center+Vector3.UnitX*.5f,repairOverlap);
        Check(repairPlan.RealPellets.Any(x=>repairOverlap.Any(y=>
                  y.MainEntityId=="repair-drone:78:0"&&y.EntityId==x.EntityId)),
              "source shotgun cone schedules a real pellet toward the active mini-drone root");
        var placedHumvee=content.GroundVehicleWeapons.PlaceBody("ID_UNIT-HUMVEE",77,
            Vector3.Zero,Vector3.UnitZ,1);
        Check(content.GroundVehicleWeapons.For("ID_UNIT-TANK").BodyParts.All(p=>p.Layer==0)&&
              content.GroundVehicleWeapons.For("ID_UNIT-HUMVEE").BodyParts.All(p=>p.Layer==8)&&
              content.GroundVehicleWeapons.PlaceBody("ID_UNIT-TANK",79,Vector3.Zero,Vector3.UnitZ,1)
                  .All(p=>p.Layer==23)&&
              content.GroundVehicleWeapons.PlaceBody("ID_UNIT-TANK",80,Vector3.Zero,Vector3.UnitZ,2)
                  .All(p=>p.Layer==22)&&
              new[]{"ID_UNIT-HUMVEE","ID_UNIT-BUGGY","ID_UNIT-TRANSPORTER"}.All(unit=>
                  content.GroundVehicleWeapons.PlaceBody(unit,81,Vector3.Zero,Vector3.UnitZ,1)
                      .All(p=>p.Layer==27)&&
                  content.GroundVehicleWeapons.PlaceBody(unit,82,Vector3.Zero,Vector3.UnitZ,2)
                      .All(p=>p.Layer==26)),
            "ground vehicle body collisions use faction runtime layers after source ChangeLayer, not prefab layers");
        Reject(()=>content.GroundVehicleWeapons.PlaceBody("ID_UNIT-TANK",80,
            Vector3.Zero,Vector3.UnitZ,0));
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
              sourcePart==bodyTarget.PartComponentFileId&&bodyHit.SourcePath==bodyTarget.Hitbox.SourcePath&&
              bodyHit.ColliderLayer==27&&bodyHit.SourceDestroyable,
              "player projectile ray selects the nearest source-pinned vehicle body collider");
        var tankTargets=content.GroundVehicleWeapons.PlaceBody("ID_UNIT-TANK",79,
            Vector3.Zero,Vector3.UnitZ,1);
        var tankPart=tankTargets.First(x=>x.Hitbox.Kind==PlayerHitboxKind.Box);
        var tankRayOrigin=tankPart.Hitbox.Center+Vector3.Transform(Vector3.UnitX,
            tankPart.Hitbox.Rotation)*10;
        var tankWorld=new ShotCollisionWorld(null,
        [
            new(bodyShooter,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new(bodyOpponent,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>tankTargets);
        var tankHit=tankWorld.Raycast(bodyShooter,tankRayOrigin,
            tankPart.Hitbox.Center-tankRayOrigin,20,1u<<23);
        Check(tankHit?.DynamicEntityId==79&&tankHit.ColliderLayer==23&&tankHit.SourceDestroyable&&
              tankWorld.Raycast(bodyShooter,tankRayOrigin,tankPart.Hitbox.Center-tankRayOrigin,
                  20,1u<<0)==null,
            "Tank body uses its live faction destroyable layer, never prefab layer zero, in bullet masks");
        var shotgunOrigin=bodyTarget.Hitbox.Center-Vector3.UnitZ*2;
        var bodyOverlap=bodyWorld.OverlapEnemy(bodyShooter,shotgunOrigin,4,
            1u<<bodyTarget.Layer);
        Check(bodyOverlap.Any(x=>x.MainEntityId=="vehicle:77")&&
              !bodyWorld.OverlapEnemy(bodyShooter,shotgunOrigin,4,0)
                  .Any(x=>x.MainEntityId=="vehicle:77"),
              "source-pinned opposing vehicle body enters shotgun sphere only through its runtime layer");
        var bodyPlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            shotgunOrigin,bodyTarget.Hitbox.Center+Vector3.UnitX*.5f,bodyOverlap);
        Check(bodyPlan.RealPellets.Any(x=>bodyOverlap.Any(y=>y.MainEntityId=="vehicle:77"&&
              y.EntityId==x.EntityId)),
              "source shotgun cone schedules a real pellet toward the placed vehicle body");
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
        string passengerRole=humveeRig.Passengers[0].Role;
        var passengerTargets=idlePassenger.Select(hitbox=>new DynamicShotTarget(77,0,23,
            hitbox,PassengerRole:passengerRole)).ToArray();
        var passengerWorld=new ShotCollisionWorld(null,
        [
            new(bodyShooter,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
            new(bodyOpponent,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
        ],dynamicTargets:_=>passengerTargets);
        var passengerOrigin=idlePassenger[0].Center-Vector3.UnitZ*2;
        var passengerOverlap=passengerWorld.OverlapEnemy(bodyShooter,passengerOrigin,4,1u<<23);
        Check(passengerOverlap.Count(x=>x.MainEntityId=="passenger:77:"+passengerRole)==3&&
              !passengerWorld.OverlapEnemy(bodyShooter,passengerOrigin,4,0)
                  .Any(x=>x.MainEntityId=="passenger:77:"+passengerRole),
              "sampled Humvee passenger body/head share one shotgun object on the opponent layer");
        var passengerPlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            passengerOrigin,idlePassenger[0].Center+Vector3.UnitX*.5f,passengerOverlap);
        Check(passengerPlan.RealPellets.Count(x=>passengerOverlap.Any(y=>
                  y.MainEntityId=="passenger:77:"+passengerRole&&y.EntityId==x.EntityId))<=2&&
              passengerPlan.RealPellets.Any(x=>passengerOverlap.Any(y=>
                  y.MainEntityId=="passenger:77:"+passengerRole&&y.EntityId==x.EntityId)),
              "shotgun limits a passenger's sampled body/head to two extra real pellets");
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
        Check(!tankRig.Roles.Single(r=>r.Role=="cannon").Weapons.Single().FriendKill&&
              !buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons[0].FriendKill&&
              buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons[1].FriendKill,
              "recovered Tank and Buggy cannon weapons retain their distinct friendKill flags");
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
        var passengerMissileCenter=idlePassenger[0].Center;
        var passengerMissileOrigin=passengerMissileCenter-Vector3.UnitZ*5;
        var passengerMissileTarget=passengerMissileCenter+Vector3.UnitZ*5;
        var passengerMissileFlight=new TankMissileFlight(83,84,tankMissileBinding,
            passengerMissileOrigin,()=>passengerMissileTarget,0,
            (from,direction,range)=>passengerWorld.Raycast(bodyShooter,from,direction,range,uint.MaxValue));
        TankMissileImpact? passengerMissileImpact=null;
        for(ulong flightTick=1;flightTick<=200&&!passengerMissileFlight.Finished;flightTick++)
            passengerMissileImpact=passengerMissileFlight.Advance(flightTick)??passengerMissileImpact;
        Check(passengerMissileImpact?.Collision is {DynamicEntityId:77,
                  DynamicPassengerRole:var missileRole}&&missileRole==passengerRole,
              "Tank missile flight traces into one live source-pose passenger hitbox");
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
            foreach(var unit in new[]{"ID_UNIT-HUMVEE","ID_UNIT-TANK","ID_UNIT-BUGGY","ID_UNIT-TRANSPORTER"})
                Check(content.GroundVehicleWeapons.For(unit).FlamePartCoefficient==.4f,
                    "source Awake-time vehicle Flame coefficient: "+unit);
            foreach(var unit in new[]{"ID_UNIT-HUMVEE","ID_UNIT-TANK","ID_UNIT-BUGGY","ID_UNIT-TRANSPORTER"})
                Check(content.GroundVehicleWeapons.For(unit).ShotTarget==new Vector3(0,unit=="ID_UNIT-TANK"?.289806f:.51933026f,0),
                    "source vehicle Body aim target: "+unit);
            var changedFlame=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            changedFlame["vehicles"]![0]!["flamePartCoefficient"]=.33f;
            File.WriteAllText(vehicleWeaponTemp,changedFlame.ToJsonString());
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)))));
            var changedFriendKill=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            changedFriendKill["vehicles"]![1]!["roles"]![1]!["weapons"]![0]!["friendKill"]=true;
            File.WriteAllText(vehicleWeaponTemp,changedFriendKill.ToJsonString());
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)))));
            var missingFriendKill=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            ((JsonObject)missingFriendKill["vehicles"]![2]!["roles"]![1]!["weapons"]![1]!).Remove("friendKill");
            File.WriteAllText(vehicleWeaponTemp,missingFriendKill.ToJsonString());
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)))));
            var changedTarget=JsonNode.Parse(File.ReadAllText(vehicleWeaponPath))!;
            changedTarget["vehicles"]![0]!["shotTargets"]![0]!["position"]![1]=0;
            File.WriteAllText(vehicleWeaponTemp,changedTarget.ToJsonString());
            Reject(()=>GroundVehicleWeaponCatalog.Load(vehicleWeaponTemp,
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(vehicleWeaponTemp)))));
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
            damaged["repairDronePrefab"]!["flameCoefficient"]=.5f;
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
        Check(content.Army.Families.Count==24 && content.Army.Families.Sum(f=>f.Options.Count)==45 &&
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
        Check(minigunnerFamily.SheetRow=="Google2u.DBUpgradeSlotsMinigunner"&&
              minigunnerFamily.BaseShot is {ProbabilityOfRealShot:1f,FireBatchSizeMin:1,
                  FireBatchSizeMax:4,MinShootTime:2f,MaxShootTime:5f}&&
              content.ArmyWeapons.MuzzleCount("ID_UNIT-MINIGUNNER")==1&&
              content.ArmyWeapons.Muzzle("ID_UNIT-MINIGUNNER").Path==
                  "MiniGun/HK416/MachinegunMuzzleFlash"&&
              content.ArmyWeapons.WindupTicks("ID_UNIT-MINIGUNNER")==30&&
              content.ArmyWeapons.CadenceTicks("ID_UNIT-MINIGUNNER")==6,
              "Minigunner uses its attached scene sheet, base batch, shield windup, muzzle, and strict cadence");
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
              content.Army.EffectiveSpeed("ID_UNIT-SWAT",1f,0,null,null)==.8f&&
              content.Army.ComposeSpecial("ID_UNIT-SWAT",0,86,null)==.05f&&
              Math.Abs(content.Army.EffectiveSpeed("ID_UNIT-SWAT",1f,0,86,null)-.84f)<.00001f&&
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
        var overflowDeployment=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT"]);
        overflowDeployment.SetOffers([0,1,0]);
        try
        {
            _=overflowDeployment.TryDeploy(1,ulong.MaxValue);
            throw new Exception("Overflowing army schedule was accepted.");
        }
        catch(OverflowException){}
        Check(overflowDeployment.PendingCount==0&&overflowDeployment.NextDeployTick==0&&
              overflowDeployment.OfferedOptions.SequenceEqual([0,1,0]),
              "overflowing deployment does not enqueue a partial four-unit batch or consume its hand");
        var starvingDeployment=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT"]);
        starvingDeployment.SetOffers([1,1,1]);
        Check(starvingDeployment.TryDeploy(1,0)=="army-deploying"&&starvingDeployment.PendingCount==4,
              "four-unit authority can be scheduled before one host tick");
        typeof(ArmyDeploymentState).GetProperty(nameof(ArmyDeploymentState.Energy))!.SetValue(starvingDeployment,2);
        try
        {
            _=starvingDeployment.Advance(100);
            throw new Exception("Lost reserved energy was accepted.");
        }
        catch(InvalidDataException){}
        Check(starvingDeployment.PendingCount==4&&starvingDeployment.ActiveCount==0&&starvingDeployment.Energy==2,
              "late shortage rejects the entire due spawn batch before queue or energy mutation");
        typeof(ArmyDeploymentState).GetProperty(nameof(ArmyDeploymentState.Energy))!.SetValue(starvingDeployment,8);
        Check(starvingDeployment.Advance(100).Count==4&&starvingDeployment.PendingCount==0&&
              starvingDeployment.ActiveCount==4&&starvingDeployment.Energy==4,
              "repaired reserved energy can still commit the complete ordered spawn batch once");
        Check(deployment.TryDeploy(1,101)=="army-cooldown" &&
              deployment.TryDeploy(1,200)=="army-deploying" &&
              deployment.Advance(200).Count==1 && deployment.Energy==5 &&
              deployment.Advance(227).Count==3 && deployment.Energy==2 && deployment.ActiveCount==6,
              "cooldown and later four-unit batch are owned by host ticks");
        var combatDeath=deployment.RemoveEntity(1);
        var opposingEnergy=new ArmyDeploymentState(content.Army,["ID_UNIT-ASSAULT"]);
        Check(opposingEnergy.PreviewKillEnergy(combatDeath!.Power)==9&&opposingEnergy.Energy==8,
              "kill energy can be checked before the host removes a victim");
        try
        {
            _=opposingEnergy.PreviewKillEnergy(1001);
            throw new Exception("Invalid kill power passed death preflight.");
        }
        catch(InvalidDataException){}
        Check(opposingEnergy.Energy==8,"rejected kill power leaves recipient energy unchanged");
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
        var rejectedFirst=new ArmyDeploymentState(content.Army,
            ["ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER","ID_UNIT-SHOTGUNNER"],
            ["ID_UNIT-SNIPER"]);
        try
        {
            _=rejectedFirst.GenerateOffers(count=>count);
            throw new Exception("Invalid army random choice accepted.");
        }
        catch(InvalidDataException){}
        Check(rejectedFirst.OfferedOptions.Count==0&&rejectedFirst.GenerateOffers(_=>0).SequenceEqual([6,7,11]),
              "rejected host choice leaves the first-new priority available for a successful hand");
        var delayedNew=new ArmyDeploymentState(content.Army,
            ["ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER","ID_UNIT-SHOTGUNNER"],
            ["ID_UNIT-SNIPER"]);
        Check(delayedNew.GenerateOffers(_=>0,(_,_)=>false).Count==0&&
              delayedNew.GenerateOffers(_=>0).SequenceEqual([6,7,11]),
              "a temporarily unavailable scene route does not consume first-new priority");
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
                  content.Army.Families.Single(f=>f.BehaviorType=="SoldierBehaviourSwat").MovementSpeed==.8f &&
                  content.Army.Families.Single(f=>f.BehaviorType=="HelicopterBehaviour").MovementSpeed==3f &&
                  content.Army.EffectiveSpeed("ID_UNIT-SWAT",1.25f)==1f &&
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
                  decoys.Prefab.DamageComponentFileId==11484216&&decoys.Prefab.FlameCoefficient==1&&
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
                changed=JsonNode.Parse(File.ReadAllText(decoyArtifact))!;
                changed["prefab"]!["flameCoefficient"]=.5f;
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
            const string minePosePath="MineTriggerPlayer";
            PlayerCollisionModel MinePose(Vector3 root)=>PlayerCollisionModel.InitializedFrame("mine-pose",minePosePath,root,Quaternion.Identity,
            [
                new(minePosePath+"/Body",PlayerHitboxKind.Box,1,root,new(1,.8f,.6f),Quaternion.Identity,0,Vector3.Zero,0),
                new(minePosePath+"/Head",PlayerHitboxKind.Sphere,1.5f,root+new Vector3(0,1,0),Vector3.Zero,Quaternion.Identity,.25f,Vector3.Zero,0)
            ]);
            var centeredMine=-landMines.Prefab.TriggerCenter;
            var mineExplosion=LandMineExplosion.Resolve(centeredMine,57.625f,landMines,MinePose(Vector3.Zero),Vector3.Zero);
            var mineDynamic=new MapDynamicCollider(1,"mine-shield","shield",8,
                new Vector3(1.6f,0,0),new Vector3(1.4f,-.2f,-.2f),new Vector3(1.8f,.2f,.2f));
            var nearMineDynamic=LandMineExplosion.ResolveDynamic(Vector3.Zero,57.625f,landMines,
                mineDynamic with {TransformPosition=new(.5f,0,0),BoundsMin=new(.3f,-.2f,-.2f),
                    BoundsMax=new(.7f,.2f,.2f)});
            var outerMineDynamic=LandMineExplosion.ResolveDynamic(Vector3.Zero,57.625f,landMines,mineDynamic);
            Check(nearMineDynamic is {Kind:CombatDamageType.Explosion,RawDamage:57.625f}&&
                  outerMineDynamic is {Kind:CombatDamageType.Shiver,RawDamage:57.625f},
                  "Land Mine scene blast retains recovered dead/hurt types and equal card damage");
            var rotatedBody=new PlayerHitbox("rotated-body",PlayerHitboxKind.Box,1,Vector3.Zero,new(.4f,.4f,2),
                Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/4),0,Vector3.Zero,0);
            var capsuleBody=new PlayerHitbox("capsule-body",PlayerHitboxKind.Capsule,1,Vector3.Zero,Vector3.Zero,
                Quaternion.Identity,.2f,Vector3.UnitY,.5f);
            bool mineNear=LandMineExplosion.Triggered(centeredMine,landMines.Prefab,MinePose(Vector3.Zero));
            bool mineFar=LandMineExplosion.Triggered(centeredMine,landMines.Prefab,MinePose(new Vector3(2,0,0)));
            bool rotatedOverlap=rotatedBody.OverlapsBox(new(.5f,0,0),new(.3f,.3f,.3f),Quaternion.Identity);
            bool capsuleOverlap=capsuleBody.OverlapsBox(new(0,.55f,0),new(.2f,.2f,.2f),Quaternion.Identity);
            bool capsuleFar=capsuleBody.OverlapsBox(new(1,.6f,0),new(.2f,.2f,.2f),Quaternion.Identity);
            Check(mineNear&&!mineFar&&mineExplosion is {Kind:CombatDamageType.Explosion,RawDamage:57.625f}&&
                  rotatedOverlap&&capsuleOverlap&&!capsuleFar,
                  "Land Mine trigger uses source box volume against current box, sphere and capsule poses");
            var landMineRegistry=new LandMineMatchRegistry(3);
            string landMineRequest=new string('7',32),landMineOwner=new string('2',32);
            var landMinePlacements=selectedLandMines.Select((slot,index)=>(slot,new Vector3(index,0,index))).ToArray();
            Check(landMineRegistry.TrySpawn(landMineRequest,landMineOwner,1,57.625f,landMinePlacements,out var spawnedLandMines)&&
                  spawnedLandMines.Count==3&&landMineRegistry.Snapshot().Count==3&&
                  landMineRegistry.TryReplay(landMineRequest,landMineOwner,out var replayedLandMines)&&replayedLandMines.Count==3&&
                  !landMineRegistry.TrySpawn(new string('8',32),landMineOwner,1,57.625f,landMinePlacements,out _),
                  "Land Mine registry atomically owns three opposing placements and retry receipts");
            Check(landMineRegistry.TryRemove(spawnedLandMines[0].EntityId,out var removedLandMine)&&removedLandMine!=null&&
                  landMineRegistry.RemoveOwner(landMineOwner).Count==2&&landMineRegistry.Snapshot().Count==0,
                  "Land Mine trigger and owner cleanup remove exact server entities");
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
            string heavyTurretArtifact=Path.Combine(directory,"recovered-heavy-turret-source.json");
            string heavyTurretRevision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretArtifact)));
            var heavyTurrets=HeavyTurretSourceCatalog.Load(heavyTurretArtifact,heavyTurretRevision,content.Maps);
            var parkTurretCovers=heavyTurrets.ForMap(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer"));
            var heavyMid=heavyTurrets.Compose(22);var firstTurretCover=parkTurretCovers[0];
            using(var turretOracle=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-heavy-turret-aim-samples.json"))))
            {
                Check(turretOracle.RootElement.GetProperty("sha256").GetString()==heavyTurrets.PrefabRevision&&
                    turretOracle.RootElement.GetProperty("samples").GetArrayLength()==6,
                    "turret joint oracle binds the complete six-sample source prefab export");
                foreach(var sample in turretOracle.RootElement.GetProperty("samples").EnumerateArray())
                {
                    Vector3 Point(string name){var v=sample.GetProperty(name);return new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());}
                    var aimedTurret=new HeavyTurretAimState();aimedTurret.Plan(Vector3.Zero,Point("target"));aimedTurret.Complete();
                    Check(Vector3.Distance(aimedTurret.SightOffset(heavyTurrets),Point("sight"))<.00001f&&
                        Vector3.Distance(aimedTurret.MuzzleOffset(heavyTurrets),Point("muzzle"))<.00001f,
                        "host turret sight and world-offset muzzle match independent Unity hierarchy sample");
                    var boxes=sample.GetProperty("colliders").EnumerateArray().ToArray();
                    Check(Vector3.Distance(aimedTurret.BodyTargetOffset(heavyTurrets),Point("body"))<.00001f,
                        "host turret Body target matches independent completed Unity joint pose");
                    Check(boxes.Length==3,"Unity turret oracle retains all three source boxes");
                    foreach(var sourceShape in heavyTurrets.Colliders)
                    {
                        Vector3 BoxPoint(JsonElement box,string name){var v=box.GetProperty(name);return new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());}
                        var expectedBox=boxes.Single(b=>Vector3.Distance(BoxPoint(b,"size"),sourceShape.Size)<.00001f);
                        var q=expectedBox.GetProperty("rotation");var expectedRotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
                        var aimedShape=aimedTurret.Collider(heavyTurrets,sourceShape);
                        Check(Vector3.Distance(aimedShape.Center,BoxPoint(expectedBox,"center"))<.00001f&&
                            1-Math.Abs(Quaternion.Dot(aimedShape.Rotation,expectedRotation))<.00001f,
                            "aimed turret box center and rotation match independent Unity hierarchy sample");
                    }
                }
            }
            var shotgunTurretAim=new HeavyTurretAimState();
            shotgunTurretAim.Plan(Vector3.Zero,Vector3.UnitZ);shotgunTurretAim.Complete();
            var turretOverlapTargets=heavyTurrets.Colliders.Select(shape=>
            {
                var placed=shotgunTurretAim.Collider(heavyTurrets,shape);
                return new DynamicShotTarget(91,placed.ComponentFileId,23,
                    new PlayerHitbox(heavyTurrets.PrefabRevision+"#"+placed.ComponentFileId,
                        PlayerHitboxKind.Box,1,placed.Center,placed.Size,placed.Rotation,0,
                        Vector3.Zero,0),HeavyTurret:true);
            }).ToArray();
            var turretOverlapWorld=new ShotCollisionWorld(null,
            [
                new(bodyShooter,referencePose.Place(new(100,0,100),Quaternion.Identity).Collision),
                new(bodyOpponent,referencePose.Place(new(110,0,100),Quaternion.Identity).Collision)
            ],dynamicTargets:_=>turretOverlapTargets);
            var turretOrigin=turretOverlapTargets[0].Hitbox.Center-Vector3.UnitZ*2;
            var turretOverlap=turretOverlapWorld.OverlapEnemy(bodyShooter,turretOrigin,4,1u<<23);
            Check(turretOverlap.Any(x=>x.MainEntityId=="heavy-turret:91")&&
                  !turretOverlapWorld.OverlapEnemy(bodyShooter,turretOrigin,4,0)
                      .Any(x=>x.MainEntityId=="heavy-turret:91"),
                  "source Heavy Turret damage boxes enter shotgun overlap on the opponent layer");
            var turretShot=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
                turretOrigin,turretOverlapTargets[0].Hitbox.Center+Vector3.UnitX*.5f,turretOverlap);
            Check(turretShot.RealPellets.Count(x=>turretOverlap.Any(y=>
                      y.MainEntityId=="heavy-turret:91"&&y.EntityId==x.EntityId)) is >=1 and <=2,
                  "source shotgun limits Heavy Turret damage parts to two extra pellets per root");
            var turretAim=new HeavyTurretAimState();
            using(var tweenOracle=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-heavy-turret-aim-samples.json"))))
            foreach(var sample in tweenOracle.RootElement.GetProperty("tweenSamples").EnumerateArray())
            {
                var t=sample.GetProperty("target");var turningTurret=new HeavyTurretAimState();
                turningTurret.Plan(Vector3.Zero,new(t[0].GetSingle(),t[1].GetSingle(),t[2].GetSingle()));
                int previousStep=0;
                foreach(var frame in sample.GetProperty("frames").EnumerateArray())
                {
                    int step=frame.GetProperty("step").GetInt32();while(previousStep<step){turningTurret.AdvanceTick();previousStep++;}
                    Vector3 FramePoint(JsonElement row,string name){var v=row.GetProperty(name);return new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());}
                    // Native Unity tween/Euler interpolation and Numerics
                    // differ slightly; use the existing pose reconstruction
                    // tolerance (0.2 mm), while endpoints retain 0.01 mm.
                    Check(Vector3.Distance(turningTurret.SightOffset(heavyTurrets),FramePoint(frame,"sight"))<.0002f&&
                        Vector3.Distance(turningTurret.MuzzleOffset(heavyTurrets),FramePoint(frame,"muzzle"))<.0002f,
                        "tick-sampled turret origins match actual Unity TweenRotation.Sample: "+t+" step "+step+
                        " host "+turningTurret.SightOffset(heavyTurrets)+" Unity "+FramePoint(frame,"sight"));
                    var boxes=frame.GetProperty("colliders").EnumerateArray().ToArray();
                    Check(Vector3.Distance(turningTurret.BodyTargetOffset(heavyTurrets),FramePoint(frame,"body"))<.0002f,
                        "host turret Body target matches independent Unity tween tick");
                    foreach(var shape in heavyTurrets.Colliders)
                    {
                        var box=boxes.Single(b=>Vector3.Distance(FramePoint(b,"size"),shape.Size)<.00001f);
                        var q=box.GetProperty("rotation");var expected=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
                        var actual=turningTurret.Collider(heavyTurrets,shape);
                        Check(Vector3.Distance(actual.Center,FramePoint(box,"center"))<.0002f&&
                            1-Math.Abs(Quaternion.Dot(actual.Rotation,expected))<.00001f,
                            "tick-sampled turret hitboxes match actual Unity TweenRotation.Sample");
                    }
                }
            }
            Check(turretAim.Plan(Vector3.Zero,Vector3.UnitZ)==0&&
                  turretAim.Plan(Vector3.Zero,Vector3.UnitX)==8,
                "Heavy Turret aligned aim is immediate and quarter turn uses source angular duration");
            turretAim.Complete();
            Check(turretAim.Plan(Vector3.Zero,Vector3.UnitX)==0&&
                  turretAim.Plan(Vector3.Zero,-Vector3.UnitX)==15,
                "Heavy Turret retains completed horizontal aim and half turn uses half a second");
            turretAim.Complete();
            Check(turretAim.Plan(Vector3.Zero,new(-1,1,0))==3,
                "Heavy Turret vertical pitch requires the source horizontal minimum callback delay");
            var smallTurretAim=new HeavyTurretAimState();
            Check(smallTurretAim.Plan(Vector3.Zero,Vector3.Transform(Vector3.UnitZ,
                  Quaternion.CreateFromAxisAngle(Vector3.UnitY,3*MathF.PI/180)))==3,
                "Heavy Turret unaligned small turns retain the tenth-second minimum");
            Reject(()=>turretAim.Plan(Vector3.Zero,Vector3.Zero));
            var turretRandoms=new Queue<float>([0,0,.1f,.9f,.2f,0]);int turretDraws=0;
            var turretBatch=new HeavyTurretAttackState(heavyMid with {RealShotProbability=.5f},()=>{turretDraws++;return turretRandoms.Dequeue();});
            while(turretBatch.CooldownTicksRemaining>0)turretBatch.AdvanceTick();
            Check(turretBatch.TryBegin("target")&&turretBatch.BatchRemaining==0&&turretDraws==1,
                "Heavy Turret does not select a batch before its aim completes");
            for(int i=0;i<30;i++)turretBatch.AdvanceTick();
            Check(turretBatch.BatchReady&&!turretBatch.ShotDue&&turretDraws==1,
                "completed turret aim waits for visibility before consuming batch randomness");
            turretBatch.SelectBatchSize();
            Check(turretBatch.ShotDue&&turretBatch.BatchRemaining==3&&turretDraws==2,
                "Heavy Turret chooses exclusive-upper-bound batch size after aiming");
            turretBatch.PrepareBatchRounds();
            Check(turretDraws==5&&turretBatch.CurrentShotIsReal&&turretBatch.CommitShot(),
                "Heavy Turret preselects every round before the first shot");
            for(int i=0;i<6;i++)turretBatch.AdvanceTick();
            turretBatch.PrepareBatchRounds();
            Check(!turretBatch.CurrentShotIsReal&&turretDraws==5&&turretBatch.CommitShot(),
                "Heavy Turret retains its fake second round without another random draw");
            for(int i=0;i<6;i++)turretBatch.AdvanceTick();
            Check(turretBatch.CurrentShotIsReal&&turretBatch.CommitShot()&&turretDraws==6&&
                turretBatch.Phase==HeavyTurretAttackPhase.Cooldown&&turretBatch.TargetId=="",
                "Heavy Turret retains its real final round and schedules one post-batch cooldown");
            Reject(()=>new HeavyTurretAttackState(heavyMid,()=>float.NaN));
            Reject(()=>new HeavyTurretAttackState(heavyMid,()=>1));
            int blockedTurretDraws=0;
            var blockedTurret=new HeavyTurretAttackState(heavyMid,()=>{blockedTurretDraws++;return 0;});
            while(blockedTurret.CooldownTicksRemaining>0)blockedTurret.AdvanceTick();
            blockedTurret.TryBegin("blocked");for(int i=0;i<30;i++)blockedTurret.AdvanceTick();
            blockedTurret.CancelTarget();
            Check(blockedTurretDraws==2&&blockedTurret.Phase==HeavyTurretAttackPhase.Cooldown&&blockedTurret.BatchRemaining==0,
                "failed turret sight consumes only the new cooldown draw, without batch or round draws");
            var otherFriendlyCover=parkTurretCovers.First(x=>x.Fraction==firstTurretCover.Fraction&&x.Order!=firstTurretCover.Order);
            var parkTurretMap=content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer");
            Check(heavyTurrets.SelectNearestFree(parkTurretMap,firstTurretCover.Order,firstTurretCover.Fraction,
                otherFriendlyCover.Slots[0].SourcePosition,_=>false)==otherFriendlyCover.Slots[0],
                "Heavy Turret searches all friendly covers rather than restricting placement to current cover");
            var friendlySlots=parkTurretCovers.Where(x=>x.Fraction==firstTurretCover.Fraction).SelectMany(x=>x.Slots).ToArray();
            var lastFriendlySlot=friendlySlots[^1];
            Check(heavyTurrets.SelectNearestFree(parkTurretMap,firstTurretCover.Order,firstTurretCover.Fraction,
                firstTurretCover.Slots[0].SourcePosition,id=>id!=lastFriendlySlot.ComponentFileId)==lastFriendlySlot&&
                heavyTurrets.SelectNearestFree(parkTurretMap,firstTurretCover.Order,firstTurretCover.Fraction,
                    firstTurretCover.Slots[0].SourcePosition,_=>true)==null,
                "Heavy Turret falls back to the last friendly free slot and never an enemy slot");
            var nearestTurret=heavyTurrets.SelectNearestFree(content.Maps.Single(x=>Path.GetFileNameWithoutExtension(x.Source)=="Park_Multiplayer"),
                firstTurretCover.Order,firstTurretCover.Fraction,firstTurretCover.Slots[1].SourcePosition,id=>id==firstTurretCover.Slots[1].ComponentFileId);
            Check(heavyTurrets.SpawnCount==1&&heavyTurrets.NavMeshSampleRadius==10&&heavyTurrets.NavMeshAreaMask==1&&
                  heavyTurrets.MaxDisplayLevel==44&&parkTurretCovers.Count==8&&parkTurretCovers.Sum(x=>x.Slots.Count)==16&&
                  Math.Abs(heavyMid.Health-858.6711f)<.001f&&Math.Abs(heavyMid.Damage-55.07f)<.001f&&
                  heavyMid.BatchMinimum==3&&heavyMid.BatchMaximum==6&&Math.Abs(heavyMid.ShootMinimum-2.5f)<.001f&&
                  Math.Abs(heavyMid.ShootMaximum-5)<.001f&&Math.Abs(heavyMid.RealShotProbability-.775f)<.001f&&
                  heavyTurrets.EffectiveRealShotProbability==1&&heavyTurrets.EffectiveBulletSpeed==25&&
                  heavyTurrets.BulletCheckDistance==.6f&&heavyTurrets.PlayerDamageRatio==.5f&&
                  heavyTurrets.PlayerOvertimeDamageRatio==.5f&&heavyTurrets.ShieldHitProbability==0&&
                  PlayerHitbox.Finite(heavyTurrets.MuzzleOffset)&&
                  heavyTurrets.Colliders.Count==3&&heavyTurrets.Colliders.Select(x=>x.ComponentFileId)
                      .SequenceEqual(new[]{6525385,6572182,6582579})&&
                  heavyTurrets.Colliders.All(x=>x.Size.X>0&&x.Size.Y>0&&x.Size.Z>0&&
                      x.DamagePartComponentFileId>0&&x.FlameWeight==1)&&
                  heavyTurrets.FlameCoefficient==1&&
                  nearestTurret==firstTurretCover.Slots[0],
                  "Heavy Turret source pins 80 slots, prefab graph and source card-level interpolation");
            string heavyTurretTemp=Path.Combine(Path.GetTempPath(),"war-heavy-turret-"+Guid.NewGuid().ToString("N")+".json");
            try
            {
                var changed=JsonNode.Parse(File.ReadAllText(heavyTurretArtifact))!;
                changed["prefab"]!["turret"]!["maxShotRotation"]=359;
                File.WriteAllText(heavyTurretTemp,changed.ToJsonString());
                Reject(()=>HeavyTurretSourceCatalog.Load(heavyTurretTemp,
                    Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretTemp))),content.Maps));
                changed=JsonNode.Parse(File.ReadAllText(heavyTurretArtifact))!;
                changed["prefab"]!["colliders"]![0]!["flameWeight"]=.5f;
                File.WriteAllText(heavyTurretTemp,changed.ToJsonString());
                Reject(()=>HeavyTurretSourceCatalog.Load(heavyTurretTemp,
                    Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretTemp))),content.Maps));
                foreach(bool changeGroup in new[]{true,false})
                {
                    var damagedTarget=JsonNode.Parse(File.ReadAllText(heavyTurretArtifact))!;
                    if(changeGroup)damagedTarget["behavior"]!["unitType"]=1;
                    else damagedTarget["prefab"]!["shotTarget"]!["position"]![1]=0;
                    File.WriteAllText(heavyTurretTemp,damagedTarget.ToJsonString());
                    Reject(()=>HeavyTurretSourceCatalog.Load(heavyTurretTemp,
                        Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretTemp))),content.Maps));
                }
                foreach(var field in new[]{"secondaryTargets","primTarget","primaryTargetOnly","needToSeePrimaryTarget","needToSeeSecondaryTarget","keepAimed"})
                {
                    var missing=JsonNode.Parse(File.ReadAllText(heavyTurretArtifact))!;
                    missing["prefab"]!["turret"]!.AsObject().Remove(field);
                    File.WriteAllText(heavyTurretTemp,missing.ToJsonString());
                    Reject(()=>HeavyTurretSourceCatalog.Load(heavyTurretTemp,
                        Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretTemp))),content.Maps));
                }
                var reordered=JsonNode.Parse(File.ReadAllText(heavyTurretArtifact))!;
                reordered["prefab"]!["turret"]!["secondaryTargets"]=new JsonArray(2,0,1);
                File.WriteAllText(heavyTurretTemp,reordered.ToJsonString());
                Reject(()=>HeavyTurretSourceCatalog.Load(heavyTurretTemp,
                    Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(heavyTurretTemp))),content.Maps));
            }
            finally {if(File.Exists(heavyTurretTemp))File.Delete(heavyTurretTemp);}
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
            foreach(var reason in new[]{"invalid-army-flame-authority","invalid-buggy-projectile-authority",
                "invalid-drone-route-authority","invalid-helicopter-route-authority",
                "invalid-land-mine-authority","invalid-tank-projectile-authority",
                "invalid-vehicle-route-authority"})
                BattleTerminalPolicy.Validate(reason,"",false,false);
            count++;
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
            var ownedCards=new BattlePerformanceLedger();
            const string firstCardOwner="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            const string secondCardOwner="bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            const string cardReceipt="cccccccccccccccccccccccccccccccc";
            Check(ownedCards.RecordCard(cardReceipt,firstCardOwner,"CardDecoy")&&
                  !ownedCards.RecordCard(cardReceipt,firstCardOwner,"CardDecoy")&&
                  ownedCards.CardActivationsFor(firstCardOwner)==1&&
                  ownedCards.CardActivationsFor(secondCardOwner)==0&&
                  ownedCards.CardUsageSnapshot().Single()==new BattlePerformanceLedger.CardUsage(firstCardOwner,"CardDecoy","DECOY",1),
                  "accepted card activation retains its player owner on replay");
            Reject(()=>ownedCards.RecordCard(cardReceipt,secondCardOwner,"CardDecoy"));
            Reject(()=>ownedCards.RecordCard(cardReceipt,firstCardOwner,"CardLandmine"));
            Check(WarCardSourceIdentityCatalog.All.Count==23&&
                  WarCardSourceIdentityCatalog.Resolve("CardHeavyTurret")=="HEAVYTURRET"&&
                  WarCardSourceIdentityCatalog.Resolve("CardSpawnUnit","ELITEPARA")=="ELITEPARA",
                  "recovered card class and serialized source identities stay distinct");
            Reject(()=>WarCardSourceIdentityCatalog.Resolve("CardSpawnUnit"));
            Reject(()=>WarCardSourceIdentityCatalog.Resolve("CardSpawnUnit","DECOY"));
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
            var gunnerImpactPage=new MatchEventBatch{Code="events",LatestEventId=1};
            gunnerImpactPage.Events.Add(new MatchEvent{EventId=1,Tick=3,
                Kind=MatchEventKind.Impact,ActorId=warperOwner,TargetId="army:4294967297",
                ProjectileId=9,Reason="helicopter-gunner"});
            Check(new War.Client.MatchEventConsumer().Consume(gunnerImpactPage)==1,
                  "Client event consumer accepts source-bound Helicopter gunner impacts");
            var invalidGunnerImpact=gunnerImpactPage.Clone();
            invalidGunnerImpact.Events[0].TargetId="army:0004294967297";
            Reject(()=>new War.Client.MatchEventConsumer().Consume(invalidGunnerImpact));
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
        var trustedShotCoefficients=new float[]{2};
        var shotPerkManifest=armyManifest with {Players=[armyManifest.Players[0] with {ArmyShotSpeedCoefficients=trustedShotCoefficients},
            armyManifest.Players[1] with {ArmyShotSpeedCoefficients=[1]}]};
        var detachedShotPerk=MatchManifest.Validate(shotPerkManifest);trustedShotCoefficients[0]=3;
        Check(detachedShotPerk.Players[0].ArmyShotSpeedCoefficients![0]==2,"shot-speed manifest detaches caller arrays");
        Reject(()=>MatchManifest.Validate(armyManifest with {Players=[armyManifest.Players[0] with {ArmyShotSpeedCoefficients=[1]},armyManifest.Players[1]]}));
        Reject(()=>MatchManifest.Validate(shotPerkManifest with {Players=[shotPerkManifest.Players[0] with {ArmyShotSpeedCoefficients=[float.NaN]},shotPerkManifest.Players[1]]}));
        Reject(()=>MatchManifest.Validate(shotPerkManifest with {Players=[shotPerkManifest.Players[0] with {ArmyShotSpeedCoefficients=[]},shotPerkManifest.Players[1]]}));
        string decoyPlayer=armyManifest.Players[0].PlayerId,decoyOpponent=armyManifest.Players[1].PlayerId;
        int criticalDraws=0;
        var criticalRifle=new RifleMatchSimulation(armyManifest,park,content,
            sourceRandom:()=>{criticalDraws++;return 0;});
        var ordinaryRifle=new RifleMatchSimulation(armyManifest,park,content,sourceRandom:()=>1);
        var rifleAim=park.Covers[coverTwo.SourceIndex].Position+Vector3.UnitY;
        var criticalRound=criticalRifle.PrepareVolley(1,decoyPlayer,rifleAim,60).Single();
        var ordinaryRound=ordinaryRifle.PrepareVolley(1,decoyPlayer,rifleAim,60).Single();
        Check(criticalDraws==1&&
              criticalRound.Damage.Amount==ordinaryRound.Damage.Amount*
                  content.Bindings.Get(weapon.SourceId).CriticalMultiplier,
            "live rifle projectile consumes injected host critical roll rather than a global random draw");
        var decoyManifest=armyManifest with
        {
            MatchId="decoy-match",SceneMasterPlayerId=decoyPlayer,
            Players=[armyManifest.Players[0] with {PlayerLevel=22},armyManifest.Players[1] with {PlayerLevel=22}]
        };
        var missileDecoySource=MatchManifest.Validate(decoyManifest);
        var decoyMatch=new MatchEngine(decoyManifest,content:content,armyChoice:_=>0);
        decoyMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardDecoy"],[],[0],[133],[-1]),
            new(decoyOpponent,["CardDecoy"],[],[0],[-1],[-1])]);
        decoyMatch.Admit(decoyPlayer);decoyMatch.Admit(decoyOpponent);
        Check(decoyMatch.DroneTargetSnapshot().Select(r=>r.Id).SequenceEqual(new[]{"player:"+decoyPlayer,"player:"+decoyOpponent}),"admitted players register in recovered owner bucket order");
        decoyMatch.Admit(decoyPlayer);
        Check(decoyMatch.DroneTargetSnapshot().Count==2,"repeat admission does not duplicate shootable target");
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
        Check(decoyMatch.DroneTargetSnapshot().Count(r=>r.IsDecoy)==3&&decoyMatch.DroneTargetSnapshot().Where(r=>r.IsDecoy).All(r=>r.Fraction==1&&r.Alive&&r.Visible),"live Decoy spawn registers Drone target lifecycle");
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
        foreach(var sightDecoy in decoyMatch.Snapshot().Decoys)
        {
            var sightRotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(sightDecoy.FacingX,sightDecoy.FacingZ));
            var sightCenter=new Vector3(sightDecoy.X,sightDecoy.Y,sightDecoy.Z)+Vector3.Transform(content.Decoys.Prefab.ColliderCenter,sightRotation);
            Check(!decoyMatch.DroneCanSee(sightCenter-Vector3.UnitX*2-Vector3.UnitY*.5f,sightCenter+Vector3.UnitX*2),
                "Drone visibility includes real destroyable Decoy blockers on either fraction");
            var helicopterSelection=HelicopterTurretSightRay.ForSelection(
                sightCenter-Vector3.UnitX*2,sightCenter+Vector3.UnitX*2);
            Check(!decoyMatch.HelicopterVisibilityRay(helicopterSelection),
                "Helicopter source sight mask includes friendly and opposing Decoy collider blockers");
        }
        Check(decoyMatch.DroneCanSee(new(0,100,0),new(0,100.5f,0)),"Drone zero normalized sight ray retains Unity no-hit behavior");
        Check(decoyMatch.DroneCanSee(new(0,100,0),new(0,100.5f,10)),"clear elevated Drone sight excludes player body hitboxes");
        Check(decoyMatch.HelicopterVisibilityRay(HelicopterTurretSightRay.ForSelection(
                  new(0,100,0),new(0,100,10)))&&
              decoyMatch.HelicopterVisibilityRay(HelicopterTurretSightRay.ForSelection(
                  new(0,100,0),new(0,100,0))),
              "Helicopter static/dynamic sight query preserves clear and zero-direction rays");
        Reject(()=>decoyMatch.HelicopterVisibilityRay(new HelicopterSightRay(
            Vector3.Zero,Vector3.UnitX,10,uint.MaxValue)));
        var mineDecoyBefore=decoyMatch.Snapshot().Decoys.First(x=>x.OwnerPlayerId==decoyPlayer);
        var mineDecoyPosition=new Vector3(mineDecoyBefore.X,mineDecoyBefore.Y,mineDecoyBefore.Z);
        uint mineDecoyEnemyHits=decoyMatch.Snapshot().Players.Single(x=>x.PlayerId==decoyOpponent)
            .ConfirmedEnemyHits;
        Check(decoyMatch.ApplyLandMineDecoyExplosion(decoyOpponent,mineDecoyPosition,10,71)>0&&
              Math.Abs(decoyMatch.Snapshot().Decoys.Single(x=>x.EntityId==mineDecoyBefore.EntityId).Health-
                  (mineDecoyBefore.Health-10))<.001f&&
              decoyMatch.Snapshot().Players.Single(x=>x.PlayerId==decoyOpponent)
                  .ConfirmedEnemyHits>mineDecoyEnemyHits,
            "Land Mine blast damages the recovered Decoy root box and credits an enemy hit");
        float mineDecoyFriendlyBefore=decoyMatch.Snapshot().Decoys
            .Single(x=>x.EntityId==mineDecoyBefore.EntityId).Health;
        Check(decoyMatch.ApplyLandMineDecoyExplosion(decoyPlayer,mineDecoyPosition,10,72)>0&&
              Math.Abs(decoyMatch.Snapshot().Decoys.Single(x=>x.EntityId==mineDecoyBefore.EntityId).Health-
                  (mineDecoyFriendlyBefore-5))<.001f,
            "allied Land Mine blast applies recovered half damage to a Decoy");
        Reject(()=>decoyMatch.ApplyLandMineDecoyExplosion(decoyOpponent,mineDecoyPosition,float.NaN,73));
        ulong mineDecoyCursor=decoyMatch.EventBatch(decoyOpponent,0).LatestEventId;
        float mineDecoyRemaining=decoyMatch.Snapshot().Decoys
            .Single(x=>x.EntityId==mineDecoyBefore.EntityId).Health;
        int lethalMineDecoyHits=decoyMatch.ApplyLandMineDecoyExplosion(decoyOpponent,mineDecoyPosition,
            mineDecoyRemaining+1,74);
        Check(lethalMineDecoyHits>0&&
              decoyMatch.Snapshot().Decoys.All(x=>x.EntityId!=mineDecoyBefore.EntityId)&&
              decoyMatch.DroneTargetSnapshot().All(x=>x.Id!="decoy:"+mineDecoyBefore.EntityId)&&
              decoyMatch.EventBatch(decoyOpponent,mineDecoyCursor).Events.Any(x=>
                  x.Kind==MatchEventKind.DecoyDestroyed&&x.ProjectileId==mineDecoyBefore.EntityId&&
                  x.Reason=="land-mine:74"),
            "lethal Land Mine blast releases Decoy collision authority and publishes its destruction event");
        var landMineManifest=decoyManifest with {MatchId="land-mine-match",
            Players=decoyManifest.Players.Select(p=>p with {ShieldLevel=0}).ToArray()};
        var landMineMatch=new MatchEngine(landMineManifest,content:content,armyChoice:_=>0);
        landMineMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardLandmine"],[],[0],[133],[-1]),
            new(decoyOpponent,[],[],[0],[-1],[-1])]);
        landMineMatch.Admit(decoyPlayer);landMineMatch.Admit(decoyOpponent);
        Check(landMineMatch.Command(decoyPlayer,new(){CommandId=1,SelectCards=new SelectCardsCommand
              {CardIds={"CardLandmine"},NormalUpgradeIndexes={0},SpecialUpgradeIndexes={133},EliteUpgradeIndexes={-1}}}).Code=="cards-selected"&&
              landMineMatch.Command(decoyOpponent,new(){CommandId=1,SelectCards=new SelectCardsCommand
              {NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
              "Land Mine selection binds the trusted card before battle start");
        landMineMatch.Command(decoyPlayer,new(){CommandId=2,Ready=new(){ManifestHash=landMineMatch.ManifestHash}});
        landMineMatch.Command(decoyOpponent,new(){CommandId=2,Ready=new(){ManifestHash=landMineMatch.ManifestHash}});
        landMineMatch.Advance(60);
        string liveLandMineRequest=new string('6',32);
        var landMineReply=landMineMatch.Command(decoyPlayer,new(){CommandId=3,
            UseLandMine=new(){RequestId=liveLandMineRequest}});
        float expectedLandMineDamage=content.LandMines.Damage(22,content.BarrelPolicy.MaxDisplayLevel);
        Check(landMineReply.Code=="land-mine-spawned"&&landMineReply.Snapshot.LandMines.Count==3&&
              landMineReply.Snapshot.LandMines.All(x=>x.OwnerPlayerId==decoyPlayer&&x.OwnerFraction==1&&
                  x.RequestId==liveLandMineRequest&&Math.Abs(x.Damage-expectedLandMineDamage)<.001f)&&
              landMineReply.Snapshot.LandMines.Select(x=>x.HidingComponentFileId).Distinct().Count()==3&&
              landMineReply.Snapshot.LandMines.All(x=>content.LandMines.ForMap(park)
                  .Single(s=>s.ComponentFileId==x.HidingComponentFileId).Fraction==2),
              "live authenticated Land Mine activation atomically projects three level-scaled opposing placements");
        Check(landMineMatch.Command(decoyPlayer,new(){CommandId=4,
                  UseLandMine=new(){RequestId=liveLandMineRequest}}).Code=="land-mine-replayed"&&
              landMineMatch.Command(decoyPlayer,new(){CommandId=5,
                  UseLandMine=new(){RequestId=new string('5',32)}}).Code=="land-mine-unavailable"&&
              landMineMatch.Snapshot().LandMines.Count==3&&landMineMatch.Snapshot().CardActivations==1,
              "Land Mine request replay creates no duplicate and exhausted inventory cannot create partial state");
        var beforeMineTrigger=landMineMatch.Snapshot();
        var mineVictimBefore=beforeMineTrigger.Players.Single(x=>x.PlayerId==decoyOpponent);
        var mineShieldBefore=beforeMineTrigger.Shields.Single(x=>x.CoverIndex==coverTwo.SourceIndex);
        var triggerPosition=new Vector3(mineVictimBefore.PositionX,mineVictimBefore.PositionY,mineVictimBefore.PositionZ);
        Check(landMineMatch.TryRegisterLandMine(new string('4',32),decoyPlayer,triggerPosition,25),
            "host-only Land Mine simulation seed accepts a bounded authoritative position");
        landMineMatch.Advance(61);
        var afterMineTrigger=landMineMatch.Snapshot();
        var mineVictimAfter=afterMineTrigger.Players.Single(x=>x.PlayerId==decoyOpponent);
        var mineShieldAfter=afterMineTrigger.Shields.Single(x=>x.CoverIndex==coverTwo.SourceIndex);
        Check(afterMineTrigger.LandMines.Count==3&&mineVictimAfter.Health<mineVictimBefore.Health&&
              mineVictimAfter.DamageRevision==mineVictimBefore.DamageRevision+1&&
              mineVictimAfter.ConfirmedPlayerHits==mineVictimBefore.ConfirmedPlayerHits&&
              afterMineTrigger.Players.Single(x=>x.PlayerId==decoyPlayer).ConfirmedPlayerHits==1,
              "authoritative tick consumes a source-box Land Mine and applies host explosion damage once");
        Check(mineShieldAfter.Health<mineShieldBefore.Health&&
              mineShieldAfter.Revision>mineShieldBefore.Revision,
              "Land Mine blast mutates the nearby recovered shield through host explosion authority");
        var snowMineMap=content.Maps.Single(m=>m.Source.EndsWith("Snow_Multiplayer.unity",StringComparison.Ordinal));
        var snowVictimCover=snowMineMap.Covers.Single(c=>c.SourceIndex==2&&c.Fraction==1);
        var snowBarrelCover=snowMineMap.Covers.Single(c=>c.SourceIndex==3&&c.Fraction==1);
        var snowOwnerCover=snowMineMap.Covers.First(c=>c.Main&&c.Fraction==2);
        var snowMineManifest=landMineManifest with {MatchId="snow-mine-barrel",MapId="Snow_Multiplayer",
            MapRevision=snowMineMap.SourceHash,Players=[
                landMineManifest.Players[0] with {StartCover=snowVictimCover.SourceIndex},
                landMineManifest.Players[1] with {StartCover=snowOwnerCover.SourceIndex}]};
        var snowMineMatch=new MatchEngine(snowMineManifest,content:content,armyChoice:_=>0);
        snowMineMatch.Admit(decoyPlayer);snowMineMatch.Admit(decoyOpponent);
        snowMineMatch.Command(decoyPlayer,new(){CommandId=1,Ready=new(){ManifestHash=snowMineMatch.ManifestHash}});
        snowMineMatch.Command(decoyOpponent,new(){CommandId=1,Ready=new(){ManifestHash=snowMineMatch.ManifestHash}});
        snowMineMatch.Advance(60);
        Check(snowMineMatch.Command(decoyPlayer,new(){CommandId=2,MoveCover=new(){Direction=1}}).Code=="moving",
            "Snow player takes source cover path toward barrel contact");
        for(ulong snowTick=61;snowTick<=180;snowTick++)snowMineMatch.Advance(snowTick);
        var snowBarrelBefore=snowMineMatch.BarrelState.Single(b=>b.ColliderIndex==182);
        var snowBarrelCollider=snowMineMap.DynamicColliders.Single(c=>c.ColliderIndex==182);
        var snowVictim=snowMineMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyPlayer);
        var snowVictimPosition=new Vector3(snowVictim.PositionX,snowVictim.PositionY,snowVictim.PositionZ);
        Check(Vector3.Distance(snowVictimPosition,snowBarrelCover.Position)<.25f,
            "Snow player reaches the source cover adjacent to the barrel");
        var towardBarrel=Vector3.Normalize(snowBarrelCollider.TransformPosition-snowVictimPosition);
        var snowMinePosition=snowVictimPosition+towardBarrel*.15f;
        ulong snowMineEventCursor=snowMineMatch.EventBatch(decoyOpponent,0).LatestEventId;
        Check(snowMineMatch.TryRegisterLandMine(new string('3',32),decoyOpponent,snowMinePosition,10),
            "host-only Snow Land Mine seed binds source scene barrel contact");
        ulong snowMineId=snowMineMatch.Snapshot().LandMines.Single().EntityId;
        snowMineMatch.Advance(181);
        var snowBarrelAfter=snowMineMatch.BarrelState.Single(b=>b.ColliderIndex==182);
        var firstMineEvents=snowMineMatch.EventBatch(decoyOpponent,snowMineEventCursor);
        var nextMineEvents=snowMineMatch.EventBatch(decoyOpponent,firstMineEvents.Events.Last().EventId);
        Check(Math.Abs(snowBarrelAfter.Health-(snowBarrelBefore.Health-10))<.001f&&
              snowBarrelAfter.Revision>snowBarrelBefore.Revision&&
              snowMineMatch.Snapshot().LandMines.Count==0&&
              nextMineEvents.Events.Any(e=>
                  e.Kind==MatchEventKind.BarrelDamaged&&e.ProjectileId==snowMineId&&
                  e.BarrelColliderIndex==182),
              "player-triggered Land Mine damages a live Snow barrel through ordered chain authority");
        var heavyTurretManifest=decoyManifest with {MatchId="heavy-turret-match",SceneMasterPlayerId=decoyPlayer,
            Players=decoyManifest.Players.Select(p=>p with {ShieldLevel=0}).ToArray()};
        var deployedDroneManifest=armyManifest with {MatchId="deployed-drone-special",Players=[
            armyManifest.Players[0] with {EquippedArmyUnitIds=["ID_UNIT-DRONE"],
                ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[96],ArmyEliteUpgradeIndexes=[-1],ArmyShotSpeedCoefficients=[2]},
            armyManifest.Players[1] with {ArmyShotSpeedCoefficients=[1]}]};
        var assaultHelicopterManifest = armyManifest with
        {
            MatchId = "deployed-assault-helicopter-route",
            Players = [armyManifest.Players[0] with
            {
                EquippedArmyUnitIds = ["ID_UNIT-ASSAULTHELI"],
                ArmyNormalUpgradeIndexes = [0],
                ArmySpecialUpgradeIndexes = [-1],
                ArmyEliteUpgradeIndexes = [-1],
                ArmySpeedCoefficients = [1]
            }, armyManifest.Players[1]]
        };
        content.ValidateAllocation(assaultHelicopterManifest);
        var assaultHelicopterMatch = new MatchEngine(assaultHelicopterManifest,
            content: content, armyChoice: _ => 0, combatRandom: () => 0.5f);
        assaultHelicopterMatch.Admit(decoyPlayer);
        assaultHelicopterMatch.Admit(decoyOpponent);
        assaultHelicopterMatch.Command(decoyPlayer, new() { CommandId = 1,
            Ready = new() { ManifestHash = assaultHelicopterMatch.ManifestHash } });
        assaultHelicopterMatch.Command(decoyOpponent, new() { CommandId = 1,
            Ready = new() { ManifestHash = assaultHelicopterMatch.ManifestHash } });
        assaultHelicopterMatch.Advance(60);
        int assaultHelicopterOption = assaultHelicopterMatch.ArmyBatch(decoyPlayer).OptionIndexes[0];
        Check(assaultHelicopterMatch.Command(decoyPlayer, new() { CommandId = 2,
            DeployArmy = new() { OptionIndex = assaultHelicopterOption } }).Code == "army-deploying",
            "normal Assault Helicopter deployment accepts its trusted source route");
        assaultHelicopterMatch.Advance(61);
        var assaultHelicopterSpawn = assaultHelicopterMatch.ArmyEntityBatch(decoyPlayer, 0, 0)
            .Entities.Single(entity => entity.UnitId == "ID_UNIT-ASSAULTHELI");
        Check(assaultHelicopterSpawn.AssaultGlassMaxHealth > 0 &&
              assaultHelicopterSpawn.AssaultGlassHealth == assaultHelicopterSpawn.AssaultGlassMaxHealth &&
              War.Client.MatchConnection.ValidAssaultGlass(assaultHelicopterSpawn),
            "normal Assault Helicopter spawn publishes a separate full glass health record");
        var forgedGlass = assaultHelicopterSpawn.Clone();
        forgedGlass.AssaultGlassHealth = forgedGlass.AssaultGlassMaxHealth + 1f;
        Check(!War.Client.MatchConnection.ValidAssaultGlass(forgedGlass),
            "replacement SDK rejects glass health greater than its host maximum");
        var missingGlass = assaultHelicopterSpawn.Clone();
        missingGlass.AssaultGlassMaxHealth = 0;
        missingGlass.AssaultGlassHealth = 0;
        Check(!War.Client.MatchConnection.ValidAssaultGlass(missingGlass),
            "replacement SDK rejects an Assault Helicopter without glass authority");
        var missingRotation = assaultHelicopterSpawn.Clone();
        missingRotation.AssaultRotation = null;
        Check(!War.Client.MatchConnection.ValidAssaultRotation(missingRotation),
            "replacement SDK rejects an Assault Helicopter without a host root pose");
        Check(assaultHelicopterMatch.AssaultHelicopterShot(assaultHelicopterSpawn.EntityKey) ==
              assaultHelicopterShot,
            "normal Assault Helicopter deployment binds selected source firing stats to its entity");
        Vector3 assaultSpawnPosition = new(assaultHelicopterSpawn.X,
            assaultHelicopterSpawn.Y, assaultHelicopterSpawn.Z);
        for (ulong routeTick = 62; routeTick <= 100; routeTick++)
            assaultHelicopterMatch.Advance(routeTick);
        var movingAssaultHelicopter = assaultHelicopterMatch.ArmyEntityBatch(decoyPlayer, 0, 0)
            .Entities.Single(entity => entity.EntityKey == assaultHelicopterSpawn.EntityKey);
        Vector3 assaultRoutePosition = new(movingAssaultHelicopter.X,
            movingAssaultHelicopter.Y, movingAssaultHelicopter.Z);
        Check(Vector3.Distance(assaultSpawnPosition, assaultRoutePosition) > 0.1f &&
              movingAssaultHelicopter.PositionTick == 100 && !assaultHelicopterMatch.Terminal,
            "deployed Assault Helicopter follows its reserved route on normal host ticks");
        var assaultRotation = assaultHelicopterMatch.AssaultHelicopterRotation(
            assaultHelicopterSpawn.EntityKey);
        Check(assaultRotation.HasValue &&
              Math.Abs(assaultRotation.Value.LengthSquared() - 1) < 0.001f &&
              Quaternion.Dot(assaultRotation.Value, Quaternion.Identity) < 0.999f &&
              movingAssaultHelicopter.AssaultRotation is { } publishedAssaultRotation &&
              Math.Abs(Quaternion.Dot(assaultRotation.Value,
                  new Quaternion(publishedAssaultRotation.X,publishedAssaultRotation.Y,
                      publishedAssaultRotation.Z,publishedAssaultRotation.W))) > .99999f,
            "normal Assault Helicopter movement publishes its source-based root orientation");
        var liveAssaultBody = assaultHelicopterMatch.GroundVehicleShotTargets(decoyOpponent)
            .Single(target => target.EntityId == assaultHelicopterSpawn.EntityKey &&
                target.PartComponentFileId == AssaultHelicopterBoxColliderCatalog.ColliderFileId);
        Check(liveAssaultBody.Layer == 27 && liveAssaultBody.HelicopterBody &&
              Vector3.Distance(liveAssaultBody.Hitbox.Center, assaultRoutePosition) < 1f,
            "opposing projectiles see the source body box at the live Assault Helicopter pose");
        var liveAssaultMeshes = assaultHelicopterMatch.GroundVehicleShotTargets(decoyOpponent)
            .Where(target => target.EntityId == assaultHelicopterSpawn.EntityKey &&
                target.HelicopterBody && target.Hitbox.Kind == PlayerHitboxKind.Mesh).ToArray();
        Check(liveAssaultMeshes.Length == 5 &&
              liveAssaultMeshes.All(target => target.Layer == 27 && target.HelicopterBody),
            "all assigned body meshes follow the deployed Assault Helicopter");
        var liveFrontGlass = assaultHelicopterMatch.GroundVehicleShotTargets(decoyOpponent)
            .Single(target => target.EntityId == assaultHelicopterSpawn.EntityKey &&
                target.PartComponentFileId == 6468680);
        Check(liveFrontGlass.AssaultGlass && liveFrontGlass.Layer == 8 &&
              liveFrontGlass.Hitbox.Kind == PlayerHitboxKind.Mesh,
            "front glass retains its separate source layer and damage owner");
        using (var frontReference = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-air-unit-unity-geometry.json"))))
        {
            var frontSource = frontReference.RootElement.GetProperty("meshes")
                .GetProperty("799a7c85c474ee0449daf0e57600399c:4300000");
            var sourceVertices = frontSource.GetProperty("vertices").EnumerateArray()
                .Select(point => new Vector3(point[0].GetSingle(), point[1].GetSingle(),
                    point[2].GetSingle())).ToArray();
            var sourceTriangles = frontSource.GetProperty("triangles").EnumerateArray()
                .Select(index => index.GetInt32()).ToArray();
            Vector3 boundsCenter = (sourceVertices.Aggregate(Vector3.Min) +
                sourceVertices.Aggregate(Vector3.Max)) / 2f;
            Vector3 meshOrigin = liveFrontGlass.Hitbox.Center -
                Vector3.Transform(boundsCenter, liveFrontGlass.Hitbox.Rotation);
            bool glassRayFound = false;
            for (int triangleIndex = 0; triangleIndex < sourceTriangles.Length; triangleIndex += 3)
            {
                Vector3 a = sourceVertices[sourceTriangles[triangleIndex]];
                Vector3 b = sourceVertices[sourceTriangles[triangleIndex + 1]];
                Vector3 c = sourceVertices[sourceTriangles[triangleIndex + 2]];
                Vector3 localNormal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
                Vector3 point = meshOrigin + Vector3.Transform((a + b + c) / 3f,
                    liveFrontGlass.Hitbox.Rotation);
                Vector3 frontNormal = Vector3.Transform(localNormal, liveFrontGlass.Hitbox.Rotation);
                foreach (int side in new[] { -1, 1 })
                {
                    var glassTrace = assaultHelicopterMatch.TraceHeavyTurretShot(decoyOpponent,
                        point + frontNormal * side * .2f, -frontNormal * side, .4f);
                    if (glassTrace?.DynamicEntityId == assaultHelicopterSpawn.EntityKey &&
                        glassTrace.DynamicPartId ==
                            AssaultHelicopterMeshColliderCatalog.FrontGlassColliderFileId)
                    {
                        glassRayFound = true;
                        break;
                    }
                }
                if (glassRayFound) break;
            }
            Check(glassRayFound,
                "live match ray resolves the separate front glass collider before the aircraft body");
        }
        var assaultBodyTrace = assaultHelicopterMatch.TraceHeavyTurretShot(decoyOpponent,
            liveAssaultBody.Hitbox.Center + Vector3.UnitY,
            -Vector3.UnitY, 2f);
        Check(assaultBodyTrace is { DynamicEntityId: ulong assaultHitEntity,
                  DynamicPartId: int assaultHitPart } &&
              assaultHitEntity == assaultHelicopterSpawn.EntityKey &&
              (assaultHitPart == AssaultHelicopterBoxColliderCatalog.ColliderFileId ||
               content.AssaultHelicopterMeshColliders.HasCollider(assaultHitPart)),
            "normal projectile ray identifies the deployed Assault Helicopter body");
        var meshDirections = new[] { Vector3.UnitX, -Vector3.UnitX,
            Vector3.UnitY, -Vector3.UnitY, Vector3.UnitZ, -Vector3.UnitZ };
        var liveMeshTrace = liveAssaultMeshes.SelectMany(mesh => meshDirections.Select(axis =>
            assaultHelicopterMatch.TraceHeavyTurretShot(decoyOpponent,
                mesh.Hitbox.Center + axis * 2f, -axis, 4f)))
            .FirstOrDefault(hit => hit is { DynamicEntityId: ulong entityId,
                DynamicPartId: int partId } &&
                entityId == assaultHelicopterSpawn.EntityKey &&
                content.AssaultHelicopterMeshColliders.HasCollider(partId));
        Check(liveMeshTrace?.DynamicPartId is int liveMeshPart &&
              content.AssaultHelicopterMeshColliders.HasCollider(liveMeshPart),
            "normal projectile ray resolves a source triangle body mesh");
        float assaultHealthBeforeHit = assaultHelicopterMatch.ArmyHealth(
            assaultHelicopterSpawn.EntityKey)!.Value;
        assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,
            assaultHelicopterSpawn.EntityKey,
            AssaultHelicopterBoxColliderCatalog.ColliderFileId, 10f);
        Check(assaultHelicopterMatch.ArmyHealth(assaultHelicopterSpawn.EntityKey) ==
                  assaultHealthBeforeHit - 10f,
            "source body box routes a verified opposing hit to Assault Helicopter vitality");
        assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,
            assaultHelicopterSpawn.EntityKey, liveMeshTrace!.DynamicPartId!.Value, 7f);
        Check(assaultHelicopterMatch.ArmyHealth(assaultHelicopterSpawn.EntityKey) ==
                  assaultHealthBeforeHit - 17f,
            "source triangle mesh routes opposing damage to the same body vitality");
        assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,
            assaultHelicopterSpawn.EntityKey, 6468680, 20f);
        Check(assaultHelicopterMatch.AssaultGlassHealth(assaultHelicopterSpawn.EntityKey) ==
                  assaultHelicopterSpawn.AssaultGlassMaxHealth - 20f &&
              assaultHelicopterMatch.ArmyHealth(assaultHelicopterSpawn.EntityKey) ==
                  assaultHealthBeforeHit - 17f,
            "front glass damage leaves the aircraft body health unchanged");
        assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,
            assaultHelicopterSpawn.EntityKey, 6468680, 10_000f);
        var brokenGlassRow = assaultHelicopterMatch.ArmyEntityBatch(decoyPlayer, 0, 0)
            .Entities.Single(entity => entity.EntityKey == assaultHelicopterSpawn.EntityKey);
        Check(brokenGlassRow.AssaultGlassHealth == 0 &&
              assaultHelicopterMatch.GroundVehicleShotTargets(decoyOpponent)
                  .All(target => target.EntityId != assaultHelicopterSpawn.EntityKey ||
                      target.PartComponentFileId != 6468680),
            "lethal glass damage publishes broken state and removes its live front collider");
        assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,
            assaultHelicopterSpawn.EntityKey, 6468680, 5f);
        Check(assaultHelicopterMatch.AssaultGlassHealth(assaultHelicopterSpawn.EntityKey) == 0 &&
              assaultHelicopterMatch.ArmyHealth(assaultHelicopterSpawn.EntityKey) ==
                  assaultHealthBeforeHit - 17f,
            "a broken glass part cannot reopen or redirect later damage to the body");
        Reject(() => assaultHelicopterMatch.ApplyArmyBodyProjectileImpact(decoyPlayer,
            assaultHelicopterSpawn.EntityKey,
            AssaultHelicopterBoxColliderCatalog.ColliderFileId, 10f));
        var frontGlassFireManifest = assaultHelicopterManifest with
        {
            MatchId = "player-projectile-assault-front-glass",
            DurationSeconds = 180,
            IdleSeconds = 120
        };
        var frontGlassFireMatch = new MatchEngine(frontGlassFireManifest,
            content: content, armyChoice: _ => 0, combatRandom: () => .5f);
        frontGlassFireMatch.Admit(decoyPlayer);
        frontGlassFireMatch.Admit(decoyOpponent);
        frontGlassFireMatch.Command(decoyPlayer, new() { CommandId = 1,
            Ready = new() { ManifestHash = frontGlassFireMatch.ManifestHash } });
        frontGlassFireMatch.Command(decoyOpponent, new() { CommandId = 1,
            Ready = new() { ManifestHash = frontGlassFireMatch.ManifestHash } });
        frontGlassFireMatch.Advance(60);
        int glassFireOption = frontGlassFireMatch.ArmyBatch(decoyPlayer).OptionIndexes[0];
        frontGlassFireMatch.Command(decoyPlayer, new() { CommandId = 2,
            DeployArmy = new() { OptionIndex = glassFireOption } });
        frontGlassFireMatch.Advance(61);
        var glassFireAircraft = frontGlassFireMatch.ArmyEntityBatch(decoyOpponent, 0, 0)
            .Entities.Single(entity => entity.UnitId == "ID_UNIT-ASSAULTHELI");
        float glassBeforeFire = glassFireAircraft.AssaultGlassHealth;
        ulong glassFireCommand = 2;
        bool playerFireDamagedGlass = false;
        bool bodyUnaffectedByGlassHit = false;
        float? bodyBeforeGlassImpact = null;
        for (ulong fireTick = 62; fireTick < 900 && !frontGlassFireMatch.Terminal; fireTick++)
        {
            if (fireTick % 12 == 0)
            {
                var liveGlass = frontGlassFireMatch.GroundVehicleShotTargets(decoyOpponent)
                    .FirstOrDefault(target => target.EntityId == glassFireAircraft.EntityKey &&
                        target.AssaultGlass);
                if (liveGlass == null) break;
                Vector3 aim = liveGlass.Hitbox.Center;
                frontGlassFireMatch.Command(decoyOpponent, new() { CommandId = glassFireCommand++,
                    Fire = new() { TargetX = aim.X, TargetY = aim.Y, TargetZ = aim.Z } });
            }
            float? bodyBeforeAdvance = frontGlassFireMatch.ArmyHealth(glassFireAircraft.EntityKey);
            frontGlassFireMatch.Advance(fireTick);
            if (frontGlassFireMatch.AssaultGlassHealth(glassFireAircraft.EntityKey) is float health &&
                health < glassBeforeFire)
            {
                playerFireDamagedGlass = true;
                bodyBeforeGlassImpact = bodyBeforeAdvance;
                bodyUnaffectedByGlassHit =
                    frontGlassFireMatch.ArmyHealth(glassFireAircraft.EntityKey) == bodyBeforeAdvance;
                break;
            }
        }
        Check(playerFireDamagedGlass && bodyUnaffectedByGlassHit,
            $"admitted player Fire reaches front glass without damaging aircraft body: " +
            $"glass={frontGlassFireMatch.AssaultGlassHealth(glassFireAircraft.EntityKey)}/{glassBeforeFire}, " +
            $"body={frontGlassFireMatch.ArmyHealth(glassFireAircraft.EntityKey)}/{bodyBeforeGlassImpact}, " +
            $"shots={frontGlassFireMatch.Snapshot().Players.Single(p => p.PlayerId == decoyOpponent).ShotsFired}, " +
            $"terminal={frontGlassFireMatch.Terminal}");
        var targetClock = new AssaultHelicopterTargetState(0);
        var targetDecoys = new[]
        {
            new DecoyMatchEntity(71, Guid.NewGuid().ToString("N"), decoyOpponent,
                2, 1, new Vector3(1, 0, 2), Vector3.UnitZ, 100, 100),
            new DecoyMatchEntity(72, Guid.NewGuid().ToString("N"), decoyOpponent,
                2, 2, new Vector3(3, 0, 4), Vector3.UnitZ, 100, 100)
        };
        targetClock.Advance(2f, assaultHelicopterShot, targetDecoys, decoyOpponent,
            _ => 1, () => 0f);
        Check(targetClock.TargetDecoyId == null && targetClock.TargetPlayerId == null,
            "Assault Helicopter waits strictly past its two-second first target deadline");
        targetClock.Advance(2.01f, assaultHelicopterShot, targetDecoys, decoyOpponent,
            _ => 1, () => 0f);
        Check(targetClock.TargetDecoyId == 72 && targetClock.TargetPlayerId == null &&
              targetClock.LookTarget(targetDecoys, decoyOpponent, Vector3.Zero) ==
                  targetDecoys[1].Position,
            "Assault Helicopter chooses an opposing Decoy root before the player");
        Check(targetClock.LookTarget([], decoyOpponent, Vector3.Zero) == null,
            "a destroyed Decoy does not silently retarget before the next selection");
        targetClock.Advance(targetClock.NextSelectionTime + .01f, assaultHelicopterShot,
            [], decoyOpponent, _ => 0, () => 0f);
        Check(targetClock.TargetDecoyId == null && targetClock.TargetPlayerId == decoyOpponent,
            "Assault Helicopter falls back to the opposing player on its next selection");
        for (ulong routeTick = 101; routeTick <= 122; routeTick++)
            assaultHelicopterMatch.Advance(routeTick);
        Check(assaultHelicopterMatch.AssaultHelicopterTargetPlayer(
                  assaultHelicopterSpawn.EntityKey) == decoyOpponent,
            "normal Assault Helicopter ticks select the opposing player after the source deadline");
        var preparedAssaultVolley = assaultHelicopterMatch.AssaultHelicopterVolley(
            assaultHelicopterSpawn.EntityKey);
        Check(preparedAssaultVolley != null &&
              preparedAssaultVolley.SelectionTick == 122 &&
              preparedAssaultVolley.TargetChoice.First.TransformFileId > 0 &&
              preparedAssaultVolley.TargetChoice.Second.TransformFileId > 0 &&
              preparedAssaultVolley.Plan.FirstGunCount +
                  preparedAssaultVolley.Plan.SecondGunCount ==
                  assaultHelicopterShot.FireBatchSizeMin &&
              preparedAssaultVolley.FirstGunRealShots.Count ==
                  preparedAssaultVolley.Plan.FirstGunCount,
            "live Assault Helicopter selection prepares the source-split first gun before cooldown sampling");
        var firstLiveAssaultRound = assaultHelicopterMatch.AssaultHelicopterRoundIntents(
            assaultHelicopterSpawn.EntityKey);
        Check(firstLiveAssaultRound.Count == 1 &&
              firstLiveAssaultRound[0].GunIndex == 0 &&
              firstLiveAssaultRound[0].RoundIndex == 0 &&
              firstLiveAssaultRound[0].Target == preparedAssaultVolley?.FirstAimPoint &&
              firstLiveAssaultRound[0].TargetId == preparedAssaultVolley?.TargetId,
            "normal Assault Helicopter tick schedules its first source gun round");
        var firstAssaultShot = assaultHelicopterMatch.EventBatch(decoyPlayer, 0).Events
            .SingleOrDefault(row => row.Kind == MatchEventKind.AssaultHelicopterFired);
        Check(firstAssaultShot?.AssaultHelicopterShot is { GunIndex: 0 } firstGunShot &&
              firstGunShot.ArmyEntityKey == assaultHelicopterSpawn.EntityKey &&
              firstAssaultShot.TargetId == preparedAssaultVolley?.TargetId &&
              assaultHelicopterMatch.PendingAssaultHelicopterProjectiles > 0,
            "first Assault Helicopter gun publishes a distinct shot and host flight");
        for (ulong routeTick = 123; routeTick <= 126; routeTick++)
            assaultHelicopterMatch.Advance(routeTick);
        var secondAssaultVolley = assaultHelicopterMatch.AssaultHelicopterVolley(
            assaultHelicopterSpawn.EntityKey);
        Check(secondAssaultVolley?.SecondGunRealShots?.Count ==
                  secondAssaultVolley?.Plan.SecondGunCount &&
              secondAssaultVolley?.SelectionTick == 122,
            "normal Assault Helicopter ticks prepare the second gun after half-cadence delay");
        var secondLiveAssaultRound = assaultHelicopterMatch.AssaultHelicopterRoundIntents(
            assaultHelicopterSpawn.EntityKey);
        Check(secondLiveAssaultRound.Count == 1 &&
              secondLiveAssaultRound[0].GunIndex == 1 &&
              secondLiveAssaultRound[0].RoundIndex == 0 &&
              secondLiveAssaultRound[0].Target == secondAssaultVolley?.SecondAimPoint &&
              secondLiveAssaultRound[0].TargetId == secondAssaultVolley?.TargetId,
            "normal Assault Helicopter tick schedules its delayed second source gun round");
        Check(assaultHelicopterMatch.EventBatch(decoyPlayer, 0).Events.Any(row =>
                  row.Kind == MatchEventKind.AssaultHelicopterFired &&
                  row.AssaultHelicopterShot?.GunIndex == 1),
            "second Assault Helicopter gun publishes its own muzzle identity");
        var mineTarget = assaultHelicopterMatch.ArmyEntityBatch(decoyPlayer, 0, 0)
            .Entities.Single(entity => entity.EntityKey == assaultHelicopterSpawn.EntityKey);
        var mineRotation = mineTarget.AssaultRotation!;
        var mineBody = content.AssaultHelicopterBoxCollider.Place(
            new Vector3(mineTarget.X, mineTarget.Y, mineTarget.Z),
            new Quaternion(mineRotation.X, mineRotation.Y, mineRotation.Z, mineRotation.W));
        float bodyBeforeMine = assaultHelicopterMatch.ArmyHealth(mineTarget.EntityKey)!.Value;
        float glassBeforeMine = assaultHelicopterMatch.AssaultGlassHealth(mineTarget.EntityKey)!.Value;
        Check(assaultHelicopterMatch.ApplyLandMineAssaultHelicopterBodyExplosion(
                  decoyOpponent, mineBody.Center, 10f) == 1 &&
              Math.Abs(assaultHelicopterMatch.ArmyHealth(mineTarget.EntityKey)!.Value -
                  (bodyBeforeMine - 10f)) < .001f &&
              assaultHelicopterMatch.AssaultGlassHealth(mineTarget.EntityKey) == glassBeforeMine,
            "opposing Land Mine damages one Assault Helicopter body owner without using glass health");
        float bodyBeforeFriendlyMine = assaultHelicopterMatch.ArmyHealth(mineTarget.EntityKey)!.Value;
        Check(assaultHelicopterMatch.ApplyLandMineAssaultHelicopterBodyExplosion(
                  decoyPlayer, mineBody.Center, 10f) == 1 &&
              Math.Abs(assaultHelicopterMatch.ArmyHealth(mineTarget.EntityKey)!.Value -
                  (bodyBeforeFriendlyMine - 5f)) < .001f,
            "friendly Land Mine applies the source half-damage coefficient to the aircraft body");
        Reject(() => assaultHelicopterMatch.ApplyLandMineAssaultHelicopterBodyExplosion(
            decoyOpponent, mineBody.Center, float.NaN));
        ulong assaultTriggerCursor=assaultHelicopterMatch.EventBatch(decoyOpponent,0).LatestEventId;
        Check(assaultHelicopterMatch.TryRegisterLandMine(new string('6',32),decoyOpponent,
                  mineBody.Center,10f),
            "host-only mine placement binds the current Assault Helicopter body part");
        ulong assaultTriggerMineId=assaultHelicopterMatch.Snapshot().LandMines.Single().EntityId;
        assaultHelicopterMatch.Advance(127);
        Check(assaultHelicopterMatch.Snapshot().LandMines.Count==0&&
              assaultHelicopterMatch.EventBatch(decoyOpponent,assaultTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==assaultTriggerMineId&&
                  row.Reason=="air-trigger:"+mineTarget.EntityKey),
            "a non-metal Assault Helicopter body child triggers a mine on the normal host tick");

        var mineGlassManifest = assaultHelicopterManifest with
        {
            MatchId = "assault-helicopter-mine-glass"
        };
        var mineGlassMatch = new MatchEngine(mineGlassManifest, content: content,
            armyChoice: _ => 0);
        mineGlassMatch.Admit(decoyPlayer);
        mineGlassMatch.Admit(decoyOpponent);
        mineGlassMatch.Command(decoyPlayer, new() { CommandId = 1,
            Ready = new() { ManifestHash = mineGlassMatch.ManifestHash } });
        mineGlassMatch.Command(decoyOpponent, new() { CommandId = 1,
            Ready = new() { ManifestHash = mineGlassMatch.ManifestHash } });
        mineGlassMatch.Advance(60);
        int mineGlassOption = mineGlassMatch.ArmyBatch(decoyPlayer).OptionIndexes[0];
        Check(mineGlassMatch.Command(decoyPlayer, new() { CommandId = 2,
            DeployArmy = new() { OptionIndex = mineGlassOption } }).Code == "army-deploying",
            "separate Assault Helicopter mine fixture uses its trusted deployment option");
        mineGlassMatch.Advance(61);
        var mineGlassAircraft = mineGlassMatch.ArmyEntityBatch(decoyPlayer, 0, 0)
            .Entities.Single(row => row.UnitId == "ID_UNIT-ASSAULTHELI");
        var glassRotation = mineGlassAircraft.AssaultRotation!;
        var glassCollider = content.AssaultHelicopterMeshColliders.PlaceFrontGlass(
            new(mineGlassAircraft.X, mineGlassAircraft.Y, mineGlassAircraft.Z),
            new(glassRotation.X, glassRotation.Y, glassRotation.Z, glassRotation.W));
        float mineGlassBodyHealth = mineGlassMatch.ArmyHealth(mineGlassAircraft.EntityKey)!.Value;
        float mineGlassHealth = mineGlassAircraft.AssaultGlassHealth;
        Check(mineGlassMatch.ApplyLandMineAssaultHelicopterGlassExplosion(
                  decoyOpponent, glassCollider.Hitbox.Center, 10f) == 1 &&
              Math.Abs(mineGlassMatch.AssaultGlassHealth(mineGlassAircraft.EntityKey)!.Value -
                  (mineGlassHealth - 10f)) < .001f &&
              mineGlassMatch.ArmyHealth(mineGlassAircraft.EntityKey) == mineGlassBodyHealth,
            "opposing Land Mine blast damages the front glass owner without using body health");
        Check(mineGlassMatch.ApplyLandMineAssaultHelicopterGlassExplosion(
                  decoyPlayer, glassCollider.Hitbox.Center, 10f) == 1 &&
              Math.Abs(mineGlassMatch.AssaultGlassHealth(mineGlassAircraft.EntityKey)!.Value -
                  (mineGlassHealth - 15f)) < .001f,
            "friendly Land Mine blast applies the source half-damage coefficient to glass");
        Check(mineGlassMatch.ApplyLandMineAssaultHelicopterGlassExplosion(
                  decoyOpponent, glassCollider.Hitbox.Center, 10_000f) == 1 &&
              mineGlassMatch.ApplyLandMineAssaultHelicopterGlassExplosion(
                  decoyOpponent, glassCollider.Hitbox.Center, 10f) == 0 &&
              mineGlassMatch.AssaultGlassHealth(mineGlassAircraft.EntityKey) == 0,
            "broken Assault Helicopter glass cannot be damaged again by a Land Mine");
        Reject(() => mineGlassMatch.ApplyLandMineAssaultHelicopterGlassExplosion(
            decoyOpponent, glassCollider.Hitbox.Center, float.NaN));
        var deployedDroneMatch=new MatchEngine(deployedDroneManifest,content:content,armyChoice:_=>0);
        deployedDroneMatch.Admit(decoyPlayer);deployedDroneMatch.Admit(decoyOpponent);
        deployedDroneMatch.Command(decoyPlayer,new(){CommandId=1,Ready=new(){ManifestHash=deployedDroneMatch.ManifestHash}});
        deployedDroneMatch.Command(decoyOpponent,new(){CommandId=1,Ready=new(){ManifestHash=deployedDroneMatch.ManifestHash}});
        deployedDroneMatch.Advance(60);
        deployedDroneMatch.ArmyBatch(decoyPlayer);
        Check(deployedDroneMatch.Command(decoyPlayer,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=9}}).Code=="army-deploying","normal army path accepts trusted Drone deployment");
        deployedDroneMatch.Advance(61);
        var deployedDrone=deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Single();
        Check(deployedDroneMatch.ObserveDroneAttack(deployedDrone.EntityKey)==null,
            "live Drone attack observation before spawn deadline emits no intent");
        Check(deployedDroneMatch.DroneAttackDeadline(deployedDrone.EntityKey)==61f/MatchManifest.TickRate+2,
            "normal Drone attack clock binds actual deployment time plus source two seconds");
        var droneAimDetails=deployedDroneMatch.ResolveDroneShotTarget(deployedDroneMatch.DroneTargetSnapshot().Single(r=>r.Id=="army:"+deployedDrone.EntityKey));
        Check(droneAimDetails.Targets.Single() is {TransformFileId:454360,Type:1}&&
            droneAimDetails.Targets.Single().Position==new Vector3(deployedDrone.X,deployedDrone.Y,deployedDrone.Z),
            "live Drone target resolution uses verified root target transform");
        var playerAimDetails=deployedDroneMatch.ResolveDroneShotTarget(deployedDroneMatch.DroneTargetSnapshot().Single(r=>r.Id=="player:"+decoyOpponent));
        Check(playerAimDetails.IsPlayer&&playerAimDetails.Targets.Count==content.PlayerShotTargets.Gameplay.Count&&
            playerAimDetails.Velocity==Vector3.Zero,"Drone player resolution binds current source poses and zero prediction velocity");
        float droneHealth=deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)!.Value;
        Check(deployedDroneMatch.DroneShotDefinition(deployedDrone.EntityKey) is {ShotSpeed:18,ProbabilityOfRealShot:.7f},"normal Drone deployment binds trusted shot-speed perk into composed firing authority");
        var droneCollisionTargets=deployedDroneMatch.GroundVehicleShotTargets(decoyOpponent).Where(r=>r.EntityId==deployedDrone.EntityKey).ToArray();
        Check(droneCollisionTargets.Length==2&&droneCollisionTargets.Any(r=>r.PartComponentFileId==6544804&&r.Layer==27)&&droneCollisionTargets.Any(r=>r.PartComponentFileId==13511718&&r.Layer==8),"normal Drone projectile targets retain root flying and child layers");
        var shotgunDroneRoot=droneCollisionTargets.Single(x=>x.DroneRoot);
        var shotgunDroneWorld=new ShotCollisionWorld(null,
        [
            new(decoyOpponent,deployedDroneMatch.CombatPose(decoyOpponent).Collision),
            new(decoyPlayer,deployedDroneMatch.CombatPose(decoyPlayer).Collision)
        ],dynamicTargets:deployedDroneMatch.GroundVehicleShotTargets);
        var droneRootRay=shotgunDroneWorld.Raycast(decoyOpponent,
            shotgunDroneRoot.Hitbox.Center-Vector3.UnitZ*2,Vector3.UnitZ,4,1u<<27);
        Check(droneRootRay?.DynamicEntityId==deployedDrone.EntityKey&&droneRootRay.ColliderLayer==27,
            "deployed Drone bullet impact keeps its exact flying-faction collider layer");
        Check(droneRootRay?.SourceDestroyable==true,
            "deployed Drone root owns the source DestroyableObject for player bullet hit credit");
        var droneChild=droneCollisionTargets.Single(x=>!x.DroneRoot);
        var droneChildWorld=new ShotCollisionWorld(null,
        [
            new(decoyOpponent,deployedDroneMatch.CombatPose(decoyOpponent).Collision),
            new(decoyPlayer,deployedDroneMatch.CombatPose(decoyPlayer).Collision)
        ],dynamicTargets:_=>[droneChild]);
        var droneChildRay=droneChildWorld.Raycast(decoyOpponent,
            droneChild.Hitbox.Center-Vector3.UnitZ*2,Vector3.UnitZ,4,1u<<8);
        Check(droneChildRay?.DynamicEntityId==deployedDrone.EntityKey&&
              droneChildRay.ColliderLayer==8&&!droneChildRay.SourceDestroyable,
            "Drone child sphere can collide but has no same-GameObject DestroyableObject hit credit");
        var shotgunDroneOrigin=shotgunDroneRoot.Hitbox.Center-Vector3.UnitZ*2;
        var shotgunDroneOverlap=shotgunDroneWorld.OverlapEnemy(decoyOpponent,
            shotgunDroneOrigin,4,1u<<27);
        Check(shotgunDroneOverlap.Any(x=>x.MainEntityId=="drone:"+deployedDrone.EntityKey)&&
              !shotgunDroneWorld.OverlapEnemy(decoyOpponent,shotgunDroneOrigin,4,1u<<8)
                  .Any(x=>x.MainEntityId=="drone:"+deployedDrone.EntityKey),
              "deployed Drone root DestroyableObject enters shotgun overlap on its flying faction layer, not child layer eight");
        var shotgunDronePlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            shotgunDroneOrigin,shotgunDroneRoot.Hitbox.Center+Vector3.UnitX*.5f,
            shotgunDroneOverlap);
        Check(shotgunDronePlan.RealPellets.Any(x=>shotgunDroneOverlap.Any(y=>
                  y.MainEntityId=="drone:"+deployedDrone.EntityKey&&y.EntityId==x.EntityId)),
              "live Drone root schedules a real shotgun extra while its unowned child sphere cannot");
        deployedDroneMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,deployedDrone.EntityKey,13511718,10);
        Check(deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)==droneHealth,"child sphere impact cannot promote parent health damage");
        deployedDroneMatch.ApplyArmyBodyProjectileImpact(decoyOpponent,deployedDrone.EntityKey,6544804,10);
        Check(deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)==droneHealth-10,"Drone root projectile impact uses source coefficient one");
        droneHealth-=10;

        var droneSightPosition=new Vector3(deployedDrone.X,deployedDrone.Y,deployedDrone.Z);
        Check(!deployedDroneMatch.DroneCanSee(droneSightPosition-Vector3.UnitX-Vector3.UnitY*.5f,droneSightPosition+Vector3.UnitX),"live deployed Drone collider blocks source sight ray");
        for(ulong t=62;t<=211;t++)deployedDroneMatch.Advance(t);
        var movedDrone=deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Single();
        var droneTarget=deployedDroneMatch.DroneTargetSnapshot().Single(r=>r.Id=="army:"+movedDrone.EntityKey);
        Check(droneTarget.Position==new Vector3(movedDrone.X,movedDrone.Y,movedDrone.Z)&&droneTarget.Fraction==1&&droneTarget.UnitType==content.Army.Families.Single(f=>f.UnitId=="ID_UNIT-DRONE").UnitType,"live army target snapshot follows authoritative Drone flight position");
        var droneRotation=movedDrone.DroneRotation;
        Check(droneRotation!=null&&Math.Abs(droneRotation.X*droneRotation.X+droneRotation.Y*droneRotation.Y+
            droneRotation.Z*droneRotation.Z+droneRotation.W*droneRotation.W-1)<.001f,
            "deployed Drone publishes normalized source bank orientation");
        Check(Vector3.Distance(new(deployedDrone.X,deployedDrone.Y,deployedDrone.Z),
            new(movedDrone.X,movedDrone.Y,movedDrone.Z))>.1f&&movedDrone.PositionTick==211,
            "normal deployed Drone advances through its trusted source route and publishes sample tick");
        Check(!deployedDroneMatch.ArmyDroneImmortal(deployedDrone.EntityKey),"deployed Drone retains strict initial five-second deadline");
        deployedDroneMatch.Advance(212);
        var transparentDroneBatch=deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0);
        var transparentWire=MatchArmyEntityBatch.Parser.ParseFrom(
            Google.Protobuf.MessageExtensions.ToByteArray(transparentDroneBatch));
        Check(transparentWire.Entities.Single().DroneTransparent,
            "protobuf army roster preserves authoritative Drone transparency");
        Check(transparentWire.Entities.Single().DroneRotation.Equals(transparentDroneBatch.Entities.Single().DroneRotation),
            "protobuf army roster preserves authoritative Drone rotation");
        Check(deployedDroneMatch.ArmyDroneImmortal(deployedDrone.EntityKey)&&
            deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Single().DroneTransparent&&
            !deployedDroneMatch.ApplyArmyHostDamage(deployedDrone.EntityKey,droneHealth)&&
            deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)==droneHealth,
            "trusted special stage protects normal deployed Drone health against host damage");
        var immortalWorld=new ShotCollisionWorld(content.Maps.Single(m=>
            Path.GetFileNameWithoutExtension(m.Source)==deployedDroneManifest.MapId),
            [new(decoyOpponent,deployedDroneMatch.CombatPose(decoyOpponent).Collision,22,2),
             new(decoyPlayer,deployedDroneMatch.CombatPose(decoyPlayer).Collision,23,1)],
            dynamicTargets:deployedDroneMatch.GroundVehicleShotTargets);
        var immortalMuzzle=deployedDroneMatch.CombatPose(decoyOpponent)
            .Muzzle(deployedDroneManifest.Players[1].Weapon.SourceId).Position;
        var immortalRoot=deployedDroneMatch.GroundVehicleShotTargets(decoyOpponent)
            .Single(x=>x.EntityId==deployedDrone.EntityKey&&x.DroneRoot);
        var centerDirection=Vector3.Normalize(immortalRoot.Hitbox.Center-immortalMuzzle);
        var centerHit=immortalWorld.Raycast(decoyOpponent,immortalMuzzle,centerDirection,50,
            content.Bindings.BulletMask(2));
        Check(centerHit?.DynamicEntityId==deployedDrone.EntityKey&&
              centerHit.DynamicPartId==13511718&&!centerHit.SourceDestroyable,
            "player muzzle ray toward immortal Drone center first meets its non-destroyable child sphere");
        var bulletOrigin=immortalMuzzle+content.Bindings.Get(
            deployedDroneManifest.Players[1].Weapon.SourceId).ShotOffset;
        Vector3? exposedRootAim=null;
        foreach(var offset in new[]{-.8f,-.5f,-.25f,0,.25f,.5f,.8f})
        {
            var aim=immortalRoot.Hitbox.Center+new Vector3(offset,0,0);
            var direction=Vector3.Normalize(aim-bulletOrigin);
            var hit=immortalWorld.Raycast(decoyOpponent,bulletOrigin,direction,50,
                content.Bindings.BulletMask(2));
            if(hit?.DynamicEntityId==deployedDrone.EntityKey&&
               hit.DynamicPartId==6544804&&hit.SourceDestroyable)
            {exposedRootAim=aim;break;}
        }
        Check(exposedRootAim.HasValue,
            "an exposed immortal Drone root ray retains same-collider destroyable provenance");
        // Seed one controlled host flight into the private queue so this checks
        // the actual impact path without depending on a moving target or aim RNG.
        const ulong immortalProbeId=900001;
        var immortalFlight=new BulletFlight(immortalProbeId,decoyOpponent,
            new BulletFlightDefinition(10000,0,true),bulletOrigin,exposedRootAim!.Value,212,
            (from,direction,range)=>immortalWorld.Raycast(decoyOpponent,from,direction,range,
                content.Bindings.BulletMask(2)));
        var projectileField=typeof(MatchEngine).GetField("projectiles",
            System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic)
            ??throw new Exception("Host projectile queue field changed.");
        var projectileQueue=(Dictionary<ulong,PreparedProjectile>?)projectileField.GetValue(deployedDroneMatch)
            ??throw new Exception("Host projectile queue unavailable.");
        uint immortalHitsBefore=deployedDroneMatch.Snapshot().Players
            .Single(p=>p.PlayerId==decoyOpponent).ConfirmedEnemyHits;
        projectileQueue.Add(immortalProbeId,new PreparedProjectile(immortalFlight,
            new ResolvedPlayerDamage(10,CombatDamageType.Shot),
            deployedDroneManifest.Players[1].Weapon.SourceId));
        deployedDroneMatch.Advance(213);
        Check(deployedDroneMatch.ArmyDroneImmortal(deployedDrone.EntityKey)&&
              deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)==droneHealth&&
              deployedDroneMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent)
                  .ConfirmedEnemyHits==immortalHitsBefore+1,
            "controlled player flight into immortal Drone root credits contact without reducing health");
        for(ulong t=214;t<=256;t++)deployedDroneMatch.Advance(t);
        var observedDroneIntent=deployedDroneMatch.LastDroneIntent(deployedDrone.EntityKey);
        Check(deployedDroneMatch.DroneAttackDeadline(deployedDrone.EntityKey)>61f/MatchManifest.TickRate+2,
            "live host observation resolves source registry and advances attack deadline");
        Check(observedDroneIntent is {Speed:>0,Damage:>0,CheckDistance:1},
            "live Drone intent uses trusted composed projectile authority");
        Check(deployedDroneMatch.DroneLookTarget(deployedDrone.EntityKey)==
            deployedDroneMatch.DroneTargetSnapshot().Single(r=>r.Id=="player:"+decoyOpponent).Position,
            "host Drone steering tracks selected player root instead of predicted shot point");
        var dronePlayerPolicy=content.Army.PlayerDamagePolicy("ID_UNIT-DRONE");
        Check(observedDroneIntent!.PlayerDamageCoefficient==dronePlayerPolicy.PlayerDamageRatio&&
            observedDroneIntent.PlayerOvertimeDamageCoefficient==dronePlayerPolicy.OvertimePlayerDamageRatio,
            "Drone projectile retains source player and overtime damage coefficients");
        var droneDamageInput=new ResolvedPlayerDamage(observedDroneIntent.Damage,CombatDamageType.Shot,
            PlayerCoefficient:observedDroneIntent.PlayerDamageCoefficient,
            PlayerOvertimeCoefficient:observedDroneIntent.PlayerOvertimeDamageCoefficient);
        var normalDroneDamage=PlayerDamage.Resolve(new(100000),100000,droneDamageInput,false,false,1);
        var overtimeDroneDamage=PlayerDamage.Resolve(new(100000),100000,droneDamageInput with {Overtime=true},false,false,1);
        Check(Math.Abs(normalDroneDamage.Damage-observedDroneIntent.Damage*dronePlayerPolicy.PlayerDamageRatio)<.0001f&&
            Math.Abs(overtimeDroneDamage.Damage-observedDroneIntent.Damage*dronePlayerPolicy.OvertimePlayerDamageRatio)<.0001f,
            "Drone prepared player damage honors source overtime coefficient selection");
        Check(!deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Single().DroneTransparent,
            "Drone expiry clears authoritative renderer phase before death");
        Check(!deployedDroneMatch.ArmyDroneImmortal(deployedDrone.EntityKey)&&
            deployedDroneMatch.ApplyArmyHostDamage(deployedDrone.EntityKey,droneHealth)&&
            deployedDroneMatch.ArmyHealth(deployedDrone.EntityKey)==null,
            "source duration expiry permits deployed Drone death and releases special state");
        Check(deployedDroneMatch.DroneTargetSnapshot().All(r=>r.Id!="army:"+deployedDrone.EntityKey),"confirmed Drone death removes army target registry row");
        Check(deployedDroneMatch.DroneShotDefinition(deployedDrone.EntityKey)==null,"Drone death removes composed firing authority");
        Check(deployedDroneMatch.DroneAttackDeadline(deployedDrone.EntityKey)==null,"Drone death removes prepared attack lifecycle");
        deployedDroneMatch.Advance(257);
        Check(deployedDroneMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Count==0,
            "deployed Drone death releases route traversal before subsequent motion tick");
        deployedDroneMatch.Command(decoyPlayer,new(){CommandId=3,Forfeit=new()});
        Check(deployedDroneMatch.TerminalEvidenceSnapshot().Players
                  .Single(p=>p.PlayerId==decoyOpponent).ConfirmedPlayerBulletHits==1,
            "controlled immortal-root contact survives as one private terminal bullet hit");
        var droneShotManifest=deployedDroneManifest with {MatchId="player-projectile-drone",DurationSeconds=180,
            Players=[deployedDroneManifest.Players[0] with {ArmySpecialUpgradeIndexes=[-1]},deployedDroneManifest.Players[1]]};
        var droneShotMatch=new MatchEngine(droneShotManifest,content:content,armyChoice:_=>0);
        droneShotMatch.Admit(decoyPlayer);droneShotMatch.Admit(decoyOpponent);
        droneShotMatch.Command(decoyPlayer,new(){CommandId=1,Ready=new(){ManifestHash=droneShotMatch.ManifestHash}});
        droneShotMatch.Command(decoyOpponent,new(){CommandId=1,Ready=new(){ManifestHash=droneShotMatch.ManifestHash}});
        droneShotMatch.Advance(60);var droneShotOption=droneShotMatch.ArmyBatch(decoyPlayer).OptionIndexes.First();
        droneShotMatch.Command(decoyPlayer,new(){CommandId=2,DeployArmy=new(){OptionIndex=droneShotOption}});
        droneShotMatch.Advance(61);var shotDrone=droneShotMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.Single();
        float initialShotHealth=shotDrone.Health;bool playerShotDamagedDrone=false;ulong droneFireCommand=2;
        bool droneProjectileLaunched=false,droneProjectileDrained=false;
        bool lethalDroneBulletCredited=false;
        ulong droneEventCursor=0;bool droneProjectileImpactSeen=false;
        bool droneFiringEventSeen=false;
        for(ulong shotTick=62;shotTick<5000&&!droneShotMatch.Terminal;shotTick++)
        {
            if(shotTick%12==0)
            {
                var currentDrone=droneShotMatch.ArmyEntityBatch(decoyPlayer,0,0).Entities.SingleOrDefault();
                if(currentDrone==null){playerShotDamagedDrone=true;break;}
                var q=currentDrone.DroneRotation;
                var corner=Vector3.Transform(new Vector3(.34f,.05f,.34f),new Quaternion(q.X,q.Y,q.Z,q.W));
                var aim=new Vector3(currentDrone.X,currentDrone.Y,currentDrone.Z)+corner;
                var targetVelocity=droneShotMatch.ResolveDroneShotTarget(droneShotMatch.DroneTargetSnapshot()
                    .Single(r=>r.Id=="army:"+shotDrone.EntityKey)).Velocity;
                var shooterPose=droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent);
                aim+=targetVelocity*(Vector3.Distance(new(shooterPose.PositionX,shooterPose.PositionY,shooterPose.PositionZ),aim)/
                    content.Bindings.Get(droneShotManifest.Players[1].Weapon.SourceId).Speed+.1f);
                droneShotMatch.Command(decoyOpponent,new(){CommandId=droneFireCommand++,Fire=new(){TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            }
            uint enemyHitsBeforeAdvance=droneShotMatch.Snapshot().Players
                .Single(p=>p.PlayerId==decoyOpponent).ConfirmedEnemyHits;
            droneShotMatch.Advance(shotTick);
            if(shotTick%30==0)
            {
                while(true)
                {
                    var batch=droneShotMatch.EventBatch(decoyPlayer,droneEventCursor);
                    if(batch.Events.Count==0)break;
                    droneProjectileImpactSeen|=batch.Events.Any(e=>e.Kind==MatchEventKind.Impact&&e.Reason=="drone");
                    droneFiringEventSeen|=batch.Events.Any(e=>e.Kind==MatchEventKind.DroneFired&&
                        e.DroneShot is {Speed:>0,Fake:false}&&e.DroneShot.ArmyEntityKey==shotDrone.EntityKey);
                    droneEventCursor=batch.Events.Last().EventId;
                }
                droneShotMatch.EventBatch(decoyOpponent,droneEventCursor);
            }
            if(!droneProjectileLaunched&&droneShotMatch.PendingDroneProjectiles>0)
            {
                droneProjectileLaunched=true;
                if(droneProjectileLaunched)
                    Check(droneShotMatch.Snapshot().Projectiles.Any(p=>p.Kind=="drone-bullet"&&p.OwnerPlayerId==decoyPlayer),
                        "live Drone flight projects dedicated host-owned bullet snapshot");
            }
            if(droneProjectileLaunched&&droneShotMatch.PendingDroneProjectiles==0)droneProjectileDrained=true;
            if(droneShotMatch.ArmyHealth(shotDrone.EntityKey) is not float health||health<initialShotHealth)
            {
                playerShotDamagedDrone=true;
                if(droneShotMatch.ArmyHealth(shotDrone.EntityKey)==null)
                {
                    lethalDroneBulletCredited=droneShotMatch.Snapshot().Players
                        .Single(p=>p.PlayerId==decoyOpponent).ConfirmedEnemyHits>enemyHitsBeforeAdvance;
                    break;
                }
            }
        }
        Check(playerShotDamagedDrone&&lethalDroneBulletCredited&&
              droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent).ConfirmedEnemyHits>0&&
              droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent).ConfirmedPlayerBulletHits==0,
            "normal player Fire command advances projectile collision into deployed Drone root damage");
        if(!droneShotMatch.Terminal)droneShotMatch.Command(decoyOpponent,new()
            {CommandId=droneFireCommand++,Forfeit=new()});
        Check(droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent).ConfirmedPlayerBulletHits==0&&
              droneShotMatch.TerminalEvidenceSnapshot().Players.Single(p=>p.PlayerId==decoyOpponent)
                  .ConfirmedPlayerBulletHits>0,
            "player-owned bullet contacts enter private terminal evidence without expanding UDP snapshots");
        Check(droneShotMatch.Snapshot().DirectArmyKills.Count==0&&
              droneShotMatch.TerminalEvidenceSnapshot().DirectArmyKills.Single() is
              {UnitId:"ID_UNIT-DRONE",Cause:"player-bullet"} directDroneKill&&
              directDroneKill.EntityKey==shotDrone.EntityKey&&
              directDroneKill.AttackerPlayerId==decoyOpponent&&
              directDroneKill.VictimOwnerPlayerId==decoyPlayer,
            "lethal player bullet retains one private source-identity Drone kill rather than a generic army loss");
        var bulletResult=Google.Protobuf.MessageExtensions.ToByteArray(droneShotMatch.TerminalEvidenceSnapshot());
        Check(TerminalOutbox.ValidatePayload(bulletResult,droneShotMatch.MatchId,
                  War.Shared.TerminalResultDigest.Compute(bulletResult)).Players
                  .Single(p=>p.PlayerId==decoyOpponent).ConfirmedPlayerBulletHits>0,
            "terminal outbox accepts the private player-bullet evidence absent from UDP replies");
        Check(BattleDirectArmyKillEvidenceProjection.FromPayload(bulletResult,droneShotMatch.MatchId,
                  War.Shared.TerminalResultDigest.Compute(bulletResult)).Single() is
              {UnitId:"ID_UNIT-DRONE",Cause:"player-bullet",AttackerPlayerId:var directAttacker}&&
              directAttacker==decoyOpponent,
            "validated terminal projection retains direct player-bullet army kill attribution");
        foreach(var family in content.Army.Families)
        {
            var unitResult=droneShotMatch.TerminalEvidenceSnapshot();
            var option=ArmyOptionIdentityCatalog.All.First(x=>x.UnitId==family.UnitId);
            var unitUsage=unitResult.Players.Single(p=>p.PlayerId==decoyPlayer).ArmyUsage.Single();
            unitUsage.OptionIndex=option.Index;
            unitUsage.UnitId=family.UnitId;
            unitUsage.PlannedSpawns=(uint)option.SpawnCount;
            unitResult.DirectArmyKills[0].UnitId=family.UnitId;
            var unitBytes=Google.Protobuf.MessageExtensions.ToByteArray(unitResult);
            var stats=BattleDirectKillStatsProjection.FromPayload(unitBytes,droneShotMatch.MatchId,
                War.Shared.TerminalResultDigest.Compute(unitBytes));
            Check(stats.Single(x=>x.PlayerId==decoyOpponent) is
                  {DirectBulletKills:1} attackerStats&&
                  attackerStats.DirectBulletVehiclesDestroyed==(family.IsSoldier?0:1)&&
                  attackerStats.DirectBulletTanksDestroyed==(family.UnitId=="ID_UNIT-TANK"?1:0)&&
                  attackerStats.DirectGrenadeKills==0&&
                  attackerStats.DirectGrenadeVehiclesDestroyed==0&&
                  attackerStats.DirectGrenadeTanksDestroyed==0&&
                  stats.Single(x=>x.PlayerId==decoyPlayer) is
                  {DirectBulletKills:0,DirectBulletVehiclesDestroyed:0,DirectBulletTanksDestroyed:0,
                   DirectGrenadeKills:0,DirectGrenadeVehiclesDestroyed:0,DirectGrenadeTanksDestroyed:0},
                $"direct bullet kill candidates classify source army family {family.UnitId}");
        }
        var forgedKill=droneShotMatch.TerminalEvidenceSnapshot();
        forgedKill.DirectArmyKills[0].Cause="army-projectile";
        var forgedKillBytes=Google.Protobuf.MessageExtensions.ToByteArray(forgedKill);
        Reject(()=>TerminalOutbox.ValidatePayload(forgedKillBytes,droneShotMatch.MatchId,
            War.Shared.TerminalResultDigest.Compute(forgedKillBytes)));
        forgedKill=droneShotMatch.TerminalEvidenceSnapshot();
        forgedKill.DirectArmyKills.Add(forgedKill.DirectArmyKills[0].Clone());
        forgedKillBytes=Google.Protobuf.MessageExtensions.ToByteArray(forgedKill);
        Reject(()=>TerminalOutbox.ValidatePayload(forgedKillBytes,droneShotMatch.MatchId,
            War.Shared.TerminalResultDigest.Compute(forgedKillBytes)));
        forgedKill=droneShotMatch.TerminalEvidenceSnapshot();
        forgedKill.DirectArmyKills[0].Cause="player-grenade";
        forgedKill.DirectArmyKills[0].UnitId="ID_UNIT-ASSAULTHELI";
        var unsupportedGrenadeUsage=forgedKill.Players.Single(p=>p.PlayerId==decoyPlayer)
            .ArmyUsage.Single();
        unsupportedGrenadeUsage.OptionIndex=30;
        unsupportedGrenadeUsage.UnitId="ID_UNIT-ASSAULTHELI";
        unsupportedGrenadeUsage.PlannedSpawns=1;
        forgedKillBytes=Google.Protobuf.MessageExtensions.ToByteArray(forgedKill);
        Reject(()=>TerminalOutbox.ValidatePayload(forgedKillBytes,droneShotMatch.MatchId,
            War.Shared.TerminalResultDigest.Compute(forgedKillBytes)));
        forgedKill=droneShotMatch.TerminalEvidenceSnapshot();
        var forgedVictim=forgedKill.Players.Single(p=>p.PlayerId==decoyPlayer);
        var forgedAttacker=forgedKill.Players.Single(p=>p.PlayerId==decoyOpponent);
        forgedVictim.ArmyUsage.Insert(0,new BattleArmyUsage
            {OptionIndex=2,UnitId="ID_UNIT-HELICOPTER",Deployments=1,PlannedSpawns=1,ConfirmedSpawns=1});
        forgedVictim.ConfirmedArmySpawns++;
        forgedVictim.ConfirmedArmyLosses++;
        forgedAttacker.ConfirmedPlayerBulletHits++;
        var extraDroneKill=forgedKill.DirectArmyKills[0].Clone();
        extraDroneKill.EntityKey++;
        forgedKill.DirectArmyKills.Add(extraDroneKill);
        forgedKillBytes=Google.Protobuf.MessageExtensions.ToByteArray(forgedKill);
        Reject(()=>TerminalOutbox.ValidatePayload(forgedKillBytes,droneShotMatch.MatchId,
            War.Shared.TerminalResultDigest.Compute(forgedKillBytes)));
        Check(droneProjectileLaunched&&droneProjectileDrained,
            "deployed Drone host observation launches source flight and retires it through tick traversal");
        while(droneEventCursor<droneShotMatch.EventBatch(decoyPlayer,droneEventCursor).LatestEventId)
        {
            var droneEvents=droneShotMatch.EventBatch(decoyPlayer,droneEventCursor);
            if(droneEvents.Events.Count==0)break;
            droneProjectileImpactSeen|=droneEvents.Events.Any(e=>e.Kind==MatchEventKind.Impact&&e.Reason=="drone");
            droneEventCursor=droneEvents.Events.Last().EventId;
        }
        Check(droneProjectileImpactSeen&&
              droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyPlayer).ConfirmedPlayerBulletHits==0,
              "normal host Drone impacts cannot claim player-owned bullet hit credit");
        Check(droneFiringEventSeen,"Drone launch emits distinct source-bound firing presentation metadata");
        Console.WriteLine($"Drone shot trace initial {initialShotHealth}, remaining {droneShotMatch.ArmyHealth(shotDrone.EntityKey)}, hits {droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyOpponent).ConfirmedEnemyHits}, terminal {droneShotMatch.Terminal}, phase {droneShotMatch.Snapshot().Phase}");
        Check(droneShotMatch.ArmyHealth(shotDrone.EntityKey)==null&&
            droneShotMatch.DroneTargetSnapshot().All(r=>r.Id!="army:"+shotDrone.EntityKey)&&
            droneShotMatch.GroundVehicleShotTargets(decoyOpponent).All(r=>r.EntityId!=shotDrone.EntityKey)&&
            droneShotMatch.Snapshot().Players.Single(p=>p.PlayerId==decoyPlayer).ConfirmedArmyLosses==1,
            "lethal player projectile removes Drone vitality, sight/shot targets and credits one army loss");
        var droneClockMatch=new MatchEngine(heavyTurretManifest with {MatchId="drone-special-clock"},content:content);
        droneClockMatch.Admit(decoyPlayer);droneClockMatch.Admit(decoyOpponent);
        droneClockMatch.Command(decoyPlayer,new(){CommandId=1,Ready=new(){ManifestHash=droneClockMatch.ManifestHash}});
        droneClockMatch.Command(decoyOpponent,new(){CommandId=1,Ready=new(){ManifestHash=droneClockMatch.ManifestHash}});
        droneClockMatch.Advance(60);
        var hostDroneCycle=new DroneSpecialState(2,true,2.5f,()=>0);
        var hostDrone=new AirBattleEntity(96,decoyPlayer,new(Vector3.Zero,Vector3.Zero,1),
            new(new(5,1,1,1,0,0,0),()=>0),new(40),hostDroneCycle);
        Check(droneClockMatch.TryRegisterAirEntity(hostDrone),"host registration binds Drone special to current simulation spawn time");
        var staleDrone=new AirBattleEntity(97,decoyPlayer,new(Vector3.Zero,Vector3.Zero,1),
            new(new(5,1,1,1,0,0,0),()=>0),new(40),new DroneSpecialState(0,true,2.5f,()=>0));
        Check(!droneClockMatch.TryRegisterAirEntity(staleDrone),"host rejects a mismatched Drone special spawn clock before publishing entity");
        for(ulong t=61;t<=210;t++)droneClockMatch.Advance(t);
        Check(!hostDroneCycle.IsImmortal,"host strict activation boundary remains vulnerable at exact scheduled tick");
        droneClockMatch.Advance(211);
        Check(hostDroneCycle.IsImmortal&&!droneClockMatch.TryDamageAirEntity(decoyOpponent,96,100)&&
              droneClockMatch.Snapshot().AirEntities.Single().Health==40,
              "host tick activates special before confirmed damage; immune lethal hit preserves authoritative health");
        for(ulong t=212;t<=285;t++)droneClockMatch.Advance(t);
        Check(hostDroneCycle.IsImmortal,"host retains immunity at exact scheduled duration boundary");
        droneClockMatch.Advance(286);
        Check(!hostDroneCycle.IsImmortal&&droneClockMatch.TryDamageAirEntity(decoyOpponent,96,100)&&
              droneClockMatch.Snapshot().AirEntities.Count==0,
              "host expiry restores damage and existing lethal removal lifecycle");
        var heavyTurretMatch=new MatchEngine(heavyTurretManifest,content:content,armyChoice:_=>0);
        heavyTurretMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardHeavyTurret"],[],[0],[133],[-1]),
            new(decoyOpponent,[],[],[0],[-1],[-1])]);
        heavyTurretMatch.Admit(decoyPlayer);heavyTurretMatch.Admit(decoyOpponent);
        Check(heavyTurretMatch.Command(decoyPlayer,new(){CommandId=1,SelectCards=new SelectCardsCommand
              {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},SpecialUpgradeIndexes={133},EliteUpgradeIndexes={-1}}}).Code=="cards-selected"&&
              heavyTurretMatch.Command(decoyOpponent,new(){CommandId=1,SelectCards=new SelectCardsCommand
              {NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
              "Heavy Turret selection binds the trusted card before battle start");
        heavyTurretMatch.Command(decoyPlayer,new(){CommandId=2,Ready=new(){ManifestHash=heavyTurretMatch.ManifestHash}});
        heavyTurretMatch.Command(decoyOpponent,new(){CommandId=2,Ready=new(){ManifestHash=heavyTurretMatch.ManifestHash}});
        heavyTurretMatch.Advance(60);string liveHeavyTurretRequest=new string('3',32);
        var heavyTurretReply=heavyTurretMatch.Command(decoyPlayer,new(){CommandId=3,
            UseHeavyTurret=new(){RequestId=liveHeavyTurretRequest}});
        var expectedHeavyTurret=content.HeavyTurrets.Compose(22);
        Check(heavyTurretReply.Code=="heavy-turret-spawned"&&heavyTurretReply.Snapshot.HeavyTurrets.Count==1&&
              heavyTurretReply.Snapshot.HeavyTurrets[0] is var liveTurret&&liveTurret.OwnerPlayerId==decoyPlayer&&
              liveTurret.OwnerFraction==1&&liveTurret.RequestId==liveHeavyTurretRequest&&
              Math.Abs(liveTurret.Health-expectedHeavyTurret.Health)<.001f&&liveTurret.Health==liveTurret.MaxHealth&&
              Math.Abs(liveTurret.Damage-expectedHeavyTurret.Damage)<.001f&&liveTurret.BatchMinimum==expectedHeavyTurret.BatchMinimum&&
              liveTurret.BatchMaximum==expectedHeavyTurret.BatchMaximum&&liveTurret.RealShotProbability==1&&
              content.HeavyTurrets.ForMap(park)[coverOne.SourceIndex].Slots.Any(x=>x.ComponentFileId==liveTurret.SlotComponentFileId),
              "live authenticated Heavy Turret activation projects one current-cover source placement and composed stats");
        Check(heavyTurretMatch.Command(decoyPlayer,new(){CommandId=4,
                  UseHeavyTurret=new(){RequestId=liveHeavyTurretRequest}}).Code=="heavy-turret-replayed"&&
              heavyTurretMatch.Command(decoyPlayer,new(){CommandId=5,
                  UseHeavyTurret=new(){RequestId=new string('2',32)}}).Code=="heavy-turret-unavailable"&&
              heavyTurretMatch.Snapshot().HeavyTurrets.Count==1&&heavyTurretMatch.Snapshot().CardActivations==1,
              "Heavy Turret replay creates no duplicate and exhausted inventory cannot create state");
        float heavyTurretVictimHealth=heavyTurretMatch.Snapshot().Players.Single(x=>x.PlayerId==decoyOpponent).Health;
        var turretVictimMove=heavyTurretMatch.Command(decoyOpponent,new(){CommandId=3,MoveCover=new(){Direction=1}});
        Check(turretVictimMove.Code=="moving","Heavy Turret target enters a source-bound walking route");
        bool observedTurretFlight=false;
        for(ulong heavyTick=61;heavyTick<=900&&!heavyTurretMatch.Terminal;heavyTick++)
        {
            heavyTurretMatch.Advance(heavyTick);
            observedTurretFlight|=heavyTurretMatch.Snapshot().Projectiles.Any(x=>x.Kind=="heavy-turret-bullet");
            heavyTurretMatch.EventBatch(decoyPlayer,0);heavyTurretMatch.EventBatch(decoyOpponent,0);
        }
        var heavyTurretCombatSnapshot=heavyTurretMatch.Snapshot();
        var heavyTurretEvents=new List<MatchEvent>();ulong heavyTurretCursor=0;
        while(heavyTurretCursor<heavyTurretMatch.EventBatch(decoyPlayer,heavyTurretCursor).LatestEventId)
        {var page=heavyTurretMatch.EventBatch(decoyPlayer,heavyTurretCursor);heavyTurretEvents.AddRange(page.Events);if(page.Events.Count==0)break;heavyTurretCursor=page.Events[^1].EventId;}
        Check(heavyTurretEvents.Any(x=>x.Kind==MatchEventKind.HeavyTurretFired&&
                  x.ActorId==decoyPlayer&&x.TargetId==decoyOpponent)&&
              observedTurretFlight&&
              heavyTurretCombatSnapshot.Players.Single(x=>x.PlayerId==decoyOpponent).Health<=heavyTurretVictimHealth&&
              heavyTurretCombatSnapshot.HeavyTurrets.Single().AttackPhase is "cooldown" or "aiming" or "firing",
              "Heavy Turret owns source cooldown, aim, batch cadence and live BulletSlow flight; misses do not imply damage: "+
              string.Join(",",heavyTurretEvents.Select(x=>x.Kind+":"+x.Reason)));
        ulong liveHeavyTurretId=heavyTurretCombatSnapshot.HeavyTurrets.Single().EntityId;
        var turretPose=heavyTurretCombatSnapshot.HeavyTurrets.Single();
        Check(turretPose.HorizontalRotation!=null&&turretPose.VerticalRotation!=null&&
              Math.Abs(turretPose.HorizontalRotation.Y*turretPose.HorizontalRotation.Y+turretPose.HorizontalRotation.W*turretPose.HorizontalRotation.W-1)<.0002f&&
              Math.Abs(turretPose.VerticalRotation.X*turretPose.VerticalRotation.X+turretPose.VerticalRotation.Y*turretPose.VerticalRotation.Y+
                  turretPose.VerticalRotation.Z*turretPose.VerticalRotation.Z+turretPose.VerticalRotation.W*turretPose.VerticalRotation.W-1)<.0002f,
              "live Heavy Turret snapshot carries sampled unit joint rotations for Client presentation");
        var firstTurretBatch=heavyTurretEvents.Where(x=>x.Kind==MatchEventKind.HeavyTurretFired).Take(3).ToArray();
        Check(firstTurretBatch.Length==3&&firstTurretBatch.All(x=>x.X==firstTurretBatch[0].X&&
                  x.Y==firstTurretBatch[0].Y&&x.Z==firstTurretBatch[0].Z)&&
              firstTurretBatch[1].Tick-firstTurretBatch[0].Tick==6&&firstTurretBatch[2].Tick-firstTurretBatch[1].Tick==6,
              "live Heavy Turret retains the first batch aim point across its source six-tick cadence");
        var turretShieldBefore=heavyTurretMatch.Snapshot().Shields.Single(x=>x.CoverIndex==coverTwo.SourceIndex);
        var turretShieldCollider=park.DynamicColliders.First(x=>x.DynamicOwner==coverTwo.SourcePath+"/riot_shield");
        var turretShieldImpact=new BulletImpact(900001,decoyPlayer,
            new ShotCollision(0,turretShieldCollider.TransformPosition,turretShieldCollider.SourcePath,null,1,
                DynamicOwner:turretShieldCollider.DynamicOwner,ColliderIndex:turretShieldCollider.ColliderIndex),
            heavyTurretMatch.Snapshot().ServerTick);
        heavyTurretMatch.ApplyHeavyTurretEnvironmentImpact(turretShieldImpact,10);
        var turretShieldAfter=heavyTurretMatch.Snapshot().Shields.Single(x=>x.CoverIndex==coverTwo.SourceIndex);
        Check(Math.Abs(turretShieldAfter.Health-(turretShieldBefore.Health-10*content.Shields.UnitToShieldCoefficient))<.001f&&
              turretShieldAfter.Revision==turretShieldBefore.Revision+1&&
              heavyTurretMatch.EventBatch(decoyPlayer,heavyTurretCursor).Events.Any(x=>x.Kind==MatchEventKind.ShieldDamaged&&x.ProjectileId==900001),
              "Heavy Turret shield impact applies recovered unit coefficient and publishes authoritative mutation");
        var friendlyTurretShield=heavyTurretMatch.Snapshot().Shields.Single(x=>x.CoverIndex==coverOne.SourceIndex);
        heavyTurretMatch.ApplyHeavyTurretEnvironmentImpact(turretShieldImpact with {Hit=turretShieldImpact.Hit with {
            DynamicOwner=coverOne.SourcePath+"/riot_shield"}},10);
        Check(heavyTurretMatch.Snapshot().Shields.Single(x=>x.CoverIndex==coverOne.SourceIndex).Equals(friendlyTurretShield),
              "Heavy Turret shot cannot damage its own fraction shield");
        Reject(()=>heavyTurretMatch.ApplyHeavyTurretEnvironmentImpact(turretShieldImpact,float.NaN));
        var turretBarrelBefore=heavyTurretMatch.BarrelState.First(x=>!x.Destroyed);
        var turretBarrelCollider=park.DynamicColliders.Single(x=>x.ColliderIndex==turretBarrelBefore.ColliderIndex);
        heavyTurretMatch.ApplyHeavyTurretEnvironmentImpact(turretShieldImpact with {ProjectileId=900002,Hit=
            new ShotCollision(0,turretBarrelCollider.TransformPosition,turretBarrelCollider.SourcePath,null,1,
                ColliderIndex:turretBarrelCollider.ColliderIndex)},1);
        var turretBarrelAfter=heavyTurretMatch.BarrelState.Single(x=>x.ColliderIndex==turretBarrelBefore.ColliderIndex);
        Check(turretBarrelAfter.Health==turretBarrelBefore.Health-1&&turretBarrelAfter.Revision==turretBarrelBefore.Revision+1,
              "Heavy Turret barrel impact enters the shared source-backed shot damage chain");
        float liveHeavyTurretHealth=heavyTurretCombatSnapshot.HeavyTurrets.Single().Health;
        var liveHeavyTurretColliders=heavyTurretMatch.GroundVehicleShotTargets(decoyOpponent)
            .Where(x=>x.HeavyTurret&&x.EntityId==liveHeavyTurretId).ToArray();
        Check(liveHeavyTurretColliders.Length==3&&liveHeavyTurretColliders.Select(x=>x.PartComponentFileId)
                  .SequenceEqual(new[]{6525385,6572182,6582579}),
              "opposing bullets see all three recovered Heavy Turret box colliders as host dynamic targets");
        ulong heavyTurretEventCursor=heavyTurretMatch.EventBatch(decoyPlayer,0).LatestEventId;
        Check(heavyTurretMatch.ApplyHeavyTurretHostDamage(decoyOpponent,liveHeavyTurretId,1,"focused-test")&&
              Math.Abs(heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)!.Value-(liveHeavyTurretHealth-1))<.001f&&
              heavyTurretMatch.EventBatch(decoyPlayer,heavyTurretEventCursor).Events.Any(x=>x.Kind==MatchEventKind.HeavyTurretDamaged&&x.ProjectileId==liveHeavyTurretId),
              "trusted opposing damage mutates Heavy Turret health and publishes authoritative damage state");
        Vector3 mineTurretOrigin=liveHeavyTurretColliders[0].Hitbox.Center;
        float mineTurretBefore=heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)!.Value;
        Check(heavyTurretMatch.ApplyLandMineHeavyTurretExplosion(decoyOpponent,mineTurretOrigin,10,81)==1&&
              Math.Abs(heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)!.Value-
                  (mineTurretBefore-10))<.001f,
            "Land Mine blast selects one current Heavy Turret box and applies one opposing hit");
        float friendlyMineTurretBefore=heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)!.Value;
        Check(heavyTurretMatch.ApplyLandMineHeavyTurretExplosion(decoyPlayer,mineTurretOrigin,10,82)==1&&
              Math.Abs(heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)!.Value-
                  (friendlyMineTurretBefore-5))<.001f,
            "allied Land Mine blast applies recovered half damage to Heavy Turret");
        Reject(()=>heavyTurretMatch.ApplyLandMineHeavyTurretExplosion(decoyOpponent,mineTurretOrigin,float.NaN,83));
        heavyTurretEventCursor=heavyTurretMatch.EventBatch(decoyPlayer,0).LatestEventId;
        Check(heavyTurretMatch.ApplyHeavyTurretHostDamage(decoyOpponent,liveHeavyTurretId,10_000_000,"focused-lethal")&&
              heavyTurretMatch.HeavyTurretHealth(liveHeavyTurretId)==null&&
              heavyTurretMatch.EventBatch(decoyPlayer,heavyTurretEventCursor).Events.Any(x=>x.Kind==MatchEventKind.HeavyTurretDestroyed&&x.ProjectileId==liveHeavyTurretId),
              "lethal trusted damage destroys Heavy Turret state and releases its source slot");
        var turretDuel=new MatchEngine(heavyTurretManifest with {MatchId="turret-duel"},content:content,armyChoice:_=>0);
        turretDuel.ConfigureBattleAllocations([
            new(decoyPlayer,["CardHeavyTurret"],[],[0],[133],[-1]),
            new(decoyOpponent,["CardHeavyTurret"],[],[0],[-1],[-1])]);
        turretDuel.Admit(decoyPlayer);turretDuel.Admit(decoyOpponent);
        foreach(var id in new[]{decoyPlayer,decoyOpponent})
        {
            turretDuel.Command(id,new(){CommandId=1,SelectCards=new(){CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
                SpecialUpgradeIndexes={id==decoyPlayer?133:-1},EliteUpgradeIndexes={-1}}});
            turretDuel.Command(id,new(){CommandId=2,Ready=new(){ManifestHash=turretDuel.ManifestHash}});
        }
        turretDuel.Advance(60);
        Check(turretDuel.Command(decoyPlayer,new(){CommandId=3,UseHeavyTurret=new(){RequestId=new string('c',32)}}).Code=="heavy-turret-spawned"&&
              turretDuel.Command(decoyOpponent,new(){CommandId=3,UseHeavyTurret=new(){RequestId=new string('d',32)}}).Code=="heavy-turret-spawned",
              "opposing trusted turret cards spawn independently");
        var duelIds=turretDuel.Snapshot().HeavyTurrets.ToDictionary(x=>x.OwnerPlayerId,x=>x.EntityId);
        var duelAcquisition=new HashSet<string>();
        for(ulong t=61;t<=360&&!turretDuel.Terminal;t++)
        {
            turretDuel.Advance(t);turretDuel.EventBatch(decoyPlayer,0);turretDuel.EventBatch(decoyOpponent,0);
            foreach(var row in turretDuel.Snapshot().HeavyTurrets)
                if(row.TargetId=="turret:"+duelIds[row.OwnerPlayerId==decoyPlayer?decoyOpponent:decoyPlayer])
                    duelAcquisition.Add(row.OwnerPlayerId);
        }
        Check(duelAcquisition.Count==2,"each live turret acquires the opposing source Defender before player fallback");
        if(!turretDuel.Terminal)
            turretDuel.Command(decoyPlayer,new(){CommandId=4,Forfeit=new()});
        var duelTerminal=turretDuel.Snapshot();
        Check(turretDuel.Terminal&&duelTerminal.CardActivations==2&&
              duelTerminal.Players.All(p=>p.ConfirmedCardsPlayed==1)&&
              duelTerminal.CardUsage.Count==2&&
              duelTerminal.CardUsage.All(row=>row.CardId=="CardHeavyTurret"&&
                  row.SourceCardId=="HEAVYTURRET"&&row.Count==1&&
                  duelTerminal.Players.Any(p=>p.PlayerId==row.OwnerPlayerId)),
              "terminal card statistics retain one accepted activation for each authenticated player");
        var duelPayload=Google.Protobuf.MessageExtensions.ToByteArray(duelTerminal);
        var duelStats=BattleCardStatsProjection.FromPayload(duelPayload,duelTerminal.MatchId,
            War.Shared.TerminalResultDigest.Compute(duelPayload));
        Check(duelStats.Count==2&&duelStats.All(row=>row.CardsPlayed==1&&
              row.CardsPlayedSeparately.Count==1&&row.CardsPlayedSeparately["HEAVYTURRET"]==1),
              "validated terminal evidence projects source MatchStats card fields for both players");
        var outcomeStats=BattleOutcomeStatsProjection.FromPayload(duelPayload,duelTerminal.MatchId,
            War.Shared.TerminalResultDigest.Compute(duelPayload));
        bool outcomeForfeit=duelTerminal.TerminalReason is "forfeit" or "opponent-disconnected";
        Check(outcomeStats.Count==2&&outcomeStats.Select(x=>x.PlayerId)
                  .SequenceEqual(duelTerminal.Players.Select(x=>x.PlayerId))&&
              outcomeStats.Single(x=>x.PlayerId==duelTerminal.WinnerPlayerId) is
                  {BattlesWon:1,BattlesLost:0,BattlesLostInRowDelta:-1}&&
              outcomeStats.Single(x=>x.PlayerId!=duelTerminal.WinnerPlayerId) is
                  {BattlesWon:0,BattlesLost:1,BattlesLostInRowDelta:1}&&
              outcomeStats.Single(x=>x.PlayerId==duelTerminal.WinnerPlayerId).GameEndReason==
                  (outcomeForfeit?"WinByForfeit":"Win")&&
              outcomeStats.Single(x=>x.PlayerId!=duelTerminal.WinnerPlayerId).GameEndReason==
                  (outcomeForfeit?"Forfeit":"Killed"),
              "validated scored terminal evidence projects the recovered per-player win/loss reasons");
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
        Check(miniMatch.ArmyBatch(miniOwner).OptionIndexes.Contains(21) &&
              miniMatch.Command(miniOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=21}}).Code=="army-deploying",
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
        Check(miniPair.ArmyBatch(miniOwner).OptionIndexes.Contains(22)&&
              miniPair.Command(miniOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=22}}).Code=="army-deploying",
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
        var flameManifest=detached with{MatchId="army-flame-infantry",Players=detached.Players.Select(p=>p with
        {
            EquippedArmyUnitIds=["ID_UNIT-FLAMETHROWER"],ArmyNormalUpgradeIndexes=[0],
            ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
            ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
            ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f],ShieldLevel=0
        }).ToArray()};
        content.ValidateAllocation(flameManifest);
        var flameInfantryMatch=new MatchEngine(flameManifest,content:content,armyChoice:_=>0);
        flameInfantryMatch.Admit(soldierOwner);flameInfantryMatch.Admit(helicopterOwner);
        flameInfantryMatch.Command(soldierOwner,new(){CommandId=1,Ready=new(){ManifestHash=flameInfantryMatch.ManifestHash}});
        flameInfantryMatch.Command(helicopterOwner,new(){CommandId=1,Ready=new(){ManifestHash=flameInfantryMatch.ManifestHash}});
        flameInfantryMatch.Advance(60);
        int flameOptionA=flameInfantryMatch.ArmyBatch(soldierOwner).OptionIndexes[0];
        int flameOptionB=flameInfantryMatch.ArmyBatch(helicopterOwner).OptionIndexes[0];
        Check(flameInfantryMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new(){OptionIndex=flameOptionA}}).Code=="army-deploying"&&
              flameInfantryMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new(){OptionIndex=flameOptionB}}).Code=="army-deploying",
            "both factions deploy source-backed flamethrower infantry for host damage proof");
        for(ulong flameTick=61;flameTick<=75;flameTick++)flameInfantryMatch.Advance(flameTick);
        var flameRows=flameInfantryMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var flameSource=flameRows.First(x=>x.OwnerPlayerId==soldierOwner);
        var flameTarget=flameRows.First(x=>x.OwnerPlayerId==helicopterOwner);
        var flamePart=flameInfantryMatch.InfantryPose(flameTarget.EntityKey)!.Parts[0];
        float flameTargetBefore=flameInfantryMatch.ArmyHealth(flameTarget.EntityKey)!.Value;
        float flameSourceBefore=flameInfantryMatch.ArmyHealth(flameSource.EntityKey)!.Value;
        int flameHits=flameInfantryMatch.ApplyArmyFlameInfantryPulse(flameSource.EntityKey,
            flamePart.Center-Vector3.UnitZ,Vector3.UnitZ);
        Check(flameHits>=1&&flameInfantryMatch.ArmyHealth(flameTarget.EntityKey)<flameTargetBefore&&
              flameInfantryMatch.ArmyHealth(flameSource.EntityKey)==flameSourceBefore,
            "source flame cone mutates opposing spawned infantry vitality while excluding allied infantry");
        var flameAllyPart=flameInfantryMatch.InfantryPose(flameSource.EntityKey)!.Parts[0];
        flameInfantryMatch.ApplyArmyFlameInfantryPulse(flameSource.EntityKey,
            flameAllyPart.Center-Vector3.UnitZ,Vector3.UnitZ);
        Check(flameInfantryMatch.ArmyHealth(flameSource.EntityKey)==flameSourceBefore,
            "army flame cone does not damage its owning deployed infantry collider");
        Reject(()=>flameInfantryMatch.ApplyArmyFlameInfantryPulse(ulong.MaxValue,
            flamePart.Center-Vector3.UnitZ,Vector3.UnitZ));
        float friendlyInfantryBefore=flameInfantryMatch.ArmyHealth(flameSource.EntityKey)!.Value;
        var friendlyInfantryBox=flameInfantryMatch.InfantryPose(flameSource.EntityKey)!.Parts[0];
        flameInfantryMatch.ApplyGroundVehicleMissileInfantryExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,friendlyInfantryBox.Center);
        flameInfantryMatch.ApplyGroundVehicleMissileInfantryExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,friendlyInfantryBox.Center);
        Check(Math.Abs(flameInfantryMatch.ArmyHealth(flameSource.EntityKey)!.Value-
                  friendlyInfantryBefore)<.01f,
            "Tank and Buggy primary friendKill=false prevent friendly infantry missile damage");
        var friendlyBuggyMissile=buggyRig.Roles.Single(role=>role.Role=="cannon").Weapons[1].Missile!;
        flameInfantryMatch.ApplyGroundVehicleMissileInfantryExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,friendlyBuggyMissile,friendlyInfantryBox.Center);
        float friendlyInfantryAfter=flameInfantryMatch.ArmyHealth(flameSource.EntityKey)!.Value;
        Check(friendlyInfantryAfter<friendlyInfantryBefore&&
              Math.Abs(friendlyInfantryAfter-(friendlyInfantryBefore-
                  Math.Max(0,10.5f-flameSource.Kevlar)))<.01f,
            "Buggy secondary friendKill=true applies half blast damage to allied infantry");
        float opposingInfantryBefore=flameInfantryMatch.ArmyHealth(flameTarget.EntityKey)!.Value;
        flameInfantryMatch.ApplyGroundVehicleMissileInfantryExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,flamePart.Center);
        float opposingInfantryAfter=flameInfantryMatch.ArmyHealth(flameTarget.EntityKey)!.Value;
        Check(opposingInfantryAfter<opposingInfantryBefore&&
              Math.Abs(opposingInfantryAfter-(opposingInfantryBefore-
                  Math.Max(0,21-flameTarget.Kevlar)))<.01f,
            "opposing Tank missile damages spawned infantry once without bullet part weight");
        Reject(()=>flameInfantryMatch.ApplyGroundVehicleMissileInfantryExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},flamePart.Center));
        var flameShieldCover=park.Covers.First(x=>x.Fraction==2);
        string flameShieldOwner=flameShieldCover.SourcePath+"/riot_shield";
        var flameShieldCollider=park.DynamicColliders.First(x=>x.DynamicOwner==flameShieldOwner);
        var flameShieldCenter=(flameShieldCollider.BoundsMin+flameShieldCollider.BoundsMax)*.5f;
        var flameShieldOrigin=flameShieldCenter-Vector3.UnitZ;
        var flameShieldBefore=flameInfantryMatch.Snapshot().Shields
            .ToDictionary(x=>x.CoverIndex,x=>x.Health);
        float expectedFlameShield=ArmyFlameBurst.ResolveCenter(flameShieldOrigin,Vector3.UnitZ,
            flameShieldCenter,flameInfantryMatch.ArmyDamage(flameSource.EntityKey)!.Value,
            flameShieldCollider.SourcePath)!.RawDamage;
        int flameShieldHits=flameInfantryMatch.ApplyArmyFlameShieldPulse(flameSource.EntityKey,
            flameShieldOrigin,Vector3.UnitZ,1);
        var flameShieldAfter=flameInfantryMatch.Snapshot().Shields
            .ToDictionary(x=>x.CoverIndex,x=>x.Health);
        Check(flameShieldHits==2&&
              park.Covers.Count(x=>x.Fraction==2&&flameShieldAfter[x.SourceIndex]<flameShieldBefore[x.SourceIndex])==2&&
              park.Covers.Where(x=>x.Fraction==1).All(x=>flameShieldAfter[x.SourceIndex]==flameShieldBefore[x.SourceIndex])&&
              Math.Abs(flameShieldBefore[flameShieldCover.SourceIndex]-
                  flameShieldAfter[flameShieldCover.SourceIndex]-expectedFlameShield)<.001f,
            "one Flame pulse damages both source-overlapping enemy shields without the unit bullet coefficient or allied damage");
        var flameVehicleManifest=flameManifest with {MatchId="army-flame-vehicle",
            Players=[flameManifest.Players[0],flameManifest.Players[1] with
            {
                EquippedArmyUnitIds=["ID_UNIT-HUMVEE"],ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
                ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
            }]};
        content.ValidateAllocation(flameVehicleManifest);
        var flameVehicleMatch=new MatchEngine(flameVehicleManifest,content:content,armyChoice:_=>0);
        flameVehicleMatch.Admit(soldierOwner);flameVehicleMatch.Admit(helicopterOwner);
        flameVehicleMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameVehicleMatch.ManifestHash}});
        flameVehicleMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameVehicleMatch.ManifestHash}});
        flameVehicleMatch.Advance(60);
        Check(flameVehicleMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameVehicleMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameVehicleMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameVehicleMatch.ArmyBatch(helicopterOwner).OptionIndexes[0]}}).Code=="army-deploying",
            "opposing Flamethrower and Humvee deploy from trusted allocation");
        for(ulong vehicleTick=61;vehicleTick<=75;vehicleTick++)flameVehicleMatch.Advance(vehicleTick);
        var flameVehicleRows=flameVehicleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var flameVehicleSource=flameVehicleRows.Single(x=>x.OwnerPlayerId==soldierOwner);
        var flameVehicleTarget=flameVehicleRows.Single(x=>x.OwnerPlayerId==helicopterOwner);
        var flameVehicleColliders=flameVehicleMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==flameVehicleTarget.EntityKey&&x.PartComponentFileId!=0).ToArray();
        var flameVehicleCollider=flameVehicleColliders[0];
        Vector3 flameVehicleOrigin=flameVehicleCollider.Hitbox.Center-Vector3.UnitZ;
        float vehicleBefore=flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value;
        var flameVehicleRig=content.GroundVehicleWeapons.For(flameVehicleTarget.UnitId);
        var flameVehicleFacing=flameVehicleMatch.GroundVehicleFacing(flameVehicleTarget.EntityKey)!.Value;
        var flameVehicleRotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,
            MathF.Atan2(flameVehicleFacing.X,flameVehicleFacing.Z));
        float vehicleExpected=0;
        foreach(var candidate in flameVehicleColliders)
        {
            if(!candidate.Hitbox.OverlapsSphere(flameVehicleOrigin,ArmyFlameBurst.Radius))continue;
            var part=flameVehicleRig.BodyParts.Single(x=>x.PartComponentFileId==candidate.PartComponentFileId);
            var colliderSource=part.Colliders.Single(x=>candidate.Hitbox.SourcePath.EndsWith(
                "/"+x.ColliderFileId,StringComparison.Ordinal));
            var center=colliderSource.Kind==PlayerHitboxKind.Capsule?
                new Vector3(flameVehicleTarget.X,flameVehicleTarget.Y,flameVehicleTarget.Z)+
                Vector3.Transform(part.Position,flameVehicleRotation):candidate.Hitbox.Center;
            var hit=ArmyFlameBurst.ResolveCenter(flameVehicleOrigin,Vector3.UnitZ,center,
                flameVehicleMatch.ArmyDamage(flameVehicleSource.EntityKey)!.Value,candidate.Hitbox.SourcePath);
            if(hit==null||hit.RawDamage<=0)continue;
            vehicleExpected=hit.RawDamage*part.Weight*flameVehicleRig.FlamePartCoefficient;
            break;
        }
        Check(flameVehicleMatch.ApplyArmyFlameVehiclePulse(flameVehicleSource.EntityKey,
                  flameVehicleOrigin,Vector3.UnitZ)==1&&
              Math.Abs(vehicleBefore-flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value-
                  vehicleExpected)<.001f&&
              Math.Abs(flameVehicleMatch.Snapshot().Vehicles.Single(x=>x.EntityId==flameVehicleTarget.EntityKey).Health-
                  flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value)<.001f,
            "one Flame pulse applies prefab Awake-time 0.4 body coefficient once and synchronizes vehicle health");
        float vehicleAfter=flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value;
        flameVehicleMatch.ApplyArmyFlameVehiclePulse(flameVehicleSource.EntityKey,
            flameVehicleOrigin,-Vector3.UnitZ);
        Check(flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)==vehicleAfter,
            "vehicle Flame rejects a rear-facing cone before changing shared health");
        Vector3 vehicleMineOrigin=flameVehicleCollider.Hitbox.Center;
        float vehicleBeforeMine=flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value;
        Check(flameVehicleMatch.ApplyLandMineVehicleExplosion(soldierOwner,vehicleMineOrigin,10)==1&&
              Math.Abs(vehicleBeforeMine-flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value-
                  10)<.001f&&
              Math.Abs(flameVehicleMatch.Snapshot().Vehicles.Single(x=>x.EntityId==flameVehicleTarget.EntityKey).Health-
                  flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value)<.001f,
            "host Land Mine blast chooses one nearest Humvee damage part without bullet armor coefficient");
        float vehicleBeforeFriendlyMine=flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value;
        Check(flameVehicleMatch.ApplyLandMineVehicleExplosion(helicopterOwner,vehicleMineOrigin,10)==1&&
              Math.Abs(vehicleBeforeFriendlyMine-flameVehicleMatch.ArmyHealth(flameVehicleTarget.EntityKey)!.Value-
                  5)<.001f,
            "recovered friend-damage coefficient halves a Land Mine blast against an allied vehicle");
        Reject(()=>flameVehicleMatch.ApplyLandMineVehicleExplosion(soldierOwner,vehicleMineOrigin,float.NaN));
        var minePassengerParts=flameVehicleMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==flameVehicleTarget.EntityKey&&x.PassengerRole=="gunner").ToArray();
        Vector3 passengerMineOrigin=minePassengerParts.First(x=>x.Hitbox.Weight==1.5f)
            .Hitbox.Center+Vector3.UnitY*.15f;
        var selectedMinePassengerPart=minePassengerParts.Where(x=>x.Hitbox.OverlapsSphere(
                passengerMineOrigin,content.LandMines.HurtRadius))
            .OrderBy(x=>x.Hitbox.BoundsDistanceToPoint(passengerMineOrigin))
            .ThenBy(x=>x.Hitbox.SourcePath,StringComparer.Ordinal).First();
        float passengerBeforeMine=flameVehicleMatch.VehiclePassengers(flameVehicleTarget.EntityKey)
            .Single(x=>x.Role=="gunner").Health;
        uint enemyHitsBeforeMine=flameVehicleMatch.Snapshot().Players
            .Single(x=>x.PlayerId==soldierOwner).ConfirmedEnemyHits;
        uint bulletHitsBeforeMine=flameVehicleMatch.Snapshot().Players
            .Single(x=>x.PlayerId==soldierOwner).ConfirmedPlayerBulletHits;
        Check(selectedMinePassengerPart.Hitbox.Weight==1.5f&&
              flameVehicleMatch.ApplyLandMinePassengerExplosion(soldierOwner,passengerMineOrigin,10)==1&&
              Math.Abs(passengerBeforeMine-flameVehicleMatch.VehiclePassengers(flameVehicleTarget.EntityKey)
                  .Single(x=>x.Role=="gunner").Health-10)<.001f&&
              flameVehicleMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
                  .ConfirmedEnemyHits==enemyHitsBeforeMine+1&&
              flameVehicleMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
                  .ConfirmedPlayerBulletHits==bulletHitsBeforeMine,
            "Land Mine head contact damages its passenger owner once without bullet head weight");
        float passengerBeforeFriendlyMine=flameVehicleMatch.VehiclePassengers(flameVehicleTarget.EntityKey)
            .Single(x=>x.Role=="gunner").Health;
        Check(flameVehicleMatch.ApplyLandMinePassengerExplosion(helicopterOwner,passengerMineOrigin,10)==1&&
              Math.Abs(passengerBeforeFriendlyMine-flameVehicleMatch.VehiclePassengers(flameVehicleTarget.EntityKey)
                  .Single(x=>x.Role=="gunner").Health-5)<.001f,
            "recovered friend-damage coefficient also applies to a vehicle passenger mine blast");
        Reject(()=>flameVehicleMatch.ApplyLandMinePassengerExplosion(soldierOwner,passengerMineOrigin,float.NaN));
        var vehicleTriggerManifest=flameVehicleManifest with
        {
            MatchId="land-mine-vehicle-trigger"
        };
        var vehicleTriggerMatch=new MatchEngine(vehicleTriggerManifest,content:content,armyChoice:_=>0);
        vehicleTriggerMatch.Admit(soldierOwner);
        vehicleTriggerMatch.Admit(helicopterOwner);
        vehicleTriggerMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=vehicleTriggerMatch.ManifestHash}});
        vehicleTriggerMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=vehicleTriggerMatch.ManifestHash}});
        vehicleTriggerMatch.Advance(60);
        int triggerHumveeOption=vehicleTriggerMatch.ArmyBatch(helicopterOwner).OptionIndexes[0];
        Check(vehicleTriggerMatch.Command(helicopterOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=triggerHumveeOption}}).Code=="army-deploying",
            "mine trigger fixture deploys an opposing source Humvee");
        vehicleTriggerMatch.Advance(61);
        var triggerVehicle=vehicleTriggerMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(row=>row.UnitId=="ID_UNIT-HUMVEE");
        var triggerBody=vehicleTriggerMatch.GroundVehicleShotTargets(soldierOwner)
            .First(part=>part.EntityId==triggerVehicle.EntityKey&&part.GroundVehicleBody);
        Vector3 contact=triggerBody.Hitbox.Center;
        float triggerHealth=vehicleTriggerMatch.ArmyHealth(triggerVehicle.EntityKey)!.Value;
        Check(vehicleTriggerMatch.TryRegisterLandMine(new string('6',32),soldierOwner,
            contact,10f),"host-only mine placement binds a current vehicle body contact");
        ulong triggerMineId=vehicleTriggerMatch.Snapshot().LandMines.Single().EntityId;
        vehicleTriggerMatch.Advance(62);
        var triggerEvents=vehicleTriggerMatch.EventBatch(soldierOwner,0).Events;
        Check(vehicleTriggerMatch.Snapshot().LandMines.Count==0&&
              triggerEvents.Any(row=>row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==triggerMineId&&
                  row.Reason=="vehicle-trigger:"+triggerVehicle.EntityKey)&&
              vehicleTriggerMatch.ArmyHealth(triggerVehicle.EntityKey)<triggerHealth,
            "a current opposing Humvee body naturally triggers and consumes a Land Mine");
        var friendlyBody=vehicleTriggerMatch.GroundVehicleShotTargets(soldierOwner)
            .First(part=>part.EntityId==triggerVehicle.EntityKey&&part.GroundVehicleBody);
        Check(vehicleTriggerMatch.TryRegisterLandMine(new string('7',32),helicopterOwner,
            friendlyBody.Hitbox.Center,10f),
            "host-only allied mine placement uses the same current Humvee contact");
        ulong alliedMineId=vehicleTriggerMatch.Snapshot().LandMines.Single().EntityId;
        vehicleTriggerMatch.Advance(63);
        Check(vehicleTriggerMatch.Snapshot().LandMines.Any(row=>row.EntityId==alliedMineId)&&
              !vehicleTriggerMatch.EventBatch(helicopterOwner,0).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&row.ProjectileId==alliedMineId),
            "allied Humvee contact does not trigger its own faction's Land Mine");
        var passengerTriggerManifest=vehicleTriggerManifest with
        {
            MatchId="land-mine-passenger-trigger"
        };
        var passengerTriggerMatch=new MatchEngine(passengerTriggerManifest,content:content,
            armyChoice:_=>0);
        passengerTriggerMatch.Admit(soldierOwner);
        passengerTriggerMatch.Admit(helicopterOwner);
        passengerTriggerMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=passengerTriggerMatch.ManifestHash}});
        passengerTriggerMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=passengerTriggerMatch.ManifestHash}});
        passengerTriggerMatch.Advance(60);
        int passengerHumveeOption=passengerTriggerMatch.ArmyBatch(helicopterOwner).OptionIndexes[0];
        Check(passengerTriggerMatch.Command(helicopterOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=passengerHumveeOption}}).Code=="army-deploying",
            "passenger mine fixture deploys an opposing source Humvee");
        passengerTriggerMatch.Advance(61);
        var minePassengerVehicle=passengerTriggerMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(row=>row.UnitId=="ID_UNIT-HUMVEE");
        var minePassengerTargets=passengerTriggerMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(row=>row.EntityId==minePassengerVehicle.EntityKey).ToArray();
        var passengerBodyParts=minePassengerTargets.Where(row=>row.GroundVehicleBody)
            .Select(row=>row.Hitbox).ToArray();
        Vector3? passengerOnlyContact=null;
        foreach(var part in minePassengerTargets.Where(row=>row.PassengerRole=="gunner"))
        {
            foreach(float lift in new[]{0f,.1f,.2f,.3f,.4f,.5f})
            {
                var candidate=part.Hitbox.Center+Vector3.UnitY*lift;
                if(!LandMineExplosion.Triggered(candidate,content.LandMines.Prefab,
                       new[]{part.Hitbox})||
                   LandMineExplosion.Triggered(candidate,content.LandMines.Prefab,
                       passengerBodyParts))continue;
                passengerOnlyContact=candidate;
                break;
            }
            if(passengerOnlyContact.HasValue)break;
        }
        Check(passengerOnlyContact.HasValue,
            "a current Humvee gunner pose has a trigger contact outside the vehicle body");
        Check(passengerTriggerMatch.TryRegisterLandMine(new string('8',32),soldierOwner,
            passengerOnlyContact!.Value,10f),
            "host-only mine placement binds a passenger-only trigger contact");
        ulong passengerTriggerMineId=passengerTriggerMatch.Snapshot().LandMines.Single().EntityId;
        passengerTriggerMatch.Advance(62);
        Check(passengerTriggerMatch.Snapshot().LandMines.Count==0&&
              passengerTriggerMatch.EventBatch(soldierOwner,0).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==passengerTriggerMineId&&
                  row.Reason=="vehicle-passenger-trigger:"+minePassengerVehicle.EntityKey+":gunner"),
            "a current non-metal Humvee gunner collider naturally triggers the Land Mine");
        var flameRepairManifest=flameManifest with {MatchId="army-flame-repair-drone",
            Players=[flameManifest.Players[0],flameManifest.Players[1] with
            {
                EquippedArmyUnitIds=["ID_UNIT-TRANSPORTER"],ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[71],ArmyEliteUpgradeIndexes=[-1],
                ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
                ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
            }]};
        content.ValidateAllocation(flameRepairManifest);
        var flameRepairMatch=new MatchEngine(flameRepairManifest,content:content,armyChoice:_=>0);
        flameRepairMatch.Admit(soldierOwner);flameRepairMatch.Admit(helicopterOwner);
        flameRepairMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameRepairMatch.ManifestHash}});
        flameRepairMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameRepairMatch.ManifestHash}});
        flameRepairMatch.Advance(60);
        Check(flameRepairMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameRepairMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameRepairMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameRepairMatch.ArmyBatch(helicopterOwner).OptionIndexes[0]}}).Code=="army-deploying",
            "opposing Flamethrower and special Transporter deploy from trusted allocations");
        for(ulong flameRepairTick=61;flameRepairTick<=75;flameRepairTick++)
            flameRepairMatch.Advance(flameRepairTick);
        var flameRepairRows=flameRepairMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var flameRepairSource=flameRepairRows.Single(x=>x.OwnerPlayerId==soldierOwner);
        var flameRepairTransporter=flameRepairRows.Single(x=>x.OwnerPlayerId==helicopterOwner);
        var flameRepairDrones=flameRepairMatch.TransporterRepairDrones(flameRepairTransporter.EntityKey);
        var flameRepairBox=flameRepairMatch.GroundVehicleShotTargets(soldierOwner)
            .Single(x=>x.EntityId==flameRepairTransporter.EntityKey&&x.RepairDronePathIndex==0).Hitbox;
        Vector3 flameRepairOrigin=flameRepairBox.Center-Vector3.UnitZ;
        float repairExpected=ArmyFlameBurst.ResolveParts(flameRepairOrigin,Vector3.UnitZ,
            [flameRepairBox],flameRepairMatch.ArmyDamage(flameRepairSource.EntityKey)!.Value)!.RawDamage*
            content.GroundVehicleWeapons.RepairDronePrefab.FlameCoefficient;
        Check(flameRepairDrones.Count==2&&flameRepairDrones[0].Active&&
              content.GroundVehicleWeapons.RepairDronePrefab.DamageComponentFileId==11470521&&
              flameRepairMatch.ApplyArmyFlameRepairDronePulse(flameRepairSource.EntityKey,
                  flameRepairOrigin,Vector3.UnitZ)>=1&&
              Math.Abs(flameRepairDrones[0].Health-
                  flameRepairMatch.TransporterRepairDrones(flameRepairTransporter.EntityKey)[0].Health-
                  repairExpected)<.001f,
            "one Flame pulse applies the pinned coefficient-one root damage to a live repair mini-drone");
        ulong repairFlameEventCursor=flameRepairMatch.EventBatch(soldierOwner,0).LatestEventId;
        int repairFlamePulses=checked((int)Math.Ceiling(flameRepairDrones[0].Health/repairExpected)+1);
        Check(repairFlamePulses is >0 and <10000,
            "source Flame damage downs the repair mini-drone within bounded host pulses");
        for(int repairFlamePulse=0;repairFlamePulse<repairFlamePulses&&
            flameRepairMatch.TransporterRepairDrones(flameRepairTransporter.EntityKey)[0].Active;
            repairFlamePulse++)
            flameRepairMatch.ApplyArmyFlameRepairDronePulse(flameRepairSource.EntityKey,
                flameRepairOrigin,Vector3.UnitZ);
        Check(!flameRepairMatch.TransporterRepairDrones(flameRepairTransporter.EntityKey)[0].Active&&
              flameRepairMatch.GroundVehicleShotTargets(soldierOwner).All(x=>
                  x.EntityId!=flameRepairTransporter.EntityKey||x.RepairDronePathIndex!=0)&&
              flameRepairMatch.EventBatch(soldierOwner,repairFlameEventCursor).Events.Any(x=>
                  x.Kind==MatchEventKind.VehicleRepairDroneDown&&
                  x.ProjectileId==flameRepairTransporter.EntityKey),
            "lethal Flame removes repair-drone collision and publishes its source down event");
        var flameDroneManifest=flameManifest with {MatchId="army-flame-drone",
            Players=[flameManifest.Players[0],flameManifest.Players[1] with
            {
                EquippedArmyUnitIds=["ID_UNIT-DRONE"],ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
                ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
            }]};
        content.ValidateAllocation(flameDroneManifest);
        var flameDroneMatch=new MatchEngine(flameDroneManifest,content:content,armyChoice:_=>0);
        flameDroneMatch.Admit(soldierOwner);flameDroneMatch.Admit(helicopterOwner);
        flameDroneMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameDroneMatch.ManifestHash}});
        flameDroneMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameDroneMatch.ManifestHash}});
        flameDroneMatch.Advance(60);
        Check(flameDroneMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameDroneMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameDroneMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameDroneMatch.ArmyBatch(helicopterOwner).OptionIndexes[0]}}).Code=="army-deploying",
            "opposing Flamethrower and Drone deploy from trusted allocations");
        for(ulong flameDroneTick=61;flameDroneTick<=75;flameDroneTick++)
            flameDroneMatch.Advance(flameDroneTick);
        var flameDroneRows=flameDroneMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var flameDroneSource=flameDroneRows.Single(x=>x.OwnerPlayerId==soldierOwner);
        var flameDroneTarget=flameDroneRows.Single(x=>x.OwnerPlayerId==helicopterOwner);
        var flameDroneBoxes=flameDroneMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==flameDroneTarget.EntityKey).ToArray();
        var flameDroneRoot=flameDroneBoxes.Single(x=>x.PartComponentFileId==6544804);
        Check(flameDroneBoxes.Length==2&&
              flameDroneBoxes.Single(x=>x.PartComponentFileId==13511718).Layer==8&&
              DroneColliderCatalog.FlameCoefficient==1,
            "source Drone Flame authority belongs to the root box, not its child sphere");
        Vector3 flameDroneOrigin=flameDroneRoot.Hitbox.Center-Vector3.UnitZ;
        float droneExpected=ArmyFlameBurst.ResolveParts(flameDroneOrigin,Vector3.UnitZ,
            [flameDroneRoot.Hitbox],flameDroneMatch.ArmyDamage(flameDroneSource.EntityKey)!.Value)!.RawDamage;
        float droneBefore=flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value;
        Check(flameDroneMatch.ApplyArmyFlameDronePulse(flameDroneSource.EntityKey,
                  flameDroneOrigin,Vector3.UnitZ)==1&&
              Math.Abs(droneBefore-flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value-
                  droneExpected)<.001f,
            "one Flame pulse damages the opposing Drone root by its source coefficient-one amount");
        Vector3 droneMineOrigin=flameDroneRoot.Hitbox.Center;
        float droneBeforeMine=flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value;
        Check(flameDroneMatch.ApplyLandMineDroneExplosion(soldierOwner,droneMineOrigin,10)==1&&
              Math.Abs(flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value-
                  (droneBeforeMine-10))<.001f,
            "Land Mine blast damages only the deployed Drone root damage box");
        float droneBeforeFriendlyMine=flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value;
        Check(flameDroneMatch.ApplyLandMineDroneExplosion(helicopterOwner,droneMineOrigin,10)==1&&
              Math.Abs(flameDroneMatch.ArmyHealth(flameDroneTarget.EntityKey)!.Value-
                  (droneBeforeFriendlyMine-5))<.001f,
            "allied Land Mine blast uses recovered half damage on a Drone");
        Reject(()=>flameDroneMatch.ApplyLandMineDroneExplosion(soldierOwner,droneMineOrigin,float.NaN));
        Check(flameDroneMatch.TryRegisterLandMine(new string('8',32),soldierOwner,
                  droneMineOrigin,10f),
            "host-only mine placement overlaps the opposing Drone root");
        ulong metalDroneMineId=flameDroneMatch.Snapshot().LandMines.Single().EntityId;
        flameDroneMatch.Advance(76);
        var movedMetalDroneRoot=flameDroneMatch.GroundVehicleShotTargets(soldierOwner)
            .Single(target=>target.EntityId==flameDroneTarget.EntityKey&&target.DroneRoot).Hitbox;
        Check(LandMineExplosion.Triggered(droneMineOrigin,content.LandMines.Prefab,
                  new[]{movedMetalDroneRoot})&&
              flameDroneMatch.Snapshot().LandMines.Any(mine=>
                  mine.EntityId==metalDroneMineId),
            "Drone's source metal root does not trigger a Land Mine on the normal host tick");
        var flameHelicopterManifest=flameManifest with {MatchId="army-flame-helicopter",
            Players=[flameManifest.Players[0],flameManifest.Players[1] with
            {
                EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],
                ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[1f]
            }]};
        content.ValidateAllocation(flameHelicopterManifest);
        var flameHelicopterMatch=new MatchEngine(flameHelicopterManifest,content:content,armyChoice:_=>0);
        flameHelicopterMatch.Admit(soldierOwner);flameHelicopterMatch.Admit(helicopterOwner);
        flameHelicopterMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameHelicopterMatch.ManifestHash}});
        flameHelicopterMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=flameHelicopterMatch.ManifestHash}});
        flameHelicopterMatch.Advance(60);
        Check(flameHelicopterMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameHelicopterMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameHelicopterMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=flameHelicopterMatch.ArmyBatch(helicopterOwner).OptionIndexes[0]}}).Code=="army-deploying",
            "opposing Flamethrower and Helicopter deploy from trusted allocations");
        for(ulong flameHelicopterTick=61;flameHelicopterTick<=75;flameHelicopterTick++)
            flameHelicopterMatch.Advance(flameHelicopterTick);
        var flameHelicopterRows=flameHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var flameHelicopterSource=flameHelicopterRows.Single(x=>x.OwnerPlayerId==soldierOwner);
        var flameHelicopterTarget=flameHelicopterRows.Single(x=>x.OwnerPlayerId==helicopterOwner);
        var helicopterFlameBoxes=flameHelicopterMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==flameHelicopterTarget.EntityKey&&!x.HelicopterGunner)
            .Select(x=>x.Hitbox).ToArray();
        var helicopterShotWorld=new ShotCollisionWorld(null,
        [
            new(soldierOwner,flameHelicopterMatch.CombatPose(soldierOwner).Collision),
            new(helicopterOwner,flameHelicopterMatch.CombatPose(helicopterOwner).Collision)
        ],dynamicTargets:flameHelicopterMatch.GroundVehicleShotTargets);
        var helicopterShotOrigin=helicopterFlameBoxes[0].Center-Vector3.UnitZ*2;
        var helicopterOverlap=helicopterShotWorld.OverlapEnemy(soldierOwner,
            helicopterShotOrigin,4,1u<<26);
        Check(helicopterOverlap.Any(x=>x.MainEntityId==
                  "helicopter:"+flameHelicopterTarget.EntityKey)&&
              !helicopterShotWorld.OverlapEnemy(soldierOwner,helicopterShotOrigin,4,1u<<8)
                  .Any(x=>x.MainEntityId=="helicopter:"+flameHelicopterTarget.EntityKey),
              "live source-pinned Helicopter body enters shotgun overlap on its faction mech layer");
        var helicopterPlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            helicopterShotOrigin,helicopterFlameBoxes[0].Center+Vector3.UnitX*.5f,
            helicopterOverlap);
        Check(helicopterPlan.RealPellets.Count(x=>helicopterOverlap.Any(y=>
                  y.MainEntityId=="helicopter:"+flameHelicopterTarget.EntityKey&&
                  y.EntityId==x.EntityId)) is >=1 and <=2,
              "live Helicopter's eleven damage parts share the shotgun two-extra root limit");
        Vector3 helicopterFlameOrigin=helicopterFlameBoxes[0].Center-Vector3.UnitZ;
        float helicopterFlameExpected=ArmyFlameBurst.ResolveParts(helicopterFlameOrigin,Vector3.UnitZ,
            helicopterFlameBoxes,flameHelicopterMatch.ArmyDamage(flameHelicopterSource.EntityKey)!.Value)!.RawDamage*
            HelicopterBodyColliderCatalog.FlamePartCoefficient;
        float helicopterFlameBefore=flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value;
        float helicopterGunnerBefore=flameHelicopterTarget.HelicopterGunnerHealth;
        Check(helicopterFlameBoxes.Length==11&&
              flameHelicopterMatch.ApplyArmyFlameHelicopterPulse(flameHelicopterSource.EntityKey,
                  helicopterFlameOrigin,Vector3.UnitZ)==1&&
              Math.Abs(helicopterFlameBefore-
                  flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value-
                  helicopterFlameExpected)<.001f&&
              flameHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                  .Single(x=>x.EntityKey==flameHelicopterTarget.EntityKey).HelicopterGunnerHealth==helicopterGunnerBefore,
            "one Flame pulse damages the Helicopter body once without promoting gunner colliders");
        Vector3 helicopterMineOrigin=helicopterFlameBoxes[0].Center;
        float helicopterBeforeMine=flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value;
        Check(flameHelicopterMatch.ApplyLandMineHelicopterBodyExplosion(soldierOwner,
                  helicopterMineOrigin,10)==1&&
              Math.Abs(flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value-
                  (helicopterBeforeMine-10))<.001f&&
              flameHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                  .Single(x=>x.EntityKey==flameHelicopterTarget.EntityKey).HelicopterGunnerHealth==helicopterGunnerBefore,
            "Land Mine blast selects one current Helicopter body box without merging gunner health");
        float helicopterBeforeFriendlyMine=flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value;
        Check(flameHelicopterMatch.ApplyLandMineHelicopterBodyExplosion(helicopterOwner,
                  helicopterMineOrigin,10)==1&&
              Math.Abs(flameHelicopterMatch.ArmyHealth(flameHelicopterTarget.EntityKey)!.Value-
                  (helicopterBeforeFriendlyMine-5))<.001f,
            "allied Land Mine blast uses recovered half damage on Helicopter body");
        Reject(()=>flameHelicopterMatch.ApplyLandMineHelicopterBodyExplosion(soldierOwner,
            helicopterMineOrigin,float.NaN));
        ulong helicopterTriggerCursor=flameHelicopterMatch.EventBatch(soldierOwner,0).LatestEventId;
        Check(flameHelicopterMatch.TryRegisterLandMine(new string('6',32),soldierOwner,
                  helicopterMineOrigin,10f),
            "host-only mine placement binds a current Helicopter body child");
        ulong helicopterTriggerMineId=flameHelicopterMatch.Snapshot().LandMines.Single().EntityId;
        flameHelicopterMatch.Advance(76);
        Check(flameHelicopterMatch.Snapshot().LandMines.Count==0&&
              flameHelicopterMatch.EventBatch(soldierOwner,helicopterTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==helicopterTriggerMineId&&
                  row.Reason=="air-trigger:"+flameHelicopterTarget.EntityKey),
            "a non-metal Helicopter body child triggers a mine on the normal host tick");
        var flameDecoyManifest=flameManifest with {MatchId="army-flame-decoy",
            SceneMasterPlayerId=soldierOwner,
            Players=flameManifest.Players.Select(p=>p with {PlayerLevel=22}).ToArray()};
        content.ValidateAllocation(flameDecoyManifest);
        var flameDecoyMatch=new MatchEngine(flameDecoyManifest,content:content,armyChoice:_=>0);
        flameDecoyMatch.ConfigureBattleAllocations([
            new(soldierOwner,["CardDecoy"],[],[0],[-1],[-1]),
            new(helicopterOwner,["CardDecoy"],[],[0],[-1],[-1])]);
        flameDecoyMatch.Admit(soldierOwner);flameDecoyMatch.Admit(helicopterOwner);
        MatchCommand FlameDecoyCards()=>new(){CommandId=1,SelectCards=new()
            {CardIds={"CardDecoy"},NormalUpgradeIndexes={0},
             SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}};
        Check(flameDecoyMatch.Command(soldierOwner,FlameDecoyCards()).Code=="cards-selected"&&
              flameDecoyMatch.Command(helicopterOwner,FlameDecoyCards()).Code=="cards-selected",
            "Flame-versus-Decoy match binds both source cards before admission");
        flameDecoyMatch.Command(soldierOwner,new(){CommandId=2,
            Ready=new(){ManifestHash=flameDecoyMatch.ManifestHash}});
        flameDecoyMatch.Command(helicopterOwner,new(){CommandId=2,
            Ready=new(){ManifestHash=flameDecoyMatch.ManifestHash}});
        flameDecoyMatch.Advance(60);
        Check(flameDecoyMatch.Command(soldierOwner,new(){CommandId=3,DeployArmy=new()
            {OptionIndex=flameDecoyMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameDecoyMatch.Command(soldierOwner,new(){CommandId=4,UseDecoy=new()
            {RequestId=new string('a',32)}}).Code=="decoy-spawned"&&
              flameDecoyMatch.Command(helicopterOwner,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('b',32)}}).Code=="decoy-spawned",
            "deployed Flame infantry and both factions' Decoys coexist under host ownership");
        for(ulong flameDecoyTick=61;flameDecoyTick<=75;flameDecoyTick++)
            flameDecoyMatch.Advance(flameDecoyTick);
        var flameDecoySource=flameDecoyMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.OwnerPlayerId==soldierOwner);
        var enemyDecoy=flameDecoyMatch.Snapshot().Decoys.First(x=>x.OwnerPlayerId==helicopterOwner);
        var allyDecoy=flameDecoyMatch.Snapshot().Decoys.First(x=>x.OwnerPlayerId==soldierOwner);
        var enemyDecoyBox=flameDecoyMatch.GroundVehicleShotTargets(soldierOwner)
            .Single(x=>x.Decoy&&x.EntityId==enemyDecoy.EntityId).Hitbox;
        var decoyPulseOrigin=enemyDecoyBox.Center-Vector3.UnitZ;
        float decoyExpected=ArmyFlameBurst.ResolveParts(decoyPulseOrigin,Vector3.UnitZ,
            [enemyDecoyBox],flameDecoyMatch.ArmyDamage(flameDecoySource.EntityKey)!.Value)!.RawDamage*
            content.Decoys.Prefab.FlameCoefficient;
        float decoyBefore=flameDecoyMatch.DecoyHealth(enemyDecoy.EntityId)!.Value;
        float allyDecoyBefore=flameDecoyMatch.DecoyHealth(allyDecoy.EntityId)!.Value;
        Check(flameDecoyMatch.ApplyArmyFlameDecoyPulse(flameDecoySource.EntityKey,
                  decoyPulseOrigin,Vector3.UnitZ)>=1&&
              Math.Abs(decoyBefore-flameDecoyMatch.DecoyHealth(enemyDecoy.EntityId)!.Value-
                  decoyExpected)<.001f&&
              flameDecoyMatch.DecoyHealth(allyDecoy.EntityId)==allyDecoyBefore,
            "one Flame pulse applies the prefab's coefficient-one damage to an enemy Decoy only");
        int remainingDecoyPulses=checked((int)Math.Ceiling(decoyBefore/decoyExpected)+1);
        Check(remainingDecoyPulses is >0 and <10000,
            "source Flame damage reaches a Decoy within bounded host pulses");
        for(int flameDecoyPulse=0;flameDecoyPulse<remainingDecoyPulses&&
            flameDecoyMatch.DecoyHealth(enemyDecoy.EntityId)!=null;flameDecoyPulse++)
            flameDecoyMatch.ApplyArmyFlameDecoyPulse(flameDecoySource.EntityKey,
                decoyPulseOrigin,Vector3.UnitZ);
        var flameDecoyEvents=new List<MatchEvent>();ulong flameDecoyCursor=0,flameDecoyLatest;
        do
        {
            var page=flameDecoyMatch.EventBatch(soldierOwner,flameDecoyCursor);
            flameDecoyLatest=page.LatestEventId;flameDecoyEvents.AddRange(page.Events);
            if(page.Events.Count>0)flameDecoyCursor=page.Events[^1].EventId;
        }while(flameDecoyCursor<flameDecoyLatest);
        Check(flameDecoyMatch.DecoyHealth(enemyDecoy.EntityId)==null&&
              !flameDecoyMatch.DecoyObstacleOccupied(enemyDecoy.ObstacleComponentFileId)&&
              flameDecoyMatch.DroneTargetSnapshot().All(x=>x.Id!="decoy:"+enemyDecoy.EntityId)&&
              flameDecoyEvents.Any(x=>
                  x.Kind==MatchEventKind.DecoyDestroyed&&x.ProjectileId==enemyDecoy.EntityId)&&
              flameDecoyMatch.DecoyHealth(allyDecoy.EntityId)==allyDecoyBefore,
            "lethal Flame damage releases Decoy obstacle and drone authority without touching an allied Decoy");
        var mineDecoyBox=flameDecoyMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(row=>row.Decoy&&row.EntityId==allyDecoy.EntityId).Hitbox;
        ulong decoyTriggerCursor=flameDecoyMatch.EventBatch(helicopterOwner,0).LatestEventId;
        Check(flameDecoyMatch.TryRegisterLandMine(new string('c',32),helicopterOwner,
                  mineDecoyBox.Center,10f),
            "host-only mine placement binds an opposing non-metal Decoy root");
        ulong decoyTriggerMineId=flameDecoyMatch.Snapshot().LandMines.Single().EntityId;
        flameDecoyMatch.Advance(76);
        Check(flameDecoyMatch.Snapshot().LandMines.Count==0&&
              flameDecoyMatch.EventBatch(helicopterOwner,decoyTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==decoyTriggerMineId&&
                  row.Reason=="decoy-trigger:"+allyDecoy.EntityId)&&
              flameDecoyMatch.DecoyHealth(allyDecoy.EntityId)<allyDecoyBefore,
            "an opposing Decoy root naturally triggers a mine and takes host blast damage");
        var alliedDecoyBox=flameDecoyMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(row=>row.Decoy&&row.EntityId==allyDecoy.EntityId).Hitbox;
        Check(flameDecoyMatch.TryRegisterLandMine(new string('d',32),soldierOwner,
                  alliedDecoyBox.Center,10f),
            "host-only allied mine placement uses the same source Decoy root");
        ulong alliedDecoyMineId=flameDecoyMatch.Snapshot().LandMines.Single().EntityId;
        flameDecoyMatch.Advance(77);
        Check(flameDecoyMatch.Snapshot().LandMines.Any(row=>row.EntityId==alliedDecoyMineId)&&
              !flameDecoyMatch.EventBatch(soldierOwner,decoyTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==alliedDecoyMineId),
            "an allied Decoy root does not trigger its faction's Land Mine");
        var flameTurretManifest=flameDecoyManifest with {MatchId="army-flame-heavy-turret"};
        var flameTurretMatch=new MatchEngine(flameTurretManifest,content:content,armyChoice:_=>0);
        flameTurretMatch.ConfigureBattleAllocations([
            new(soldierOwner,["CardHeavyTurret"],[],[0],[-1],[-1]),
            new(helicopterOwner,["CardHeavyTurret"],[],[0],[-1],[-1])]);
        flameTurretMatch.Admit(soldierOwner);flameTurretMatch.Admit(helicopterOwner);
        MatchCommand FlameTurretCards()=>new(){CommandId=1,SelectCards=new()
            {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
             SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}};
        Check(flameTurretMatch.Command(soldierOwner,FlameTurretCards()).Code=="cards-selected"&&
              flameTurretMatch.Command(helicopterOwner,FlameTurretCards()).Code=="cards-selected",
            "Flame-versus-Heavy-Turret match binds both trusted cards");
        flameTurretMatch.Command(soldierOwner,new(){CommandId=2,
            Ready=new(){ManifestHash=flameTurretMatch.ManifestHash}});
        flameTurretMatch.Command(helicopterOwner,new(){CommandId=2,
            Ready=new(){ManifestHash=flameTurretMatch.ManifestHash}});
        flameTurretMatch.Advance(60);
        Check(flameTurretMatch.Command(soldierOwner,new(){CommandId=3,DeployArmy=new()
            {OptionIndex=flameTurretMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              flameTurretMatch.Command(soldierOwner,new(){CommandId=4,UseHeavyTurret=new()
            {RequestId=new string('a',32)}}).Code=="heavy-turret-spawned"&&
              flameTurretMatch.Command(helicopterOwner,new(){CommandId=3,UseHeavyTurret=new()
            {RequestId=new string('b',32)}}).Code=="heavy-turret-spawned",
            "host deploys one Flamethrower and both factions' Heavy Turrets");
        for(ulong flameTurretTick=61;flameTurretTick<=75;flameTurretTick++)
            flameTurretMatch.Advance(flameTurretTick);
        var flameTurretSource=flameTurretMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.OwnerPlayerId==soldierOwner);
        var opposingTurret=flameTurretMatch.Snapshot().HeavyTurrets.Single(x=>x.OwnerPlayerId==helicopterOwner);
        var alliedTurret=flameTurretMatch.Snapshot().HeavyTurrets.Single(x=>x.OwnerPlayerId==soldierOwner);
        var turretBoxes=flameTurretMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.HeavyTurret&&x.EntityId==opposingTurret.EntityId).ToArray();
        Vector3 turretFlameOrigin=turretBoxes[0].Hitbox.Center-Vector3.UnitZ;
        var turretHit=ArmyFlameBurst.ResolveParts(turretFlameOrigin,Vector3.UnitZ,
            turretBoxes.Select(x=>x.Hitbox).ToArray(),
            flameTurretMatch.ArmyDamage(flameTurretSource.EntityKey)!.Value)!;
        var turretPart=turretBoxes.Single(x=>x.Hitbox.SourcePath==turretHit.PartPath);
        float expectedTurretFlame=turretHit.RawDamage*content.HeavyTurrets.Colliders
            .Single(x=>x.ComponentFileId==turretPart.PartComponentFileId).FlameWeight*
            content.HeavyTurrets.FlameCoefficient;
        float turretBefore=flameTurretMatch.HeavyTurretHealth(opposingTurret.EntityId)!.Value;
        float alliedTurretBefore=flameTurretMatch.HeavyTurretHealth(alliedTurret.EntityId)!.Value;
        Check(flameTurretMatch.ApplyArmyFlameHeavyTurretPulse(flameTurretSource.EntityKey,
                  turretFlameOrigin,Vector3.UnitZ)==1&&
              Math.Abs(turretBefore-flameTurretMatch.HeavyTurretHealth(opposingTurret.EntityId)!.Value-
                  expectedTurretFlame)<.001f&&
              flameTurretMatch.HeavyTurretHealth(alliedTurret.EntityId)==alliedTurretBefore,
            "one Flame pulse applies one source-part hit to an opposing Heavy Turret only");
        var mineTurretPart=flameTurretMatch.GroundVehicleShotTargets(soldierOwner)
            .First(row=>row.HeavyTurret&&row.EntityId==opposingTurret.EntityId);
        float turretHealthBeforeMine=flameTurretMatch.HeavyTurretHealth(opposingTurret.EntityId)!.Value;
        ulong turretTriggerCursor=flameTurretMatch.EventBatch(soldierOwner,0).LatestEventId;
        Check(flameTurretMatch.TryRegisterLandMine(new string('c',32),soldierOwner,
                  mineTurretPart.Hitbox.Center,10f),
            "host-only mine placement binds a current opposing Heavy Turret child part");
        ulong turretTriggerMineId=flameTurretMatch.Snapshot().LandMines.Single().EntityId;
        flameTurretMatch.Advance(76);
        Check(flameTurretMatch.Snapshot().LandMines.Count==0&&
              flameTurretMatch.EventBatch(soldierOwner,turretTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==turretTriggerMineId&&
                  row.Reason=="heavy-turret-trigger:"+opposingTurret.EntityId)&&
              flameTurretMatch.HeavyTurretHealth(opposingTurret.EntityId)<turretHealthBeforeMine,
            "a non-metal Heavy Turret child part triggers a mine and takes host blast damage");
        var friendlyTurretPart=flameTurretMatch.GroundVehicleShotTargets(soldierOwner)
            .First(row=>row.HeavyTurret&&row.EntityId==opposingTurret.EntityId);
        Check(flameTurretMatch.TryRegisterLandMine(new string('d',32),helicopterOwner,
                  friendlyTurretPart.Hitbox.Center,10f),
            "host-only allied mine placement uses the same Heavy Turret child part");
        ulong friendlyTurretMineId=flameTurretMatch.Snapshot().LandMines.Single().EntityId;
        flameTurretMatch.Advance(77);
        Check(flameTurretMatch.Snapshot().LandMines.Any(row=>row.EntityId==friendlyTurretMineId)&&
              !flameTurretMatch.EventBatch(helicopterOwner,turretTriggerCursor).Events.Any(row=>
                  row.Kind==MatchEventKind.LandMineTriggered&&
                  row.ProjectileId==friendlyTurretMineId),
            "allied Heavy Turret child contact leaves its faction's Land Mine active");
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
        var helicopterSpawn=deathMatch.EventBatch(soldierOwner,0).Events.Single(e=>
            e.Kind==MatchEventKind.ArmySpawned&&e.ActorId==helicopterOwner);
        Check(helicopterEntity.UnitId=="ID_UNIT-HELICOPTER"&&
              deathMatch.HasHelicopterPath(helicopterEntity.EntityKey)&&
              helicopterEntity.SpawnComponentFileId==helicopterSpawn.ArmySpawnComponentFileId&&
              helicopterEntity.PositionTick==70&&
              helicopterEntity.HelicopterStopTick==0&&
              helicopterEntity.HelicopterCrewCount==2&&helicopterEntity.HelicopterCrewDropMask==0&&
              helicopterEntity.HelicopterRotation is { } helicopterRotation&&
              War.Client.MatchConnection.ValidHelicopterTurretPose(helicopterEntity)&&
              War.Client.MatchConnection.ValidHelicopterGunner(helicopterEntity)&&
              helicopterEntity.HelicopterGunnerMaxHealth==621f&&
              helicopterEntity.HelicopterGunnerHealth==621f&&
              helicopterEntity.HelicopterGunnerSpawnTick==helicopterEntity.SpawnTick&&
              helicopterEntity.HelicopterGunnerRespawnTick==0&&
              Math.Abs(helicopterRotation.X*helicopterRotation.X+
                  helicopterRotation.Y*helicopterRotation.Y+
                  helicopterRotation.Z*helicopterRotation.Z+
                  helicopterRotation.W*helicopterRotation.W-1)<.001f&&
              deathMatch.HelicopterCrewDueSlots(helicopterEntity.EntityKey,70).Count==0&&
              deathMatch.HelicopterCrewDefinition(helicopterEntity.EntityKey)==
                  new ArmyHelicopterCrewStats(2,621f)&&
              deathMatch.HelicopterShotDefinition(helicopterEntity.EntityKey)==helicopterShot&&
              deathMatch.HelicopterGunner(helicopterEntity.EntityKey) is
                  {PointComponentFileId:11499861,MaximumHealth:621f,Health:621f,TurretEnabled:true}&&
              deathMatch.HelicopterTurretPose(helicopterEntity.EntityKey) is
                  {PointComponentFileId:11499861}&&
              deathMatch.HelicopterCrewMembers(helicopterEntity.EntityKey).Select(x=>x.PointComponentFileId)
                  .SequenceEqual(new[]{11438461,11450766})&&
              deathMatch.HelicopterCrewMembers(helicopterEntity.EntityKey)
                  .All(x=>x.Health==621f&&x.Maximum==621f&&x.DropStartTick==0)&&
              deathMatch.HelicopterAttachedCrewPoses(helicopterEntity.EntityKey).Count==2&&
              Vector3.Distance(new Vector3(helicopterEntity.X,helicopterEntity.Y,helicopterEntity.Z),
                  new Vector3(helicopterSpawn.X,helicopterSpawn.Y,helicopterSpawn.Z))>0,
              "normal Helicopter deployment publishes host-owned source-route motion after spawn");
        var liveTurretPose=deathMatch.HelicopterTurretPose(helicopterEntity.EntityKey)!;
        var liveAirAim=deathMatch.ResolveDroneShotTarget(deathMatch.DroneTargetSnapshot()
            .Single(x=>x.Id=="army:"+helicopterEntity.EntityKey));
        var heliAimRotation=new Quaternion(helicopterEntity.HelicopterRotation!.X,
            helicopterEntity.HelicopterRotation.Y,helicopterEntity.HelicopterRotation.Z,
            helicopterEntity.HelicopterRotation.W);
        var expectedAirAim=new Vector3(helicopterEntity.X,helicopterEntity.Y,helicopterEntity.Z)+
            Vector3.Transform(new Vector3(0,0,-.3907919f),heliAimRotation);
        Check(liveAirAim.Targets.Count==1&&liveAirAim.Targets[0].TransformFileId==414249&&
              liveAirAim.Targets[0].Type==0&&
              Vector3.Distance(liveAirAim.Targets[0].Position,expectedAirAim)<.0002f&&
              PlayerHitbox.Finite(liveAirAim.Velocity),
              "Drone target resolution binds Helicopter's source shootable to its live flight pose");
        var liveHelicopterBoxes=deathMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==helicopterEntity.EntityKey).ToArray();
        var liveHelicopterBodyBoxes=liveHelicopterBoxes.Where(x=>!x.HelicopterGunner).ToArray();
        var liveGunnerBoxes=liveHelicopterBoxes.Where(x=>x.HelicopterGunner).ToArray();
        Check(liveHelicopterBodyBoxes.Length==11&&liveHelicopterBodyBoxes.All(x=>x.Layer==26)&&
              liveHelicopterBodyBoxes.Select(x=>x.PartComponentFileId)
                  .SequenceEqual(heliBoxes.Select(x=>x.ColliderFileId))&&
              liveGunnerBoxes.Length==3&&liveGunnerBoxes.All(x=>x.Layer==22&&
                  x.PartComponentFileId==0&&x.Hitbox.SourcePath.StartsWith("helicopter-gunner/"))&&
              !deathMatch.GroundVehicleShotTargets(helicopterOwner)
                  .Any(x=>x.EntityId==helicopterEntity.EntityKey),
              "normal deployed Helicopter contributes its source boxes on the runtime mech layer only to opposing projectile traces");
        var gunnerShotWorld=new ShotCollisionWorld(null,
        [
            new(soldierOwner,deathMatch.CombatPose(soldierOwner).Collision),
            new(helicopterOwner,deathMatch.CombatPose(helicopterOwner).Collision)
        ],dynamicTargets:deathMatch.GroundVehicleShotTargets);
        var gunnerShotOrigin=liveGunnerBoxes[0].Hitbox.Center-Vector3.UnitZ*2;
        var gunnerOverlap=gunnerShotWorld.OverlapEnemy(soldierOwner,gunnerShotOrigin,4,1u<<22);
        Check(gunnerOverlap.Count(x=>x.MainEntityId==
                  "helicopter-gunner:"+helicopterEntity.EntityKey)==3&&
              !gunnerShotWorld.OverlapEnemy(soldierOwner,gunnerShotOrigin,4,1u<<8)
                  .Any(x=>x.MainEntityId=="helicopter-gunner:"+helicopterEntity.EntityKey),
              "live Helicopter gunner body/head enter shotgun overlap only on the opposing soldier layer");
        var gunnerPlan=ShotgunShotPlanner.Plan(new ShotgunRule(50,3,10,10,100,false,false),
            gunnerShotOrigin,liveGunnerBoxes[0].Hitbox.Center+Vector3.UnitX*.5f,gunnerOverlap);
        Check(gunnerPlan.RealPellets.Count(x=>gunnerOverlap.Any(y=>
                  y.MainEntityId=="helicopter-gunner:"+helicopterEntity.EntityKey&&
                  y.EntityId==x.EntityId)) is >=1 and <=2,
              "sampled Helicopter gunner parts share the source two-extra shotgun limit");
        var gunnerDirections=new[]{Vector3.UnitX,-Vector3.UnitX,Vector3.UnitY,-Vector3.UnitY,
            Vector3.UnitZ,-Vector3.UnitZ};
        var gunnerRay=liveGunnerBoxes.SelectMany(box=>gunnerDirections.Select(direction=>
            deathMatch.TraceHeavyTurretShot(soldierOwner,box.Hitbox.Center+direction*2f,
                -direction,4f))).FirstOrDefault(x=>x is {DynamicHelicopterGunner:true});
        Check(gunnerRay is {DynamicEntityId:ulong gunnerEntity,PartWeight:1f or 1.5f}&&
              gunnerEntity==helicopterEntity.EntityKey,
              "opposing source ray reaches the live Helicopter gunner beyond its body boxes");
        var helicopterBoxAxis=Vector3.Transform(Vector3.UnitX,
            new Quaternion(helicopterEntity.HelicopterRotation!.X,
                helicopterEntity.HelicopterRotation.Y,helicopterEntity.HelicopterRotation.Z,
                helicopterEntity.HelicopterRotation.W));
        var helicopterBoxCenter=liveHelicopterBoxes[0].Hitbox.Center;
        var helicopterBodyTrace=deathMatch.TraceHeavyTurretShot(soldierOwner,
            helicopterBoxCenter-helicopterBoxAxis*.5f,helicopterBoxAxis,2f);
        Check(helicopterBodyTrace is {DynamicEntityId:ulong tracedHelicopter,
                  DynamicPartId:int tracedCollider}&&
              tracedHelicopter==helicopterEntity.EntityKey&&
              content.HelicopterBodyColliders.HasCollider(tracedCollider),
              "normal projectile collision trace resolves a live Helicopter source box");
        Check(!deathMatch.HelicopterVisibilityRay(HelicopterTurretSightRay.ForSelection(
                  helicopterBoxCenter-helicopterBoxAxis*2,
                  helicopterBoxCenter+helicopterBoxAxis*2)),
              "live Helicopter body box blocks the recovered static/destroyable sight mask");
        var liveSelectionSight=deathMatch.HelicopterRestSightRay(helicopterEntity.EntityKey,
            liveTurretPose.SightRestPosition+Vector3.UnitZ*10,false);
        Check(liveSelectionSight is { } liveRay&&Math.Abs(liveRay.Range-9.45f)<.00001f&&
              Vector3.Distance(liveRay.Origin,
                  liveTurretPose.SightRestPosition+Vector3.UnitZ*.05f)<.000001f,
              "live Helicopter root places the source rest sight ray before target selection");
        var liveRoot=new Vector3(helicopterEntity.X,helicopterEntity.Y,helicopterEntity.Z);
        var liveRootRotation=new Quaternion(helicopterEntity.HelicopterRotation!.X,
            helicopterEntity.HelicopterRotation.Y,helicopterEntity.HelicopterRotation.Z,
            helicopterEntity.HelicopterRotation.W);
        var liveAimTarget=liveRoot+Vector3.Transform(new Vector3(-8,2,4),liveRootRotation);
        var liveAim=deathMatch.HelicopterTurretAimFromRest(helicopterEntity.EntityKey,liveAimTarget);
        var expectedAim=HelicopterTurretAim.FromRest(liveRoot,liveRootRotation,liveAimTarget);
        Check(liveAim is {Immediate:false,Clipped:false}&&
              Vector3.Distance(liveAim.SightPosition,expectedAim.SightPosition)<.000001f&&
              Vector3.Distance(liveAim.MuzzlePosition,expectedAim.MuzzlePosition)<.000001f&&
              Vector3.Distance(liveAim.SightPosition,liveTurretPose.SightRestPosition)>.001f,
              "live Helicopter root resolves a turned source sight and muzzle from its current flight pose");
        var sideTarget=liveRoot+Vector3.Transform(new Vector3(-5,0,9),liveRootRotation);
        var sideAim=HelicopterTurretAim.FromRest(liveRoot,liveRootRotation,sideTarget);
        Check(deathMatch.BeginHelicopterTurretAim(helicopterEntity.EntityKey,sideTarget)==
                  (int)MathF.Ceiling(sideAim.AimSeconds*30)&&
              deathMatch.HelicopterTurretCurrentAimPose(helicopterEntity.EntityKey) is
                  {SightPosition:var currentSight}&&
              Vector3.Distance(currentSight,liveTurretPose.SightRestPosition)<.00001f&&
              deathMatch.HelicopterCurrentSightRay(helicopterEntity.EntityKey,
                  currentSight+Vector3.UnitZ*10,false) is {Range:var currentRange}&&
              Math.Abs(currentRange-9.45f)<.00001f,
              "live Helicopter turret starts a host-owned source turn and sight ray from its rest joints");
        var projectedTurret=deathMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.EntityKey==helicopterEntity.EntityKey);
        var hostTurret=deathMatch.HelicopterTurretCurrentAimPose(helicopterEntity.EntityKey)!;
        Check(projectedTurret.HelicopterTurretHorizontalLocal is { } projectedHorizontal&&
              projectedTurret.HelicopterTurretVerticalWorld is { } projectedVertical&&
              Math.Abs(Quaternion.Dot(new Quaternion(projectedHorizontal.X,projectedHorizontal.Y,
                  projectedHorizontal.Z,projectedHorizontal.W),
                  hostTurret.HorizontalLocalRotation))>.99999f&&
              Math.Abs(Quaternion.Dot(new Quaternion(projectedVertical.X,projectedVertical.Y,
                  projectedVertical.Z,projectedVertical.W),
              hostTurret.VerticalWorldRotation))>.99999f,
              "Helicopter roster projects the host's current local yaw and world vertical joint");
        var turretWire=MatchArmyEntityBatch.Parser.ParseFrom(
            Google.Protobuf.MessageExtensions.ToByteArray(
                deathMatch.ArmyEntityBatch(soldierOwner,0,0)));
        Check(War.Client.MatchConnection.ValidHelicopterTurretPose(turretWire.Entities
                  .Single(x=>x.EntityKey==helicopterEntity.EntityKey)),
              "Helicopter turret joints survive the paged protobuf roster round trip");
        Check(War.Client.MatchConnection.ValidHelicopterGunner(turretWire.Entities
                  .Single(x=>x.EntityKey==helicopterEntity.EntityKey)),
              "Helicopter gunner health and clock survive the paged protobuf roster round trip");
        Check(War.Client.MatchConnection.ValidHelicopterCrew(helicopterEntity),
              "SDK accepts host Helicopter crew before its stop callback");
        var forgedTurret=helicopterEntity.Clone();
        forgedTurret.HelicopterTurretVerticalWorld=null;
        Check(!War.Client.MatchConnection.ValidHelicopterTurretPose(forgedTurret),
              "SDK rejects incomplete Helicopter turret pose");
        forgedTurret=helicopterEntity.Clone();
        forgedTurret.HelicopterTurretHorizontalLocal!.W=2;
        Check(!War.Client.MatchConnection.ValidHelicopterTurretPose(forgedTurret),
              "SDK rejects non-unit Helicopter turret joint rotation");
        var forgedGunner=helicopterEntity.Clone();forgedGunner.HelicopterGunnerHealth=0;
        Check(!War.Client.MatchConnection.ValidHelicopterGunner(forgedGunner),
              "SDK rejects a dead gunner without a respawn deadline");
        forgedGunner=helicopterEntity.Clone();forgedGunner.HelicopterGunnerSpawnTick=ulong.MaxValue;
        Check(!War.Client.MatchConnection.ValidHelicopterGunner(forgedGunner),
              "SDK rejects a gunner spawned after its roster sample");
        var forgedCrew=helicopterEntity.Clone();forgedCrew.HelicopterCrewCount=7;
        Check(!War.Client.MatchConnection.ValidHelicopterCrew(forgedCrew),
              "SDK rejects crew beyond six source slots");
        forgedCrew=helicopterEntity.Clone();forgedCrew.HelicopterCrewDropMask=1;
        Check(!War.Client.MatchConnection.ValidHelicopterCrew(forgedCrew),
              "SDK rejects a rope descent before source stop");
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
        deathMatch.Advance(71);
        var movingAim=deathMatch.HelicopterTurretCurrentAimPose(helicopterEntity.EntityKey);
        var movingRest=deathMatch.HelicopterTurretPose(helicopterEntity.EntityKey);
        Check(movingAim!=null&&movingRest!=null&&
              Vector3.Distance(movingAim.SightPosition,movingRest.SightRestPosition)>.00001f&&
              deathMatch.HelicopterCurrentSightRay(helicopterEntity.EntityKey,sideTarget,false) is
                  {Origin:var movingRayOrigin}&&
              Vector3.Distance(movingRayOrigin,movingAim.SightPosition)>.04f,
              "running Helicopter tick advances its moving joint eye before the live sight ray");
        float helicopterHealthBefore=deathMatch.ArmyHealth(helicopterEntity.EntityKey)!.Value;
        uint helicopterHitCountBefore=deathMatch.Snapshot().Players[0].ConfirmedEnemyHits;
        Reject(()=>deathMatch.ApplyArmyBodyProjectileImpact(soldierOwner,
            helicopterEntity.EntityKey,1,5f));
        deathMatch.ApplyArmyBodyProjectileImpact(soldierOwner,helicopterEntity.EntityKey,
            helicopterBodyTrace!.DynamicPartId!.Value,5f);
        Check(deathMatch.ArmyHealth(helicopterEntity.EntityKey)==helicopterHealthBefore-5f&&
              deathMatch.Snapshot().Players[0].ConfirmedEnemyHits==helicopterHitCountBefore+1,
              "source Helicopter body part routes a valid opposing projectile to shared host health");
        Check(deathMatch.ConfirmArmyDeath(helicopterEntity.EntityKey,true) &&
              !deathMatch.HasHelicopterPath(helicopterEntity.EntityKey) &&
              deathMatch.HelicopterCrewDefinition(helicopterEntity.EntityKey)==null&&
              deathMatch.HelicopterShotDefinition(helicopterEntity.EntityKey)==null&&
              deathMatch.HelicopterGunner(helicopterEntity.EntityKey)==null&&
              deathMatch.HelicopterTurretPose(helicopterEntity.EntityKey)==null&&
              deathMatch.HelicopterTurretCurrentAimPose(helicopterEntity.EntityKey)==null&&
              !deathMatch.GroundVehicleShotTargets(soldierOwner)
                  .Any(x=>x.EntityId==helicopterEntity.EntityKey)&&
              deathMatch.HelicopterRestSightRay(helicopterEntity.EntityKey,Vector3.Zero,false)==null&&
              deathMatch.HelicopterCrewMembers(helicopterEntity.EntityKey).Count==0&&
              deathMatch.HelicopterCrewDescents(helicopterEntity.EntityKey).Count==0&&
              deathMatch.HelicopterAttachedCrewPoses(helicopterEntity.EntityKey).Count==0&&
              deathMatch.HelicopterCrewDueSlots(helicopterEntity.EntityKey,ulong.MaxValue).Count==0&&
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
        var helicopterShotManifest=detached with {MatchId="player-projectile-helicopter",
            DurationSeconds=180,IdleSeconds=120};
        var helicopterShotMatch=new MatchEngine(helicopterShotManifest,content:content,armyChoice:_=>0);
        helicopterShotMatch.Admit(soldierOwner);helicopterShotMatch.Admit(helicopterOwner);
        helicopterShotMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=helicopterShotMatch.ManifestHash}});
        helicopterShotMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=helicopterShotMatch.ManifestHash}});
        helicopterShotMatch.Advance(60);
        var helicopterShotOption=helicopterShotMatch.ArmyBatch(helicopterOwner).OptionIndexes
            .First(x=>x==2);
        helicopterShotMatch.Command(helicopterOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=helicopterShotOption}});
        helicopterShotMatch.Advance(61);
        var shotHelicopter=helicopterShotMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.OwnerPlayerId==helicopterOwner&&x.UnitId=="ID_UNIT-HELICOPTER");
        float initialHelicopterShotHealth=shotHelicopter.Health;
        Check(helicopterShotMatch.SelectHelicopterTurretTarget(shotHelicopter.EntityKey)?.Id==
              "player:"+soldierOwner,
              "live Helicopter selector finds the opponent through its source first-target sight gate");
        ulong helicopterFireCommand=2;bool playerShotDamagedHelicopter=false;
        bool automaticHelicopterAim=false;
        for(ulong shotTick=62;shotTick<5000&&!helicopterShotMatch.Terminal;shotTick++)
        {
            if(shotTick%12==0)
            {
                var current=helicopterShotMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                    .SingleOrDefault(x=>x.EntityKey==shotHelicopter.EntityKey);
                if(current==null)break;
                var boxes=helicopterShotMatch.GroundVehicleShotTargets(soldierOwner)
                    .Where(x=>x.EntityId==shotHelicopter.EntityKey).ToArray();
                if(boxes.Length==0)break;
                var aim=boxes[0].Hitbox.Center;
                helicopterShotMatch.Command(soldierOwner,new(){CommandId=helicopterFireCommand++,
                    Fire=new(){TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            }
            helicopterShotMatch.Advance(shotTick);
            automaticHelicopterAim|=helicopterShotMatch.HelicopterSelectedTarget(
                shotHelicopter.EntityKey)=="player:"+soldierOwner;
            if(helicopterShotMatch.ArmyHealth(shotHelicopter.EntityKey) is not float health||
                health<initialHelicopterShotHealth)
            {playerShotDamagedHelicopter=true;break;}
        }
        Check(playerShotDamagedHelicopter&&
              helicopterShotMatch.Snapshot().Players.Single(p=>p.PlayerId==soldierOwner)
                  .ConfirmedEnemyHits>0,
              "normal player Fire traverses live Helicopter body collision into host-owned health");
        ulong helicopterAimStart=helicopterShotMatch.Snapshot().ServerTick;
        for(ulong aimTick=helicopterAimStart+1;
            aimTick<helicopterAimStart+600&&!automaticHelicopterAim&&
            !helicopterShotMatch.Terminal;aimTick++)
        {
            helicopterShotMatch.Advance(aimTick);
            automaticHelicopterAim=helicopterShotMatch.HelicopterSelectedTarget(
                shotHelicopter.EntityKey)=="player:"+soldierOwner;
        }
        Check(automaticHelicopterAim&&
              helicopterShotMatch.HelicopterTurretCurrentAimPose(shotHelicopter.EntityKey)!=null,
              "normal Helicopter ticks acquire the visible opponent and advance live turret joints");
        var autonomousHelicopterManifest=detached with {MatchId="autonomous-helicopter-fire",
            DurationSeconds=180,IdleSeconds=120};
        var autonomousHelicopterMatch=new MatchEngine(autonomousHelicopterManifest,
            content:content,armyChoice:_=>0);
        autonomousHelicopterMatch.Admit(soldierOwner);autonomousHelicopterMatch.Admit(helicopterOwner);
        foreach(var owner in new[]{soldierOwner,helicopterOwner})
            autonomousHelicopterMatch.Command(owner,new(){CommandId=1,
                Ready=new(){ManifestHash=autonomousHelicopterMatch.ManifestHash}});
        autonomousHelicopterMatch.Advance(60);
        autonomousHelicopterMatch.ArmyBatch(helicopterOwner);
        autonomousHelicopterMatch.Command(helicopterOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=2}});
        autonomousHelicopterMatch.Advance(61);
        var autonomousHelicopter=autonomousHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0)
            .Entities.Single(x=>x.UnitId=="ID_UNIT-HELICOPTER");
        bool observedHelicopterFlight=false,observedPlayerTargetSpeed=false;
        for(ulong airFireTick=62;airFireTick<1200&&!autonomousHelicopterMatch.Terminal;airFireTick++)
        {
            autonomousHelicopterMatch.Advance(airFireTick);
            observedHelicopterFlight|=autonomousHelicopterMatch.Snapshot().Projectiles
                .Any(x=>x.Kind=="helicopter-bullet"&&x.OwnerPlayerId==helicopterOwner);
            observedPlayerTargetSpeed|=autonomousHelicopterMatch.Snapshot().Projectiles
                .Any(x=>x.Kind=="helicopter-bullet"&&x.OwnerPlayerId==helicopterOwner&&
                    MathF.Abs(MathF.Sqrt(x.VelocityX*x.VelocityX+x.VelocityY*x.VelocityY+
                        x.VelocityZ*x.VelocityZ)-6f)<.001f);
        }
        ulong helicopterEventCursor=0;int helicopterRealFired=0,helicopterImpacts=0;
        MatchEvent? firstHelicopterFired=null;
        var helicopterFireTicks=new List<ulong>();
        var helicopterConsumer=new War.Client.MatchEventConsumer();
        while(true)
        {
            var batch=autonomousHelicopterMatch.EventBatch(helicopterOwner,helicopterEventCursor);
            if(batch.Events.Count==0)break;
            helicopterConsumer.Consume(batch);
            helicopterRealFired+=batch.Events.Count(e=>e.Kind==MatchEventKind.HelicopterFired&&
                e.HelicopterShot is {Fake:false}&&
                e.HelicopterShot.ArmyEntityKey==autonomousHelicopter.EntityKey);
            firstHelicopterFired??=batch.Events.FirstOrDefault(e=>
                e.Kind==MatchEventKind.HelicopterFired);
            helicopterFireTicks.AddRange(batch.Events.Where(e=>
                e.Kind==MatchEventKind.HelicopterFired).Select(e=>e.Tick));
            helicopterImpacts+=batch.Events.Count(e=>e.Kind==MatchEventKind.Impact&&
                e.Reason=="helicopter");
            helicopterEventCursor=batch.Events.Last().EventId;
        }
        Check(helicopterRealFired>=4&&helicopterImpacts>0&&observedHelicopterFlight&&
              observedPlayerTargetSpeed&&
              firstHelicopterFired is {HelicopterShot:{Speed:6,Fake:false}}&&
              helicopterFireTicks.Count>=4&&
              helicopterFireTicks.Take(4).Skip(1)
                  .Select((shot,i)=>shot-helicopterFireTicks[i]).All(delta=>delta is >=6 and <=8)&&
              helicopterConsumer.LastEventId==helicopterEventCursor,
              "normal Helicopter batches publish source-speed rounds, fly, collide and replay through SDK events");
        var fakeHelicopterFlight=new HelicopterFakeProjectileFlight(Vector3.Zero,
            new Vector3(0,0,10),12,100);
        fakeHelicopterFlight.Advance(115);
        Check(!fakeHelicopterFlight.Finished&&
              Vector3.Distance(fakeHelicopterFlight.Position,new Vector3(0,0,9))<.001f,
              "fake Helicopter BulletSlow follows the source doubled-distance tween at upgrade-backed fake speed");
        fakeHelicopterFlight.Advance(135);
        Check(fakeHelicopterFlight.Finished&&
              Vector3.Distance(fakeHelicopterFlight.Position,new Vector3(0,0,20))<.001f,
              "fake Helicopter BulletSlow expires at its doubled endpoint without collision authority");
        var fakeHelicopterMatch=new MatchEngine(autonomousHelicopterManifest with
            {MatchId="autonomous-helicopter-fake-fire"},content:content,armyChoice:n=>n-1);
        fakeHelicopterMatch.Admit(soldierOwner);fakeHelicopterMatch.Admit(helicopterOwner);
        foreach(var owner in new[]{soldierOwner,helicopterOwner})
            fakeHelicopterMatch.Command(owner,new(){CommandId=1,
                Ready=new(){ManifestHash=fakeHelicopterMatch.ManifestHash}});
        fakeHelicopterMatch.Advance(60);
        fakeHelicopterMatch.ArmyBatch(helicopterOwner);
        fakeHelicopterMatch.Command(helicopterOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=2}});
        fakeHelicopterMatch.Advance(61);
        bool observedFakeHelicopterFlight=false;
        bool observedFakeHelicopterVelocity=false;
        for(ulong fakeTick=62;fakeTick<1200&&!fakeHelicopterMatch.Terminal;fakeTick++)
        {
            fakeHelicopterMatch.Advance(fakeTick);
            observedFakeHelicopterFlight|=fakeHelicopterMatch.Snapshot().Projectiles
                .Any(x=>x.Kind=="helicopter-fake-bullet"&&x.OwnerPlayerId==helicopterOwner);
            observedFakeHelicopterVelocity|=fakeHelicopterMatch.Snapshot().Projectiles
                .Any(x=>x.Kind=="helicopter-fake-bullet"&&
                    MathF.Abs(MathF.Sqrt(x.VelocityX*x.VelocityX+x.VelocityY*x.VelocityY+
                        x.VelocityZ*x.VelocityZ)-18f)<.001f);
        }
        ulong fakeCursor=0;int fakeRounds=0,fakeImpacts=0;
        bool fakeSpeedMatches=false;
        while(true)
        {
            var page=fakeHelicopterMatch.EventBatch(helicopterOwner,fakeCursor);
            if(page.Events.Count==0)break;
            fakeRounds+=page.Events.Count(e=>e.Kind==MatchEventKind.HelicopterFired&&
                e.HelicopterShot is {Fake:true});
            fakeSpeedMatches|=page.Events.Any(e=>e.Kind==MatchEventKind.HelicopterFired&&
                e.HelicopterShot is {Fake:true,Speed:18});
            fakeImpacts+=page.Events.Count(e=>e.Kind==MatchEventKind.Impact&&e.Reason=="helicopter");
            fakeCursor=page.Events.Last().EventId;
        }
        Check(fakeRounds>0&&fakeSpeedMatches&&observedFakeHelicopterFlight&&
              observedFakeHelicopterVelocity&&fakeImpacts==0,
              "deployed fake Helicopter rounds publish visual flights without collision impacts");
        var forgedHelicopterEvent=firstHelicopterFired!.Clone();
        forgedHelicopterEvent.EventId=1;forgedHelicopterEvent.HelicopterShot=null;
        Reject(()=>new War.Client.MatchEventConsumer().Consume(new MatchEventBatch
        {Code="events",LatestEventId=1,Events={forgedHelicopterEvent}}));
        var droneHelicopterManifest=detached with
        {
            MatchId="drone-projectile-helicopter",DurationSeconds=180,IdleSeconds=120,
            Players=[detached.Players[0] with {EquippedArmyUnitIds=["ID_UNIT-DRONE"],
                ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[96],
                ArmyEliteUpgradeIndexes=[-1],ArmyShotSpeedCoefficients=[2]},
                detached.Players[1] with {ArmyShotSpeedCoefficients=[1]}]
        };
        var droneHelicopterMatch=new MatchEngine(droneHelicopterManifest,content:content,armyChoice:_=>0);
        droneHelicopterMatch.Admit(soldierOwner);droneHelicopterMatch.Admit(helicopterOwner);
        foreach(var owner in new[]{soldierOwner,helicopterOwner})
            droneHelicopterMatch.Command(owner,new(){CommandId=1,
                Ready=new(){ManifestHash=droneHelicopterMatch.ManifestHash}});
        droneHelicopterMatch.Advance(60);
        droneHelicopterMatch.ArmyBatch(soldierOwner);droneHelicopterMatch.ArmyBatch(helicopterOwner);
        Check(droneHelicopterMatch.Command(soldierOwner,new(){CommandId=2,
                  DeployArmy=new(){OptionIndex=9}}).Code=="army-deploying"&&
              droneHelicopterMatch.Command(helicopterOwner,new(){CommandId=2,
                  DeployArmy=new(){OptionIndex=2}}).Code=="army-deploying",
              "opposing Drone and Helicopter use normal host deployment commands");
        droneHelicopterMatch.Advance(61);
        var droneVsHelicopter=droneHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.UnitId=="ID_UNIT-DRONE");
        var helicopterVsDrone=droneHelicopterMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.UnitId=="ID_UNIT-HELICOPTER");
        float helicopterVsDroneHealth=helicopterVsDrone.Health;
        bool droneDamagedHelicopter=false;
        for(ulong airTick=62;airTick<5000&&!droneHelicopterMatch.Terminal;airTick++)
        {
            droneHelicopterMatch.Advance(airTick);
            if(droneHelicopterMatch.ArmyHealth(helicopterVsDrone.EntityKey) is float health&&
               health<helicopterVsDroneHealth)
            {droneDamagedHelicopter=true;break;}
        }
        bool droneSelectedHelicopter=false,droneImpactSeen=false;
        ulong airEventCursor=0;
        while(true)
        {
            var batch=droneHelicopterMatch.EventBatch(soldierOwner,airEventCursor);
            if(batch.Events.Count==0)break;
            droneSelectedHelicopter|=batch.Events.Any(e=>e.Kind==MatchEventKind.DroneFired&&
                e.TargetId=="army:"+helicopterVsDrone.EntityKey&&e.DroneShot is {Fake:false});
            droneImpactSeen|=batch.Events.Any(e=>e.Kind==MatchEventKind.Impact&&
                e.Reason=="drone"&&e.ActorId==soldierOwner);
            airEventCursor=batch.Events.Last().EventId;
        }
        Check(droneDamagedHelicopter&&
              droneSelectedHelicopter&&droneImpactSeen&&
              droneHelicopterMatch.LastDroneIntent(droneVsHelicopter.EntityKey)!=null&&
              droneHelicopterMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
                  .ConfirmedEnemyHits>0,
              "autonomous Drone projectile damages an opposing deployed Helicopter");
        var crewManifest=detached with {MatchId="helicopter-crew-phase",DurationSeconds=180,IdleSeconds=120};
        var crewMatch=new MatchEngine(crewManifest,content:content);
        crewMatch.Admit(soldierOwner);crewMatch.Admit(helicopterOwner);
        foreach(string owner in new[]{soldierOwner,helicopterOwner})
            crewMatch.Command(owner,new MatchCommand{CommandId=1,
                Ready=new ReadyCommand{ManifestHash=crewMatch.ManifestHash}});
        crewMatch.Advance(60);
        crewMatch.ArmyBatch(helicopterOwner);
        Check(crewMatch.Command(helicopterOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=2}}).Code=="army-deploying",
              "normal Helicopter crew phase uses a trusted deployment");
        ulong sourceStop=0,sourceHelicopter=0;
        for(ulong t=61;t<=1800&&!crewMatch.Terminal;t++)
        {
            crewMatch.Advance(t);
            var row=crewMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
                .FirstOrDefault(x=>x.OwnerPlayerId==helicopterOwner);
            if(row is {HelicopterStopTick:>0})
            {sourceStop=row.HelicopterStopTick;sourceHelicopter=row.EntityKey;break;}
        }
        Check(sourceStop>0&&sourceHelicopter>0&&
              crewMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
                  .Single(x=>x.EntityKey==sourceHelicopter).HelicopterCrewDropMask==0,
              "live Helicopter stop publishes a source-backed timeline before crew descent");
        var heliAtStop=crewMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
            .Single(x=>x.EntityKey==sourceHelicopter);
        var heliQ=new Quaternion(heliAtStop.HelicopterRotation.X,heliAtStop.HelicopterRotation.Y,
            heliAtStop.HelicopterRotation.Z,heliAtStop.HelicopterRotation.W);
        var heliAimOrigin=new Vector3(heliAtStop.X,heliAtStop.Y,heliAtStop.Z)+
            Vector3.Transform(coneOrigin,heliQ);
        var heliForward=Vector3.Transform(Vector3.Transform(Vector3.UnitZ,
            new Quaternion(0,-.7071068f,0,.7071067f)),heliQ);
        Check(crewMatch.HelicopterTargetInTurretCone(sourceHelicopter,heliAimOrigin+heliForward*10)&&
              !crewMatch.HelicopterTargetInTurretCone(sourceHelicopter,heliAimOrigin-heliForward*10)&&
              !crewMatch.HelicopterTargetVisibleInCone(sourceHelicopter,
                  heliAimOrigin-heliForward*10),
              "live Helicopter target cone follows the authoritative flight rotation");
        var crewGunnerBoxes=crewMatch.GroundVehicleShotTargets(soldierOwner)
            .Where(x=>x.EntityId==sourceHelicopter&&x.HelicopterGunner).ToArray();
        var crewGunnerHit=crewGunnerBoxes.SelectMany(box=>gunnerDirections.Select(direction=>
            crewMatch.TraceHeavyTurretShot(soldierOwner,box.Hitbox.Center+direction*2f,
                -direction,4f))).FirstOrDefault(x=>x is {DynamicHelicopterGunner:true});
        Check(crewGunnerBoxes.Length==3&&crewGunnerHit is
                  {DynamicEntityId:var gunnerHitEntity,PartWeight:1f or 1.5f}&&
              gunnerHitEntity==sourceHelicopter,
              "source idle gunner remains an exposed opposing collision target at the Helicopter stop");
        uint gunnerHitsBefore=crewMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
            .ConfirmedEnemyHits;
        ulong gunnerRevisionBefore=crewMatch.Snapshot().StateRevision;
        Reject(()=>crewMatch.ApplyHelicopterGunnerProjectileImpact(helicopterOwner,
            sourceHelicopter,10f,1f));
        Reject(()=>crewMatch.ApplyHelicopterGunnerProjectileImpact(soldierOwner,
            sourceHelicopter,10f,2f));
        Check(crewMatch.HelicopterGunner(sourceHelicopter) is {Health:621f,TurretEnabled:true}&&
              crewMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
                  .ConfirmedEnemyHits==gunnerHitsBefore,
              "friendly and non-source-weight gunner hits cannot change combat authority");
        crewMatch.ApplyHelicopterGunnerProjectileImpact(soldierOwner,sourceHelicopter,621f,
            crewGunnerHit!.PartWeight);
        var deadGunnerRow=crewMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
            .Single(x=>x.EntityKey==sourceHelicopter);
        Check(crewMatch.Snapshot().Players.Single(x=>x.PlayerId==soldierOwner)
                  .ConfirmedEnemyHits==gunnerHitsBefore+1&&
              crewMatch.Snapshot().StateRevision>gunnerRevisionBefore&&
              deadGunnerRow.HelicopterGunnerHealth==0&&
              deadGunnerRow.HelicopterGunnerRespawnTick>deadGunnerRow.PositionTick&&
              War.Client.MatchConnection.ValidHelicopterGunner(deadGunnerRow)&&
              crewMatch.HelicopterGunner(sourceHelicopter) is {Health:0,TurretEnabled:false}&&
              !crewMatch.GroundVehicleShotTargets(soldierOwner)
                  .Any(x=>x.EntityId==sourceHelicopter&&x.HelicopterGunner)&&
              crewMatch.HelicopterSelectedTarget(sourceHelicopter)==null&&
              !crewMatch.HelicopterTargetInTurretCone(sourceHelicopter,Vector3.Zero)&&
              crewMatch.HelicopterTurretAimFromRest(sourceHelicopter,
                  heliAimOrigin+heliForward*10)==null&&
              crewMatch.BeginHelicopterTurretAim(sourceHelicopter,
                  heliAimOrigin+heliForward*10)==null&&
              !crewMatch.DamageHelicopterGunner(sourceHelicopter,1f),
              "trusted projectile hit kills the gunner, credits the attacker and disables its live turret");
        ulong crewTick=sourceStop;
        uint MaskAt(ulong target)
        {
            for(ulong t=crewTick+1;t<=target&&!crewMatch.Terminal;t++)crewMatch.Advance(t);
            crewTick=target;
            return crewMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
                .Single(x=>x.EntityKey==sourceHelicopter).HelicopterCrewDropMask;
        }
        Check(MaskAt(sourceStop+149)==0&&MaskAt(sourceStop+150)==1&&
              MaskAt(sourceStop+210)==3&&!crewMatch.Terminal,
              "live roster advances the two ordered Helicopter crew descent phases exactly once");
        var droppedCrew=crewMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities
            .Single(x=>x.EntityKey==sourceHelicopter);
        Check(crewMatch.HelicopterCrewMembers(sourceHelicopter).Select(x=>x.DropStartTick)
                  .SequenceEqual(new[]{sourceStop+150,sourceStop+210}),
              "live Helicopter attached crew records retain their two source descent start ticks");
        Check(crewMatch.HelicopterCrewDescents(sourceHelicopter) is var descents&&
              descents.Count==2&&descents[0].Progress==1f&&descents[0].AnimationComplete&&
              descents[1].Progress==0f&&!descents[1].AnimationComplete,
              "crew descent animation progress follows ordered source starts on the host clock");
        MaskAt(sourceStop+225);
        Check(Math.Abs(crewMatch.HelicopterCrewDescents(sourceHelicopter)[1].Progress-.5f)<.000001f&&
              !crewMatch.HelicopterCrewDescents(sourceHelicopter)[1].AnimationComplete,
              "second crew rope animation reaches half progress after fifteen host ticks");
        MaskAt(sourceStop+240);
        Check(crewMatch.HelicopterCrewDescents(sourceHelicopter)[1].Progress==1f&&
              crewMatch.HelicopterCrewDescents(sourceHelicopter)[1].AnimationComplete,
              "rope animation completion clamps at one without asserting NavMesh landing");
        ulong deadGunnerRevision=crewMatch.Snapshot().StateRevision;
        MaskAt(sourceStop+375);
        Check(crewMatch.HelicopterGunner(sourceHelicopter) is
                  {Health:621f,TurretEnabled:true,RespawnTick:0}&&
              crewMatch.Snapshot().StateRevision>deadGunnerRevision&&
              crewMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single(x=>
                  x.EntityKey==sourceHelicopter) is {HelicopterGunnerHealth:621f,
                      HelicopterGunnerRespawnTick:0}&&
              crewMatch.GroundVehicleShotTargets(soldierOwner)
                  .Count(x=>x.EntityId==sourceHelicopter&&x.HelicopterGunner)==3,
              "live Helicopter gunner recovers at the source respawn deadline");
        Check(crewMatch.HelicopterAttachedCrewPoses(sourceHelicopter).Count==0,
              "crew leaves source attachment poses once both rope descents begin");
        Check(War.Client.MatchConnection.ValidHelicopterCrew(droppedCrew),
              "SDK accepts the live host's completed ordered crew descent prefix");
        forgedCrew=droppedCrew.Clone();forgedCrew.HelicopterCrewDropMask=2;
        Check(!War.Client.MatchConnection.ValidHelicopterCrew(forgedCrew),
              "SDK rejects a forged second-slot drop without the first slot");
        Check(deathMatch.Snapshot() is {Phase:BattlePhase.Aborted,RewardEligible:false} &&
              deathMatch.Snapshot().Players[0].ConfirmedArmySpawns==2 &&
              deathMatch.Snapshot().Players[0].ConfirmedArmyLosses==1 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmySpawns==1 &&
              deathMatch.Snapshot().Players[1].ConfirmedArmyLosses==1,
              "unscored terminal evidence freezes confirmed army transitions");
        var armyTerminal=deathMatch.Snapshot();
        Check(armyTerminal.Players[0].ArmyUsage.Single() is
                  {OptionIndex:0,UnitId:"ID_UNIT-ASSAULT",Deployments:1,PlannedSpawns:2,ConfirmedSpawns:2}&&
              armyTerminal.Players[1].ArmyUsage.Single() is
                  {OptionIndex:2,UnitId:"ID_UNIT-HELICOPTER",Deployments:1,PlannedSpawns:1,ConfirmedSpawns:1},
              "terminal army ledger separates accepted source options from realized unit spawns");
        var armyTerminalPayload=Google.Protobuf.MessageExtensions.ToByteArray(armyTerminal);
        Check(TerminalOutbox.ValidatePayload(armyTerminalPayload,armyTerminal.MatchId,
            War.Shared.TerminalResultDigest.Compute(armyTerminalPayload)).Players[0].ArmyUsage.Count==1,
            "durable terminal validator accepts real two-owner army deployment and spawn evidence");
        var armyStats=BattleArmyStatsProjection.FromPayload(armyTerminalPayload,armyTerminal.MatchId,
            War.Shared.TerminalResultDigest.Compute(armyTerminalPayload));
        Check(armyStats[0].Units.Single()==new BattleArmyUnitStats("ID_UNIT-ASSAULT",1,2,2)&&
              armyStats[1].Units.Single()==new BattleArmyUnitStats("ID_UNIT-HELICOPTER",1,1,1),
              "validated terminal result projects accepted, planned and realized counts by source unit ID");
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
        Check(paratrooperKevlar==paratrooperHealth*.37f&&paratrooper.Kevlar==paratrooperKevlar&&
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
            helicopterOwner,new(walkingLive.X,walkingLive.Y,walkingLive.Z),sourceDroneHealth);
        Check(infantryBlastHits==1&&Math.Abs(walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value-
                  (walkingHealthBefore-sourceDroneHealth*content.GroundVehicleWeapons.RepairDronePrefab.ExplosionDamageRatio))<.001f,
              "repair-drone blast selects the live animated Shotgunner body and applies source full-radius damage");
        float friendlyBlastBefore=walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value;
        int friendlyBlastHits=walkingShotgunnerMatch.ApplyTransporterRepairDroneInfantryExplosion(
            soldierOwner,new(walkingLive.X,walkingLive.Y,walkingLive.Z),sourceDroneHealth);
        Check(friendlyBlastHits==1&&
              Math.Abs(walkingShotgunnerMatch.ArmyHealth(walkingLive.EntityKey)!.Value-
                  (friendlyBlastBefore-sourceDroneHealth*
                      content.GroundVehicleWeapons.RepairDronePrefab.ExplosionDamageRatio*
                      content.Explosions.Friendly))<.001f,
            "friendly repair-drone crash blast halves damage to its own infantry faction");
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
              staleMatch.GroundVehicleAttack(firstCar.EntityKey) is {ShotSpeed:14f} carAttack&&
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
                  DeployArmy=new DeployArmyCommand{OptionIndex=20}}).Code=="army-deploying" &&
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
              humveeRusherMatch.GroundVehicleSelectedShotSpeed(humveeId)==14,
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
              humveeDecoyMatch.GroundVehicleSelectedShotSpeed(decoyHumveeId)==14,
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
        Check(humveeDecoyMatch.DroneTargetSnapshot().All(r=>r.Id!="decoy:"+selectedDecoyId),"confirmed Decoy death removes Drone target authority");
        foreach(string cannonUnit in new[]{"ID_UNIT-TANK","ID_UNIT-BUGGY"})
        {
            var cannonDecoyManifest=humveeDecoyManifest with
            {
                MatchId="cannon-decoy-priority-"+cannonUnit,
                Players=[humveeDecoyManifest.Players[0] with
                    {EquippedArmyUnitIds=[cannonUnit]},humveeDecoyManifest.Players[1]]
            };
            content.ValidateAllocation(cannonDecoyManifest);
            var cannonDecoyMatch=new MatchEngine(cannonDecoyManifest,content:content,
                armyChoice:_=>0,combatRandom:()=>0);
            cannonDecoyMatch.ConfigureBattleAllocations([
                new(soldierOwner,[],[],[0],[-1],[-1]),
                new(helicopterOwner,["CardDecoy"],[],[0],[-1],[-1])]);
            cannonDecoyMatch.Admit(soldierOwner);cannonDecoyMatch.Admit(helicopterOwner);
            Check(cannonDecoyMatch.Command(soldierOwner,emptyHumveeCards).Code=="cards-selected"&&
                  cannonDecoyMatch.Command(helicopterOwner,opposingDecoyCards).Code=="cards-selected",
                cannonUnit+" match binds trusted Decoy card selection");
            cannonDecoyMatch.Command(soldierOwner,new(){CommandId=2,
                Ready=new(){ManifestHash=cannonDecoyMatch.ManifestHash}});
            cannonDecoyMatch.Command(helicopterOwner,new(){CommandId=2,
                Ready=new(){ManifestHash=cannonDecoyMatch.ManifestHash}});
            cannonDecoyMatch.Advance(60);
            Check(cannonDecoyMatch.Command(helicopterOwner,new(){CommandId=3,
                UseDecoy=new(){RequestId=new string('8',32)}}).Code=="decoy-spawned"&&
                  cannonDecoyMatch.Command(soldierOwner,new(){CommandId=3,DeployArmy=new()
                    {OptionIndex=cannonDecoyMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying",
                cannonUnit+" and opposing Decoy deploy in a live match");
            ulong cannonEntityId=0,cannonDecoyId=0,cannonTick=61;
            for(;cannonTick<1800&&cannonDecoyId==0&&!cannonDecoyMatch.Terminal;cannonTick++)
            {
                cannonDecoyMatch.Advance(cannonTick);
                cannonEntityId=cannonDecoyMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                    .SingleOrDefault(entity=>entity.UnitId==cannonUnit)?.EntityKey??0;
                cannonDecoyId=cannonEntityId==0?0:
                    cannonDecoyMatch.GroundVehicleCannonDecoyTarget(cannonEntityId)??0;
            }
            Check(cannonEntityId!=0&&cannonDecoyId!=0&&
                  cannonDecoyMatch.DecoyHealth(cannonDecoyId)>0,
                cannonUnit+" cannon selects a live opposing Decoy before player fallback");
            float initialCannonDecoyHealth=cannonDecoyMatch.DecoyHealth(cannonDecoyId)!.Value;
            while(cannonTick<2400&&!cannonDecoyMatch.Terminal&&
                  cannonDecoyMatch.DecoyHealth(cannonDecoyId)==initialCannonDecoyHealth)
                cannonDecoyMatch.Advance(cannonTick++);
            Check(cannonDecoyMatch.DecoyHealth(cannonDecoyId)<initialCannonDecoyHealth||
                  cannonDecoyMatch.DecoyHealth(cannonDecoyId)==null,
                cannonUnit+" normal missile flight damages its selected Decoy");
        }
        var turretVehicleManifest=humveeDecoyManifest with {MatchId="turret-ground-vehicle-priority"};
        var turretVehicleMatch=new MatchEngine(turretVehicleManifest,content:content,armyChoice:_=>0,combatRandom:()=>0);
        turretVehicleMatch.ConfigureBattleAllocations([
            new(soldierOwner,[],[],[0],[-1],[-1]),new(helicopterOwner,["CardHeavyTurret"],[],[0],[-1],[-1])]);
        turretVehicleMatch.Admit(soldierOwner);turretVehicleMatch.Admit(helicopterOwner);
        turretVehicleMatch.Command(soldierOwner,new(){CommandId=1,SelectCards=new(){NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}});
        turretVehicleMatch.Command(helicopterOwner,new(){CommandId=1,SelectCards=new(){CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}});
        turretVehicleMatch.Command(soldierOwner,new(){CommandId=2,Ready=new(){ManifestHash=turretVehicleMatch.ManifestHash}});
        turretVehicleMatch.Command(helicopterOwner,new(){CommandId=2,Ready=new(){ManifestHash=turretVehicleMatch.ManifestHash}});
        turretVehicleMatch.Advance(60);
        Check(turretVehicleMatch.Command(helicopterOwner,new(){CommandId=3,UseHeavyTurret=new(){RequestId=new string('b',32)}}).Code=="heavy-turret-spawned"&&
              turretVehicleMatch.Command(soldierOwner,new(){CommandId=3,DeployArmy=new(){OptionIndex=turretVehicleMatch.ArmyBatch(soldierOwner).OptionIndexes.First()}}).Code=="army-deploying",
              "live opposing turret and ground vehicle activate from trusted allocations");
        bool turretAcquiredVehicle=false;
        bool turretFiredAtVehicle=false;
        ulong turretVehicleCursor=0;
        float? initialVehicleHealth=null;
        float? latestVehicleHealth=null;
        int turretVehicleImpacts=0;
        bool turretHitMovingVehicle=false;
        for(ulong battleTick=61;battleTick<=900&&!turretVehicleMatch.Terminal;battleTick++)
        {
            turretVehicleMatch.Advance(battleTick);
            var eventBatch=turretVehicleMatch.EventBatch(helicopterOwner,turretVehicleCursor);
            turretVehicleMatch.EventBatch(soldierOwner,0);
            if(eventBatch.Events.Count>0)
                turretVehicleCursor=eventBatch.Events[^1].EventId;
            turretFiredAtVehicle|=eventBatch.Events.Any(eventRow=>
                eventRow.Kind==MatchEventKind.HeavyTurretFired&&eventRow.Reason=="vehicle:real");
            turretVehicleImpacts+=eventBatch.Events.Count(eventRow=>
                eventRow.Kind==MatchEventKind.Impact&&eventRow.Reason=="heavy-turret");
            turretAcquiredVehicle|=turretVehicleMatch.Snapshot().HeavyTurrets.Any(turret=>
                turret.TargetId.StartsWith("army:",StringComparison.Ordinal));
            var vehicle=turretVehicleMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                .SingleOrDefault(entity=>entity.UnitId=="ID_UNIT-HUMVEE");
            if(vehicle!=null)
            {
                initialVehicleHealth??=vehicle.Health;
                if(latestVehicleHealth>vehicle.Health&&
                   turretVehicleMatch.VehicleRouteMotion(vehicle.EntityKey)!=null)
                    turretHitMovingVehicle=true;
                latestVehicleHealth=vehicle.Health;
            }
        }
        Check(turretAcquiredVehicle&&turretFiredAtVehicle,"Heavy Turret acquires and launches at source Body target of live opposing Humvee");
        Check(turretVehicleImpacts>0&&initialVehicleHealth>0&&
              latestVehicleHealth<initialVehicleHealth,
            "normal Heavy Turret projectiles hit and damage the opposing Humvee");
        var sharedVehicleHealth=turretVehicleMatch.Snapshot().Vehicles
            .Single(vehicle=>vehicle.UnitId=="ID_UNIT-HUMVEE").Health;
        Check(turretHitMovingVehicle&&latestVehicleHealth.HasValue&&
              Math.Abs(sharedVehicleHealth-latestVehicleHealth.Value)<.01f,
            "Heavy Turret damages a moving Humvee and synchronizes its shared vehicle health");
        foreach(string airUnit in new[]{"ID_UNIT-DRONE","ID_UNIT-HELICOPTER",
            "ID_UNIT-ASSAULTHELI"})
        {
            var turretAirManifest=humveeDecoyManifest with
            {
                MatchId="turret-air-priority-"+airUnit,
                Players=[humveeDecoyManifest.Players[0] with
                    {EquippedArmyUnitIds=[airUnit]},humveeDecoyManifest.Players[1]]
            };
            content.ValidateAllocation(turretAirManifest);
            var turretAirMatch=new MatchEngine(turretAirManifest,content:content,
                armyChoice:_=>0,combatRandom:()=>0);
            turretAirMatch.ConfigureBattleAllocations([
                new(soldierOwner,[],[],[0],[-1],[-1]),
                new(helicopterOwner,["CardHeavyTurret"],[],[0],[-1],[-1])]);
            turretAirMatch.Admit(soldierOwner);turretAirMatch.Admit(helicopterOwner);
            Check(turretAirMatch.Command(soldierOwner,emptyHumveeCards).Code=="cards-selected"&&
                  turretAirMatch.Command(helicopterOwner,new(){CommandId=1,SelectCards=new()
                    {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
                     SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
                airUnit+" target fixture binds both trusted card selections");
            turretAirMatch.Command(soldierOwner,new(){CommandId=2,
                Ready=new(){ManifestHash=turretAirMatch.ManifestHash}});
            turretAirMatch.Command(helicopterOwner,new(){CommandId=2,
                Ready=new(){ManifestHash=turretAirMatch.ManifestHash}});
            turretAirMatch.Advance(60);
            Check(turretAirMatch.Command(helicopterOwner,new(){CommandId=3,
                UseHeavyTurret=new(){RequestId=new string('c',32)}}).Code=="heavy-turret-spawned"&&
                  turretAirMatch.Command(soldierOwner,new(){CommandId=3,DeployArmy=new()
                    {OptionIndex=turretAirMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying",
                airUnit+" and opposing Heavy Turret deploy in a live match");
            bool acquiredAir=false,firedAtAir=false;ulong airTurretCursor=0,lastAirTurretTick=60;
            for(ulong airTurretTick=61;airTurretTick<=1200&&!turretAirMatch.Terminal;airTurretTick++)
            {
                turretAirMatch.Advance(airTurretTick);
                lastAirTurretTick=airTurretTick;
                var batch=turretAirMatch.EventBatch(helicopterOwner,airTurretCursor);
                turretAirMatch.EventBatch(soldierOwner,0);
                if(batch.Events.Count>0)airTurretCursor=batch.Events[^1].EventId;
                firedAtAir|=batch.Events.Any(x=>x.Kind==MatchEventKind.HeavyTurretFired&&
                    x.Reason=="air:real");
                acquiredAir|=turretAirMatch.Snapshot().HeavyTurrets.Any(x=>
                    x.TargetId.StartsWith("army:",StringComparison.Ordinal));
                if(acquiredAir&&firedAtAir)break;
            }
            Check(acquiredAir&&firedAtAir,
                "Heavy Turret acquires and fires at live opposing "+airUnit+" source target");
            var airTargetId=turretAirMatch.ArmyEntityBatch(soldierOwner,0,0).Entities
                .Single(entity=>entity.UnitId==airUnit).EntityKey;
            float? airBefore=turretAirMatch.ArmyHealth(airTargetId);
            for(ulong airTick=lastAirTurretTick+1;airTick<=1800&&!turretAirMatch.Terminal;airTick++)
            {
                turretAirMatch.Advance(airTick);
                if(turretAirMatch.ArmyHealth(airTargetId)!=airBefore)break;
            }
            float? airAfter=turretAirMatch.ArmyHealth(airTargetId);
            var airImpactEvents=turretAirMatch.EventBatch(helicopterOwner,airTurretCursor).Events;
            Check(airBefore>0&&airAfter>=0&&airAfter<airBefore&&
                  airImpactEvents.Any(x=>x.Kind==MatchEventKind.Impact&&x.Reason=="heavy-turret"),
                "Heavy Turret real projectile hits and damages live opposing "+airUnit);
        }
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
        // Reuse this allocation seed so the Transporter keeps source option 32.
        var repairMineMatch=new MatchEngine(transporterManifest,content:content);
        repairMineMatch.Admit(soldierOwner);
        repairMineMatch.Admit(helicopterOwner);
        repairMineMatch.Command(soldierOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=repairMineMatch.ManifestHash}});
        repairMineMatch.Command(helicopterOwner,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=repairMineMatch.ManifestHash}});
        repairMineMatch.Advance(60);
        Check(repairMineMatch.ArmyBatch(soldierOwner).OptionIndexes.Contains(32),
            "metal repair-drone proof receives its source Transporter allocation");
        Check(repairMineMatch.Command(soldierOwner,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=32}}).Code=="army-deploying",
            "metal repair-drone mine proof deploys its source Transporter");
        ulong repairSpawnTick=repairMineMatch.ArmyBatch(soldierOwner).NextDeployTick;
        for(ulong repairTick=61;repairTick<=repairSpawnTick;repairTick++)
            repairMineMatch.Advance(repairTick);
        var repairVehicle=repairMineMatch.ArmyEntityBatch(soldierOwner,0,0).Entities.Single();
        var repairRoot=repairMineMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(target=>target.EntityId==repairVehicle.EntityKey&&
                target.RepairDronePathIndex==0).Hitbox;
        Check(repairMineMatch.TryRegisterLandMine(new string('9',32),helicopterOwner,
                  repairRoot.Center,10f),
            "host-only mine placement overlaps the opposing repair-drone root");
        ulong repairMineId=repairMineMatch.Snapshot().LandMines.Single().EntityId;
        repairMineMatch.Advance(repairSpawnTick+1);
        var movedRepairRoot=repairMineMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(target=>target.EntityId==repairVehicle.EntityKey&&
                target.RepairDronePathIndex==0).Hitbox;
        Check(LandMineExplosion.Triggered(repairRoot.Center,content.LandMines.Prefab,
                  new[]{movedRepairRoot})&&
              repairMineMatch.Snapshot().LandMines.Any(mine=>mine.EntityId==repairMineId),
            "metal MiniDrone root does not trigger a Land Mine on the normal host tick");
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
        var missileDrone=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1];
        var missileDroneBox=transporterMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(x=>x.EntityId==transporterEntity.EntityKey&&x.RepairDronePathIndex==1).Hitbox;
        Vector3 missileDroneCenter=missileDroneBox.Center;
        var tankDroneEffect=BuggyExplosion.ResolveArmy(missileDroneCenter,missileDrone.Position,
            [missileDroneBox],21,tankMissileBinding);
        Check(tankDroneEffect is {Kind:CombatDamageType.Explosion,RawDamage:21},
            "Tank missile selects one MiniDrone root collider without bullet part weight");
        float missileVehicleHealth=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,missileDroneCenter);
        float friendlyMissileHealth=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1].Health;
        Check(Math.Abs(friendlyMissileHealth-missileDrone.Health)<.01f&&
              Math.Abs(transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value-
                  missileVehicleHealth)<.01f,
            "Tank cannon friendKill=false prevents damage to a friendly repair drone");
        transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,missileDroneCenter);
        Check(Math.Abs(transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1].Health-
                  friendlyMissileHealth)<.01f,
            "Buggy primary friendKill=false prevents damage to a friendly repair drone");
        var buggySecondaryBinding=buggyRig.Roles.Single(r=>r.Role=="cannon").Weapons[1].Missile!;
        var missileDecoyManifest=missileDecoySource with {MatchId="vehicle-missile-decoy-blast"};
        var missileDecoyMatch=new MatchEngine(missileDecoyManifest,content:content,armyChoice:_=>0);
        missileDecoyMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardDecoy"],[],[0],[133],[-1]),
            new(decoyOpponent,["CardDecoy"],[],[0],[-1],[-1])]);
        missileDecoyMatch.Admit(decoyPlayer);missileDecoyMatch.Admit(decoyOpponent);
        Check(missileDecoyMatch.Command(decoyPlayer,SelectDecoy(1)).Code=="cards-selected"&&
              missileDecoyMatch.Command(decoyOpponent,opponentSelection).Code=="cards-selected",
            "vehicle missile Decoy match accepts both trusted card selections");
        missileDecoyMatch.Command(decoyPlayer,new(){CommandId=2,
            Ready=new(){ManifestHash=missileDecoyMatch.ManifestHash}});
        missileDecoyMatch.Command(decoyOpponent,new(){CommandId=2,
            Ready=new(){ManifestHash=missileDecoyMatch.ManifestHash}});
        missileDecoyMatch.Advance(60);
        Check(missileDecoyMatch.Command(decoyPlayer,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('a',32)}}).Code=="decoy-spawned"&&
              missileDecoyMatch.Command(decoyOpponent,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('b',32)}}).Code=="decoy-spawned",
            "both factions deploy source Decoys for vehicle missile blasts");
        var friendlyMissileDecoy=missileDecoyMatch.Snapshot().Decoys
            .First(value=>value.OwnerPlayerId==decoyPlayer);
        var friendlyMissileBox=missileDecoyMatch.GroundVehicleShotTargets(decoyOpponent)
            .First(value=>value.Decoy&&value.EntityId==friendlyMissileDecoy.EntityId).Hitbox;
        Vector3 friendlyDecoyCenter=friendlyMissileBox.Center;
        missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding,friendlyDecoyCenter);
        missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,friendlyDecoyCenter);
        Check(Math.Abs(missileDecoyMatch.DecoyHealth(friendlyMissileDecoy.EntityId)!.Value-
                  friendlyMissileDecoy.Health)<.01f,
            "Tank and Buggy primary friendKill=false skip friendly Decoys");
        missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,friendlyDecoyCenter);
        Check(Math.Abs(missileDecoyMatch.DecoyHealth(friendlyMissileDecoy.EntityId)!.Value-
                  (friendlyMissileDecoy.Health-10.5f))<.01f,
            "Buggy secondary missile applies half friendly blast damage to Decoy");
        var enemyMissileDecoy=missileDecoyMatch.Snapshot().Decoys
            .First(value=>value.OwnerPlayerId==decoyOpponent);
        var enemyMissileBox=missileDecoyMatch.GroundVehicleShotTargets(decoyPlayer)
            .First(value=>value.Decoy&&value.EntityId==enemyMissileDecoy.EntityId).Hitbox;
        Vector3 enemyDecoyCenter=enemyMissileBox.Center;
        missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding,enemyDecoyCenter);
        Check(Math.Abs(missileDecoyMatch.DecoyHealth(enemyMissileDecoy.EntityId)!.Value-
                  (enemyMissileDecoy.Health-21))<.01f,
            "opposing Tank missile damages independent Decoy host health");
        Reject(()=>missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},enemyDecoyCenter));
        for(int blast=0;blast<30&&missileDecoyMatch.DecoyHealth(enemyMissileDecoy.EntityId)!=null;blast++)
            missileDecoyMatch.ApplyGroundVehicleMissileDecoyExplosion(decoyPlayer,
                "ID_UNIT-TANK",21,tankMissileBinding,enemyDecoyCenter);
        Check(missileDecoyMatch.DecoyHealth(enemyMissileDecoy.EntityId)==null&&
              missileDecoyMatch.DroneTargetSnapshot().All(value=>
                  value.Id!="decoy:"+enemyMissileDecoy.EntityId),
            "lethal vehicle missile blast removes Decoy health and Drone target authority");
        var missileTurretManifest=missileDecoySource with {MatchId="vehicle-missile-turret-blast",
            Players=missileDecoySource.Players.Select(value=>value with {ShieldLevel=0}).ToArray()};
        var missileTurretMatch=new MatchEngine(missileTurretManifest,content:content,armyChoice:_=>0);
        missileTurretMatch.ConfigureBattleAllocations([
            new(decoyPlayer,["CardHeavyTurret"],[],[0],[133],[-1]),
            new(decoyOpponent,["CardHeavyTurret"],[],[0],[-1],[-1])]);
        missileTurretMatch.Admit(decoyPlayer);missileTurretMatch.Admit(decoyOpponent);
        Check(missileTurretMatch.Command(decoyPlayer,new(){CommandId=1,SelectCards=new()
            {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
             SpecialUpgradeIndexes={133},EliteUpgradeIndexes={-1}}}).Code=="cards-selected"&&
              missileTurretMatch.Command(decoyOpponent,new(){CommandId=1,SelectCards=new()
            {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
             SpecialUpgradeIndexes={-1},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
            "vehicle missile Heavy Turret match accepts trusted card selections");
        missileTurretMatch.Command(decoyPlayer,new(){CommandId=2,
            Ready=new(){ManifestHash=missileTurretMatch.ManifestHash}});
        missileTurretMatch.Command(decoyOpponent,new(){CommandId=2,
            Ready=new(){ManifestHash=missileTurretMatch.ManifestHash}});
        missileTurretMatch.Advance(60);
        Check(missileTurretMatch.Command(decoyPlayer,new(){CommandId=3,UseHeavyTurret=new()
            {RequestId=new string('a',32)}}).Code=="heavy-turret-spawned"&&
              missileTurretMatch.Command(decoyOpponent,new(){CommandId=3,UseHeavyTurret=new()
            {RequestId=new string('b',32)}}).Code=="heavy-turret-spawned",
            "both factions deploy Heavy Turrets for vehicle missile blasts");
        var friendlyMissileTurret=missileTurretMatch.Snapshot().HeavyTurrets
            .Single(value=>value.OwnerPlayerId==decoyPlayer);
        var friendlyMissileTurretBoxes=missileTurretMatch.GroundVehicleShotTargets(decoyOpponent)
            .Where(value=>value.HeavyTurret&&value.EntityId==friendlyMissileTurret.EntityId)
            .Select(value=>value.Hitbox).ToArray();
        Vector3 friendlyTurretCenter=friendlyMissileTurretBoxes[0].Center;
        missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding,friendlyTurretCenter);
        missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,friendlyTurretCenter);
        Check(friendlyMissileTurretBoxes.Length==3&&
              Math.Abs(missileTurretMatch.HeavyTurretHealth(friendlyMissileTurret.EntityId)!.Value-
                  friendlyMissileTurret.Health)<.01f,
            "Tank and Buggy primary missiles skip a friendly Heavy Turret");
        missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,friendlyTurretCenter);
        Check(Math.Abs(missileTurretMatch.HeavyTurretHealth(friendlyMissileTurret.EntityId)!.Value-
                  (friendlyMissileTurret.Health-10.5f))<.01f,
            "Buggy secondary missile damages one friendly Heavy Turret at half strength");
        var enemyMissileTurret=missileTurretMatch.Snapshot().HeavyTurrets
            .Single(value=>value.OwnerPlayerId==decoyOpponent);
        var enemyMissileTurretBox=missileTurretMatch.GroundVehicleShotTargets(decoyPlayer)
            .First(value=>value.HeavyTurret&&value.EntityId==enemyMissileTurret.EntityId).Hitbox;
        Vector3 enemyTurretCenter=enemyMissileTurretBox.Center;
        missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding,enemyTurretCenter);
        Check(Math.Abs(missileTurretMatch.HeavyTurretHealth(enemyMissileTurret.EntityId)!.Value-
                  (enemyMissileTurret.Health-21))<.01f,
            "opposing Tank missile damages one Heavy Turret owner across three colliders");
        Reject(()=>missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},enemyTurretCenter));
        for(int blast=0;blast<200&&missileTurretMatch.HeavyTurretHealth(enemyMissileTurret.EntityId)!=null;blast++)
            missileTurretMatch.ApplyGroundVehicleMissileHeavyTurretExplosion(decoyPlayer,
                "ID_UNIT-TANK",21,tankMissileBinding,enemyTurretCenter);
        Check(missileTurretMatch.HeavyTurretHealth(enemyMissileTurret.EntityId)==null&&
              missileTurretMatch.GroundVehicleShotTargets(decoyPlayer)
                  .All(value=>value.EntityId!=enemyMissileTurret.EntityId),
            "lethal vehicle missile blast removes Heavy Turret health and joint collision authority");
        var missileAirManifest=flameHelicopterManifest with {MatchId="vehicle-missile-air-blast",
            Players=[flameHelicopterManifest.Players[0] with
            {EquippedArmyUnitIds=["ID_UNIT-DRONE"]},flameHelicopterManifest.Players[1]]};
        content.ValidateAllocation(missileAirManifest);
        var missileAirMatch=new MatchEngine(missileAirManifest,content:content,armyChoice:_=>0);
        missileAirMatch.Admit(soldierOwner);missileAirMatch.Admit(helicopterOwner);
        missileAirMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=missileAirMatch.ManifestHash}});
        missileAirMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=missileAirMatch.ManifestHash}});
        missileAirMatch.Advance(60);
        Check(missileAirMatch.Command(soldierOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=missileAirMatch.ArmyBatch(soldierOwner).OptionIndexes[0]}}).Code=="army-deploying"&&
              missileAirMatch.Command(helicopterOwner,new(){CommandId=2,DeployArmy=new()
            {OptionIndex=missileAirMatch.ArmyBatch(helicopterOwner).OptionIndexes[0]}}).Code=="army-deploying",
            "vehicle missile air-body proof deploys both recovered air families");
        for(ulong airTick=61;airTick<=75;airTick++)missileAirMatch.Advance(airTick);
        var missileAirRows=missileAirMatch.ArmyEntityBatch(soldierOwner,0,0).Entities;
        var airMissileDrone=missileAirRows.Single(row=>row.UnitId=="ID_UNIT-DRONE");
        var missileHelicopter=missileAirRows.Single(row=>row.UnitId=="ID_UNIT-HELICOPTER");
        var droneBody=missileAirMatch.GroundVehicleShotTargets(helicopterOwner)
            .Single(target=>target.EntityId==airMissileDrone.EntityKey&&target.DroneRoot).Hitbox.Center;
        var helicopterBody=missileAirMatch.GroundVehicleShotTargets(soldierOwner)
            .First(target=>target.EntityId==missileHelicopter.EntityKey&&target.HelicopterBody).Hitbox.Center;
        float friendlyDroneHealth=missileAirMatch.ArmyHealth(airMissileDrone.EntityKey)!.Value;
        missileAirMatch.ApplyGroundVehicleMissileAirBodyExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,droneBody);
        missileAirMatch.ApplyGroundVehicleMissileAirBodyExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,droneBody);
        Check(missileAirMatch.ArmyHealth(airMissileDrone.EntityKey)==friendlyDroneHealth,
            "Tank and Buggy primary missiles cannot damage a friendly Drone body");
        missileAirMatch.ApplyGroundVehicleMissileAirBodyExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,droneBody);
        Check(Math.Abs(missileAirMatch.ArmyHealth(airMissileDrone.EntityKey)!.Value-
                  (friendlyDroneHealth-10.5f))<.01f,
            "Buggy secondary missile applies recovered half friendly damage to Drone root");
        float enemyHelicopterHealth=missileAirMatch.ArmyHealth(missileHelicopter.EntityKey)!.Value;
        missileAirMatch.ApplyGroundVehicleMissileAirBodyExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,helicopterBody);
        Check(Math.Abs(missileAirMatch.ArmyHealth(missileHelicopter.EntityKey)!.Value-
                  (enemyHelicopterHealth-21))<.01f,
            "Tank missile explosion damages one opposing Helicopter body once");
        Reject(()=>missileAirMatch.ApplyGroundVehicleMissileAirBodyExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},helicopterBody));
        transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,missileDroneCenter);
        float friendlyBuggyHealth=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1].Health;
        Check(Math.Abs(friendlyBuggyHealth-(friendlyMissileHealth-10.5f))<.01f&&
              Math.Abs(transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value-
                  missileVehicleHealth)<.01f,
            "Buggy secondary friendKill=true permits half-damage to a friendly repair drone");
        transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(helicopterOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,missileDroneCenter);
        float opposingMissileHealth=transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1].Health;
        Check(Math.Abs(opposingMissileHealth-Math.Max(0,friendlyBuggyHealth-21))<.01f&&
              Math.Abs(transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value-
                  missileVehicleHealth)<.01f,
            "opposing Buggy missile blast damages the same independent repair-drone health");
        transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(helicopterOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,missileDroneCenter);
        Check(Math.Abs(transporterMatch.TransporterRepairDrones(transporterEntity.EntityKey)[1].Health-
                  Math.Max(0,opposingMissileHealth-21))<.01f,
            "opposing Tank cannon blast damages the same independent repair-drone health");
        Reject(()=>transporterMatch.ApplyGroundVehicleMissileRepairDroneExplosion(helicopterOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding with {MinimumDamage=1},missileDroneCenter));
        var missilePassenger=transporterMatch.VehiclePassengers(transporterEntity.EntityKey)
            .First(value=>value.Active);
        var missilePassengerBox=transporterMatch.GroundVehicleShotTargets(helicopterOwner)
            .First(target=>target.EntityId==transporterEntity.EntityKey&&
                target.PassengerRole==missilePassenger.Role).Hitbox;
        Vector3 missilePassengerCenter=missilePassengerBox.Center;
        float bodyBeforePassengerMissile=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        transporterMatch.ApplyGroundVehicleMissilePassengerExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,missilePassengerCenter);
        transporterMatch.ApplyGroundVehicleMissilePassengerExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,missilePassengerCenter);
        float passengerAfterPrimaryMissiles=transporterMatch.VehiclePassengers(transporterEntity.EntityKey)
            .Single(value=>value.Role==missilePassenger.Role).Health;
        Check(Math.Abs(passengerAfterPrimaryMissiles-missilePassenger.Health)<.01f,
            "Tank and Buggy primary missiles skip a friendly attached passenger");
        transporterMatch.ApplyGroundVehicleMissilePassengerExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,missilePassengerCenter);
        float passengerAfterFriendlyMissile=transporterMatch.VehiclePassengers(transporterEntity.EntityKey)
            .Single(value=>value.Role==missilePassenger.Role).Health;
        Check(Math.Abs(passengerAfterFriendlyMissile-
                  Math.Max(0,missilePassenger.Health-10.5f))<.01f,
            "Buggy secondary missile applies half blast damage to a friendly passenger");
        Check(passengerAfterFriendlyMissile>21,
            "Transporter passenger survives long enough to verify opposing missile damage");
        transporterMatch.ApplyGroundVehicleMissilePassengerExplosion(helicopterOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,missilePassengerCenter);
        float passengerAfterEnemyMissile=transporterMatch.VehiclePassengers(transporterEntity.EntityKey)
            .Single(value=>value.Role==missilePassenger.Role).Health;
        Check(Math.Abs(passengerAfterEnemyMissile-(passengerAfterFriendlyMissile-21))<.01f&&
              Math.Abs(transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value-
                  bodyBeforePassengerMissile)<.01f,
            "opposing Tank blast damages passenger separately from Transporter body");
        Reject(()=>transporterMatch.ApplyGroundVehicleMissilePassengerExplosion(helicopterOwner,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},missilePassengerCenter));
        var missileBody=transporterMatch.GroundVehicleShotTargets(helicopterOwner)
            .First(target=>target.EntityId==transporterEntity.EntityKey&&target.GroundVehicleBody).Hitbox;
        Vector3 missileBodyCenter=missileBody.Center;
        float vehicleHealthBeforeMissile=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        float vehicleKevlarBeforeMissile=transporterMatch.ArmyKevlar(transporterEntity.EntityKey)!.Value;
        float bodyMissileDamage=vehicleKevlarBeforeMissile+21;
        var vehicleBeforeMissile=transporterMatch.Snapshot().Vehicles.Single();
        var bodyEffect=BuggyExplosion.ResolveArmy(missileBodyCenter,
            new Vector3(vehicleBeforeMissile.X,vehicleBeforeMissile.Y,vehicleBeforeMissile.Z),[missileBody],
            bodyMissileDamage,tankMissileBinding);
        Check(bodyEffect is {Kind:CombatDamageType.Explosion}&&
              Math.Abs(bodyEffect.RawDamage-bodyMissileDamage)<.01f,
            "Tank blast selects one nearest Transporter body collider without shot-part weight");
        transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(helicopterOwner,
            "ID_UNIT-TANK",bodyMissileDamage,tankMissileBinding,missileBodyCenter);
        float vehicleAfterEnemyMissile=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        Check(Math.Abs(vehicleAfterEnemyMissile-(vehicleHealthBeforeMissile-21))<.01f&&
              Math.Abs(transporterMatch.Snapshot().Vehicles.Single().Health-
                  vehicleAfterEnemyMissile)<.01f,
            "opposing Tank blast keeps Army and vehicle-registry health synchronized");
        transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(soldierOwner,
            "ID_UNIT-TANK",21,tankMissileBinding,missileBodyCenter);
        transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggyMissileBinding,missileBodyCenter);
        Check(Math.Abs(transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value-
                  vehicleAfterEnemyMissile)<.01f,
            "Tank and Buggy primary friendKill=false prevent allied vehicle blast damage");
        transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(soldierOwner,
            "ID_UNIT-BUGGY",21,buggySecondaryBinding,missileBodyCenter);
        float vehicleAfterFriendlyMissile=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value;
        Check(Math.Abs(vehicleAfterFriendlyMissile-(vehicleAfterEnemyMissile-10.5f))<.01f&&
              Math.Abs(transporterMatch.Snapshot().Vehicles.Single().Health-
                  vehicleAfterFriendlyMissile)<.01f,
            "Buggy secondary permits half-damage to allied ground vehicle with synchronized health");
        Reject(()=>transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(helicopterOwner,
            "ID_UNIT-TANK",21,tankMissileBinding with {MinimumDamage=1},missileBodyCenter));
        float lethalMissileDamage=transporterMatch.ArmyHealth(transporterEntity.EntityKey)!.Value+
            transporterMatch.ArmyKevlar(transporterEntity.EntityKey)!.Value+1;
        transporterMatch.ApplyGroundVehicleMissileVehicleExplosion(helicopterOwner,
            "ID_UNIT-TANK",lethalMissileDamage,tankMissileBinding,missileBodyCenter);
        Check(transporterMatch.ArmyHealth(transporterEntity.EntityKey)==null&&
              transporterMatch.Snapshot().Vehicles.All(value=>value.EntityId!=transporterEntity.EntityKey)&&
              transporterMatch.GroundVehicleShotTargets(helicopterOwner).All(value=>
                  value.EntityId!=transporterEntity.EntityKey),
            "lethal Tank blast removes vehicle, shared vitality, and collision authority together");
        var repairShotManifest=transporterManifest with {MatchId="player-shot-repair-drone",
            DurationSeconds=180};
        var repairShotMatch=new MatchEngine(repairShotManifest,content:content,armyChoice:_=>0);
        repairShotMatch.Admit(soldierOwner);repairShotMatch.Admit(helicopterOwner);
        repairShotMatch.Command(soldierOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=repairShotMatch.ManifestHash}});
        repairShotMatch.Command(helicopterOwner,new(){CommandId=1,
            Ready=new(){ManifestHash=repairShotMatch.ManifestHash}});
        repairShotMatch.Advance(60);
        int repairShotOption=repairShotMatch.ArmyBatch(soldierOwner).OptionIndexes.First();
        Check(repairShotMatch.Command(soldierOwner,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=repairShotOption}}).Code=="army-deploying",
            "special-lane Transporter deploys for natural player bullet collision");
        ulong repairShotTick=60;
        while(repairShotTick<700&&repairShotMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities.Count==0)
            repairShotMatch.Advance(++repairShotTick);
        var shotTransporter=repairShotMatch.ArmyEntityBatch(helicopterOwner,0,0).Entities.Single();
        float initialRepairHealth=repairShotMatch.TransporterRepairDrones(shotTransporter.EntityKey)[0].Health;
        bool repairBulletHit=false;
        ulong repairFireCommand=2;
        for(;repairShotTick<3000&&!repairShotMatch.Terminal;)
        {
            if(repairShotTick%12==0)
            {
                var target=repairShotMatch.GroundVehicleShotTargets(helicopterOwner)
                    .FirstOrDefault(x=>x.EntityId==shotTransporter.EntityKey&&
                        x.RepairDronePathIndex==0);
                if(target==null)break;
                Vector3 aim=target.Hitbox.Center;
                repairShotMatch.Command(helicopterOwner,new(){CommandId=repairFireCommand++,
                    Fire=new(){TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            }
            repairShotMatch.Advance(++repairShotTick);
            if(repairShotMatch.TransporterRepairDrones(shotTransporter.EntityKey)[0].Health<initialRepairHealth)
            {repairBulletHit=true;break;}
        }
        Check(repairBulletHit&&repairShotMatch.Snapshot().Players
                  .Single(x=>x.PlayerId==helicopterOwner).ConfirmedEnemyHits>0,
            "normal player Fire projectile reaches the moving Transporter repair-drone root");
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
