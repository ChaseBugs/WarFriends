# PvP player bazooka ownership and shared resource budget

This fifth S07 increment gives active player missiles, delayed secondary launches and the global
curve-sign sequence one owner: Match/Projectiles/PvpPlayerBazookaSystem. Engine adapters retain
admission, weapon/owner validation, source muzzle/collision factories, shared IDs, shot events,
explosion application and terminal/revision publication. Ordinary grenades, army/vehicle/air
projectiles and the remaining impact/frame orchestration retain their own S07 work.

## Owners and immutable observations

| Type | Responsibility |
| --- | --- |
| PvpPlayerBazookaSystem | Private active/scheduled collections, curve sequence, due/active frame capture, completion, snapshots and clear |
| PvpBazookaLaunch | Owner, target, due tick and launch-bound shot selection |
| PvpBazookaShot / PvpBazookaShotKind | Source identity/upgrade, half-damage flag and explicit primary-real/secondary-real/secondary-fake identity |
| PvpBazookaPayload | Immutable stage, binding, source and half-damage metadata for explosion processing |
| PvpBazookaStep | Value observation of a flight result or invalid authority, without a mutable flight handle |

The engine's active dictionary, delayed list, curve counter and nested projectile/launch types are
removed rather than duplicated behind adapters. Launch construction groups its settings instead of
passing the former eight positional fields. Payload/shot/step and frame cursors are value types;
there is no separate heap object per flight observation. Existing captured-array processing remains.
This is an ownership/allocation-structure description, not a measured throughput improvement.

## Source rules and order retained

Bazooka, BazookaFangs and Missile were inspected. BazookaFangs immediately launches its real primary,
then schedules fake, real, fake secondary shots at the binding's recovered 0.1-second intervals.
The original float multiplication, ceiling-to-tick conversion, primary/secondary muzzle choice,
half-damage selection, two random trajectory draws and alternating curve signs retain their order.
Missile's curved/straight progress, collision clearance and expiry algorithm was not changed.

Due launches are captured in existing list order and removed immediately before the engine's trusted
launch callback. A failed launch therefore keeps the original consume-before-failure boundary.
Weapon selection remains locked only while that owner has delayed launches; already-flying missiles
retain their launch-bound source metadata after the queue becomes empty.

Active flights are captured in insertion order. A flight created in the current tick is skipped;
the next frame advances it exactly once. Completed flights leave storage before the engine emits
their impact and applies its world effects. A terminal real hit stops later flights. Fake impacts
retain their reliable event/presentation identity and skip explosion damage. InvalidDataException
and InvalidOperationException preserve the family's existing invalid-projectile-authority outcome.

Snapshot rows remain sorted by ID at the same position among projectile families, with the same
bazooka/bazooka-fake kind, source identity, position and velocity. Returned protobuf rows are detached
from live flights. Cleanup clears active then scheduled state and retains curve history, matching
the former engine cleanup. No Client code, scene, library or content artifact was edited.

## C30: active missiles missing from the shared budget

The old PendingProjectileCount counted scheduledBazookas but omitted bazookaProjectiles. A source-bound
RPG could therefore appear in the live projectile snapshot while contributing zero to the engine's
shared capacity check. M202 initially counted its three pending launches but omitted its active
primary; consuming a later launch removed another reservation without counting its replacement
flight. The existing self-hosted limit is 128 across projectile families, not 128 plus live missiles.
This limit is server resource policy, not a recovered Client balancing rule.

The new owner's Count is exactly active plus scheduled. The engine includes that count once in the
shared budget, preserving reservations as a delayed launch becomes active and releasing capacity
only when a missile finishes or is cleared. The existing whole-volley preflight still refuses a
launch before ammo, shot counters, IDs or events are consumed.

The original source-bound regression failed in checkpoint-e284aa5ab06d46a9a6869768d5aa8bfe before
production edits. Three final groups check the live RPG, M202's primary/delayed transition and actual
second-player hold/fire refusal at a full shared budget with unchanged ammunition. The last case
uses controlled host flights for the other 127 occupants; it is a deterministic resource fixture,
not a claim that such a load was observed in normal gameplay. Network callers cannot install those
host fixtures. No prior live-player capacity incident is inferred from the reproduced code defect.

## Before/after proof and focused testing

Before production edits, captured the original engine twice with identical output. Six frozen
source-bound scenarios contain 914 complete observations: RPG flight/impact and replay, M202's
delays and selection lock, cancelled hold, reconnect pause with an active missile, terminal cleanup
and two-owner M202 ordering/curves. Full framed protobuf snapshots/replies/terminal events and exact
clock bits still match after extraction and C30 correction. The private budget is absent from those
wire hashes; C30's intentional behavior change has separate red/green regression proof. Normal
tests cannot regenerate expected hashes; the temporary capture switch was removed.

Six owner/order groups additionally cover due deadlines and reservation transfer, captured flight
order/removal, launch-tick skip, invalid-frame stop, detached projection, retained curve history,
match isolation and compiled ownership/value types. Existing connection, weapon, movement and
player-bullet fixtures remain unchanged in Debug and Release. These source-bound engine fixtures
do not establish normal Unity scene/Android gameplay or full source-provenance V07 completion.

```powershell
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-bazookas --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-bazooka-capacity --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case bazooka-combat --no-build
```

The first two focused cases run source-bound simulation without Mongo, sockets, Unity projects or
Library copies. The bazooka-combat case exposes the existing source catalog/presentation/real-UDP
selector through managed logs/temp; checkpoint-704798df66dd4a98947ff030d8fd38e7 passed 218 assertions
in 10.6 seconds, including five live UDP checks. Combined state/budget
checkpoint-11c8c9331aee4107a3202d7dd079cb46 passed six traces, six owner groups and three capacity groups in
2.9 seconds. Full runtime/native integration remains required for this simulation increment.

## Verified result

Debug and Release builds pass without warnings/errors. Both configurations pass the six traces,
six owner/order groups, three capacity groups and all prior connection/weapon/movement/bullet
fixtures. Ten new C# files pass LF/width/whitespace checks; all three Client evidence hashes, the
original missile algorithm hash and the bazooka manifest hash are unchanged.

checkpoint-bc43740813374b63b59253dc9c53c071 passed all 35 runtime/native stages. The full battle stage
reported 267,796 engine/admission/portable-SDK/map/two-peer UDP assertions in 612.0 seconds. Native
smoke-318bc217fcdd4be19abbaf0ab41cf123 passed in 36.2 seconds with 74 live Mongo/HTTP/protobuf/UDP
checks and reclaimed 210,867,695 bytes after owned shutdown. C30 is complete at the stated shared
budget scope; no measured throughput improvement or normal Unity gameplay certification is inferred.

Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed LOCALAPPDATA
storage contains 949,377 bytes/134 files after retention. No managed run or test Backend/Worker/battle
process remains active; the original Mongo service is preserved. Broader S07 ownership, C13/V02
source review, performance measurements, V07 provenance and actual Unity/Android retain separate gates.
