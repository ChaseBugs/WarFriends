using System;
using System.Reflection;
using Google.Protobuf;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks the actual random-search entry point before it mutates lobby/player state.</summary>
public static class UnityRandomSearchBoundaryAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    /// <summary>Checks local terminal release without claiming live Backend allocation or result proof.</summary>
    public static void VerifyEndedRelease(SelfHostedBattleClient client, MatchConnectionGrant grant)
    {
        Require(!client.OwnsMatch && SelfHostedBattleClient.Active == null,
            "The terminal-release fixture must not replace an owned connection.");
        MatchSnapshot ended = client.State.Clone();
        ended.Phase = BattlePhase.Ended;
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, ended, null);
        typeof(SelfHostedBattleClient).GetField("connection", PrivateInstance)
            .SetValue(client, new MatchConnection(grant));
        typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
        ByteString frozen = ended.ToByteString();
        int closeNotifications = 0;
        Action onClosed = () => closeNotifications++;
        client.MatchClosed += onClosed;
        try
        {
            client.ReleaseEndedMatchForNewSearch();
            Require(!client.OwnsMatch && !client.IsConnected && SelfHostedBattleClient.Active == null &&
                closeNotifications == 1 && client.State.ToByteString().Equals(frozen),
                "Terminal release must clear local ownership once without rewriting the retained snapshot.");
        }
        finally
        {
            client.MatchClosed -= onClosed;
            client.LeaveMatch();
        }

        Debug.Log("PASS: ended local transport releases ownership once and preserves its retained terminal snapshot; " +
            "controlled state, no fresh Backend allocation proof.");
    }

    /// <summary>Requires a live retained match to reject a new random search before UI/profile work.</summary>
    public static void VerifyLiveOwner(SelfHostedBattleClient client)
    {
        GameControllerDeathMatch controller = Array.Find(Resources.FindObjectsOfTypeAll<GameControllerDeathMatch>(),
            candidate => candidate.GetType() == typeof(GameControllerDeathMatch) &&
                candidate.gameObject.scene.IsValid() && !candidate.gameObject.activeInHierarchy);
        Require(controller != null && client == SelfHostedBattleClient.Active && client.OwnsMatch,
            "The isolated random-search controller/owner is missing.");
        BattlePhase originalPhase = client.State.Phase;
        int originalPlayerCount = PlayerController.players.Count;
        bool wasRandom = controller.isRandomMatchMaking;
        try
        {
            client.State.Phase = BattlePhase.Running;
            VerifyRejection(controller);
            Require(client.OwnsMatch && SelfHostedBattleClient.Active == client &&
                PlayerController.players.Count == originalPlayerCount && controller.isRandomMatchMaking == wasRandom,
                "Rejected random search changed the live owner, player roster or lobby mode.");
        }
        finally
        {
            client.State.Phase = originalPhase;
        }

        Debug.Log("PASS: actual random matchmaking refuses a retained running match before lobby/player mutation.");
    }

    private static void VerifyRejection(GameControllerDeathMatch controller)
    {
        try
        {
            controller.StartRandomMatchMaking();
        }
        catch (InvalidOperationException failure)
        {
            Require(failure.Message == "Only a confirmed ended match can be released for a fresh search.",
                "Random search failed after entering an unrelated UI/profile path: " + failure.Message);
            return;
        }

        throw new InvalidOperationException("Random search replaced an active battle.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
