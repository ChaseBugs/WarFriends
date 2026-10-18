namespace War.BattleServer;

internal enum GunslingerFireLoopEntry
{
    FreshQueuedFire,
    ReplaceQueuedClone,
    RestartEnabledFire
}

/// <summary>Separates source Colt callbacks, gameplay polls and native fire-loop activation phases.</summary>
internal static class GunslingerFiringClock
{
    internal const float CadenceSeconds = 0.18f;
    private const float MaximumDelaySeconds = 60f;
    private const ulong MaximumPhaseTicks = 60 * MatchManifest.TickRate;

    internal static ulong CallbackTick(ulong preparationTick, float selectedPhaseZeroLength)
    {
        ValidateDelay(selectedPhaseZeroLength);
        // Gunslinger uses GetStandPhase0Length directly, with no Corner callback padding.
        // InvokeAfter(0) still resumes in a later coroutine phase, not inside preparation.
        ulong delay = (ulong)MathF.Ceiling(selectedPhaseZeroLength * MatchManifest.TickRate);
        return checked(preparationTick + Math.Max(1UL, delay));
    }

    internal static ulong GameplayPollTick(ulong callbackTick)
    {
        return CoopShotCallbackClock.FirstGameplayPollTick(callbackTick);
    }

    internal static ulong NextPreparationTick(ulong shotTick)
    {
        // ReturnToPreviousStateFromShotGunSlinger writes cadence, then tests strict mTime > next time.
        return checked(shotTick + (ulong)MathF.Floor(CadenceSeconds * MatchManifest.TickRate) + 1);
    }

    internal static float? FireLoopSeconds(GunslingerFireLoopEntry entry, ulong elapsedTick, float startLength)
    {
        ValidateDelay(startLength);
        if (startLength == 0f || elapsedTick > MaximumPhaseTicks)
        {
            throw new InvalidDataException("Gunslinger fire-loop phase lost bounded source animation authority.");
        }

        switch (entry)
        {
            case GunslingerFireLoopEntry.FreshQueuedFire:
                ulong loopStart = (ulong)MathF.Ceiling(startLength * MatchManifest.TickRate);
                return elapsedTick < loopStart ? null : (elapsedTick - loopStart) / (float)MatchManifest.TickRate;
            case GunslingerFireLoopEntry.ReplaceQueuedClone:
                // Playing the ordinary loop for the first time replaces its queued clone.
                return elapsedTick == 0 ? null : (elapsedTick - 1) / (float)MatchManifest.TickRate;
            case GunslingerFireLoopEntry.RestartEnabledFire:
                return elapsedTick / (float)MatchManifest.TickRate;
            default:
                throw new InvalidDataException("Unknown Gunslinger source fire-loop entry.");
        }
    }

    private static void ValidateDelay(float seconds)
    {
        if (!float.IsFinite(seconds) || seconds < 0f || seconds > MaximumDelaySeconds)
        {
            throw new InvalidDataException("Gunslinger callback requires a finite recovered animation delay.");
        }
    }
}
