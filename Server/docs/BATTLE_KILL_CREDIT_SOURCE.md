# Recovered 1.4.0 kill and vehicle-destruction statistics

This is the source boundary for B24. The active Client code is under `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp`. `StatsManager.RecomputeStatistics` assigns `MatchStats.kills` and `vehicleDestroyed` from the local `ScoreManager.skillShotCounts` entries for `SkillShotType.Kill` and `VehicleDestroyed` (`StatsManager.cs:1357-1363`). `ScoreManager.AddSkillshot` increments the local dictionary only for `playerController.isCurrentPlayer` (`ScoreManager.cs:255-276`). `SkillShotManager.AddSkillshot` expands a skill-shot bitmask through its configured item definitions before calling that method (`SkillShotManager.cs:148-155`).

`SkillShotController.GameEntityOnKilled` returns for network-copy damage. Its direct-player branch requires `info.owner as PlayerController` and awards the skill shot only if the attacker and killed entity have opposing fractions (`SkillShotController.cs:24-143`). Within that branch, an `EnemyController` kill sets `Kill`; `Drone` and `Tank` set both `Kill` and `VehicleDestroyed` (Tank also sets `TankDestroyed`); `AICar`, `AICarBuggy`, `AICarTransporter`, `Helicopter`, `AssaultHelicopter`, and `Mech` set both. The source also sets optional headshot, explosive, environmental, revenge and other bits, whose separate definitions still need audit. A friendly kill does not reach `AddSkillshot`.

The same controller's `info.owner is IGameMainEntity` branch awards `ArmyKill`, not `Kill` or `VehicleDestroyed`. Its no-owner environmental branch may award `Kill | EnviromentalKill` for an opposing entity under `Basic` or `Explosion` damage, without `VehicleDestroyed`; this path needs its own attribution rule and cannot be inferred from ordinary opponent-owned projectile or unit death. `SkillShotControllerPlayer.PlayerOnDamage` awards `EnemyPlayerHit` on qualifying player-owned hits and `ArmyPlayerHit` on qualifying AI-owned hits; it does not set `Kill` or `VehicleDestroyed` (`SkillShotControllerPlayer.cs:22-67`). Consequently, killing the opposing **player** is not evidence for Client `MatchStats.kills`.

The Worker currently records `confirmed_player_kills` for terminal opposing-player deaths and records each spawned army entity's loss. `ConfirmArmyDeath` knows the victim and an energy recipient but discards the actual `DamageInfo.owner` category and network-copy proof; it also handles deaths from army attacks, land mines, explosions and suicide. `TryDestroyVehicle` emits a removal event but does not prove a direct local-player kill. None of those broad counters or events can be relabeled as the two Client statistics. Future durable evidence needs the exact victim family, direct player/army/environment damage provenance, opposing faction, non-network authority and one terminal generation per death; only then can an atomic statistics receipt consume it. Backend rewards stay closed until that proof and policy exist.

The Worker retains a narrow `direct_army_kills` terminal-only ledger when a player-owned bullet flight hits a source-backed opposing destroyable collider and its host damage transition removes that exact active army entity. Each row carries the entity key, recovered unit ID, victim and attacker player IDs, `player-bullet` cause and host tick. The normal UDP snapshot omits these rows. Terminal validation requires a bounded, unique, ordered entity set, source-known unit identity, roster ownership, per-unit kill counts no higher than the victim's confirmed spawns, and conservation against the victim's army losses and attacker's confirmed bullet contacts. `BattleResultStore.GetDirectArmyKillEvidence` revalidates the durable payload before returning rows. A live Drone Fire-to-death test verifies one attributed row and rejects forged cause, duplicate identity, or an extra Drone death concealed by a different unit's spawn. This direct-bullet slice is not a settlement-ready `MatchStats.kills` or `vehicleDestroyed` value.

`BattleDirectKillStatsProjection` classifies that validated direct-bullet slice into per-attacker `Kill`, `VehicleDestroyed`, and Tank-specific candidate counts. Its explicit 16-soldier/eight-vehicle identity partition must cover all 24 recovered unit families; tests compare every family against the pinned deployment catalog's `isSoldier` field. The result store exposes these read-only counts. They are deliberately named direct-bullet counts because the Client also credits explosion and ownerless environmental kills, and attached entity behavior still needs proof. No Backend statistics or achievement consumer may treat this subset as complete match totals.

The recovered `GrenadeAmmo` calls `Explosion.MissileExplode`, which groups `DestroyableObjectpart` colliders by owner and selects the nearest collider before calling `Explode`/`Shiver` with the player weapon owner. The Worker grenade path applies that nearest-collider dead/hurt-radius calculation to deployed infantry, four ground vehicle bodies, the Drone's destroyable root, and Helicopter and Assault Helicopter bodies of both factions, including the recovered 0.5 friendly-damage coefficient. The Assault Helicopter uses its source body box and five assigned body meshes for sphere splash; its front glass remains a separate owner. Mesh-versus-box contact is the narrower unresolved mine-trigger case. The Drone child sphere and Helicopter gunner are separate targets and cannot duplicate body damage. It damages each shared vehicle body once without applying the part's shot weight, synchronizes nonlethal ground-vehicle registry health, and records `player-grenade` only when an opposing entity dies. Controlled host blast tests verify infantry, Tank, Drone, Helicopter and Assault Helicopter damage, friendly damage, removal, and the private terminal cause; read-only `DirectGrenadeKills`, `DirectGrenadeVehiclesDestroyed`, and `DirectGrenadeTanksDestroyed` keep this slice separate from bullet counts. Mech bodies, attached gunners/passengers, and normal throws against other army targets remain open; these counts are not complete Client `MatchStats` values.

A normal M320 throw at the recovered Helicopter gunner now has a live host and two-peer UDP regression: the gunner is damaged and the Helicopter body loses exactly the 133.25 stage-zero explosion damage once, with both peers observing the same body health. This proves one normal projectile-to-air-body path and shared-owner deduplication. It does not prove a lethal body hit, all grenade weapon families, other army targets, or Client `MatchStats` parity.

`CardLandmine.UseCard` fires `playerOld.weaponInventory.landMine`; `MineAmmo.Explode` passes `weapon.owner` into `Explosion.MissileExplode`. A non-network opposing death with that `PlayerController` owner reaches the direct-player branch of `SkillShotController.GameEntityOnKilled`, which awards `Kill` and, for a recovered vehicle family, `VehicleDestroyed`. The Worker now retains `player-mine` terminal rows for opposing army entities removed by a mine's own blast, after any barrel-chain effects. `BattleDirectKillStatsProjection` exposes separate read-only `DirectMineKills`, `DirectMineVehiclesDestroyed`, and `DirectMineTanksDestroyed` candidates; it does not mix them into bullet or grenade counts. Terminal validation permits only the 16 implemented infantry families and seven implemented vehicle families for this cause. Mech mine-blast authority and attached gunner deaths remain absent. A lethal normal-tick Helicopter mine proves the owner, unit, cause, terminal validation, and one mine vehicle candidate. These candidates are not yet a complete `MatchStats` settlement because other death paths and live Unity callback parity remain open.

The recovered `Missile.TryKill` supplies its `owner` and weapon to the same `Explosion.MissileExplode` path. A player-owned Bazooka missile therefore reaches the direct-player skill-shot branch for an opposing entity death. The Worker now snapshots live army entities after barrel chains and records only enemy entities removed by that Bazooka blast as `player-bazooka`. A normal host Bazooka hold, flight and impact kills a low-health Helicopter, and validated terminal evidence projects one read-only `DirectBazookaKills` and `DirectBazookaVehiclesDestroyed` candidate without changing bullet, grenade or mine counts. The validator limits Bazooka victims to the 16 implemented infantry and seven implemented vehicle families; Mech remains closed. Attached gunner death and complete source `MatchStats` settlement remain open.

# Confirmed player-owned kill scoring

For a confirmed player-bullet army death, the host records the source base Kill flag, VehicleDestroyed for a non-soldier family, and TankDestroyed for the Tank family in match-local PvP score and streak authority. The normal peer snapshot omits private skill-shot counts; the signed terminal result includes them. A live Drone death checks one Kill and VehicleDestroyed row and the source score of 40 points. Tests compare all 24 family classifications against the deployment catalog.

`DestroyableObject.DoDamage` marks `isOneHit` when its root had full health
before one lethal damage callback. Confirmed player bullet, grenade, mine, and
Bazooka army deaths now add `OneHitKill` from the host's prior root health.
Damaged roots do not receive it; a live collected-grenade burst now kills one
full-health and three previously weakened infantry, awarding one one-hit row.
Sabotage retains its explicit source `isOneHit` assertion. A live player rifle
headshot against a host-authored low-health infantry also confirms one lethal
bullet contact, one `OneHitKill`, and the private terminal count.

A separate live host mine now destroys one full-health Helicopter with its
first blast. The match records `OneHitKill` and `ExplosiveKill`, never
`HeadShot`, and preserves the mine victim and one-hit count in private terminal
evidence. This uses host mine placement; the normal Client card-to-mine
command path remains a separate integration boundary. A normal player
Bazooka hold and missile flight also destroy a low-maximum-health Helicopter
from full root health in one blast. `OneHitKill` and `ExplosiveKill` reach match
score and private terminal evidence, while `HeadShot` stays absent.

`EnemyController` marks `isHeadShot` only when a `Shot` death arrived through
`DestroyableObjectpart` index one. The pinned infantry pose distinguishes that
head sphere from the body by its source path and 1.5 damage weight. Confirmed
player-bullet deaths now add `HeadShot` only for that trusted head collider;
body hits and explosion deaths do not. A real animated-infantry collision test
proves the head/body distinction. A live player `Fire` sequence also kills one
deployed infantry through head contact, scores one `HeadShot`, and retains that
count only in private terminal evidence. Other weapons and attached victims
remain outside this proof.

Confirmed player-owned mine, Bazooka, and grenade blasts add the source ExplosiveKill flag to those
same base flags. The blast death recorder stages every combo/score transition before publishing its
direct-kill batch. Normal M320 and collected bonus grenades compare ordered `ArmyDied` events and
removed army entities with their direct-kill rows, then stage the shared combo and enemy score; a
confirmed friendly death advances combo without awarding points. A score-capacity failure aborts the
match instead of partially scoring a blast. Real Helicopter mine/Bazooka deaths check Kill,
VehicleDestroyed, ExplosiveKill, 44 source points, and private terminal counts. A normal M320 Tank
death checks the Tank-specific flag and 104 points; a live collected-grenade burst kills four
infantry and earns one DoubleKill, one TripleKill, and one MultiKill while conserving private
direct-kill evidence. The source combo flags are applied when its host-time window is met. Headshot,
other contextual flags, revenge, environmental flags, exact scaled time, and full
cross-cause callback order remain open. These counts remain incomplete for Client MatchStats and
Backend settlement.

For a walking Rusher infantry death caused by a player bullet or player-owned
grenade, mine, or Bazooka blast, the host also derives `Runner` from its
published pre-death displacement and configured speed. The Client requires
`EnemyAIState.Walk` and velocity squared above 90% of agent speed squared.
Blocked and slow walkers do not qualify; a live moving Shotgunner bullet death
retains one private `Runner` count. Blast scoring captures this movement proof
before entity removal and checks the death-event identity. A live moving
Shotgunner mine death also retains one private count. Other infantry movement
modes remain open.

The recovered player damage callback marks the exact `MainGameEntity` that
damaged the local player for five scaled seconds. A player-owned kill of that
entity within the window adds `RevengeKill`. The host now binds a confirmed
army projectile hit to its live entity and damaged player, then checks that
window before removing a player-bullet victim. Player-owned grenade, mine,
and Bazooka blasts capture the same victim marker before removal and check
their death-event identities. Live Shotgunner hits followed by that player's
bullet or mine kill each verify one private revenge count; an unmarked bullet
kill verifies zero. Source `Burn` and `Poison` damage retain the weapon's
army-entity owner; the host refreshes its revenge marker only while that
entity is live. A Flamethrower hit followed by that player's mine kill now
verifies one revenge score and private terminal count. A Commando fixture
isolates a poison pulse with no concurrent bullet hit, observes its revenge
deadline advance, then verifies the same player's mine kill and private count.
Tank and Buggy cannon targeting now follows the source's disabled primary
visibility requirement. Their missile impacts retain the source vehicle ID
and mark it after confirmed damage to an opposing player, only while that
vehicle is still live. Tank and Buggy cannon prefab components 11492654 and
11461370 both serialize `playerShieldProbability: 1`; the host now chooses a
posed shield or moving target when each weapon fires. The Tank holds its
launch target for the straight missile flight. The shield advances before
vehicle projectile damage, so a Tank shield impact no longer aborts on a
stale tick. Park matches verify live Tank and Buggy missile hits, mine kills
of those same vehicles, and one private `RevengeKill` count each. Tank and
Buggy now check `TurretSeesEnemy` at launch from their serialized spawn-point
fallback to the first ordered source target, reusing the verified static and
destroyable visibility ray. Live grenade/Bazooka revenge remains open. In
`GrenadeCombatMode`, the host constructs `GrenadeMatchSimulation` without
`RifleMatchSimulation`, but its deployed-army flame, bullet, and vehicle
player-damage paths still require `rifleCombat`. An exploratory live
Flamethrower fixture produced no player hit through tick 1500 in that mode,
although its rifle-mode counterpart does. Shared army collision and player
damage must work across weapon modes before a grenade revenge fixture can
exercise the complete source callback chain.

Sabotage is a distinct player-owned card shot. The recovered card supplies the selected mechanical root's maximum health as Shot damage, sets `isOneHit`, and keeps the player as damage owner. The host prepares the source `Kill | OneHitKill | VehicleDestroyed` flags, plus `TankDestroyed` for a Tank, before spending the selected card. It publishes that prepared combo and score only when the host confirms the selected opposing entity's death and writes the `card-sabotage` row. A real card Drone death checks 46 source points, one of each base flag, replay-safe card use, and private terminal counts. Other cards, barrel-chain deaths, ownerless environmental deaths, and AI-owned deaths remain outside this score path; contextual flags remain open.
