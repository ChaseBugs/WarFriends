using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks an actual controlled server snapshot through the SDK and production Unity presenter.</summary>
public static class UnityObservedHostSnapshotAudit
{
    /// <summary>Compares the host-selected observed pose with its independent automatic source capture.</summary>
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            MatchReply reply = MatchReply.Parser.ParseFrom(File.ReadAllBytes(
                Environment.GetEnvironmentVariable("WAR_OBSERVED_HOST_FRAME_OUTPUT")));
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            owner = new GameObject("ObservedHostSnapshotAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(
                client, reply.Snapshot.Coop.SceneMasterPlayerId, null);
            typeof(SelfHostedBattleClient).GetField("_observedPoseCatalogRevision",
                BindingFlags.Instance | BindingFlags.NonPublic).SetValue(client,
                    ObservedInfantryPoseCatalogData.BuiltIn.Revision);
            typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(client, new object[] { reply });
            SelfHostedCoopInfantryPresenter presenter = owner.AddComponent<SelfHostedCoopInfantryPresenter>();
            presenter.Configure(components.OfType<ObjectPoolDatabase>().Single().enemy,
                components.OfType<LevelBehaviourManager>().Single(), client);
            BattleCoopEnemySpawn enemy = reply.Snapshot.Coop.EnemySpawns.First(row =>
                row.InfantryAnimation != null && row.InfantryAnimation.ObservedPose != null);
            Verify(enemy);
            Debug.Log("PASS: controlled host snapshot -> SDK -> Unity observed pose matches source; " +
                "no UDP or normal gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static void Verify(BattleCoopEnemySpawn enemy)
    {
        const BindingFlags Flags = BindingFlags.Static | BindingFlags.NonPublic;
        Type audit = typeof(UnityObservedInfantryRendererAudit);
        JObject source = (JObject)audit.GetMethod("ReadReference", Flags).Invoke(null, null);
        ObservedInfantryPoseSample sample = ObservedInfantryPoseCatalogData.BuiltIn.GetSample(
            enemy.InfantryAnimation.ObservedPose);
        JObject expected = source["samples"].OfType<JObject>().Single(row =>
            (uint)row["priorReturnTicks"] == sample.PriorReturnTicks &&
            (uint)row["observationTick"] == sample.ObservationTick);
        var compare = (Action<Transform, JObject, uint>)Delegate.CreateDelegate(
            typeof(Action<Transform, JObject, uint>), audit.GetMethod("Compare", Flags));
        GameObject actor = GameObject.Find("SelfHostedCoopInfantry_" + enemy.EntityId);
        Transform rig = actor.transform.GetChild(0);
        foreach (JObject transform in expected["rig"]["transforms"])
        {
            string path = (string)transform["path"];
            if (path == "root" || (string)transform["name"] == "AK47_lp")
            {
                continue;
            }

            Transform actual = rig;
            foreach (string segment in path.Split('/').Skip(1))
            {
                actual = actual.GetChild(int.Parse(segment));
            }

            compare(actual, transform, sample.Id);
        }
    }
}
