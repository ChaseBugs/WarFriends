using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedInfantryProjectileRenderAudit
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
            Require(pool.bulletPoison != null, "source BulletPoison is absent");

            player.playerProperties.playerID = new string('a', 32);
            host = new GameObject("SelfHostedSwatProjectileRenderAudit");
            var presenter = host.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player, player, behaviours);

            var snapshot = new MatchSnapshot();
            var families = new[]
            {
                new { UnitId = "ID_UNIT-SWAT", CardId = "ELITESWAT" },
                new { UnitId = "ID_UNIT-PARATROOPER", CardId = "ELITEPARA" },
                new { UnitId = "ID_UNIT-MINIGUNNER", CardId = "ELITEMINIGUN" },
                new { UnitId = "ID_UNIT-SNIPER", CardId = "ELITESNIPER" }
            };
            for (int index = 0; index < families.Length; index++)
            {
                for (int card = 0; card < 2; card++)
                    snapshot.Projectiles.Add(new BattleProjectileState
                    {
                        ProjectileId = (ulong)(71 + index * 2 + card),
                        OwnerPlayerId = player.playerProperties.playerID,
                        Kind = "army-bullet", ArmyUnitId = families[index].UnitId,
                        ArmySourceCardId = card == 0 ? families[index].CardId : "",
                        X = 1 + index, Y = 2, Z = 3, VelocityZ = 5
                    });
            }
            for (int poison = 0; poison < 2; poison++)
                snapshot.Projectiles.Add(new BattleProjectileState
                {
                    ProjectileId = (ulong)(79 + poison),
                    OwnerPlayerId = player.playerProperties.playerID,
                    Kind = "army-bullet", ArmyUnitId = "ID_UNIT-COMMANDO",
                    ArmyPoison = poison == 1,
                    X = 5, Y = 2, Z = 3, VelocityZ = 5
                });
            snapshot.Projectiles.Add(new BattleProjectileState
            {
                ProjectileId = 81, OwnerPlayerId = player.playerProperties.playerID,
                Kind = "army-bullet", ArmyUnitId = "ID_UNIT-SHOTGUNNER",
                X = 6, Y = 2, Z = 3, VelocityZ = 10
            });
            snapshot.Projectiles.Add(new BattleProjectileState
            {
                ProjectileId = 82, OwnerPlayerId = player.playerProperties.playerID,
                Kind = "army-bullet", ArmyUnitId = "ID_UNIT-WARPER",
                X = 7, Y = 2, Z = 3, VelocityZ = 10
            });
            presenter.Apply(snapshot);
            foreach (var projectile in snapshot.Projectiles)
            {
                var visual = GameObject.Find("SelfHostedProjectile_" + projectile.ProjectileId);
                Require(visual != null, "infantry shot has no visual");
                BulletBase sourceBullet;
                if (projectile.ArmyUnitId == "ID_UNIT-SHOTGUNNER" ||
                    projectile.ArmyUnitId == "ID_UNIT-WARPER")
                {
                    Type behaviourType = projectile.ArmyUnitId == "ID_UNIT-SHOTGUNNER" ?
                        typeof(SoldierBehaviourShotgunner) : typeof(SoldierBehaviourWarper);
                    var behaviour = behaviours.levelBehaviours.Single(entry =>
                        entry.behaviour.GetType() == behaviourType).behaviour;
                    var inventory = behaviour.GetComponent<EnemyBasicInventory>();
                    var shotgun = inventory.weapons[0].weapon.bulletPrefab as BulletShotGun;
                    Require(shotgun != null && shotgun.bulletPrefab != null,
                        "source infantry pellet is absent");
                    sourceBullet = shotgun.bulletPrefab;
                }
                else
                    sourceBullet = projectile.ArmyPoison ?
                        (BulletBase)pool.bulletPoison : pool.bulletSlow;
                Require(visual.GetComponentsInChildren<MeshFilter>(true)
                    .Select(filter => filter.sharedMesh).SequenceEqual(sourceBullet
                        .GetComponentsInChildren<MeshFilter>(true)
                        .Select(filter => filter.sharedMesh)), "infantry bullet mesh differs from source");
                Require(visual.GetComponent<LineTrailRenderer>() != null,
                    "infantry shot has no source-configured trail");
                Require(visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
                    visual.GetComponentsInChildren<Rigidbody>(true).Length == 0 &&
                    visual.GetComponentsInChildren<BulletBase>(true).Length == 0,
                    "infantry visual contains gameplay or collision components");
            }

            presenter.ApplyEvent(new MatchEvent
            {
                Kind = MatchEventKind.Impact, ProjectileId = 71, Reason = "army"
            });
            Require(GameObject.Find("SelfHostedProjectile_71") == null,
                "host impact did not retire the infantry shot");

            presenter.Apply(new MatchSnapshot());
            foreach (var projectile in snapshot.Projectiles)
                Require(GameObject.Find("SelfHostedProjectile_" + projectile.ProjectileId) == null,
                    "completed infantry shot remains visible");
            Debug.Log("UNITY_INFANTRY_PROJECTILE_RENDER_PASSED families=7 normal=True card=True poison=True pellet=True sourceMesh=True trail=True impact=True removal=True");
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
        if (!condition) throw new InvalidOperationException("Infantry render audit: " + message);
    }
}
