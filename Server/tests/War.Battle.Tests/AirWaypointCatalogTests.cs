using System.Security.Cryptography;
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
                if(route.Waypoints.Count!=5||route.Radius!=.2f||route.Waypoints[route.JoinIndex].ComponentFileId!=spawn.JoinWaypointFileId)
                    throw new Exception("Drone catalog lost source route binding.");
                count++;
            }
        string temporary=Path.GetTempFileName();
        try
        {
            foreach(var mutation in new Action<JsonObject>[] {
                root=>root["spawnSourceSha256"]=new string('0',64),
                root=>root["maps"]![0]!["routes"]!.AsArray().RemoveAt(0),
                root=>root["maps"]![0]!["routes"]![0]!["joinIndex"]=99,
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
