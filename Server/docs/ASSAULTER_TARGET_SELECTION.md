# Normal Assaulter opponent selection

SoldierBehaviourAssaulter.PickTarget first calls TryPickDecoy, then
PickRandomOpponent(UnitType.AttackerRusher). The new internal host selector preserves the entity
selection part of that chain. It does not yet resolve a selected entity's shot-target transform,
perform the two aim predictions, expose the Corner or launch a projectile.

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
draws and the recovered player-specific shield/body selection are still required.

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

--assaulter-targets-only passes nineteen checks. Source policy checks cover random Decoy and
Rusher priority, no distance sorting, dead/invisible/friendly exclusions, whole-list fallback
draw counts/order, player exclusion from unit lists, owner-type buckets and malformed authority.

A fixed Park host fixture admits/readies participants and sends normal deployment and
GREATGRENADIER card commands. It verifies player fallback before opposing units exist, actual
card registration, explosive-before-defender combined-list ordering, card/normal death cleanup,
and restoration of player fallback when the spawned opposing set becomes empty. The death helper
is an internal host-confirmed transition; these checks do not claim projectile kill evidence.

Release build has zero warnings/errors and combat regression passes 26,395 assertions after common
card target registration/cleanup. The new test is registered in the default suite; that complete
suite was not rerun. These are internal policy/host checks, not automatic Corner shot attempts,
authenticated UDP target execution, normal Unity gameplay or complete Assaulter implementation.
