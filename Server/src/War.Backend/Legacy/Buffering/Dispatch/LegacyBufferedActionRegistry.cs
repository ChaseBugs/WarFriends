using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using War.Backend.Legacy.Buffering.Cards;
using War.Backend.Legacy.Buffering.Economy;
using War.Backend.Legacy.Buffering.Inventory;
using War.Backend.Legacy.Buffering.Squads;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Buffering.LegacyBufferedActionRegistration;
using Feature = War.Backend.Legacy.Buffering.LegacyBufferedFeature;

namespace War.Backend.Legacy.Buffering;

/// <summary>One reviewed feature owner per supported buffered action; never infers behavior from names.</summary>
internal sealed class LegacyBufferedActionRegistry
{
    private readonly FrozenDictionary<DatabaseAction, Entry> _actions;

    internal LegacyBufferedActionRegistry(IEnumerable<Entry> registrations, IReadOnlySet<DatabaseAction> expected)
    {
        var actions = new Dictionary<DatabaseAction, Entry>();
        foreach (Entry entry in registrations)
        {
            if (!Enum.IsDefined(entry.Action) || !Enum.IsDefined(entry.Feature) || entry.Handler == null ||
                !actions.TryAdd(entry.Action, entry))
            {
                throw new InvalidOperationException("A buffered action has an invalid or duplicate owner.");
            }
        }
        if (!actions.Keys.ToHashSet().SetEquals(expected))
        {
            throw new InvalidOperationException("Buffered feature ownership differs from the supported action set.");
        }
        _actions = actions.ToFrozenDictionary();
    }

    internal IReadOnlyDictionary<DatabaseAction, Entry> Actions => _actions;

    internal bool TryGet(DatabaseAction action, [NotNullWhen(true)] out Entry? registration)
    {
        return _actions.TryGetValue(action, out registration);
    }

    internal static LegacyBufferedActionRegistry Create(LegacyCatalog catalog, IReadOnlySet<DatabaseAction> expected)
    {
        Entry[] actions =
        [
            new(Action.WeaponWasShown, Feature.Inventory, LegacyBufferedInventoryMarkers.WeaponWasShown),
            new(Action.ArmyUnitWasShown, Feature.Inventory, LegacyBufferedInventoryMarkers.ArmyUnitWasShown),
            new(Action.VisualWasShown, Feature.Inventory, LegacyBufferedInventoryMarkers.VisualWasShown),
            new(Action.EquipWeapon, Feature.Inventory,
                (request, state) => LegacyBufferedEquipment.EquipWeapon(request, state, catalog)),
            new(Action.UpdateEquippedUnits, Feature.Inventory,
                (request, state) => LegacyBufferedEquipment.UpdateEquippedUnits(request, state, catalog)),
            new(Action.BuyWeapon, Feature.Inventory,
                (request, state) => LegacyBufferedWeapons.BuyWeapon(request, state, catalog)),
            new(Action.ActivateWeapon, Feature.Inventory, LegacyBufferedWeapons.ActivateWeapon),
            new(Action.InstantBuyWeapon, Feature.Inventory,
                (request, state) => LegacyBufferedWeapons.InstantBuyWeapon(request, state, catalog)),
            new(Action.BuyWeaponUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedWeaponUpgrades.BuyWeaponUpgrade(request, state, catalog)),
            new(Action.ActivateWeaponUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedWeaponUpgrades.ActivateWeaponUpgrade(request, state, catalog)),
            new(Action.InstantWeaponUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedWeaponUpgrades.InstantWeaponUpgrade(request, state, catalog)),
            new(Action.BuyUnit, Feature.Inventory,
                (request, state) => LegacyBufferedUnits.BuyUnit(request, state, catalog)),
            new(Action.ActivateUnit, Feature.Inventory,
                (request, state) => LegacyBufferedUnits.ActivateUnit(request, state, catalog)),
            new(Action.InstantBuyUnit, Feature.Inventory,
                (request, state) => LegacyBufferedUnits.InstantBuyUnit(request, state, catalog)),
            new(Action.PromoteUnit, Feature.Inventory,
                (request, state) => LegacyBufferedUnits.PromoteUnit(request, state, catalog)),
            new(Action.BuyUnitUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedUnitUpgrades.BuyUnitUpgrade(request, state, catalog)),
            new(Action.ActivateUnitUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedUnitUpgrades.ActivateUnitUpgrade(request, state, catalog)),
            new(Action.InstantUnitUpgrade, Feature.Inventory,
                (request, state) => LegacyBufferedUnitUpgrades.InstantUnitUpgrade(request, state, catalog)),
            new(Action.BuyDecal, Feature.Inventory,
                (request, state) => LegacyBufferedCosmetics.BuyDecal(request, state, catalog)),
            new(Action.EquipDecal, Feature.Inventory,
                (request, state) => LegacyBufferedCosmetics.EquipDecal(request, state, catalog)),
            new(Action.UpgradeEliteSlot, Feature.Inventory,
                (request, state) => LegacyBufferedElite.UpgradeEliteSlot(request, state, catalog)),
            new(Action.ConvertPartsToScraps, Feature.Economy,
                (request, state) => LegacyBufferedPartsConversion.ConvertPartsToScraps(request, state, catalog)),
            new(Action.ConvertScrapsToParts, Feature.Economy,
                (request, state) => LegacyBufferedPartsConversion.ConvertScrapsToParts(request, state, catalog)),
            new(Action.BuyCardPack, Feature.Cards,
                (request, state) => LegacyBufferedCardPacks.BuyCardPack(request, state, catalog)),
            new(Action.SaveLastSeenSquadChatTimeStamp, Feature.Squads,
                LegacyBufferedSquadChat.SaveLastSeenSquadChatTimeStamp)
        ];
        return new LegacyBufferedActionRegistry(actions, expected);
    }
}
