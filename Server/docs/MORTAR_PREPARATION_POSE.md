# Mortar preparation pose authority

The host now captures an immutable weapon world position, rotation and scale when ordinary
Mortar preparation starts. It retains that exact pose during later body retargeting, expires it
at the observed hand-return tick, and clears it on death, relocation or terminal match closure.
The optional protobuf pose now publishes this capture to the SDK and the production Unity
infantry presenter. See the [attachment integration](MORTAR_WEAPON_ATTACHMENT.md) for the
verified replay, expiry and cleanup boundary; normal two-Unity gameplay is not yet acceptance-tested.

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

The first four absolute-clock preparation poses agree within 0.00001 in local position/scale and
quaternion comparison. Their source-local position is approximately `(0.06664552, 0.136648089, 0.248797)`.
The capture retains source rotation and scale too; position alone is insufficient. The host
composes these observed values with the soldier's authoritative root position and current
planar facing, rather than with a receiver's current hand pose.

## Source and lifecycle guards

The compressed full native history is `content/mortar-preparation-unity-reference.json.gz`.
It contains source/probe hashes, 894 frames per controller order, original animation states,
world/local transforms and detach/callback observations. Its SHA-256 is
`0caa927c7881476859e59153855dd90e5aa0a4357c758e5a8d221986f8376280`.

`tools/extract_mortar_prepared_pose.py --check` reproduces the compact
`recovered-mortar-prepared-pose.json` now comes from the subsequent
[accumulated-clock comparison](MORTAR_CONTROLLER_TIME.md). The runtime loader bounds its
read, validates its digest and within-phase agreement, and retains immutable source vectors.
Capture requires the observed two-second build domain, bounded match time, finite root position,
unit planar facing, an observed 60/61-tick preparation phase and hand-return projection.
An unsupported source change fails
instead of silently substituting a different weapon pose.

The original `EnemyController` accumulates a private float `mTime` using `Time.deltaTime` after
initialization from `Time.time`. The initial absolute-time probe did not establish that parity.
The subsequent comparison observes both 60- and 61-frame deadlines and the host now preserves
the stored-float rule. Full gameplay/activation-order and variable-frame parity remain open;
see the controller-time report for the explicit authoritative server epoch policy.

The prepared world transform is stored before target selection and random draws, matching the
source `FireMortar` ordering even if target preparation cannot produce a shot. It stays unchanged
through natural opponent movement/retargeting, expires before the post-tick projection at the
hand-return deadline, and is removed when the soldier or match can no longer own it.

## Verification and next integration

At the initial preparation-pose checkpoint, native-reference/host-lifecycle checks passed 440,
including terminal cleanup
and rejection of an unobserved preparation phase.
The broader Mortar executable passed 1,127 checks before that terminal addition. These cover
actual deployments, both native controller orders, every native construction frame, composed
world poses, body retargeting, hand expiry and airborne shooter death.

The final solution build had zero warnings/errors. The native Windows MongoDB/HTTP/protobuf/UDP
smoke passed 74 live checks with two independent clients and no Photon; its protocol run passed
1,360 checks. Its isolated data/logs are at
`Server/.local/smoke-042fbe0da1b9445384e18bf178461a21`. This stage did not rerun the complete
Battle executable; the earlier 248,560-assertion full run belongs to the firing/relocation checkpoint.
See the subsequent [controller-time report](MORTAR_CONTROLLER_TIME.md) for the accumulated-clock
implementation and its newer full-suite verification.

The subsequent wire/presenter stage restores the captured world pose rather than detaching at
the receiver's current animated hand. Full network reconnect acceptance and EnemyController/
TweenRotation execution-order parity, original Unity 5.2.5, rendered two-player gameplay,
indicator/particle/trail behavior and Android acceptance remain unproven.

`BattleMortarWeaponPose` now carries preparation, hand-return and observation ticks plus world
position, unit rotation and world scale. SDK validation binds each present pose to its actor,
spawn/preparation phase and the containing page's observation tick. Earlier pages retain their
own observation rather than acquiring the last page's tick. The presenter uses current match
time to prevent an expired earlier-page pose from detaching a weapon again.
