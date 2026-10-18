# Source-executed Grenadier fuse clock

The shared ordinary/card grenade flight now follows two recovered rules that the former
first-contact/ceiling deadline omitted: every new static/destroyable contact rearms the countdown,
and Update subtracts a single-precision delta before testing strictly below zero.

## Executed source evidence

`UnityGrenadierFuseProbe` runs recovered GrenadeAmmoBase.OnCollisionEnter with real Unity Collision
objects from a Rigidbody sphere and static floor. It calls the original protected Update each
captured frame. It bypasses unrelated pool/render initialization, the content GroundHitted hook
and falling-collider enable logic. At expiry it verifies the source's cleared flag/zero countdown
and catches the absent PhotonView read before network/explosion dispatch. No Photon component,
connection or explosion-effect execution is part of this probe.

Six observations run in disposable Unity 2018.3.0f2 at capture rate thirty, fixed delta 1/30 and
time scale one. Three use continuous floor contact. Three lift the body briefly and return to the
same floor, producing a second actual contact. Sources, probe and exporter are SHA-256-bound in
`grenadier-fuse-unity-reference.json` and checked by `verify_grenadier_fuse.py`.

| Source fuse | Initial contact | Second contact | Expiry without recontact | Expiry with recontact |
| --- | --- | --- | --- | --- |
| 3 | 7 | 16 | 97 | 106 |
| 2.4 | 7 | 16 | 79 | 88 |
| 0.9000001 | 7 | 16 | 33 | 42 |

The observed offsets from the most recent contact are 90, 72 and 26 ticks. The short-fuse interval
is the original float result `3f - 3f * 0.7f`; rounding it to 0.9 or taking its ceiling times thirty
loses the original countdown behavior. The source also subtracts on the contact frame itself.

## Host integration

`GrenadierFuseClock` retains the original float interval and remaining countdown. Contact entry
resets it. Each host tick subtracts `1f / TickRate` and expires only when remaining time is negative.
`CardGrenadierFlight` uses it for both ordinary and card actors, preserving first-contact provenance
and separately exposing the latest entry. A capsule-radius support ray distinguishes continued
surface support from separation when the motion point-ray misses; continuous support cannot
silently restart the fuse every frame. A different surface or contact after separation rearms it.
The subsequent [corner-contact ledger](GRENADIER_CORNER_CONTACTS.md) retains multiple observed
support surfaces independently. Complete overlap acquisition and native map/manifold parity
still remain open.

The ordinary short-special fixture now explodes at tick 273 instead of the former tick 275.
Its shield-destruction result remains valid. The three-second and 2.4-second fixture timings stay
349 and 319. The ordinary explosion tests derive expected offsets from the native evidence rather
than the production clock or an approximate time threshold.

## Verification boundary

The focused group passes 107 checks. The complete default Windows Battle executable passes
247,810 assertions with exit code zero, including actual two-peer UDP. Live polling makes that
count variable; it is not a fixed completeness score. Fourteen new checks bind the native artifact, replay all six
source countdowns, check continuous/new-surface/separated entry in the actual flight component,
and reject malformed intervals. Unit collision traces test entry semantics; they do not claim
native map trajectory equivalence. Existing real ordinary deployments still prove physical host
contacts, shield damage and upgraded destruction. Original recovered Client files are unchanged.

This proves the observed source contact/countdown behavior at the captured clock. It does not
prove the complete Unity collision manifold, real map trajectory, other frame rates/time scales,
original Unity 5.2.5, Photon dispatch/effects, broader player blast scenarios or two normal Unity
Clients. Those boundaries remain open; the retained Photon types are not a server runtime dependency.
