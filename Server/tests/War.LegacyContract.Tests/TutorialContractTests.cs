using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using War.Persistence;
using War.Persistence.Legacy.Tutorial;
using RecoveredTutorialOracle = War.LegacyContract.Tests.Recovered.RecoveredTutorialOracle;

namespace War.LegacyContract.Tests;

/// <summary>Checks exact tutorial BSON/state identity and the unchanged callback's required fields.</summary>
internal static class TutorialContractTests
{
    private static readonly string BattleId = new('a', 32);

    internal static int Run()
    {
        CheckMigrationShapes();
        CheckBsonTypes();
        CheckCommands();
        CheckOriginalCallbacks();
        return 4;
    }

    private static void CheckMigrationShapes()
    {
        LegacyTutorialAuthority.ValidateForRead(new LegacyPlayerDocument());
        LegacyTutorialAuthority.ValidateForRead(new LegacyPlayerDocument { PendingTutorialBattleId = BattleId });
        LegacyTutorialAuthority.ValidateForRead(new LegacyPlayerDocument { TutorialCompleted = true });
        LegacyTutorialAuthority.ValidateForRead(new LegacyPlayerDocument
        {
            PendingTutorialBattleId = BattleId,
            TutorialState = new() { BattleId = BattleId }
        });
        LegacyTutorialAuthority.ValidateForRead(new LegacyPlayerDocument
        {
            TutorialCompleted = true,
            TutorialState = new() { BattleId = BattleId, Completed = true }
        });
        LegacyPlayerDocument[] damaged =
        [
            new() { TutorialCompleted = true, PendingTutorialBattleId = BattleId },
            new() { PendingTutorialBattleId = "bad" },
            new() { TutorialState = new() { BattleId = BattleId } },
            new() { TutorialCompleted = true, TutorialState = new() { BattleId = BattleId } },
            new() { PendingTutorialBattleId = BattleId, TutorialState = new() { Version = 2, BattleId = BattleId } },
            new() { TutorialCompleted = true, TutorialState = new() { BattleId = "bad", Completed = true } }
        ];
        foreach (LegacyPlayerDocument player in damaged)
        {
            Reject(() => LegacyTutorialAuthority.ValidateForRead(player));
        }
    }

    private static void CheckBsonTypes()
    {
        BsonDocument empty = new LegacyPlayerDocument().ToBsonDocument();
        Require(!empty.Contains("TutorialState"), "Absent legacy schema became an explicit null state.");
        BsonValue[] invalid = [0, 1, "true", BsonNull.Value, new BsonDouble(1), new BsonDocument()];
        foreach (BsonValue value in invalid)
        {
            BsonDocument damaged = empty.DeepClone().AsBsonDocument;
            damaged["TutorialCompleted"] = value;
            RejectBson(damaged);
        }

        BsonDocument missing = empty.DeepClone().AsBsonDocument;
        missing.Remove("TutorialCompleted");
        RejectBson(missing);
        foreach (BsonValue value in new BsonValue[] { BsonNull.Value, "{}", new BsonArray(), new BsonDocument() })
        {
            BsonDocument damaged = empty.DeepClone().AsBsonDocument;
            damaged["TutorialState"] = value;
            RejectBson(damaged);
        }

        var pending = new LegacyPlayerDocument
        {
            PendingTutorialBattleId = BattleId,
            TutorialState = new() { BattleId = BattleId }
        };
        BsonDocument canonical = pending.ToBsonDocument();
        LegacyTutorialAuthority.ValidateForRead(BsonSerializer.Deserialize<LegacyPlayerDocument>(canonical));
        foreach (string name in new[] { "Version", "BattleId", "Completed" })
        {
            BsonDocument damaged = canonical.DeepClone().AsBsonDocument;
            damaged["TutorialState"].AsBsonDocument.Remove(name);
            RejectBson(damaged);
        }

        canonical["TutorialState"]["Completed"] = 1;
        RejectBson(canonical);
    }

    private static void CheckCommands()
    {
        LegacyTutorialOperation.Start();
        LegacyTutorialOperation.End(BattleId);
        foreach (string? id in new string?[] { null, "", "null", "bad", BattleId.ToUpperInvariant(), " " + BattleId })
        {
            Reject(() => LegacyTutorialOperation.End(id));
        }
    }

    private static void CheckOriginalCallbacks()
    {
        Require(RecoveredTutorialOracle.Start(new() { ["BattleId"] = BattleId }) == (BattleId, 1),
            "Original start callback did not bind identity before continuing tutorial.");
        Missing(() => RecoveredTutorialOracle.Start(new()));
        var completed = RecoveredTutorialOracle.End(new() { ["LevelExperience"] = 12, ["TutorialData"] = true });
        Require(completed == (12, true, 1, 1), "Original completion excerpt lost XP or its tutorial callbacks.");
        Missing(() => RecoveredTutorialOracle.End(new() { ["TutorialData"] = true }));
        Require(!RecoveredTutorialOracle.End(new() { ["LevelExperience"] = 12 }).Completed,
            "Tutorial was marked complete without the source presence marker.");
        Require(RecoveredTutorialOracle.RejectWrongBattle(), "Original wrong-battle error requires extra fields.");
    }

    private static void RejectBson(BsonDocument value)
    {
        try
        {
            BsonSerializer.Deserialize<LegacyPlayerDocument>(value);
        }
        catch (Exception exception) when (exception is FormatException or BsonSerializationException)
        {
            return;
        }

        throw new InvalidOperationException("Malformed tutorial BSON authority was accepted.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Damaged tutorial identity or mirrors were accepted.");
    }

    private static void Missing(Action action)
    {
        try
        {
            action();
        }
        catch (KeyNotFoundException)
        {
            return;
        }

        throw new InvalidOperationException("A mandatory tutorial callback field was no longer indexed.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
