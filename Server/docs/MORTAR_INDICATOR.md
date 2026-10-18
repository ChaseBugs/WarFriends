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
