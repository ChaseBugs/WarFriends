# Ice_Moba integration reference

Inspected local source on 2026-10-19, with an additional Unity client review on 2026-10-20. Reference roots are
`E:/Github/Mobile/Ice_Moba/client`, `server/src`, and `common/protocol`.
This is a static source review, not a successful runtime or deployment test of Ice_Moba.
WarFriends 1.4.0 remains the gameplay and protocol specification.

## Useful integration patterns

### Source navigation for the Unity reference

The following local entry points were rechecked on 2026-10-20. Line numbers are
navigation aids for this snapshot, not a shared protocol contract.

| Source | Entry point | Responsibility to preserve in WarFriends |
| --- | --- | --- |
| `client/Assets/Scripts/Framework/NetworkManager.cs` | `UdpConnect` (24), `AddEvent` (137), `Update` (145) | Create the transport, queue received messages, and deliver gameplay callbacks on the Unity thread. |
| `client/Assets/Scripts/FrameSub/UdpSocketClient.cs` | `SendConnect`, `SendMessage`, `OnReceive`, `Close` | Understand the RakNet transport boundary; retain WarFriends authentication, bounds, and connection lifetime. |
| `client/Assets/Lua/Net/BattleTcp.lua` | `OnConnect`, `OnDisconnect`, `Reconnect` | Separate first entry, unexpected interruption, and deliberate departure. |
| `client/Assets/Scripts/Battle/Battle.cs` | `send_link` (440), `send_reset` (891), `send_in` (898) | Keep participant admission, state recovery, and scene readiness as distinct transitions. |
| `client/Assets/Scripts/start.cs` | `Start` (10-11) | Audit both platform configuration initializers before accepting device startup as self-hosted. |
| `client/Assets/Scripts/Framework/GameManager.cs` | Recharge initialization (32) | Prevent optional platform purchase initialization from becoming a mandatory boot dependency. |

For provider removal, inspect both `Assets/Scripts/platform/platform_config.cs`
and `Assets/Scripts/platform/common/platform_config_common.cs`. The Editor and
device content endpoints differ. A local Editor session cannot establish that a
device build avoids external service calls. Do not migrate their literal endpoints.

### Client source recheck on 2026-10-20

Rechecked `NetworkManager.cs`, `UdpSocketClient.cs`, `BattleTcp.lua`, the link/reset/in
handlers in `Battle.cs`, and platform startup configuration directly in the local client.
The active WarFriends `SelfHostedBattleClient` already uses `MatchConnection`, guards
connection ownership, and maintains an army-binding generation. Extend those existing
boundaries; do not infer that controller integration is absent from an older checkpoint.
Their presence is source evidence, not proof that normal multiplayer gameplay is complete.

Use these acceptance checks when applying the reference:

- Connection acceptance, authenticated admission, scene readiness, and active gameplay
  must remain distinct. A connection dictionary entry is not admission evidence.
- Unexpected disconnection may recover the same match; deliberate departure must cancel
  pending retries and prevent old callbacks from affecting a subsequent match.
- Recovery must restore authoritative state before applying later events. Preserve pending
  command identities when delivery is uncertain rather than issuing new gameplay effects.
- Failed connections must release resources before transport acceptance as well as after it.
  Bound receive storage, decompression, queued callbacks, and work per Unity frame.
- Test a device build with external network access blocked and configured self-hosted
  services reachable. Editor-only endpoint selection cannot establish provider independence.

This recheck changes documentation only and does not remove SDKs or certify either game at runtime.

| Concern | Ice_Moba evidence | WarFriends application |
| --- | --- | --- |
| Separate lobby and battle connections | `client/Assets/Lua/Net/ConnectTcp.lua` requests a gate; `BattleTcp.lua` opens UDP; `BattleStateTcp.lua` uses a separate TCP connection. | Keep legacy HTTP account/progression and the existing self-hosted UDP battle host. Do not add TCP merely to copy this topology. |
| Main-thread delivery | `client/Assets/Scripts/Framework/NetworkManager.cs`: `AddEvent` queues under a lock; `Update` dispatches connection and gameplay messages. | Preserve Unity main-thread callbacks in `SelfHostedBattleClient`. Bound queued work and reject callbacks from an obsolete connection generation. |
| Admission before gameplay | `server/src/room/room_manager.cpp`: `terminal_battle_link` checks a waiting player and code; `terminal_battle_in` requires a bound connection. | Continue using allocator-issued participant grants. A socket connection alone must not authorize input, ownership, readiness, or rewards. |
| Server-bound input identity | `terminal_battle_op` replaces the submitted GUID with the connection-bound player GUID. | Derive actor ownership from the authenticated match participant, never a payload player ID or former Photon master flag. |
| Explicit reconnect and reset | `BattleTcp.lua` distinguishes reconnect from first entry; `Battle.cs` sends `CMSG_BATTLE_RESET`; `room_manager.cpp` handles reset for a bound player. | Re-admit to the existing match, rebuild authoritative views, and retain command/event identities across retries. Do not repeat purchases, spawns, or settlement. |
| Shared protobuf messages | `common/protocol/msg_battle.proto` defines room allocation and result messages; `msg_battle1.proto` defines unit state, operations, link, frame, and code messages. | Keep WarFriends protobuf schemas and generated contracts shared by .NET and Unity. Ice_Moba field numbers and DTOs are game-specific. |

## Transport details that must not be copied blindly

`client/Assets/Scripts/FrameSub/UdpSocketClient.cs` uses RakNet, not a bare UDP socket.
It sends chunks of at most 500 bytes using `RELIABLE_ORDERED` on channel zero.
`server/src/libservice/udp_handler.cpp` uses the same scheme. The receiver reconstructs
an application stream with an eight-byte header: compression flag at byte zero,
16-bit opcode at byte two, and 32-bit body length at byte four.

RakNet supplies reliability and ordering underneath this stream reconstruction.
Copying the chunk loop into ordinary UDP would lose that guarantee. Protobuf supplies
serialization, not authentication, ordering, retransmission, or duplicate suppression.
Keep WarFriends `War.Client/MatchConnection` and its existing authenticated envelope,
replay handling, pending command identity, and reply-transfer implementation.
`BattleConnection` is a connectivity probe and must not become the gameplay transport.

The inspected client also has limitations worth avoiding:

- `NetworkManager.Isconnect` checks dictionary membership rather than admission state.
- Its static event queue and per-frame drain have no explicit work bound.
- `UdpSocketClient.Close` returns before cleanup when connection acceptance has not occurred.
  Failure and cancellation cleanup must release resources even before admission.
- The client framing path does not visibly bound body size or decompressed output before
  dispatch. WarFriends must retain explicit limits at every untrusted parsing boundary.
- `BattleStateTcp.OnConnectFail` immediately reconnects. Use bounded retry/backoff and a
  connection lifetime so an obsolete attempt cannot revive after leaving a match.

These observations are source-level findings, not measured exploit or performance results.

### Connection lifetime and queued callbacks

The Unity client reuses the name `BattleTcp` for reconnects. `NetworkManager.AddEvent`
stores only that name and the message in its static queue; dispatch resolves the Lua
handler by name. There is no connection-generation field at this queue boundary.
`UdpConnect` also replaces the dictionary entry without explicitly closing its previous
value in that method. These are reasons to preserve WarFriends connection-owner guards,
not reasons to replace its adapter with this reference implementation.

For WarFriends, exercise a disconnect event queued by connection A after connection B
has taken ownership, a cancelled connection attempt followed by a new match, and adapter
destruction with pending receive work. Old work must not disconnect B, restart A, or
apply A's gameplay state. This is an integration acceptance requirement, not a claim
that those scenarios have passed a Unity device test.

An additional authority boundary needs care: `RoomManager::terminal_battle_state`
passes `msg.guid()` directly to `sRoomPool->battle_state`, while
`terminal_battle_op` derives the GUID from the connection binding and overwrites
the submitted value. Do not copy the state handler as an authentication pattern.
WarFriends must bind state, readiness, reset, and gameplay operations to the admitted
participant consistently. This is a local handler observation; upstream dispatch
and deployment protections were not verified by a runtime test.

## Photon and retired online-service replacement sequence

### Additional client evidence

`Battle.cs/send_link` sends the player GUID and battle code after clearing the previous
`BattlePlayers` state. `send_in` sends a distinct readiness message, and `send_reset`
clears local state before asking for a reset. These are separate lifecycle steps:
transport acceptance does not establish authenticated participation or scene readiness.
WarFriends should preserve its own admission, scene-ready, and authoritative snapshot
boundaries rather than copy the Ice_Moba message IDs or clear state on every retry.

`BattleTcp.lua/OnConnect` distinguishes first entry from reconnect. First entry changes
the scene state and opens the state connection; reconnect opens the loading UI and
calls `Battle.Start`. Its disconnect handler reconnects only while the battle has not
ended. This is useful evidence for separating reconnect presentation from new-match
creation, but not proof of durable replay safety or authoritative combat in WarFriends.

The reference is not an external-service-free startup template. `start.cs/Start`
calls both platform configuration initializers before loading `main`.
`platform_config_common.cs/init` selects a private-network HTTP endpoint in the Editor,
while `platform_config.cs/init` selects an external HTTP content host outside the Editor.
`Framework/GameManager.cs` also calls the platform recharge initializer, and
`platform.cs/share_init` calls an Android activity method outside the Editor.
Consequently, successful Editor networking would not prove Android independence from
external content, platform bridges, or providers. Do not copy embedded addresses,
provider settings, credentials, or platform initialization into WarFriends.

### Application to the existing WarFriends integration

| Reference responsibility | Existing WarFriends boundary | Remaining verification |
| --- | --- | --- |
| Endpoint selection before networking | `SelfHostedBackendEndpoint`; recovered `BeanstalkUrlCreator` HTTP routing | Normal account/menu flow and Android routing against only configured self-hosted services. |
| Named lobby and battle connections | Legacy HTTP plus `SelfHostedBattleClient` / `War.Client.MatchConnection` | Normal controller call order, admission and readiness for every supported mode. |
| Receive callbacks on the Unity thread | Existing adapter `Update` and connection-owner guards | Leaving, destroying, or replacing the adapter must prevent stale work changing the next match. |
| Separate reconnect from first scene entry | Adapter reconnect and authoritative snapshot handling | Two real clients, interruption, repeated reconnect, leave and rematch without duplicated effects. |
| Platform initialization independent of transport | Bundled OBB loading and retired AWS analytics bypass are documented in `CLIENT_LOBBY_BOOTSTRAP.md` | Audit the complete device boot chain; these individual changes do not prove every provider path is disabled. |

Keep this work incremental. Inventory each Photon call by its gameplay responsibility,
replace that responsibility with the existing self-hosted contracts, and validate its
callbacks before removing serialized components. A networking library, protobuf, or
physics library that runs locally is not an online-service dependency merely because
it is third-party. Remove mandatory external interactions without deleting local
dependencies that the recovered gameplay and assets still require.

### Migration order

1. Keep one self-hosted endpoint configuration for boot, account, allocation, and battle.
   Preserve the recovered `requestId` HTTP contract and existing backend parsers.
2. Boot from bundled assets without waiting for Photon, Google Play, Fuse, Kochava, AWS,
   or another retired provider. `GameLauncher.LoadMainScene` already bypasses Google Play
   OBB download; audit the complete boot chain before claiming offline boot is complete.
3. Use the existing `SelfHostedBattleClient` and `War.Client.MatchConnection`; connect
   normal scene readiness, participant roster, map revision, callbacks, and teardown to
   that path. Check the current integration docs before assuming any bridge is absent.
4. Replace Photon semantics individually: room lifecycle, actor IDs, ownership,
   serialization, RPCs, cached state, reconnect, offline AI, and chat. Preserve recovered
   callback order and gameplay identities; a transport substitution alone is insufficient.
5. Keep hit resolution, spawn eligibility, outcomes, and settlement server-authoritative.
   Ice_Moba input/frame messages are references, not proof that its combat rules fit
   WarFriends physics or AI.
6. Disable online-only provider entry points and configuration requirements before
   deleting their components. Preserve serialized type/GUID compatibility until scene
   and prefab audits show that removal is safe. A retained DLL does not imply permission
   to contact its retired service at runtime.
7. Verify normal scene play with two clients, reconnect, timeout, duplicate commands,
   leave/rematch, AI modes, and server-authored outcomes. Test startup with external
   network access blocked while allowing the configured self-hosted hosts. Re-run asset
   reference audits after component changes and native Windows/Linux transport checks.

This review changes no Unity asset, library, or runtime code. It does not establish
complete Photon removal, full battle fidelity, or successful offline gameplay.
See `CLIENT_COMMUNICATION.md`, `CLIENT_LOBBY_BOOTSTRAP.md`, and `BATTLE_SERVER.md`
for the current implementation and verified boundaries.
