using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record CoopPlayerWeapon(
    int Slot, int InventoryIndex, int UpgradeIndex, WeaponManifest Weapon);

/// <summary>
/// Checks the signed co-op roster against the recovered player weapon tables.
/// The mission catalog and combat package have separate revisions, so a co-op
/// allocation must bind both before any player shot can become host authority.
/// </summary>
public sealed class CoopPlayerWeaponCatalog
{
    private readonly IReadOnlyDictionary<string, IReadOnlyList<CoopPlayerWeapon>> players;

    private CoopPlayerWeaponCatalog(
        IReadOnlyDictionary<string, IReadOnlyList<CoopPlayerWeapon>> players)
    {
        this.players = players;
    }

    public IReadOnlyList<CoopPlayerWeapon> ForPlayer(string playerId)
    {
        return players.TryGetValue(playerId, out IReadOnlyList<CoopPlayerWeapon>? weapons)
            ? weapons
            : throw new InvalidDataException("Player is absent from co-op weapon authority.");
    }

    public static CoopPlayerWeaponCatalog Bind(
        MatchManifest allocation, BattleCombatContent combat)
    {
        ArgumentNullException.ThrowIfNull(combat);
        MatchManifest manifest = MatchManifest.Validate(allocation);
        if (manifest.Mode != MatchManifest.CoopMissionMode ||
            combat.Stats.SceneRevision != manifest.CatalogRevision)
            throw new InvalidDataException(
                "Co-op weapons require the matching recovered MainScene.");

        var bound = new Dictionary<string, IReadOnlyList<CoopPlayerWeapon>>(
            StringComparer.Ordinal);
        foreach (ParticipantManifest player in manifest.Players)
        {
            if (!player.WeaponUpgrade.HasValue)
                throw new InvalidDataException(
                    "Co-op weapon lacks a signed upgrade index.");

            WeaponSlotManifest[] slots = player.WeaponSlots ??
            [new WeaponSlotManifest(0,
                combat.AllWeaponBindings.Get(player.Weapon.SourceId).InventoryIndex,
                player.Weapon, player.WeaponUpgrade.Value)];
            var weapons = new CoopPlayerWeapon[slots.Length];
            for (int index = 0; index < slots.Length; index++)
            {
                WeaponSlotManifest slot = slots[index];
                WeaponManifest expected = combat.CreateCoopWeaponManifest(
                    slot.Weapon.SourceId, slot.WeaponUpgrade);
                int sourceIndex = combat.AllWeaponBindings.Get(
                    slot.Weapon.SourceId).InventoryIndex;
                if (slot.Weapon != expected || slot.WeaponIndex != sourceIndex)
                    throw new InvalidDataException(
                        "Co-op weapon differs from its recovered stage or inventory index.");
                weapons[index] = new CoopPlayerWeapon(slot.Slot,
                    sourceIndex, slot.WeaponUpgrade, expected);
            }
            bound.Add(player.PlayerId,
                new ReadOnlyCollection<CoopPlayerWeapon>(weapons));
        }
        return new CoopPlayerWeaponCatalog(
            new ReadOnlyDictionary<string, IReadOnlyList<CoopPlayerWeapon>>(bound));
    }
}
