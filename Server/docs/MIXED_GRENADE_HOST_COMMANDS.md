# Mixed starter grenade host command checkpoint

The mixed host now constructs grenade simulation alongside rifle simulation
when its pinned grenade package is configured. The normal starter manifest
still begins with its source primary rifle. Switching to the owned FRAG slot
activates grenade state at the host's current cover and suspends the old rifle
first-shot, burst, minigun, sniper and bazooka state. Returning to a rifle-family
slot refreshes that source pose and deactivates grenade state.

Rifle simulation routes collision and snapshots through the active grenade view
while its owner is outside the rifle class. Inactive rifle actors retain current
host location but do not advance animation or scheduled firing. Grenade poses
advance before rifle fire callbacks, so a rifle shot can query the grenade
player's current frame. Target-position consumers use BodyTargetPosition and do
not request rotations missing from the grenade exports.

Generic Fire cannot fire a stale rifle from a grenade slot, and GrenadeThrow
requires an active grenade slot. The existing per-slot inventory owns ammunition
and cadence. A grenade launch captures its own source binding and stage;
collision queries continue to use every player's active class after the thrower
returns to rifle. Explosion resolution reads the same current collision view.

## Verified native scope

`--mixed-grenade-host-only` starts an actual MatchEngine from the source starter
presentation and four-slot manifest. Thirteen checks cover readiness, a queued
rifle uncover shot, FRAG activation and snapshot, wrong generic-fire rejection,
the source swipe windup, a rejected early switch, exactly one grenade launch and
ammo debit, an airborne return to rifle, unchanged rifle ammo, resumed rifle
fire, and completed grenade flight without aborting. The release counter proves
that the earlier queued rifle shot did not leak into the grenade phase.

The checks also run in --grenade-only and the default native suite. The focused
rifle engine and mixed allocator checks pass. No real Unity or mixed UDP peer
test is claimed by this native engine checkpoint.

## Remaining boundaries

This is the source starter's rifle-to-FRAG command path, not every weapon/flavor,
army interaction, effect, mode or production outcome. Normal durable allocation,
card/Buddy selection and consumption, army modifier projection and normal Unity
battle entry remain open. The source primary slot must still be a supported
non-grenade weapon; arbitrary mixed manifests beginning with a grenade are not
supported by the rifle constructor.

Grenade common views intentionally lack uncaptured moving-target and complete
weapon-root transforms. A delayed rifle bullet that kills an army unit while
the owner holds a grenade can reach the existing PvP skill-shot WeaponRoot
query. Its required root is not in the current grenade export; this remains a
source-data/integration requirement and must not be replaced by a fabricated
rotation, static point or launch-time position. Additional mixed-class damage,
status effects, movement, snapshots, UDP and rendered Client parity need their
own evidence before the overall gameplay feature can be closed.

The Release solution builds with zero warnings/errors. The focused host path
passes 13 checks; rifle regression passes 2,435 checks; mixed allocator checks
also pass. The full native executable completes successfully with 205,658
assertions across battle admission, SDK, geometry and two-peer UDP coverage.
That full result includes pre-existing diagnostic comparisons and does not
prove all listed gameplay parity requirements or a normal Unity match.
