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

## Implemented runtime transitions

`CoopObstacleVolleyClock` owns crawling/pending state and strict fixed-tick
shot/position deadlines. Invalid fractions, backward mutation time and deadline
overflow leave its state unchanged. `CoopMatchRuntime.ObstacleVolleys.cs` binds
accepted preparation and last-round completion; the windup and clock use the
same cooldown draw. First-target diagnostics remain immutable history.

After a supported first volley, target selection now consults that clock again.
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
have clock-unit evidence; dedicated runtime cases for those conditions, and a
shot while the reposition path is still active, remain open. Do not extend this
fixture's evidence to Unity animation or authoritative player damage.
