using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Google.Protobuf;
using Newtonsoft.Json.Linq;
using War.Protocol;

/// <summary>Checks walking and corner-fire protobuf samples without enabling source enemy simulation.</summary>
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
        next.Coop.EnemySpawns[0].InfantryAnimation.SampleTick = 23;
        next.Coop.EnemySpawns[0].InfantryAnimation.Clips[0].TimeSeconds = 0.5f;
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
        VerifyPreparation(client, actor, skin, next);
        MatchSnapshot fire = next.Clone();
        ClearAnimation(fire.Coop.EnemySpawns[0]);
        fire.Coop.EnemySpawns[0].InfantryAnimation = new BattleInfantryAnimationFrame { SampleTick = 23 };
        fire.Coop.EnemySpawns[0].InfantryAnimation.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = "player_fire_right3", TimeSeconds = 0.1f, Weight = 1f,
            Wrap = BattleInfantryAnimationWrap.ClampForever
        });
        Quaternion[] walkingPose = skin.bones.Select(bone => bone.localRotation).ToArray();
        Publish(client, fire);
        Require(GameObject.Find(actor.name) == actor &&
            skin.bones.Where((bone, index) => Quaternion.Angle(bone.localRotation, walkingPose[index]) > 0.001f).Any(),
            "A confirmed protobuf fire frame must reuse the actor and replace its walking bone pose.");
        VerifyReturnBlend(client, actor, skin, fire);
    }

    private static void VerifyPreparation(SelfHostedBattleClient client, GameObject actor,
        SkinnedMeshRenderer skin, MatchSnapshot previous)
    {
        MatchSnapshot snapshot = previous.Clone();
        ClearAnimation(snapshot.Coop.EnemySpawns[0]);
        var frame = new BattleInfantryAnimationFrame { SampleTick = snapshot.ServerTick };
        frame.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = "player_look_right3", TimeSeconds = 0.1f, Weight = 1f,
            Wrap = BattleInfantryAnimationWrap.Clamp
        });
        snapshot.Coop.EnemySpawns[0].InfantryAnimation = frame;
        Quaternion[] before = skin.bones.Select(bone => bone.localRotation).ToArray();
        Publish(client, snapshot);
        Require(GameObject.Find(actor.name) == actor &&
            skin.bones.Where((bone, index) => Quaternion.Angle(bone.localRotation, before[index]) > 0.001f).Any(),
            "The decoded first preparation frame must replace walking on the same source actor.");
    }

    private static void VerifyReturnBlend(SelfHostedBattleClient client, GameObject actor,
        SkinnedMeshRenderer skin, MatchSnapshot previous)
    {
        string path = Environment.GetEnvironmentVariable("WAR_CORNER_RETURN_ANIMATION_REFERENCE");
        if (string.IsNullOrEmpty(path))
        {
            throw new InvalidOperationException("Set WAR_CORNER_RETURN_ANIMATION_REFERENCE to the reviewed artifact.");
        }

        JObject source = JObject.Parse(File.ReadAllText(path));
        JToken rows = source["scenarios"][0]["frames"][7]["clips"];
        MatchSnapshot snapshot = previous.Clone();
        var frame = new BattleInfantryAnimationFrame { SampleTick = snapshot.ServerTick };
        foreach (JToken row in rows)
        {
            frame.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = row.Value<string>("clipName"),
                TimeSeconds = row.Value<float>("timeSeconds"),
                Weight = row.Value<float>("weight"),
                Wrap = row.Value<string>("wrap") == "Clamp"
                    ? BattleInfantryAnimationWrap.Clamp : BattleInfantryAnimationWrap.Loop
            });
        }
        snapshot.Coop.EnemySpawns[0].InfantryAnimation = frame;
        Quaternion[] before = skin.bones.Select(bone => bone.localRotation).ToArray();
        Publish(client, snapshot);
        Require(frame.Clips.Count == 2 && GameObject.Find(actor.name) == actor &&
            skin.bones.Where((bone, index) => Quaternion.Angle(bone.localRotation, before[index]) > 0.001f).Any(),
            "A measured cover-to-idle protobuf blend must reuse the actor and update its actual source rig.");
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
        second.InfantryAnimation.SampleTick = spawn.ServerTick;
        second.InfantryAnimation.Clips[0].TimeSeconds = 0f;
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
        var animation = new BattleInfantryAnimationFrame { SampleTick = 20 };
        animation.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = "run_0", TimeSeconds = 0.4f, Weight = 1f, Wrap = BattleInfantryAnimationWrap.Loop
        });
        snapshot.Coop.EnemySpawns[0].InfantryAnimation = animation;
        return snapshot;
    }

    private static void ClearAnimation(BattleCoopEnemySpawn enemy)
    {
        enemy.InfantryVisualClip = "";
        enemy.InfantryVisualStartTick = 0;
        enemy.InfantryVisualSampleTick = 0;
        enemy.InfantryAnimation = null;
    }

    private static void InvokeLifecycle(SelfHostedCoopInfantryPresenter presenter, string method)
    {
        typeof(SelfHostedCoopInfantryPresenter).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(presenter, null);
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = decoded } });
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
