# Grenade common combat view prerequisite

Mixed weapon gameplay needs one way to read current player collision and
animated target positions. The recovered grenade exports contain collision
parts, weapon muzzles and five target positions. They do not contain the target
rotations, a moving-target transform or a complete weapon-root rig.

`PlayerAimPose.BodyTargetPosition` now supports position-only target authority
while preserving the existing full-pose query for rifle poses. A grenade view
rejects BodyTarget and WeaponRoot requests rather than supplying invented
rotations or rig transforms. MovingTarget stays absent. Rigid placement carries
the position-only points into the new root transform, and the constructor copies
the supplied positions so callers cannot change a cached view.

`GrenadeCombatPoseProjection` preserves the exported collision parts and muzzles,
and maps the five positions to their pinned gameplay transform identities.
`GrenadeMatchSimulation.CombatPose` caches that result until the sampled frame or
target identity catalog changes. Grenade-only army collision and body-target
queries now use this view; they no longer rebuild independent target mappings.

## Launch frame consistency

The native launcher clock samples its windup pose for the release muzzle before
starting the next fire clip. Previously target queries used the new clip name,
so launch-tick collision/muzzle geometry and target positions could come from
different frames. The actor now retains the sampled pose clip and time explicitly.
Both target query paths use that sample. Cache identity changes when selection,
windup, movement or the next animation sample changes the pose.

## Verification scope

`--grenade-pose-view-only` checks all exported frames in the twelve grenade clips,
their exact target identities, preserved muzzle/collision geometry, rigid root
placement and unsupported transform rejection. A real launcher animation-clock
case verifies that release-tick targets retain the sampled windup frame and the
next tick invalidates the cached view. The existing rifle position path is also
checked. These checks are included in --grenade-only and the default native suite.

This is a shared-view prerequisite, not completed mixed-class gameplay. The
mixed active-class coordinator, simultaneous rifle/grenade simulation, snapshot
selection, transitions between classes, normal Unity proof and automatic account
allocation remain open. The export provenance is the existing disposable Unity
2018 reference; this change does not prove original Unity 5.2, Android or rendered
Client parity.

Verification at this checkpoint: Release build has zero warnings/errors;
7,816 common-view checks, 8,095 combined grenade checks (including existing UDP
and Tank impacts), 2,435 live rifle engine checks, and the mixed allocator's
existing weapon checks plus 14 starter army checks pass. No mixed-class grenade
gameplay or normal Unity match is claimed by these scoped results.

The [mixed actor lifecycle](MIXED_GRENADE_ACTORS.md) can now consume these cached
poses through an explicit active-class provider. The MatchEngine coordinator
and full mixed command path remain unimplemented.
