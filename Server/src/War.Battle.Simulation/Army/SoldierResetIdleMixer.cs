namespace War.BattleServer;

/// <summary>Observed Reset-to-Riffle-idle layers after a sampled slide at 30 Hz.</summary>
internal sealed record SoldierResetIdleSnapshot(HelicopterFadeLayer Idle, HelicopterFadeLayer StoppedSlide);

/// <summary>Projects the captured initial idle fade; visibility, prior pose and later commands are separate.</summary>
internal static class SoldierResetIdleMixer
{
    internal static SoldierResetIdleSnapshot AtFixedTicks(ulong elapsedTicks)
    {
        // The incoming layer uses the same observed default CrossFade weight accumulation as the slide transition.
        HelicopterFadeLayer idle = HelicopterSlideFade.AtFixedTicks(0, elapsedTicks).Slide;
        // Animation.Stop clears time/enabled, while this captured outgoing slide retains weight one.
        return new SoldierResetIdleSnapshot(idle, new HelicopterFadeLayer(0, 1, false));
    }
}
