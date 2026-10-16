# Self-hosted PvP score HUD

The recovered Client remains the behavioral reference. `ScoreManager` owns score,
kill-streak progress and skill-shot counts; `HudScreen.OnScoreChanged` updates
NGUI labels and animates the displayed total. Original Photon score callbacks
cannot remain authoritative when the UDP host owns combat results.

## Contract and application order

- `BattlePlayerState.score` (53): authoritative nonnegative PvP score.
- `kill_streak_progress` (54): finite nonnegative source progress. A pending bonus
  can temporarily exceed 100, so validation does not clamp it to that threshold.
- `skill_shot_counts` (55): complete source-ordered counters at terminal state.
  Live snapshots omit them. Private field 52 remains separate settlement evidence.

`SkillShotCounterPolicy` shares exact counter identities, ordering and receipt
bounds between host and SDK. Public and private terminal rows are independent
copies. Empty counters remain accepted for legacy compatibility.

`SelfHostedBattleClient` applies the snapshot to its bound `ScoreManager` before
room lifecycle observation and terminal callbacks. The existing tick/revision
checks reject stale replies. `SelfHostedDeathMatchBridge.Configure` registers the
manager once; `ScoreManager.Awake` also handles the opposite activation order.

The manager resolves both participants and validates the complete score payload
before changing either score. Terminal counts are prepared before publication.
Self-hosted PvP bypasses local score setters, skill-shot increments, streak decay
and bonus generation, plus legacy Photon score reads/writes. Diagnostic history
sampling continues. Disconnect preserves this authority guard until restart.
Campaign/tutorial and co-op retain their separate existing scoring paths.

## Verification and limits

`BattleScoreSnapshotTests` covers roundtrip, malformed score/progress, duplicate
participants, incomplete counters and terminal public/private copy separation.
`GrenadeDroneTests` checks the controlled 56-point Sabotage/revenge sequence.
`LiveSabotageUdpTests` exercises real host transport with two SDK participants.

`SelfHostedScoreHudAudit.Run` is an Editor audit in an isolated source copy. It
checks actual NGUI total/gain text, terminal callback ordering, stale replay,
invalid snapshot atomicity and resistance to local/Photon overwrites before and
after disconnect. It does not open the normal game scene or send UDP packets.
Run it through Unity batch mode with `-executeMethod SelfHostedScoreHudAudit.Run`.

Still required: normal scene rendering and lifecycle proof, two Unity peers,
Android verification, and complete source-equivalent skill-shot popup/statistics
integration. This work does not make matches eligible for durable rewards.

Verified checkpoint (2026-10-17): solution build with zero warnings/errors;
1,037 protocol checks; 74 native MongoDB/HTTP/protobuf/UDP checks; restart and
idempotent acknowledgement proof; 24 focused Drone assertions; nine isolated
Unity HUD assertions. Static asset checks report zero missing scripts/broken
references. The existing 17 unmatched NGUI sprite selections remain unchanged.

The first complete regression run caught an incorrect test expectation: the
Sabotage fixture admits two rank-zero players, so the recovered online noob
policy disables crate progress while still awarding skill-shot score. The test
now requires zero progress in that fixture; all 120 focused Sabotage UDP checks
pass. The complete regression rerun then passed 143,243 assertions with exit code zero.

## MainScene audit preparation

`SelfHostedScoreHudAudit.RunScene` opens the recovered scene without saving it,
checks that its real score singleton and serialized HUD references resolve,
initializes the production `HudScreen.InitEvents` subscription, and checks the
actual labels and configured score animations after a terminal host snapshot.
The Unity 2018.3 run passed all four MainScene assertions with exit code zero
on 2026-10-17 after project initialization completed. The separate nine-assertion
component audit also passed again. The scene audit uses a controlled terminal
snapshot and invokes the score notification coroutine explicitly in Edit Mode.
It does not prove UDP-to-HUD delivery, normal Play Mode, two running Unity peers,
Android behavior, or final result-screen navigation. Those gates remain open.

## Live UDP score delivery

On 2026-10-17 the existing live rifle Editor harness passed with the production
UDP Worker, two independently admitted participants and both recovered scene
rigs. The fixture now admits both zero-based player ranks and a scene-master
identity, enabling source score authority. It retains the previous unshielded
setup; map-loader/shield integration is outside this fixture.

`SelfHostedLiveRifleAudit` initializes the actual scene HUD subscription, fires
until the local host score is positive, and verifies the scene manager and
NGUI total/gain labels against that same received snapshot. The run recorded
`UNITY_LIVE_SCORE_HUD_PASSED score=6` and the complete existing rifle audit passed,
including movement, weapon switching and automatic event-history reconnect.
Editor mode explicitly advances the score notification coroutine and samples
the text tween. This proves live UDP-to-HUD value delivery; it does not prove
normal frame scheduling, final result navigation, two running Unity processes,
or Android presentation. No combat outcome becomes reward-eligible here.

## Play Mode notification clock

`SelfHostedScoreClockAudit.Run` passed in Unity 2018.3 Play Mode on 2026-10-17.
It invokes recovered `ScoreManager.Start` once and then leaves its actual
notification coroutine and NGUI text tween to Unity frame scheduling. After an
accepted 56-point snapshot, the total reaches `56` and the gain reaches `+56`
without manually advancing the coroutine or sampling the tween.

The test uses an empty scene, inactive controller/HUD wiring and a disabled
unrelated gameplay Update; it does not initialize MainScene or receive UDP.
Its real-frame scheduling proof complements the separate live UDP Editor and
MainScene binding audits. These independent checks do not replace a combined
normal boot, complete battle/result-screen, two-Unity-client or Android run.

## Recovered result summary prefab

The MainScene Edit Mode audit now also instantiates the existing
`RibbonsContent.skillshotGuiRecordPrefab` and runs its production
`MultiplayerSkillshotSpecial` formatter with the accepted terminal totals.
All six scene checks pass: the summary model and its actual labels retain
56 local points and zero opponent points. No scene or prefab is saved.
This verifies the total-score result row, not the full per-flag table, pooled
screen initialization, GameOver navigation, or Backend response lifecycle.

## Complete skill-shot row formatting

The MainScene audit now passes 26 assertions. In addition to its total-score row,
it resolves all 19 terminal counter identities through the scene's recovered
`SkillShotManager` definitions and attached Google2u `Skillshots` rows. Each
counter is passed to the existing `SkillshotGuiRecord.MultiplayerSkillshot`
formatter, checking both count labels, source multiplayer point multiplication
and conservation of the complete 56-point breakdown. The audit explicitly binds
rows as normal boot does after `PlayerDataLoaded`; it reuses one instantiated
result row and does not exercise the complete pooled table or its animations.

Static audits completed with zero missing scripts/broken references across
288,080 references; the existing 17 unmatched NGUI sprite selections persist.

The remaining full-result gate crosses the Backend boundary: recovered
`GameController.FinishGame` opens GameOver and calls `BeanstalkServerManager.GameEnded`;
`WaitForGameEndResponse` waits for the GameOver animation and a real response
before freeing the level. That request includes score, obtained/used cards,
crate currencies, ribbon rewards and assignment/statistic assertions. The Worker
currently publishes unscored durable terminal evidence, with no atomic economy
settlement consumer. A local success flag would bypass that missing authority
and is not implemented. Complete GameOver navigation needs this handoff and
normal controller/UI boot, not only a valid score display.
