using War.Backend.Legacy;
using War.Backend.Legacy.Catalog;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.State;

namespace War.Backend.Features.Battle.Settlement;

/// <summary>Applies earned server XP using the recovered zero-based rank and per-rank thresholds.</summary>
public sealed class BattleRankProgression
{
    private readonly RankDefinition[] _ranks;

    private sealed record RankDefinition(int Experience, int Gold, int WarBucks, int ArmyPower);

    public BattleRankProgression(LegacyCatalog catalog)
    {
        IReadOnlyList<LegacyCatalogRow> rows = catalog.Sheet("Google2u.Levels");
        if (rows.Count != LegacyAccountCreation.RecoveredRankCount)
        {
            throw new InvalidDataException("Battle progression requires all recovered rank rows.");
        }

        _ranks = new RankDefinition[rows.Count];
        long totalGold = 0;
        long totalWarBucks = 0;
        for (int index = 0; index < rows.Count; index++)
        {
            _ranks[index] = ReadRank(rows[index], index);
            totalGold += _ranks[index].Gold;
            totalWarBucks += _ranks[index].WarBucks;
            if (index > 0 && _ranks[index].ArmyPower < _ranks[index - 1].ArmyPower)
            {
                throw new InvalidDataException("Recovered rank power must not decrease.");
            }
        }

        if (totalGold > int.MaxValue || totalWarBucks > int.MaxValue)
        {
            throw new InvalidDataException("Rank rewards exceed the Client result counter domain.");
        }
    }

    public BattleRankAdvance Apply(BattleRankSnapshot current, int earnedExperience)
    {
        Validate(current, earnedExperience);
        int level = current.Level;
        long remaining = (long)current.LevelExperience + earnedExperience;
        int gold = 0;
        int warBucks = 0;
        while (level < _ranks.Length - 1 && remaining >= _ranks[level].Experience)
        {
            RankDefinition completed = _ranks[level];
            remaining -= completed.Experience;
            // GameEnded's LevelReward assertion uses currentLevel.golds. The server selects that row;
            // the submitted amount is never used. Each crossed threshold earns its completed row once.
            gold = checked(gold + completed.Gold);
            warBucks = checked(warBucks + completed.WarBucks);
            level++;
        }

        // The final rank has no successor. Retain earned XP without issuing its reward repeatedly.
        // This is explicit offline progression policy; original server cap behavior is unavailable.
        if (remaining > int.MaxValue || current.Experience > long.MaxValue - earnedExperience)
        {
            throw new InvalidDataException("Earned battle experience exceeds the Client counter domain.");
        }

        return new BattleRankAdvance
        {
            Rank = new(level, (int)remaining, current.Experience + earnedExperience),
            LevelsGained = level - current.Level,
            GoldReward = gold,
            WarBucksReward = warBucks,
            RankPowerIncrease = _ranks[level].ArmyPower - _ranks[current.Level].ArmyPower
        };
    }

    private void Validate(BattleRankSnapshot current, int earnedExperience)
    {
        if (current.Level < 0 || current.Level >= _ranks.Length || current.LevelExperience < 0 ||
            current.Experience < 0 || earnedExperience < 0 ||
            (current.Level < _ranks.Length - 1 && current.LevelExperience >= _ranks[current.Level].Experience))
        {
            throw new InvalidDataException("Invalid server-owned battle rank state or earned XP.");
        }
    }

    private static RankDefinition ReadRank(LegacyCatalogRow row, int index)
    {
        int level = ReadNonnegative(row, "LEVEL");
        int experience = ReadNonnegative(row, "EXPERIENCE");
        int gold = ReadNonnegative(row, "REWARDGOLD");
        int warBucks = ReadNonnegative(row, "REWARDWARBUCKS");
        int power = ReadNonnegative(row, "ARMYPOWER");
        if (level != index + 1 || experience == 0)
        {
            throw new InvalidDataException("Rank row identity or experience threshold is invalid.");
        }

        LegacyPlayerEconomyAuthority.ValidateArmyPower(power);
        return new(experience, gold, warBucks, power);
    }

    private static int ReadNonnegative(LegacyCatalogRow row, string field)
    {
        int value = row[field]?.GetValue<int>() ?? throw new InvalidDataException("Missing rank field: " + field);
        if (value < 0)
        {
            throw new InvalidDataException("Negative rank field: " + field);
        }

        return value;
    }
}
