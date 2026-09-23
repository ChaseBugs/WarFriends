using System.Security.Cryptography;
using System.Text.Json.Nodes;
using System.Numerics;
using War.BattleServer;

internal static class RifleStatTests
{
    internal static int Run(string path)
    {
        int checks = 0;
        void Check(bool value, string name) { if (!value) throw new Exception(name); checks++; }
        void Reject(Action action, string name)
        {
            try { action(); } catch (InvalidDataException) { checks++; return; }
            throw new Exception(name);
        }
        var bytes = File.ReadAllBytes(path);
        string hash = Convert.ToHexStringLower(SHA256.HashData(bytes));
        var source = JsonNode.Parse(bytes)!.AsObject();
        string scene = source["mainSceneSha256"]!.GetValue<string>();
        var catalog = RifleStatCatalog.Load(path,hash,scene);
        Check(catalog.WeaponCount == 11 && catalog.StageCount == 586,"complete rifle lanes");
        Check(catalog.Revision == hash && catalog.SceneRevision == scene,"rifle provenance");
        var first = catalog.Get("Google2u.AssaultRifle_AK47",0);
        Check(first.ClipSize == 28 && first.ReserveAmmo == 180 && first.ReloadSeconds == 3.7f &&
            first.Damage == 21.76f && first.CadenceSeconds == .2f && first.CriticalProbability == .05f &&
            first.PlayerDamageRatio == .4085f && first.OvertimePlayerDamageRatio == .33f,"AK47 initial source stats");
        Check(catalog.Get(first.SourceId,25).Damage == 174.8f,"AK47 final source stage");
        Check(catalog.Get(first.SourceId,0).Damage == 21.76f,"lookup preserves source stage");
        var manifestWeapon = catalog.CreateManifest(first.SourceId,0);
        var match = new MatchManifest("rifle-test","test-host","test-map",hash,hash,MatchManifest.PrototypeMode,
            10,60,10,[new(new string('a',32),manifestWeapon),new(new string('b',32),manifestWeapon)]);
        Check(MatchManifest.Validate(match).Players[0].Weapon == manifestWeapon,"source identity admitted in trusted manifest");
        foreach (string bad in new[] { "Google2u..AK47", "Google2u/AK47", " Google2u.AK47", "Google2u.AK47\n" })
            Reject(() => MatchManifest.Validate(match with { Players = [new(new string('a',32),manifestWeapon with { SourceId = bad }),match.Players[1]] }),"invalid weapon identity");
        Reject(() => catalog.Get(first.SourceId,-1),"negative stage");
        Reject(() => catalog.Get(first.SourceId,26),"overflow stage");
        Reject(() => catalog.Get("Google2u.Bazooka_RPG",0),"unsupported weapon family");
        Reject(() => RifleStatCatalog.Load(path,new string('0',64),scene),"content mismatch");
        Reject(() => RifleStatCatalog.Load(path,hash,new string('0',64)),"scene mismatch");
        string bindingPath=Path.Combine(Path.GetDirectoryName(path)!,"recovered-rifle-bindings.json");
        byte[] bindingBytes=File.ReadAllBytes(bindingPath);
        string bindingHash=Convert.ToHexStringLower(SHA256.HashData(bindingBytes));
        var bindings=RifleBindingCatalog.Load(bindingPath,bindingHash,catalog);
        Check(bindings.Count==11 && bindings.SceneRevision==scene,"complete source rifle bindings");
        var ak=bindings.Get(first.SourceId);
        var poses=PlayerPoseCatalog.Load(Path.Combine(Path.GetDirectoryName(path)!,"recovered-player-poses.json"),scene,bindings);
        checks+=RiflePlaybackTests.Run(catalog,bindings,poses);
        Check(poses.SampleMuzzle("idle",first.SourceId,0,false).SourcePath==ak.MuzzlePath,"pose muzzle bound to weapon catalog");
        Check(ak.InventoryIndex==11 && ak.Speed==30 && ak.CheckDistance==.5f && ak.CriticalMultiplier==2,"AK47 prefab parameters");
        string owner=new string('a',32);
        PreparedProjectile Prepare(float roll) => bindings.Prepare(catalog,first.SourceId,0,1,owner,Vector3.Zero,new Vector3(10,0,0),0,roll,(_,_,_)=>null);
        Check(Prepare(0).Damage.Amount==first.Damage*2,"source critical multiplier applied once");
        var ordinary=Prepare(first.CriticalProbability);
        Check(ordinary.Damage.Amount==first.Damage && ordinary.Damage.PlayerCoefficient==first.PlayerDamageRatio &&
            ordinary.Damage.PlayerOvertimeCoefficient==first.OvertimePlayerDamageRatio,"source strict critical boundary and player coefficients");
        Check(ordinary.Flight.Position==ak.ShotOffset,"world shot offset applied to host muzzle");
        Reject(()=>Prepare(float.NaN),"invalid random authority");
        Reject(()=>Prepare(-.1f),"negative random authority");
        Reject(()=>RifleBindingCatalog.Load(bindingPath,new string('0',64),catalog),"binding digest mismatch");
        string temp = Path.Combine(Path.GetTempPath(),"war-rifle-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            void Corrupt(Action<JsonObject> change, string name)
            {
                var copy = source.DeepClone().AsObject();
                change(copy);
                byte[] damaged = System.Text.Encoding.UTF8.GetBytes(copy.ToJsonString());
                File.WriteAllBytes(temp,damaged);
                // Even explicitly repinned damaged artifacts must fail structural validation.
                Reject(() => RifleStatCatalog.Load(temp,Convert.ToHexStringLower(SHA256.HashData(damaged)),scene),name);
            }
            JsonArray Sheets(JsonObject root) => root["sheets"]!.AsArray();
            JsonArray Rows(JsonObject root, string type) => Sheets(root).Single(x => x!["type"]!.GetValue<string>() == type)!["rows"]!.AsArray();
            Corrupt(x => Rows(x,first.SourceId).RemoveAt(0),"truncated lane");
            Corrupt(x => Sheets(x).Add(Sheets(x)[0]!.DeepClone()),"duplicate sheet");
            Corrupt(x => Rows(x,"Google2u.WeaponUpgrades").Add(Rows(x,"Google2u.WeaponUpgrades")[0]!.DeepClone()),"duplicate definition");
            Corrupt(x => Rows(x,first.SourceId)[0]!["CLIPSIZE"] = 1.5,"fractional clip");
            Corrupt(x => Rows(x,first.SourceId)[0]!["AMMO"] = -1,"negative ammunition");
            Corrupt(x => Rows(x,first.SourceId)[0]!["DAMAGE"] = "21.76","string damage");
            Corrupt(x => Rows(x,first.SourceId)[0]!["RELOADTIME"] = 0,"zero reload");
            Corrupt(x => Rows(x,"Google2u.WeaponUpgrades")[0]!["CRITICAL"] = 1.01,"invalid critical probability");
            void CorruptBinding(Action<JsonObject> change,string name)
            {
                var copy=JsonNode.Parse(bindingBytes)!.AsObject(); change(copy);
                byte[] data=System.Text.Encoding.UTF8.GetBytes(copy.ToJsonString());
                File.WriteAllBytes(temp,data);
                Reject(()=>RifleBindingCatalog.Load(temp,Convert.ToHexStringLower(SHA256.HashData(data)),catalog),name);
            }
            CorruptBinding(x=>x["weapons"]!.AsArray().RemoveAt(0),"missing rifle binding");
            CorruptBinding(x=>x["weapons"]![1]=x["weapons"]![0]!.DeepClone(),"duplicate rifle binding");
            CorruptBinding(x=>x["weapons"]![0]!["definitionSpeed"]=0,"invalid definition speed");
            CorruptBinding(x=>x["weapons"]![0]!["weaponType"]="LightMachinegun","unsupported spread controller");
            CorruptBinding(x=>x["weapons"]![0]!["muzzlePath"]="MainSceneRootNew/OtherPlayer/gun","foreign muzzle binding");
            CorruptBinding(x=>x["weapons"]![0]!["criticalMultiplier"]=-2,"negative critical multiplier");
        }
        finally { if (File.Exists(temp)) File.Delete(temp); }
        return checks;
    }
}
