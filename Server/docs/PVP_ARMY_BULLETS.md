# PvP army bullet ownership

This seventh S07 increment moves real/cosmetic army bullet membership and launch metadata into
Match/Projectiles/PvpArmyBulletSystem. The engine's separate armyProjectiles and
armyProjectileAuthority dictionaries and nested authority record are removed. One private entry
contains the flight and its immutable PvpArmyBulletPayload; a flight cannot be published through
this owner separately from its launch metadata.

| Type | Responsibility |
| --- | --- |
| PvpArmyBulletSystem | Private flight/metadata entries, captured advancement, completion, detached snapshots and clear |
| PvpArmyBulletPayload | Firing entity, player/fraction, damage, poison, unit/card, cosmetic flag and optional player damage policy |
| PvpArmyBulletStep | Value observation of one flight's payload/impact or invalid flight authority |

Entry, frame cursor and step are value types. The private entry does not introduce a wrapper heap
object per launched bullet. The existing immutable authority object remains, now with descriptive
initializers instead of eight positional constructor arguments. Captured arrays remain; reducing
dictionary duplication and removing lookup work does not establish a measured throughput gain.

## Boundaries retained

Source factories and muzzle/target selection remain in the existing Assaulter, Gunslinger,
Grenadier-primary and general army launch adapters. They still own shared IDs, capacity/event
preflight, random draws, source player policy and publication order. The complete payload is
constructed before the paired entry is inserted; a metadata-construction failure cannot leave an
unpaired flight in a second dictionary. This removes an internal representable orphan state,
not evidence of a previously observed live-player incident.

BulletSlow, BulletBase and BulletShotGun were inspected. Slow preflight/continuation, cached fast
shotgun collisions, movement prediction and doubled-distance cosmetic tween algorithms remain
unchanged in ArmyProjectileFlight. Cosmetic trails perform no collision queries. Source-derived
flight math is still separate from the collection owner.

The owner captures insertion order, then advances one flight before returning control to the
engine. A launch-tick or repeated-tick call retains ArmyProjectileFlight's existing no-op behavior.
A completed flight and its metadata leave storage together before world impact observation.
InvalidDataException from flight advancement retains invalid-army-projectile-authority and stops
later entries. Other exception types retain their original propagation. Cosmetic-impact rejection,
owner/fraction checks, impact events, barrel/entity/bonus/shield/player damage, poison creation,
revenge credit and terminal decisions remain at their existing engine call sites and in their
existing order. A terminal impact can abandon the cursor before another flight advances.

Already-launched bullets survive firing-soldier removal under the existing server contract. Their
launch-bound damage and ownership do not depend on a later active entity lookup. Existing revenge
credit still requires a live soldier. Terminal cleanup clears entries at the original flight-clear
point. Flame bursts, poison ledgers, rockets, mortar/grenadier flights and world-impact orchestration
retain separate S07 work; this owner does not clear or reinterpret those systems.

Snapshots remain ID-sorted at the same family position, with army-bullet/army-fake-bullet kind,
owner, unit/card, Commando poison identity, position, velocity and the prior empty WeaponSourceId.
Returned protobuf rows are detached. Existing launch/source/speed diagnostics return immutable
metadata or scalar observations, never stored mutable flights.

## Before/after proof

Before production edits, two identical captures of the original engine produced nine frozen
source-bound traces with 5,625 observations. They cover real/cosmetic Assaulter and Gunslinger,
Shotgunner real/fake groups, upgraded Commando identity, firing-soldier death with a live bullet,
terminal cleanup and card Grenadier primary fire. They retain complete framed snapshot/reply/
terminal-event bytes and exact clock bits. Deployment replay and source launch diagnostics are
checked alongside those observations. The temporary capture switch was removed; ordinary tests
cannot regenerate expected hashes. Provenance hashes are historical capture inputs, not current
source pins after intentional extraction/formatting.

Eight owner/order groups add paired metadata queries, detached sorted projections, completion/removal
with one impact observed at a time, insertion capture boundaries, duplicate/non-contiguous ticks, unchanged
exception classification, cosmetic lifetime without collision queries, clear/isolation and compiled
ownership/value-type checks. Normal Unity/Android gameplay, source-provenance V07 and comparative
performance retain separate verification gates.

## Focused testing

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-army-bullets --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case assaulter-volley --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case gunslinger-shooting --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenadier-primary --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case shotgunner-udp --no-build
```

The first four cases need no Mongo instance, socket, Unity project or Library copy. The existing
shotgunner-udp gate uses actual peers and immutable projectile scans; full runtime integration also
covers it. All managed cases own logs/temp and use the existing bounded retention policy.

Initial state checkpoint-4ec442e2ddca40098937b14327b28f45 passed nine traces/eight groups in 5.5 seconds.
Existing source selectors passed 112 Assaulter volley checks in 5.0 seconds
(checkpoint-c0c1d6e271f545c8a9c32df25cf04b59), 29 Gunslinger checks in 4.0 seconds
(checkpoint-02a73ded79324930bf33f5991a1e8817) and 23 Grenadier damage checks in 3.9 seconds
(checkpoint-a5754cf863964468a60a87aaa6f7d63b). These precede the final private-entry value-type
adjustment; final integrated verification must cover that code too.

checkpoint-0682a3d95985426da33798152683ea7a was deliberately stopped during its full battle stage
when the private entry was changed to avoid a new per-flight wrapper allocation. Its first 35 stages
passed; the stopped stage is not a combat assertion failure or a final passing checkpoint. Its
bounded failure diagnostics are retained. Final Debug and Release builds pass without warnings/errors.

## Final integrated result

checkpoint-8ffd2a3818854311b0b51eec1385b9c9 passed all 37 runtime/native stages on the final value-entry
code. The army state stage passed nine unchanged traces/eight groups in 5.0 seconds; Release also
passed these and all prior connection/weapon/movement/player-bullet/bazooka/grenade fixtures. Five
new C# files pass LF/width/whitespace checks. All five inspected Client/flight/binding evidence hashes
remain unchanged. No Client code, scene, library or content artifact was edited.

The full battle stage reported 267,862 engine/admission/portable-SDK/map/two-peer UDP assertions in
599.7 seconds, including the existing source volley/shooting/damage and real Shotgunner scan gates.
Native smoke-0979a6e52a2b4f06bbe33d23c4ec51ae passed in 37.3 seconds with 74 live integration checks,
reclaiming 210,864,232 bytes after owned shutdown. These correctness timings are not a performance
comparison. The superseded run above is excluded from the passing result.

Root .local remains 80,842 bytes. Server/.local now measures 2,624,416,528 bytes/34,638 files, down
211,036,874 bytes after marker-based retention applied to its older managed runs. Unowned history
was preserved. Managed LOCALAPPDATA storage is 553,013 bytes/186 files, including bounded stopped-run
diagnostics. No managed run or test Backend/Worker/battle process remains active; original Mongo
service PID 6164 is preserved. Broader S07-S09, C03/C12/C13/C18, performance, remaining test producers/
Unity leases, V07 and actual Unity/Android gameplay retain separate completion gates.
