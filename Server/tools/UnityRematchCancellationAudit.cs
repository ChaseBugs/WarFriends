using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks source-scoped cancellation against a real Backend and a callback-started successor search.</summary>
public static class UnityRematchCancellationAudit
{
    private const int SearchTimeoutSeconds = 90;
    private const int PollDelayMilliseconds = 100;

    /// <summary>Requires remote consent cancellation without authorizing local cleanup of a successor.</summary>
    public static async Task VerifyAsync(
        SelfHostedBattleClient client,
        string endpoint,
        string token,
        CancellationToken cancellationToken)
    {
        MatchSnapshot source = client.State.Clone();
        ByteString frozen = source.ToByteString();
        Task successorSearch = null;
        int closed = 0;
        Action startSuccessor = () =>
        {
            closed++;
            successorSearch = client.MatchmakeAndConnect(endpoint, token, SearchTimeoutSeconds, true);
        };
        Task discovery = client.RematchAndConnectAsync(endpoint, token, true, cancellationToken);
        try
        {
            using (var backend = new BackendClient(new Uri(endpoint), true))
            {
                await WaitForConsentAsync(backend, source.MatchId, token, cancellationToken);
                client.MatchClosed += startSuccessor;
                MethodInfo cancel = typeof(SelfHostedBattleClient).GetMethod(
                    "CancelRematchAndReleaseAsync", BindingFlags.Instance | BindingFlags.NonPublic);
                bool released = await (Task<bool>)cancel.Invoke(client, null);
                await RequireCancelledAsync(discovery);
                MatchRematchConsent receipt = await backend.ReadRematchConsentAsync(
                    source.MatchId, token, cancellationToken);
                Require(receipt.Status == "cancelled" && string.IsNullOrEmpty(receipt.NextMatchId),
                    "The source consent was not durably cancelled before local closure.");
                Require(!released && closed == 1 && successorSearch != null && !successorSearch.IsCompleted &&
                    client.IsMatchmaking &&
                    !client.HasPendingRematch && client.State.ToByteString().Equals(frozen),
                    "Old rematch cleanup authorized local quit after a callback started a successor search.");
                await UnityPendingBattleOwnerAudit.VerifyAsync(client, endpoint, token, cancellationToken);
            }
        }
        finally
        {
            client.MatchClosed -= startSuccessor;
            client.LeaveMatch();
            await RequireCancelledAsync(discovery);
            if (successorSearch != null)
            {
                await RequireCancelledAsync(successorSearch);
            }
            while (client.IsMatchmaking)
            {
                await Task.Delay(PollDelayMilliseconds, cancellationToken);
            }
            Require(SelfHostedBattleClient.Active == null && !client.OwnsBattleOperation,
                "Confirmed successor cleanup retained an empty canonical owner.");
        }

        Debug.Log("UNITY_REMATCH_CANCELLATION_PASSED remoteReceipt=True successorProtected=True");
    }

    private static async Task WaitForConsentAsync(
        BackendClient backend,
        string sourceMatchId,
        string token,
        CancellationToken cancellationToken)
    {
        MatchRematchConsent consent;
        do
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            consent = await backend.ReadRematchConsentAsync(sourceMatchId, token, cancellationToken);
        } while (consent.Status == "not-requested");
        Require(consent.Status == "waiting" && consent.AcceptedPlayerIds.Count == 1,
            "The real one-player consent was not waiting before cancellation.");
    }

    private static async Task RequireCancelledAsync(Task operation)
    {
        try
        {
            await operation;
        }
        catch (OperationCanceledException)
        {
            // Cancellation is the expected terminal outcome of both authenticated discovery operations.
            return;
        }

        throw new InvalidOperationException("Cancelled discovery unexpectedly completed admission.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
