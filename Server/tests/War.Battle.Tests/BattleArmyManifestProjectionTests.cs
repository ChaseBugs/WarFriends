using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Protocol;
using War.Shared;

/// <summary>Checks presentation-ordered army authority through a real recovered mixed-combat host.</summary>
internal static class BattleArmyManifestProjectionTests
{
    private const int StarterUnitCount = 4;
    private static readonly string[] StarterUnitIds =
    ["ID_UNIT-ASSAULT", "ID_UNIT-GRENADIER", "ID_UNIT-MACHINEGUNNER", "ID_UNIT-SHOTGUNNER"];

    internal static int Run(string contentDirectory)
    {
        BattleCombatContent content = LoadContent(contentDirectory);
        JsonObject root = CreateTemplate(content, contentDirectory);
        var catalog = new BattleMixedManifestCatalog(content);
        var allocations = new List<BattleAllocationProjection>();
        var views = new List<BattlePlayerPresentation>();
        foreach (JsonNode? node in root["Players"]!.AsArray())
        {
            JsonObject participant = node!.AsObject();
            string playerId = participant["PlayerId"]!.GetValue<string>();
            BattlePlayerPresentation view = CreateStarterView(playerId);
            views.Add(view);
            catalog.Bind(participant, view);
            Require(participant["EquippedArmyUnitIds"]!.Deserialize<string[]>()!.SequenceEqual(StarterUnitIds),
                "Army unit identities do not match the Client presentation order.");
            allocations.Add(new BattleAllocationProjection(playerId, [], [],
                view.Units.Select(unit => unit.UpgradeIndex).ToArray(),
                view.Units.Select(unit => unit.SpecialIndex).ToArray(),
                view.Units.Select(unit => unit.EliteIndex).ToArray()));
            CheckRejectedMutation(catalog, participant, view);
        }

        catalog.BindArmyCombat(root["Players"]!.AsArray(), views);
        MatchManifest manifest = MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(root));
        content.ValidateAllocation(manifest);
        var map = content.Maps.Single(candidate => candidate.SourceHash == manifest.MapRevision);
        var host = new MatchEngine(manifest, map, content, armyChoice: _ => 0);
        host.ConfigureBattleAllocations(allocations);
        foreach (BattleAllocationProjection allocation in allocations)
        {
            Require(host.Admit(allocation.PlayerId), "Starter army host admission failed.");
            var selection = new SelectCardsCommand();
            selection.NormalUpgradeIndexes.Add(allocation.NormalUpgradeIndexes);
            selection.SpecialUpgradeIndexes.Add(allocation.SpecialUpgradeIndexes);
            selection.EliteUpgradeIndexes.Add(allocation.EliteUpgradeIndexes);
            selection.NormalUpgradeIndexes[0]++;
            Require(host.Command(allocation.PlayerId, new MatchCommand
            {
                CommandId = 1, SelectCards = selection
            }).Code == "invalid-card-selection", "A Client changed the trusted army stage.");
            selection.NormalUpgradeIndexes[0]--;
            Require(host.Command(allocation.PlayerId, new MatchCommand
            {
                CommandId = 2, SelectCards = selection
            }).Code == "cards-selected", "The source starter army echo was rejected.");
        }
        return 14 + VerifySpawnedVitality(host, manifest);
    }

    private static int VerifySpawnedVitality(MatchEngine host, MatchManifest manifest)
    {
        int checks = 0;
        foreach (ParticipantManifest player in manifest.Players)
        {
            Require(host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 3, Ready = new() { ManifestHash = host.ManifestHash }
            }).Code == "ready", "The durable starter host could not acknowledge readiness.");
            checks++;
        }
        host.Advance(60);
        Require(host.Snapshot().Phase == BattlePhase.Running, "The durable starter host did not start.");
        string ownerId = manifest.Players[0].PlayerId;
        Require(host.Command(ownerId, new MatchCommand
        {
            CommandId = 4, DeployArmy = new() { OptionIndex = host.ArmyBatch(ownerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The durable starter deployment was rejected.");
        host.Advance(61);
        var entities = host.ArmyEntityBatch(ownerId, 0, 0).Entities;
        Require(entities.Count > 0, "The durable starter deployment did not spawn an entity.");
        foreach (BattleArmyEntityState entity in entities)
        {
            Require(entity.MaxHealth > 0f && entity.Health > 0f && entity.Health <= entity.MaxHealth &&
                host.ArmyHealth(entity.EntityKey) == entity.Health,
                "A durable starter unit lacks host-owned vitality or publishes an invalid live health row.");
            checks++;
        }
        return checks + 3;
    }

    internal static BattleCombatContent LoadContent(string directory)
    {
        return BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            Path.Combine(directory, "shotgun-content-manifest.json"),
            Path.Combine(directory, "smg-content-manifest.json"),
            Path.Combine(directory, "pistol-content-manifest.json"),
            Path.Combine(directory, "lmg-content-manifest.json"),
            Path.Combine(directory, "minigun-content-manifest.json"),
            Path.Combine(directory, "sniper-content-manifest.json"),
            Path.Combine(directory, "bazooka-content-manifest.json"),
            Path.Combine(directory, "grenade-content-manifest.json"));
    }

    internal static JsonObject CreateTemplate(BattleCombatContent content, string directory)
    {
        JsonObject template = JsonNode.Parse(File.ReadAllBytes(
            Path.Combine(directory, "local-mixed-match-template.json")))!.AsObject();
        template["CatalogRevision"] = content.MixedRevision;
        content.ValidateAllocation(MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(template)));
        return template;
    }

    private static BattlePlayerPresentation CreateStarterView(string playerId)
    {
        return BattlePlayerPresentationSource.Project(new LegacyPlayerDocument
        {
            Id = playerId, Name = "StarterArmy", Country = "US", Level = 1,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        });
    }

    private static void CheckRejectedMutation(BattleMixedManifestCatalog catalog, JsonObject participant,
        BattlePlayerPresentation view)
    {
        Require(view.Units.Count == StarterUnitCount, "The source initial army changed.");
        string before = participant.ToJsonString();
        view.Units[0].UpgradeIndex = 255;
        Reject(() => catalog.Bind(participant, view));
        Require(participant.ToJsonString() == before, "Rejected army authority partially changed a participant.");
        view.Units[0].UpgradeIndex = 0;
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
        throw new InvalidOperationException("An invalid army upgrade reached the battle manifest.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
