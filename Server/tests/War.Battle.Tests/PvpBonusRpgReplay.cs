using System.Numerics;
using System.Text.Json;
using War.BattleServer;
using War.Protocol;

/// <summary>Replays the observed box location with fixed host draws and ordinary RPG hold/flight.</summary>
internal static class PvpBonusRpgReplay
{
    private const float FailedBoxX = 0.5833868f;
    private const float FailedBoxZ = -0.73505604f;
    private const ulong ReadyTick = 60;
    private const ulong GroundingDeadline = 300;
    private const ulong FlightDeadline = 3000;
    private const int ReplaySeconds = 120;
    private const int SourceKevlarIndex = 6;
    private const int SourcePlayerLevel = 8;
    private const int SourceStreakHits = 3;
    private const int BlockedCoverIndex = 2;
    private const int ExpectedCases = 12;
    private const float ImpactTolerance = 0.0001f;
    private static readonly Vector3 BlockedImpact = new(-2.6722121f, 0.27738816f, -0.47879574f);

    /// <summary>Writes diagnostic evidence; this does not certify every random crate or Unity flight parity.</summary>
    public static void Run(string directory, string outputPath)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory, "bazooka-content-manifest.json"));
        MatchManifest template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            Path.GetFileNameWithoutExtension(candidate.Source) == template.MapId);
        PvpBonusSpawnArea area = content.PvpBonusSpawnAreas.ForMap(map).First(candidate =>
            FailedBoxX >= candidate.BoundsMin.X && FailedBoxX <= candidate.BoundsMax.X &&
            FailedBoxZ >= candidate.BoundsMin.Z && FailedBoxZ <= candidate.BoundsMax.Z);
        var results = new List<ReplayResult>();
        foreach (CoverNode cover in map.Covers.Where(row => row.Fraction == template.Players[0].Fraction))
        {
            foreach (float draw in new[] { 0f, 0.5f, 1f })
            {
                MatchManifest manifest = CreateManifest(template, content);
                results.Add(Replay(content, map, manifest, new ReplayInput(area, draw, cover.SourceIndex)));
            }
        }
        CheckCounterexample(results);
        CheckCoverSearch(map, template.Players[0].Fraction, results);
        File.WriteAllText(outputPath, JsonSerializer.Serialize(new
        {
            scope = "fixed X/Z, forced source Kevlar box, normal cover movement, initial RPG curve sign",
            map.SourceHash,
            results
        }, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true }) + "\n");
        Console.WriteLine($"PASS: {results.Count} fixed-location RPG cover/draw replays and failed-cover fallback; " +
            $"collected={results.Count(row => row.IsCollected)}; report={outputPath}");
    }

    private static void CheckCounterexample(IReadOnlyList<ReplayResult> results)
    {
        if (results.Count != ExpectedCases || results.Any(row =>
            row.CoverIndex == BlockedCoverIndex
                ? row.IsCollected || Vector3.Distance(row.ImpactPosition, BlockedImpact) > ImpactTolerance
                : !row.IsCollected))
        {
            throw new InvalidOperationException("The recovered blocked-cover counterexample changed.");
        }
    }

    private static void CheckCoverSearch(RecoveredBattleMap map, int fraction, IReadOnlyList<ReplayResult> results)
    {
        var search = new RpgCoverSearch(map);
        string boxId = Guid.NewGuid().ToString("N");
        CoverNode first = search.SelectNext(boxId, fraction, FailedBoxZ);
        CoverNode second = search.SelectNext(boxId, fraction, FailedBoxZ);
        if (first.SourceIndex != BlockedCoverIndex || second.SourceIndex == first.SourceIndex ||
            results.Any(row => row.CoverIndex == second.SourceIndex && !row.IsCollected))
        {
            throw new InvalidOperationException("RPG cover search repeated the blocked position.");
        }
        CoverNode reset = search.SelectNext(Guid.NewGuid().ToString("N"), fraction, FailedBoxZ);
        if (reset.SourceIndex != first.SourceIndex)
        {
            throw new InvalidOperationException("RPG cover search leaked attempts into a different crate.");
        }
    }

    private static MatchManifest CreateManifest(MatchManifest template, BattleCombatContent content)
    {
        BazookaCatalog catalog = content.Bazookas ?? throw new InvalidDataException("RPG catalog is absent.");
        WeaponManifest weapon = catalog.CreateManifest("Google2u.Bazooka_RPG7", 0);
        ParticipantManifest[] players = template.Players.Select(player => player with
        {
            Weapon = weapon,
            WeaponUpgrade = 0,
            PlayerLevel = SourcePlayerLevel
        }).ToArray();
        return template with
        {
            MatchId = Guid.NewGuid().ToString("N"),
            Mode = MatchManifest.BazookaCombatMode,
            CatalogRevision = content.BazookaRevision ?? throw new InvalidDataException("RPG revision is absent."),
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
            PvpGoldBonusesAtAdmission = 0,
            DurationSeconds = ReplaySeconds,
            SceneMasterPlayerId = players[0].PlayerId,
            Players = players
        };
    }

    private static ReplayResult Replay(BattleCombatContent content, RecoveredBattleMap map,
        MatchManifest manifest, ReplayInput input)
    {
        PvpBonusSpawnArea area = input.Area;
        Vector3 unitPosition = new(
            (FailedBoxX - area.BoundsMin.X) / (area.BoundsMax.X - area.BoundsMin.X),
            0.5f,
            (FailedBoxZ - area.BoundsMin.Z) / (area.BoundsMax.Z - area.BoundsMin.Z));
        var host = new MatchEngine(manifest, map, content, combatRandom: () => input.MissileDraw,
            bonusAreaChoice: _ => area.Order, bonusPositionDraw: () => unitPosition);
        foreach (ParticipantManifest player in manifest.Players)
        {
            host.Admit(player.PlayerId);
            host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = host.ManifestHash }
            });
        }
        host.Advance(ReadyTick);
        string owner = manifest.Players[0].PlayerId;
        host.BonusPlanner.EnqueueConfirmedBonus(Guid.NewGuid().ToString("N"), owner, SourceKevlarIndex);
        for (int i = 0; i < SourceStreakHits; i++)
        {
            host.BonusProgress.RecordConfirmedSkillShot(owner, Guid.NewGuid().ToString("N"), 0x1210, 1f);
        }
        PvpBonusBoxSnapshot box = WaitForGroundedBox(host);
        MoveToCover(host, map, input.CoverIndex);
        return FireAtBox(host, manifest, box, input.MissileDraw);
    }

    private static void MoveToCover(MatchEngine host, RecoveredBattleMap map, int destination)
    {
        string owner = host.Snapshot().Players[0].PlayerId;
        for (int step = 0; step < map.Covers.Count; step++)
        {
            MatchSnapshot frame = host.Snapshot();
            int current = frame.Players[0].CoverIndex;
            if (current == destination)
            {
                return;
            }
            MatchReply move = host.Command(owner, new MatchCommand
            {
                CommandId = frame.Players[0].LastCommandId + 1,
                MoveCover = new MoveCoverCommand { Direction = Math.Sign(destination - current) }
            });
            if (move.Code != "moving")
            {
                throw new InvalidOperationException("Normal cover replay movement rejected: " + move.Code);
            }
            do
            {
                ulong nextTick = host.Snapshot().ServerTick + 1;
                if (nextTick >= FlightDeadline || host.Terminal)
                {
                    throw new InvalidOperationException("Normal cover replay movement did not finish.");
                }
                host.Advance(nextTick);
            } while (host.Snapshot().Players[0].Moving);
        }
        throw new InvalidOperationException("Normal cover replay did not reach its destination.");
    }

    private static PvpBonusBoxSnapshot WaitForGroundedBox(MatchEngine host)
    {
        for (ulong tick = ReadyTick + 1; tick <= GroundingDeadline; tick++)
        {
            host.Advance(tick);
            PvpBonusBoxSnapshot? box = host.BonusPlanner.ActiveBoxesSnapshot().SingleOrDefault();
            if (box?.Phase == PvpBonusBoxPhase.Grounded)
            {
                return box;
            }
        }
        throw new InvalidOperationException("The deterministic source box did not land.");
    }

    private static ReplayResult FireAtBox(MatchEngine host, MatchManifest manifest,
        PvpBonusBoxSnapshot box, float draw)
    {
        string owner = manifest.Players[0].PlayerId;
        MatchReply reply = host.Command(owner, new MatchCommand
        {
            CommandId = host.Snapshot().Players[0].LastCommandId + 1,
            BazookaHold = new BazookaHoldCommand
            {
                Pressed = true, TargetX = box.Position.X, TargetY = box.Position.Y, TargetZ = box.Position.Z
            }
        });
        if (reply.Code != "bazooka-targeting")
        {
            throw new InvalidOperationException("Deterministic RPG hold rejected: " + reply.Code);
        }
        for (ulong tick = host.Snapshot().ServerTick + 1; tick <= FlightDeadline; tick++)
        {
            host.Advance(tick);
            MatchEvent? impact = host.EventBatch(owner, 0).Events.FirstOrDefault(item =>
                item.Kind == MatchEventKind.Impact && item.Reason == "bazooka");
            if (impact != null)
            {
                return new ReplayResult(host.Snapshot().Players[0].CoverIndex, draw, box.Position,
                    new Vector3(impact.X, impact.Y, impact.Z),
                    host.BonusPlanner.BoxSnapshot(box.BoxId).Phase == PvpBonusBoxPhase.Collected);
            }
        }
        throw new InvalidOperationException("The deterministic RPG never produced impact evidence.");
    }

    private sealed record ReplayResult(int CoverIndex, float MissileDraw, Vector3 BoxPosition,
        Vector3 ImpactPosition, bool IsCollected);

    private sealed record ReplayInput(PvpBonusSpawnArea Area, float MissileDraw, int CoverIndex);
}
