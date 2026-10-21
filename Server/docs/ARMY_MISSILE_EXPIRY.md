# Straight army missile expiry priority

C33 corrects the order of expiry and collision in CardRocketMissileFlight.Advance, the straight
flight model shared by Rocket Soldier, BIGROCKET and Mortar. The recovered 1.4.0 Missile.Update
first advances progress/position, then expires a straight missile when progress is strictly greater
than three. TryKill explodes at that advanced position and sets mExploded. The later !mExploded
guard therefore prevents CheckHit in the same frame. The server previously queried collision first.

## Reproduction and resulting behavior

A controlled one-unit path at speed thirty advances one whole path per thirty-Hz frame. Frame one
arms collision after movement; frames two and three remain live. On frame four, the source expires
at four units and performs no ray query. The old server could instead select a synthetic collision
at 3.1 units and expose its collider to direct/explosion routing. It could also throw for damaged
collision authority that the source would never have queried. This is a valid isolated regression,
not evidence of an observed historical live-player incident.

The unchanged expiry branch now runs immediately after finite-position validation and before the
collision branch. It returns null Collision at the advanced endpoint with the same projectile,
soldier, tick and fake identity. Exact progress three remains live. Earlier valid collisions still
win. Tick validation, finite position/collision checks, source target cap, movement/velocity,
Mortar negative progress/stop time, arming, ray length, source damage, shared capacity and paired
ownership remain unchanged. Reversing only the moved block/comment exactly reconstructs the
recorded pre-fix model SHA-256. No baseline or recovered Client file was rewritten.

## Evidence and small verification

MissileExpiryReference pins the complete Client Missile.cs hash and checks the reviewed Fire,
AnimateShot, Update and TryKill expressions in their original order. It translates only straight
progress, expiry and collision eligibility into a managed thirty-Hz reference. System.Numerics
geometry and synthetic ray candidates are test inputs. This is source-anchored control-flow proof,
not execution of the original Unity method, native Physics.Raycast or a complete scene/pause/curved-
trajectory oracle. The source/binding/owner hashes and historical red-run inputs are recorded in
tests/War.Battle.Tests/Match/Projectiles/missile-expiry-provenance.json.

Before production edits, checkpoint-ab6a957927a4479ab66f15eb60f55b67 fails six groups: real, fake and
Mortar expiry, forbidden expired callbacks, differential matrix and paired-owner completion.
Boundary/arming and authority guards already pass. After correction,
checkpoint-35bc328753db495c98896b91e9aaee8a passes all eight groups in 0.8 seconds. Fifty differential
matrix scenarios cover six path lengths, four speeds, real/fake cases and overhead Mortar stops.
Other groups check exact progress three, earlier collisions, skipped/duplicate ticks, non-finite or
oversized launch input, malformed pre-expiry collision and completion through the paired owner.
All ten existing frozen Rocket/Mortar engine traces and eight ownership groups remain unchanged.

From the repository root after a successful Debug solution build:

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-missile-expiry --no-build
```

This case also runs in fast/runtime checkpoints. It reads existing source files in place and creates
no Unity project, Library, package or runtime dependency. Managed logs use the normal bounded
retention policy. See [TESTING.md](TESTING.md) for final integrated verification. One avoided expired
ray is a direct behavior consequence; measured calculation/network performance remains P01 work.
Normal Unity/Android gameplay and wider V02 physics/lifecycle fidelity retain separate gates.

Final Debug/Release builds pass without warnings/errors. Managed Release run
missile-expiry-release-f6951266e29e453a89db905f3d67120b passes all thirteen selected cases, including
the new eight groups, every earlier frozen ownership trace and flame clock/interpolation/geometry
gates. Both new files pass LF/width/whitespace checks; ordinary methods are at most 36 lines.
The two Client sources, source binding and paired-owner hashes remain unchanged.

Final checkpoint-cadb083878da4be6850b529aeecc50e0 passes all 43 runtime/native stages, including
the expiry gate in 0.9 seconds and 267,867 full battle assertions in 627.0 seconds. Native
smoke-3a013c82c97146c9a80c310abf247854 passes 74 live checks in 36.6 seconds, reclaiming 210,867,748
bytes after owned shutdown. External retained managed evidence is under one megabyte; no test host
remains active. Historical workspace data and original Mongo service PID 6164 remain preserved.
C33 is complete at its priority scope; wider ownership, physics/gameplay and performance stay open.
