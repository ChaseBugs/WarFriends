using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

// Rest hierarchy bindings. Callers must supply the runtime root pose; animated
// child transforms require their own observation before these can be live aim.
internal sealed class AirShotTargetCatalog
{
    private readonly IReadOnlyDictionary<string,DroneShotTarget[]> targets;
    private AirShotTargetCatalog(Dictionary<string,DroneShotTarget[]> targets){this.targets=targets;}
    internal static AirShotTargetCatalog Load(string path)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length>500000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=DroneColliderCatalog.VerifiedInventoryRevision)
            throw new InvalidDataException("Air aim inventory differs from verified source.");
        using var doc=JsonDocument.Parse(bytes);
        var result=new Dictionary<string,DroneShotTarget[]>(StringComparer.Ordinal);
        foreach(var unit in doc.RootElement.GetProperty("units").EnumerateArray())
        {
            string id=unit.GetProperty("unitId").GetString()!;
            var shootables=unit.GetProperty("shootables");
            if(shootables.GetArrayLength()!=1)throw new InvalidDataException("Air shootable identity is ambiguous.");
            var rows=shootables[0].GetProperty("targets");var accepted=new DroneShotTarget[rows.GetArrayLength()];
            for(int i=0;i<accepted.Length;i++)
            {
                var row=rows[i];var p=row.GetProperty("restPosition");
                accepted[i]=new(row.GetProperty("transformFileId").GetInt32(),row.GetProperty("type").GetInt32(),
                    new(p[0].GetSingle(),p[1].GetSingle(),p[2].GetSingle()));
            }
            result.Add(id,accepted);
        }
        return new(result);
    }
    internal IReadOnlyList<DroneShotTarget> PlaceRest(string unitId,Vector3 position,Quaternion rotation)
    {
        if(!targets.TryGetValue(unitId,out var source)||!PlayerHitbox.Finite(position)||
           !float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.0002f)
            throw new InvalidDataException("Invalid air aim rest placement.");
        return Array.AsReadOnly(source.Select(t=>t with
            {Position=position+Vector3.Transform(t.Position,Quaternion.Normalize(rotation))}).ToArray());
    }
}
