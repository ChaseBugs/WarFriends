# PvP player bullet ownership

This fourth S07 increment gives player-owned real bullets and cosmetic shotgun pellets a cohesive
state owner: Match/Projectiles/PvpPlayerBulletSystem. It owns membership, captured-frame advancement,
completion/removal, detached observations and terminal cleanup. The engine retains whole-volley
validation, shared projectile IDs/capacity, accepted-shot authority and world impact application.
Other projectile families and the broader S07 impact/collision/frame split remain open.

## Boundaries

| Owner | Responsibility |
| --- | --- |
| PvpPlayerBulletSystem | Private real/cosmetic dictionaries, frame capture, ordered advancement, completed-flight removal, sorted detached snapshots and clear |
| PvpBulletStep | Immutable value observation: ID, damage/source metadata, optional impact and invalid-authority outcome; no mutable flight handle |
| PvpPlayerBulletSystem.RealFrame | One captured insertion-order frame, consumed one step at a time without a reference object per step |
| MatchEngine shot adapter | Complete volley validation, ammo/counters, shared identity consumption and shot events at their existing locations |
| MatchEngine impact adapter | Impact events, bonus/shield/barrel/dynamic/player routing, conserved statistics, failure reasons and terminal decisions |
| Existing BulletFlight/ShotgunFakePelletFlight | Recovered flight timing, collision geometry and cosmetic motion algorithms |

The engine's two player-flight dictionaries are removed rather than mirrored behind an interface.
No dictionary or mutable stored flight is returned. Prepared flights enter only through the existing
trusted host factory after complete admission validation; packets cannot install them. Snapshot
protobufs are newly constructed observations, so a caller editing one cannot change live motion.

Shared ID allocation and the 128-projectile cross-family budget remain engine-owned. Real and fake
launches retain their existing order and event positions. This component does not add a second ID
counter, a separate capacity allowance, a service locator or an event bus.

## Preserved advancement and failure order

1. Capture real dictionary entries in their existing insertion order. Sorting this frame would alter
   which same-tick hit becomes terminal. Newly inserted flights wait for the next captured frame.
2. Advance one real flight at a time. On successful completion, remove it before returning its impact
   observation to the engine, matching the previous engine loop.
3. Apply that one observation's existing world side effects before advancing the next real flight.
   A lethal first pellet therefore stops later real and cosmetic flight advancement. Do not prepare
   all flight impacts in a batch before applying them.
4. An InvalidDataException from real flight advancement returns an explicit invalid-authority step
   and stops that captured frame. The engine retains invalid-projectile-authority termination.
   Existing InvalidOperationException/ArgumentOutOfRangeException clock contracts still propagate;
   they are not silently reclassified as collision corruption.
5. Only after real flight processing finishes without a terminal decision, advance cosmetic pellets
   at their existing later frame point. InvalidDataException preserves the same failure reason.
   Cosmetic motion exposes neither a hit callback nor damage authority.
6. Terminal cleanup clears real then cosmetic membership at their original cleanup position. Impact
   statistics, remaining projectile families, clocks, events and revisions keep their existing owners.

The frame and step are value types. The implementation retains the previous dictionary-entry
snapshot array and does not add a boxed enumerator, per-flight step object or per-frame delegate.
This describes allocation structure, not a measured throughput/GC improvement; P01 still owns
representative profiling before optimization.

## Recovered Client evidence

Ammo, BulletBase, BulletSlow and BulletShotGun were inspected before extraction. Real and fake
BulletSlow branches remain distinct. BulletShotGun launches actual real shots and separate fake
presentation pellets; BulletBase's fake tween destroys its pooled object rather than running the
real hit callback. The existing server implementations retain their fast/slow/check/tail timing,
fake endpoint/duration and collision/damage separation unchanged.

No raycast, target prediction, scatter, damage, force, falloff, immunity, shield or kill-report formula
was changed by the collection extraction. The source-backed factory and engine impact routes still
own those rules. Source hashes are historical fixture provenance, not mutable current pins. Client
scripts, scenes, libraries, content identities and generated artifacts were preserved.

Snapshot ordering also remains unchanged: real shotgun bullets sorted by ID, followed by cosmetic
shotgun bullets sorted by ID, at the same location among other projectile families. This is not a
single global ID sort. Non-shotgun real bullets remain counted but absent from that shotgun-only
wire projection, preserving their prior presentation contract.

## Before/after proof and focused workflow

Before editing simulation, the original engine was captured twice with identical output. Seven
frozen scenarios contain 350 complete observations: real/cosmetic expiry and command replay,
coexisting two-owner volleys, lethal first-pellet interruption, slow miss/check/tail completion,
malformed collision abort, reconnect pause/resume and terminal cleanup. Complete framed protobuf
snapshots, replies, terminal events and clock bits still match after extraction. The temporary
capture switch was removed; normal tests cannot regenerate golden expectations.

Seven additional groups exercise captured insertion order, removal before impact dispatch, deferred
newly inserted flights, invalid-step stop/no later advancement, preserved clock exceptions,
cosmetic expiry/refusal, projection selection/order/detachment, match isolation, clear and compiled
private ownership/value-step structure. Existing connection, weapon and movement fixtures remain
separate gates.

```powershell
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-player-bullets --no-build
```

The focused gate runs in approximately one second here, without Mongo, sockets, Unity projects or
Library copies. Managed checkpoint logs remain small and temporary data is removed on success.
The selector also runs in fast/runtime/full checkpoints. These synthetic prototype fixtures do
not independently establish real weapon geometry, full combat physics or normal Unity gameplay;
full combat/native integration remain required for this simulation increment. V07 source provenance,
measured performance and actual Unity/Android execution retain separate gates.

The first integrated run, checkpoint-5ae39dd42ee840d3a49c103a492a3511, stopped after 274.7 seconds
on a stale CombatContentTests reflection field. The controlled immortal-Drone flight fixture now
seeds the new private owner rather than the removed dictionary. Its actual collision, preserved
health and enemy-contact assertions were retained. Managed focused combat-content
checkpoint-25acad5fcf0947388ec9b1d1630f472a then passed 29,180 assertions in 78.7 seconds. This exposes the
existing --combat-content-only selector through the same owned report/temp lifecycle for diagnosis.

## Verified result

Debug and Release builds passed without warnings/errors. Both configurations pass the seven frozen
bullet traces/seven owner/order groups and the existing connection, weapon and movement fixtures.
Four new C# files pass LF/width/whitespace checks. All four Client evidence sources and both original
flight algorithm source files retain their pre-extraction hashes.

The corrected integrated checkpoint-44e0506a474942f4a49126a5b1f56ae1 passed all 34 runtime/native
stages. Full battle reported 267,729 engine, admission, portable SDK, map and real two-peer UDP
assertions in 725.7 seconds. Native smoke-b7c2ed6e9c32457b9093861638b9c9a1 passed in 37.2 seconds
with 74 live Mongo/HTTP/protobuf/UDP checks and reclaimed 210,867,652 bytes after owned shutdown.
There was no simulation change between the failed reflection fixture and this passing rerun.

Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed
LOCALAPPDATA storage contains 974,212 bytes/133 files after retention, including bounded failure
diagnostics. No managed run or test Backend/Worker/battle process remains active; the original Mongo
service is preserved. No unowned history was deleted. Broader S07 ownership, C13/V02 source review,
measured performance, V07 provenance and actual Unity/Android gameplay remain separate work.
