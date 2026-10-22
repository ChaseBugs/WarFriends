# Client-driven implementation and both play modes

## Latest synchronization clarification — 2026-10-22

The owner initially selected separate offline progression, then explicitly clarified:
when Backend is reachable, synchronize the account at login; otherwise save locally.
In the follow-up choice the owner selected **upload and merge offline progression into
the server**. This supersedes permanent offline/online separation.

Use durable per-account, per-endpoint local records, retain unacknowledged outcomes,
and make server imports atomic and retry-safe. Never replace an online wallet with
a stale offline balance. The bot import is a device-reported progression channel,
not proof that BattleServer verified combat. Keep ranked PvP result authority
separate and describe supported import fields and policy limits explicitly.

## Owner decision — 2026-10-22

The owner explicitly requires Backend and BattleServer logic to follow the Client C# scripts. The Client is the available original-game behavioral reference, and the finished Client must support **offline and online play**.

The active reference is `Clients/ExportedProject` (recovered WarFriends 1.4.0). Its recovery provenance remains unchanged: it is a reconstruction of the shipped game, not recovered original source-control history. Do not mix in the older singular `Client` trees or other versions without documenting differences.

## Implementation rules

1. Inspect the Client caller, request builder, parser, callbacks, rollback behavior, gameplay rules and referenced serialized data before implementing a feature. Cite the concrete classes/methods in the implementation documentation.
2. Make Backend and BattleServer satisfy that behavior. Do not rewrite or remove an original feature merely because current server validation, allocation or persistence cannot handle it yet.
3. Client integration changes are permitted to replace retired transports/services and repair verified defects while preserving gameplay intent, scene/prefab identities and existing user changes.
4. Current Client files include later integration edits. Consult Git history, recovered assemblies and documented observations when an edited path conflicts with original behavior. A recent server-workaround edit is not automatically a recovered game rule.
5. Source-of-truth means the rules in trusted code/data, not trust in arbitrary network input. Preserve authoritative economy, validated outcomes and atomic/idempotent persistence. When server-only production rules are absent, document configurable reconstruction policy explicitly instead of claiming it came from the Client.
6. Preserve beginner bots, timed matchmaking fallback, tutorial bots and human PvP according to source evidence. A server limitation must be tracked as incomplete work rather than silently redefining the game.

## Offline and online scope

- Offline: the user must be able to play without public Internet or retired cloud services, including applicable AI/bot flows. Do not equate offline support with merely showing a lobby while waiting for a second human.
- Online: support human matchmaking and battles through the self-hosted Backend/BattleServer integration while retaining source-defined bot behavior where applicable.
- The existing .NET Backend, separate BattleServer, MongoDB, protobuf and BestHTTP integration remain the foundation. Online does not mean reintroducing Photon Cloud, Fuse, Kochava, Google Play or AWS as boot dependencies.
- Serverless local play, same-machine local servers, LAN and Internet-hosted servers are different deployment topologies. The owner requires both play modes but has not specified every storage/synchronization detail. State which topology is implemented and test it explicitly.
- Do not assume a new standalone VS AI button or a reward-free-only bot mode is approved as a replacement for the original Ranked PvP button's automatic bot selection.
- Do not upload offline client-reported rewards into the online economy without a defined validation and reconciliation policy. This boundary must be designed without removing the offline gameplay requirement.

## Known regression at this decision

Earlier networking work changed `GameControllerDeathMatch.StartRandomMatchMaking` to always use self-hosted human matchmaking and removed automatic local-bot fallback. The old bot-start request lacked the server-owned battle assignment expected by the reconstructed Backend, causing rejection. Blocking the Client path avoided that rejection but left solo players waiting and did not implement a replacement.

This is **unfinished integration**, not an owner-approved removal of bots. The retained `BotManager`, `PlayerBot`, `GameControllerDeathMatchOffline` and tutorial paths provide implementation evidence; their presence alone does not prove the normal bot flow currently works.

## Next implementation and acceptance work

- Recover the exact original beginner, timeout and other bot-selection conditions from source/history, including precedence and cancellation behavior.
- Implement compatible bot start/resume/end handling and the necessary server authority boundaries; do not fabricate a PvP assignment or accept an unvalidated client result merely to pass a callback.
- Preserve the original button flow and restore automatic bot selection alongside human matchmaking.
- Verify first-account defaults and tutorial progression using the Client rules; consult `Server/docs/FIRST_ACCOUNT_DEFAULTS.md` before changing rank, loadout or currency.
- Verify one-Client bot play, two-Client human PvP, cancellation/retry, disconnect/reconnect, result screens, rematch and duplicate-safe rewards where supported.
- Test offline with Internet unavailable, and online using distinct Clients. Protocol/SDK tests or healthy server endpoints alone do not establish gameplay completion.

This memory update records direction; it does not itself restore bot matchmaking or establish offline/online gameplay completion.

## Restoration checkpoint — 2026-10-22

The regression described above is now addressed by restored automatic local-bot
selection and an explicit offline-outcome import channel. Native Unity verification
covered beginner bot combat, forfeit/result UI, cached boot with Backend stopped,
and acknowledgement on the next online login. This is not proof of all offline
features or two-human PvP. See `Server/docs/OFFLINE_BOT_MATCHMAKING.md` for supported
fields, trust boundaries, limits and outstanding validation. The historical next-work
list above records the decision point; use this checkpoint for current status.

## Daily reward implementation — 2026-10-22

BE07 now has an executable Gold-only UTC attendance calendar and atomic ordered
claims. The owner-approved configurable offline-policy approach is used because
the production monthly reward table is absent. Client claimRweard is preserved;
CalendarId binds retries to the displayed month, and DailyRewardWallet reconciles
lost/replayed responses. Defaults are ordinary Gold 5 / every seventh credit 25,
frozen per opened month. See Server/docs/DAILY_REWARD_CALENDAR.md for source and
native Client proof. Other missing.md features remain separately tracked.

## Desert rendering checkpoint — 2026-10-23

Desert_Multiplayer's missing battlefield was caused by lost Unity 5 static-batch
metadata, not an absent map or a Backend failure. Restore selectors/root links
without replacing geometry or changing gameplay transforms. The T4M shader also
needed UV packing to compile within ForwardBase interpolator limits; vegetation
needed transparent sampling without multiplying wind weights into color/alpha.
See Clients/Validation/DESERT_RENDERING.md for native before/after images, exact
scope and the repeatable audits. Preserve concurrent prefab/material serialization
changes; the final native run refreshed and verified their current source snapshot.


## All gameplay scenes and default shields — 2026-10-23

The rendering repair now covers all ten gameplay scenes, not only Desert
Multiplayer. Preserve the 2,288 source static submesh ranges and world-identity
batch roots. Add an inverse-position identity child for translated LevelRoot
objects rather than moving existing gameplay objects.

The 60 Shield components swap their intact/broken meshes and must remain dynamic.
Clear BatchingStatic and LightmapStatic for those objects. Also remove their paired
LightingData bake records: the old uvMesh is built against a combined static mesh
and overrides the smaller shield's vertex stream, hiding otherwise healthy cover.
Do not replace the renderer at runtime or change the recovered shield mechanics.
A native pixel check now verifies every original shield MeshRenderer actually draws.

The default cover already comes from MapDefinition and Shield.OnGameStarted,
using the rank table's SHIELDHP through GetShieldHP and Refill; it is not a new
Backend purchase or invented starting inventory entitlement. Keep this rule as the
source of truth for both local and self-hosted battle integration. See
Clients/Validation/GAMEPLAY_RENDERING.md for current proof and verification limits.

Native verification for this checkpoint: all ten scene/shader checks and all 60
shield pixel checks passed. Actual bot battles on Desert, Aztec, City, Park and
Snow reached the visible result screen with zero gameplay errors/exceptions.
Park was repeated after correcting the opaque wind shader's vertex-color tint.
This proves those rendered bot flows, not every mission, co-op, Android rendering
or two-human network battle. Reuse one disposable Library for map checks and keep
only small proof images/reports in the repository.
