# Co-op survivor mission foundation

Recovered `GameControllerCoop.FinishGameCoopClient` calls
`DisalblePlayerAndResumeGame`. That method clears the peer's player point,
marks its network status inactive, shows the partner-left or partner-dead
notification, and disables its GameObject after a real-time delay. It does
not finish the master's mission. Non-KIA departure also resumes the game.

`CoopMissionEngine.ContinueAfterPeerDeparture` now expresses that mission-level
transition separately from terminal `Leave`. It accepts only a running,
unfinished mission with two active participants and an actual departing peer.
It retains one survivor, the original deadline, AI spawning and objective
progress. Duplicate departure, prestart use and removal of the final survivor
are rejected without mutation. Explicit final `Leave` still fails the mission.

The engine freezes score-eligible identities when both starting allies become
ready. A previous loading-stage admission is not a combat owner. Removing an
active peer preserves earned shared points and permits host-confirmed late
attack or deployed-unit credit for the original owner. The frozen roster does
not prove an attack: the internal caller must still establish ownership, the
spawned enemy's death and its typed source credit. Unknown ownership cannot
consume the death receipt.

## Verification and remaining integration

`CoopSurvivorMissionTests` uses the recovered mission and skill-shot catalogs.
It verifies the original survival deadline, replay-safe kill progress, boss
completion, conserved shared/per-player Score, late original-owner credit,
rejection of a former loading identity, and departure boundaries. Kill tests
use confirmed source-scheduled AI spawns rather than client score assertions.
The focused combat-content executable passes its existing 26,368 counted
assertions and this additional fixture.

## Runtime command integration

The recovered `FinishGame` caller distinguishes roles: the master sends
`FinishGameMultiplayerRPC`, while the client sends `FinishGameCoopClient`.
The authenticated runtime Forfeit command therefore continues a started
mission only for a non-master departure with an admitted, ready, living ally
remaining. Master departure still ends the shared mission. The signed
`SceneMasterPlayerId` owns this distinction; older isolated allocations without
that optional field retain their established first-roster master default.
Departure sets `coop_departed`
on the protobuf player snapshot and clears readiness, motion, destination and
shot-pose state. Admission history, position, vitality and command receipts stay
intact. Exact retries return the frozen original reply; a new command receives
`coop-peer-departed`. Polling remains available for observation, while Resume
cannot reactivate a departed peer. The final active departure ends the mission.

Target selection and collision exclude the departed peer. The survivor may
acquire its former cover, and the absent player no longer occupies a shield
for regeneration. Already emitted flight evidence remains intact. Trusted
Score attribution may retain a departed starting owner; new weapon actions
still require readiness. Source master-relative sniper positioning uses that
same signed master identity. No automatic master migration is invented.

Terminal validation binds the active mission roster to departure flags in the
complete signed player history. Survivor success includes only living,
non-departed success rows; timeout retains the original source deadline and
the smaller active roster. A forged departed-player success row is rejected.
`CoopSurvivorRuntimeTests` drives actual commands through moving departure,
released-cover acquisition, protobuf round trip, host-confirmed enemy kills,
survivor success and timeout, a dead remaining spectator, master departure and
an explicit master role that differs from roster order. Cancellation tests
cover both departures, immutable replay and rejection of conflicting departure
history.

The later [peer presentation integration](COOP_PEER_PRESENTATION.md) connects
normal co-op startup to the recovered remote partner-left callback. Local
departed-player exit/spectator presentation and durable per-player settlement
remain unconnected. This is not two-Client gameplay verification. No combat,
reward or Worker admission gate is opened by these changes.
The shared SDK schema contains the new field; this checkpoint does not replace
the owner's installed Unity plugin binaries or claim that their normal co-op
controllers consume it yet.

Windows verification: the focused combat-content executable exits zero with
26,368 counted assertions plus the mission/runtime fixtures. Sequential native
smoke builds with zero warnings/errors, passes 1,037 protocol checks and 74 live
MongoDB/HTTP/protobuf/UDP checks, and preserves pending evidence and acknowledged
tombstones across Worker restarts. These checks do not establish normal Unity
co-op presentation or a new Linux runtime result.
