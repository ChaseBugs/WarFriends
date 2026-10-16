# Co-op obstacle Assaulter volleys

Status: isolated host scheduling is partially implemented. Co-op Worker
registration and authoritative Assaulter projectile damage remain closed.

## Recovered Client rules

`EnemyController.ObstacleHidingUpdate` checks shooting before repositioning.
A crawling enemy strictly past its shot deadline prepares a shot, clears crawling
and draws a 2–3 second position-change delay. A later position branch requires
`mWillShoot` to be false and draws a 2–6 second delay before `SetFinalTarget`.
`SetFinalTarget` regenerates the current obstacle segment position and resumes
the agent. It does not clear crawling; source shooting is therefore possible
while moving within that same obstacle segment. Rejecting every moving shot
would introduce a rule absent from this Client.

`EndShooting` clears pending fire on the final emitted round.
`ReturnToPreviousStateFromShot` draws the recovered behavior's ordinary/card
`minShootTime`–`maxShootTime` cooldown and restores crawling. A change to a
different enemy point is a separate branch, outside same-segment repositioning.

## Changing the reserved enemy point

Obstacle arrival now schedules the source integer `Random.Range(10, 20)` point
change deadline separately from shot and same-point position timers. The same
validated draw callback supplies corner and obstacle point-change intervals.
The runtime uses the source third-branch priority: a ready shot, a pending
volley or a same-point reposition on this tick prevents a point-change attempt.

An eligible change uses the existing source mask/free-point reservation
selector, releases the old claim, reserves the new point and restarts walking.
Walking clears the old arrival, volley and position/change clocks; reaching
the new point initializes its own behavior. If no different free point exists,
the runtime adds ten seconds to the original deadline, including after firing
delayed the attempt. It does not shift that retry to ten seconds from now.

The fixtures verify no early abandonment, a different reserved point and cleared
old hiding state. A second fixture fills the destination ledger's compatible
points with other source-valid claims, delays the attempt through a pending
volley and verifies the original-deadline retry with the old reservation intact.
The source `canChangePosition=false` assignments belong to tutorial actors;
normal co-op enemies retain the initialization default `true`. Tutorial actor
control is not inferred from this co-op transition.

This implements point-selection/scheduling only. Source native movement,
moving root orientation and complete collision/damage authority remain open.

## Implemented runtime transitions

`CoopObstacleVolleyClock` now starts at obstacle arrival and owns crawling/pending
state and strict fixed-tick shot/position deadlines. Invalid fractions, backward mutation time and deadline
overflow leave its state unchanged. `CoopMatchRuntime.ObstacleVolleys.cs` binds
accepted preparation and last-round completion; the windup and clock use the
same cooldown draw. First-target diagnostics remain immutable history.

Target selection consults that same clock through initial repositioning and
every subsequent volley. The old unchanged-point first-shot restriction is no
longer an eligibility condition: moving within the reserved obstacle segment
does not cancel or refresh the source shot deadline.
The early-reposition fixture now checks two pre-shot position changes, no early
shot, preparation at the original deadline, same-tick replay stability, emitted
rounds and the resulting source cooldown. Initial and later repositioning use
one clock instead of separate pre-first-shot fallback logic. Collider authority
remains closed for unverified moving poses.
A new volley refreshes target, stand-up/fire timing and local round sequence,
while match-wide projectile IDs remain monotonic. Completed volley clocks are
reused rather than reset to the initial arrival deadline.

Repositioning retains an overdue deadline while preparation/fire is pending.
Once fire completes, source shoot-first priority selects either the next volley
or a regenerated same-segment destination. The host follows its covered NavMesh
path; it removes the completed firing windup before crawl movement so that old
firing poses cannot be reused. Source-compatible within-segment moving shots are
not globally prohibited. These transforms and flights remain diagnostic.

Path reset, death and terminal cleanup remove the clock. Replaying an already
advanced simulation tick cannot emit another round.

## Verification and remaining work

A clean Release build and the 15 focused clock tests cover shared deadlines,
pending movement suppression, both position delay ranges, second-shot readiness,
invalid draws, backward time and overflow. The combat-content fixture exercises
actual first preparation, last-round completion, second-volley boundary, fresh
projectile identity, tick replay and death cleanup. It also checks overdue
repositioning when its deadlines put movement before the next shot; dedicated
movement-overlap and simultaneous-deadline runtime fixtures remain necessary.
The final clean build has zero warnings/errors, and the combat-content run
reports 26,368 passing checks.

The initial reposition-before-first-shot route remains restricted by existing
pose/arrival evidence. No-target behavior, changing enemy points, non-player and
Decoy selection, actual moving/crawl/stand-up pose parity and projectile damage
still need implementation or Unity verification. Current enemy collision frames
remain unplaced for this authority. Do not infer player damage from a selected
target or a diagnostic flight. Complete source-equivalent combat and the other
B22 completion gates are required before Worker registration can open.

## Dedicated post-volley movement fixture

`CoopObstacleVolleyRuntimeTests` now forces a legal movement window by changing
source draw fractions at observed arrival/preparation boundaries, rather than
assuming the first RNG call belongs to a particular enemy. It uses real source
batch bounds, cadence, shot cooldown and same-segment path geometry.

The clean build and combat-content regression pass. This fixture proves no
early reposition, removal of the completed firing windup, actual next-tick
position change, retained unplaced collision status, replay-stable movement
deadline, and a subsequent volley at the source cooldown boundary.

The chosen source row completes its maximum batch before the minimum two-second
position delay. It therefore does not prove an unfinished volley spanning that
deadline. Pending suppression and simultaneous shoot-first priority currently
have clock-unit evidence; dedicated runtime cases for those two conditions
remain open. A subsequent fixture below exercises a shot during an active
reposition path. Neither fixture proves Unity animation or authoritative damage.

## Active-path shot fixture

The source map's longest ordinary obstacle segment reachable from a legal
Assaulter spawn supplies a deterministic moving-shot case. It uses the pinned
source selection algorithm and unchanged map points, navigation and movement
speed. Source draw fractions 0.1875 for the following shot cooldown and zero
for position delay place the second shot at host tick 383 while its regenerated
same-segment path remains active. Position choices alternate the two legal
segment ends so later repositioning actually moves rather than repeatedly
choosing the same endpoint.

The fixture checks the actual runtime's active-path state and shot windup start,
then advances another tick and requires continuing position change with the
same windup. The collision frame must still mark the enemy unplaced. The search
used to locate the source combination is not part of the committed regression.
This is host scheduling/motion evidence only; the moving crawl-to-stand/fire
animation, hitbox placement and damage still need Unity/source parity work.

## Source controller observation

An actual two-round host schedule now drives the recovered Unity animation
controller, with 82 observed frames of muzzle and all three collider parts.
The source per-round `ShootFromCrawl` call resets the fire loop and later returns
to crawling; the queue-only muzzle artifact does not contain that lifecycle.
The new reference now supplies diagnostic stationary collider candidates and
has a source-frame selector, but it is not gameplay hit authority.
See [the observation, reproduction steps and limits](COOP_OBSTACLE_POSES.md).
