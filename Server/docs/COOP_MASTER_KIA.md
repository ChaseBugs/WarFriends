# Co-op master KIA boundary

Recovered `MissionsManager.CurrentPlayerOnKilled` calls the selected mission's
`EndMission` only when the local player is the master. `KillMission`,
`ScoreMission`, `SurviveMission` and `BotMission` then resolve their source
objective. In contrast, `GameControllerCoop.OnPlayerControllerKilled` keeps a
non-master KIA peer in spectator presentation while the master continues.

The host already makes completed objectives terminal immediately. Therefore,
while its objective is still unfinished and before the source deadline, a
host-confirmed master death now fails the mission immediately. It does not
remove the master from admission history or label a death as departure. The
existing first-terminal ordering remains immutable; this does not claim native
Unity parity for simultaneous physics callbacks.

## Runtime and evidence

`CoopMissionEngine.FailAfterMasterDeath` validates the started/in-progress
state and exact host tick window before failing the objective and stopping
source spawns. `CoopMatchRuntime` invokes it only from its host-owned damage
transition for the signed source master. A peer's death leaves the mission
running, stops that peer's movement and releases its occupied source cover.
No player UDP command can assert this damage.

`BattlePlayerState.coop_death_tick` is optional protobuf field 57. Its presence
distinguishes an actual death at tick zero from no death. The host records the
tick on the first lethal transition and retains it through snapshots and exact
impact replay. This adds source SDK schema data without replacing the owner's
installed Unity plugin binaries.

Started terminal evidence now requires coherent health/dead flags, signed
vitality, bounded damage revisions and death-tick presence/ranges. An early
`mission-failed` requires the master's death at exactly the terminal tick;
ordinary failure with a living master still requires the original deadline.
A peer's KIA, absent timestamp or absent impact history cannot substitute for
the master boundary. Prestart cancellation cannot carry combat death history.
These checks validate snapshot coherence; physical impact proof still belongs
to the unfinished host collision/damage integration.

## Verification scope

`CoopMasterDeathTests` covers all four source mission types at the objective
kernel, master death under legacy and explicit second-player roles, frozen
terminal evidence and exact lethal-hit replay, tick-zero protobuf presence,
peer spectating and released-cover acquisition. It rejects missing/wrong
death time, a peer death relabelled as master failure, missing impact history
and an overflowing damage revision. A later peer Forfeit cannot replace an
already terminal master-KIA result.

The previous corner no-target fixture killed both allies while leaving the
mission running. That setup is no longer reachable. Its replacement keeps the
master alive in the unsampled movement-start frame after peer KIA, verifies
the exact no-target retry delay and resumes target selection when its pose
returns. It does not weaken master termination to retain the old fixture.

Normal Worker co-op admission, rendered KIA/spectator/result UI, collision-based
live damage, durable per-player settlement and new Linux/Android runtime proof
remain open. This transition does not enable combat or economy authority.

Windows verification: the focused combat-content executable exits zero with
26,368 counted assertions plus the master-KIA and existing role/replay fixtures.
Sequential native Mongo smoke builds with zero warnings/errors, passes 1,051
protocol checks and 74 live MongoDB/HTTP/protobuf/UDP checks, and preserves
terminal evidence across Worker restarts. These results do not establish a
normal Unity KIA/result-screen or a new Linux/Android execution proof.
