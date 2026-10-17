using System;
using System.Reflection;
using UnityEngine;
using War.Protocol;

/// <summary>Checks actual controller owner resolution before any profile-dependent player mutation.</summary>
public static class UnityControllerOwnerAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    /// <summary>Requires inactive retained ownership to reach the roster-ownership guard.</summary>
    public static void Verify(SelfHostedBattleClient client)
    {
        GameControllerOnline controller = Array.Find(Resources.FindObjectsOfTypeAll<GameControllerOnline>(),
            candidate => candidate.gameObject.scene.IsValid() && !candidate.gameObject.activeInHierarchy);
        Require(controller != null && client == SelfHostedBattleClient.Active && client.OwnsMatch &&
            !client.gameObject.activeInHierarchy, "The controlled inactive controller/session fixture is missing.");
        FieldInfo connectedPlayers = typeof(GameControllerOnline).GetField("mBothPlayersConnected", PrivateInstance);
        Require(!(bool)connectedPlayers.GetValue(controller), "The fixture must not replace initialized players.");
        PropertyInfo roster = typeof(SelfHostedBattleClient).GetProperty("PlayerViews");
        PropertyInfo connected = typeof(SelfHostedBattleClient).GetProperty("IsConnected");
        object previousRoster = roster.GetValue(client, null);
        object previousConnection = connected.GetValue(client, null);
        try
        {
            // Missing local ownership must reject before any PlayerController/profile fields are written.
            roster.SetValue(client, new[]
            {
                new BattlePlayerView { PlayerId = new string('d', 32) },
                new BattlePlayerView { PlayerId = new string('e', 32) }
            }, null);
            connected.SetValue(client, true, null);
            VerifyRosterRejection(controller);
            Require(!(bool)connectedPlayers.GetValue(controller), "Rejected ownership initialized game players.");
        }
        finally
        {
            roster.SetValue(client, previousRoster, null);
            connected.SetValue(client, previousConnection, null);
        }

        Debug.Log("PASS: actual controller resolves the inactive retained owner and rejects absent local roster " +
            "ownership before player mutation; no complete player/bootstrap proof.");
    }

    private static void VerifyRosterRejection(GameControllerOnline controller)
    {
        try
        {
            typeof(GameControllerOnline).GetMethod("InitializeSelfHostedPlayers", PrivateInstance)
                .Invoke(controller, null);
        }
        catch (TargetInvocationException failure)
        {
            Require(failure.InnerException is InvalidOperationException &&
                failure.InnerException.Message == "Self-hosted roster ownership is invalid.",
                "The controller lost the retained owner before checking roster ownership: " + failure.InnerException);
            return;
        }

        throw new InvalidOperationException("The controller accepted a roster without local ownership.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
