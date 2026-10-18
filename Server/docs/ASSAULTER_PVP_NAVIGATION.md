# Normal Assaulter PvP navigation

The later [point-change integration](ASSAULTER_POINT_CHANGES.md) extends the initial route below
with automatic shared reservation transfer, walking to a new Corner and fresh fire after arrival.

Normal ID_UNIT-ASSAULT deployments previously initialized vitality and a static idle pose without
assigning any destination. InitializeStationaryArmyCombat handled Sniper/Minigunner, while the
Rusher path required a separately assigned shield-linked slot. A fixed Park observation remained
idle through tick 3000. This was missing execution, not a Sickness damage-calculation failure.

## Recovered rule

- SoldierBehaviour.GetInitPoint calls SpawningManager.GetPoint. AcceptsPoint requires the
  soldier's own fraction and a point type contained in its source mask.
- The MainScene Assaulter mask is 14: Hiding, Corner and Car. The already pinned five-map
  EnemyPointsCollection inventory contains thirteen Corners and no Hiding/Car points. Its
  SHA-256 remains f2b047343039b88371b7379dfa0d8721fc316956c486accec4493bda29fc588f.
- GetPoint filters free accepted points and picks the nearest transform position; source
  collection order resolves equal distances. The present Corner position equals its transform.
- EnemyController.SetFinalTarget reserves enemyAtPoint before SetDestination, resumes the agent
  and sets stoppingDistance to zero. GenerateInitPoint retries after five seconds when no point
  exists. It does not create a fallback destination outside the accepted inventory.

## Host integration

Normal army initialization now assigns the Assaulter through the same point occupancy used by
Snipers and card soldiers. A new normal-unit entry point preserves the ordinary unit identity;
it does not pretend an Assaulter is a GREATGRENADIER card. The registry validates owner fraction,
reserves before walking and releases the reservation if route construction fails.

The source map NavMesh connectivity projects start/end positions and plans the corridor. The
existing infantry motion state advances using the current trusted effective speed and agent
settings. Entities created at a fixed tick start displacement in the next interval. This is
host clock ownership, not an invented source 0.02-second GoTo delay: EnemyController directly
calls agent.SetDestination in SetFinalTarget.

The normal tick loop advances retries/walks, publishes position ticks and the run_0 base clip,
and retains the point after arrival. Host-confirmed death removes both walking/retry state and
the shared reservation. No packet may choose a point, position, speed or arrival outcome.

## Verification and remaining work

Release build has zero warnings/errors. --assaulter-navigation-only passes nineteen checks:
a normal accepted Park deployment reserves same-fraction Corners, both soldiers move to distinct
destinations, arrive at tick 434, complete the final entry by tick 450, and host death releases the point.
Arrival checks use planar
distance because the agent projects authored Corner positions to the baked surface. Snow has no
Corner; a six-second observation crosses the retry interval without inventing a walking route.

The existing Sickness checks pass 116, moving Grenadier checks pass 25 and combat regression
passes 26,395 assertions with the navigation change. The new checks are registered in the default
suite; the full default suite was not rerun.

This connects ground navigation and initial Corner root entry, not the full Assaulter controller. Corner exposure,
source target priorities, both prediction stages, firing/cooldown and point-change callbacks,
special healing, parachute entry, native avoidance/turning comparisons, actual projectile damage,
UDP and normal Client presentation remain required. Arrival must not be reported as firing proof.
The remaining three PvP maps also need normal-deployment movement fixtures.
The later [opponent selector](ASSAULTER_TARGET_SELECTION.md) now supplies source entity priority
and complete-list draws for registered opponents. It is not yet the automatic shot-target or
firing controller.

## Initial Corner state

The host now checks EnemyPoint.IsEnemyPointReached against the authored point, with the source
strict planar distance below 0.04. Reaching only a projected NavMesh endpoint is insufficient.
On entry, EnemyController's Corner branch stops navigation, idles, starts a half-second rotation
toward -corner.direction, and tweens X/Z to the source point while preserving current Y.

AssaulterCornerEntry samples that root transition with the source NGUI EaseInOut formula followed
by its linear animation curve. enemy.prefab's existing TweenPosition and the default dynamically
added TweenRotation use those settings. This does not claim native whole-controller frame parity.
Settled entries stop writing the root; their metadata remains until death for later shot/point clocks.

Source GenerateNextShootTime draws the initial Corner delay from the composed minShootTime and
maxShootTime. The first eligible native tick is floor(delay * 30) + 1, preserving mTime > deadline.
The point-change delay independently draws an integer from [10, 20), with the same strict boundary.
Diagnostic manifests without upgrade-lane shot authority retain no shot deadline.

The previous initializer skipped Assaulter's shot composition because its family had no BaseShot
row in the older serialized eight-family artifact. Its recovered upgrade shot lanes are available;
normal initialization now composes those selected lanes and trusted accuracy just as for the other
supported soldier families. No serialized placeholder or invented cooldown is substituted.

The Park host test checks both initial deadlines, the half-second duration, final authored X/Z,
preserved Y, actual root facing opposite the source direction, unchanged vitality, and Corner-state
cleanup on host death. Live combat still advances one simulation tick at a time. These seven checks
extend the previous twelve; reaching a deadline is not an executed shot or point change.
