using War.Client;
using War.Protocol;

/// <summary>Checks the shared enemy view before any recovered visual is created.</summary>
internal static class CoopEnemyViewTests
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private static int _checks;

    internal static int Run()
    {
        _checks = 0;
        VerifyIsolationAndDeath();
        VerifySourceSpellingAndCardLane();
        VerifyMalformedRows();
        VerifyWalkingFrames();
        return _checks;
    }

    private static void VerifyIsolationAndDeath()
    {
        MatchSnapshot snapshot = CreateSnapshot();
        IReadOnlyList<CoopEnemyViewState> views = CoopEnemyViewProjection.FromSnapshot(snapshot, PlayerId);
        Require(views.Count == 1 && views[0].EntityId == 1 && views[0].Behaviour == "Assaulter" &&
            views[0].X == 1f && views[0].Health == 100f && !views[0].IsDead,
            "One source enemy must retain its host identity, pose and vitality.");
        snapshot.Coop.EnemySpawns[0].CurrentX = 99;
        snapshot.Coop.EnemySpawns[0].CurrentRotation.W = 0;
        BattleJointRotation returnedRotation = views[0].Rotation;
        returnedRotation.W = 0;
        Require(views[0].X == 1f && views[0].Rotation.W == 1f,
            "Source packet and consumer rotation mutation must not change an already published view.");
        MatchSnapshot dead = CreateSnapshot();
        dead.Coop.EnemySpawns[0].Health = 0;
        dead.Coop.EnemySpawns[0].DeathTick = 12;
        CoopEnemyViewState deadView = CoopEnemyViewProjection.FromSnapshot(dead, PlayerId)[0];
        Require(deadView.IsDead && deadView.DeathTick == 12,
            "A confirmed body death must remain in the source roster rather than silently disappear.");
        MatchSnapshot empty = CreateSnapshot();
        empty.Coop.EnemySpawns.Clear();
        Require(CoopEnemyViewProjection.FromSnapshot(empty, PlayerId).Count == 0,
            "A valid started mission may precede its first source spawn.");
    }

    private static void VerifySourceSpellingAndCardLane()
    {
        MatchSnapshot sourceSpelling = CreateSnapshot();
        sourceSpelling.Coop.EnemySpawns[0].Behaviour = "FlameThrower";
        Require(CoopEnemyViewProjection.FromSnapshot(sourceSpelling, PlayerId)[0].Behaviour == "FlameThrower",
            "The recovered mixed-case source spelling must resolve without rewriting its identity.");
        MatchSnapshot card = CreateSnapshot();
        BattleCoopEnemySpawn enemy = card.Coop.EnemySpawns[0];
        enemy.Level = 25;
        enemy.TimedEvent = true;
        enemy.CardUnit = true;
        enemy.CardProgress = 1f;
        CoopEnemyViewState view = CoopEnemyViewProjection.FromSnapshot(card, PlayerId)[0];
        Require(view.IsCardUnit && view.CardProgress == 1f && view.Level == 25,
            "A source timed card spawn must retain its validated interpolation lane.");
    }

    private static void VerifyMalformedRows()
    {
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns.Add(snapshot.Coop.EnemySpawns[0].Clone()));
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].EntityId = 2);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].Behaviour = "UnknownEnemy");
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].SpawnComponentFileId = 0);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].CurrentX = float.NaN);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].Health = float.PositiveInfinity);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].Health = 101);
        VerifyInvalid(snapshot =>
        {
            snapshot.Coop.EnemySpawns[0].Health = 0;
            snapshot.Coop.EnemySpawns[0].DeathTick = 30;
        });
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].CardProgress = 0.5f);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].CurrentRotation.W = 0);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].PoseTick = 7);
        VerifyInvalid(snapshot => snapshot.Coop.EnemySpawns[0].SpawnTick = 21);
    }

    private static void VerifyInvalid(Action<MatchSnapshot> change)
    {
        MatchSnapshot snapshot = CreateSnapshot();
        change(snapshot);
        try
        {
            CoopEnemyViewProjection.FromSnapshot(snapshot, PlayerId);
        }
        catch (InvalidDataException)
        {
            _checks++;
            return;
        }

        throw new InvalidDataException("An invalid enemy row selected a published visual state.");
    }

    private static void VerifyWalkingFrames()
    {
        MatchSnapshot snapshot = CreateSnapshot();
        SetWalkingFrame(snapshot);
        CoopEnemyViewState view = CoopEnemyViewProjection.FromSnapshot(snapshot, PlayerId)[0];
        Require(view.InfantryVisualClip == "run_0" && view.InfantryVisualStartTick == 8 &&
            view.InfantryVisualSampleTick == 20, "A supported walking sample must preserve its exact host clock.");
        VerifyInvalidWalking(row => row.InfantryVisualClip = "idle_1");
        VerifyInvalidWalking(row => row.InfantryVisualClip = "");
        VerifyInvalidWalking(row => row.InfantryVisualStartTick = 21);
        VerifyInvalidWalking(row =>
        {
            row.PoseTick = 19;
            row.InfantryVisualSampleTick = 19;
        });
        VerifyInvalidWalking(row =>
        {
            row.Health = 0;
            row.DeathTick = 20;
        });
        VerifyInvalidWalking(row => row.Behaviour = "Sniper");
        VerifyInvalid(terminal =>
        {
            SetWalkingFrame(terminal);
            terminal.Phase = BattlePhase.Ended;
            terminal.EndTick = terminal.ServerTick;
            terminal.TerminalReason = "mission-success";
            terminal.Coop.Completed = true;
            terminal.Coop.SuccessScores.Add(new BattleCoopPlayerScore { PlayerId = PlayerId, Score = 100, Stars = 1 });
            terminal.Coop.PeerCompletionPlayerIds.Add("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        });
    }

    private static void VerifyInvalidWalking(Action<BattleCoopEnemySpawn> change)
    {
        VerifyInvalid(snapshot =>
        {
            SetWalkingFrame(snapshot);
            change(snapshot.Coop.EnemySpawns[0]);
        });
    }

    private static void SetWalkingFrame(MatchSnapshot snapshot)
    {
        BattleCoopEnemySpawn enemy = snapshot.Coop.EnemySpawns[0];
        enemy.PoseTick = snapshot.ServerTick;
        enemy.InfantryVisualClip = "run_0";
        enemy.InfantryVisualStartTick = enemy.SpawnTick;
        enemy.InfantryVisualSampleTick = snapshot.ServerTick;
    }

    internal static MatchSnapshot CreateSnapshot()
    {
        MatchSnapshot snapshot = CoopOutcomeProjectionTests.CreateSuccess();
        snapshot.MatchId = "enemy-view-audit";
        snapshot.ManifestHash = new string('a', 64);
        snapshot.Phase = BattlePhase.Running;
        snapshot.EndTick = 0;
        snapshot.ServerTick = 20;
        snapshot.TerminalReason = "";
        snapshot.Coop.Completed = false;
        snapshot.Coop.SuccessScores.Clear();
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
        snapshot.Coop.EnemySpawns.Add(new BattleCoopEnemySpawn
        {
            EntityId = 1, Behaviour = "Assaulter", SpawnComponentFileId = 100, SpawnTick = 8,
            PoseTick = 8, X = 1, Y = 2, Z = 3, CurrentX = 1, CurrentY = 2, CurrentZ = 3,
            Health = 100, MaxHealth = 100, CurrentRotation = new BattleJointRotation { W = 1 }
        });
        return snapshot;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }

        _checks++;
    }
}
