# Player bazooka presentation checkpoint

The host already simulated the seven recovered bazooka families, but did not
publish their flying projectiles. The normal projectile presenter also omitted
their kinds and impact events. This checkpoint connects that missing display
path without moving trajectory, collision or damage authority into Unity.

## Source contracts

`Missile.AnimateShot` selects the model scale, big/small particles, burning
smoke and trail dimensions using `MissileSetup.missileType`. Six reviewed player
families use RpgBold; M202 uses Small. Its original `particles.Clear/Play` call
is explicit because the flight flash does not enable Play On Awake.

`Missile.TryKill` selects Medium explosions for RpgBold and Small for Small.
`Explosion.MissileExplode` plays effects before checking `isFake`, so harmless
M202 missiles still have visual explosions. The replacement calls only
`Explosion.PlayEffects` for authenticated impact presentation; it never calls
the local overlap/damage path.

## Host, protobuf and SDK

`BattleProjectileState` now includes `bazooka` and `bazooka-fake` rows with the
existing `weapon_source_id` field 10 bound at launch. The host publishes current
position and finite per-second velocity. The launch frame uses the original
aim direction; subsequent velocities derive from actual fixed-step movement.
The current seven source bindings have zero stop time.

`MatchEvent.weapon_source_id`, field 34, identifies the launch weapon on player
bazooka Shot/Impact events. This survives a slot change or an impact received
without an earlier projectile snapshot. `BazookaSourceIdentity` binds the seven
original inventory indexes. Only M202 may publish fake missiles. SDK row/event
validation rejects missing or mismatched metadata; unrelated events cannot
carry this field. Install the matching host and portable SDK together: the old
SDK did not accept player-bazooka projectile kinds.

The new rows participate in existing MTU trimming, complete frozen projectile
scans and SDK ordering rules. Reliable events retain their source identity.
No extra player-provided damage, model path or economy assertion is accepted.

## Unity display

`SelfHostedProjectilePresenter` uses the launch source rather than currentWeapon
to select the recovered inventory slot. The factory loads a reviewed render-only
resource and checks every component before instantiation. Model, materials,
particle systems, gradient and trail configuration come from the original
missile asset. An empty-controller Animator is permitted; no MonoBehaviour,
Collider, Rigidbody, Photon or combat component is permitted.

`build_player_missile_visual.py` pins the source prefab SHA-256 and removes only
its two MonoBehaviour records and their component-list entries. All remaining
serialized bytes are preserved. The original prefab and GUID remain intact.
The generated resource has a new GUID; `player-missile-visual-reference.json`
records both digests and the exact removed IDs. Verify regeneration with:

```powershell
python Server/tools/build_player_missile_visual.py --verify
```

The existing presenter applies host transforms and at most 0.1 seconds of
velocity extrapolation. It does no local missile simulation or hit testing.
Impact events remove the active mesh and select the original explosion type,
including M202 fake effects. Reconnect/teardown retains the existing cleanup.

## Verification and remaining work

Focused tests pass 218 reported checks: all seven source bindings, real/fake
flight rows, first-frame facing, reliable launch/impact metadata, rejected fake
ordinary RPGs and missing event metadata, plus two actual UDP SDK peers and a
complete frozen projectile scan. Native Mongo/HTTP/UDP smoke passes 74 live
checks and result-outbox restart recovery; protocol checks pass 1,144.
The final complete Battle executable passes 143,186 reported assertions with
the updated first-frame velocity; the solution builds with zero warnings/errors.

`UnityPlayerBazookaPresentationAudit.Run` compares decoded snapshots through the
production presenter with the original `Missile.AnimateShot` method on inactive
source controls. It covers seven real families and one M202 fake, selected while
the inventory's current slot is a rifle. Meshes, source activation/scale, trail,
explicit flight particles, bounded extrapolation and impact removal pass in
Unity 2018.3. The source controls' Awake stays uncalled. Asset reference audits
report zero missing scripts and broken references; the existing 17 NGUI sprite
mismatches remain unchanged.

The subsequent [lifetime checkpoint](PLAYER_BAZOOKA_LIFETIME.md) adds the original
owner/peer tail delays and scoped late-read suppression. Its controlled tests
and independent Play Mode source-timer comparison pass. This is not a complete
visual-parity claim: combined live Play Mode sound/explosion scheduling, rendered live
Worker/Unity missile flight, broader ordering, Android, Unity 5.2 and two actual
Unity clients remain unverified. B32 and overall completion remain open.

The [subsequent live UDP Editor checkpoint](PLAYER_BAZOOKA_LIVE_UDP.md) connects
the production Worker, SDK, adapter and normal battle bridge for five source
flights/impacts and a mid-flight slot change. It verifies component binding,
not rendered Play Mode effects or two Unity processes.

The [explosion-effects checkpoint](PLAYER_BAZOOKA_EFFECTS.md) subsequently verifies
real source sound/particle dispatch and interrupted callback replay in isolated
Play Mode. It restores two zero-length WAV container headers without changing
their PCM samples. It does not combine Play Mode effects with the live UDP run.

The [later combined Play Mode run](PLAYER_BAZOOKA_LIVE_PLAY_MODE.md) closes that
specific network/effect scheduling gap using automatic adapter Update and real
callback retry. Normal boot/input, rendered rigs and two Unity clients remain open.
