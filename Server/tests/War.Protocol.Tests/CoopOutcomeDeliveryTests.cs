using War.Client;
using War.Protocol;

/// <summary>Checks scene result delivery across replay, reentrancy and failed callbacks.</summary>
internal static class CoopOutcomeDeliveryTests
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string MatchId = "scene-match";
    private const string ManifestHash = "scene-manifest";

    internal static int Run()
    {
        VerifyIdentityAndReplay();
        VerifyCallbackRetry();
        VerifyReentrancy();
        VerifyMalformedStateDoesNotConsumeDelivery();
        VerifyNonSharedResults();
        return 10;
    }

    private static void VerifyIdentityAndReplay()
    {
        int callbacks = 0;
        var delivery = new CoopOutcomeDelivery(MatchId, ManifestHash, MasterId, reason =>
        {
            Require(reason == ClientGameEndReason.MissionSuccess, "The callback must retain the source result.");
            callbacks++;
        });
        MatchSnapshot snapshot = CreateSuccess();
        snapshot.MatchId = "another-match";
        Require(!delivery.ApplySnapshot(snapshot) && callbacks == 0, "Another match must not finish this scene.");
        snapshot.MatchId = MatchId;
        snapshot.ManifestHash = "another-manifest";
        Require(!delivery.ApplySnapshot(snapshot) && callbacks == 0, "Another manifest must not finish this scene.");
        snapshot.ManifestHash = ManifestHash;
        Require(delivery.ApplySnapshot(snapshot) && callbacks == 1, "A valid result must finish the scene once.");
        Require(!delivery.ApplySnapshot(snapshot.Clone()) && callbacks == 1, "A replay must not finish twice.");
    }

    private static void VerifyCallbackRetry()
    {
        int callbacks = 0;
        var delivery = new CoopOutcomeDelivery(MatchId, ManifestHash, MasterId, reason =>
        {
            callbacks++;
            if (callbacks == 1)
            {
                throw new InvalidOperationException("Presentation unavailable.");
            }
        });
        bool hasThrown = false;
        try
        {
            delivery.ApplySnapshot(CreateSuccess());
        }
        catch (InvalidOperationException)
        {
            hasThrown = true;
        }

        Require(hasThrown && delivery.ApplySnapshot(CreateSuccess()) && callbacks == 2,
            "A callback failure must propagate without consuming the successful-delivery marker.");
    }

    private static void VerifyReentrancy()
    {
        int callbacks = 0;
        CoopOutcomeDelivery? delivery = null;
        delivery = new CoopOutcomeDelivery(MatchId, ManifestHash, MasterId, reason =>
        {
            callbacks++;
            Require(delivery != null && !delivery.ApplySnapshot(CreateSuccess()),
                "Scene reset must not recursively deliver the same finish.");
        });
        Require(delivery.ApplySnapshot(CreateSuccess()) && callbacks == 1,
            "A reentrant callback must complete exactly once.");
    }

    private static void VerifyMalformedStateDoesNotConsumeDelivery()
    {
        int callbacks = 0;
        var delivery = new CoopOutcomeDelivery(MatchId, ManifestHash, MasterId, reason => callbacks++);
        MatchSnapshot malformed = CreateSuccess();
        malformed.WinnerPlayerId = MasterId;
        bool hasThrown = false;
        try
        {
            delivery.ApplySnapshot(malformed);
        }
        catch (InvalidDataException)
        {
            hasThrown = true;
        }

        Require(hasThrown && callbacks == 0 && delivery.ApplySnapshot(CreateSuccess()) && callbacks == 1,
            "Invalid authority must not call the scene or consume its later valid result.");
    }

    private static void VerifyNonSharedResults()
    {
        int callbacks = 0;
        var delivery = new CoopOutcomeDelivery(MatchId, ManifestHash, MasterId, reason => callbacks++);
        MatchSnapshot running = CreateSuccess();
        running.Phase = BattlePhase.Running;
        running.EndTick = 0;
        running.TerminalReason = "";
        running.Coop.Completed = false;
        running.Coop.SuccessScores.Clear();
        running.Coop.PeerCompletionPlayerIds.Clear();
        Require(!delivery.ApplySnapshot(running) && callbacks == 0, "A running mission must not finish the scene.");
        MatchSnapshot pvp = CreateSuccess();
        pvp.Coop = null;
        Require(!delivery.ApplySnapshot(pvp) && callbacks == 0, "This delivery must never route a PvP result.");

        const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        var peerDelivery = new CoopOutcomeDelivery(MatchId, ManifestHash, PeerId, reason => callbacks++);
        MatchSnapshot departed = CreateSuccess();
        departed.Players[1].CoopDeparted = true;
        departed.Players[1].Ready = false;
        departed.Coop.ParticipantIds.Remove(PeerId);
        departed.Coop.PeerCompletionPlayerIds.Clear();
        Require(!peerDelivery.ApplySnapshot(departed) && callbacks == 0,
            "A departed peer's later shared result must not reopen its finished scene.");
    }

    private static MatchSnapshot CreateSuccess()
    {
        MatchSnapshot snapshot = CoopOutcomeProjectionTests.CreateSuccess();
        snapshot.MatchId = MatchId;
        snapshot.ManifestHash = ManifestHash;
        return snapshot;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
