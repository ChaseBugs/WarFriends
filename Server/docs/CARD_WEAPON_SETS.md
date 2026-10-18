# Source-ordered card weapon visual sets

`SelfHostedInfantryWeaponSet` now constructs every weapon in a recovered card inventory and accepts
an explicit visibility mask. The subsequent [host-authority integration](INFANTRY_WEAPON_AUTHORITY.md)
now connects it to the PvP roster using field 46 and source-derived Grenadier return timing.
Complete normal two-client gameplay remains unverified; no weapon is inferred from an animation clip.

## Source inventory evidence

The native audit reads MainScene, invokes the original protected `GetCardWeaponLevels` selector
and compares each inventory entry with the new resolver. Six supported infantry card inventories
contain seven weapons, all attached to the source right-hand socket in this version:

| Card | Index | Source prefab | Model number | Model resource |
| --- | --- | --- | --- | --- |
| BIGROCKET | 0 | BazookaEnemy | 2 | Weapons/RocketLauncher_FGM_SRAW/RPG_FGM_SRAW_lp |
| ELITEMINIGUN | 0 | MiniGun | 0 | Weapons/Minigun/Minigun |
| ELITEPARA | 0 | AssaultRifleEnemy | 15 | Weapons/SMG_UMP45/UMP45_lp_t |
| ELITESNIPER | 0 | SniperRifleEnemy | 3 | Weapons/SniperRifle_M110/M110_lp_t |
| ELITESWAT | 0 | AssaultRifleEnemy | 7 | Weapons/SMG_P90/P90_lp |
| GREATGRENADIER | 0 | PistolEnemy | 0 | Retain static source prefab meshes |
| GREATGRENADIER | 1 | GrenadeEnemy | 2 | Weapons/Grenade_M34/Grenade_M34_lp |

PistolEnemy has no root `EnemyLeveledWeapon`. `SetWeaponsUpgrade` skips model replacement for that
entry; selecting an arbitrary level-zero model would change its recovered identity. Leveled
entries use the original resource path rule, selected mesh/material, negative pivot offset and
record scale.

`SoldierParts.AttachWeapons` preserves prefab rotation, resets local translation/scale, and resets
the first swapper per entry before `SetWeaponsUpgrade` applies model replacement. The new builder
retains that order and uses cached transform identities across snapPoint reparenting. It strips
all scripts, colliders and rigid bodies. Visibility masks preserve inventory order: one selects
index zero, two selects index one, three enables both, and zero hides all. Invalid bits reject
before changing any existing visibility.

## Verification and remaining integration

`UnityCardWeaponSetAudit.Run` passes 53 checks in disposable Unity 2018.3.0f2 over all six inventories
and seven weapons. It compares original virtual level selection, source geometry/material/pivot,
hand attachment and visibility against the original `EnemyBasicInventory.SwitchWeapon` and
`EnableSecondaryWeapon` methods on isolated reference objects. Invalid masks preserve the previous
state, and the actual copies contain no gameplay or physics components. Existing eighty weapon
selector cases, Gunslinger weapon/holster checks and 192 card-skin checks also pass.

The host-authority integration follows these source requirements:

- Grenadier's index zero is the basic gun. `PickTarget` can switch to index one, the grenade,
  before target selection completes. `Shooting` schedules a return to zero through `InvokeAfter`
  with a half-second delay after a secondary shot. The native fifteen-tick delay and host lifecycle
  now have focused proof in the linked authority report.
- Ordinary Commando enables both weapons through `SwitchWeapon(0)` and `EnableSecondaryWeapon(1)`.
  Its ordinary inventory migration remains separate; this does not introduce a new Commando card.
- The protobuf army row now carries field 46. Host state, SDK validation, paged recovery projection
  and the production presenter binding are implemented; a normal rendered two-client recovery is not proven.

Full normal two-client gameplay, all animation frames/effects, original Unity 5.2.5, Android and
Linux runtime are not proven by these component checks. See the [feature checklist](BATTLE_SERVER_FEATURES.md).
