using Google.Protobuf;
using War.Protocol;

/// <summary>Checks the exact Unity presentation classifier against real co-op wire transitions.</summary>
internal static class CoopDeparturePresentationTests
{
    private const string LocalId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string RemoteId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    internal static int Run()
    {
        VerifyConfirmedDeparture();
        VerifyLoadingAndSpectatorBoundaries();
        VerifyRosterBoundaries();
        return 10;
    }

    private static void VerifyConfirmedDeparture()
    {
        MatchSnapshot snapshot = CreateDeparture();
        Require(IsDeparture(snapshot), "A confirmed inactive peer must show the source departure presentation.");
        Require(IsDeparture(MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray())),
            "The exact Unity classifier must accept the real protobuf round trip.");
        snapshot.Coop.ParticipantIds.Add(RemoteId);
        Require(!IsDeparture(snapshot), "An inactive flag alone must not imply removal from the running mission.");
    }

    private static void VerifyLoadingAndSpectatorBoundaries()
    {
        MatchSnapshot snapshot = CreateDeparture();
        snapshot.Coop.Started = false;
        Require(!IsDeparture(snapshot), "Loading must not present a departing partner.");
        snapshot.Coop.Started = true;
        snapshot.Phase = BattlePhase.Ended;
        Require(!IsDeparture(snapshot), "A shared terminal result must not resume the survivor's mission.");
        snapshot.Phase = BattlePhase.Running;
        snapshot.Players[0].Dead = true;
        Require(!IsDeparture(snapshot), "A dead local spectator must not resume a running player presentation.");
        snapshot.Players[0].Dead = false;
        snapshot.Players[1].Ready = true;
        snapshot.Players[1].Dead = true;
        Require(!IsDeparture(snapshot), "A ready dead partner is a KIA transition, not a departure.");
    }

    private static void VerifyRosterBoundaries()
    {
        MatchSnapshot snapshot = CreateDeparture();
        snapshot.Coop.ParticipantIds[0] = RemoteId;
        Require(!IsDeparture(snapshot), "Local departure must not display a remote departure notification.");
        snapshot.Coop.ParticipantIds[0] = LocalId;
        snapshot.Players[1].PlayerId = LocalId;
        Require(!IsDeparture(snapshot), "Duplicate player history must not substitute for the expected remote peer.");
        snapshot.Players[1].PlayerId = RemoteId;
        snapshot.Players[1].Admitted = false;
        Require(!IsDeparture(snapshot), "A peer who never entered must not be shown as leaving a played mission.");
    }

    private static MatchSnapshot CreateDeparture()
    {
        var snapshot = new MatchSnapshot
        {
            Phase = BattlePhase.Running,
            Coop = new BattleCoopState { Started = true }
        };
        snapshot.Players.Add(new BattlePlayerState { PlayerId = LocalId, Admitted = true, Ready = true });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = RemoteId, Admitted = true, CoopDeparted = true });
        snapshot.Coop.ParticipantIds.Add(LocalId);
        return snapshot;
    }

    private static bool IsDeparture(MatchSnapshot snapshot)
    {
        return SelfHostedCoopDepartureState.IsRemoteDeparture(snapshot, LocalId, RemoteId);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
