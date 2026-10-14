using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private PvpBonusSpawnPlanner? pvpBonusPlanner;
    private PvpBonusProgressCoordinator? pvpBonusProgress;
    private PvpBonusBoobyTrapPolicy? pvpBoobyTrap;
    private readonly HashSet<string> appliedPvpBonusBoxes = new(StringComparer.Ordinal);

    internal PvpBonusSpawnPlanner BonusPlanner => pvpBonusPlanner ??
        throw new InvalidOperationException("PvP bonus authority is not configured.");
    internal PvpBonusProgressCoordinator BonusProgress => pvpBonusProgress ??
        throw new InvalidOperationException("PvP bonus progress is not configured.");

    private string PvpHitReceiptId(string source, ulong projectileKey, string victimId)
    {
        string identity = "pvp-" + source + "-hit/v1\n" + manifest.MatchId + "\n" +
            projectileKey.ToString(CultureInfo.InvariantCulture) + "\n" + victimId;
        byte[] digest = SHA256.HashData(Encoding.UTF8.GetBytes(identity));
        return Convert.ToHexStringLower(digest)[..32];
    }

    internal void ConfigurePvpBonuses(BattleCombatContent content)
    {
        if (phase != BattlePhase.Waiting || players.Any(player => player.Admitted) ||
            pvpBonusPlanner != null)
            throw new InvalidOperationException("PvP bonus authority must be bound once before admission.");
        var planner = new PvpBonusSpawnPlanner(content, manifest,
            manifest.SceneMasterPlayerId ?? throw new InvalidDataException("Missing scene master."));
        var progress = PvpBonusProgressCoordinator.CreateForOnlineManifest(content,
            manifest, manifest.SceneMasterPlayerId);
        pvpBoobyTrap = content.PvpBoobyTrap;
        pvpBonusPlanner = planner;
        pvpBonusProgress = progress;
    }

    /// <summary>
    /// Applies only source effects whose player-state mutation is currently
    /// verified. Other collected crates remain closed to prevent a false grant.
    /// The box identity and recipient come from this match's host registry.
    /// </summary>
    internal string ApplyCollectedPvpBonus(string boxId)
    {
        if (pvpBonusPlanner == null)
            return "bonus-unavailable";
        if (appliedPvpBonusBoxes.Contains(boxId)) return "bonus-applied";
        if (phase != BattlePhase.Running)
            return "bonus-unavailable";
        PvpBonusEffectIntent intent;
        try { intent = pvpBonusPlanner.EffectIntent(boxId); }
        catch (InvalidDataException) { return "bonus-unavailable"; }
        catch (InvalidOperationException) { return "bonus-unavailable"; }
        var recipient = Find(intent.RecipientPlayerId);
        if (recipient?.Admitted != true || recipient.Dead ||
            recipient.Definition.Combat == null || stateRevision == ulong.MaxValue)
            return "bonus-unavailable";

        if (intent.Kind == PvpBonusEffectKind.BoobyTrap)
        {
            if (pvpBoobyTrap == null || recipient.DamageRevision == ulong.MaxValue ||
                stateRevision > ulong.MaxValue - 3 || events.Count > MaximumRetainedEvents - 2)
                return "bonus-unavailable";
            var box = pvpBonusPlanner.BoxSnapshot(boxId);
            float damage;
            try { damage = pvpBoobyTrap.Damage(recipient.MaximumHealth); }
            catch (InvalidDataException) { return "bonus-unavailable"; }
            // KillStreakBonusBoobyTrap sets the earning player's enemy as
            // damage owner, so the stolen recipient is damaged by that owner.
            var hit = new ResolvedPlayerDamage(damage, CombatDamageType.Explosion,
                HasWeapon: false);
            var result = ApplyResolvedPlayerDamage(box.Plan.Request.OwnerPlayerId,
                recipient.Definition.PlayerId, hit, combatRandom());
            if (result?.Applied != true) return "bonus-unavailable";
            appliedPvpBonusBoxes.Add(boxId);
            return "bonus-applied";
        }
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
