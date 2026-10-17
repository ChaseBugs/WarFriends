# Retained source corner preparation

The host retains the prior corner animation before creating another windup.
`CreateInfantryShotWindup` now runs before the old round ledger is cleared.
That ledger determines the previous hide deadline; reading it afterward can
mistake an active return for completed idle and incorrectly restart look.

## Source branch order

`CoopCornerPreparationPlan` preserves the recovered private ShotFromCover rules:

| Prior source state | New preparation |
| --- | --- |
| Matching look already enabled | Retain its sample time. |
| Matching fire already enabled | Restart fire at zero without a new look. |
| Matching cover return enabled | Start look at one minus return normalized progress. |
| Known idle or another side's clips | Start the fresh look/queue path. |

Enabled zero-weight states participate in this order, as in IsPlaying. Prior
frames require known source identities, finite scalars, reviewed wrapping,
unique states and conserved weights. Unknown prior state does not become an
invented fresh look. On first entry, preparation remains closed until the
source corner-entry tween has settled.

The plan derives remaining queued-fire ticks from the retained look phase.
Values close to a reviewed fixed-tick boundary use that boundary; fractional
remaining durations advance to the next evaluation. The first full look queues
fire at tick 15. In the measured return interruption, right-side fire starts
four ticks after the new attempt and left-side fire starts after three.

Gameplay callback timing remains the recovered full uncover length plus
0.05 seconds. A shorter remaining animation does not accelerate emitted rounds.
Later rounds own fire resets and hide deadlines. Return blending continues
through the measured return catalog. Snapshot projection and prior-state
capture share the same timeline reader, with different admission timing:
capture can read the old state on the tick a new attempt becomes eligible.

## Rendering and diagnostic boundary

The existing protobuf frame and Unity sampler carry the retained time without
new wire fields or SDK binaries. Root pose must match the host's current corner
turn clock; active paths, invalid roots, dead/ended actors and navigation
conflicts remain excluded. Initial tick-zero blending and current-round reset
evaluation boundaries remain unrepresented.

Known retained/reversed/direct-fire plans cannot use the old fresh-look
uncover/fire hitbox or queued-muzzle diagnostic samples. Those methods return
no geometry for a non-fresh plan. Visual progression therefore does not promote
an incorrect collision frame or launch origin into authority. Returning collider
diagnostics retain their separate provenance and existing unplaced marker.

## Windows evidence

Seventy-two source/model checks cover both measured initial queues, reversed
return phases, direct fire resets, retained look and malformed prior frames.
The live runtime regression advances a trusted eligibility timestamp only in
the test, reaches a return interruption, and checks capture-before-clear plus
the resulting nonzero look time and closed fresh-clock geometry. No Client
request can set that timestamp.

The native adapter audit passes seventeen checks, including decoding the actual
protobuf sample written by the server model and updating the same source actor.
Run the combat executable first to generate
`Server/.local/corner-interruption-sample.bin`; set
`WAR_CORNER_INTERRUPTION_FRAME` to that file and
`WAR_CORNER_RETURN_ANIMATION_REFERENCE` to the reviewed compact return JSON
before invoking the disposable Unity audit. This is component/source geometry
proof, not normal two-Client gameplay or rendered pixels.

The 26,368 combat assertions, 154 return checks, 1,136 protocol checks and 74
live integration checks plus restart recovery pass. Public co-op admission,
authoritative player-hit routing, obstacle fire, procedural aiming, unsupported
transition boundaries and normal complete co-op gameplay remain open. Shipped
Unity 5.2, Linux and Android execution are not established by these Windows tests.
