using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class PvpBonusSpawnPlannerTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        string Id(int value) => value.ToString("x32");
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        Check(content.AllWeaponBindings.Get("Google2u.AssaultRifle_AK47").ReloadableWeapon &&
              !content.AllWeaponBindings.Get("Google2u.LMG_Minigun").ReloadableWeapon,
            "source weapon graph retains the reloadable flags used by ammo probability");
        Check(PvpBonusAmmoPolicy.HasLowAmmo(true, 100, 0, 9) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(true, 100, 0, 10) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(false, 100, 0, 0) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(true, 0, 0, 0),
            "source low-ammo threshold is strict and excludes non-reloadable weapons");
        var template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        string localId = template.Players[0].PlayerId;
        var manifest = template with {
            MatchId = Id(100), SceneMasterPlayerId = localId,
            Players = [template.Players[0] with {PlayerLevel = 8},
                template.Players[1] with {PlayerLevel = 8}]
        };
        try
        {
            MatchManifest.Validate(manifest with {PvpBonusMode = "war arena"});
            throw new Exception("Unknown bonus mode entered a signed manifest.");
        }
        catch (InvalidDataException) { checks++; }
        Check(MatchManifest.Validate(manifest with {
                  PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode
              }).PvpBonusMode == MatchManifest.OrdinaryPvpBonusMode,
            "ordinary bonus mode survives signed manifest validation");
        using var progress = PvpBonusProgressCoordinator.CreateForOnlineManifest(content, manifest, localId);
        var planner = new PvpBonusSpawnPlanner(content, manifest, localId);
        var context = new PvpBonusSpawnContext(false, false, 0, false);
        void ThreeKills(int first)
        {
            for (int index = 0; index < 3; index++)
                progress.RecordConfirmedSkillShot(localId, Id(first + index), 0x1210, 1f);
        }
        PvpBonusProgressFrame Mature(int issueFrame, int firstReceipt)
        {
            ThreeKills(firstReceipt);
            progress.AdvanceFrame((ulong)issueFrame, 0f, true);
            return progress.AdvanceFrame((ulong)(issueFrame + 1), 1.5f, false);
        }

        var first = Mature(1, 1);
        Check(first.MaturedRequests.Count == 1,
            "only a matured host delay can enter the spawn planning stage");
        var draw = new PvpBonusSpawnDraw(0f, 0, new Vector3(0.5f));
        var planned = planner.PlanMatured(first, 0, context, draw);
        var map = content.Maps.Single(item =>
            Path.GetFileNameWithoutExtension(item.Source) == manifest.MapId);
        Check(planned.Request == first.MaturedRequests[0] &&
              planned.SourceIndex == 1 && planned.PrefabIndex == 1 &&
              planned.AreaColliderFileId == content.PvpBonusSpawnAreas.ForMap(map)[0].ColliderFileId &&
              planned.Position == content.PvpBonusSpawnAreas.Position(map, 0, draw.UnitPosition),
            "matured receipt binds one source selection and one reviewed map position");
        Check(planner.LastSourceIndex == 1 && planner.PlanCount == 1,
            "accepted plan advances shared source selection exactly once");
        Check(planner.PlanMatured(first, 0, context,
            new PvpBonusSpawnDraw(999f, 1, Vector3.One)) == planned && planner.PlanCount == 1,
            "replayed plan returns its original placement without another random draw");
        try { planner.PlanMatured(first, 0, context with {GoldBonusesCollected = 1}, draw);
            throw new Exception("Changed source context replay was accepted."); }
        catch (InvalidDataException) { checks++; }

        var second = Mature(3, 4);
        planner.EnqueueConfirmedBonus(Id(90), localId, 8);
        var heldQueue = planner.QueuedCount(PvpBonusSide.Allies);
        try { planner.PlanMatured(second, 0, context,
                new PvpBonusSpawnDraw(0f, 2, Vector3.Zero));
            throw new Exception("Invalid area consumed queued bonus."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(planner.QueuedCount(PvpBonusSide.Allies) == heldQueue &&
              planner.LastSourceIndex == 1 && planner.PlanCount == 1,
            "failed placement keeps the source FIFO and last-index history intact");
        var forced = planner.PlanMatured(second, 0, context,
            new PvpBonusSpawnDraw(0f, 1, Vector3.Zero));
        Check(forced.SourceIndex == 8 && forced.PrefabIndex == 8 &&
              planner.QueuedCount(PvpBonusSide.Allies) == 0 && planner.LastSourceIndex == 8,
            "accepted queued override bypasses weights and consumes one FIFO item");

        var falling = planner.BoxSnapshot(planned.Request.ReceiptId);
        Check(falling.Phase == PvpBonusBoxPhase.Falling && planner.ActiveBoxCount == 2 &&
              planner.BoxReceiptCount == 2,
            "accepted spawn plans also register host-owned falling boxes before selection commits");
        try { planner.EffectIntent(falling.BoxId);
            throw new Exception("Uncollected crate exposed an effect."); }
        catch (InvalidOperationException) { checks++; }
        Check(planner.ConfirmStaticContact(falling.BoxId).Phase == PvpBonusBoxPhase.Grounded &&
              planner.ConfirmStaticContact(falling.BoxId).Phase == PvpBonusBoxPhase.Grounded,
            "repeated static contacts do not create another box or collection");
        planner.ArmBoobyTrap(Id(200), localId);
        Check(planner.HasArmedBoobyTrap(localId) && planner.BoxReceiptCount == 3,
            "confirmed card effect arms the earning fraction before collection");
        var stolen = planner.ConfirmDestroyed(falling.BoxId, Id(201), manifest.Players[1].PlayerId);
        Check(stolen is {Stolen:true,BoobyTrapped:true} &&
              stolen.OwnerPlayerId == localId && stolen.RecipientPlayerId == manifest.Players[1].PlayerId &&
              planner.ActiveBoxCount == 1 && !planner.HasArmedBoobyTrap(localId),
            "opposing damage claims exactly one box and consumes its owner's booby trap");
        Check(planner.EffectIntent(falling.BoxId) ==
              new PvpBonusEffectIntent(falling.BoxId, manifest.Players[1].PlayerId,
                  PvpBonusEffectKind.BoobyTrap),
            "stolen trapped box replaces its original healing effect with booby-trap intent");
        planner.ArmBoobyTrap(Id(200), localId);
        Check(!planner.HasArmedBoobyTrap(localId),
            "replaying an already consumed card receipt cannot arm another trap");
        Check(planner.ConfirmDestroyed(falling.BoxId, Id(201), manifest.Players[1].PlayerId) == stolen &&
              planner.BoxSnapshot(falling.BoxId).Collection == stolen && planner.BoxReceiptCount == 4,
            "damage and spawn replay return their original terminal result without a second grant");
        try { planner.ArmBoobyTrap(Id(200), manifest.Players[1].PlayerId);
            throw new Exception("Trap receipt changed its owner."); }
        catch (InvalidDataException) { checks++; }
        try { planner.ConfirmDestroyed(falling.BoxId, Id(202), localId);
            throw new Exception("Collected box chose another winner."); }
        catch (InvalidDataException) { checks++; }
        Check(planner.ConfirmStaticContact(falling.BoxId).Phase == PvpBonusBoxPhase.Collected,
            "late static contact cannot resurrect a collected box");
        var airborne = planner.BoxSnapshot(forced.Request.ReceiptId);
        var ownerFallback = planner.ConfirmDestroyed(airborne.BoxId, Id(203), null);
        Check(ownerFallback.RecipientPlayerId == localId && !ownerFallback.Stolen &&
              !ownerFallback.BoobyTrapped && planner.ActiveBoxCount == 0,
            "source null damage owner falls back to the box owner even before ground contact");
        Check(planner.EffectIntent(airborne.BoxId).Kind == PvpBonusEffectKind.Ammo,
            "untrapped collection retains its source prefab effect");

        var effectRegistry = new PvpBonusBoxRegistry(content, manifest);
        PvpBonusEffectKind[] expectedEffects = [PvpBonusEffectKind.Gold,
            PvpBonusEffectKind.Health, PvpBonusEffectKind.Warbucks,
            PvpBonusEffectKind.Grenades, PvpBonusEffectKind.SlowMotion,
            PvpBonusEffectKind.Turret, PvpBonusEffectKind.Kevlar,
            PvpBonusEffectKind.Card, PvpBonusEffectKind.Ammo];
        for (int index = 0; index < expectedEffects.Length; index++)
        {
            var request = planned.Request with {ReceiptId = Id(400 + index)};
            var sourcePlan = planned with {Request = request,
                SourceIndex = index, PrefabIndex = index};
            effectRegistry.Register(sourcePlan);
            effectRegistry.ConfirmDestroyed(request.ReceiptId, Id(420 + index), null);
            Check(effectRegistry.EffectIntent(request.ReceiptId) ==
                  new PvpBonusEffectIntent(request.ReceiptId, localId, expectedEffects[index]),
                "collected source bonus index maps to its recovered effect kind");
        }

        var third = Mature(5, 7);
        var weights = content.PvpBonuses.WeightsForSourceContext(
            new(false, false, 9, 8, 0, false));
        float upperEndpoint = PvpBonusSelectionState.SourceTotal(weights, 8);
        try { planner.PlanMatured(third, 0, context,
                new PvpBonusSpawnDraw(upperEndpoint + 1f, 0, Vector3.One));
            throw new Exception("Out-of-range weighted draw changed source selection."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(planner.LastSourceIndex == 8 && planner.PlanCount == 2,
            "rejected probability draw leaves the mature request available for retry");
        var endpoint = planner.PlanMatured(third, 0, context,
            new PvpBonusSpawnDraw(upperEndpoint, 0, Vector3.One));
        Check(endpoint.SourceIndex == 9 && endpoint.PrefabIndex == 8 &&
              planner.LastSourceIndex == 9,
            "source upper-endpoint fallthrough preserves history 9 but publishes actual prefab 8");

        var engine = new MatchEngine(manifest, map, content, combatRandom: () => 1f);
        engine.Admit(localId);
        engine.Admit(manifest.Players[1].PlayerId);
        foreach (var player in manifest.Players)
            engine.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                Ready = new ReadyCommand {ManifestHash = engine.ManifestHash}});
        engine.Advance(60);
        float beforeRejectedHit = engine.Snapshot().Players[1].Health;
        try { engine.ApplyResolvedPlayerDamage(localId, manifest.Players[1].PlayerId,
                new ResolvedPlayerDamage(10f, CombatDamageType.Shot), 1f,
                confirmedProjectileImpact: true, sourcePlayerBullet: true,
                pvpPlayerDamageReceiptId: "invalid");
            throw new Exception("Malformed PvP score receipt accepted player damage."); }
        catch (InvalidDataException) { checks++; }
        Check(engine.Snapshot().Players[1].Health == beforeRejectedHit &&
              engine.BonusProgress.ScoreSnapshot(localId).Score == 0,
            "failed score preparation leaves player damage and source progress untouched");
        var directHit = engine.ApplyResolvedPlayerDamage(localId,
            manifest.Players[1].PlayerId,
            new ResolvedPlayerDamage(10f, CombatDamageType.Shot), 1f,
            confirmedProjectileImpact: true, sourcePlayerBullet: true,
            pvpPlayerDamageReceiptId: Id(600));
        Check(directHit is {Applied:true} &&
              engine.BonusProgress.ScoreSnapshot(localId).Score == 6 &&
              engine.BonusProgress.Snapshot(localId).Progress == 4.5f,
            "confirmed player bullet publishes source hit score with accepted damage");
        var armyHit = engine.ApplyResolvedPlayerDamage(localId,
            manifest.Players[1].PlayerId,
            new ResolvedPlayerDamage(10f, CombatDamageType.Shot), 1f,
            confirmedProjectileImpact: true,
            pvpPlayerDamageReceiptId: Id(601),
            pvpDamageOwner: PvpPlayerDamageOwner.Army);
        Check(armyHit is {Applied:true} &&
              engine.BonusProgress.ScoreSnapshot(localId).Score == 16 &&
              engine.BonusProgress.Snapshot(localId).Progress == 12f,
            "host-confirmed army impact credits the owning player's ArmyPlayerHit row");
        var projectileEngine = new MatchEngine(manifest, map, content,
            combatRandom: () => 1f);
        foreach (var player in manifest.Players) projectileEngine.Admit(player.PlayerId);
        foreach (var player in manifest.Players)
            projectileEngine.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                Ready = new ReadyCommand {ManifestHash = projectileEngine.ManifestHash}});
        projectileEngine.Advance(60);
        var projectileImpact = new BulletImpact(601, localId,
            new ShotCollision(1f, Vector3.One, "army-player", manifest.Players[1].PlayerId, 1f),
            60);
        var projectileHit = projectileEngine.ApplyConfirmedArmyProjectilePlayerDamage(
            projectileImpact, new ResolvedPlayerDamage(10f, CombatDamageType.Shot), 1f);
        Check(projectileHit is {Applied:true} &&
              projectileEngine.BonusProgress.ScoreSnapshot(localId).Score == 10 &&
              projectileEngine.BonusProgress.Snapshot(localId).Progress == 7.5f &&
              projectileEngine.Snapshot().Players[1].Health == 990f,
            "host army projectile receipt publishes source army score and player damage");
        var clockManifest = manifest with {
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode
        };
        var clockEngine = new MatchEngine(clockManifest, map, content,
            combatRandom: () => 1f);
        foreach (var player in manifest.Players) clockEngine.Admit(player.PlayerId);
        foreach (var player in manifest.Players)
            clockEngine.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                Ready = new ReadyCommand {ManifestHash = clockEngine.ManifestHash}});
        clockEngine.Advance(60);
        for (int index = 0; index < 3; index++)
            clockEngine.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(700 + index), 0x1210, 1f);
        clockEngine.Advance(61);
        Check(clockEngine.BonusProgress.PendingCount == 1 &&
              clockEngine.MaturedBonusRequests.Count == 0,
            "a live match tick issues the source streak request without an early crate");
        for (ulong nextTick = 62; nextTick <= 153; nextTick++)
            clockEngine.Advance(nextTick);
        var maturedInMatch = clockEngine.MaturedBonusRequests;
        Check(maturedInMatch.Count == 1 &&
              maturedInMatch[0].OwnerPlayerId == localId &&
              maturedInMatch[0].BonusOrdinal == 1 &&
              clockEngine.BonusProgress.PendingCount == 0,
            "the match clock retains a matured source request for later crate issuance");
        clockEngine.Advance(153);
        Check(clockEngine.MaturedBonusRequests.SequenceEqual(maturedInMatch),
            "replaying one match tick does not mature or duplicate a bonus request");
        clockEngine.BonusPlanner.EnqueueConfirmedBonus(Id(750), localId, 6);
        Check(!clockEngine.FirstTwoUsedWeaponsHaveLowAmmo(localId),
            "full starting ammunition is not a source low-ammo bonus condition");
        try
        {
            clockEngine.IssueNextMaturedBonus(
                context with {FirstTwoWeaponsHaveLowAmmo = true}, draw);
            throw new Exception("Caller supplied an unproven low-ammo weight boost.");
        }
        catch (InvalidDataException) { checks++; }
        Check(clockEngine.MaturedBonusRequests.Count == 1 &&
              clockEngine.BonusPlanner.ActiveBoxCount == 0,
            "host ammunition mismatch preserves the matured box request");
        try
        {
            clockEngine.IssueNextMaturedBonus(context with {IsWarArena = true}, draw);
            throw new Exception("Untrusted Arena mode selected an ordinary PvP box.");
        }
        catch (InvalidDataException) { checks++; }
        Check(clockEngine.MaturedBonusRequests.Count == 1 &&
              clockEngine.BonusPlanner.ActiveBoxCount == 0,
            "a mode mismatch cannot consume the signed match's matured request");
        try
        {
            clockEngine.IssueNextMaturedBonus(context,
                new PvpBonusSpawnDraw(-1f, 0, Vector3.One));
            throw new Exception("Rejected box draw consumed the live matured request.");
        }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(clockEngine.MaturedBonusRequests.Count == 1 &&
              clockEngine.BonusPlanner.ActiveBoxCount == 0,
            "invalid host selection leaves the oldest matured request available");
        var issuedInMatch = clockEngine.IssueNextMaturedBonus(context, draw);
        Check(issuedInMatch?.Request == maturedInMatch[0] &&
              issuedInMatch.PrefabIndex == 6 &&
              clockEngine.MaturedBonusRequests.Count == 0 &&
              clockEngine.BonusPlanner.ActiveBoxCount == 1 &&
              clockEngine.IssueNextMaturedBonus(context, draw) == null,
            "a host-confirmed selection registers one box and consumes its live request once");
        if (issuedInMatch == null)
            throw new Exception("Live matured bonus was not issued.");
        clockEngine.BonusPlanner.ConfirmDestroyed(issuedInMatch.Request.ReceiptId,
            Id(751), null);
        Check(clockEngine.ApplyCollectedPvpBonus(issuedInMatch.Request.ReceiptId) ==
                  "bonus-applied" &&
              clockEngine.Snapshot().Players[0].KevlarHealth ==
                  manifest.Players[0].Combat!.MaxHealth * 0.1f,
            "a box issued from the live streak clock reaches its verified Kevlar effect");
        var enginePlanner = engine.BonusPlanner;
        enginePlanner.EnqueueConfirmedBonus(Id(500), localId, 6);
        var kevlarPlan = enginePlanner.PlanMatured(second, 0, context, draw);
        enginePlanner.ConfirmDestroyed(kevlarPlan.Request.ReceiptId, Id(501), null);
        Check(kevlarPlan.PrefabIndex == 6 &&
              engine.ApplyCollectedPvpBonus(kevlarPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[0].KevlarHealth ==
                  manifest.Players[0].Combat!.MaxHealth * 0.1f,
            "collected Kevlar crate changes the admitted match player's armor");
        ulong armorRevision = engine.Snapshot().Players[0].DamageRevision;
        Check(engine.ApplyCollectedPvpBonus(kevlarPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[0].DamageRevision == armorRevision,
            "replaying a collected crate cannot refill Kevlar twice");
        enginePlanner.EnqueueConfirmedBonus(Id(502), localId, 8);
        var ammoPlan = enginePlanner.PlanMatured(third, 0, context, draw);
        enginePlanner.ConfirmDestroyed(ammoPlan.Request.ReceiptId, Id(503), null);
        int oldReserve = engine.Snapshot().Players[0].ReserveAmmo;
        int clipSize = manifest.Players[0].Weapon.ClipSize;
        Check(engine.ApplyCollectedPvpBonus(ammoPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[0].ReserveAmmo == oldReserve + clipSize &&
              engine.ApplyCollectedPvpBonus(ammoPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[0].ReserveAmmo == oldReserve + clipSize,
            "collected ammo crate increases reserve once, including on replay");
        enginePlanner.EnqueueConfirmedBonus(Id(504), localId, 1);
        var healthPlan = enginePlanner.PlanMatured(first, 0, context, draw);
        enginePlanner.ConfirmDestroyed(healthPlan.Request.ReceiptId, Id(505), null);
        var damageResult = engine.ApplyResolvedPlayerDamage(manifest.Players[1].PlayerId, localId,
            new ResolvedPlayerDamage(200f, CombatDamageType.Basic, HasWeapon: false), 1f);
        float damagedHealth = engine.Snapshot().Players[0].Health;
        var healthCode = engine.ApplyCollectedPvpBonus(healthPlan.Request.ReceiptId);
        float healedHealth = engine.Snapshot().Players[0].Health;
        var replayCode = engine.ApplyCollectedPvpBonus(healthPlan.Request.ReceiptId);
        Check(damageResult is {Applied:true,Health:900f} &&
              healthCode == "bonus-applied" &&
              healedHealth == damagedHealth + manifest.Players[0].Combat!.MaxHealth * 0.1f &&
              replayCode == "bonus-applied" && engine.Snapshot().Players[0].Health == healedHealth,
            $"health crate uses negative Basic damage once: {damageResult}, {healthCode}, {replayCode}, {damagedHealth}, {healedHealth}");
        Check(content.PvpBoobyTrap.Damage(1000f) == 150f,
            "booby-trap damage comes from the pinned CardConstants row");
        var fourth = Mature(7, 10);
        enginePlanner.ArmBoobyTrap(Id(506), localId);
        var trappedPlan = enginePlanner.PlanMatured(fourth, 0, context, draw);
        var trapped = enginePlanner.ConfirmDestroyed(trappedPlan.Request.ReceiptId,
            Id(507), manifest.Players[1].PlayerId);
        Check(trapped.BoobyTrapped &&
              engine.ApplyCollectedPvpBonus(trappedPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[1].Health == 830f &&
              engine.ApplyCollectedPvpBonus(trappedPlan.Request.ReceiptId) == "bonus-applied" &&
              engine.Snapshot().Players[1].Health == 830f,
            "stolen trapped crate damages the thief once through the player explosion path");

        var lethalEngine = new MatchEngine(manifest, map, content, combatRandom: () => 1f);
        foreach (var player in manifest.Players) lethalEngine.Admit(player.PlayerId);
        foreach (var player in manifest.Players)
            lethalEngine.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                Ready = new ReadyCommand {ManifestHash = lethalEngine.ManifestHash}});
        lethalEngine.Advance(60);
        var lethalPlanner = lethalEngine.BonusPlanner;
        lethalPlanner.ArmBoobyTrap(Id(508), localId);
        var lethalPlan = lethalPlanner.PlanMatured(fourth, 0, context, draw);
        lethalPlanner.ConfirmDestroyed(lethalPlan.Request.ReceiptId,
            Id(509), manifest.Players[1].PlayerId);
        lethalEngine.ApplyResolvedPlayerDamage(localId, manifest.Players[1].PlayerId,
            new ResolvedPlayerDamage(950f, CombatDamageType.Basic, HasWeapon: false), 1f);
        Check(lethalEngine.ApplyCollectedPvpBonus(lethalPlan.Request.ReceiptId) ==
                  "bonus-applied" && lethalEngine.Terminal &&
              lethalEngine.Snapshot().Players[1].Dead &&
              lethalEngine.ApplyCollectedPvpBonus(lethalPlan.Request.ReceiptId) ==
                  "bonus-applied",
            "lethal booby trap ends the match and its box remains replay-safe after termination");

        var twoOwners = manifest with {
            Players = [manifest.Players[0], manifest.Players[1] with {PlayerLevel = 5}]
        };
        using var bothProgress = PvpBonusProgressCoordinator.CreateForOnlineManifest(
            content, twoOwners, localId);
        var bothPlanner = new PvpBonusSpawnPlanner(content, twoOwners, localId);
        for (int index = 0; index < 3; index++)
        {
            bothProgress.RecordConfirmedSkillShot(localId, Id(100 + index), 0x1210, 1f);
            bothProgress.RecordConfirmedSkillShot(twoOwners.Players[1].PlayerId,
                Id(110 + index), 0x1210, 1f);
        }
        bothProgress.AdvanceFrame(1, 0f, true);
        var bothReady = bothProgress.AdvanceFrame(2, 1.5f, false);
        bothPlanner.EnqueueConfirmedBonus(Id(120), twoOwners.Players[1].PlayerId, 7);
        var localPlan = bothPlanner.PlanMatured(bothReady, 0, context, draw);
        var enemyPlan = bothPlanner.PlanMatured(bothReady, 1, context, draw);
        Check(localPlan.Request.OwnerPlayerId == localId && localPlan.PrefabIndex == 1 &&
              enemyPlan.Request.OwnerPlayerId == twoOwners.Players[1].PlayerId &&
              enemyPlan.PrefabIndex == 7 && bothPlanner.LastSourceIndex == 7 &&
              bothPlanner.QueuedCount(PvpBonusSide.Enemy) == 0,
            "both owners share one selection history while fraction-specific queue overrides stay separate");

        using var capacityProgress = PvpBonusProgressCoordinator.CreateForOnlineManifest(
            content, manifest, localId);
        var capacityPlanner = new PvpBonusSpawnPlanner(content, manifest, localId,
            maximumActiveBoxes: 1);
        PvpBonusProgressFrame CapacityMature(int issueFrame, int firstReceipt)
        {
            for (int index = 0; index < 3; index++)
                capacityProgress.RecordConfirmedSkillShot(localId,
                    Id(firstReceipt + index), 0x1210, 1f);
            capacityProgress.AdvanceFrame((ulong)issueFrame, 0f, true);
            return capacityProgress.AdvanceFrame((ulong)(issueFrame + 1), 1.5f, false);
        }
        var capacityFirst = capacityPlanner.PlanMatured(
            CapacityMature(1, 300), 0, context, draw);
        var capacitySecondFrame = CapacityMature(3, 303);
        capacityPlanner.EnqueueConfirmedBonus(Id(310), localId, 8);
        try { capacityPlanner.PlanMatured(capacitySecondFrame, 0, context, draw);
            throw new Exception("Full box capacity consumed source selection."); }
        catch (InvalidOperationException) { checks++; }
        Check(capacityPlanner.PlanCount == 1 && capacityPlanner.ActiveBoxCount == 1 &&
              capacityPlanner.BoxReceiptCount == 1 && capacityPlanner.LastSourceIndex == 1 &&
              capacityPlanner.QueuedCount(PvpBonusSide.Allies) == 1,
            "full box capacity preserves the matured request and its queued source override");
        capacityPlanner.ConfirmDestroyed(capacityFirst.Request.ReceiptId, Id(311), null);
        var capacityRetry = capacityPlanner.PlanMatured(capacitySecondFrame, 0, context, draw);
        Check(capacityRetry.SourceIndex == 8 && capacityPlanner.PlanCount == 2 &&
              capacityPlanner.ActiveBoxCount == 1 && capacityPlanner.LastSourceIndex == 8 &&
              capacityPlanner.QueuedCount(PvpBonusSide.Allies) == 0,
            "collection frees capacity and the exact matured request then commits once");
        return checks;
    }
}
