# PvP ordinary and bonus grenade ownership

This sixth S07 increment gives equipped grenade flights and bonus/card grenade flights separate
owners in Match/Projectiles. They have different collision/explosion timing and failure boundaries.
MatchEngine retains command authority, animation/ammunition publication, shared IDs/capacity, source
flight construction, card receipts/burst scheduling, world damage and terminal publication.

| Type | Responsibility |
| --- | --- |
| PvpPlayerGrenadeSystem | Equipped flight membership, captured advancement, completion, snapshots and clear |
| PvpGrenadePayload / PvpGrenadeStep | Immutable stage/binding/source metadata and impact/invalid-authority observations |
| PvpBonusGrenadeFlightSystem | Bonus/card flights, pending collisions, explosion quote preflight and frame observations |

The old engine collections and nested equipped-grenade record are removed. Owners never return
stored mutable flights. Frame cursors and equipped payload/step observations are value types;
captured arrays and existing flight objects remain. This describes ownership, not measured speedup.

## Equipped grenades

The source throw animation still launches the flight before ammunition, shot counters, fire deadlines
and events change at their original engine points. The captured frame follows insertion order and
skips flights launched in the current tick. Completion removes the flight before the engine observes
its impact and applies the existing explosion algorithm. InvalidDataException/InvalidOperationException
still select invalid-projectile-authority and stop later processing. Terminal hits stop the frame.

Snapshots remain ID-sorted in the same projectile-family position, retaining grenade/grenade-molotov
kinds and the original empty wire WeaponSourceId. Launch-bound source metadata is retained privately
for world effects. Snapshot rows are detached. Terminal cleanup clears equipped flights at the same
point as before extraction. GrenadeFlight and the ordinary explosion formulas were not changed.

## Bonus/card grenades

GrenadeAmmoBase's zero-second fuse explodes in the following Update, reading the shared setup then.
CardGrenadesBurst/KillStreakBonusGrenades can change that setup after launch or collision. Quotes
therefore use the current burst-clock damage when pending collisions are processed, not a frozen
launch-time value. The existing bonus explosion policy remains unchanged.

Each frame retains these steps:

1. Reset current collision observations; validate every pending explosion quote before clearing any
   pending collision or replacing the previous explosion observations. Failed preflight preserves
   pending capacity and the previous explosion list.
2. Apply prepared world explosions in order, stopping if terminal. Capture active flights only after
   these effects, at the original engine capture point.
3. Advance captured flights in insertion order. A collision removes its active flight and adds its
   pending explosion before emitting the existing impact event. Active plus pending counts once
   against the same shared budget.
4. Validate/create ready shots and emit launches using the existing engine logic. Publish the new
   read-only collision list only after all captured flights and ready launches succeed. A failed,
   incomplete or already-published frame cannot publish partial observations.

Flight exceptions retain their original type and the engine's invalid-pvp-grenade-authority outcome.
Snapshot rows remain sorted, detached and marked pvp-bonus-grenade with the prior empty source field.
Idle observation reset does not erase flight/pending authority.

The prior engine retains bonus/card grenade state when a match becomes terminal, while equipped
grenades are cleared. Extraction deliberately preserves that server behavior. The terminal-freeze
trace documents an existing boundary; it does not certify Client intent. V02 must determine the
correct terminal presentation/cleanup contract before changing it. No new confirmed bug is claimed.

## Before/after proof and focused testing

Before production edits, the original engine was captured twice with identical output. Seven frozen
source-bound scenarios contain 1,075 observations: FRAG/M320/Molotov animation, launch, ammunition,
replay and impact; equipped terminal cleanup; three Cluster Grenade collisions followed by three
next-frame explosions; prior bonus terminal retention; and reconnect pause with live bonus flights.
Full framed snapshots/replies/terminal events and exact clock bits still match. The temporary capture
switch was removed; normal tests cannot regenerate expected hashes.

Eight owner/order groups additionally check insertion order, removal-before-observation, launch-tick
skip, invalid-frame stop, sorted detached snapshots, isolation, active-to-pending conservation,
late shared damage reads, immutable previous observations, failed preflight, partial-frame failure,
capture boundaries and compiled ownership/value types. Historical hashes in the provenance file
record capture inputs; they are not current-file pins after intentional extraction/formatting.

```powershell
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case pvp-grenades --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenade-combat --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case grenades-burst-udp --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case bonus-grenade-policy --no-build
```

The first case needs no Mongo, socket, Unity project or Library copy. All cases use managed logs/temp
and the existing bounded retention policy. Final state checkpoint-4778be54a0774f179006935c1cdb6bc9
passes seven unchanged traces and eight groups in 3.0 seconds. Existing grenade-combat
checkpoint-c459607ba06f4f94878a6babd08f2515 passed 49,470 source grenade assertions in 34.3 seconds;
grenades-burst-udp checkpoint-b271b93a30854911a32e7c5485ebffcb passed 13 real Cluster Grenade UDP
checks in 8.8 seconds; bonus-grenade-policy checkpoint-620a247d8b5a490fb33c29970094c91f passed
74 shared-setup assertions in 2.9 seconds. Source-bound simulation/SDK checks do not certify normal
Unity/Android gameplay, V07 provenance or comparative throughput. Broader S07 remains open.

## Final integrated result

checkpoint-88d706b901d54a98bc50b94fe1dc86ef passed all 36 runtime/native stages. The full battle stage
reported 267,793 engine/admission/portable-SDK/map/two-peer UDP assertions in 621.6 seconds. Native
smoke-1c8fe4262fd6406aa6881d3fe6b17382 passed in 36.8 seconds with 74 live Mongo/HTTP/protobuf/UDP
checks and reclaimed 210,895,041 bytes after owned shutdown. No duplicate full combat run was needed.

Historical root .local remains 80,842 bytes and Server/.local 2,835,453,402 bytes. Managed LOCALAPPDATA
storage contains 527,459 bytes/128 files after retention. No managed run or test Backend/Worker/battle
process remains active; original Mongo service PID 6164 is preserved. No unowned history was deleted.
Global frames, impact orchestration, other projectile/army/vehicle/air/card/status/collision/projection
owners, V02 terminal intent, performance, V07 and normal Unity/Android retain separate completion gates.
