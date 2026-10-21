using System.Numerics;
using System.Security.Cryptography;

namespace War.BattleServer;

public sealed record PvpBonusCurrencyRewardQuote(string MatchId, string BoxId,
    string RecipientPlayerId, PvpBonusEffectKind Kind, int BaseDraw, int Amount);
