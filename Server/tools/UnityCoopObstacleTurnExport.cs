using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Observes native agent rotation and the recovered firing tween on a real host route.</summary>
[InitializeOnLoad]
public static class UnityCoopObstacleTurnExport
{
    private const string SessionKey = "WarFriends.ObstacleTurnExport";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const int CaptureRate = 30;
    private const int CaptureFrames = 60;
    private const float TurnSeconds = 0.2f;
    private const float SurfaceRadius = 3f;
    private static readonly List<object> Samples = new List<object>();
    private static NavMeshAgent _agent;
    private static NavMeshDataInstance _mesh;
    private static TweenRotation _turn;
    private static JObject _plan;
    private static float _startTime;
    private static int _lastFrame = -1;

    static UnityCoopObstacleTurnExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += Update;
        }
    }

    /// <summary>Runs only in a disposable full-asset project with the recovered navigation data.</summary>
    public static void Run()
    {
        RequireEnvironment("WAR_COOP_OBSTACLE_TURN_PLAN");
        RequireEnvironment("WAR_COOP_OBSTACLE_TURN_OUTPUT");
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void Update()
    {
        if (!EditorApplication.isPlaying || Time.frameCount == _lastFrame)
        {
            return;
        }

        try
        {
            if (_agent == null)
            {
                StartProbe();
            }

            _lastFrame = Time.frameCount;
            Samples.Add(new
            {
                tick = Samples.Count,
                seconds = Time.time - _startTime,
                position = Values(_agent.transform.position),
                rotation = Values(_agent.transform.rotation),
                velocity = Values(_agent.velocity),
                desiredVelocity = Values(_agent.desiredVelocity),
                tweenEnabled = _turn.enabled
            });
            if (Samples.Count == CaptureFrames)
            {
                Finish();
            }
        }
        catch (Exception exception)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static void StartProbe()
    {
        _plan = JObject.Parse(File.ReadAllText(RequireEnvironment("WAR_COOP_OBSTACLE_TURN_PLAN")));
        if ((int)_plan["version"] != 1 || (string)_plan["asset"] != "Assets/NavMeshData/NavMesh_7.asset" ||
            (string)_plan["enemySha256"] != Hash(EnemyPath))
        {
            throw new InvalidOperationException("The host moving-shot plan does not bind recovered sources.");
        }

        Time.captureFramerate = CaptureRate;
        NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>((string)_plan["asset"]);
        _mesh = NavMesh.AddNavMeshData(data);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        NavMeshAgent source = prefab.GetComponent<NavMeshAgent>();
        var actor = new GameObject("DisposableObstacleTurnProbe");
        _agent = actor.AddComponent<NavMeshAgent>();
        _agent.radius = source.radius;
        _agent.height = source.height;
        _agent.speed = (float)_plan["speed"];
        _agent.acceleration = source.acceleration;
        _agent.angularSpeed = source.angularSpeed;
        _agent.stoppingDistance = source.stoppingDistance;
        _agent.autoBraking = source.autoBraking;
        _agent.autoRepath = source.autoRepath;
        _agent.autoTraverseOffMeshLink = source.autoTraverseOffMeshLink;
        _agent.avoidancePriority = source.avoidancePriority;
        _agent.baseOffset = source.baseOffset;
        _agent.areaMask = source.areaMask;
        _agent.obstacleAvoidanceType = source.obstacleAvoidanceType;
        NavMeshHit start;
        NavMeshHit end;
        if (!NavMesh.SamplePosition(Vector(_plan["start"]), out start, SurfaceRadius, NavMesh.AllAreas) ||
            !NavMesh.SamplePosition(Vector(_plan["end"]), out end, SurfaceRadius, NavMesh.AllAreas) ||
            !_agent.Warp(start.position) || !_agent.SetDestination(end.position))
        {
            throw new InvalidOperationException("The host obstacle route is not on the recovered mesh.");
        }

        actor.transform.rotation = Rotation(_plan["startRotation"]);
        _turn = TweenRotation.Begin(actor, TurnSeconds, Rotation(_plan["targetRotation"]));
        _turn.ignoreTimeScale = false;
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_TURN_PHASE_OUTPUT")))
        {
            actor.AddComponent<UnityCoopObstacleTurnPhaseProbe>().Initialize(_agent);
        }
        _startTime = Time.time;
    }

    private static void Finish()
    {
        File.WriteAllText(RequireEnvironment("WAR_COOP_OBSTACLE_TURN_OUTPUT"),
            JsonConvert.SerializeObject(new
            {
                version = 2,
                unity = Application.unityVersion,
                planSha256 = Hash(RequireEnvironment("WAR_COOP_OBSTACLE_TURN_PLAN")),
                exporterSha256 = Hash("Assets/Editor/UnityCoopObstacleTurnExport.cs"),
                phaseProbeSha256 = Hash("Assets/UnityCoopObstacleTurnPhaseProbe.cs"),
                navMeshSha256 = Hash((string)_plan["asset"]),
                tweenSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/TweenRotation.cs"),
                captureRate = CaptureRate,
                angularSpeed = _agent.angularSpeed,
                samples = Samples
            }, Formatting.Indented));
        _mesh.Remove();
        SessionState.SetBool(SessionKey, false);
        Debug.Log("COOP_OBSTACLE_TURN_EXPORT_PASSED frames=" + Samples.Count);
        EditorApplication.Exit(0);
    }

    private static Vector3 Vector(JToken values)
    {
        return new Vector3((float)values[0], (float)values[1], (float)values[2]);
    }

    private static Quaternion Rotation(JToken values)
    {
        return new Quaternion((float)values[0], (float)values[1], (float)values[2], (float)values[3]);
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

    private static string RequireEnvironment(string name)
    {
        string value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidOperationException("Set " + name + ".");
        }

        return value;
    }
}
