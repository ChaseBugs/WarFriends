using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record EnemyPoseFrame(float Seconds,IReadOnlyList<PlayerHitbox> Parts);
internal sealed record EnemyPoseClip(string Name,float Length,string Wrap,IReadOnlyList<EnemyPoseFrame> Frames);

/// <summary>Complete Unity-sampled hit geometry for every legacy Animation clip attached to enemy.prefab.</summary>
internal sealed class EnemyPoseCatalog
{
    private const string BodyPath="enemy/character_assault_1/global_move/cartoon_guyHub001";
    private const string HeadPath=BodyPath+"/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003";
    private static readonly string[] ExpectedNames=
    [
        "SMG_idle","SMG_run","T_pose","bazooka_crawl","bazooka_idle","bazooka_reload","bazooka_run","bazooka_shoot_left","bazooka_shoot_right","bazooka_shot_barrier","bazooka_shot_run","bazooka_uncover_left","bazooka_uncover_right","buggy_idle","colt_idle01","colt_run","colt_shooting_loop","colt_shooting_start","colt_shooting_stop","commando_shooting","engineer_idle","engineer_repair","engineer_run","flamethrower_idle","flamethrower_run","flamethrower_shot","flamethrower_shot_loop","flight_forward_jetpack_elite","flight_start_jetpack_elite","grenade_idle","grenade_reload","grenade_run","grenadelauncher_idle","helicopter_jump_pose","idle_1","machinegn_reload","minigun_idle","minigun_run","minigun_shot","mortar_down","mortar_down_idle","mortar_hide","mortar_idle_standing","mortar_run","mortar_up","pistol_idle","pistol_run","player_dead_left","player_dead_right","player_fire_left3","player_fire_left_grenadelauncher","player_fire_left_minigun","player_fire_left_pistol","player_fire_left_qbz","player_fire_left_qbz2","player_fire_left_shotgun","player_fire_left_sniper","player_fire_right3","player_fire_right_grenadelauncher","player_fire_right_minigun","player_fire_right_pistol","player_fire_right_qbz","player_fire_right_qbz2","player_fire_right_shotgun","player_fire_right_sniper","player_left_coverBack3","player_left_coverBack_grenadelauncher","player_left_coverBack_minigun","player_left_coverBack_pistol","player_left_coverBack_qbz","player_left_coverBack_qbz2","player_left_coverBack_shotgun","player_left_coverBack_sniper","player_look_left3","player_look_left_grenadelauncher","player_look_left_minigun","player_look_left_pistol","player_look_left_qbz","player_look_left_qbz2","player_look_left_shotgun","player_look_left_sniper","player_look_right3","player_look_right_grenadelauncher","player_look_right_minigun","player_look_right_pistol","player_look_right_qbz","player_look_right_qbz2","player_look_right_shotgun","player_look_right_sniper","player_right_coverBack3","player_right_coverBack_grenadelauncher","player_right_coverBack_minigun","player_right_coverBack_pistol","player_right_coverBack_qbz","player_right_coverBack_qbz2","player_right_coverBack_shotgun","player_right_coverBack_sniper","qbz2_idle","qbz2_reload","qbz2_run","qbz_idle","qbz_reload","qbz_run","reload_fast_01","reload_grenadelauncher","reload_pistol","rifle_shot","rifle_shot_loop","run_0","run_grenadelauncher","shield_hide","shield_idle","shield_run","shield_shot","shield_unhide","shootAdditive","shot_jetpack_elite","shotgun_reload","shotgunner_idle","shotgunner_run","shotgunner_shot","shotgunner_shot_loop","sniper_idle","sniper_reload","sniper_run","stand_up_begin","stand_up_crawl","stand_up_shoot","throw_grenade_left","throw_grenade_right","throw_grenade_up","warp_idle","warp_movement"
    ];
    private sealed class Root {public int Version{get;set;}public string Client{get;set;}="";public string Source{get;set;}="";public string Sha256{get;set;}="";public int SampleRate{get;set;}public ClipDto[] Clips{get;set;}=[];}
    private sealed class ClipDto {public string Name{get;set;}="";public string Source{get;set;}="";public string Guid{get;set;}="";public long FileId{get;set;}public string Sha256{get;set;}="";public float Length{get;set;}public string Wrap{get;set;}="";public FrameDto[] Frames{get;set;}=[];}
    private sealed class FrameDto {public float Seconds{get;set;}public PartDto[] Parts{get;set;}=[];}
    private sealed class PartDto {public string Role{get;set;}="";public string Path{get;set;}="";public string Type{get;set;}="";public float Weight{get;set;}public bool Trigger{get;set;}public float[] Center{get;set;}=[];public float[] Rotation{get;set;}=[];public float[] Size{get;set;}=[];public float Radius{get;set;}}

    private readonly IReadOnlyDictionary<string,EnemyPoseClip> clips;
    internal string Revision {get;}
    internal string SourceSha256 {get;}
    internal IReadOnlyList<string> Names=>ExpectedNames;
    private EnemyPoseCatalog(string revision,string sourceSha256,Dictionary<string,EnemyPoseClip> clips)
    {Revision=revision;SourceSha256=sourceSha256;this.clips=clips;}

    internal EnemyPoseClip Clip(string name)=>clips.TryGetValue(name,out var clip)?clip:
        throw new InvalidDataException("Unknown recovered enemy animation clip.");

    internal IReadOnlyList<PlayerHitbox> Place(string clipName,Vector3 rootPosition,Quaternion rootRotation,float seconds,string prefix="")
    {
        if(!PlayerHitbox.Finite(rootPosition)||!Finite(rootRotation)||Math.Abs(rootRotation.LengthSquared()-1)>.0002f||
           !float.IsFinite(seconds)||seconds<0||prefix.Length>128||prefix.Any(char.IsControl))
            throw new InvalidDataException("Invalid enemy pose placement.");
        var clip=Clip(clipName);
        float sampleTime=clip.Wrap=="Loop"&&clip.Length>0?seconds%clip.Length:Math.Min(seconds,clip.Length);
        int index=Math.Min((int)MathF.Floor(sampleTime*30f),clip.Frames.Count-1);
        var rotation=Quaternion.Normalize(rootRotation);
        return clip.Frames[index].Parts.Select(p=>new PlayerHitbox(prefix+p.SourcePath,p.Kind,p.Weight,
            rootPosition+Vector3.Transform(p.Center,rotation),p.Size,Quaternion.Normalize(rotation*p.Rotation),
            p.Radius,Vector3.Zero,0,true,true)).ToArray();
    }

    internal static EnemyPoseCatalog Load(string path,string expectedRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <1_000_000 or >16_000_000||!Regex.IsMatch(expectedRevision,@"\A[0-9a-f]{64}\z")||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Enemy pose revision mismatch.");
        Root root;
        try {root=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??throw new InvalidDataException("Missing enemy pose artifact.");}
        catch(JsonException e){throw new InvalidDataException("Malformed enemy pose artifact.",e);}
        if(root.Version!=2||root.Client!="1.4.0"||root.Source!="Assets/GameObject/enemy.prefab"||
           !Regex.IsMatch(root.Sha256,@"\A[0-9a-f]{64}\z")||root.SampleRate!=30||root.Clips.Length!=ExpectedNames.Length)
            throw new InvalidDataException("Wrong enemy pose provenance.");
        var result=new Dictionary<string,EnemyPoseClip>(StringComparer.Ordinal);
        for(int c=0;c<ExpectedNames.Length;c++)
        {
            var source=root.Clips[c];string name=ExpectedNames[c];
            if(source.Name!=name||source.Source!=$"Assets/AnimationClip/{name}.anim"||source.FileId!=7400000||
               !Regex.IsMatch(source.Guid,@"\A[0-9a-f]{32}\z")||!Regex.IsMatch(source.Sha256,@"\A[0-9a-f]{64}\z")||
               !float.IsFinite(source.Length)||source.Length<=0||source.Length>60||
               source.Wrap is not ("Clamp" or "ClampForever" or "Default" or "Loop")||
               source.Frames.Length!=checked((int)MathF.Ceiling(source.Length*30f)+1))
                throw new InvalidDataException("Invalid enemy pose clip identity.");
            var frames=new EnemyPoseFrame[source.Frames.Length];
            for(int f=0;f<frames.Length;f++)
            {
                var frame=source.Frames[f];float expectedSeconds=Math.Min(f/30f,source.Length);
                if(!float.IsFinite(frame.Seconds)||Math.Abs(frame.Seconds-expectedSeconds)>.00001f||frame.Parts.Length!=3)
                    throw new InvalidDataException("Invalid enemy pose timeline.");
                var parts=new PlayerHitbox[3];
                string[] roles=["body-box","body-sphere","head"];string[] paths=[BodyPath,BodyPath,HeadPath];
                PlayerHitboxKind[] kinds=[PlayerHitboxKind.Box,PlayerHitboxKind.Sphere,PlayerHitboxKind.Sphere];float[] weights=[1,1,1.5f];
                for(int p=0;p<3;p++)
                {
                    var part=frame.Parts[p];
                    if(part.Role!=roles[p]||part.Path!=paths[p]||part.Type!=(kinds[p]==PlayerHitboxKind.Box?"BoxCollider":"SphereCollider")||
                       part.Weight!=weights[p]||part.Trigger||part.Radius<0||!float.IsFinite(part.Radius)||part.Radius>1||
                       (p==0?(part.Radius!=0||part.Size.Any(x=>x<=0)):(part.Radius<=0||part.Size.Any(x=>x!=0))))
                        throw new InvalidDataException("Invalid enemy pose hit part.");
                    parts[p]=new(part.Path,kinds[p],part.Weight,Vector(part.Center),Vector(part.Size),Rotation(part.Rotation),part.Radius,Vector3.Zero,0,true,true);
                }
                frames[f]=new(frame.Seconds,Array.AsReadOnly(parts));
            }
            if(!result.TryAdd(name,new(name,source.Length,source.Wrap,Array.AsReadOnly(frames))))
                throw new InvalidDataException("Duplicate enemy pose clip.");
        }
        return new(expectedRevision,root.Sha256,result);
    }

    private static Vector3 Vector(float[] value)
    {
        if(value.Length!=3)throw new InvalidDataException("Invalid enemy pose vector.");
        var vector=new Vector3(value[0],value[1],value[2]);
        if(!PlayerHitbox.Finite(vector)||Math.Abs(vector.X)>5||Math.Abs(vector.Y)>5||Math.Abs(vector.Z)>5)
            throw new InvalidDataException("Enemy pose vector outside source bounds.");
        return vector;
    }
    private static Quaternion Rotation(float[] value)
    {
        if(value.Length!=4)throw new InvalidDataException("Invalid enemy pose rotation.");
        var rotation=new Quaternion(value[0],value[1],value[2],value[3]);
        if(!Finite(rotation)||Math.Abs(rotation.LengthSquared()-1)>.0002f)throw new InvalidDataException("Invalid enemy pose rotation.");
        return Quaternion.Normalize(rotation);
    }
    private static bool Finite(Quaternion value)=>float.IsFinite(value.X)&&float.IsFinite(value.Y)&&float.IsFinite(value.Z)&&float.IsFinite(value.W);
}
