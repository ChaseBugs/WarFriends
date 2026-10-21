# Ice MOBA server references for WarFriends

Reviewed 2026-10-19. Reference directory: `E:/Github/Mobile/Ice_Moba/server`.
This is a read-only source review. The owner reports that this server works; this review did
not start, rebuild, benchmark or independently validate that deployment. The directory is not
a Git worktree, so source SHA-256 values below identify the exact reviewed files.

The recovered WarFriends 1.4.0 Client remains the gameplay specification. Ice MOBA is a
networking/operations reference, not replacement combat rules. Keep .NET 10, protobuf, MongoDB,
Windows/Linux native deployment and the prohibition on runtime Photon and Docker.

The [client integration review](ICE_MOBA_CLIENT_INTEGRATION.md) follows the corresponding Unity
transport, scene/message lifecycle and reconnect code, and inventories remaining WarFriends
online-provider dependencies before physical SDK removal.

## Main finding

Ice MOBA uses C++ services, ACE queues/timers, RakNet UDP and protobuf. The inspected Room
implementation assigns input operations to server frame numbers, broadcasts them, compares
client-reported states/codes, and returns a checkpoint plus subsequent operations on reconnect.
That evidence supports classifying this Room path as input-frame relay with client-state
agreement; it does not establish server simulation of its character combat.

WarFriends already simulates authoritative combat at 30 Hz and has a managed UDP protocol.
Borrow the lifecycle and diagnostic ideas while preserving host authority. Switching to client
state voting or importing RakNet would change a different layer from the missing Client rules.

## Source-backed comparison

| Reference | Evidence in Ice MOBA | WarFriends disposition |
| --- | --- | --- |
| Reliable ordered delivery | `src/libservice/udp_handler.cpp:28`: chunks of at most 500 bytes, `RELIABLE_ORDERED`, channel 0. | Keep authenticated command retries and exact replay. Do not copy this stream framing into raw UDP. |
| Network/logic separation | `udp_handler.cpp:103` enqueues decoded packets; `logic_service.cpp:55` drains work within a time budget. | Already present as bounded input queues and a single state writer in `NetworkWorker`. Preserve bounded work per tick. |
| Fixed frame publication | `src/room/room_pool.h:8` sets 50 ms; `room_pool.cpp:753` stamps and publishes queued operations. | Keep the source-bound WarFriends 30 Hz simulation. Its tick rate is not a tuning value inherited from Ice MOBA. |
| Reconnect payload | `room_pool.cpp:586` and `room_message.cpp:6`: frame, state, seeds and operations after the checkpoint. | Useful model for checking that one authoritative reconnect snapshot and its retained events form a coherent resume boundary. |
| Session admission | `room_manager.cpp:70` checks the provisioned player/code before binding a handle. Input operations are assigned the bound identity at line 135. | WarFriends already has signed match/player/server/manifest grants, HMAC, endpoint checks and generation changes. Keep those stronger bindings. |
| State disagreement diagnostics | `room_pool.cpp:81` groups reported states and identifies disagreement; `update_code` schedules code checks. | Borrow disagreement visibility, not client authority. Add bounded host-state diagnostics with explicit schema/content identities. |
| Room lifecycle supervision | `room_master_manager.cpp:102` creates a child process; line 174 checks creation/lifetime deadlines and reclaims it. | Reference for readiness, capacity release and crash isolation. Evaluate Worker pools rather than automatically adding one process per match. |
| Result forwarding | `room_pool.cpp:701` chooses the most frequent submitted result and forwards it to the room master. | Do not adopt result voting. WarFriends outcomes, score and consumption must come from server evidence and existing idempotent result publication. |

The 500-byte pieces rely on RakNet reliable ordering: `UdpHandler.recv/feed` accumulates them
before extracting a `TPacket`. They are not independently recoverable application chunks.
All inspected sends use channel 0; consequently bulk state and input share the same ordering
domain. Inferring that this policy is optimal for WarFriends would require measurements.

## Existing WarFriends mechanisms to retain

- `src/War.BattleServer/Hosting/NetworkWorker.cs`: 30 Hz monotonic scheduling, four-tick catch-up cap,
  bounded input channel, per-endpoint pending limit, bounded datagram work and drop/backlog metrics.
- `src/War.Shared/PacketCodec.cs`: protobuf packets, explicit authentication and a 1,200-byte cap.
- `src/War.Client/MatchConnection.cs`: one pending mutation identity, retry/recovery APIs and
  authenticated state/event polling. These are not the same wire protocol as RakNet.
- `src/War.BattleServer/Transport/Reliability/MatchReplyTransfer.cs`: frozen replies, 900-byte indexed pages, a
  262,144-byte transfer limit and a SHA-256 digest before acknowledgement publication.
- `src/War.BattleServer/Matches/MatchRouter.cs:184`: idempotent reconnect grants with player binding,
  expiry checks, new sessions and bounded connection generations.
- `src/War.BattleServer/Transport/Reliability/ReliableEventWindow.cs`: bounded event retention and explicit cursors.
- `src/War.BattleServer/Persistence/ActiveMatchJournal.cs`: durable allocation crash markers. This is
  explicitly not a gameplay checkpoint; startup recovers abandoned allocations as unscored
  host-crash results rather than resuming combat from an absent state.
- `src/War.BattleServer/Program.cs:39` and `deploy/warfriends-battle.service`: existing live/ready/
  metrics endpoints and native Linux service restart policy. Do not list these as absent work.

Existing targeted loss/retry/flood, reconnect, restart/outbox and real two-peer UDP tests are
useful evidence. They are not automatically a normal Unity match under combined packet loss,
latency, reordering and reconnect. The preceding complete Battle test run passed 247,923
assertions; this documentation review adds no runtime verification.

## Adoption priorities and proof required

### 1. One reproducible normal Client reconnect gate

Use Ice MOBA's checkpoint-plus-tail concept to audit the existing WarFriends path. Exercise
normal lobby admission, both Unity Clients, movement, an active projectile/card action,
disconnection, replacement grant, authoritative snapshot, event cursor recovery and completion.
Test a lost mutation acknowledgement as well as the reconnect reply, so retry cannot duplicate
card use, shots, units or terminal publication. Reject old sessions and expired event cursors
without silently applying an incomplete state.

Keep this a shared acceptance test of existing mechanisms, not a second reconnect subsystem.
Record the pinned Client/content revisions, fault profile, host/client traces and outcome.
This recommendation does not assert that the complete test currently exists or passes.

### 2. Bounded server-owned reproduction artifacts

Borrow the seed/frame/history diagnostic idea. A useful WarFriends artifact would bind the
manifest/content revision, server RNG state or recorded draws, accepted command identities,
server ticks, authoritative snapshots and a bounded event tail. It must be versioned, bounded,
redacted and independent of untrusted client state. Existing co-op replay/reference fixtures
remain separate; they do not prove a complete live-match crash checkpoint.

A seed alone cannot restore consumed random state, callback order, pending projectile flights,
collision geometry, active buffs, replay receipts or current health. Do not promise live crash
resume until every authority field has an executable restore/continue proof. Hashes can detect
disagreement but cannot prove that client state is a valid replacement for server state.

### 3. Native operational lifecycle tests

Use RoomMaster's creation acknowledgement/deadline distinction as a review checklist for the
existing Worker readiness and control-plane allocation path. Test failed startup, startup
without readiness, crash during a match, capacity release, duplicate registration, restart,
result forwarding and shutdown during allocation. Reuse existing crash/outbox semantics.

Windows and Linux should exercise equivalent outcomes with native service/process management;
Docker is unnecessary. A process-per-match design has content-loading, memory and supervision
costs. Decide Worker-pool isolation from measured failure scope and load instead of copying
Ice MOBA's process count. Linux systemd restart and current health endpoints already exist.

### 4. Broaden transport fault profiles where coverage is missing

Keep existing focused lost-ack and recovery tests. Identify uncovered combinations of loss,
duplication, reordering, jitter, large state transfer and multiple active matches; publish bounded
memory/queue behavior, tick backlog, eventual command outcome and resynchronization results.
Do not declare a gap merely because another project's test has a different name.

## Boundaries that should not be copied

- Client-state or end-result plurality is not battle authority, especially for a two-player game.
- Ice MOBA's `op_all_`/`op_index_` are appended throughout a match and cleared at finalization.
  Preserve WarFriends explicit history/transfer limits rather than introducing an unbounded log.
- `TPacket` copies a native C++ header struct directly into its byte stream. Keep WarFriends'
  explicit protobuf/authenticated framing instead of inheriting ABI-dependent layout.
- Ice MOBA's 3-second peer timeout, 50 ms room tick, 500-byte pieces, 30-second state interval
  and 5-second code interval are project-specific constants, not recovered WarFriends policy.
- The inspected legacy README's MySQL/ACE/Boost/ZeroMQ dependencies do not replace the accepted
  .NET/MongoDB architecture. No external library was downloaded or added for this review.

## Reviewed source fingerprints

These hashes identify source content only. They are not build digests or running-service proof.
Paths are relative to the external reference directory given above.

```text
2e93c711866fe29f45bc7c9f33cceb077a9f4d8e19bb24bde0b43adedb92552f  src/libservice/udp_service.cpp
c9801a382b672c172176b4baaba50281b9ccf4bc3e411f7160ad6f98e0ddcbcd  src/libservice/udp_handler.cpp
dd5e65f6fff50ae729d307e8ade7e08037bfbf67dc04fcc1b19e1649a33edbf7  src/libservice/logic_service.cpp
27ef61871e804cf8ce9640c9b418392f751d67a2f5ac015ffc4cb5936dd0b1a1  src/libservice/tpacket.h
2afbed8f874df8efd0530cff3b9a8d0a171843857d08abdc9f14d3fe894bf646  src/libservice/tpacket.cpp
aeca29477b781d0cc817bae99e38a3528a24c10786bf17e629432a72928fae88  src/room/room_pool.h
85e621d34e4fc1d41d20cd031b8d600f1e39e4b96d5a4f0616add96aa0e475b7  src/room/room_pool.cpp
7a2ebe9176e9c95bbbf4cb73866b156db8e7b81b1516fc9021a2abc6599203e0  src/room/room_message.cpp
4c3f3dc87f05e6f89a3d1403ca6c611f2d7df5923b3991d3e83ce652f52cf3ff  src/room/room_manager.cpp
6a9c7f60f9eb2be6cf1ecce1c8c30a82ee064963f53ad7d3716954352e05b937  src/room_master/room_master_manager.cpp
```
