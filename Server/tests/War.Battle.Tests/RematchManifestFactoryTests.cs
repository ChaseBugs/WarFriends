using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

/// <summary>Checks current durable equipment against ordered source manifests on real MongoDB.</summary>
internal static class RematchManifestFactoryTests
{
    private const string RifleId = "Google2u.AssaultRifle_AK47";

    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_rematch_manifest_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        try
        {
            var legacy = new LegacyPlayerStore(uri, databaseName);
            var allocations = new BattleAllocationStore(uri, databaseName);
            await legacy.Initialize(deadline.Token);
            await allocations.Initialize(deadline.Token);
            string[] players = [new string('b', 32), new string('a', 32)];
            foreach (string playerId in players)
            {
                await SeedAsync(legacy, playerId, deadline.Token);
                await allocations.Put(new BattleAllocationProjection(playerId, [], [], [], [], []), deadline.Token);
            }
            string content = FindContent();
            var factory = new BattleManifestFactory(File.ReadAllBytes(Path.Combine(content,
                "local-rifle-match-template.json")), allocations, new BattlePlayerPresentationSource(legacy),
                BattleRifleManifestCatalog.Load(Path.Combine(content, "combat-content-manifest.json")));
            string sourceId = "m" + Guid.NewGuid().ToString("N");
            JsonObject source = JsonNode.Parse(await factory.Create(sourceId, players, deadline.Token))!.AsObject();
            source["SceneMasterPlayerId"] = players[1];
            foreach (JsonNode? player in source["Players"]!.AsArray())
            {
                player!["PlayerLevel"] = 1;
            }
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(source);
            var snapshots = new BattleManifestSnapshotStore(uri, databaseName);
            await snapshots.GetOrCreate(sourceId, players, () => Task.FromResult(bytes), deadline.Token);
            byte[] saved = await snapshots.GetForParticipantsAsync(
                sourceId, players.Reverse().ToArray(), deadline.Token)
                ?? throw new InvalidDataException("Ordered source snapshot is missing.");
            await UpdateEquipmentAsync(mongo.GetDatabase(databaseName), players[0], deadline.Token);
            await VerifyRebindingAsync(factory, saved, players, deadline.Token);
            Require(saved.SequenceEqual(bytes), "Rematch generation must not mutate source snapshot bytes.");
            await RematchArmyManifestTests.RunAsync(uri, databaseName, content);
            Console.WriteLine("PASS: rematch source hash, slot/master preservation, " +
                "current equipment and stale-authority rejection");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    private static async Task VerifyRebindingAsync(
        BattleManifestFactory factory, byte[] source, string[] players, CancellationToken cancellationToken)
    {
        MatchManifest previous = MatchManifest.Parse(source);
        string nextId = "m" + Guid.NewGuid().ToString("N");
        PreparedBattleManifest prepared = await factory.PrepareRematchAsync(
            source, previous.Digest(), nextId, cancellationToken);
        byte[] generated = prepared.Manifest;
        Require(prepared.AccountRevisions.Select(row => row.PlayerId).SequenceEqual(players) &&
            prepared.AccountRevisions[0].Revision == 2 && prepared.AccountRevisions[1].Revision == 1,
            "Prepared rematch lost its exact source-ordered account revisions.");
        MatchManifest next = MatchManifest.Parse(generated);
        Require(next.MatchId == nextId && next.MapId == previous.MapId && next.MapRevision == previous.MapRevision &&
            next.Mode == previous.Mode && next.SceneMasterPlayerId == players[1] &&
            next.Players.Select(player => player.PlayerId).SequenceEqual(players),
            "A new match must preserve the original map, mode, scene master and player order.");
        for (int index = 0; index < players.Length; index++)
        {
            Require(next.Players[index].Fraction == previous.Players[index].Fraction &&
                next.Players[index].StartCover == previous.Players[index].StartCover,
                "Rematch must preserve each participant's source placement.");
        }
        Require(next.Players[0].WeaponUpgrade == 1 && next.Players[0].PlayerLevel == 2 &&
            next.Presentations?[0].DisplayName == "UpdatedPlayer" && next.Presentations[0].Level == 2 &&
            previous.Players[0].WeaponUpgrade == 0 && previous.Players[0].PlayerLevel == 1,
            "New equipment and rank must come from current durable state, not the accepted snapshot.");
        await RejectAsync(() => factory.CreateRematchAsync(source, new string('0', 64), nextId, cancellationToken));
        await RejectAsync(() => factory.CreateRematchAsync(
            source, previous.Digest(), previous.MatchId, cancellationToken));
        MatchManifest staleShield = previous with
        {
            Players = previous.Players.Select(player => player with { ShieldLevel = 0 }).ToArray(),
        };
        await RejectAsync(() => factory.CreateRematchAsync(JsonSerializer.SerializeToUtf8Bytes(staleShield),
            staleShield.Digest(), nextId, cancellationToken));
        MatchManifest staleArmy = previous with
        {
            Players = previous.Players.Select(player => player with
            {
                EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
                ArmyNormalUpgradeIndexes = [0],
                ArmySpecialUpgradeIndexes = [-1],
                ArmyEliteUpgradeIndexes = [-1]
            }).ToArray()
        };
        await RejectAsync(() => factory.CreateRematchAsync(JsonSerializer.SerializeToUtf8Bytes(staleArmy),
            staleArmy.Digest(), nextId, cancellationToken));
    }

    private static async Task SeedAsync(LegacyPlayerStore store, string playerId, CancellationToken cancellationToken)
    {
        var decals = new DecalManagerData();
        for (int slot = 0; slot < 4; slot++)
        {
            decals.Slots[slot] = new SavedPlayerVisualSlot { EquippedId = "VISUAL_" + slot };
        }
        var inventory = new InventoryData();
        inventory.Slots[0] = new SerializedSlotDetail { Name = RifleId, WeaponIndex = 1 };
        var levels = new LevelManagerData();
        levels.SavedWeapons[RifleId] = new SavedWeaponSlots { Bought = true, BoughtIndex = 0 };
        await store.Insert(new LegacyPlayerDocument
        {
            Id = playerId, Name = "OriginalPlayer", Locale = "en", Country = "US", Level = 1,
            ArmyPower = 1, LeagueId = "1-local", CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            Serialized = new Dictionary<string, string>
            {
                ["DecalManagerData"] = PlayerState.Write(decals),
                ["InventoryData"] = PlayerState.Write(inventory),
                ["LevelManagerData"] = PlayerState.Write(levels),
            },
        }, LegacyPlayerStore.NewPassword(), cancellationToken);
    }

    private static async Task UpdateEquipmentAsync(IMongoDatabase database, string playerId,
        CancellationToken cancellationToken)
    {
        var levels = new LevelManagerData();
        levels.SavedWeapons[RifleId] = new SavedWeaponSlots { Bought = true, BoughtIndex = 1 };
        await database.GetCollection<LegacyPlayerDocument>("legacyPlayers").UpdateOneAsync(
            player => player.Id == playerId,
            Builders<LegacyPlayerDocument>.Update.Set("Serialized.LevelManagerData", PlayerState.Write(levels))
                .Set(player => player.Name, "UpdatedPlayer").Set(player => player.Level, 2)
                .Inc(player => player.Revision, 1),
            cancellationToken: cancellationToken);
    }

    private static string FindContent()
    {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);
        while (directory != null)
        {
            string content = Path.Combine(directory.FullName, "content");
            if (File.Exists(Path.Combine(content, "local-rifle-match-template.json")))
            {
                return content;
            }
            directory = directory.Parent;
        }
        throw new FileNotFoundException("Reviewed combat content is absent.");
    }

    private static async Task RejectAsync(Func<Task<byte[]>> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidDataException("Invalid rematch source was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
