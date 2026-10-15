# Source PvP bonus crates

This follows the active recovered 1.4.0 Client. The reviewed catalog, weight
calculation, host selection planning, automatic delayed issuance for signed
bonus-mode matches, and a read-only Unity box presentation are implemented.
Player-bullet, grenade, and bazooka blast collection are implemented. Other
damage paths, full effect delivery and durable rewards remain incomplete.

Host-owned infantry projectiles now use the source layer-eight box collider
for damaging flight while their separate visibility probes remain unchanged.
A confirmed soldier bullet applies its launch damage through the soldier's
player owner, so an opposing army can steal a box. Focused flight, collection,
and replay checks pass; a normal deployed infantry shot into a box is still
unverified.

The source Rocket soldier's real missile also uses `MissileExplode`. Its
host flight now sees active box colliders, and the blast applies the pinned
card damage with the prefab's 0.8/1.2-unit radii. Focused checks cover flight
collision through a real host missile, blast range, opposing-owner collection,
and replay. A signed Park match now issues a queued Kevlar box from a source
spawn area, deploys the Rocket card, and observes a real automatic missile
collect the box and grant Kevlar. Two-peer presentation remains unverified.

The source Grenadier soldier inherits `GrenadeAmmo.MissileExplode`. Its
physical grenade now sees the same active box collider, and the host applies
the recovered card grenade's full object blast radius and damage. Focused
checks cover contact, range, opposing-owner collection, and replay. A normal
grenade flight also contacts the live box, completes its source fuse, and
collects it with the resulting blast in the focused host simulation. A normal
deployed Grenadier throw into a box remains to be verified.
An actual Park Grenadier deployment also confirms that automatic blasts
outside the recovered radius leave a host-issued box at one HP and grant no
Kevlar; this is a negative range test, not a collection proof.

The recovered `Missile.TryKill` sends RPG impacts through
`Explosion.MissileExplode`. The host now includes active box colliders in
bazooka flight tracing and applies the source dead/hurt radius falloff at the
confirmed impact. A positive hit destroys the one-HP box through the same
receipt-bound collection path as a player bullet. Focused host tests cover
range, opposing-player collection, replay, and a normal RPG hold, flight,
impact and collection against a live box. A two-peer UDP fixture now earns a
box from confirmed rifle hits, switches to RPG, and verifies both peers see
the host RPG impact and box removal. The fixture does not yet prove every
randomly selected bonus effect or visual presentation.

The host can call `MatchEngine.IssueNextMaturedBonus()` after a delayed request
matures. It derives mode, collected-Gold count, and the first two weapons'
low-ammo condition from signed/live match state. The planner supplies the
reviewed source weight total and map spawn-area count; the host draws the
weighted value, area, and three position coordinates. A queued bonus card still
forces its source prefab exactly once. A running match now drains matured waits
in source callback order, registers each falling box and publishes it in the
snapshot. Queued cards bypass the weighted random draw as in the Client.
Matches without a signed bonus mode do not auto-issue. Non-bullet dynamic
collisions remain open.
No live reward is granted merely because the plan exists.

The original `KillStreakBonusBox` prefab has a gravity-enabled Rigidbody and
BoxCollider. Its `onGround` flag changes only after a collision with source
static layer 13 or terrain layer 30. `PvpBonusLandingProbe` now queries those
exact layers in the recovered map geometry beneath a planned spawn position.
All ten reviewed spawn-area centers (two on each of five PvP maps) have a
static hit below them. Each accepted spawn plan now retains that optional
static-surface candidate. Registered boxes now advance under the pinned
`-9.81` source gravity on running host ticks. The server stops the vertical
motion at the candidate surface plus half of the source cube height and marks
the box grounded. It prepares all falling-box updates before publishing any,
so a failed calculation cannot move only part of a frame. This is a bounded
first-contact model: a downward center ray does not reproduce the entire
PhysX contact manifold, dynamic-object impacts, rotation or bounce. Grounding
does not collect a box or authorize its reward.

Active falling/grounded boxes now appear in `MatchSnapshot.pvp_bonus_boxes` in
stable box-ID order. Each row contains the admitted owner, source prefab index,
host position and phase; collected boxes disappear. `War.Client` checks the
bounded list, identity, owner, coordinates, prefab and phase before presenting
it. `SelfHostedBonusBoxPresenter` copies the recovered box mesh, team material
and source-sized BoxCollider for local aiming, follows the server position and
removes stale visuals after collection or reconnect. It attaches no Photon,
Rigidbody, damage or reward scripts. Server damage alone decides collection.
The latest collider change compiled in a disposable Unity 2018.3 project. Rendered Play Mode,
original Android Unity 5.2 and two-peer box display remain unverified.

The host treats an active box as a distinct runtime layer-eight hitbox, separate
from player and army target IDs. Player-owned bullets reduce its source one HP;
only lethal cumulative damage confirms collection, including in the air.
Projectile receipts prevent repeated damage or duplicate collection. An
in-process two-participant match now verifies a normal Fire command, bullet
travel, lethal collection, snapshot removal and the Kevlar effect. Two-peer
UDP Worker proof now covers two authenticated peers, source-triggered box
issuance, shared box identities, shooting one box and its disappearance on
both peers. Rendered Unity aiming and army damage paths remain unverified;
grenade damage has only focused host-blast proof below.

The serialized prefab starts on layer zero, but its `DestroyableObject.Awake`
sets the GameObject to destroyable-entity layer eight. The host and the local
Unity aiming collider now use that runtime layer. Source shotgun overlap can
select the box as an additional real pellet target: its `DestroyableObject`
owner is the box's neutral `IFraction`, so either player's cone may include it.
An in-process match now verifies a normal SPAS Fire command whose main pellet
misses the box while an extra real pellet collects it and applies Kevlar.
Two authenticated UDP peers also verify source-triggered issuance, shared box
identity and shotgun collection on both snapshots. Rendered Unity aiming
remains open.

The recovered `Explosion.MissileExplode` includes the box in its destroyable
overlap and uses the closest box-collider point for the lethal radius. Normal
player grenades and the KillStreak Manager grenade burst now use that same
host-owned distance and damage path. A grenade projectile receipt prevents a
second collection; a blast outside the hurt radius leaves the box untouched.
Focused host tests confirm a nearby grenade blast lets an opposing shooter
steal a Kevlar box. A bonus-enabled host match now also verifies a normal M320
throw command, projectile flight, grenade impact, box removal and Kevlar
delivery. A two-peer UDP grenade-box encounter and rendered Unity aiming
remain unverified.

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
  zero base for low local levels. `goldBonuses` is durable PlayerAnalytics data,
  not a per-match counter. A bonus-enabled signed manifest now requires the
  scene master's nonnegative starting count, and issue rejects a conflicting
  count. Backend projection and trusted Gold reward/collection increments are
  still open. Do not silently force all Arena Gold to zero.
  The source reward table is now pinned as well: `KillStreakBonusAddCredits`
  interpolates minimum 5 to 3 and exclusive maximum 10 to 6 across display
  levels five through eight, then truncates each bound before its integer
  random draw. The Battle catalog exposes those ranges; no Gold wallet grant
  or terminal reward receipt is published yet.
- Warbucks: `IsAllowedMoneyBonus` closes friendly DeathMatch, with no extra cap.
  The recovered `BonussesDefinitions` table supplies a base integer draw of
  500 through 1499. `KillStreakBonusAddMoney` multiplies that draw by
  `WarbucksScalingBase` 1.033 raised to the owner's zero-based level index
  minus three, then truncates to an integer. The catalog now validates this
  range and factor and exposes the calculated amount; wallet delivery and a
  durable reward receipt remain closed.
  An isolated Unity 2018.3 probe evaluates all 43 ranks and all 1,000 possible
  base draws. It found a real `MathF.Pow` mismatch at rank four/draw 1000:
  Unity returns 1032, while the former .NET calculation returned 1033.
  The host now loads the digest-pinned Unity scale for each rank and preserves
  Mono's intermediate multiplication precision. All 43,000 amounts match that
  probe. This establishes Unity 2018.3 arithmetic, not Android Unity 5.2
  runtime parity or a durable wallet grant.
- Card: closes friendly DeathMatch and requires the supplied owner's
  `playerProperties.level` strictly above the source unlock value six. This is
  the owner's zero-based rank index, unlike Gold's local display number.
- Ammo: doubles its base weight when either of the first two used weapons has
  low ammo. A third low-ammo weapon does not trigger it. `Weapon.hasLowAmmo`
  additionally requires a reloadable weapon and checks total reserve plus clip
  against starting ammunition using the source LowAmmoRatio of 0.1. That
  predicate now reads the first two signed equipped slots and their live host
  reserve/clip values. The complete 66-weapon source graph supplies each
  `reloadable` flag. A caller's conflicting low-ammo assertion cannot select a
  box; live firing-to-threshold and Unity parity remain to be verified.

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
`--pvp-bonus-only` for the Battle catalog/weight and exhaustive Warbucks
arithmetic tests. The checked-in `unity-pvp-bonus-reference.json` must travel
with the other combat content files because catalog startup validates its
digest and reads its reviewed rank scales.

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
test. This is a geometry input, not a live crate spawn or proof of full PhysX
parity. Pool identity, host entity publication, dynamic contacts, and pickup
still need runtime proof.
Regenerate/check with `python Server/tools/extract_pvp_bonus_spawn_areas.py
--check`; focused server checks use `--pvp-bonus-spawn-areas-only`.

`PvpBonusSpawnPlanner` now joins one matured host delay receipt with the
source's shared selection history and one map position. It derives the
owner's fraction and rank plus the local display rank from the validated
match manifest. The host derives Arena/friendly mode, Gold count and first-two
low ammunition, then supplies its own random draws. The planner copies
selection queues and receipts before attempting placement, registers the
host-owned box, then publishes the plan and selection together. A failed area,
weighted draw, or full box registry leaves the queue and last index untouched;
the matured request can be retried after capacity is freed. A repeated receipt
returns the original plan. On the source's
inclusive upper-endpoint fallthrough, the plan retains `SourceIndex=9` for
future exclusion history and uses the actual prefab's valid index eight for
publication. This explicit repair prevents an out-of-range prefab lookup in
the replacement Client; it does not claim exact original RPC parity at that
broken endpoint. The registered host box has vertical motion and first-static-
contact state and a read-only Client visual, but is not yet a shootable Client
entity or a complete physics body and grants no reward. Run
`--pvp-bonus-spawn-plan-only` for the
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
`PvpBonusSpawnPlanner.QuoteCurrencyReward` now produces a receipt-bound amount
only after host-confirmed collection of Gold or Warbucks. It uses the actual
recipient's signed rank: the local recipient's display number for Gold and
zero-based index for Warbucks. A changed draw cannot replace an existing
quote, and an uncollected or booby-trapped box yields no currency quote.
The production overload chooses the integer with the Worker's own bounded
random draw and replays the stored quote without drawing again. A supplied
draw overload remains internal for deterministic source tests.
`MatchEngine.ApplyCollectedPvpBonus` now calls that production path for a
confirmed Gold or Warbucks box and returns `bonus-quoted`. Its read-only
`CurrencyBonusQuotes` snapshot retains each box and actual recipient for a
future terminal settlement handoff. Calling the effect path before collection
returns unavailable, and calling it again after quoting does not redraw.
This quote is still match-local evidence, not a Backend wallet transaction;
count updates and delivery remain open. On a terminal transition, the Worker
now copies the sorted quotes into a private protobuf result field and the
durable terminal outbox. Public UDP snapshots omit it. Outbox validation
requires unique ordered box IDs, an admitted recipient, a bounded rank, and
the exact source Gold range or Unity-verified Warbucks amount. A reopened
outbox retains the same rows. The terminal result remains unscored with
`RewardEligible=false`. During result acceptance, Backend now compares each
recorded recipient rank with the frozen match manifest before storing the
result or releasing the queue pair, and refuses currency rows without that
allocation proof. It must still settle the wallet atomically before any quote
becomes a grant. A Worker crash before terminal publication still
produces an unscored host-crash result without these in-memory quotes.
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
Live infantry, Drone, Helicopter, Assault Helicopter and Heavy Turret projectile
collisions stage `ArmyPlayerHit` under a separate projectile receipt before
player damage; poison follow-up pulses remain excluded.
MatchEngine now advances source progress and waits on accepted running host
updates, then automatically drains matured requests through the pinned
selection and spawn-area planner. It skips replayed ticks and stages the
progress copy before its bounded request queue. A rejected issue retains the
oldest request; an accepted plan registers exactly one box.
`MatchManifest.PvpBonusMode` now accepts only
ordinary, War Arena or friendly DeathMatch from the trusted manifest, and an
issue rejects mismatched mode flags before selection. Existing manifests may
omit it; those matches do not auto-issue. The host derives live gold/ammo
selection inputs itself. Backend mode/analytics projection, a shootable box
and collection still await integration.
Other army-owned damage, AI death/combo flags, verified walking state parity,
card multiplier lifetimes, normal Backend crate allocation and effect delivery
remain open.
The Grenades prefab and recovered `KillStreakBonusGrenades` method specify a
three-shot burst, not grenade inventory refill. It waits one scaled second,
sorts living visible opposing `GameShootableEntity` components by distance
from the collected box, and fires at up to three within a strict three-unit
radius, with 0.2 scaled seconds between shots. Missing targets become random
box-centered X/Z offsets in [-1.5, 1.5]. The fallback grenade's source
damage rows are 50 to 872, scaled by recipient rank/43. The planner now
attaches the 43 bit-exact Unity-probed explosion and direct-damage pairs to
fallback shots; targeted shots retain the `GrenadeAmmoSetup` values already on
the shared `KillStreakManager` grenade component. `GrenadeAmmoBase.LoadAmmoSetup`
stores a reference to that setup and `GrenadeAmmo.CreateExplosionInfo` reads it
at explosion time. A previous or overlapping fallback burst can therefore
change even a targeted shot's final explosion damage. The host burst clock now
tracks the scene's initial 350/20 setup and applies fallback mutations in
shot order; its launch snapshot is not a final impact-damage decision. The
separate `CardGrenadesBurst` uses the same component. Its new source-order
planner randomly selects up to three opposing shootables, then draws distinct
unoccupied enemy shield points for missing targets. The card's three shots
wait 0.2 scaled seconds each; targeted shots retain the shared setup and
fallback shots replace it with the same rank-bound pair as bonus boxes. The
shared clock accepts both burst schedules and preserves card mutations for a
later box shot. The authenticated `UseGrenadesBurst` command now checks the
selected `CLUSTERGRENADE` inventory identity, plans from host shootables and
empty enemy shields, retains a request replay receipt, and dispatches each
due shot into the normal grenade flight/explosion path. A focused match now
confirms all three flights collide and explode, with opponent health loss.
Two signed UDP clients now confirm one card spend, safe request replay,
three matching shot/impact events, one live grenade pose in the SDK snapshot,
and the same opponent health after damage. The Unity projectile presenter now
copies the recovered KillStreak Manager grenade mesh without its gameplay or
Photon components, follows the host projectile pose, and plays a medium
explosion effect on the confirmed impact event. Rendered Play Mode parity is
still unverified. The current presenter and SDK DLLs compiled in a disposable
Unity 2018.3.0f2 project containing the Client scripts and Plugins; this was
a script compilation check without the full scene/assets or Play Mode. A
separate MainScene Editor audit checked the Manager grenade's copied mesh,
absence of collision/Photon/damage components, host position update, and
impact removal; the full grenade fixture passed 876 checks. The Editor audit
does not render a running match or capture the explosion effect.
The normal Unity `CardManager` sends this command and spends the card only
after an accepted host reply; the portable SDK DLLs were refreshed. The host uses
the `PlayerPoint` child shield's serialized `hudIndicator.snapTransform`
for the owner's fire origin. `recovered-card-grenade-origins.json` pins all
40 component chains and world coordinates to the five scene hashes; the snap
positions differ from the nearby `shotPosition` by about 0.168 units. Empty
shield targets use the cover transform. Unity projectile/visual parity and
Client projectile presentation still needs live comparison.
The checked-in bonus catalog now extracts the shared setup's 350/20 values
and its 45-degree throw, zero distance/fuse, 1.3/2.2 blast radii, and
behind-shield ratio 1 from MainScene. It pins the `GrenadeAmmoBase`, `GrenadeAmmo`, and
`CardGrenadesBurst` source digests. The host clock initializes from that
validated catalog instead of an independent constant.
Bonus projectiles now use host ballistic flight, a downward collision trace,
the shared projectile capacity, and ordered battle ticks. MainScene's
KillStreak Manager setup supplies a 45-degree throw angle and no distance
cap; the confirmed collection position is the launch origin. The host emits
shot and impact evidence. Its
collision trace now uses the exact eight Static/DestroyableObject layers
checked by `TagsAndLayers` and `GrenadeAmmoBase.OnCollisionEnter`, independent
of the shooter's bullet mask. A collision arms the source's zero-second fuse;
the next host tick records an immutable explosion quote using the *current*
shared setup, including changes made by intervening fallback launches. The
quote accepts only the source initial pair or one of the 43 reviewed fallback
pairs; card fallback shots use those same validated rows once their match
dispatch is connected. The match now applies
the quote to current player hitboxes through the recovered 0.7 player-radius
coefficient and normal health/Kevlar transition. The Manager Grenade's
`friendKill: 0` prevents damage to its owner and allies. An isolated
owner-collected box fixture hits an opposing player and preserves owner health.
The same host explosion now groups Decoy and Heavy Turret hitboxes by entity,
damages each enemy owner once, and excludes friendly owners before applying
damage. Separate card-deployment fixtures prove the bonus burst damages a
Decoy and a Heavy Turret through real host flights. Infantry and ground-vehicle
bodies now use shared Army vitality; a nonlethal Tank blast keeps its vehicle
registry in sync, and a lethal Assault blast records a direct player-grenade
kill in terminal evidence. Allied units are excluded by the Manager weapon's
`friendKill: 0`. Tank passengers and Transporter repair drones now use their
own host poses, hitboxes, and health pools in the same explosion; deployed-unit
fixtures exercise both without treating them as vehicle-body damage. Drone
and Helicopter bodies now use the same host air-collider grouping and
shared Army vitality as normal grenades, with deployed-unit blast fixtures.
The Assault Helicopter body and separate front glass now have successful
moving-flight fixtures: both use a ground-level collected box after the
aircraft descends into blast range, and the glass keeps its own health pool.
The same bonus blast now reaches the Helicopter's independently owned gunner
after player damage. A deployed flight fixture reduces gunner health, while a
same-faction blast leaves it unchanged under the Manager grenade's
`friendKill: 0`.
Host map overlaps now damage enemy shields and trigger source barrel
chains before character damage. The Manager scene weapon has no `PlayerWeapon`,
so shield damage uses the recovered explosion coefficient without an inventory
weapon ratio; `friendKill: 0` protects allied shields. A shield present in the
saved overlap set also supplies the recovered player-behind-shield multiplier.
Deployed map fixtures verify shield and barrel mutations. A host-confirmed
bonus blast on an opposing player now records `EnemyPlayerHit` through the
existing PvP score coordinator with a projectile/victim receipt. This follows
`SkillShotControllerPlayer.PlayerOnDamage`; the grenade's separate
`ReportShotHit(null)` does not itself identify a hit target. A deployed blast
fixture verifies both health loss and score credit.
Unity Rigidbody bounce against other layers and exact Unity Update ordering
still need parity review. The planner
draws random offsets only for fallback shots. The source passes the *local current player*
fraction to `GetOpponents`; the planner keeps that perspective explicit until
the self-hosted scene-owner callback is bound. The recovered C# displays a
null `killStreakBonusBox2` inside its sort comparator, but the original APK
assembly's iterator IL loads the captured `killStreakBonusBox` parameter in
both distance calculations. The planner follows the original IL. Equal-distance
ties retain host registry order as an explicit replacement choice; exact Mono
sort tie parity remains unverified. The normal live pickup route is still absent.
`MatchEngine.PlanCollectedPvpGrenades` now binds the plan to a host-confirmed
collected Grenades box, its collection position, recipient rank, and signed scene-master
view. It reads live player, army-root and Decoy targets from the existing
source-bucket host registry, plus separately deployed Heavy Turrets. The match
engine itself draws each fallback X/Z offset from its combat RNG; callers cannot
supply positions or offsets. It caches the first plan by box ID so replay cannot
consume more random draws or switch recipients. The planner only schedules
the burst; match ticks create projectiles and publish shot/impact events.
Other source shootable types, exact cross-registry tie order, and Unity PRNG
sequence parity still need verification before claiming complete target parity.
The source captures its target list at activation before the one-second wait;
normal collection dispatch must call the host planner at that same point.
The collection receipt can now carry a finite host-confirmed world position.
Grenade planning requires it and rejects a replay that changes it; using the
spawn-area position as the launch origin is no longer implicit. The host now
tracks vertical box position, but the lethal hit callback and Client-visible
collection are still absent, so runtime does not produce a confirmed pickup
position autonomously.
The host now schedules the planned shots on ordered scaled battle frames. At
30 host ticks per second, a normal-rate burst releases at frames 30, 36 and 42
after activation; a long frame still releases only one shot because each
`WaitForSeconds` starts after its preceding launch. Active bursts and flights
forbid skipped simulation ticks, and frame replay cannot emit a shot twice.
Normal collection dispatch, Rigidbody bounce parity, remaining non-player blast damage,
and score credit still need to be connected. The host currently supplies nominal tick
delta; the unfinished SlowMotion bonus must scale it before claiming slowed
coroutine parity.
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
collision marks the box on-ground/alive. The host currently approximates the
first static contact from a downward source-map probe; dynamic impacts, the
damage callback, and Client presentation still need simulation evidence.
No current SDK event or catalog test proves the full gameplay path.

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
explicit host safety bounds, not recovered production limits. Complete source
manager lifetime, capacity handoff, and previous-game state still require
binding before full live-crate parity.

Four `CardIncreaseBonusChance` MainScene cards now use this queue through an
authenticated `QueueBonusCardCommand`: HEALTHCRATE points to source prefab 1,
TURRETCRATE to 5, KEVLARCRATE to 6, and AMMOCRATE to 8. The Worker resolves
each exact prefab GUID against the reviewed bonus catalog, then prepares the
queue receipt before spending the selected Backend-provisioned card. A full
queue or rejected card leaves both stock and queue unchanged. A repeated
request returns its original result, while another player cannot take it over.
The normal Unity card button sends only the source card ID; it does not choose
the bonus index or invoke the recovered Photon gameplay method. A host test
proves that the next matured selection consumes the queued Health Crate, and
two real UDP clients prove command replay and ownership. This does not by
itself establish live score threshold, physical crate spawning, collection or
reward delivery for every mode.

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
draw and capacity checks. The signed-mode host now connects delayed issuance
to Client crate projection; dynamic contacts, collection, effects and Backend
rewards remain unbound.

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
collection, effects or economy. The signed-mode MatchEngine now publishes a
crate from this queue; normal Backend allocation does not yet project that
mode and the scene master's durable Gold analytics.

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
