using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using War.Protocol;

/// <summary>Checks identity and stale-snapshot boundaries on actual presentation actors.</summary>
public static class UnityStartPresentationAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    /// <summary>Uses the controlled retained owner without opening another transport or scene.</summary>
    public static void Verify(SelfHostedBattleClient client)
    {
        var bindings = (IDictionary)typeof(SelfHostedBattleClient).GetField("_startPresentationPlayers",
            PrivateInstance).GetValue(client);
        Require(client.OwnsMatch && bindings.Count == 0, "The fixture must not replace bound presentation actors.");
        PropertyInfo roster = typeof(SelfHostedBattleClient).GetProperty("PlayerViews");
        PropertyInfo identity = typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId");
        object previousRoster = roster.GetValue(client, null);
        object previousIdentity = identity.GetValue(client, null);
        var owner = new GameObject("InactiveStartPresentationActors");
        owner.SetActive(false);
        try
        {
            string localId = client.State.Players[0].PlayerId;
            string otherId = client.State.Players[1].PlayerId;
            identity.SetValue(client, localId, null);
            roster.SetValue(client, new[]
            {
                new BattlePlayerView { PlayerId = localId }, new BattlePlayerView { PlayerId = otherId }
            }, null);
            VerifyProjection(client, CreateActor(owner.transform, "Local"), CreateActor(owner.transform, "Other"));
        }
        finally
        {
            bindings.Clear();
            typeof(SelfHostedBattleClient).GetField("_startPresentationMatchId", PrivateInstance).SetValue(client, null);
            roster.SetValue(client, previousRoster, null);
            identity.SetValue(client, previousIdentity, null);
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifyProjection(SelfHostedBattleClient client, PlayerController local, PlayerController other)
    {
        client.BindStartPresentationPlayers(local, other);
        MatchSnapshot completed = client.State.Clone();
        completed.Players[1].PresentationReady = true;
        BattlePlayerState remoteRow = completed.Players[1];
        completed.Players.RemoveAt(1);
        completed.Players.Insert(0, remoteRow);
        Project(client, completed);
        Require(!local.networkStatus.startAnimationFinished && other.networkStatus.startAnimationFinished,
            "Reordered snapshot rows must project by identity rather than actor position.");

        local.networkStatus.startAnimationFinished = true;
        Project(client, client.State.Clone());
        Require(local.networkStatus.startAnimationFinished && other.networkStatus.startAnimationFinished,
            "An older false snapshot must not erase local or confirmed completion.");
        local.networkStatus.startAnimationFinished = false;
        other.networkStatus.startAnimationFinished = false;
        completed.MatchId += "-obsolete";
        Project(client, completed);
        Require(!local.networkStatus.startAnimationFinished && !other.networkStatus.startAnimationFinished,
            "Another battle must not complete actors still bound to this match.");
        Debug.Log("PASS: reordered presentation rows retain actor identity, false snapshots preserve completion, " +
            "and obsolete battle state cannot mutate bound actors.");
    }

    private static PlayerController CreateActor(Transform parent, string actorName)
    {
        var root = new GameObject(actorName);
        root.transform.parent = parent;
        var actor = root.AddComponent<PlayerController>();
        actor.networkStatus = new PlayerNetworkStatus(actor);
        return actor;
    }

    private static void Project(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("ApplyStartPresentation", PrivateInstance)
            .Invoke(client, new object[] { snapshot });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
