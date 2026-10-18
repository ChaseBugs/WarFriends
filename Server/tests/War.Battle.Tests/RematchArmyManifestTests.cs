using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

/// <summary>Checks fresh durable army lanes and rejection boundaries during mixed rematch generation.</summary>
internal static class RematchArmyManifestTests
{
    internal static async Task RunAsync(string uri, string databaseName, string directory)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        CancellationToken cancellationToken = deadline.Token;
        var legacy = new LegacyPlayerStore(uri, databaseName);
        var allocations = new BattleAllocationStore(uri, databaseName);
        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        LegacyPlayerDocument[] players = [CreatePlayer(new string('c', 32)), CreatePlayer(new string('d', 32))];
        foreach (LegacyPlayerDocument player in players)
        {
            await legacy.Insert(player, LegacyPlayerStore.NewPassword(), cancellationToken);
            await PutAllocationAsync(allocations, player, cancellationToken);
        }

        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        var factory = new BattleManifestFactory(File.ReadAllBytes(Path.Combine(directory,
            "local-starter-match-template.json")), allocations, new BattlePlayerPresentationSource(legacy),
            new BattleMixedManifestCatalog(content));
        string[] identities = players.Select(player => player.Id).ToArray();
        byte[] source = await factory.Create(NewMatchId(), identities, cancellationToken);
        MatchManifest previous = MatchManifest.Parse(source);
        await UpgradeArmyAsync(database, players[0], cancellationToken);
        await RejectStaleAllocationAsync(factory, source, cancellationToken);
        await PutAllocationAsync(allocations, players[0], cancellationToken);
        byte[] generated = await factory.CreateRematchAsync(source, previous.Digest(), NewMatchId(), cancellationToken);
        MatchManifest next = MatchManifest.Parse(generated);
        CheckRefreshed(previous, next, source);
        content.ValidateAllocation(next);
        var host = new MatchEngine(next, content: content);
        host.ConfigureBattleAllocations(next.Allocations!);
        await CheckRejectedAsync(factory, previous, cancellationToken);
        Console.WriteLine("PASS: mixed rematch refreshes durable army lanes " +
            "and rejects modifiers/new-unit/shield authority");
    }

    private static LegacyPlayerDocument CreatePlayer(string identity)
    {
        return new LegacyPlayerDocument
        {
            Id = identity, Name = "ArmyRematch", Locale = "en", Country = "US", Level = 1,
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
    }

    private static async Task RejectStaleAllocationAsync(BattleManifestFactory factory, byte[] source,
        CancellationToken cancellationToken)
    {
        try
        {
            await factory.CreateRematchAsync(source, MatchManifest.Parse(source).Digest(),
                NewMatchId(), cancellationToken);
        }
        catch (InvalidDataException exception) when
            (exception.Message == "Rematch army allocation differs from current durable unit lanes.")
        {
            return;
        }

        throw new InvalidOperationException("Rematch accepted stale allocation lanes after a durable army upgrade.");
    }

    private static async Task PutAllocationAsync(BattleAllocationStore store, LegacyPlayerDocument player,
        CancellationToken cancellationToken)
    {
        BattlePlayerPresentation view = BattlePlayerPresentationSource.Project(player);
        await store.Put(new BattleAllocationProjection(player.Id, [], [],
            view.Units.Select(unit => unit.UpgradeIndex).ToArray(),
            view.Units.Select(unit => unit.SpecialIndex).ToArray(),
            view.Units.Select(unit => unit.EliteIndex).ToArray()), cancellationToken);
    }

    private static async Task UpgradeArmyAsync(IMongoDatabase database, LegacyPlayerDocument player,
        CancellationToken cancellationToken)
    {
        BattlePlayerPresentation before = BattlePlayerPresentationSource.Project(player);
        var levels = PlayerState.Read<LevelManagerData>(player.Serialized["LevelManagerData"]);
        levels.SavedArmies[before.Units[0].SourceId].BoughtIndex = 1;
        levels.SavedArmies[before.Units[^1].SourceId].Equipped = false;
        string serialized = PlayerState.Write(levels);
        player.Serialized["LevelManagerData"] = serialized;
        await database.GetCollection<LegacyPlayerDocument>("legacyPlayers").UpdateOneAsync(
            row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set("Serialized.LevelManagerData", serialized),
            cancellationToken: cancellationToken);
    }

    private static void CheckRefreshed(MatchManifest previous, MatchManifest next, byte[] source)
    {
        Require(previous.Players[0].ArmyNormalUpgradeIndexes![0] == 0 &&
            next.Players[0].ArmyNormalUpgradeIndexes![0] == 1,
            "Rematch reused the accepted battle's old army upgrade.");
        Require(next.Players[0].ArmySpecialUpgradeIndexes!.All(index => index == -1) &&
            next.Players[0].ArmyEliteUpgradeIndexes!.All(index => index == -1),
            "Rematch invented purchased special or Elite lanes.");
        Require(next.Players.Select(player => player.PlayerId)
            .SequenceEqual(previous.Players.Select(player => player.PlayerId)) &&
            next.Players[0].EquippedArmyUnitIds!.SequenceEqual(previous.Players[0].EquippedArmyUnitIds!
                .Take(previous.Players[0].EquippedArmyUnitIds!.Length - 1)),
            "Rematch did not refresh the unequipped unit while preserving participant and source order.");
        Require(MatchManifest.Parse(source).Digest() == previous.Digest(),
            "Army refresh mutated the accepted source bytes.");
    }

    private static async Task CheckRejectedAsync(BattleManifestFactory factory, MatchManifest previous,
        CancellationToken cancellationToken)
    {
        string[] fields = ["ArmyHealthFactors", "ArmyDamageScales", "ArmySpeedCoefficients",
            "ArmyAccuracyCoefficients", "ArmyShotSpeedCoefficients", "NewArmyUnitIds", "ShieldLevel"];
        foreach (string field in fields)
        {
            JsonObject source = JsonSerializer.SerializeToNode(previous)!.AsObject();
            int count = previous.Players[0].EquippedArmyUnitIds!.Length;
            JsonNode value = field switch
            {
                "ArmyHealthFactors" => JsonSerializer.SerializeToNode(
                    Enumerable.Repeat(new ArmyHealthFactors(1, 1), count))!,
                "NewArmyUnitIds" => JsonSerializer.SerializeToNode(previous.Players[0].EquippedArmyUnitIds)!,
                "ShieldLevel" => JsonValue.Create(0)!,
                _ => JsonSerializer.SerializeToNode(Enumerable.Repeat(1f, count))!
            };
            foreach (JsonNode? participant in source["Players"]!.AsArray())
            {
                participant![field] = value.DeepClone();
            }

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(source);
            string hash = MatchManifest.Parse(bytes).Digest();
            try
            {
                await factory.CreateRematchAsync(bytes, hash, NewMatchId(), cancellationToken);
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidDataException("Rematch accepted unrefreshable authority: " + field);
        }
    }

    private static string NewMatchId()
    {
        return "m" + Guid.NewGuid().ToString("N");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
