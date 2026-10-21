using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpBonusProgressFrame(ulong FrameId,
    IReadOnlyList<PvpOwnerStreakFrame> Players, IReadOnlyList<PvpBonusDelayedRequest> MaturedRequests);
