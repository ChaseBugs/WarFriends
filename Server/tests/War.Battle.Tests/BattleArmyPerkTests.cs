using System.Text.Json;
using System.Text.Json.Nodes;

using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

namespace War.Battle.Tests;

/// <summary>Checks source faction selection, rounded compound factors and malformed upgrade rejection.</summary>
internal static class BattleArmyPerkTests
{
    private const int FirstShotgunnerElite = 127;
    private const int FirstSniperElite = 117;
    private const int FirstGrenadierElite = 127;
    private const int FirstParatrooperElite = 117;
    private const int FirstEngineerElite = 102;
    private const int FirstAssaultHelicopterElite = 102;
    private static int _checks;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        BattleArmyPerkCatalog catalog = BattleArmyPerkCatalog.Recovered;
        BattlePlayerPresentation owner = CreatePlayer(content.Army, new string('a', 32));
        BattlePlayerPresentation opponent = CreatePlayer(content.Army, new string('b', 32));
        VerifyNeutral(catalog, content.Army, owner, opponent);
        VerifyCombined(catalog, content.Army, owner, opponent);
        VerifyRejectedInputs(catalog, content.Army, directory);
        VerifySourceSnapshot(catalog, content.Army, directory);
        VerifyProjectionRefresh(content, owner, opponent, directory);
        Console.WriteLine($"PASS: {_checks} bilateral recovered army perk checks.");
        return _checks;
    }

    private static BattlePlayerPresentation CreatePlayer(ArmyDeploymentCatalog army, string identity)
    {
        var account = new LegacyPlayerDocument
        {
            Id = identity, Name = "ArmyPerkFixture", Country = "US", Level = 22,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
        BattlePlayerPresentation view = BattlePlayerPresentationSource.Project(account);
        // Synthetic trusted equipment exercises every target type without altering a durable account.
        view.Units = army.Families.Select(family => new BattleUnitPresentation(family.SheetRow, 0, -1, -1, 1))
            .ToArray();
        return view;
    }

    private static void VerifyNeutral(BattleArmyPerkCatalog catalog, ArmyDeploymentCatalog army,
        BattlePlayerPresentation owner, BattlePlayerPresentation opponent)
    {
        var factors = catalog.Calculate(army, owner, opponent);
        Require(factors.Count == army.Families.Count, "All equipped target families need a factor row.");
        foreach (var row in factors.Values)
        {
            Require(row.Health == 1f && row.Accuracy == 1f && row.ShotSpeed == 1f && row.Speed == 1f &&
                row.BuffCount == 0 && row.DebuffCount == 0, "Non-elite units must retain source neutral coefficients.");
        }
        owner.Units[0].UpgradeIndex = 1;
        Require(factors.Values.All(row => row.Health == 1f), "Published factors must not retain mutable unit inputs.");
        owner.Units[0].UpgradeIndex = 0;
        try
        {
            ((IDictionary<string, BattleArmyPerkCatalog.Factors>)factors).Clear();
            throw new InvalidOperationException("The factor dictionary was mutable.");
        }
        catch (NotSupportedException)
        {
            _checks++;
        }
    }

    private static void VerifyCombined(BattleArmyPerkCatalog catalog, ArmyDeploymentCatalog army,
        BattlePlayerPresentation owner, BattlePlayerPresentation opponent)
    {
        SetElite(owner, "Google2u.DBUpgradeSlotsSniper", FirstSniperElite);
        SetElite(owner, "Google2u.DBUpgradeSlotsAssaultHeli", FirstAssaultHelicopterElite);
        SetElite(opponent, "Google2u.DBUpgradeSlotsShotgunner", FirstShotgunnerElite);
        SetElite(opponent, "Google2u.DBUpgradeSlotsGrennader", FirstGrenadierElite);
        SetElite(opponent, "Google2u.DBUpgradeSlotsParachuter", FirstParatrooperElite);
        SetElite(opponent, "Google2u.DBUpgradeSlotsEngineer", FirstEngineerElite);
        var result = catalog.Calculate(army, owner, opponent);
        var humvee = result["ID_UNIT-HUMVEE"];
        float expectedAccuracy = 1.1f;
        expectedAccuracy = 0.9f * expectedAccuracy;
        Require(humvee.Health == 1f - 0.06f && humvee.ShotSpeed == 1f - 0.14f,
            "Enemy Shotgunner and Paratrooper must affect the source mechanical target set.");
        Require(BitConverter.SingleToInt32Bits(humvee.Accuracy) == BitConverter.SingleToInt32Bits(expectedAccuracy),
            "Ally Sniper then enemy Grenadier must retain source binary32 multiplication.");
        Require(humvee.BuffCount == 1 && humvee.DebuffCount == 3, "Contributing source perk counts are incorrect.");
        Require(result["ID_UNIT-ASSAULT"].Health == 1f && result["ID_UNIT-SHOTGUNNER"].Speed == 1.1f,
            "A perk must not affect a different source target category.");
        Require(result["ID_UNIT-DRONE"].Health == 0.9f && result["ID_UNIT-DRONE"].DebuffCount == 2,
            "Enemy Engineer health and Grenadier accuracy must combine for the Drone.");
        var reverse = catalog.Calculate(army, opponent, owner);
        Require(reverse["ID_UNIT-HUMVEE"].Health == 1f && reverse["ID_UNIT-HUMVEE"].Accuracy == 1f,
            "Own debuffs and opposing buffs must not leak across factions.");
    }

    private static void VerifyRejectedInputs(BattleArmyPerkCatalog catalog, ArmyDeploymentCatalog army,
        string directory)
    {
        BattlePlayerPresentation owner = CreatePlayer(army, new string('c', 32));
        BattlePlayerPresentation opponent = CreatePlayer(army, new string('d', 32));
        Reject(() => catalog.Calculate(army, owner, owner));
        SetElite(owner, "Google2u.DBUpgradeSlotsAssaulter", 0);
        Reject(() => catalog.Calculate(army, owner, opponent));
        SetElite(owner, "Google2u.DBUpgradeSlotsAssaulter", -1);
        owner.Units[0].SourceId = "unknown-unit";
        Reject(() => catalog.Calculate(army, owner, opponent));
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "recovered-army-perks.json"));
        byte[] damaged = bytes.ToArray();
        damaged[^1] ^= 1;
        Reject(() => BattleArmyPerkCatalog.Parse(damaged));
        var parsed = BattleArmyPerkCatalog.Parse(bytes);
        bytes.AsSpan().Clear();
        owner = CreatePlayer(army, new string('c', 32));
        Require(parsed.Calculate(army, owner, opponent).Count == army.Families.Count,
            "Parsed recipes must own their bytes independently of a caller buffer.");
    }

    private static void SetElite(BattlePlayerPresentation view, string sourceId, int index)
    {
        view.Units.Single(unit => unit.SourceId == sourceId).EliteIndex = index;
    }

    private static void VerifySourceSnapshot(BattleArmyPerkCatalog catalog, ArmyDeploymentCatalog reference,
        string directory)
    {
        string definitionPath = Path.Combine(directory, "recovered-army-deployment.json");
        using JsonDocument definition = JsonDocument.Parse(File.ReadAllBytes(definitionPath));
        var army = ArmyDeploymentCatalog.Load(definitionPath, reference.Revision,
            definition.RootElement.GetProperty("sceneSha256").GetString()!);
        Reject(() => catalog.ValidateSource(army));
        string sourcePath = Path.Combine(directory, "recovered-battle-content.json");
        string local = Directory.CreateTempSubdirectory("warfriends-perk-source-").FullName;
        string changedPath = Path.Combine(local, "changed-source.json");
        try
        {
            JsonObject changed = JsonNode.Parse(File.ReadAllBytes(sourcePath))!.AsObject();
            changed["client"] = "different-source-snapshot";
            File.WriteAllText(changedPath, changed.ToJsonString());
            army.ValidateSourceSheet(changedPath);
            Reject(() => catalog.ValidateSource(army));
            army.ValidateSourceSheet(sourcePath);
            catalog.ValidateSource(army);
            Require(army.SourceSheetRevision == reference.SourceSheetRevision,
                "Only the exact validated source-table snapshot may authorize recovered perk recipes.");
        }
        finally
        {
            if (File.Exists(changedPath))
            {
                File.Delete(changedPath);
            }
            Directory.Delete(local);
        }
    }

    private static void VerifyProjectionRefresh(BattleCombatContent content, BattlePlayerPresentation owner,
        BattlePlayerPresentation opponent, string directory)
    {
        JsonObject source = BattleArmyManifestProjectionTests.CreateTemplate(content, directory);
        JsonArray participants = source["Players"]!.AsArray();
        var catalog = new BattleMixedManifestCatalog(content);
        BattlePlayerPresentation[] views = [owner, opponent];
        for (int index = 0; index < views.Length; index++)
        {
            participants[index]!["PlayerId"] = views[index].PlayerId;
            catalog.Bind(participants[index]!.AsObject(), views[index]);
        }
        catalog.BindArmyCombat(participants, views);
        JsonNode expectedPlayers = participants.DeepClone();
        source["Presentations"] = JsonSerializer.SerializeToNode(views);
        MatchManifest accepted = MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(source));
        content.ValidateAllocation(accepted);
        Require(accepted.Players.All(player => player.ArmyHealthFactors?.Length == player.EquippedArmyUnitIds?.Length),
            "Combat projection must cover every equipped target in presentation order.");
        JsonObject damaged = source.DeepClone().AsObject();
        damaged["Players"]![1]!["ArmyHealthFactors"]![0]!["PerkCoefficient"] = 2f;
        string before = damaged.ToJsonString();
        Reject(() => catalog.PrepareArmyCombatRefresh(damaged, accepted));
        Require(damaged.ToJsonString() == before, "Rejected combat refresh partially removed accepted authority.");
        catalog.PrepareArmyCombatRefresh(source, accepted);
        Require(source["Players"]!.AsArray().All(player => player!["ArmyHealthFactors"] == null &&
            player["ArmyNormalUpgradeIndexes"] != null), "Refresh must release only generated combat lanes.");
        catalog.BindArmyCombat(source["Players"]!.AsArray(), views);
        Require(JsonNode.DeepEquals(source["Players"], expectedPlayers),
            "Identical current authority must rebuild identical accepted combat rows.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception failure) when (failure is InvalidDataException or ArgumentOutOfRangeException)
        {
            _checks++;
            return;
        }
        throw new InvalidOperationException("Malformed army perk authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        _checks++;
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
