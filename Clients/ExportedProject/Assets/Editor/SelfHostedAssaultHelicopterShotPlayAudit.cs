using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

// Run this in a disposable project. LineTrailRenderer needs Play Mode.
[InitializeOnLoad]
public static class SelfHostedAssaultHelicopterShotPlayAudit
{
    private const string Active = "WarFriends.AssaultHelicopterShotPlayAudit";
    private static GameObject owner;
    private static Vector3 initialPosition;
    private static int frames;
    private static double deadline;

    static SelfHostedAssaultHelicopterShotPlayAudit()
    {
        if (!SessionState.GetBool(Active, false)) return;
        deadline = EditorApplication.timeSinceStartup + 45;
        EditorApplication.update += Update;
    }

    public static void Run()
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        var sourceModels = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<BulletModels>(true)).Single();
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
            "Assets/GameObject/assaultHelicopter.prefab");
        var assault = prefab == null ? null : prefab.GetComponent<AssaultHelicopter>();
        if (assault == null || assault.weapons == null || assault.weapons.Count != 2)
            throw new InvalidOperationException("Recovered Assault Helicopter weapons are absent.");
        var firstBullet = assault.weapons[0].weapon.bulletPrefab;
        var secondBullet = assault.weapons[1].weapon.bulletPrefab;
        if (firstBullet == null || secondBullet == null ||
            !firstBullet.GetComponentsInChildren<MeshFilter>(true)
                .Select(filter => filter.sharedMesh)
                .SequenceEqual(secondBullet.GetComponentsInChildren<MeshFilter>(true)
                    .Select(filter => filter.sharedMesh)))
            throw new InvalidOperationException("Assault Helicopter gun meshes differ; projectile presentation needs a gun index.");

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        new GameObject("AuditCamera").AddComponent<Camera>().tag = "MainCamera";
        new GameObject("AuditPool").AddComponent<ObjectPoolDatabase>().assaultHelicopter = assault;
        new GameObject("AuditBulletModels").AddComponent<BulletModels>().bulletmeshes =
            sourceModels.bulletmeshes.ToList();
        SessionState.SetBool(Active, true);
        deadline = EditorApplication.timeSinceStartup + 45;
        EditorApplication.isPlaying = true;
    }

    private static void Update()
    {
        if (!SessionState.GetBool(Active, false) || !EditorApplication.isPlaying ||
            EditorApplication.isPaused) return;
        if (EditorApplication.timeSinceStartup > deadline)
        {
            Fail(new TimeoutException("Assault Helicopter shot Play Mode audit timed out."));
            return;
        }
        try
        {
            if (owner == null)
            {
                var pool = Singleton<ObjectPoolDatabase>.instance;
                var assault = pool == null ? null : pool.assaultHelicopter;
                var models = Singleton<BulletModels>.instance;
                if (assault == null || models == null || Camera.main == null)
                    throw new InvalidOperationException("Assault Helicopter render sources are absent.");
                owner = new GameObject("AssaultHelicopterShotPlayAudit");
                var presenter = owner.AddComponent<SelfHostedProjectilePresenter>();
                presenter.ApplyEvent(new MatchEvent
                {
                    Kind = MatchEventKind.AssaultHelicopterFired,
                    ActorId = "11111111111111111111111111111111",
                    ProjectileId = 903, X = 0, Y = 0, Z = 10,
                    AssaultHelicopterShot = new AssaultHelicopterShotPresentation
                    {
                        ArmyEntityKey = 83, GunIndex = 1,
                        MuzzleX = 0, MuzzleY = 0, MuzzleZ = 0,
                        Speed = 18, Fake = true
                    }
                });
                var visual = GameObject.Find("SelfHostedProjectile_903");
                var trail = visual == null ? null : visual.GetComponent<LineTrailRenderer>();
                var setup = assault.weapons[1].weapon.ammoSetup as BulletSetup;
                if (visual == null || trail == null || setup == null ||
                    Mathf.Abs(trail.trailLength - setup.GetTrailSize()) > .0001f ||
                    Mathf.Abs(trail.disapearTime - setup.GetTrailSize() / 18f) > .0001f ||
                    visual.GetComponent<MeshFilter>().sharedMesh !=
                        models.GetMesh(setup.fakeShotTexture) ||
                    visual.GetComponentsInChildren<Collider>(true).Length != 0)
                    throw new InvalidOperationException("Assault Helicopter shot lacks its recovered trail or mesh.");
                initialPosition = visual.transform.position;
                return;
            }
            frames++;
            var flight = GameObject.Find("SelfHostedProjectile_903");
            if (flight != null && Vector3.Distance(flight.transform.position, initialPosition) > .1f)
            {
                SessionState.SetBool(Active, false);
                EditorApplication.update -= Update;
                Debug.Log("PASS: SelfHostedAssaultHelicopterShotPlayAudit");
                EditorApplication.Exit(0);
            }
            else if (frames > 120)
                throw new InvalidOperationException("Assault Helicopter shot never advanced.");
        }
        catch (Exception error) { Fail(error); }
    }

    private static void Fail(Exception error)
    {
        SessionState.SetBool(Active, false);
        EditorApplication.update -= Update;
        Debug.LogException(error);
        EditorApplication.Exit(1);
    }
}
