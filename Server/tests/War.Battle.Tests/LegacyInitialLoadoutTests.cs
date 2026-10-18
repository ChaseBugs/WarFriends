using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Checks source-exact defaults and observes complete initial state in the original account insert.</summary>
internal static class LegacyInitialLoadoutTests
{
    private const int MaximumWatchSeconds = 180;
    private const int InitialSubsystemCount = 3;

    internal static int Run(string contentDirectory)
    {
        LegacyInitialLoadout.Validate();
        JsonNode expected = JsonNode.Parse(File.ReadAllText(
            Path.Combine(contentDirectory, "../docs/client-starter-loadout-observation.json")))
            ?? throw new InvalidDataException("Client starter observation is missing.");
        Dictionary<string, string> first = LegacyInitialLoadout.CreateSerializedState();
        Require(first.Count == InitialSubsystemCount, "Initial state changed unrelated subsystems.");
        foreach (var entry in first)
        {
            Require(JsonNode.DeepEquals(JsonNode.Parse(entry.Value), expected["serialized"]?[entry.Key]),
                "Initial subsystem state differs from the actual Client observation.");
        }
        first["InventoryData"] = "{}";
        first.Clear();
        Dictionary<string, string> second = LegacyInitialLoadout.CreateSerializedState();
        Require(second.Count == InitialSubsystemCount && JsonNode.DeepEquals(JsonNode.Parse(second["InventoryData"]),
            expected["serialized"]?["InventoryData"]), "One account mutated another account's initial state.");
        return 5;
    }

    internal static async Task WatchAccountInsertAsync(string uri, string databaseName, string reportPath)
    {
        var collection = new MongoClient(uri).GetDatabase(databaseName)
            .GetCollection<LegacyPlayerDocument>("legacyPlayers");
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(MaximumWatchSeconds));
        using var cursor = await collection.WatchAsync(cancellationToken: deadline.Token);
        await File.WriteAllTextAsync(reportPath + ".ready", "ready\n", deadline.Token);
        while (await cursor.MoveNextAsync(deadline.Token))
        {
            foreach (var change in cursor.Current)
            {
                if (change.OperationType != ChangeStreamOperationType.Insert)
                {
                    continue;
                }
                VerifyInsertedState(change.FullDocument);
                string report = JsonSerializer.Serialize(new
                {
                    schemaVersion = 1,
                    hasCompleteInitialStateInInsert = true,
                    subsystemCount = InitialSubsystemCount,
                    hasStarterBattlePresentation = true,
                    weaponCount = 4,
                    unitCount = 4
                });
                await File.WriteAllTextAsync(reportPath, report + "\n", deadline.Token);
                Console.WriteLine("PASS: all three source-derived subsystems exist in the original account insert");
                return;
            }
        }
        throw new InvalidDataException("No account insert was observed.");
    }

    private static void VerifyInsertedState(LegacyPlayerDocument player)
    {
        Dictionary<string, string> expected = LegacyInitialLoadout.CreateSerializedState();
        Require(player.Serialized.Count == expected.Count,
            "Initial account insert has incomplete or extra subsystem state.");
        foreach (var entry in expected)
        {
            Require(player.Serialized.TryGetValue(entry.Key, out string? actual) &&
                JsonNode.DeepEquals(JsonNode.Parse(actual), JsonNode.Parse(entry.Value)),
                "Initial subsystem state was absent or changed in the account insert.");
        }
        var presentation = BattlePlayerPresentationSource.Project(player);
        Require(presentation.Weapons.Count == 4 && presentation.Units.Count == 4 &&
            presentation.Units.All(unit => unit.UpgradeIndex == 0 && unit.SpecialIndex == -1 && unit.EliteIndex == -1),
            "The original account insert did not produce the source starter battle presentation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
