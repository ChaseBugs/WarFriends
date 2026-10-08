using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float ArmyHealthCardMultiplier = 1.2f;
    private const float ArmyHealthCardSeconds = 60f;
    private readonly Dictionary<string, HashSet<ulong>> armyHealthBuffedEntities = new(StringComparer.Ordinal);

    private string UseArmyHealthBuff(Player owner, string requestId, string cardId)
    {
        if (!owner.CardsSelected || !owner.SelectedCards.Contains(cardId, StringComparer.Ordinal))
            return "army-health-card-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) || requestId != requestId.ToLowerInvariant())
            return "invalid-army-health-card-request";
        if (cardReservations == null || armyCatalog == null)
            return "army-health-card-authority-unavailable";
        if (events.Count >= MaximumRetainedEvents || stateRevision == ulong.MaxValue ||
            armyEntityRevision == ulong.MaxValue)
            return "event-backpressure";

        // Both recovered CardConstants rows grant 20% maximum health for 60 seconds.
        // Existing units also heal by 20% of their old maximum; later spawns refill.
        var targets = activeArmyEntities.Values
            .Where(entity => entity.OwnerFraction == owner.Definition.Fraction &&
                             MatchesArmyHealthCard(cardId, entity.UnitId) &&
                             armyVitality.ContainsKey(entity.EntityKey))
            .Select(entity => entity.EntityKey).ToArray();
        if (targets.Any(key => !CanIncreaseArmyMaximum(armyVitality[key])))
            return "army-health-card-authority-unavailable";

        var request = new WarCardEffectRequest(cardId, Vector3.Zero, ArmyHealthCardSeconds, 0);
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, request))
            return "army-health-card-unavailable";

        var affected = new HashSet<ulong>();
        armyHealthBuffedEntities.Add(requestId, affected);
        foreach (ulong key in targets)
            IncreaseArmyMaximum(key, affected, refill: false);
        return "army-health-card-active";
    }

    private bool MatchesArmyHealthCard(string cardId, string unitId)
    {
        var family = armyCatalog?.Families.SingleOrDefault(item => item.UnitId == unitId);
        if (family == null) return false;
        return cardId == "CardHealthForSoldiers" ? family.IsSoldier :
            cardId == "CardHealthForMachines" && !family.IsSoldier;
    }

    private static bool CanIncreaseArmyMaximum(ArmyVitality vitality)
    {
        float increased = vitality.Maximum * ArmyHealthCardMultiplier;
        return float.IsFinite(increased) && increased > 0 && increased <= 10_000_000 &&
               float.IsFinite(vitality.Current) && vitality.Current > 0 &&
               vitality.Current <= vitality.Maximum;
    }

    private void IncreaseArmyMaximum(ulong key, HashSet<ulong> affected, bool refill)
    {
        if (!armyVitality.TryGetValue(key, out var vitality) || !affected.Add(key)) return;
        float oldMaximum = vitality.Maximum;
        vitality.Maximum *= ArmyHealthCardMultiplier;
        vitality.Current = refill ? vitality.Maximum :
            Math.Min(vitality.Maximum, vitality.Current + oldMaximum * 0.2f);
        activeArmyEntities[key].MaxHealth = vitality.Maximum;
        activeArmyEntities[key].Health = vitality.Current;
        armyEntityRevision++;
        stateRevision++;
    }

    private void ApplyActiveArmyHealthBuffs(ulong key)
    {
        var entity = activeArmyEntities[key];
        foreach (var effect in cardEffects.Snapshot())
        {
            if (!effect.Lease.ActiveAt(tick) ||
                Find(effect.OwnerPlayerId)?.Definition.Fraction != entity.OwnerFraction ||
                !MatchesArmyHealthCard(effect.Definition.CardId, entity.UnitId)) continue;
            if (!CanIncreaseArmyMaximum(armyVitality[key]))
                throw new InvalidDataException("New army health exceeds the card vitality domain.");
            IncreaseArmyMaximum(key, armyHealthBuffedEntities[effect.EffectId], refill: true);
        }
    }

    private void RemoveArmyHealthBuff(ActiveWarCardEffect effect)
    {
        if (!armyHealthBuffedEntities.Remove(effect.EffectId, out var affected)) return;
        foreach (ulong key in affected)
        {
            if (!armyVitality.TryGetValue(key, out var vitality) ||
                !activeArmyEntities.TryGetValue(key, out var entity)) continue;
            vitality.Maximum /= ArmyHealthCardMultiplier;
            vitality.Current = Math.Min(vitality.Current, vitality.Maximum);
            entity.MaxHealth = vitality.Maximum;
            entity.Health = vitality.Current;
            armyEntityRevision++;
            stateRevision++;
        }
    }
}
