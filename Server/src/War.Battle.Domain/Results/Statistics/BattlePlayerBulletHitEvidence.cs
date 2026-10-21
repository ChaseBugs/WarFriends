using War.Protocol;

namespace War.BattleServer;

/// <summary>Direct player-bullet contacts, distinct from all host enemy damage.</summary>
public sealed record BattlePlayerBulletHitEvidence(string PlayerId,int ConfirmedBulletHits);
