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
                    var surface=expected.GetProperty("position");
                    var surfacePosition=new Vector3(surface[0].GetSingle(),surface[1].GetSingle(),surface[2].GetSingle());
                    if(!map.SphereOverlaps(surfacePosition+Vector3.UnitY*.005f,.01f,mask))
                        throw new Exception("Source ray intersection lacks static sphere surface overlap.");
                    if(map.SphereOverlaps(new Vector3(origin.X,100,origin.Z),.01f,mask))
                        throw new Exception("Drone high-air sphere unexpectedly overlaps map geometry.");
                    checks+=2;
                    if(expected.GetProperty("layer").GetInt32()==30)
                    {
                        var contacts=map.SphereSurfaceContacts(surfacePosition+Vector3.UnitY*.005f,.01f,0,mask);
                        var contact=contacts.FirstOrDefault(c=>c.SourcePath==expected.GetProperty("path").GetString());
                        if(contact==null||Vector3.Distance(contact.SurfacePoint,surfacePosition)>.006f||
                           Math.Abs(contact.Normal.Length()-1)>.0001f||contact.Separation>0||contact.Separation<-.01f)
                            throw new Exception("Ground sphere contact point/normal disagrees with source ray surface.");
                        checks++;
                        if(map.SphereSurfaceContacts(surfacePosition+Vector3.UnitY*.005f,.01f,0,mask,
                            colliderEnabled:_=>false).Count!=0)
                            throw new Exception("Disabled colliders leaked into sphere contact authority.");
                        if(map.SphereSurfaceContacts(surfacePosition+Vector3.UnitY*.005f,.01f,0,0).Count!=0)
                            throw new Exception("Empty runtime mask leaked sphere contacts.");
                        checks+=2;
                    }
                }
            }
        }
        return checks;
    }
}
