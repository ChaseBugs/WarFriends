using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Samples missing grenade target and weapon-root transforms in a disposable Client copy.</summary>
public static class UnityGrenadeRigExport
{
    private const string ScenePath = "Assets/Scenes/MainScene.unity";
    private const string OutputVariable = "WAR_GRENADE_RIG_OUTPUT";
    private const string BindingsVariable = "WAR_GRENADE_RIG_BINDINGS";
    private const string ValidationMarker = "/Server/.local/";
    private const int SampleRate = 30;
    private const int WeaponCount = 66;
    private const int InventoryCount = 67;
    private const int TargetCount = 5;
    private const int MovingTargetType = 16;
    private const float MaximumClipSeconds = 60;
    private static readonly string[] ClipNames =
    {
        "throw_grenade_left", "throw_grenade_right", "grenade_run", "grenade_idle",
        "player_look_left_grenadelauncher", "player_fire_left_grenadelauncher",
        "player_left_coverBack_grenadelauncher", "player_look_right_grenadelauncher",
        "player_fire_right_grenadelauncher", "player_right_coverBack_grenadelauncher",
        "run_grenadelauncher", "grenadelauncher_idle"
    };

    /// <summary>Exports observed transforms without saving the scene or starting gameplay.</summary>
    public static void Run()
    {
        string outputPath = ValidateOutputPath();
        string bindingsPath = Environment.GetEnvironmentVariable(BindingsVariable);
        if (string.IsNullOrEmpty(bindingsPath))
        {
            throw new InvalidOperationException("Set " + BindingsVariable + ".");
        }
        var previous = EditorSceneManager.GetSceneManagerSetup();
        try
        {
            JObject reference = JObject.Parse(File.ReadAllText(bindingsPath));
            ExportSources sources = ReadSources(reference);
            object result = CreateExport(sources, reference, bindingsPath);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            File.WriteAllText(outputPath, JsonConvert.SerializeObject(result, Formatting.None) + "\n",
                new UTF8Encoding(false));
            Debug.Log("UNITY_GRENADE_RIG_EXPORT_PASSED clips=" + ClipNames.Length + " weapons=" + WeaponCount);
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogError(error);
            EditorApplication.Exit(1);
            throw;
        }
        finally
        {
            if (previous.Any(scene => scene.isActive && scene.isLoaded) &&
                previous.All(scene => !string.IsNullOrEmpty(scene.path)))
            {
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            }
            else
            {
                EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            }
        }
    }

    private static string ValidateOutputPath()
    {
        string requested = Environment.GetEnvironmentVariable(OutputVariable);
        if (string.IsNullOrEmpty(requested))
        {
            throw new InvalidOperationException("Set " + OutputVariable + ".");
        }
        string project = Path.GetFullPath(Application.dataPath).Replace('\\', '/');
        int marker = project.IndexOf(ValidationMarker, StringComparison.OrdinalIgnoreCase);
        string output = Path.GetFullPath(requested).Replace('\\', '/');
        if (marker < 0 || !output.StartsWith(project.Substring(0, marker + ValidationMarker.Length),
            StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Use a disposable project and output under the same Server/.local.");
        }
        return output;
    }

    private static ExportSources ReadSources(JObject reference)
    {
        var scene = EditorSceneManager.OpenScene(ScenePath);
        PlayerController player = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var shootable = player.GetComponent<GameShootableEntityPlayer>();
        var animation = player.GetComponentInChildren<SoldierAnimationController>(true).GetComponent<Animation>();
        var levels = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<LevelManager>(true)).Single();
        var inventory = player.GetComponentsInChildren<WeaponInventory>(true).Single();
        if (shootable == null || shootable.targets == null || shootable.targets.Count != TargetCount ||
            levels.weaponLevelsSetups.Count != WeaponCount || inventory.allWeapons.Count != InventoryCount)
        {
            throw new InvalidOperationException("The complete source player targets and weapon lists are required.");
        }
        SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
        var sources = new ExportSources { Player = player, Shootable = shootable, Animation = animation };
        var rows = new List<object>();
        var roots = new List<Transform>();
        var bindings = ((JArray)reference["weapons"]).ToDictionary(row => (string)row["id"], StringComparer.Ordinal);
        var identities = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < levels.weaponLevelsSetups.Count; index++)
        {
            WeaponLevelsSetup level = levels.weaponLevelsSetups[index];
            string sourceId = level.GetComponent<Google2uComponentBase>().GetType().ToString();
            int inventoryIndex = level.indexInWeaponInventory;
            Transform weapon = inventory.allWeapons[inventoryIndex].transform;
            JToken binding;
            if (!identities.Add(sourceId) || !bindings.TryGetValue(sourceId, out binding) ||
                (int)binding["inventoryIndex"] != inventoryIndex || (string)binding["weaponPath"] != PathOf(weapon))
            {
                throw new InvalidOperationException("A weapon identity or root differs from the reviewed binding graph.");
            }
            rows.Add(new { sourceId, levelManagerIndex = index, inventoryIndex, path = PathOf(weapon) });
            roots.Add(weapon);
        }
        if (bindings.Count != identities.Count)
        {
            throw new InvalidOperationException("The binding graph contains an unmatched source weapon.");
        }
        sources.WeaponRows = rows.ToArray();
        sources.WeaponRoots = roots.ToArray();
        return sources;
    }

    private static object CreateExport(ExportSources sources, JObject reference, string bindingsPath)
    {
        var targets = sources.Shootable.targets.Select((target, index) => new
        {
            index, type = (int)target.type, path = PathOf(target.transform)
        }).ToArray();
        int movingIndex = targets.Single(target => target.type == MovingTargetType).index;
        return new
        {
            schemaVersion = 1, clientVersion = "1.4.0", unityVersion = Application.unityVersion,
            source = ScenePath, sceneSha256 = Hash(ScenePath), bindingArtifactSha256 = Hash(bindingsPath),
            bindingSceneSha256 = (string)reference["sha256"], sampleRate = SampleRate,
            matrixLayout = "unity-row-major", playerPath = PathOf(sources.Player.transform),
            weapons = sources.WeaponRows, targets, movingTargetIndex = movingIndex, clips = CaptureClips(sources)
        };
    }

    private static object[] CaptureClips(ExportSources sources)
    {
        var clips = new List<object>();
        foreach (string name in ClipNames)
        {
            AnimationState state = sources.Animation[name];
            if (state == null || state.length <= 0 || state.length > MaximumClipSeconds)
            {
                throw new InvalidOperationException("Missing or invalid grenade clip " + name + ".");
            }
            string guid;
            long fileId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(state.clip, out guid, out fileId))
            {
                throw new InvalidOperationException("The grenade clip has no asset identity.");
            }
            string path = AssetDatabase.GetAssetPath(state.clip);
            var frames = new List<object>();
            int last = Mathf.CeilToInt(state.length * SampleRate);
            for (int index = 0; index <= last; index++)
            {
                Sample(sources.Animation, "T_pose", 1);
                float seconds = Mathf.Min(index / (float)SampleRate, state.length);
                Sample(sources.Animation, name, seconds / state.length);
                frames.Add(new
                {
                    seconds, root = CaptureTransform(sources.Player.transform),
                    weapons = sources.WeaponRoots.Select(CaptureTransform).ToArray(),
                    targets = sources.Shootable.targets.Select(target => CaptureTransform(target.transform)).ToArray()
                });
            }
            clips.Add(new { name, source = path, guid, fileId, sha256 = Hash(path), length = state.length, frames });
        }
        return clips.ToArray();
    }

    private static void Sample(Animation animation, string name, float normalizedTime)
    {
        animation.Stop();
        AnimationState state = animation[name];
        state.enabled = true;
        state.weight = 1;
        state.normalizedTime = normalizedTime;
        animation.Sample();
        state.enabled = false;
    }

    private static object CaptureTransform(Transform transform)
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        Matrix4x4 matrix = transform.localToWorldMatrix;
        return new
        {
            position = new[] { position.x, position.y, position.z },
            rotation = new[] { rotation.x, rotation.y, rotation.z, rotation.w },
            matrix = new[] { matrix.m00, matrix.m01, matrix.m02, matrix.m03, matrix.m10, matrix.m11, matrix.m12, matrix.m13,
                matrix.m20, matrix.m21, matrix.m22, matrix.m23, matrix.m30, matrix.m31, matrix.m32, matrix.m33 }
        };
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

    private static string PathOf(Transform transform)
    {
        return transform.parent == null ? transform.name : PathOf(transform.parent) + "/" + transform.name;
    }

    private sealed class ExportSources
    {
        public PlayerController Player { get; set; }
        public GameShootableEntityPlayer Shootable { get; set; }
        public Animation Animation { get; set; }
        public object[] WeaponRows { get; set; }
        public Transform[] WeaponRoots { get; set; }
    }
}
