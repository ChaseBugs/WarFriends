# Initial corner preparation and the remaining interruption state

The host now projects the first accepted preparation at a corner point.
`EnemyController` enters CornerHiding by stopping the agent and calling Idle.
The retained first-target tick identifies the first windup at that point;
later windups cannot silently reuse its zero-based animation clock.

## Represented frames

The selector requires the existing source uncover/root geometry guard, an
alive Assaulter, no active path and no navigation rotation conflict. It
also requires the corner-entry 0.5-second tween to have finished before this
first attempt, so a remaining prior movement/idle transition is not treated
as an established fresh starting state. The start tick remains unrepresented.
The source's 0.02-second fade has completed
by the first 30 Hz observation, so subsequent initial preparation frames carry
the side-specific look clip at elapsed host seconds with unit weight and Clamp.

Both measured source queues switch to their fire state at elapsed tick 15,
with fire time zero. The new selector represents that exact boundary instead
of showing the look end pose. It validates that source look length agrees
with the reviewed fixed-tick boundary. Later fire frames continue through the
existing selector. None of this promotes diagnostic geometry into collision,
projectile or damage authority.

The SDK and runtime sampler already support these reviewed clip identities,
so no protobuf, SDK binary or Client asset change is required.

## Why later attempts remain closed

The recovered private ShotFromCover has different starting-state branches:
an already playing look is retained; an already playing fire is restarted;
and a playing return sets look normalized time to `1 - returnNormalizedTime`.
Only the remaining branch cross-fades a fresh look and queues fire.

The source-method fixture interrupts return at observation 43. At the next
observation, right-side look time is 0.41794908 seconds and left-side look time
is 0.4333336 seconds. Both match the reversed normalized phase plus 1/30 second,
not a new look time of 1/30 second. The source verifier now checks this relation
as well as the initial queued-fire boundary. Resetting these later attempts
to the initial preparation clock would misrepresent the Client.

The next integration must retain the prior source animation before
`ChooseInfantryTargets` clears `infantryRoundIntents` and replaces the windup.
That round history owns the prior hide deadline. It must distinguish idle,
existing look, existing fire and active return, preserve the selected side,
and carry any nonzero preparation phase into later queue/reset selection.
Do not shorten the recovered gameplay callback delay merely because an
interrupted look has less animation remaining.

## Windows verification

The combat fixture verifies the first preparation clip/time during root turn,
the queued-fire boundary, and rejection of an unclassified later preparation.
The existing 26,368 focused combat assertions and 154 source return checks pass.
The native adapter audit passes fifteen checks, including protobuf-decoded
preparation on the reused source rig. Source capture checks validate queue
start and both reversed-return relations under unchanged strict pose tolerances.

Protocol checks remain at 1,136. The 74 live MongoDB/HTTP/UDP checks and restart
recovery also pass; their scope does not include public co-op combat admission.

These remain isolated component/source observations. Normal co-op admission,
validated player-hit routing, later preparation/interruption, current-round
reset boundaries, obstacle fire and procedural aiming remain open. No normal
two-Client gameplay, rendered pixels, shipped Unity 5.2, Linux or Android
execution is claimed.
