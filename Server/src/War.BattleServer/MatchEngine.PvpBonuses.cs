using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private PvpBonusSpawnPlanner? pvpBonusPlanner;
    private readonly HashSet<string> appliedPvpBonusBoxes = new(StringComparer.Ordinal);

    internal PvpBonusSpawnPlanner BonusPlanner => pvpBonusPlanner ??
        throw new InvalidOperationException("PvP bonus authority is not configured.");

    internal void ConfigurePvpBonuses(BattleCombatContent content)
    {
        if (phase != BattlePhase.Waiting || players.Any(player => player.Admitted) ||
            pvpBonusPlanner != null)
            throw new InvalidOperationException("PvP bonus authority must be bound once before admission.");
        pvpBonusPlanner = new PvpBonusSpawnPlanner(content, manifest,
            manifest.SceneMasterPlayerId ?? throw new InvalidDataException("Missing scene master."));
    }

    /// <summary>
    /// Applies only source effects whose player-state mutation is currently
    /// verified. Other collected crates remain closed to prevent a false grant.
    /// The box identity and recipient come from this match's host registry.
    /// </summary>
    internal string ApplyCollectedPvpBonus(string boxId)
    {
        if (phase != BattlePhase.Running || pvpBonusPlanner == null)
            return "bonus-unavailable";
        PvpBonusEffectIntent intent;
        try { intent = pvpBonusPlanner.EffectIntent(boxId); }
        catch (InvalidDataException) { return "bonus-unavailable"; }
        catch (InvalidOperationException) { return "bonus-unavailable"; }
        if (appliedPvpBonusBoxes.Contains(boxId)) return "bonus-applied";
        var recipient = Find(intent.RecipientPlayerId);
        if (recipient?.Admitted != true || recipient.Dead ||
            recipient.Definition.Combat == null || stateRevision == ulong.MaxValue)
            return "bonus-unavailable";

        if (intent.Kind == PvpBonusEffectKind.Health)
        {
            if (recipient.DamageRevision == ulong.MaxValue) return "bonus-unavailable";
            float healing = recipient.MaximumHealth * 0.1f;
            if (!float.IsFinite(healing) || healing <= 0)
                return "bonus-unavailable";
            PlayerDamageResult result;
            try
            {
                // KillStreakBonusAddHealth calls Heal, which sends negative
                // Basic damage through PlayerController.OnDamage. The normal
                // resolver preserves its dodge, immortality and tutorial gates.
                result = PlayerDamage.Resolve(CombatFor(recipient), recipient.Health,
                    new ResolvedPlayerDamage(-healing, CombatDamageType.Basic,
                        HasWeapon: false), sameFraction: false, self: false,
                    randomRoll: combatRandom());
            }
            catch (InvalidDataException) { return "bonus-unavailable"; }
            if (!result.Applied) return "bonus-unavailable";
            recipient.Health = result.Health;
            recipient.DamageRevision++;
        }
        else if (intent.Kind == PvpBonusEffectKind.Kevlar)
        {
            float maximum;
            try { maximum = PlayerKevlar.BonusCrateMaximum(recipient.MaximumHealth); }
            catch (InvalidDataException) { return "bonus-unavailable"; }
            if (recipient.DamageRevision == ulong.MaxValue) return "bonus-unavailable";
            recipient.KevlarMaximum = maximum;
            recipient.KevlarHealth = maximum;
            recipient.DamageRevision++;
        }
        else if (intent.Kind == PvpBonusEffectKind.Ammo)
        {
            var refills = new List<(WeaponRuntime Weapon, int Reserve)>();
            foreach (var weapon in recipient.Weapons.OrderBy(slot => slot.Key).Select(slot => slot.Value))
            {
                int reserve;
                try { reserve = PvpBonusAmmoPolicy.RefilledReserve(
                    weapon.Reserve, weapon.Definition.Weapon.ClipSize); }
                catch (InvalidDataException) { return "bonus-unavailable"; }
                refills.Add((weapon, reserve));
            }
            if (refills.Count == 0) return "bonus-unavailable";
            foreach (var refill in refills) refill.Weapon.Reserve = refill.Reserve;
        }
        else return "bonus-effect-pending";

        appliedPvpBonusBoxes.Add(boxId);
        stateRevision++;
        return "bonus-applied";
    }
}
