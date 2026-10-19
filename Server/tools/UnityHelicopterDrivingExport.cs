using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes source Driving after a completed entry tween without running global gameplay services.</summary>
public static class UnityHelicopterDrivingExport
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string Prefab = "Assets/GameObject/Helicopter.prefab";
    private const string Enemy = "Assets/Scripts/Assembly-CSharp/EnemyController.cs";

    public static void Run()
    {
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_HELICOPTER_DRIVING_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            Helicopter source = AssetDatabase.LoadAssetAtPath<GameObject>(Prefab).GetComponent<Helicopter>();
            var scenarios = new List<object>();
            foreach (EnemyPointHelicopter point in source.enemyPoints)
            {
                scenarios.Add(Capture(source.transform, point.transform));
            }
            string text = JsonConvert.SerializeObject(new
            {
                version = 1, client = "1.4.0", unity = Application.unityVersion,
                fixture = "Inactive unparented source owner, completed entry tween, " +
                    "moving source crew point; no lifecycle.",
                prefabSha256 = Hash(Prefab), enemySha256 = Hash(Enemy),
                tweenSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/TweenRotation.cs"), scenarios
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(output, text);
            Debug.Log("PASS: source Driving observations=" + scenarios.Count * 16);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static object Capture(Transform source, Transform sourcePoint)
    {
        var aircraft = new GameObject("DrivingAircraft");
        aircraft.SetActive(false);
        var target = new GameObject("DrivingPoint");
        target.transform.SetParent(aircraft.transform, false);
        target.transform.localPosition = source.InverseTransformPoint(sourcePoint.position);
        target.transform.localRotation = Quaternion.Inverse(source.rotation) * sourcePoint.rotation;
        EnemyPointHelicopter point = target.AddComponent<EnemyPointHelicopter>();
        var soldier = new GameObject("InactiveDrivingSoldier");
        soldier.SetActive(false);
        EnemyController owner = soldier.AddComponent<EnemyController>();
        owner.mTransform = soldier.transform;
        owner.enemyPoint = point;
        FieldInfo phase = typeof(EnemyController).GetField("mHeliPhase", PrivateInstance);
        phase.SetValue(owner, Enum.Parse(phase.FieldType, "Driving"));
        Quaternion entryTarget = point.transform.rotation;
        TweenRotation tween = TweenRotation.Begin(soldier, 0.3f, entryTarget);
        tween.Sample(1f, true);
        tween.enabled = false;
        Quaternion completedRotation = soldier.transform.rotation;
        object[] frames = CaptureFrames(owner, aircraft.transform, point.transform);
        UnityEngine.Object.DestroyImmediate(soldier);
        UnityEngine.Object.DestroyImmediate(aircraft);
        return new { entryTarget = Values(entryTarget), completedRotation = Values(completedRotation), frames };
    }

    private static object[] CaptureFrames(EnemyController owner, Transform aircraft, Transform point)
    {
        MethodInfo update = typeof(EnemyController).GetMethod("HelicopterUpdate", PrivateInstance);
        var frames = new object[16];
        for (int index = 0; index < frames.Length; index++)
        {
            aircraft.SetPositionAndRotation(new Vector3(index * 0.2f, 10, index * 0.1f),
                Quaternion.Euler(0, index * 7, index * 0.5f));
            update.Invoke(owner, null);
            frames[index] = new
            {
                pointPosition = Values(point.position), pointRotation = Values(point.rotation),
                soldierPosition = Values(owner.transform.position), soldierRotation = Values(owner.transform.rotation)
            };
        }
        return frames;
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
