using System.Globalization;
using War.Persistence.Legacy.Accounts;

namespace War.Persistence.Legacy.State;

/// <summary>Checks root currency, rank and progression counters without repairing damaged authority.</summary>
public static class LegacyPlayerEconomyAuthority
{
    /// <summary>Google2u.Constants.LeaguePlacementMatches in the recovered 1.4.0 catalog.</summary>
    public const int RecoveredPlacementMatches = 1;
    private const int ClientArmyPowerScale = 10;

    /// <summary>Largest nonnegative power whose recovered Client times-ten projection cannot wrap.</summary>
    public const int MaximumArmyPower = int.MaxValue / ClientArmyPowerScale;

    private const int MaximumBeginnerTier = 3;
    private const int MaximumNormalTier = 16;
    private const int MaximumLeagueIdLength = 256;

    /// <summary>Validates independent global/division medal counts and exact recovered rank/tier domains.</summary>
    public static void Validate(LegacyPlayerDocument player, DateTimeOffset? authorityTime = null)
    {
        if (player.Gold < 0 || player.WarBucks < 0 || player.Tickets < 0 || player.Scraps < 0 ||
            player.Level is < 0 or >= LegacyAccountCreation.RecoveredRankCount ||
            player.LevelExperience < 0 || player.Experience < 0 || player.Reputation < 0 ||
            player.Skill < 0 || player.MedalsBalance < 0 || player.BeginnersLeague is < 0 or > MaximumBeginnerTier ||
            player.PlacementMatchesRequired is < 0 or > RecoveredPlacementMatches ||
            player.SquadPoints < 0 || player.RenameCount < 0 || player.SquadCreationsCount < 0 ||
            player.BattlesLostInRow < 0 || player.Position < 0 || player.Status is < 0 or > 2 || player.LastAction < 0)
        {
            throw new InvalidDataException("Invalid stored legacy wallet/rank/progression authority.");
        }

        player.DailyRewards?.Validate(authorityTime ?? DateTimeOffset.UtcNow);
        ValidateArmyPower(player.ArmyPower);
        ValidateLeagueId(player.LeagueId);
    }

    /// <summary>
    /// DatabasePlayer.armyPowerX10 multiplies a signed Int32; a publishable value must not wrap there.
    /// </summary>
    public static void ValidateArmyPower(int value)
    {
        if (value is < 0 or > MaximumArmyPower)
        {
            throw new InvalidDataException("Army Power exceeds the recovered Client scaling domain.");
        }
    }

    private static void ValidateLeagueId(string? value)
    {
        if (value == null || value.Length > MaximumLeagueIdLength || value.Any(char.IsControl))
        {
            throw new InvalidDataException("Invalid stored legacy league identity.");
        }

        if (value.Length == 0)
        {
            return;
        }

        string tier = value.Split('-')[0];
        if (!int.TryParse(tier, NumberStyles.None, CultureInfo.InvariantCulture, out int parsed) ||
            parsed is < 0 or > MaximumNormalTier || parsed.ToString(CultureInfo.InvariantCulture) != tier)
        {
            throw new InvalidDataException("Stored legacy league has an unknown or ambiguous tier.");
        }
    }
}
