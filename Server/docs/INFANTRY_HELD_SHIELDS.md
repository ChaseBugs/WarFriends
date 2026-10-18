# Ordinary and card SWAT held shields

The PvP infantry presenter now attaches the recovered inventory shield after selecting the actor's
body appearance. `EnemyBasicInventory.shield` is used for ordinary actors and `cardShield` for card
actors. Families without a source shield remain unchanged.

## Recovered contract

`SoldierParts.AttachShield` parents the instantiated shield under `shieldSnapPointNotScaled`, resets
local position/rotation and calls `FakeRigidBodySwapper.Swap(false)`. It does not reset the shield
root scale. The clone keeps its initial world scale during parenting, including compensation for
a nonuniform socket. The attached form is enabled, the rigid form hidden, and the optional
snapPoint is returned to the attached form with its local pose/scale reset.

The card branch of `EnemyBasicInventory.AttachAllWeapons` additionally calls `ChangeShieldMat`
with the body material. Both shield forms then share that material. The ordinary branch retains
its source shield materials. The adapter preserves that distinction instead of recoloring every
shield indiscriminately.

`SelfHostedInfantryShieldAppearance` copies only transforms and static mesh renderers. It preserves
source mesh/material identities, child visibility and layers. It starts no recovered scripts,
rigid bodies or colliders. Card shields share the skin helper's body material, so roster removal
releases that material once with the actor; shield source materials are never destroyed.

## Native validation

`UnityInfantryShieldAppearanceAudit.Run` passes 56 checks in disposable Unity 2018.3.0f2:

- Four direct comparisons execute the original `SoldierParts.AttachShield` and `ChangeShieldMat`
  on isolated reference actors. Ordinary/card inventories and unit/nonuniform socket scales match
  the script-free copies in transform count, world pose/scale, visibility, layers, meshes and materials.
- Four production presenter actors cover normal/card SWAT for both admitted owners, correct
  material sharing, absence of local collision/gameplay writers and removal/material cleanup.

The 192 card-skin checks, seventeen ordinary owner/presenter checks, sixteen-family infantry
regression and Gunslinger weapon/holster checks also pass after this integration. The Gunslinger
source-hash fixture includes the new shared shield helper.

This covers held shields. The source death-time `Swap(true)` rigid-body drop, complete ragdoll
presentation, every animation frame, normal two-client battle execution, runtime pixel/shader
parity, original Unity 5.2.5, Android and Linux remain unverified or incomplete. Combat collision
continues to belong to the Worker; this change adds no Client damage authority. Card weapons
remain separate work. See the [feature checklist](BATTLE_SERVER_FEATURES.md).
