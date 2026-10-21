using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusGrenadeBurstPlan(string BoxId, string RecipientPlayerId,
    IReadOnlyList<PvpBonusGrenadeLaunch> Launches);
