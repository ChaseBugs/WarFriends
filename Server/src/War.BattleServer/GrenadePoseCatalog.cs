using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record GrenadePoseFrame(float Seconds,PlayerCollisionModel Collision,RifleMuzzlePose Left,
    IReadOnlyDictionary<string,RifleMuzzlePose> Right);

internal sealed class GrenadePoseCatalog
{
    private sealed record Clip(float Length,GrenadePoseFrame[] Frames);
    private static readonly string[] Expected=["throw_grenade_left","throw_grenade_right","grenade_run","grenade_idle",
        "player_look_left_grenadelauncher","player_fire_left_grenadelauncher","player_left_coverBack_grenadelauncher",
        "player_look_right_grenadelauncher","player_fire_right_grenadelauncher","player_right_coverBack_grenadelauncher",
        "run_grenadelauncher","grenadelauncher_idle"];
    private readonly Dictionary<string,Clip> clips;
    internal string Revision{get;}internal int FrameCount=>clips.Values.Sum(x=>x.Frames.Length);
    internal IReadOnlyList<string> ClipNames=>Array.AsReadOnly(Expected);
    private GrenadePoseCatalog(string revision,Dictionary<string,Clip> clips){Revision=revision;this.clips=clips;}
    internal float Duration(string name)=>Get(name).Length;
    internal GrenadePoseFrame Sample(string name,double seconds,bool loop)
    {var c=Get(name);if(!double.IsFinite(seconds)||seconds<0||seconds>86400)throw new ArgumentOutOfRangeException(nameof(seconds));if(loop)seconds%=c.Length;int i=seconds>=c.Length?c.Frames.Length-1:Math.Min(c.Frames.Length-1,(int)Math.Floor(seconds*30));return c.Frames[i];}
    private Clip Get(string name)=>clips.TryGetValue(name,out var c)?c:throw new ArgumentException("Unsupported grenade pose clip.",nameof(name));

    internal static GrenadePoseCatalog Load(string path,string expectedRevision,string sceneRevision,IReadOnlyCollection<GrenadeBinding> bindings)
    {
        using var stream=File.OpenRead(path);if(stream.Length is <2 or >8*1024*1024)throw new InvalidDataException("Invalid grenade pose size.");
        string revision=Convert.ToHexStringLower(System.Security.Cryptography.SHA256.HashData(stream));if(revision!=expectedRevision)throw new InvalidDataException("Grenade pose hash mismatch.");
        stream.Position=0;using var doc=JsonDocument.Parse(stream,new JsonDocumentOptions{MaxDepth=20});var root=doc.RootElement;
        string playerPath=root.GetProperty("playerPath").GetString()??"",leftPath=root.GetProperty("leftSpawnPath").GetString()??"";
        if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity"||
           root.GetProperty("sha256").GetString()!=sceneRevision||root.GetProperty("sampleRate").GetInt32()!=30||playerPath!="MainSceneRootNew/Player"||
           leftPath.Length>1200||bindings.Where(x=>x.SwipeInput!=null).Any(x=>x.SwipeInput!.LeftMuzzlePath!=leftPath))throw new InvalidDataException("Invalid grenade pose provenance.");
        var rootPosition=V(root.GetProperty("position"));var rootRotation=Q(root.GetProperty("rotation"));var ids=bindings.Select(x=>x.SourceId).Order(StringComparer.Ordinal).ToArray();
        var rows=root.GetProperty("clips");if(rows.GetArrayLength()!=Expected.Length)throw new InvalidDataException("Incomplete grenade pose clips.");
        var result=new Dictionary<string,Clip>(StringComparer.Ordinal);int clipIndex=0;string[]? partPaths=null;float[]? weights=null;
        foreach(var row in rows.EnumerateArray())
        {
            string name=row.GetProperty("name").GetString()??"",source=row.GetProperty("source").GetString()??"";
            if(name!=Expected[clipIndex++]||!source.StartsWith("Assets/",StringComparison.Ordinal)||source.Contains("..",StringComparison.Ordinal)||
               !Regex.IsMatch(row.GetProperty("guid").GetString()??"",@"\A[0-9a-f]{32}\z")||row.GetProperty("fileId").GetInt64()<=0||
               !Regex.IsMatch(row.GetProperty("sha256").GetString()??"",@"\A[0-9a-f]{64}\z"))throw new InvalidDataException("Invalid grenade clip identity.");
            float length=row.GetProperty("length").GetSingle();int count=(int)MathF.Ceiling(length*30)+1;var frameRows=row.GetProperty("frames");
            if(!float.IsFinite(length)||length<=0||length>60||frameRows.GetArrayLength()!=count)throw new InvalidDataException("Truncated grenade pose clip.");
            var frames=new GrenadePoseFrame[count];int frameIndex=0;
            foreach(var frame in frameRows.EnumerateArray())
            {
                float seconds=frame.GetProperty("seconds").GetSingle();if(!float.IsFinite(seconds)||Math.Abs(seconds-Math.Min(frameIndex/30f,length))>.000001f)throw new InvalidDataException("Invalid grenade pose ordering.");
                var parts=frame.GetProperty("parts").EnumerateArray().Select(p=>new PlayerHitbox(p.GetProperty("path").GetString()??"",
                    p.GetProperty("type").GetString() switch{"BoxCollider"=>PlayerHitboxKind.Box,"SphereCollider"=>PlayerHitboxKind.Sphere,_=>throw new InvalidDataException("Unsupported grenade pose primitive.")},
                    p.GetProperty("weight").GetSingle(),V(p.GetProperty("center")),V(p.GetProperty("size")),Q(p.GetProperty("rotation")),p.GetProperty("radius").GetSingle(),Vector3.Zero,0,p.GetProperty("enabled").GetBoolean(),p.GetProperty("active").GetBoolean())).ToArray();
                if(parts.Length!=2)throw new InvalidDataException("Incomplete grenade hit pose.");partPaths??=parts.Select(x=>x.SourcePath).ToArray();weights??=parts.Select(x=>x.Weight).ToArray();
                if(!partPaths.SequenceEqual(parts.Select(x=>x.SourcePath))||!weights.SequenceEqual(parts.Select(x=>x.Weight)))throw new InvalidDataException("Grenade hit identities changed.");
                var left=Pose(frame.GetProperty("left"),rootPosition,rootRotation);if(left.SourcePath!=leftPath)throw new InvalidDataException("Grenade left spawn changed.");
                var rightRows=frame.GetProperty("right").EnumerateArray().ToArray();if(rightRows.Length!=8)throw new InvalidDataException("Incomplete grenade right spawns.");
                var right=new Dictionary<string,RifleMuzzlePose>(StringComparer.Ordinal);
                foreach(var value in rightRows){string id=value.GetProperty("id").GetString()??"";var pose=Pose(value,rootPosition,rootRotation);if(!right.TryAdd(id,pose))throw new InvalidDataException("Duplicate grenade spawn.");}
                if(!right.Keys.Order(StringComparer.Ordinal).SequenceEqual(ids)||bindings.Any(x=>right[x.SourceId].SourcePath!=x.MuzzlePath))throw new InvalidDataException("Grenade spawn identity mismatch.");
                frames[frameIndex++]=new(seconds,PlayerCollisionModel.InitializedFrame(sceneRevision,playerPath,rootPosition,rootRotation,parts),left,right);
            }
            result.Add(name,new(length,frames));
        }
        var catalog=new GrenadePoseCatalog(revision,result);if(catalog.FrameCount!=289)throw new InvalidDataException("Unexpected grenade pose frame count.");return catalog;
    }
    private static RifleMuzzlePose Pose(JsonElement e,Vector3 root,Quaternion rotation)=>new(e.GetProperty("path").GetString()??"",V(e.GetProperty("position")),Q(e.GetProperty("rotation")),root,rotation);
    private static Vector3 V(JsonElement e){if(e.GetArrayLength()!=3)throw new InvalidDataException("Invalid grenade vector.");var v=new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid grenade vector.");return v;}
    private static Quaternion Q(JsonElement e){if(e.GetArrayLength()!=4)throw new InvalidDataException("Invalid grenade rotation.");var q=new Quaternion(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());if(!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0001f)throw new InvalidDataException("Invalid grenade rotation.");return Quaternion.Normalize(q);}
}
