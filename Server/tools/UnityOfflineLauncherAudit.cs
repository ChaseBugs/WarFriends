using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks compiled launcher boundaries, restored fields and enabled-scene script attachments.</summary>
public static class UnityOfflineLauncherAudit
{
    private const string LauncherGuid = "afa63b05fddc8fcf6a0d6b94cf2a11ce";
    private static readonly HashSet<string> RetiredTypes = new HashSet<string>
    {
        "Terms", "FuseSDK", "GooglePlayGameService", "GameCenterProvider", "GooglePlayDownloader",
        "Crittercism", "CrittercismAndroid", "CrittercismIOS", "NoodlePermissionGranter",
        "Kochava", "AndroidJavaClass", "AndroidJavaObject"
    };
    private static readonly Dictionary<short, OpCode> Instructions = typeof(OpCodes)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(field => field.FieldType == typeof(OpCode))
        .Select(field => (OpCode)field.GetValue(null)).ToDictionary(opcode => opcode.Value);
    private const BindingFlags DeclaredMembers = BindingFlags.DeclaredOnly | BindingFlags.Public |
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>Requires a disposable project and writes evidence without saving any recovered scene.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }

        int methods = VerifyCompiledType(typeof(GameLauncher));
        int telemetryMethods = VerifyCompiledType(typeof(Crittercism));
        if (!Crittercism.GetOptOut())
        {
            throw new InvalidOperationException("Retired crash telemetry must always be opted out.");
        }
        Crittercism.SetOptOut(false);
        if (!Crittercism.GetOptOut())
        {
            throw new InvalidOperationException("A legacy caller cannot reactivate retired crash telemetry.");
        }
        int scenes = VerifyScenes();
        VerifyLauncherFields();
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "offline-launcher-audit.json");
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            scope = "Compiled GameLauncher/nested IL, enabled-scene scripts and Splash fields; no network trace.",
            unityVersion = Application.unityVersion,
            methodsChecked = methods,
            telemetryMethodsChecked = telemetryMethods,
            telemetryAlwaysOptedOut = true,
            enabledScenesChecked = scenes,
            launcherGuid = LauncherGuid,
            serializedFieldsChecked = 8,
            missingScripts = 0,
            retiredProviderReferencesInLauncher = 0,
            legacyDownloadFlagRead = false
        }, Formatting.Indented) + "\n");
        Debug.Log("UNITY_OFFLINE_LAUNCHER_AUDIT_PASSED methods=" + methods +
            " telemetryMethods=" + telemetryMethods + " scenes=" + scenes);
    }

    private static int VerifyCompiledType(Type root)
    {
        int methods = 0;
        foreach (Type type in EnumerateTypes(root))
        {
            IEnumerable<MethodBase> members = type.GetMethods(DeclaredMembers).Cast<MethodBase>()
                .Concat(type.GetConstructors(DeclaredMembers));
            foreach (MethodBase method in members)
            {
                MethodBody body = method.GetMethodBody();
                if (body == null)
                {
                    continue;
                }

                VerifyInstructions(method, body.GetILAsByteArray());
                methods++;
            }
        }

        return methods;
    }

    private static IEnumerable<Type> EnumerateTypes(Type root)
    {
        yield return root;
        foreach (Type nested in root.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
        {
            foreach (Type descendant in EnumerateTypes(nested))
            {
                yield return descendant;
            }
        }
    }

    private static void VerifyInstructions(MethodBase method, byte[] bytes)
    {
        int position = 0;
        while (position < bytes.Length)
        {
            short value = bytes[position++];
            if (value == 0xfe)
            {
                value = unchecked((short)(0xfe00 | bytes[position++]));
            }

            OpCode instruction = Instructions[value];
            if (instruction.OperandType == OperandType.InlineMethod ||
                instruction.OperandType == OperandType.InlineField ||
                instruction.OperandType == OperandType.InlineType ||
                instruction.OperandType == OperandType.InlineTok)
            {
                MemberInfo target = method.Module.ResolveMember(BitConverter.ToInt32(bytes, position));
                VerifyTarget(method, target);
            }

            position += OperandBytes(instruction.OperandType, bytes, position);
        }
    }

    private static void VerifyTarget(MethodBase caller, MemberInfo target)
    {
        Type owner = target as Type ?? target.DeclaringType;
        while (owner != null)
        {
            bool isRetainedTelemetrySelf = owner == typeof(Crittercism) &&
                caller.DeclaringType == typeof(Crittercism);
            if (RetiredTypes.Contains(owner.Name) && !isRetainedTelemetrySelf)
            {
                throw new InvalidOperationException(caller.Name + " retains provider dependency " + owner.FullName);
            }

            owner = owner.DeclaringType;
        }

        if (target is FieldInfo && target.DeclaringType == typeof(GameLauncher) && target.Name == "downloadOBB")
        {
            throw new InvalidOperationException("The legacy download flag still gates compiled launcher behavior.");
        }
    }

    private static int OperandBytes(OperandType operand, byte[] bytes, int position)
    {
        switch (operand)
        {
            case OperandType.InlineNone: return 0;
            case OperandType.ShortInlineBrTarget:
            case OperandType.ShortInlineI:
            case OperandType.ShortInlineVar: return 1;
            case OperandType.InlineVar: return 2;
            case OperandType.InlineI8:
            case OperandType.InlineR: return 8;
            case OperandType.InlineSwitch: return checked(4 + 4 * BitConverter.ToInt32(bytes, position));
            default: return 4;
        }
    }

    private static int VerifyScenes()
    {
        int count = 0;
        foreach (EditorBuildSettingsScene entry in EditorBuildSettings.scenes.Where(scene => scene.enabled))
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.OpenScene(entry.path);
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                if (root.GetComponentsInChildren<MonoBehaviour>(true).Any(component => component == null))
                {
                    throw new InvalidOperationException("Missing script in enabled scene " + entry.path);
                }
            }

            count++;
        }

        if (count != 12)
        {
            throw new InvalidOperationException("The recovered twelve-scene build set changed.");
        }

        return count;
    }

    private static void VerifyLauncherFields()
    {
        string[] expected = { "chillingoLogo", "ourLogo", "splashes", "downloadAssetsDialog",
            "downloadOBB", "logo", "splashCamera", "scales" };
        string[] actual = typeof(GameLauncher).GetFields(BindingFlags.Public | BindingFlags.Instance |
            BindingFlags.DeclaredOnly).Select(field => field.Name).OrderBy(name => name).ToArray();
        if (!actual.SequenceEqual(expected.OrderBy(name => name)))
        {
            throw new InvalidOperationException("Recovered launcher serialization fields changed.");
        }

        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity");
        GameLauncher launcher = UnityEngine.Object.FindObjectOfType<GameLauncher>();
        string path = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(launcher));
        if (AssetDatabase.AssetPathToGUID(path) != LauncherGuid || launcher.chillingoLogo == null ||
            launcher.ourLogo == null || launcher.splashes == null || launcher.downloadAssetsDialog == null ||
            launcher.logo == null || launcher.splashCamera == null || launcher.scales == null ||
            launcher.scales.Count == 0)
        {
            throw new InvalidOperationException("Restored Splash object references or source identity changed.");
        }
    }
}
