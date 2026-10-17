# Battle-owned managed resource loading

## Source counterexample

LevelBehaviour.PrepareVisualsForCardCoroutine starts the slot loader on its own
component. The slot loader then starts individual TechnologyVisualDefinition
loaders on UpgradeSlots. Each texture read is synchronous Resources.Load, but
sequential StartCoroutine/yield boundaries let later definitions run on later
frames. Stopping the root loader does not stop independently hosted children.
A later child can therefore repopulate visuals after NullCardVisuals cleared them.

The controlled native baseline reproduced that source behavior:
`Server/.local/unity-battle-visual-loading-baseline.log`. It loaded the first of
two real source visual definitions, cleared the mine lane, cancelled only the
tracked root and observed the untracked nested loader repopulating the lane.
The texture asset is a disposable Resources fixture, not invented player state.

## Explicit ownership

BattleResourceLoadScope records a host and coroutine handle for each managed
battle loader. GameController.StartGame creates a fresh scope for its map/start
iterator. The reviewed upgrade, card and weapon preparation chains use
StartNested to retain that ownership across their independent hosts.

Ownership is carried only while one iterator MoveNext executes on Unity's
thread. StartNested called inside that step registers the child with the same
scope. Between steps the previous context is restored, including on exceptions.
An ordinary army/menu preview started outside a battle scope uses the original
StartCoroutine behavior and is not added to the battle's pending list.

Confirmed abort cancels the retained scope before resource release. Cancellation
stops each exact recorded handle and disposes its iterator once. It also handles
already completed synchronous children and repeated cancellation. Cleanup errors
are collected so other recorded loaders are still visited, then reported; they
must not release admission through an apparently successful abort. A cancelled
scope cannot start another child. A fresh battle receives a different scope.

Native map operations and atlas bundle operations retain their separate drain
and publication-scope handling. An empty managed PendingCount is not proof that
native loading, scene teardown or menu restoration has completed.

## Reviewed source connections

The GameController battle-load chain now tracks upgrade preparation, selected
local/opponent/friend cards and weapon inventory loading. Its nested links cover:

- UpgradesManager and LevelBehaviour visual preparation.
- UpgradeSlots base, base-soldier, engineer and vehicle loaders.
- SoldierBehaviour and EnemyBasicInventory weapon/model preparation.
- CardManager.InitGameCards and CardSpawnUnit/heavy-turret/rocket-turret InitCard.
- CardBuddy weapon preparation and WeaponInventory's AssetBundleManager-hosted
  PlayerWeapon loader.

Only loading calls in those paths were changed. ArmyPreviewCamera and other
unscoped preview entry points retain ordinary coroutine ownership. Native gates
below exercise the base level/card-visual path; compiling the other connections
and inspecting their call sites is not full native execution of every variant.
Mission-triggered preparation, additional effect/spawn routines and complete
mode-specific cleanup still need their own scope audit and integration proof.

## Native verification

UnityBattleVisualLoadingAudit uses original base level/slot/card-visual methods.
The two runtime probes omit unrelated upgrade economy initialization and provide
only required abstract members. Source TechnologyVisualDefinition performs the
actual Resources.Load and NullMine/NullOpponent mutations.

The final test runs an unscoped opponent-lane loader on the same LevelBehaviour
host as the pending battle loader. After clearing and cancelling the battle
lane, the old mine lane must remain empty, the unscoped lane must finish, and a
new scope must load the mine lane successfully with zero tracked pending jobs.
This is an unscoped visual-lane control, not a rendered ArmyPreviewCamera proof.

UnityAbortRecoveryRoutingAudit seeds a pending managed scope in each of the four
source GameState cases and requires confirmed abort to empty it. That test still
stops before the complete resource/menu recovery coroutine.

Full profile/menu initialization, every card/unit variant, callback failure/retry,
two real Unity peers, source Unity 5.2 and Android remain open. No reward, price,
progression or outcome authority is supplied by this loading scope.

## Checkpoint evidence

The final combined native run passed without compiler errors:
`Server/.local/unity-battle-resource-same-host-final.log`. It includes the corrected
same-host control, fresh managed scope, real in-flight atlas bundle completion,
message entry/queue handoff and original modal cycles. The confirmed-abort
routing check passed separately in
`Server/.local/UnityAbortRecoveryRoutingAudit.RunAsync-resource-scope.log`.

The protocol executable passed 1,334 checks. Static audits retained 2,376 asset
documents, 23,513 components and 288,165 serialized references with zero missing
scripts and zero broken references. The seventeen original NGUI atlas selections
remain unmatched. The helper adds a new source/meta identity; existing source
GUIDs, scenes, prefabs and serialized component payloads were preserved.
