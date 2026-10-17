using System;
using System.Linq;
using System.Reflection;
using Google.Protobuf;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks negotiated protobuf pose references through the production adapter and presenter.</summary>
public static class UnityObservedPosePresenterAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const int ObservationsPerPhase = 13;
    private static Action<Transform, JObject, uint> _compare;

    /// <summary>Compares every supported reference with independent source poses on the displayed actor.</summary>
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
            Type audit = typeof(UnityObservedInfantryRendererAudit);
            JObject source = (JObject)audit.GetMethod("ReadReference", Flags).Invoke(null, null);
            _compare = (Action<Transform, JObject, uint>)Delegate.CreateDelegate(
                typeof(Action<Transform, JObject, uint>), audit.GetMethod("Compare", Flags));
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            owner = new GameObject("ObservedPosePresenterAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
            typeof(SelfHostedBattleClient).GetField("_observedPoseCatalogRevision",
                BindingFlags.NonPublic | BindingFlags.Instance).SetValue(client,
                    ObservedInfantryPoseCatalogData.BuiltIn.Revision);
            Publish(client, (JObject)source["samples"][0], 0);
            SelfHostedCoopInfantryPresenter presenter = owner.AddComponent<SelfHostedCoopInfantryPresenter>();
            presenter.Configure(components.OfType<ObjectPoolDatabase>().Single().enemy, manager, client);
            int index = 0;
            foreach (JObject sample in source["samples"])
            {
                Publish(client, sample, index++);
                Verify(sample);
            }

            JObject interrupted = source["samples"].OfType<JObject>().First(sample =>
                (int)sample["priorReturnTicks"] == 3 && (int)sample["observationTick"] == 1);
            Publish(client, interrupted, index++);
            VerifyWalkingReturn(client, components.OfType<ObjectPoolDatabase>().Single().enemy, manager, index);
            Debug.Log("PASS: 221 negotiated source pose references through production adapter/presenter; " +
                "clip return restores a fresh basis; no live Worker or rendered-pixel proof.");
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

    private static void Publish(SelfHostedBattleClient client, JObject source, int index)
    {
        const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
        MatchSnapshot snapshot = (MatchSnapshot)typeof(UnityCoopWalkingVisualAudit)
            .GetMethod("CreateSnapshot", Flags).Invoke(null, null);
        snapshot.ServerTick += (ulong)index;
        snapshot.Coop.DeadlineTick = 10000;
        BattleCoopEnemySpawn enemy = snapshot.Coop.EnemySpawns[0];
        enemy.InfantryVisualClip = "";
        enemy.InfantryVisualStartTick = 0;
        enemy.InfantryVisualSampleTick = 0;
        enemy.PoseTick = snapshot.ServerTick;
        uint id = (uint)((int)source["priorReturnTicks"] * ObservationsPerPhase +
            (int)source["observationTick"] + 1);
        var reference = new BattleInfantryObservedPoseReference
        {
            CatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision, SampleId = id
        };
        enemy.InfantryAnimation = new BattleInfantryAnimationFrame
        {
            SampleTick = snapshot.ServerTick, ObservedPose = reference
        };
        enemy.InfantryAnimation.Clips.AddRange(ObservedInfantryPoseCatalogData.BuiltIn.GetSample(reference).Clips);
        ApplySnapshot(client, snapshot);
    }

    private static void ApplySnapshot(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(client, new object[]
            {
                new MatchReply
                {
                    Code = "state", Snapshot = decoded,
                    ObservedPoseCatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision
                }
            });
    }

    private static void VerifyWalkingReturn(
        SelfHostedBattleClient client, EnemyController source, LevelBehaviourManager manager, int index)
    {
        const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
        MatchSnapshot snapshot = (MatchSnapshot)typeof(UnityCoopWalkingVisualAudit)
            .GetMethod("CreateSnapshot", Flags).Invoke(null, null);
        snapshot.ServerTick += (ulong)index;
        snapshot.Coop.DeadlineTick = 10000;
        BattleCoopEnemySpawn enemy = snapshot.Coop.EnemySpawns[0];
        enemy.InfantryVisualClip = "";
        enemy.InfantryVisualStartTick = 0;
        enemy.InfantryVisualSampleTick = 0;
        enemy.PoseTick = snapshot.ServerTick;
        enemy.InfantryAnimation.SampleTick = snapshot.ServerTick;
        ApplySnapshot(client, snapshot);
        SoldierBehaviourAssaulter family = manager.levelBehaviours.Select(entry => entry.behaviour)
            .OfType<SoldierBehaviourAssaulter>().First();
        SelfHostedInfantryVisual fresh = SelfHostedInfantryVisualFactory.CreateWithAppearance(source,
            family.soldierVisuals[0], SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                family, new UpgradeSlots.UnitUpgrades()), "FreshWalkingComparison");
        try
        {
            var sampler = new SelfHostedInfantryAnimationSampler(
                fresh.AnimationRoot, source.GetComponentInChildren<Animation>(true));
            sampler.Sample(new[] { new SelfHostedInfantryAnimationState("run_0", 0.4f, 1f, WrapMode.Loop) });
            JObject rig = JObject.FromObject(UnityCoopRigFrameCapture.Capture(
                fresh.Root.transform.GetChild(0), fresh.AnimationRoot.GetComponent<Animation>()));
            Verify(new JObject { ["observationTick"] = 0, ["rig"] = rig });
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(fresh.Root);
        }
    }

    private static void Verify(JObject sample)
    {
        GameObject actor = GameObject.Find("SelfHostedCoopInfantry_1");
        Transform rig = actor.transform.GetChild(0);
        foreach (JObject expected in sample["rig"]["transforms"])
        {
            string path = (string)expected["path"];
            if (path == "root" || (string)expected["name"] == "AK47_lp")
            {
                // Model pivot/scale follow the separate source appearance selector, tested by its own matrix.
                continue;
            }

            Transform current = rig;
            string[] segments = path.Split('/');
            for (int index = 1; index < segments.Length; index++)
            {
                current = current.GetChild(int.Parse(segments[index]));
            }

            _compare(current, expected, (uint)sample["observationTick"]);
        }
    }
}
