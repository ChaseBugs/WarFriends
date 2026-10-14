using War.BattleServer;

internal static class PvpBonusProgressCoordinatorTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        string Id(int ordinal) => ordinal.ToString("x32");
        string matchId = Id(100);
        PvpBonusProgressCoordinator Create(bool drops=true, int pending=256, int receipts=4096,
            int scoreReceipts=4096, int gainReceipts=4096, int hitReceipts=4096) =>
            new(content.PvpScores, content.PvpScoreStreak, matchId, "local", "opponent", drops,
                pending, receipts, scoreReceipts, gainReceipts,
                maximumHitReceipts: hitReceipts);
        void ThreeKills(PvpBonusProgressCoordinator state, string owner, int firstReceipt)
        {
            for (int index = 0; index < 3; index++)
                state.RecordConfirmedSkillShot(owner, Id(firstReceipt + index), 0x1210, 1f);
        }

        using var normal = Create();
        ThreeKills(normal, "local", 1);
        ThreeKills(normal, "opponent", 4);
        var localScore = normal.ScoreSnapshot("local");
        Check(localScore.Score == 138 && localScore.ReceiptCount == 3 &&
              localScore.Counts[0x1000] == 3 && localScore.Counts[0x10] == 3,
            "confirmed skill shots publish score and source-row counts with progress");
        var scoreReplay = normal.RecordConfirmedSkillShotWithScore("local", Id(1), 0x1210, 1f);
        Check(scoreReplay.Score.ScoreAfter == 46 && scoreReplay.Progress == 34.5f &&
              normal.ScoreSnapshot("local").Score == 138,
            "one receipt replay returns its original score/progress without recounting");
        try { normal.RecordConfirmedSkillShot("opponent", Id(1), 0x1210, 1f);
            throw new Exception("Another owner reused a direct skill-shot receipt."); }
        catch (InvalidDataException) { checks++; }
        try { normal.RecordConfirmedSkillShot("local", Id(1), 0x1210, 1.25f);
            throw new Exception("Changed multiplier was accepted on score replay."); }
        catch (InvalidDataException) { checks++; }
        Check(normal.ScoreSnapshot("local").Score == 138 && normal.Snapshot("local").Progress == 103.5f,
            "rejected progress replay does not rewrite score or progress");
        try { normal.RecordConfirmedSkillShot("local", Id(9), 0x1210, float.NaN);
            throw new Exception("Invalid multiplier awarded score."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(normal.ScoreSnapshot("local").ReceiptCount == 3 && normal.Snapshot("local").GainReceiptCount == 3,
            "progress validation failure leaves the score ledger unchanged");
        using var hits = Create();
        var standingHit = hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1000),
            PvpPlayerDamageOwner.Player, CombatDamageType.Shot, false, 1f);
        var walkingHit = hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1001),
            PvpPlayerDamageOwner.Player, CombatDamageType.Explosion, true, 1f);
        var armyHit = hits.RecordConfirmedPlayerDamage("opponent", "local", Id(1002),
            PvpPlayerDamageOwner.Army, CombatDamageType.Shot, true, 1f);
        Check(standingHit?.Score is {Flags:65536,Points:6,ScoreAfter:6} &&
              walkingHit?.Score is {Flags:196608,Points:10,ScoreAfter:16} &&
              armyHit?.Score is {Flags:524288,Points:10,ScoreAfter:10} &&
              hits.Snapshot("local").Progress == 12f,
            "confirmed source damage publishes score and streak gain in one transition");
        Check(hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1001),
                  PvpPlayerDamageOwner.Player, CombatDamageType.Explosion, true, 1f) == walkingHit &&
              hits.ScoreSnapshot("local").ReceiptCount == 2,
            "host hit replay does not grant points or progress twice");
        var suppressed = hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1003),
            PvpPlayerDamageOwner.Player, CombatDamageType.Poison, true, 1f);
        Check(suppressed == null && hits.ScoreSnapshot("local").Score == 16 &&
              hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1003),
                  PvpPlayerDamageOwner.Player, CombatDamageType.Poison, true, 1f) == null,
            "source-excluded damage retains an unscored replay receipt");
        try { hits.RecordConfirmedPlayerDamage("local", "opponent", Id(1003),
                PvpPlayerDamageOwner.Player, CombatDamageType.Shot, true, 1f);
            throw new Exception("Suppressed hit receipt changed into scoring damage."); }
        catch (InvalidDataException) { checks++; }
        try { hits.RecordConfirmedSkillShot("local", Id(1003), 65536, 1f);
            throw new Exception("Suppressed hit receipt entered the direct score route."); }
        catch (InvalidDataException) { checks++; }
        Check(hits.RecordConfirmedPlayerDamage("local", "local", Id(1004),
                  PvpPlayerDamageOwner.Player, CombatDamageType.Shot, false, 1f) == null &&
              hits.RecordConfirmedPlayerDamage("opponent", "opponent", Id(1005),
                  PvpPlayerDamageOwner.Army, CombatDamageType.Shot, false, 1f) == null,
            "self and friendly-army callbacks reserve receipts without scoring");
        try { hits.RecordConfirmedPlayerDamage("local", "local", Id(1006),
                PvpPlayerDamageOwner.Player, (CombatDamageType)99, false, 1f);
            throw new Exception("Invalid self-damage type acquired a silent receipt."); }
        catch (InvalidDataException) { checks++; }
        using var fullHits = Create(hitReceipts: 1);
        fullHits.RecordConfirmedPlayerDamage("local", "opponent", Id(1010),
            PvpPlayerDamageOwner.Player, CombatDamageType.Poison, false, 1f);
        try { fullHits.RecordConfirmedPlayerDamage("local", "opponent", Id(1011),
                PvpPlayerDamageOwner.Player, CombatDamageType.Shot, false, 1f);
            throw new Exception("Full hit receipt ledger awarded score."); }
        catch (InvalidOperationException) { checks++; }
        Check(fullHits.ScoreSnapshot("local").Score == 0 &&
              fullHits.Snapshot("local").Progress == 0,
            "hit receipt capacity failure preserves score and streak state");
        using var fullHitScore = Create(scoreReceipts: 1);
        fullHitScore.RecordConfirmedPlayerDamage("local", "opponent", Id(1012),
            PvpPlayerDamageOwner.Player, CombatDamageType.Shot, false, 1f);
        try { fullHitScore.RecordConfirmedPlayerDamage("local", "opponent", Id(1013),
                PvpPlayerDamageOwner.Player, CombatDamageType.Shot, false, 1f);
            throw new Exception("Full score ledger accepted a hit."); }
        catch (InvalidOperationException) { checks++; }
        Check(fullHitScore.RecordConfirmedPlayerDamage("local", "opponent", Id(1013),
                  PvpPlayerDamageOwner.Player, CombatDamageType.Poison, false, 1f) == null &&
              fullHitScore.ScoreSnapshot("local").Score == 6,
            "failed score preparation leaves hit receipt free for corrected host evidence");
        using var stagedHit = Create();
        var candidateHit = stagedHit.PrepareConfirmedPlayerDamageCopy("local", "opponent",
            Id(1014), PvpPlayerDamageOwner.Player, CombatDamageType.Shot,
            victimWalking: false, confirmedMultiplier: 1f, out var stagedResult);
        Check(stagedResult?.Score.Points == 6 &&
              stagedHit.ScoreSnapshot("local").Score == 0 &&
              stagedHit.Snapshot("local").Progress == 0 &&
              candidateHit.ScoreSnapshot("local").Score == 6,
            "host can stage score and streak before publishing an accepted damage mutation");
        using var stagedFrame = Create();
        ThreeKills(stagedFrame, "local", 1020);
        var candidateFrame = stagedFrame.PrepareFrameCopy(1, 0f, true,
            out var pendingFrame);
        Check(pendingFrame.Players[0].Streak.BonusRequested &&
              stagedFrame.PendingCount == 0 &&
              candidateFrame.PendingCount == 1 &&
              stagedFrame.Snapshot("local").BonusesRequested == 0 &&
              candidateFrame.Snapshot("local").BonusesRequested == 1,
            "host can stage a bonus frame without consuming the original request");
        try { ((IDictionary<int, int>)localScore.Counts)[0x10] = 0;
            throw new Exception("Published counts were mutable."); }
        catch (NotSupportedException) { checks++; }
        using var fullScore = Create(scoreReceipts:1);
        using var fullGain = Create(gainReceipts:1);
        foreach (var state in new[] {fullScore, fullGain})
        {
            state.RecordConfirmedSkillShot("local", Id(20), 0x1210, 1f);
            var scoreBefore = state.ScoreSnapshot("local");
            var progressBefore = state.Snapshot("local");
            try { state.RecordConfirmedSkillShot("local", Id(21), 0x1210, 1f);
                throw new Exception("Exhausted score or gain ledger accepted another shot."); }
            catch (InvalidOperationException) { checks++; }
            Check(state.ScoreSnapshot("local").Score == scoreBefore.Score &&
                  state.ScoreSnapshot("local").ReceiptCount == scoreBefore.ReceiptCount &&
                  state.Snapshot("local") == progressBefore,
                "either receipt capacity failure leaves the score, counts and progress unchanged");
        }
        using var deaths = Create();
        var friendly = deaths.RecordConfirmedPlayerOwnedDeath("local", Id(30), 0x1210, 10f, false, 1f);
        Check(friendly.Combo is {Streak:1,ComboFlag:0} && friendly.ScoredSkillShot == null &&
              deaths.ScoreSnapshot("local").Score == 0 && deaths.Snapshot("local").Progress == 0,
            "player-owned friendly death advances shared combo before the faction score filter");
        var enemy = deaths.RecordConfirmedPlayerOwnedDeath("opponent", Id(31), 0x1210, 10.5f, true, 1f);
        int doubleFlags = 0x1210 | 32;
        Check(enemy.Combo is {Streak:2,ComboFlag:32} &&
              enemy.ScoredSkillShot?.Score.Flags == doubleFlags &&
              deaths.ScoreSnapshot("opponent").Score == content.PvpScores.PointsForConfirmedFlags(doubleFlags) &&
              deaths.ScoreSnapshot("local").Score == 0,
            "one source view shares combo history across owners and scores only the enemy death");
        Check(deaths.RecordConfirmedPlayerOwnedDeath("opponent", Id(31), 0x1210, 10.5f, true, 1f) == enemy &&
              deaths.ComboSnapshot() is {Streak:2,ReceiptCount:2},
            "confirmed death replay cannot recount or advance shared combo");
        try { deaths.RecordConfirmedPlayerOwnedDeath("opponent", Id(31), 0x1210, 10.5f, false, 1f);
            throw new Exception("Changed enemy identity replay was accepted."); }
        catch (InvalidDataException) { checks++; }
        try { deaths.RecordConfirmedSkillShot("opponent", Id(31), doubleFlags, 1f);
            throw new Exception("Death receipt was accepted through a direct skill shot."); }
        catch (InvalidDataException) { checks++; }
        var beforeInvalidDeath = deaths.ComboSnapshot();
        try { deaths.RecordConfirmedPlayerOwnedDeath("local", Id(32), 0x1210 | 64, 10.6f, true, 1f);
            throw new Exception("Untrusted precomposed combo flags were accepted."); }
        catch (InvalidDataException) { checks++; }
        Check(deaths.ComboSnapshot() == beforeInvalidDeath && deaths.ScoreSnapshot("local").Score == 0,
            "rejected base flags do not change combo or score authority");
        using var fullDeathScore = Create(scoreReceipts:1);
        fullDeathScore.RecordConfirmedPlayerOwnedDeath("local", Id(40), 0x1210, 10f, true, 1f);
        var beforeFullDeath = fullDeathScore.ComboSnapshot();
        try { fullDeathScore.RecordConfirmedPlayerOwnedDeath("local", Id(41), 0x1210, 10.5f, true, 1f);
            throw new Exception("Death advanced combo after score capacity failure."); }
        catch (InvalidOperationException) { checks++; }
        Check(fullDeathScore.ComboSnapshot() == beforeFullDeath &&
              fullDeathScore.ScoreSnapshot("local").ReceiptCount == 1 &&
              fullDeathScore.Snapshot("local").GainReceiptCount == 1,
            "failed enemy score publication rolls back the shared combo and progress");
        var laterFriendly = fullDeathScore.RecordConfirmedPlayerOwnedDeath("local", Id(41), 0x1210, 10.5f, false, 1f);
        Check(laterFriendly.Combo.ComboFlag == 32 && fullDeathScore.ComboSnapshot().ReceiptCount == 2,
            "rejected death receipt can be retried with actual host-confirmed friendly attribution");
        using var fullDeathGain = Create(gainReceipts:1);
        fullDeathGain.RecordConfirmedPlayerOwnedDeath("local", Id(50), 0x1210, 10f, true, 1f);
        var gainComboBefore = fullDeathGain.ComboSnapshot();
        var gainScoreBefore = fullDeathGain.ScoreSnapshot("local");
        try { fullDeathGain.RecordConfirmedPlayerOwnedDeath("local", Id(51), 0x1210, 10.5f, true, 1f);
            throw new Exception("Death advanced score after gain capacity failure."); }
        catch (InvalidOperationException) { checks++; }
        Check(fullDeathGain.ComboSnapshot() == gainComboBefore &&
              fullDeathGain.ScoreSnapshot("local").Score == gainScoreBefore.Score &&
              fullDeathGain.ScoreSnapshot("local").ReceiptCount == 1,
            "failed streak publication rolls back shared combo and score");
        var invalidTimeCombo = deaths.ComboSnapshot();
        try { deaths.RecordConfirmedPlayerOwnedDeath("local", Id(52), 0x1210, float.NaN, false, 1f);
            throw new Exception("Nonfinite source time advanced combo."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        Check(deaths.ComboSnapshot() == invalidTimeCombo,
            "invalid source clock leaves the shared death sequence unchanged");
        using var directReceipt = Create();
        directReceipt.RecordConfirmedSkillShot("opponent", Id(53), 0x1210, 1f);
        try { directReceipt.RecordConfirmedPlayerOwnedDeath("local", Id(53), 0x1210, 10f, true, 1f);
            throw new Exception("Another owner's direct receipt was reused for a death."); }
        catch (InvalidDataException) { checks++; }
        var template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        string firstId = template.Players[0].PlayerId;
        string secondId = template.Players[1].PlayerId;
        var ranked = template with {
            MatchId = Id(100), SceneMasterPlayerId = firstId,
            Players = [template.Players[0] with {PlayerLevel = 4},
                template.Players[1] with {PlayerLevel = 5}]
        };
        using var eligibleView = PvpBonusProgressCoordinator.CreateForOnlineManifest(content, ranked, firstId);
        using var ineligibleView = PvpBonusProgressCoordinator.CreateForOnlineManifest(content, ranked, secondId);
        using var namedView = PvpBonusProgressCoordinator.CreateForOnlineManifest(
            content, ranked with {MatchId = "bazooka-decoy-blast"}, firstId);
        Check(namedView.ScoreSnapshot(firstId).Score == 0,
            "source progress accepts a signed named match ID used by normal Worker matches");
        ThreeKills(eligibleView, firstId, 60);
        ThreeKills(ineligibleView, secondId, 70);
        Check(eligibleView.AdvanceFrame(1, 0f, true).Players[0].Streak.BonusRequested &&
              !ineligibleView.AdvanceFrame(1, 0f, true).Players[0].Streak.BonusRequested,
            "trusted roster ranks bind different original dropCreates values for the two Client views");
        try { PvpBonusProgressCoordinator.CreateForOnlineManifest(content,
                ranked with {Players = [ranked.Players[0] with {PlayerLevel = null}, ranked.Players[1]]}, firstId);
            throw new Exception("Missing signed source rank enabled crate view."); }
        catch (InvalidDataException) { checks++; }
        var issued = normal.AdvanceFrame(1, 0f, true);
        Check(issued.Players.Select(player => player.OwnerPlayerId).SequenceEqual(new[] {"local","opponent"}) &&
              issued.Players.All(player => player.Streak is {BonusRequested:true,BonusOrdinal:1,Progress:3.5f}),
            "one source Update preserves local/opponent order and requests both earned bonuses");
        Check(normal.PendingCount == 2 && normal.DelayReceiptCount == 2 && issued.MaturedRequests.Count == 0,
            "threshold consumption and both zero-age delay requests publish together");
        Check(normal.AdvanceFrame(1, 0f, true) == issued && normal.PendingCount == 2 && normal.DelayReceiptCount == 2,
            "exact joint frame replay cannot mint or schedule additional requests");
        var matured = normal.AdvanceFrame(2, 1.5f, false);
        Check(matured.MaturedRequests.Select(request => request.OwnerPlayerId).SequenceEqual(new[] {"local","opponent"}) &&
              matured.MaturedRequests.All(request => request.MatchId == matchId && request.BonusOrdinal == 1 && request.IssueFrame == 1) &&
              matured.MaturedRequests.Select(request => request.ReceiptId).Distinct().Count() == 2,
            "matured host identities retain source order and their original match/owner/ordinal/frame binding");
        Check(matured.Players.All(player => !player.Streak.BonusRequested && player.Streak.Progress == 3.5f) &&
              normal.PendingCount == 0,
            "stopped scoring does not cancel an existing manager wait while its scaled clock advances");
        Check(normal.AdvanceFrame(2, 1.5f, false) == matured && normal.DelayReceiptCount == 2,
            "matured frame replay returns the original immutable delivery list");
        try { ((IList<PvpOwnerStreakFrame>)issued.Players).Clear(); throw new Exception("Player frames were mutable."); }
        catch (NotSupportedException) { checks++; }

        using var disabled = Create(drops:false);
        ThreeKills(disabled, "local", 1);
        ThreeKills(disabled, "opponent", 4);
        var noCrates = disabled.AdvanceFrame(1, 0f, true);
        Check(noCrates.Players.All(player => player.Streak.Progress == 0 && !player.Streak.BonusRequested) && disabled.PendingCount == 0,
            "the source single no-crate ratio applies to both AddSkillshot branches");

        using var tooSmall = Create(pending:1);
        ThreeKills(tooSmall, "local", 1);
        ThreeKills(tooSmall, "opponent", 4);
        var beforeLocal = tooSmall.Snapshot("local");
        var beforeOpponent = tooSmall.Snapshot("opponent");
        for (int attempt = 0; attempt < 2; attempt++)
        {
            try { tooSmall.AdvanceFrame(1, 1f, true); throw new Exception("Partial two-owner frame accepted."); }
            catch (InvalidOperationException) { checks++; }
            Check(tooSmall.Snapshot("local") == beforeLocal && tooSmall.Snapshot("opponent") == beforeOpponent &&
                  tooSmall.PendingCount == 0 && tooSmall.DelayReceiptCount == 0,
                "second request failure preserves both progress values, ordinals and all delay receipts");
        }

        using var replacement = Create(pending:1);
        ThreeKills(replacement, "local", 1);
        replacement.AdvanceFrame(1, 0f, true);
        ThreeKills(replacement, "local", 4);
        var replaceFrame = replacement.AdvanceFrame(2, 1.5f, true);
        Check(replaceFrame.MaturedRequests.Count == 1 && replaceFrame.MaturedRequests[0].BonusOrdinal == 1 &&
              replaceFrame.Players[0].Streak is {BonusRequested:true,BonusOrdinal:2} && replacement.PendingCount == 1 &&
              replacement.DelayReceiptCount == 2,
            "old wait maturity releases capacity for the same frame's new request without early-aging it");
        Check(Math.Abs(replacement.Snapshot("local").Progress - 5.35f) < 0.00001f,
            "joint publication retains original decay then one-threshold subtraction");
        Check(replacement.AdvanceFrame(2, 1.5f, true) == replaceFrame && replacement.PendingCount == 1,
            "replacement frame replay cannot consume the second threshold or wait twice");
        Check(replacement.AdvanceFrame(3, 1.5f, false).MaturedRequests.Single().BonusOrdinal == 2,
            "newly staged replacement waits start with zero elapsed time");

        using var receiptFull = Create(receipts:1);
        ThreeKills(receiptFull, "local", 1);
        receiptFull.AdvanceFrame(1, 0f, true);
        ThreeKills(receiptFull, "local", 4);
        var held = receiptFull.Snapshot("local");
        try { receiptFull.AdvanceFrame(2, 1.5f, true); throw new Exception("Receipt exhaustion accepted."); }
        catch (InvalidOperationException) { checks++; }
        Check(receiptFull.Snapshot("local") == held && receiptFull.PendingCount == 1 && receiptFull.DelayReceiptCount == 1,
            "receipt exhaustion rolls back timer maturity as well as decay, threshold and ordinal changes");
        var stopped = receiptFull.AdvanceFrame(2, 1.5f, false);
        Check(stopped.MaturedRequests.Single().BonusOrdinal == 1 && receiptFull.Snapshot("local") == held,
            "an uncommitted frame can retry with authoritative stopped state without losing its existing wait");

        foreach (Action invalid in new Action[] {
            () => normal.AdvanceFrame(2, 0f, false),
            () => normal.AdvanceFrame(2, 1.5f, true),
            () => normal.AdvanceFrame(4, 0f, false),
            () => normal.RecordConfirmedSkillShot("outsider", Id(7), 0x1210, 1f) })
        {
            try { invalid(); throw new Exception("Changed or unbound frame authority accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        foreach (float invalid in new[] {-1f,float.NaN,float.PositiveInfinity})
        {
            try { normal.AdvanceFrame(3, invalid, false); throw new Exception("Invalid scaled delta accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        Check(normal.Snapshot("local").BonusesRequested == 1 && normal.Snapshot("opponent").BonusesRequested == 1 &&
              normal.PendingCount == 0 && normal.DelayReceiptCount == 2,
            "malformed frame/owner input leaves joint accepted state unchanged");
        normal.Dispose();
        try { normal.AdvanceFrame(3, 1f, false); throw new Exception("Destroyed source view advanced."); }
        catch (ObjectDisposedException) { checks++; }
        return checks;
    }
}
