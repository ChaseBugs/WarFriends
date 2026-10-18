# Normal Assaulter Corner changes

Ordinary deployed Assaulters now leave their current Corner after the source change deadline,
reserve another free same-fraction Corner, walk its trusted route and initialize fresh arrival
clocks. Their weapon state and already launched bullets survive the move.

## Recovered behavior

`EnemyController.CornerHidingUpdate` attempts shooting first. A successful preparation clears
the hiding flag, so the point change cannot interrupt it. `ShootingFromWeapon` runs before
the state update; the final round can call `EndShooting`, restore hiding and permit a point
change in that same tick. The host therefore performs changes after preparation and volley
advancement, before updating the published animation.

`SoldierBehaviour.GetNewEnemyPoint` delegates to `SpawningManager.GetNextFreeEnemyPoint`.
It scans the original collection, filters accepted/free points, excludes the current point
and draws a uniform index. It does not sort by distance or pick the nearest alternative.
The ordinary mask is 14; the pinned five-map inventory contains eligible Corners, with no
Hiding or Car points. The candidate projection explicitly reflects that inventory boundary.

If no destination is available, the source adds ten seconds to the previous deadline. It
retains the current reservation and continues ordinary shooting. A successful transfer checks
the complete source point record and both occupancy identities before moving the reservation.
It clears completed shot/Corner presentation state, retains the rifle aim state and starts
the existing route executor. Arrival reuses the source entry transition and fresh timers.

## Verification

Release build passes with zero warnings/errors. Shared combat regression passes 26,395
assertions. `--assaulter-volley-only` passes 90 checks. The ordinary Park deployment first fills
both friendly Corners. The tracked soldier cannot move early, and an unavailable destination
adds exactly ten seconds. After the other soldier dies and releases its reservation, the tracked
soldier transfers at tick 709, publishes the walking clip, traverses a real route, enters its
new Corner and completes another automatic volley. Independent occupancy checks preserve
source order, reject an occupied destination and a forged point position, retain ownership
after rejection and release the old reservation only on a valid transfer.

The earlier repeated-volley fixture now stops its final cooldown observation before an eligible
point change can legitimately replace that Corner. It still checks exact preparation deadlines
between the tracked volleys and every strict hide/idle boundary.

This is host behavior, not normal Unity/Android controller proof. A change deadline expiring
inside an active volley, interrupted layered warm animation and full cross-map runtime parity
still need dedicated live fixtures. Original Unity NavMesh parity limits remain documented in
the navigation evidence; no new paths or scene assets were fabricated for this feature.
