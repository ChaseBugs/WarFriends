using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedPlayerPoseExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_PLAYER_POSE_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_PLAYER_POSE_OUTPUT.");
        var previous = EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source = "Assets/Scenes/MainScene.unity";
            var scene = EditorSceneManager.OpenScene(source);
            var game = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<GameController>(true)).Single();
            var player = game.mainPlayerController;
            var inventory = player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var levels = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<RifleLevelsSetup>(true));
            var muzzles = new SortedDictionary<string, Transform>(StringComparer.Ordinal);
            foreach (var setup in levels)
            {
                string id = setup.GetComponents<MonoBehaviour>().Single(c => c != null && c.GetType().Namespace == "Google2u").GetType().FullName;
                if (!id.StartsWith("Google2u.AssaultRifle_", StringComparison.Ordinal)) continue;
                var weapon = inventory.allWeapons[setup.indexInWeaponInventory].GetComponent<Weapon>();
                if (weapon.spawnPoint == null) throw new InvalidOperationException("Missing rifle muzzle " + id);
                muzzles.Add(id,weapon.spawnPoint);
            }
            if (muzzles.Count != 11) throw new InvalidOperationException("Incomplete rifle muzzle set.");
            var animator = player.GetComponentInChildren<SoldierAnimationController>(true);
            var rigNodes=SelfHostedRigBlendExport.BuildNodes(player);
            var rigIndices=rigNodes.Select((t,i)=>new { t,i }).ToDictionary(x=>x.t,x=>x.i);
            var animation = animator.GetComponent<Animation>();
            var sourceClips = animation.Cast<AnimationState>().ToDictionary(s => s.name, s => s.clip);
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            var parts = player.GetComponentsInChildren<DestroyableObjectpart>(true);
            if (parts.Length != 2) throw new InvalidOperationException("Unexpected source hit-part count.");
            // Reproduce only the collider initialization contract, without running
            // account, camera, weapon inventory or other gameplay singletons.
            foreach (var collider in player.ragdollColliders) collider.enabled = false;
            foreach (var part in parts) part.GetComponent<Collider>().enabled = true;
            string[] names = { "T_pose", "idle", "run", "player_look_left3", "player_fire_left3", "player_left_coverBack3",
                "player_look_right3", "player_fire_right3", "player_right_coverBack3", "rifle_shot_loop",
                "player_look_left_qbz", "player_fire_left_qbz", "player_left_coverBack_qbz",
                "player_look_right_qbz", "player_fire_right_qbz", "player_right_coverBack_qbz",
                "player_look_left_qbz2", "player_fire_left_qbz2", "player_left_coverBack_qbz2",
                "player_look_right_qbz2", "player_fire_right_qbz2", "player_right_coverBack_qbz2",
                "player_look_left_shotgun", "player_fire_left_shotgun", "player_left_coverBack_shotgun",
                "player_look_right_shotgun", "player_fire_right_shotgun", "player_right_coverBack_shotgun",
                "player_look_left_pistol", "player_fire_left_pistol", "player_left_coverBack_pistol",
                "player_look_right_pistol", "player_fire_right_pistol", "player_right_coverBack_pistol",
                "qbz_run", "qbz2_run", "shotgunner_run", "pistol_run", "shootAdditive",
                "player_look_left_minigun", "player_fire_left_minigun", "player_left_coverBack_minigun",
                "player_look_right_minigun", "player_fire_right_minigun", "player_right_coverBack_minigun",
                "minigun_run", "minigun_idle",
                "player_look_left_sniper", "player_fire_left_sniper", "player_left_coverBack_sniper",
                "player_look_right_sniper", "player_fire_right_sniper", "player_right_coverBack_sniper",
                "sniper_run", "sniper_idle",
                "bazooka_uncover_left", "bazooka_shoot_left", "bazooka_uncover_right", "bazooka_shoot_right",
                "bazooka_run", "bazooka_idle" };
            var clips = new List<object>();
            foreach (string name in names)
            {
                var state = animation[name];
                if (state == null || state.length <= 0 || state.length > 60) throw new InvalidOperationException("Missing/invalid source clip " + name);
                // Animation.AddClip creates a runtime alias clip in Unity 2018;
                // bind provenance to the attached asset captured before aliasing.
                string sourceName = name == "idle" ? "idle_1" : name == "run" ? "run_0" : name;
                var sourceClip = sourceClips[sourceName];
                string clipPath = AssetDatabase.GetAssetPath(sourceClip), guid; long fileId;
                if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sourceClip, out guid, out fileId)) throw new InvalidOperationException("Missing clip identity: " + sourceName);
                var frames = new List<object>();
                int last = Mathf.CeilToInt(state.length * 30);
                for (int i = 0; i <= last; i++)
                {
                    Sample(animation, "T_pose", 1);
                    float seconds = Mathf.Min(i / 30f, state.length);
                    Sample(animation, name, seconds/state.length);
                    Physics.SyncTransforms();
                    var shapes = new List<object>();
                    foreach (var part in parts)
                    {
                        var collider = part.GetComponent<Collider>();
                        var box = collider as BoxCollider; var sphere = collider as SphereCollider;
                        if (box == null && sphere == null) throw new InvalidOperationException("Unsupported source pose part.");
                        var s = collider.transform.lossyScale;
                        s = new Vector3(Mathf.Abs(s.x), Mathf.Abs(s.y), Mathf.Abs(s.z));
                        var center = collider.transform.TransformPoint(box != null ? box.center : sphere.center);
                        var rays = new List<object>();
                        foreach (var direction in new[] { Vector3.right, Vector3.up, Vector3.forward })
                        {
                            var origin = center + direction * 2;
                            RaycastHit hit;
                            bool found = collider.Raycast(new Ray(origin, -direction), out hit, 4);
                            rays.Add(new { origin = V(origin), direction = V(-direction), hit = found, distance = found ? hit.distance : 0 });
                        }
                        shapes.Add(new { path = PathOf(part.transform), type = collider.GetType().Name, weight = part.weight,
                            enabled = collider.enabled, active = collider.gameObject.activeInHierarchy,
                            center = V(center), rotation = Q(collider.transform.rotation),
                            size = V(box != null ? Vector3.Scale(box.size,s) : Vector3.zero),
                            radius = sphere == null ? 0 : sphere.radius*Mathf.Max(s.x,Mathf.Max(s.y,s.z)), rays = rays });
                    }
                    // Capture actual Unity hierarchy placement as an independent
                    // reference for the host's rigid root transform.
                    var originalPosition = player.transform.position;
                    var originalRotation = player.transform.rotation;
                    player.transform.position = new Vector3(3,0,4);
                    player.transform.rotation = Quaternion.Euler(0,90,0);
                    var placed = muzzles.ToDictionary(m => m.Key,m => V(m.Value.position));
                    player.transform.position = originalPosition;
                    player.transform.rotation = originalRotation;
                    var muzzleSamples = muzzles.Select(m => new { id = m.Key, path = PathOf(m.Value),
                        position = V(m.Value.position), rotation = Q(m.Value.rotation), placedPosition = placed[m.Key] }).ToArray();
                    var bones = new[] { animator.transform, animator.upperBody };
                    var boneSamples = bones.Select(b => new { path = PathOf(b), position = V(b.position),
                        rotation = Q(b.rotation), parentRotation = Q(b.parent.rotation), parentScale = V(b.parent.lossyScale) }).ToArray();
                    var bodyLocal = animator.transform.localRotation;
                    var upperLocal = animator.upperBody.localRotation;
                    // Actual Unity hierarchy oracle for a combined procedural override.
                    animator.transform.localRotation = Quaternion.Euler(0,20,0);
                    animator.upperBody.localRotation = Quaternion.AngleAxis(-35,Vector3.right);
                    var aimedMuzzles = muzzles.Select(m => new { id = m.Key, position = V(m.Value.position), rotation = Q(m.Value.rotation) }).ToArray();
                    var aimedParts = parts.Select(p => { var c=p.GetComponent<Collider>(); var box=c as BoxCollider; var sphere=c as SphereCollider;
                        return new { path=PathOf(p.transform), center=V(c.transform.TransformPoint(box!=null ? box.center : sphere.center)), rotation=Q(c.transform.rotation) }; }).ToArray();
                    animator.transform.localRotation=bodyLocal;
                    animator.upperBody.localRotation=upperLocal;
                    frames.Add(new { seconds = seconds, parts = shapes, muzzles = muzzleSamples, aimBones = boneSamples,
                        rigLocals = rigNodes.Select((t,n)=>SelfHostedRigBlendExport.Local(t,n==0)).ToArray(),
                        aimedMuzzles = aimedMuzzles, aimedParts = aimedParts });
                }
                clips.Add(new { name = name, sourceName = sourceName, source = clipPath, guid = guid, fileId = fileId, sha256 = Hash(clipPath),
                    length = state.length, wrap = state.wrapMode.ToString(), frames = frames });
            }
            File.WriteAllText(output, JsonConvert.SerializeObject(new { client = "1.4.0", source = source, sha256 = Hash(source),
                pose = "initialized-single-clip-samples", sampleRate = 30, playerPath = PathOf(player.transform),
                position = V(player.transform.position), rotation = Q(player.transform.rotation),
                rigNodes=rigNodes.Select((t,i)=>new { path=PathOf(t), parent=i==0 ? -1 : rigIndices[t.parent] }).ToArray(), clips = clips }, Formatting.Indented));
            Debug.Log("PLAYER_POSE_EXPORT_PASSED clips=" + clips.Count);
        }
        finally
        {
            if (previous.Any(s => s.isActive && s.isLoaded) && previous.All(s => !string.IsNullOrEmpty(s.path))) EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static void Sample(Animation animation, string name, float time)
    {
        animation.Stop(); var state = animation[name]; state.enabled = true; state.weight = 1;
        state.normalizedTime = time; animation.Sample(); state.enabled = false;
    }
    private static string Hash(string path) { using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant(); }
    private static float[] V(Vector3 v) { return new[] { v.x,v.y,v.z }; }
    private static float[] Q(Quaternion q) { return new[] { q.x,q.y,q.z,q.w }; }
    private static string PathOf(Transform t) { return t.parent == null ? t.name : PathOf(t.parent)+"/"+t.name; }
}
