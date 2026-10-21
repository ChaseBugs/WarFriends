# Backend and BattleServer missing implementation register

Reviewed against the current working tree on 2026-10-22.

Latest documentation refresh: source-layout checks and eight regression tests pass; the card
inventory validates 67 rows. All 12 Server projects and 175 direct-action dispositions remain
present. All 29 local links in this register resolve. These checks verify structure and inventory,
not gameplay completeness. The remaining native-reference work is recorded in the
implementation handoff below; earlier EN01 observations are historical checkpoints.

This register describes the remaining work needed for the recovered WarFriends 1.4.0 game to run
against the self-hosted server. It complements [todo-list.md](todo-list.md): that file owns individual
refactoring and defect repairs; this file connects those repairs to missing playable features.
Code, documentation and identifiers remain English; conversation remains Korean.

## Review scope and interpretation

The review inventories all 12 Server projects and checks the active action registries, mode gates,
result acceptance, persistence boundaries, Client entry points, feature checklists, test scripts,
content audits, deployment records and code-style rules. `Tools` contains recovery/extraction tools;
`UI` contains reference images, not an implemented administration application. The recovered Client
and its assets are behavioral evidence, not a request to restart Client recovery.

This is a source and capability review, not an exhaustive execution of every method, map or Client
screen. Existing test records are scoped evidence. No new full combat, Mongo, Unity, Android or
production Linux run was performed for this document. New read-only audit results appear below.

Status terms used throughout:

- **Missing:** the required production path has no implementation or is explicitly rejected.
- **Partial:** useful production code exists; a named part of the feature remains absent.
- **Verification gap:** implementation exists, but the required runtime proof is incomplete.
- **Conditional:** needs source evidence or an explicit offline policy before implementation.
- **Excluded:** retired services, provider integrations, debug cheats or source-disabled content.

P0 means economy/integrity risk; P1 means a playable-release blocker; P2 means maintainability,
performance or operations work. These priorities do not authorize opening unsupported routes.

## Delivery overview

There are 39 work packages: 17 Backend, 14 BattleServer/Client integration and eight engineering
packages. These are implementation scopes, not 39 isolated bugs or a claim of exhaustive runtime coverage.

| Delivery boundary | Main missing outcome | First owners |
| --- | --- | --- |
| Trusted content | One verified source snapshot and consistent derived catalogs | EN01, BE04 |
| Safe durable mutations | Complete validation and stable retry identity | BE02, BE03 |
| Complete ordinary PvP | Host-proven results, atomic rewards and normal Client end screens | BS01, BS02, BS12, BE01 |
| Progression and economy | Source-backed missions, rewards, events and entitlements | BE05-BE14 |
| Remaining combat modes | Verified unit/card behavior, Arena, co-op and offline local play | BS03-BS11 |
| Release readiness | Network fault proof, measured capacity, bounded tests and platform runs | BS13, BS14, EN04-EN08 |

Implement each package as a vertical slice: recovered request/callback evidence, typed use case,
authority validation, durable or simulation transition, response projection, then executable proof.
Keep incomplete routes closed. Record remaining gates explicitly instead of checking off a package
when only its folder, interface or happy-path handler exists.

## Current baseline: preserve what already exists

The server is standalone .NET 10, not a Unity Dedicated Server build. Backend is ASP.NET Core;
BattleServer is a UDP Worker. MongoDB belongs behind Backend persistence. Production battle execution
does not require Unity Editor, Photon Cloud, Docker or retired online services.

| Current project | Authored C# files | Responsibility |
| --- | ---: | --- |
| War.Backend | 211 | HTTP, compatibility adapters, use cases, allocation and result acceptance |
| War.BattleServer | 59 | Worker hosting, UDP, admission, journals and result forwarding |
| War.Battle.Domain | 313 | Server contracts, validated content and shared rules |
| War.Battle.Simulation | 643 | Mutable combat execution and simulation systems |
| War.Persistence | 99 | Mongo documents, transactions, receipts and indexes |
| War.Infrastructure | 13 | Server-only signing, configuration and transport infrastructure |
| War.Shared | 17 | Portable contracts and shared validation; generated C# excluded |
| War.Client | 39 | Portable HTTP/UDP client SDK |
| War.Battle.Tests | 444 | Simulation, transport, storage and focused test entry points |
| War.LegacyContract.Tests | 59 | Recovered Client contracts and callback/rollback oracles |
| War.Protocol.Tests | 18 | Protocol, SDK and admission checks |
| War.SmokeClient | 1 | Native live integration driver |

Counts exclude `bin`, `obj` and `.local`. Backend and Worker each have only `Program.cs` at their
C# root. Domain/Simulation extraction, composition roots and typed legacy dispatch already exist.
Do not repeat these as new missing features.

The current direct registry has **175 dispositions: 4 anonymous, 60 authenticated, 25 buffered-only
and 86 closed**. Buffered-only is an intentional transport boundary: those 25 operations have typed
RequestBuffer handlers and must not be opened as direct mutations. A registered handler is not
necessarily a complete feature: `GetAllMessages` returns an empty `Items` array, and the registered
`CreateGcAccount` path deliberately returns maintenance.

Guest creation/login, profile/settings, ordinary inventory purchase/upgrade/equip, ordinary card
packs/crafting/pool transfers, squad membership transactions, tutorial identity and dog tags have
implementations. Their remaining authority/retry boundaries are listed below rather than calling
these entire systems absent. Historical TypeScript completeness claims and other Client versions'
catalog counts are not evidence for this .NET implementation.

Modern queue, grant, reconnect, rematch, manifest freezing, durable outbox forwarding and Backend
result acceptance also exist. `BattleTerminalAcceptance.Accept` validates host evidence and uses
`BattleResultStore.AcceptAndReleasePairAsync` for paired results and ordinary card consumption.
**Reward settlement is partial:** ordinary legacy action 62 now uses accepted host outcomes and a
frozen, documented offline reward policy. Both account successors and replay receipts publish in one
Mongo transaction. A native test passed simultaneous requests and recreated-store replay on
2026-10-22. Historical allocations without a policy remain ineligible. Mission/achievement updates,
league lifecycle and the normal Client end-screen proof remain unfinished; `ReconcileScored` alone
still does not grant rewards. See [offline reward policy](Server/docs/OFFLINE_BATTLE_REWARDS.md).

Normal Client wiring exists: `GameControllerDeathMatch` calls `MatchmakeWithRecoveredSession`, and
`GameControllerPVP.StartGame` calls `ActivateDeathMatchScene`. The remaining gap is complete gameplay
and presentation proof, not the total absence of an adapter connection. Likewise, WSL Linux combat
and native Mongo smoke have historical passing evidence; production Linux and current-revision
release verification remain separate work.

## Implementation structure and patterns

Extend the existing projects. Do not create one project, interface or generic repository per action.
The following is a target ownership map; proposed subfolders are not claims that they exist today.

```text
Server/src/
  War.Backend/
    Hosting/                       composition and immutable validated options
    Features/Battle/Results/        host evidence, settlement orchestration and queries
    Features/Progression/           missions, assignments, calendars and rewards
    Features/Competition/           Arena, League and squad competition use cases
    Features/Commerce/              source-priced offers and offline entitlements
    Features/Messaging/             inbox, challenges and self-hosted chat
    Legacy/<Feature>/              exact 1.4.0 form and callback adapters
    Transport/Http/                envelopes, authentication and bounded parsing
  War.Persistence/
    <Feature>/                     typed documents, indexes, transactions and receipts
  War.Battle.Domain/
    <Feature>/                     immutable contracts, catalogs and pure policies
  War.Battle.Simulation/
    Match/<Feature>/               one mutable owner per cohesive PvP system
    Coop/<Feature>/                explicit mode-specific state and ordering
  War.BattleServer/
    Hosting/ Transport/ Matches/ Persistence/ Backend/
  War.Infrastructure/              server-only signing and I/O adapters
  War.Shared/ War.Client/          portable protocol and SDK; no Mongo or server secrets
Server/tools/War.Server.Benchmarks/ proposed separate Release performance executable
Server/tests/                     focused checks plus explicit integration/release gates
```

Dependency rules:

1. Backend use cases own economy and progression; Persistence owns their atomic publication.
2. Worker owns transport and durable combat evidence; Simulation never writes a wallet or Mongo row.
3. Domain references Shared; Simulation references Domain/Shared. Neither references host applications.
4. Backend/Persistence do not reference Worker or Simulation. Shared/Client remain portable.
5. Legacy adapters parse the original contracts and call use cases; rules never depend on HttpContext.
6. A match has one mutable owner and explicit update order. Share pure policies where rules agree;
   do not hide PvP/co-op differences behind flags or run systems concurrently without an ordering proof.

Use typed feature registries, small application services, immutable validated policies, explicit
state machines, transaction-bound receipts and the existing durable outbox. Interfaces belong at
genuine I/O, time, random and alternative-implementation boundaries. Avoid reflection dispatch,
service locators, universal mutable contexts and a general event bus in the combat loop.

Follow [Docs/CODE_STYLE.md](Docs/CODE_STYLE.md): descriptive names, Allman braces, `_camelCase` private
fields, explicit control flow, one responsibility per file, methods aimed at 40 lines and never over
80 without splitting, at most four parameters, 120-column lines, UTF-8/LF and one final newline.
Keep public/serialized identities stable during moves. Separate behavior-free formatting from fixes;
do not reformat recovered Client code or the whole solution. Explain recovered rules where they
change authority, and write tests as readable setup, action and expected result.

## Backend feature work

### BE01 — Authoritative ordinary battle settlement

- [ ] **P1 / Partial.** Complete legacy action 62 over accepted Worker results. Dependencies:
  BS01, BS02, BS12, BE03, BE04 and EN01. Related plan: C18; battle checklist B24-B26.
- Evidence: [normal terminal contract][terminal], `LegacyUnavailableActions`,
  `MatchEngine.BuildSnapshot` behavior, `BattleTerminalAcceptance` and `BattleResultStore`.
- Add a result query/projection and a separate settlement application service. Authenticate BattleId
  membership against the frozen manifest; distinguish not-yet-accepted evidence, abort, unscored
  diagnostics and eligible outcomes. Derive rewards, rank/XP, medals, streaks and progression from
  host statistics and reviewed policy. Client EndReason, scores and rewards remain assertions.
- Publish wallet/progression, terminal settlement marker and replay response in one Mongo transaction.
  Reuse the ordinary-card consumption receipt already created at acceptance. Never consume twice or
  mark `Scored`/`Settled` merely because the Client requested its end screen.
- Complete when source-exact success/error responses satisfy `OnClassicGameEnded`, concurrent requests
  and lost replies grant once, worker/backend restarts recover safely, and two normal Clients reach
  opposing correct results and EndScreen. A fabricated zero-reward Success is not completion.

### BE02 — Stable intent identity for direct mutations

- [ ] **P0 / Partial.** Finish C03's protocol migration for deposits/withdrawals, squad changes,
  dog-tag actions, paid rename and profile replacements. Atomicity exists; unkeyed replay safety does not.
- Evidence: [card pool publication][pool], [squad publication][squads] and C03 in the active plan.
- Introduce a reviewed Client/server operation identity with authenticated scope and payload binding.
  Preserve it across retries; record response and mutation atomically. Define retention and the result
  of an expired, conflicting or reordered intent. Do not hash equal payloads into permanent identity.
- Complete with lost-response retries after intervening legitimate mutations, concurrent last-card
  withdrawal, stale sessions, altered payloads and fault injection at every publication boundary.

### BE03 — Complete durable-state schemas and explicit migrations

- [ ] **P1 / Partial.** Finish C13 beyond strict root numerics, Settings, profile, analytics and tutorial.
- Evidence: [stored-state validation][state]. Complete catalog-bound ownership, inventory delivery,
  equipment, progression, competition, entitlement and reward-receipt schemas at shared reads and writes.
- Give each subsystem a versioned validator/migrator and a validated successor. Missing legacy fields
  may migrate only from evidence; present malformed state must not reset into new reward eligibility.
  Preserve legitimate unknown metadata without treating it as reward authority.
- Add a bounded read-only integrity audit and dry-run repair plan with preimage/revision binding.
  Execute repairs through the same transactional validation, with replay receipts and audit records.
- Complete with corrupt BSON/JSON, future dates, overflow, missing/versioned fields, changed revisions,
  interrupted migration and replay tests against an owned Mongo replica.

### BE04 — Catalog provenance and server-derived Army Power

- [ ] **P1 / Partial.** Finish C12 and the Army Power part of C13; depend on EN01.
- Evidence: [catalog validation][catalog], `LegacyArmyPowerEndpoint`, `BattleManifestFactory`.
- Reconcile source values/provenance for the active 1.4.0 tables; bind every consumed price, upgrade,
  entitlement and reward to immutable indexed rows. Implement Army Power from validated owned/equipped
  weapon/unit lanes and source formulas. Action 192 is a display assertion, not matchmaking/combat authority.
- Complete with source-bound formula tests, corrupted/reordered/truncated releases, equipped/upgraded
  combinations, arithmetic boundaries and the same derived allocation on Backend and Worker.

### BE05 — Campaign, daily/heroic missions and co-op progression

- [ ] **P1 / Missing production lifecycle; partial battle kernels.** Actions 67, 68, 69 and 111 are closed.
- Evidence: `BeanstalkServerManager` start builders, `ServerResponseHandler` mission completion branches,
  `MissionCatalog`, `CoopMatchRuntime`, `LegacyUnavailableActions`. Related battle work: BS10-BS11.
- Model issuance, start receipt, expiry/reset, difficulty, participation and terminal progress separately.
  Define trusted completion for local solo play without accepting submitted XP or rewards. Keep source
  rank indexes distinct from display levels. Carry replay receipts across rollover where required.
- Implement source-backed mission rewards and leaderboard queries only after authoritative completion.
  Do not move every local campaign mission into Worker just to reuse an online match abstraction.
- Complete with reset/expiry boundaries, duplicate starts/ends, death/disconnect outcomes, authentic
  mission objectives and normal Client progression through a subsequent mission.

### BE06 — Assignments, starter objectives and achievements

- [ ] **P1 / Missing lifecycle.** Closed actions include 112, 149, 171, 173, 185 and 186.
- Trace RequestBuffer builders as well as direct builders: a closed direct route must not be opened
  if the real operation belongs inside action 98. Use the active achievement/message contracts rather
  than inventing an achievement endpoint from presentation enums.
- Add server-owned daily cycles, assignment selection, verified completion, ordered claims, mega-reward
  cursor and starter deadline. Bind achievement progress to authentic economy/combat events. Client
  `AssignmentsIds`, deployment clicks and card consumption are not proof of spawned entities or kills.
- Keep reward definitions and any absent production schedule explicit. Publish reward and claim together.
- Complete with missed days, rollover, expired starters, partial/unknown groups, unearned claimed tiers,
  duplicate claims and authoritative battle-to-progress integration. Dependencies: BE01, BE03-BE05.

### BE07 — Daily reward calendar

- [ ] **P1 / Missing.** Actions 1001/1002 remain closed.
- Evidence: the active builder sends the misspelled `claimRweard`; preserve that wire identity and
  exact Client callbacks. Do not silently substitute another Client version's calendar rules.
- Add one server-UTC calendar, ordered eligibility/claim cursor, source-backed reward projection,
  validated time and explicit month migration. Grant and advance the cursor in one transaction.
- Complete with month/year/leap-day changes, future/corrupt calendars, canonical integer parsing,
  insufficient authority, overflowing rewards and concurrent/replayed claims.

### BE08 — Rewarded-video compatibility and one-time grants

- [ ] **P1 / Missing; external proof conditional.** Actions 156 and 161 remain closed.
- Implement bounded per-reward ledgers and one-time receipts using server time. Decide and document
  an offline earning policy; the retired advertisement service cannot be a runtime dependency and a
  Client completion assertion alone cannot authorize currency. Keep unsupported branches closed.
- Complete with source-exact reward identifiers, window limits, malformed/future ledger refusal,
  lost-response replay, overflow and clear Client behavior when the offline reward is unavailable.

### BE09 — War Arena lifecycle and rewards

- [ ] **P1 / Missing.** Actions 200-203, 206 and 211 are closed. Related: BS09, B21.
- Add immutable event/rule policy, exact current event identity, entry/Ticket/Gold handling, lives,
  hearts, opponent history, active match receipt, terminal history, crown/top-run and rewards.
  Bind battle modifiers and outcome evidence to that receipt. Debug actions remain disabled.
- Preserve exact request keys such as `hearthPrice`; prices are assertions against server policy.
  Rank only the current event and preserve the recovered flawless-first ordering.
- Complete with season rollover, duplicate entry/end, concurrent heart purchase, timeout/forfeit,
  malformed history, source rule modifiers and two normal Client Arena battles.

### BE10 — Instant Battle

- [ ] **P1 / Missing.** Action 199 is closed.
- Trace the Client's free/paid distinction, cooldown and batch size. Create a bounded progression
  state machine with server-priced payment, one-time batch outcome and durable response receipt.
  Policy/reward data absent from the Client must be explicit reconstruction configuration.
- Complete with free cooldown equality, paid batches, malformed `IsPaid`, duplicate/lost replies,
  corrupted counters and atomic cost/reward publication without trusting submitted outcomes.

### BE11 — Leagues, squad events, Squad War and rankings

- [ ] **P1 / Missing complete competition lifecycles.** Actions 101, 106, 107, 113, 124, 152, 160,
  198 and 1006 are closed; some are query/notification/admin-like contracts requiring disposition review.
- Implement separate feature owners for Player League, Squad War and shared Squad Event progress.
  Bind allocations to server season/division identities, validated eligible rosters and host-earned
  contributions. Membership CRUD already exists and must not be rewritten as competition progress.
- Add bounded scheduler discovery, renewable leases, immutable timing policy, transactional placement
  and exactly-once settlement. Rank source-compatible records deterministically with bounded queries.
- Complete with ties, stale events, leave/kick during settlement, conflicting workers, malformed rows,
  exhausted counters and crash/replay across a season boundary. Dependencies: BE01, BE03, BE06, BE13.

### BE12 — VIP, packs, offers, rentals, lootboxes and visual parts

- [ ] **P1 / Missing or partial; offline entitlement policy conditional.** Actions 114, 130, 135,
  136, 138, 142, 189, 190 and 1013 are closed. Ordinary action-97 card packs already exist.
- Evidence: `LegacyBufferedCosmetics` implements first direct Gold/Warbucks purchase but explicitly
  excludes PARTS/duplicate compensation. `OnVIPExpired` support does not implement buying VIP.
- Add immutable source-priced offers, eligibility, expiry, purchase receipts, entitlement projection,
  rental cleanup, parts completion and duplicate conversion. Validate full ownership before rewards.
- Define self-hosted entitlement issuance/restore/reversal; do not require Google Play, Apple, Fuse
  or real-money network verification at offline boot. Never treat a submitted store receipt as proof.
  Actual provider commerce remains outside offline acceptance unless separately authorized.
- Complete with duplicate purchase/restore/reversal, expired offers/rentals, pending upgrades, extra
  card-slot projection, capped parts and overflow. No fabricated production loot weights or prices.

### BE13 — Durable inbox, reward messages and challenge records

- [ ] **P1 / Missing.** Action 5 currently returns an empty successful array; actions 2, 12, 90,
  91, 184 and 194 are closed. These are not a working inbox merely because its read callback parses.
- Add typed, bounded server-authored messages, read/ignore state, expiry and authenticated ownership.
  Message-derived rewards require source-exact payloads and an atomic claim/receipt/wallet transition.
  A client-facing SystemMessage route must never mint arbitrary server reward messages.
- Complete with pagination, wrong-owner reads/claims, malformed embedded data, expiry, duplicate claims,
  settlement-generated message replay and normal Client rendering. Integrate challenges through BE15.

### BE14 — Buddy ownership and full battle card allocation

- [ ] **P1 / Partial.** Ordinary cards have allocation and consumption; nonempty `buddyCardData` is
  explicitly rejected by `OrdinaryCardInventory.ValidateRoot`.
- Implement source-backed Buddy inventory, eligibility, selected-card projection, cooldown/replay and
  modifier/spawn authority. Reuse the accepted-result transaction instead of adding a second consumer.
  Validate extra-slot entitlement and all selected ordinary/Buddy identities before queue admission.
- Complete with allocation versus inventory changes, stale grant replay, duplicate terminal delivery,
  insufficient ownership and normal card selection/activation. Dependencies: BE03, BE12 and BS08.

### BE15 — Self-hosted player discovery and challenges

- [ ] **P2 / Missing or conditional.** Actions 3, 26 and 84-89 are closed.
- Trace actual call sites for friend info, search, provoke/challenge and hit-list behavior; several
  legacy enum entries have no current request producer. Implement only evidenced offline features.
- Use authenticated player relationships, bounded search/pagination, challenge ownership/expiry and
  accepted pair allocation. Provider friend synchronization remains excluded.
- Complete with acceptance/cancellation races, offline/expired targets, blocked/invalid identities,
  replay and two normal Client challenge flows without Photon rooms.

### BE16 — Self-hosted global/squad chat

- [ ] **P2 / Missing.** [Retired Photon Chat][chat] deliberately reports unavailable; replacement chat
  transport, accepted DTOs and history are not implemented.
- Add an authenticated messaging service outside the combat tick, bounded payloads/history, rate and
  moderation policy, squad-membership authorization, reconnect cursors and stable message identity.
  Preserve the original chat UI and prevent an unaccepted optimistic echo from becoming history.
- Complete with two Clients, repeated enable/disable, membership changes, offline/reconnect delivery,
  duplicate sends, history bounds and zero Photon Chat calls. No general battle RPC relay.

### BE17 — Account maintenance and player support dispositions

- [ ] **P2 / Conditional.** Review actions 121/122 and 148 separately from implemented guest login,
  rename and diagnostic acknowledgements. Some enum identities have no active request producer.
- If active offline account/password maintenance is required, add current-credential/session proof,
  password hashing, session rotation and exact callbacks. Do not infer account linking from a rename.
- `SendPlayerReport` is closed; `ReportCheater` currently records bounded metadata rather than an
  investigation workflow. Add authenticated report ownership and bounded operator review only when
  needed; Client reports are evidence, never automatic economy or combat authority.
- Complete with source disposition coverage, credential rotation/replay and no raw tokens/private
  diagnostics in logs. Do not add a generic admin UI or historical TypeScript endpoints by assumption.

## BattleServer and Client-integration work

### BS01 — Finish the normal two-Client match loop

- [ ] **P1 / Partial plus verification gap.** B05-B07, B20, B25, B30-B32, B36; C18 and V05.
- Existing controllers connect queue, grants and the bridge. Finish default-policy lobby/loading,
  commands, health/score, death/forfeit, EndScreen, same-opponent/random rematch and cleanup as one flow.
  Diagnose the recorded normal Editor startup stall separately from the absent GameEnded implementation.
- Gate: two actual normal Clients complete a match and a second match; correct opposing outcomes,
  no legacy simulation writer, no duplicated lifecycle callbacks, no diagnostics-only timeout override.

### BS02 — Complete authoritative statistics, kill credit and scored terminal evidence

- [ ] **P1 / Partial.** B19, B24-B26; BE01 depends on this authority.
- Extend existing statistics to every supported player/infantry/vehicle/air/card/objective family.
  Keep actual spawns, kills, assists, stolen/destroyed crates and card use distinct. Preserve projectile
  attribution after weapon switch, owner death and entity removal; do not trust submitted MatchStats.
- Gate: source-backed hit/kill/score tests, simultaneous terminal events, exact immutable result digest,
  replay, no aborted rewards and conservation from accepted host evidence into Backend settlement.

### BS03 — Remaining player weapon, pose and projectile parity

- [ ] **P1 / Partial.** B02, B04, B06-B10; V02. Existing rifle/SMG/pistol/LMG/minigun/sniper/
  shotgun/bazooka/grenade implementations are substantial and must be retained.
- Complete supported multi-slot combinations, remaining special ammunition, movement/blending/aim,
  shot scheduling, fake/real randomness, arming, collision/expiry priority and denial reconciliation.
  `BattleCombatContent` still explicitly rejects some combinations, including shotgun multi-slot
  authority in its restricted mode; widen only with matching simulation and Client evidence.
- Gate: source-backed boundary and moving-target comparisons, same-tick order, pause/reconnect,
  native geometry where relevant, all supported gestures and two-Client rendered impacts.
  C31-C33 are completed scoped fixes, not proof that all physics/timing is finished.

### BS04 — Map geometry, dynamic collision and navigation authority

- [ ] **P1 / Partial.** B03, B04, B06, B11-B12; V02.
- Finish shape/layer/trigger coverage, dynamic destructible geometry, stable entity generations,
  pose-dependent hitboxes and navigation behavior across the supported maps. Measured host path models
  must not silently become exact Unity NavMeshAgent/PhysX behavior.
- Gate: independent native source comparisons, moving/rotating bodies, nearest-hit/occlusion ties,
  zero-length/non-finite inputs, collider removal and identical scene/content identities on both peers.
  Keep performance acceleration separate from collision-semantics corrections.

### BS05 — Complete infantry state machines and deployment integration

- [ ] **P1 / Partial.** B12-B14; S07 and V02.
- Complete each recovered soldier's acquire/navigate/aim/fire/ability/death state machine, authored
  cover entry/return, procedural muzzles, spawn eligibility and normal Client visuals. Existing
  Assaulter, Gunslinger, Rusher, Shotgunner, Minigunner, Flame, Rocket and Mortar paths are not absent.
- Retain distinct source clocks and observed callback order; connect partial components to the
  actual host update rather than a fixture-injected pose/weapon producer.
- Gate: deployment through authentic movement, damage and death for each admitted family, moving
  target/owner death/reconnect cases and normal Client roster/animation agreement.

### BS06 — Complete ground-vehicle and passenger behavior

- [ ] **P1 / Partial.** B15. Existing routes, turret/cannon attacks, passengers and repair drones remain.
- Finish source wheel/steering and repair-drone fall/steering comparisons, passenger animation and
  walking-fire blends, all target/collision categories, elite/modifier combinations and presentation.
- Gate: per-family source comparisons and two running Clients observing movement, crew death/respawn,
  vehicle destruction, repair-drone lifetime and cancellation without duplicate effects.

### BS07 — Complete air-unit and helicopter crew execution

- [ ] **P1 / Partial.** B16 and parts of B14/B22.
- Finish Drone movement/fall/explosion, helicopter flight/drop/attack, elite/card variants and every
  supported target type. Crew descent/path/aim/volley components exist, but recording producers and
  supplied roots/clocks do not prove an automatically executing physical weapon and world collision.
- Gate: actual host loop generates crew motion, rig/muzzle, projectile, impact and damage; native
  comparisons and two-Client animation agree. Preserve lifetime ownership across navigation changes.

### BS08 — Remaining playable War Cards and deployables

- [ ] **P1 / Partial.** B17-B18; BE14. The current source-card audit passes with 57 enabled and
  10 source-disabled rows. Enabled does not mean implemented by this server.
- Fourteen enabled IDs have no direct normal Client host route: `ROCKETTURRET`, `AIRSTRIKE`,
  `HEADAHEAD`, `MEATHEADS`, `BOOBYTRAP`, `ELECTRICTRAPS`, `EXPLOSIVEPISTOL`, `TURRET`,
  `EXPLOSIVETIMING`, `SLOWDOWN`, `TRIGGERHAPPY`, `SICKNESS`, `CRITICALS`, `PLAGUE`.
  Some already have internal models/catalogs; complete their missing admission/command/effect path.
- For each, implement source identity, target rules, bounded reservation, eligibility, modifiers,
  stacking/expiry, host-owned activation and terminal consumption. Finish existing turret/mine/Decoy
  opponent coverage and ordinary contact/prediction. Source-disabled cards stay disabled.
- Gate: source contract, command replay, failed activation, simultaneous expiry/death, inventory
  consumption and two-Client visual proof per admitted card. Use [the card inventory][cards] as checklist.

### BS09 — War Arena combat mode

- [ ] **P1 / Missing supported production mode.** B21; BE09.
- `BattleModeCapabilityPolicy` does not authorize an Arena mode. Bind the reviewed Backend Arena
  receipt/modifiers, participant state and outcome to a distinct mode policy. Reuse combat systems
  only where rules agree; do not rename the unscored default-speed encounter into Arena.
- Gate: authoritative modifiers/lives/end reasons, rejected stale event receipts and two normal Arena
  Clients with exact settlement handoff. Economy stays Backend-owned.

### BS10 — Complete co-op runtime and open admission only after proof

- [ ] **P1 / Partial, production admission closed.** B22; S08. `MatchRouter.Register` returns
  `mode-unavailable` for `CoopMissionMode`, despite substantial runtime/catalog/component code.
- Finish native motion/rig/weapon producers, enemy combat, all objective/spawn phases, partner roles,
  survivor/departure/KIA behavior, source clocks and complete result evidence. Finish remaining
  diagnostic collision/crew seams before installing the runtime in normal Worker allocation.
- Gate: authentic host-driven full missions, both participant callback orders, loss/reconnect,
  terminal/settlement and two normal Client HUD/scene flows. Removing the gate is the final step.

### BS11 — Photon-free local campaign/tutorial and remaining room behavior

- [ ] **P1 / Partial.** B01, B23, B31, B33; BE05.
- Audit active offline-room creation, teardown, object ownership, RPCs, room properties and local
  pooling against the migration ledger. Finish local adapter behavior and progression handoff.
  Retained Photon DLLs may resolve old asset types; no Photon service may be needed at runtime.
- Gate: normal offline boot/tutorial/campaign, cancel/retry/reload, all scenes/prefabs and Android,
  with no retired online-service connection. Preserve asset identities and concurrent library work.

### BS12 — Terminal cleanup, recovery and same-tick ordering

- [ ] **P1 / Partial.** B20, B25-B26, B30; V02.
- Preserve existing prestart cancellation, journal/outbox recovery and 30/20/10 reconnect windows.
  Resolve terminal bonus/card grenade retention versus equipped-grenade cleanup from Client evidence;
  frozen old-engine traces prove preservation, not correctness of that terminal policy.
- Finish both-player loss, transient effects, simultaneous death/end, entity/event recovery and
  explicit host-crash behavior. Restart currently does not promise resuming a live simulation.
- Gate: same-tick collision/expiry/terminal cases, altered/late replay, interrupted durable writes,
  old generation revocation and normal reconnect dialogs followed by correct results.

### BS13 — Reliable events, snapshots and hostile-network coverage

- [ ] **P1 / Partial plus verification gap.** B27-B30, B35; V03.
- Existing HMAC, bounded replay/commands, chunks and generation handling are foundations. Finish
  full event-family coverage and normal Client consumption/interpolation for all admitted entities.
- Gate: real UDP loss, delay, duplication, reordering, stale chunks, reconnect during transfer,
  slow consumers, sustained authenticated floods and cross-match isolation. Record drops and budgets.
  HMAC supplies integrity/authentication, not confidentiality; encryption is a separate deployment policy.

### BS14 — Complete presentation and original UI reconciliation

- [ ] **P1 / Partial plus verification gap.** B04, B07-B19, B29-B32, B36.
- Finish remaining units/vehicles/air/cards/effects, HUD labels/controls, health/death transitions,
  interpolation and rejection feedback. Distinguish source wiring, component audits, script-free
  mesh probes and diagnostic Editor runs from normal two-Client gameplay.
- Gate: normal authored scenes on two running Clients and Android; full battle-to-menu-to-rematch,
  loss/reconnect and no duplicate local authority. Do not certify this from SDK tests alone.

## Engineering, testing and operational work

### EN01 — Resolve source provenance before content release

- [ ] **P1 / Confirmed release blocker.** C12 and V07.
- Current MainScene SHA-256 is `5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff`.
  The historical catalog binding records `d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43`.
- The current mission, score-streak and bonus source checks fail. Recover extraction provenance,
  compare semantic source values and revalidate all dependent packages/templates as one release.
  Do not replace digests solely to make checks green or silently overwrite Client assets.
- Gate: every affected source audit passes for the same reviewed snapshot and derived release identity.
- First implementation: [the provenance audit](Server/docs/MAIN_SCENE_PROVENANCE.md) identifies the
  exact LevelManager restoration commit, verifies the only changed serialized object and confirms
  unchanged mission values. It inventories 52 direct historical references and 61 affected JSON
  artifacts including dependents. Original APK/OBB pointer verification and eight audit regressions
  pass. Re-extraction/native recapture and coordinated content publication remain open; no production
  digest has been changed and EN01 is not complete.
- Static candidate increment: three extracted document builders now stage missions, bot definitions
  and bot health through the managed run lifecycle. Ten tests prove historical reproduction, exact
  gameplay-value conservation and fresh dependency hashes. Candidates total 166,260 bytes; production
  content remains unchanged pending the coordinated release of the complete affected set.
- Sheet audit increment: 78,955 typed fields reveal 386 lossy ObscuredFloat exports and four truncated
  BotNames strings. The Editor exporter now uses direct scalar conversion. Actual Unity 2018.3 Mono
  with original managed types reproduces all 386 old losses and preserves all corrected JSON bits;
  the edited exporter compiles. See [value audit](Server/docs/BATTLE_SHEET_VALUE_AUDIT.md). Production
  content and dependent releases still require recapture/revalidation; this is not EN01 completion.
- String provenance increment: all 269 BotNames match original APK/OBB bytes. A tiny owned native
  Unity 2018.3 import reproduces all four truncations from plain YAML; escaped quoted YAML preserves
  all names. Six decoder tests pass. The probe removes its temporary project/Library after success.
  Production assets/catalogs remain unchanged; integrate lossless import into coordinated recapture.
- Disposable input preparation now preserves complete scene semantics and changes only the four
  affected scalar lines. Its four regression tests pass; the native import probe uses this same
  preparation function. Full recapture must bind original and prepared hashes separately.
- Full sheet candidate increment: all 132 sheets/78,955 cells are re-extracted through the shared
  typed reader; 390 reviewed differences are corrected. Five candidate regressions pass. A bounded
  6,045,583-byte candidate preserves existing native geometry and records separate input hashes.
  This is not native geometry recapture or production publication; those EN01 gates remain open.
- Direct dependent increment: staged legacy profile and PvP score-streak policy now bind the exact
  candidate bytes. Five tests preserve gameplay/schema/identity boundaries and reject stale hashes.
  Unit-rule staging additionally requires refreshed Client observation: current WeaponInventory.cs
  differs from its recorded proof. No production pin or observation validation has been bypassed.
- Full native recapture increment: the actual Unity exporter produced five maps and 132 sheets from
  a fresh imported source copy. All sheet values match original-source decoding; native maps/meshes
  and sheet identity/order match existing content. Original inputs remained unchanged. Raw output
  preserves its prepared-scene hash separately from original provenance. Temporary project/Library
  was removed after repairing read-only package cleanup; three native guards and 22 lifecycle tests
  pass. Dependent publication, numerical review and starter observation remain open.
- Native-bound staging now revalidates the completed export, complete unchanged source inventory,
  exact prepared/original hashes, typed candidate cells and native non-sheet observations. Evidence
  is retained with the candidate. The PvP bonus catalog joins the profile and score policy; rewards
  and probability rows remain exact, with two float spellings proven bit-equivalent. Seven dependent
  and four binding tests pass. No production publication is implied by these candidate gates.
- Starter observation gate resolved: actual fresh-account Backend/Mongo/Unity startup matches every
  old gameplay value; only WeaponInventory.cs source provenance changed. Published observation,
  weapon-index/initial-state/unit-rule artifacts and four Backend pins were updated coherently.
  Release build, 54,236 loadout/ownership/unit checks, 268 index checks, protocol, native and legacy
  smoke pass. Corrected-sheet unit candidates now validate too. Broad battle-content publication and
  remaining numeric/dependent gates are still open; this is not normal battle completion.
- Precision impact increment: actual vehicle/air vitality owners distinguish all 386 corrected HP/
  damage inputs at synthetic death boundaries. This is scalar-application evidence, not all-unit
  modifier/routing parity. Army deployment joins staged dependents; all 24 family options/settings
  are unchanged, with 18 movement float spellings proven bit-identical and CRLF retained. Eight
  dependent tests and the Release precision selector pass; broad publication remains open.
- Army perk increment: the producer takes explicit scene/content/deployment bytes, checks all three
  scene identities and keeps source collection local to each build. Six staged dependents now include
  the perk catalog; all 24 ordered family recipes, selectors, affected targets and elite values remain
  exact. Twelve dependent tests pass, including mixed-source rejection, independent repeated builds
  and exact staged-byte dependency hashes. Production catalogs and broad release gates remain open.
- Co-op card-row increment: the seventh staged dependent preserves all eight source family indexes,
  including the Client's row-zero fallback when CARDS_MIN/MAX are absent. Explicit input bytes bind
  the exact staged army/content hashes. Duplicate family identities and non-finite or Boolean combat
  values now fail extraction. Sixteen dependent regressions pass; this does not open co-op admission
  or establish full card interpolation/combat parity.
- Skill-shot increment: PvP and mission score producers now build from explicit candidate bytes and
  join staging as dependents eight and nine. Both retain all 19 active score rows, flags, dictionary
  identities and combo timing; the PvP long-shot distance remains exact. Twenty dependent tests pass.
  Boolean/fractional/out-of-range points, duplicate sheets, mixed scenes and unknown CLI arguments
  are rejected. This verifies catalog preservation, not authoritative kill credit or reward settlement.
- Ordinary card identity increment: the tenth staged dependent retains all 67 ordered identities,
  rarities and implementation flags (57 enabled, ten source-disabled). Its explicit-input builder
  rejects Boolean/float/string rarity substitutions; production CLI writes still require the reviewed
  content hash. Read-only checks and unknown-argument refusal preserve production bytes. Twenty-three
  dependent tests pass; this does not implement the remaining playable card effects.
- Unified mission staging increment: the same release candidate now includes the three previously
  separate mission, bot-rule and bot-health candidates. Exact scene-byte equality, the complete
  restoration audit and original artifact preimage checks remain mandatory. Thirteen dependents
  are retained together with native evidence; twelve mission regressions pass. All 75 mission rows,
  44 player-health rows and 15 boss-health records preserve their reviewed gameplay values.
- Boss configuration increment: attack timing and loadout producers now accept explicit staged
  inputs. The mission chain contains five artifacts, bringing the combined dependent count to 15.
  All 15 attack configurations, 66 OBB-ordered weapons and 15 four-slot loadouts remain exact;
  historical source reconstruction also passes. Exact bot-byte binding and finite timing validation
  reject mixed dependency versions and decimal overflow. Fifteen mission regressions pass.
- Boss-anchor increment: five distinct multiplayer maps and all 40 ordered defend positions now
  join the unified candidate. Map bytes must match their mission hashes; duplicate maps are rejected.
  Seventeen mission regressions pass, with 16 total staged dependents. Boss-path repackaging remains
  pending: its required `Server/.local/coop-boss-path-output.json` is absent, and no replacement was
  found in the managed run root. Existing packaged routes are not a substitute for that native proof.
- Native boss-path recapture increment: a minimal owned Unity 2018.3 project loads only five checked
  NavMesh assets (971,149 copied asset/meta bytes). All 120 native routes exactly reproduce the existing
  map/route payload. Raw output, current anchor/navigation bytes and hashes are retained in managed
  run `boss-path-capture-6410b987bf5d4e0295c23bccd4eb2159`; temporary project data is removed. Five
  packaging regressions pass. This resolves the missing raw-evidence capture above; binding it into
  the combined candidate remains pending, as do full Client movement and original Unity 5.2 proofs.
- Boss-path evidence binding increment: completed native captures or retained stages can now supply
  the seventeenth dependent. Binding checks the full expected source inventory, current source bytes,
  exact anchor/navigation inputs, raw output hash and every packaged route. Four evidence files travel
  with the candidate so retention can remove the original capture independently. Six binding and five
  packaging regressions pass. Normal Client movement and the complete content release remain open.
- Mission shield increment: the eighteenth staged dependent preserves all 75 mission shield rows
  and recovered default ratios/repair flags. Its producer consumes exact staged mission bytes,
  requires a complete mission list and checks every DATA digest. Unknown CLI arguments fail before
  writes. Twenty mission regressions pass, including invalid ratio/Boolean and changed DATA rejection.
  This verifies initial shield configuration, not the entire damage/repair runtime lifecycle.
- Soldier point-mask increment: the nineteenth staged dependent preserves all 16 soldier records
  and the source sniper minimum distance. Explicit scene/deployment inputs must share a revision;
  duplicate component/unit identities and non-Boolean soldier classifications are rejected. Twenty-six
  dependent regressions pass. Position-selection metadata is verified; full movement AI remains open.
- Air-geometry increment: the twentieth staged dependent re-extracts all three air prefabs and their
  collision mesh identities. Hierarchies, colliders, targets and source hashes remain exact; only the
  deployment dependency changes, with pinned CRLF preserved. Duplicate air families and non-Boolean
  classifications fail extraction. Twenty-nine dependent tests pass; dynamic pose/hit parity remains open.
- Rusher weapon increment: the 21st staged dependent preserves eight weapon families and five-map
  Warper relocation settings. Mixed scene/content/deployment inputs fail. Four base-cadence source
  hashes are refreshed only for the reviewed d44cbdbd8 visual-loader cancellation change; its parent
  CRLF bytes reproduce the old hash, and cadence logic is unchanged. Thirty-two dependent regressions
  pass; full weapon/ability execution remains a separate completion gate.
- Assaulter weapon increment: dependent 22 preserves the ordinary/card rifle identity, muzzle,
  projectile speeds/check distance, critical fields and cadence. Its explicit scene builder retains
  prefab/script checks; only scene provenance and the already reviewed SoldierBehaviour transition
  may change. Thirty-five dependent regressions pass. This is source configuration proof, not a new
  normal-match or co-op runtime certification.
- Deployable increment: Land Mine and Heavy Turret sources bring staged dependents to 24. Five-map
  placement data, prefabs and gameplay fields remain exact; four turret scalar spellings are accepted
  only when their binary32 bits match. Explicit scene/content inputs reject mixed sources, and duplicate
  mine damage constants fail instead of overwriting. Thirty-eight dependent tests pass; full deployable
  execution and coordinated publication remain open.
- Mortar pool increment: dependent 25 binds explicit scene/deployment bytes and preserves pool
  capacity four, per-owner limit two, allocation order, delayed return rules and reviewed source hashes.
  Integer type and two-owner capacity conservation are enforced. Forty-one dependent regressions
  pass; complete multiplayer pool exhaustion/recovery behavior remains a runtime gate.
- Co-op NavMesh source increment: dependent 26 preserves all five scene/asset identities and native
  NavMesh bytes. Staging verifies the existing packaged assets against both source bytes and manifest
  hashes; only mission provenance changes. Twenty-two mission regressions pass, including changed
  package bytes, stale scene hashes and reordered stages. Derived co-op navigation artifacts and
  runtime movement verification remain open.
- Co-op detail increment: dependent 27 verifies every native tile before rebinding the source
  manifest. Binary assets are read through their complete NavMeshData tile arrays; the YAML asset's
  complete mesh-data inventory is decoded separately. All 655 tiles, 5,693 polygons and 26,081 detail
  triangles match the stored geometry. Twenty-four mission regressions pass, including last-tile
  corruption and truncation in both encodings. Existing hash-bound build settings are retained;
  this is not new Unity surface-selection or pathfinding proof.

- Co-op prefab collider increment: dependent 28 re-extracts 32 prefabs and 128 colliders from explicit
  scene bytes. All pool identities, network-entry order, transforms, flags, shape dimensions, prefab
  hashes and 14 WheelCollider counts remain exact; only `mainSceneSha256` changes. Twenty-five mission
  regressions pass, including historical reproduction and rejection of a changed collider flag.
  This inventory does not establish animated world hitboxes or authorize projectile hits.

- EN01 follow-up: dependent 29 retains the six existing Unity-exported prefab meshes (176 vertices,
  284 triangles) only after source asset hashes and the entire collider document, except scene
  provenance, match. Changed collider geometry requires native recapture. Boolean vertex values and
  invalid triangle indexes are rejected. Twenty-seven mission regressions pass. This verifies safe
  reuse and dependency binding, not independent decompression or new Unity hitbox execution.

- Native weapon increment: `weapon-recapture-74716ddc1e2246c8a524de5ae28d0355` reran the actual
  `SelfHostedAllWeaponExport.Run` in an owned source-only Unity 2018.3 project. All 66 complete weapon
  bindings match the existing export except the current scene hash. Source inventory revalidation
  passed and the temporary project was removed. Five weapon validation tests and three existing
  capture tests pass. Binding this retained evidence into the coordinated release and recapturing
  weapon-family outputs remain open; this does not prove original Unity 5.2 or gameplay parity.

- Weapon evidence binding increment: dependent 30 now consumes either the completed native weapon
  capture or retained evidence in a completed sheet stage. It revalidates all current source files,
  exact scene/output hashes and every weapon field; retained evidence is copied and hash-bound.
  Five binding tests and eight capture/validation tests pass. Actual retained-stage rebinding
  reproduced identical candidate bytes for all 66 weapons. Weapon-family outputs and production
  manifest publication remain open.

- Native family batch increment: nine original exporters now run in one disposable Unity import.
  Run `weapon-family-recapture-e2af4a0ecbae4823be34bf2abefb636c` produced all nine outputs and verified
  15,599 unchanged source files. Eight outputs match existing values except scene provenance.
  Minigun failed exact schema comparison: its native exporter emits muzzle position/rotation and
  motor path, while the packaged document instead includes setup type, ammo setup types and weapon
  components from the all-weapon identity graph. Review an explicit source-bound composition for
  those fields; do not loosen generic comparison or copy missing fields from the old artifact.
  The failed run retains raw outputs and diagnostics. Three batching/comparison tests pass; no
  family output has been published or promoted into the combined candidate release yet.

- Minigun composition resolved: `compose_minigun_binding.py` binds the family export to same-scene
  all-weapon identities, requires exact overlap, and adds only the three identity metadata fields.
  Reference-pose diagnostics remain in raw evidence. Run
  `weapon-family-recapture-93b8eed0ee2244cca18f167ad41c7dd4` executed all ten exporters in one import;
  all nine family packages now match production values except scene provenance. The 15,599 original
  inputs remained unchanged and successful temporary data was removed. Five composition and three
  batching tests pass. Retained-evidence integration and manifest publication remain open.

- Family evidence integration: dependents 31-39 now bind the nine native family outputs. Completed
  captures and retained sheet stages repeat inventory, exporter preparation, output and typed-value
  checks; Minigun is recomposed from its two native inputs. Five binding tests pass. Actual retained
  rebinding reproduces all nine candidate byte streams. Stage
  `sheet-candidates-5b26145b425c4d1c9a8e8939ace73644` contains 39 dependents without production writes;
  temporary data is removed. Manifest construction and full content release gates remain open.

- Simple weapon manifest increment: dependents 40-46 bind seven family packages to exact corrected
  stats/binding bytes and one scene revision. Missing candidates never fall back to production.
  Four generator guards pass; the Release battle-test build has zero warnings/errors and all seven
  production C# loaders accept the staged packages via `--weapon-candidate-path`. Grenade poses and
  the larger combat manifest remain pending. Loader acceptance is not full numerical gameplay parity.

- Native pose increment: `pose-recapture-3e0f80e9d05f4f9f9644edcd7b020cd6` reran grenade and player
  pose exporters in one owned import. Both complete sampled documents match existing values except
  scene provenance; all 15,599 original inputs remained unchanged and temporary data was removed.
  Shared batch preparation now serves weapon and pose capture; three batch and two pose tests pass.
  Retained pose evidence still needs candidate binding before grenade/full-combat manifest release.

- Pose and grenade integration: dependents 47-49 add both native pose documents and the Grenade
  manifest. Completed captures and retained stages repeat source, exporter preparation, raw hash
  and sampled-value checks. Four pose evidence and five manifest tests pass. Release build has
  zero warnings/errors; eight production C# weapon loaders, including Grenade, accept the candidates.
  Actual retained pose rebinding reproduces both byte streams. The full combat manifest and other
  pose-derived dependencies remain open; package loading does not prove complete gameplay parity.

- Player target increment: dependent 50 re-extracts the two players' ten serialized shot targets
  from explicit scene bytes. Role order, target types, transform identities and all coordinates stay
  exact; only scene provenance changes. Twenty-eight mission/scene candidate tests pass, including
  historical reproduction and rejection of changed reference positions. These reference transforms
  are not animated hit authority; live pose-derived collision verification remains separate.

- Combat manifest increment: the direct dependency graph now resolves against reviewed candidates
  or byte-identical files pinned by the old manifest and excluded from the source-change audit.
  Missing/ambiguous hashes, absent affected candidates and mixed stats scenes fail. Four tests pass.
  Stage `sheet-candidates-979a6ded6df54bea9dec559f6c438344` contains 67 dependent artifacts: 51 changed
  candidates and 16 unchanged dependency copies. Full `BattleCombatContent.Load` also reads auxiliary
  files outside this manifest; complete package loading and gameplay validation remain open.

- Full loader diagnostic increment: owned content overlays now verify candidate inventory/hashes
  and invoke the actual combat loader without production writes. The first run found pose formatting
  expansion from 37,316,975 to 106,655,667 bytes, exceeding the 48 MiB bound. Pose candidates now keep
  verified native bytes instead of increasing the loader limit. The next run exposed Land Mine's
  hardcoded old scene digest; it now requires the manifest's validated expected scene revision.
  Eight weapon loaders plus positive/wrong-scene Land Mine checks pass; Release build has zero
  warnings/errors. Four pose and three diagnostic-stage guards pass. Full load now stops at Heavy
  Turret's equivalent old scene pin, not a completed release. Failed overlays retain diagnostics.

- Heavy Turret scene binding now follows the manifest's validated expected revision, preserving all
  target, geometry and balance checks. Release build has zero warnings/errors; eight weapon loaders
  plus positive/wrong-scene Land Mine and Heavy Turret checks pass. Full diagnostic
  `combat-candidate-audit-6e3a60a44eb74558bbfd0d0cd09bab4e` now reaches Mortar pool loading, whose
  whole-file `VerifiedRevision` still pins old deployment provenance. This requires explicit release
  revision ownership shared by Backend admission and Worker startup, not removal of the hash check.
  Diagnostic completion now applies managed retention to bound accumulated failed overlays.

- Mortar release revision resolved: candidate combat manifests use version 14 with explicit
  `MortarWeaponPoolRevision`. One shared version policy retains the reviewed legacy pin only for
  version 13, requires canonical SHA-256 for version 14, and rejects invalid version/revision pairs.
  Backend and Worker validate the same pool file and include its chosen revision in package identity.
  Five manifest generator tests pass; Release build has zero warnings/errors. Old production v13 and
  staged v14 pass eight weapon loaders, Backend rifle admission and deployable scene/hash guards.
  Full diagnostic `combat-candidate-audit-4c2fed579c09496992667dd813e46995` passes Mortar and next
  rejects co-op Assaulter's old artifact pin. This remains an incomplete content release.

- Assaulter release binding resolved: v14 now requires `CoopAssaulterWeaponRevision`; both Backend
  and Worker validate that file hash and include it in package identity. Legacy v13 identity remains
  unchanged. The loader preserves weapon/prefab/cadence checks and distinguishes only the reviewed
  visual-loader SoldierBehaviour source transition. Six generator tests and Release build pass;
  v13/v14 focused loaders reject wrong Assaulter scene/artifact hashes. Full diagnostic
  `combat-candidate-audit-18c3d71503ea4311a55c0c6d98550fbe` now reaches the air-geometry historical
  pin. Its shared collider loaders and dependent native geometry require coordinated binding next.

### EN02 — Finish cohesive simulation ownership



- [ ] **P2 / Partial.** S07-S09. Nine PvP ownership increments exist; large partial engines remain.
- Extract remaining army/vehicles/air/cards/world effects/projections and shared capacity/ID owners.
  Apply the same process to co-op. Define command, frame, snapshot and terminal ports only where
  consumers actually differ. Keep mutation private and views detached/read-only.
- Gate: source-backed/frozen before-after traces, independent state ownership, same-tick exceptions
  and cleanup, substitution contracts, project dependency checks and relevant live integration.

### EN03 — Finish style enforcement and developer navigation

- [ ] **P2 / Partial.** S10. Ownership guides exist, but dense legacy code and unenforced style remain.
- Apply scoped style checks to changed/new authored files; introduce CI/pre-commit checking without
  reformatting recovered sources or generating a whole-repository cleanup diff. Keep guides aligned
  with actual owners and remove stale root paths after deliberate moves.
- Gate: clean changed-file formatting, dependency/source-layout checks and understandable tests.

### EN04 — Add reproducible Release performance baselines

- [ ] **P1 / Missing.** P01. No `War.Server.Benchmarks` project exists in the current solution.
  `BattlePerformanceLedger` is gameplay evidence, not a latency/allocation measurement harness.
- Add the explicit development tool shown above. Cover HTTP parsing, authenticated UDP RTT, complete
  combat ticks, static/dynamic collision, serialization and Mongo transactions independently.
- Record build/runtime/hardware, content/input hashes, seed, warmup/sample counts, operation units,
  p50/p95/p99/max, throughput, allocations, GC pauses and drops. Retain bounded summaries/raw samples
  through the managed test-run lifecycle; never clone a Unity project for a protocol benchmark.
- Gate: repeatable Release scenarios, correctness checks outside timed regions and visible contention.
  A narrow serialization microbenchmark or 32-match polling fixture cannot establish combat capacity.

### EN05 — Optimize measured bottlenecks without weakening authority

- [ ] **P2 / Unmeasured candidates.** P02-P08, then P09 only after capacity evidence.
- P02: bounded persistence coordinator for synchronous journal/outbox disk work; preserve durable
  publication before successful terminal/control responses and correct shutdown/fault recovery.
- P03: authenticated session-to-match ownership index with reconnect/revocation/expiry consistency.
- P04: profile per-tick allocation, LINQ, sorting and repeated snapshots; reuse bounded buffers only
  when no mutable alias can escape a frame or a replay receipt.
- P05: static/dynamic broadphase and hot collision queries while preserving nearest-hit/tie semantics.
- P06: avoid repeated snapshot sizing/encoding; cache immutable bytes with correct invalidation.
- P07: ingress/send contention, parsing/copies and fair bounded admission under authenticated load.
- P08: shared Mongo clients, indexes/projections and bounded Backend queries after correctness proof.
- P09: distribute independent matches across owners/processes only after measured headroom and isolation.
- Gate: before/after EN04 reports plus behavior/replay/fault checks. A 30 Hz host has 33.33 ms total
  frame budget; configured maximum 1,024 matches is not a demonstrated operating capacity.

### EN06 — Finish bounded test storage and fast developer workflow

- [ ] **P1/P2 / Partial.** T02, T04-T06. Ownership manifests, safe retention, fast/focused/runtime
  selectors and successful temporary-database cleanup already exist.
- Recorded review storage snapshot: root `.local` 80,842 bytes; `Server/.local` 2,624,416,528 bytes;
  external managed test runs 939,980 bytes. The historical 100 GB growth is not the current inventory.
  `Server/.local/test-runs` retains 424,348,200 bytes; do not silently delete unowned diagnostics.
- Migrate the six remaining explicit C# `.local` producers: `CombatContentTests`,
  `CoopCornerPreparationPlanTests`, `LiveBazookaUnityTests`, `LiveSmgTests`, `LiveRifleTests` and
  the Unity branch in Battle test `Program.cs`. Use PID plus process-creation identity and owned paths.
- Reuse a small number of disposable Unity projects with exclusive leases keyed by source/import
  revision; bound reports/publish outputs. Preserve active, linked, pinned and unmarked directories.
- Keep fast pure/protocol checks separate from storage, UDP, native physics, performance and Unity/
  Android gates. These are console assertion suites; `dotnet test` does not execute them automatically.
- Client boot storage increment: `ClientBootSmoke.ps1` now uses managed runs, owned Mongo/temp data,
  success cleanup, failed-run retention and exact environment restoration. Injected early-failure
  checks pass on PowerShell 5/7 plus 21 shared lifecycle tests. Actual refreshed Unity boot observation
  remains required; this does not certify a current gameplay run or complete reusable-project leases.
- Gate: interrupted/failed/concurrent runs, stale/PID-reused owners, no repeated Library copies,
  restored environment, documented retention and a measured small default developer footprint.

### EN07 — Current release gates and native operations

- [ ] **P1 / Verification gap plus operational work.** V03-V05; B34-B36.
- Preserve historical WSL combat/Mongo proof, then verify the final current revision on native Windows
  and Linux. Complete production-host installation, loaded-match restart/drain, disk/queue exhaustion,
  shutdown, backup/restore and bounded archival/maintenance behavior. Reuse existing health/metrics.
- Add operational collection/alerts for tick delays, authenticated drops, result backlog and storage
  failures; do not expose credentials or raw diagnostic bodies. No Docker dependency is required.
- Gate: current source/build/protocol/legacy/storage/UDP tests, production-host service lifecycle,
  normal two-Client modes, Android build/runtime and required scene/asset audits. Keep per-platform
  and per-mode outcomes separate; publishing alone is not runtime verification.

### EN08 — Complete contract coverage and keep evidence current

- [ ] **P1/P2 / Partial.** V01, V02, V06 and the B01 migration ledger.
- For every opened action/command, link builder, parser, caller, exact success/error fields, numeric
  widths, optimistic rollback, idempotency, authority owner and executable tests. Classify unproduced,
  local-only, retired and debug identities explicitly rather than implementing every enum entry.
- Refresh historical prose that conflicts with current code: result forwarding/acceptance and normal
  Client entry wiring exist; settlement/full gameplay still do not. Preserve dated logs as history.
- Gate: one executable disposition per action, a complete combat-family audit matrix, working local
  documentation links and completion claims that match actual runtime evidence.

## Work order and common acceptance contract

### Immediate implementation handoff

Owner priority: implement missing Backend/BattleServer gameplay features. Do not continue spending
successive increments solely on content verification. Start with BE01's ordinary PvP settlement,
then progression/events, remaining combat families/co-op, and the normal two-Client completion flow.

The first BE01 implementation is `Features/Battle/Settlement/BattleRankProgression`: it validates all
43 recovered rank rows and applies server-earned XP across exact thresholds, accumulating each
completed row's Gold/WarBucks and rank Army Power delta. It keeps zero-based durable ranks and computes
an immutable successor without mutating the account. Invalid rank state, incomplete/misordered rows,
fractional thresholds, negative rewards and overflow are rejected. The maximum rank retains bounded
XP without repeatedly issuing a nonexistent next-rank reward; this is explicit offline policy because
the original server cap behavior is absent. Release build and the source-backed progression tests pass.

This calculator is not yet connected to an HTTP route or database mutation. **BE01 remains partial.**
Next implement a transaction that reads accepted terminal evidence, its frozen manifest and current
accounts, binds the requester to a participant, calculates rewards/progression, and publishes both
account changes and battle/player replay responses atomically. Preserve existing ordinary-card
consumption at result acceptance. Then connect action 62 using the original response parser contract.
Do not merely flip `RewardEligible`, fabricate zero-reward Success, or mark Scored/Settled before
these writes exist. The currently unscored result format needs an explicit eligibility contract.

The interrupted content stage completed as
`sheet-candidates-13f4a39afa654eafb0504ace8036bc88`, following native blast capture
`blast-reference-recapture-c6458c0aeced438a82cd6bcfa733fdc5`. Both final native references matched
existing values with separately validated scene/weapon dependencies. Their new diagnostic entry and
ten Python guards are implemented; legacy blast calculations pass 49,523 assertions. The new combined
stage has not yet run that diagnostic. Runtime grenade rig data is still embedded/pinned; candidate
presence is not runtime publication. Keep this bounded follow-up separate from the gameplay priority.

### Delivery sequence

1. Resolve EN01 and design BE02's intent identity; complete BE03-BE04 authority boundaries.
2. Complete BS01-BS04 and BS12 evidence needed for BE01; ship one genuinely complete PvP lifecycle.
3. Add BE05-BE14 progression/economy features in dependency order; enable Arena/co-op only when their
   corresponding BS09/BS10 gates pass. Keep incomplete capabilities closed throughout.
4. Complete remaining army/vehicle/air/card/presentation families and local Photon-free behavior.
5. Develop EN04 alongside feature work, then use its measurements to prioritize EN05.
6. Continue EN02/EN03 ownership/style work and EN06 storage work with each relevant change.
7. Complete EN07/EN08 across platforms and modes before describing the whole game as implemented.

Every feature needs source evidence, typed input, current authenticated authority, bounded resource
use, immutable policy, atomic validated successor and replay behavior, exact Client response/rollback,
focused negative/race/fault checks and an honest runtime boundary. Do not invent production prices,
rewards, schedules, live-ops weights or historical-version counts to fill missing evidence.

## Coverage of the existing checklists

All 28 currently unchecked `todo-list.md` items are represented here:

| Existing item | Register owner |
| --- | --- |
| S07, S08, S09 | EN02; BS05-BS10 |
| S10 | EN03 |
| C03 | BE02 |
| C12 | BE04, EN01 |
| C13 | BE03, BE04 |
| C18 | BE01, BS01, BS02 |
| P01 | EN04 |
| P02-P09 | EN05 |
| T02, T04, T05, T06 | EN06 |
| V01 | EN08 and each Backend feature contract |
| V02 | BS02-BS12, EN08 |
| V03 | BS13, EN07 |
| V04, V05 | EN07 |
| V06 | EN08 |
| V07 | EN01 |

The broader [BattleServer checklist][battle-features] remains open beyond refactoring:

| Existing feature family | Register owner |
| --- | --- |
| B01 | BS11, EN08 |
| B02 | BE04, BE14, BS03 |
| B03-B04 | BS03-BS04, BS14 |
| B05-B07 | BS01, BS03; existing allocation remains |
| B08-B10 | BS03, BS08 |
| B11-B12 | BS04-BS07, BS14 |
| B13-B14 | BS05, BS07 |
| B15-B16 | BS06-BS07 |
| B17-B18 | BS08, BE14 |
| B19-B20 | BS01-BS02, BS12 |
| B21-B23 | BE05, BE09, BS09-BS11 |
| B24-B26 | BE01, BS02, BS12 |
| B27-B30 | BS12-BS14, EN07 |
| B31-B33 | BS01, BS11, BS14 |
| B34-B36 | EN04-EN07, BS13-BS14 |

## Deliberate exclusions and evidence-dependent actions

- **X01 — Provider account/social integration:** Facebook, Google Play and Game Center remain outside
  backend completion unless reauthorized. Keep callbacks safe and fail closed. Registered action 146
  also deliberately rejects provider creation; it is not omitted from the review because it is registered.
- **X02 — Debug/cheat mutations:** keep disabled in ordinary deployments. Do not implement these as
  gameplay features or expose them through the same credentials as a player session.
- **X03 — Unproduced/local/ambiguous identities:** inspect source references before choosing a disposition.
  Old response-only names, generic list enums and ambiguous visual acknowledgements are not authority
  to add a new mutation. Document retirement or safe compatibility when no actual feature exists.
- Photon Cloud/Chat and retired Fuse/Kochava/AWS/platform services are never offline boot dependencies.
- Source-disabled War Cards, helper-only units and unpriced source tables remain unavailable.
- A new admin website, Redis cluster, Docker/Kubernetes deployment, Unity server conversion and claims
  about unrecovered original server policy are not prerequisites inferred by this document.

## Read-only verification performed for this review

The latest refresh recounted all 12 Server projects and their authored C# files, checked project
references against the dependency rules above, and confirmed that Backend and Worker retain only
`Program.cs` at their C# roots. Domain now contains 308 files and Battle tests 433; these counts
include unfinished working-tree files and do not measure feature completeness.

Source inspection reconfirmed action 62 as closed, both PvP/co-op snapshots as reward-ineligible,
and `LegacyInboxEndpoint.Read` as an empty inbox projection. It also identified the unconnected air
inventory validator described in the implementation handoff. The layout verifier, all eight layout
regression tests and the 67-row card inventory check were rerun successfully for this refresh.
No full build, database, combat, Unity or Android execution was performed for this documentation update.

The follow-up document review reran the source-layout verifier, its eight regression tests and the
card-inventory check successfully. Storage sizes and other execution results below are retained
review snapshots; they are not continuous measurements or a fresh full-game test run.

The latest document cross-check also confirmed all 29 local Markdown links resolve, all 12 Server
project files remain present, and the two registers retain their separate scopes: 66 repair tasks
in `todo-list.md` (38 checked, 28 open) and 39 unfinished feature packages here. Passing structural
checks does not complete those packages or establish combat, economy, performance or platform parity.

| Check | Current outcome |
| --- | --- |
| Source layout verifier | PASS: 687 root moves, 632 project extractions; host/library roots clean |
| Source layout regression tests | PASS: 8 tests |
| Current source-card inventory | PASS: 67 rows, 57 enabled, 10 source-disabled |
| Mission catalog `--check` | FAIL: catalog differs from recovered MainScene |
| PvP score-streak `--check` | FAIL: policy/content refer to different scenes |
| PvP bonus catalog `--check` | FAIL: catalog/content refer to different scenes |
| Project/action/todo inventory | 12 Server projects; 175 dispositions; 66 todo items, 38 checked/28 open |
| Storage inventory | Sizes recorded under EN06; no files removed |

The passing card-inventory check is specifically `audit_battle_card_inventory.py --check`; it does
not validate every card/content provenance binding. Do not merge this result with a different
historical card-source failure. No current full source checkpoint is claimed while EN01 fails.

### Primary source navigation

- [Direct action dispositions](Server/src/War.Backend/Legacy/Dispatch/Composition/LegacyUnavailableActions.cs)
  and [legacy action IDs](Server/src/War.Backend/Legacy/DatabaseAction.cs).
- [Result acceptance](Server/src/War.Backend/Features/Battle/Results/BattleTerminalAcceptance.cs)
  and [durable result state](Server/src/War.Persistence/BattleResultStore.cs).
- [Normal Worker admission](Server/src/War.BattleServer/Matches/MatchRouter.cs)
  and [supported mode policy](Server/src/War.Battle.Domain/Matches/BattleModeCapabilityPolicy.cs).
- [PvP execution](Server/src/War.Battle.Simulation/Match/MatchEngine.cs)
  and [co-op execution](Server/src/War.Battle.Simulation/Coop/Runtime/CoopMatchRuntime.cs).
- [Durable card admission](Server/src/War.Battle.Domain/Cards/OrdinaryCardInventory.cs)
  and [cosmetic purchase boundary](Server/src/War.Backend/Legacy/Buffering/Inventory/LegacyBufferedCosmetics.cs).
- [Client request builders](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/BeanstalkServerManager.cs)
  and [Client response parsing](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/ServerResponseHandler.cs).
- [Normal Client match entry](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerDeathMatch.cs)
  and [normal Client bridge activation](Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/GameControllerPVP.cs).
- [Current test workflow](Server/docs/TESTING.md), [Linux evidence](Server/docs/BATTLE_LINUX_VALIDATION.md)
  and [source ownership](Server/docs/SERVER_STRUCTURE.md).

[terminal]: Server/docs/NORMAL_UNITY_TERMINAL.md
[pool]: Server/docs/CARD_POOL_PUBLICATION.md
[squads]: Server/docs/SQUAD_PUBLICATION.md
[state]: Server/docs/STORED_STATE_VALIDATION.md
[catalog]: Server/docs/LEGACY_CATALOG_VALIDATION.md
[chat]: Server/docs/OFFLINE_CHAT_BOUNDARY.md
[cards]: Server/docs/BATTLE_CARD_SOURCE_INVENTORY.md
[battle-features]: Server/docs/BATTLE_SERVER_FEATURES.md

## Closed-action inventory

The following appendix is derived from the current `DatabaseAction.cs` and explicit
`Dispatch/Composition/LegacyUnavailableActions.cs` registrations. It covers all 86 `Closed` entries,
not the 25 implemented `BufferedOnly` entries. Owners are implementation/review tasks above, not a
promise that every closed enum should be enabled. Check its real Client producer before changing it.

| ID | Recovered action | Work/disposition |
| ---: | --- | --- |
| 2 | `MessageSent` | BE13 |
| 3 | `AcceptChallenge` | BE15 |
| 4 | `GetAllPlayers` | X03 |
| 12 | `IgnoreMessage` | BE13 |
| 26 | `GetFriendsInfo` | BE15 |
| 39 | `UniqueSquadNameFailure` | X03 |
| 40 | `UniqueSquadNameSuccess` | X03 |
| 42 | `RemoveUserFromSquad` | X03 |
| 52 | `AddFacebook` | X01 |
| 53 | `SwitchToFacebook` | X01 |
| 54 | `FacebookLoginOk` | X01 |
| 60 | `UserAddedToSquadSuccess` | X03 |
| 62 | `GameEnded` | BE01 |
| 67 | `GameStartedCampaign` | BE05 |
| 68 | `GameStartedCoopMaster` | BE05 |
| 69 | `GameStartedCoopClient` | BE05 |
| 84 | `AddToHitList` | BE15 |
| 85 | `GetPlayersFromHitList` | BE15 |
| 86 | `ExpandHitList` | BE15 |
| 87 | `HitListPlayerLoggedIn` | BE15 |
| 88 | `ProvokePlayer` | BE15 |
| 89 | `SearchPlayers` | BE15 |
| 90 | `SystemMessage` | BE13 |
| 91 | `ClaimReward` | BE13 |
| 94 | `DebugAddLevel` | X02 |
| 101 | `GetSquadsByExperience` | BE11 |
| 106 | `GetPlayerLeaguesDivision` | BE11 |
| 107 | `GetPlayersByExperience` | BE11 |
| 108 | `DecalWasShown` | X03 |
| 111 | `GetMissionLeaderboards` | BE05 |
| 112 | `SkipAssignment` | BE06 |
| 113 | `JoinSquadEvent` | BE11 |
| 114 | `BuyVip` | BE12 |
| 121 | `ChangeNameAndPassword` | BE17 |
| 122 | `CreateFullAccount` | X03 |
| 124 | `GetSquadWarsDivision` | BE11 |
| 130 | `BuyPack` | BE12 |
| 134 | `DebugAddSquadLevel` | X02 |
| 135 | `GenerateSpecialOffer` | BE12 |
| 136 | `AcceptSpecialOffer` | BE12 |
| 138 | `AcceptRentalOffer` | BE12 |
| 142 | `BuyInApp` | BE12 |
| 147 | `AddDebugGoodies` | X02 |
| 148 | `SendPlayerReport` | BE17 |
| 149 | `GetNewAssignments` | BE06 |
| 152 | `GetLastWeeksPlayerLeague` | BE11 |
| 154 | `AddGameCenter` | X01 |
| 156 | `AddVideoReward` | BE08 |
| 159 | `DebugChangeLevel` | X02 |
| 160 | `InformSquadLeaderAboutEvent` | BE11 |
| 161 | `AddOneTimeReward` | BE08 |
| 162 | `DebugChangeMedals` | X02 |
| 164 | `RemoveFacebook` | X01 |
| 171 | `ClaimAssignment` | BE06 |
| 173 | `ClaimAssignmentMegaReward` | BE06 |
| 184 | `ReadMessage` | BE13 |
| 185 | `CompleteStarterAssignments` | BE06 |
| 186 | `ClaimStarterAssignment` | BE06 |
| 187 | `AddGooglePlay` | X01 |
| 188 | `RemoveGooglePlay` | X01 |
| 189 | `RestorePacks` | BE12 |
| 190 | `BuyLootboxes` | BE12 |
| 194 | `MessageWasShown` | BE13 |
| 198 | `FinishPlayerLeague` | BE11 |
| 199 | `InstantBattle` | BE10 |
| 200 | `EnterArena` | BE09 |
| 201 | `BuyArenaHearth` | BE09 |
| 202 | `TakeArenaLife` | BE09 |
| 203 | `GetScrapsReward` | BE09 |
| 204 | `DebugChangeArenaLives` | X02 |
| 205 | `DebugChangeArenaWins` | X02 |
| 206 | `GetArenaLeaderboards` | BE09 |
| 210 | `DebugAddScraps` | X02 |
| 211 | `WarArenaEnded` | BE09 |
| 1000 | `MaxAll` | X02 |
| 1001 | `CheckDailyReward` | BE07 |
| 1002 | `ClaimDailyReward` | BE07 |
| 1004 | `DebugRenewRental` | X02 |
| 1005 | `RemoveOrUpdateGC` | X01 |
| 1006 | `RemoveFromLeague` | BE11 |
| 1008 | `ExistGCAccount` | X01 |
| 1009 | `ExistFBAccount` | X01 |
| 1010 | `DebugChangeLeague` | X02 |
| 1011 | `DebugChangeDivision` | X02 |
| 1012 | `DebugChangeAnticheat` | X02 |
| 1013 | `RefundPack` | BE12 |
