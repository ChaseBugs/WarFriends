using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

// Unity-sampled aim transforms, distinct from collider centers.
internal sealed class EnemyShotTargetCatalog
{
    internal const string VerifiedRevision="05412a6b997771f365c656e512093347eb717ffcf582c4e347985f513d361e54";
    private readonly EnemyPoseCatalog poses;
    private readonly IReadOnlyDictionary<string,DroneShotTarget[][]> clips;
    private EnemyShotTargetCatalog(EnemyPoseCatalog poses,Dictionary<string,DroneShotTarget[][]> clips)
    {this.poses=poses;this.clips=clips;}
    internal static EnemyShotTargetCatalog Load(string path,EnemyPoseCatalog poses)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <1000000 or >8000000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=VerifiedRevision)
            throw new InvalidDataException("Enemy aim sample revision mismatch.");
        using var doc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=12});
        var root=doc.RootElement;
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("client").GetString()!="1.4.0"||
           root.GetProperty("source").GetString()!="Assets/GameObject/enemy.prefab"||
           root.GetProperty("sha256").GetString()!=poses.SourceSha256||root.GetProperty("sampleRate").GetInt32()!=30)
            throw new InvalidDataException("Enemy aim source does not match collision poses.");
        var rows=root.GetProperty("clips");
        if(rows.GetArrayLength()!=poses.Names.Count)throw new InvalidDataException("Incomplete enemy aim clips.");
        var clips=new Dictionary<string,DroneShotTarget[][]>(StringComparer.Ordinal);
        int[] ids=[454546,436299,496281],types=[8,1,4];
        for(int c=0;c<poses.Names.Count;c++)
        {
            string name=poses.Names[c];var clip=poses.Clip(name);var row=rows[c];
            if(row.GetProperty("name").GetString()!=name||row.GetProperty("length").GetSingle()!=clip.Length||
               row.GetProperty("wrap").GetString()!=clip.Wrap)
                throw new InvalidDataException("Enemy aim clip differs from collision timeline.");
            var frames=row.GetProperty("frames");
            if(frames.GetArrayLength()!=clip.Frames.Count)throw new InvalidDataException("Incomplete enemy aim frames.");
            var accepted=new DroneShotTarget[frames.GetArrayLength()][];
            for(int f=0;f<accepted.Length;f++)
            {
                if(frames[f].GetProperty("seconds").GetSingle()!=clip.Frames[f].Seconds)
                    throw new InvalidDataException("Enemy aim frame differs from collision timeline.");
                var targets=frames[f].GetProperty("targets");
                if(targets.GetArrayLength()!=3)throw new InvalidDataException("Incomplete enemy aim targets.");
                accepted[f]=new DroneShotTarget[3];
                for(int t=0;t<3;t++)
                {
                    var target=targets[t];var p=target.GetProperty("position");
                    if(target.GetProperty("type").GetInt32()!=types[t]||p.GetArrayLength()!=3)
                        throw new InvalidDataException("Enemy aim target identity differs.");
                    var position=new Vector3(p[0].GetSingle(),p[1].GetSingle(),p[2].GetSingle());
                    if(!PlayerHitbox.Finite(position))throw new InvalidDataException("Invalid enemy aim position.");
                    accepted[f][t]=new(ids[t],types[t],position);
                }
            }
            clips.Add(name,accepted);
        }
        return new(poses,clips);
    }
    internal IReadOnlyList<DroneShotTarget> Place(string name,Vector3 position,Quaternion rotation,float seconds)
    {
        if(!PlayerHitbox.Finite(position)||!float.IsFinite(rotation.LengthSquared())||
           Math.Abs(rotation.LengthSquared()-1)>.0002f||!float.IsFinite(seconds)||seconds<0)
            throw new InvalidDataException("Invalid animated enemy aim placement.");
        var clip=poses.Clip(name);
        float time=clip.Wrap=="Loop"?seconds%clip.Length:Math.Min(seconds,clip.Length);
        int index=Math.Min((int)MathF.Floor(time*30),clip.Frames.Count-1);
        return Array.AsReadOnly(clips[name][index].Select(t=>t with
            {Position=position+Vector3.Transform(t.Position,Quaternion.Normalize(rotation))}).ToArray());
    }
}
