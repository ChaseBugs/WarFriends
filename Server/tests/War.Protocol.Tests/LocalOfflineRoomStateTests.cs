using War.Client;

/// <summary>Checks callback-visible local identities against the recovered offline room transition contract.</summary>
internal static class LocalOfflineRoomStateTests
{
    internal static int Run()
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
        Require(observed.Count == 0 && !room.IsOffline && !room.IsInRoom && room.PlayerId == -1 &&
            room.MasterPlayerId == -1 && room.PlayerCount == 0,
            "Disconnect must reset identities without inventing a room-leave callback.");
        room.ObserveExistingOfflineMode();
        room.JoinSoloRoom();
        Require(observed.SequenceEqual(new[]
        {
            Detached(LocalRoomCallback.LeftRoom, -1), Joined(LocalRoomCallback.CreatedRoom),
            Joined(LocalRoomCallback.JoinedRoom)
        }), "A pre-enabled offline scene must not reconnect or retain a previous session's player identity.");
        Console.WriteLine("PASS: 6 local solo callback-visible identity checks");
        return 6;
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
