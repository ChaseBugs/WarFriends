# Portable observed infantry pose catalog

The SDK now carries the same 221 observed obstacle-preparation samples as the
verified server catalog. This is shared content infrastructure for B32, not a
completed renderer or a new co-op admission path.

## Contract and ownership

`BattleInfantryAnimationFrame` retains its existing sample tick and clip fields.
Its additive `observed_pose` field contains only a catalog revision and sample ID.
The host now captures this field for verified completed-return histories and
delivers it only to negotiated connections. Arbitrary network transform arrays
are not accepted as presentation authority.

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

The default SDK projection rejects every observed-pose reference. Its explicit
negotiated overload now accepts only the installed revision and exact source
clips, as described in the dispatch checkpoint below. This prevents accidental
clip-only presentation of a pose known to require hierarchy corrections.

Publication requires exact capability negotiation and hierarchy binding: older
protobuf clients ignore additive fields and could otherwise display an incorrect
clip-only pose. The completed-return path now connects host selection and the
production presenter under those checks. Repeated-interruption and normal
gameplay proof remain open. Public co-op admission remains closed during this work.

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
At this checkpoint the normal presenter did not yet select source inventory.
The later presenter checkpoint below adds that selection. Other weapons/styles
still require their own compatibility checks.

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

This local renderer checkpoint initially had no negotiated wire support. The
subsequent transport and dispatch checkpoints connect its SDK/presenter path.
The later host checkpoint adds bounded publication. Other appearances, repeated source
interruption histories and normal gameplay proof remain necessary.
No rendered-pixel or Android claim is made.

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

This selection checkpoint initially did not feed the normal presenter. The later
checkpoint below binds its normal upgrade index and separate card lane.
Model pivot and scale differ from the basic
attachment used by the initial catalog audit; the subsequent checkpoint below
tests that interaction. B32 remains partial.

## Model and pose compatibility checkpoint

`SelfHostedInfantryVisualFactory.CreateWithAppearance` now attaches the selected
weapon and applies its recovered model before a pose renderer captures its basis.
The visual exposes that explicit copied `WeaponRoot`; body-only construction
continues to leave it absent. Failed model application destroys the partial actor.

The native model/pose audit uses this production construction path for all 80
normal/Elite/card selections from the previous checkpoint. Each resulting actor
receives every one of the 221 source observations, for 17,680 applications. All
non-root transforms except the replaced model renderer are compared against the
independent automatic source capture. The replaced renderer retains the captured
rotation, while its mesh, material, position and scale must match the selected
model's recovered `SetLevel` rules after every sample. This verifies that current
catalog corrections do not erase model appearance values.
The existing 24-check native visual adapter regression also passes after the
factory change. Static asset audits retain zero missing scripts, zero broken
references and the same 17 pre-existing atlas sprite mismatches.

This is a controlled compatibility matrix using the first ordinary body style.
It does not capture automatic source gameplay anew with every upgraded model,
validate Elite/card body appearances, map battle level to upgrade index, enable
host references, or negotiate renderer capability. The renderer must be created
after model application. Observed-pose presenter integration and wider
source-history coverage remain open.

## Normal presenter weapon integration

The production `SelfHostedCoopInfantryPresenter` now resolves the source weapon
appearance when creating an Assaulter actor. For an ordinary unit, the wire
`Level` is passed as `UnitUpgrades.slotUpgradeindex`: host `OrdinaryStats` uses
that same zero-based normal row index, and recovered `Mission.GetUnitUpgrades`
selects a bounded normal row index. It is not a display level or model number.
Card units use the separate source inventory and fixed card visual selector;
their interpolation fraction never chooses a model number.

Actor creation uses `CreateWithAppearance` before installing its existing clip
sampler. Existing actor identity checks still reject changing the level/card
lane in place. No recovered inventory, sound or Photon controller runs for these
visuals. The source appearance resolver rejects unavailable models explicitly.

The isolated native integration audit decodes complete protobuf animation frames
through `SelfHostedBattleClient.Apply` and observes the production presenter.
It checks the ordinary visual-threshold range and one valid timed card spawn,
including selected mesh/material/pivot/scale and absence of local gameplay
scripts: 78 decoded selections pass, alongside the existing 24 visual adapter
regression checks. Static asset audits retain zero missing scripts, zero broken
references and the same 17 pre-existing atlas sprite mismatches.
This is fixture-driven component integration, not a live Worker session
or normal MainScene scheduling. Negotiated observed-pose dispatch was added
subsequently in the checkpoint below.

## Authenticated transport negotiation

`MatchHello.observed_pose_catalog_revision` is an explicit opt-in, empty for
existing clients. `MatchReply.observed_pose_catalog_revision` acknowledges the
exact selected revision on complete replies. The host accepts only the empty
revision or its reviewed catalog revision, stores it on the authenticated
session, and rejects repeated hellos that change it. Negotiation is session-local;
it is not a player entitlement, gameplay mutation or room-wide authority.

Replies are cloned before adding that connection metadata so retained command
receipts and settlement evidence remain independent of presentation capability.
Frozen chunk transfers contain the negotiated value in their complete reply;
the SDK checks it after digest-verified reassembly, before returning the snapshot.

The SDK's existing constructor stays clip-only. Its explicit two-argument
constructor requests a known installed catalog revision and rejects unknown or
null revisions. Every complete reply must match the requested value: there is
no silent downgrade to an unsupported rendering path. Unity now requests the
installed revision when connecting and retains that choice when reconnecting.
The SDK default constructor remains clip-only. Host publication is limited to
the completed-return history checkpoint below.

Authenticated endpoint tests reject unknown content before admission, reject an
in-session downgrade without consuming the valid retry, and verify that command
receipt replay retains no presentation metadata. The existing live UDP SDK
departure-recovery fixture now pairs an opted-in master with a clip-only peer,
exercising negotiation alongside ready, poll, receipt retry and departure paths.
This does not prove normal Unity admission or reconnect capability changes.

Verification after SDK installation: the solution builds without warnings or
errors; focused combat passes 26,368 assertions; native smoke passes 1,144
protocol checks, 74 live MongoDB/HTTP/protobuf/UDP checks and restart recovery.
The installed Unity SDK passes the existing 24-check visual adapter audit.
Static asset audits retain zero missing scripts, zero broken references and
the same 17 pre-existing atlas sprite mismatches.

## Negotiated SDK and Unity dispatch

The SDK projection has an explicit revision overload; its existing overload
remains clip-only. Observed frames require the negotiated revision, a known
sample ID, exact ordered source clips and a non-future observation offset inside
the match. Their captured partial weights are validated by that exact catalog
entry rather than generalized into a new arbitrary-weight policy. Accepted views
return isolated reference copies.

`SelfHostedBattleClient` requests the installed revision at connection creation,
uses the same choice for reconnect, checks reply agreement before publishing
views, and clears the local choice when closing. Its presenter now owns the
observed-pose renderer for each source actor. A validated reference invokes the
catalog reconstruction; an ordinary clip frame restores the original basis
before sampling, so old corrections cannot leak into a later walking/fire pose.
The frozen legacy sampler implementation and source evidence remain unchanged.

Protocol tests accept all 221 negotiated entries, reject them for clip-only
callers, reject altered clip clocks and premature observation offsets, and check
reference isolation. A native Unity component audit decodes all 221 references
through the actual adapter and presenter and compares non-root body transforms
with the independent source capture. Model pivot/scale remain covered separately
by the model matrix. The audit also enters a corrected interruption sample,
returns to walking and compares with a fresh source sampler basis.

These are controlled fixture/component checks. No live Worker session has been
verified publishing a pose reference. The later host checkpoint adds completed
return selection and terminal cleanup; broader interruption/appearance coverage
and normal gameplay proof remain open.

## Completed-return host publication

The runtime now reads the already validated observed catalog when projecting an
Assaulter preparation snapshot. Publication requires a captured prior return at
the completed phase (16), the existing live/stationary/root-turn guards, no newly
emitted round and an observation inside the 13-entry domain. Partial returns
remain nominal candidates only; their live transition histories are not yet
verified. Initial attempts retain their existing separate presentation path.
No unmeasured continuation is extrapolated beyond the catalog domain.

The reference and exact source clips are captured at snapshot creation, including
snapshots retained for command replay. Delivery never consults the current
simulation clock to reinterpret an older snapshot. `MatchPresentationProjection`
clones the reply and applies the authenticated session's revision before packet
sizing and frozen chunk transfer. A clip-only connection receives no animation
frame for an observed sample: removing only its reference would expose the known
incorrect clip-only reconstruction. Root placement and gameplay state remain.

Tests use the existing trusted runtime fixture, which accelerates readiness
through test-only private timing controls. They check actual host references
through the negotiated SDK projection, clip-only isolation, source-reply
immutability, frozen delivery after the runtime advances, emitted-round cleanup
and terminal evidence cleanup. A serialized controlled-host reply is also loaded
in native Unity, decoded by the production adapter and rendered on the production
source rig; non-root body transforms match the independent automatic capture.
This component check excludes model pivot/scale, covered by the earlier matrix.

This is not live UDP/Worker-to-Unity gameplay proof. Partial/unknown returns,
additional source histories, other actor families and appearances, and public
co-op admission remain open. No collision, muzzle, hit, score or reward authority
is derived from the observed animation reference.

The solution builds without warnings/errors. Focused combat passes 26,368
assertions, including the new capture/delivery/lifecycle checks. Native smoke
passes 1,144 protocol checks, 74 live MongoDB/HTTP/protobuf/UDP checks and restart
recovery. The separate native Unity controlled-host snapshot comparison passes.
