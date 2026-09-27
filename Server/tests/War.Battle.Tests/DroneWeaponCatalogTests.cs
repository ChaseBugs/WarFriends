using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;
internal static class DroneWeaponCatalogTests
{
    internal static int Run(string directory)
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        var path=Path.Combine(directory,"recovered-drone-weapon.json");
        var revision=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
        var catalog=DroneWeaponCatalog.Load(path,revision);
        var colliders=DroneColliderCatalog.Load(Path.Combine(directory,"recovered-air-unit-geometry.json"));
        var rest=colliders.Place(Vector3.Zero,Quaternion.Identity);
        Check(rest.Count==2&&rest[0].RootOwned&&!rest[1].RootOwned&&rest[1].SerializedLayer==8,
            "Drone root box and child static sphere retain separate layer ownership");
        Check(rest[1].Hitbox.Radius==.43f&&rest[0].Hitbox.Size==new Vector3(.7734146f,.17858717f,.76962006f),
            "verified Drone collider dimensions");
        var rotated=colliders.Place(new(2,3,4),Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/2));
        Check(Vector3.Distance(rotated[0].Hitbox.Center,new Vector3(2.023748398f,3.04583633f,4.00030708313f))<1e-6f&&
            rotated[1].Hitbox.Center==new Vector3(2,3,4),"Drone root rotation places offset box and centered sphere");

        using(var geometryDoc=JsonDocument.Parse(File.ReadAllText(Path.Combine(directory,"unity-drone-collider-reference.json"))))
        {
            Check(geometryDoc.RootElement.GetProperty("sha256").GetString()=="c2afc19487462e6163ad107267ef1b35c9c86fb34fa80898135b1d25f4a872a3","Unity collider probes bind recovered Drone prefab");
            var probes=geometryDoc.RootElement.GetProperty("probes");
            Check(probes.GetArrayLength()==72,"complete independent Drone collider ray probes");
            Vector3 V(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
            foreach(var probe in probes.EnumerateArray())
            {
                var q=probe.GetProperty("rotation");
                var placed=colliders.Place(V(probe.GetProperty("position")),new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle()));
                var box=placed.Single(c=>c.ComponentFileId==probe.GetProperty("colliderFileId").GetInt32());
                var distance=box.Hitbox.Raycast(V(probe.GetProperty("origin")),V(probe.GetProperty("direction")),probe.GetProperty("range").GetSingle());
                Check(distance.HasValue==probe.GetProperty("hit").GetBoolean()&&
                    (!distance.HasValue||Math.Abs(distance.Value-probe.GetProperty("distance").GetSingle())<.0002f),
                    "rotated Drone host collider ray matches independent Unity Collider.Raycast");
            }
        }
        Check(!catalog.Ready(.17f,0)&&catalog.Ready(.2f,0),"strict Drone weapon cadence at thirty Hz");
        Check(!catalog.Ready(1.17f,1)&&catalog.Ready(1.2f,1),"source cadence binds previous shot clock");
        using(var doc=JsonDocument.Parse(File.ReadAllText(Path.Combine(directory,"unity-drone-weapon-reference.json"))))
        {
            var probes=doc.RootElement.GetProperty("probes");Check(probes.GetArrayLength()==4,"complete independent Drone muzzle probes");
            Vector3 V(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
            foreach(var p in probes.EnumerateArray())
            {
                var q=p.GetProperty("rotation");var rotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
                Check(Vector3.Distance(catalog.Muzzle(V(p.GetProperty("position")),rotation),V(p.GetProperty("muzzle")))<.0002f,
                    "runtime Drone muzzle matches independent Unity transformed hierarchy");
            }
        }
        var temporary=Path.GetTempFileName();
        try
        {
            foreach(var mutation in new Action<JsonObject>[] {
                r=>r["cadence"]=.18,r=>r["projectileGuid"]=new string('0',32),r=>r["infiniteAmmo"]=false,
                r=>r["restSpawnPosition"]![0]=.1,r=>r["shotOffset"]![0]=.1,r=>r["restSpawnRotation"]![3]=1,
                r=>r["unexpected"]=true })
            {
                var r=JsonNode.Parse(File.ReadAllText(path))!.AsObject();mutation(r);File.WriteAllText(temporary,r.ToJsonString());
                var changed=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(temporary)));
                try{DroneWeaponCatalog.Load(temporary,changed);}
                catch(InvalidDataException){count++;continue;}
                throw new Exception("Damaged Drone weapon authority accepted.");
            }
        }
        finally{File.Delete(temporary);}
        return count;
    }
}
