using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneGroundProbeTests
{
    internal static int Run(string directory,BattleCombatContent content)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-ground-probes.json")));
        using var physics=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-unity-physics-settings.json")));
        int checks=0;
        foreach(var row in document.RootElement.GetProperty("maps").EnumerateArray())
        {
            var map=content.Maps.Single(m=>m.Source==row.GetProperty("source").GetString());
            if(map.SourceHash!=row.GetProperty("sourceSha256").GetString())
                throw new Exception("Drone ground probe scene provenance differs.");
            foreach(var point in row.GetProperty("points").EnumerateArray())
            {
                var xyz=point.GetProperty("origin");var origin=new Vector3(xyz[0].GetSingle(),xyz[1].GetSingle(),xyz[2].GetSingle());
                foreach(string eligibility in new[]{"alliesCollide","enemiesCollide"})
                {
                    var hits=point.GetProperty("hits").EnumerateArray().Where(h=>h.GetProperty(eligibility).GetBoolean()).ToArray();
                    int layer=eligibility=="alliesCollide"?26:27;
                    uint mask=Convert.ToUInt32(physics.RootElement.GetProperty("layers")[layer]
                        .GetProperty("collisionMask").GetString(),16);
                    var actual=map.Raycast(origin,-Vector3.UnitY,100,mask);
                    if(hits.Length==0){if(actual!=null)throw new Exception("Unexpected Drone ground hit.");checks++;continue;}
                    var expected=hits[0];
                    if(actual==null||actual.SourcePath!=expected.GetProperty("path").GetString()||
                       Math.Abs(actual.Distance-expected.GetProperty("distance").GetSingle())>.002f)
                        throw new Exception("Drone ground probe differs: "+map.Source+" waypoint "+
                            point.GetProperty("waypointFileId")+" actual "+actual+" expected "+expected);
                    checks++;
                }
            }
        }
        return checks;
    }
}
