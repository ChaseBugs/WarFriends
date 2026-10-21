using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

// Source policy only. A live shield still needs an allocator-proven player rank,
// owner/current cover, damage receipts and source state transitions.
internal sealed class ShieldSourceCatalog
{
    private readonly float[] rankHealth;
    private readonly Dictionary<string,float> weaponRatios;
    internal int RankCount=>rankHealth.Length;
    internal int WeaponCount=>weaponRatios.Count;
    internal float RepairSeconds {get;}
    internal float RespawnRatePerSecond {get;}
    internal bool RepairEnabled {get;}
    internal bool DestroyInOvertime {get;}
    internal float ExplosionCoefficient {get;}
    internal float FriendDamageCoefficient {get;}
    internal float UnitToShieldCoefficient {get;}
    private ShieldSourceCatalog(float[] ranks,Dictionary<string,float> ratios,float repair,float respawn,bool enabled,bool destroyInOvertime,float explosion,float friend,float unit)
    {rankHealth=ranks;weaponRatios=ratios;RepairSeconds=repair;RespawnRatePerSecond=respawn;RepairEnabled=enabled;DestroyInOvertime=destroyInOvertime;ExplosionCoefficient=explosion;FriendDamageCoefficient=friend;UnitToShieldCoefficient=unit;}
    internal float Health(int zeroBasedLevel)=>zeroBasedLevel>=0&&zeroBasedLevel<rankHealth.Length ? rankHealth[zeroBasedLevel] :
        throw new InvalidDataException("Unknown shield level.");
    internal float DamageToShield(string weaponId)=>weaponRatios.TryGetValue(weaponId,out float ratio) ? ratio :
        throw new InvalidDataException("Unknown shield damage weapon.");
    internal static ShieldSourceCatalog Load(string path,string expectedRevision)
    {
        byte[] data=File.ReadAllBytes(path);
        if(data.Length is <2 or >32_000_000 || Convert.ToHexStringLower(SHA256.HashData(data))!=expectedRevision)
            throw new InvalidDataException("Shield source revision mismatch.");
        try
        {
            using var document=JsonDocument.Parse(data);
            var root=document.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0")throw new InvalidDataException("Wrong shield source version.");
            var sheets=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var sheet in root.GetProperty("sheets").EnumerateArray())
                if(!sheets.TryAdd(sheet.GetProperty("type").GetString()!,sheet.GetProperty("rows")))
                    throw new InvalidDataException("Duplicate shield source sheet.");
            var ranks=sheets["Google2u.BalanceTable"];
            if(ranks.GetArrayLength()!=44)throw new InvalidDataException("Incomplete shield rank table.");
            var health=new float[44];float previous=0;
            for(int i=0;i<health.Length;i++)
            {
                health[i]=Number(ranks[i],"SHIELDHP",1,10000000);
                if(health[i]<previous)throw new InvalidDataException("Shield rank health regressed.");
                previous=health[i];
            }
            var weapons=sheets["Google2u.WeaponUpgrades"];
            if(weapons.GetArrayLength()!=66)throw new InvalidDataException("Incomplete shield weapon ratios.");
            var ratios=new Dictionary<string,float>(StringComparer.Ordinal);
            foreach(var row in weapons.EnumerateArray())
            {
                string id=row.GetProperty("NAME").GetString()??"";
                if(!Regex.IsMatch(id,@"\AGoogle2u\.[A-Za-z0-9_]{1,55}\z") ||
                    !ratios.TryAdd(id,Number(row,"DAMAGETOSHIELD",0,100)))
                    throw new InvalidDataException("Invalid shield weapon identity.");
            }
            var constants=new Dictionary<string,float>(StringComparer.Ordinal);
            foreach(var row in sheets["Google2u.Constants"].EnumerateArray())
            {
                string key=row.GetProperty("DBKEY").GetString()??"";
                if(!constants.TryAdd(key,Number(row,"FLOATVALUE",-10000000,10000000)))
                    throw new InvalidDataException("Duplicate shield constant.");
            }
            float repair=constants["ShieldRepairTime"],respawn=constants["ShieldRespawnRatePerSec"],enabled=constants["RepairShields"],destroyInOvertime=constants["DestroyShieldsInOverTime"];
            float explosion=constants["ShieldExplosionCoef"],friend=constants["FriendDamageCoeficient"],
                unit=constants["UnitToShieldCoef"];
            if(repair is <=0 or >3600 || respawn is <0 or >100 || enabled is not (0 or 1) || destroyInOvertime is not (0 or 1) ||
               explosion is <0 or >100 || friend is <0 or >1 || unit is <0 or >100 || unit!=3f)
                throw new InvalidDataException("Invalid shield repair policy.");
            return new(health,ratios,repair,respawn,enabled==1,destroyInOvertime==1,explosion,friend,unit);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed shield source policy.",e);}
    }
    private static float Number(JsonElement row,string key,float min,float max)
    {float n=row.GetProperty(key).GetSingle();if(!float.IsFinite(n)||n<min||n>max)
        throw new InvalidDataException("Invalid shield source number: "+key);return n;}
}
