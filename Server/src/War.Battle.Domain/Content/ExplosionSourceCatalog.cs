using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Pinned MainScene constants used by weaponless barrel explosions.</summary>
internal sealed class ExplosionSourceCatalog
{
    internal float PlayerNormal {get;}
    internal float PlayerOvertime {get;}
    internal float Shield {get;}
    internal float Friendly {get;}
    private ExplosionSourceCatalog(float normal,float overtime,float shield,float friendly)
    {PlayerNormal=normal;PlayerOvertime=overtime;Shield=shield;Friendly=friendly;}
    internal static ExplosionSourceCatalog Load(string path,string revision,string sceneRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <2 or >32_000_000 || Convert.ToHexStringLower(SHA256.HashData(bytes))!=revision)
            throw new InvalidDataException("Explosion source revision mismatch.");
        using var doc=JsonDocument.Parse(bytes);
        var root=doc.RootElement;
        if(root.GetProperty("client").GetString()!="1.4.0" ||
           root.GetProperty("mainSceneSha256").GetString()!=sceneRevision)
            throw new InvalidDataException("Explosion constants have different MainScene provenance.");
        var rows=root.GetProperty("sheets").EnumerateArray()
            .Where(s=>s.GetProperty("type").GetString()=="Google2u.Constants").ToArray();
        if(rows.Length!=1 || rows[0].GetProperty("path").GetString()!="MainSceneRootNew/GameVariables" ||
           rows[0].GetProperty("rows").GetArrayLength()!=194)
            throw new InvalidDataException("Incomplete recovered explosion constants sheet.");
        var values=new Dictionary<string,float>(StringComparer.Ordinal);
        foreach(var row in rows[0].GetProperty("rows").EnumerateArray())
        {
            string key=row.GetProperty("DBKEY").GetString()??"";
            float value=row.GetProperty("FLOATVALUE").GetSingle();
            if(!float.IsFinite(value) || !values.TryAdd(key,value))
                throw new InvalidDataException("Invalid or duplicate explosion constant.");
        }
        float normal=values["PlayerExplosiveCoef"],overtime=values["PlayerExplosiveOvertimeCoef"];
        float shield=values["ShieldExplosionCoef"],friendly=values["FriendDamageCoeficient"];
        if(normal!=.88f || overtime!=.6f || shield!=2f || friendly!=.5f)
            throw new InvalidDataException("Unexpected recovered explosion balance policy.");
        return new(normal,overtime,shield,friendly);
    }
}
