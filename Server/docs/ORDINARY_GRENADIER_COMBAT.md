# Ordinary Grenadier host combat integration

Ordinary Grenadiers now enter the shared Corner navigation and attack lifecycle after their
admitted owner upgrades compose pistol damage, shot fields, grenade damage and special fuse.
Card actors retain card-interpolated stats; ordinary actors retain empty SourceCardId and never
enter CardUnitEntityRegistry or the card-only pose store.

## Recovered behavior

MainScene component 49788 uses enemyPointType 14, useSecondaryWeapon true and secondary probability
0.4. SoldierBehaviour.GetInitPoint calls SpawningManager.GetPoint with zero minimum distance.
The existing Grenadier point policy uses the same family mask for both variants. Its GREATGRENADIER
lookup key chooses point policy only; it does not assign a card identity to the ordinary actor.
The recovered multiplayer collections have no Vehicle point; available Corner/Hiding selection
remains source-backed rather than inventing a destination on maps without points.

Both variants use shared point occupancy, source route planning, actor-specific movement speed,
five-second missing-point retries and Corner-change clocks. Ordinary movement updates the active
army roster directly. Card movement additionally updates its separate card pose store.
Attack construction reads the already composed shot row. Primary launches use the ordinary
pistol damage, while secondary launches freeze ordinary grenade damage/fuse into the flight.
The shared inventory lifecycle retains selection and schedules independent fifteen-tick returns.

The flight now accepts a finite source fuse from zero through three seconds rather than requiring
the card-only three-second constant. Card composition still supplies three seconds. Ordinary
special composition supplies the recovered reduced fuse; invalid bounds remain rejected.
Confirmed ordinary death cancels movement/attack/retry/weapon-return state and releases the shared
Corner reservation. Already launched grenade authority remains frozen independently of its actor.

## Verification boundary

The ordinary deployment fixture drives normal allocation, selection, readiness and DeployArmy.
Three Park tuples cover normal zero, normal 39 plus special 101, and normal 39 plus special 126
and Elite 127. Their actors walk to a real Corner and create real secondary grenade flights.
The test checks source identity, composed authority, route ownership, actual movement, launch and
actor removal/point release. A Snow fixture verifies missing-point retries without invented motion.
The host-integration checkpoint passed 62 focused checks. At that checkpoint, the complete default
Windows Battle executable passed 247,825 assertions with exit code zero, including real two-peer UDP;
its count varies with live polling. The native half-second return fixture verifier also passes.
These are host tests, not rendered Unity matches or a physical ordinary-victim damage proof.

## Remaining integration

Ordinary weapon-mask projection is now connected through host, protobuf/SDK and retained Unity
weapon sets. The latest focused group passes 73 checks, including decoded secondary state and
fifteen-tick primary return for all three ordinary deployment tuples. Disposable Unity passes
530 ordinary inventory checks, including both initial secondary visibility and later decoded
primary/secondary updates. These component checks do not execute two normal Unity matches.

[Ordinary pistol outcome fixtures](ORDINARY_GRENADIER_PRIMARY_DAMAGE.md) now cover one upgraded
physical player hit and one covered basic-unit shield-only control.
[Ordinary grenade explosion fixtures](ORDINARY_GRENADIER_EXPLOSIONS.md) now verify real shield
damage/destruction and host contact/fuse timing.
[Native fuse evidence](GRENADIER_FUSE_CLOCK.md) now binds source float countdown and recontact resets. [Physical player blast fixtures](GRENADIER_PLAYER_BLAST.md) now cover three ordinary upgrade tuples.
Ordinary sickness, broader player blast scenarios, complete source attack animation/effects, all Corner-change
scenarios and normal two-Unity-client gameplay validation remain open. The shared lifecycle does
not establish original Unity timing or cross-platform runtime parity by itself.
