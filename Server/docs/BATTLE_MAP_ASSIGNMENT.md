# Authoritative battle map assignment

The recovered `GameControllerOnline.AquireLevelName` waited for `mMapIdSet`, set by Photon map
RPCs. Self-hosted PvP now receives the frozen manifest's scene identity and resolves the same
local map-array index before continuing the original loading coroutine. It does not select a
default scene when the assignment is missing or unsupported.

## Wire and storage contract

`MatchConnectionGrant` adds protobuf fields 11 (`map_id`) and 12 (`map_revision`). The identity is
the scene filename without its extension, such as `City_Multiplayer`. The revision is the lowercase
SHA-256 of the recovered scene YAML, also used by `RecoveredBattleMap` and the match manifest.
It is not a hash of a platform-specific built scene or AssetBundle.

The Worker creates both fields from the accepted manifest. Its registration and reconnect control
responses carry `mapId`/`mapRevision`, with eleven exact grant fields. The Backend compares these
with the frozen manifest before publication. Durable grant validation requires both peers to agree;
publication and reads also validate the stored metadata against the frozen manifest and its hash.
Reconnect replacements must retain the prior map identity and revision. Old durable grants without
scene authority fail validation; no map is guessed or silently backfilled.

The portable SDK exposes the owned grant's read-only map properties. Changing a caller's original
grant cannot change the active connection's map. Its transport-only envelope permits both fields
to be absent for callers that do not load scenes; partial metadata is invalid. Published normal
assignments and the Unity PvP loader require complete map metadata.

## Recovered Unity binding

`InstalledBattleMaps` pins all five rows from `content/recovered-battle-content.json`. Tests compare
them with the actual active `Clients/ExportedProject/Assets/Scenes` files. Unknown scenes, mismatched
revisions, missing local map entries and duplicate scene entries are rejected.

`MapManager.SelectCurrentMap(int)` indexes `mapEntries`; it does not look up `MapEntry.id`.
The adapter resolves the assigned scene against each entry's `levelPVPName` and preserves this
index contract. In the recovered MainScene, `City_Multiplayer` is index 2. The existing scene load,
resource scope, callbacks and UDP readiness remain responsible for the rest of battle entry.
Co-op retains its own mission-based `AquireLevelName` override.

## Verification boundary

- Release build: zero warnings/errors.
- `dotnet tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --battle-map-only`:
  scene-file hashes, complete installed map coverage, missing/duplicate lookup rejection,
  partial metadata rejection, protobuf round trip and owned-copy isolation pass.
- Protocol executable: 1,360 checks pass with registration/reconnect map fields.
- Native Mongo/HTTP/UDP checks pass at
  `.local/map-grant-native-3443c90f125849b3b1f72af43dce9210`: terminal/publication ordering,
  rejection of a different scene revision under the same manifest hash, initial publication,
  rotated reconnect, Backend/Worker restarts, cancellation and same-opponent rematch.
- The installed SDK manifest pins `War.Client.dll` to
  `7bba83b59446ccfdc3e4e8ba7ddcd791bd8a3cfae0977df591389377d525921f` and `War.Shared.dll` to
  `20f1a11f6bfd7996c5d6bcc664fd422f4800fdf034d13d01561295aea7753a62`.

The first normal two-Unity run with this change, `.local/client-boot-3910f7f0ca044d30ae0b3740f2d9072c`,
connected both participants and recorded `Aquiire map id 2` in both logs. It failed because the boot
audit treated leaving MainScene as failure and exited during scene activation. A `Crane.OnDestroy`
exception is recorded during that premature Editor exit. The audit now continues after scene
activation, retains the assigned map/match identity and captures the first managed loading failure.
The two-Unity Running gate must still pass before claiming normal battle entry; these native tests
do not prove rendered gameplay, original Unity 5.2 behavior or an Android build.

After correcting the audit, `.local/client-boot-ecdd174919734a489b02f8207e22b33c` again connected
both participants, selected map index 2 and logged `Map Loaded` on both sides. Both reports retain
the same match, `City_Multiplayer` and its exact source revision. Neither reached Running.
The first report has zero uncaught exceptions, 129 error-level logs and no observed managed
loading failure. This is a failed entry gate, not a clean gameplay run.

The retained `WFR1` terminal record was length/checksum validated and decoded with the checked-in
protobuf schema. Its summary is `terminal-summary.json`: `BATTLE_PHASE_ABORTED`, server tick 300,
reason `admission-timeout`, two admitted participants and zero ready participants. At the host's
30 Hz tick rate, this is the starter template's ten-second admission limit. Next, trace when the
ordinary loading path actually submits readiness and inspect the recovered loading waits before
changing policy. Increasing a timeout alone is not evidence that readiness or gameplay works.
