using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedRigBlendExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_RIG_BLEND_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_RIG_BLEND_OUTPUT.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source="Assets/Scenes/MainScene.unity";
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var animation=animator.GetComponent<Animation>();
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            var nodes=BuildNodes(player);
            var indices=nodes.Select((t,i)=>new { t,i }).ToDictionary(x=>x.t,x=>x.i);
            var cases=new List<object>();
            string[][] pairs={new[] { "idle","player_look_right3" },new[] { "player_right_coverBack3","idle" },new[] { "player_fire_left3","player_look_right3" },new[] { "idle","player_look_right3","run" }};
            foreach (var pair in pairs)
            foreach (float weight in new[] { .25f,.5f,.75f })
            {
                float aTime=Mathf.Floor(animation[pair[0]].length*.5f*30)/30,bTime=Mathf.Floor(animation[pair[1]].length*.5f*30)/30;
                Sample(animation,pair[0],aTime); var a=nodes.Select((t,i)=>Local(t,i==0)).ToArray();
                Sample(animation,pair[1],bTime); var b=nodes.Select((t,i)=>Local(t,i==0)).ToArray();
                float thirdTime=pair.Length==3 ? Mathf.Floor(animation[pair[2]].length*.5f*30)/30 : 0;
                object[] c=null;
                if (pair.Length==3) { Sample(animation,pair[2],thirdTime);c=nodes.Select((t,i)=>Local(t,i==0)).ToArray(); }
                Sample(animation,"T_pose",animation["T_pose"].length);
                foreach (AnimationState state in animation) state.enabled=false;
                var first=animation[pair[0]]; var second=animation[pair[1]];
                float remainder=pair.Length==3 ? .8f : 1;
                first.enabled=true; first.weight=(1-weight)*remainder; first.time=aTime;
                second.enabled=true; second.weight=weight*remainder; second.time=bTime;
                if (pair.Length==3) { var third=animation[pair[2]];third.enabled=true;third.weight=.2f;third.time=thirdTime; }
                animation.Sample();
                cases.Add(new { from=pair[0],to=pair[1],fromSeconds=aTime,toSeconds=bTime,weight=weight,a=a,b=b,
                    third=pair.Length==3 ? pair[2] : null,thirdSeconds=thirdTime,c=c,
                    world=nodes.Select(t=>new { position=V(t.position),rotation=Q(t.rotation) }).ToArray(),
                    parts=player.GetComponentsInChildren<DestroyableObjectpart>(true).Select(p=>
                    {
                        var collider=p.GetComponent<Collider>();var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                        return new { path=PathOf(p.transform),center=V(collider.transform.TransformPoint(box!=null ? box.center : sphere.center)),rotation=Q(collider.transform.rotation) };
                    }).ToArray(),
                    local=nodes.Select((t,i)=>Local(t,i==0)).ToArray() });
            }
            string hash; using (var sha=SHA256.Create()) hash=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant();
            File.WriteAllText(output,JsonConvert.SerializeObject(new { client="1.4.0",source=source,sha256=hash,
                nodes=nodes.Select((t,i)=>new { path=PathOf(t),parent=i==0 ? -1 : indices[t.parent] }).ToArray(),cases=cases },Formatting.Indented));
            Debug.Log("RIG_BLEND_EXPORT_PASSED nodes="+nodes.Length+" cases="+cases.Count);
        }
        finally
        {
            if (previous.Any(s=>s.isActive && s.isLoaded) && previous.All(s=>!string.IsNullOrEmpty(s.path))) EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    internal static Transform[] BuildNodes(PlayerController player)
    {
        var required=new HashSet<Transform>();
        var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
        var targets=player.GetComponentsInChildren<Weapon>(true).Where(w=>w.spawnPoint!=null).Select(w=>w.spawnPoint)
            .Concat(player.GetComponentsInChildren<DestroyableObjectpart>(true).Select(p=>p.transform)).Concat(new[] { animator.upperBody });
        foreach (var target in targets)
            for (var t=target;t!=null;t=t.parent) { required.Add(t); if (t==player.transform) break; }
        var nodes=required.OrderBy(t=>Depth(t)).ThenBy(t=>PathOf(t),StringComparer.Ordinal).ToArray();
        if (nodes[0]!=player.transform) throw new InvalidOperationException("Rig contains a foreign target.");
        return nodes;
    }
    internal static object Local(Transform t,bool root) { return new { position=V(root ? t.position : t.localPosition),rotation=Q(root ? t.rotation : t.localRotation),scale=V(root ? t.lossyScale : t.localScale) }; }
    private static void Sample(Animation animation,string name,float time)
    {
        animation.Stop(); var reset=animation["T_pose"]; reset.enabled=true;reset.weight=1;reset.time=reset.length;animation.Sample();reset.enabled=false;
        var state=animation[name];state.enabled=true;state.weight=1;state.time=time;animation.Sample();state.enabled=false;
    }
    private static int Depth(Transform t) { int d=0;while(t.parent!=null){t=t.parent;d++;}return d; }
    private static string PathOf(Transform t) { return t.parent==null ? t.name : PathOf(t.parent)+"/"+t.name; }
    private static float[] V(Vector3 v) { return new[] { v.x,v.y,v.z }; }
    private static float[] Q(Quaternion q) { return new[] { q.x,q.y,q.z,q.w }; }
}
