using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.Backend;

/// <summary>Allocator-side projection of the same immutable rifle rows the
/// Worker validates. This never accepts weapon numbers from a Client.</summary>
public sealed class BattleRifleManifestCatalog
{
    private static readonly (string Name,int Count)[] Expected=
    [
        ("AssaultRifle_AK47",26),("AssaultRifle_Famas",56),("AssaultRifle_G36",76),
        ("AssaultRifle_M16",36),("AssaultRifle_QBZ95",46),("AssaultRifle_SteyrAUG",66),
        ("AssaultRifle_AKS47U",76),("AssaultRifle_G36Elite",76),("AssaultRifle_FamasElite",56),
        ("AssaultRifle_QBZ95Elite",46),("AssaultRifle_AK47Elite",26)
    ];
    private sealed record ContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision,string AllWeaponBindingsRevision,
        string PosesRevision,string BarrelBindingsRevision,string BarrelOverlapRevision,string ArmyDeploymentRevision,
        string ArmyWeaponBindingsRevision,string GroundVehicleWeaponsRevision,string EnemyPosesRevision,string ArmySpawnPointsRevision,string ArmyRusherPointsRevision,string ArmyMinigunnerPointsRevision,string PlayerShotTargetsRevision,
        string ArmyNavMeshSourcesRevision,string ArmyNavMeshTriangulationRevision,string ArmyNavMeshPathsRevision);
    private sealed record Stage(string SourceId,int UpgradeIndex,int ClipSize,int ReserveAmmo,double CadenceSeconds,double ReloadSeconds);
    private readonly IReadOnlyDictionary<string,Stage[]> stages;
    public string PackageRevision { get; }

    private BattleRifleManifestCatalog(Dictionary<string,Stage[]> stages,string packageRevision)
    {this.stages=stages;PackageRevision=packageRevision;}

    public static BattleRifleManifestCatalog Load(string manifestPath)
    {
        byte[] manifestBytes=ReadBounded(manifestPath,2,4096,"combat content manifest");
        ContentManifest manifest;
        try {manifest=JsonSerializer.Deserialize<ContentManifest>(manifestBytes,new JsonSerializerOptions
            {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow})
            ??throw new InvalidDataException("Missing combat content manifest.");}
        catch(JsonException e){throw new InvalidDataException("Malformed combat content manifest.",e);}
        string[] hashes=[manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,manifest.AllWeaponBindingsRevision,manifest.PosesRevision,
            manifest.BarrelBindingsRevision,manifest.BarrelOverlapRevision,manifest.ArmyDeploymentRevision,
            manifest.ArmyWeaponBindingsRevision,
            manifest.GroundVehicleWeaponsRevision,
            manifest.EnemyPosesRevision,
            manifest.ArmySpawnPointsRevision,manifest.ArmyRusherPointsRevision,manifest.ArmyMinigunnerPointsRevision,manifest.PlayerShotTargetsRevision,
            manifest.ArmyNavMeshSourcesRevision,manifest.ArmyNavMeshTriangulationRevision,manifest.ArmyNavMeshPathsRevision];
        if(manifest.Version!=3 || hashes.Any(x=>x==null || !Regex.IsMatch(x,@"\A[0-9a-f]{64}\z")))
            throw new InvalidDataException("Invalid combat content revisions.");
        string contentPath=Path.Combine(Path.GetDirectoryName(Path.GetFullPath(manifestPath))!,"recovered-battle-content.json");
        byte[] content=ReadBounded(contentPath,2,16_000_000,"rifle content");
        if(Convert.ToHexStringLower(SHA256.HashData(content))!=manifest.StatsRevision)
            throw new InvalidDataException("Rifle content revision mismatch.");
        try
        {
            using var document=JsonDocument.Parse(content);
            var root=document.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0" || root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)
                throw new InvalidDataException("Rifle scene provenance mismatch.");
            var sheets=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var sheet in root.GetProperty("sheets").EnumerateArray())
                if(!sheets.TryAdd(sheet.GetProperty("type").GetString()!,sheet.GetProperty("rows")))
                    throw new InvalidDataException("Duplicate source sheet.");
            var definitions=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var row in sheets["Google2u.WeaponUpgrades"].EnumerateArray())
                if(!definitions.TryAdd(row.GetProperty("NAME").GetString()!,row))
                    throw new InvalidDataException("Duplicate weapon definition.");
            if(definitions.Count!=66)throw new InvalidDataException("Incomplete weapon definitions.");
            var result=new Dictionary<string,Stage[]>(StringComparer.Ordinal);
            foreach(var (name,count) in Expected)
            {
                string id="Google2u."+name;
                JsonElement definition=definitions[id],rows=sheets[id];
                if(rows.GetArrayLength()!=count)throw new InvalidDataException("Incomplete rifle upgrade lane.");
                var lane=new Stage[count];
                for(int i=0;i<count;i++)
                {
                    JsonElement row=rows[i];
                    lane[i]=new(id,i,Integer(row,"CLIPSIZE",1,1000),Integer(row,"AMMO",0,100000),
                        Number(definition,"RATEOFFIRE",0.01f,60),Number(row,"RELOADTIME",0.01f,120));
                }
                result.Add(id,lane);
            }
            string packageRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
                "WarFriends/combat-content/v3\n"+string.Join("\n",hashes))));
            return new(result,packageRevision);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed rifle source catalog.",e);}
    }

    public void Bind(JsonObject participant,BattlePlayerPresentation view)
    {
        view=BattlePlayerPresentation.Validate(view);
        BattleWeaponPresentation equipped=view.Weapons.OrderBy(x=>x.Slot).First();
        Stage row=Resolve(equipped);
        participant["Weapon"]=Weapon(row);
        participant["WeaponUpgrade"]=row.UpgradeIndex;
        var slots=new JsonArray();
        foreach(var weapon in view.Weapons.OrderBy(x=>x.Slot))
        {
            if(!stages.ContainsKey(weapon.SourceId))continue;
            Stage stage=Resolve(weapon);
            slots.Add(new JsonObject { ["Slot"]=weapon.Slot,["WeaponIndex"]=weapon.WeaponIndex,
                ["Weapon"]=Weapon(stage),["WeaponUpgrade"]=stage.UpgradeIndex });
        }
        participant["WeaponSlots"]=slots;
    }

    private Stage Resolve(BattleWeaponPresentation weapon)
    {
        if(!stages.TryGetValue(weapon.SourceId,out Stage[]? lane) || weapon.UpgradeIndex<0 || weapon.UpgradeIndex>=lane.Length)
            throw new InvalidDataException("Durable equipped weapon is not in the recovered rifle combat catalog.");
        return lane[weapon.UpgradeIndex];
    }
    private static JsonObject Weapon(Stage row)=>new()
    {
        ["SourceId"]=row.SourceId,["ClipSize"]=row.ClipSize,["ReserveAmmo"]=row.ReserveAmmo,
        ["CadenceSeconds"]=row.CadenceSeconds,["ReloadSeconds"]=row.ReloadSeconds
    };

    public void ValidateTemplate(JsonObject template)
    {
        if(template["Mode"]?.GetValue<string>()!="unscored-rifle-combat" ||
           template["CatalogRevision"]?.GetValue<string>()!=PackageRevision)
            throw new InvalidDataException("Battle template does not bind the recovered rifle combat package.");
    }

    private static byte[] ReadBounded(string path,int min,int max,string name)
    {
        using var input=File.OpenRead(path);
        if(input.Length<min || input.Length>max)throw new InvalidDataException("Invalid "+name+" size.");
        var bytes=new byte[checked((int)input.Length)];input.ReadExactly(bytes);return bytes;
    }
    private static int Integer(JsonElement row,string key,int min,int max)
    {
        if(!row.GetProperty(key).TryGetInt32(out int value) || value<min || value>max)
            throw new InvalidDataException("Invalid rifle "+key+".");
        return value;
    }
    private static double Number(JsonElement row,string key,float min,float max)
    {
        float value=row.GetProperty(key).GetSingle();
        if(!float.IsFinite(value) || value<min || value>max)throw new InvalidDataException("Invalid rifle "+key+".");
        return value;
    }
}
