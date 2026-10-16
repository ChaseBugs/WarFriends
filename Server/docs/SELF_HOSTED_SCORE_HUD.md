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
This audit has compiled in Unity 2018.3, and the separate nine-assertion component
audit still passes. The full-scene execution has not produced a result: its
Unity process remains in project initialization before the audit method runs.
This is not a passed scene gate or a normal Play Mode/two-peer gameplay proof.
