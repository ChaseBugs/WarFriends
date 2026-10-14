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
            clockEngine.IssueNextMaturedBonus(
                context with {GoldBonusesCollected = 3}, draw);
            throw new Exception("Caller supplied a Gold-box count absent from player analytics.");
        }
        catch (InvalidDataException) { checks++; }
        Check(clockEngine.MaturedBonusRequests.Count == 1 &&
              clockEngine.BonusPlanner.ActiveBoxCount == 0,
            "Gold analytics mismatch cannot consume a source box request");
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
            var airBody = match.GroundVehicleShotTargets(localId).First(part =>
                part.EntityId == target.EntityKey &&
                (part.DroneRoot || part.HelicopterBody));
            float healthBefore = match.ArmyHealth(target.EntityKey)!.Value;
            var planner = match.BonusPlanner;
            planner.EnqueueConfirmedBonus(Id(receiptBase), localId, 3);
            var box = planner.PlanMatured(grenadeFrame, 0, context, draw);
            planner.ConfirmDestroyed(box.Request.ReceiptId,
                Id(receiptBase + 1), null, airBody.Hitbox.Center);
            match.PlanCollectedPvpGrenades(box.Request.ReceiptId);
            ulong nextTick = currentTick;
            while (nextTick < 420 && !match.Terminal &&
                   match.ArmyHealth(target.EntityKey) == healthBefore)
                match.Advance(++nextTick);
            float? healthAfter = match.ArmyHealth(target.EntityKey);
            Check(healthAfter == null || healthAfter < healthBefore,
                "host bonus grenade damages the deployed " + unitId + " air body");
        }

        BlastEnemyAirBody("ID_UNIT-DRONE", 720);
        BlastEnemyAirBody("ID_UNIT-HELICOPTER", 730);
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
