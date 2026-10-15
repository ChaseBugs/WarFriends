using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedSwatProjectileRenderAudit
{
    public static void Run()
    {
        var previous = EditorSceneManager.GetSceneManagerSetup();
        GameObject host = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var roots = scene.GetRootGameObjects();
            var player = roots.SelectMany(root => root.GetComponentsInChildren<GameController>(true))
                .Single().mainPlayerController;
            var behaviours = roots.SelectMany(root =>
                root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            var pool = roots.SelectMany(root =>
                root.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            Require(pool.bulletSlow != null, "source BulletSlow is absent");

            player.playerProperties.playerID = new string('a', 32);
            host = new GameObject("SelfHostedSwatProjectileRenderAudit");
            var presenter = host.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player, player, behaviours);

            var snapshot = new MatchSnapshot();
            snapshot.Projectiles.Add(new BattleProjectileState
            {
                ProjectileId = 71, OwnerPlayerId = player.playerProperties.playerID,
                Kind = "army-bullet", ArmyUnitId = "ID_UNIT-SWAT",
                ArmySourceCardId = "ELITESWAT", X = 1, Y = 2, Z = 3,
                VelocityZ = 5
            });
            snapshot.Projectiles.Add(new BattleProjectileState
            {
                ProjectileId = 72, OwnerPlayerId = player.playerProperties.playerID,
                Kind = "army-bullet", ArmyUnitId = "ID_UNIT-SWAT",
                X = 2, Y = 2, Z = 3, VelocityZ = 5
            });
            presenter.Apply(snapshot);
            foreach (ulong projectileId in new ulong[] { 71, 72 })
            {
                var visual = GameObject.Find("SelfHostedProjectile_" + projectileId);
                Require(visual != null, "SWAT shot has no visual");
                Require(visual.GetComponentsInChildren<MeshFilter>(true)
                    .Select(filter => filter.sharedMesh).SequenceEqual(pool.bulletSlow
                        .GetComponentsInChildren<MeshFilter>(true)
                        .Select(filter => filter.sharedMesh)), "SWAT bullet mesh differs from source");
                Require(visual.GetComponent<LineTrailRenderer>() != null,
                    "SWAT shot has no source-configured trail");
                Require(visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
                    visual.GetComponentsInChildren<Rigidbody>(true).Length == 0 &&
                    visual.GetComponentsInChildren<BulletBase>(true).Length == 0,
                    "SWAT visual contains gameplay or collision components");
            }

            presenter.ApplyEvent(new MatchEvent
            {
                Kind = MatchEventKind.Impact, ProjectileId = 71, Reason = "army"
            });
            Require(GameObject.Find("SelfHostedProjectile_71") == null,
                "host impact did not retire the SWAT shot");

            presenter.Apply(new MatchSnapshot());
            Require(GameObject.Find("SelfHostedProjectile_72") == null,
                "completed SWAT shot remains visible");
            Debug.Log("UNITY_SWAT_PROJECTILE_RENDER_PASSED normal=True card=True sourceMesh=True trail=True impact=True removal=True");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogError(error);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (host != null) UnityEngine.Object.DestroyImmediate(host);
            if (previous.Any(row => row.isActive && row.isLoaded) &&
                previous.All(row => !string.IsNullOrEmpty(row.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException("SWAT render audit: " + message);
    }
}
