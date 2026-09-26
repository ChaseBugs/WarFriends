using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record VehiclePassengerPoseFrame(float Seconds,IReadOnlyList<PlayerHitbox> Parts);
internal sealed record VehiclePassengerPoseClip(string Name,float Length,bool Loop,
    IReadOnlyList<VehiclePassengerPoseFrame> Frames);

/// <summary>Unity-sampled enemy.prefab hit geometry for vehicle-attached soldiers.</summary>
internal sealed class VehiclePassengerPoseCatalog
{
    private sealed class Root {public int Version{get;set;}public string Client{get;set;}="";
        public string Source{get;set;}="";public string Sha256{get;set;}="";public int SampleRate{get;set;}
        public ClipDto[] Clips{get;set;}=[];}
    private sealed class ClipDto {public string Name{get;set;}="";public string SourceName{get;set;}="";
        public string Source{get;set;}="";public string Guid{get;set;}="";public long FileId{get;set;}
        public string Sha256{get;set;}="";public float Length{get;set;}public string Wrap{get;set;}="";
        public FrameDto[] Frames{get;set;}=[];}
    private sealed class FrameDto {public float Seconds{get;set;}public PartDto[] Parts{get;set;}=[];}
    private sealed class PartDto {public string Role{get;set;}="";public string Path{get;set;}="";
        public string Type{get;set;}="";public float Weight{get;set;}public bool Trigger{get;set;}
        public float[] Center{get;set;}=[];public float[] Rotation{get;set;}=[];public float[] Size{get;set;}=[];
        public float Radius{get;set;}}
    private readonly IReadOnlyDictionary<string,VehiclePassengerPoseClip> clips;
    internal string Revision {get;}
    private VehiclePassengerPoseCatalog(string revision,Dictionary<string,VehiclePassengerPoseClip> clips)
    {Revision=revision;this.clips=clips;}

    internal IReadOnlyList<PlayerHitbox> Place(string unitId,GroundVehiclePassengerBinding binding,
        Vector3 vehiclePosition,Vector3 planarForward,ulong animationTick)
    {
        if(binding==null||animationTick>10_000_000||!PlayerHitbox.Finite(vehiclePosition)||
           !PlayerHitbox.Finite(planarForward))throw new InvalidDataException("Invalid passenger pose placement.");
        planarForward.Y=0;
        if(planarForward.LengthSquared()<1e-10f)throw new InvalidDataException("Passenger pose has no vehicle facing.");
        float yaw=MathF.Atan2(planarForward.X,planarForward.Z);
        var vehicleRotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw);
        var rootRotation=Quaternion.Normalize(vehicleRotation*binding.Rotation);
        var rootPosition=vehiclePosition+Vector3.Transform(binding.Position,vehicleRotation);
        var clip=clips[unitId=="ID_UNIT-BUGGY"?"buggy_idle":"idle"];
        int period=clip.Frames.Count-1;
        int index=clip.Loop?(int)(animationTick%(ulong)period):Math.Min((int)animationTick,period);
        return clip.Frames[index].Parts.Select(p=>new PlayerHitbox(
            $"{binding.Role}/{p.SourcePath}",p.Kind,p.Weight,
            rootPosition+Vector3.Transform(p.Center,rootRotation),p.Size,
            Quaternion.Normalize(rootRotation*p.Rotation),p.Radius,Vector3.Zero,0,true,true)).ToArray();
    }

    internal static VehiclePassengerPoseCatalog Load(string path,string expectedRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <10_000 or >500_000||!Regex.IsMatch(expectedRevision,@"\A[0-9a-f]{64}\z")||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Vehicle passenger pose revision mismatch.");
        Root root;
        try{root=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions
            {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??
            throw new InvalidDataException("Missing vehicle passenger pose artifact.");}
        catch(JsonException e){throw new InvalidDataException("Malformed vehicle passenger pose artifact.",e);}
        if(root.Version!=1||root.Client!="1.4.0"||root.Source!="Assets/GameObject/enemy.prefab"||
           !Regex.IsMatch(root.Sha256,@"\A[0-9a-f]{64}\z")||root.SampleRate!=30||root.Clips.Length!=2)
            throw new InvalidDataException("Wrong vehicle passenger pose provenance.");
        var expected=new[]{("idle","idle_1","Loop",31),("buggy_idle","buggy_idle","ClampForever",8)};
        var result=new Dictionary<string,VehiclePassengerPoseClip>(StringComparer.Ordinal);
        for(int c=0;c<expected.Length;c++)
        {
            var source=root.Clips[c];var e=expected[c];
            if(source.Name!=e.Item1||source.SourceName!=e.Item2||source.Wrap!=e.Item3||
               source.Source!=$"Assets/AnimationClip/{e.Item2}.anim"||source.FileId!=7400000||
               !Regex.IsMatch(source.Guid,@"\A[0-9a-f]{32}\z")||
               !Regex.IsMatch(source.Sha256,@"\A[0-9a-f]{64}\z")||!float.IsFinite(source.Length)||
               source.Length<=0||source.Length>2||source.Frames.Length!=e.Item4)
                throw new InvalidDataException("Invalid vehicle passenger clip identity.");
            var frames=new VehiclePassengerPoseFrame[source.Frames.Length];
            for(int f=0;f<frames.Length;f++)
            {
                var frame=source.Frames[f];float expectedSeconds=Math.Min(f/30f,source.Length);
                if(!float.IsFinite(frame.Seconds)||Math.Abs(frame.Seconds-expectedSeconds)>.00001f||
                   frame.Parts.Length!=3)throw new InvalidDataException("Invalid vehicle passenger pose timeline.");
                var parts=new PlayerHitbox[3];
                string[] roles=["body-box","body-sphere","head"];
                PlayerHitboxKind[] kinds=[PlayerHitboxKind.Box,PlayerHitboxKind.Sphere,PlayerHitboxKind.Sphere];
                float[] weights=[1,1,1.5f];
                for(int p=0;p<3;p++)
                {
                    var part=frame.Parts[p];
                    if(part.Role!=roles[p]||part.Type!=(kinds[p]==PlayerHitboxKind.Box?"BoxCollider":"SphereCollider")||
                       part.Weight!=weights[p]||!part.Trigger||part.Path.Length is <1 or >1024||part.Path.Any(char.IsControl))
                        throw new InvalidDataException("Invalid vehicle passenger hit part.");
                    parts[p]=new(part.Path,kinds[p],part.Weight,Vector(part.Center),Vector(part.Size),
                        Rotation(part.Rotation),part.Radius,Vector3.Zero,0,true,true);
                }
                frames[f]=new(frame.Seconds,Array.AsReadOnly(parts));
            }
            result.Add(source.Name,new(source.Name,source.Length,source.Wrap=="Loop",Array.AsReadOnly(frames)));
        }
        return new(expectedRevision,result);
    }
    private static Vector3 Vector(float[] value)
    {
        if(value.Length!=3)throw new InvalidDataException("Invalid passenger pose vector.");
        var v=new Vector3(value[0],value[1],value[2]);
        if(!PlayerHitbox.Finite(v)||Math.Abs(v.X)>5||Math.Abs(v.Y)>5||Math.Abs(v.Z)>5)
            throw new InvalidDataException("Passenger pose vector outside source bounds.");
        return v;
    }
    private static Quaternion Rotation(float[] value)
    {
        if(value.Length!=4)throw new InvalidDataException("Invalid passenger pose rotation.");
        var q=new Quaternion(value[0],value[1],value[2],value[3]);
        if(!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0002f)
            throw new InvalidDataException("Invalid passenger pose rotation.");
        return Quaternion.Normalize(q);
    }
}
