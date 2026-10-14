# Source PvP bonus crates

This follows the active recovered 1.4.0 Client. The reviewed catalog and weight
calculation are implemented; selection, delayed spawning, collection, bonus
effects, durable rewards and normal Unity presentation remain incomplete.

## Source bindings

`MainScene.KillStreakManager.bonusesPrefabs` has nine entries. Its order differs
from the `Google2u.Crates.rowNames` order. Preserve the prefab indices used by
`SpawnBonusNetwork`, rather than treating spreadsheet positions as network IDs.
`recovered-pvp-bonus-catalog.json` records each original prefab GUID, component
file ID, path, digest, and its probability row, plus scene/content/code provenance.
`PvpBonusCatalog` validates the reviewed digest and both content bindings at load,
then publishes read-only rows and weight snapshots.

| Index | Prefab name | Ordinary weight | Arena weight |
| --- | --- | ---: | ---: |
| 0 | KillStreakBonusGold | 10 | 0 |
| 1 | KillStreakBonusAddHealth | 20 | 20 |
| 2 | KillStreakBonusWarbucks | 30 | 0 |
| 3 | KillStreakBonusGrenades | 20 | 20 |
| 4 | KillStreakBonusSlowMotion | 35 | 35 |
| 5 | KillStreakBonusTurret | 35 | 35 |
| 6 | KillStreakBonusKevlar | 10 | 10 |
| 7 | KillStreakBonusCard | 5 | 0 |
| 8 | KillStreakBonusAddAmmo | 25 | 25 |

These are unnormalized weights before source overrides and exclusion of the
previous selection. They are not percentages or permission to grant an item.
The separate booby-trap prefab is not one of these nine weighted entries.

## Source weight overrides

`KillStreakBonus.GetBonusProbability` chooses the ordinary/Arena sheet value.
Four subclasses then change it:

- Gold: `PlayerAnalytics.IsAllowedGoldBonus` closes friendly DeathMatch. At
  local display level five or lower it ignores the collected-Gold cap; above
  five it requires `data.goldBonuses < 3`. Allowed Gold uses local display level
  interpolation: 25 at level five or lower, the base weight at eight or higher,
  and the original float interpolation between. This also overrides Arena's
  zero base for low local levels. Do not silently force all Arena Gold to zero.
- Warbucks: `IsAllowedMoneyBonus` closes friendly DeathMatch, with no extra cap.
- Card: closes friendly DeathMatch and requires the supplied owner's
  `playerProperties.level` strictly above the source unlock value six. This is
  the owner's zero-based rank index, unlike Gold's local display number.
- Ammo: doubles its base weight when either of the first two used weapons has
  low ammo. A third low-ammo weapon does not trigger it. `Weapon.hasLowAmmo`
  additionally requires a reloadable weapon and checks total reserve plus clip
  against starting ammunition using the source LowAmmoRatio of 0.1. That
  ammunition predicate still needs host integration; the catalog receives only
  an already established first-two condition.

`PvpBonusWeightContext` represents a host-established source perspective, not
packet assertions. Gold's local level/analytics must not be replaced with the
owner's data merely because an opponent bonus is being evaluated. Context ranks
are bounded to the recovered 43 rows; collected Gold count must be nonnegative.

## Verification and remaining selection work

An isolated Unity 2018.3 Mono probe compiles the original probability methods,
`LevelManager.InterpolateNumbersBasedOnLevel`, and both analytics getters.
Dependencies supply reviewed table values and controlled state. Its 192
contexts vary local levels 1/5/6/7/8/43, owner indices 6/7, Arena/ordinary,
friendly/random DeathMatch, Gold counts 0/3, and first-two low ammunition. A
third weapon is always low to check the source two-weapon limit. Server tests
compare all nine resulting weights by raw float bits. This does not verify
Unity Play Mode, original Unity 5.2 Android, or source random sampling.

Regenerate the catalog with `extract_pvp_bonus_catalog.py`; `--check` verifies
the checked-in source artifact and is part of the Battle release checkpoint.
Run `Server/scripts/AuditPvpBonus.ps1` for the isolated Mono fixture and
`--pvp-bonus-only` for the Battle catalog/weight tests.

`KillStreakManager.GenerateNewBonus` schedules spawning after 1.5 seconds.
`SpawnBonus` first consumes an owner-fraction queue; otherwise its weighted
selection excludes one shared `mLastBonusIndex`. That index starts at zero and
is not reset by the shown GameStarted handler. The float random draw, strict
cumulative comparison, upper endpoint, all-zero behavior, selection lifetime,
queue overrides and source perspective require the manager state described
below; actual random sampling and lifetime binding still need verification
before live selection is enabled. At an unselected final loop iteration the
source keeps the last prefab while its index reaches the list count. The source
probe below confirms this; there is no uniform or valid-index fallback.

After selection, the source chooses a map spawn area and a point inside its
bounds, assigns owner/box identity, sends the spawn RPC, and later activates the
bonus through the shot/collection path. Those steps must be replaced with host
authority and replay-safe events; reward-bearing collection must settle through
the Backend. The current catalog performs none of those mutations.

`recovered-pvp-bonus-spawn-areas.json` now pins the two `MapDefinition.spawnAreas`
BoxColliders in source order for each of the five multiplayer maps. The
extractor checks each scene digest, collider type, transform chain, and the
original `SpawnBonus` area/X/Y/Z sampling calls. Every referenced transform
has identity rotation and unit scale, so the exported world AABBs come from
local BoxCollider bounds plus parent positions. `PvpBonusSpawnAreaCatalog`
loads this reviewed artifact with the combat package, binds all five map
hashes, and maps an explicit host area choice plus three unit draws to a world
position. `AuditPvpBonusSpawnAreas.ps1` rebuilt all ten source transform chains
and colliders in an isolated Unity 2018.3 Editor project. Each actual Unity
`BoxCollider.bounds` matched the exported source bounds within 0.00002 world
units; the raw Unity results are pinned in
`unity-pvp-bonus-spawn-areas-reference.json` and checked by the focused server
test. This is a geometry input, not a live crate spawn or proof of falling box
physics. Random sampling, fall/contact, pool identity, host entity publication,
and pickup still need runtime proof.
Regenerate/check with `python Server/tools/extract_pvp_bonus_spawn_areas.py
--check`; focused server checks use `--pvp-bonus-spawn-areas-only`.

`PvpBonusSpawnPlanner` now joins one matured host delay receipt with the
source's shared selection history and one map position. It derives the
owner's fraction and rank plus the local display rank from the validated
match manifest; the serialized host actor must establish Arena/friendly mode,
Gold count, first-two low ammunition and random draws. The planner copies
selection queues and receipts before attempting placement, registers the
host-owned box, then publishes the plan and selection together. A failed area,
weighted draw, or full box registry leaves the queue and last index untouched;
the matured request can be retried after capacity is freed. A repeated receipt
returns the original plan. On the source's
inclusive upper-endpoint fallthrough, the plan retains `SourceIndex=9` for
future exclusion history and uses the actual prefab's valid index eight for
publication. This explicit repair prevents an out-of-range prefab lookup in
the replacement Client; it does not claim exact original RPC parity at that
broken endpoint. The registered host box is not yet a network entity or physics
body, and it grants no reward. Run `--pvp-bonus-spawn-plan-only` for the
focused transaction checks.

`PvpBonusBoxRegistry` now admits a plan as a host-owned falling box only when
its owner, source/published prefab indexes and selected position bind the
admitted match and reviewed spawn area. Each box reserves room for its final
damage receipt. A confirmed static contact makes it grounded; confirmed lethal
damage can collect it even while airborne, as the source `OnDeath` has no
`onGround` gate. The damage owner's fraction chooses the recipient; a null
damage owner falls back to the earning owner. One matching damage receipt
returns the original candidate, and a second claimant is rejected. A
confirmed booby-trap card arms the earning fraction and is consumed only when
an opposing recipient steals one of its boxes. Collection is still a candidate:
there is no box physics solver, live MatchEngine callback, Client event,
automatic effect dispatch, or Backend currency/item grant yet. The replacement uses
the host receipt as an opaque box identity until its Client protocol is wired.
Only a collected host box exposes an effect intent. Its nine prefab indexes map
to the nine recovered `KillStreakBonus` subclasses in source order; a stolen
box with a consumed booby trap instead exposes `BoobyTrap` for the attacker.
The intent alone does not mutate the match or award currency.
The source `KillStreakBonusKevlar` sets `kevlarStrength` to 0.1 before
`SetUpKevlar`, separate from the 0.2 Kevlar Up card. `PlayerKevlar` now exposes
that crate maximum. `KillStreakBonusAddAmmo` adds each used weapon's clip size
to its reserve without a setter cap; `PvpBonusAmmoPolicy` validates that
arithmetic before a host mutation. A source-view `MatchEngine` now configures
its crate registry during construction from the signed scene master and both
player levels. It can apply collected Health, Kevlar and ammo intents to its
admitted player state once per box, rejecting invalid arithmetic before any
slot changes.
Health uses `PlayerDamage.Resolve` with negative Basic damage, so its recovered
OnDamage dodge/immortality/tutorial gates remain in the path. The recovered
`CardConstants.BoobyTrapDamage` row is 0.15 of the recipient's maximum health;
the pinned combat sheet validates this value at load. A stolen trapped box now
applies that Explosion damage through the existing player damage and terminal
paths. A lethal result ends the match, while replay of the same box stays
idempotent after termination. The normal Worker uses this construction path,
but does not yet route score/delay maturity, box collision/death or Client
events; other effects remain closed.

`PvpPlayerHitSkillShotPolicy` now classifies the two confirmed player-damage
branches of `SkillShotControllerPlayer.PlayerOnDamage`: a different player
owner earns `EnemyPlayerHit` and, only when the victim's source state is
Walking, `OnTheMove`; a hostile AIObject earns its owning player
`ArmyPlayerHit`. Poison and Immortal return before those branches. Flame stays
closed until its real-time six-hit throttle is reproduced. The policy requires
host-proven damage ownership, faction and walking state. `PvpBonusProgressCoordinator`
can now accept such confirmed damage through one receipt: it calculates the
source flags, then publishes score and streak gain together. Poison, Immortal,
unverified Flame, self damage and friendly army damage retain an unscored
receipt so replay cannot convert them into points. The normal player-owned
bullet impact now stages this transition before publishing damage; a malformed
or exhausted score receipt aborts the host hit without partial score or health.
The live infantry projectile collision stages `ArmyPlayerHit` under a separate
projectile receipt before player damage; poison follow-up pulses remain excluded.
Other army-owned damage, death/combo flags, verified walking state parity, card
multiplier lifetimes, source frame advancement and crate issuance remain open.
The Client class default for `CRATEBLOCKER` is 0.8, but its MainScene component
serializes zero; the server retains the scene value.

## Collection contract to implement next

`KillStreakBonusBox.OnInstancied` sets health to one and clears `onGround`.
The box's public fraction is None; its separate owner identifies the player
who earned it. On a non-network death, a present damage owner selects the
recipient by that attacker's fraction. Without a damage owner, the recipient
falls back to the crate owner's fraction. Thus an opposing shooter can steal
the bonus; collection must not always grant it to the original owner.

`KillStreakManager.ActivateBonus` records the box ID, shooter and Photon time.
Its peer arbitration compares competing timestamps through TryActivateBonusRPC
and ActivateBonusResultRPC. The replacement needs one host-confirmed winner and
an atomic terminal crate receipt; Client timestamp assertions and duplicate RPCs
must not create a second recipient/effect/reward.

On accepted opposing collection, a set owner-fraction booby-trap flag replaces
the selected bonus with the separate booby-trap prefab and clears that flag.
The stolen-crate presentation then runs before ActivateBonus. Only local
recipients increment the source destroyed-box count; Gold and Warbucks bonus
activation have their own local reward counters. Preserve these distinct events
when projecting host statistics rather than inferring collection from a shot
request or a progress threshold.

While falling, OnCollisionEnter may destroy a `destroyableByBonusBox` object
with weaponless Basic damage, null owner and immortality ignored. A static
collision marks the box on-ground/alive. Spawn-area geometry, falling contacts,
these damage callbacks and recipient fallback require host simulation evidence
before the crate entity is admitted. No current SDK event or catalog test proves
that gameplay path.

## Verified selection state

`PvpBonusSelectionState` now mirrors the selection prefix of SpawnBonus. Its
shared last index starts at zero, so the initial weighted selection excludes
Gold. It sums source float weights with storage after each addition, uses the
strict `draw < cumulative` comparison, and shares exclusion history between
the two source fractions. It does not generate Unity's random sequence: the
serialized host actor supplies one draw in the exact total-weight range.

Each side has a FIFO queue. A nonnegative queued index bypasses probability
gates and exclusion, without drawing randomly; `CardIncreaseBonusChance` can
enqueue the IndexOf result `-1`, which consumes that queue head and falls back
to weighted selection. Queueing and selection have canonical host receipts;
replays do not enqueue again, redraw, consume another head or rewind history.
Changed operation kinds, sides, indices, or selection contexts are rejected.
Invalid draw results leave the pending head and accepted state unchanged.

`ClearQueuesForGameStart` reproduces the original queue clear without resetting
the last index. It retains receipts so an old accepted enqueue cannot reappear
after a clear. Queue size 64 per side and 4,096 combined mutation receipts are
explicit host safety bounds, not recovered production limits. Source manager
lifetime, replay scope, capacity handoff, and previous-game state still require
binding before admission into live matches.

The isolated Unity 2018.3 probe compiles the original SpawnBonus prefix up to
the last-index assignment; only Random.Range is replaced by controlled draws.
It captures 66 cases with ordinary/Arena/fractional/all-zero weights, exclusion
indices 0/1/8/9, zero/cumulative/midpoint/upper-endpoint draws, and queued
overrides on both sides. Prefab selection, source index, float total and draw
count are compared against the server. This tests the prefix over fixed weight
snapshots, not Unity random distribution, spawn physics or full game behavior.

For a draw equal to total, or an all-zero diagnostic table, the original retains
prefab index eight but records/sends source index nine. The state preserves both
values and marks `HasValidSourceIndex` false. The next selection then excludes
no prefab, matching the source last index nine. This is not authorization to
publish an out-of-range SDK event or silently remap it. A reviewed live wire
boundary must handle this observed source defect before selection is connected.

Run `Server/scripts/AuditPvpSelection.ps1` for the Mono fixture and
`--pvp-selection-only` for source comparison, queue ordering, replay, corrupted
draw and capacity checks. Delayed spawning, source-manager perspective, actual
random sampling, crate contacts, collection, effects and Backend rewards remain
unbound.

## Coroutine delay state

`PvpBonusDelayQueue` now schedules confirmed request identities over ordered
host scaled-frame deltas. It excludes the issue frame's delta, waits for 1.5
scaled seconds, and returns matured requests in issuance order. Zero delta
pauses the wait. It captures match/owner identity and a consecutive per-owner
request ordinal, not an early probability snapshot: SpawnBonus evaluates owner,
probabilities and map availability when its callback actually executes.

Receipt replay does not create another wait. Changed match, owner, ordinal or
issue frame fails; a new receipt cannot reissue a prior ordinal. Frame replay
requires identical delta bits and cannot age newly scheduled work twice. Matured
requests remain receipt-protected. Consumers must deduplicate by request receipt
before selecting/spawning, because frame replay returns its original ready list.
The default 256 pending requests and 4,096 issue receipts are explicit host
safety bounds, not source production limits. Live capacity admission must be
coordinated with score/progress publication so an exhausted queue cannot consume
a bonus threshold without retaining its request.

The source was exercised in **isolated Unity 2018.3 Play Mode**, using the exact
GenerateNewBonus, Core_BaseScript.InvokeAfter/WaitAndCall, and the manager's
GameEnded handler. A stub records the SpawnBonus callback; pool cleanup is
recorded rather than executing real crate/scene destruction. The fixture stores
every observed float frame delta and callback frame. The server replays those
deltas and matches these eight traces:

| Case | Callback frames after issuance | Observed result |
| --- | ---: | --- |
| 30 fps, scale one | 45 | 1.5 scaled seconds |
| 60 fps, scale one | 90 | 1.5 scaled seconds |
| 30 fps, scale 0.5 | 90 | Slower game clock |
| 30 fps, scale two | 23 | First frame after 1.5 scaled seconds |
| Pause for ten frames | 55 | Paused frames do not advance the wait |
| GameEnded handler, manager alive, clock running | 45 | Existing pool cleanup does not cancel the wait |
| Two requests in the same frame | 45 | Both callbacks, in original issuance order |
| Manager component destroyed after five frames | None | No callback during the remaining observed window |

The original GameEnded handler frees existing boxes, but does not stop the
coroutine. Other game listeners may still change time scale, unload scenes or
destroy the manager. Therefore this is not a claim that a normal ended match
always spawns a late box. Dispose the host queue for actual manager destruction,
not merely a game-end notification; lifetime/owner/map binding remains required.

Run `Server/scripts/AuditPvpDelay.ps1` for the disposable Play Mode trace and
`--pvp-delay-only` for frame-by-frame server comparisons and receipt/order/capacity
checks. The measurement includes absolute engine clock values, so regeneration
requires reviewing the new trace and its pinned test digest. These experiments
do not verify the original Unity 5.2 Android runtime, arbitrary long-frame clock
equivalence, full WarFriends Play Mode, live MatchEngine timing, physics,
collection, effects or economy. No current code publishes a crate from this
queue.

## Atomic progress-to-delay publication

`PvpBonusProgressCoordinator` now owns both progress states and the delay queue
for one match/source view. It applies one source `dropsCrates` ratio to both
players, as ScoreManager.Restart does. Local progress is processed before
opponent progress; the resulting waits retain that order.

The coordinator prepares frame-only progress copies, a private pending-timer
copy, and new issue identities before publishing any of them. Gain receipt
ledgers are read-only while a frame is prepared; delay receipt/ordinal ledgers
are copied only on frames that will write new requests. A private lock protects
gains, preparation and publication, and callers receive immutable snapshots,
not mutable access to the underlying states.

Any validation or capacity rejection discards the whole candidate frame:
neither owner's decay/threshold subtraction/ordinal nor existing timer aging
is consumed. An existing wait that matures in this frame can release space for
a new zero-age wait. Preparing that maturity before staging issuance is
equivalent here because no callback runs during preparation and new waits do
not count their issue-frame delta. Delivery becomes visible only after both
progress states and the queue are published together.

Accepted replay requires identical frame delta bits and running state and
returns the original frame, without new host identities or another timer.
Failed frames remain unaccepted and can be retried with authoritative inputs.
Stopping score updates still permits existing waits to mature when the game
clock advances; actual manager destruction disposes the queue.

Run `--pvp-progress-transaction-only` for joint issuance, shared ratio, immutable
delivery order, retry, two-owner capacity failure, replacement at a full queue,
and receipt-exhaustion rollback checks. This is still not connected to normal
MatchEngine death callbacks, score/count publication or Unity presentation.
Source-view/manager lifetime, whole-match capacity admission, frame-clock binding,
selection, spawn/collection/effect authority and Backend rewards remain open.
