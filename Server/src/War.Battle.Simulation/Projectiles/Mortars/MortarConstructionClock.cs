namespace War.BattleServer;

/// <summary>Preserves the native queued idle start tick after the final down-animation frame.</summary>
internal static class MortarConstructionClock
{
    private const float MaximumClipSeconds = 60f;

    internal static (string Clip, ulong StartTick) PoseAt(ulong enteredTick, ulong tick, float downSeconds)
    {
        if (tick < enteredTick || !float.IsFinite(downSeconds) || downSeconds <= 0f ||
            downSeconds > MaximumClipSeconds)
        {
            throw new InvalidDataException("Mortar construction lost its bounded animation clock.");
        }
        ulong downTicks = (ulong)MathF.Ceiling(downSeconds * MatchManifest.TickRate);
        ulong idleStartTick = checked(enteredTick + downTicks);
        return tick < idleStartTick ? ("mortar_down", enteredTick) : ("mortar_down_idle", idleStartTick);
    }
}
