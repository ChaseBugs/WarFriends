using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Verifies source-bound player missile rows and reliable launch/impact metadata.</summary>
internal static class BazookaPresentationTests
{
    private const ulong RunningTick = 60;
    private const ulong ImpactDeadline = 500;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory, "bazooka-content-manifest.json"));
        MatchManifest template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        RecoveredBattleMap map = content.Maps.Single(row => row.SourceHash == template.MapRevision);
        int checks = 0;
        foreach (BazookaBinding binding in content.Bazookas!.Bindings)
        {
            Require(BazookaSourceIdentity.TryGetInventoryIndex(binding.SourceId, out int inventoryIndex) &&
                inventoryIndex == binding.InventoryIndex, "Portable source identity must bind the reviewed inventory.");
            MatchManifest manifest = CreateManifest(template, content, binding.SourceId);
            var match = new MatchEngine(manifest, map, content, combatRandom: () => 0.5f);
            Start(match, manifest);
            string ownerId = manifest.Players[0].PlayerId;
            var hold = new MatchCommand
            {
                CommandId = 2,
                BazookaHold = new BazookaHoldCommand { Pressed = true, TargetX = 0, TargetY = 2, TargetZ = 0 }
            };
            Require(match.Command(ownerId, hold).Code == "bazooka-targeting", "Source missile hold is accepted.");
            var observed = new Dictionary<ulong, string>();
            for (ulong tick = RunningTick + 1; tick <= ImpactDeadline; tick++)
            {
                match.Advance(tick);
                MatchSnapshot snapshot = match.Snapshot();
                BattleProjectileRowPolicy.ValidateSnapshot(snapshot);
                foreach (BattleProjectileState row in snapshot.Projectiles)
                {
                    Require(row.WeaponSourceId == binding.SourceId, "Every flight row retains its launch weapon.");
                    if (!observed.ContainsKey(row.ProjectileId))
                    {
                        Require(row.VelocityX != 0 || row.VelocityY != 0 || row.VelocityZ != 0,
                            "The launch frame must preserve the source's initial missile facing.");
                    }

                    observed[row.ProjectileId] = row.Kind;
                }
            }

            Require(observed.Count == binding.ProjectileCount, "Every real/fake source missile reaches presentation.");
            Require(observed.Values.Count(kind => kind == "bazooka-fake") ==
                (binding.SourceId == "Google2u.Bazooka_M202" ? 2 : 0), "Only M202 has two harmless source missiles.");
            VerifyEvents(match, ownerId, binding);
            checks += 5;
        }

        VerifyMalformedMetadata();
        Console.WriteLine("PASS: source-bound missile rows and reliable events for all seven player bazookas");
        return checks + 2;
    }

    private static MatchManifest CreateManifest(MatchManifest template, BattleCombatContent content, string sourceId)
    {
        return template with
        {
            MatchId = "bazooka-presentation-" + sourceId.Substring("Google2u.Bazooka_".Length).ToLowerInvariant(),
            Mode = MatchManifest.BazookaCombatMode,
            CatalogRevision = content.BazookaRevision!,
            Players = template.Players.Select(player => player with
            {
                Weapon = content.Bazookas!.CreateManifest(sourceId, 0),
                WeaponUpgrade = 0,
                Combat = new PlayerCombatManifest(1_000_000)
            }).ToArray()
        };
    }

    private static void Start(MatchEngine match, MatchManifest manifest)
    {
        foreach (ParticipantManifest player in manifest.Players)
        {
            match.Admit(player.PlayerId);
            match.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
            });
        }

        match.Advance(RunningTick);
    }

    private static void VerifyEvents(MatchEngine match, string ownerId, BazookaBinding binding)
    {
        var consumer = new MatchEventConsumer();
        var received = new List<MatchEvent>();
        consumer.EventReceived += received.Add;
        while (true)
        {
            MatchEventBatch page = match.EventBatch(ownerId, consumer.LastEventId);
            if (page.Events.Count == 0)
            {
                break;
            }

            consumer.Consume(page);
        }

        MatchEvent[] missileEvents = received.Where(row => row.Reason == "bazooka" ||
            row.Reason == "bazooka-fake").ToArray();
        Require(missileEvents.Count(row => row.Kind == MatchEventKind.Shot) == binding.ProjectileCount &&
            missileEvents.Count(row => row.Kind == MatchEventKind.Impact) == binding.ProjectileCount &&
            missileEvents.All(row => row.WeaponSourceId == binding.SourceId),
            "Reliable events retain every source missile's launch identity through impact.");
    }

    private static void VerifyMalformedMetadata()
    {
        var invalid = new MatchSnapshot();
        invalid.Projectiles.Add(new BattleProjectileState
        {
            ProjectileId = 1, OwnerPlayerId = new string('a', 32), Kind = "bazooka-fake",
            WeaponSourceId = "Google2u.Bazooka_RPG7"
        });
        try
        {
            BattleProjectileRowPolicy.ValidateSnapshot(invalid);
            throw new Exception("An ordinary RPG cannot publish a fake missile.");
        }
        catch (InvalidOperationException)
        {
            // The source only gives M202 a real/fake sub-volley.
        }

        var batch = new MatchEventBatch { Code = "events", LatestEventId = 1 };
        batch.Events.Add(new MatchEvent { EventId = 1, Kind = MatchEventKind.Impact, Reason = "bazooka" });
        var consumer = new MatchEventConsumer();
        try
        {
            consumer.Consume(batch);
            throw new Exception("An impact without launch identity cannot select an explosion.");
        }
        catch (InvalidDataException)
        {
            Require(consumer.LastEventId == 0, "Rejected launch metadata must not consume the event cursor.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
