# Recovered 1.4.0 communication contracts

Inspected 2026-09-19 against `Clients/ExportedProject`, not the older 1.6.0/4.9.5 client. The machine-readable [inventory](client-communication-inventory.json) records source paths, line numbers, signatures, and source SHA-256 digests. Regenerate with `python Server/tools/inventory_client.py`.

## HTTP account/progression channel

`BeanstalkUrlCreator.CreateUrl()` selects `index_09_25_2015.php` on the original environment host. `BeanstalkServerManager.GetServerRequest()` posts form fields to that single URL. **This is not the older `/<action>/<version>` transport.**

Common fields are `requestId` (DatabaseAction integer), `Version`, `Os=android`, `SheetConfig`, and action-specific string fields. The header `App-Version` carries the short version. Most authenticated calls add `Token` and `PlayerId`; the account-management allowlist differs. Null/empty action values become the literal string `null`. Debug and cheat flags are client assertions, never authorization.

The recovered enum contains **175 named actions**. [LEGACY_ACTIONS.md](LEGACY_ACTIONS.md) lists every ID, with references in the JSON inventory. Examples:

| Operation | ID | Evidence / constraints |
|---|---:|---|
| LoginToCustomAccount | 30 | Distinct from provider login and account creation |
| GetPlayerData | 34 | Includes buffered requests; response is a full initialization contract |
| GameEnded | 62 | Client-reported outcome/statistics must not authorize rewards in the replacement |
| GameStartedMaster / Client | 64 / 65 | Original peer-hosted PvP lifecycle |
| SendRequestBuffer | 98 | `BufferId`, invariant `Count`, JSON `Requests` |
| CreateAccount | 118 | `Locale`, invariant `UtcOffset`; optional Fusebox starting-currency assertions |
| ChangePlayerName | 139 | Do not substitute a later client's action numbering |
| UpdateRegionPings | 140 | Distinct from later-version protocol guidance |
| GetConfigurations | 157 | Raw semicolon-delimited configuration stream |
| ChangePlayerCountry | 196 | Preserve the exact recovered request builder during migration |
| CheckDailyReward / ClaimDailyReward | 1001 / 1002 | Separate check and mutation |

`RequestBuffer` stores ordered requests with `{action,data}`; `data` is itself serialized content. `RequestBufferManager` persists pending work and `GetPlayerData` can carry `Buffers`. Buffered economy operations require idempotency keyed by player, buffer identity and request position, exact request validation, server-owned prices, and per-action results. A retry cannot apply a purchase twice. Request/response inventory counts are not coverage claims.

`ServerResponseHandler.ServerRequestFinished()` ordinarily reads a JSON dictionary and its `Result` code; values greater than 10 enter error handling. It has **137 directly indexed response keys** (nested DTO fields add more). `GetConfigurations` bypasses normal JSON parsing; `GameConfigurationManager.PrepareConfigurations()` parses semicolon sections. `GetCheckRequest()` posts to sibling `check.php`; connectivity checking expects the recovered acknowledgement.

`LoadPlayerData()` calls `DatabaseSerializedObject.LoadObjects()` and consumes Dynamo-style typed values such as `Gold.N`, `WarBucks.N`, `Level.N`, dog-tag fields, and serialized `S` strings. It also triggers inventory, tutorial, calendar, notification, and UI initialization. A small replacement `PlayerProfile` is **not** a compatible stock-client boot response. The new `/v1` protobuf account API is deliberately separate and currently used by the new SDK/smoke clients only.

## Photon realtime and chat channels

Core Photon types occur in **98 gameplay source files**. The inventory finds **165 `[PunRPC]`/`[RPC]` method definitions**, **173 literal `.RPC()` calls**, **35 `OnPhotonSerializeView` occurrences** (definitions and calls), and **398 PhotonView attachments** in scenes/prefabs. Dynamic calls through `PhotonCachedRPC` require separate review; these counts are not all possible runtime messages.

| Boundary | Recovered responsibility | Replacement ownership |
|---|---|---|
| PhotonConnectionManager | Region pings, cloud connection, room creation/join, random matchmaking, reconnect callbacks | Backend matchmaking/allocator + battle-session state machine |
| RoomConnection subclasses / PlayerProperties | SQL lobby filters, two-player room selection, custom room/player properties | Validated server matchmaking criteria and authenticated participants |
| PhotonView / PhotonLevelIDChanger / PhotonLevelView | View IDs, observed components, scene object ownership | Stable server entity IDs and an audited scene-entity map |
| PhotonCachedRPC | Delayed/buffered local and online RPC delivery | Explicit event lifecycle, reliable delivery, bounded replay |
| PlayerNetworkStatus / GameControllerOnline | Match state, rematch, disconnection, peer-host/client branches | Authoritative match lifecycle and reconnect snapshot |
| PhotonTransform / OnPhotonSerializeView | Ordered position/rotation and component streams | Typed snapshots, sequence/tick numbers, interpolation |
| AIObject, weapons, vehicles, CardManager RPCs | Spawns, combat effects, damage/death, War Cards | Validated client commands; server-owned simulation/results |
| Chat.cs | Photon Chat connection, public/squad subscriptions, message history and online status | Separate authenticated protobuf-over-WSS chat service; never combat UDP |

`PhotonConnectionManager.Start()` configures send rate 26 and serialization rate 13, a 4,000 ms disconnect timeout, and MTU 1,500. The replacement starts with a 30 Hz host loop and a 1,200-byte authenticated datagram budget; snapshot frequency requires measurement, not a blind translation of Photon settings.

`CustomTypes.Register()` installs custom Photon type 90 for `UpgradeSlots.UnitUpgrades` (24 bytes) and type 88 for `PlayerInventory.EquippedWeapon` (10 bytes). Replace these with explicit protobuf messages bound to authoritative loadouts; never accept client-sent HP/damage multipliers as authority.

`PhotonConnectionManager.JoinOfflineGame()` still creates an offline Photon room. Therefore campaign/tutorial paths also require migration before removing Photon assemblies. Deleting PhotonView components now would break both serialized references and local/offline behavior.

`SocketHandler` additionally contains a BestHTTP Socket.IO connection to localhost:3000, with a `chatmessage` listener and player ID query. This is a separate experimental-looking code path, not proof that production chat used Socket.IO. The inspected `Chat.cs` explicitly constructs Photon Chat's `ChatClient`. Provider SDK traffic (analytics, purchases, social) is a third category and is not replaced merely by changing the game server URL.

## Required migration sequence

1. Prove the new SDK and protobuf HTTP/UDP admission path (implemented outside gameplay).
2. Define complete typed account/bootstrap DTOs from all 1.4.0 loaders and provide authoritative starter/catalog state. Replace the HTTP adapter/parser together, preserving callback order and buffered rollback semantics.
3. Add a backend-owned two-player allocation, participant-bound tickets, and a battle state machine. The current connectivity grant does not represent a match.
4. Map the 398 view attachments into stable entity bindings. Replace room/ownership/offline lifecycle calls before touching individual combat RPCs.
5. Implement cover movement, weapons/ammo/cooldowns, hit validation, damage, unit AI and War Cards server-side. Convert each RPC into either a client command or server event; do not create an unrestricted generic RPC relay.
6. Add reliable command/event delivery, snapshots/interpolation, loss/reordering tests, reconnect and bounded replay. Current UDP supports authenticated hello/ping/pong/disconnect only.
7. Replace Photon Chat with authenticated WSS, Mongo-backed membership/history and rate limits. Add internal authenticated result submission and atomic/idempotent Mongo settlement.
8. Run two Unity clients through campaign/tutorial and PvP, then remove Photon/PUN/Chat sources and DLLs once no code or serialized dependency remains. Verify all 12 scenes and 781 prefabs again.

The existing Unity runtime has not been rewired in this checkpoint. The new server and portable SDK contain no Photon dependency; that does not mean the old Unity client is already Photon-free.
