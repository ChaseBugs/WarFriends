using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

// Trusted deployment input; never accepted from a game packet. Fixed neighboring
// filenames keep the package portable between Windows and Linux.
public sealed record CombatContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision,string AllWeaponBindingsRevision,string PosesRevision,string BarrelBindingsRevision,string BarrelOverlapRevision,string ArmyDeploymentRevision,string ArmyWeaponBindingsRevision,string GroundVehicleWeaponsRevision,string EnemyPosesRevision,string DecoyRevision,string LandMineRevision,string HeavyTurretRevision,string ArmySpawnPointsRevision,string ArmyRusherPointsRevision,string ArmyMinigunnerPointsRevision,string PlayerShotTargetsRevision,string ArmyNavMeshSourcesRevision,string ArmyNavMeshTriangulationRevision,string ArmyNavMeshPathsRevision,string AirWaypointRoutesRevision,string DroneWeaponRevision,string AirGeometryRevision,string HelicopterCrewPointsRevision,string DroneProjectileRevision,string EnemyShotTargetsRevision,string? MortarWeaponPoolRevision=null,string? CoopAssaulterWeaponRevision=null);
