# Host-owned DeathMatch clock and overtime

The normal `GameControllerDeathMatch.Update` now uses the owned self-hosted
snapshot for its recovered time display and overtime flag. It no longer decrements
local frame time or calls the legacy overtime starter while that match is owned.
The existing local-mode branch remains separate.

## Recovered rules and ownership

The original DeathMatch Update subtracts `Time.deltaTime`, then calls
`MatchManager.StartOverTime` when local time reaches zero. That method starts
the source shield-destruction coroutine and sends `StartOverTime_RPC`. Both are
inappropriate for a self-hosted match: the Worker already owns its deadline,
overtime transition, shield destruction and damage coefficients.

The Worker starts its countdown two seconds ahead, derives `EndTick` from the
trusted duration, and publishes a 30 Hz simulation clock. Its `BeginOvertime`
sets `Overtime=true`, clears the scheduled end tick and emits the original
overtime/shield event families. Paused reconnect grace advances `PauseHostTick`
without advancing the simulation clock. Ending a match replaces `EndTick` with
the terminal simulation tick; prestart cancellation preserves its scheduled
future `StartTick`.

The portable SDK's immutable `PvpMatchClock` validates that phase/clock tuple
before the Client changes either time or overtime presentation. It is a readonly
value type, so the per-frame projection does not allocate a clock object.

| Host phase | Recovered time display | Overtime presentation |
| --- | --- | --- |
| Waiting | Zero; no scheduled match clock | Off |
| Countdown | Full scheduled duration, excluding the prestart delay | Off |
| Running | `(EndTick - ServerTick) / 30` | Off until the host confirms it |
| Running overtime | Zero, with no scheduled end tick | On |
| Ended or Aborted | Zero | Retain the host's confirmed flag |

A zero display does not infer overtime. Malformed phases, contradictory
overtime/deadline combinations, excessive duration, expired running deadlines
and unsupported mission/Arena state fail before publishing HUD values. An
aborted countdown may retain a start no more than the original two-second
prestart interval ahead; a future-start overtime claim is rejected.
The 1,800-second duration cap follows current trusted `MatchManifest` validation;
it is not a recovered production matchmaking schedule.

`MatchManager.ApplySelfHostedOvertime` only updates the source presentation flag
and raises the recovered `OverTimeStarted` event on transition. Its source
listeners animate the overtime widget and time HUD. It does not call Photon,
run the local overtime coroutine or grant damage/settlement authority.
While the local scene is still loading, the controller retains the host time
but defers overtime notification until the recovered game is running. This
preserves the original GameStarted-before-overtime presentation order.

## Verification

`UnityPvpClockAudit.Run` invokes the actual recovered DeathMatch Update in an
isolated Editor component fixture with an owned SDK connection. Its original
controllers/providers remain inactive and its PhotonView is intentionally
uninitialized. The baseline reaches `MatchManager.StartOverTime`, attempts its
local coroutine and fails at the legacy RPC call. The fix instead displays the
host's eight seconds despite an expired local timer. Repeated held-tick updates,
deferred loading notification, single overtime notification, regular-state reset, prestart cancellation and
rejection before mutation are covered. This is controlled component invocation,
not real-frame Play Mode or rendered HUD proof.

Portable protocol cases cover waiting, countdown, remaining time, disconnect
grace, zero-time-without-overtime, confirmed overtime, terminal clocks, prestart
cancellation and malformed tuples. The existing live shotgun overtime UDP
fixture also projects the actual countdown and both participants' actual
overtime snapshots; the same fixture verifies host-destroyed shields and equal
overtime event histories. No Worker timing or damage policy was changed.

The final solution build has zero warnings/errors, all 1,166 protocol checks
pass (including 22 clock cases), and the live overtime fixture passes 13 checks.
The native controller audit passes. Static asset audits retain zero missing
scripts/broken references and the existing 17 NGUI sprite mismatches.
The updated SDK also passes the existing live bazooka Play Mode network/effect
regression. That fixture keeps the original game controllers inactive and does
not extend the clock audit into rendered HUD or real-frame controller proof.

The current networking SDK is installed in the active recovered Client with its
digest manifest. Scene/prefab references and GUIDs are unchanged. Source
compilation and these targeted checks do not prove normal camera/UI boot, two
running Unity clients, Android, Unity 5.2 or Linux gameplay. B16/B32 and the
overall BattleServer objective remain partial.
The [subsequent queue cancellation checkpoint](CLIENT_MATCHMAKING_CANCELLATION.md)
covers pending searches and delayed callbacks. Paired allocation cancellation,
the region/bot decision and complete offline room entry remain open.
