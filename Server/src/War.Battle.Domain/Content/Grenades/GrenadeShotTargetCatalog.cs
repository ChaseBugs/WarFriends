using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

// Five serialized GameShootableEntityPlayer target transforms sampled in the
// same disposable Unity session as the grenade collision/muzzle pose family.
internal sealed class GrenadeShotTargetCatalog
{
    internal string Revision { get; }
    private sealed class Root
    {
        public int Version{get;set;}public string Client{get;set;}="";
        public string Source{get;set;}="";public string Sha256{get;set;}="";
        public int SampleRate{get;set;}public string PlayerPath{get;set;}="";
        public float[] Position{get;set;}=[];public float[] Rotation{get;set;}=[];
        public Target[] Targets{get;set;}=[];public Clip[] Clips{get;set;}=[];
    }
    private sealed class Target
    {public int Index{get;set;}public int Type{get;set;}public string Path{get;set;}="";}
    private sealed class Clip
    {
        public string Name{get;set;}="";public string Source{get;set;}="";
        public string Guid{get;set;}="";public long FileId{get;set;}
        public string Sha256{get;set;}="";public float Length{get;set;}
        public Frame[] Frames{get;set;}=[];
    }
    private sealed class Frame
    {public float Seconds{get;set;}public float[][] Positions{get;set;}=[];}
    private sealed record PosedClip(float Length,IReadOnlyList<IReadOnlyList<Vector3>> Frames);
    private readonly IReadOnlyDictionary<string,PosedClip> clips;
    private readonly Vector3 sourceRoot;
    private readonly Quaternion sourceRotation;
    private GrenadeRigCatalog? _rig;

    internal PlayerAimPoseDetails PoseDetails(string clip, double seconds, bool loop, PlayerCollisionModel collision)
    {
        return (_rig ?? throw new InvalidDataException("Missing grenade rig authority."))
            .Place(clip, seconds, loop, collision);
    }
    private GrenadeShotTargetCatalog(Dictionary<string,PosedClip> clips,Vector3 root,Quaternion rotation,string revision)
    {this.clips=clips;sourceRoot=root;sourceRotation=rotation;Revision=revision;}

    internal IReadOnlyList<Vector3> Place(string clip,double seconds,bool loop,Vector3 root,
        Quaternion rotation)
    {
        if(!clips.TryGetValue(clip,out var source)||!double.IsFinite(seconds)||seconds<0||
           seconds>86400||!PlayerHitbox.Finite(root)||!float.IsFinite(rotation.LengthSquared())||
           Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid grenade shot-target pose request.");
        if(loop)seconds%=source.Length;
        int index=seconds>=source.Length?source.Frames.Count-1:
            Math.Min(source.Frames.Count-1,(int)Math.Floor(seconds*30));
        var delta=Quaternion.Normalize(rotation*Quaternion.Inverse(sourceRotation));
        return Array.AsReadOnly(source.Frames[index]
            .Select(p=>root+Vector3.Transform(p-sourceRoot,delta)).ToArray());
    }

    internal static GrenadeShotTargetCatalog Load(string path,string sceneRevision,
        PlayerShotTargetCatalog targetCatalog,GrenadePoseCatalog poses)
    {
        byte[] bytes=GrenadeShotTargetEvidence.Read(path,sceneRevision);
        Root source;
        try{source=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions
            {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??
                throw new InvalidDataException("Missing grenade shot-target export.");}
        catch(JsonException e){throw new InvalidDataException("Malformed grenade shot-target export.",e);}
        if(source.Version!=1||source.Client!="1.4.0"||source.Source!="Assets/Scenes/MainScene.unity"||
           source.Sha256!=sceneRevision||source.SampleRate!=30||
           source.PlayerPath!="MainSceneRootNew/Player"||source.Targets.Length!=5||
           source.Clips.Length!=12)
            throw new InvalidDataException("Wrong grenade shot-target provenance.");
        var root=Vector(source.Position);var rotation=Rotation(source.Rotation);
        var targetRows=targetCatalog.Gameplay;
        for(int i=0;i<5;i++)
            if(source.Targets[i].Index!=i||source.Targets[i].Type!=targetRows[i].Type||
               source.Targets[i].Path!=targetRows[i].Path)
                throw new InvalidDataException("Grenade target identity changed.");
        var clips=new Dictionary<string,PosedClip>(StringComparer.Ordinal);
        for(int i=0;i<source.Clips.Length;i++)
        {
            var clip=source.Clips[i];string name=poses.ClipNames[i];
            if(clip.Name!=name||clip.Source!=$"Assets/AnimationClip/{name}.anim"||
               clip.Guid.Length!=32||clip.FileId!=7400000||clip.Sha256.Length!=64||
               clip.Length!=poses.Duration(name)||clip.Frames.Length!=(int)MathF.Ceiling(clip.Length*30)+1)
                throw new InvalidDataException("Grenade target clip changed.");
            var frames=new IReadOnlyList<Vector3>[clip.Frames.Length];
            for(int j=0;j<frames.Length;j++)
            {
                var frame=clip.Frames[j];
                if(Math.Abs(frame.Seconds-Math.Min(j/30f,clip.Length))>.000001f||
                   frame.Positions.Length!=5)
                    throw new InvalidDataException("Grenade target timeline changed.");
                frames[j]=Array.AsReadOnly(frame.Positions.Select(Vector).ToArray());
            }
            clips.Add(name,new(clip.Length,Array.AsReadOnly(frames)));
        }
        if(clips.Values.Sum(x=>x.Frames.Count)!=289)
            throw new InvalidDataException("Incomplete grenade target frames.");
        var result = new GrenadeShotTargetCatalog(clips, root, rotation,Convert.ToHexStringLower(SHA256.HashData(bytes)));
        result._rig = GrenadeRigCatalog.Load(targetCatalog);
        return result;
    }
    private static Vector3 Vector(float[] value)
    {
        if(value.Length!=3)throw new InvalidDataException("Invalid grenade target vector.");
        var v=new Vector3(value[0],value[1],value[2]);
        if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Grenade target vector escaped source bounds.");
        return v;
    }
    private static Quaternion Rotation(float[] value)
    {
        if(value.Length!=4)throw new InvalidDataException("Invalid grenade target rotation.");
        var q=new Quaternion(value[0],value[1],value[2],value[3]);
        if(!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid grenade target root rotation.");
        return Quaternion.Normalize(q);
    }
}
