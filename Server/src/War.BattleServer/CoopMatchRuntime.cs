using Google.Protobuf;
using System.Numerics;
using War.Protocol;
using War.Shared;

namespace War.BattleServer;

/// <summary>
/// Authenticated co-op mission shell. It owns admission and terminal state but
/// cannot accept combat commands until host AI and player controls are wired.
/// Registration remains closed while this runtime is incomplete.
/// </summary>
internal sealed class CoopMatchRuntime : IMatchRuntime
{
    private sealed class Participant(string playerId)
    {
        public string PlayerId { get; } = playerId;
        public bool Admitted;
        public bool Ready;
        public ulong LastCommandId;
        public int CoverIndex;
        public int DestinationIndex = -1;
        public Vector3 Position;
        public CoopDefendRoute? Route;
        public ulong MoveStartTick;
        public ulong MoveEndTick;
        public readonly Dictionary<ulong, (byte[] Payload, MatchReply Reply)> Receipts = [];
    }

    private readonly MatchManifest manifest;
    private readonly CoopMissionEngine mission;
    private readonly MissionRule missionRule;
    private readonly CoopAiSpawnSelector spawnSelector;
    private readonly CoopEnemyCombatCatalog combat;
    private readonly Func<int, int> chooseSpawnPoint;
    private readonly List<BattleCoopEnemySpawn> enemySpawns = [];
    private readonly Dictionary<string, Participant> participants;
    private readonly IReadOnlyDictionary<string, CoopPlayerAnchor> playerStarts;
    private readonly CoopMapSpawnPoints sourceMap;
    private readonly CoopMapRoutes sourceRoutes;
    private ulong nextEnemyId = 1;
    private BattlePhase phase = BattlePhase.Waiting;
    private ulong tick;
    private ulong stateRevision;
    private string terminalReason = "";

    public string MatchId => manifest.MatchId;
    public string ManifestHash { get; }
    public bool Terminal => phase is BattlePhase.Ended or BattlePhase.Aborted;

    internal CoopMatchRuntime(MatchManifest allocation, MissionCatalog catalog,
        CoopSpawnPointCatalog spawnPoints, CoopNavMeshPathCatalog paths,
        CoopEnemyCombatCatalog combat,
        Func<int, int>? chooseBehaviour = null,
        Func<int, int>? choosePoint = null)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        manifest = MatchManifest.Validate(allocation);
        MissionMapRule? missionMap = manifest.MissionIndex is int selectedMission
            ? catalog.MapForMission(selectedMission) : null;
        if (manifest.Mode != MatchManifest.CoopMissionMode ||
            manifest.MissionIndex is not int missionIndex ||
            catalog.SourceSha256 != manifest.CatalogRevision ||
            missionMap == null || manifest.MapId != missionMap.Scene ||
            manifest.MapRevision != missionMap.SceneSha256 ||
            manifest.DurationSeconds != catalog.Get(missionIndex).TimeSeconds)
            throw new InvalidDataException("Co-op allocation differs from source mission authority.");

        ManifestHash = manifest.Digest();
        missionRule = catalog.Get(missionIndex);
        ArgumentNullException.ThrowIfNull(spawnPoints);
        CoopMapSpawnPoints map = spawnPoints.MapForMission(catalog, missionIndex);
        sourceMap = map;
        sourceRoutes = (paths ?? throw new ArgumentNullException(nameof(paths)))
            .MapForMission(catalog, missionIndex);
        CoopPlayerAnchor[] mainPositions = map.PlayerPositions
            .Where(position => position.Main)
            .OrderBy(position => position.Index)
            .ToArray();
        if (mainPositions.Length != manifest.Players.Length)
            throw new InvalidDataException("Co-op scene lacks both allied main positions.");
        // Photon master used mainPositions[0]. In the self-hosted match, the
        // signed roster order replaces that room-owned assignment.
        playerStarts = manifest.Players
            .Select((player, index) => (player.PlayerId, Position: mainPositions[index]))
            .ToDictionary(entry => entry.PlayerId, entry => entry.Position,
                StringComparer.Ordinal);
        spawnSelector = new CoopAiSpawnSelector(catalog, spawnPoints, missionIndex);
        this.combat = combat ?? throw new ArgumentNullException(nameof(combat));
        chooseSpawnPoint = choosePoint ?? Random.Shared.Next;
        mission = new CoopMissionEngine(catalog, missionIndex, chooseBehaviour);
        participants = manifest.Players.ToDictionary(player => player.PlayerId,
            player => new Participant(player.PlayerId), StringComparer.Ordinal);
        foreach (Participant participant in participants.Values)
        {
            CoopPlayerAnchor start = playerStarts[participant.PlayerId];
            participant.CoverIndex = start.Index;
            participant.Position = start.Position;
        }
    }

    public bool HasPlayer(string playerId) => participants.ContainsKey(playerId);

    public bool Admit(string playerId)
    {
        if (phase != BattlePhase.Waiting ||
            !participants.TryGetValue(playerId, out Participant? participant) ||
            participant.Admitted || !mission.Admit(playerId))
            return false;
        participant.Admitted = true;
        stateRevision++;
        return true;
    }

    public bool Resume(string playerId)
    {
        return !Terminal && participants.TryGetValue(playerId, out Participant? participant) &&
            participant.Admitted;
    }

    public bool CancelBeforeStart()
    {
        if (phase != BattlePhase.Waiting)
            return false;
        End(BattlePhase.Aborted, "cancelled-before-start");
        return true;
    }

    public bool AbortForHostShutdown()
    {
        if (Terminal)
            return false;
        End(BattlePhase.Aborted, "host-shutdown");
        return true;
    }

    public void Advance(ulong nextTick)
    {
        if (nextTick < tick)
            throw new InvalidOperationException("Co-op match tick moved backwards.");
        if (Terminal)
            return;

        if (phase == BattlePhase.Waiting)
        {
            ulong admissionDeadline =
                (ulong)manifest.AdmissionSeconds * MatchManifest.TickRate;
            tick = Math.Min(nextTick, admissionDeadline);
            if (nextTick >= admissionDeadline)
                End(BattlePhase.Aborted, "admission-timeout");
            return;
        }

        // A Worker normally advances one tick at a time. Replay and catch-up
        // may jump ahead; each omitted fixed step still owns its timed events
        // and WaveManager's automatic spawn opportunity.
        while (tick < nextTick && phase == BattlePhase.Running)
        {
            tick++;
            foreach (Participant participant in participants.Values)
                AdvancePlayerMovement(participant);
            if (mission.AdvanceTick(tick))
            {
                End(BattlePhase.Ended, mission.Outcome == MissionOutcome.Succeeded
                    ? "mission-success" : "mission-failed");
                break;
            }
            SpawnDueEnemies();
        }
    }

    private void SpawnDueEnemies()
    {
        // Mission.UpdateMission creates timed units; WaveManager also tries one
        // automatic creation when its quarter-second cadence has elapsed.
        foreach (int eventIndex in mission.DueTimedEvents(tick))
        {
            MissionTimedEvent timedEvent = missionRule.Events[eventIndex];
            BattleCoopEnemySpawn enemy = CreateEnemy(
                timedEvent.Behaviour, timedEvent.Level, true,
                timedEvent.IsCardUnit);
            if (!mission.ConfirmTimedEventSpawn(eventIndex, enemy.EntityId, tick))
                throw new InvalidDataException("A due co-op event rejected its host-created enemy.");
            enemySpawns.Add(enemy);
            stateRevision++;
        }

        int? behaviourIndex = mission.SelectAutomaticBehaviour(tick);
        if (behaviourIndex is not int selectedIndex)
            return;
        MissionSpawnBehaviour behaviour = missionRule.Behaviours[selectedIndex];
        BattleCoopEnemySpawn automaticEnemy = CreateEnemy(
            behaviour.Name, behaviour.Level, false, false);
        if (!mission.ConfirmAutomaticSpawn(selectedIndex, automaticEnemy.EntityId, tick))
            throw new InvalidDataException("A due co-op spawn rejected its host-created enemy.");
        enemySpawns.Add(automaticEnemy);
        stateRevision++;
    }

    private BattleCoopEnemySpawn CreateEnemy(
        string behaviour, int level, bool timedEvent, bool cardUnit)
    {
        IReadOnlyList<CoopSpawnPoint> candidates = spawnSelector.Candidates(behaviour);
        int selectedIndex = chooseSpawnPoint(candidates.Count);
        if (selectedIndex < 0 || selectedIndex >= candidates.Count)
            throw new InvalidDataException("Co-op spawn choice is outside the source collection.");
        CoopSpawnPoint point = candidates[selectedIndex];
        // The Client's co-op controller scales both paths with COOPHP, but
        // card units first interpolate their named card rows (or row zero when
        // that particular sheet has no card labels).
        float cardProgress = cardUnit ? Math.Clamp(level / 25f, 0f, 1f) : 0f;
        float maximumHealth = cardUnit
            ? combat.CardStats(behaviour, cardProgress).Health
            : combat.OrdinaryStats(behaviour, level).Health;
        return new BattleCoopEnemySpawn
        {
            EntityId = nextEnemyId++,
            Behaviour = behaviour,
            Level = level,
            SpawnComponentFileId = point.ComponentFileId,
            X = point.Position.X,
            Y = point.Position.Y,
            Z = point.Position.Z,
            SpawnTick = tick,
            TimedEvent = timedEvent,
            CardUnit = cardUnit,
            CardProgress = cardProgress,
            MaxHealth = maximumHealth,
            Health = maximumHealth
        };
    }

    /// <summary>
    /// Applies damage already established by host hit simulation. No client
    /// packet routes here: player fire, impact, and ownership still need their
    /// co-op validators before this can become live combat authority.
    /// </summary>
    internal bool ApplyHostEnemyDamage(ulong entityId, float damage, ulong impactTick)
    {
        if (phase != BattlePhase.Running || impactTick != tick ||
            impactTick >= mission.DeadlineTick ||
            !float.IsFinite(damage) || damage <= 0 || damage > 10_000_000)
            return false;

        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(
            spawned => spawned.EntityId == entityId);
        if (enemy == null || enemy.SpawnTick > impactTick ||
            enemy.Health <= 0 || enemy.DeathTick != 0)
            return false;

        float remaining = MathF.Max(0, enemy.Health - damage);
        if (remaining == 0 && !mission.ConfirmAiDeath(entityId, impactTick))
            return false;

        enemy.Health = remaining;
        if (remaining == 0)
        {
            enemy.DeathTick = impactTick;
            if (mission.Outcome == MissionOutcome.Succeeded)
                End(BattlePhase.Ended, "mission-success");
        }
        stateRevision++;
        return true;
    }

    public void ConfigureBattleAllocations(IEnumerable<BattleAllocationProjection> allocations)
    {
        if (allocations.Any())
            throw new InvalidDataException("Co-op loadout projection is not yet battle authority.");
    }

    public MatchReply Command(string playerId, MatchCommand command)
    {
        if (!participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted)
            return Reply(command.CommandId, "not-admitted");
        if (command.CalculateSize() > 256 ||
            command.IntentCase == MatchCommand.IntentOneofCase.None)
            return Reply(command.CommandId, "invalid-command");

        if (command.IntentCase == MatchCommand.IntentOneofCase.Poll)
            return Reply(0, command.CommandId == 0 ? "state" : "invalid-poll-id");
        if (command.CommandId is 0 or > 100000)
            return Reply(command.CommandId, "invalid-command");

        byte[] payload = command.ToByteArray();
        if (participant.Receipts.TryGetValue(command.CommandId, out var receipt))
            return payload.AsSpan().SequenceEqual(receipt.Payload)
                ? receipt.Reply.Clone() : Reply(command.CommandId, "command-conflict");
        if (Terminal)
            return Reply(command.CommandId, "match-terminal");
        if (command.CommandId != participant.LastCommandId + 1)
            return Reply(command.CommandId, "command-order");

        string code = Apply(participant, command);
        participant.LastCommandId = command.CommandId;
        stateRevision++;
        MatchReply reply = Reply(command.CommandId, code);
        participant.Receipts.Add(command.CommandId, (payload, reply.Clone()));
        if (participant.Receipts.Count > 64)
            participant.Receipts.Remove(command.CommandId - 64);
        return reply;
    }

    private string Apply(Participant participant, MatchCommand command)
    {
        if (command.IntentCase == MatchCommand.IntentOneofCase.Ready)
        {
            if (command.Ready.ManifestHash != ManifestHash)
                return "manifest-mismatch";
            if (participant.Ready)
                return "already-ready";
            if (!mission.MarkReady(participant.PlayerId, tick))
                return "ready-unavailable";
            participant.Ready = true;
            if (mission.Started)
                phase = BattlePhase.Running;
            return "ready";
        }
        if (command.IntentCase == MatchCommand.IntentOneofCase.Forfeit)
        {
            mission.Leave(participant.PlayerId);
            End(BattlePhase.Ended, "forfeit");
            return "forfeit";
        }
        if (command.IntentCase == MatchCommand.IntentOneofCase.MoveCover)
            return StartPlayerMovement(participant, command.MoveCover.Direction);
        return "coop-command-unavailable";
    }

    private string StartPlayerMovement(Participant participant, int direction)
    {
        if (phase != BattlePhase.Running || !participant.Ready)
            return "match-not-running";
        if (direction is not (-1 or 1))
            return "invalid-direction";
        if (participant.Route != null)
            return "already-moving";

        // PlayerController.GoLeft/GoRight scans availablePoints in source
        // order, skips the other fraction and shields occupied by a player.
        // The host also reserves an in-flight destination so simultaneous
        // requests cannot both acquire the same shield.
        int target = participant.CoverIndex + direction;
        while (target >= 0 && target < sourceMap.PlayerPositions.Count)
        {
            if (!participants.Values.Any(other => other != participant &&
                    (other.CoverIndex == target || other.DestinationIndex == target)))
                break;
            target += direction;
        }
        if (target < 0 || target >= sourceMap.PlayerPositions.Count)
            return "cover-unavailable";

        CoopDefendRoute route = sourceRoutes.Between(participant.CoverIndex, target);
        double length = 0;
        for (int index = 1; index < route.Corners.Count; index++)
            length += Vector3.Distance(route.Corners[index - 1], route.Corners[index]);
        if (!double.IsFinite(length) || length <= 0 || length > 100)
            throw new InvalidDataException("Co-op route has an invalid travel length.");

        participant.Route = route;
        participant.DestinationIndex = target;
        // PlayerController.GoTo defers NavMeshAgent.SetDestination by 0.02s.
        // At 30 Hz this is the next host tick.
        participant.MoveStartTick = tick + 1;
        participant.MoveEndTick = participant.MoveStartTick +
            (ulong)Math.Max(1, Math.Ceiling(length * MatchManifest.TickRate));
        return "moving";
    }

    private void AdvancePlayerMovement(Participant participant)
    {
        CoopDefendRoute? route = participant.Route;
        if (route == null || tick <= participant.MoveStartTick)
            return;
        if (tick >= participant.MoveEndTick)
        {
            participant.CoverIndex = participant.DestinationIndex;
            participant.Position = sourceMap.PlayerPositions[participant.CoverIndex].Position;
            participant.DestinationIndex = -1;
            participant.Route = null;
            stateRevision++;
            return;
        }

        double remaining = (double)(tick - participant.MoveStartTick) /
            MatchManifest.TickRate; // PlayerPrefab NavMeshAgent speed is 1 unit/s.
        for (int index = 1; index < route.Corners.Count; index++)
        {
            Vector3 start = route.Corners[index - 1];
            Vector3 end = route.Corners[index];
            float segmentLength = Vector3.Distance(start, end);
            if (remaining <= segmentLength)
            {
                participant.Position = Vector3.Lerp(start, end,
                    (float)(remaining / segmentLength));
                stateRevision++;
                return;
            }
            remaining -= segmentLength;
        }
        participant.Position = route.Corners[^1];
        stateRevision++;
    }

    public MatchReply Reply(ulong commandId, string code)
    {
        return new MatchReply
        {
            CommandId = commandId,
            Code = code,
            Snapshot = Snapshot()
        };
    }

    public MatchSnapshot Snapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            Phase = phase,
            ServerTick = tick,
            StartTick = mission.StartTick,
            EndTick = Terminal ? tick : 0,
            TerminalReason = terminalReason,
            RewardEligible = false,
            StateRevision = stateRevision,
            Coop = new BattleCoopState
            {
                MissionIndex = mission.MissionIndex,
                MissionType = mission.MissionType,
                ObjectiveTarget = mission.ObjectiveTarget,
                EnemyKills = mission.EnemyKills,
                DeadlineTick = mission.DeadlineTick,
                Started = mission.Started,
                Failed = mission.Outcome == MissionOutcome.Failed ||
                    phase == BattlePhase.Aborted || terminalReason == "forfeit",
                Completed = mission.Outcome == MissionOutcome.Succeeded
            }
        };
        snapshot.Coop.ParticipantIds.AddRange(
            mission.Participants.OrderBy(id => id, StringComparer.Ordinal));
        snapshot.Coop.EnemySpawns.AddRange(
            enemySpawns.Select(enemy => enemy.Clone()));
        foreach (ParticipantManifest rosterPlayer in manifest.Players)
        {
            CoopPlayerAnchor anchor = playerStarts[rosterPlayer.PlayerId];
            snapshot.Coop.ParticipantStarts.Add(new BattleCoopParticipantStart
            {
                PlayerId = rosterPlayer.PlayerId,
                DefendComponentFileId = anchor.ComponentFileId,
                X = anchor.Position.X,
                Y = anchor.Position.Y,
                Z = anchor.Position.Z
            });
        }
        foreach (Participant participant in participants.Values)
        {
            snapshot.Players.Add(new BattlePlayerState
            {
                PlayerId = participant.PlayerId,
                Admitted = participant.Admitted,
                Ready = participant.Ready,
                LastCommandId = participant.LastCommandId,
                CombatEnabled = false,
                CoverIndex = participant.CoverIndex,
                Moving = participant.Route != null,
                MoveEndTick = participant.MoveEndTick,
                PositionX = participant.Position.X,
                PositionY = participant.Position.Y,
                PositionZ = participant.Position.Z
            });
        }
        return snapshot;
    }

    public MatchSnapshot TerminalEvidenceSnapshot() => Snapshot();

    public MatchEventBatch EventBatch(string playerId, ulong afterEventId)
    {
        RequireAdmitted(playerId);
        return new MatchEventBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            LatestEventId = 0,
            Code = afterEventId == 0 ? "events" : "invalid-cursor"
        };
    }

    public MatchBarrelBatch BarrelBatch(string playerId)
    {
        RequireAdmitted(playerId);
        return new MatchBarrelBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            StateRevision = stateRevision
        };
    }

    public MatchArmyBatch ArmyBatch(string playerId)
    {
        RequireAdmitted(playerId);
        return new MatchArmyBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            StateRevision = stateRevision,
            Code = "army-disabled"
        };
    }

    public MatchArmyEntityBatch ArmyEntityBatch(
        string playerId, ulong afterEntityKey, ulong expectedRevision)
    {
        RequireAdmitted(playerId);
        return new MatchArmyEntityBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            ServerTick = tick,
            Code = afterEntityKey == 0 && expectedRevision == 0
                ? "army-disabled" : "invalid-cursor"
        };
    }

    private void RequireAdmitted(string playerId)
    {
        if (!participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted)
            throw new InvalidOperationException("Co-op state requires admission.");
    }

    private void End(BattlePhase finalPhase, string reason)
    {
        if (Terminal)
            return;
        foreach (Participant participant in participants.Values)
        {
            participant.Route = null;
            participant.DestinationIndex = -1;
            participant.MoveEndTick = 0;
        }
        phase = finalPhase;
        terminalReason = reason;
        stateRevision++;
    }
}
