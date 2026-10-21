using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>The source level table and Barrel.Awake health formula, without Photon ownership guesses.</summary>
internal sealed class BarrelSourcePolicy
{
    internal int MaxDisplayLevel { get; }
    private BarrelSourcePolicy(int count)=>MaxDisplayLevel=count;
    internal static BarrelSourcePolicy Load(string path,string expectedRevision,string sceneRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <2 or >16_000_000 || Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Barrel level source revision mismatch.");
        using var doc=JsonDocument.Parse(bytes);
        var root=doc.RootElement;
        if(root.GetProperty("client").GetString()!="1.4.0" ||
           root.GetProperty("mainSceneSha256").GetString()!=sceneRevision)
            throw new InvalidDataException("Barrel levels have different source provenance.");
        var levels=root.GetProperty("sheets").EnumerateArray()
            .Where(s=>s.GetProperty("type").GetString()=="Google2u.Levels").ToArray();
        if(levels.Length!=1 || levels[0].GetProperty("path").GetString()!=
           "MainSceneRootNew/Managers/Levels Manager" || levels[0].GetProperty("rows").GetArrayLength()!=43)
            throw new InvalidDataException("Incomplete recovered LevelManager display levels.");
        return new(43);
    }
    internal float MaxHealth(int zeroBasedLevel)
    {
        if(zeroBasedLevel<0 || zeroBasedLevel>=MaxDisplayLevel)
            throw new InvalidDataException("Invalid scene-owner level for barrel health.");
        // Barrel.Awake: float num=(float)level/(float)maxDisplayLevel;
        return 50f+((float)zeroBasedLevel/MaxDisplayLevel)*6f;
    }
}
