using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks host-clock walking samples on recovered meshes without enabling source enemy simulation.</summary>
public static class UnityCoopWalkingVisualAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private static int _checks;

    /// <summary>
    /// Exercises the production adapter, presenter, source assets and teardown in a disposable Editor.
    /// </summary>
    public static void Run()
    {
        _checks = 0;
        GameObject owner = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            ObjectPoolDatabase pool = components.OfType<ObjectPoolDatabase>().Single();
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            owner = new GameObject("CoopWalkingVisualAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
            Publish(client, CreateSnapshot());
            SelfHostedCoopInfantryPresenter presenter = owner.AddComponent<SelfHostedCoopInfantryPresenter>();
            presenter.Configure(pool.enemy, manager, client);
            VerifyMotionAndUnknownState(client);
            VerifyLifecycle(client, presenter);
            File.WriteAllText(Path.Combine(Application.dataPath, "../coop-walking-visual-audit.json"),
                "{\"schemaVersion\":1,\"checks\":" + _checks + ",\"scope\":\"source walking mesh samples\"}\n");
            Debug.Log("PASS: " + _checks + " co-op walking visual checks; no local AI, combat or rendered pixels.");
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

    private static void VerifyMotionAndUnknownState(SelfHostedBattleClient client)
    {
        GameObject actor = GameObject.Find("SelfHostedCoopInfantry_1");
        Require(actor != null, "A supported confirmed walking frame must create the source actor.");
        SkinnedMeshRenderer skin = actor.GetComponentInChildren<SkinnedMeshRenderer>(true);
        Require(skin != null && skin.sharedMesh != null &&
            actor.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
            actor.GetComponentsInChildren<Collider>(true).Length == 0 &&
            actor.GetComponentsInChildren<Rigidbody>(true).Length == 0,
            "The walking visual must retain a real source skin without AI or collision components.");
        Quaternion[] before = skin.bones.Select(bone => bone.localRotation).ToArray();
        MatchSnapshot next = CreateSnapshot();
        next.ServerTick = 23;
        next.Coop.EnemySpawns[0].PoseTick = 23;
        next.Coop.EnemySpawns[0].InfantryVisualSampleTick = 23;
        next.Coop.EnemySpawns[0].CurrentX = 4;
        Publish(client, next);
        Require(GameObject.Find(actor.name) == actor && actor.transform.position.x == 4f,
            "A later host frame must reuse the actor and place it at the confirmed position.");
        Require(skin.bones.Where((bone, index) => Quaternion.Angle(bone.localRotation, before[index]) > 0.001f).Any(),
            "A later host clip clock must change the copied source bone pose.");
        MatchSnapshot unsupported = next.Clone();
        ClearAnimation(unsupported.Coop.EnemySpawns[0]);
        Publish(client, unsupported);
        Require(!actor.activeSelf, "An unrepresented state must hide the rig instead of inventing an idle pose.");
        Publish(client, next);
        Require(GameObject.Find(actor.name) == actor, "Supported presentation must resume its cached appearance.");
    }

    private static void VerifyLifecycle(SelfHostedBattleClient client, SelfHostedCoopInfantryPresenter presenter)
    {
        presenter.enabled = false;
        InvokeLifecycle(presenter, "OnDisable");
        Require(GameObject.Find("SelfHostedCoopInfantry_1") == null, "Disable must destroy owned visual roots.");
        Publish(client, client.State.Clone());
        Require(GameObject.Find("SelfHostedCoopInfantry_1") == null, "Disabled presenters must unsubscribe.");
        presenter.enabled = true;
        InvokeLifecycle(presenter, "OnEnable");
        Require(GameObject.Find("SelfHostedCoopInfantry_1") != null, "Enable must replay the current view.");
        MatchSnapshot death = client.State.Clone();
        BattleCoopEnemySpawn enemy = death.Coop.EnemySpawns[0];
        enemy.Health = 0;
        enemy.DeathTick = death.ServerTick;
        death.Coop.EnemyKills = 1;
        ClearAnimation(enemy);
        Publish(client, death);
        Require(GameObject.Find("SelfHostedCoopInfantry_1") == null,
            "Confirmed body death must retire its walking rig.");
        MatchSnapshot spawn = death.Clone();
        BattleCoopEnemySpawn second = CreateSnapshot().Coop.EnemySpawns[0].Clone();
        spawn.ServerTick++;
        second.EntityId = 2;
        second.SpawnTick = spawn.ServerTick;
        second.PoseTick = spawn.ServerTick;
        second.InfantryVisualStartTick = spawn.ServerTick;
        second.InfantryVisualSampleTick = spawn.ServerTick;
        spawn.Coop.EnemySpawns.Add(second);
        Publish(client, spawn);
        Require(GameObject.Find("SelfHostedCoopInfantry_2") != null, "Another source entity must create its own rig.");
        client.LeaveMatch();
        Require(GameObject.Find("SelfHostedCoopInfantry_2") == null, "Match close must clear actor roots immediately.");
    }

    private static MatchSnapshot CreateSnapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = "walking-visual-audit", ManifestHash = new string('a', 64),
            Phase = BattlePhase.Running, ServerTick = 20,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies", Started = true, DeadlineTick = 100,
                SceneMasterPlayerId = PlayerId, ObjectiveTarget = 10
            }
        };
        foreach (string playerId in new[] { PlayerId, PeerId })
        {
            snapshot.Players.Add(new BattlePlayerState
            {
                PlayerId = playerId, Admitted = true, Ready = true, Health = 100, MaxHealth = 100
            });
            snapshot.Coop.ParticipantIds.Add(playerId);
        }
        snapshot.Coop.EnemySpawns.Add(new BattleCoopEnemySpawn
        {
            EntityId = 1, Behaviour = "Assaulter", SpawnComponentFileId = 100, SpawnTick = 8,
            PoseTick = 20, X = 1, Y = 2, Z = 3, CurrentX = 1, CurrentY = 2, CurrentZ = 3,
            Health = 100, MaxHealth = 100, CurrentRotation = new BattleJointRotation { W = 1 },
            InfantryVisualClip = "run_0", InfantryVisualStartTick = 8, InfantryVisualSampleTick = 20
        });
        return snapshot;
    }

    private static void ClearAnimation(BattleCoopEnemySpawn enemy)
    {
        enemy.InfantryVisualClip = "";
        enemy.InfantryVisualStartTick = 0;
        enemy.InfantryVisualSampleTick = 0;
    }

    private static void InvokeLifecycle(SelfHostedCoopInfantryPresenter presenter, string method)
    {
        typeof(SelfHostedCoopInfantryPresenter).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(presenter, null);
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }
}
