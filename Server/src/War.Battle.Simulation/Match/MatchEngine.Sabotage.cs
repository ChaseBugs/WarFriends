using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<string, (string OwnerPlayerId, string ResultCode)>
        sabotageReceipts = new(StringComparer.Ordinal);
    private readonly Dictionary<ulong, CardUnitEntity> sabotageCardVictims = [];

    private string UseSabotage(Player owner, string requestId)
    {
        if (phase != BattlePhase.Running)
            return "sabotage-not-running";
        if (!HasSelectedCard(owner, "CardSabotage"))
            return "sabotage-not-selected";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-sabotage-request";

        if (sabotageReceipts.TryGetValue(requestId, out var replay))
            return replay.OwnerPlayerId == owner.Definition.PlayerId
                ? replay.ResultCode : "sabotage-request-conflict";
        if (cardReservations == null)
            return "sabotage-authority-unavailable";
        string inventoryId = CardInventoryId(owner.Definition.PlayerId,
            "CardSabotage", "SABOTAGE");
        if (cardReservations.Remaining(owner.Definition.PlayerId,
                inventoryId) < 1)
            return "sabotage-unavailable";
        if (sabotageReceipts.Count >= 256 ||
            events.Count > MaximumRetainedEvents - 16 ||
            stateRevision > ulong.MaxValue - 16)
            return "event-backpressure";

        SabotageTargetPolicy.Candidate? target;
        try
        {
            target = SabotageTargetPolicy.Select(
                SabotageMechanicalCandidates(), owner.Definition.Fraction,
                tick, armyChoice);
        }
        catch (InvalidDataException)
        {
            return "sabotage-authority-unavailable";
        }
        if (target != null && directArmyKills.Count >= 256)
            return "event-backpressure";

        PvpBonusProgressCoordinator? scoredKill = null;
        if (target != null && pvpBonusProgress != null)
        {
            BattleArmyEntityState victim = activeArmyEntities.GetValueOrDefault(target.EntityId) ??
                throw new InvalidDataException("Sabotage target lost its host army identity.");
            int flags = checked((int)War.Shared.SabotageKillPresentationPolicy.BaseFlags(victim.UnitId));
            // SkillShotController includes the living victim's revenge context for Sabotage too.
            flags |= ConfirmedArmyRevengeFlag(victim.EntityKey, owner.Definition.PlayerId);
            string scoreReceiptId = PvpHitReceiptId(
                "card-sabotage-army-kill", target.EntityId, requestId);
            try
            {
                scoredKill = pvpBonusProgress.PrepareConfirmedPlayerOwnedDeathCopy(
                    owner.Definition.PlayerId, scoreReceiptId, flags,
                    PlayerOwnedDeathGameTime, true, out _);
            }
            catch (InvalidOperationException)
            {
                return "event-backpressure";
            }
        }

        // The packet carries no target or damage. The recovered Client spends
        // SABOTAGE even when there is no visible opposing mechanical unit.
        var effect = new WarCardEffectRequest(
            "CardSabotage", Vector3.Zero, 0, 1, "SABOTAGE");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "sabotage-unavailable";

        string resultCode = "sabotage-no-target";
        if (target != null)
        {
            var victim = activeArmyEntities.GetValueOrDefault(target.EntityId);
            CardUnitEntity? cardVictim = null;
            if (victim != null && victim.SourceCardId.Length > 0)
            {
                cardVictim = cardUnitEntities.Find(victim.LocalEntityId);
                if (cardVictim == null || cardVictim.EntityKey != victim.EntityKey ||
                    cardVictim.OwnerPlayerId != victim.OwnerPlayerId ||
                    cardVictim.SourceCardId != "HEAVYDRONE" ||
                    cardVictim.UnitId != victim.UnitId)
                {
                    End("invalid-card-unit-authority", "", false);
                    return "match-aborted";
                }
            }
            if (!ApplySabotageHostDamage(owner.Definition.PlayerId, target))
            {
                End("invalid-card-unit-authority", "", false);
                return "match-aborted";
            }
            // Retain the source spawn proof before the death path releases it.
            if (victim != null &&
                !activeArmyEntities.ContainsKey(target.EntityId))
            {
                directArmyKills.Add((target.EntityId, victim.UnitId,
                    victim.OwnerPlayerId, owner.Definition.PlayerId,
                    "card-sabotage", tick));
                if (scoredKill != null)
                {
                    pvpBonusProgress = scoredKill;
                }
                if (cardVictim != null)
                    sabotageCardVictims.Add(target.EntityId, cardVictim);
                Emit(MatchEventKind.SabotageKillCredited, owner.Definition.PlayerId,
                    victim.OwnerPlayerId, 0, new(victim.X, victim.Y, victim.Z), 0, "sabotage");
                events[^1].SabotageKill = new SabotageKillPresentation
                {
                    VictimEntityKey = target.EntityId,
                    UnitId = victim.UnitId,
                    RequestId = requestId,
                    BaseSkillShotFlags = War.Shared.SabotageKillPresentationPolicy.BaseFlags(victim.UnitId)
                };
            }
            resultCode = "sabotage-applied";
        }
        sabotageReceipts.Add(requestId, (owner.Definition.PlayerId, resultCode));
        return resultCode;
    }

    /// <summary>
    /// Projects the mechanical army roots already owned by this match into
    /// the Client's GameShootableEntity type order. This is a read-only input
    /// for Sabotage selection; reading it does not spend a card or deal damage.
    /// </summary>
    internal IReadOnlyList<SabotageTargetPolicy.Candidate>
        SabotageMechanicalCandidates()
    {
        var registrationOrders = new Dictionary<string, int>(StringComparer.Ordinal);
        var candidates = new List<SabotageTargetPolicy.Candidate>();

        // Each of these recovered mechanical prefabs has one enabled,
        // visible main GameShootableEntity on its root. A source HeavyTurret
        // is a distinct class from Turret and must not enter this list.
        foreach (var army in activeArmyEntities.Values
            .OrderBy(entity => entity.SpawnTick)
            .ThenBy(entity => entity.EntityKey))
        {
            string? sourceType = SabotageTargetPolicy.SourceTypeForArmyUnit(
                army.UnitId);
            if (sourceType == null)
                continue;

            int registrationOrder = registrationOrders.GetValueOrDefault(sourceType);
            registrationOrders[sourceType] = checked(registrationOrder + 1);
            candidates.Add(new SabotageTargetPolicy.Candidate(
                sourceType, army.EntityKey, 0, registrationOrder,
                army.OwnerFraction, true, army.Health > 0f, true, true,
                army.SpawnTick, army.MaxHealth));
        }

        return candidates;
    }

    /// <summary>
    /// Applies a host-selected Sabotage hit to the same live root that was
    /// offered for selection. The recovered card supplies max-health Shot
    /// damage and explicitly ignores immortality; it does not accept damage
    /// or a target from a client packet.
    /// </summary>
    internal bool ApplySabotageHostDamage(string attackerPlayerId,
        SabotageTargetPolicy.Candidate selected)
    {
        var attacker = Find(attackerPlayerId);
        if (attacker?.Admitted != true || phase != BattlePhase.Running ||
            selected == null || selected.OwnerFraction == attacker.Definition.Fraction)
            return false;

        var current = SabotageMechanicalCandidates()
            .FirstOrDefault(candidate => candidate.SourceType == selected.SourceType &&
                candidate.EntityId == selected.EntityId &&
                candidate.PartId == selected.PartId);
        if (current == null || current != selected ||
            !current.Alive || !current.Visible)
            return false;

        return ApplyArmyHostDamage(current.EntityId, current.MaximumHealth,
            ignoreImmortality: true);
    }
}
