# Co-op firing presentation implementation requirements

This is an implementation dependency list for B22, not evidence that firing
presentation or co-op combat admission is complete. The walking presenter is
installed; this firing path is not implemented.

## Recovered behavior

The active 1.4.0 `SoldierAnimationController.ShotFromCover` overload reverses
the Boolean side before selecting the left/right look and fire clips. Its
private overload has three distinct paths: retain an already playing look,
restart an already playing fire, or reverse a partially played cover return.
Only the remaining branch cross-fades into look over 0.02 seconds and queues
fire. Calling this method on every received snapshot would repeatedly reset
the source animation rather than reproduce it.

`EnemyController.OnShot` calls that method with a 0.5-second hide delay for
corner shots. `SoldierBehaviour.Shooting` invokes OnShot for emitted rounds.
The generic animation Update later plays the cover-return clip at its timer.
Do not interpret a queued-fire start as an emitted projectile or a hit.

`CoopMatchRuntime.CreateInfantryShotWindup` already selects the source corner
look/fire pair and records the volley start, callback and root rotations.
Its callback length uses `player_look_right3` on both sides, matching the
source getter. Obstacle shots instead use `stand_up_begin`/`rifle_shot_loop`;
they require their own transition model.

## Existing evidence and its limits

`CoopAssaulterQueueCatalog` contains measured Unity 2018 queue frames, including
local muzzle position/rotation and a fire-clip clock. It does not contain all
bone poses or mixer weights. `CoopCornerFiringMuzzle.Sample` deliberately uses
the preceding animation evaluation for a gameplay callback, excludes a round
at the current observation tick, and treats the first queued-clone reset
differently from subsequent ordinary-loop resets. That callback observation
must not be reused as the visual post-evaluation frame.

`ObserveShotStartAssaulterMuzzle` remains diagnostic, with explicit navigation
rotation and final-root-rotation guards. Publishing a visual sample must not
remove those guards or admit an enemy into moving collision.

## Ordered implementation work

1. Capture source whole-body transforms and Animation state weights for both
   corner sides and obstacle firing. Include preparation, queued clone start,
   first and later OnShot resets, cover return and interrupted return. Record
   gameplay callback observation separately from the displayed frame.
2. Derive a host visual timeline from windup and actual emitted-round history.
   Preserve the recovered clip speed, loop/clamp modes, hide deadline and
   previous transition pose. Do not infer a shot from elapsed cadence alone.
3. Extend protobuf with an explicit validated mixer description or a validated
   equivalent source pose. A single clip/start tick cannot represent every
   blend above. Preserve the existing walking fields and wire numbers.
4. Validate supported clips, finite weights/times, match identity, entity life,
   host sample clock and timeline ordering in the SDK before replacing State.
   Define terminal and absent-state behavior explicitly; reject partial tuples.
5. Extend the script-free presenter to sample confirmed visual state. Repeated
   snapshots must not restart animation; missed intermediate snapshots must
   still reconstruct the confirmed pose. Do not attach EnemyController,
   SoldierBehaviour, weapon scripts or Photon components to visual actors.
6. Compare all source rig bone transforms at transition boundaries, then verify
   actor reuse, hiding, death, reset, disconnect and rejoin. Check two independent
   clients from the same host snapshot. Keep rendering and projectile authority
   assertions separate.

The native reference project currently uses Unity 2018.3.0f2. Its observations
must retain that provenance; they do not establish shipped Unity 5.2 parity.
No server economy or settlement transition depends on these visual samples.

## Whole-rig queue observation checkpoint

`UnityCoopAssaulterAnimationQueueExport.RunWholeRig` now records every local
transform and enabled mixer state's time, normalized time, weight, speed,
layer, wrap mode and blend mode. `UnityCoopRigFrameCapture` observes the
already evaluated hierarchy; it does not call Sample or advance animation.
The existing muzzle-only export modes remain available independently.

Run in a disposable Unity project with `WAR_COOP_ASSAULTER_RIG_OUTPUT` set to
an absolute JSON output path. The checked-in compressed reference is
`Server/content/coop-assaulter-whole-rig-reference.json.gz`. Validate it with:

```powershell
python Server/tools/verify_coop_rig_capture.py `
  Server/content/coop-assaulter-whole-rig-reference.json.gz `
  --project Clients/ExportedProject
```

This checkpoint contains three source-cover-primed sequences with forty
consecutive frames and 59 transforms each at 30 Hz. The verifier checks source
prefab/clip hashes, ordered clocks, stable unique hierarchy paths, finite
transforms, normalized quaternions, mixer scalars, changed poses and arrival
in a weighted firing state. Indexed hierarchy paths distinguish duplicate
bone names without renaming the source rig.

This is the initial preparation/queued-fire capture only. It does not yet
exercise emitted-round resets, timer-driven cover return, interrupted return,
live procedural aiming or a normal gameplay callback. No SDK mixer contract,
firing presenter or authoritative projectile path is added by this checkpoint.

## Source-method corner volley observation

`RunCornerVolley` adds a separately named fixture, stored as
`Server/content/coop-corner-volley-rig-reference.json.gz`. Use the same verifier
command above with that filename. The initial obstacle scenario remains a
queue-only control; only the two corner scenarios exercise round/return logic.

`UnityCoopCornerVolleyProbe` calls the recovered public `ShotFromCover` method
and the recovered private Update on an inactive disabled controller. It wires
the existing Animation and the enabled/force-visible flags explicitly. Awake,
Start, LateUpdate, gameplay AI and Photon do not run on that controller.
The source controller digest is bound into this reference.

The declared fixture starts with a 0.7-second hide delay and notifies the
source animation of shots at ticks 18, 24 and 43, each with a 0.5-second hide
delay. These are fixture notifications, not host-authorized emitted rounds.
Source timer handling runs before notifications. Both operations occur after
the recorded observation and before the next animation evaluation; the trace
names them `commandsAfterObservation` to avoid confusing callback state with
the displayed bone pose.

Each scenario records 91 frames and 59 transforms. For both corner sides the
verifier requires fire reset at observations 19/25, cover return at 41, reversed
look during return interruption at 44, a later cover return at 60 and queued
idle at 90. The reset observations have fire time 1/30 second. Full-rig finite,
hierarchy, source-hash and clock checks still apply to all three scenarios.

This supplies measured source-method reset/return/interruption poses under one
explicit command order. It does not prove normal controller lifecycle, actual
gameplay callback order, obstacle round resets, procedural aiming, network
mixer reconstruction or Unity 5.2 parity. Those requirements remain open.

## Independent mixer replay and corrected physics isolation

The two rig references above have been regenerated with `physicsFrozen=true`.
The earlier whole-hierarchy observations retained detached weapon rigid bodies;
their physics motion was not animation evidence. The probe now makes all
source rigid bodies kinematic, disables gravity/collisions and disables source
colliders before Play Mode. This affects disposable probes only, not Client
prefabs or gameplay physics. Muzzle-only historical references are unchanged.

`UnityCoopRigReplayProbe` samples a separate inactive hierarchy from observed
clip bindings, time, weight, layer, wrap and blend mode. Each frame records
maximum local position error, normalized quaternion error, relative scale
error and the transforms owning the greatest errors. Quaternion error is
`1 - abs(normalizedDot)` calculated with double intermediates; relative scale
error divides distance by `max(1, sourceScaleMagnitude)`.

### Historical failed alias replay

The initial replayer registered a base clip under a generated state name such
as `player_fire_right3 - Queued Clone`. It produced maximum quaternion errors
of about 0.00001155 for obstacle, 0.00000305 for right corner and 0.00000220
for left corner. Changing initial bind pose, preserving continuous states,
matching speed, creating a fresh mixer and manually sampling the source's
final frame did not remove those errors.

`UnityCoopClipBindingAudit` records 237 bindings for each tested prior,
preparation and fire clip. The diagnosed ankle/forearm/palm all have complete
x/y/z/w quaternion channels; missing components do not explain these cases.
The generated state name was incorrectly treated as a clip asset identity.

### Corrected clip binding and three-way control

Three independent inactive replay hierarchies now receive the same observed
states and clocks:

| Replay mode | Clip binding | Observed result |
| --- | --- | --- |
| `NativeQueue` | Original clip plus a real PlayQueued state | Strict parity passes. |
| `OrdinaryBaseName` | Original clip under its base binding | Strict parity passes. |
| `OrdinaryQueuedAlias` | AddClip under the generated queued name | Different clip object; rotation mismatch. |

The alias control reproduces the historical error, while both accepted paths
preserve source clip object identity in the local probe. Thus queue mode alone
is not required to sample these confirmed poses; the original clip binding
must be preserved. Do not use generated queue-state names as asset identities.
This establishes the alias-path defect without claiming how Unity internally
re-encodes its compressed curves.

Both corrected references pass `--require-mixer-parity` without changing the
thresholds: position error at most 0.00001 local units, normalized quaternion
error at most 0.000001 and relative scale error at most 0.00001. The corner
fixture's maximum corrected quaternion error is below 0.000000001 across all
three scenarios. The negative alias control still exceeds the quaternion
threshold in every scenario. The verifier requires both the positive
original-name control and the negative alias control.

Clip instance IDs in the captures are process-local diagnostics, never wire
or durable gameplay identities. Production reconstruction must resolve
reviewed base clips from matching source content. The network mixer DTO,
host timeline projection, runtime presenter and skipped-snapshot verification
remain unimplemented. This is 393 frames of isolated source/replay geometry,
not normal two-Client battle, projectile authority or Unity 5.2 parity.
