using System.Text.Json;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Checks source availability across rank, purchase, borrowing and tutorial contexts.</summary>
internal static class BattleWeaponOwnershipTests
{
    private const int RankCount = 43;
    private const int FlagCombinationCount = 4;
    private const string TutorialWeapon = "Google2u.Grenade_FRAG";

    internal static int Run(string contentDirectory)
    {
        BattleWeaponOwnership.Validate();
        using JsonDocument observation = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(contentDirectory, "../docs/client-starter-loadout-observation.json")));
        int observedRank = observation.RootElement.GetProperty("context").GetProperty("rankIndex").GetInt32();
        int checks = 0;
        foreach (JsonElement weapon in observation.RootElement.GetProperty("weapons").EnumerateArray())
        {
            string sourceId = weapon.GetProperty("sourceId").GetString() ?? "";
            var initial = new SavedWeaponSlots();
            Require(BattleWeaponOwnership.IsAvailable(sourceId, initial, new(observedRank, false)) ==
                weapon.GetProperty("isBought").GetBoolean(),
                "Availability differs from the actual Client observation.");
            checks++;
            checks += CheckRankAndFlagMatrix(weapon);
        }

        Reject(() => BattleWeaponOwnership.IsAvailable(TutorialWeapon, new(), new(-1, false)));
        Reject(() => BattleWeaponOwnership.IsAvailable(TutorialWeapon, new(), new(RankCount, false)));
        Reject(() => BattleWeaponOwnership.IsAvailable("unknown-source", new(), new(0, false)));
        CheckInitialWeaponProjection();
        return checks + 6;
    }

    private static int CheckRankAndFlagMatrix(JsonElement weapon)
    {
        string sourceId = weapon.GetProperty("sourceId").GetString() ?? "";
        bool isTutorialWeapon = weapon.GetProperty("isTutorialWeapon").GetBoolean();
        bool isFree = weapon.GetProperty("hasImplicitFreeOwnership").GetBoolean();
        int minimumRank = weapon.GetProperty("minimumPurchaseRankIndex").GetInt32();
        int checks = 0;
        for (int rankIndex = 0; rankIndex < RankCount; rankIndex++)
        {
            for (int flags = 0; flags < FlagCombinationCount; flags++)
            {
                var saved = new SavedWeaponSlots { Bought = (flags & 1) != 0, Borrowed = (flags & 2) != 0 };
                foreach (bool isTutorial in new[] { false, true })
                {
                    bool expected;
                    if (isTutorialWeapon)
                    {
                        expected = !isTutorial || saved.Bought;
                    }
                    else
                    {
                        expected = isFree || saved.Borrowed || (saved.Bought && rankIndex >= minimumRank);
                    }

                    bool actual = BattleWeaponOwnership.IsAvailable(sourceId, saved, new(rankIndex, isTutorial));
                    Require(actual == expected, "Weapon availability differs from the recovered branch contract.");
                    Require(saved.Bought == ((flags & 1) != 0) && saved.Borrowed == ((flags & 2) != 0),
                        "Availability evaluation changed a durable ownership flag.");
                    checks += 2;
                }
            }
        }

        return checks;
    }

    private static void CheckInitialWeaponProjection()
    {
        var player = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "StarterWeaponTest", Country = "US", Level = 1,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
        LevelManagerData levels = PlayerState.Read<LevelManagerData>(player.Serialized["LevelManagerData"]);
        // Unit ownership and upgrade lane projection are separate work; isolate the four real initial weapons.
        foreach (SavedArmySlots unit in levels.SavedArmies.Values)
        {
            unit.Equipped = false;
        }
        player.Serialized["LevelManagerData"] = PlayerState.Write(levels);

        var presentation = BattlePlayerPresentationSource.Project(player);
        Require(presentation.Weapons.Count == 4 && presentation.Weapons.Any(weapon =>
            weapon.SourceId == TutorialWeapon && weapon.WeaponIndex == 5),
            "Initial free/tutorial weapons did not pass the normal battle projection.");

        const string PaidRifle = "Google2u.AssaultRifle_M16";
        InventoryData inventory = PlayerState.Read<InventoryData>(player.Serialized["InventoryData"]);
        inventory.Slots[0] = new SerializedSlotDetail { Name = PaidRifle, WeaponIndex = 0 };
        player.Serialized["InventoryData"] = PlayerState.Write(inventory);
        Reject(() => BattlePlayerPresentationSource.Project(player));

        levels.SavedWeapons[PaidRifle].Borrowed = true;
        player.Serialized["LevelManagerData"] = PlayerState.Write(levels);
        Require(BattlePlayerPresentationSource.Project(player).Weapons[0].SourceId == PaidRifle,
            "A durable borrowed weapon was rejected by normal presentation.");
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
        throw new InvalidOperationException("An invalid ownership identity or rank was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
