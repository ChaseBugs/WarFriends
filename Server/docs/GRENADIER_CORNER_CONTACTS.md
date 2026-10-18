# Grenadier simultaneous support retention

The grenade flight now retains each observed collider independently. Previously it remembered one
source path; alternating motion hits between an already supported floor and wall could repeatedly
look like a new entry and restart the fuse. The replacement ledger releases each contact only when
its own support query loses that collider. Revisiting a retained collider is not another entry.

## Source-executed evidence

The shared native probe now records collider names, exits and active sources at expiry, alongside
its original recovered GrenadeAmmoBase contact/countdown execution. Original Client files remain
unchanged. Existing six floor/lift observations were rerun and their source-bound fixture refreshed.

A separate corner experiment gives two Rigidbody spheres a controlled initial lateral velocity
and continuing lateral acceleration against a static wall above a floor. The acceleration is a
fixture condition to retain wall contact, not recovered grenade flight behavior. The original
contact and Update methods still determine countdown resets and expiry; Photon dispatch is not run.

| Fuse | Wall entry | Floor entry | Exit callbacks | Sources active at expiry | Expiry |
| --- | --- | --- | --- | --- | --- |
| 3 | 1 | 11 | None | Floor and wall | 101 |
| 0.9000001 | 1 | 11 | None | Floor and wall | 37 |

An earlier unpressed observation exited the wall at tick 15. It was rejected as evidence for
continuous dual support. The published artifact requires both contacts active with no exit, and
binds original methods, instrumented probe and exporter by SHA-256.

## Host integration and checks

`GrenadierContactTracker` stores normal/support state per collider identity. Identity includes
source path, map collider index, player, entity, dynamic part, passenger role, repair-drone path and
bonus-box ID where present. Prefab paths alone cannot distinguish multiple instantiated soldiers
or passengers. The ledger never accepts client contact or damage commands.

The actual flight uses that ledger for entry/reset decisions and independently checks the retained
support directions. Native contact sequences replay through the host ledger and float clock.
Another controlled flight alternates floor/wall primary rays and must keep two contacts while
expiring at the original deadline. Fourteen collider variants check distinct instance identities
and repeated observation without spurious entry. The focused group now passes 126 checks.
The complete default Windows Battle executable passes 247,827 assertions with exit code zero,
including actual two-peer UDP. Its count varies with live polling. Both native artifact verifiers pass.

## Remaining boundary

This corrects retention of contacts already observed by the current flight query. It does not
replace the complete PhysX manifold or acquire every capsule overlap: source contacts not reached
by the motion ray, perfectly overlapping colliders hidden by a nearer support ray, and full dynamic
collision geometry still need broader overlap/contact acquisition and native map evidence.
Controlled trace tests isolate contact state and do not claim trajectory parity. Original Unity
5.2.5, other frame rates/time scales, broader player blast scenarios and two normal Unity Clients
remain unverified or incomplete. The native experiment uses Unity 2018.3.0f2 and time scale one.
