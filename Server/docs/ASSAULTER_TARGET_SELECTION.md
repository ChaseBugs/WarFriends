# Normal Assaulter opponent selection

SoldierBehaviourAssaulter.PickTarget first calls TryPickDecoy, then
PickRandomOpponent(UnitType.AttackerRusher). The new internal host selector preserves the entity
selection part of that chain. A second internal transition now resolves current infantry,
Decoy and player target transforms. It does not perform the two aim predictions, expose the
Corner or launch a projectile. The later [prediction component](ASSAULTER_AIM.md) now captures
moving-player lead and models the separate callback speed/lead calculation, without an automatic
normal Corner callback or projectile launch.

## Source candidate rules

GameShootableEntity.GetOpponents filters opposing fraction, live IGameMainEntity owner and the
visible flag. Its generatedEntities dictionary retains owner-type buckets and per-bucket enable
order. UnitType filtering additionally requires an AIObject's prepared behavior. Player entities
therefore do not participate in either unit draw.

1. Draw one eligible Decoy from its source bucket.
2. Otherwise draw one eligible AttackerRusher (UnitType 3).
3. Otherwise concatenate eligible groups in anyUnit order [1, 3, 2, 0] and draw from the complete
   combined list. Selecting only the first nonempty group would change the source distribution.
4. Only an empty unit list chooses the separate PickPlayerOpponent path.

There is no nearest-distance or line-of-sight preference at this stage. A chosen Decoy later
draws a target from GetShotTargets(All); the ordinary unit branch draws from AllIn. Those later
draws now use a separate source-list selector. The player path retains its source Shield,
Moving and nearest WholeBody branches.

AssaulterTargetPolicy validates bounded unique finite registry facts and every random index.
It uses the existing host registry ordering, without calling DroneTargetPolicy's different
visibility/first-candidate selection algorithm. A null result means the caller may perform the
separate player selection; it does not claim that player's transform or consume its random draws.

## Actual host registry

SelectAssaulterOpponent binds the policy to the normal source entity and current shared registry.
Normal deployments already register all supported owner types. The seven card-unit spawn paths
now also register at the common post-initialization point, rather than registering only HEAVYDRONE.
Every card-unit death unregisters its target, not just Drone death. This preserves existing shared
owner-type bucket ordering and makes the other six card soldiers visible to registry consumers.
Target registration is not the separate AfterSpawned effect dispatcher or Sickness activation.

Mech owner/prefab target identity remains unresolved in the existing registry. If an opposing
active army entity has no target registration, the selector returns Unavailable instead of
silently drawing from a truncated unit set or claiming player fallback. An eligible Decoy still
takes its source priority before that unresolved lower-priority set. Complete Mech targeting and
the rest of the normal Assaulter firing controller remain required.

## Verification

--assaulter-targets-only passes twenty-nine checks. Source policy checks cover random Decoy and
Rusher priority, no distance sorting, dead/invisible/friendly exclusions, whole-list fallback
draw counts/order, player exclusion from unit lists, owner-type buckets and malformed authority.

A fixed Park host fixture admits/readies participants and sends normal deployment and
GREATGRENADIER card commands. It verifies player fallback before opposing units exist, actual
card registration, explosive-before-defender combined-list ordering, card/normal death cleanup,
and restoration of player fallback when the spawned opposing set becomes empty. Additional checks
verify AllIn excludes Out, All retains it, target draws preserve serialized order, malformed lists
reject, a real player Shield branch uses its cover point, and card infantry targets use their
current sampled Head transform both before and after movement. The death helper
is an internal host-confirmed transition; these checks do not claim projectile kill evidence.

Release build has zero warnings/errors and combat regression passes 26,395 assertions after common
card target registration/cleanup and the source Shield correction. The new test is registered in
the default suite; that complete suite was not rerun. These are internal policy/host checks, not automatic Corner shot attempts,
authenticated UDP target execution, normal Unity gameplay or complete Assaulter implementation.

## Current transform projection and Shield correction

SelectAssaulterShotTarget returns the owning entity, source target slot/type and current transform
position. Infantry reads the pinned EnemyShotTargetCatalog through InfantryShotTargets, rather
than using a hitbox center. Decoy uses its pinned sole Body target and current root rotation.
The player branch consumes its separate player and Shield draws, halves shield probability while
walking, and reads current sampled Moving/WholeBody positions. The returned TransformPosition is
raw geometry, not a predicted aim. Moving selection and ShootJustStarted must apply their separate
source prediction stages using the current muzzle and weapon speed state before firing.

GameShootableEntityPlayer.GetShotTargets replaces the player-child Shield slot with
currentPlayerPoint.point.shield.shotPosition. A new actual-host check exposed the old wrong
player-child position. ArmyShieldShotTarget now supplies the canonical current-cover position to
Assaulter, Sniper and Grenadier. Logical target-slot IDs remain unchanged; the position follows
the source override. The battle map's shotPosition was already verified against each actual
Shield reference by extract_card_grenade_origins.py, separately from grenade effect origins.

The old full-regression Grenadier/Sniper checks expected the player-child target and were corrected
to the source override. Grenadier's three actual damage scenarios now additionally observe the
latched source Shield position. They pass 23 checks with unchanged damage amounts and impact ticks
383, 413 and 492 for normal, overtime and Sickness respectively.

A selected vehicle/air entity without an infantry target graph returns no transform; this does
not select a replacement player. Those source target graphs, live Decoy/Moving/WholeBody fixtures,
automatic Corner attempts, prediction and actual Assaulter fire remain incomplete.
