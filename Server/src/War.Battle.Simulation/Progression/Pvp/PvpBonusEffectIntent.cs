using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusEffectIntent(string BoxId, string RecipientPlayerId,
    PvpBonusEffectKind Kind);
