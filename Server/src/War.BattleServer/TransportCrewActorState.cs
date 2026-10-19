namespace War.BattleServer;

/// <summary>Tracks one confirmed secondary actor independently of its original aircraft.</summary>
internal sealed class TransportCrewActorState
{
    private const float MaximumSupportedHealth = 10_000_000;
    private const int MaximumSeats = 6;

    private ulong _lastMutationTick;

    internal ulong EntityId { get; }

    internal ulong AircraftId { get; }

    internal int SeatComponentFileId { get; }

    internal float MaximumHealth { get; }

    internal float Health { get; private set; }

    internal bool IsAttached { get; private set; } = true;

    internal ulong DeathTick { get; private set; }

    internal TransportCrewActorState(
        CoopMatchRuntime.TransportCrewIdentity identity,
        ulong aircraftId,
        HelicopterCrewMemberSnapshot member,
        ulong tick)
    {
        ArgumentNullException.ThrowIfNull(identity);
        ArgumentNullException.ThrowIfNull(member);
        if (identity.EntityId == 0 || aircraftId == 0 || identity.EntityId == aircraftId ||
            identity.Slot < 0 || identity.Slot >= MaximumSeats || identity.Slot != member.Slot ||
            identity.PointComponentFileId != member.PointComponentFileId ||
            member.PointComponentFileId <= 0 || tick == 0 || member.SpawnTick != tick ||
            !float.IsFinite(member.Maximum) || member.Maximum <= 0 ||
            member.Maximum > MaximumSupportedHealth || member.Health != member.Maximum)
        {
            throw new InvalidDataException("Confirmed crew identity and initial health must match its source seat.");
        }

        EntityId = identity.EntityId;
        AircraftId = aircraftId;
        SeatComponentFileId = member.PointComponentFileId;
        MaximumHealth = member.Maximum;
        Health = member.Health;
        _lastMutationTick = tick;
    }

    /// <summary>Called only when host SetFinalTarget behavior actually releases the source seat.</summary>
    internal bool Detach(ulong tick)
    {
        if (!CanMutate(tick) || !IsAttached)
        {
            return false;
        }

        IsAttached = false;
        _lastMutationTick = tick;
        return true;
    }

    /// <summary>Applies a host-resolved impact; hit selection and mission credit remain separate.</summary>
    internal bool Damage(float amount, ulong tick)
    {
        if (!CanMutate(tick) || !float.IsFinite(amount) || amount <= 0 || amount > MaximumSupportedHealth)
        {
            return false;
        }

        Health = MathF.Max(0, Health - amount);
        _lastMutationTick = tick;
        if (Health == 0)
        {
            DeathTick = tick;
        }

        return true;
    }

    /// <summary>Preserves Vehicle.DestroySoldier's current seat binding check.</summary>
    internal bool DestroyWithAircraft(ulong aircraftId, ulong tick)
    {
        if (aircraftId != AircraftId || !IsAttached || !CanMutate(tick))
        {
            return false;
        }

        return Damage(Health, tick);
    }

    private bool CanMutate(ulong tick)
    {
        return tick >= _lastMutationTick && Health > 0;
    }
}
