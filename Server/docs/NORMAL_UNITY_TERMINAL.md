# Normal Unity terminal and result acceptance

The ordinary two-Unity gate previously exited after reload and reconnect. It did not prove
server termination, recovered GameOver animation, HTTP completion or EndScreen presentation.
`UnityNormalTerminalAudit` adds an opt-in continuation without changing production behavior.

Set `WAR_NORMAL_BATTLE_TERMINAL=1` for `ClientBootSmoke.ps1 -SecondUnityProject ...`.
Use the same disposable projects, isolated Mongo replica set and native Backend/Worker as the
normal entry gate. The thirty-second admission override remains diagnostic.

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
