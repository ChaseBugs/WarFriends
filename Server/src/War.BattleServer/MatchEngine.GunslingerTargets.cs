using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Selects the source Gunslinger entity and current transform before shot preparation.</summary>
    internal AssaulterShotTarget? SelectGunslingerShotTarget(ulong entityKey)
    {
        if (phase != BattlePhase.Running || !HasArmyCombatView || playerShotTargets == null || map == null)
        {
            return null;
        }

        AssaulterOpponentSelection selected = SelectStationarySoldierOpponent(entityKey, "ID_UNIT-GUNSLINGER");
        if (selected.Kind == AssaulterOpponentKind.PlayerFallback)
        {
            // PickRandomOpponent delegates to the common player Shield/body policy.
            // ShootJustStarted later resamples the raw transform; preparation is separate.
            return SelectAssaulterPlayerTransform(activeArmyEntities[entityKey]);
        }

        if (selected.Kind == AssaulterOpponentKind.Unavailable)
        {
            return null;
        }

        DroneTargetCandidate candidate = selected.Candidate ??
            throw new InvalidDataException("Gunslinger selection lost its source opponent.");
        if (candidate.IsDecoy)
        {
            // TryPickDecoy uses All, without the normal infantry Head preference.
            return SelectAssaulterDecoyTransform(candidate);
        }

        return SelectStationaryInfantryTransform(candidate, targets =>
            GunslingerTargetPolicy.SelectShotTarget(targets, armyChoice));
    }
}
