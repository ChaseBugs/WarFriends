# Co-op secondary actor snapshot contract

`protocol/war.proto` extends `BattleCoopEnemySpawn` additively. Existing field numbers
remain unchanged. Deploy the matching portable SDK with the server: the new SDK
requires the initial crew roster when a transport declares occupied crew seats.

| Parent field | Number | Meaning |
| --- | --- | --- |
| `crew_actors` | 33 | Ordered initial rope-crew lives, retained after detachment or death. |
| `gunner_entity_id` | 34 | Current turret life; a confirmed respawn allocates a new ID. |

Each `BattleCoopCrewActor` carries `entity_id` (1), `slot` (2),
`point_component_file_id` (3), `max_health` (4), `health` (5), `spawn_tick` (6),
`death_tick` (7), and `is_attached` (8). The containing enemy row identifies the
original aircraft. No position, collision body, infantry state or landing flag is
invented by this contract.

## Host publication

- Initial creation binds the reserved seat IDs to source-scaled maximum health.
- Host damage updates health and confirmed death time. Mission confirmation precedes
  publication of lethal health.
- A host-confirmed destination reservation and seat release publish
  `is_attached=false`; animation completion alone does not release the seat.
- Accepted completed descent may reserve a scene point and then release the seat.
  Without a free point, the source starts walking to a normal-spawn fallback while
  retaining that seat binding until a later five-second scaled retry succeeds.
  `is_attached` describes ownership of the source seat, not proof of world placement.
- Death or confirmed detachment removes that slot's pending drop/descent state;
  old motion callbacks cannot use a retired life, and other seats retain their rope.
- Parent destruction kills still-attached actors, preserves detached survivors,
  and confirms the current living turret soldier after the aircraft death.
- Enemy rows retain the secondary lifetime data after active parent registries are
  removed. A detached survivor's later death therefore still reaches the snapshot.
- Turret health/creation/respawn times remain in parent fields 24-28. The current
  turret ID remains in the dead snapshot and changes only on a new life.

## Portable SDK boundary

`CoopCrewSnapshotValidation` validates the complete current snapshot before any
enemy view is published. It rejects primary/secondary ID aliases, duplicate IDs,
missing or reordered initial seats, shared turret/rope seat identities, non-finite
or inconsistent vitality, future deaths, and living attached crew on a dead parent.
Initial crew IDs follow their parent's contiguous reservation; ordinary enemy IDs
may have gaps because that same allocator owns secondary actors and respawns.

`CoopEnemyViewState.CrewActors` contains immutable `CoopCrewActorViewState` values;
`GunnerEntityId` exposes the current turret life. Mutating the decoded protobuf
after projection cannot change those published views. Current-snapshot validation
does not independently prove all historical turret identities across reconnects.

The recovered Unity adapter already projects co-op snapshots through this SDK and
publishes `CoopEnemiesReceived`. New secondary visuals, host-owned collision poses,
automatic descent callbacks, and two-Unity-client reconnect acceptance remain
separate integration work. Protobuf round trips and Editor compilation do not
establish that gameplay acceptance.

## Signed UDP acceptance checkpoint

`CoopCrewUdpTests` uses two independent portable SDK sockets against the actual
authenticated `MatchEndpoint` and a source-backed mission-46 runtime. It compares
secondary lifetimes across both clients, applies explicit host-confirmed crew
damage and gunner death, advances to the recovered gunner respawn deadline, then
reconnects one participant with a new socket, ticket and connection generation.
Crew IDs/health and the current turret life must survive that replacement.
At least one secondary-state poll must use the SDK's real reply-chunk path.

The fixture advances its controlled clock for received datagrams, preserving the
endpoint's per-tick budget. Aircraft pose may legitimately advance between polls;
the comparison owns secondary lifetime fields rather than freezing flight poses.
An initial frozen-clock fixture exhausted that budget during chunk retrieval;
that failed attempt is not validation evidence and no production limit was relaxed.

This is real SDK/UDP delivery and session replacement, not two Unity processes or
the normal Worker clock. Host impacts are explicit fixture inputs, not validated
player-shot collisions. Automatic crew descent, rendering, Worker scheduling,
packet-loss scenarios and full gameplay reconnect remain separate acceptance work.

Validation: the test build passed with zero warnings/errors. Native-enabled Windows
and actual WSL Linux runs passed the new UDP checkpoint and all 28,908 counted
combat-content assertions. The UDP fixture prints its own PASS marker and does not
increase that legacy counter. Logs: `.local/coop-crew-udp-windows-final.log` and
`.local/coop-crew-udp-linux.log`.
