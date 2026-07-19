# Army Power

## Client formula

The recovered `LevelManager` calculates visible Army Power as three independently rounded integer
components:

```text
ArmyPower = UnitPower + WeaponPower + RankPower
```

- `UnitPower`: float32 sum of the equipped, usable, non-borrowed unit power values, rounded once.
- `WeaponPower`: float32 sum of DPS for the weapon in every equipped inventory slot, rounded once.
- `RankPower`: the `ARMYPOWER` value on the current player-level row.

The `X10` UI properties multiply each already-rounded component by ten; the persisted
`DatabasePlayer.armyPower` uses the unscaled integer value.

## Unit component

The server currently reproduces the unit component from the saved normal, special, and Elite
cursors. Normal power uses the current normal row. Special power is added only after promotion
above the unit's starting tier. Elite power is added only when at least one Elite level has been
bought.

JavaScript uses double precision by default, while Unity performs these additions as C# `float`.
The backend applies `Math.fround` at the same boundaries and rounds only after summing the equipped
roster.

## Weapon component

For a normal shop weapon, the selected `boughtIndex` chooses a DPS row. The index is clamped to the
playable range; the final source row is War Arena balancing and is not a normal weapon level.
Black-market special features may multiply DPS by a feature coefficient.

Only normal `specialFeature = 0` weapons are currently granted by the authoritative shop path.
Black-market acquisition and its feature coefficient table remain outside the trusted inventory
path until that system is implemented.

## Rank component

`DatabasePlayer.Level` is loaded directly as the zero-based `LevelManager.levelNumber`. The matching
serialized `levels[index].row.ARMYPOWER` value is therefore the rank contribution. Display level is
`index + 1` and must not be used as an array index without conversion.

## Update flow and current boundary

The recovered client sends `UpdateArmyPower` when its locally calculated value differs from the
value restored at boot. The final backend must recompute all three components from server-owned
inventory and catalog data and persist that result; a client-provided value is only a diagnostic
assertion.

The unit component is authoritative. Weapon DPS and rank-level catalog extraction are the remaining
work before the public player value can be replaced entirely by a server recomputation. Until then,
inventory mutation services do not persist a client-calculated Army Power total.

## Security invariants

- Never accept Army Power solely because the client supplied a larger number.
- Never count an unowned, borrowed, incompatible, or unequipped item.
- Use the persisted cursor, not the cursor echoed in the update request.
- Fail closed for an unsupported black-market feature coefficient.
- Update the indexed top-level value and the public player DTO together.

## Key implementation files

- Recovered client: `LevelManager.cs`, `WeaponLevelsSetup.cs`, and `UpgradeSlots.cs`.
- Server: `Server/src/services/unitInventoryService.ts`.
- Pending integration point: `Server/src/handlers/player.ts` (`UpdateArmyPower`).
