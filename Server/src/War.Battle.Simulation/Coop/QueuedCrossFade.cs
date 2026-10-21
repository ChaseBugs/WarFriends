namespace War.BattleServer;

internal sealed record QueuedBlend(double IncomingSeconds,float IncomingWeight);

// Continuous phase model verified against the isolated Unity legacy-animation
// probe. Tick/queue activation and interrupted mixes still need rig integration.
internal static class QueuedCrossFade
{
    internal const float DefaultDuration=.3f;
    internal static QueuedBlend Sample(double outgoingSeconds,double outgoingLength,float fadeSeconds=DefaultDuration)
    {
        if (!double.IsFinite(outgoingSeconds)||outgoingSeconds is < 0 or > 86400 ||
            !double.IsFinite(outgoingLength)||outgoingLength is <= 0 or > 60 ||
            !float.IsFinite(fadeSeconds)||fadeSeconds is <= 0 or > 60)
            throw new InvalidDataException("Invalid queued animation blend.");
        if (outgoingLength<fadeSeconds) throw new InvalidDataException("Short-clip queued fades require additional Unity evidence.");
        double elapsed=Math.Max(0,outgoingSeconds-(outgoingLength-fadeSeconds));
        return new(elapsed,(float)Math.Clamp(elapsed/fadeSeconds,0,1));
    }
}
