# Battle Server: implementation and remaining work

Updated 2026-09-19 from [Server_guide.md](../../Server_guide.md). This work adds Battle Server code and a portable Unity networking adapter. Backend gameplay is outside this task. **This is not yet a complete playable replacement for the recovered Photon battle runtime.**

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

The mode remains an **unscored weapon prototype**. `RewardEligible` is always false. A shot acknowledgement confirms ammo/timing validation and, with a recovered map configured, a static geometry query. It does not apply damage. Health/death, weapon variants/projectiles, destructible-state changes, AI, vehicles, cards, production allocation and durable settlement are unfinished. Synthetic test weapon values are not recovered balancing data.

### Recovered maps and Unity integration

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

## Run the tests

From repository root:

```powershell
dotnet run --project Server/tests/War.Battle.Tests
dotnet run --project Server/tests/War.Protocol.Tests
```

The Battle test executable starts the real `NetworkWorker` on a temporary loopback UDP port and drives two authenticated peers through readiness, firing, retry and forfeit. It also tests pure simulation deadlines, rejected targets, partial reload, exhausted ammo, duplicate commands, forged admissions, packet replays, endpoint binding and rate limits. It creates one temporary manifest and removes it on exit. The same command is portable to Linux; Windows execution does not prove Linux runtime behavior.

Windows validation on 2026-09-19: full solution build passed with zero warnings/errors; Battle test run passed 429 assertions (poll count can vary), including reconnect, match isolation, SDK response-loss recovery, cover movement and 200 map-ray comparisons. Protocol tests passed 1,017 checks; native Mongo/HTTP/UDP regression smoke passed 44 checks. Smoke logs: `.local/smoke-3954d24191124e94b82d30dbcb070a5c`. Actual Unity 2018.3 Mono SDK admission/ready/fire/forfeit passed (`.local/unity-battle-sdk.log`). These tests do not certify rendered gameplay, Android, damage or Backend settlement.

Optional actual Unity SDK test (use a disposable project with the installed SDK and Editor audit):

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --unity 'C:\Program Files\Unity\Hub\Editor\2018.3.0f2\Editor\Unity.exe' 'E:\Temp\WarFriends-compile'
```

The Battle Worker also published successfully for `linux-x64` (framework-dependent, Release). Linux execution has not been tested in this Windows session.

After the SDK installation, the Unity scene audit opened all 12 scenes with zero missing scripts and passed the GUI, GameController, preview-camera and dialog reference checks. Static reference validation found zero broken references across 288,080 serialized references. Existing unmatched NGUI sprite selections remain (17 across the static audit, 13 in MainScene's runtime lookup); this work does not claim to repair them. Neither Android gameplay nor a rendered two-client battle has been validated.

## Provisioning boundary

Set `Battle__MatchManifestPath` to one local JSON file, or `Battle__MatchManifestDirectory` to a directory containing 1–32 manifest JSON files; never set both. Without either the host runs the original connectivity channel only. The configured `Battle__ServerId` must match every manifest. Use the existing 32-byte base64 `Battle__SigningKey` in a secret environment; no key is stored in the manifest. Set `Battle__ContentPath` to the recovered content artifact to enable mapped matches. Their MapId is the source scene filename without extension, MapRevision its exported SHA-256, and each participant must provide Fraction, StartCover and MovementSpeed. Do not use the duplicated serialized `MapDefinition.levelName` as a unique map identity.

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

No unauthenticated/public packet can create or replace this manifest. Its hash is SHA-256 of the validated record serialized by `MatchManifest.Digest`; obtain it through that implementation, not a raw-file hash. The allocator integration is future work. `MatchTokens` is server-only code used by the test harness to issue participant capabilities; never distribute the signing key or that capability to Unity.

Admission ticket claims: match ID, player ID, host ID, manifest hash, unique nonzero session ID, issued/expires Unix seconds and connection generation. Admission lifetime is at most 120 seconds. After admission, match deadlines own session lifetime. Reconnect requires a newly signed capability with a fresh session ID and strictly increasing generation (maximum 1,000,000), before the match becomes terminal. It revokes the previous key/endpoint and preserves command receipts. The SDK synchronizes its command cursor on admission. The trusted reconnect issuer/allocator is not implemented. Restarting the host loses in-memory matches and receipts.

## Wire behavior

New protobuf fields are appended to the existing `Packet.oneof` without changing old tags:

| Tag | Body | Direction |
|---:|---|---|
| 20 | MatchHello(ticket, match_id) | Client -> host |
| 21 | MatchCommand(command_id, oneof ready/fire/reload/move_cover/forfeit/poll) | Client -> host |
| 22 | MatchReply(command_id, code, snapshot) | Host -> Client |

Each UDP packet uses existing HMAC framing, 1,200-byte maximum datagram and a fresh nonzero packet sequence. A command retry reuses the **same command ID and identical command bytes**, with a **new packet sequence**. Same-packet replay is dropped. Match commands do not accept arbitrary RPC names, player IDs, health, prices or rewards.

Poll uses command ID zero and returns current state; other commands start at one and are processed consecutively per participant. A well-formed in-sequence command consumes its ID even when gameplay rejects it; malformed envelopes, conflicting retries and out-of-order IDs do not advance the sequence. Receipt replay returns the original snapshot, not current state: poll afterward if a newer view is needed. This is request/reply reliability for this slice, not general reliable event delivery or delta snapshots.

At most four authenticated packets per participant per tick are processed, inside the existing global receive queue and processing budget. Two participant sessions and 64 response receipts each bound state. Full-state replies fit the existing MTU. After a terminal outcome the host serves receipts/state for at most 120 more seconds, then becomes silent for that match. Both peers timing out together produces an unscored abort; duration expiry also aborts rather than fabricating a winner.

HMAC authenticates bytes; it does not encrypt them. Session keys must be delivered through a trusted local harness or future HTTPS allocator channel. No credential/reward payload belongs in these combat datagrams.

## Next Battle Server work

1. Validate and bind extracted weapon stages, loadouts and player health to authoritative manifests.
2. Add combat hit targets, damage, health/death and end conditions over the recovered geometry. Keep the prototype mode unscored until this exists.
3. Add individual firing modes, projectiles and destructible parts; then units, tank/helicopter behaviors and War Card effects.
4. Wire normal Unity battle flow and rendering to authoritative entities; add a trusted allocation/reconnect issuer, reliable combat events, entity snapshots and loss/reordering tests.
5. Provide authenticated, durable result handoff to Backend as a separate integration task. Do not implement wallets or Backend routes in this Battle-only work.

Solo campaign can retain the Client's local AI simulation. It uses offline Photon APIs today, so removing Photon still requires a local adapter. Multiplayer co-op and PvP require a shared battle authority; this milestone does not move solo campaign into the Worker.
