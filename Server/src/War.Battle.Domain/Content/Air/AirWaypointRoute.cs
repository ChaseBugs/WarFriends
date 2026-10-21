using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed record AirWaypointRoute(int SpawnComponentFileId,int PathComponentFileId,
    int JoinIndex,int StopIndex,float Radius,IReadOnlyList<DroneWaypoint> Waypoints);
