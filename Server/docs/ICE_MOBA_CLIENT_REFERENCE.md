# Ice_Moba Unity integration reference

Reviewed on 2026-10-19 from the local `E:/Github/Mobile/Ice_Moba` checkout.
This is a source review, not a runtime certification of that project. Its gameplay and protocol are not WarFriends contracts.

## Evidence and applicable patterns

Paths in this table are relative to the Ice_Moba root.

| Source | Observed behavior | Application to WarFriends |
| --- | --- | --- |
| `client/Assets/Scripts/Framework/NetworkManager.cs` | Owns named TCP and UDP connections; drains a shared event queue in `Update()`. | Keep transport callbacks separate from scene/UI work; dispatch Unity changes on the main thread. Bound work per frame and queue capacity. |
| `client/Assets/Scripts/FrameSub/UdpSocketClient.cs` | Uses RakNet, connection notifications, ping, a 3-second transport timeout, and reliable ordered channel zero. | Model connecting, accepted, failed, disconnected, and recovering explicitly. Keep WarFriends transport and its existing delivery guarantees. |
| `client/Assets/Lua/Net/GameTcp.lua` | Separates initial login from relogin using the saved game code and player GUID. | Distinguish a new authenticated session from recovery; use WarFriends server-issued credentials and ownership checks. |
| `client/Assets/Lua/Net/BattleTcp.lua` | Despite its name, connects through `UdpConnect`; distinguishes intentional departure from unexpected disconnect and reconnects to the saved endpoint. | Preserve departure intent and recovered battle callbacks. A transport reconnect alone must not grant participation or replay gameplay commands. |
| `common/protocol/*.proto` | Shared proto2 schemas have generated Unity C# and Lua counterparts. | Maintain shared protobuf contracts and generation checks; do not copy Ice_Moba message IDs or DTOs. |
| `client/Assets/Scripts/Battle/Battle.cs` | Serializes/deserializes typed battle messages with protobuf-net. | Decode typed messages before presenting them; retain WarFriends server authority over combat outcomes. |
| `server/src/libservice/udp_handler.cpp` | Mirrors the client's 500-byte chunks on reliable ordered RakNet and checks receive storage/packet bounds. | Test both ends of framing and malformed-input handling. Raw UDP cannot inherit RakNet ordering or reassembly implicitly. |

## Wire format is not compatible

Ice_Moba's application header occupies eight bytes: a compression flag at offset zero, an opcode at offset two,
and a body length at offset four. The client uses `BitConverter` and sends the resulting frame in chunks of at most
500 bytes, each behind RakNet's `ID_USER_PACKET_ENUM`. Its receive stream reconstructs application frames across
ordered chunks. Compression is selected for outgoing bodies of at least 1,024 bytes.

These details explain that implementation; they are not a proposal for a second WarFriends transport.
Keep `War.BattleServer`, `War.Client`, and `War.Shared` as the existing UDP/protobuf foundation.
Do not introduce RakNet native plugins, Lua, or Ice_Moba's TCP lobby protocol merely to remove Photon.

## Defects and limitations to avoid

- `UdpSocketClient.Close()` returns when `is_connect_` is false. Connection failures can therefore leave a created
  peer undisposed. Cleanup must own and dispose resources even before connection acceptance.
- `NetworkManager.Isconnect()` checks dictionary membership rather than connection acceptance. Track actual states.
- `NetworkManager` uses an unbounded static queue and drains it completely in one frame. Bound both storage and work.
- The client receive parser has no explicit maximum body length or decompressed-size limit at this boundary.
  Enforce limits before allocation, buffering, and decompression.
- All shown UDP sends use reliable ordered channel zero. Do not impose its head-of-line behavior on every
  WarFriends movement snapshot; choose delivery semantics from each existing message contract.
- `GameTcp.OnDisconnect()` tests `BattleTcp.Isconnect` as a Lua function value without calling it.
  Do not transfer this branch as a connection-state check.
- This review does not establish that Ice_Moba has no external online dependencies or that its authentication,
  encryption, replay protection, reconnect behavior, and native plugins are production-safe.

## WarFriends migration sequence

1. Use recovered WarFriends builders, parsers, and callback order as the behavioral specification. Inspect the
   current `SelfHostedBattleClient` and controller bridges before adding another abstraction; integration already exists.
2. Audit each remaining Photon call by behavior: room lifecycle, actor ownership, object identity, RPC,
   serialization, region queries, disconnect, chat, and offline branches. Map each required behavior to an
   authenticated self-hosted replacement or an explicit unavailable result.
3. Keep scene/UI changes on Unity's main thread. Reject callbacks from a destroyed scene or superseded connection;
   release owned resources once on failure, cancellation, scene change, and shutdown.
4. Recover from a server-validated session and authoritative state. Check intentional departure, stale messages,
   duplicate commands, admission expiry, and terminal-result replay separately.
5. Audit boot dependencies separately from battle transport: Fuse, Kochava, Google Play, AWS, analytics, ads,
   and remote configuration. Replacing Photon does not disable these automatically. Preserve bundled/server-owned
   configuration and explicit failure behavior without fabricating purchases, login success, or rewards.
6. Retain recovered SDK type identities until scenes and prefabs no longer require them. Remove runtime startup
   paths before deleting binaries; verify asset references after deliberate removals.
7. Prove the normal Unity boot-to-match-to-result flow with outbound internet unavailable and the local backend,
   battle Worker, and MongoDB reachable. Include loss, reconnect, departure, scene reload, and process shutdown.
   SDK or native server tests alone do not prove this acceptance boundary.

No Client code, assets, or Ice_Moba files were changed by this reference review.
