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
            int scoreReceipts=4096, int gainReceipts=4096) =>
            new(content.PvpScores, content.PvpScoreStreak, matchId, "local", "opponent", drops,
                pending, receipts, scoreReceipts, gainReceipts);
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
