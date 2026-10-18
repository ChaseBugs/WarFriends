# Gunslinger point changes after an exhausted burst

EnemyController.GunslingerUpdate changes point only after all attempts are consumed, no shot is
pending and the strict position-change clock has elapsed. Each completed shot sets that clock
to current time plus two seconds. SpawningManager.GetNextFreeEnemyPoint enumerates accepted
same-fraction points, excludes the current and occupied points, then draws once from the complete
source-ordered list. It does not select the nearest destination at this stage.

The host now follows that path after automatic shots. It constructs the new route before
releasing the old exclusive reservation, reserves the selected point, clears the completed
attempt/arrival state and begins a normal walk on the next movement tick. The actor position
is not teleported. Its mutable weapon speed and already launched projectile ledgers are retained.
At authored arrival, the source maximum attempts and strict clocks are initialized again; the
next shot uses a fresh Colt start rather than retaining the previous point's warm fire loop.
Authoritative death releases the transferred point.

If no candidate exists, the source Gunslinger has no added retry delay. The host keeps the old
reservation and deadline and checks again next tick. The normal source maximum is two Gunslingers,
with three same-fraction points on each recovered map. Consequently a full point set cannot be
constructed by ordinary deployment in the current two-player host. Tests do not widen that limit:
empty-list/no-draw behavior and a newly released candidate are checked in the selection function;
actual movement and source reservation transitions are checked through real deployments.

## Validation

The focused group passes 44 checks. Tests run a complete initial burst and verify deadline boundaries, source-ordered
selection, old/new occupancy, no teleport, retained weapon state, authored arrival, renewed attempt
counters, a fresh automatic shot and transferred-reservation death cleanup on all five maps.

| Map | First transfer tick |
| --- | ---: |
| Aztec | 458 |
| City | 430 |
| Desert | 387 |
| Park | 401 |
| Snow | 446 |

```powershell
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-points-only
```

Release build has zero warnings/errors. Existing shooting (29), navigation (50), Sickness (164)
and Assaulter volley (110) groups also pass. Shared combat regression passes 26,395 assertions. The native stand source-bound verifier remains unchanged.
The full default suite, native Unity execution and Linux runtime were not rerun for this checkpoint.

These are server execution checks, not native EnemyController/NavMesh parity or normal Client
presentation proof. Gun holstering, interrupted/failed stand preparation and remaining moving-victim
and special-target collision cases remain open. See [shooting](GUNSLINGER_SHOOTING.md) and the
[feature checklist](BATTLE_SERVER_FEATURES.md).
