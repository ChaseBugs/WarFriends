# Unity integration reference and online dependency removal

Reviewed 2026-10-19 against `E:/Github/Mobile/Ice_Moba/client` and the active recovered
`Clients/ExportedProject`. This is source/attachment research and an executable inventory.
The research alone does not prove runtime behavior or complete removal of retired SDKs.
The companion [server review](ICE_MOBA_SERVER_REFERENCE.md) explains the different authority model.

## Implemented launcher boundary

`GameLauncher` now loads the recovered bundled assets without Terms callbacks, Google Play/Game
Center authentication, Fuse session calls, Play OBB downloading, or Android storage permission
requests. It preserves the original logo timing, asynchronous MainScene activation, source GUID,
and all eight serialized public fields. The unused `downloadOBB` field remains for scene compatibility.

`Server/tools/UnityOfflineLauncherAudit.cs` runs only in a disposable project under `Server/.local`.
The Unity 2018.3.0f2 run passed: 17 compiled launcher/nested methods inspected, twelve enabled
scenes checked with zero missing script attachments, and eight launcher fields plus Splash object
references checked. Compiled launcher IL contains no references to the audited retired provider
types and does not read `downloadOBB`. This checks the launcher, not every provider consumer or
every runtime serialization field. It is not original Unity 5.2.5 parity or an Android build proof.

The native `ClientBootSmoke.ps1` run also passed after synchronizing the disposable project's
stale C# sources with the active Client. It used isolated MongoDB and a real Backend: Splash to
MainScene, account/player callbacks, 24 initialized units, 66 initialized weapons, and card
definitions completed, with zero exceptions and zero invalid bootstrap queries. The report still
contains 70 error-level diagnostics in the previously observed ragdoll/pool/preview/config paths;
this is not a clean rendered lobby or multiplayer gameplay acceptance. Evidence is local at
`Server/.local/client-boot-d2a6bb8fa3c84eae99073ff9f27aec33/report.json`.
The asset audits found zero missing scripts and zero broken references across 288,258 references;
the existing seventeen unmatched NGUI sprite selections remain unchanged. Private package
manifest bytes were restored after all owned Unity validation processes exited.

Fuse component auto-initialization, native plugins/manifests, other provider consumers, and the
remaining Photon gameplay semantics still need migration. Preserve callback failure behavior and
local notifications; never turn unavailable ads or identity providers into successful rewards or
authenticated accounts. A denied-external-network device run remains necessary before declaring
the complete boot/gameplay path offline.

## Patterns worth using

| Ice MOBA source | Observed integration | WarFriends application |
| --- | --- | --- |
| `Assets/Scripts/Framework/NetworkManager.cs:24` | Separates named UDP connections from the TCP connection dictionary. | Keep Backend HTTP and battle UDP responsibilities separate, but resolve them through one self-hosted session/allocation flow. |
| `NetworkManager.cs:137` and `:145` | Enqueues network events and dispatches them in Unity Update. | Preserve main-thread ownership of GameObjects, UI and callbacks. Bound queue/drain work; do not copy its unbounded drain/allocation pattern. |
| `Assets/Lua/Net/BattleTcp.lua:57` | Distinguishes initial connection from reconnect, and manages loading UI. | Use one explicit lobby/loading/running/reconnecting/terminal lifecycle. Socket connection alone must not enable gameplay. |
| `Assets/Scripts/Battle/Battle.cs:1042` | Deserializes protobuf reconnect state, restores actors, queues operations and catches up. | Apply an authoritative WarFriends snapshot and retained event tail before resuming input/rendering. Keep existing signed grants and recovery receipts. |
| `Battle.cs:484` and `:493` | Pairs battle message registration and removal. | Match subscription lifetime to scene/session ownership; old connections and late replies must not affect a successor scene. |
| `Assets/Scripts/Framework/GameManager.cs:40` | Separates resource completion from logic initialization. | Local assets and self-hosted account/config completion should gate the menu, independently of retired social/analytics callbacks. |

Ice MOBA uses RakNet native bindings, Lua and its own frame simulation. Its `UdpSocketClient`
500-byte pieces rely on RakNet reliable ordering. Copying that class into WarFriends raw UDP
would not preserve the existing packet authentication, retries, MTU handling or session identity.
The reference client also initializes platform services, including recharge support, so it is
not evidence of a completely external-service-free bootstrap.

WarFriends already has `SelfHostedBackendEndpoint`, `SelfHostedBattleClient`, the portable
`MatchConnection` SDK, scene bridges and presentation adapters. In particular,
`SelfHostedBattleClient` applies replies through Unity's synchronization context and ignores
responses from a replaced connection. Extend these owned boundaries rather than adding a
parallel NetworkManager/Lua/RakNet stack. Normal two-Client gameplay remains a separate gate.

## Current external-service evidence

The read-only inventory command is:

```powershell
python -B Server/tools/audit_client_online_dependencies.py --output Server/.local/client-online-dependencies.json
```

It scans top-level recovered Assembly-CSharp source and serialized Assets scene/prefab/asset
attachments for selected provider types. It reports source hashes/GUIDs and bounded examples
without copying source lines or credential values. It complements `audit_photon_runtime.py`;
it is not a substitute for binary/plugin, native manifest, call-graph or runtime network audits.

The latest inventory contains 1,381 top-level gameplay C# files and 1,701 readable YAML assets:
12 scenes, 782 prefabs and 907 asset files. Ten non-YAML files are explicitly reported as not
parsed. These are current filesystem observations, not a revision of historical recovery counts.

| Lexical category | References | Files |
| --- | ---: | ---: |
| photon_api | 161 | 49 |
| fuse_api | 106 | 3 |
| kochava_api | 10 | 2 |
| google_play_api | 11 | 2 |
| aws_analytics_type | 3 | 1 |
| social_api | 21 | 2 |
| platform_service_api | 74 | 24 |

Matches can include comments, compatibility paths and unreachable code. For example, the
retained `PhotonConnectionManager.ConnectToPhotonSafe` already refuses cloud connections and
region probing is disabled. Photon API references therefore do not equal Photon Cloud requests.
Conversely, zero serialized attachments do not prove a provider is unused: a Singleton or
ordinary constructor can create it dynamically. The category regexes are intentionally not an
exhaustive third-party SDK catalog.

Concrete boundaries requiring continued migration:

- `GameLauncher` is attached to SplashScene. Its former Terms, social-authentication and Fuse
  startup gates have been removed as described above. The retained serialized fields preserve
  scene compatibility; this launcher change does not disable other SDK auto-initializers.
- `GooglePlayGameService.Init` activates the platform and requests silent authentication. Its
  source still exists even though the direct serialized attachment count is zero.
- `FuseSDK` has two scene attachments. Its Awake creates an Android Java plugin and its Start
  can automatically start a session. Removing one launcher call cannot disable these entrypoints.
- `KochavaManager` has a scene attachment and registers attribution callbacks in Start. Audit
  its native SDK component/manifest auto-initialization as well as its gameplay wrapper calls.
- `PushNotificationManager` is attached to a scene and subscribes GCM handlers/checks native
  notifications in Awake. Separate local scheduling from remote registration; disabling remote
  push must not remove ordinary local game state or create a boot wait.
- `GameCenterProvider.Authenticate` currently reports failure locally. Preserve callback
  completion without manufacturing a valid external identity or reopening social account links.
- `AwsEvents` retains a constructor that attaches AWS initialization and constructs analytics
  credentials/manager types. Earlier boot work removed its boot construction; the retained class
  still needs a caller and platform audit before deleting AWS dependency binaries.
- Facebook/IAP/ad/crash-reporting/Terms wrappers require their own call and native startup audit.
  Offline operation must not treat an unavailable advertisement or purchase as a successful reward.

## Migration order and acceptance gates

1. **Offline bootstrap completion.** Replace retired Terms/social/analytics boot requirements
   with explicit local completion and self-hosted account/config readiness. Complete existing
   callbacks once, avoid success-shaped social identities, and do not introduce provider timeouts
   as normal boot behavior. Keep HTTP request IDs, player parsing and recovered callback order.
2. **Provider auto-initialization.** Remove or disable remote SDK Awake/Start and native Android/
   iOS auto-initializers. Preserve source GUIDs and fields until every serialized reference and
   dynamic construction path is migrated. Audit analytics, attribution, ads, push, social and IAP.
3. **Match lifecycle and transport.** Keep authoritative self-hosted admission, loading, readiness,
   battle state, reconnect, terminal and rematch flow. No Photon region ping, room join, fallback
   matchmaking or chat service may be required. Actions 140/143 and Regions fields must remain
   compatible without contacting Photon. Do not substitute client state voting for host outcomes.
4. **Photon gameplay semantics.** Migrate ownership/view IDs, Instantiate/Destroy, serialization,
   RPC ordering/buffering, callbacks, solo rooms and chat behavior. Existing offlineMode/type
   compatibility is not complete SDK removal. Do not replace RPCs with empty success stubs.
5. **Physical SDK removal.** Remove Photon and retired online SDK binaries/components only after
   source, scene, prefab, serialized type and native build dependency audits prove their absence.
   Keep local libraries such as NGUI, JSON/protobuf and the self-hosted HTTP transport where used.
   A library's third-party origin alone does not make it a retired online service dependency.
6. **End-to-end proof.** Run source compilation, scene/Missing Script and field audits, boot and
   normal two-Unity-player gameplay, reconnect/terminal/rematch, and Android build/runtime gates.
   Retest local solo/co-op paths too. Record which Unity version was actually exercised; Ice MOBA
   does not establish original WarFriends Unity 5.2.5 parity.

The root OBB and recovered bundled assets are present. Package them locally; do not reintroduce
Google Play expansion fetching as a required boot path. Distinguish local file validation from
cloud download success. Physical Android HTTP testing can use the existing TCP adb reverse;
battle UDP needs a separately reachable host endpoint and must not be assumed to work through
that TCP mapping.

The network acceptance run should block retired external destinations while permitting only
the configured self-hosted Backend and battle endpoints. Prove no required external DNS/socket
attempts from Splash through gameplay and resume, on both Editor and the actual Android build.
A successful Editor boot or static zero-match scan alone cannot prove this property.

## Review fingerprints

External client source paths are relative to the directory at the top of this report. These
identify source content, not a running build. The generated local inventory also includes
provider source hashes and GUIDs so later owner library changes can be distinguished.

```text
9b89691da100f2bffd24e399e17a7df83e4100fb0860ec0c6d83e39168fff4d5  Assets/Scripts/Framework/NetworkManager.cs
e1a3ec3e540a6805d167b1a0fc3917bc56256866eeea4ae6fe8d4d2f88a89a29  Assets/Scripts/FrameSub/UdpSocketClient.cs
0cb09825fe320afcd46b73bade9bf573779efe89f3d76fa313e13f1fc5782bf9  Assets/Scripts/Framework/MessageManager.cs
4a3d860a2b91467311993aa137fb13b92d19be6bbd49b5adb0589362f1d7b09b  Assets/Scripts/Framework/GameManager.cs
36f1e3a114e52cb6ec5156282f8051186d2dcc1a81d2ea4d1e399acd3aa59ce2  Assets/Scripts/Battle/CSharpNetMessage.cs
44cbe76041863ed8245af372b6fd242a571c9052a1bd940de7cea1b0589d1496  Assets/Scripts/Battle/Battle.cs
b28e1e5b9c78833694c3e1c9ea731ad9c6a7e41e327235d941a02da035d1dd52  Assets/Lua/Net/BattleTcp.lua
```
