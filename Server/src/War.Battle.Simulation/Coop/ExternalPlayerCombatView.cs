using War.Protocol;

namespace War.BattleServer;

/// <summary>Host-owned active-class pose routing for a participant temporarily outside rifle simulation.</summary>
internal sealed record ExternalPlayerCombatView(
    Func<string, bool> IsActive,
    Func<string, PlayerAimPose> Pose,
    Func<string, RiflePoseState> Snapshot);
