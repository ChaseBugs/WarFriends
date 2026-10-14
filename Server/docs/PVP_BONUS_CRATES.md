# Source PvP bonus crates

This follows the active recovered 1.4.0 Client. The reviewed catalog and weight
calculation are implemented; selection, delayed spawning, collection, bonus
effects, durable rewards and normal Unity presentation remain incomplete.

## Source bindings

`MainScene.KillStreakManager.bonusesPrefabs` has nine entries. Its order differs
from the `Google2u.Crates.rowNames` order. Preserve the prefab indices used by
`SpawnBonusNetwork`, rather than treating spreadsheet positions as network IDs.
`recovered-pvp-bonus-catalog.json` records each original prefab GUID, component
file ID, path, digest, and its probability row, plus scene/content/code provenance.
`PvpBonusCatalog` validates the reviewed digest and both content bindings at load,
then publishes read-only rows and weight snapshots.

| Index | Prefab name | Ordinary weight | Arena weight |
| --- | --- | ---: | ---: |
| 0 | KillStreakBonusGold | 10 | 0 |
| 1 | KillStreakBonusAddHealth | 20 | 20 |
| 2 | KillStreakBonusWarbucks | 30 | 0 |
| 3 | KillStreakBonusGrenades | 20 | 20 |
| 4 | KillStreakBonusSlowMotion | 35 | 35 |
| 5 | KillStreakBonusTurret | 35 | 35 |
| 6 | KillStreakBonusKevlar | 10 | 10 |
| 7 | KillStreakBonusCard | 5 | 0 |
| 8 | KillStreakBonusAddAmmo | 25 | 25 |

These are unnormalized weights before source overrides and exclusion of the
previous selection. They are not percentages or permission to grant an item.
The separate booby-trap prefab is not one of these nine weighted entries.

## Source weight overrides

`KillStreakBonus.GetBonusProbability` chooses the ordinary/Arena sheet value.
Four subclasses then change it:

- Gold: `PlayerAnalytics.IsAllowedGoldBonus` closes friendly DeathMatch. At
  local display level five or lower it ignores the collected-Gold cap; above
  five it requires `data.goldBonuses < 3`. Allowed Gold uses local display level
  interpolation: 25 at level five or lower, the base weight at eight or higher,
  and the original float interpolation between. This also overrides Arena's
  zero base for low local levels. Do not silently force all Arena Gold to zero.
- Warbucks: `IsAllowedMoneyBonus` closes friendly DeathMatch, with no extra cap.
- Card: closes friendly DeathMatch and requires the supplied owner's
  `playerProperties.level` strictly above the source unlock value six. This is
  the owner's zero-based rank index, unlike Gold's local display number.
- Ammo: doubles its base weight when either of the first two used weapons has
  low ammo. A third low-ammo weapon does not trigger it. `Weapon.hasLowAmmo`
  additionally requires a reloadable weapon and checks total reserve plus clip
  against starting ammunition using the source LowAmmoRatio of 0.1. That
  ammunition predicate still needs host integration; the catalog receives only
  an already established first-two condition.

`PvpBonusWeightContext` represents a host-established source perspective, not
packet assertions. Gold's local level/analytics must not be replaced with the
owner's data merely because an opponent bonus is being evaluated. Context ranks
are bounded to the recovered 43 rows; collected Gold count must be nonnegative.

## Verification and remaining selection work

An isolated Unity 2018.3 Mono probe compiles the original probability methods,
`LevelManager.InterpolateNumbersBasedOnLevel`, and both analytics getters.
Dependencies supply reviewed table values and controlled state. Its 192
contexts vary local levels 1/5/6/7/8/43, owner indices 6/7, Arena/ordinary,
friendly/random DeathMatch, Gold counts 0/3, and first-two low ammunition. A
third weapon is always low to check the source two-weapon limit. Server tests
compare all nine resulting weights by raw float bits. This does not verify
Unity Play Mode, original Unity 5.2 Android, or source random sampling.

Regenerate the catalog with `extract_pvp_bonus_catalog.py`; `--check` verifies
the checked-in source artifact and is part of the Battle release checkpoint.
Run `Server/scripts/AuditPvpBonus.ps1` for the isolated Mono fixture and
`--pvp-bonus-only` for the Battle catalog/weight tests.

`KillStreakManager.GenerateNewBonus` schedules spawning after 1.5 seconds.
`SpawnBonus` first consumes an owner-fraction queue; otherwise its weighted
selection excludes one shared `mLastBonusIndex`. That index starts at zero and
is not reset by the shown GameStarted handler. The float random draw, strict
cumulative comparison, upper endpoint, all-zero behavior, selection lifetime,
queue overrides and source perspective still need explicit verification before
host selection is enabled. At an unselected final loop iteration the source
keeps the last prefab while its index can reach the list count; do not assume a
uniform or valid-index fallback without tracing the original runtime behavior.

After selection, the source chooses a map spawn area and a point inside its
bounds, assigns owner/box identity, sends the spawn RPC, and later activates the
bonus through the shot/collection path. Those steps must be replaced with host
authority and replay-safe events; reward-bearing collection must settle through
the Backend. The current catalog performs none of those mutations.

## Collection contract to implement next

`KillStreakBonusBox.OnInstancied` sets health to one and clears `onGround`.
The box's public fraction is None; its separate owner identifies the player
who earned it. On a non-network death, a present damage owner selects the
recipient by that attacker's fraction. Without a damage owner, the recipient
falls back to the crate owner's fraction. Thus an opposing shooter can steal
the bonus; collection must not always grant it to the original owner.

`KillStreakManager.ActivateBonus` records the box ID, shooter and Photon time.
Its peer arbitration compares competing timestamps through TryActivateBonusRPC
and ActivateBonusResultRPC. The replacement needs one host-confirmed winner and
an atomic terminal crate receipt; Client timestamp assertions and duplicate RPCs
must not create a second recipient/effect/reward.

On accepted opposing collection, a set owner-fraction booby-trap flag replaces
the selected bonus with the separate booby-trap prefab and clears that flag.
The stolen-crate presentation then runs before ActivateBonus. Only local
recipients increment the source destroyed-box count; Gold and Warbucks bonus
activation have their own local reward counters. Preserve these distinct events
when projecting host statistics rather than inferring collection from a shot
request or a progress threshold.

While falling, OnCollisionEnter may destroy a `destroyableByBonusBox` object
with weaponless Basic damage, null owner and immortality ignored. A static
collision marks the box on-ground/alive. Spawn-area geometry, falling contacts,
these damage callbacks and recipient fallback require host simulation evidence
before the crate entity is admitted. No current SDK event or catalog test proves
that gameplay path.
