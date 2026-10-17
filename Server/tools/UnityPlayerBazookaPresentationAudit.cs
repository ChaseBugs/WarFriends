using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Compares decoded player RPG presentation with the recovered Missile.AnimateShot method.</summary>
public static class UnityPlayerBazookaPresentationAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private static readonly string[] SourceIds =
    {
        "Google2u.Bazooka_RPG7", "Google2u.Bazooka_FGM", "Google2u.Bazooka_HMV",
        "Google2u.Bazooka_Panzerfaust", "Google2u.Bazooka_M202", "Google2u.Bazooka_FGMElite",
        "Google2u.Bazooka_Hater"
    };

    /// <summary>Runs component comparisons with inactive source controls and no local missile simulation.</summary>
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            PlayerController player = components.OfType<PlayerController>().First(row =>
                row.ResolveSelfHostedInventory() != null && row.ResolveSelfHostedInventory().allWeapons.Count > 58);
            player.playerProperties = new PlayerProperties { playerID = PlayerId };
            WeaponInventory inventory = player.ResolveSelfHostedInventory();
            inventory.usedWeapons = new List<PlayerWeapon> { inventory.allWeapons[11] };
            typeof(WeaponInventory).GetProperty("weaponIndex").SetValue(inventory, 0, null);
            owner = new GameObject("PlayerBazookaPresentationAudit");
            SelfHostedProjectilePresenter presenter = owner.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player, player, components.OfType<LevelBehaviourManager>().Single());
            ulong projectileId = 100;
            foreach (string sourceId in SourceIds)
            {
                VerifySource(presenter, inventory, CreateProjectile(sourceId, ++projectileId, false));
            }

            VerifySource(presenter, inventory, CreateProjectile("Google2u.Bazooka_M202", ++projectileId, true));
            Debug.Log("PASS: seven player bazooka models and M202 fake through decoded snapshots, " +
                "original AnimateShot appearance, rifle-slot independence and impact cleanup; no rendered match.");
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

    private static BattleProjectileState CreateProjectile(string sourceId, ulong projectileId, bool isFake)
    {
        return new BattleProjectileState
        {
            ProjectileId = projectileId, OwnerPlayerId = PlayerId,
            Kind = isFake ? "bazooka-fake" : "bazooka", WeaponSourceId = sourceId,
            X = 1, Y = 2, Z = 3, VelocityZ = 4
        };
    }

    private static void VerifySource(
        SelfHostedProjectilePresenter presenter, WeaponInventory inventory, BattleProjectileState projectile)
    {
        string sourceId = projectile.WeaponSourceId;
        ulong projectileId = projectile.ProjectileId;
        var snapshot = new MatchSnapshot();
        snapshot.Projectiles.Add(projectile);
        presenter.Apply(MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray()));
        GameObject visual = GameObject.Find("SelfHostedProjectile_" + projectileId);
        Require(visual != null && visual.transform.position == new Vector3(1, 2, 3),
            "The decoded missile must appear.");
        Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
            visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
            visual.GetComponentsInChildren<Rigidbody>(true).Length == 0,
            "The missile visual must have no combat scripts.");
        CompareOriginalAppearance(visual, SelfHostedBazookaVisual.ResolveWeapon(inventory, sourceId));
        presenter.RenderAt(Time.realtimeSinceStartup + 1f);
        Require(visual.transform.position.z >= 3f && visual.transform.position.z <= 3.4001f,
            "Only bounded host-velocity extrapolation may move the missile.");
        presenter.ApplyEvent(new MatchEvent
        {
            Kind = MatchEventKind.Impact, ActorId = PlayerId, ProjectileId = projectileId,
            Reason = projectile.Kind, WeaponSourceId = sourceId
        });
        Require(visual != null && !visual.transform.Find("missilePrototype").gameObject.activeSelf,
            "The host impact stops the model before the original smoke tail expires.");
        var lifetime = (SelfHostedBazookaLifetime)typeof(SelfHostedProjectilePresenter)
            .GetField("bazookaLifetime", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(presenter);
        lifetime.Advance(Time.time + 1.31f);
        Require(GameObject.Find("SelfHostedProjectile_" + projectileId) == null,
            "The host impact removes the missile.");
    }

    private static void CompareOriginalAppearance(GameObject visual, Weapon weapon)
    {
        GameObject staging = new GameObject("InactiveOriginalMissileControl");
        staging.SetActive(false);
        try
        {
            Missile prefab = weapon.bulletPrefab as Missile;
            GameObject reference = UnityEngine.Object.Instantiate(prefab.gameObject, staging.transform, false);
            Missile original = reference.GetComponent<Missile>();
            FieldInfo awakeState = typeof(Missile).GetField(
                "mTransform", BindingFlags.Instance | BindingFlags.NonPublic);
            Require(awakeState.GetValue(original) == null, "The inactive source control must not run Awake.");
            typeof(Missile).GetField("mSetup", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(original, weapon.ammoSetup);
            original.AnimateShot(Vector3.zero, Vector3.forward * 4f);
            ComparePart(original.projectileModel, reference.transform, visual.transform);
            ComparePart(original.smallParticles, reference.transform, visual.transform);
            ComparePart(original.bigParticles, reference.transform, visual.transform);
            ComparePart(original.burningSmokeParticles, reference.transform, visual.transform);
            TrailRenderer trail = visual.GetComponent<TrailRenderer>();
            Require(trail.time == original.trail.time && trail.startWidth == original.trail.startWidth &&
                trail.endWidth == original.trail.endWidth &&
                trail.sharedMaterials.SequenceEqual(original.trail.sharedMaterials), "Source trail style must match.");
            Require(visual.GetComponentsInChildren<ParticleSystem>(true).Single(row =>
                row.name == original.particles.name).isPlaying,
                "The source flight particles must be started explicitly.");
            MeshFilter[] sourceMeshes = reference.GetComponentsInChildren<MeshFilter>(true);
            MeshFilter[] copiedMeshes = visual.GetComponentsInChildren<MeshFilter>(true);
            Require(sourceMeshes.Select(row => row.sharedMesh)
                .SequenceEqual(copiedMeshes.Select(row => row.sharedMesh)),
                "Every original missile mesh must be preserved.");
            Require(original.GetComponent<PhotonView>() != null && awakeState.GetValue(original) == null,
                "The original control remains inactive with no Photon or combat Awake.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(staging);
        }
    }

    private static void ComparePart(GameObject original, Transform sourceRoot, Transform visualRoot)
    {
        var names = new List<string>();
        Transform current = original.transform;
        while (current != sourceRoot)
        {
            names.Add(current.name);
            current = current.parent;
        }

        names.Reverse();
        Transform copy = visualRoot.Find(string.Join("/", names.ToArray()));
        Require(copy != null && copy.gameObject.activeSelf == original.activeSelf &&
            copy.localPosition == original.transform.localPosition &&
            copy.localRotation == original.transform.localRotation && copy.localScale == original.transform.localScale,
            "Original AnimateShot activation and local transforms must match: " + original.name);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
