using System;
using System.Collections.Generic;
using War.Protocol;
using War.Shared;

/// <summary>Reads infantry upgrades from immutable owner-bound admission views instead of local inventory.</summary>
public sealed class SelfHostedInfantryUpgradeSelection
{
    private const int RequiredPlayerCount = 2;
    private readonly Dictionary<string, BattlePlayerView> _players =
        new Dictionary<string, BattlePlayerView>(StringComparer.Ordinal);

    /// <summary>Copies the validated two-player admission roster before any infantry is displayed.</summary>
    public SelfHostedInfantryUpgradeSelection(IReadOnlyList<BattlePlayerView> players)
    {
        if (players == null || players.Count != RequiredPlayerCount)
        {
            throw new ArgumentException("Two admitted player views are required.");
        }

        foreach (BattlePlayerView player in players)
        {
            Guid identity;
            if (player == null || !Guid.TryParseExact(player.PlayerId, "N", out identity) ||
                player.PlayerId != player.PlayerId.ToLowerInvariant() ||
                player.Fraction < 1 || player.Fraction > RequiredPlayerCount ||
                _players.ContainsKey(player.PlayerId))
            {
                throw new ArgumentException("Admission views must have distinct canonical player identities.");
            }

            ValidateUnits(player);
            _players.Add(player.PlayerId, player.Clone());
        }

        if (players[0].Fraction == players[1].Fraction)
        {
            throw new ArgumentException("Admission views must use opposing fractions.");
        }
    }

    /// <summary>Reproduces CreateFromBattleView's upgrade tuple for this actor's admitted owner and source sheet.</summary>
    public UpgradeSlots.UnitUpgrades Resolve(BattleArmyEntityState actor, SoldierBehaviour family)
    {
        BattlePlayerView owner;
        if (actor == null || family == null || family.upgradeSlots == null ||
            actor.SourceCardId.Length != 0 || actor.UnitId != family.unitDictionaryId ||
            !_players.TryGetValue(actor.OwnerPlayerId, out owner) || owner.Fraction != actor.OwnerFraction)
        {
            throw new ArgumentException("An ordinary actor must belong to its admitted owner and recovered family.");
        }

        string sourceId = family.upgradeSlots.GetSheetName();
        foreach (BattleUnitView unit in owner.Units)
        {
            if (unit.SourceId == sourceId)
            {
                return new UpgradeSlots.UnitUpgrades(1f)
                {
                    slotUpgradeindex = unit.UpgradeIndex,
                    slotUpgradeIndexSpecial = unit.SpecialIndex,
                    slotUpgradeIndexElite = unit.EliteIndex,
                    isSpecial = unit.SpecialIndex >= 0,
                    isElite = unit.EliteIndex >= 0
                };
            }
        }

        throw new InvalidOperationException("The actor's unit is absent from its owner's admitted equipment.");
    }

    private static void ValidateUnits(BattlePlayerView player)
    {
        var sourceIds = new HashSet<string>(StringComparer.Ordinal);
        foreach (BattleUnitView unit in player.Units)
        {
            BattleUnitPresentation.Validate(new BattleUnitPresentation(unit.SourceId, unit.UpgradeIndex,
                unit.SpecialIndex, unit.EliteIndex, unit.Tier));
            if (!sourceIds.Add(unit.SourceId))
            {
                throw new ArgumentException("Admission views must not repeat a unit sheet identity.");
            }
        }
    }
}
