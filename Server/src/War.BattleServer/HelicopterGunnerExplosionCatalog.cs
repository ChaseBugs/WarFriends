using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

// The source Explosion selects one part by Collider.ClosestPointOnBounds, but
// uses that part's transform position for outer-radius falloff.
internal sealed class HelicopterGunnerExplosionCatalog
{
    internal const string VerifiedRevision="f212c7d0764818c37672383fc4379763bd8e203f59b3e160d9d2374ffd8f07ee";
    private sealed class Root
    {
        public int Version{get;set;} public string Client{get;set;}="";
        public string Source{get;set;}=""; public string Sha256{get;set;}="";
        public Clip Clip{get;set;}=new(); public int SampleRate{get;set;}
        public Frame[] Frames{get;set;}=[];
    }
    private sealed class Clip
    {
        public string Source{get;set;}=""; public string Guid{get;set;}="";
        public long FileId{get;set;} public string Sha256{get;set;}="";
        public float Length{get;set;}
    }
    private sealed class Frame
    {
        public int Tick{get;set;} public float Seconds{get;set;}
        public Part[] Parts{get;set;}=[];
    }
    private sealed class Part
    {
        public string Role{get;set;}="";public string Path{get;set;}="";
        public float[] TransformPosition{get;set;}=[];
        public float[] BoundsMin{get;set;}=[];public float[] BoundsMax{get;set;}=[];
    }
    private readonly IReadOnlyList<IReadOnlyList<Vector3>> positions;
    private HelicopterGunnerExplosionCatalog(IReadOnlyList<IReadOnlyList<Vector3>> positions)
        =>this.positions=positions;

    internal Vector3[] PlaceTransformPositions(HelicopterTurretRestPose seat,ulong animationTick)
    {
        if(animationTick>10_000_000||!PlayerHitbox.Finite(seat.GunnerPosition))
            throw new InvalidDataException("Invalid gunner explosion placement.");
        var frame=positions[(int)(animationTick%30)];
        return frame.Select(p=>seat.GunnerPosition+Vector3.Transform(p,seat.GunnerRotation)).ToArray();
    }

    internal static HelicopterGunnerExplosionCatalog Load(string path,VehiclePassengerPoseCatalog poses)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <10_000 or >100_000||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=VerifiedRevision)
            throw new InvalidDataException("Unverified gunner explosion geometry.");
        Root root;
        try{root=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions
            {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??
                throw new InvalidDataException("Missing gunner explosion geometry.");}
        catch(JsonException e){throw new InvalidDataException("Malformed gunner explosion geometry.",e);}
        if(root.Version!=1||root.Client!="1.4.0"||root.Source!="Assets/GameObject/enemy.prefab"||
           root.Sha256!=poses.SourceSha256||root.Clip.Source!="Assets/AnimationClip/idle_1.anim"||
           root.Clip.Guid!="879d0cc21df0fe24e953d2ce4185c761"||root.Clip.FileId!=7400000||
           root.Clip.Sha256!="fc75d82afa2e12a7119e53ddad5db550273f71e513f487cd17b5bca1d8518b04"||
           root.Clip.Length!=1||root.SampleRate!=30||root.Frames.Length!=31)
            throw new InvalidDataException("Gunner explosion source identity changed.");
        string[] roles=["body-box","body-sphere","head"];
        var positions=new IReadOnlyList<Vector3>[31];
        for(int i=0;i<31;i++)
        {
            var frame=root.Frames[i];
            if(frame.Tick!=i||Math.Abs(frame.Seconds-i/30f)>.00001f||frame.Parts.Length!=3)
                throw new InvalidDataException("Gunner explosion timeline changed.");
            var row=new Vector3[3];
            for(int j=0;j<3;j++)
            {
                var part=frame.Parts[j];
                if(part.Role!=roles[j]||part.Path.Length is <1 or >1024||part.Path.Any(char.IsControl))
                    throw new InvalidDataException("Gunner explosion part changed.");
                var minimum=Vector(part.BoundsMin);var maximum=Vector(part.BoundsMax);
                if(minimum.X>maximum.X||minimum.Y>maximum.Y||minimum.Z>maximum.Z)
                    throw new InvalidDataException("Gunner explosion bounds changed.");
                row[j]=Vector(part.TransformPosition);
            }
            positions[i]=Array.AsReadOnly(row);
        }
        return new(Array.AsReadOnly(positions));
    }
    private static Vector3 Vector(float[] values)
    {
        if(values.Length!=3)throw new InvalidDataException("Invalid gunner explosion vector.");
        var v=new Vector3(values[0],values[1],values[2]);
        if(!PlayerHitbox.Finite(v)||Math.Abs(v.X)>5||Math.Abs(v.Y)>5||Math.Abs(v.Z)>5)
            throw new InvalidDataException("Gunner explosion vector outside source range.");
        return v;
    }
}
