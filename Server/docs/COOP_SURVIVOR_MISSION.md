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

This is an internal mission foundation, not a playable survivor feature.
Normal `CoopMatchRuntime` Forfeit still ends a started mission. Before routing
that command to continuation, the runtime must deactivate inputs, targeting,
cover and shield ownership, retain already emitted attack provenance, project
peer-specific terminal/spectator state, and connect the normal Client's partner
notifications and presentation. Result validation and durable settlement must
distinguish a departed ally from the survivor's later terminal outcome. No
combat, reward or Worker admission gate is opened by this change.
