# Prestart cancellation ordering

`--prestart-cancellation-ordering-only` enumerates every ordering of the first
player's ready command, the second player's ready command, countdown expiry and
prestart cancellation. This models serial execution by the Worker's simulation
reader; the test deliberately does not call a non-thread-safe engine from
parallel tasks and present that as a production race.

All 24 permutations must execute. Exactly two permutations enter Running before
cancellation (the two ready-player orderings followed by the expiry tick); those
must reject cancellation and retain Running. The other 22 must freeze an aborted,
unscored, winner-free `cancelled-before-start` result. Each result is validated
through the durable terminal envelope validator. Later ticks, fresh ready command
IDs and repeated cancellation must leave its exact terminal bytes unchanged.
A separate 25th case cancels before either admission and rejects both late
participants. Synthetic fixture weapon values are not recovered balancing data.

The standard Windows/Linux smoke scripts run this focused executable gate.
Native Windows execution passes; Bash syntax checking is not Linux runtime proof.
This closes the engine ordering gate only. Separate
[actual HTTP/UDP cases](LIVE_PRESTART_CANCELLATION_RACES.md) now cover late Ready,
concurrent dispatch and Running-first refusal. Deterministically paused
registration/grant publication and broader network schedules still need proof. The existing service, replay, ownership
and Worker-outage tests remain separate evidence. B31/B36 and the complete
BattleServer objective remain partial; no complete gameplay claim follows from
these deterministic engine cases.
