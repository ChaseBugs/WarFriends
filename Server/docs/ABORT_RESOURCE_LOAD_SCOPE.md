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
Early Mission.LoadingStarted preparation now has the synchronous ownership gate
below. Additional effect/spawn routines and complete mode-specific cleanup still
need their own scope audit and integration proof.

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

## Early synchronous mission setup

GameController.StartGame originally called mainController.LoadingStarted before
creating its managed battle scope. Campaign and co-op controllers call
Mission.LoadingStarted from that callback; the mission starts event-unit visual
preparation without awaiting it. Those loaders therefore escaped the root scope
even after the managed iterator connections above were added.

GameController now creates the scope before LoadingStarted and invokes that
callback through RunSetup. RunSetup provides the same temporary ownership context
used by iterator steps, cancels already started loaders on setup failure, restores
the previous context in finally and preserves the original exception. If cleanup
also fails, an AggregateException retains both failures. Map loading still starts
after successful LoadingStarted, preserving the source callback-before-map order.
No mission reward, progression or entry-cost rollback is invented here.

The three Mission event/initial-unit visual start calls use StartNested. They
inherit ownership only when called from an owned setup/loader context; an old
Photon RPC callback outside that context does not become migrated merely through
this helper. Initial turret-specific rendering, legacy LoadUnitsVisualsRPC
replacement and full mission gameplay remain separate work.

UnityMissionLoadingAudit executes the original Mission.LoadingStarted using a
controlled event definition, a temporary source behaviour lookup and inactive
original LevelManager provider. It uses the existing base-level/slot probes and
actual Resources texture loads, not a replacement mission algorithm. The baseline
`Server/.local/unity-mission-loading-baseline.log` reproduced opponent visuals
being repopulated after cancellation of the unowned setup.

The owned run checks cancellation and fresh setup. Its failure control then calls
the actual GameController.StartGame entry with a controller probe dispatching to
the original mission callback: a valid first event starts loading, then a missing
second behaviour throws the original KeyNotFoundException. The start entry must
have created a scope before that callback and cancelled its pending loaders.
After clearing the partial visual, it must stay clear. A later unscoped source
load must still finish, proving the failed context did not leak ownership.
The probe restores root controller/scope fields, mission lookup and level list.

The combined Unity 2018.3 run passed without compiler errors:
`Server/.local/unity-mission-loading-owned.log`. It also passed the existing
same-host lane, fresh managed scope, native bundle completion, message handoff
and original modal gates. The protocol executable passed 1,334 checks and static
asset references retained zero missing scripts and zero broken references.
This remains component/start-entry proof, not a complete normal mission start,
full menu/profile recovery, Android, Unity 5.2 or two-client battle proof.

## Initial turret visual branches and controller continuations

The root wait for mainController.StartGame now uses StartNested through its
existing RadicalRoutine wrapper. The co-op, PvP and War Arena base StartGame
waits also retain the scope. These connections matter because a coroutine on an
independent host loses the temporary context after its first yield unless its
continuation is wrapped. This is source-reviewed/compiled wiring, not a full
native run through every controller's account, readiness and gameplay setup.

UnityInitialTurretLoadingAudit now calls original Mission.LoadInitialUnitVisuals
with base, rocket and heavy initial-unit selectors. The base-only selection must
start no special visual loader. The two special branches are dispatched after a
real coroutine frame boundary inside a scope, then cancelled and cleared. Their
caches must stay empty. A fresh scope must subsequently resolve the original
nonempty texture paths for both actual turret preparation types.

The fixture initially found preparedBehaviour unset because it deliberately
omits full pool startup. In the source, AIObjectG.PrepareInstancies obtains this
binding from LevelBehaviourManager.GetPreparedBehaviour<T>. The fixture now calls
that original selection method and restores its allocation counts. It copies
the selected original LevelBehaviour/UpgradeSlots component data onto matching
concrete types and rebinds only the cloned inactive carrier references. It does
not substitute the generic visual probes or invent visual rows for these types.
The original pool/provider fields are restored after the test.

The executed types are TurretRocketsBehaviour and HeavyTurretBehaviour, both with
UpgradeSlotsTurret. Each resolves its one original nonempty opponent texture row.
Visual component clones are activated only for preparation; carrier prefabs stay
inactive, and the sound lookup is isolated. This verifies texture-cache loading
and cancellation, not complete turret hierarchy rendering, audio, spawning,
aiming, projectile collision, damage authority or original live-service behavior.
Legacy mission Photon RPC entry points outside an owned scope remain unmigrated.

The final combined Unity 2018.3 run passed without compiler errors:
`Server/.local/unity-initial-turret-controller-final.log`. It includes both original
turret texture branches plus the existing native bundle, managed scope, mission
setup/failure and modal/message gates. The protocol executable passed 1,334
checks and the static asset audit retained zero missing scripts and zero broken
references. Full normal controller readiness/gameplay, initial-unit rendering,
legacy RPC replacement and two real Unity peers remain open.

## Cleanup callbacks and retained failure evidence

Managed iterator disposal now runs under its original battle context, including
cancellation. Previously a cleanup callback using StartNested ran outside that
context and could reopen source visual loading after cancellation. The native
fault control reproduced this by starting the real level/card visual chain from
an injected iterator's Dispose callback; see
`Server/.local/unity-resource-scope-fault-baseline.log`.

The scope now retains stop/disposal failures for its lifetime. Cancellation still
visits every recorded loader, attempts disposal even if stopping a handle fails,
and disposes each pending iterator at most once. Repeated Cancel calls continue
to report known failures instead of interpreting an empty pending list as clean
completion. GameController.StartGame therefore cannot replace a failed old scope
and run new setup through a retry. New loaders attempted during cancelled cleanup
are disposed inside the same closed context. Cleanup context is restored even
when disposal fails.

UnityResourceScopeFailureAudit uses explicit fault iterators, not corrupted source
assets. It checks a cleanup continuation against actual source visual loading,
a failing disposer followed by another pending loader, retained failure on retry,
real root start rejection before setup, and preservation of both setup and cleanup
causes. These are managed lifecycle fault controls, not proof that every recovered
loader currently throws or that arbitrary UI/native-operation errors recover.

## Quiescence before failing resource cleanup

The separate abort baseline reproduced another ordering problem: the original
confirmed-abort entry cancelled resources before stopping game time or suspending
the adapter. A managed cleanup exception could leave those states running;
`Server/.local/unity-abort-cleanup-fault-baseline.log` records that counterexample.

Confirmed abort now stops gameplay/time, clears the outcome, suspends its retained
transport owner and selects Loading/GameCancelled before managed cancellation.
Root/map coroutine stopping, atlas-scope invalidation and controller preparation
run in finally, even if managed resource cleanup reports failure. The menu/resource
recovery coroutine starts only after this stage succeeds. No failure is treated
as a terminal reward, successful cleanup or released match admission.

The routing audit injects a cleanup failure in each of the four source GameState
values. Gameplay and transport must be quiescent, ownership retained and late
outcome/new-admission paths blocked. The fixture destroys the adapter to isolate
subsequent cases; this represents forced scene teardown and does not demonstrate
automatic production recovery. Retained cleanup errors intentionally require a
new scene/session lifecycle or a future reviewed repair path. Automatic repair,
full menu/resource completion and two-client error presentation remain open.

The final fault-enabled native runs passed without compiler errors:
`Server/.local/UnityBattleVisualLoadingAudit.RunWithNativeBundleAsync-cleanup-fault-final.log`
and `Server/.local/UnityAbortRecoveryRoutingAudit.RunAsync-cleanup-fault-final.log`.
The combined run also checks real native bundle completion, original turret
texture loading, source mission setup, scoped/unscoped visual lanes and modal
handoff. Protocol regression checks passed 1,334 cases; serialized asset audits
retained zero missing scripts and zero broken references. These checks do not
close the full BattleServer, automatic repair or complete gameplay/UI gates.
