using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Observes the recovered animation controller with an actual host volley schedule.</summary>
[InitializeOnLoad]
public static class UnityCoopObstacleVolleyPoseExport
{
    private const string SessionKey = "WarFriends.ObstacleVolleyPoseExport";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string WeaponPath = "Assets/GameObject/AssaultRifleEnemy.prefab";
    private const string ProbeName = "ObstacleVolleyPoseProbe";
    private const string CrawlClip = "stand_up_crawl";
    private const int ObservationVersion = 4;
    private const int MaximumStripPasses = 5;
    private const int MaximumFrames = 240;
    private const float InitialHideSeconds = 1f;
    private const float RoundHideSeconds = 0.5f;
    private const float ShotSpeed = 1f;
    private static readonly List<object> Samples = new List<object>();
    private static JObject _plan;
    private static HashSet<int> _roundTicks;
    private static Animation _animation;
    private static SoldierAnimationController _controller;
    private static Transform _root;
    private static Transform _muzzle;
    private static Collider[] _parts;
    private static float _startedTime;
    private static int _lastFrame = -1;
    private static int _roundInvocations;
    private static bool _observedReturnToCrawl;
    private static readonly FieldInfo CrawlDeadlineField = typeof(SoldierAnimationController).GetField(
        "mTimeToHideToCrawl", BindingFlags.Instance | BindingFlags.NonPublic);
    private static float _deadlineBeforeShot;

    /// <summary>Exposes the next source-relative frame after the editor initializes playback.</summary>
    public static int GameplayTick
    {
        get { return _animation == null ? -1 : Samples.Count; }
    }

    /// <summary>Resets the shot animation after the gameplay observer records the firing pose.</summary>
    public static void EmitGameplayRound(int tick)
    {
        _deadlineBeforeShot = (float)CrawlDeadlineField.GetValue(_controller);
        if (_roundTicks.Contains(tick))
        {
            _controller.ShootFromCrawl(RoundHideSeconds, ShotSpeed, Weapon.WeaponType.Riffle);
            _roundInvocations++;
        }
    }

    private static bool UsesGameplayEmission
    {
        get { return Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_EMISSION_PHASE") == "update"; }
    }

    static UnityCoopObstacleVolleyPoseExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += Update;
        }
    }

    /// <summary>Prepares a disposable source rig and enters Play Mode without online gameplay.</summary>
    public static void Run()
    {
        RequireEnvironment("WAR_COOP_OBSTACLE_POSE_PLAN");
        RequireEnvironment("WAR_COOP_OBSTACLE_POSE_OUTPUT");
        string emissionPhase = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_EMISSION_PHASE");
        if (!string.IsNullOrEmpty(emissionPhase) && emissionPhase != "update")
        {
            throw new InvalidOperationException("WAR_COOP_OBSTACLE_EMISSION_PHASE must be unset or update.");
        }
        if (UsesGameplayEmission)
        {
            RequireEnvironment("WAR_COOP_OBSTACLE_QUERY_OUTPUT");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        GameObject enemy = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        enemy.name = ProbeName;
        AttachWeapon(enemy);
        SoldierAnimationController controller = enemy.GetComponentInChildren<SoldierAnimationController>(true);
        controller.enabled = false;
        StripGameplay(enemy, controller);
        foreach (NavMeshAgent agent in enemy.GetComponentsInChildren<NavMeshAgent>(true))
        {
            agent.enabled = false;
        }
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void AttachWeapon(GameObject enemy)
    {
        SoldierParts parts = enemy.GetComponentInChildren<SoldierParts>(true);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath);
        if (parts == null || parts.gunSnapPointNotScaled == null || prefab == null)
        {
            throw new InvalidOperationException("Missing recovered rifle attachment.");
        }
        GameObject weapon = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        weapon.transform.SetParent(parts.gunSnapPointNotScaled, false);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = prefab.transform.localRotation;
        weapon.transform.localScale = Vector3.one;
    }

    private static void StripGameplay(GameObject enemy, SoldierAnimationController controller)
    {
        for (int pass = 0; pass < MaximumStripPasses; pass++)
        {
            MonoBehaviour[] scripts = enemy.GetComponentsInChildren<MonoBehaviour>(true)
                .Where(script => script != null && script != controller).ToArray();
            foreach (MonoBehaviour script in scripts)
            {
                UnityEngine.Object.DestroyImmediate(script);
            }
        }
        if (enemy.GetComponentsInChildren<MonoBehaviour>(true).Any(script => script != controller))
        {
            throw new InvalidOperationException("Unexpected gameplay component remains on the probe.");
        }
    }

    private static void Update()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused || Time.frameCount == _lastFrame)
        {
            return;
        }
        try
        {
            if (_animation == null)
            {
                StartPlayback();
            }
            _lastFrame = Time.frameCount;
            int tick = Samples.Count;
            if (!UsesGameplayEmission)
            {
                EmitGameplayRound(tick);
            }
            if (tick > _roundTicks.Max() + (int)_plan["captureRate"] * RoundHideSeconds &&
                _animation.IsPlaying(CrawlClip) && _animation[CrawlClip].normalizedTime > 0)
            {
                _observedReturnToCrawl = true;
            }
            CaptureFrame(tick);
            if (Samples.Count >= (int)_plan["captureFrames"])
            {
                Finish();
            }
        }
        catch (Exception exception)
        {
            SessionState.SetBool(SessionKey, false);
            EditorApplication.update -= Update;
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static void StartPlayback()
    {
        _plan = JObject.Parse(File.ReadAllText(RequireEnvironment("WAR_COOP_OBSTACLE_POSE_PLAN")));
        _roundTicks = new HashSet<int>(((JArray)_plan["roundTicks"]).Select(value => (int)value));
        int frameCount = (int)_plan["captureFrames"];
        if ((int)_plan["version"] != 1 || (string)_plan["enemySha256"] != Hash(EnemyPath) ||
            (string)_plan["weaponPrefabGuid"] != AssetDatabase.AssetPathToGUID(WeaponPath) ||
            (string)_plan["startClip"] != "stand_up_begin" || (string)_plan["fireClip"] != "rifle_shot_loop" ||
            _roundTicks.Count == 0 || _roundTicks.Min() <= 0 || _roundTicks.Max() >= frameCount ||
            frameCount > MaximumFrames || (int)_plan["captureRate"] <= 0)
        {
            throw new InvalidOperationException("The host pose plan differs from the recovered rig.");
        }
        Time.captureFramerate = (int)_plan["captureRate"];
        GameObject enemy = GameObject.Find(ProbeName);
        _root = enemy.transform;
        _controller = enemy.GetComponentInChildren<SoldierAnimationController>(true);
        _animation = enemy.GetComponentInChildren<Animation>(true);
        _muzzle = enemy.GetComponentsInChildren<Transform>(true)
            .Single(node => node.name == "MachinegunMuzzleFlash" && node.parent.name == "HK416");
        _parts = FindCollisionParts(enemy);
        string lookMode = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_POSE_LOOK") ?? "disabled";
        if (lookMode != "enabled" && lookMode != "disabled")
        {
            throw new InvalidOperationException("WAR_COOP_OBSTACLE_POSE_LOOK must be enabled or disabled.");
        }
        _controller.disableLookRot = lookMode == "disabled";
        _controller.ForceInScreen();
        _controller.Resume();
        _controller.enabled = true;
        PrimeCrawl();
        _controller.ShootFromCrawl(InitialHideSeconds, ShotSpeed, Weapon.WeaponType.Riffle);
        _startedTime = Time.time;
    }

    private static void PrimeCrawl()
    {
        _animation.cullingType = AnimationCullingType.AlwaysAnimate;
        _animation.Stop();
        _animation.Play(CrawlClip);
        _animation[CrawlClip].normalizedTime = 1f;
        _animation.Sample();
        // Keep normal speed: the controller later replays this same clip to return to crawling.
        _animation[CrawlClip].speed = ShotSpeed;
    }

    private static Collider[] FindCollisionParts(GameObject enemy)
    {
        Transform body = enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001");
        Transform head = enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001/" +
            "cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003");
        var parts = new Collider[]
        {
            body.GetComponent<BoxCollider>(), body.GetComponent<SphereCollider>(), head.GetComponent<SphereCollider>()
        };
        if (parts.Any(part => part == null))
        {
            throw new InvalidOperationException("The recovered collision rig is incomplete.");
        }
        return parts;
    }

    private static void CaptureFrame(int tick)
    {
        Samples.Add(new
        {
            tick,
            unityFrame = Time.frameCount,
            seconds = Time.time - _startedTime,
            scaledTime = Time.time,
            deadlineBeforeShot = _deadlineBeforeShot,
            deadlineAfterShot = (float)CrawlDeadlineField.GetValue(_controller),
            roundInvoked = _roundTicks.Contains(tick),
            muzzle = Values(_root.InverseTransformPoint(_muzzle.position)),
            states = _animation.Cast<AnimationState>().Where(state => state.enabled)
                .Select(state => new { state.name, state.time, state.normalizedTime, state.weight }).ToArray(),
            parts = _parts.Select(part => new
            {
                path = RelativePath(part.transform),
                kind = part is BoxCollider ? "box" : "sphere",
                center = Values(_root.InverseTransformPoint(part.transform.TransformPoint(
                    part is BoxCollider ? ((BoxCollider)part).center : ((SphereCollider)part).center))),
                rotation = Values(Quaternion.Inverse(_root.rotation) * part.transform.rotation),
                size = Values(ColliderSize(part)),
                radius = ColliderRadius(part),
                enabled = part.enabled,
                active = part.gameObject.activeInHierarchy
            }).ToArray()
        });
    }

    private static Vector3 ColliderSize(Collider part)
    {
        BoxCollider box = part as BoxCollider;
        if (box == null)
        {
            return Vector3.zero;
        }
        Vector3 scale = part.transform.lossyScale;
        scale = new Vector3(Mathf.Abs(scale.x), Mathf.Abs(scale.y), Mathf.Abs(scale.z));
        return Vector3.Scale(box.size, scale);
    }

    private static float ColliderRadius(Collider part)
    {
        SphereCollider sphere = part as SphereCollider;
        if (sphere == null)
        {
            return 0;
        }
        Vector3 scale = part.transform.lossyScale;
        float largest = Mathf.Max(Mathf.Abs(scale.x), Mathf.Abs(scale.y), Mathf.Abs(scale.z));
        return sphere.radius * largest;
    }

    private static void Finish()
    {
        if (_roundInvocations != _roundTicks.Count || !_observedReturnToCrawl)
        {
            throw new InvalidOperationException("The controller did not complete every shot and return to crawl.");
        }
        File.WriteAllText(RequireEnvironment("WAR_COOP_OBSTACLE_POSE_OUTPUT"),
            JsonConvert.SerializeObject(new
            {
                version = UsesGameplayEmission ? 5 : ObservationVersion,
                proceduralLookEnabled = !_controller.disableLookRot,
                client = "1.4.0",
                unity = Application.unityVersion,
                prefabSha256 = Hash(EnemyPath),
                controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
                exporterSha256 = Hash("Assets/Editor/UnityCoopObstacleVolleyPoseExport.cs"),
                clips = new[] { "stand_up_begin", "rifle_shot_loop", CrawlClip }.Select(name => new
                {
                    name,
                    sha256 = Hash("Assets/AnimationClip/" + name + ".anim")
                }).ToArray(),
                planSha256 = Hash(RequireEnvironment("WAR_COOP_OBSTACLE_POSE_PLAN")),
                captureRate = (int)_plan["captureRate"],
                samplePhase = "EditorApplication.update; controller uses normal MonoBehaviour.Update",
                roundInvocations = _roundInvocations,
                observedReturnToCrawl = _observedReturnToCrawl,
                samples = Samples
            }, Formatting.Indented));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Update;
        Debug.Log("COOP_OBSTACLE_VOLLEY_POSE_EXPORT_PASSED frames=" + Samples.Count);
        EditorApplication.Exit(0);
    }

    private static string RequireEnvironment(string name)
    {
        string value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidOperationException("Set " + name + ".");
        }
        return value;
    }

    private static string RelativePath(Transform node)
    {
        return node == _root ? "enemy" : RelativePath(node.parent) + "/" + node.name;
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
