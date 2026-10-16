using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Checks source start positions and distinct master-star/peer-completion ownership.</summary>
internal static class CoopSceneRoleTests
{
    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        VerifyOwnership(sources);
        VerifyOwnership(CreateExplicitMaster(sources, 0));
        VerifyOwnership(CreateExplicitMaster(sources, 1));
        VerifySpectatingPeer(sources);
        Console.WriteLine("PASS: co-op source master positions, master-only stars and peer completion ownership");
    }

    private static CoopObstacleVolleyRuntimeTests.Sources CreateExplicitMaster(
        CoopObstacleVolleyRuntimeTests.Sources sources, int masterIndex)
    {
        return sources with
        {
            Manifest = sources.Manifest with
            {
                SceneMasterPlayerId = sources.Manifest.Players[masterIndex].PlayerId,
                Players = sources.Manifest.Players.Select(player => player with { PlayerLevel = 0 }).ToArray()
            }
        };
    }

    private static void VerifyOwnership(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string masterId = sources.Manifest.SceneMasterPlayerId ?? sources.Manifest.Players[0].PlayerId;
        string peerId = sources.Manifest.Players.Single(player => player.PlayerId != masterId).PlayerId;
        VerifyStarts(runtime.Snapshot(), sources, masterId, peerId);
        CompleteKillMission(runtime);
        MatchSnapshot terminal = MatchSnapshot.Parser.ParseFrom(runtime.TerminalEvidenceSnapshot().ToByteArray());
        Require(terminal.Coop.SceneMasterPlayerId == masterId && terminal.Coop.SuccessScores.Count == 1 &&
            terminal.Coop.SuccessScores[0].PlayerId == masterId && runtime.HostSuccessScore(peerId) == null &&
            terminal.Coop.PeerCompletionPlayerIds.SequenceEqual([peerId]) && !terminal.RewardEligible,
            "Only the source master owns stars/highscore; the peer owns the separate completion marker.");
        VerifyRejectedRoleForgeries(terminal, sources, peerId);
        Require(MatchOutcomeProjection.ForPlayer(terminal, masterId) == ClientGameEndReason.MissionSuccess &&
            MatchOutcomeProjection.ForPlayer(terminal, peerId) == ClientGameEndReason.MissionSuccess,
            "The shared source success callback must not require a PvP winner or grant the peer its own stars.");
    }

    private static void VerifyStarts(MatchSnapshot snapshot, CoopObstacleVolleyRuntimeTests.Sources sources,
        string masterId, string peerId)
    {
        CoopPlayerAnchor[] points = sources.Spawns.MapForMission(sources.Missions,
            sources.Manifest.MissionIndex!.Value).PlayerPositions.Where(point => point.Main)
            .OrderBy(point => point.Index).ToArray();
        Require(snapshot.Coop.ParticipantStarts.Single(player => player.PlayerId == masterId)
            .DefendComponentFileId == points[0].ComponentFileId &&
            snapshot.Coop.ParticipantStarts.Single(player => player.PlayerId == peerId)
            .DefendComponentFileId == points[1].ComponentFileId,
            "The source master owns the first main point even when stored second in the signed roster.");
    }

    private static void VerifyRejectedRoleForgeries(MatchSnapshot terminal,
        CoopObstacleVolleyRuntimeTests.Sources sources, string peerId)
    {
        MatchSnapshot wrongMaster = terminal.Clone();
        wrongMaster.Coop.SceneMasterPlayerId = peerId;
        RequireInvalid(wrongMaster, sources);
        MatchSnapshot peerStars = terminal.Clone();
        peerStars.Coop.SuccessScores[0].PlayerId = peerId;
        RequireInvalid(peerStars, sources);
        MatchSnapshot missingPeerCompletion = terminal.Clone();
        missingPeerCompletion.Coop.PeerCompletionPlayerIds.Clear();
        RequireInvalid(missingPeerCompletion, sources);
        MatchSnapshot wrongPeerCompletion = terminal.Clone();
        wrongPeerCompletion.Coop.PeerCompletionPlayerIds[0] = terminal.Coop.SceneMasterPlayerId;
        RequireInvalid(wrongPeerCompletion, sources);
        MatchSnapshot wrongStarts = terminal.Clone();
        wrongStarts.Coop.ParticipantStarts[0].DefendComponentFileId =
            terminal.Coop.ParticipantStarts[1].DefendComponentFileId;
        RequireInvalid(wrongStarts, sources);
    }

    private static void VerifySpectatingPeer(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = Start(sources);
        string peerId = sources.Manifest.Players[1].PlayerId;
        float health = runtime.Snapshot().Players[1].MaxHealth;
        Require(runtime.ApplyHostPlayerDamage(1, peerId,
            new ResolvedPlayerDamage(health * 2, CombatDamageType.Basic, HasWeapon: false), 1f, 0)?.Dead == true,
            "The co-op peer must actually be a KIA spectator before the master succeeds.");
        CompleteKillMission(runtime);
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(terminal.Coop.PeerCompletionPlayerIds.SequenceEqual([peerId]) &&
            terminal.Coop.SuccessScores.Count == 1 && terminal.Coop.SuccessScores[0].PlayerId != peerId,
            "MissionSucceededRPC still marks the connected spectating peer complete without awarding it stars.");
        Require(MatchOutcomeProjection.ForPlayer(terminal, peerId) == ClientGameEndReason.MissionSuccess,
            "FinishGameMultiplayerRPC replaces the spectating peer's KIA presentation with the shared mission result.");
    }

    private static CoopMatchRuntime Start(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        var runtime = new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, chooseBehaviour: _ => 0);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            Require(runtime.Admit(player.PlayerId), "The source role fixture requires both admitted allies.");
            Require(runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
            }).Code == "ready", "The source role fixture requires both ready allies.");
        }

        return runtime;
    }

    private static void CompleteKillMission(CoopMatchRuntime runtime)
    {
        ulong deadline = runtime.Snapshot().Coop.DeadlineTick;
        for (ulong tick = 1; tick < deadline && !runtime.Terminal; tick++)
        {
            runtime.Advance(tick);
            foreach (BattleCoopEnemySpawn enemy in runtime.Snapshot().Coop.EnemySpawns.Where(enemy => enemy.Health > 0))
            {
                Require(runtime.ApplyHostEnemyDamage(enemy.EntityId, enemy.Health, tick),
                    "Completion requires actual source-spawned enemies and host-confirmed deaths.");
            }
        }
    }

    private static void RequireInvalid(MatchSnapshot snapshot, CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        try
        {
            CoopTerminalScoreValidator.ValidateSuccess(snapshot, sources.Manifest, sources.Missions,
                sources.Combat, spawnPoints: sources.Spawns);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Forged co-op role progression passed terminal validation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
