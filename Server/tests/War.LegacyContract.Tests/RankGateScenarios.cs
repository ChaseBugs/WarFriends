using War.Backend.Legacy;
using War.Backend.Legacy.Progression;
using War.LegacyContract.Tests.Recovered;
using DatabaseAction = War.Backend.Legacy.DatabaseAction;
using DatabaseResult = War.Backend.Legacy.DatabaseResult;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static class RankGateScenarios
{
    private const int GateDisplayLevel = 10;

    internal static IEnumerable<CatalogBufferScenario> All()
    {
        foreach (DatabaseAction action in new[] { DatabaseAction.BuyWeapon, DatabaseAction.BuyUnit,
            DatabaseAction.BuyDecal, DatabaseAction.PromoteUnit })
        {
            string name = TargetName(action);
            yield return new(action + " rank below displayed requirement", Create(action, name),
                DatabaseResult.NotEnoughLevel, fixture => Arrange(fixture, action, GateDisplayLevel - 2));
            yield return new(action + " rank equals displayed requirement", Create(action, name),
                DatabaseResult.Success, fixture => Arrange(fixture, action, GateDisplayLevel - 1));
        }

        foreach (DatabaseAction action in new[] { DatabaseAction.BuyWeapon, DatabaseAction.BuyUnit,
            DatabaseAction.BuyDecal })
        {
            string prefix = action switch
            {
                DatabaseAction.BuyWeapon => "fixture-weapon-",
                DatabaseAction.BuyUnit => "fixture-unit-",
                _ => "fixture-visual-"
            };
            yield return new(action + " first rank permanent purchase", Create(action, prefix + "free"),
                DatabaseResult.Success, fixture =>
                {
                    fixture.Player.Level = 0;
                    fixture.Levels.SavedWeapons.Remove(prefix + "free");
                    fixture.Levels.SavedArmies.Remove(prefix + "free");
                    fixture.Decals.Visuals.Remove(prefix + "free");
                });
        }

        yield return new("Last display-level tier gate",
            Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.Success, fixture =>
            {
                fixture.Player.Level = 42;
                fixture.OwnUnit();
                fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].Tier = 5;
            });
        yield return new("Below last display-level tier gate",
            Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.NotEnoughLevel, fixture =>
            {
                fixture.Player.Level = 41;
                fixture.OwnUnit();
                fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].Tier = 5;
            });
    }

    internal static void RejectInvalidAuthority()
    {
        foreach ((int rank, int gate) in new[] { (-1, 1), (43, 1), (int.MaxValue, 1), (0, -1) })
        {
            try
            {
                LegacyRankGate.IsUnlocked(rank, gate);
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidOperationException("Invalid rank/gate became unlock authority.");
        }
    }

    internal static void CompareRecoveredRules()
    {
        foreach (int rank in new[] { 0, 1, 8, 9, 38, 39, 41, 42 })
        {
            foreach (int requiredDisplayLevel in new[] { 0, 1, 2, 9, 10, 39, 40, 42, 43, 999 })
            {
                CompareRankLevel(rank, requiredDisplayLevel);
            }
        }
    }

    private static void CompareRankLevel(int rank, int requiredDisplayLevel)
    {
        foreach (string kind in new[] { "weapon", "unit", "visual", "promotion" })
        {
            bool expected = RecoveredRankGateOracle.IsUnlocked(kind, rank, requiredDisplayLevel);
            if (LegacyRankGate.IsUnlocked(rank, requiredDisplayLevel) != expected)
            {
                throw new InvalidOperationException(
                    $"Rank gate differs from Client {kind}: {rank}/{requiredDisplayLevel}.");
            }
        }
    }

    private static string TargetName(DatabaseAction action) => action switch
    {
        DatabaseAction.BuyWeapon => "fixture-weapon-locked",
        DatabaseAction.BuyUnit => "fixture-unit-locked",
        DatabaseAction.BuyDecal => "fixture-visual-locked",
        _ => CatalogBufferFixture.UnitName
    };

    private static void Arrange(CatalogBufferFixture fixture, DatabaseAction action, int rankIndex)
    {
        fixture.Player.Level = rankIndex;
        if (action == DatabaseAction.PromoteUnit)
        {
            fixture.OwnUnit();
        }
    }
}
