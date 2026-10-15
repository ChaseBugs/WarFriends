using System.Numerics;
using Google.Protobuf;
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
        foreach (var sourceMap in content.Maps)
        {
            foreach (var area in content.PvpBonusSpawnAreas.ForMap(sourceMap))
            {
                Vector3 center = (area.BoundsMin + area.BoundsMax) / 2f;
                MapHit? landing = PvpBonusLandingProbe.FindStaticSurface(sourceMap, center);
                Check(landing != null && landing.Distance >= 0 &&
                      landing.Position.Y <= center.Y &&
                      (landing.Layer is 13 or 30) &&
                      landing.DynamicOwner == null,
                    "reviewed box area center has source-static geometry below it");
            }
        }
        try
        {
            PvpBonusLandingProbe.FindStaticSurface(content.Maps[0],
                new Vector3(float.NaN, 0, 0));
            throw new Exception("Non-finite bonus spawn entered the landing probe.");
        }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(content.AllWeaponBindings.Get("Google2u.AssaultRifle_AK47").ReloadableWeapon &&
              !content.AllWeaponBindings.Get("Google2u.LMG_Minigun").ReloadableWeapon,
            "source weapon graph retains the reloadable flags used by ammo probability");
        float lowAmmoThreshold = content.PvpBonuses.LowAmmoThreshold;
        Check(PvpBonusAmmoPolicy.HasLowAmmo(true, 100, 0, 9, lowAmmoThreshold) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(true, 100, 0, 10, lowAmmoThreshold) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(false, 100, 0, 0, lowAmmoThreshold) &&
              !PvpBonusAmmoPolicy.HasLowAmmo(true, 0, 0, 0, lowAmmoThreshold),
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
        try
        {
            MatchManifest.Validate(manifest with {
                PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
                PvpGoldBonusesAtAdmission = -1
            });
            throw new Exception("Negative durable Gold-box count entered a match.");
        }
        catch (InvalidDataException) { checks++; }
        Check(MatchManifest.Validate(manifest with {
                  PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
                  PvpGoldBonusesAtAdmission = 0
              }).PvpBonusMode == MatchManifest.OrdinaryPvpBonusMode,
            "ordinary bonus mode survives signed manifest validation");
        try
        {
            MatchManifest.Validate(manifest with {
                PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode
            });
            throw new Exception("PvP Gold selection accepted absent durable analytics.");
        }
        catch (InvalidDataException) { checks++; }
        using var progress = PvpBonusProgressCoordinator.CreateForOnlineManifest(content, manifest, localId);
        var planner = new PvpBonusSpawnPlanner(content, manifest, localId);
        var context = new PvpBonusSpawnContext(false, false, 0, false);
        var sourceWeights = content.PvpBonuses.WeightsForSourceContext(
            new PvpBonusWeightContext(false, false, 9, 8, 0, false));
        Check(planner.SpawnAreaCount == 2 &&
              planner.WeightTotal(localId, context) ==
                  PvpBonusSelectionState.SourceTotal(sourceWeights, 0),
            "host draw bounds come from signed owner level and reviewed map areas");
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
        Check(planned.StaticSurfaceCandidate is {Layer: 13 or 30} &&
              planned.StaticSurfaceCandidate.Position.Y <= planned.Position.Y,
            "registered box plan retains a source-static landing candidate");
        try
        {
            var forgedRegistry = new PvpBonusBoxRegistry(content, manifest);
            forgedRegistry.Register(planned with {StaticSurfaceCandidate = null});
            throw new Exception("A forged landing candidate entered the host box registry.");
        }
        catch (InvalidDataException) { checks++; }
        var map = content.Maps.Single(item =>
            Path.GetFileNameWithoutExtension(item.Source) == manifest.MapId);
        var cardGrenades = new CardGrenadesBurstPolicy(content.PvpBonuses);
        var cardTargets = Enumerable.Range(0, 4).Select(index =>
            new PvpBonusGrenadeTarget("army:" + index,
                manifest.Players[1].Fraction, true, true, true,
                new Vector3(index, 0, 0))).ToArray();
        var duplicateDraws = new Queue<int>([0, 0, 0]);
        var cardTargetsPlan = cardGrenades.Plan(Id(8000), localId,
            manifest.Players[0].Fraction, 8, Vector3.Zero,
            cardTargets, [], _ => duplicateDraws.Dequeue());
        Check(cardTargetsPlan.Launches.Select(launch => launch.TargetId)
                  .SequenceEqual(["army:0", "army:3", "army:2"]) &&
              cardTargetsPlan.Launches.All(launch => launch.DamageOverride == null),
            "CardGrenadesBurst preserves source random-index duplicate repair");

        var emptyShields = new[] {new Vector3(10, 0, 0),
            new Vector3(20, 0, 0), new Vector3(30, 0, 0)};
        var shieldDraws = new Queue<int>([0, 1, 0]);
        var cardFallbackPlan = cardGrenades.Plan(Id(8001), localId,
            manifest.Players[0].Fraction, 8, Vector3.Zero,
            cardTargets[..1], emptyShields,
            _ => shieldDraws.Dequeue());
        var cardDamage = content.PvpBonuses.GrenadeFallbackDamageForLevel(8);
        Check(cardFallbackPlan.Launches[0].TargetId == "army:0" &&
              cardFallbackPlan.Launches[1].Position == emptyShields[1] &&
              cardFallbackPlan.Launches[2].Position == emptyShields[0] &&
              cardFallbackPlan.Launches.Skip(1).All(launch =>
                  launch.DamageOverride == cardDamage) &&
              cardFallbackPlan.Launches.Select(launch => launch.DelayScaledSeconds)
                  .SequenceEqual([0.2f, 0.4f, 0.6f]),
            "CardGrenadesBurst uses distinct empty shields and 0.2-second launches");
        try
        {
            cardGrenades.Plan(Id(8003), localId, manifest.Players[0].Fraction,
                8, Vector3.Zero, cardTargets, [], _ => 99);
            throw new Exception("Out-of-range card target draw was accepted.");
        }
        catch (InvalidDataException) { checks++; }
        try
        {
            cardGrenades.Plan(Id(8004), localId, manifest.Players[0].Fraction,
                8, Vector3.Zero, cardTargets[..1], [], _ => 0);
            throw new Exception("Card burst used a missing enemy shield.");
        }
        catch (InvalidDataException) { checks++; }
        var sharedClock = new PvpBonusGrenadeBurstClock(content.PvpBonuses);
        sharedClock.AdvanceFrame(1, 0f);
        try
        {
            sharedClock.ScheduleCard(cardFallbackPlan with {OwnerLevel = 9}, 1);
            throw new Exception("Card fallback damage was accepted at another rank.");
        }
        catch (InvalidDataException) { checks++; }
        try
        {
            sharedClock.ScheduleCard(cardFallbackPlan with {
                FireOrigin = new Vector3(float.NaN, 0, 0)
            }, 1);
            throw new Exception("Invalid card launch origin reached the clock.");
        }
        catch (InvalidDataException) { checks++; }
        sharedClock.ScheduleCard(cardFallbackPlan, 1);
        var laterBox = new PvpBonusGrenadeBurstPlan(Id(8002), localId,
            [new(0, 1f, "player:" + manifest.Players[1].PlayerId,
                Vector3.One, null),
             new(1, 1.2f, null, Vector3.One, null),
             new(2, 1.4f, null, Vector3.One, null)]);
        sharedClock.Schedule(laterBox, 1);
        Check(sharedClock.AdvanceFrame(2, 0.2f).Single().CardFireOrigin == Vector3.Zero &&
              sharedClock.AdvanceFrame(3, 0.2f).Single().Launch.ShotIndex == 1 &&
              sharedClock.CurrentSharedDamage ==
                  new PvpBonusGrenadeSharedDamage(cardDamage.Explosion, cardDamage.Direct) &&
              sharedClock.AdvanceFrame(4, 0.2f).Single().Launch.ShotIndex == 2 &&
              sharedClock.AdvanceFrame(5, 0.2f).Count == 0 &&
              sharedClock.AdvanceFrame(6, 0.2f).Single().CardFireOrigin == null &&
              sharedClock.AdvanceFrame(6, 0.2f).Single().SetupAtLaunch ==
                  sharedClock.CurrentSharedDamage,
            "card fallback changes the Manager setup inherited by a later box shot");
        var callerLaunches = cardFallbackPlan.Launches.ToArray();
        var isolatedClock = new PvpBonusGrenadeBurstClock(content.PvpBonuses);
        isolatedClock.AdvanceFrame(1, 0f);
        isolatedClock.ScheduleCard(cardFallbackPlan with {
            RequestId = Id(8005), Launches = callerLaunches
        }, 1);
        Vector3 scheduledTarget = callerLaunches[0].Position;
        callerLaunches[0] = callerLaunches[0] with {Position = new Vector3(99, 0, 99)};
        Check(isolatedClock.AdvanceFrame(2, 0.2f).Single().Launch.Position ==
                  scheduledTarget,
            "scheduled card shots keep their validated target after caller mutation");
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
        var motionRegistry = new PvpBonusBoxRegistry(content, manifest);
        motionRegistry.Register(planned);
        try
        {
            motionRegistry.AdvanceFalling(float.MaxValue);
            throw new Exception("Overflowing fall step changed box authority.");
        }
        catch (InvalidDataException) { checks++; }
        Check(motionRegistry.Snapshot(planned.Request.ReceiptId).Position == planned.Position,
            "rejected fall frame leaves the registered box at its previous pose");
        motionRegistry.AdvanceFalling(0.1f);
        var descending = motionRegistry.Snapshot(planned.Request.ReceiptId);
        Check(descending.Phase == PvpBonusBoxPhase.Falling &&
              descending.Position.Y < planned.Position.Y &&
              descending.VerticalVelocity < 0,
            "host gravity moves the registered crate downward before static contact");
        motionRegistry.AdvanceFalling(10f);
        var landed = motionRegistry.Snapshot(planned.Request.ReceiptId);
        Check(landed.Phase == PvpBonusBoxPhase.Grounded &&
              landed.VerticalVelocity == 0 &&
              landed.Position.Y > landed.Plan.StaticSurfaceCandidate!.Position.Y &&
              motionRegistry.ActiveCount == 1,
            "host motion grounds a crate on its reviewed source-static surface");
        motionRegistry.AdvanceFalling(1f);
        Check(motionRegistry.Snapshot(planned.Request.ReceiptId) == landed,
            "later ticks do not move a grounded crate or collect it");
        var distantShooter = content.Poses.SampleBlended("idle", 0, true,
            "idle", 0, true, 0).Place(new Vector3(100, 0, 100),
                Quaternion.Identity).Collision;
        var distantOpponent = content.Poses.SampleBlended("idle", 0, true,
            "idle", 0, true, 0).Place(new Vector3(110, 0, 100),
                Quaternion.Identity).Collision;
        var boxWorld = new ShotCollisionWorld(null,
            [new(localId, distantShooter),
             new(manifest.Players[1].PlayerId, distantOpponent)],
            bonusBoxes: motionRegistry.ActiveSnapshot);
        Vector3 shotOrigin = landed.Position + Vector3.UnitX * 2f;
        Vector3 shotDirection = -Vector3.UnitX;
        const uint boxBulletMask = 1u << PvpBonusShotHitbox.RuntimeLayer;
        var boxHit = boxWorld.Raycast(localId, shotOrigin, shotDirection, 4f,
            boxBulletMask);
        Check(boxHit?.BonusBoxId == landed.BoxId &&
              boxHit.ColliderLayer == 8 && boxHit.SourceDestroyable &&
              boxWorld.Raycast(localId, shotOrigin, shotDirection, 4f, 0u) == null,
            "player ray hits only the active source runtime layer-8 box collider");
        var shotgunBoxCandidates = boxWorld.OverlapEnemy(localId,
            landed.Position + Vector3.UnitX * 2f, 3f, boxBulletMask);
        Check(shotgunBoxCandidates.Count == 1 &&
              shotgunBoxCandidates[0].MainEntityId == landed.BoxId &&
              shotgunBoxCandidates[0].Enemy,
            "source shotgun sphere includes the destroyable box for either fraction");
        var shotguns = ShotgunCatalog.Load(Path.Combine(directory,
            "shotgun-content-manifest.json"));
        var shotgun = shotguns.Bindings[0];
        var shotgunStage = shotguns.Stage(shotgun.SourceId, 0);
        var shotgunPlan = ShotgunShotPlanner.Plan(shotgun.Rule(shotgunStage),
            shotOrigin, landed.Position - Vector3.UnitX,
            shotgunBoxCandidates);
        Check(shotgunPlan.RealPellets.Count >= 2 &&
              shotgunPlan.RealPellets.Any(pellet => !pellet.Main &&
                  pellet.EntityId == shotgunBoxCandidates[0].EntityId &&
                  pellet.Target == landed.Position),
            "shotgun cone adds a real pellet aimed at the source box center");
        var boxFlight = new BulletFlight(9200, localId,
            new BulletFlightDefinition(100f, 0f, true), shotOrigin,
            landed.Position, 1,
            (from, ray, range) => boxWorld.Raycast(localId, from, ray, range,
                boxBulletMask));
        var boxImpact = boxFlight.Advance(2);
        Check(boxImpact?.Hit.BonusBoxId == landed.BoxId,
            "real bullet flight accepts the box as a distinct collision owner");
        Check(motionRegistry.ApplyConfirmedDamage(landed.BoxId, Id(9201),
                  localId, 0.4f) == null &&
              motionRegistry.Snapshot(landed.BoxId).Health > 0.5f,
            "a sublethal bullet reduces the original one-HP box without collection");
        float boxDamagedHealth = motionRegistry.Snapshot(landed.BoxId).Health;
        motionRegistry.ApplyConfirmedDamage(landed.BoxId, Id(9201), localId, 0.4f);
        Check(motionRegistry.Snapshot(landed.BoxId).Health == boxDamagedHealth,
            "replaying a sublethal bullet cannot subtract box health twice");
        var lethalCollection = motionRegistry.ApplyConfirmedDamage(landed.BoxId,
            Id(9202), localId, boxDamagedHealth);
        Check(lethalCollection?.RecipientPlayerId == localId &&
              motionRegistry.Snapshot(landed.BoxId).Phase == PvpBonusBoxPhase.Collected &&
              boxWorld.Raycast(localId, shotOrigin, shotDirection, 4f,
                  boxBulletMask) == null,
            "only cumulative lethal bullet damage collects and removes the box");
        try
        {
            motionRegistry.AdvanceFalling(float.NaN);
            throw new Exception("Non-finite box frame moved host authority.");
        }
        catch (ArgumentOutOfRangeException) { checks++; }
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
        try { planner.QuoteCurrencyReward(falling.BoxId, 500);
            throw new Exception("Booby-trapped box exposed a currency reward."); }
        catch (InvalidOperationException) { checks++; }
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

        var currencyManifest = manifest with {
            Players = [manifest.Players[0], manifest.Players[1] with {PlayerLevel = 3}]
        };
        var currencyPlanner = new PvpBonusSpawnPlanner(content, currencyManifest, localId);
        currencyPlanner.EnqueueConfirmedBonus(Id(500), localId, 0);
        var goldPlan = currencyPlanner.PlanMatured(first, 0, context, draw);
        try { currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId, 8);
            throw new Exception("Uncollected Gold box exposed a reward quote."); }
        catch (InvalidOperationException) { checks++; }
        currencyPlanner.ConfirmDestroyed(goldPlan.Request.ReceiptId, Id(501),
            currencyManifest.Players[1].PlayerId);
        try { currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId, 10);
            throw new Exception("Gold quote accepted a draw outside the recipient's rank range."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        var goldQuote = currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId, 8);
        Check(goldQuote == new PvpBonusCurrencyRewardQuote(currencyManifest.MatchId,
                  goldPlan.Request.ReceiptId, currencyManifest.Players[1].PlayerId,
                  PvpBonusEffectKind.Gold, 8, 8) &&
              currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId, 8) == goldQuote &&
              currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId) == goldQuote,
            "stolen Gold box uses the recipient's display rank and replays one host quote");
        try { currencyPlanner.QuoteCurrencyReward(goldPlan.Request.ReceiptId, 5);
            throw new Exception("Gold reward replay changed its draw."); }
        catch (InvalidDataException) { checks++; }

        currencyPlanner.EnqueueConfirmedBonus(Id(502), localId, 2);
        var moneyPlan = currencyPlanner.PlanMatured(second, 0, context, draw);
        currencyPlanner.ConfirmDestroyed(moneyPlan.Request.ReceiptId, Id(503),
            currencyManifest.Players[1].PlayerId);
        var moneyQuote = currencyPlanner.QuoteCurrencyReward(moneyPlan.Request.ReceiptId, 500);
        Check(moneyQuote.Kind == PvpBonusEffectKind.Warbucks &&
              moneyQuote.RecipientPlayerId == currencyManifest.Players[1].PlayerId &&
              moneyQuote.Amount == 500,
            "Warbucks scaling uses the collected recipient's zero-based rank");
        try { currencyPlanner.QuoteCurrencyReward(moneyPlan.Request.ReceiptId, 1500);
            throw new Exception("Warbucks reward replay changed its draw."); }
        catch (InvalidDataException) { checks++; }

        var third = Mature(5, 7);
        currencyPlanner.EnqueueConfirmedBonus(Id(504), localId, 0);
        var randomGoldPlan = currencyPlanner.PlanMatured(third, 0, context, draw);
        currencyPlanner.ConfirmDestroyed(randomGoldPlan.Request.ReceiptId, Id(505), null);
        var hostDrawnQuote = currencyPlanner.QuoteCurrencyReward(randomGoldPlan.Request.ReceiptId);
        var hostGoldRange = content.PvpBonuses.GoldRewardRange(9);
        Check(hostDrawnQuote.BaseDraw >= hostGoldRange.Minimum &&
              hostDrawnQuote.BaseDraw < hostGoldRange.MaximumExclusive &&
              hostDrawnQuote.Amount == hostDrawnQuote.BaseDraw &&
              currencyPlanner.QuoteCurrencyReward(randomGoldPlan.Request.ReceiptId) == hostDrawnQuote,
            "host draws a Gold reward in the recipient range only once per collected box");
        var randomMoneyPlanner = new PvpBonusSpawnPlanner(content, currencyManifest, localId);
        randomMoneyPlanner.EnqueueConfirmedBonus(Id(506), localId, 2);
        var randomMoneyPlan = randomMoneyPlanner.PlanMatured(first, 0, context, draw);
        randomMoneyPlanner.ConfirmDestroyed(randomMoneyPlan.Request.ReceiptId, Id(507),
            currencyManifest.Players[1].PlayerId);
        var hostMoneyQuote = randomMoneyPlanner.QuoteCurrencyReward(randomMoneyPlan.Request.ReceiptId);
        Check(hostMoneyQuote.BaseDraw is >= 500 and < 1500 &&
              hostMoneyQuote.Amount == hostMoneyQuote.BaseDraw &&
              randomMoneyPlanner.QuoteCurrencyReward(randomMoneyPlan.Request.ReceiptId) == hostMoneyQuote,
            "host draws one Warbucks base value and scales by the actual rank-three recipient");
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

        int hostCombatDraws = 0;
        var engine = new MatchEngine(manifest, map, content, combatRandom: () => {
            hostCombatDraws++;
            return 1f;
        });
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
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
            PvpGoldBonusesAtAdmission = 0
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
        clockEngine.BonusPlanner.EnqueueConfirmedBonus(Id(750), localId, 6);
        Check(!clockEngine.FirstTwoUsedWeaponsHaveLowAmmo(localId),
            "full starting ammunition is not a source low-ammo bonus condition");
        ulong firstBoxTick = 0;
        for (ulong nextTick = 62; nextTick <= 153; nextTick++)
        {
            clockEngine.Advance(nextTick);
            if (firstBoxTick == 0 && clockEngine.BonusPlanner.ActiveBoxCount > 0)
                firstBoxTick = nextTick;
        }
        var issuedInMatch = clockEngine.BonusPlanner.ActiveBoxesSnapshot().Single().Plan;
        Check(issuedInMatch.Request.OwnerPlayerId == localId &&
              issuedInMatch.Request.BonusOrdinal == 1 &&
              issuedInMatch.PrefabIndex == 6 &&
              clockEngine.BonusProgress.PendingCount == 0 &&
              clockEngine.MaturedBonusRequests.Count == 0 &&
              clockEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 0 &&
              firstBoxTick is >= 105 and <= 108,
            "the source wait automatically issues and consumes one queued Kevlar crate");
        clockEngine.Advance(153);
        Check(clockEngine.BonusPlanner.ActiveBoxCount == 1 &&
              clockEngine.IssueNextMaturedBonus() == null,
            "replaying one match tick does not issue a second crate");
        var issuedRow = clockEngine.Snapshot().PvpBonusBoxes.Single();
        var issuedBox = clockEngine.BonusPlanner.BoxSnapshot(issuedInMatch.Request.ReceiptId);
        Check(issuedRow.BoxId == issuedInMatch.Request.ReceiptId &&
              issuedRow.OwnerPlayerId == localId &&
              issuedRow.PrefabIndex == issuedInMatch.PrefabIndex &&
              issuedRow.Phase == (int)issuedBox.Phase &&
              issuedRow.Y == issuedBox.Position.Y,
            "public battle snapshot includes the host-owned live crate pose");
        var wireSnapshot = MatchSnapshot.Parser.ParseFrom(
            clockEngine.Snapshot().ToByteArray());
        War.Client.BattlePvpBonusBoxPolicy.Validate(wireSnapshot);
        Check(wireSnapshot.PvpBonusBoxes.Single().BoxId == issuedRow.BoxId,
            "protobuf roundtrip preserves a validated active bonus box");
        var forgedSnapshot = clockEngine.Snapshot().Clone();
        forgedSnapshot.PvpBonusBoxes[0].OwnerPlayerId = Id(9999);
        try
        {
            War.Client.BattlePvpBonusBoxPolicy.Validate(forgedSnapshot);
            throw new Exception("Client accepted a box owned outside the match.");
        }
        catch (InvalidOperationException) { checks++; }
        forgedSnapshot = clockEngine.Snapshot().Clone();
        forgedSnapshot.PvpBonusBoxes[0].Phase = 2;
        try
        {
            War.Client.BattlePvpBonusBoxPolicy.Validate(forgedSnapshot);
            throw new Exception("Client accepted a terminal box in the active list.");
        }
        catch (InvalidOperationException) { checks++; }
        clockEngine.Advance(154);
        Check(clockEngine.BonusPlanner.BoxSnapshot(issuedInMatch.Request.ReceiptId)
                  .Position.Y <= issuedBox.Position.Y &&
              clockEngine.Snapshot().PvpBonusBoxes.Single().Y <= issuedRow.Y,
            "a normal running match tick preserves or advances its crate pose");
        var liveBox = clockEngine.BonusPlanner.BoxSnapshot(issuedInMatch.Request.ReceiptId);
        var liveBoxWorld = new ShotCollisionWorld(null,
            [new(localId, distantShooter),
             new(manifest.Players[1].PlayerId, distantOpponent)],
            bonusBoxes: clockEngine.BonusPlanner.ActiveBoxesSnapshot);
        var liveBoxHit = liveBoxWorld.Raycast(localId,
            liveBox.Position + Vector3.UnitX * 2f, -Vector3.UnitX, 4f,
            boxBulletMask);
        Check(liveBoxHit?.BonusBoxId == liveBox.BoxId,
            "player bullet trace selects the issued live-match bonus box");
        var confirmedBoxImpact = new BulletImpact(751, localId, liveBoxHit!,
            clockEngine.Snapshot().ServerTick);
        clockEngine.ApplyPlayerBulletBonusImpact(confirmedBoxImpact, 2f);
        Check(clockEngine.Snapshot().PvpBonusBoxes.Count == 0,
            "collected crate disappears from the reconnect snapshot");
        Check(clockEngine.ApplyCollectedPvpBonus(issuedInMatch.Request.ReceiptId) ==
                  "bonus-applied" &&
              clockEngine.Snapshot().Players[0].KevlarHealth ==
                  manifest.Players[0].Combat!.MaxHealth * 0.1f,
            "host-confirmed bullet collection applies the source Kevlar effect");
        ulong collectedRevision = clockEngine.Snapshot().StateRevision;
        clockEngine.ApplyPlayerBulletBonusImpact(confirmedBoxImpact, 2f);
        Check(clockEngine.Snapshot().StateRevision == collectedRevision &&
              liveBoxWorld.Raycast(localId, liveBox.Position + Vector3.UnitX * 2f,
                  -Vector3.UnitX, 4f, boxBulletMask) == null,
            "replaying a bullet cannot recollect or keep a destroyed box shootable");
        clockEngine.BonusPlanner.EnqueueConfirmedBonus(Id(752), localId, 0);
        var liveGoldPlan = clockEngine.BonusPlanner.PlanMatured(second, 0, context, draw);
        Check(clockEngine.ApplyCollectedPvpBonus(liveGoldPlan.Request.ReceiptId) ==
                  "bonus-unavailable" && clockEngine.CurrencyBonusQuotes.Count == 0,
            "uncollected live Gold box cannot produce a currency quote");
        clockEngine.BonusPlanner.ConfirmDestroyed(liveGoldPlan.Request.ReceiptId,
            Id(753), manifest.Players[1].PlayerId);
        Check(clockEngine.ApplyCollectedPvpBonus(liveGoldPlan.Request.ReceiptId) ==
                  "bonus-quoted" &&
              clockEngine.CurrencyBonusQuotes.Single().RecipientPlayerId ==
                  manifest.Players[1].PlayerId &&
              clockEngine.CurrencyBonusQuotes.Single().Amount is >= 3 and < 6,
            "live engine quotes stolen Gold for the confirmed recipient without a wallet grant");
        var firstGoldQuote = clockEngine.CurrencyBonusQuotes.Single();
        Check(clockEngine.ApplyCollectedPvpBonus(liveGoldPlan.Request.ReceiptId) ==
                  "bonus-quoted" &&
              clockEngine.CurrencyBonusQuotes.Single() == firstGoldQuote,
            "replaying live Gold collection retains the first host draw");
        clockEngine.BonusPlanner.EnqueueConfirmedBonus(Id(754), localId, 2);
        var liveMoneyPlan = clockEngine.BonusPlanner.PlanMatured(third, 0, context, draw);
        clockEngine.BonusPlanner.ConfirmDestroyed(liveMoneyPlan.Request.ReceiptId,
            Id(755), null);
        Check(clockEngine.ApplyCollectedPvpBonus(liveMoneyPlan.Request.ReceiptId) ==
                  "bonus-quoted" &&
              clockEngine.CurrencyBonusQuotes.Count == 2 &&
              clockEngine.CurrencyBonusQuotes.Single(quote =>
                  quote.BoxId == liveMoneyPlan.Request.ReceiptId).Kind ==
                  PvpBonusEffectKind.Warbucks,
            "live engine retains both Gold and Warbucks quotes by confirmed box ID");
        clockEngine.Command(localId, new MatchCommand {CommandId = 2,
            Forfeit = new ForfeitCommand()});
        var quoteTerminal = clockEngine.TerminalEvidenceSnapshot();
        Check(clockEngine.Snapshot().PvpCurrencyQuotes.Count == 0 &&
              quoteTerminal.PvpCurrencyQuotes.Count == 2 &&
              quoteTerminal.PvpCurrencyQuotes.All(quote => quote.RecipientLevelIndex == 8),
            "currency quotes appear only in private terminal evidence with signed recipient ranks");
        byte[] QuotePayload(MatchSnapshot snapshot) =>
            Google.Protobuf.MessageExtensions.ToByteArray(snapshot);
        MatchSnapshot ValidatedQuotePayload(MatchSnapshot snapshot)
        {
            byte[] payload = QuotePayload(snapshot);
            return TerminalOutbox.ValidatePayload(payload, snapshot.MatchId,
                War.Shared.TerminalResultDigest.Compute(payload));
        }
        Check(ValidatedQuotePayload(quoteTerminal).PvpCurrencyQuotes.Count == 2,
            "terminal validator accepts both host-collected currency receipts");
        PvpBonusCurrencyManifestValidator.Validate(quoteTerminal, clockManifest);
        checks++;
        var changedRankTerminal = quoteTerminal.Clone();
        changedRankTerminal.PvpCurrencyQuotes.Single(quote => quote.Currency == "gold")
            .RecipientLevelIndex = 9;
        Check(ValidatedQuotePayload(changedRankTerminal).PvpCurrencyQuotes.Count == 2,
            "Gold arithmetic alone cannot detect a plausible forged recipient rank");
        try
        {
            PvpBonusCurrencyManifestValidator.Validate(changedRankTerminal, clockManifest);
            throw new Exception("Currency quote changed the frozen recipient rank.");
        }
        catch (InvalidDataException) { checks++; }
        string quoteSpool = Path.Combine(Path.GetTempPath(),
            "war-pvp-quotes-" + Guid.NewGuid().ToString("N"));
        try
        {
            Check(new TerminalOutbox(quoteSpool).Publish(quoteTerminal),
                "terminal outbox persists the first currency evidence record");
            Check(new TerminalOutbox(quoteSpool).PendingPage().Single().Snapshot
                  .PvpCurrencyQuotes.Count == 2,
                "reopened terminal outbox retains both currency quotes");
        }
        finally { Directory.Delete(quoteSpool, recursive: true); }
        void RejectChangedQuote(Action<MatchSnapshot> change)
        {
            var forged = quoteTerminal.Clone();
            change(forged);
            try { ValidatedQuotePayload(forged);
                throw new Exception("Forged terminal currency quote was accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes[0].RecipientPlayerId = Id(999));
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes[0].BaseDraw = 10);
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes[0].Amount++);
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes[0].Currency = "premium");
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes[0].RecipientLevelIndex = 43);
        RejectChangedQuote(snapshot => snapshot.PvpCurrencyQuotes.Add(
            snapshot.PvpCurrencyQuotes[0].Clone()));
        MatchEngine RunningBonusMatch(int matchNumber, Func<float> randomDraw)
        {
            var match = new MatchEngine(clockManifest with {MatchId = Id(matchNumber)},
                map, content, combatRandom: randomDraw);
            foreach (var participant in manifest.Players)
                match.Admit(participant.PlayerId);
            foreach (var participant in manifest.Players)
                match.Command(participant.PlayerId, new MatchCommand
                {
                    CommandId = 1,
                    Ready = new ReadyCommand {ManifestHash = match.ManifestHash}
                });
            match.Advance(60);
            return match;
        }

        var grenadeBoxMatch = RunningBonusMatch(8697, () => 1f);
        grenadeBoxMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86971), localId, 6);
        for (int index = 0; index < 3; index++)
            grenadeBoxMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86972 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            grenadeBoxMatch.Advance(nextTick);
        var grenadeBox = grenadeBoxMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var grenadeCatalog = GrenadeCatalog.Load(Path.Combine(directory,
            "grenade-content-manifest.json"));
        var grenadeStage = grenadeCatalog.Stage("Google2u.Grenade_FRAG", 0);
        var grenadeWeapon = grenadeCatalog.CreateManifest(
            "Google2u.Grenade_FRAG", 0);
        var grenadeManifest = clockManifest with
        {
            Mode = MatchManifest.GrenadeCombatMode,
            Players = clockManifest.Players.Select(player => player with
            {
                Weapon = grenadeWeapon,
                WeaponUpgrade = 0
            }).ToArray()
        };
        var grenadeTrace = new GrenadeMatchSimulation(grenadeManifest, map,
            grenadeCatalog);
        grenadeTrace.ConfigureBonusBoxTargets(
            grenadeBoxMatch.BonusPlanner.ActiveBoxesSnapshot);
        var grenadeBoxContact = grenadeTrace.Trace(localId,
            grenadeBox.Position + Vector3.UnitY, -Vector3.UnitY, 2f,
            1u << PvpBonusShotHitbox.RuntimeLayer);
        Check(grenadeBoxContact?.BonusBoxId == grenadeBox.BoxId,
            "live grenade trajectory can collide with the source box layer");
        string grenadeAttacker = clockManifest.Players[1].PlayerId;
        grenadeBoxMatch.ApplyGrenadeBonusBoxes(grenadeAttacker, 86976,
            grenadeBox.Position + Vector3.UnitX * (grenadeStage.HurtRadius + 1f),
            grenadeStage);
        Check(grenadeBoxMatch.BonusPlanner.BoxSnapshot(grenadeBox.BoxId).Health == 1f,
            "grenade blast outside the source hurt radius cannot damage a box");
        grenadeBoxMatch.ApplyGrenadeBonusBoxes(grenadeAttacker, 86977,
            grenadeBox.Position, grenadeStage);
        Check(grenadeBoxMatch.BonusPlanner.BoxSnapshot(grenadeBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              grenadeBoxMatch.Snapshot().Players[1].KevlarHealth ==
                  clockManifest.Players[1].Combat!.MaxHealth * 0.1f,
            "host grenade blast destroys a box and grants its effect to the shooter");
        ulong grenadeRevision = grenadeBoxMatch.Snapshot().StateRevision;
        grenadeBoxMatch.ApplyGrenadeBonusBoxes(grenadeAttacker, 86977,
            grenadeBox.Position, grenadeStage);
        Check(grenadeBoxMatch.Snapshot().StateRevision == grenadeRevision,
            "replaying the grenade explosion cannot collect the same box twice");

        var bazookaBoxMatch = RunningBonusMatch(8698, () => 1f);
        bazookaBoxMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86981), localId, 6);
        for (int index = 0; index < 3; index++)
            bazookaBoxMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86982 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            bazookaBoxMatch.Advance(nextTick);
        var bazookaBox = bazookaBoxMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var bazookaCatalog = BazookaCatalog.Load(Path.Combine(directory,
            "bazooka-content-manifest.json"));
        var bazookaStage = bazookaCatalog.Stage("Google2u.Bazooka_RPG7", 0);
        var bazookaBinding = bazookaCatalog.Binding("Google2u.Bazooka_RPG7");
        bazookaBoxMatch.ApplyBazookaBonusBoxes(grenadeAttacker, 86985,
            bazookaBox.Position + Vector3.UnitX * (bazookaBinding.HurtRadius + 1f),
            bazookaStage, bazookaBinding, false);
        Check(bazookaBoxMatch.BonusPlanner.BoxSnapshot(bazookaBox.BoxId).Health == 1f,
            "bazooka blast outside the source hurt radius cannot damage a box");
        bazookaBoxMatch.ApplyBazookaBonusBoxes(grenadeAttacker, 86986,
            bazookaBox.Position, bazookaStage, bazookaBinding, false);
        Check(bazookaBoxMatch.BonusPlanner.BoxSnapshot(bazookaBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              bazookaBoxMatch.Snapshot().Players[1].KevlarHealth ==
                  clockManifest.Players[1].Combat!.MaxHealth * 0.1f,
            "host bazooka blast destroys a box and grants its effect to the shooter");
        ulong bazookaRevision = bazookaBoxMatch.Snapshot().StateRevision;
        bazookaBoxMatch.ApplyBazookaBonusBoxes(grenadeAttacker, 86986,
            bazookaBox.Position, bazookaStage, bazookaBinding, false);
        Check(bazookaBoxMatch.Snapshot().StateRevision == bazookaRevision,
            "replaying the bazooka explosion cannot collect the same box twice");

        var bazookaContent = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory,
                "bazooka-content-manifest.json"));
        var liveBazookaWeapon = bazookaContent.Bazookas!.CreateManifest(
            "Google2u.Bazooka_RPG7", 0);
        var liveBazookaManifest = clockManifest with
        {
            MatchId = Id(8695),
            Mode = MatchManifest.BazookaCombatMode,
            CatalogRevision = bazookaContent.BazookaRevision!,
            Players = clockManifest.Players.Select(player => player with
            {
                Weapon = liveBazookaWeapon,
                WeaponUpgrade = 0
            }).ToArray()
        };
        var liveBazookaMatch = new MatchEngine(liveBazookaManifest, map,
            bazookaContent, combatRandom: () => 1f);
        foreach (var participant in liveBazookaManifest.Players)
            liveBazookaMatch.Admit(participant.PlayerId);
        foreach (var participant in liveBazookaManifest.Players)
            liveBazookaMatch.Command(participant.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = liveBazookaMatch.ManifestHash }
            });
        liveBazookaMatch.Advance(60);
        liveBazookaMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86951), localId, 6);
        for (int index = 0; index < 3; index++)
            liveBazookaMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86952 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            liveBazookaMatch.Advance(nextTick);
        var liveBazookaBox = liveBazookaMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var liveBazookaHold = liveBazookaMatch.Command(localId, new MatchCommand
        {
            CommandId = 2,
            BazookaHold = new BazookaHoldCommand
            {
                Pressed = true,
                TargetX = liveBazookaBox.Position.X,
                TargetY = liveBazookaBox.Position.Y,
                TargetZ = liveBazookaBox.Position.Z
            }
        });
        for (ulong nextTick = 154; nextTick <= 500 && !liveBazookaMatch.Terminal;
             nextTick++)
        {
            liveBazookaMatch.Advance(nextTick);
            if (liveBazookaMatch.BonusPlanner.BoxSnapshot(liveBazookaBox.BoxId).Phase ==
                PvpBonusBoxPhase.Collected) break;
        }
        var liveBazookaImpacts = liveBazookaMatch.EventBatch(localId, 0).Events
            .Where(item => item.Kind == MatchEventKind.Impact &&
                item.Reason == "bazooka").ToArray();
        Check(liveBazookaHold.Code == "bazooka-targeting" &&
              liveBazookaImpacts.Length == 1 &&
              liveBazookaMatch.BonusPlanner.BoxSnapshot(liveBazookaBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              liveBazookaMatch.Snapshot().Players[0].KevlarHealth ==
                  liveBazookaManifest.Players[0].Combat!.MaxHealth * 0.1f,
            $"normal RPG flight collects a live box: command={liveBazookaHold.Code}, " +
            $"impacts={liveBazookaImpacts.Length}, box={liveBazookaBox.Position}, " +
            $"phase={liveBazookaMatch.BonusPlanner.BoxSnapshot(liveBazookaBox.BoxId).Phase}");

        var cardRocketMatch = RunningBonusMatch(8694, () => 1f);
        cardRocketMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86941), localId, 6);
        for (int index = 0; index < 3; index++)
            cardRocketMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86942 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            cardRocketMatch.Advance(nextTick);
        var cardRocketBox = cardRocketMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var cardRocketTrace = new RifleMatchSimulation(clockManifest, map, content);
        cardRocketTrace.ConfigureBonusBoxTargets(
            cardRocketMatch.BonusPlanner.ActiveBoxesSnapshot);
        var cardRocketContact = cardRocketTrace.TraceForArmyDamage(localId,
            cardRocketBox.Position + Vector3.UnitY, -Vector3.UnitY, 2f);
        Check(cardRocketContact?.BonusBoxId == cardRocketBox.BoxId,
            "card Rocket flight can hit the active layer-eight box collider");
        var cardRocketMissile = content.Army.CardBaseStats("BIGROCKET", 22,
            content.BarrelPolicy.MaxDisplayLevel).Rocket!;
        cardRocketMatch.ApplyCardRocketBonusBoxes(grenadeAttacker, 86945,
            cardRocketBox.Position + Vector3.UnitX * 2f, cardRocketMissile);
        Check(cardRocketMatch.BonusPlanner.BoxSnapshot(cardRocketBox.BoxId).Health == 1f,
            "card Rocket blast beyond the source radius leaves the box intact");
        var fallingCardRocket = new CardRocketMissileFlight(86946, 1,
            cardRocketMissile,
            cardRocketBox.Position + Vector3.UnitY * 2f,
            cardRocketBox.Position - Vector3.UnitY * 2f,
            153, false,
            (from, direction, range) => cardRocketTrace.TraceForArmyDamage(
                localId, from, direction, range));
        CardRocketMissileImpact? cardRocketImpact = null;
        for (ulong nextTick = 154; nextTick <= 300 &&
             cardRocketImpact == null; nextTick++)
            cardRocketImpact = fallingCardRocket.Advance(nextTick);
        Check(cardRocketImpact is { IsFake: false } &&
              cardRocketImpact.Collision?.BonusBoxId == cardRocketBox.BoxId,
            "real card Rocket flight impacts the live box collider");
        cardRocketMatch.ApplyCardRocketBonusBoxes(grenadeAttacker,
            cardRocketImpact!.ProjectileId, cardRocketImpact.Position,
            cardRocketMissile);
        Check(cardRocketMatch.BonusPlanner.BoxSnapshot(cardRocketBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              cardRocketMatch.Snapshot().Players[1].KevlarHealth ==
                  clockManifest.Players[1].Combat!.MaxHealth * 0.1f,
            "host card Rocket blast destroys a box for the opposing owner");
        ulong cardRocketRevision = cardRocketMatch.Snapshot().StateRevision;
        cardRocketMatch.ApplyCardRocketBonusBoxes(grenadeAttacker, 86946,
            cardRocketImpact.Position, cardRocketMissile);
        Check(cardRocketMatch.Snapshot().StateRevision == cardRocketRevision,
            "replaying card Rocket blast cannot collect a box again");

        var cardGrenadierMatch = RunningBonusMatch(8693, () => 1f);
        cardGrenadierMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86931), localId, 6);
        for (int index = 0; index < 3; index++)
            cardGrenadierMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86932 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            cardGrenadierMatch.Advance(nextTick);
        var cardGrenadierBox = cardGrenadierMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var cardGrenadierStats = content.Army.CardBaseStats("GREATGRENADIER", 22,
            content.BarrelPolicy.MaxDisplayLevel);
        var cardGrenadierTrace = new RifleMatchSimulation(clockManifest, map, content);
        cardGrenadierTrace.ConfigureBonusBoxTargets(
            cardGrenadierMatch.BonusPlanner.ActiveBoxesSnapshot);
        var cardGrenadierContact = cardGrenadierTrace.TraceForArmyDamage(localId,
            cardGrenadierBox.Position + Vector3.UnitY, -Vector3.UnitY, 2f);
        Check(cardGrenadierContact?.BonusBoxId == cardGrenadierBox.BoxId,
            "card Grenadier flight can contact the active box collider");
        cardGrenadierMatch.ApplyCardGrenadierBonusBoxes(grenadeAttacker, 86935,
            cardGrenadierBox.Position + Vector3.UnitX *
                (cardGrenadierStats.Grenadier!.OuterRadius + 1f),
            cardGrenadierStats.Grenade!, cardGrenadierStats.Grenadier);
        Check(cardGrenadierMatch.BonusPlanner.BoxSnapshot(cardGrenadierBox.BoxId)
                  .Health == 1f,
            "card Grenadier blast beyond its source radius leaves the box intact");
        bool touchedGrenadierBox = false;
        var fallingCardGrenade = new CardGrenadierFlight(86936, 1,
            cardGrenadierStats.Grenadier,
            cardGrenadierBox.Position + Vector3.UnitY,
            -Vector3.UnitY, 153,
            (from, direction, range) =>
            {
                var hit = cardGrenadierTrace.TraceForArmyDamage(localId,
                    from, direction, range);
                touchedGrenadierBox |= hit?.BonusBoxId == cardGrenadierBox.BoxId;
                return hit;
            });
        CardGrenadierExplosion? cardGrenadierExplosion = null;
        for (ulong nextTick = 154; nextTick <= 400 &&
             cardGrenadierExplosion == null; nextTick++)
            cardGrenadierExplosion = fallingCardGrenade.Advance(nextTick);
        Check(touchedGrenadierBox && fallingCardGrenade.FirstContactTick.HasValue &&
              cardGrenadierExplosion != null,
            "card Grenadier grenade touches the box and completes its source fuse");
        cardGrenadierMatch.ApplyCardGrenadierBonusBoxes(grenadeAttacker,
            cardGrenadierExplosion!.ProjectileId,
            cardGrenadierExplosion.Position, cardGrenadierStats.Grenade!,
            cardGrenadierStats.Grenadier);
        Check(cardGrenadierMatch.BonusPlanner.BoxSnapshot(cardGrenadierBox.BoxId)
                  .Phase == PvpBonusBoxPhase.Collected &&
              cardGrenadierMatch.Snapshot().Players[1].KevlarHealth ==
                  clockManifest.Players[1].Combat!.MaxHealth * 0.1f,
            "host card Grenadier blast destroys a box for the opposing owner");
        ulong cardGrenadierRevision = cardGrenadierMatch.Snapshot().StateRevision;
        cardGrenadierMatch.ApplyCardGrenadierBonusBoxes(grenadeAttacker, 86936,
            cardGrenadierExplosion.Position, cardGrenadierStats.Grenade!,
            cardGrenadierStats.Grenadier);
        Check(cardGrenadierMatch.Snapshot().StateRevision == cardGrenadierRevision,
            "replaying card Grenadier blast cannot collect a box again");

        var armyBulletMatch = RunningBonusMatch(8692, () => 1f);
        armyBulletMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86921), localId, 6);
        for (int index = 0; index < 3; index++)
            armyBulletMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86922 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            armyBulletMatch.Advance(nextTick);
        var armyBulletBox = armyBulletMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var armyBulletTrace = new RifleMatchSimulation(clockManifest, map, content);
        armyBulletTrace.ConfigureBonusBoxTargets(
            armyBulletMatch.BonusPlanner.ActiveBoxesSnapshot);
        var armyBullet = new ArmyProjectileFlight(86926, 1,
            armyBulletBox.Position + Vector3.UnitY,
            armyBulletBox.Position - Vector3.UnitY, 10f, 153,
            (from, direction, range) => armyBulletTrace.TraceForArmyDamage(
                grenadeAttacker, from, direction, range));
        ArmyProjectileImpact? armyBoxImpact = null;
        for (ulong nextTick = 154; nextTick <= 165 &&
             armyBoxImpact == null; nextTick++)
            armyBoxImpact = armyBullet.Advance(nextTick);
        Check(armyBoxImpact?.Collision.BonusBoxId == armyBulletBox.BoxId,
            "real army bullet flight hits the active bonus box collider");
        armyBulletMatch.ApplyArmyProjectileBonusImpact(armyBoxImpact!,
            grenadeAttacker, 2f);
        Check(armyBulletMatch.BonusPlanner.BoxSnapshot(armyBulletBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              armyBulletMatch.Snapshot().Players[1].KevlarHealth ==
                  clockManifest.Players[1].Combat!.MaxHealth * 0.1f,
            "army projectile box hit credits the soldier's opposing player owner");
        ulong armyBulletRevision = armyBulletMatch.Snapshot().StateRevision;
        armyBulletMatch.ApplyArmyProjectileBonusImpact(armyBoxImpact!,
            grenadeAttacker, 2f);
        Check(armyBulletMatch.Snapshot().StateRevision == armyBulletRevision,
            "replayed army projectile impact cannot collect the box again");

        var grenadeContent = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory,
                "grenade-content-manifest.json"));
        var launcherWeapon = grenadeContent.Grenades!.CreateManifest(
            "Google2u.GrenadeLauncher_M320", 0);
        var launcherManifest = clockManifest with
        {
            MatchId = Id(8696),
            Mode = MatchManifest.GrenadeCombatMode,
            CatalogRevision = grenadeContent.GrenadeRevision!,
            Players = clockManifest.Players.Select(player => player with
            {
                Weapon = launcherWeapon,
                WeaponUpgrade = 0
            }).ToArray()
        };
        var launcherBoxMatch = new MatchEngine(launcherManifest, map,
            grenadeContent, combatRandom: () => 1f);
        foreach (var participant in launcherManifest.Players)
            launcherBoxMatch.Admit(participant.PlayerId);
        foreach (var participant in launcherManifest.Players)
            launcherBoxMatch.Command(participant.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = launcherBoxMatch.ManifestHash }
            });
        launcherBoxMatch.Advance(60);
        launcherBoxMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86961), localId, 6);
        for (int index = 0; index < 3; index++)
            launcherBoxMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86962 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            launcherBoxMatch.Advance(nextTick);
        var launcherBox = launcherBoxMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var launcherThrow = launcherBoxMatch.Command(localId, new MatchCommand
        {
            CommandId = 2,
            GrenadeThrow = new GrenadeThrowCommand
            {
                TargetX = launcherBox.Position.X,
                TargetY = launcherBox.Position.Y,
                TargetZ = launcherBox.Position.Z
            }
        });
        for (ulong nextTick = 154; nextTick <= 500 && !launcherBoxMatch.Terminal;
             nextTick++)
        {
            launcherBoxMatch.Advance(nextTick);
            if (launcherBoxMatch.BonusPlanner.BoxSnapshot(launcherBox.BoxId).Phase ==
                PvpBonusBoxPhase.Collected) break;
        }
        var launcherImpacts = launcherBoxMatch.EventBatch(localId, 0).Events
            .Where(item => item.Kind == MatchEventKind.Impact).ToArray();
        Check(launcherThrow.Code == "grenade-throwing" &&
              launcherImpacts.Any(item => item.Reason == "grenade") &&
              launcherBoxMatch.BonusPlanner.BoxSnapshot(launcherBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              launcherBoxMatch.Snapshot().PvpBonusBoxes.Count == 0 &&
              launcherBoxMatch.Snapshot().Players[0].KevlarHealth ==
                  launcherManifest.Players[0].Combat!.MaxHealth * 0.1f,
            $"normal M320 throw flies, explodes and collects a live box: " +
            $"command={launcherThrow.Code}, impacts={launcherImpacts.Length}, " +
            $"box={launcherBox.Position}, phase=" +
            launcherBoxMatch.BonusPlanner.BoxSnapshot(launcherBox.BoxId).Phase);

        var firedBoxMatch = RunningBonusMatch(8699, () => 1f);
        firedBoxMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86990), localId, 6);
        for (int index = 0; index < 3; index++)
            firedBoxMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86991 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            firedBoxMatch.Advance(nextTick);
        var firedBox = firedBoxMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        string shotResult = firedBoxMatch.Command(localId, new MatchCommand
        {
            CommandId = 2,
            Fire = new FireCommand
            {
                TargetX = firedBox.Position.X,
                TargetY = firedBox.Position.Y,
                TargetZ = firedBox.Position.Z
            }
        }).Code;
        for (ulong nextTick = 154; nextTick <= 180 && !firedBoxMatch.Terminal;
             nextTick++)
            firedBoxMatch.Advance(nextTick);
        Check(shotResult == "shot-scheduled" &&
              firedBoxMatch.BonusPlanner.BoxSnapshot(firedBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              firedBoxMatch.Snapshot().PvpBonusBoxes.Count == 0 &&
              firedBoxMatch.Snapshot().Players[0].KevlarHealth ==
                  manifest.Players[0].Combat!.MaxHealth * 0.1f,
            "normal Fire command shoots and collects a host-issued bonus box: " +
            $"shot={shotResult}, phase={firedBoxMatch.BonusPlanner.BoxSnapshot(firedBox.BoxId).Phase}, " +
            $"terminal={firedBoxMatch.Terminal}, target={firedBox.Position}");

        var shotgunContent = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            Path.Combine(directory, "shotgun-content-manifest.json"));
        const string shotgunSource = "Google2u.Shotgun_SPAS";
        var shotgunWeapon = shotgunContent.Shotguns!.CreateManifest(shotgunSource, 35);
        var shotgunManifest = clockManifest with
        {
            MatchId = Id(8698),
            Mode = MatchManifest.ShotgunCombatMode,
            CatalogRevision = shotgunContent.ShotgunRevision!,
            Players = clockManifest.Players.Select(player => player with
            {
                Weapon = shotgunWeapon,
                WeaponUpgrade = 35
            }).ToArray()
        };
        var shotgunBoxMatch = new MatchEngine(shotgunManifest, map,
            shotgunContent, combatRandom: () => 1f);
        foreach (var participant in shotgunManifest.Players)
            shotgunBoxMatch.Admit(participant.PlayerId);
        foreach (var participant in shotgunManifest.Players)
            shotgunBoxMatch.Command(participant.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = shotgunBoxMatch.ManifestHash }
            });
        shotgunBoxMatch.Advance(60);
        shotgunBoxMatch.BonusPlanner.EnqueueConfirmedBonus(Id(86981), localId, 6);
        for (int index = 0; index < 3; index++)
            shotgunBoxMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(86982 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            shotgunBoxMatch.Advance(nextTick);
        var shotgunBox = shotgunBoxMatch.BonusPlanner.ActiveBoxesSnapshot().Single();
        var liveShotgunBinding = shotgunContent.Shotguns.Binding(shotgunSource);
        Vector3 shotgunMuzzle = shotgunBoxMatch.CombatPose(localId)
            .Muzzle(shotgunSource).Position + liveShotgunBinding.ShotOffset;
        Vector3 boxDirection = Vector3.Normalize(shotgunBox.Position - shotgunMuzzle);
        Vector3 sideways = Vector3.Normalize(Vector3.Cross(boxDirection,
            Vector3.UnitY));
        Vector3 shotgunAim = shotgunBox.Position + sideways * 0.5f;
        var shotgunWorld = new ShotCollisionWorld(map,
            [new(localId, shotgunBoxMatch.CombatPose(localId).Collision, 23, 1),
             new(shotgunManifest.Players[1].PlayerId,
                 shotgunBoxMatch.CombatPose(shotgunManifest.Players[1].PlayerId)
                     .Collision, 22, 2)],
            bonusBoxes: shotgunBoxMatch.BonusPlanner.ActiveBoxesSnapshot);
        var liveShotgunCandidates = shotgunWorld.OverlapEnemy(localId,
            shotgunMuzzle, liveShotgunBinding.Geometry.Radius,
            shotgunContent.Bindings.BulletMask(1));
        var liveShotgunPlan = ShotgunShotPlanner.Plan(liveShotgunBinding.Rule(
                shotgunContent.Shotguns.Stage(shotgunSource, 35)),
            shotgunMuzzle, shotgunAim, liveShotgunCandidates);
        Check(liveShotgunPlan.RealPellets.Any(pellet => !pellet.Main &&
                  pellet.Target == shotgunBox.Position),
            $"live shotgun muzzle selects a bonus-box extra pellet: " +
            $"distance={Vector3.Distance(shotgunMuzzle, shotgunBox.Position)}, " +
            $"candidates={liveShotgunCandidates.Count}, " +
            $"pellets={liveShotgunPlan.RealPellets.Count}");
        Vector3 mainDirection = Vector3.Normalize(shotgunAim - shotgunMuzzle);
        var mainHit = shotgunWorld.Raycast(localId, shotgunMuzzle,
            mainDirection, Vector3.Distance(shotgunMuzzle, shotgunAim),
            shotgunContent.Bindings.BulletMask(1));
        Check(mainHit?.BonusBoxId != shotgunBox.BoxId,
            "shotgun main pellet misses the box so only an extra pellet can collect it");
        var shotgunFire = shotgunBoxMatch.Command(localId, new MatchCommand
        {
            CommandId = 2,
            Fire = new FireCommand
            {
                TargetX = shotgunAim.X,
                TargetY = shotgunAim.Y,
                TargetZ = shotgunAim.Z
            }
        });
        for (ulong nextTick = 154; nextTick <= 180 && !shotgunBoxMatch.Terminal;
             nextTick++)
            shotgunBoxMatch.Advance(nextTick);
        Check(shotgunFire.Code == "shot-scheduled" &&
              shotgunBoxMatch.BonusPlanner.BoxSnapshot(shotgunBox.BoxId).Phase ==
                  PvpBonusBoxPhase.Collected &&
              shotgunBoxMatch.Snapshot().Players[0].KevlarHealth ==
                  shotgunManifest.Players[0].Combat!.MaxHealth * 0.1f,
            $"live shotgun extra pellet collects the host bonus box: " +
            $"fire={shotgunFire.Code}, " +
            $"phase={shotgunBoxMatch.BonusPlanner.BoxSnapshot(shotgunBox.BoxId).Phase}");

        var simultaneous = RunningBonusMatch(8700, () => 0.5f);
        foreach (var participant in manifest.Players)
            for (int index = 0; index < 3; index++)
                simultaneous.BonusProgress.RecordConfirmedSkillShot(
                    participant.PlayerId, Id(8800 + participant.Fraction * 10 + index),
                    0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153; nextTick++)
            simultaneous.Advance(nextTick);
        Check(simultaneous.BonusPlanner.PlanCount == 2 &&
              simultaneous.BonusPlanner.ActiveBoxCount == 2 &&
              simultaneous.MaturedBonusRequests.Count == 0 &&
              simultaneous.Snapshot().PvpBonusBoxes.Select(box => box.OwnerPlayerId)
                  .Distinct(StringComparer.Ordinal).Count() == 2,
            "same-frame waits automatically issue one crate for each owner");
        simultaneous.Advance(153);
        Check(simultaneous.BonusPlanner.PlanCount == 2,
            "replaying the maturity tick cannot issue another crate");

        var invalidDrawMatch = RunningBonusMatch(8701, () => float.NaN);
        for (int index = 0; index < 3; index++)
            invalidDrawMatch.BonusProgress.RecordConfirmedSkillShot(localId,
                Id(8900 + index), 0x1210, 1f);
        for (ulong nextTick = 61; nextTick <= 153 && !invalidDrawMatch.Terminal;
             nextTick++)
            invalidDrawMatch.Advance(nextTick);
        Check(invalidDrawMatch.Terminal &&
              invalidDrawMatch.Snapshot().TerminalReason ==
                  "invalid-pvp-bonus-authority" &&
              invalidDrawMatch.BonusPlanner.ActiveBoxCount == 0 &&
              invalidDrawMatch.MaturedBonusRequests.Count == 1,
            "invalid host random input aborts without publishing a crate");
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

        enginePlanner.EnqueueConfirmedBonus(Id(600), localId, 3);
        var grenadeFrame = Mature(9, 14);
        var grenadePlan = enginePlanner.PlanMatured(grenadeFrame, 0, context, draw);
        try
        {
            engine.PlanCollectedPvpGrenades(grenadePlan.Request.ReceiptId);
            throw new Exception("Uncollected grenade crate produced a burst.");
        }
        catch (InvalidOperationException) { checks++; }
        try
        {
            enginePlanner.ConfirmDestroyed(grenadePlan.Request.ReceiptId,
                Id(601), manifest.Players[1].PlayerId,
                new Vector3(float.NaN, 0f, 0f));
            throw new Exception("Invalid host collection position was accepted.");
        }
        catch (InvalidDataException) { checks++; }
        Check(enginePlanner.BoxSnapshot(grenadePlan.Request.ReceiptId).Collection == null,
            "invalid collection geometry leaves the grenade box uncollected");
        var collectionPosition = grenadePlan.Position + new Vector3(0.75f, -0.25f, 0.5f);
        var grenadeCollection = enginePlanner.ConfirmDestroyed(
            grenadePlan.Request.ReceiptId, Id(601), manifest.Players[1].PlayerId,
            collectionPosition);
        Check(grenadeCollection.RecipientPlayerId == manifest.Players[1].PlayerId &&
              grenadeCollection.CollectionPosition == collectionPosition &&
              enginePlanner.ConfirmDestroyed(grenadePlan.Request.ReceiptId,
                  Id(601), manifest.Players[1].PlayerId, collectionPosition) ==
                  grenadeCollection &&
              grenadePlan.PrefabIndex == 3,
            "host collection binds the grenade burst to its actual position and stolen recipient");
        try
        {
            enginePlanner.ConfirmDestroyed(grenadePlan.Request.ReceiptId,
                Id(601), manifest.Players[1].PlayerId, grenadePlan.Position);
            throw new Exception("Collection replay changed the box position.");
        }
        catch (InvalidDataException) { checks++; }
        enginePlanner.EnqueueConfirmedBonus(Id(602), localId, 3);
        var unlocatedFrame = Mature(11, 17);
        var unlocatedPlan = enginePlanner.PlanMatured(unlocatedFrame, 0, context, draw);
        enginePlanner.ConfirmDestroyed(unlocatedPlan.Request.ReceiptId, Id(603), null);
        try
        {
            engine.PlanCollectedPvpGrenades(unlocatedPlan.Request.ReceiptId);
            throw new Exception("Grenade box without a collection position produced a burst.");
        }
        catch (InvalidOperationException) { checks++; }
        var hostShootables = engine.PvpGrenadeShootables();
        Check(hostShootables.Any(target => target.Id == "player:" + localId) &&
              hostShootables.Any(target => target.Id ==
                  "player:" + manifest.Players[1].PlayerId),
            "grenade targets include both players from the host shootable registry");
        int drawsBeforeGrenade = hostCombatDraws;
        var burst = engine.PlanCollectedPvpGrenades(grenadePlan.Request.ReceiptId);
        var expectedFallback = content.PvpBonuses.GrenadeFallbackDamageForLevel(8);
        int fallbackCount = burst.Launches.Count(launch => launch.TargetId == null);
        Check(fallbackCount > 0,
            "the collected-box fixture exercises host-owned fallback random draws");
        Check(burst.BoxId == grenadePlan.Request.ReceiptId &&
              burst.RecipientPlayerId == manifest.Players[1].PlayerId &&
              burst.Launches.Count == 3 &&
              burst.Launches.Where(launch => launch.TargetId != null)
                  .All(launch => launch.DamageOverride == null &&
                      hostShootables.Any(target => target.Id == launch.TargetId)) &&
              burst.Launches.Where(launch => launch.TargetId == null)
                  .All(launch => launch.DamageOverride == expectedFallback &&
                      launch.Position == collectionPosition +
                          new Vector3(1.5f, 0f, 1.5f)) &&
              hostCombatDraws - drawsBeforeGrenade == fallbackCount * 2 &&
              engine.ApplyCollectedPvpBonus(grenadePlan.Request.ReceiptId) ==
                  "bonus-effect-pending",
            "collected grenade crate plans only live host targets and rank-bound fallback shots");
        Check(ReferenceEquals(burst, engine.PlanCollectedPvpGrenades(
                  grenadePlan.Request.ReceiptId)) &&
              hostCombatDraws - drawsBeforeGrenade == fallbackCount * 2,
            "replaying the collected box returns its first burst without new random draws");
        var stationaryFallback = new GrenadeFlight(1, localId, 45f, 0f,
            collectionPosition, collectionPosition, 1,
            (from, direction, distance) => null, allowStationary: true);
        Check(stationaryFallback.Velocity == Vector3.Zero &&
              stationaryFallback.Advance(2) == null &&
              stationaryFallback.Position.Y < collectionPosition.Y,
            "a zero-offset bonus draw follows Unity's stationary launch and gravity");
        const uint sourceContactMask = (1u << 8) | (1u << 13) |
            (1u << 22) | (1u << 23) | (1u << 24) |
            (1u << 26) | (1u << 27) | (1u << 30);
        var staticContact = new ShotCollision(1f, collectionPosition, "static",
            null, 0f, Static: true, ColliderLayer: 13);
        var destroyableContact = new ShotCollision(1f, collectionPosition,
            "destroyable", null, 0f, ColliderLayer: 22,
            SourceDestroyable: true);
        var unrelatedContact = new ShotCollision(1f, collectionPosition,
            "unrelated", null, 0f, ColliderLayer: 14);
        Check(PvpBonusGrenadeCollision.ExplosiveContactMask == sourceContactMask &&
              PvpBonusGrenadeCollision.ExplosiveContact(staticContact) == staticContact &&
              PvpBonusGrenadeCollision.ExplosiveContact(destroyableContact) ==
                  destroyableContact &&
              PvpBonusGrenadeCollision.ExplosiveContact(unrelatedContact) == null &&
              PvpBonusGrenadeCollision.ExplosiveContact(
                  unrelatedContact with {ColliderLayer = 22}) != null,
            "bonus grenade fuse follows source layer checks, including player layers");
        var impactAtChangedSetup = new GrenadeFlightImpact(2, localId,
            collectionPosition, staticContact, 5);
        var sourceFallbackSetup = content.PvpBonuses.GrenadeFallbackDamageForLevel(8);
        var changedSetupQuote = PvpBonusGrenadeExplosionPolicy.AfterCollision(
            impactAtChangedSetup,
            new PvpBonusGrenadeSharedDamage(sourceFallbackSetup.Explosion,
                sourceFallbackSetup.Direct),
            content.PvpBonuses, 6);
        Check(changedSetupQuote.ExplosionDamage == sourceFallbackSetup.Explosion &&
              changedSetupQuote.DirectDamage == sourceFallbackSetup.Direct &&
              changedSetupQuote.ProjectileId == impactAtChangedSetup.ProjectileId &&
              changedSetupQuote.CollisionTick == 5 &&
              changedSetupQuote.ExplosionTick == 6 &&
              changedSetupQuote.DeadRadius == 1.3f &&
              changedSetupQuote.HurtRadius == 2.2f,
            "bonus explosion reads the shared setup after collision, not launch");
        var friendlyPose = engine.CombatPose(localId).Collision;
        var friendlyOrigin = friendlyPose.Parts.First(part =>
            part.Enabled && part.Active).Center;
        var friendlyBlast = GrenadeExplosion.ResolvePlayer(friendlyOrigin,
            friendlyPose, friendlyPose.RootPosition,
            manifest.Players[0].Combat!, 1000f,
            changedSetupQuote.ToExplosionStage(), false, false,
            sameFraction: true, self: true, randomRoll: 1f,
            friendKill: false);
        Check(friendlyBlast is {Result.Applied: false},
            "manager grenade's disabled friendKill prevents owner blast damage");
        try
        {
            PvpBonusGrenadeExplosionPolicy.AfterCollision(impactAtChangedSetup,
                new PvpBonusGrenadeSharedDamage(700f, 70f),
                content.PvpBonuses, 6);
            throw new Exception("Unreviewed shared grenade damage became authority.");
        }
        catch (InvalidDataException) { checks++; }
        try
        {
            engine.Advance(62);
            throw new Exception("An active grenade burst skipped host frames.");
        }
        catch (InvalidOperationException) { checks++; }
        var healthBeforeBurst = engine.Snapshot().Players.Select(player => player.Health).ToArray();
        var dueShots = new List<PvpBonusGrenadeDueShot>();
        int mostActiveGrenades = 0;
        int confirmedGrenadeImpacts = 0;
        var explosionQuotes = new List<PvpBonusGrenadeExplosionQuote>();
        bool checkedFlightFrameGuard = false;
        for (ulong nextTick = 61; nextTick <= 150; nextTick++)
        {
            engine.Advance(nextTick);
            dueShots.AddRange(engine.ReadyPvpGrenadeShots);
            mostActiveGrenades = Math.Max(mostActiveGrenades,
                engine.PendingPvpGrenadeFlights);
            confirmedGrenadeImpacts += engine.PvpGrenadeImpacts.Count;
            explosionQuotes.AddRange(engine.PvpGrenadeExplosions);
            if (!checkedFlightFrameGuard && engine.PendingPvpGrenadeFlights > 0)
            {
                try
                {
                    engine.Advance(nextTick + 2);
                    throw new Exception("An active bonus projectile skipped host frames.");
                }
                catch (InvalidOperationException) { checks++; }
                checkedFlightFrameGuard = true;
            }
        }
        Check(dueShots.Count == 3 &&
              dueShots.Select(shot => shot.Launch.ShotIndex).SequenceEqual([0, 1, 2]) &&
              dueShots[0].FrameId == 31 &&
              dueShots[1].FrameId - dueShots[0].FrameId == 6 &&
              dueShots[2].FrameId - dueShots[1].FrameId == 6 &&
              mostActiveGrenades > 0 &&
              confirmedGrenadeImpacts > 0 &&
              explosionQuotes.Count == confirmedGrenadeImpacts &&
              explosionQuotes.All(quote =>
                  quote.ExplosionTick == quote.CollisionTick + 1 &&
                  quote.DeadRadius == content.PvpBonuses.GrenadeDeadRadius &&
                  quote.HurtRadius == content.PvpBonuses.GrenadeHurtRadius &&
                  quote.PlayerBehindShieldRatio ==
                      content.PvpBonuses.GrenadePlayerBehindShieldRatio &&
                  quote.ExplosionDamage > 0f) &&
              checkedFlightFrameGuard &&
              engine.PendingProjectileCount >= engine.PendingPvpGrenadeFlights &&
              engine.Snapshot().Players.Select(player => player.Health)
                  .SequenceEqual(healthBeforeBurst),
            $"host scaled frames launch and track three bonus grenades without unreviewed impact damage: " +
            $"due={string.Join(',', dueShots.Select(shot =>
                $"{shot.FrameId}/{shot.Launch.ShotIndex}"))}, " +
            $"active={mostActiveGrenades}, impacts={confirmedGrenadeImpacts}, " +
            $"health={string.Join(',', engine.Snapshot().Players.Select(player => player.Health))}");

        var damageEngine = new MatchEngine(manifest, map, content,
            combatRandom: () => 1f);
        foreach (var player in manifest.Players)
            damageEngine.Admit(player.PlayerId);
        foreach (var player in manifest.Players)
            damageEngine.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                Ready = new ReadyCommand {ManifestHash = damageEngine.ManifestHash}});
        damageEngine.Advance(60);
        var damagePlanner = damageEngine.BonusPlanner;
        damagePlanner.EnqueueConfirmedBonus(Id(650), localId, 3);
        var damageBox = damagePlanner.PlanMatured(grenadeFrame, 0, context, draw);
        string enemyId = manifest.Players[1].PlayerId;
        var enemyPose = damageEngine.CombatPose(enemyId).Collision;
        var blastOrigin = enemyPose.Parts.First(part => part.Enabled && part.Active).Center;
        damagePlanner.ConfirmDestroyed(damageBox.Request.ReceiptId,
            Id(651), null, blastOrigin);
        var damageBurst = damageEngine.PlanCollectedPvpGrenades(
            damageBox.Request.ReceiptId);
        Check(damageBurst.Launches.Any(launch =>
                launch.TargetId == "player:" + enemyId),
            "owner-collected grenade box selects the nearby opposing player");
        float enemyHealthBefore = damageEngine.Snapshot().Players[1].Health;
        float ownerHealthBefore = damageEngine.Snapshot().Players[0].Health;
        int scoreBefore = damageEngine.BonusProgress.ScoreSnapshot(localId).Score;
        uint playerHitsBefore = damageEngine.Snapshot().Players[0].ConfirmedPlayerHits;
        for (ulong nextTick = 61; nextTick <= 180 && !damageEngine.Terminal;
             nextTick++)
        {
            damageEngine.Advance(nextTick);
            if (damageEngine.Snapshot().Players[1].Health < enemyHealthBefore)
                break;
        }
        Check(damageEngine.Snapshot().Players[1].Health < enemyHealthBefore &&
              damageEngine.Snapshot().Players[0].Health == ownerHealthBefore,
            "host collision applies bonus grenade blast to an enemy, not its owner");
        Check(damageEngine.BonusProgress.ScoreSnapshot(localId).Score == scoreBefore + 6 &&
              damageEngine.Snapshot().Players[0].ConfirmedPlayerHits ==
                  playerHitsBefore + 1,
            "confirmed bonus blast credits exactly one enemy-player hit skillshot");

        MatchEngine BonusCardMatch(string cardId)
        {
            var cardManifest = manifest with {
                Players = manifest.Players.Select(player =>
                    player with {PlayerLevel = 22}).ToArray()
            };
            var match = new MatchEngine(cardManifest, map, content,
                combatRandom: () => 1f);
            match.ConfigureBattleAllocations([
                new(localId, [cardId], [], [0], [-1], [-1]),
                new(enemyId, [cardId], [], [0], [-1], [-1])]);
            foreach (var player in cardManifest.Players)
            {
                match.Admit(player.PlayerId);
                Check(match.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                    SelectCards = new SelectCardsCommand {CardIds = {cardId}}}).Code ==
                    "cards-selected", "bonus target card selection uses trusted allocation");
                match.Command(player.PlayerId, new MatchCommand {CommandId = 2,
                    Ready = new ReadyCommand {ManifestHash = match.ManifestHash}});
            }
            match.Advance(60);
            return match;
        }

        var boostEngine = BonusCardMatch("STREAKBOOST");
        var boostRequest = Id(656);
        var boostCommand = new MatchCommand {CommandId = 3,
            UseScoreMultiplier = new UseScoreMultiplierCommand
            {
                RequestId = boostRequest,
                SourceCardId = PvpScoreMultiplierState.StreakBoost
            }};
        Check(boostEngine.Command(localId, boostCommand).Code == "score-card-active" &&
              boostEngine.BonusProgress.ConfirmedMultiplierFor(localId) == 1.25f &&
              boostEngine.BonusProgress.ConfirmedMultiplierFor(enemyId) == 1f,
            "selected Streak Boost spends host inventory and buffs its owner");
        Check(boostEngine.Command(localId, new MatchCommand {CommandId = 4,
                  UseScoreMultiplier = boostCommand.UseScoreMultiplier}).Code ==
                  "score-card-active" &&
              boostEngine.Command(enemyId, new MatchCommand {CommandId = 3,
                  UseScoreMultiplier = boostCommand.UseScoreMultiplier}).Code ==
                  "score-card-request-conflict",
            "card receipt replay cannot spend twice or cross player ownership");
        Check(boostEngine.Command(localId, new MatchCommand {CommandId = 5,
                  UseScoreMultiplier = new UseScoreMultiplierCommand
                  {
                      RequestId = Id(657), SourceCardId = "CRATEBLOCKER"
                  }}).Code == "score-card-not-selected",
            "one selected card cannot activate the other score effect");

        var blockerEngine = BonusCardMatch("CRATEBLOCKER");
        var blockerCommand = new MatchCommand {CommandId = 3,
            UseScoreMultiplier = new UseScoreMultiplierCommand
            {
                RequestId = Id(658),
                SourceCardId = PvpScoreMultiplierState.CrateBlocker
            }};
        Check(blockerEngine.Command(localId, blockerCommand).Code ==
                  "score-card-active" &&
              blockerEngine.BonusProgress.ConfirmedMultiplierFor(localId) == 1f &&
              blockerEngine.BonusProgress.ConfirmedMultiplierFor(enemyId) == 0f,
            "selected Crate Blocker targets the opponent's bonus progress");
        Check(blockerEngine.Command(localId, new MatchCommand {CommandId = 4,
                  UseScoreMultiplier = new UseScoreMultiplierCommand
                  {
                      RequestId = Id(660), SourceCardId = "CRATEBLOCKER"
                  }}).Code == "score-card-already-active",
            "another use while active cannot consume a second card");
        for (ulong scoreTick = 61; scoreTick <= 1870; scoreTick++)
            blockerEngine.Advance(scoreTick);
        Check(blockerEngine.BonusProgress.ConfirmedMultiplierFor(enemyId) == 1f,
            "host frame clock expires the score block after 60 seconds: " +
            blockerEngine.BonusProgress.ConfirmedMultiplierFor(enemyId) + "/" +
            blockerEngine.Snapshot().Phase + "/" + blockerEngine.Snapshot().ServerTick);

        Check(QueuedBonusCardSourceCatalog.IndexFor("HEALTHCRATE", content.PvpBonuses) == 1 &&
              QueuedBonusCardSourceCatalog.IndexFor("TURRETCRATE", content.PvpBonuses) == 5 &&
              QueuedBonusCardSourceCatalog.IndexFor("KEVLARCRATE", content.PvpBonuses) == 6 &&
              QueuedBonusCardSourceCatalog.IndexFor("AMMOCRATE", content.PvpBonuses) == 8,
            "four source card prefab references resolve to the reviewed bonus order");
        var healthCardEngine = BonusCardMatch("HEALTHCRATE");
        var healthRequest = Id(665);
        var healthCommand = new MatchCommand {CommandId = 3,
            QueueBonusCard = new QueueBonusCardCommand
            {
                RequestId = healthRequest, SourceCardId = "HEALTHCRATE"
            }};
        Check(healthCardEngine.Command(localId, new MatchCommand {CommandId = 3,
                  QueueBonusCard = new QueueBonusCardCommand
                  {
                      RequestId = Id(663), SourceCardId = "UNKNOWNCRATE"
                  }}).Code == "invalid-bonus-card-source" &&
              healthCardEngine.Command(localId, new MatchCommand {CommandId = 4,
                  QueueBonusCard = new QueueBonusCardCommand
                  {
                      RequestId = Id(664), SourceCardId = "AMMOCRATE"
                  }}).Code == "bonus-card-not-selected" &&
              healthCardEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 0,
            "packet aliases cannot choose another prefab or enqueue a box");
        healthCommand.CommandId = 5;
        Check(healthCardEngine.Command(localId, healthCommand).Code ==
                  "bonus-card-queued" &&
              healthCardEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 1 &&
              healthCardEngine.Snapshot().CardActivations == 1,
            "selected Health Crate card queues one host-owned bonus and spends stock");
        Check(healthCardEngine.Command(localId, new MatchCommand {CommandId = 6,
                  QueueBonusCard = healthCommand.QueueBonusCard}).Code ==
                  "bonus-card-queued" &&
              healthCardEngine.Command(enemyId, new MatchCommand {CommandId = 3,
                  QueueBonusCard = healthCommand.QueueBonusCard}).Code ==
                  "bonus-card-request-conflict" &&
              healthCardEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 1,
            "queued card replay cannot enqueue twice or cross ownership");
        var forcedHealth = healthCardEngine.BonusPlanner.PlanMatured(first, 0,
            context, draw);
        Check(forcedHealth.PrefabIndex == 1 &&
              forcedHealth.SourceIndex == 1 &&
              healthCardEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 0,
            "the next matured box consumes the Health Crate card's exact prefab");
        var fullQueueEngine = BonusCardMatch("HEALTHCRATE");
        for (int queueItem = 0; queueItem < 64; queueItem++)
            fullQueueEngine.BonusPlanner.EnqueueConfirmedBonus(Id(2000 + queueItem),
                localId, 1);
        Check(fullQueueEngine.Command(localId, new MatchCommand {CommandId = 3,
                  QueueBonusCard = healthCommand.QueueBonusCard}).Code ==
                  "bonus-queue-full" &&
              fullQueueEngine.Snapshot().CardActivations == 0 &&
              fullQueueEngine.BonusPlanner.QueuedCount(PvpBonusSide.Allies) == 64,
            "a full next-box queue rejects before card inventory is spent");

        var cardEngine = BonusCardMatch("CardGrenadesBurst");
        var cardRequest = Id(659);
        var cardCommand = new MatchCommand {CommandId = 3,
            UseGrenadesBurst = new UseGrenadesBurstCommand {RequestId = cardRequest}};
        var cardResult = cardEngine.Command(localId, cardCommand);
        Check(cardResult.Code == "grenades-burst-active",
            "selected Cluster Grenade card starts a host burst: " + cardResult.Code);
        Check(cardEngine.Command(localId, new MatchCommand {CommandId = 4,
            UseGrenadesBurst = new UseGrenadesBurstCommand {RequestId = cardRequest}}).Code ==
            "grenades-burst-active", "card request replay does not consume another card");
        Check(cardEngine.Command(enemyId, new MatchCommand {CommandId = 3,
            UseGrenadesBurst = new UseGrenadesBurstCommand {RequestId = cardRequest}}).Code ==
            "grenades-burst-request-conflict", "other player cannot replay card receipt");
        for (ulong cardTick = 61; cardTick <= 75 &&
             cardEngine.ReadyPvpGrenadeShots.Count == 0; cardTick++)
            cardEngine.Advance(cardTick);
        Check(cardEngine.ReadyPvpGrenadeShots.Count == 1 &&
            cardEngine.ReadyPvpGrenadeShots[0].CardFireOrigin ==
                content.CardGrenadeOrigins.ForCover(map,
                    manifest.Players[0].StartCover),
            "first card shot uses the serialized shield HUD snap origin");
        Check(Vector3.Distance(
                content.CardGrenadeOrigins.ForCover(map,
                    manifest.Players[0].StartCover),
                map.Covers[manifest.Players[0].StartCover].ShotPosition) > 0.1f,
            "shield HUD snap is distinct from ordinary cover shot position");
        Check(cardEngine.PendingPvpGrenadeFlights > 0,
            "card burst enters host grenade flight simulation");
        var visibleCardGrenade = cardEngine.Snapshot().Projectiles.Single(row =>
            row.Kind == "pvp-bonus-grenade");
        Check(visibleCardGrenade.OwnerPlayerId == localId &&
              visibleCardGrenade.ProjectileId > 0 &&
              new Vector3(visibleCardGrenade.X, visibleCardGrenade.Y,
                  visibleCardGrenade.Z) ==
                  content.CardGrenadeOrigins.ForCover(map,
                      manifest.Players[0].StartCover),
            "host snapshot publishes the live card grenade visual pose");
        float cardEnemyHealth = cardEngine.Snapshot().Players[1].Health;
        var cardShots = new List<PvpBonusGrenadeDueShot>(
            cardEngine.ReadyPvpGrenadeShots);
        int cardImpacts = cardEngine.PvpGrenadeImpacts.Count;
        int cardExplosions = cardEngine.PvpGrenadeExplosions.Count;
        for (ulong cardTick = cardEngine.Snapshot().ServerTick + 1;
             cardTick <= 180 && !cardEngine.Terminal; cardTick++)
        {
            cardEngine.Advance(cardTick);
            cardShots.AddRange(cardEngine.ReadyPvpGrenadeShots);
            cardImpacts += cardEngine.PvpGrenadeImpacts.Count;
            cardExplosions += cardEngine.PvpGrenadeExplosions.Count;
        }
        Check(cardShots.Count == 3 &&
              cardShots.Select(shot => shot.Launch.ShotIndex)
                  .SequenceEqual([0, 1, 2]) &&
              cardImpacts == 3 && cardExplosions == 3,
            $"card burst resolves all three host flights: " +
            $"shots={cardShots.Count}, impacts={cardImpacts}, explosions={cardExplosions}");
        Check(cardEngine.Snapshot().Players[1].Health < cardEnemyHealth,
            "card grenade explosions damage the opposing player");

        var decoyEngine = BonusCardMatch("CardDecoy");
        Check(decoyEngine.Command(enemyId, new MatchCommand {CommandId = 3,
            UseDecoy = new UseDecoyCommand {RequestId = Id(660)}}).Code ==
            "decoy-spawned", "enemy deploys a host-owned Decoy before the bonus blast");
        var initialDecoy = decoyEngine.Snapshot().Decoys.First();
        var decoyPosition = new Vector3(initialDecoy.X, initialDecoy.Y, initialDecoy.Z);
        var decoyPlanner = decoyEngine.BonusPlanner;
        decoyPlanner.EnqueueConfirmedBonus(Id(661), localId, 3);
        var decoyBox = decoyPlanner.PlanMatured(grenadeFrame, 0, context, draw);
        decoyPlanner.ConfirmDestroyed(decoyBox.Request.ReceiptId,
            Id(662), null, decoyPosition);
        var decoyBurst = decoyEngine.PlanCollectedPvpGrenades(decoyBox.Request.ReceiptId);
        Check(decoyBurst.Launches.Any(launch =>
                launch.TargetId == "decoy:" + initialDecoy.EntityId),
            "bonus grenade targets the nearby enemy Decoy from host registry");
        for (ulong nextTick = 61; nextTick <= 180 && !decoyEngine.Terminal;
             nextTick++)
            decoyEngine.Advance(nextTick);
        var remainingDecoy = decoyEngine.Snapshot().Decoys.SingleOrDefault(value =>
            value.EntityId == initialDecoy.EntityId);
        Check(remainingDecoy == null || remainingDecoy.Health < initialDecoy.Health,
            "host bonus grenade explosion damages the enemy Decoy once per blast");

        var turretEngine = BonusCardMatch("CardHeavyTurret");
        Check(turretEngine.Command(enemyId, new MatchCommand {CommandId = 3,
            UseHeavyTurret = new UseHeavyTurretCommand {RequestId = Id(670)}}).Code ==
            "heavy-turret-spawned",
            "enemy deploys a host-owned Heavy Turret before the bonus blast");
        var initialTurret = turretEngine.Snapshot().HeavyTurrets.Single();
        var turretPosition = new Vector3(initialTurret.X, initialTurret.Y, initialTurret.Z);
        var turretPlanner = turretEngine.BonusPlanner;
        turretPlanner.EnqueueConfirmedBonus(Id(671), localId, 3);
        var turretBox = turretPlanner.PlanMatured(grenadeFrame, 0, context, draw);
        turretPlanner.ConfirmDestroyed(turretBox.Request.ReceiptId,
            Id(672), null, turretPosition);
        var turretBurst = turretEngine.PlanCollectedPvpGrenades(turretBox.Request.ReceiptId);
        Check(turretBurst.Launches.Any(launch =>
                launch.TargetId == "heavy-turret:" + initialTurret.EntityId),
            "bonus grenade targets the nearby enemy Heavy Turret");
        for (ulong nextTick = 61; nextTick <= 180 && !turretEngine.Terminal;
             nextTick++)
            turretEngine.Advance(nextTick);
        var remainingTurret = turretEngine.Snapshot().HeavyTurrets.SingleOrDefault(value =>
            value.EntityId == initialTurret.EntityId);
        Check(remainingTurret == null || remainingTurret.Health < initialTurret.Health,
            "host bonus grenade explosion damages one Heavy Turret across its parts");

        (MatchEngine Match, ulong Tick) BonusArmyMatch(string unitId)
        {
            var armyManifest = manifest with {
                Players = manifest.Players.Select(player => player with {
                    EquippedArmyUnitIds = [unitId],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [unitId == "ID_UNIT-TRANSPORTER" ? 71 : -1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1, 1)],
                    ArmyDamageScales = [1],
                    ArmySpeedCoefficients = [1],
                    ArmyAccuracyCoefficients = [1]
                }).ToArray()
            };
            var match = new MatchEngine(armyManifest, map, content,
                armyChoice: _ => 0, combatRandom: () => 1f);
            foreach (var player in armyManifest.Players)
            {
                match.Admit(player.PlayerId);
                match.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                    Ready = new ReadyCommand {ManifestHash = match.ManifestHash}});
            }
            match.Advance(60);
            int option = match.ArmyBatch(enemyId).OptionIndexes.First();
            Check(match.Command(enemyId, new MatchCommand {CommandId = 2,
                DeployArmy = new DeployArmyCommand {OptionIndex = option}}).Code ==
                "army-deploying", "opponent deploys a source army unit before bonus blast");
            ulong tick = 60;
            while (tick < 300 && !match.Terminal &&
                   match.ArmyEntityBatch(localId, 0, 0).Entities.Count == 0)
                match.Advance(++tick);
            Check(match.ArmyEntityBatch(localId, 0, 0).Entities.Count > 0,
                "deployed enemy unit reaches host vitality before bonus blast");
            return (match, tick);
        }

        void BlastEnemyArmy(string unitId, int receiptBase,
            bool vehicleBody, bool expectKill = false)
        {
            var (match, currentTick) = BonusArmyMatch(unitId);
            var target = match.ArmyEntityBatch(localId, 0, 0).Entities.First();
            var hitbox = match.GroundVehicleShotTargets(localId)
                .First(part => part.EntityId == target.EntityKey &&
                    (vehicleBody ? part.GroundVehicleBody : part.ArmyInfantry)).Hitbox;
            if (expectKill)
            {
                float setupDamage = target.Health + target.Kevlar - 10f;
                if (setupDamage > 0f)
                    match.ApplyArmyHostDamage(target.EntityKey, setupDamage);
            }
            float healthBefore = match.ArmyHealth(target.EntityKey)!.Value;
            var planner = match.BonusPlanner;
            planner.EnqueueConfirmedBonus(Id(receiptBase), localId, 3);
            var box = planner.PlanMatured(grenadeFrame, 0, context, draw);
            planner.ConfirmDestroyed(box.Request.ReceiptId,
                Id(receiptBase + 1), null, hitbox.Center);
            var plannedBurst = match.PlanCollectedPvpGrenades(box.Request.ReceiptId);
            Check(plannedBurst.Launches.Any(launch =>
                    launch.TargetId == "army:" + target.EntityKey),
                "bonus grenade includes the deployed enemy unit in host targets");
            ulong nextTick = currentTick;
            while (nextTick < 420 && !match.Terminal &&
                   match.ArmyHealth(target.EntityKey) == healthBefore)
                match.Advance(++nextTick);
            float? healthAfter = match.ArmyHealth(target.EntityKey);
            Check(healthAfter == null || healthAfter < healthBefore,
                "host bonus grenade damages the deployed " + unitId);
            if (vehicleBody && healthAfter != null)
                Check(Math.Abs(match.Snapshot().Vehicles.Single(item =>
                    item.EntityId == target.EntityKey).Health - healthAfter.Value) < 0.01f,
                    "vehicle registry and shared vitality agree after bonus grenade damage");
            if (expectKill)
            {
                Check(healthAfter == null,
                    "source bonus blast kills the prepared enemy infantry");
                match.Command(localId, new MatchCommand {CommandId = 2,
                    Forfeit = new ForfeitCommand()});
                Check(match.TerminalEvidenceSnapshot().DirectArmyKills.Any(kill =>
                    kill.EntityKey == target.EntityKey &&
                    kill.AttackerPlayerId == localId &&
                    kill.VictimOwnerPlayerId == enemyId &&
                    kill.Cause == "player-grenade"),
                    "bonus grenade infantry death persists direct grenade-kill evidence");
            }
        }

        BlastEnemyArmy("ID_UNIT-ASSAULT", 680, vehicleBody: false,
            expectKill: true);
        BlastEnemyArmy("ID_UNIT-TANK", 690, vehicleBody: true);

        void BlastEnemyVehiclePart(string unitId, int receiptBase,
            Func<MatchEngine, ulong, (Vector3 Center, float Health)> selectPart,
            Func<MatchEngine, ulong, float> remainingHealth)
        {
            var (match, currentTick) = BonusArmyMatch(unitId);
            var vehicleId = match.ArmyEntityBatch(localId, 0, 0).Entities.First().EntityKey;
            var part = selectPart(match, vehicleId);
            var planner = match.BonusPlanner;
            planner.EnqueueConfirmedBonus(Id(receiptBase), localId, 3);
            var box = planner.PlanMatured(grenadeFrame, 0, context, draw);
            planner.ConfirmDestroyed(box.Request.ReceiptId,
                Id(receiptBase + 1), null, part.Center);
            match.PlanCollectedPvpGrenades(box.Request.ReceiptId);
            ulong nextTick = currentTick;
            while (nextTick < 420 && !match.Terminal &&
                   remainingHealth(match, vehicleId) == part.Health)
                match.Advance(++nextTick);
            Check(remainingHealth(match, vehicleId) < part.Health,
                "host bonus grenade damages the separate " + unitId + " part");
            float? bodyHealth = match.ArmyHealth(vehicleId);
            if (bodyHealth != null)
                Check(Math.Abs(match.Snapshot().Vehicles.Single(value =>
                    value.EntityId == vehicleId).Health - bodyHealth.Value) < 0.01f,
                    "vehicle body stays synchronized independently of its damaged part");
        }

        BlastEnemyVehiclePart("ID_UNIT-TANK", 700,
            (match, vehicleId) => {
                var passenger = match.VehiclePassengers(vehicleId).First(value => value.Active);
                var collider = match.GroundVehicleShotTargets(localId).First(value =>
                    value.EntityId == vehicleId && value.PassengerRole == passenger.Role);
                return (collider.Hitbox.Center, passenger.Health);
            },
            (match, vehicleId) => match.VehiclePassengers(vehicleId).First().Health);
        BlastEnemyVehiclePart("ID_UNIT-TRANSPORTER", 710,
            (match, vehicleId) => {
                var drone = match.TransporterRepairDrones(vehicleId).First(value => value.Active);
                var collider = match.GroundVehicleShotTargets(localId).First(value =>
                    value.EntityId == vehicleId && value.RepairDronePathIndex == drone.PathIndex);
                return (collider.Hitbox.Center, drone.Health);
            },
            (match, vehicleId) => match.TransporterRepairDrones(vehicleId).First().Health);

        void BlastEnemyAirBody(string unitId, int receiptBase)
        {
            var (match, currentTick) = BonusArmyMatch(unitId);
            var target = match.ArmyEntityBatch(localId, 0, 0).Entities.First();
            if (unitId == "ID_UNIT-ASSAULTHELI")
            {
                while (currentTick < 400 && !match.Terminal &&
                       match.GroundVehicleShotTargets(localId).First(part =>
                           part.EntityId == target.EntityKey &&
                           part.HelicopterBody).Hitbox.Center.Y > 1.8f)
                    match.Advance(++currentTick);
            }
            var airBody = match.GroundVehicleShotTargets(localId).First(part =>
                part.EntityId == target.EntityKey &&
                (part.DroneRoot || part.HelicopterBody));
            if (unitId == "ID_UNIT-ASSAULTHELI")
                Check(airBody.Hitbox.Center.Y <= 1.8f,
                    "Assault Helicopter descends into bonus blast range");
            float healthBefore = match.ArmyHealth(target.EntityKey)!.Value;
            var planner = match.BonusPlanner;
            planner.EnqueueConfirmedBonus(Id(receiptBase), localId, 3);
            var box = planner.PlanMatured(grenadeFrame, 0, context, draw);
            var boxPosition = airBody.Hitbox.Center;
            if (unitId == "ID_UNIT-ASSAULTHELI") boxPosition.Y = 0.5f;
            planner.ConfirmDestroyed(box.Request.ReceiptId,
                Id(receiptBase + 1), null, boxPosition);
            match.PlanCollectedPvpGrenades(box.Request.ReceiptId);
            ulong nextTick = currentTick;
            while (nextTick < 550 && !match.Terminal &&
                   match.ArmyHealth(target.EntityKey) == healthBefore)
                match.Advance(++nextTick);
            float? healthAfter = match.ArmyHealth(target.EntityKey);
            Check(healthAfter == null || healthAfter < healthBefore,
                "host bonus grenade damages the deployed " + unitId + " air body");
        }

        BlastEnemyAirBody("ID_UNIT-DRONE", 720);
        BlastEnemyAirBody("ID_UNIT-HELICOPTER", 730);
        BlastEnemyAirBody("ID_UNIT-ASSAULTHELI", 740);

        var (gunnerMatch, gunnerTick) = BonusArmyMatch("ID_UNIT-HELICOPTER");
        ulong gunnerHelicopterId = gunnerMatch.ArmyEntityBatch(localId, 0, 0)
            .Entities.First().EntityKey;
        var gunnerPart = gunnerMatch.GroundVehicleShotTargets(localId).First(part =>
            part.EntityId == gunnerHelicopterId && part.HelicopterGunner);
        float gunnerHealthBefore = gunnerMatch.HelicopterGunner(gunnerHelicopterId)!.Health;
        gunnerMatch.ApplyHelicopterGunnerExplosion(enemyId,
            gunnerPart.Hitbox.Center, 1.3f, 2.2f, 20f, 350f,
            halfDamage: false, friendKill: false);
        Check(gunnerMatch.HelicopterGunner(gunnerHelicopterId)?.Health ==
                  gunnerHealthBefore,
            "Manager grenade friendKill=0 protects the allied Helicopter gunner");
        var gunnerPlanner = gunnerMatch.BonusPlanner;
        gunnerPlanner.EnqueueConfirmedBonus(Id(745), localId, 3);
        var gunnerBox = gunnerPlanner.PlanMatured(grenadeFrame, 0, context, draw);
        gunnerPlanner.ConfirmDestroyed(gunnerBox.Request.ReceiptId,
            Id(746), null, gunnerPart.Hitbox.Center);
        gunnerMatch.PlanCollectedPvpGrenades(gunnerBox.Request.ReceiptId);
        while (gunnerTick < 420 && !gunnerMatch.Terminal &&
               gunnerMatch.HelicopterGunner(gunnerHelicopterId)?.Health == gunnerHealthBefore)
            gunnerMatch.Advance(++gunnerTick);
        Check(gunnerMatch.HelicopterGunner(gunnerHelicopterId)?.Health <
                  gunnerHealthBefore,
            "host bonus grenade damages the Helicopter's separate gunner");

        var (glassMatch, glassTick) = BonusArmyMatch("ID_UNIT-ASSAULTHELI");
        ulong glassAircraftId = glassMatch.ArmyEntityBatch(localId, 0, 0)
            .Entities.First().EntityKey;
        while (glassTick < 400 && !glassMatch.Terminal &&
               glassMatch.GroundVehicleShotTargets(localId).First(part =>
                   part.EntityId == glassAircraftId && part.AssaultGlass)
                   .Hitbox.Center.Y > 1.8f)
            glassMatch.Advance(++glassTick);
        var glassCollider = glassMatch.GroundVehicleShotTargets(localId)
            .First(part => part.EntityId == glassAircraftId && part.AssaultGlass);
        Check(glassCollider.Hitbox.Center.Y <= 1.8f,
            "Assault Helicopter glass descends into bonus blast range");
        // The collected crate is on the ground below the moving glass.
        var glassBoxPosition = glassCollider.Hitbox.Center;
        glassBoxPosition.Y = 0.5f;
        float glassHealthBefore = glassMatch.AssaultGlassHealth(glassAircraftId)!.Value;
        var glassPlanner = glassMatch.BonusPlanner;
        glassPlanner.EnqueueConfirmedBonus(Id(750), localId, 3);
        var glassBox = glassPlanner.PlanMatured(grenadeFrame, 0, context, draw);
        glassPlanner.ConfirmDestroyed(glassBox.Request.ReceiptId,
            Id(751), null, glassBoxPosition);
        glassMatch.PlanCollectedPvpGrenades(glassBox.Request.ReceiptId);
        while (glassTick < 550 && !glassMatch.Terminal &&
               glassMatch.AssaultGlassHealth(glassAircraftId) == glassHealthBefore)
            glassMatch.Advance(++glassTick);
        Check(glassMatch.AssaultGlassHealth(glassAircraftId) < glassHealthBefore,
            "ground-launched bonus grenade damages the moving Assault Helicopter glass");

        MatchEngine BonusMapMatch(MatchManifest mapManifest)
        {
            var match = new MatchEngine(mapManifest, map, content,
                combatRandom: () => 1f);
            foreach (var player in mapManifest.Players)
            {
                match.Admit(player.PlayerId);
                match.Command(player.PlayerId, new MatchCommand {CommandId = 1,
                    Ready = new ReadyCommand {ManifestHash = match.ManifestHash}});
            }
            match.Advance(60);
            return match;
        }

        void BlastMapTarget(MatchEngine match, int receiptBase, Vector3 position)
        {
            var planner = match.BonusPlanner;
            planner.EnqueueConfirmedBonus(Id(receiptBase), localId, 3);
            var box = planner.PlanMatured(grenadeFrame, 0, context, draw);
            planner.ConfirmDestroyed(box.Request.ReceiptId,
                Id(receiptBase + 1), null, position);
            match.PlanCollectedPvpGrenades(box.Request.ReceiptId);
            for (ulong nextTick = 61; nextTick <= 180 && !match.Terminal;
                 nextTick++)
                match.Advance(nextTick);
        }

        var shieldManifest = manifest with {
            Players = manifest.Players.Select(player => player with {ShieldLevel = 0})
                .ToArray()
        };
        var shieldRules = new ShieldMatchSimulation(map, content.Shields,
            shieldManifest);
        var friendlyCover = map.Covers.First(cover => cover.Fraction ==
            manifest.Players[0].Fraction);
        var enemyCover = map.Covers.First(cover => cover.Fraction ==
            manifest.Players[1].Fraction);
        string friendlyShieldOwner = friendlyCover.SourcePath + "/riot_shield";
        string enemyShieldOwner = enemyCover.SourcePath + "/riot_shield";
        Check(shieldRules.ApplyBonusGrenadeExplosion(friendlyShieldOwner,
                manifest.Players[0].Fraction, 350f, 0) == null,
            "Manager grenade friendKill=0 excludes the allied shield");
        float isolatedShieldBefore = shieldRules.Snapshot().Single(value =>
            value.CoverIndex == enemyCover.SourceIndex).Health;
        var isolatedShieldHit = shieldRules.ApplyBonusGrenadeExplosion(
            enemyShieldOwner, manifest.Players[0].Fraction, 350f, 0);
        Check(isolatedShieldHit != null && Math.Abs(
                isolatedShieldBefore - isolatedShieldHit.Health -
                Math.Min(isolatedShieldBefore,
                    350f * content.Shields.ExplosionCoefficient)) < 0.01f,
            "scene Manager grenade applies the source shield explosion coefficient");
        var shieldMatch = BonusMapMatch(shieldManifest);
        float enemyShieldBefore = shieldMatch.Snapshot().Shields.Single(value =>
            value.CoverIndex == enemyCover.SourceIndex).Health;
        var shieldCollider = map.DynamicColliders.First(collider =>
            collider.DynamicOwner == enemyCover.SourcePath + "/riot_shield");
        BlastMapTarget(shieldMatch, 750, shieldCollider.TransformPosition);
        Check(shieldMatch.Snapshot().Shields.Single(value =>
                value.CoverIndex == enemyCover.SourceIndex).Health < enemyShieldBefore,
            "host bonus grenade damages an opposing source shield");

        var barrelManifest = manifest with {
            Players = manifest.Players.Select(player => player with {PlayerLevel = 0})
                .ToArray()
        };
        var barrelMatch = BonusMapMatch(barrelManifest);
        var sourceBarrel = map.DynamicColliders.First(collider =>
            barrelMatch.BarrelState.Any(barrel =>
                barrel.ColliderIndex == collider.ColliderIndex));
        BlastMapTarget(barrelMatch, 760, sourceBarrel.TransformPosition);
        Check(barrelMatch.BarrelState.Any(barrel => barrel.Revision > 0),
            "host bonus grenade enters the recovered barrel damage chain");
        try
        {
            engine.PlanCollectedPvpGrenades(ammoPlan.Request.ReceiptId);
            throw new Exception("Non-grenade crate produced a grenade burst.");
        }
        catch (InvalidDataException) { checks++; }

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
