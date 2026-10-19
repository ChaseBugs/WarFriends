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
