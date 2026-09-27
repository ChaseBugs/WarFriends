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
