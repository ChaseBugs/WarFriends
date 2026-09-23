# Battle Server: implementation and remaining work

Updated 2026-09-19 from [Server_guide.md](../../Server_guide.md). This work adds Battle Server code and a portable Unity networking adapter. Backend gameplay is outside this task. **This is not yet a complete playable replacement for the recovered Photon battle runtime.**

The full active scope and completion gates are tracked in [BATTLE_SERVER_FEATURES.md](BATTLE_SERVER_FEATURES.md). The opt-in [live stationary rifle mode](LIVE_RIFLE_COMBAT.md) connects real UDP commands to source-bound animation, projectiles, collision and health changes.

The Worker supports a [pinned combat content package](COMBAT_CONTENT.md), validates source-bound rifle upgrades before admission and uses its canonical map in rifle combat. Two independent SDK clients verify damage through the real Worker; normal Unity gameplay wiring remains pending.

## What runs

- Existing connectivity-probe channel remains available.
- Optional, operator-provisioned host with **1–32 isolated matches, two participants each**, on the same UDP socket.
- Strict manifest validation, player/host/match/content-bound signed admission, separate ticket/key cryptographic domains from connectivity probes.
- A 30 Hz single-writer state machine: waiting -> two-second countdown -> running -> ended/aborted.
- Ready acknowledgements require the exact manifest digest. No firing before both players are ready and the countdown ends.
- Basic finite-ammo reloadable weapon commands: target-position validation, cadence, clip depletion, automatic/manual reload and reserve conservation.
- Stop-and-wait command IDs with exact reply replay for the last 64 commands per participant; altered retries and skipped/evicted IDs cannot reapply a mutation.
- Pollable full two-player state, authoritative tick/ammo/reload/shot counters, forfeit and idle/admission/duration expiry.
- No Mongo, Backend process, Photon Cloud or Unity process is needed for the Battle tests.

Both available modes remain **unscored**: `RewardEligible` is always false. The original weapon prototype validates ammo/timing and static geometry without live damage. The opt-in rifle mode applies collision-driven damage using server-owned poses and projectiles; it permits cover movement and stationary firing for the eleven recovered assault rifles. Walking fire, other weapon variants, destructible-state changes, AI, vehicles, cards, production allocation and Backend settlement remain unfinished. Synthetic test weapon values are not recovered balancing data. See [player damage evidence and limits](PLAYER_DAMAGE.md).

### Recovered maps and Unity integration

- Initialized player poses cover 61 source clips and 1,065 snapshots at 30 Hz, with 6,390 Unity collider-ray comparisons. A guarded runtime alias repair restores the attached `idle_1`/`run_0` clips under the names requested by gameplay. Local rig blending and procedural aim drive live weapon collision during cover movement and stationary firing. See [player pose evidence](PLAYER_POSES.md).

- Player collision includes validated reference-pose box/sphere geometry, a capsule intersection kernel, rigid placement and a host-only nearest-player/map-occlusion resolver. All 32 exported Unity part-ray comparisons pass; animated parts feed live stationary rifle firing. See [player collision evidence](PLAYER_COLLISION.md).

- `content/recovered-battle-content.json` contains five multiplayer maps, 40 cover nodes, 60 directed complete NavMesh paths, 1,004 collider records, 150 shared meshes, 132 Google2u sheet components and 200 reference Unity Physics raycasts. Source scene hashes and paths are retained. Sheet extraction is evidence, not a validated authoritative economy implementation.
- `RecoveredBattleMap` supports active non-trigger box, triangle-mesh and convex-mesh raycasts. The current fixtures match all 200 reference rays within 0.002 world units. This does not establish full PhysX parity or production performance. Dynamic destructibles still use their initial geometry.
- Mapped matches enforce cover side, start location, adjacency, occupancy and server-timed movement over recovered paths. Movement speed remains trusted manifest input. Serialized cover health is a base value, not final combat health.
- `War.Client.MatchConnection` provides signed UDP admission, ready/fire/reload/move/poll/forfeit calls, bounded retries and pending-command recovery. `SelfHostedBattleClient` exposes it through main-thread Unity events. SDK DLLs are installed under `Assets/Plugins/WarFriends.Networking`; signing code and server secrets are excluded.
- **The adapter is not wired into the normal battle preparation, player, weapon or game-controller flow.** Existing Photon-dependent gameplay is not migrated simply by adding these DLLs. The Unity audit drives the SDK, not a rendered two-player battle.

Rebuild the DLLs with `python Server/tools/install_unity_sdk.py`. Re-export content using the Editor method `SelfHostedBattleExport.Run` and an absolute `WAR_BATTLE_CONTENT_OUTPUT` path, preferably in a disposable project. Export does not save scenes. Unity 2018.3 was used to validate the currently repaired workspace; this is not a claim about the original APK's Unity version.

## Source behavior used

| Behavior | Recovered evidence | Implementation |
|---|---|---|
| Both participants load before start; start scheduled two seconds ahead | `GameControllerOnline.cs`, LoadingFinishedRPC / SyncMatchStart | Ready barrier and 60-tick countdown |
| Reloadable firing removes one clip round and starts reload when empty | `Weapon.cs`, Fire | Authoritative decrement and auto-reload |
| Reload transfers min(clip deficit, reserve), subtracting reserve | `Weapon.cs`, FinishReload | Conserved finite ammo transfer |
| Fire argument is Vector3 target position | `Weapon.cs`, Fire / FireNetworkRPC | Finite bounded target-position DTO; no submitted damage |
| Forfeit maps opponent to WinByForfeit | `GameControllerOnline.cs`, Forfeit/end mapping | Prototype winner/opponent terminal state; not a reward receipt |

Cadence/reload seconds are trusted manifest input, rounded upward to simulation ticks. Idle/admission/duration bounds, command limits and coordinate bounds are explicit prototype policy. Only the basic reloadable weapon resource behavior is implemented; individual weapon firing modes and repeated manual-reload quirks are not claimed as full parity.

The recovered `GameControllerOnline.PlayerDistonnectedBeforeAfterMatch` cancels a room disconnect before play, while `CheckForReconnect` and `MatchManager.mReconnectTimes` use 30/20/10-second reconnect windows during play and `CheckIfDisconnected3rdTime` forfeits after more than three reconnects. As an explicit unscored fallback, an idle participant during the two-second ready countdown aborts with `prestart-disconnect`; it cannot create a winner before `Running`. In `Running`, manifest `IdleSeconds` is the transport inactivity detection threshold. The first three detected disconnects pause simulation, preserve projectiles and timers, and expose a 30/20/10-second host-wall-clock reconnect deadline in each player's snapshot. A higher-generation signed hello resumes play and revokes the previous session; a fourth disconnect forfeits immediately. The other player must remain active at grace expiry or the match aborts without an invented winner. The exact Unity loading/reconnect dialog, pause callbacks, both-player disconnect sequence, and rematch behavior are not integrated yet, so B20/B30 remain partial.

## Run the tests

From repository root:

```powershell
dotnet run --project Server/tests/War.Battle.Tests
dotnet run --project Server/tests/War.Protocol.Tests
```

The Battle test executable starts the real `NetworkWorker` on a temporary loopback UDP port and drives two authenticated peers through readiness, firing, retry and forfeit. It also tests pure simulation deadlines, rejected targets, partial reload, exhausted ammo, duplicate commands, forged admissions, packet replays, endpoint binding and rate limits. It creates one temporary manifest and removes it on exit. The same Battle test suite was also published self-contained and executed under Ubuntu 22.04 in WSL2.

Windows validation on 2026-09-20: full solution build passed with zero warnings/errors; the Battle test run passed 54,662 assertions (poll count can vary), including staged reconnect, match isolation, SDK response-loss recovery, cover movement, source geometry comparisons, and trusted spawned-unit damage composition. Protocol tests passed 1,019 checks; native Mongo/HTTP/UDP smoke passed 74 live checks, including a real two-client pause/resume and old-key revocation, plus two BattleServer process restarts; Battle startup now waits for UDP-bound `/health/ready`; stopping withdraws readiness, returns `control-unavailable` for new control calls, and resolves queued registrations; loopback `/health/metrics` exposes bounded ingress/drop/queue/tick counters and returned HTTP 200 in a running-process probe. A self-contained `linux-x64` Battle test publish ran under Ubuntu 22.04 in WSL2 and passed 54,662 assertions, including real two-peer and 32-match UDP burst, single-sender flood, and 64-sender malformed, unknown-session, and wrong-endpoint floods plus a bound-endpoint burst and eight seconds of 32-match concurrent polling, reordered SDK poll replies, and per-player finish-reason projection; a separate self-contained Worker passed two WSL2 process start, health, SIGTERM and same-spool restart cycles, then a force-killed allocated match recovered as unscored `host-crash` evidence through authenticated poll; an adapted systemd unit passed a local unprivileged ready/start/stop probe, but production-host behavior remains unverified. An earlier Unity 2018.3 Mono SDK admission/ready/fire/forfeit audit passed (`.local/unity-battle-sdk.log`); it does not yet validate the new reconnect presentation. These tests do not certify rendered gameplay, Android, complete combat or Backend settlement.

Optional actual Unity SDK test (use a disposable project with the installed SDK and Editor audit):

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --unity 'C:\Program Files\Unity\Hub\Editor\2018.3.0f2\Editor\Unity.exe' 'E:\Temp\WarFriends-compile'
```

The Battle Worker published for `linux-x64` (framework-dependent, Release). The self-contained Linux Battle test runner and standalone Worker executed under WSL2 Ubuntu 22.04. An adapted systemd battle unit passed unprivileged ready/start/stop with a persistent writable outbox; production host installation and live-match service restart remain unverified.

After the SDK installation, the Unity scene audit opened all 12 scenes with zero missing scripts and passed the GUI, GameController, preview-camera and dialog reference checks. Static reference validation found zero broken references across 288,080 serialized references. Existing unmatched NGUI sprite selections remain (17 across the static audit, 13 in MainScene's runtime lookup); this work does not claim to repair them. Neither Android gameplay nor a rendered two-client battle has been validated.

## Provisioning boundary

Set `Battle__MatchManifestPath` to one local JSON file, or `Battle__MatchManifestDirectory` to a directory containing up to 32 manifest JSON files; never set both. The host also accepts bounded runtime registration over `POST /internal/matches` on a separate **loopback-only** control port (`Battle__ControlPort`, default UDP port + 1). The configured `Battle__ServerId` must match every manifest. Use distinct 32-byte base64 `Battle__SigningKey` and `Battle__ControlKey` values in the secret environment; no key is stored in the manifest. The signing key protects player UDP tickets and sessions, while the control key authenticates loopback allocator/control requests. Set `Battle__ContentPath` to the recovered content artifact to enable mapped matches. Their MapId is the source scene filename without extension, MapRevision its exported SHA-256, and each participant must provide Fraction, StartCover and MovementSpeed. The current unscored rifle mode requires MovementSpeed to be exactly 1, matching Client initialization; War Arena speed rules are not provisioned in this mode. Do not use the duplicated serialized `MapDefinition.levelName` as a unique map identity.

An internal allocator signs the exact UTF-8 manifest body with `HMAC-SHA256(Battle__ControlKey, "war/match/control/v1/" + unixSecond + "\n" + body)`, then sends the lowercase or uppercase 64-character hex MAC as `X-War-Control-Mac` and the current Unix second as `X-War-Control-Time`. The timestamp must be within 30 seconds; the body is capped at 65,536 bytes and parsed with strict manifest fields. A new registration returns HTTP 201 with `matchId`, the host-computed `manifestHash`, and two roster-bound `grants`. Each grant contains `host`, `port`, `ticket`, base64 `sessionKey`, `sessionId`, `matchId`, `playerId`, `manifestHash`, and `expiresUnixSeconds`. An identical registration returns HTTP 200 and the same grants for allocator retry; a conflicting manifest, expired admission grants, a terminal match, or an ID already retained in the durable result outbox return 409, and capacity exhaustion returns 503. The same signed control caller can POST exact JSON `{"matchId":"..."}` to `/internal/matches/cancel` while the match is waiting or counting down. Cancellation is retry-safe (`cancelled-before-start` then `already-cancelled`), rejects later UDP admission, and flushes an unscored terminal snapshot to the durable outbox before the successful control response. A running match or unknown ID returns 409. Only the UDP worker mutates the 32-match registry. Each late registration starts its own tick clock; terminal matches remain available for 120 seconds of replay and then leave the registry. The control endpoint trusts its HMAC caller and does not authenticate player accounts. Backend assignment, trusted loadout projection, safe grant delivery, and crash recovery still need implementation before normal Client matchmaking can use it. `Server/scripts/Smoke.ps1` verifies control rejection and retry against a live Worker, then admits two actual UDP clients using only the returned grants through ready, running, and forfeit.

Manifest shape (illustrative test content, not a production loadout):

```json
{
  "MatchId": "example-match",
  "ServerId": "local-1",
  "MapId": "fixture-map",
  "MapRevision": "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
  "CatalogRevision": "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
  "Mode": "unscored-weapon-prototype",
  "AdmissionSeconds": 120,
  "DurationSeconds": 60,
  "IdleSeconds": 10,
  "Players": [
    {"PlayerId":"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","Weapon":{"SourceId":"fixture-rifle","ClipSize":2,"ReserveAmmo":3,"CadenceSeconds":0.1,"ReloadSeconds":0.2}},
    {"PlayerId":"bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb","Weapon":{"SourceId":"fixture-rifle","ClipSize":2,"ReserveAmmo":3,"CadenceSeconds":0.1,"ReloadSeconds":0.2}}
  ]
}
```

No unauthenticated/public packet can create or replace this manifest. Its hash is SHA-256 of the validated record serialized by `MatchManifest.Digest`; obtain it through that implementation, not a raw-file hash. The HMAC control endpoint can register a runtime match, but Backend-authenticated matchmaking and loadout projection are still future work. `MatchTokens` is server-only signing code used by the host; never distribute the signing key to Unity.

Admission ticket claims: match ID, player ID, host ID, manifest hash, unique nonzero session ID, issued/expires Unix seconds and connection generation. Admission lifetime is at most 120 seconds. After admission, match deadlines own session lifetime. The HMAC-authenticated loopback `POST /internal/matches/reconnect` requires exact JSON `{"matchId":"...","playerId":"...","requestId":"<lowercase GUID N>"}` and returns one replacement `grant` only for an admitted player in a nonterminal match. A retry with the same request ID and player/match returns `reconnect-existing` with the same grant while its ticket is valid, or `reconnect-expired` once it expires; reuse for a different identity returns `reconnect-conflict`. Repeating registration likewise returns `admission-expired` instead of an expired initial ticket. A new request ID issues a fresh session ID and increasing generation, with at most 16 reissues per player per match. The request-ID receipts live only while the match remains in the bounded worker registry; after expiry or host restart they cannot recover the match. A successful UDP reconnect revokes the previous key/endpoint and preserves command receipts. The SDK synchronizes its command cursor on admission. Backend must authenticate the player and safely request/deliver this capability; restart still loses in-memory matches and receipts.

The worker writes each terminal `MatchSnapshot` to `Battle__ResultOutboxPath` before sending its terminal UDP reply. The `WFR1` record contains bounded protobuf bytes and a SHA-256 checksum; publication uses a flushed same-directory temporary file and atomic rename. On startup, a complete flushed `.tmp` record interrupted before rename is validated and promoted to pending; an incomplete temporary with a validated active-allocation marker is preserved as `.partial` and yields unscored `host-crash` recovery; an unproven incomplete or conflicting temporary stops startup. Every pending (`.wfr`) and acknowledged (`.ack`) record is then revalidated, rejecting corruption, conflicting match IDs, or more than 10,000 retained records. Set the path to a persistent local volume; without configuration it defaults beside the BattleServer binary. The smoke kills and restarts BattleServer once with pending evidence and again with an acknowledged tombstone, then verifies both recovery paths.

An HMAC-authenticated allocator can `POST /internal/results/poll` with the exact body `{}` and the `war/result/poll/v1/` MAC domain. The response contains up to 16 ordered `{matchId,digest,snapshot}` rows; `snapshot` is base64 protobuf and `digest` is the lowercase SHA-256 of the durable record. After durably accepting one result, the consumer can `POST /internal/results/ack` with `{"matchId":"...","digest":"..."}` signed under `war/result/ack/v1/`. A correct ack atomically renames `.wfr` to `.ack`; retry returns `already-acknowledged`, while a wrong digest cannot clear the pending record. Both endpoints are loopback-only. The acknowledged record remains as a tombstone for 30 days from acknowledgement. Startup and hourly maintenance validate every acknowledged record before deleting only expired tombstones; pending `.wfr` evidence is never pruned. After that window an old acknowledgement retry returns `missing`, so Backend must retain its own durable idempotency and globally unique match IDs. The 30-day interval is an explicit reconstruction policy, not a recovered production setting. These are **unscored evidence only**, not reward receipts. No Backend consumer or settlement exists yet; an incomplete write or storage failure before a complete temporary record is flushed can still prevent recovery.

## Wire behavior

New protobuf fields are appended to the existing `Packet.oneof` without changing old tags:

| Tag | Body | Direction |
|---:|---|---|
| 20 | MatchHello(ticket, match_id) | Client -> host |
| 21 | MatchCommand(command_id, oneof ready/fire/reload/switch_weapon/move_cover/forfeit/poll/...) | Client -> host |
| 22 | MatchReply(command_id, code, snapshot) | Host -> Client |
| 23 | MatchEventPoll(after_event_id) | Client -> host |
| 24 | MatchEventBatch(match identity, latest ID, ordered events, code) | Host -> Client |

Each UDP packet uses existing HMAC framing, 1,200-byte maximum datagram and a fresh nonzero packet sequence. A command retry reuses the **same command ID and identical command bytes**, with a **new packet sequence**. Same-packet replay is dropped. Match commands do not accept arbitrary RPC names, player IDs, health, prices or rewards.

Poll uses command ID zero and returns current state; other commands start at one and are processed consecutively per participant. A well-formed in-sequence command consumes its ID even when gameplay rejects it; malformed envelopes, conflicting retries and out-of-order IDs do not advance the sequence. Receipt replay returns the original snapshot, not current state: poll afterward if a newer view is needed. The separate [battle event cursor](BATTLE_EVENTS.md) now carries bounded shot/impact/death/terminal pages; it is not a complete entity event stream or a durable host-restart replay.

The match endpoint admits only the six Client-to-host match body types. Empty or oversized commands, server-only replies, and unknown fields inside hello, command, and poll bodies are dropped before packet replay accounting. The separate connectivity-probe path admits only hello, ping, and disconnect with exact known fields; malformed bodies cannot reserve a session, consume a sequence, or close it. The shared codec also rejects duplicate/noncanonical protobuf envelopes whose parsed size differs from the authenticated wire payload. An empty intent leaves the engine's reliable command cursor unchanged for direct callers. The broader abusive-input/resource-exhaustion matrix and deployment encryption policy remain B27 work.

At most four authenticated packets per participant per tick are processed, inside the existing global receive queue and processing budget. Two participant sessions and 64 response receipts each bound state. Full-state replies fit the existing MTU. After a terminal outcome the host serves receipts/state for at most 120 more seconds, then becomes silent for that match. Both peers timing out together produces an unscored abort; duration expiry also aborts rather than fabricating a winner.

On controlled Worker shutdown, every still-active match aborts with `host-shutdown`, no winner, and no reward eligibility; the Worker flushes those terminal records before exit. Runtime allocations are journaled under `Battle__ResultOutboxPath/active` before grants are returned. After a forced kill, startup validates the journal and any existing terminal record against the manifest and two-player roster, then publishes a single unscored `host-crash` result for an abandoned allocation. This is abandonment evidence only: in-memory combat state, commands, and reconnect sessions are not restored. Startup manifest matches are not journaled; they must have fresh identities on every deployment. Startup rejects any configured ID that collides with an abandoned runtime allocation or a retained terminal result. Runtime registration likewise refuses a retained terminal ID, even after its in-memory match expired. Once a 30-day acknowledged tombstone is pruned, global uniqueness must be enforced by the allocator and Backend. After terminal transition, later worker ticks and new rejected commands cannot advance the engine's terminal tick, command cursors, or state revision. Previously accepted command receipts remain replayable. The live smoke compares the terminal UDP `MatchSnapshot` byte-for-byte with the durable outbox projection.

HMAC authenticates bytes; it does not encrypt them. Session keys must be delivered through a trusted local harness or future HTTPS allocator channel. No credential/reward payload belongs in these combat datagrams.

## Next Battle Server work

1. Complete the remaining grenade, grenade-launcher, flamethrower and other special firing modes; rifle, SMG, pistol, shotgun, burst LMG, minigun, sniper and bazooka host paths are source-bound.
2. Complete infantry, vehicle, air, deployable and environmental combat over the existing source-bound entity foundations.
3. Complete each multiplayer mode's objective, scoring and terminal statistics rules.
4. Finish normal Unity UI/entity/effect presentation, reconnect recovery and two-process/Android validation.
5. Connect accepted durable battle evidence to Backend settlement without moving wallet authority into the Worker.

Solo campaign can retain the Client's local AI simulation. It uses offline Photon APIs today, so removing Photon still requires a local adapter. Multiplayer co-op and PvP require a shared battle authority; this milestone does not move solo campaign into the Worker.
