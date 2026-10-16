# Co-op obstacle Assaulter follow-up

Status: implementation gap identified from recovered Client and current host.
This is part of B22, not permission to open co-op registration.

## Source behavior

`EnemyController.ObstacleHidingUpdate` checks shooting before repositioning.
When crawling and the source clock is strictly past `mNextShootTime`, it calls
`PrepareToShoot(true, false, 0)`, clears crawling and schedules a 2–3 second
position-change deadline. Otherwise an expired position deadline can regenerate
the current obstacle destination only while `mWillShoot` is false, drawing a
new 2–6 second delay. Changing enemy points is a separate later branch.

`ReturnToPreviousStateFromShot` always calls `GenerateNextShootTime`; a living
owned obstacle infantry then becomes crawling again. The next shot delay comes
from the recovered behavior's `minShootTime`/`maxShootTime`, rather than a new
server constant. Walking uses its separate source bounds. The ordinary shooting
batch ends on its last emitted round, as the existing host tests already check.

## Existing host boundary

`CoopMatchRuntime.ChooseInfantryTargets` allows only the first obstacle target
through `infantryFirstTargets.ContainsKey`. Corner shots already have a separate
repeat-readiness path. `AdvanceObstacleRepositions` permanently removes its
pending movement deadline once the first shot is due or selected. Simply
removing the first-target check would therefore repeat shots without reproducing
the source movement/pose clock.

The host tick currently advances obstacle repositioning before target selection.
A new state transition must explicitly preserve the Client's shoot-first branch
on a shared deadline; call order alone cannot establish that invariant.

## Required implementation and proof

1. Represent obstacle crawling, pending fire and post-batch cooldown together.
   Preserve the first target as diagnostic history while tracking each current
   volley separately. Dead or moving enemies cannot start a standing volley.
2. Bind the 2–3 second post-preparation and 2–6 second reposition draws to their
   exact source transitions. Invalid draws must fail before state publication.
3. Resolve simultaneous readiness with the source shoot-first priority. Movement
   cannot rewrite a firing root or make an unsupported collider pose authoritative.
4. Restart source stand-up/fire timing for each accepted volley, retain unique
   projectile IDs and rerun living-player/target/rotation selection.
5. Add deterministic runtime cases beside the existing first-batch fixture in
   `CombatContentTests`: before/at/after strict cooldown; second volley; target
   changes/death; simultaneous movement/shot deadlines; no-target behavior; death
   cleanup; and no repeated spawn/credit on replay.
6. Compare obstacle return-to-crawl and subsequent exposure poses in Unity Play
   Mode before authorizing collision/damage. Diagnostic flight success alone is
   insufficient. Keep Worker registration closed until complete combat authority
   and the existing co-op completion gates are satisfied.

No runtime behavior changed in this investigation. Existing source evidence does
not supply a reason to bypass posture or manufacture player-hit damage.

## Implemented clock foundation

`CoopObstacleVolleyClock` now models shoot-first decisions, crawling/pending
flags, strict fixed-tick deadlines, the post-preparation 2–3 second position
delay, the subsequent 2–6 second delay, and the recovered post-batch shot bounds.
Invalid random fractions, backward mutation time and overflowing deadlines
leave state unchanged. `ObstacleShotDelay` groups the three source delay inputs
so the transition remains readable.

A clean Release build passed with zero warnings/errors, followed by 15 focused
clock assertions (`--coop-obstacle-clock-only`). The test also participates in
the full Battle test entry point, which has not been rerun for this addition.
The clock now binds accepted obstacle shot preparation and actual last-round
completion in `CoopMatchRuntime.ObstacleVolleys.cs`. Its post-batch delay uses
one shared source draw with the windup's `NextEligibleTick`. Runtime snapshots
expose an immutable diagnostic clock view; path reset, death and terminal cleanup
remove the stored state. First-target diagnostics remain unchanged.

The focused combat-content suite passed 26,368 checks, including the new runtime
preparation/completion invariants. The first-volley selection and reposition
guards still remain. Next work must replace those together, verify repeated
volley identities and movement, then compare collision posture before opening
any damage path. Co-op registration remains closed.
