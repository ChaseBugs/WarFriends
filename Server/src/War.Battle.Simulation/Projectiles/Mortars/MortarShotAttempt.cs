namespace War.BattleServer;

/// <summary>Owns one construction cycle's captured target and delayed single-shot callback.</summary>
internal sealed class MortarShotAttempt
{
    private const float CallbackDelaySeconds = 0.3f;

    internal ulong PreparedTick { get; }
    internal ulong CallbackTick { get; }
    internal ulong PollTick { get; }
    internal MortarShotTarget? Target { get; }
    internal bool IsFake { get; }
    internal ulong? CompletedTick { get; set; }
    internal ulong? ProjectileId { get; set; }

    internal MortarShotAttempt(ulong preparedTick, MortarShotTarget? target, bool isFake)
    {
        PreparedTick = preparedTick;
        CallbackTick = checked(preparedTick + (ulong)MathF.Ceiling(CallbackDelaySeconds * MatchManifest.TickRate));
        PollTick = CoopShotCallbackClock.FirstGameplayPollTick(CallbackTick);
        Target = target;
        IsFake = isFake;
    }
}
