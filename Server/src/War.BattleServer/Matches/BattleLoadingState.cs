using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Requires both participants to load the exact manifest before starting play.</summary>
public sealed class BattleLoadingState
{
    private const int RequiredPlayers = 2;
    private const int MaximumReasonLength = 64;
    private const ulong MaximumDeadlineTick = 10_000_000;
    private readonly string _manifestHash;
    private readonly ulong _deadlineTick;
    private readonly HashSet<string> _admittedPlayers = [];
    private readonly HashSet<string> _readyPlayers = [];

    /// <summary>Reports whether both participants completed readiness.</summary>
    public bool Started { get; private set; }

    /// <summary>Reports whether cancellation closed the loading state.</summary>
    public bool Cancelled { get; private set; }

    /// <summary>Returns the stored phase without evaluating a clock.</summary>
    public BattleLoadingPhase Phase
    {
        get
        {
            if (Cancelled)
            {
                return BattleLoadingPhase.Cancelled;
            }

            return Started ? BattleLoadingPhase.Started : BattleLoadingPhase.Waiting;
        }
    }

    /// <summary>Binds readiness to the expected manifest and optional server deadline.</summary>
    public BattleLoadingState(string manifestHash, ulong deadlineTick = 0)
    {
        if (!Regex.IsMatch(manifestHash ?? "", @"\A[0-9a-f]{64}\z") || deadlineTick > MaximumDeadlineTick)
        {
            throw new InvalidDataException("Invalid loading manifest.");
        }

        _manifestHash = manifestHash!;
        _deadlineTick = deadlineTick;
    }

    /// <summary>Evaluates deadline expiry without mutating loading state.</summary>
    public bool TimedOut(ulong tick) => _deadlineTick != 0 && !Started && tick >= _deadlineTick;

    /// <summary>Evaluates the deadline while preserving terminal phase precedence.</summary>
    public BattleLoadingPhase PhaseAt(ulong tick)
    {
        if (Phase != BattleLoadingPhase.Waiting)
        {
            return Phase;
        }

        return TimedOut(tick) ? BattleLoadingPhase.TimedOut : BattleLoadingPhase.Waiting;
    }

    /// <summary>Cancels only before readiness has started the battle.</summary>
    public bool Cancel(string reason)
    {
        if (Started || Cancelled || string.IsNullOrWhiteSpace(reason) || reason.Length > MaximumReasonLength)
        {
            return false;
        }

        Cancelled = true;
        return true;
    }

    /// <summary>Validates a command before applying its loading transition.</summary>
    public bool Apply(BattleLoadingCommand command)
    {
        BattleLoadingCommandValidator.Validate(command);
        return command.Kind switch
        {
            BattleLoadingCommandKind.Admit => Admit(command.PlayerId),
            BattleLoadingCommandKind.Ready => MarkReady(command.PlayerId, command.ManifestHash, true),
            BattleLoadingCommandKind.Cancel => Cancel(command.Reason),
            _ => false
        };
    }

    /// <summary>Admits a distinct participant while room capacity remains available.</summary>
    public bool Admit(string playerId)
    {
        if (Started || Cancelled || !War.Shared.CanonicalGuid.IsCanonical(playerId) || _admittedPlayers.Count >= RequiredPlayers)
        {
            return false;
        }

        return _admittedPlayers.Add(playerId);
    }

    /// <summary>Accepts readiness only for an admitted participant and the exact manifest.</summary>
    public bool MarkReady(string playerId, string manifestHash, bool sceneReady)
    {
        if (Started || Cancelled || !_admittedPlayers.Contains(playerId) || manifestHash != _manifestHash || !sceneReady)
        {
            return false;
        }

        _readyPlayers.Add(playerId);
        if (_admittedPlayers.Count == RequiredPlayers && _readyPlayers.Count == RequiredPlayers)
        {
            Started = true;
        }

        return true;
    }
}
