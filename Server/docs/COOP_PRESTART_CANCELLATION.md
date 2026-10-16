# Co-op loading cancellation

Recovered `GameControllerCoop.StartMultiplayerGame` shows the friend-waiting
loading dialog. Its `DialogResult` callback returns to the mission screen,
disconnects and quits. `StartGame` calls `MissionsManager.PlayCurrentMission`
later. Cancelling the loading stage must therefore remain distinct from a
started mission ending in forfeit.

`CoopMatchRuntime` previously classified every authenticated Forfeit command
as `Ended/forfeit`, even when only one ally had joined or one ally was ready.
It now removes the participant and uses `Aborted/cancelled-before-start` until
the server-owned mission has actually started. The reply code remains
`forfeit`, preserving the accepted command contract. No winner or reward
eligibility is introduced. Existing control-plane cancellation already used
the aborted reason; this closes the gameplay-command discrepancy.

`CoopTerminalScoreValidator.ValidateNonSuccess` now requires `Coop.Started` for
`Ended/forfeit`. A prestart snapshot cannot become accepted forfeit evidence by
changing its phase and reason. Previously emitted prototype records with that
invalid combination are no longer valid inputs to this validator; immutable
stored results must not be silently rewritten to conceal their provenance.

## Verified boundary

`CoopPrestartCancellationTests` executes the actual mission runtime with the
recovered catalog and signed allocation. It covers one admitted ally waiting,
two admitted allies with one ready, exact command replay, frozen tick/evidence
after cancellation, rejection of forged prestart forfeit evidence, and the
existing started-forfeit terminal envelope. A mission started at tick zero is
identified through `Started`, not a nonzero `StartTick` heuristic.

The command dispatcher now delegates to short ready, forfeit, weapon-selection
and reload methods in `CoopMatchRuntime.Commands.cs`. The recovered readiness,
boss/shield initialization, weapon-animation settling, reload validation and
reply strings retain their existing order and behavior.

## Remaining running-mission behavior

The later [survivor runtime integration](COOP_SURVIVOR_MISSION.md) now keeps a
started mission running when one ally forfeits and another living ally remains.
Recovered `FinishGameCoopClient -> DisalblePlayerAndResumeGame` disables the
departing peer while the master continues; its KIA path also supports spectating.
Dedicated Worker ownership, normal Client departure/spectator presentation,
and durable per-player settlement still need integration. The started-forfeit
fixture now verifies continuation after the first departure and terminal
forfeit after the last active departure; normal Client UI remains unverified.

Normal Worker co-op admission, Client loading/cancel UI and full battle-mode
completion remain unverified. This runtime and validator correction does not
open combat authority or reward settlement.

Windows validation: the complete combat-content executable exits zero with
26,368 counted assertions plus the lifecycle fixtures, including after command
handler extraction. Sequential native smoke builds without warnings/errors,
passes 1,037 protocol checks and 74 live MongoDB/HTTP/protobuf/UDP checks,
and verifies evidence persistence through Worker restarts. No normal Unity
co-op cancellation UI or new Linux execution is claimed by these checks.
