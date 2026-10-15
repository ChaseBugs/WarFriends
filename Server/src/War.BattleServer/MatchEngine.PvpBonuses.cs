using System.Globalization;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private PvpBonusSpawnPlanner? pvpBonusPlanner;
    private PvpBonusProgressCoordinator? pvpBonusProgress;
    private WeaponBindingGraphCatalog? pvpBonusWeapons;
    private float pvpBonusLowAmmoThreshold;
    private int pvpGoldBonusesCollected;
    private ulong pvpBonusFrameId;
    private sealed record MaturedBonus(PvpBonusProgressFrame Frame, int Index)
    {
        internal PvpBonusDelayedRequest Request => Frame.MaturedRequests[Index];
    }
    private readonly List<MaturedBonus> maturedPvpBonuses = new();
    private PvpBonusBoobyTrapPolicy? pvpBoobyTrap;
    private PvpBonusGrenadeBurstPolicy? pvpGrenadeBurstPolicy;
    private PvpBonusGrenadeBurstClock? pvpGrenadeClock;
    private CardGrenadesBurstPolicy? cardGrenadesBurstPolicy;
    private CardGrenadeOriginCatalog? cardGrenadeOrigins;
    private readonly Dictionary<string, (string OwnerId, string Result)> cardGrenadeReceipts = new(StringComparer.Ordinal);
    private PvpBonusCatalog? pvpGrenadeCatalog;
    private IReadOnlyList<PvpBonusGrenadeDueShot> readyPvpGrenadeShots =
        Array.Empty<PvpBonusGrenadeDueShot>();
    private readonly Dictionary<string, PvpBonusGrenadeBurstPlan> pvpGrenadeBurstPlans =
        new(StringComparer.Ordinal);
    private readonly Dictionary<ulong, GrenadeFlight> pvpGrenadeFlights = new();
    private readonly List<GrenadeFlightImpact> pvpGrenadePendingExplosions = new();
    private IReadOnlyList<GrenadeFlightImpact> pvpGrenadeImpacts =
        Array.Empty<GrenadeFlightImpact>();
    private IReadOnlyList<PvpBonusGrenadeExplosionQuote> pvpGrenadeExplosions =
        Array.Empty<PvpBonusGrenadeExplosionQuote>();
    private readonly HashSet<string> appliedPvpBonusBoxes = new(StringComparer.Ordinal);

    internal PvpBonusSpawnPlanner BonusPlanner => pvpBonusPlanner ??
        throw new InvalidOperationException("PvP bonus authority is not configured.");
    internal PvpBonusProgressCoordinator BonusProgress => pvpBonusProgress ??
        throw new InvalidOperationException("PvP bonus progress is not configured.");
    internal IReadOnlyList<PvpBonusCurrencyRewardQuote> CurrencyBonusQuotes =>
        pvpBonusPlanner?.CurrencyQuotes ?? Array.Empty<PvpBonusCurrencyRewardQuote>();
    internal IReadOnlyList<PvpBonusDelayedRequest> MaturedBonusRequests =>
        new ReadOnlyCollection<PvpBonusDelayedRequest>(
            maturedPvpBonuses.Select(bonus => bonus.Request).ToArray());
    internal IReadOnlyList<PvpBonusGrenadeDueShot> ReadyPvpGrenadeShots =>
        readyPvpGrenadeShots;
    internal IReadOnlyList<GrenadeFlightImpact> PvpGrenadeImpacts => pvpGrenadeImpacts;
    internal IReadOnlyList<PvpBonusGrenadeExplosionQuote> PvpGrenadeExplosions =>
        pvpGrenadeExplosions;
    internal int PendingPvpGrenadeFlights =>
        pvpGrenadeFlights.Count + pvpGrenadePendingExplosions.Count;

    private void AdvancePvpGrenadeFlights()
    {
        if (readyPvpGrenadeShots.Count == 0 && PendingPvpGrenadeFlights == 0)
        {
            pvpGrenadeImpacts = Array.Empty<GrenadeFlightImpact>();
            pvpGrenadeExplosions = Array.Empty<PvpBonusGrenadeExplosionQuote>();
            return;
        }

        var impacts = new List<GrenadeFlightImpact>();
        var explosions = new List<PvpBonusGrenadeExplosionQuote>();
        pvpGrenadeImpacts = Array.Empty<GrenadeFlightImpact>();
        // GrenadeAmmoBase.OnCollisionEnter arms a zero-second fuse. Its Update
        // reads the shared setup later, after this frame's burst mutations.
        foreach (var pending in pvpGrenadePendingExplosions)
            explosions.Add(PvpBonusGrenadeExplosionPolicy.AfterCollision(pending,
                pvpGrenadeClock?.CurrentSharedDamage ??
                    throw new InvalidDataException("Shared grenade setup is missing."),
                pvpGrenadeCatalog ??
                    throw new InvalidDataException("Bonus grenade catalog is missing."), tick));
        pvpGrenadePendingExplosions.Clear();
        pvpGrenadeExplosions = new ReadOnlyCollection<PvpBonusGrenadeExplosionQuote>(explosions);
        foreach (var explosion in explosions)
        {
            ApplyPvpBonusGrenadeExplosion(explosion);
            if (Terminal) return;
        }
        foreach (var flight in pvpGrenadeFlights.Values.ToArray())
        {
            var impact = flight.Advance(tick);
            if (impact == null) continue;
            pvpGrenadeFlights.Remove(flight.Id);
            impacts.Add(impact);
            pvpGrenadePendingExplosions.Add(impact);
            Emit(MatchEventKind.Impact, impact.OwnerId,
                impact.Collision.PlayerId ?? "", impact.ProjectileId,
                impact.Position, 0, "pvp-bonus-grenade");
        }

        foreach (var shot in readyPvpGrenadeShots)
        {
            if (PendingProjectileCount >= MaximumProjectiles ||
                projectileId == ulong.MaxValue)
                throw new InvalidOperationException("PvP grenade projectile capacity exhausted.");
            var owner = Find(shot.RecipientPlayerId);
            if (owner?.Admitted != true)
                throw new InvalidDataException("PvP grenade owner is no longer admitted.");
            var origin = shot.CardFireOrigin ??
                pvpBonusPlanner?.BoxSnapshot(shot.BoxId).Collection?.CollectionPosition ??
                throw new InvalidDataException("Grenade fire origin is missing.");

            // MainScene KillStreak Manager GrenadeAmmoSetup 41786 supplies
            // this flight; its spawnPoint is the box, not a weapon muzzle.
            var catalog = pvpGrenadeCatalog ??
                throw new InvalidDataException("Bonus grenade catalog is missing.");
            Func<Vector3, Vector3, float, ShotCollision?> trace =
                (from, direction, distance) => TracePvpGrenade(
                    owner.Definition.PlayerId, from, direction, distance);
            var flight = new GrenadeFlight(++projectileId, owner.Definition.PlayerId,
                catalog.GrenadeThrowAngle, catalog.GrenadeThrowDistance, origin,
                shot.Launch.Position, tick, trace, allowStationary: true);
            pvpGrenadeFlights.Add(flight.Id, flight);
            Emit(MatchEventKind.Shot, owner.Definition.PlayerId, "",
                flight.Id, origin, 0, "pvp-bonus-grenade");
        }
        pvpGrenadeImpacts = new ReadOnlyCollection<GrenadeFlightImpact>(impacts);
    }

    private void ApplyPvpBonusGrenadeExplosion(
        PvpBonusGrenadeExplosionQuote explosion)
    {
        if (phase != BattlePhase.Running || tick != explosion.ExplosionTick ||
            rifleCombat == null || damageRoll == null ||
            Find(explosion.OwnerId)?.Admitted != true)
            throw new InvalidDataException("Bonus grenade player damage lacks host authority.");

        var owner = Find(explosion.OwnerId)!;
        bool friendKill = pvpGrenadeCatalog?.GrenadeFriendKill ??
            throw new InvalidDataException("Bonus grenade weapon setup is missing.");
        var stage = explosion.ToExplosionStage();
        bool shieldNearPlayer = ApplyPvpBonusGrenadeMapExplosion(explosion,
            stage, owner);
        if (Terminal) return;
        ApplyPvpBonusGrenadeInfantry(explosion, stage, owner);
        if (Terminal) return;
        ApplyPvpBonusGrenadeDecoys(explosion, stage, owner);
        ApplyPvpBonusGrenadeHeavyTurrets(explosion, stage, owner);
        ApplyPvpBonusGrenadeRepairDrones(explosion, stage, owner);
        ApplyPvpBonusGrenadePassengers(explosion, stage, owner);
        ApplyPvpBonusGrenadeGroundVehicles(explosion, stage, owner);
        if (Terminal) return;
        ApplyPvpBonusGrenadeAssaultGlass(explosion, stage, owner);
        ApplyPvpBonusGrenadeAirBodies(explosion, stage, owner);
        if (Terminal) return;
        foreach (var victim in players.Where(player => !player.Dead).ToArray())
        {
            float roll = damageRoll();
            var pose = rifleCombat.Pose(victim.Definition.PlayerId).Collision;
            var effect = GrenadeExplosion.ResolvePlayer(explosion.Position,
                pose, victim.Position, CombatFor(victim), victim.Health,
                stage, shieldNearPlayer, overtime,
                owner.Definition.Fraction == victim.Definition.Fraction,
                owner == victim, roll, friendKill);
            if (effect?.Result.Applied != true) continue;

            var damage = new ResolvedPlayerDamage(effect.RawDamage, effect.Kind,
                HasWeapon: true, FriendKill: friendKill,
                PlayerCoefficient: stage.PlayerDamageRatio,
                PlayerOvertimeCoefficient: stage.OvertimePlayerDamageRatio,
                Overtime: overtime);
            // PlayerOnDamage, not GrenadeAmmoBase.ReportShotHit(null),
            // grants the source EnemyPlayerHit skillshot after actual damage.
            string receiptId = PvpHitReceiptId("bonus-grenade",
                explosion.ProjectileId, victim.Definition.PlayerId);
            ApplyResolvedPlayerDamage(explosion.OwnerId,
                victim.Definition.PlayerId, damage, roll,
                confirmedProjectileImpact: true,
                pvpPlayerDamageReceiptId: receiptId);
            if (Terminal) return;
        }
        ApplyHelicopterGunnerExplosion(explosion.OwnerId, explosion.Position,
            stage.DeadRadius, stage.HurtRadius, stage.MinimumDamage,
            stage.ExplosionDamage, halfDamage: false, friendKill: false);
    }

    private void ApplyPvpBonusGrenadeInfantry(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        var groups = GroundVehicleShotTargets(explosion.OwnerId, true)
            .Where(target => target.ArmyInfantry)
            .GroupBy(target => target.EntityId)
            .OrderBy(group => group.Key);
        foreach (var group in groups)
        {
            if (!activeArmyEntities.TryGetValue(group.Key, out var army) ||
                !infantryAnimations.ContainsKey(group.Key))
                throw new InvalidDataException("Bonus grenade infantry target disappeared.");
            if (army.OwnerFraction == owner.Definition.Fraction) continue;
            var position = new Vector3(army.X, army.Y, army.Z);
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                position, group.Select(target => target.Hitbox).ToArray(), stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f)
                throw new InvalidDataException("Bonus grenade infantry damage is invalid.");
            ApplyArmyHostDamage(group.Key, effect.RawDamage);
            if (Terminal) return;
            if (activeArmyEntities.ContainsKey(group.Key)) continue;
            if (directArmyKills.Count >= 256)
            {
                End("source-kill-backpressure", "", false);
                return;
            }
            directArmyKills.Add((group.Key, army.UnitId, army.OwnerPlayerId,
                explosion.OwnerId, "player-grenade", tick));
        }
    }

    private void ApplyPvpBonusGrenadeGroundVehicles(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (vehicles == null) return;
        if (groundVehicleWeapons == null)
            throw new InvalidDataException("Bonus grenade vehicle source is missing.");
        foreach (var vehicle in vehicles.Snapshot().OrderBy(item => item.EntityId))
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId, out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !groundVehicleFacing.TryGetValue(vehicle.EntityId, out var facing))
                throw new InvalidDataException("Bonus grenade vehicle lost host authority.");
            var vehicleOwner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException("Bonus grenade vehicle owner disappeared.");
            if (vehicleOwner.Definition.Fraction == owner.Definition.Fraction) continue;
            var bodies = groundVehicleWeapons.PlaceBody(vehicle.UnitId,
                vehicle.EntityId, vehicle.Position, facing,
                vehicleOwner.Definition.Fraction);
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                vehicle.Position, bodies.Select(part => part.Hitbox).ToArray(), stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f)
                throw new InvalidDataException("Bonus grenade vehicle damage is invalid.");
            float before = ArmyHealth(vehicle.EntityId) ??
                throw new InvalidDataException("Bonus grenade vehicle has no shared health.");
            ApplyArmyHostDamage(vehicle.EntityId, effect.RawDamage);
            if (Terminal) return;
            if (!activeArmyEntities.ContainsKey(vehicle.EntityId))
            {
                if (directArmyKills.Count >= 256)
                {
                    End("source-kill-backpressure", "", false);
                    return;
                }
                directArmyKills.Add((vehicle.EntityId, vehicle.UnitId,
                    vehicle.OwnerPlayerId, explosion.OwnerId, "player-grenade", tick));
                continue;
            }
            float after = ArmyHealth(vehicle.EntityId) ??
                throw new InvalidDataException("Bonus grenade vehicle health disappeared.");
            float applied = before - after;
            if (applied > 0f &&
                (!vehicles.TryDamage(vehicle.EntityId, applied,
                    out float registryApplied, out bool destroyed) || destroyed ||
                 Math.Abs(applied - registryApplied) > 0.001f))
                throw new InvalidDataException("Bonus grenade vehicle health diverged.");
        }
    }

    private void ApplyPvpBonusGrenadeDecoys(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (decoySource == null) return;
        // DestroyableObject.DoDamage rejects same-fraction weapon damage when
        // the Manager Grenade's recovered friendKill field is zero.
        foreach (var collider in DecoyShotTargets(owner))
        {
            var decoy = decoys.Snapshot().SingleOrDefault(item =>
                item.EntityId == collider.EntityId) ??
                throw new InvalidDataException("Bonus grenade Decoy target disappeared.");
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                decoy.Position, [collider.Hitbox], stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f ||
                !decoys.TryDamage(decoy.EntityId, effect.RawDamage,
                    out var changed, out bool destroyed) || changed == null)
                throw new InvalidDataException("Bonus grenade Decoy damage is invalid.");
            stateRevision++;
            if (!destroyed) continue;
            droneTargets.Disable(DroneDecoyId(decoy.EntityId));
            Emit(MatchEventKind.DecoyDestroyed, explosion.OwnerId,
                changed.OwnerPlayerId, decoy.EntityId, changed.Position, 0,
                "pvp-bonus-grenade");
        }
    }

    private void ApplyPvpBonusGrenadeHeavyTurrets(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (heavyTurretSource == null) return;
        var colliders = HeavyTurretShotTargets(owner);
        foreach (var group in colliders.GroupBy(collider => collider.EntityId)
                     .OrderBy(group => group.Key))
        {
            var turret = heavyTurrets.Snapshot().SingleOrDefault(item =>
                item.EntityId == group.Key) ??
                throw new InvalidDataException("Bonus grenade Heavy Turret target disappeared.");
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                turret.Position, group.Select(collider => collider.Hitbox).ToArray(), stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f ||
                !heavyTurrets.TryDamage(group.Key, effect.RawDamage,
                    out var changed, out bool destroyed) || changed == null)
                throw new InvalidDataException("Bonus grenade Heavy Turret damage is invalid.");
            stateRevision++;
            Emit(destroyed ? MatchEventKind.HeavyTurretDestroyed :
                MatchEventKind.HeavyTurretDamaged, explosion.OwnerId,
                changed.OwnerPlayerId, group.Key, changed.Position,
                changed.Health, "pvp-bonus-grenade");
        }
    }

    private ShotCollision? TracePvpGrenade(string ownerId,
        Vector3 from, Vector3 direction, float distance)
    {
        if (rifleCombat != null)
        {
            var hit = rifleCombat.TraceForBazooka(ownerId, from, direction,
                distance, PvpBonusGrenadeCollision.ExplosiveContactMask);
            return PvpBonusGrenadeCollision.ExplosiveContact(hit);
        }
        if (grenadeCombat == null)
            throw new InvalidDataException("PvP grenade collision world is missing.");
        var grenadeHit = grenadeCombat.Trace(ownerId, from, direction,
            distance, PvpBonusGrenadeCollision.ExplosiveContactMask);
        return PvpBonusGrenadeCollision.ExplosiveContact(grenadeHit);
    }

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
                slot.Weapon.ReserveAmmo, weapon.Reserve, weapon.Clip,
                pvpBonusLowAmmoThreshold))
                return true;
        }
        return false;
    }

    // A host allocation must supply the source game mode and live analytics.
    // Only the oldest matured callback may select and register a box.
    internal PvpBonusSpawnPlan? IssueNextMaturedBonus()
    {
        if (phase != BattlePhase.Running || pvpBonusPlanner == null ||
            maturedPvpBonuses.Count == 0)
            return null;
        if (manifest.PvpBonusMode == null)
            throw new InvalidOperationException("Match lacks a trusted PvP bonus mode.");

        var ownerId = maturedPvpBonuses[0].Request.OwnerPlayerId;
        var context = new PvpBonusSpawnContext(
            manifest.PvpBonusMode == MatchManifest.WarArenaPvpBonusMode,
            manifest.PvpBonusMode == MatchManifest.FriendlyDeathMatchPvpBonusMode,
            pvpGoldBonusesCollected, FirstTwoUsedWeaponsHaveLowAmmo(ownerId));
        float weightedValue = 0f;
        if (!pvpBonusPlanner.HasQueuedBonus(ownerId))
        {
            float total = pvpBonusPlanner.WeightTotal(ownerId, context);
            weightedValue = NextBonusUnitDraw() * total;
        }
        var draw = new PvpBonusSpawnDraw(
            weightedValue,
            Random.Shared.Next(pvpBonusPlanner.SpawnAreaCount),
            new Vector3(NextBonusUnitDraw(), NextBonusUnitDraw(),
                NextBonusUnitDraw()));
        return IssueNextMaturedBonus(context, draw);
    }

    private float NextBonusUnitDraw()
    {
        float value = combatRandom();
        if (!float.IsFinite(value) || value < 0f || value > 1f)
            throw new InvalidDataException("Invalid host bonus random draw.");
        return value;
    }

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
        if (context.GoldBonusesCollected != pvpGoldBonusesCollected)
            throw new InvalidDataException("Gold-bonus count differs from signed player analytics.");
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
        var dueGrenades = (pvpGrenadeClock ??
            throw new InvalidOperationException("PvP grenade clock is missing."))
            .AdvanceFrame(nextFrame, delta);
        if (maturedPvpBonuses.Count > 256 - frame.MaturedRequests.Count)
            throw new InvalidOperationException("Unissued PvP bonus capacity exhausted.");
        pvpBonusPlanner?.AdvanceFalling(delta);
        for (int index = 0; index < frame.MaturedRequests.Count; index++)
            maturedPvpBonuses.Add(new MaturedBonus(frame, index));
        pvpBonusProgress = prepared;
        readyPvpGrenadeShots = dueGrenades;
        pvpBonusFrameId = nextFrame;
        if (manifest.PvpBonusMode != null)
        {
            // InvokeAfter may finish multiple waits in one frame. Publish each
            // accepted box in the same FIFO order as the source callbacks.
            while (maturedPvpBonuses.Count > 0)
                IssueNextMaturedBonus();
        }
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
        pvpGrenadeBurstPolicy = new PvpBonusGrenadeBurstPolicy(content.PvpBonuses);
        cardGrenadesBurstPolicy = new CardGrenadesBurstPolicy(content.PvpBonuses);
        cardGrenadeOrigins = content.CardGrenadeOrigins;
        pvpGrenadeClock = new PvpBonusGrenadeBurstClock(content.PvpBonuses);
        pvpGrenadeCatalog = content.PvpBonuses;
        pvpBonusWeapons = content.AllWeaponBindings;
        pvpBonusLowAmmoThreshold = content.PvpBonuses.LowAmmoThreshold;
        pvpGoldBonusesCollected = manifest.PvpGoldBonusesAtAdmission ?? 0;
        pvpBonusPlanner = planner;
        pvpBonusProgress = progress;
    }

    /// <summary>
    /// Plans a collected grenade crate using the host's current shootable
    /// registries. No Client-declared target or random offset enters this path.
    /// The match tick later launches projectiles and resolves player blasts.
    /// </summary>
    internal PvpBonusGrenadeBurstPlan PlanCollectedPvpGrenades(string boxId)
    {
        if (pvpGrenadeBurstPlans.TryGetValue(boxId, out var previous))
            return previous;
        if (phase != BattlePhase.Running || pvpBonusPlanner == null ||
            pvpGrenadeBurstPolicy == null || pvpGrenadeClock == null ||
            pvpBonusFrameId == 0)
            throw new InvalidOperationException("PvP grenade crate is unavailable.");
        if (pvpGrenadeClock.PendingCount >= 256)
            throw new InvalidOperationException("Too many pending grenade-box bursts.");

        var intent = pvpBonusPlanner.EffectIntent(boxId);
        if (intent.Kind != PvpBonusEffectKind.Grenades)
            throw new InvalidDataException("Collected crate is not a grenade bonus.");
        var recipient = Find(intent.RecipientPlayerId);
        if (recipient?.Admitted != true || recipient.Dead ||
            recipient.Definition.PlayerLevel is not int recipientLevel)
            throw new InvalidOperationException("Grenade recipient lacks live host authority.");
        string sceneMasterId = manifest.SceneMasterPlayerId ??
            throw new InvalidDataException("Grenade source view is missing.");
        var sourceView = Find(sceneMasterId);
        if (sourceView == null)
            throw new InvalidDataException("Grenade source view is outside the match.");
        var collection = pvpBonusPlanner.BoxSnapshot(boxId).Collection;
        var boxPosition = collection?.CollectionPosition ??
            throw new InvalidOperationException(
                "Grenade box lacks a host-confirmed collection position.");
        var launches = pvpGrenadeBurstPolicy.Plan(sourceView.Definition.Fraction,
            recipientLevel, boxPosition, PvpGrenadeShootables(), NextGrenadeFallbackOffset);
        var plan = new PvpBonusGrenadeBurstPlan(boxId, intent.RecipientPlayerId, launches);
        pvpGrenadeClock.Schedule(plan, pvpBonusFrameId);
        pvpGrenadeBurstPlans.Add(boxId, plan);
        return plan;
    }

    internal IReadOnlyList<PvpBonusGrenadeTarget> PvpGrenadeShootables()
    {
        // The Drone target registry already preserves the source's owner-type
        // buckets for players, deployed army roots, and Decoys. Heavy Turret
        // has the same main shootable component but a separate host registry.
        var targets = DroneTargetSnapshot().Select(target =>
            new PvpBonusGrenadeTarget(target.Id, target.Fraction, true,
                target.Alive, target.Visible, target.Position)).ToList();
        foreach (var turret in heavyTurrets.Snapshot())
        {
            targets.Add(new PvpBonusGrenadeTarget(
                "heavy-turret:" + turret.EntityId, turret.OwnerFraction, true,
                turret.Health > 0f, true, turret.Position));
        }
        return targets.AsReadOnly();
    }

    private string UseGrenadesBurst(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardGrenadesBurst"))
            return "grenades-burst-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-grenades-burst-request";
        if (cardGrenadeReceipts.TryGetValue(requestId, out var replay))
            return replay.OwnerId == owner.Definition.PlayerId
                ? replay.Result : "grenades-burst-request-conflict";
        if (cardReservations == null || cardGrenadesBurstPolicy == null ||
            cardGrenadeOrigins == null ||
            pvpGrenadeClock == null || map == null || pvpBonusFrameId == 0 ||
            owner.Definition.PlayerLevel is not int level)
            return "grenades-burst-authority-unavailable";
        string inventoryId = CardInventoryId(owner.Definition.PlayerId,
            "CardGrenadesBurst", "CLUSTERGRENADE");
        if (cardReservations.Remaining(owner.Definition.PlayerId, inventoryId) < 1)
            return "grenades-burst-unavailable";
        if (cardGrenadeReceipts.Count >= 256 ||
            pvpGrenadeClock.PendingCount >= 256 ||
            events.Count > MaximumRetainedEvents - 4 ||
            stateRevision > ulong.MaxValue - 4)
            return "event-backpressure";

        // CardGrenadesBurst starts at the owner's shield HUD snap transform.
        // The recovered scene binds that position separately from shotPosition;
        // no packet position or opponent identity is trusted for this card.
        if (owner.Cover < 0 || owner.Cover >= map.Covers.Count ||
            map.Covers[owner.Cover].Fraction != owner.Definition.Fraction)
            return "grenades-burst-owner-unavailable";
        var occupied = players.Where(player => !player.Dead)
            .Select(player => player.Route == null ? player.Cover : player.Destination)
            .ToHashSet();
        var emptyEnemyShields = map.Covers
            .Where((cover, index) => cover.Fraction != owner.Definition.Fraction &&
                !occupied.Contains(index))
            .Select(cover => cover.Position).ToArray();

        CardGrenadesBurstPlan plan;
        try
        {
            plan = cardGrenadesBurstPolicy.Plan(requestId,
                owner.Definition.PlayerId, owner.Definition.Fraction, level,
                cardGrenadeOrigins.ForCover(map, owner.Cover), PvpGrenadeShootables(),
                emptyEnemyShields, armyChoice);
        }
        catch (InvalidDataException)
        {
            return "grenades-burst-authority-unavailable";
        }

        var effect = new WarCardEffectRequest("CardGrenadesBurst",
            plan.FireOrigin, 0, 1, "CLUSTERGRENADE");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "grenades-burst-unavailable";
        pvpGrenadeClock.ScheduleCard(plan, pvpBonusFrameId);
        const string result = "grenades-burst-active";
        cardGrenadeReceipts.Add(requestId, (owner.Definition.PlayerId, result));
        return result;
    }

    private float NextGrenadeFallbackOffset()
    {
        float unitDraw = combatRandom();
        return PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(unitDraw);
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

        if (intent.Kind is PvpBonusEffectKind.Gold or PvpBonusEffectKind.Warbucks)
        {
            // The original local recipient receives a random currency amount.
            // Keep the host-owned quote for later durable settlement. No
            // wallet balance, Gold analytics, or visible effect changes here.
            try { _ = pvpBonusPlanner.QuoteCurrencyReward(boxId); }
            catch (InvalidOperationException) { return "bonus-unavailable"; }
            return "bonus-quoted";
        }

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
