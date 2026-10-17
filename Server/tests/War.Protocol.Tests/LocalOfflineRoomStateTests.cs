using War.Client;

/// <summary>Checks callback-visible local identities against the recovered offline room transition contract.</summary>
internal static class LocalOfflineRoomStateTests
{
    internal static int Run()
    {
        int checks = VerifyLifecycle();
        checks += VerifyCallbackCancellation();
        checks += VerifyDetachedObservation();
        checks += VerifyJoinedObservation();
        Console.WriteLine("PASS: " + checks + " local solo callback-visible identity checks");
        return checks;
    }

    private static int VerifyJoinedObservation()
    {
        var room = new LocalOfflineRoom();
        var observed = new List<RoomView>();
        room.Callback += callback => observed.Add(Capture(callback, room));

        room.ObserveJoinedOfflineRoom();
        room.ObserveJoinedOfflineRoom();

        Require(room.IsOffline && room.IsInRoom && room.PlayerId == 1 &&
            room.MasterPlayerId == 1 && room.PlayerCount == 1 && observed.Count == 0,
            "Observed room adoption must publish membership without duplicating external callbacks.");
        room.LeaveRoom();
        Require(observed.SequenceEqual(new[] { Detached(LocalRoomCallback.LeftRoom, 1) }),
            "An observed room must retain the recovered local identity when it is left.");
        return 2;
    }

    private static int VerifyLifecycle()
    {
        var room = new LocalOfflineRoom();
        var observed = new List<RoomView>();
        room.Callback += callback => observed.Add(Capture(callback, room));
        room.JoinSoloRoom();
        Require(observed.SequenceEqual(new[]
        {
            Detached(LocalRoomCallback.ConnectedToMaster, -1), Detached(LocalRoomCallback.LeftRoom, -1),
            Joined(LocalRoomCallback.CreatedRoom), Joined(LocalRoomCallback.JoinedRoom)
        }), "First join must expose detached identity before publishing the solo player.");

        observed.Clear();
        room.JoinSoloRoom();
        Require(observed.SequenceEqual(new[]
        {
            Detached(LocalRoomCallback.LeftRoom, 1), Joined(LocalRoomCallback.CreatedRoom),
            Joined(LocalRoomCallback.JoinedRoom)
        }), "Replacement leave must preserve the local identity until the next room is created.");

        observed.Clear();
        room.LeaveRoom();
        Require(observed.SequenceEqual(new[] { Detached(LocalRoomCallback.LeftRoom, 1) }),
            "Explicit leave must clear membership without resetting the offline local identity.");
        observed.Clear();
        room.JoinSoloRoom();
        Require(observed.SequenceEqual(new[]
        {
            Detached(LocalRoomCallback.LeftRoom, 1), Joined(LocalRoomCallback.CreatedRoom),
            Joined(LocalRoomCallback.JoinedRoom)
        }), "Rejoining an empty offline room must preserve the repeated leave callback and local identity.");

        observed.Clear();
        room.Disconnect();
        Require(observed.SequenceEqual(new[] { new RoomView { Callback = LocalRoomCallback.Disconnected } }) &&
            !room.IsOffline && !room.IsInRoom && room.PlayerId == -1 &&
            room.MasterPlayerId == -1 && room.PlayerCount == 0,
            "Disconnect must publish its reset state once without inventing a room-leave callback.");
        observed.Clear();
        room.Disconnect();
        Require(observed.Count == 0, "An already disconnected model must not repeat its disconnect notification.");
        room.ObserveExistingOfflineMode();
        room.JoinSoloRoom();
        Require(observed.SequenceEqual(new[]
        {
            Detached(LocalRoomCallback.LeftRoom, -1), Joined(LocalRoomCallback.CreatedRoom),
            Joined(LocalRoomCallback.JoinedRoom)
        }), "A pre-enabled offline scene must not reconnect or retain a previous session's player identity.");
        return 7;
    }

    private static int VerifyCallbackCancellation()
    {
        int checks = 0;
        foreach (LocalRoomCallback cancelAt in new[]
            { LocalRoomCallback.ConnectedToMaster, LocalRoomCallback.LeftRoom, LocalRoomCallback.CreatedRoom })
        {
            var room = new LocalOfflineRoom();
            var observed = new List<RoomView>();
            room.Callback += callback =>
            {
                observed.Add(Capture(callback, room));
                if (callback == cancelAt)
                {
                    room.Disconnect();
                }
            };
            bool isAccepted = true;
            try
            {
                room.JoinSoloRoom();
            }
            catch (InvalidOperationException)
            {
                isAccepted = false;
            }
            Require(observed.SequenceEqual(ExpectedCancellation(cancelAt)) &&
                isAccepted == (cancelAt == LocalRoomCallback.CreatedRoom) && !room.IsOffline && !room.IsInRoom,
                "Callback cancellation differs from the recovered join command at " + cancelAt + ".");
            checks++;
        }
        return checks;
    }

    private static RoomView[] ExpectedCancellation(LocalRoomCallback cancelAt)
    {
        RoomView connected = Detached(LocalRoomCallback.ConnectedToMaster, -1);
        RoomView left = Detached(LocalRoomCallback.LeftRoom, -1);
        var disconnected = new RoomView { Callback = LocalRoomCallback.Disconnected };
        switch (cancelAt)
        {
            case LocalRoomCallback.ConnectedToMaster:
                return new[] { connected, disconnected };
            case LocalRoomCallback.LeftRoom:
                return new[] { connected, left, disconnected };
            case LocalRoomCallback.CreatedRoom:
                return new[] { connected, left, Joined(LocalRoomCallback.CreatedRoom), disconnected,
                    new RoomView { Callback = LocalRoomCallback.JoinedRoom } };
            default:
                throw new ArgumentOutOfRangeException(nameof(cancelAt));
        }
    }

    private static int VerifyDetachedObservation()
    {
        var room = new LocalOfflineRoom();
        var observed = new List<LocalRoomCallback>();
        room.Callback += observed.Add;
        room.JoinSoloRoom();
        observed.Clear();
        room.ObserveDetachedOfflinePlayer(1);
        Require(observed.Count == 0 && room.IsOffline && !room.IsInRoom && room.PlayerId == 1 &&
            room.MasterPlayerId == 1 && room.PlayerCount == 0,
            "Observing an SDK leave must not recreate membership or replay its callbacks.");
        bool isRejected = false;
        try
        {
            room.ObserveDetachedOfflinePlayer(2);
        }
        catch (ArgumentOutOfRangeException)
        {
            isRejected = true;
        }
        Require(isRejected && room.IsOffline && !room.IsInRoom && room.PlayerId == 1 && observed.Count == 0,
            "An invalid observed identity changed local room state before rejection.");
        return 2;
    }

    private static RoomView Capture(LocalRoomCallback callback, LocalOfflineRoom room)
    {
        return new RoomView
        {
            Callback = callback, IsOffline = room.IsOffline, RoomName = room.RoomName,
            PlayerId = room.PlayerId, MasterPlayerId = room.MasterPlayerId, PlayerCount = room.PlayerCount
        };
    }

    private static RoomView Detached(LocalRoomCallback callback, int playerId)
    {
        return new RoomView { Callback = callback, IsOffline = true, PlayerId = playerId, MasterPlayerId = playerId };
    }

    private static RoomView Joined(LocalRoomCallback callback)
    {
        return new RoomView
        {
            Callback = callback, IsOffline = true, RoomName = LocalOfflineRoom.SoloRoomName,
            PlayerId = 1, MasterPlayerId = 1, PlayerCount = 1
        };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed record RoomView
    {
        internal LocalRoomCallback Callback { get; init; }
        internal bool IsOffline { get; init; }
        internal string RoomName { get; init; } = string.Empty;
        internal int PlayerId { get; init; } = -1;
        internal int MasterPlayerId { get; init; } = -1;
        internal int PlayerCount { get; init; }
    }
}
