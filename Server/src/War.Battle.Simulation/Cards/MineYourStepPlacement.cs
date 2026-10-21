using System.Numerics;

namespace War.BattleServer;

public sealed record MineYourStepPlacement(
    Vector3 Position, int FirstEnemyCover, int SecondEnemyCover,
    float OuterDamage, float ExplosionDamage);
