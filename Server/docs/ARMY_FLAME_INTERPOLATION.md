# Army flame clamped interpolation (C32)

FlameAmmo.CheckHit uses Mathf.Lerp for both cone half angle and damage. The old server implemented
both expressions as unrestricted linear extrapolation. Executing the recovered Client's original
UnityEngine.dll confirms that this Mathf.Lerp clamps its input to 0..1. The correction clamps those
two inputs; it preserves the existing overlap sphere, minimum distance, facing, strict angle check,
first eligible collider order, source damage validation and clock.

## Reproduced defects

| Source-backed example | Previous server | Recovered interpolation |
| --- | --- | --- |
| Distance 2, angle 38 degrees, overlapping collider | Miss: half angle falls below 38 degrees | Hit: far half angle remains 40 degrees |
| Center at distance 3.1, source damage 60 | Damage below the source minimum | Damage 1, the configured minimum per pulse |
| Large overlapping collider centered at distance 4, source damage 60 | Negative extrapolation throws InvalidDataException | Damage 1 |

The cone uses distance^0.25 as its interpolation input. It exceeds one beyond distance one, so the
Client keeps its configured far half angle instead of narrowing it further. Damage uses
1 - distance/radius. An overlapping collider can have its center beyond the radius; the Client then
selects minimum damage instead of extrapolating below it. A collider outside the overlap volume
still misses. This does not increase the overlap radius or infer eligibility from clamped damage.

The original regression checkpoint-6ed938cacd57438693a0f839564474e4 reports both the missed far-angle
target and the invalid damage result before production edits. The latter exception reaches the
engine's existing invalid-flame-authority handling if such a collider appears during a pulse.
The large-box regression is a controlled geometry fixture, not evidence of a historical production
match termination or proof that every recovered scene presents that exact collider arrangement.

## Original managed math reference

FlameInterpolationReference verifies the original UnityEngine.dll SHA-256, loads it into a separate
test-only assembly context and calls its actual managed Mathf.Lerp through a primitive-float
delegate. The reviewed DLL is 885,248 bytes with SHA-256
e428db4e8652f5d548024ccbbb994dc1636a3c4ad374bac48e18e2fd5db6c76b. The test also checks the inspected
FlameAmmo interpolation call expressions. Source/binding hashes and the historical before-fix
server hash are recorded in tests/War.Battle.Tests/Match/Effects/flame-interpolation-provenance.json.

No Unity project, Library copy, Editor process, native physics engine or new package is required.
The DLL is read in place; no production project references or copies it. New server/SDK runtime
dependencies remain unchanged. This reference verifies the managed interpolation used here; it does
not claim to execute Unity Physics.OverlapSphere, Vector3.Angle or a complete FlameAmmo scene.

Eight groups cover the original Lerp endpoint behavior, both regressions, 440 combinations of damage/
distance/angle, physical overlap exclusion, near/cone-edge filtering, collider order and malformed
source damage. Matrix inputs use the existing server vector/overlap geometry and the original DLL
for expected interpolated values. Near-boundary floating-point geometry is not presented as a new
native Unity oracle. Existing clock and world-effect tests remain separate regression gates.

```powershell
$env:WAR_TEST_RUN_ROOT = Join-Path $env:LOCALAPPDATA 'WarFriends/ServerTests/test-runs'
dotnet build Server/WarFriendsServer.sln
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-interpolation --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-clock --no-build
python Server/scripts/verify_battle_checkpoint.py --suite focused --case army-flame-geometry --no-build
```

Green checkpoint-2f088441d0574973a348fc78502a27d5 passes the eight groups in 0.9 seconds. Debug and
Release builds pass without warnings/errors. Release also passes the source interpolation groups,
ten clock groups and 29 prior geometry assertions. Full runtime/native results for the corrected
hit/damage behavior are recorded below. Broader source geometry, state ownership, V07, throughput
and normal Unity/Android gameplay retain separate verification requirements.

## Final integrated result

checkpoint-6a501ae622a1442f85d75679c4bbec8c passed all 40 runtime/native stages. The original-math
gate passed in 0.8 seconds; full battle reported 267,803 engine/admission/portable-SDK/map/two-peer
UDP assertions in 623.2 seconds. Native smoke-95a9a8012b2447f7b5ab5f2c564ef8df passed 74 live
Mongo/HTTP/protobuf/UDP checks in 36.7 seconds, reclaiming 210,867,519 bytes after owned shutdown.
No duplicate full combat run was required. These correctness timings do not measure throughput.

Both new C# files pass LF/width/whitespace checks, and all three original binary/source/binding hashes
remain unchanged. Root .local remains 80,842 bytes and Server/.local 2,624,416,528 bytes/34,638 files.
Managed LOCALAPPDATA storage contains 937,345 bytes/118 files after retention. No managed run or test
Backend/Worker/battle process remains active; original Mongo service PID 6164 and unowned history
are preserved. C32 is complete at these two interpolation inputs; wider native geometry, ownership,
source provenance and actual Unity/Android gameplay remain separate work.
