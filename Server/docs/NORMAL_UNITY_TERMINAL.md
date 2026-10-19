# Normal Unity terminal and result acceptance

The ordinary two-Unity gate previously exited after reload and reconnect. It did not prove
server termination, recovered GameOver animation, HTTP completion or EndScreen presentation.
`UnityNormalTerminalAudit` adds an opt-in continuation without changing production behavior.

Set `WAR_NORMAL_BATTLE_TERMINAL=1` for `ClientBootSmoke.ps1 -SecondUnityProject ...`.
Use the same disposable projects, isolated Mongo replica set and native Backend/Worker as the
normal entry gate. Omit the admission override to use the current repository policy;
explicit overrides remain diagnostic.

After both participants complete reconnect observation, each publishes a run-local readiness
marker. The designated initiator sends the existing authenticated `Forfeit` command. Neither
client writes a terminal snapshot, game-end reason, response status or wallet. Both must observe
the host's Ended phase, the recovered successful HTTP completion and an active scene EndScreen.
The report exposes those observations separately under `normalBattle.terminal`. Failure types
are recorded without session-bearing exception messages. Report completion still requires zero
exceptions, and the paired script checks complete process logs after exit.

## Source boundary

`SelfHostedDeathMatchBridge.Apply` projects the host outcome and invokes normal `FinishGame`.
`GameControllerOnline.FinishGame` resets the match and calls the root controller. The root
shows GameOver and waits for animation and `gameEndServerResponse`, then frees the level and
shows EndScreen. `BeanstalkServerManager.GameEnded` sends legacy action 62, including BattleId
and client assertions. Those assertions cannot become reward or outcome authority.

The current legacy endpoint implements TutorialEnded (120) but not ordinary GameEnded (62).
Connecting the latter requires validated accepted host results, authenticated player binding,
source-exact response fields and retry-safe settlement. A fabricated success or zero-reward
placeholder would hide this missing path. This acceptance gate must remain failed until the
real pipeline works. Same-opponent and random rematch are separate subsequent gates.

## First execution evidence

The Release solution builds with zero warnings/errors. The new Unity sources compile in both
disposable projects during their ordinary account boots. The terminal-enabled pair at
`.local/client-boot-6c7b9725752d41d3893216e1b780a36e` exits nonzero before matchmaking:
the first report has `hasStartedSearch=false`, no Running milestone, zero exceptions and
82 error-level diagnostics. Its terminal gate is enabled, but no forfeit is requested and
neither Ended nor EndScreen is observed. The second Editor does not publish lobby readiness;
its last log entries include Unity login-page CEF errors. The first participant reaches its
bounded deadline and the script cleans up its owned processes. This does not establish the
cause of the Editor delay or a runtime failure in the game's terminal path. Rerun the same gate
before drawing a result-screen conclusion. No success or complete feature is claimed.

## Repeated startup boundary

The retry at `.local/client-boot-c4f08a8f33ae478e903cc0c0d5fb0cdd` also builds without
warnings/errors and completes both ordinary account boots. Its rendered battle Editors do not
publish either readiness marker or a battle report. The first Editor times out at the script's
240-second process boundary; its log contains Unity login-page CEF failures, while the second
log remains at early native startup. The script exits nonzero and stops its owned Editors,
Worker, Backend and Mongo processes. No game terminal command was observed. The presence of
login-page errors is not proof of the exact startup cause; do not interpret this as a result
handler failure or repeat launches without investigating the Editor startup boundary.

## Result response dependencies from active 1.4.0 sources

| Source consumer | Required contract |
| --- | --- |
| `ServerResponseHandler.OnClassicGameEnded` | Always indexes top-level `LevelExperience`, even when reward fields are absent. |
| Random-match result branch | Expects `Skill`; that branch also indexes `PlacementMatchesRequired` and `MedalsBalance` and uses `lastGameReward`. A partial medal tuple is unsafe. |
| `WinCount` branch | Also indexes `TimeStamp`; publish the pair from validated durable streak authority. |
| `DatabaseGameReward(JToken)` Warbucks object | Requires `BattleRewards`, `ExtraRewards`, `Winstreak` and `League` together. |
| Reward Xp object | Requires `BattleRewards`, `ExtraRewards`, `Winstreak` and `Time` together. |
| Reward GameGold object | Requires `BattleRewards` and `League`; the alternative `Gold` is a scalar. |
| Root `WaitForGameEndResponse` | Waits for animation and then HTTP Success/Error before level release and result presentation. |

These are parser dependencies, not a reward policy. The current result store already exposes
`GetOutcomeStats` from validated accepted terminal payloads. `AcceptAndReleasePairAsync` checks
the frozen manifest and player roster and consumes ordinary cards atomically with result
publication. Reuse that evidence and card receipt rather than consuming cards again in action 62.
Do not mark its `Scored`/`Settled` flags merely because the UI requested results: those flags
represent distinct durable scoring/settlement authority. An authenticated result request must
bind BattleId and the exact participant, wait/retry if host publication is not yet accepted,
and replay one recorded settlement response without granting rewards twice. Client EndReason,
score, currency, obtained cards and progression updates remain assertions.

## Instrumented startup investigation on 2026-10-19

The disposable audit now emits bounded `WAR_BOOT_STAGE` milestones for its execute method,
Splash opening, observer attachment, requested Play Mode, first Editor update and first
unpaused Play Mode update. These markers contain no player IDs, credentials or message bodies.
The wrapper reports the last observed milestone on timeout without dumping unrelated log lines.
No gameplay timing, readiness condition, scene or active Client source is changed.

Run `.local/client-boot-f71dbfb70e60432890ab7203f2b1d1a9` uses the repository admission
template without an override. Both ordinary account boots complete with zero exceptions,
zero invalid bootstrap queries, 70 error-level diagnostics and complete player-data loading.
Both subsequent rendered Editors emit `execute-method`, `splash-opened`, `observer-attached`,
`play-requested`, `editor-update`, and `play-update`, including observer reattachment after
the Play Mode domain reload. This narrows the previously unobserved startup interval:
the audit is invoked and receives an unpaused Play Mode update. It does not establish
continued frame progression, rendered loading completion, or a successful match.
CEF login-page errors remain present and do not alone establish the cause of the stall.
The wrapper exits nonzero at its 240-second boundary and cleans up the owned processes;
neither lobby-ready markers nor rendered battle reports are produced. The updated stage
extractor is separately executed against both completed logs and returns `play-update` for
each; the in-flight wrapper still used its earlier timeout message. The Release build and
both actual Unity account runs compile the new audit. Normal entry, results and rematch remain
unverified. The next diagnostic must distinguish a stopped Editor callback loop from stalled
game frame/coroutine progression after that first update, rather than increasing admission time.

## Bounded Editor progress probe

The disposable audit now samples wall-clock UTC, Editor time, frame count, scene, play/pause/
compilation state, time scale and focused Editor-window type every five Editor seconds.
Each domain limits itself to 48 samples. The wrapper clears the previous run's file and copies
both participants' JSONL progress on success or failure; a copy failure cannot prevent owned
process cleanup. This uses the normal Editor update callback, with no background Unity calls,
synthetic game frames, changed readiness gates or longer admission deadline.

In `.local/client-boot-84dfdadc8ffb4e4ba1e7e98b0375b282`, the first headless account boot
advances from Splash frame 438 to MainScene frame 571 and the second reaches MainScene frame
583. Both subsequent rendered participants record Splash frame zero before Play Mode and frame
two after domain reload, unpaused, with time scale one, compilation inactive and GameView
focused. Neither record advances during the following wall-clock observation. This distinguishes
the observed failure from a continuously sampled Editor with only a stuck loading coroutine:
the audit's Editor update callback stops producing samples too. It does not identify which native
or managed operation prevents further callbacks. Project UnityConnect services are already
disabled in the disposable settings, so simply turning that setting off is not a new fix.

The paired wrapper exits nonzero at 240 seconds with last stage `play-update`. Its progress
artifacts are `Unity-first-battle-progress.jsonl`, `Unity-first-final-progress.jsonl`,
`Unity-second-final-progress.jsonl` and `Unity-second-boot-progress.jsonl` in that run directory.
Both account reports retain zero exceptions, 70 errors and complete loading. No normal battle
report or lobby-ready marker is produced. Owned processes are stopped; no gameplay success is claimed.

### Empty rendered Editor control

`tools/UnityEditorProgressControl.cs` reproduces only the Editor launch, empty scene, GameView
and Play Mode observation in `.local/editor-progress-control`. Its Assets folder contains only
the Editor probe, with no WarFriends runtime, networking SDK, scenes or prefabs. Launch it with
the same Unity 2018.3.0f2 executable and `-noUpm -projectPath <control-project> -executeMethod
UnityEditorProgressControl.Run -logFile <log>`, without batch/nographics flags, hidden as in
the paired harness. An external wrapper caps execution at 60 seconds and stops its own process.

The baseline records frame one before Play Mode and frame two in Play Mode, then reaches that
external timeout. Logs remain at `.local/editor-progress-control/progress-baseline.log` and
`Editor.log`. The control is then changed to set `Application.runInBackground = true` both
before Play Mode and in its callback, in addition to the existing PlayerSettings value. That
second run also times out with frame two and `background=True`; its evidence is `progress.log`
and `Editor-background.log`. Both runs compile and both owned processes are cleaned up.
The control samples using wall-clock UTC, so a frozen Editor-time reading does not suppress
its next observation. Unity login-page CEF errors also appear in the control's completed log.

This reproduces the stalled rendered execution without game code and rejects the proposed
runtime-background flag fix in this environment. It does not prove CEF is the blocking call,
nor certify a normally visible Editor, standalone player, Android or every game startup path.
Do not increase admission deadlines or modify gameplay to accommodate this control failure.
Further normal-pair retries need an independently verified Editor execution path or new
environment evidence; the separate server implementation backlog remains actionable.
