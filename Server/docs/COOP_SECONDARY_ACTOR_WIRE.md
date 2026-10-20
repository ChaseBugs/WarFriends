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
