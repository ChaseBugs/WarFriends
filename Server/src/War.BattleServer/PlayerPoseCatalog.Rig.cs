using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed partial class PlayerPoseCatalog
{
    private sealed record RigPart(PlayerHitbox Template,int Node,Vector3 Center,Vector3 Size,float Radius);
    private int[] rigParents=[];
    private Dictionary<string,int> rigIndex=new(StringComparer.Ordinal);
    private readonly Dictionary<string,RigLocalTransform[][]> rigFrames=new(StringComparer.Ordinal);
    private RigPart[] rigParts=[];
    private int bodyNode,upperNode;
    private Dictionary<string,(int Node,string Path)> extraMuzzles=new(StringComparer.Ordinal);
    private (int Node,string Path)? movingShotTarget;
    private PlayerShotTarget[] bodyShotTargets=[];

    internal void AttachPlayerShotTargets(PlayerShotTargetCatalog catalog)
    {
        if(catalog==null || movingShotTarget!=null || bodyShotTargets.Length!=0 || rigIndex.Count!=142)
            throw new InvalidDataException("Invalid moving-target pose binding.");
        var target=catalog.Gameplay.Single(t=>t.Type==16);
        if(!rigIndex.TryGetValue(target.Path,out int node))
            throw new InvalidDataException("Recovered moving target is absent from player rig.");
        movingShotTarget=(node,target.Path);
        bodyShotTargets=catalog.Gameplay.Where(t=>t.Type==1).ToArray();
        if(bodyShotTargets.Length!=2 || bodyShotTargets.Any(t=>t.Path!="MainSceneRootNew/Player/shotTarget"))
            throw new InvalidDataException("Recovered Body targets are not direct player children.");
    }

    // The original pose export sampled only rifle muzzles explicitly, but its
    // complete validated rig contains all nine shotgun muzzle transforms.
    internal void AttachShotgunMuzzles(ShotgunCatalog catalog)
    {
        if(catalog==null || catalog.SceneRevision!=SourceHash || rigIndex.Count!=142)
            throw new InvalidDataException("Invalid shotgun pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node) ||
                !nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("Shotgun muzzle missing from recovered rig.");
        }
        if(nodes.Count!=9)throw new InvalidDataException("Incomplete shotgun muzzle binding.");
        foreach(var row in nodes)
            if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachSmgMuzzles(SmgCatalog catalog)
    {
        if(catalog==null || catalog.SceneRevision!=SourceHash || rigIndex.Count!=142)
            throw new InvalidDataException("Invalid SMG pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node) ||
                !nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("SMG muzzle missing from recovered rig.");
        }
        if(nodes.Count!=8)throw new InvalidDataException("Incomplete SMG muzzle binding.");
        foreach(var row in nodes)
            if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachPistolMuzzles(PistolCatalog catalog)
    {
        if(catalog==null || catalog.SceneRevision!=SourceHash || rigIndex.Count!=142)
            throw new InvalidDataException("Invalid pistol pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node)||!nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("Pistol muzzle missing from recovered rig.");
        }
        if(nodes.Count!=6)throw new InvalidDataException("Incomplete pistol muzzle binding.");
        foreach(var row in nodes)if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachLmgMuzzles(LmgCatalog catalog)
    {
        if(catalog==null||catalog.SceneRevision!=SourceHash||rigIndex.Count!=142)throw new InvalidDataException("Invalid LMG pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node)||!nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("LMG muzzle missing from recovered rig.");
        }
        if(nodes.Count!=8)throw new InvalidDataException("Incomplete LMG muzzle binding.");
        foreach(var row in nodes)if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachMinigunMuzzle(MinigunCatalog catalog)
    {
        if(catalog==null||catalog.SceneRevision!=SourceHash||rigIndex.Count!=142||
           !rigIndex.TryGetValue(catalog.Binding.MuzzlePath,out int node)||
           !extraMuzzles.TryAdd(MinigunCatalog.SourceId,(node,catalog.Binding.MuzzlePath)))
            throw new InvalidDataException("Minigun muzzle missing from recovered rig.");
    }

    internal void AttachSniperMuzzles(SniperCatalog catalog)
    {
        if(catalog==null||catalog.SceneRevision!=SourceHash||rigIndex.Count!=142)throw new InvalidDataException("Invalid sniper pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node)||!nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("Sniper muzzle missing from recovered rig.");
        if(nodes.Count!=8)throw new InvalidDataException("Incomplete sniper muzzle binding.");
        foreach(var row in nodes)if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachBazookaMuzzles(BazookaCatalog catalog)
    {
        if(catalog==null||catalog.SceneRevision!=SourceHash||rigIndex.Count!=142)throw new InvalidDataException("Invalid bazooka pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node)||!nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("Bazooka muzzle missing from recovered rig.");
            if(binding.SecondaryMuzzlePath is { } secondary &&
               (!rigIndex.TryGetValue(secondary,out int secondaryNode)||!nodes.TryAdd(binding.SourceId+"#secondary",(secondaryNode,secondary))))
                throw new InvalidDataException("Bazooka secondary muzzle missing from recovered rig.");
        }
        if(nodes.Count!=8)throw new InvalidDataException("Incomplete bazooka muzzle binding.");
        foreach(var row in nodes)if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal void AttachGrenadeMuzzles(GrenadeCatalog catalog)
    {
        if(catalog==null||catalog.SceneRevision!=SourceHash||rigIndex.Count!=142)throw new InvalidDataException("Invalid grenade pose binding.");
        var nodes=new Dictionary<string,(int Node,string Path)>(StringComparer.Ordinal);
        foreach(var binding in catalog.Bindings)
        {
            if(!rigIndex.TryGetValue(binding.MuzzlePath,out int node)||!nodes.TryAdd(binding.SourceId,(node,binding.MuzzlePath)))
                throw new InvalidDataException("Grenade muzzle missing from recovered rig.");
        }
        // The existing pose package samples the equipped right-hand weapon
        // hierarchy. The shared left-hand swipe spawn is outside that exported
        // hierarchy and remains a separately pinned path in GrenadeCatalog.
        if(nodes.Count!=8)throw new InvalidDataException("Incomplete grenade muzzle binding.");
        foreach(var row in nodes)if(!extraMuzzles.TryAdd(row.Key,row.Value))throw new InvalidDataException("Duplicate extra muzzle identity.");
    }

    internal PlayerAimPose SampleLayers(IReadOnlyList<RifleClipLayer> layers,Quaternion? bodyLocal=null,Quaternion? upperLocal=null)
    {
        var local=RigLocalPose.BlendWeighted(layers.Select(l=>rigFrames[l.Clip.Name][Frame(Get(l.Clip.Name),l.Clip.Seconds,l.Clip.Loop)]).ToArray(),layers.Select(l=>l.Weight).ToArray());
        if (bodyLocal.HasValue) local[bodyNode]=local[bodyNode] with { Rotation=bodyLocal.Value };
        if (upperLocal.HasValue) local[upperNode]=local[upperNode] with { Rotation=upperLocal.Value };
        return BuildRigPose(RigLocalPose.Compose(rigParents,local));
    }

    internal PlayerAimPose SampleWalkingShot(string run,double runSeconds,double shotSeconds,float weight,
        Quaternion? bodyLocal=null,Quaternion? upperLocal=null)
    {
        if (run is not ("run" or "qbz_run" or "qbz2_run" or "shotgunner_run" or "pistol_run" or "minigun_run" or "sniper_run" or "bazooka_run"))
            throw new ArgumentException("Unsupported walking rifle pose.",nameof(run));
        var basePose=rigFrames[run][Frame(Get(run),runSeconds,true)];
        var shotPose=rigFrames["shootAdditive"][Frame(Get("shootAdditive"),shotSeconds,false)];
        var blended=RigLocalPose.Blend(basePose,shotPose,weight);
        for (int node=0;node<blended.Length;node++)
        {
            int ancestor=node;
            while (ancestor>=0 && ancestor!=upperNode) ancestor=rigParents[ancestor];
            if (ancestor<0) blended[node]=basePose[node];
        }
        if(bodyLocal.HasValue) blended[bodyNode]=blended[bodyNode] with {Rotation=bodyLocal.Value};
        if(upperLocal.HasValue) blended[upperNode]=blended[upperNode] with {Rotation=upperLocal.Value};
        return BuildRigPose(RigLocalPose.Compose(rigParents,blended));
    }

    public PlayerAimPose SampleBlended(string from,double fromSeconds,bool fromLoop,string to,double toSeconds,bool toLoop,
        float weight,Quaternion? bodyLocal=null,Quaternion? upperLocal=null)
    {
        var a=Get(from); var b=Get(to);
        var local=RigLocalPose.Blend(rigFrames[from][Frame(a,fromSeconds,fromLoop)],rigFrames[to][Frame(b,toSeconds,toLoop)],weight);
        if (bodyLocal.HasValue) local[bodyNode]=local[bodyNode] with { Rotation=bodyLocal.Value };
        if (upperLocal.HasValue) local[upperNode]=local[upperNode] with { Rotation=upperLocal.Value };
        return BuildRigPose(RigLocalPose.Compose(rigParents,local));
    }

    private void LoadRig(JsonElement root)
    {
        var nodes=root.GetProperty("rigNodes").EnumerateArray().ToArray();
        if (nodes.Length!=142) throw new InvalidDataException("Incomplete recovered rig hierarchy.");
        rigParents=new int[nodes.Length];
        string rootPath=root.GetProperty("playerPath").GetString()!;
        string[] paths=new string[nodes.Length];
        for (int i=0;i<nodes.Length;i++)
        {
            string path=nodes[i].GetProperty("path").GetString()??"";
            int parent=nodes[i].GetProperty("parent").GetInt32();
            if (path.Length>1200 || path.Any(char.IsControl) || !rigIndex.TryAdd(path,i) ||
                (i==0 ? parent!=-1 || path!=rootPath : parent<0 || parent>=i || path[..Math.Max(0,path.LastIndexOf('/'))]!=paths[parent]))
                throw new InvalidDataException("Invalid rig hierarchy identity/order.");
            paths[i]=path;rigParents[i]=parent;
        }
        var reference=clips[Expected[0]].Frames[0];
        var aim=clips[Expected[0]].Bones[0];
        if (!rigIndex.TryGetValue(aim[0].Path,out bodyNode)||!rigIndex.TryGetValue(aim[1].Path,out upperNode))
            throw new InvalidDataException("Rig missing procedural aim bones.");
        foreach (var clipRow in root.GetProperty("clips").EnumerateArray())
        {
            string name=clipRow.GetProperty("name").GetString()!; var clip=clips[name];
            var localFrames=new RigLocalTransform[clip.Frames.Length][]; int i=0;
            foreach (var frame in clipRow.GetProperty("frames").EnumerateArray())
            {
                var local=frame.GetProperty("rigLocals").EnumerateArray().Select(n=>new RigLocalTransform(
                    V(n.GetProperty("position")),Q(n.GetProperty("rotation")),V(n.GetProperty("scale")))).ToArray();
                var world=RigLocalPose.Compose(rigParents,local);
                if (rigParts.Length==0)
                    rigParts=reference.Parts.Select(p=>
                    {
                        if (!rigIndex.TryGetValue(p.SourcePath,out int node) || !Matrix4x4.Invert(world[node].Matrix,out var inverse))
                            throw new InvalidDataException("Rig missing/invertible hit part.");
                        var scale=Scale(world[node].Matrix);
                        return new RigPart(p,node,Vector3.Transform(p.Center,inverse),p.Size/scale,p.Radius/Max(scale));
                    }).ToArray();
                var predicted=BuildRigPose(world); var expected=clip.Frames[i];
                for (int part=0;part<2;part++)
                {
                    var actual=predicted.Collision.Parts[part];var source=expected.Parts[part];
                    if (Vector3.Distance(actual.Center,source.Center)>.0002f || Vector3.Distance(actual.Size,source.Size)>.0002f ||
                        Math.Abs(actual.Radius-source.Radius)>.0002f || 1-Math.Abs(Quaternion.Dot(actual.Rotation,source.Rotation))>.00001f)
                        throw new InvalidDataException("Local rig disagrees with exported collider.");
                }
                foreach (string id in ExpectedRifles)
                {
                    var actual=predicted.Muzzle(id);var source=clip.Muzzles[id][i];
                    if (Vector3.Distance(actual.Position,source.Position)>.0002f || 1-Math.Abs(Quaternion.Dot(actual.Rotation,source.Rotation))>.00001f)
                        throw new InvalidDataException("Local rig disagrees with exported muzzle.");
                }
                localFrames[i++]=local;
            }
            rigFrames.Add(name,localFrames);
        }
    }

    private PlayerAimPose BuildRigPose(RigWorldTransform[] world)
    {
        var source=clips[Expected[0]].Frames[0];
        var parts=rigParts.Select(p=>
        {
            var node=world[p.Node];var scale=Scale(node.Matrix);var t=p.Template;
            return new PlayerHitbox(t.SourcePath,t.Kind,t.Weight,Vector3.Transform(p.Center,node.Matrix),p.Size*scale,
                node.Rotation,p.Radius*Max(scale),Vector3.Zero,0,t.Enabled,t.Active,node.Position);
        }).ToArray();
        var collision=PlayerCollisionModel.InitializedFrame(source.SourceHash,source.SourcePath,world[0].Position,world[0].Rotation,parts,"local-rig-blend");
        var muzzles=new Dictionary<string,RifleMuzzlePose>(StringComparer.Ordinal);
        foreach (string id in ExpectedRifles)
        {
            var template=clips[Expected[0]].Muzzles[id][0];
            if (!rigIndex.TryGetValue(template.SourcePath,out int index)) throw new InvalidDataException("Rig missing rifle muzzle.");
            var node=world[index];
            muzzles.Add(id,template with { Position=node.Position,Rotation=node.Rotation,RootPosition=world[0].Position,RootRotation=world[0].Rotation });
        }
        foreach(var (id,binding) in extraMuzzles)
        {
            var node=world[binding.Node];
            muzzles.Add(id,new RifleMuzzlePose(binding.Path,node.Position,node.Rotation,
                world[0].Position,world[0].Rotation));
        }
        RifleMuzzlePose? moving=null;
        if(movingShotTarget is { } target)
        {
            var node=world[target.Node];
            moving=new RifleMuzzlePose(target.Path,node.Position,node.Rotation,
                world[0].Position,world[0].Rotation);
        }
        var bodies=new Dictionary<int,RifleMuzzlePose>();
        foreach(var body in bodyShotTargets)
        {
            // Direct Player children follow the root but not the animated rig.
            var reference=new RifleMuzzlePose(body.Path,body.ReferencePosition,
                source.RootRotation,source.RootPosition,source.RootRotation);
            bodies.Add(body.TransformFileId,reference.Place(world[0].Position,world[0].Rotation));
        }
        return new(collision,muzzles,moving,bodies);
    }
    private static float Max(Vector3 v)=>Math.Max(v.X,Math.Max(v.Y,v.Z));
    private static Vector3 Scale(Matrix4x4 m)
    {
        var scale=new Vector3(new Vector3(m.M11,m.M12,m.M13).Length(),new Vector3(m.M21,m.M22,m.M23).Length(),new Vector3(m.M31,m.M32,m.M33).Length());
        if (!PlayerHitbox.Finite(scale)||scale.X<.000001f||scale.Y<.000001f||scale.Z<.000001f) throw new InvalidDataException("Invalid composed rig scale.");
        return scale;
    }
}
