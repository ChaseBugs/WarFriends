using System.Globalization;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private PvpBonusSpawnPlanner? pvpBonusPlanner;
    private PvpBonusProgressCoordinator? pvpBonusProgress;
    private WeaponBindingGraphCatalog? pvpBonusWeapons;
    private ulong pvpBonusFrameId;
    private sealed record MaturedBonus(PvpBonusProgressFrame Frame, int Index)
    {
        internal PvpBonusDelayedRequest Request => Frame.MaturedRequests[Index];
    }
    private readonly List<MaturedBonus> maturedPvpBonuses = new();
    private PvpBonusBoobyTrapPolicy? pvpBoobyTrap;
    private readonly HashSet<string> appliedPvpBonusBoxes = new(StringComparer.Ordinal);

    internal PvpBonusSpawnPlanner BonusPlanner => pvpBonusPlanner ??
        throw new InvalidOperationException("PvP bonus authority is not configured.");
    internal PvpBonusProgressCoordinator BonusProgress => pvpBonusProgress ??
        throw new InvalidOperationException("PvP bonus progress is not configured.");
    internal IReadOnlyList<PvpBonusDelayedRequest> MaturedBonusRequests =>
        new ReadOnlyCollection<PvpBonusDelayedRequest>(
            maturedPvpBonuses.Select(bonus => bonus.Request).ToArray());

    internal bool FirstTwoUsedWeaponsHaveLowAmmo(string ownerId)
    {
        if (pvpBonusWeapons == null)
            throw new InvalidOperationException("PvP bonus weapon bindings are unavailable.");
        var owner = Find(ownerId) ??
            throw new InvalidDataException("PvP bonus owner is outside the match.");
        var slots = owner.Definition.WeaponSlots ??
            [new WeaponSlotManifest(0, 0, owner.Definition.Weapon,
                owner.Definition.WeaponUpgrade ?? 0)];
        foreach (var slot in slots.Take(2))
        {
            var binding = pvpBonusWeapons.Get(slot.Weapon.SourceId);
            var weapon = owner.Weapons[slot.Slot];
            if (PvpBonusAmmoPolicy.HasLowAmmo(binding.ReloadableWeapon,
                slot.Weapon.ReserveAmmo, weapon.Reserve, weapon.Clip))
                return true;
        }
        return false;
    }

    // A host allocation must supply the source game mode and live analytics.
    // Only the oldest matured callback may select and register a box.
    internal PvpBonusSpawnPlan? IssueNextMaturedBonus(
        PvpBonusSpawnContext context, PvpBonusSpawnDraw draw)
    {
        if (phase != BattlePhase.Running || pvpBonusPlanner == null ||
            maturedPvpBonuses.Count == 0)
            return null;
        if (manifest.PvpBonusMode == null)
            throw new InvalidOperationException("Match lacks a trusted PvP bonus mode.");
        bool isWarArena = manifest.PvpBonusMode == MatchManifest.WarArenaPvpBonusMode;
        bool isFriendly = manifest.PvpBonusMode == MatchManifest.FriendlyDeathMatchPvpBonusMode;
        if (context.IsWarArena != isWarArena ||
            context.IsFriendlyDeathMatch != isFriendly)
            throw new InvalidDataException("Bonus selection mode differs from the signed match.");
        var matured = maturedPvpBonuses[0];
        if (context.FirstTwoWeaponsHaveLowAmmo !=
            FirstTwoUsedWeaponsHaveLowAmmo(matured.Request.OwnerPlayerId))
            throw new InvalidDataException("Bonus ammo condition differs from host weapon state.");
        var plan = pvpBonusPlanner.PlanMatured(matured.Frame, matured.Index,
            context, draw);
        maturedPvpBonuses.RemoveAt(0);
        return plan;
    }

    private void AdvancePvpBonusFrame(ulong elapsedTicks, bool justStarted)
    {
        if (pvpBonusProgress == null || elapsedTicks == 0) return;
        if (pvpBonusFrameId == ulong.MaxValue)
            throw new InvalidOperationException("PvP bonus frame identity exhausted.");

        ulong nextFrame = pvpBonusFrameId + 1;
        float delta = justStarted ? 0f :
            (float)((double)elapsedTicks / MatchManifest.TickRate);
        var prepared = pvpBonusProgress.PrepareFrameCopy(nextFrame, delta, true,
            out var frame);
        if (maturedPvpBonuses.Count > 256 - frame.MaturedRequests.Count)
            throw new InvalidOperationException("Unissued PvP bonus capacity exhausted.");
        for (int index = 0; index < frame.MaturedRequests.Count; index++)
            maturedPvpBonuses.Add(new MaturedBonus(frame, index));
        pvpBonusProgress = prepared;
        pvpBonusFrameId = nextFrame;
    }

    private string PvpHitReceiptId(string source, ulong projectileKey, string victimId)
    {
        string identity = "pvp-" + source + "-hit/v1\n" + manifest.MatchId + "\n" +
            projectileKey.ToString(CultureInfo.InvariantCulture) + "\n" + victimId;
        byte[] digest = SHA256.HashData(Encoding.UTF8.GetBytes(identity));
        return Convert.ToHexStringLower(digest)[..32];
    }

    // A real unit projectile supplies the owner, collision and unique shot ID.
    // The source PlayerOnDamage callback credits the AIObject's owning player.
    internal PlayerDamageResult? ApplyConfirmedArmyProjectilePlayerDamage(
        BulletImpact impact, ResolvedPlayerDamage damage, float randomRoll)
    {
        string victimId = impact.Hit.PlayerId ??
            throw new InvalidDataException("Army projectile has no player collision.");
        string? receiptId = pvpBonusProgress == null ? null :
            PvpHitReceiptId("army-projectile", impact.ProjectileId, victimId);
        return ApplyResolvedPlayerDamage(impact.OwnerId, victimId, damage, randomRoll,
            confirmedProjectileImpact: true, pvpPlayerDamageReceiptId: receiptId,
            pvpDamageOwner: PvpPlayerDamageOwner.Army);
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
        pvpBonusWeapons = content.AllWeaponBindings;
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
