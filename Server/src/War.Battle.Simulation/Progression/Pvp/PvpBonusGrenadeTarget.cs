using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusGrenadeTarget(string Id, int Fraction,
    bool HasMainEntityOwner, bool Alive, bool Visible, Vector3 Position);
