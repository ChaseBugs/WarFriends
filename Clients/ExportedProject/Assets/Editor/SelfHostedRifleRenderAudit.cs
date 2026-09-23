using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Google.Protobuf;
using Newtonsoft.Json.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;
using System.Reflection;

public static class SelfHostedRifleRenderAudit
{
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_RIFLE_RENDER_FIXTURE");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_RIFLE_RENDER_FIXTURE.");
        var fixture=JObject.Parse(File.ReadAllText(path));
        const string source="Assets/Scenes/MainScene.unity";
        using(var sha=SHA256.Create())
            if(BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant()!=(string)fixture["sceneHash"])
                throw new InvalidOperationException("Renderer fixture scene mismatch.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var renderer=new SelfHostedRiflePoseRenderer(player.transform,animator);
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true);
            var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var muzzle=inventory.allWeapons[(int)fixture["inventoryIndex"]].GetComponent<Weapon>().spawnPoint;
            int checks=0;
            foreach(var item in fixture["cases"])
            {
                var state=JsonParser.Default.Parse<BattlePlayerState>((string)item["player"]);
                renderer.Apply(state);
                var caseMuzzle=item["inventoryIndex"]==null?muzzle:
                    inventory.allWeapons[(int)item["inventoryIndex"]].GetComponent<Weapon>().spawnPoint;
                for(int i=0;i<parts.Length;i++)
                {
                    var collider=parts[i].GetComponent<Collider>();var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                    Near(collider.transform.TransformPoint(box!=null?box.center:sphere.center),V(item["parts"][i]),"part "+i+" tick "+state.RiflePose.SampledTick);checks++;
                }
                Near(caseMuzzle.position,V(item["muzzle"]),"muzzle tick "+state.RiflePose.SampledTick);checks++;
            }
            if(checks<1000)throw new InvalidOperationException("Incomplete encounter fixtures.");
            var malformed=JsonParser.Default.Parse<BattlePlayerState>((string)fixture["cases"][0]["player"]);
            var before=muzzle.position;malformed.RiflePose.Layers[0].Seconds=double.NaN;
            bool rejected=false;
            try {renderer.Apply(malformed);}catch(ArgumentException){rejected=true;}
            if(!rejected || Vector3.Distance(before,muzzle.position)>.000001f)throw new InvalidOperationException("Malformed pose changed the rig.");
            var owner=new GameObject("RifleSnapshotAdapterAudit");
            try
            {
                var adapter=owner.AddComponent<SelfHostedBattleClient>();
                var cases=fixture["cases"].Where(row=>JsonParser.Default.Parse<BattlePlayerState>((string)row["player"]).PlayerId==
                    JsonParser.Default.Parse<BattlePlayerState>((string)fixture["cases"][0]["player"]).PlayerId).ToArray();
                var newest=cases.Last(row=>JsonParser.Default.Parse<BattlePlayerState>((string)row["player"]).RiflePose.SampledTick>0);
                var next=JsonParser.Default.Parse<BattlePlayerState>((string)newest["player"]);
                bool refused=false;
                try {adapter.BindRifleView(next.PlayerId,player.transform,animator);}catch(InvalidOperationException){refused=true;}
                if(!refused)throw new InvalidOperationException("Active original writers were accepted.");
                player.enabled=false;animator.enabled=false;
                adapter.BindRifleView(next.PlayerId,player.transform,animator);
                bool duplicateRig=false;
                try {adapter.BindRifleView(new string('c',32),player.transform,animator);}catch(ArgumentException){duplicateRig=true;}
                if(!duplicateRig)throw new InvalidOperationException("Two identities owned one rig.");
                var apply=typeof(SelfHostedBattleClient).GetMethod("Apply",BindingFlags.NonPublic|BindingFlags.Instance);
                var current=new MatchReply {Snapshot=new MatchSnapshot {ServerTick=next.RiflePose.SampledTick,StateRevision=20}};
                current.Snapshot.Players.Add(next);
                apply.Invoke(adapter,new object[] {current});
                Near(muzzle.position,V(newest["muzzle"]),"adapter snapshot pose");checks++;
                var old=JsonParser.Default.Parse<BattlePlayerState>((string)cases[0]["player"]);
                var stale=new MatchReply {Snapshot=new MatchSnapshot {ServerTick=0,StateRevision=19}};
                stale.Snapshot.Players.Add(old);
                apply.Invoke(adapter,new object[] {stale});
                Near(muzzle.position,V(newest["muzzle"]),"stale adapter pose did not rewind");checks++;
                if(adapter.State.ServerTick!=current.Snapshot.ServerTick)throw new InvalidOperationException("Adapter snapshot rewound.");
                adapter.UnbindRifleView(next.PlayerId);
            }
            finally {UnityEngine.Object.DestroyImmediate(owner);}
            Debug.Log("RIFLE_RENDER_AUDIT_PASSED checks="+checks);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static Vector3 V(JToken a) {return new Vector3((float)a[0],(float)a[1],(float)a[2]);}
    private static void Near(Vector3 a,Vector3 b,string label)
    { if(Vector3.Distance(a,b)>.0003f)throw new InvalidOperationException(label+": actual="+a.ToString("F6")+" expected="+b.ToString("F6")); }
}
