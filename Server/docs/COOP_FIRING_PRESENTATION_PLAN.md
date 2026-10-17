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
