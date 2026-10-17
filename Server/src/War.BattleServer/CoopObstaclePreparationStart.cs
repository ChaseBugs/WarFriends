namespace War.BattleServer;

/// <summary>Preserves the previous crawl identity before a new volley replaces its clock and round history.</summary>
internal sealed class CoopObstaclePreparationStart
{
    private const int CompletedReturnPhase = 16;
    private const int ObservationCount = 13;

    private readonly PreviousActivity _previous;

    internal ulong CapturedTick { get; }
    internal bool HasPreviousAttempt { get; }
    internal ulong? PreviousReturnTick => _previous.ReturnTick;
    internal ulong? PreviousRoundTick => _previous.RoundTick;
    internal int? PriorReturnTicks { get; }
    internal bool HasUnverifiedTransition => HasPreviousAttempt && PriorReturnTicks != CompletedReturnPhase;

    private CoopObstaclePreparationStart(ulong capturedTick, bool hasPreviousAttempt,
        PreviousActivity previous, int? priorReturnTicks)
    {
        CapturedTick = capturedTick;
        HasPreviousAttempt = hasPreviousAttempt;
        _previous = previous;
        PriorReturnTicks = priorReturnTicks;
    }

    internal static CoopObstaclePreparationStart Unresolved(ulong tick, bool hasPreviousAttempt,
        ulong? previousReturnTick = null, ulong? previousRoundTick = null)
    {
        ValidateActivity(tick, previousReturnTick, previousRoundTick);
        if (!hasPreviousAttempt && (previousReturnTick.HasValue || previousRoundTick.HasValue))
        {
            throw new InvalidDataException("A first obstacle attempt cannot own previous activity.");
        }
        return new CoopObstaclePreparationStart(tick, hasPreviousAttempt,
            new PreviousActivity(previousReturnTick, previousRoundTick), null);
    }

    internal static CoopObstaclePreparationStart FromReturn(ulong tick, ulong returnTick, float clipLength,
        ulong? previousRoundTick = null)
    {
        ValidateActivity(tick, returnTick, previousRoundTick);
        if (previousRoundTick.HasValue && previousRoundTick.Value >= returnTick)
        {
            throw new InvalidDataException("A confirmed round after return does not prove a known crawl pose.");
        }
        if (!float.IsFinite(clipLength) || clipLength <= 0f ||
            MathF.Ceiling(clipLength * MatchManifest.TickRate) != CompletedReturnPhase)
        {
            throw new InvalidDataException("The crawl clip does not match the reviewed fixed-step phase domain.");
        }
        // ShootFromCrawl clamps completed return progress; preserve its real epoch separately from the catalog phase.
        int phase = (int)Math.Min(tick - returnTick, (ulong)CompletedReturnPhase);
        return new CoopObstaclePreparationStart(tick, true, new PreviousActivity(returnTick, previousRoundTick), phase);
    }

    internal int? SelectSampleId(ulong sampleTick)
    {
        if (sampleTick < CapturedTick)
        {
            throw new InvalidDataException("An obstacle preparation sample cannot precede its captured origin.");
        }
        ulong elapsed = sampleTick - CapturedTick;
        if (PriorReturnTicks == null || elapsed >= ObservationCount)
        {
            return null;
        }
        return 1 + PriorReturnTicks.Value * ObservationCount + (int)elapsed;
    }

    private static void ValidateActivity(ulong tick, ulong? returnTick, ulong? roundTick)
    {
        if ((returnTick.HasValue && returnTick.Value > tick) || (roundTick.HasValue && roundTick.Value > tick))
        {
            throw new InvalidDataException("Previous obstacle activity cannot be in the future.");
        }
    }

    private sealed record PreviousActivity(ulong? ReturnTick, ulong? RoundTick);
}
