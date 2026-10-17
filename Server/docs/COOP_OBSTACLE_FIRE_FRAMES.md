# Confirmed obstacle fire and crawl frames

The host now projects `rifle_shot_loop` from actual emitted-round history for
stationary Assaulter obstacle volleys. Each confirmed round resets displayed
time to zero; later samples use the latest round epoch at the fixed host rate.
The existing protobuf frame, SDK validation and script-free sampler are reused.

The recovered `ShootFromCrawl` method retains an already playing preparation,
restarts enabled fire, or reverses crawl progress before queuing fire. The
separate source notification audit verifies these branches and compares both
queued and ordinary zero-time fire against the production sampler. It passes
460 checks including the retained corner cases and crawl-return geometry.
That audit does not prove normal source callback scheduling.

The confirmed fire window now continues into the consumed crawl-return event.
No frame is invented for a callback without an emitted round. Walking/repositioning, navigation
rotation conflicts, interrupted crawl, the next attempt boundary, death and
non-running matches remain excluded. Preparation and later interrupted attempts
need their own host timeline; this is not complete obstacle presentation or an admission gate removal.

The visual is evaluated after notification. Gameplay muzzle geometry still
uses its earlier source observation. Collider placement, player damage,
outcomes, economy and public co-op admission are unchanged.

## Verification

Live runtime regression checks the absent pre-round frame, exact first-round
zero-time tuple and the second-round reset. The combat executable passes
26,368 assertions. The native Unity 2018 adapter audit passes twenty-two checks,
including protobuf decoding of the obstacle fire frame, actor reuse and a
changed bone pose. These are isolated Windows checks, not rendered gameplay,
two normal Unity clients, Android/Linux execution or shipped Unity 5.2 parity.

Native MongoDB/HTTP/protobuf/UDP smoke also passes 1,136 protocol checks,
74 live integration checks and restart recovery. That smoke does not exercise
public co-op combat admission or normal Unity gameplay.

## Crawl return checkpoint

`SoldierAnimationController.Update` clears an expired crawl timer and calls
ordinary `Play("stand_up_crawl")`. Unlike the corner return, it queues no idle
blend. The recovered clip uses ClampForever. The host now publishes this
single clip at time zero on its existing consumed return tick, then advances
from that epoch, including samples beyond clip duration. It preserves the
strict single-precision `Time.time > deadline` clock already used by gameplay.

The source audit explicitly expires the private timer and invokes real source
Update on the isolated controller. It checks enabled state, zero time and
ClampForever, then compares every local transform at zero, one fixed step,
a quarter second, clip duration and beyond duration against the production
sampler. These 206 additional checks prove sampled return geometry, not normal
callback scheduling or procedural aiming. Existing source timer-reference
checks separately compare actual Unity deadline observations.

The live regression checks the last fire frame immediately before expiry,
the exact consumed return tick and its zero-time tuple, then the next sample.
The native protobuf adapter keeps the actor on return start and changes its
bone pose on a later confirmed return sample. Initial preparation and renewed
shooting during crawl remain open.

The existing corner interruption fixture now fixes its point-change draw to
nineteen seconds. A default random 10-19-second draw could move that fixture
before its third attempt, producing a missing windup unrelated to obstacle
presentation. Production random policy is unchanged, and the test now reports
a missing windup explicitly instead of throwing an uninformative null error.

## Fully weighted preparation checkpoint

For a completed-prior-crawl windup with no emitted rounds, the host now
projects the reviewed preparation clock from elapsed tick two. It uses
`stand_up_begin` with Clamp, then the catalog's measured first queued-fire
tick and `rifle_shot_loop` with ClampForever. Queue start is observed at tick
seven in the pinned Unity reference; rounding the nominal clip duration would
incorrectly invent a different transition tick. A queued visual never issues
a projectile, changes an emitted-round receipt or advances the shot callback.
The first confirmed round still replaces its queued clock with zero.

The prior-crawl predicate is the same conservative source-delay requirement
used by existing obstacle pose diagnostics. Interrupted returns stay excluded.
This does not reconstruct arbitrary previous poses or later shortened queues.

Source comparison checks the absent initial frames and every fully weighted
sample through tick ten in both pinned controller captures. Live runtime
regression checks preparation at elapsed tick two, queued fire before the
first emitted round and the subsequent confirmed reset. The adapter audit now
also decodes the clamped stand-up clip and checks actor reuse and changed bones.

Elapsed ticks zero and one remain unsupported. The gameplay-preparation
post-reference contains a partial-weight transition: tick zero has a clamped
crawl weight about one third plus zero-weight begin, and tick one has begin
weight about two thirds. Those command-state observations are separate from
the previously evaluated hierarchy. The SDK currently requires total weight
one. Do not normalize, copy the Editor-phase blend, or lower that guard without
capturing the gameplay-phase whole hierarchy and proving stateless replay of
the missing base contribution. That is required unfinished work, not an
alternative definition of completed preparation.

The final preparation checkpoint passes the existing 26,368 combat assertions
and twenty-two native adapter checks. Protocol smoke retains 1,136 checks,
74 live integration checks and restart recovery. Public co-op admission and
combat authority remain incomplete.

The [gameplay-phase rig checkpoint](COOP_OBSTACLE_GAMEPLAY_RIG.md) now captures
82 complete frames and verifies primed runtime replay, including partial
initial weights. Fresh-actor/skipped-frame controls remain required before
publishing initial blend frames or changing SDK validation.
