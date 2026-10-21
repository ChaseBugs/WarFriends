using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

/// <summary>Freezes SoldierBehaviourMortar's shield position at preparation, before its delayed callback.</summary>
internal sealed record MortarShotTarget(string PlayerId, int CoverIndex, Vector3 Position);

public sealed partial class MatchEngine
{
    /// <summary>Selects the recovered shield target without a probability roll or live-position binding.</summary>
    internal MortarShotTarget? SelectMortarShotTarget(ulong entityKey)
    {
        const float TargetHeightOffset = 0.4f;
        if (phase != BattlePhase.Running || map == null || armyCatalog == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-MORTAR" || entity.SourceCardId.Length != 0 ||
            !_ordinaryMortarWeapons.ContainsKey(entityKey))
        {
            return null;
        }

        float shieldProbability = armyCatalog.ShieldHitProbability(entity.UnitId);
        if (!float.IsFinite(shieldProbability))
        {
            throw new InvalidDataException("Mortar target selection lost its source shield probability.");
        }
        if (shieldProbability < 0f)
        {
            return null;
        }

        // GetRandomEnemy filters active opponents, not dead bodies. Match authority never substitutes
        // the owner's shield when no admitted opponent exists, as the original global fallback could do.
        Player[] opponents = players.Where(player => player.Admitted &&
            player.Definition.Fraction != entity.OwnerFraction).ToArray();
        if (opponents.Length == 0)
        {
            return null;
        }
        int opponentIndex = armyChoice(opponents.Length);
        if (opponentIndex < 0 || opponentIndex >= opponents.Length || armyChoice(1) != 0)
        {
            throw new InvalidDataException("Mortar opponent or Shield selection left its source range.");
        }

        Player opponent = opponents[opponentIndex];
        // GoTo changes currentPlayerPoint immediately; Cover remains the physical old point until arrival.
        int coverIndex = !opponent.IsMoving ? opponent.Cover : opponent.Destination;
        if (coverIndex < 0 || coverIndex >= map.Covers.Count ||
            map.Covers[coverIndex].Fraction != opponent.Definition.Fraction)
        {
            throw new InvalidDataException("Mortar target lost its opponent's logical cover.");
        }

        Vector3 position = map.Covers[coverIndex].ShotPosition - Vector3.UnitY * TargetHeightOffset;
        return new MortarShotTarget(opponent.Definition.PlayerId, coverIndex, position);
    }
}
