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

`UnityCoopRigReplayProbe` samples a separate inactive clone from observed clip
names, time, weight, layer, wrap and blend mode. It creates aliases for queued
clones without enabling source scripts or autonomous animation. Each frame
records maximum local position error, normalized quaternion error, relative
scale error and the transforms owning the greatest position/rotation errors.
Quaternion error is `1 - abs(normalizedDot)` calculated with double intermediates;
relative scale error divides distance by `max(1, sourceScaleMagnitude)`.

Structural reference validation succeeds, but strict mixer equivalence does
not. In the corner fixture, maximum normalized quaternion errors are about
0.00001155 for the obstacle control, 0.00000305 for right corner and 0.00000220
for left corner. The largest rotation discrepancies identify the left ankle,
left forearm and right palm respectively. These observations contradict a
claim that the current scalar-only replay exactly reproduces every bone.

Use `--require-mixer-parity` with the verifier to enforce the separate gate:
position error at most 0.00001 local units, quaternion error at most 0.000001
and relative scale error at most 0.00001. The current references must fail
that gate; ordinary reference validation checks finite/nonnegative measurements
without claiming equivalence. Investigate evaluation phase, state interpolation
and remaining mixer inputs before adopting this representation for networking.
The replay currently evaluates consecutive observations; skipped-snapshot
reconstruction is also unverified.

### Evaluation-phase and inherited-cache diagnosis

The replay now creates a fresh Animation component on its inactive hierarchy
rather than inheriting the source component's native queue/transition cache.
The maximum rotation errors remain unchanged in the corner fixture.

On the final observation only, `CompareAfterSourceSample` saves the source
local transforms, calls its own Animation.Sample, compares again and restores
the saved transforms in a finally block. No subsequent observation consumes
this diagnostic mutation. The final normalized quaternion errors before/after
manual source evaluation remain identical: about 0.000002157 for the obstacle
control and 0.000002197 for either corner.

This rules out a simple final-frame automatic-versus-manual evaluation phase
explanation for those observations, and the fresh component removes inherited
native queue cache as an explanation. It does not exclude phase effects at
every earlier transition or identify the remaining missing input. Bone binding,
partial rotation channels and interpolation still need investigation. Keep the
strict equivalence gate closed and do not substitute relaxed tolerances for
an explanation. The corner reference includes the final `manualSampleReplay`
measurement; reference validation rejects nonfinite diagnostic measurements
and any diagnostic resampling before the last observation.
