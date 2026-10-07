using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json.Nodes;
using War.BattleServer;
internal static class AirWaypointCatalogTests
{
    internal static int Run(string directory,BattleCombatContent content)
    {
        int count=0;string path=Path.Combine(directory,"recovered-air-waypoint-routes.json");
        string revision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
        var catalog=AirWaypointCatalog.Load(path,revision,content.ArmySpawnPoints,content.Maps);
        foreach(var map in content.Maps)
            foreach(var spawn in content.ArmySpawnPoints.ForMap(map).Where(p=>p.Collection=="spawnPointsCollectionDrones"))
            {
                var route=catalog.ForSpawn(map,spawn.ComponentFileId);
                var packaged=content.AirWaypoints.ForSpawn(map,spawn.ComponentFileId);
                if(route.Waypoints.Count!=5||route.Radius!=.2f||route.Waypoints[route.JoinIndex].ComponentFileId!=spawn.JoinWaypointFileId)
                    throw new Exception("Drone catalog lost source route binding.");
                if(packaged.JoinIndex!=route.JoinIndex||!packaged.Waypoints.SequenceEqual(route.Waypoints))
                    throw new Exception("Combat package omitted validated air routes.");
                count++;
            }
        foreach(var map in content.Maps)
            foreach(var spawn in content.ArmySpawnPoints.ForMap(map).Where(p=>p.Collection=="spawnPointsCollectionHelicopters"))
            {
                var route=catalog.ForSpawn(map,spawn.ComponentFileId);
                var packaged=content.AirWaypoints.ForSpawn(map,spawn.ComponentFileId);
                if(route.StopIndex<=route.JoinIndex||route.StopIndex>=route.Waypoints.Count||
                   route.Waypoints[route.StopIndex].ComponentFileId==spawn.JoinWaypointFileId||
                   packaged.StopIndex!=route.StopIndex)
                    throw new Exception("Helicopter stop target lost its source route binding.");
                count++;
            }
        var sourceRoute = new AirWaypointRoute(1, 2, 0, -1, 0.1f,
            [new DroneWaypoint(3, new Vector3(1, 0, 0), 0),
             new DroneWaypoint(4, new Vector3(2, 0, 0), 0)]);
        var movingAssaultHelicopter = new AssaultHelicopterWaypointState(
            sourceRoute, Vector3.Zero, 0.87f, () => 0.5f);
        movingAssaultHelicopter.Advance(2, 1f / 30);
        if (Math.Abs(movingAssaultHelicopter.Position.X - 0.04f) > 0.00001f ||
            Math.Abs(movingAssaultHelicopter.Velocity.X - 0.02f) > 0.00001f)
            throw new Exception("Assault Helicopter lost its clamped speed or double root movement.");
        count++;
        Vector3 firstForward = Vector3.Transform(Vector3.UnitZ,
            movingAssaultHelicopter.Rotation);
        if (firstForward.X <= 0 || firstForward.Y >= 0 ||
            Math.Abs(movingAssaultHelicopter.Rotation.LengthSquared() - 1) > 0.0001f)
            throw new Exception("Assault Helicopter lost its source forward tilt or unit rotation.");
        count++;

        var untargetedHelicopter = new AssaultHelicopterWaypointState(
            sourceRoute, Vector3.Zero, 0.87f, () => 0.5f);
        untargetedHelicopter.Advance(2, 1f / 30);
        untargetedHelicopter.Advance(2 + 1f / 30, 1f / 30);
        movingAssaultHelicopter.Advance(2 + 1f / 30, 1f / 30,
            new Vector3(-1, 0, 0));
        if (Math.Abs(Quaternion.Dot(untargetedHelicopter.Rotation,
                movingAssaultHelicopter.Rotation)) >= 0.999f)
            throw new Exception("Assault Helicopter did not turn toward its selected target root.");
        count++;

        var reversingAssaultHelicopter = new AssaultHelicopterWaypointState(
            sourceRoute with { Radius = 0.2f }, new Vector3(1, 0, 0), 0.6f, () => 0);
        reversingAssaultHelicopter.Advance(2, 1f / 30);
        if (reversingAssaultHelicopter.UsingWaypoints ||
            reversingAssaultHelicopter.Position != new Vector3(1, 0, 0))
            throw new Exception("Assault Helicopter did not stop after reversing at the first waypoint.");
        count++;
        string temporary=Path.GetTempFileName();
        try
        {
            foreach(var mutation in new Action<JsonObject>[] {
                root=>root["spawnSourceSha256"]=new string('0',64),
                root=>root["maps"]![0]!["routes"]!.AsArray().RemoveAt(0),
                root=>root["maps"]![0]!["routes"]![0]!["joinIndex"]=99,
                root=>root["maps"]![0]!["routes"]![0]!["stopIndex"]=0,
                root=>root["maps"]![0]!["routes"]![0]!["radius"]=0,
                root=>root["maps"]![0]!["routes"]![0]!["waypoints"]![0]!["stayTime"]=-1,
                root=>root["maps"]![0]!["routes"]![0]!["waypoints"]![0]!["worldPosition"]![0]=99,
                root=>root["maps"]![0]!["routes"]![0]!["waypoints"]![0]!["index"]=1,
                root=>root["maps"]![0]!["routes"]![0]!["unexpected"]=true })
            {
                var root=JsonNode.Parse(File.ReadAllText(path))!.AsObject();mutation(root);
                File.WriteAllText(temporary,root.ToJsonString());
                string changed=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(temporary)));
                try{AirWaypointCatalog.Load(temporary,changed,content.ArmySpawnPoints,content.Maps);}
                catch(InvalidDataException){count++;continue;}
                throw new Exception("Damaged air waypoint authority accepted.");
            }
        }
        finally{File.Delete(temporary);}
        return count;
    }
}
