# Battle RPC migration ledger (active 1.4.0 client)

The [communication inventory](client-communication-inventory.json) records 165 methods marked as Photon RPCs, 173 literal calls, 35 serialization occurrences, 98 gameplay files using Photon, and 398 PhotonView attachments. These counts measure source references, not implemented behavior. The inventory identifies the extracted `Clients/ExportedProject` 1.4.0 client; contracts from other versions must be compared separately. No arbitrary RPC name or client-submitted outcome is accepted by the protobuf Worker.

This first reviewed slice covers the battle lifecycle entry points. A mapping means that the Worker has an analogous authority or projection, **not** that the original Unity caller consumes it. Normal Client wiring is still pending.

| Recovered call or method | Source ownership | Required replacement | Current evidence and gap |
|---|---|---|---|
| `LoadingFinishedRPC(int playerID, int stateCounter)` | `GameControllerOnline` loading barrier | Authenticated `ReadyCommand`; Worker starts only when both admitted participants are ready | Ready barrier and 60-tick countdown exist; self-hosted adapter dispatches the bounded equivalent and bypasses the Photon wait loop; normal scene presentation still needs end-to-end proof |
| `FinishChoosingCardsRPC(string upgradesJson, int playerId, int stateCounter, string chosenCards, string selectedBuddyCards)` | `GameControllerOnline` prebattle choice | Typed protobuf `SelectCardsCommand` with card IDs, normal/special/elite upgrade indexes, and buddy IDs; snapshot confirmation is authoritative | Signed manifest and typed selection validation exist; buddy catalog/ownership proof, full upgrade economics, and live Client presentation remain open |
| `StartCameraAnimationFinishedRPC(int id)` | `GameControllerOnline` presentation gate | Authenticated participant presentation flag, separate from loading Ready | Typed PresentationReadyCommand now reaches both host runtimes and the peer snapshot; PVP/Coop preserve the immediate local callback and project host completion onto roster-bound actors. Actual Unity reporter/Worker/SDK peer and reconnect projection pass; full normal camera/controller bootstrap remains open. See [start presentation](START_PRESENTATION.md) |
| `ResyncTimeRPC(float syncTime)` | `GameControllerOnline` clock sync | Host tick/start tick in snapshot; client derives presentation time from host authority | Tick projection exists. Router only validates one finite argument and returns true; it does not apply a callback or transmit a clock change. The authoritative clock is the snapshot tick |
| `SetMapRPC(int i)` | `GameControllerOnline` map selection | Signed map/content identity in allocation manifest | Five recovered maps are pinned; original room/map callback not migrated |
| `RematchRPC(int playerID, int stateUpdate)` | `GameControllerOnline` postmatch negotiation | New Backend-authorized allocation and fresh grants; terminal match remains immutable | Random rematch now releases a retained Ended SDK transport before starting its original fresh-search branch, with controlled native ownership/cleanup checks. A real Unity adapter now completes two fresh Backend/Worker allocations with Mongo pair release and unchanged first-result evidence. Normal second-battle UI proof remains open. Same-opponent friend/co-op consent remains absent; see [random handoff](RANDOM_REMATCH_BOUNDARY.md) |
| `FinishGameMultiplayerRPC(byte gameEndReason)` and mode overrides | `GameControllerOnline`, DeathMatch, WarArena, Coop | Worker-owned terminal reason, winner, stats, durable outbox; Backend accepts once | Prototype terminal/outbox exists; self-hosted path suppresses the Photon presentation RPC; mode-specific outcomes and original callbacks remain absent |
| `StartOverTime_RPC()` | `MatchManager` overtime | Host starts overtime at authoritative duration and emits an event/snapshot | Worker overtime exists for rifle modes; normal Client presentation absent |
| `FireNetworkRPC(Vector3 to, bool fake, byte type)` | `Weapon` firing copy | Validated fire intent; host resolves cadence, projectile, hit, damage and ordered event | Rifle/shotgun paths exist; other weapon modes and original weapon bridge absent |
| `SetHitByPlayerRPC`, `SetHitByUnitRPC`, `EnviromentalHitRPC` | `MatchManager` hit attribution | Host-derived impact/kill credit in terminal evidence | Player/shield/barrel subsets exist; full unit/environment and mode stats absent |
| `FreezeRPC(bool freeze)` | `EnemyController` unit status | Host-owned status application/expiry; snapshots render it | Absent; client Boolean cannot authorize a status |
| `SyncWarperRPC(Vector3 position, Quaternion rotation)` | `EnemyController` warper relocation | Host-owned legal relocation and entity event | Absent; client position cannot be accepted as authority |

The recovered `AIObject` and `AICarBase` RPCs form one entity lifecycle slice. `AIObject.ReSync` sends a live object's fraction, position, rotation, upgrades, card flag/progress/ID; an inactive object sends `ReSyncDisabledRPC`. The receiving `ReSyncRPC` recreates a pooled object only when needed, applies the card state before upgrades, and then loads its visual layers. `AICarBase` additionally feeds the received transform to Photon interpolation. These fields describe a host-owned entity and its presentation, not permission for a player to choose a fraction, upgrade, card progress, or position.

| Recovered method | Required replacement | Current evidence and gap |
|---|---|---|
| `SyncUpgradesRPC(byte fr, UnitUpgrades upgrades)` | Immutable allocator-proven unit lane and fraction in spawn/snapshot state | Worker binds signed normal/special/elite upgrades; normal Client `AIObject.UpgradesLoaded` presentation is not migrated for every unit |
| `StartEnemyBehaviourNetwork(byte newFraction)` | Host spawn/activation event after the entity and faction are committed | Entity spawn events and snapshots exist for supported units; all behavior callbacks and pooled activation are incomplete |
| `SetPower(byte power)` | Host-selected ability/power state if a source caller proves one | No literal caller was found in this inventory slice; keep the mutation closed rather than trusting an arbitrary byte |
| `SpawnByCardRPC(float progress, string cardId)` | Backend-proven card selection and host-derived level/progress attached to the spawn | Card-aware unit stage and co-op HP sources exist; full card effect/ownership and normal Client presentation remain open |
| `ReSyncRPC(fr, position, rotation, upgrades, spawnedByCard, progress, cardId)` | Validated full active-entity snapshot plus source identity and allocator state | Paged `BattleArmyEntityState` and reconnect snapshots carry supported entity pose/health, but do not yet reproduce every card/upgrades/behavior field or pooled recreation callback |
| `ReSyncDisabledRPC()` | Host despawn/tombstone event and absence from the active entity roster | Spawn/despawn event kinds and paged active roster exist; normal Client pooled teardown/reconnect proof remains incomplete |
| `AICarBase.ReSyncRPC(...)` override | Same entity snapshot plus ordered vehicle transform samples for interpolation | Host vehicle position/rotation projection covers reviewed families; the original `mPhotonTransform.AddNewState` renderer path is not migrated |

## Local solo pool slice

`NetworkReInstantiate` and `NetworkReInstantiate_1` represent the remote half of
NetworkObjectPool creation/reuse. The four public solo commands now perform only
their original local pool operation because an offline room has no Others
recipient. First-free-slot selection uses the local model rather than Photon
master identity. [The source and native fixture](LOCAL_SOLO_POOLING.md) document
the exact boundary. Pool initialization/view registration and online host-owned
entity projection remain open; local pool IDs are not Worker authority.

## Cached legacy sends during self-hosted ownership

Both PhotonCachedRPC public send overloads now explicitly reject retained
self-hosted ownership, and Update discards a pre-admission legacy queue rather
than replaying it through Photon. Room reset directly clears inactive caches;
the receiver registry no longer duplicates re-enabled or retains destroyed
objects. [The native boundary checks](CACHED_RPC_BOUNDARY.md) prove those scoped
behaviors with a controlled SDK owner. This is a closed legacy transport path,
not an implementation of arbitrary RPC replacement or a full battle proof.

Next review must classify every remaining inventory RPC, dynamic/cached RPC call, stream, room/player property, offline room, and attached PhotonView as a validated command, host event, snapshot field, or local presentation behavior. Each row then needs a replacement test and a normal Client consumption proof. Until that review and integration pass, B01, B31, and B33 remain incomplete.
