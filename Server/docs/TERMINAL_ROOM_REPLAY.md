# Terminal room snapshot replay

The normal Unity adapter calls `roomLifecycle.Observe(State)` before invoking
`StateReceived`. The first Ended or Aborted snapshot closes the room. Previously
`Observe` rejected every later snapshot with `ObjectDisposedException`, even
when the host repeated exactly the same frozen terminal evidence. This could
block subsequent presentation callbacks after a callback failure or later poll.

`SelfHostedRoomLifecycle` now retains a private clone of its first terminal
snapshot. While closed but not disposed, it accepts only an exactly equal
terminal replay and does not repeat the Closed phase transition. Changed
evidence, a return to Running and every observation after disposal remain
rejected. Mutating the original caller snapshot cannot change the retained
proof. Room lifecycle still does not validate combat outcomes or issue rewards;
transport validation and the authoritative Worker retain those responsibilities.

## Verification

The portable regression first reproduced the second-observation
`ObjectDisposedException` on the previous implementation. Twelve checks cover
Ended and Aborted, exact replay, one phase callback, caller-copy isolation,
changed evidence, nonterminal regression and disposal. These are room-phase
fixtures rather than fabricated authoritative combat outcomes.

`UnityTerminalRoomReplayAudit.RunAsync` exercises the installed SDK through the
actual recovered `SelfHostedBattleClient.Apply` callback route in a disposable
Unity project. It injects one failing `StateReceived` callback and then repeats
the same snapshot twice. Both terminal phases must reach all three callback
attempts, emit Closed once and keep callback-copy mutations out of retained
state. It uses controlled snapshots and a pending UDP socket: no admitted battle,
normal HUD, menu navigation, rendered outcome or two-Unity-client play is proven.
It does not test retry of a failing `RoomPhaseChanged` subscriber.

The corrected portable suite passed 1,334 checks. The Windows smoke run
`Server/.local/smoke-8886273a668845679c77ff5ce5835346` passed those checks,
the Mongo terminal/grant ordering gates and 74 live communication checks.
Static asset audits retained zero missing-script attachments and zero broken
references; the seventeen existing NGUI sprite mismatches are unchanged.

The native Unity 2018.3 component audit passed with the installed SDK; see
`Server/.local/unity-terminal-room-replay.log`. This was controlled Editor
component execution, not Play Mode, source Unity 5.2, Android or rendered UI.

The separate full `--queue-live` run against Release revision `1baef61f2`, before
this SDK change, passed all Backend restart, delayed registration, HTTP/UDP
cancel/ready, Worker crash and unattended cancellation recovery cases. Its log
is `Server/.local/terminal-verify-0f088aae41f64b509713bfe66942b7bd/queue-current-release.log`.
That supersedes the earlier timeout as a later successful run, without deleting
the historical failure record.

## Remaining Client boundary

Aborted deliberately does not project a win or loss. The DeathMatch bridge
currently presents Ended outcomes; explicit recovery to the original cancellation
or menu screen after Aborted remains work. This replay fix does not claim that
navigation, all terminal UI, every multiplayer mode or BattleServer completion.
