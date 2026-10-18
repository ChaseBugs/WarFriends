# Mortar accumulated controller time

Mortar construction and relocation now use the recovered `EnemyController` time rule instead
of repeatedly converting the absolute host tick to seconds. This changes real frame eligibility:
the source can pass a two-second strict deadline after either 60 or 61 fixed-rate updates.
The host selects the preparation pose observed for that actual elapsed frame count.

## Recovered rule and native comparison

`EnemyController.BeforeInstancied` initializes private float `mTime` from `Time.time`.
`EnemyController.Update` adds `Time.deltaTime` to that stored float. Construction compares it
strictly against `mTime + mortarBuildTime`; `FireMortar` sets the position-change deadline with
left-associative additions of `mTime`, `mortarShotTime` and `mortarStandTime`.

`UnityMortarPreparationExport.RunAccumulated` compares four stripped native rigs: before/after
the animation controller, each with either absolute `Time.time` or the copied stored-float
addition. It invokes the original animation/swapper methods and records actual frame deltas,
controller time, transforms and strict deadline transitions. Physics, Photon and the complete
EnemyController Update are not executed; the later root turn is synthetic.

| Clock | First build/preparation/relocation | Second build/preparation/relocation |
| --- | --- | --- |
| Absolute time | 5 / 66 / 127 | 305 / 366 / 427 |
| Stored float additions | 5 / 66 / 127 | 305 / 365 / 425 |

Both controller orders agree. The accumulated second build takes 60 frames, and its relocation
also takes 60 frames after preparation. The earlier absolute-time probe selects 61 for both.
Hand return remains a separate real coroutine phase, 34 frames after preparation.

The 60-frame preparation samples `mortar_down_idle` at about 0.9 seconds; the 61-frame preparation
samples about 0.9333334 seconds. Their local snap positions differ beyond the 0.00001 comparison
tolerance, so keeping one constant pose would be incorrect. The compact artifact now includes
eight observations and stores separate immutable 60/61-frame pose selections.

## Host implementation

`MortarControllerClock` stores each binary32 addition explicitly and predicts the first strict
deadline successor using the same fixed-frame addition. Invalid/non-finite epochs, deltas and
delay inputs reject without changing timer state. Prediction has a bounded loop.

Each ordinary Mortar owns a clock from spawn through walking, construction, firing and relocation.
The self-hosted epoch is authoritative match time (`spawnTick / 30`), and the first clock update
follows spawn. This epoch mapping is explicit server reconstruction policy; it does not accept
an arbitrary client Unity uptime as authority. Reconnect pauses already pause logical simulation.

Construction records its actual predicted 60/61-frame deadline. Preparation still freezes the
weapon before target selection. Relocation retains the soldier's accumulated deadline using the
original addition order, including when no free point is available and the source retries.
Clocks survive relocation and are cleared on death or terminal closure. Navigation, source point
occupancy, current weapon setup, missile flight and coroutine callback/poll clocks retain their
existing responsibilities.

The full native reference is `content/mortar-accumulated-unity-reference.json.gz`, SHA-256
`98346fe6745e76eed3dd1016c6fdab810941cebcefe8b5f65d62ecd505c7cd14`.
`tools/extract_mortar_prepared_pose.py --check` reproduces the compact artifact from it.
The prior absolute-time reference remains historical evidence, not the accumulated-clock model.

## Related terminal-contract repair

Reviewing the new clock failure path found eighteen literal engine abort reasons missing from
`BattleTerminalPolicy`, including the existing Mortar, Gunslinger and Assaulter failure paths.
They are now explicit unscored reasons shared by Worker/outbox validation. Unknown `invalid-`
prefixes remain rejected. `BattleAbortReasonCoverageTests` scans explicit positional
`End("reason", "", false)` calls and validates those literal reasons against the same policy;
it is not a proof of every dynamically constructed terminal path.

## Verification and remaining boundary

The focused Mortar executable passed 2,034 checks after clock integration. Native regression
checks compare every recorded accumulated update exactly, both predicted build deadlines,
both relocation boundaries and all eight composed world transforms. Actual host fixtures cover
natural deployment, windup retargeting, hand expiry, death, repeated relocation and terminal cleanup.

The complete Battle executable exited zero with 249,842 engine/admission/SDK/geometry and
real two-peer UDP assertions. This run preceded the added literal-abort coverage checks;
those are included in the final focused verification. Local evidence is
`Server/.local/mortar-accumulated-full.log`.

The final `--mortar-preparation-only` run passed 1,405 native-clock/host-lifecycle and literal-abort
coverage checks. The final solution build had zero warnings/errors. The Windows MongoDB/HTTP/
protobuf/UDP smoke passed 74 live checks with two independent clients and no Photon, and its
protocol executable passed 1,360 checks. Its isolated data/logs are at
`Server/.local/smoke-51e2340c994c433aa71b68521a8724f5`.

Protobuf/SDK delivery of the captured pose and normal Unity attachment/reconnect presentation
remain open. Original variable-frame gameplay, source pool-activation/update order and every
possible Unity uptime are not proven by these 30 Hz stripped-rig observations. Root/TweenRotation
order, target indicator, particle/trail behavior, normal multiplayer and Android acceptance remain
separate gates.
