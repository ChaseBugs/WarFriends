# Mortar preparation pose authority

The host now captures an immutable weapon world position, rotation and scale when ordinary
Mortar preparation starts. It retains that exact pose during later body retargeting, expires it
at the observed hand-return tick, and clears it on death, relocation or terminal match closure.
This is internal host state. It is not yet published through protobuf or consumed by the normal
Unity infantry presenter.

## Native observation

`UnityMortarPreparationExport` creates two stripped source rigs in an empty private scene.
They invoke the original `SoldierAnimationController.BuildMortar`, `FiredMortar`,
`FakeRigidBodySwapper.SetParent` and `Swap(false)` methods. One probe runs before the default-order
animation controller and one after it. Each observes two construction/firing cycles. Physics,
EnemyController, Photon and provider components are not executed. A synthetic two-second strict
build deadline and later root turn are explicit probe inputs, not a claimed full gameplay run.

At 30 Hz, the observed sequence is:

| Relative tick | Native state |
| --- | --- |
| 0 | `mortar_down` starts at time zero. |
| 31 | The down clip still runs at about 1.0333334 seconds. |
| 32 | Queued `mortar_down_idle` starts at time zero. |
| 60, after animation | Idle has advanced 28 frames, about 0.9333334 seconds. |
| 61, before animation | The strict build deadline selects preparation; the snap point still has that prior pose. |
| 61, after `FiredMortar` | The active clip changes to hide, but the current snap-point world pose does not change. |
| 61, after `SetParent` | The world pose remains unchanged while the body can subsequently turn. |
| Preparation + 34 | Source coroutine restores the hand; queued `mortar_up` begins in that frame. |

The previous host idle start used a rounded down length, giving tick 31 instead of tick 32.
`MortarConstructionClock` now uses the observed ceiling boundary. This corrects the one-frame
idle-phase offset without altering recovered clips or Client gameplay.

The four observed preparation poses agree within 0.00001 in local position/scale and quaternion
comparison. Their source-local position is approximately `(0.06664552, 0.136648089, 0.248797)`.
The capture retains source rotation and scale too; position alone is insufficient. The host
composes these observed values with the soldier's authoritative root position and current
planar facing, rather than with a receiver's current hand pose.

## Source and lifecycle guards

The compressed full native history is `content/mortar-preparation-unity-reference.json.gz`.
It contains source/probe hashes, 894 frames per controller order, original animation states,
world/local transforms and detach/callback observations. Its SHA-256 is
`0caa927c7881476859e59153855dd90e5aa0a4357c758e5a8d221986f8376280`.

`tools/extract_mortar_prepared_pose.py --check` reproduces the compact
`recovered-mortar-prepared-pose.json` from that pinned history. The runtime loader bounds its
read, validates its digest and four-case agreement, and retains immutable source vectors.
Capture requires the observed two-second build domain, bounded match time, finite root position,
unit planar facing, the observed 61-tick preparation phase and hand-return projection.
An unsupported source change fails
instead of silently substituting a different weapon pose.

The original `EnemyController` accumulates a private float `mTime` using `Time.deltaTime` after
initialization from `Time.time`. This probe uses a synthetic strict `Time.time` deadline and
does not establish accumulated-clock parity at every spawn time or frame rate. The current host
uses its fixed 61-tick construction domain. Exact accumulated-clock/frame-phase parity remains
open; a future timing change must supply its observed preparation pose rather than reuse this
61-tick pose for a different phase.

The prepared world transform is stored before target selection and random draws, matching the
source `FireMortar` ordering even if target preparation cannot produce a shot. It stays unchanged
through natural opponent movement/retargeting, expires before the post-tick projection at the
hand-return deadline, and is removed when the soldier or match can no longer own it.

## Verification and next integration

The final native-reference/host-lifecycle run passed 440 checks, including terminal cleanup
and rejection of an unobserved preparation phase.
The broader Mortar executable passed 1,127 checks before that terminal addition. These cover
actual deployments, both native controller orders, every native construction frame, composed
world poses, body retargeting, hand expiry and airborne shooter death.

The final solution build had zero warnings/errors. The native Windows MongoDB/HTTP/protobuf/UDP
smoke passed 74 live checks with two independent clients and no Photon; its protocol run passed
1,360 checks. Its isolated data/logs are at
`Server/.local/smoke-042fbe0da1b9445384e18bf178461a21`. This stage did not rerun the complete
Battle executable; the earlier 248,560-assertion full run belongs to the firing/relocation checkpoint.

Still required: protobuf/SDK projection and validation of this complete captured pose, replay and
reconnect acceptance, and normal presenter attachment/lifetime integration. The receiver must
restore the captured world pose, not detach at its current animated hand. Full EnemyController/
TweenRotation execution-order parity, original Unity 5.2.5, rendered two-player gameplay,
indicator/particle/trail behavior and Android acceptance remain unproven.

The next wire change should be a read-only optional Mortar weapon-pose projection: preparation
tick, hand-return tick, world position, unit rotation and world scale. It must be absent for other
unit/card identities and after hand return, and bind to the same actor's spawn/preparation phase.
SDK validation, complete snapshot/scan copying, replay reconstruction and presenter disposal
must be implemented together. This paragraph describes required work, not an existing DTO.
