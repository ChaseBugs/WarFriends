# Mixed grenade actor lifecycle prerequisite

GrenadeMatchSimulation now accepts a mixed manifest without pretending that
every participant initially holds a grenade. It creates an actor only for an
initial grenade weapon or a later host-selected grenade slot. Selection must
match the exact weapon and upgrade in that participant's trusted manifest;
catalog membership alone is not ownership.

GrenadeWeaponSelection carries the selected weapon, upgrade, current host tick
and current host location. Creation and reactivation validate the source stage,
same-fraction cover and finite stationary position before publishing state. A
dormant actor returns at that current cover, rather than its original spawn.
Moving or throwing actors cannot change selection, and an inactive actor cannot
start a throw or expose stale grenade collision/target poses.

The mixed collision provider is mandatory and supplies every participant's
currently active class pose. Grenade and army traces enumerate the original
participant order, including players with no active grenade actor. They do not
omit a rifle opponent or insert a placeholder grenade pose. Dynamic visibility
queries likewise cover all participants. Simultaneous release order follows
manifest order even when actors were first selected in the reverse order.

## Verification scope

`--mixed-grenade-actors-only` builds the actual source starter presentation and
its four-slot mixed manifest. It uses a real RifleMatchSimulation for rifle
collision poses and the grenade simulation for selected FRAG poses. Checks cover
lazy creation, missing collision-provider rejection, an unowned M320 rejection,
wrong-fraction cover rejection without mutation, active-class ray hits, a source
FRAG windup/release, pending-throw deselection rejection, inactive reads/throws,
reactivation at another valid host cover, and stable simultaneous release order.
These checks also run in --grenade-only and the default native suite.

These checks test simulation lifecycle APIs, not a normal Client match.
The subsequent [host command checkpoint](MIXED_GRENADE_HOST_COMMANDS.md) now
connects the basic starter FRAG transition, active-class views and in-flight
completion to MatchEngine. Other mixed interactions, UDP and normal Unity
gameplay still require proof. Automatic allocation remains open.

At this checkpoint the Release solution builds with zero warnings/errors.
The focused actor suite passes 18 checks; the combined grenade suite passes
8,113 checks including existing grenade-only UDP and Tank impacts. The live
rifle engine regression passes 2,435 checks. These scoped results do not prove
mixed MatchEngine commands, mixed UDP peers or normal Unity gameplay.
