# Economy, Weapons, and Units

## Server-owned currencies

The reconstructed wallet stores Gold, WarBucks, Tickets, Scraps, and dog-tag energy time. A client
price is treated only as an assertion. The server selects the relevant versioned catalog row,
checks the player's balance, and performs debit and grant in one optimistic-concurrency write.

Discounts are rejected unless a server-owned offer entitlement proves them. Accepting an arbitrary
client discount would allow a modified APK to select its own price.

## Weapon ownership

The recovered 4.9.5 scene contains 84 shop rows that resolve to real `LevelManager` weapon entries.
Nine priced Pulse Rifle rows have null `LevelManager` references and remain explicitly unresolved.

Weapon purchase validates:

- exact Google2u name and non-sequential LevelManager index;
- zero-based player level gate;
- exact Gold or WarBucks price;
- ownership and available balance;
- unsupported discounts and malformed timing values.

All enabled shop weapons have zero purchase-delivery time, so ownership is granted immediately.
Equipping validates ownership, recovered category masks, target slot, index, and special-feature
state.

## Weapon upgrades

The server owns 5,781 upgrade transitions across all 84 playable weapons. The current `boughtIndex`
selects the next WarBucks cost and delivery duration.

Normal completion flow:

1. `BuyWeaponUpgrade` verifies the old cursor and creates the one shared weapon delivery receipt.
2. WarBucks are debited immediately.
3. `ActivateWeaponUpgrade` can consume the receipt only after server time reaches its end.
4. The cursor advances exactly once and the receipt is cleared.

Instant completion calculates Gold from the recovered float32 time-price formula. A delayed request
may use its valid receipt-time price, but never a smaller fabricated amount.

## Unit ownership and loadout

The resolved roster contains 24 player units. One tutorial Assaulter is granted through the first
backend-visible equip update; the other 23 use the normal purchase path. Three turret helpers and
18 ArmyUpgrades rows without matching LevelManager objects cannot be purchased.

The active roster enforces:

- ownership of every permanent selected unit;
- at most two units per deployment category;
- at most three mechanical/non-soldier units;
- exact saved-army rollback data when validation fails.

## Normal and special unit upgrades

Each unit has independent normal and special cursors. Normal upgrades are limited by the unit's
current tier. Special upgrades remain locked until the unit is promoted above its starting tier.
Both lanes share one `unitDelivery` receipt, so concurrent unit upgrades cannot overwrite each
other.

The catalog contains 4,124 normal levels and 684 special levels. The server verifies price, duration,
tier boundary, old cursor, delivery time, and instant-completion price before advancing a cursor.

## Promotion and Elite upgrades

Promotion requires ownership, no active unit delivery, completion of the current tier's normal
levels, and the recovered player-level gate for the next tier. Maximum permanent tier is six.

The 216 Elite rows use a separate relative cursor. Elite upgrades are immediate and consume
unit-specific parts plus, on later levels, WarBucks. The historical source column named
`NextUpgradePriceGold` is interpreted as parts because that is how the recovered client reads it.

## Replay safety and rollback

Buffered economy requests carry a `BufferId`. The server stores a bounded result cache and returns
the original result for a retry instead of spending or granting twice. Client-compatible recovery
fields restore the wallet, item, cursor, and delivery view after a rejected optimistic mutation.

## Key implementation files

- `Server/src/services/economyService.ts`
- `Server/src/services/itemInventoryService.ts`
- `Server/src/services/unitInventoryService.ts`
- `Server/src/services/assignmentService.ts` (buffer dispatcher)
- `Tools/Extract-WeaponCatalog.ps1`
- `Server/scripts/Extract-WeaponUpgradeCatalog.ps1`
- `Tools/Extract-UnitCatalog.ps1`
