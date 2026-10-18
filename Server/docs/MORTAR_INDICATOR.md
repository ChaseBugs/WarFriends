# Mortar target warning

The recovered `Mortar.StartIndicatorAnimation` is the behavioral source. The warning must be
visible only for an opposing fraction and must use the final shot target, including the fake
shot's displacement, plus `Vector3.up * 0.04`. It is presentation, never damage authority.

## Native observation and portable sampling

`tools/UnityMortarIndicatorAudit.cs` runs in the disposable project. It invokes the original
private setup method on an isolated weapon shell with a copied source indicator, then calls
the original tween sampling, completion and repetition methods. Inactive player shells provide
the local fraction without starting gameplay or provider services. The nonmatching branch uses
an ownerless weapon's `None` fraction against local `Allies`; it does not prove admitted enemy
ownership. The observation is Editor
method execution, not a Play Mode update/callback scheduling or normal battle proof.

Unity 2018.3.0f2 passed eleven checks: activation/world parenting, target preservation, sprite
alpha, rotation/shrink configuration, blink configuration, five repetition boundaries and allied
suppression. The source indicator includes the recovered tk2d sprite; no replacement artwork
was generated. The report contains six original source/prefab hashes.

`content/recovered-mortar-indicator-reference.json` retains five native samples each for
rotation/scale and blink alpha, using an explicit two-second test stop time. Its SHA-256 is
`b10ea3c6d4d2b8d04a75943c041dea64bc05ec34b23e12498b674bcb570957ba`.
Source-byte attributes preserve the original CRLF for the four additional tween references;
the new observation and implementation files use LF. Tests compare source digests with the
active Client and reject an unreviewed reference change.
The focused executable passes 38 checks for native sample agreement, source/reference digests
and invalid-factor rejection. The final refactored Unity audit reproduces the pinned JSON
byte-for-byte. Local logs are `Server/.local/mortar-indicator-tests-final.log` and
`Server/.local/mortar-indicator-unity-final.log`; the private manifest was restored afterward.

`War.Shared.MortarIndicatorTween` implements the observed sampling:

- Rotation uses linear factor times 360 degrees, composed as a world-up angle followed by
  the source 90-degree X base rotation. The reset animation curve is linear in this observation.
- Shrink uses `f - sin(2*pi*f)/(2*pi)`, interpolating uniform scale from 1.5 to 0.65.
  This is the source NGUI EaseInOut formula, not cosine easing or SmoothStep.
- Each forward blink lane applies that same easing from alpha 0.35 to zero. The source
  PingPong lifecycle reverses the factor. Its counter begins at one and hides the indicator
  on the fifth subsequent boundary; it does not run five complete forward/backward cycles.

The sampler rejects non-finite or out-of-range normalized factors. Native setup uses a shrink
duration of `stopTime - 0.3`, then a 0.1-second blink lane. The frame observation below now
checks lifecycle boundaries for five fixed-rate scenarios. Sampling alone cannot prove them.

## Native frame lifecycle

`UnityMortarIndicatorFrameExport` runs the original setup and actual tween Update methods in
Play Mode. Inactive local/opponent shells retain Allies/Enemies fractions; the inactive weapon
uses a real `MissileSetup` component. These shells never activate recovered combat/provider
entrypoints. The earlier method audit also now uses AddComponent, eliminating its invalid
MonoBehaviour construction without changing the existing pinned sample report.

Five scenarios record 241 frames each at 30 Hz. First fire occurs at tick 5 and repeat fire at
105; the probe executes before the source tweens. This is isolated warning timing, not the
complete EnemyController/weapon/scene update order or variable-frame gameplay proof.

| Stop seconds | Shrink completion ticks | Indicator hidden ticks |
| --- | --- | --- |
| 2 | 56, 157 | 70, 172 |
| Native `1 / 0.43` | 65, 166 | 79, 181 |
| 0.3 | None | None through tick 240 |
| 0.2 | None | None through tick 240 |
| 4 | 216; repeat replaces the first unfinished shrink | 230 |

Reactivation misses the same-frame normal Update that the first activation received through
Start. Likewise, the first enabled color tween advances through Start immediately; later blink
enables wait one frame. At native base speed, the first warning ends 74 frames after fire and
the reused warning ends 76 frames after fire. Strict factor comparisons, stored float addition
and PingPong reflection also matter; a rounded total duration loses these observations.

At `stopTime <= 0.3`, TweenScale samples its end and disables itself before Mortar attaches the
completion callback. No blink starts. This persistent warning is an observed source edge case,
not a new expiry rule. Do not silently shorten it. Production session cleanup must still own
every visual; admission/content policy for that domain remains a separate decision.

`War.Shared.MortarIndicatorClock` reproduces these rules independently of Unity. It preserves
scale on positive-duration restarts, replaces an in-progress warning and retains source
activation history. Visibility does not depend on current projectile membership. Stop time
must be finite, positive and no greater than 1,800 seconds; frame delta must be finite from
zero through one second. Damaged inputs are rejected rather than clamped.

The focused executable passes 8,353 assertions: native histories, exact callback frames,
per-frame scale/alpha/factors/phase flags, source/probe digests and invalid inputs. The complete
1,205-frame report is `content/mortar-indicator-frames-unity-reference.json.gz`, with SHA-256
`9c58d7f96c0b7d7e3cb101f5eb0954313a14b37e326e13ac5265ee011bdfcc08`.
Its size is 36,485 compressed and 593,449 expanded bytes. Local evidence is
`Server/.local/mortar-indicator-frames-unity-final.log`,
`Server/.local/mortar-indicator-clock-tests.log` and
`Server/.local/mortar-indicator-component-audit.log`. The private manifest was restored afterward.

## Host ownership and pause boundary

The host now creates one `MortarIndicatorRuntime` when an ordinary Mortar successfully launches.
It copies the admitted owner/fraction, projectile identity, launch tick, final real/fake target,
current stop time and native warning samples. Position includes the source 0.04-unit upward
offset. Its immutable `MortarIndicatorObservation` exposes current presentation without sharing
the mutable clock. Repeated shots reuse the same weapon history and replace its launch identity.

Warnings advance once per completed simulation frame, independently of the construction map
and live projectile collection. Soldier death preserves a still-visible world warning; its
hidden history is removed once the dead weapon no longer owns a visible warning. Living
weapons retain hidden history for reuse. Terminal closure clears every warning and history.
The observed short-duration persistent-warning edge remains unchanged until explicit cleanup.

The integration exposed a pre-existing pause-entry problem: idle detection previously occurred
after the public simulation tick and some subsystems advanced, but before strict missile clocks
advanced. Resuming could skip a missile/warning frame. Running-match presence checks now occur
before the simulation frame begins. `ServerTick` remains the last completely applied frame;
`PauseHostTick` and the existing 30/20/10-second reconnect windows advance on host wall time.
Countdown cancellation and reconnect outcome rules remain in place. Tests now expect tick 299
at a host pause entry of 300, and tick 118 at a host pause entry of 119.

The focused indicator group passes 8,727 assertions. New coverage includes actual ordinary
deployment/launch, final target offset and owner binding, same-tick reads, warning survival
after shooter death, native expiry, terminal cleanup, retained observation independence and
reused fake-shot targets. A deterministic physical-flight collision fixture confirms an early
impact can finish while its warning remains visible; it is not a natural map collision proof.
A live-engine idle test pauses during an airborne shot, advances four host seconds, resumes
both peers and verifies the same next logical frame and retained missile authority. This is
engine/API coverage, not real Unity reconnect acceptance. Local evidence is
`Server/.local/mortar-indicator-host-tests-final.log`.
The complete Battle executable subsequently passed 259,078 assertions, including existing
authenticated UDP pause/resume, combat, source geometry and outcome regression coverage.
Its log is `Server/.local/mortar-indicator-host-full.log`. The separate protocol executable
passed 1,360 assertions at this checkpoint. These results do not establish Unity warning rendering.
The final solution build completed with zero warnings/errors. The isolated Windows MongoDB,
Backend and battle Worker smoke passed 74 live checks with two independent clients and no
Photon, including reconnect and restart/replay evidence. Its aggregate log is
`Server/.local/mortar-indicator-host-smoke.log`; isolated data/logs are at
`Server/.local/smoke-fe879efb23c84c7ba16d1bc990a3a2cd`.

## Observer-local reuse callbacks

The subsequent `UnityMortarIndicatorReuseExport` calls the original Mortar.OnInstancied,
StartIndicatorAnimation and tween updates on two observer-local copies of one logical weapon.
Both weapon/player shells remain inactive. This tests reuse callbacks and observer history;
it does not allocate/free an ObjectPool slot, execute its master/peer selection, or run Photon.

At 30 Hz, ownership is rebound at ticks 0, 85, 170, 220 and 285, alternating Enemies/Allies.
Shots occur at 5, 90, 175, 200, 225 and 290, with a two-second test stop time. This covers allied
suppression, completed warning reuse, an active-warning restart, and reuse during both shrink
and blink. Each observer records 361 frames and retains the same indicator GameObject.

| Local fraction | Shrink completion callbacks | Blink completion callbacks |
| --- | --- | --- |
| Allies (2) | 56, 342 | 70, 357 |
| Enemies (1) | 141, 277 | 155; the second blink is hidden by reuse at 285 |

OnInstancied hides visibility without clearing enabled flags, factors, scale, alpha or prior
tween Start history. An allied shot returns without creating a new warning history. The two
observers therefore cannot share one global fresh-actor clock. `MortarIndicatorClock.HideForReuse`
now represents the original hide operation, and `MortarIndicatorObserver` retains an independent
history for one local fraction, binding each new owner before accepting shots. Invalid or
unbound owner input is rejected without clearing an existing warning.

The focused executable passes 13,232 assertions, including the previous frame/host coverage and
4,505 additional reuse, source-digest and owner-binding checks. It compares all 722 new native
frames, including hidden retained tween state and exact callback histories. The report is
`content/mortar-indicator-reuse-unity-reference.json.gz`, SHA-256
`c39711ff2007ee3ab629d7985fbf22c3f267ab8739ffa51e5007f1214b456cf7`.
Its size is 9,309 compressed and 312,630 expanded bytes. Local evidence is
`Server/.local/mortar-indicator-reuse-unity-final.log` and
`Server/.local/mortar-indicator-reuse-tests-final.log`. The private manifest was restored after
the owned Unity process exited. These observations use Unity 2018.3.0f2, not original 5.2.5 parity.
The portable networking Release build passes with zero warnings/errors. The active Unity SDK
binaries were not replaced because no active Client source consumes the new observer yet.

This stage adds reusable observer logic without changing active host/Client presentation flow.
The observer must eventually live per real pool slot and viewer, not be recreated for every new
logical soldier. Actual allocation/return/slot reuse remains the next authority boundary; the
host's current per-actor warning observation is not silently promoted into that contract.

## Remaining production integration

The sampler and lifecycle clock are not connected to Unity presentation yet. The installed SDK remains at the
previous wire/weapon-pose checkpoint; this stage changes no active Client source, scene or prefab.
The host now uses the clock internally, but does not yet publish warnings through protobuf.

Pool identity must be resolved before fixing that wire contract. The active MainScene's
NetworkObjectPool component 49549 references MortarEnemy component 11496012, prefab GUID
`79ce5dcc1733e5a4eaac84b9e49f9994`, with Count 4. `NetworkObjectPool.Instantiate(int, ...)`
selects the first free slot for the master/local-solo path and the last for the peer;
`ObjectPool.FreeObject` adds a released slot at the front. SoldierParts uses this network pool
to attach weapons, and EnemyBasicInventory returns them on destruction. This is source and
serialized configuration evidence, not a native recycled-slot gameplay observation.

`tools/extract_mortar_weapon_pool.py --check` now reproduces
`content/recovered-mortar-weapon-pool.json` from this exact scene component and prefab. It
Schema 2 records fourteen source/configuration digests after UTF-8 BOM removal and LF normalization, so
Windows/Linux checkout line endings do not change source identity. Allocation labels are
explicitly reviewed source rules; the extractor does not claim to interpret arbitrary C#.
The artifact SHA-256 is
`2d9aedb6b3b5114698907371e537aecb2050c381262940b5a794870ddd6ca05a`.

The new `MortarWeaponPool` primitive initializes indices in ascending order, allocates master
from the front and peer from the back, and inserts every released slot at the front. Capacity
is supplied from reviewed source data rather than silently growing the pool. A failed full-pool
allocation creates no index or binding. Duplicate allocation rejects before mutation; stale
actor releases cannot free a slot now owned by a successor. Returned diagnostic arrays are
copies. Actor bindings are an explicit server authority invariant around the recovered free-list
rules, not a claim that the original pointer-based pool enforced actor generations.

The focused group passes 13,255 checks, including 23 new source/pool assertions. Mixed-role
traces cover capacity exhaustion, multiple release ordering, peer selection of an older free
slot, duplicate ownership, stale release, invalid inputs and immutable diagnostic copies.
Local evidence is `Server/.local/mortar-weapon-pool-tests.log`. These are source/configuration
and managed primitive tests; original NetworkObjectPool execution is not covered by this stage.
The primitive is not yet called by live host spawning. Role must come from trusted scene-master
ownership, not a client assertion or a guessed relationship between faction and master role.
Deployment admission, resource-pool exhaustion behavior, actual
allocation/return observations and per-slot observer integration still need completion before
publishing warning state. No live deployment limit was changed here.

The subsequent startup gate now loads this artifact in both the allocator's rifle catalog and
the Worker's combat package. `MortarWeaponPoolSource` bounds its size, verifies the complete
reviewed SHA-256 and binds its deployment revision, historical scene revision and behavior
component 41188 to the actual admitted army catalog. Mortar permits two live units per
fraction: `SpawnHelper` keys generated-minus-killed counts by `Fractions`, and
`SpawningManagerDeathMatch` tests this count against `maxGeneratedCount`. In ordinary two-sided
PvP, `GameControllerPVP.GetPlayerFraction` assigns the Photon master to Allies and its peer to
Enemies, so the server's per-owner reservation limit corresponds to that source fraction limit.
The artifact's `maxPerOwner` field names that PvP projection; it does not establish a separate
per-player allowance in a shared-fraction co-op game. Two opposing fractions fit the four-slot
live bound. This is necessary capacity proof,
not proof that corpse-held weapons have already returned.

The complete pool artifact digest is included in both sides' `WarFriends/combat-content/v8`
fingerprint before weapon-specific revisions are derived. Backend/Worker equality is tested;
source packages missing this new sibling JSON or using a stale fingerprint must not admit
new matches. The current normalized MainScene digest and historical deployment-scene digest
remain distinct provenance identities rather than being silently treated as byte-identical.

The rifle, shotgun, mixed and starter local match templates were regenerated through the
existing `War.Battle.Tests` `--write-*-template` commands after this fingerprint change.
Each generator validates its source-backed allocation before writing. A structural comparison
against the preceding committed templates confirms that only `CatalogRevision` changed in
all four files; gameplay fields and participant loadouts are unchanged. The mixed allocator
check passes with fourteen starter-army host checks. The earlier full-suite run rejected the
old rifle template as intended; the replacement run passed 263,304 Battle assertions with
exit code zero, recorded at `Server/.local/mortar-pool-catalog-full-v8.log`. That executable
predates the subsequent shared spawn-preflight change; it verifies the pool-source startup,
v8 fingerprints and regenerated templates, not that later host change.

Source inspection also confirms why allocation cannot yet be connected at the kill callback.
EnemyController.OnDeath publishes OnKilled immediately; the spawning manager decrements its
live count there. The weapon remains attached to the corpse until a later DestroyPooled call:
normal death schedules HideUnderGround after Random.Range(2, 3) seconds, then schedules
DestroyEntity one second later. SoldierBehaviour.DestroyBehaviour finally returns its weapons.
Explicit resync/teardown can reclaim a body through other paths. Exact coroutine boundaries,
cosmetic random ownership, corpse retention, resource-pool exhaustion and forced reclaim need
their own integration proof. An immediate weapon release on kill is not implemented.

Both delays use `Core_BaseScript.InvokeAfter`, whose coroutine yields `WaitForSeconds`,
not its separate real-time wait helpers. Do not replace these with a single wall-clock
three-to-four-second deadline: each scheduled wait resumes on a Unity frame boundary and
uses scaled time. `AIObject.ReSyncRPC` destroys an instantiated dead body before reusing it;
`ReSyncDisabledRPC` destroys any instantiated body. `MainGameEntity.DestroyEntity` still
requires a PhotonView even though both master and peer branches perform the same local
`DestroyPooled` call. The replacement must preserve the return transition while removing
that runtime Photon gate, and a stale scheduled callback must not release a successor slot.

The native `UnityPoolReturnClockExport` now observes the original `InvokeAfter`,
`PoolableObject.DestroyPooled` and `ObjectPool` methods on plain one-slot shells. With
30 Hz capture, a pause during ticks 30-59 and half speed during ticks 60-119, consecutive
2+1-second waits return at tick 150; 3+1-second waits return at tick 180. Both are game-time
boundaries. A forced return at tick 20 followed by immediate allocation reuses the same object;
neither old callback runs through tick 300 and the successor still owns the slot. Native
deactivation cancels the body-owned coroutine rather than leaving a callback for its successor.
The fourth scenario forces return at tick 140, after the hide callback at tick 120 has scheduled
the second wait. That pending return also cancels: no delayed-return callback occurs and the
reallocated successor still owns the same slot at tick 300.

The successful four-scenario Unity 2018.3.0f2 log is
`Server/.local/pool-return-clock-four-unity.log`.
`verify_pool_return_clock.py` rejects exception-bearing logs, unexpected frame boundaries,
duplicate scenarios and source mismatches between active Client and disposable project. It
produced `Server/content/pool-return-clock-unity-reference.json` with normalized source hashes
for the three original classes and both executed probes. The first probe run failed because
its pool was activated before Entries were configured; the corrected run has no exceptions.
The private package manifest was restored byte-for-byte after the owned Unity process exited.
This proves these primitives only: no EnemyController death, NetworkObjectPool, cosmetic RNG,
actual combat, Android or original Unity 5.2.5 behavior was executed by this probe.

`MortarCorpseReturnClock` now models the two independently scheduled scaled waits. It consumes
supplied frame deltas, emits the hide and delayed-return transitions once, and retires permanently
on forced return. A second wait starts with zero elapsed time on the hide frame; a large first
frame cannot consume part of that new wait. Accumulation uses double precision rather than the
soldier controller's separate stored-float `mTime` clock. The native-reference test compares the
complete callback sequence and ticks in all four captured pause/half-speed/reuse scenarios;
it also rejects malformed delays/deltas and checks that a resumed wait does not return twice.
This clock is not yet connected to live corpses, slot release or any Client wire state. Delay
sampling, source-body ownership, host frame ordering and forced-reclaim application still need
their integration before this can establish actual battlefield pool parity.
The final isolated-build indicator group passes 13,284 checks including fifteen new return-clock
checks; evidence is `Server/.local/mortar-corpse-clock-tests-final.log`. The simultaneously
running full executable was built at `caa517f2b`, before this clock was added, and must not be
reported as covering this later class.

The managed `MortarWeaponPool` now owns each actor's pending corpse return. BeginCorpseReturn
retains the occupied slot; hide does not release it. AdvanceCorpseReturn requires consecutive
completed frame numbers, skips the death frame itself, and releases only on the final return.
Explicit Release cancels either pending wait before the index can bind a successor, while Clear
cancels every retained body. `OccupiedCount` includes both live owners and retained corpses;
it must not be interpreted as the spawning manager's live-soldier count.

The four native scenarios now also drive this actual managed pool: it stays exhausted while
the corpse owns the slot, returns the slot on the source callback frame, and preserves the
successor through stale callbacks after forced reuse. Additional rejection checks cover an
unowned death, duplicate death, skipped/repeated/backward frame, malformed delay and terminal
reset. No host spawn/death path calls these new pool methods yet; cross-player preflight,
death-delay sampling and frame/callback ordering must be wired before live slot parity exists.
The final isolated-build indicator group passes 13,299 checks, recorded in
`Server/.local/mortar-corpse-pool-tests-final.log`. This newer pool code is not included in the
still-running full executable built at `caa517f2b`.

Exhaustion is not a recovered queue or automatic corpse-reclaim policy. The original
`NetworkObjectPool.GetFirstFreeIndex` returns -1 when the free list is empty, and its
instantiate path returns null. `SoldierParts.AttachWeapons` immediately accesses the returned
weapon's transform; it does not postpone attachment or release another corpse. The indexed
remote attachment path uses `ReInstantiate` and likewise assumes a returned weapon. Before
activating host leases, define an explicit fail-closed admission/error boundary for this
source failure case and prove its ordering against energy consumption and actor publication.
Do not silently manufacture a fifth slot, release on death, or claim an automatic retry was
recovered from these methods.

The current host advances `ArmyDeploymentState.Advance(tick)` before publishing each returned
actor in `MatchEngine`. Advance validates the complete due batch, then consumes energy,
dequeues reservations and issues entity IDs. A future physical-slot guard must participate in
that preflight for the whole due batch across both players. Adding a pool check only inside
`InitializeOrdinaryMortar` would run after these mutations and could leave a partially applied
spawn. This preflight integration is still absent; the source startup check does not supply it.

`ArmyDeploymentState.PreviewDueSpawns` now exposes that non-mutating preview using the same
energy, reserved-count and entity-ID validation consumed by Advance. It returns immutable
spawn records in source queue order and does not dequeue, spend energy, allocate IDs or finish
deployment waves. The wave regression checks repeated/current/future previews and then compares
both committed actors against the earlier preview. MatchEngine now validates both owners'
due batches before advancing either queue. A fault-injection regression damages the second
owner's reserved energy and checks that the host aborts unscored before spending the first
owner's energy, consuming its reservation or committing either soldier. Physical-slot
reservation and its exhaustion-specific rejection path remain unimplemented.
The final isolated-build `--army-waves-only` run passes twenty wave/preflight assertions,
including the damaged-second-owner host case, at
`Server/.local/mortar-shared-preflight-tests-final.log`. The latest solution build passes with
zero warnings/errors, protocol checks pass 1,360 assertions, and the native isolated smoke
passes 74 real MongoDB/HTTP/protobuf/UDP checks. Smoke evidence is
`Server/.local/smoke-01fe03d494c742e08eeb6bde62c61952` and
`Server/.local/mortar-pool-v8-smoke.log`. Its MongoDB, Backend and Worker processes completed
and were cleaned up by the script. A new full run including this later host change is running
at `Server/.local/mortar-shared-preflight-full.log`; do not substitute the earlier 263,304
result for its final result.

After running the exporter in that disposable project, retain and validate its evidence with:

```powershell
python -B Server/tools/verify_pool_return_clock.py `
  --project Server/.local/coop-geometry-project `
  --log Server/.local/pool-return-clock-four-unity.log `
  --output Server/content/pool-return-clock-unity-reference.json
```

The focused group now passes 13,269 checks, including startup rejection of truncated, oversized,
unreviewed and wrong-scene artifacts, terminal pool reset and matching allocator/Worker catalog
revisions. Source extraction `--check` also passes. Local evidence is
`Server/.local/mortar-pool-catalog-tests-final.log`. This stage changes startup/package binding;
it does not activate weapon-slot allocation or change the Client's corpse behavior.

Mortar.OnInstancied hides the old world indicator but does not remove its tween components.
Furthermore, StartIndicatorAnimation returns for the local fraction, so tween activation history
can differ between the two observers of the same recycled weapon. A global fresh-actor clock
cannot establish original pool-slot or observer parity. The current internal host observation
is therefore a first-actor/within-actor integration checkpoint, not the final warning wire
contract. Keep that boundary explicit while adding pool allocation/return/reuse evidence and
observer-specific state; do not infer original slot history from a new logical entity ID.

The host already freezes `MortarMissileLaunch` target, launch tick, fake identity and weapon
stop time, but current `BattleProjectileState` publishes only current pose/velocity and unit
identity. It cannot reconstruct a warning's original target or elapsed phase on late receipt.
The integration must publish the complete required launch authority, validate it in the SDK,
and reconstruct the warning using current authoritative match time rather than receipt time.

Keep warning lifetime independent of current projectile membership: an early collision must
not automatically erase a warning whose source animation is still running. Conversely, an
expired shot replay must not restart a warning. The original weapon reuses one indicator per
weapon and reparents it to the world, so soldier removal and repeated-shot ownership need
explicit acceptance tests. Scene/session cleanup must remove any remaining owned copies.

Required gates include real/fake opposing warnings, allied suppression, normal combat frame
timing, late receipt, reconnect, duplicate events, early impact, shooter death, repeat shots,
terminal/session cleanup, packet capacity, normal two-Unity gameplay and Android rendering.
Original pool allocation/return and complete gameplay activation order also require native proof;
the current binding retains history per self-hosted actor and does not claim original pool parity.
These remain open; neither the sampler nor the native method audit completes this feature.
