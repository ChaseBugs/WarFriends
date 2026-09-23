using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PlayerShotTarget(int TransformFileId,int Type,string Path,Vector3 ReferencePosition);

/// <summary>Serialized gameplay target identities; reference positions are not animated hit authority.</summary>
public sealed class PlayerShotTargetCatalog
{
    private readonly IReadOnlyList<PlayerShotTarget> gameplay;
    public IReadOnlyList<PlayerShotTarget> Gameplay => gameplay;
    private PlayerShotTargetCatalog(PlayerShotTarget[] rows)=>gameplay=Array.AsReadOnly(rows);

    public PlayerShotTarget ReferenceNearest(int typeMask,Vector3 origin)
        =>Nearest(typeMask,origin,row=>row.ReferencePosition);

    // Caller supplies positions from the host's current animated player pose.
    // The serialized target order breaks equal-distance ties as in the Client.
    public PlayerShotTarget Nearest(int typeMask,Vector3 origin,Func<PlayerShotTarget,Vector3> position)
    {
        if(typeMask is <1 or >0xFFFFFF || !Finite(origin))throw new ArgumentOutOfRangeException(nameof(typeMask));
        ArgumentNullException.ThrowIfNull(position);
        PlayerShotTarget? nearest=null;
        float distance=float.MaxValue;
        foreach(var row in gameplay)
        {
            // GameShootableEntity.GetShotTargets includes a target when all of its
            // own bits occur in the requested mask, preserving serialized order.
            if((row.Type&typeMask)!=row.Type)continue;
            var targetPosition=position(row);
            if(!Finite(targetPosition))throw new InvalidDataException("Invalid posed player shot target.");
            float candidate=Vector3.Distance(origin,targetPosition);
            if(candidate<distance){nearest=row;distance=candidate;}
        }
        return nearest??throw new InvalidDataException("No source target for requested type.");
    }

    public static PlayerShotTargetCatalog Load(string path,string expectedRevision,string sceneRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <200 or >16000 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Player shot-target revision mismatch.");
        using var doc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=8});
        var root=doc.RootElement;
        Exact(root,"version","source","sceneSha256","players");
        if(root.GetProperty("version").GetInt32()!=1 ||
           root.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity" ||
           root.GetProperty("sceneSha256").GetString()!=sceneRevision)
            throw new InvalidDataException("Player shot targets do not bind the active scene.");
        var players=root.GetProperty("players");
        if(players.GetArrayLength()!=2)throw new InvalidDataException("Incomplete player shot targets.");
        var ids=new HashSet<int>();
        PlayerShotTarget[]? gameplay=null;
        for(int i=0;i<2;i++)
        {
            var player=players[i];Exact(player,"role","componentFileId","targets");
            string role=i==0?"gameplay":"rendering";
            if(player.GetProperty("role").GetString()!=role ||
               !ids.Add(player.GetProperty("componentFileId").GetInt32()))
                throw new InvalidDataException("Wrong player target owner.");
            var targets=player.GetProperty("targets");
            if(targets.GetArrayLength()!=5)throw new InvalidDataException("Incomplete player target list.");
            var rows=new PlayerShotTarget[5];
            int[] expectedTypes=[1,1,2,16,8];
            for(int j=0;j<5;j++)
            {
                var target=targets[j];Exact(target,"transformFileId","type","path","referencePosition");
                int id=target.GetProperty("transformFileId").GetInt32();
                int type=target.GetProperty("type").GetInt32();
                string pathName=target.GetProperty("path").GetString()??"";
                var position=target.GetProperty("referencePosition");
                if(position.GetArrayLength()!=3 || id<=0 || !ids.Add(id) || type!=expectedTypes[j] ||
                   pathName.Length is <20 or >500 ||
                   !pathName.StartsWith(role=="gameplay"?"MainSceneRootNew/Player/":
                       "MainSceneRootNew/ArmyUnitRig/player texture camera/Player For Rendering/",StringComparison.Ordinal) ||
                   pathName.Any(char.IsControl))
                    throw new InvalidDataException("Invalid serialized player shot target.");
                var point=new Vector3(position[0].GetSingle(),position[1].GetSingle(),position[2].GetSingle());
                if(!Finite(point) || Math.Max(Math.Abs(point.X),Math.Max(Math.Abs(point.Y),Math.Abs(point.Z)))>10000)
                    throw new InvalidDataException("Invalid target reference position.");
                rows[j]=new(id,type,pathName,point);
            }
            if(i==0)gameplay=rows;
        }
        return new(gameplay!);
    }

    private static bool Finite(Vector3 p)=>float.IsFinite(p.X)&&float.IsFinite(p.Y)&&float.IsFinite(p.Z);
    private static void Exact(JsonElement row,params string[] names)
    {
        if(row.ValueKind!=JsonValueKind.Object || row.EnumerateObject().Count()!=names.Length ||
           names.Any(name=>!row.TryGetProperty(name,out _)))
            throw new InvalidDataException("Unexpected player target artifact fields.");
    }
}
