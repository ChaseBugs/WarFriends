# Player bazooka retirement and replay protection

The previous presentation checkpoint removed the whole missile immediately.
The original `Missile.TryKill` stops its flight particles and hides its model,
then keeps the remaining visual hierarchy for 1.3 seconds on the owner or
0.2 seconds on a network copy. `PoolableObject.DestroyPooled(float)` uses
`Core_BaseScript.InvokeAfter` and `WaitForSeconds`, so this delay follows scaled
Unity time and freezes when timeScale is zero.

## Current behavior

`SelfHostedBazookaLifetime` owns the registered render-only missile handles.
An authenticated impact stops the copied `fireFlash` system, hides
`missilePrototype`, moves the tail to the host impact, and starts the source
owner/peer delay. The presenter's ordinary Update advances cleanup with
`Time.time`; its separate unscaled position extrapolation cannot move or expire
a retired tail. No local projectile, collision or damage script is activated.

A complete snapshot omission also retires the mesh and bounds its remaining
tail. It does not invent an explosion. An MTU-truncated omission does nothing.
If the reliable impact follows the omission, it updates the surviving tail's
position/deadline and may publish its first effect even after that tail expired.
A repeated impact does not restart the timer or replay a successful effect.

Completed identities survive tail expiry and same-match reconnect cleanup.
Old complete snapshots or frozen scans therefore cannot recreate a finished
flight. A new match/manifest scope clears those identities and the old visual
handles, allowing that match's projectile counter to restart. The first scope
assignment preserves an already-checked impact received before its first full
snapshot. The SDK connection-ownership and foreign-match guards remain the
outer boundary; this component is not a transport authenticator.

History and tracked handles are bounded at the host's 512 retained-event limit.
Every player missile consumes a Shot event, so this covers the current host
lifecycle. Capacity failure rejects before evicting completed identities.
Changing the host event retention model requires reviewing this bound too.

## Verification

`UnityBazookaLifetimeAudit.Run` passes 37 controlled component checks: owner and
peer deadlines, immediate model/emission stop, scaled/unscaled clock separation,
duplicate impacts, late snapshots/scans before and after expiry, MTU omission,
complete omission, same-match reconnect, new-match ID reuse, unseen impacts,
malformed times/coordinates and bounded completion history.

`UnityBazookaTailPlayAudit.Run` passes six real-frame checks in an empty Play
Mode scene. It registers script-free missile visuals with the actual presenter,
lets its normal Update perform cleanup, and compares against the original
`PoolableObject.DestroyPooled` coroutine with no pool attached. Both were paused
for approximately 0.404 real seconds. The owner objects disappeared at scaled
age 1.30275 on frame 254; peer objects at 0.20388 on frame 94. Source and
replacement disappeared on the same frame for both roles in this run. The gate
permits one scheduling frame and requires neither to expire before its delay.

These tools live in `Server/tools`; copy them into the disposable project's
Editor folder and invoke their Run methods with Unity batch mode, without
`-quit`. SessionState restores the Play audit across the domain reload.
`UnityPlayerBazookaPresentationAudit.Run` also still passes its seven real
families and M202 fake after updating its cleanup observation to include the
source tail. The 218 focused RPG/SDK checks and 1,144 protocol checks pass.
Asset references remain free of missing scripts and broken references; the
existing 17 NGUI mismatches remain unchanged.

This closes the previously identified immediate-retirement discrepancy and
the scoped resurrection cases above. It does not prove original pool reuse,
arbitrary event/snapshot ordering, every projectile family's replay behavior,
normal Play Mode sounds/explosion scheduling, rendered live Worker/Unity
missile flight, Android, Unity 5.2 or two actual Unity clients. B32 and the full
BattleServer objective remain open.
