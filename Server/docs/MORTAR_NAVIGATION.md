# Ordinary Mortar navigation and construction entry

The host now moves ordinary Mortars from their real deployments to exclusive source-authored
destinations on all five multiplayer maps. Arrival captures the construction deadline and selects
the recovered construction clips. Automatic aiming/firing, position changes after firing, missile
flight/contact/explosion, construction-facing rotation and normal Unity gameplay remain required.

## Source rules

- MainScene behavior component 41188 has `enemyPointType: 4096`, the exact Mortar bit.
  `SoldierBehaviour.GetInitPoint` uses `SpawningManager.GetPoint`: nearest free accepted point,
  preserving the source collection order for equal distances and accepting only the same fraction.
- `EnemyPointMortar.Awake` selects the Mortar state. `EnemyPoint.IsEnemyPointReached` requires
  planar distance strictly below 0.04; route projection must not widen that threshold.
- The five map collections contain forty Mortar points, four per fraction on every map. The
  ordinary deployment definition permits at most two Mortars; no supported card spawn owns this
  mask. Exhausting all four points is therefore an inconsistent current host state, not a reason
  to fabricate a destination or silently share occupancy.
- `UpgradeSlotsMortar.LoadDefinitionFromXLS` adds `mortarBuildTime` from each selected lane.
  The validated `Google2u.DBUpgradeSlotsMortar` data has 33 rows: normal rows contribute two
  seconds and the supported special rows zero. The host reads these fields rather than imposing
  a separate timer policy. Existing upgrade validation still decides which rows are selectable.
- `EnemyController.SwitchStateToMortar` stops the soldier and starts building. The next action
  requires `mTime > mNextShootTime`; the host records the first eligible fixed tick after that
  deadline. This checkpoint records eligibility but does not execute `FireMortar`.
- `SoldierAnimationController.BuildMortar` plays `mortar_down` and queues `mortar_down_idle`.
  The host uses the recovered clip length and the existing tick-based infantry pose projection.
  This is not a native queued-animation/update-order or construction-rotation acceptance run.

## Native destination evidence

`extract_mortar_points.py` extracts the unit mask and all forty ordered scene points without
editing the Client. `recovered-mortar-points.json` is revision
`35142d2aece4eb37886f484d8dad66df31f187e949269df3de537bb2edae13f5`.

`UnityMortarPointAudit.Run` sampled all forty points with the original five NavMeshData assets
in the disposable Unity 2018.3.0f2 project. The audit exited zero. Each copied NavMesh asset
matched the corresponding active Client file byte-for-byte. Every native sample preserved X/Z;
only height changed. The earlier generic Euclidean triangle projection shifted an Aztec endpoint
about eight centimeters and prevented the Client's four-centimeter arrival condition.

The native detail-mesh height also differs slightly from interpolation over exported coarse
triangles. The host therefore binds the forty measured native endpoints directly, rather than
claiming those triangles reproduce exact native height. The normalized LF reference is
`mortar-points-unity-reference.json`, revision
`ab74aeff6a18b3c9c822089247600cec22df8fef1343cda59acbe58c2dc7c5d1`.
Both JSON artifacts have explicit LF checkout rules so their byte revisions remain stable on
Windows and Linux. The native exporter also writes LF.

`MortarPointCatalog` validates bounded input size, both complete revisions, unit/scene identity,
point counts/order/transforms, unique native bindings, matching authored positions and vertical-only
native offsets before publishing immutable destinations. The native sample is used only as the
fixed destination. Existing spawn sampling and general corridor/motion behavior remain as before;
this does not claim exact native agent motion, avoidance, intermediate height or frame timing.

## Verification boundary

The focused Mortar group passes 212 checks: previous weapon/Sickness setup plus twenty naturally
arriving ordinary Mortars across both fractions on all five maps, nearest free destination selection,
walking/construction clips, strict construction deadlines, exclusive occupancy and death cleanup,
altered source-byte rejection, and all forty native endpoint bindings. Arrival ticks range from
261 to 412 in these fixtures. Soldiers are neither teleported nor assigned artificial arrival points.

The source extractor's `--check` passes. The .NET solution build passes with zero warnings/errors.
The full default Battle suite exited zero with 248,137 engine, admission, portable SDK, geometry
and real two-peer UDP assertions. Its local log is `Server/.local/mortar-navigation-full.log`.
Native evidence is static Unity NavMesh sampling, not a native moving-agent or normal game session.
It does not prove original Unity 5.2.5 parity, Android or Linux runtime behavior. The private package
manifest was restored byte-for-byte after the owned Unity audit exited; active Client assets,
settings and concurrent library edits were untouched.

Next, connect source construction-facing rotation, `FireMortar`/`PrepareToShoot` timing and target
selection, the delayed overhead missile, authoritative contact/explosion results, post-shot movement,
SDK presentation and the actual Unity battle controllers. SICKNESS activation and inventory
consumption remain separately incomplete.
