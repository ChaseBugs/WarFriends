using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises authenticated departure through live mission progress and terminal evidence.</summary>
internal static class CoopSurvivorRuntimeTests
{
    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        VerifyMovingDeparture(sources);
        VerifySurvivorSuccess(sources);
        VerifySurvivorTimeout(sources);
        VerifyNoLivingSurvivor(sources);
        VerifyMasterDeparture(sources);
        VerifyExplicitMasterRole(sources);
        Console.WriteLine("PASS: co-op moving departure, survivor success and timeout evidence");
    }

    private static void VerifyMovingDeparture(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string departingId = sources.Manifest.Players[1].PlayerId;
        string survivorId = sources.Manifest.Players[0].PlayerId;
        MatchReply movement = runtime.Command(departingId, new MatchCommand
        {
            CommandId = 2,
            MoveCover = new MoveCoverCommand { Direction = -1 }
        });
        Require(movement.Code == "moving", "The fixture must depart during an accepted source cover route.");
        runtime.Advance(2);
        BattlePlayerState before = runtime.Snapshot().Players[1];
        Depart(runtime, departingId, 3);
        runtime.Advance(10);
        BattlePlayerState after = runtime.Snapshot().Players[1];
        Require(after.CoopDeparted && !after.Moving && after.MoveEndTick == 0 && after.RiflePose == null &&
            after.PositionX == before.PositionX && after.PositionY == before.PositionY &&
            after.PositionZ == before.PositionZ, "Departure must stop movement without teleporting the peer.");
        Require(runtime.Command(survivorId, new MatchCommand
        {
            CommandId = 2,
            MoveCover = new MoveCoverCommand { Direction = 1, TargetCoverIndex = before.CoverIndex }
        }).Code == "moving", "The survivor must acquire the departed peer's released cover.");
    }

    private static void VerifySurvivorSuccess(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string departingId = sources.Manifest.Players[1].PlayerId;
        string survivorId = sources.Manifest.Players[0].PlayerId;
        Depart(runtime, departingId, 2);
        IReadOnlyList<CollisionPlayer>? placed = runtime.PlaceCurrentAlliedCollisionPoses();
        Require(placed?.Count == 1 && placed[0].PlayerId == survivorId,
            "The surviving ally's verified pose must remain available without the departed peer's collider.");
        ulong deadline = runtime.Snapshot().Coop.DeadlineTick;
        for (ulong tick = 1; tick < deadline && !runtime.Terminal; tick++)
        {
            runtime.Advance(tick);
            foreach (BattleCoopEnemySpawn enemy in runtime.Snapshot().Coop.EnemySpawns.Where(enemy => enemy.Health > 0))
            {
                Require(runtime.ApplyHostEnemyDamage(enemy.EntityId, enemy.Health, tick),
                    "Only host-confirmed source-spawn deaths may complete the survivor's objective.");
            }
        }

        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(terminal.TerminalReason == "mission-success" &&
            terminal.Coop.ParticipantIds.SequenceEqual([survivorId]) &&
            terminal.Coop.SuccessScores.Count == 1 && terminal.Coop.SuccessScores[0].PlayerId == survivorId &&
            runtime.HostSuccessScore(departingId) == null && !terminal.RewardEligible,
            "Survivor completion must exclude the departed peer from success and reward presentation.");
        CoopTerminalScoreValidator.ValidateSuccess(terminal, sources.Manifest, sources.Missions,
            sources.Combat, spawnPoints: sources.Spawns);
        MatchSnapshot forged = terminal.Clone();
        forged.Coop.SuccessScores.Add(new BattleCoopPlayerScore { PlayerId = departingId });
        RequireInvalid(() => CoopTerminalScoreValidator.ValidateSuccess(forged, sources.Manifest,
            sources.Missions, sources.Combat, spawnPoints: sources.Spawns));
    }

    private static void VerifySurvivorTimeout(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        Depart(runtime, sources.Manifest.Players[1].PlayerId, 2);
        runtime.Advance(runtime.Snapshot().Coop.DeadlineTick);
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(terminal.TerminalReason == "mission-failed" && terminal.Coop.ParticipantIds.Count == 1,
            "An unfinished survivor objective must fail at its original source deadline.");
        CoopTerminalScoreValidator.ValidateNonSuccess(terminal, sources.Manifest, sources.Missions,
            sources.Combat, spawnPoints: sources.Spawns);
    }

    private static void VerifyNoLivingSurvivor(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string survivorId = sources.Manifest.Players[0].PlayerId;
        float maximumHealth = runtime.Snapshot().Players[0].MaxHealth;
        PlayerDamageResult? death = runtime.ApplyHostPlayerDamage(1, survivorId,
            new ResolvedPlayerDamage(maximumHealth * 2, CombatDamageType.Basic, HasWeapon: false), 1f, 0);
        Require(death?.Dead == true, "The remaining peer must actually be dead before departure.");
        MatchReply reply = runtime.Command(sources.Manifest.Players[1].PlayerId, new MatchCommand
        {
            CommandId = 2,
            Forfeit = new ForfeitCommand()
        });
        Require(reply.Code == "forfeit" && runtime.Terminal && reply.Snapshot.TerminalReason == "forfeit",
            "A dead spectator must not count as a living survivor and keep an abandoned mission running.");
        runtime.TerminalEvidenceSnapshot();
    }

    private static void VerifyMasterDeparture(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        runtime.Command(sources.Manifest.Players[0].PlayerId, new MatchCommand
        {
            CommandId = 2,
            Forfeit = new ForfeitCommand()
        });
        Require(runtime.Terminal && runtime.Snapshot().TerminalReason == "forfeit" &&
            !runtime.Snapshot().Players[1].CoopDeparted,
            "Source master FinishGame broadcasts the shared end even while its peer remains active.");
        runtime.TerminalEvidenceSnapshot();
    }

    private static void VerifyExplicitMasterRole(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        MatchManifest manifest = sources.Manifest with
        {
            SceneMasterPlayerId = sources.Manifest.Players[1].PlayerId,
            Players = sources.Manifest.Players.Select(player => player with { PlayerLevel = 0 }).ToArray()
        };
        CoopMatchRuntime runtime = Start(sources with { Manifest = manifest });
        Depart(runtime, manifest.Players[0].PlayerId, 2);
        Require(runtime.Snapshot().Coop.ParticipantIds.SequenceEqual([manifest.SceneMasterPlayerId]),
            "An explicit signed master role must override the legacy first-roster default.");
    }

    private static CoopMatchRuntime Start(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        var runtime = new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, chooseBehaviour: _ => 0, playerWeaponContent: sources.Content);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            Require(runtime.Admit(player.PlayerId), "Both source allies must be admitted.");
            Require(runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
            }).Code == "ready", "Both source allies must be ready.");
        }

        return runtime;
    }

    private static void Depart(CoopMatchRuntime runtime, string playerId, ulong commandId)
    {
        MatchReply reply = runtime.Command(playerId, new MatchCommand
        {
            CommandId = commandId,
            Forfeit = new ForfeitCommand()
        });
        Require(reply.Code == "forfeit" && reply.Snapshot.Phase == BattlePhase.Running,
            "The authenticated first departure must leave the survivor's mission running.");
        Require(MatchSnapshot.Parser.ParseFrom(reply.Snapshot.ToByteArray()).Players
            .Single(player => player.PlayerId == playerId).CoopDeparted,
            "The departure state must survive the actual protobuf round trip.");
    }

    private static void RequireInvalid(Action validate)
    {
        try
        {
            validate();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("A departed peer received forged success presentation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
