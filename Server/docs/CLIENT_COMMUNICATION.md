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

### Implemented: the legacy boot chain

`War.Backend/Legacy/` now serves the recovered client's own channel at `/check.php` and
`/index_09_25_2015.php`, alongside — not replacing — the new `/v1` protobuf API. Only the host in
`BeanstalkUrlCreator` needs repointing; the paths match what the shipped client requests.

Shapes established from the client's parsers and locked in by `scripts/LegacySmoke.ps1`
(**75 assertions**, run against live MongoDB):

- Top-level response keys are **bare JSON**, because `ServerResponseHandler` reads them with
  `Convert.ToInt32`/`ToString` straight off a `Dictionary<string, object>`. Wrapping `Result` or
  `Time` in an AttributeValue breaks the client.
- `Player` and `PlayerData` are **DynamoDB AttributeValue JSON** (`{"Id":{"S":…},"Level":{"N":…}}`),
  proven by `StringParser.ParseString(key, databaseType, dict)` evaluating
  `dict[key][databaseType]`. `N` is emitted as a string, DynamoDB's real wire shape.
- Each of the **16** `DatabaseSerializedObjectGeneric<T>` subsystems loads its own blob from
  `PlayerData` keyed by `typeof(T).Name`, with a JSON document escaped inside an `S` string.
  A **missing key is not an error**: `Load` falls through to `LoadEmpty()`, an
  `Activator.CreateInstance` default. Omission is therefore the correct encoding of "new account",
  and no starter blob is synthesised.
- Mandatory keys, indexed without a presence check: `CreateAccount` needs `Player`, `Token`,
  `Password`, `PlayerData`, `Time`; `LoginToCustomAccount` needs `Player`, `AccountType`, `Token`,
  `Password` (and **not** `PlayerData` — the client follows up with `GetPlayerData`);
  `GetPlayerData` needs `Time` and `PlayerData`; `GetAllMessages` needs `Items` even when empty.
  Every other key in these responses is `ContainsKey`-guarded and may be omitted.
- **Client dispatch quirk:** the failure branch triggers only on `Result > 10`, so
  `SameFacebookAlreadyCreated` (3) and `AccountAlreadyCreated` (4) reach the *success* handler.
  `LegacyResponse.Failure` refuses to emit a sub-11 code for this reason.
- `check.php` must return exactly `ok`. It is a reachability probe: no session, no rewards.
- `GetConfigurations` is not JSON — `success;<version>;<versionsJson>` leaves the client on its
  shipped Google2u sheets.

Authority held server-side: the guest `Password` and `Token` are server-generated (PBKDF2-SHA256,
600k iterations; the token is stored hashed and rotated on every login, and is bound to its
`PlayerId`). The client's `StartingGold`/`StartingWarbucks` arrive on an unauthenticated action
from a Fuseboxx payload and are logged and discarded; `Legacy:Starter` is the authority. Actions
outside the boot chain return `ServerMaintenance` and log, rather than a hollow `Success` that
would send the client into a handler indexing keys that are not there.

Offline deployment: `Regions` is never emitted, because it deserializes to a
`Dictionary<CloudRegionCode, int>` of Photon Cloud region pings and no Photon is reachable. The
client's null guard leaves `bestRegions` null, which is the accurate representation. Plain-HTTP
serving is opt-in via `Legacy:AllowInsecureHttp` and logs a warning; it is not a default.

### Implemented: buffered request replay

`RequestBufferManager`/`RequestBuffer` are the client's own offline queue: UI actions are appended
locally, `Save()`d, and sent as a batch either via `SendRequestBuffer` (98) or, for anything still
unacknowledged, attached to the next `GetPlayerData` (34) as the `Buffers` field. `War.Backend/Legacy/LegacyBuffer.cs`
and `War.Persistence/LegacyBufferStore.cs` implement both paths.

- **Wire shapes differ from the boot chain.** `ProcessBuffer` reads `RequestsResults`/`BufferId`
  with the single-argument `ParseString` (a bare `ToString()`), and each result entry with
  `ParseIntToken`/`ParseLongToken` — so buffer results are **plain JSON, not DynamoDB
  AttributeValues**. `RequestsResults` itself is a JSON array serialized into a string field.
- **On success the client needs only `ActionId`/`Result`.** Every other field
  `ProcessBuffer` reads on a request's success branch is `!= null`-guarded; the rollback fields
  (`LevelName`, `Weapon`, `InventoryData`, `data`, …) are read only on that action's specific
  failure code, and must carry the authoritative state for the client to revert to.
- **Idempotency is claim-then-apply**, keyed by player + buffer id + request index per
  `Server/AGENTS.md`. `LegacyBufferStore.TryClaim` pushes a null-result placeholder conditional on
  the index being absent; `Complete` fills in the result afterward. A crash between the two leaves
  the index claimed-but-unresolved, and replay reports a failure rather than risk re-granting —
  see the remarks on `LegacyBufferProcessor` for why that direction of error is preferred.
- **Implemented actions are the five whose effect needs no catalog data**: `WeaponWasShown` (104),
  `ArmyUnitWasShown` (105), `VisualWasShown` (191), `EquipWeapon` (116), `UpdateEquippedUnits`
  (1003). The other 22 buffered actions are gold/warbucks/scraps economy or cosmetic-catalog
  purchases; they need the price/reward tables from the client's Google2u sheets, which are not yet
  imported, and return `ServerMaintenance` rather than a fabricated success. Granting an unpriced
  purchase would be worse than refusing it.
- `PlayerState.cs` models the three blobs these five actions touch — `LevelManagerData`,
  `InventoryData`, `DecalManagerData` — field-for-field against the client's POCOs, explicit
  `JsonPropertyName`s included (`equippedID`'s casing is not a typo). The other 13 subsystem blobs
  remain opaque strings, unread and unwritten by buffer processing, until an implemented action
  needs to mutate one.

### Implemented: profile and presence

Six catalog-free actions from the `Server_guide.md` "Profile/settings/presence" domain:
`UpdateDeviceToken` (13), `ChangeLanguage` (150), `ChangePlayerCountry` (196), `UpdateSettings`
(165), `ChangePlayerName` (139), `GetPlayerInfo` (170). See `todo_list.md` for the full checklist
this fits into.

- `ChangePlayerName` reproduces `PlayerAnalytics.renameGoldPrice` exactly: free while
  `RenameCount == 0`, else `2^(RenameCount-1) * Constants.rowIds.SecondRenameGoldCost`. That row
  value has not been extracted yet, so a priced rename returns `ServerMaintenance` rather than a
  guessed price — never free, never charged an invented amount. The shift is capped at 30, not the
  client's 31, because the client's own `int` arithmetic overflows negative at 31; reproducing that
  would let a high rename count buy a name for negative gold, so the cap is a deliberate safety
  deviation from the source, not new gameplay logic.
- `GetPlayerInfo` surfaces a real, source-verified subtlety: `OnGetPlayerInfo` reads
  `mResponse["PlayerInfo"]` as a **direct index on the top-level response `Dictionary<string,
  object>`**, not through `ContainsKey` or a nested `JToken` (which never throws on a missing key).
  A genuine .NET dictionary throws `KeyNotFoundException` on a missing key even though the caller
  immediately compares the result to `null` — so an unknown player id must still emit
  `"PlayerInfo": null` as an explicit key, never an omitted one. This is the one boot/profile
  response key discovered so far where "guarded with `!= null`" does **not** mean "safe to omit"
  the way it does for every `PlayerData`/nested-`JToken` field. `DeviceToken` is withheld from this
  projection since it has no use to a third party and the client's reader never requires it.
- `ChangePlayerCountry` has no case at all in the client's response switch — nothing reads the
  body, so a bare `Result` is the entire contract.

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
2. Define complete typed account/bootstrap DTOs from all 1.4.0 loaders and provide authoritative starter/catalog state. Replace the HTTP adapter/parser together, preserving callback order and buffered rollback semantics. **Partly done** — see [Implemented: the legacy boot chain](#implemented-the-legacy-boot-chain), [Implemented: buffered request replay](#implemented-buffered-request-replay) and [Implemented: profile and presence](#implemented-profile-and-presence), and the full checklist in `todo_list.md`. The transport, envelope, AttributeValue encoding, session authority, the boot actions (`check.php`, 157, 118, 30, 34, 5, 29), claim-then-apply idempotent replay of 5 of the 27 buffered actions (104, 105, 191, 116, 1003), and 6 catalog-free profile actions (13, 139, 150, 165, 170, 196) are served and covered by `scripts/LegacySmoke.ps1` (75 assertions). Still outstanding: the remaining ~157 actions; the 22 economy/cosmetic-catalog buffered actions, which need the Google2u price/reward sheets before they can grant anything real; the catalog/starter *content* beyond scalar balances; and the tutorial handoff (`BattleId`, 119, 120).
3. Add a backend-owned two-player allocation, participant-bound tickets, and a battle state machine. The current connectivity grant does not represent a match.
4. Map the 398 view attachments into stable entity bindings. Replace room/ownership/offline lifecycle calls before touching individual combat RPCs.
5. Implement cover movement, weapons/ammo/cooldowns, hit validation, damage, unit AI and War Cards server-side. Convert each RPC into either a client command or server event; do not create an unrestricted generic RPC relay.
6. Add reliable command/event delivery, snapshots/interpolation, loss/reordering tests, reconnect and bounded replay. Current UDP supports authenticated hello/ping/pong/disconnect only.
7. Replace Photon Chat with authenticated WSS, Mongo-backed membership/history and rate limits. Add internal authenticated result submission and atomic/idempotent Mongo settlement.
8. Run two Unity clients through campaign/tutorial and PvP, then remove Photon/PUN/Chat sources and DLLs once no code or serialized dependency remains. Verify all 12 scenes and 781 prefabs again.

The existing Unity runtime has not been rewired in this checkpoint. The new server and portable SDK contain no Photon dependency; that does not mean the old Unity client is already Photon-free.
