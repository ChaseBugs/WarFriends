using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks owner/peer smoke lifetimes and replay suppression through the normal projectile presenter.</summary>
public static class UnityBazookaLifetimeAudit
{
    private const string LocalPlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string RemotePlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string SourceId = "Google2u.Bazooka_RPG7";
    private const int HostEventCapacity = 512;
    private static int _checks;

    /// <summary>Runs controlled scaled clocks in a disposable Editor without local combat or RPC execution.</summary>
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            _checks = 0;
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            PlayerController player = components.OfType<PlayerController>().First(row =>
                row.ResolveSelfHostedInventory() != null && row.ResolveSelfHostedInventory().allWeapons.Count > 58);
            player.playerProperties = new PlayerProperties { playerID = LocalPlayerId };
            WeaponInventory inventory = player.ResolveSelfHostedInventory();
            inventory.usedWeapons = new List<PlayerWeapon> { inventory.allWeapons[11] };
            typeof(WeaponInventory).GetProperty("weaponIndex").SetValue(inventory, 0, null);
            owner = new GameObject("BazookaLifetimeAudit");
            SelfHostedProjectilePresenter presenter = owner.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player, player, components.OfType<LevelBehaviourManager>().Single());
            VerifyRole(presenter, LocalPlayerId, 1, 1.3f);
            VerifyRole(presenter, RemotePlayerId, 2, 0.2f);
            VerifyMissingAndScope(presenter);
            VerifyEarlyImpact();
            VerifyBounds();
            Debug.Log("PASS: " + _checks + " bazooka scaled tail, owner/peer, stale-read and scope checks; " +
                "controlled component clocks only, no rendered gameplay.");
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

    private static void VerifyRole(SelfHostedProjectilePresenter presenter, string ownerId, ulong id, float delay)
    {
        MatchSnapshot frame = Frame("tail-match", ownerId, id);
        presenter.Apply(frame);
        GameObject root = Find(id);
        Require(root != null, "The source missile flight is visible.");
        MatchEvent impact = Impact(ownerId, id);
        presenter.ApplyEvent(impact);
        float scaledStart = Time.time;
        Require(root != null && !root.transform.Find("missilePrototype").gameObject.activeSelf,
            "An impact immediately hides the source missile model.");
        Require(!root.transform.Find("fireFlash").GetComponent<ParticleSystem>().isEmitting,
            "The source flight particles stop emitting.");
        Require(root.transform.position == new Vector3(4, 5, 6), "The remaining tail stays at the host impact.");
        presenter.ApplyScan(Scan(frame));
        presenter.Apply(frame);
        Require(!root.transform.Find("missilePrototype").gameObject.activeSelf,
            "A delayed snapshot or frozen scan cannot revive the flight.");
        presenter.RenderAt(Time.realtimeSinceStartup + 100f);
        Require(Find(id) == root && root.transform.position == new Vector3(4, 5, 6),
            "Unscaled extrapolation time cannot expire or move a retired tail.");
        SelfHostedBazookaLifetime lifetime = Lifetime(presenter);
        lifetime.Advance(scaledStart + delay - 0.001f);
        Require(Find(id) == root, "The tail remains before its source scaled-time deadline.");
        Require(!lifetime.Impact(impact, scaledStart + delay - 0.001f),
            "A repeated impact does not restart the tail or replay its effect.");
        lifetime.Advance(scaledStart + delay);
        Require(Find(id) == null, "The tail expires at its owner/peer deadline.");
        presenter.ApplyScan(Scan(frame));
        Require(Find(id) == null, "The completed identity survives visual destruction.");
        presenter.ResetForFullSnapshot();
        presenter.Apply(frame);
        Require(Find(id) == null, "Same-match reconnect cleanup retains the completed identity.");
    }

    private static void VerifyMissingAndScope(SelfHostedProjectilePresenter presenter)
    {
        const ulong Id = 3;
        MatchSnapshot frame = Frame("tail-match", RemotePlayerId, Id);
        presenter.Apply(frame);
        GameObject root = Find(Id);
        MatchSnapshot empty = Frame("tail-match", RemotePlayerId, Id);
        empty.Projectiles.Clear();
        empty.ProjectilesTruncated = true;
        presenter.Apply(empty);
        Require(root.transform.Find("missilePrototype").gameObject.activeSelf,
            "MTU omission cannot retire an active missile.");
        empty.ProjectilesTruncated = false;
        presenter.Apply(empty);
        Require(!root.transform.Find("missilePrototype").gameObject.activeSelf,
            "A complete omission retires the mesh without fabricating an explosion.");
        Lifetime(presenter).Advance(Time.time + 0.2f);
        Require(Find(Id) == null, "A missing peer missile's tail also stays bounded.");
        presenter.ApplyScan(Scan(frame));
        Require(Find(Id) == null, "A late scan cannot restore a missing completed flight.");
        Require(Lifetime(presenter).Impact(Impact(RemotePlayerId, Id), Time.time),
            "A reliable impact after tail expiry can still publish its first effect.");
        presenter.Apply(Frame("next-tail-match", LocalPlayerId, Id));
        Require(Find(Id) != null, "A new match can reuse its own projectile counter.");
        presenter.ApplyEvent(Impact(LocalPlayerId, Id));
        presenter.ResetForFullSnapshot();
        Require(Find(Id) == null, "Reconnect cleanup immediately removes retained tails.");
    }

    private static void VerifyEarlyImpact()
    {
        const ulong Id = 20;
        var lifetime = new SelfHostedBazookaLifetime();
        Require(lifetime.Impact(Impact(LocalPlayerId, Id), 0), "An unseen impact is still retained.");
        lifetime.SelectScope("first-match", new string('a', 64));
        Require(lifetime.IsFinished(Id), "The first full snapshot cannot erase an earlier checked impact.");
        MatchEvent invalid = Impact(LocalPlayerId, Id + 1);
        invalid.X = float.NaN;
        Reject(() => lifetime.Impact(invalid, 0), "Malformed coordinates cannot retire a flight.");
        Reject(() => lifetime.Impact(Impact(LocalPlayerId, Id + 1), float.NaN),
            "Malformed scaled time cannot create a completion record.");
        Require(!lifetime.IsFinished(Id + 1), "Rejected input leaves completion authority unchanged.");
    }

    private static void VerifyBounds()
    {
        var lifetime = new SelfHostedBazookaLifetime();
        for (ulong id = 1; id <= HostEventCapacity; id++)
        {
            lifetime.Impact(Impact(LocalPlayerId, id), 0);
        }

        Reject(() => lifetime.Impact(Impact(LocalPlayerId, HostEventCapacity + 1), 0),
            "Completion history is bounded without silently evicting replay protection.");
        Require(lifetime.IsFinished(1) && !lifetime.IsFinished(HostEventCapacity + 1),
            "Capacity rejection retains the earliest completed ID.");
        lifetime.SelectScope("old", "hash");
        lifetime.SelectScope("new", "hash");
        Require(lifetime.Impact(Impact(LocalPlayerId, HostEventCapacity + 1), 0),
            "Only a deliberate new-match scope releases completion capacity.");
    }

    private static MatchSnapshot Frame(string matchId, string ownerId, ulong id)
    {
        var frame = new MatchSnapshot { MatchId = matchId, ManifestHash = new string('a', 64) };
        frame.Projectiles.Add(new BattleProjectileState
        {
            ProjectileId = id, OwnerPlayerId = ownerId, Kind = "bazooka", WeaponSourceId = SourceId,
            X = 1, Y = 2, Z = 3, VelocityZ = 4
        });
        return frame;
    }

    private static MatchProjectileBatch Scan(MatchSnapshot frame)
    {
        var scan = new MatchProjectileBatch
        {
            Code = "projectiles", MatchId = frame.MatchId, ManifestHash = frame.ManifestHash,
            ActiveCount = (uint)frame.Projectiles.Count
        };
        scan.Projectiles.Add(frame.Projectiles);
        return scan;
    }

    private static MatchEvent Impact(string ownerId, ulong id)
    {
        return new MatchEvent
        {
            Kind = MatchEventKind.Impact, Reason = "bazooka", ActorId = ownerId,
            ProjectileId = id, WeaponSourceId = SourceId, X = 4, Y = 5, Z = 6
        };
    }

    private static SelfHostedBazookaLifetime Lifetime(SelfHostedProjectilePresenter presenter)
    {
        return (SelfHostedBazookaLifetime)typeof(SelfHostedProjectilePresenter)
            .GetField("bazookaLifetime", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(presenter);
    }

    private static GameObject Find(ulong id)
    {
        return GameObject.Find("SelfHostedProjectile_" + id);
    }

    private static void Reject(Action action, string message)
    {
        bool isRejected = false;
        try
        {
            action();
        }
        catch (Exception failure) when (failure is InvalidOperationException || failure is ArgumentException)
        {
            isRejected = true;
        }

        Require(isRejected, message);
    }

    private static void Require(bool condition, string message)
    {
        _checks++;
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
