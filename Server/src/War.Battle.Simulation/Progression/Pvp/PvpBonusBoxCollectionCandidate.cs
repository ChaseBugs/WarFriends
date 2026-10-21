using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusBoxCollectionCandidate(string BoxId, string OwnerPlayerId,
    string RecipientPlayerId, int PrefabIndex, bool Stolen, bool BoobyTrapped,
    Vector3? CollectionPosition);
