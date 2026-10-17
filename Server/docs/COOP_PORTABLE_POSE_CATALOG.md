# Portable observed infantry pose catalog

The SDK now carries the same 221 observed obstacle-preparation samples as the
verified server catalog. This is shared content infrastructure for B32, not a
completed renderer or a new co-op admission path.

## Contract and ownership

`BattleInfantryAnimationFrame` retains its existing sample tick and clip fields.
Its additive `observed_pose` field contains only a catalog revision and sample ID.
The host does not publish this field yet. Arbitrary network transform arrays are
not accepted as presentation authority.

`coop-obstacle-fixed-step-pose-catalog.pb` is embedded in `War.Shared.dll`.
The server exporter derives it from the validated source catalog. The server test
compares its complete encoded bytes with the committed portable artifact.
The SDK bounds input size, verifies its SHA-256, checks source identity and
ordering, and exposes deep copies. Mutating a returned sample or topology cannot
change subsequent lookups. Unknown revisions and out-of-range IDs are rejected.

The catalog contains 58 non-root transform identities and 17 prior-return phases
with 13 observations each. It describes only the captured nominal histories;
it is not proof for every interruption, actor style or weapon hierarchy.

## Verification and remaining integration

Protocol tests round-trip and retrieve all 221 references and check copy
isolation. A native Unity 2018.3 audit repeats those checks using the installed
SDK binaries. Neither check proves rendered pixels or normal gameplay.

The installed SDK also passes the existing 24-check native co-op visual adapter
audit. Focused combat passes 26,368 assertions; native MongoDB/HTTP/protobuf/UDP
smoke passes 1,144 protocol checks, 74 live checks and restart recovery. Static
asset validation reports no missing scripts or broken references. The existing
17 atlas sprite mismatches remain unchanged. These checks do not establish
Unity 5.2, Android, Linux or two-Unity-client gameplay support.

The normal SDK animation view deliberately rejects every observed-pose reference
until a renderer capability is installed. Even a valid reference with matching
clip fields is rejected. This prevents accidental clip-only presentation of a
pose known to require hierarchy corrections.

Before the host can publish references, implement capability and revision
negotiation: older protobuf clients ignore additive fields and could otherwise
display an incorrect clip-only pose. Bind the actual Unity actor hierarchy,
including weapon attachments, validate the complete sample before mutation, and
verify source-equivalent local transforms. Then connect host history selection
and the production presenter, with repeated-interruption and normal gameplay
proof. Public co-op admission remains closed during this work.

## Production visual topology checkpoint

The visual factory now offers an explicit inventory-weapon overload. It copies
only transforms and static mesh renderers to the selected left/right attachment.
It follows recovered `SoldierParts.AttachWeapons`: zero local translation,
prefab rotation, unit local scale. Construction stays inactive and a rejected
attachment destroys the partially built actor. Existing body-only callers retain
their previous behavior; no weapon is guessed from a behavior name or pose ID.

A native Unity 2018.3 audit uses the production factory, recovered enemy prefab,
real Assaulter style and source AssaultRifleEnemy prefab. The resulting rig has
59 transforms including its root, matches every one of the catalog's 58 indexed
path/name identities, and has no MonoBehaviour, Collider or Rigidbody components.
It also checks the rifle's local attachment pose and static renderer count.
The existing 24-check production visual adapter audit still passes. Static
asset audits report zero missing scripts, zero broken references and the same
17 pre-existing atlas sprite mismatches.
This establishes a supported binding candidate, not pose correction parity.
The normal presenter still needs source-backed inventory selection before using
this overload, and other weapons/styles require their own compatibility checks.

## Local renderer checkpoint

`SelfHostedObservedInfantryPoseRenderer` binds the exact catalog topology before
adding a disabled mixer. It retains every non-root source transform's initial
position, rotation and scale. Each sample resolves its revision/ID through the
pinned local catalog, checks that the bound hierarchy has not changed, restores
that initial basis, samples the original clips and applies the source-observed
position/scale corrections. Root placement stays host-owned. Restoring the basis
prevents partial-weight animation and previous corrections from accumulating
across reordered or repeated samples.

The native audit compares one reused production factory actor against the
independent automatic source capture in forward order, reverse order and replay:
663 applications spanning all 221 observations. It checks all non-root local
positions, rotations and scales, using position tolerance 1e-5, quaternion-dot
error 1e-6 and per-axis relative scale tolerance 1e-5. Invalid references and a
renamed bound transform must leave both mixer and transform state unchanged.

This is a local rendering component, not negotiated wire support. The normal SDK
frame path still rejects observed references, the presenter does not invoke this
renderer, and the host publishes none. Capability negotiation, source inventory
selection, other appearances, repeated source interruption histories and normal
gameplay proof remain necessary. No rendered-pixel or Android claim is made.

## Recovered weapon model selection

`SelfHostedInfantryWeaponAppearance` separates model selection from combat level
and attachment. Ordinary/Elite selection calls the recovered
`upgradeSlots.GetVisuals(UnitUpgrades)` and takes weapon slot 2, matching
`SoldierBehaviour.GetWeaponLevels`. Card selection instead uses `cardVisuals[2]`,
matching `GetCardWeaponLevels`; card combat scaling is not a visual model number.
The inventory's normal/card lane supplies the weapon prefab and attachment hand.
This first implementation requires the Assaulter's single primary weapon.

The matching `EnemyLeveledWeapon.weaponRecords` row supplies its model number,
resource path and scale. Loading follows `PrepareAsync` exactly:
`Weapons/<assetBundleName>/<weaponModelPath.Split('/')[1]>`. It does not start
the recovered inventory, sound manager, model-unload flow or Photon service.
Missing model/mesh/material/pivot evidence rejects selection instead of silently
keeping a default rifle.

Application changes only a script-free copied renderer's mesh, material, light
probe setting, negative source pivot position and record scale, following
`EnemyLeveledWeapon.SetLevel`. It rejects the source prefab itself. The native
audit compares model numbers with the original protected selectors, checks all
normal/Elite indices through the last visual threshold plus one and the card
lane, and applies the corresponding models to copied source weapon hierarchies:
80 selections/applications. The card model resolves to
`Weapons/AssaultRiffle_AK47/AK47_lp` in this source snapshot.

This does not yet feed the normal presenter. Its battle level must be mapped to
the exact recovered upgrade index, and pose-catalog compatibility must be checked
after model replacement: model pivot and scale differ from the basic attachment
used by the existing catalog audit. Do not let a pose correction overwrite those
appearance channels without a source-backed reconstruction. B32 remains partial.
