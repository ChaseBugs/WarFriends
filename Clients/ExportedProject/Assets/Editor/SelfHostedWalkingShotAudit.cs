using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Google.Protobuf;
using Newtonsoft.Json.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedWalkingShotAudit
{
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_WALKING_SHOT_RENDER_FIXTURE");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_WALKING_SHOT_RENDER_FIXTURE.");
        var fixture=JObject.Parse(File.ReadAllText(path));
        const string source="Assets/Scenes/MainScene.unity";
        using(var sha=SHA256.Create())
            if(BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant()!=(string)fixture["sceneHash"])
                throw new InvalidOperationException("Walking-shot scene mismatch.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var renderer=new SelfHostedRiflePoseRenderer(player.transform,animator);
            var nodes=player.GetComponentsInChildren<Transform>(true).ToLookup(t=>PathOf(t));
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true);
            int checks=0;
            foreach(var row in fixture["cases"])
            {
                var state=JsonParser.Default.Parse<BattlePlayerState>((string)row["player"]);
                renderer.Apply(state);
                foreach(var part in row["parts"])
                {
                    var collider=parts.Single(p=>PathOf(p.transform)==(string)part["path"]).GetComponent<Collider>();
                    var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                    Near(collider.transform.TransformPoint(box!=null?box.center:sphere.center),V(part["center"]),"walking collider");checks++;
                }
                foreach(var muzzle in row["muzzles"])
                {
                    Near(nodes[(string)muzzle["path"]].First().position,V(muzzle["position"]),"walking muzzle");checks++;
                }
            }
            if(checks!=260)throw new InvalidOperationException("Incomplete walking-shot renderer fixtures.");
            var bad=JsonParser.Default.Parse<BattlePlayerState>((string)fixture["cases"][0]["player"]);
            bad.RiflePose.UpperBodyLayer.Weight=float.NaN;
            bool rejected=false;try{renderer.Apply(bad);}catch(ArgumentException){rejected=true;}
            if(!rejected)throw new InvalidOperationException("Malformed walking-shot overlay accepted.");
            Debug.Log("WALKING_SHOT_AUDIT_PASSED checks="+checks);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static Vector3 V(JToken a){return new Vector3((float)a[0],(float)a[1],(float)a[2]);}
    private static void Near(Vector3 actual,Vector3 expected,string label)
    {if(Vector3.Distance(actual,expected)>.0003f)throw new InvalidOperationException(label+": actual="+actual.ToString("F6")+" expected="+expected.ToString("F6"));}
}
