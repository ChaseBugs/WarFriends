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
        PvpBonusProgressCoordinator Create(bool drops=true, int pending=256, int receipts=4096) =>
            new(content.PvpScores, content.PvpScoreStreak, matchId, "local", "opponent", drops, pending, receipts);
        void ThreeKills(PvpBonusProgressCoordinator state, string owner, int firstReceipt)
        {
            for (int index = 0; index < 3; index++)
                state.RecordConfirmedSkillShot(owner, Id(firstReceipt + index), 0x1210, 1f);
        }

        using var normal = Create();
        ThreeKills(normal, "local", 1);
        ThreeKills(normal, "opponent", 4);
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
