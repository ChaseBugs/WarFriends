using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;

/// <summary>Checks actual solo pool commands without a bound PhotonView or SDK room.</summary>
[InitializeOnLoad]
public static class UnityLocalPoolAudit
{
    private const string SessionKey = "WarFriends.LocalPoolAudit";
    private const int PrefabIndex = 0;
    private const int LocalObjectIndex = 0;
    private const int LastObjectIndex = 1;
    private const int CommandVariantCount = 4;
    private static readonly List<string> Errors = new List<string>();

    static UnityLocalPoolAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += VerifyWhenPlaying;
        }
    }

    /// <summary>Uses an inactive recovered scene pool with controlled plain pooled objects.</summary>
    public static void Run()
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        foreach (GameObject root in scene.GetRootGameObjects())
        {
            root.SetActive(false);
        }
        SessionState.SetBool(SessionKey, true);
        EditorApplication.update += VerifyWhenPlaying;
        EditorApplication.isPlaying = true;
    }

    private static void VerifyWhenPlaying()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        EditorApplication.update -= VerifyWhenPlaying;
        Errors.Clear();
        Application.logMessageReceived += CaptureError;
        try
        {
            VerifyCommands();
            Require(Errors.Count == 0, "Unexpected pool errors: " + string.Join(" | ", Errors.ToArray()));
            Debug.Log("LOCAL_SOLO_POOL_AUDIT_PASSED");
            Finish(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            Finish(1);
        }
        finally
        {
            Application.logMessageReceived -= CaptureError;
        }
    }

    private static void VerifyCommands()
    {
        var room = (LocalOfflineRoom)typeof(PhotonConnectionManager).GetField("mLocalOfflineRoom",
            BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
        Require(SelfHostedBattleClient.Active == null && !room.IsOffline && !PhotonNetwork.offlineMode,
            "The fixture must not replace a live battle or SDK room.");
        var owner = new GameObject("InactiveLocalPoolFixture");
        owner.SetActive(false);
        try
        {
            // The recovered RequireComponent names abstract PhotonNetwork; use its existing serialized pool.
            NetworkObjectPool pool = Array.Find(Resources.FindObjectsOfTypeAll<NetworkObjectPool>(),
                candidate => candidate.gameObject.scene.IsValid());
            Require(pool != null && !pool.gameObject.activeInHierarchy,
                "The inactive recovered scene pool was not found.");
            pool.Entries = new List<ObjectPool.ObjectPoolEntry>();
            typeof(ObjectPool).GetField("mIsInitialized", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(pool, true);
            var prefab = CreateObject(owner.transform, "Prefab");
            var first = CreateObject(owner.transform, "FirstPooledObject");
            var last = CreateObject(owner.transform, "LastPooledObject");
            first.prefab = last.prefab = prefab;
            first.indexInObjectPool = LocalObjectIndex;
            last.indexInObjectPool = LastObjectIndex;
            pool.prefabToIndexDic = new Dictionary<PoolableObject, int> { { prefab, PrefabIndex } };
            pool.pooledObjects = new Dictionary<int, List<PoolableObject>>
            {
                { PrefabIndex, new List<PoolableObject> { first, last } }
            };
            room.ObserveJoinedOfflineRoom();
            VerifyVariants(pool, prefab, first);
            Require(!PhotonNetwork.offlineMode, "Solo pool commands enabled a legacy SDK room.");
        }
        finally
        {
            room.Disconnect();
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifyVariants(NetworkObjectPool pool, PoolableObject prefab, PoolableObject first)
    {
        Vector3 position = new Vector3(2f, 3f, 4f);
        Quaternion rotation = Quaternion.Euler(0f, 45f, 0f);
        for (int variant = 0; variant < CommandVariantCount; variant++)
        {
            pool.freePooledObjects = new Dictionary<int, LinkedList<int>>
            {
                { PrefabIndex, new LinkedList<int>(new[] { LocalObjectIndex, LastObjectIndex }) }
            };
            first.transform.SetPositionAndRotation(position, rotation);
            PoolableObject result;
            switch (variant)
            {
                case 0: result = pool.InstantiateNetwork(prefab); break;
                case 1: result = pool.InstantiateNetwork(prefab, position, rotation); break;
                case 2: result = pool.ReInstantiateNetwork(first); break;
                default: result = pool.ReInstantiateNetwork(first, position, rotation); break;
            }

            Vector3 expectedPosition = variant == 0 ? Vector3.zero : position;
            Quaternion expectedRotation = variant == 0 ? Quaternion.identity : rotation;
            Require(result == first && first.isInstantiated && first.gameObject.activeSelf &&
                first.transform.position == expectedPosition && first.transform.rotation == expectedRotation &&
                pool.freePooledObjects[PrefabIndex].Count == 1,
                "Solo pool variant lost source identity, pose or free-list consumption: " + variant);
        }
    }

    private static PoolableObject CreateObject(Transform parent, string objectName)
    {
        var root = new GameObject(objectName);
        root.transform.parent = parent;
        return root.AddComponent<PoolableObject>();
    }

    private static void CaptureError(string message, string stack, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
        {
            Errors.Add(message);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static void Finish(int exitCode)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.Exit(exitCode);
    }
}
