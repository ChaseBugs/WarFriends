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

    /// <summary>Reproduces the admitted owner's source-sheet upgrade tuple from CreateFromBattleView.</summary>
    public UpgradeSlots.UnitUpgrades Resolve(BattleArmyEntityState actor, SoldierBehaviour family)
    {
        BattlePlayerView owner = GetOwner(actor, family);
        if (actor.SourceCardId.Length != 0)
        {
            throw new ArgumentException("Card actors do not use admitted ordinary unit upgrades.");
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

    /// <summary>Selects the fixed source card lane or the ordinary owner's admitted upgrade lane.</summary>
    public List<TechnologyVisualDefinition> ResolveVisuals(BattleArmyEntityState actor, SoldierBehaviour family)
    {
        GetOwner(actor, family);
        if (actor.SourceCardId.Length == 0)
        {
            return family.upgradeSlots.GetVisuals(Resolve(actor, family));
        }

        if (!CardUnitSourceIdentity.Matches(actor.SourceCardId, actor.UnitId) ||
            family.upgradeSlots.cardVisuals == null)
        {
            throw new ArgumentException("The card actor must preserve its recovered card/unit appearance identity.");
        }

        // UpdateVisual copies cardVisuals directly; card actors need no ordinary equipped-unit upgrade tuple.
        return new List<TechnologyVisualDefinition>(family.upgradeSlots.cardVisuals);
    }

    /// <summary>Checks that a presentation perspective belongs to this admitted match.</summary>
    public bool HasPlayer(string playerId)
    {
        return playerId != null && _players.ContainsKey(playerId);
    }

    private BattlePlayerView GetOwner(BattleArmyEntityState actor, SoldierBehaviour family)
    {
        BattlePlayerView owner;
        if (actor == null || family == null || family.upgradeSlots == null ||
            actor.UnitId != family.unitDictionaryId || !_players.TryGetValue(actor.OwnerPlayerId, out owner) ||
            owner.Fraction != actor.OwnerFraction)
        {
            throw new ArgumentException("An actor must belong to its admitted owner and recovered family.");
        }

        return owner;
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
