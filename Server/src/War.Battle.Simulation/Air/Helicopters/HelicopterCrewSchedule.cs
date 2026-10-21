namespace War.BattleServer;

/// <summary>Projects the recovered initial crew coroutine onto the host's fixed tick clock.</summary>
internal sealed class HelicopterCrewSchedule
{
    private const int MaximumSeats = 6;
    private const ulong InitialWaitTicks = 5UL * MatchManifest.TickRate;
    private const ulong SeatIntervalTicks = 2UL * MatchManifest.TickRate;

    private readonly ulong _stopTick;
    private readonly int _seats;

    internal HelicopterCrewSchedule(ulong stopTick, int seats)
    {
        if (stopTick == 0 || seats is < 1 or > MaximumSeats)
        {
            throw new InvalidDataException("Invalid source Helicopter crew schedule.");
        }

        ulong lastSeatDelay = InitialWaitTicks + SeatIntervalTicks * (ulong)(seats - 1);
        if (stopTick > ulong.MaxValue - lastSeatDelay)
        {
            throw new InvalidDataException("Helicopter crew schedule exceeds the host tick range.");
        }

        _stopTick = stopTick;
        _seats = seats;
    }

    internal ulong DueTick(int slot)
    {
        if (slot < 0 || slot >= _seats)
        {
            throw new ArgumentOutOfRangeException(nameof(slot));
        }

        // DeployEnemies waits five seconds, then two seconds after each ordered seat.
        return _stopTick + InitialWaitTicks + SeatIntervalTicks * (ulong)slot;
    }

    internal IReadOnlyList<int> DueSlots(ulong tick)
    {
        var dueSlots = new List<int>(_seats);
        for (int slot = 0; slot < _seats; slot++)
        {
            if (DueTick(slot) > tick)
            {
                break;
            }

            dueSlots.Add(slot);
        }

        return dueSlots.ToArray();
    }

    internal uint DueMask(ulong tick)
    {
        uint mask = 0;
        for (int slot = 0; slot < _seats; slot++)
        {
            if (DueTick(slot) > tick)
            {
                break;
            }

            mask |= 1u << slot;
        }

        return mask;
    }
}
