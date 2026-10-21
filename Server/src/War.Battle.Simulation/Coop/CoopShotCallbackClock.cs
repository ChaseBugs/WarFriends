namespace War.BattleServer;

/// <summary>Separates the recovered delayed callback from the next gameplay Update that can fire.</summary>
internal static class CoopShotCallbackClock
{
    private const float SourceCallbackPaddingSeconds = 0.05f;
    private const float MaximumClipSeconds = 60f;
    private const ulong MinimumDelayTicks = 1;

    internal static ulong CallbackTick(ulong preparationTick, float clipSeconds)
    {
        if (!float.IsFinite(clipSeconds) || clipSeconds <= 0 || clipSeconds > MaximumClipSeconds)
        {
            throw new InvalidDataException("The shot callback requires a bounded recovered animation length.");
        }

        // Preserve the source float addition before projecting its deadline onto the fixed host clock.
        float delaySeconds = clipSeconds + SourceCallbackPaddingSeconds;
        ulong delayTicks = (ulong)Math.Ceiling(delaySeconds * MatchManifest.TickRate);
        return checked(preparationTick + Math.Max(MinimumDelayTicks, delayTicks));
    }

    internal static ulong FirstGameplayPollTick(ulong callbackTick)
    {
        // WaitForSeconds resumes after Update, so ShootingFromWeapon can first see it on the next Update.
        return checked(callbackTick + 1);
    }
}
