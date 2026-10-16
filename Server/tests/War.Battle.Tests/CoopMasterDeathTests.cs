using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Preserves source master-KIA termination and peer spectating with exact host death ticks.</summary>
internal static class CoopMasterDeathTests
{
    private const ulong DeathTick = 8;
    private const ulong ImpactId = 42;
    private const string FirstPlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string SecondPlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        VerifyKernelBoundaries(sources.Missions);
        VerifyMasterDeath(sources);
        VerifyMasterDeath(sources with
        {
            Manifest = sources.Manifest with
            {
                SceneMasterPlayerId = sources.Manifest.Players[1].PlayerId,
                Players = sources.Manifest.Players.Select(player => player with { PlayerLevel = 0 }).ToArray()
            }
        });
        VerifyTickZeroDeath(sources);
        VerifyPeerSpectating(sources);
        Console.WriteLine("PASS: co-op master KIA, tick-zero death presence, immutable replay and peer spectating");
    }

    private static void VerifyKernelBoundaries(MissionCatalog catalog)
    {
        const ulong startTick = 5;
        foreach (MissionRule rule in catalog.Missions.DistinctBy(mission => mission.MissionType))
        {
            var mission = new CoopMissionEngine(catalog, rule.Index);
            Require(!mission.FailAfterMasterDeath(startTick), "Master death cannot start an unready mission.");
            mission.Admit(FirstPlayerId);
            mission.Admit(SecondPlayerId);
            mission.MarkReady(FirstPlayerId, startTick);
            mission.MarkReady(SecondPlayerId, startTick);
            Require(!mission.FailAfterMasterDeath(startTick - 1) &&
                !mission.FailAfterMasterDeath(mission.DeadlineTick) && mission.Outcome == MissionOutcome.InProgress,
                "Out-of-window master death must leave the source objective unchanged.");
            Require(mission.FailAfterMasterDeath(startTick) && mission.Outcome == MissionOutcome.Failed &&
                mission.Participants.Count == 2 && mission.SelectAutomaticBehaviour(startTick + 1) == null &&
                !mission.FailAfterMasterDeath(startTick) && !mission.AdvanceTick(mission.DeadlineTick),
                "Master KIA must stop each mission type without removing participant history or reopening progress.");
        }
    }

    private static void VerifyMasterDeath(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        runtime.Advance(DeathTick);
        string masterId = runtime.Snapshot().Coop.SceneMasterPlayerId;
        BattlePlayerState master = runtime.Snapshot().Players.Single(player => player.PlayerId == masterId);
        var hit = new ResolvedPlayerDamage(master.MaxHealth * 2, CombatDamageType.Basic, HasWeapon: false);
        PlayerDamageResult? result = runtime.ApplyHostPlayerDamage(ImpactId, masterId, hit, 1f, DeathTick);
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(result?.Dead == true && terminal.Phase == BattlePhase.Ended &&
            terminal.TerminalReason == "mission-failed" && terminal.EndTick == DeathTick &&
            terminal.Coop.ParticipantIds.Count == 2 && terminal.Coop.SuccessScores.Count == 0 &&
            terminal.Coop.PeerCompletionPlayerIds.Count == 0 && !terminal.RewardEligible,
            "A host-confirmed master death must fail the source mission immediately without completion rewards.");
        byte[] before = terminal.ToByteArray();
        Require(runtime.ApplyHostPlayerDamage(ImpactId, masterId, hit, 1f, DeathTick) == result,
            "The exact lethal impact retry must retain its original result after terminal.");
        runtime.Advance(DeathTick + MatchManifest.TickRate);
        Require(runtime.TerminalEvidenceSnapshot().ToByteArray().AsSpan().SequenceEqual(before),
            "Master KIA must freeze terminal tick, vitality, objective and evidence.");
        VerifyRejectedForgeries(terminal, sources);
        foreach (BattlePlayerState player in terminal.Players)
        {
            Require(MatchOutcomeProjection.ForPlayer(terminal, player.PlayerId) == ClientGameEndReason.MissionFailed,
                "The source shared master-KIA boundary must display MissionFailed to both connected players.");
        }
    }

    private static void VerifyTickZeroDeath(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string masterId = runtime.Snapshot().Coop.SceneMasterPlayerId;
        float health = runtime.Snapshot().Players.Single(player => player.PlayerId == masterId).MaxHealth;
        runtime.ApplyHostPlayerDamage(ImpactId, masterId,
            new ResolvedPlayerDamage(health * 2, CombatDamageType.Basic, HasWeapon: false), 1f, 0);
        MatchSnapshot terminal = MatchSnapshot.Parser.ParseFrom(runtime.TerminalEvidenceSnapshot().ToByteArray());
        BattlePlayerState master = terminal.Players.Single(player => player.PlayerId == masterId);
        Require(terminal.Coop.Started && terminal.EndTick == 0 && master.HasCoopDeathTick && master.CoopDeathTick == 0,
            "An actual tick-zero death must retain optional-field presence across protobuf serialization.");
    }

    private static void VerifyPeerSpectating(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string peerId = sources.Manifest.Players[1].PlayerId;
        float health = runtime.Snapshot().Players[1].MaxHealth;
        runtime.ApplyHostPlayerDamage(ImpactId, peerId,
            new ResolvedPlayerDamage(health * 2, CombatDamageType.Basic, HasWeapon: false), 1f, 0);
        MatchSnapshot snapshot = runtime.Snapshot();
        Require(snapshot.Phase == BattlePhase.Running && snapshot.Coop.ParticipantIds.Count == 2 &&
            snapshot.Players[1].Dead && snapshot.Players[1].HasCoopDeathTick &&
            !snapshot.Players[1].CoopDeparted, "Peer KIA must remain distinct from departure and shared failure.");
        Require(runtime.Command(snapshot.Coop.SceneMasterPlayerId, new MatchCommand
        {
            CommandId = 2,
            MoveCover = new MoveCoverCommand { Direction = 1, TargetCoverIndex = snapshot.Players[1].CoverIndex }
        }).Code == "moving", "A KIA peer must release its source currentPlayerPoint for the surviving master.");
    }

    private static void VerifyRejectedForgeries(MatchSnapshot terminal,
        CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        int masterIndex = terminal.Players[0].PlayerId == terminal.Coop.SceneMasterPlayerId ? 0 : 1;
        MatchSnapshot missingTick = terminal.Clone();
        missingTick.Players[masterIndex].ClearCoopDeathTick();
        RequireInvalid(missingTick, sources);
        MatchSnapshot wrongTick = terminal.Clone();
        wrongTick.Players[masterIndex].CoopDeathTick = DeathTick - 1;
        RequireInvalid(wrongTick, sources);
        MatchSnapshot fakePeerDeath = terminal.Clone();
        BattlePlayerState master = fakePeerDeath.Players[masterIndex];
        master.Dead = false;
        master.Health = master.MaxHealth;
        master.ClearCoopDeathTick();
        master.DamageRevision = 0;
        BattlePlayerState peer = fakePeerDeath.Players[1 - masterIndex];
        peer.Dead = true;
        peer.Health = 0;
        peer.CoopDeathTick = DeathTick;
        peer.DamageRevision = 1;
        RequireInvalid(fakePeerDeath, sources);
        MatchSnapshot missingImpactHistory = terminal.Clone();
        missingImpactHistory.Players[masterIndex].DamageRevision = 0;
        RequireInvalid(missingImpactHistory, sources);
        MatchSnapshot excessiveImpactHistory = terminal.Clone();
        excessiveImpactHistory.Players[masterIndex].DamageRevision = ulong.MaxValue;
        RequireInvalid(excessiveImpactHistory, sources);
    }

    private static CoopMatchRuntime Start(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        var runtime = new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, chooseBehaviour: _ => 0);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            Require(runtime.Admit(player.PlayerId), "Both source allies must enter before KIA testing.");
            Require(runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
            }).Code == "ready", "Both source allies must be ready before any host damage.");
        }

        return runtime;
    }

    private static void RequireInvalid(MatchSnapshot snapshot, CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        try
        {
            CoopTerminalScoreValidator.ValidateNonSuccess(snapshot, sources.Manifest, sources.Missions,
                sources.Combat, spawnPoints: sources.Spawns);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Forged master-KIA evidence passed terminal validation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
