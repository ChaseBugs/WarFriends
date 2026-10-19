using System.Numerics;

namespace War.BattleServer;

internal enum CrewEntryCallback
{
    Start,
    Update,
}

internal enum CrewEntryClockMode
{
    Unscaled,
    Scaled,
}

/// <summary>One host-observed Unity callback; frame identity does not replace callback identity.</summary>
internal sealed record CrewEntryInvocation
{
    internal required ulong Frame { get; init; }
    internal required CrewEntryCallback Callback { get; init; }
    internal required CrewEntryClockMode ClockMode { get; init; }
    internal required float Realtime { get; init; }
    internal required float ScaledDelta { get; init; }
    internal required Vector3 PointPosition { get; init; }
}

/// <summary>Preserves one component's Start lifetime and distinct automatic updates across reuse.</summary>
internal sealed class HelicopterCrewEntryDispatch
{
    private readonly HelicopterCrewEntryState _entry;
    private bool _hasStarted;
    private bool _hasUpdatedFrame;
    private ulong? _lastFrame;

    internal HelicopterCrewEntryDispatch(HelicopterCrewEntryState entry)
    {
        ArgumentNullException.ThrowIfNull(entry);
        _entry = entry;
    }

    /// <summary>Validates dispatch order before advancing the owned entry state.</summary>
    internal HelicopterRopeBodyPose Advance(CrewEntryInvocation invocation)
    {
        ArgumentNullException.ThrowIfNull(invocation);
        if (!Enum.IsDefined(invocation.Callback) || !Enum.IsDefined(invocation.ClockMode) ||
            !float.IsFinite(invocation.Realtime) || invocation.Realtime < 0 ||
            !float.IsFinite(invocation.ScaledDelta) || invocation.ScaledDelta < 0)
        {
            throw new InvalidDataException("Crew entry callback requires a known kind, mode and valid clocks.");
        }
        bool isStart = invocation.Callback == CrewEntryCallback.Start;
        if ((isStart && _hasStarted) || (!isStart && !_hasStarted) ||
            (_lastFrame.HasValue && invocation.Frame < _lastFrame.Value) ||
            (!isStart && _hasUpdatedFrame && invocation.Frame == _lastFrame))
        {
            throw new InvalidDataException("Crew entry callback is repeated, reversed or missing its initial Start.");
        }
        // Source Start invokes Update itself; the normal Update in that same frame is a separate observation.
        HelicopterRopeBodyPose pose = invocation.ClockMode == CrewEntryClockMode.Unscaled
            ? _entry.AdvanceUpdate(invocation.Realtime, invocation.PointPosition)
            : _entry.AdvanceScaledUpdate(invocation.ScaledDelta, invocation.PointPosition);
        _hasStarted = true;
        _hasUpdatedFrame = !isStart;
        _lastFrame = invocation.Frame;
        return pose;
    }
}
