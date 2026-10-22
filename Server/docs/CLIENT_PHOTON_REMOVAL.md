# Client Photon retirement and protobuf migration

Implementation checkpoint: 2026-10-22. Active Client: `Clients/ExportedProject` (recovered 1.4.0).
The owner explicitly authorized Client changes for offline self-hosted operation.

## Implemented boundary

- `PhotonNetwork` Cloud, master, name-server, region and reconnect entry points return refusal.
  Their former connection bodies have been removed, including settings-based Photon hosting.
- `NetworkingPeer` no longer invokes `base.Connect` for master/name/game servers or queries regions.
  This closes the lower-level connection paths that could bypass the application manager.
- `PhotonHandler` no longer services incoming/outgoing Photon traffic, starts an ACK thread or runs
  region probes. `PhotonPingManager` no longer opens ping sockets or performs DNS lookups.
- `BeanstalkServerManager` encodes action requests with `ClientActionRequest` and decodes
  `ClientActionReply`. Both action and connectivity requests select `application/x-protobuf`.
  Loopback Backend access is permitted even when Unity reports no external network interface.
- Backend dispatch keeps the same authentication, action owners, transaction boundaries and callback
  semantics. It accepts protobuf on the existing endpoint and emits protobuf for those requests.
  Existing form clients remain supported, including the exact plain-text `check.php` contract.
- The Client SDK is rebuilt/installed using `python Server/tools/install_unity_sdk.py`.
  Battle commands, snapshots, admissions and reconnect already use typed protobuf through `War.Client`.

The Backend action migration uses a **protobuf envelope**, not new typed DTOs for all 175 actions.
Field strings retain the recovered request semantics. Reply payload bytes retain JSON or configuration
text so the existing callback parser and rollback behavior continue to work. HTTP carries this
protobuf body; UDP remains the battle transport. Local single-player method calls need no network wire.

## Detailed dependency inventory

Run `python Server/tools/inventory_photon_migration.py` to refresh
[`photon-migration-inventory.json`](photon-migration-inventory.json). The current inventory includes
Plugins and Editor sources: 188 source files contain Photon-related identifiers and 537 serialized
component attachments point at Photon-named source scripts. These lexical counts are not a call graph
or proof that each reference opens a connection.

The older `audit_photon_runtime.py` deliberately skips Plugins and flags local CreateRoom/LeaveRoom
calls alongside network calls. It cannot certify complete Photon removal. Its results must not be
interpreted as a network trace or used to delete every matching component automatically.

## Still required for complete SDK removal

`Photon3Unity3D.dll` and serialized compatibility types are **still present**. This is a transport
retirement checkpoint, not a Photon-free Client or complete game release.

1. Replace local `PhotonView` RPC dispatch, `PhotonMessageInfo`, `PhotonStream` serialization and
   buffered invocation with local components that preserve callback ordering and inactive-object rules.
2. Replace player/owner/master/view-ID identities in all recovered controllers, projectile/entity
   pooling and ownership-transfer paths. Network commands must retain explicit server authority;
   arbitrary RPC names must never become accepted BattleServer commands.
3. Move the single-player room lifecycle to `LocalOfflineRoom` without the retained SDK mirror.
   Cover reentrant room cancellation, leave/rejoin, scene changes and pooled callback invalidation.
4. Complete normal self-hosted PvP and co-op/Arena controller paths; migrate invitation, rematch,
   presence and chat contracts where they still require obsolete room/provider types.
5. Migrate all serialized components while preserving GameObjects, GUIDs and gameplay fields;
   remove the DLL and unused PUN sources only after every type/assembly reference is replaced.
6. Verify normal Client boot, battle, result and rematch, then supported Android/Windows/Linux
   deployment. SDK/HTTP tests do not prove normal Unity gameplay or Android compilation.

## Verification

- Full .NET solution build: passed, no warnings/errors.
- Protocol executable: passed, including 1,365 protocol/admission/replay checks.
- Legacy dispatch: 11 groups pass, including real route delegates with protobuf config/probe,
  case-ambiguous fields and malformed input.
- Native Mongo-backed Legacy smoke: 561 existing assertions pass, plus protobuf probe/configuration,
  account creation, authenticated player-state, invalid-token and duplicate-field checks.
- Native Backend/Worker smoke: 74 HTTP/protobuf/UDP checks pass, including terminal replay and Worker restarts.
- Asset reference audit: zero missing scripts and zero broken serialized references.
- NGUI audit: the existing 17 unresolved sprite selections remain; no asset selection was changed.
- `check_unity_offline_transport.py --unity <path>` imports one managed disposable project and runs
  the actual Client compile plus retained offline room/network-refusal/protobuf codec checks.
  Run `offline-transport-4bb2f578fb0c4d109cd9f04a9de21dd7` passed and verified 15,599 unchanged
  source inputs. The initial run found the recovered AWS assembly's duplicate `InvalidDataException`
  type; the Client transport check now uses `InvalidOperationException` and compiles successfully.
  This is not two normal Clients completing gameplay.
  Unity 2018.3.0f2 is the available inspection environment, not proof of the original 5.2.5f1 runtime
  or an approved project upgrade. Only the disposable project is opened.

The disposable runner does not copy imported Library caches, stops its owned Editor on timeout,
removes successful data and retains bounded failure evidence using the shared test-run lifecycle.
